Imports System.Xml.Serialization
Imports System.Collections
Imports System.IO
Imports System.Collections.Generic

Public Class ListOfCodeAPE
    Private m_lst As New List(Of CodeAPE)

    Public Property lst As List(Of CodeAPE)
        Get
            Return m_lst
        End Get
        Set(ByVal value As List(Of CodeAPE))
            m_lst = value
        End Set
    End Property
    Public Function writeXml(ByVal strFileName As String) As Boolean
        Dim bReturn As Boolean
        Dim objStreamWriter As StreamWriter = Nothing
        Try

            objStreamWriter = New StreamWriter(strFileName)
            Dim x As New XmlSerializer(Me.GetType)
            x.Serialize(objStreamWriter, Me)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ListOfCodeAPE.WriteXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("ListOfCodeAPE.WriteXML: " & ex.InnerException.Message)
            End If
            bReturn = False
            If objStreamWriter IsNot Nothing Then
                objStreamWriter.Close()
            End If


        End Try
        Return bReturn
    End Function


    Public Function readOldFile(ByVal pxmlFile As CSXml)
        Dim x As Xml.XmlNode = pxmlFile.getXmlNode("/root")
        Dim oCodeAPE As CodeAPE

        For Each oNode As Xml.XmlNode In x.ChildNodes
            oCodeAPE = New CodeAPE
            oCodeAPE.Libelle = oNode.Item("libelle").InnerText
            oCodeAPE.LibelleLong = oNode.Item("libelle_long").InnerText
            m_lst.Add(oCodeAPE)
        Next

    End Function
End Class

Public Class CodeAPE

    Private m_Libelle As String
    Private m_libelleLong As String

    Public Property Libelle As String
        Get
            Return m_Libelle
        End Get
        Set(ByVal value As String)
            m_Libelle = value
        End Set
    End Property

    Public Property LibelleLong As String
        Get
            Return m_libelleLong
        End Get
        Set(ByVal value As String)
            m_libelleLong = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property LibelleComplet As String
        Get
            Return m_Libelle & " " & m_libelleLong
        End Get
        Set(ByVal value As String)
        End Set
    End Property

End Class
