'<root>
Imports System.IO
Imports System.Xml.Serialization
<Serializable(), XmlInclude(GetType(Agent))>
<XmlRoot("root")>
Public Class FacturationConfig
    Private _isActive As Boolean
    '    <isActive>True</isActive>
    Public Property isActive() As Boolean
        Get
            Return _isActive
        End Get
        Set(ByVal value As Boolean)
            _isActive = value
        End Set
    End Property
    Private _siren As String
    '   <siren>444681705</siren>
    Public Property siren() As String
        Get
            Return _siren
        End Get
        Set(ByVal value As String)
            _siren = value
        End Set
    End Property
    Private _tva As String
    '    <tva>444681705111222333</tva>
    Public Property tva() As String
        Get
            Return _tva
        End Get
        Set(ByVal value As String)
            _tva = value
        End Set
    End Property
    Private _rcs As String
    '    <rcs> RCS01</rcs>
    Public Property rcs() As String
        Get
            Return _rcs
        End Get
        Set(ByVal value As String)
            _rcs = value
        End Set
    End Property
    '    <footer> Pied de Page</footer>
    Private _footer As String
    Public Property footer() As String
        Get
            Return _footer
        End Get
        Set(ByVal value As String)
            _footer = value
        End Set
    End Property
    '    <logo></logo>
    Private _logo As String
    Public Property logo() As String
        Get
            Return _logo
        End Get
        Set(ByVal value As String)
            _logo = value
        End Set
    End Property
    '    <logo_tn></logo_tn>
    Private _logo_tn As String
    Public Property logo_tn() As String
        Get
            Return _logo_tn
        End Get
        Set(ByVal value As String)
            _logo_tn = value
        End Set
    End Property
    '</root>

    Public Sub New()
        isActive = False
        siren = ""
        Me.tva = ""
        Me.rcs = ""
        Me.logo = ""
        Me.logo_tn = ""
        Me.footer = ""
    End Sub

    Public Shared Function WriteXml() As Boolean
        Dim bReturn As Boolean
        Dim strXMLFile As String = Globals.GLOB_STR_FACTURATIONCONFIG_FILENAME

        Try
            Dim oParam As New FacturationConfig()
            Dim ns As New XmlSerializerNamespaces()
            ns.Add("", "")

            Using objStreamWriter As StreamWriter = New StreamWriter(strXMLFile)
                Dim x As XmlSerializer = New XmlSerializer(oParam.GetType)
                x.Serialize(objStreamWriter, oParam, ns)
            End Using
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FacturationConfig.WriteXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                CSDebug.dispError("Facturationconfig.WriteXML: " & ex.InnerException.Message)
            End If
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class
