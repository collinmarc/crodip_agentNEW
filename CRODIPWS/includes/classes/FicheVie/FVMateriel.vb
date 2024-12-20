Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(FVMateriel))>
Public MustInherit Class FVMateriel
    Inherits root

    Private _id As String
    Private _type As String
    Private _auteur As String
    Private _aidAgentControleur As String
    Private _uidAgentControleur As Integer
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
        idAgentControleur = pAgent.id
    End Sub

    Public Property id() As String
        Get
            Return aid
        End Get
        Set(ByVal Value As String)
            aid = Value
        End Set
    End Property

    Private _uidstructure As Integer
    <XmlIgnore>
    Public Property uidstructure() As Integer
        Get
            Return _uidstructure
        End Get
        Set(ByVal value As Integer)
            _uidstructure = value
        End Set
    End Property
    <XmlElement("uidstructure")>
    Public Property uidstructureS() As String
        Get
            Return uidstructure
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                uidstructure = value
            End If
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
    <XmlIgnore>
    Public Property idAgentControleur() As Integer
        Get
            If IsNumeric(_aidAgentControleur) Then
                Return _aidAgentControleur
            Else
                Return 0
            End If
        End Get
        Set(ByVal Value As Integer)
            _aidAgentControleur = Value
        End Set
    End Property
    Public Property aidagentcontroleur() As String
        Get
            Return _aidAgentControleur
        End Get
        Set(ByVal Value As String)
            _aidAgentControleur = Value
        End Set
    End Property
    <XmlElement("uidagentcontroleur")>
    Public Property uidagentcontroleurS() As String
        Get
            Return uidagentcontroleur
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                uidagentcontroleur = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property uidagentcontroleur() As Integer
        Get
            Return _uidAgentControleur
        End Get
        Set(ByVal Value As Integer)
            _uidAgentControleur = Value
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


    Public Property FVFileName() As String
        Get
            Return _FVFileName
        End Get
        Set(ByVal Value As String)
            _FVFileName = Value
        End Set
    End Property

    Protected Function FillCommun(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean = True
        Try
            If Not MyBase.Fill(pColName, pColValue) Then
                Select Case pColName.ToUpper().Trim()
                    Case "uidstructure".ToUpper().Trim()
                        Me.uidstructure = pColValue.ToString
                    Case "id".ToUpper().Trim()
                        Me.id = pColValue.ToString
                    Case "type".ToUpper().Trim()
                        Me.type = pColValue.ToString
                    Case "auteur".ToUpper().Trim()
                        Me.auteur = pColValue.ToString
                    Case "idAgentControleur".ToUpper().Trim()
                        Me.idAgentControleur = pColValue.ToString
                    Case "aidAgentControleur".ToUpper().Trim()
                        Me.aidagentcontroleur = pColValue.ToString
                    Case "uidAgentControleur".ToUpper().Trim()
                        Me.uidagentcontroleur = pColValue.ToString
                    Case "caracteristiques".ToUpper().Trim()
                        Me.caracteristiques = pColValue.ToString
                    Case "dateModif".ToUpper().Trim()
                        Me.dateModif = pColValue.ToString
                    Case "blocage".ToUpper().Trim()
                        Me.blocage = CType(pColValue, Boolean)
                    Case "FVFileName".ToUpper().Trim()
                        Me.FVFileName = pColValue.ToString
                    Case Else
                        bReturn = False
                End Select
            End If
        Catch ex As Exception
            CSDebug.dispError("FVMateriel.Fill(" & pColName & ",...) Err " & ex.Message())
            bReturn = False
        End Try
        Return bReturn
    End Function 'FillCommun

End Class