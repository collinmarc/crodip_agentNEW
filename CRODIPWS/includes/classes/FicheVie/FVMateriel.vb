Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(FVMateriel))> _
Public MustInherit Class FVMateriel

    Private _id As String
    Private _type As String
    Private _auteur As String
    Private _idAgentControleur As Integer
    Private _caracteristiques As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String
    Private _FVFileName As String
    Private _dateModif As String
    Private _blocage As Boolean
    'Private _idBancMesure As String
    'Private _blocage As Boolean
    'Private _pressionControle As String
    'Private _valeursMesurees As String
    'Private _idManometreControle As String
    'Private _idBuseEtalon As String

    Public Const FVTYPE_MISENSERVICE As String = "MISEENSERVICE"
    Public Const FVTYPE_PREMIEREUTILISATION As String = "PREMIERE-UTILISATION"
    Public Const FVTYPE_DESACTIVATION As String = "DESACTIVATION"
    Public Const FVTYPE_SUPPRESSION As String = "SUPPRESSION"
    Public Const FVTYPE_CONTROLE As String = "CONTROLE"

    Sub New()
        _FVFileName = ""
    End Sub
    Sub New(ByVal pAgent As Agent)
        idAgentControleur = pAgent.uid
    End Sub

    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
        End Set
    End Property


    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public Property auteur() As String
        Get
            Return _auteur
        End Get
        Set(ByVal Value As String)
            _auteur = Value
        End Set
    End Property

    Public Property idAgentControleur() As Integer
        Get
            Return _idAgentControleur
        End Get
        Set(ByVal Value As Integer)
            _idAgentControleur = Value
        End Set
    End Property

    Public Property caracteristiques() As String
        Get
            Return _caracteristiques
        End Get
        Set(ByVal Value As String)
            _caracteristiques = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateModif() As String
        Get
            Return _dateModif
        End Get
        Set(ByVal Value As String)
            _dateModif = Value
        End Set
    End Property
    <XmlElement("dateModif")>
    Public Property dateModifS() As String
        Get
            Return CSDate.GetDateForWS(_dateModif)
        End Get
        Set(ByVal Value As String)
            _dateModif = Value
        End Set
    End Property


    Public Property blocage() As Boolean
        Get
            Return _blocage
        End Get
        Set(ByVal Value As Boolean)
            _blocage = Value
        End Set
    End Property


    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property

    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationAgent)
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationCrodip)
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property
    Public Property FVFileName() As String
        Get
            Return _FVFileName
        End Get
        Set(ByVal Value As String)
            _FVFileName = Value
        End Set
    End Property

    Public MustOverride Function Fill(ByVal pColName As String, ByVal pColValue As Object) As Boolean

    Protected Function FillCommun(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case pColName.ToUpper().Trim()
                Case "id".ToUpper().Trim()
                    Me.id = pColValue.ToString
                Case "type".ToUpper().Trim()
                    Me.type = pColValue.ToString
                Case "auteur".ToUpper().Trim()
                    Me.auteur = pColValue.ToString
                Case "idAgentControleur".ToUpper().Trim()
                    Me.idAgentControleur = pColValue.ToString
                Case "caracteristiques".ToUpper().Trim()
                    Me.caracteristiques = pColValue.ToString
                Case "dateModif".ToUpper().Trim()
                    Me.dateModif = pColValue.ToString
                Case "blocage".ToUpper().Trim()
                    Me.blocage = CType(pColValue, Boolean)
                Case "dateModificationAgent".ToUpper().Trim()
                    Me.dateModificationAgent = pColValue.ToString
                Case "dateModificationCrodip".ToUpper().Trim()
                    Me.dateModificationCrodip = pColValue.ToString
                Case "FVFileName".ToUpper().Trim()
                    Me.FVFileName = pColValue.ToString
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVMateriel.Fill(" & pColName & ",...) Err " & ex.Message())
            bReturn = False
        End Try
        Return bReturn
    End Function 'FillCommun

End Class