Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
<Serializable(), XmlInclude(GetType(Materiel))> _
Public MustInherit Class Materiel

    Protected _numeroNational As String
    Protected _idCrodip As String
    Protected _idStructure As Integer
    Protected _isSupprime As Boolean
    Protected _AgentSuppression As String
    Protected _RaisonSuppression As String
    Protected _DateSuppression As String
    Protected _JamaisServi As Boolean
    Protected _DateActivation As Nullable(Of Date)
    Protected _dateDernierControle As String
    Protected _dateModificationAgent As String
    Protected _dateModificationCrodip As String
    Protected _etat As Boolean



    Sub New()
        _numeroNational = ""
        _idCrodip = ""
        _idStructure = 0
        _isSupprime = False
        _AgentSuppression = ""
        _RaisonSuppression = ""
        _DateSuppression = CSDate.ToCRODIPString(Date.MinValue)
        _JamaisServi = False
        _DateActivation = Date.MinValue
        _dateDernierControle = ""
        _dateModificationAgent = ""
        _dateModificationCrodip = ""
        _JamaisServi = False

    End Sub

    Public Property numeroNational() As String
        Get
            Return _numeroNational
        End Get
        Set(ByVal Value As String)
            _numeroNational = Value
        End Set
    End Property

    Public Property idCrodip() As String
        Get
            Return _idCrodip
        End Get
        Set(ByVal Value As String)
            _idCrodip = Value
        End Set
    End Property

    Public Property idStructure() As Integer
        Get
            Return _idStructure
        End Get
        Set(ByVal Value As Integer)
            _idStructure = Value
        End Set
    End Property


    Public Property isSupprime() As Boolean
        Get
            Return _isSupprime
        End Get
        Set(ByVal Value As Boolean)
            _isSupprime = Value
        End Set
    End Property


    Public Property AgentSuppression() As String
        Get
            Return _AgentSuppression
        End Get
        Set(ByVal Value As String)
            _AgentSuppression = Value
        End Set
    End Property

    Public Property RaisonSuppression() As String
        Get
            Return _RaisonSuppression
        End Get
        Set(ByVal Value As String)
            _RaisonSuppression = Value
        End Set
    End Property
    Public Property DateSuppression() As String
        Get
            Return _DateSuppression
        End Get
        Set(ByVal Value As String)
            _DateSuppression = Value
        End Set
    End Property

    Public Property JamaisServi() As Boolean
        Get
            Return _JamaisServi
        End Get
        Set(ByVal Value As Boolean)
            _JamaisServi = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property DateActivation() As Date
        Get
            If _DateActivation.HasValue Then
                Return _DateActivation
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Date)
            _DateActivation = Value
        End Set
    End Property
    <XmlElement("dateActivation")>
    Public Property DateActivationS() As String
        Get
            Return CSDate.GetDateForWS(_DateActivation.GetValueOrDefault())
        End Get
        Set(ByVal Value As String)
            _DateActivation = Value
        End Set
    End Property
    <XmlElement("dateDernierControle")>
    Public Property dateDernierControleS() As String
        Get
            Return _dateDernierControle
        End Get
        Set(ByVal Value As String)
            _dateDernierControle = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateDernierControle() As Date
        Get
            Return DateTime.Parse(_dateDernierControle)
        End Get
        Set(ByVal Value As Date)
            _dateDernierControle = CSDate.ToCRODIPString(Value)
        End Set
    End Property
    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property

    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property

    Public Property etat() As Boolean
        Get
            Return _etat
        End Get
        Set(ByVal Value As Boolean)
            _etat = Value
        End Set
    End Property

    Public Overridable ReadOnly Property Libelle() As String
        Get
            Return "Matériel : " + numeroNational
        End Get
    End Property
    Public Overridable Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Return False
    End Function

    Public Overridable Function ActiverMateriel(ByVal pDateActivation As Date, ByVal pAgent As Agent) As Boolean
        Debug.Assert(Not CSDate.isDateNull(pDateActivation), "Date non nulle")
        Debug.Assert(pAgent IsNot Nothing, "Agent initialisé")
        Dim bReturn As Boolean
        Try
            JamaisServi = False
            etat = True
            DateActivation = pDateActivation
            dateDernierControleS = pDateActivation

            bReturn = creerFichevieActivation(pAgent)
        Catch ex As Exception
            CSDebug.dispError("Materiel.ActiverMateriel ERR: " & ex.Message)
            bReturn = False

        End Try
        Return bReturn
    End Function 'ActiverMateriel

    Public MustOverride Function creerFichevieActivation(ByVal pAgent As Agent) As Boolean

    Public Shared Function getNiveauAlerte(pType As NiveauAlerte.Enum_typeMateriel) As NiveauAlerte
        Dim bReturn As Globals.ALERTE
        bReturn = Globals.ALERTE.NONE
        Dim lstNiveauAlerte As List(Of NiveauAlerte)
        lstNiveauAlerte = NiveauAlerte.readXML()
        Dim oNiveau As NiveauAlerte = Nothing
        For Each oNiv As NiveauAlerte In lstNiveauAlerte
            If oNiv.Materiel = pType Then
                oNiveau = oNiv
            End If
        Next
        Dim AlerteNoire As Integer = 7
        Dim AlerteRouge As Integer = 30
        Dim AlerteOrange As Integer = 15
        Dim AlerteJaune As Integer = 1

        If oNiveau Is Nothing Then
            oNiveau = New NiveauAlerte()
            oNiveau.Noire = AlerteNoire
            oNiveau.Rouge = AlerteRouge
            oNiveau.Orange = AlerteOrange
            oNiveau.Jaune = AlerteJaune
        End If
        Return oNiveau
    End Function
    Public Function getAlerte(pDate As Date, oNiveau As NiveauAlerte) As Globals.ALERTE
        Dim bReturn As Globals.ALERTE
        bReturn = Globals.ALERTE.NONE

        Dim dernCtrl As Date = pDate
        Dim n As Integer
        Dim DL As Date
        'Alerte Noire ( 1 mois et 7 jours)
        If (oNiveau.Noire <> 0) Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Noire * -1, Now) '1 mois et 7 jours
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                bReturn = Globals.ALERTE.NOIRE
            End If
        End If
        If bReturn = Globals.ALERTE.NONE And oNiveau.Rouge <> 0 Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Rouge * -1, Now) '1 mois 
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return Globals.ALERTE.ROUGE
            End If
        End If
        If bReturn = Globals.ALERTE.NONE And oNiveau.Orange <> 0 Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Orange * -1, Now) '2 semaines
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return Globals.ALERTE.ORANGE
            End If
        End If
        If bReturn = Globals.ALERTE.NONE And oNiveau.Jaune <> 0 Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Jaune * -1, Now) '1 semaine
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return Globals.ALERTE.JAUNE
            End If
        End If

        Return bReturn
    End Function

End Class