Imports System.Xml.Serialization
Imports System.Collections
Imports System.IO
Imports System.Collections.Generic
<Serializable()>
Public Class ParamDiag

    Private _id As String
    Private _libelle As String
    Private _fichierConfig As String
    Private _ParamCalc833 As New ParamDiagCalc833()
    Private _ParamCalc542 As New ParamDiagCalc542()
    Private _ParamCalc922 As New ParamDiagCalc922()

    Public Sub New()
        _id = ""
        _libelle = ""
        _fichierConfig = ""
    End Sub
    Public Property id As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property
    Public Property libelle As String
        Get
            Return _libelle
        End Get
        Set(value As String)
            _libelle = value
        End Set
    End Property
    Public Property fichierConfig As String
        Get
            Return _fichierConfig
        End Get
        Set(value As String)
            _fichierConfig = value
        End Set
    End Property

    Public Property ParamDiagCalc542 As ParamDiagCalc542
        Get
            Return _ParamCalc542

        End Get
        Set(value As ParamDiagCalc542)
            _ParamCalc542 = value
        End Set
    End Property
    Public Property ParamDiagCalc833 As ParamDiagCalc833
        Get
            Return _ParamCalc833

        End Get
        Set(value As ParamDiagCalc833)
            _ParamCalc833 = value
        End Set
    End Property
    Public Property ParamDiagCalc922 As ParamDiagCalc922
        Get
            Return _ParamCalc922

        End Get
        Set(value As ParamDiagCalc922)
            _ParamCalc922 = value
        End Set
    End Property


    ''' <summary>
    ''' Lecture dy fichier XML et retour d'une Liste de paramétre
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function readXML() As List(Of ParamDiag)
        Dim oReturn As New List(Of ParamDiag)
        Dim strXMLFile As String = "./moduleDocumentaire/_parametres/ParamDiag.xml"
        Try
            Dim oParam As New List(Of ParamDiag)
            Dim objStreamReader As New StreamReader(strXMLFile)
            Dim x As New XmlSerializer(oParam.GetType)
            oReturn = x.Deserialize(objStreamReader)
            objStreamReader.Close()
        Catch ex As Exception
            Debug.Print("ParamDiag.readXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("ParamDiag.readXML: " & ex.InnerException.Message)
            End If
        End Try
        Return oReturn
    End Function

    Public Shared Function writeXml(pLstParamDiag As List(Of ParamDiag)) As Boolean
        Dim bReturn As Boolean
        Dim objStreamWriter As StreamWriter = Nothing
        Dim strXMLFile As String = "./moduleDocumentaire/_parametres/ParamDiag.xml"

        Try
            Dim oParam As New List(Of ParamDiag)
            Dim ns As New XmlSerializerNamespaces()
            ns.Add("", "")

            objStreamWriter = New StreamWriter(strXMLFile)
            Dim x As New XmlSerializer(oParam.GetType)
            x.Serialize(objStreamWriter, pLstParamDiag, ns)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            Debug.Print("ParamDiag.WriteXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("ParamDiag.WriteXML: " & ex.InnerException.Message)
            End If
            bReturn = False
            If objStreamWriter IsNot Nothing Then
                objStreamWriter.Close()
            End If


        End Try
        Return bReturn
    End Function



End Class
