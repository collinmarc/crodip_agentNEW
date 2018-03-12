Imports System.Xml.Serialization
Imports System.Collections
Imports System.IO
Imports System.Collections.Generic
''' <summary>
''' Classe paramètre du ReglagePulve
''' Cette classe utilise la serialisation XML
''' </summary>
''' <remarks></remarks>
<Serializable()>
Public Class RPParam

    Protected Shared m_xmlfileName As String = "RPParam.xml"

    Private m_reference As String = ""
    Private m_ImagePath As String = ""
    Private m_ReportPath As String = ""
    Private m_bSectionEntete As Boolean = True
    Private m_bSectionDefauts As Boolean = False
    Private m_bSectionCommentaires As Boolean = False
    Private m_bSectionSyntheseMesures As Boolean = False
    Private m_bSectionSyntheseBuses As Boolean = False
    Private m_bSectionSynthese833 As Boolean = False
    Private m_bSectionSynthese542 As Boolean = False
    Private m_bSectionSyntheseCapteurVitesse As Boolean = False
    Private m_bSectionSyntheseCapteurDebitMetre As Boolean = False
    Private m_bSectionCalculs As Boolean = False

    Public Property bSectionEntete As Boolean
        Get
            Return m_bSectionEntete
        End Get
        Set(ByVal value As Boolean)
            m_bSectionEntete = value
        End Set
    End Property
    Public Property bSectionDefauts As Boolean
        Get
            Return m_bSectionDefauts
        End Get
        Set(ByVal value As Boolean)
            m_bSectionDefauts = value
        End Set
    End Property
    Public Property bSectionCommentaires As Boolean
        Get
            Return m_bSectionCommentaires
        End Get
        Set(ByVal value As Boolean)
            m_bSectionCommentaires = value
        End Set
    End Property
    Public Property bSectionSyntheseMesures As Boolean
        Get
            Return m_bSectionSyntheseMesures
        End Get
        Set(ByVal value As Boolean)
            m_bSectionSyntheseMesures = value
        End Set
    End Property
    Public Property bSectionSyntheseBuses As Boolean
        Get
            Return m_bSectionSyntheseBuses
        End Get
        Set(ByVal value As Boolean)
            m_bSectionSyntheseBuses = value
        End Set
    End Property
    Public Property bSectionSynthese833 As Boolean
        Get
            Return m_bSectionSynthese833
        End Get
        Set(ByVal value As Boolean)
            m_bSectionSynthese833 = value
        End Set
    End Property
    Public Property bSectionSynthese542 As Boolean
        Get
            Return m_bSectionSynthese542
        End Get
        Set(ByVal value As Boolean)
            m_bSectionSynthese542 = value
        End Set
    End Property
    Public Property bSectionSyntheseCapteurVitesse As Boolean
        Get
            Return m_bSectionSyntheseCapteurVitesse
        End Get
        Set(ByVal value As Boolean)
            m_bSectionSyntheseCapteurVitesse = value
        End Set
    End Property
    Public Property bSectionSyntheseCapteurDebit As Boolean
        Get
            Return m_bSectionSyntheseCapteurDebitMetre
        End Get
        Set(ByVal value As Boolean)
            m_bSectionSyntheseCapteurDebitMetre = value
        End Set
    End Property

    Public Property bSectionCalculs As Boolean
        Get
            Return m_bSectionCalculs
        End Get
        Set(ByVal value As Boolean)
            m_bSectionCalculs = value
        End Set
    End Property
    Public Sub New()
        m_xmlfileName = "RPParam.xml"
    End Sub
    Public Shared Property xmlFileName As String
        Get
            Return m_xmlfileName
        End Get
        Set(value As String)
            m_xmlfileName = value
        End Set
    End Property
    ''' <summary>
    ''' Reference de l'agent 
    ''' (Propriété sauvegardée en XML)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ReferenceAgentToXML_ As String
        Get
            Return m_reference
        End Get
        Set(value As String)
            m_reference = value
        End Set
    End Property
    ''' Cette propiété ne sera pas sauvegardé dans le fichier XML
    ''' mais elle est basée sur le même attribut que ReferenceAgentToXML
    ''' Elle remplave les CRLF par des | pour pouvoir les stocker en xml
    <XmlIgnore()>
    Public Property ReferenceAgent As String
        Get
            Return m_reference.Replace("|", vbCrLf)
        End Get
        Set(value As String)
            m_reference = value.Replace(vbCrLf, "|")
        End Set
    End Property
    Public Property ImagePath As String
        Get
            Return m_ImagePath
        End Get
        Set(value As String)
            m_ImagePath = value
        End Set
    End Property
    Public Property ReportPath As String
        Get
            Return m_ReportPath
        End Get
        Set(value As String)
            m_ReportPath = value
        End Set
    End Property

    Public Function writeXML() As Boolean
        Return RPParam.writeXML(Me)
    End Function


    ''' <summary>
    ''' Lecture du fichier XML et retour d'un Object
    ''' (Nothing if fails)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function readXML() As RPParam
        Dim oReturn As New RPParam()
        Dim objStreamReader As StreamReader = Nothing
        Try
            If System.IO.File.Exists(RPParam.xmlFileName) Then

                objStreamReader = New StreamReader(m_xmlfileName)
                Dim x As New XmlSerializer(oReturn.GetType)
                oReturn = x.Deserialize(objStreamReader)
            End If
        Catch ex As Exception
            Debug.Print("RPParam.readXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("RPParam.readXML: " & ex.InnerException.Message)
            End If
            oReturn = Nothing
        Finally
            If objStreamReader IsNot Nothing Then
                objStreamReader.Close()
            End If
        End Try
        Return oReturn
    End Function
    ''' <summary>
    ''' Ecriture dans le fichier XML
    ''' </summary>
    ''' <param name="pRpParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function writeXml(pRpParam As RPParam) As Boolean
        Dim bReturn As Boolean
        Dim objStreamWriter As StreamWriter = Nothing

        Try
            Dim oParam As New List(Of CRODIP_ControlLibrary.ParamDiag)
            Dim ns As New XmlSerializerNamespaces()
            ns.Add("", "")

            objStreamWriter = New StreamWriter(m_xmlfileName)
            Dim x As New XmlSerializer(pRpParam.GetType)
            x.Serialize(objStreamWriter, pRpParam, ns)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            Debug.Print("pRPParam.WriteXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("pRPParam.WriteXML: " & ex.InnerException.Message)
            End If
            bReturn = False
        Finally
            If objStreamWriter IsNot Nothing Then
                objStreamWriter.Close()
            End If

        End Try
        Return bReturn
    End Function




End Class
