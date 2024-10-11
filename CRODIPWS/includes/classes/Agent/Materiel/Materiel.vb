Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
<Serializable(), XmlInclude(GetType(Materiel))> _
Public MustInherit Class Materiel
    Inherits root
    'Protected _id As Integer
    Protected _numeroNational As String = ""
    Protected _idCrodip As String = ""
    Protected _idStructure As Integer = 0
    Protected _isSupprime As Boolean = False
    Protected _AgentSuppression As String = ""
    Protected _RaisonSuppression As String = ""
    Protected _DateSuppression As String = ""
    Protected _JamaisServi As Boolean = False
    Protected _DateActivation As Nullable(Of Date) = Nothing
    Protected _dateDernierControle As String = ""
    Protected _etat As Boolean = False



    Sub New()
        MyBase.New()
        _numeroNational = ""
        _idCrodip = ""
        _idStructure = 0
        _isSupprime = False
        _AgentSuppression = ""
        _RaisonSuppression = ""
        _DateSuppression = ""
        _JamaisServi = False
        _DateActivation = Date.MinValue
        _dateDernierControle = ""
        _JamaisServi = False

    End Sub

    'Public Property id() As Integer
    '    Get
    '        Return _id
    '    End Get
    '    Set(ByVal value As Integer)
    '        _id = value
    '    End Set
    'End Property
    <XmlIgnore()>
    Public Property numeroNational() As String
        Get
            Return _numeroNational
        End Get
        Set(ByVal Value As String)
            _numeroNational = Value
        End Set
    End Property

    <XmlIgnore()>
    Public Property idCrodip() As String
        Get
            Return _idCrodip
        End Get
        Set(ByVal Value As String)
            _idCrodip = Value
        End Set
    End Property
    Public Property uidstructure() As Integer
        Get
            Return _idStructure
        End Get
        Set(ByVal Value As Integer)
            _idStructure = Value
        End Set
    End Property

    <XmlIgnore()>
    Public Property isSupprime() As Integer
        Get
            Return CInt(_isSupprime)
        End Get
        Set(ByVal Value As Integer)
            _isSupprime = CBool(Value)
        End Set
    End Property
    <XmlElement("isSupprime")>
    Public Property isSupprimeWS() As Boolean
        Get
            Return _isSupprime
        End Get
        Set(ByVal Value As Boolean)
            _isSupprime = Value
        End Set
    End Property


    Public Property agentSuppression() As String
        Get
            Return _AgentSuppression
        End Get
        Set(ByVal Value As String)
            _AgentSuppression = Value
        End Set
    End Property

    Public Property raisonSuppression() As String
        Get
            Return _RaisonSuppression
        End Get
        Set(ByVal Value As String)
            _RaisonSuppression = Value
        End Set
    End Property
    Public Property dateSuppression() As String
        Get
            Return _DateSuppression
        End Get
        Set(ByVal Value As String)
            _DateSuppression = Value
        End Set
    End Property

    Public Property jamaisServi() As Boolean
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
            If Value <> "" Then
                _DateActivation = Value
            End If
        End Set
    End Property
    <XmlElement("dateDernierControle")>
    Public Property dateDernierControleS() As String
        Get
            Return _dateDernierControle
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                _dateDernierControle = Value
            End If
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateDernierControle() As Date
        Get
            If Not String.IsNullOrEmpty(_dateDernierControle) Then
                Return DateTime.Parse(_dateDernierControle)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Date)
            _dateDernierControle = CSDate.ToCRODIPString(Value)
        End Set
    End Property
    Public Function IsDateControle() As Boolean
        Dim bReturn As Boolean = False
        If _dateDernierControle = "" Then
            bReturn = False
        Else
            Try
                Dim dDate As Date = Date.Parse(_dateDernierControle)
                If dDate.Year > 1970 Then
                    bReturn = True
                End If
            Catch
                bReturn = False
            End Try
        End If
        Return bReturn
    End Function
    <XmlElement("etat")>
    Public Property etatWS() As Integer
        Get
            Return CInt(_etat)
        End Get
        Set(ByVal Value As Integer)
            _etat = CBool(Value)
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property etat() As Boolean
        Get
            Return _etat
        End Get
        Set(ByVal Value As Boolean)
            _etat = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Overridable Property Libelle() As String
        Get
            Return "Matériel : " + numeroNational
        End Get
        Set(value As String)

        End Set
    End Property
    Public Overridable Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Return False
    End Function
    Public Overrides Function Fill(pColName As String, pcolValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = MyBase.Fill(pColName, pcolValue)
            If Not bReturn Then
                bReturn = True
                Select Case pColName.Trim().ToUpper()
                    Case "idCrodip".Trim().ToUpper()
                        Me.idCrodip = pcolValue.ToString()
                    Case "idstructure".Trim().ToUpper()
                        Me.uidstructure = pcolValue.ToString()
                    Case "etat".Trim().ToUpper()
                        Me.etat = CType(pcolValue, Boolean)
                    Case "issupprime".Trim().ToUpper()
                        Me.isSupprime = CType(pcolValue, Boolean)
                    Case "issupprime".Trim().ToUpper()
                        Me.isSupprime = CType(pcolValue, Boolean)
                    Case "agentsuppression".Trim().ToUpper()
                        Me.agentSuppression = pcolValue.ToString()
                    Case "raisonsuppression".Trim().ToUpper()
                        Me.raisonSuppression = pcolValue.ToString()
                    Case "datesuppression".Trim().ToUpper()
                        Dim strDateMin As String = CSDate.ToCRODIPString("")
                        Dim strDateValue As String = CSDate.ToCRODIPString(pcolValue)
                        If strDateValue <> strDateMin And strDateValue <> "1899-12-30 00:00:00" Then
                            Me.dateSuppression = CSDate.ToCRODIPString(pcolValue).ToString()
                        Else
                            Me.dateSuppression = ""
                        End If

                    Case "jamaisServi".Trim().ToUpper()
                        Me.jamaisServi = pcolValue
                    Case "dateActivation".Trim().ToUpper()
                        Me.DateActivation = pcolValue
                    Case Else
                        bReturn = False
                End Select
            End If
        Catch ex As Exception
            CSDebug.dispError("Materiel.Fill  (" + pColName + "," + pcolValue.ToString + ") ERR : " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Public Overridable Function ActiverMateriel(ByVal pDateActivation As Date, ByVal pAgent As Agent) As Boolean
        Debug.Assert(Not CSDate.isDateNull(pDateActivation), "Date non nulle")
        Debug.Assert(pAgent IsNot Nothing, "Agent initialisé")
        Dim bReturn As Boolean
        Try
            jamaisServi = False
            etat = True
            DateActivation = pDateActivation


            bReturn = creerFichevieActivation(pAgent)
        Catch ex As Exception
            CSDebug.dispError("Materiel.ActiverMateriel ERR: " & ex.Message)
            bReturn = False

        End Try
        Return bReturn
    End Function 'ActiverMateriel

    Public MustOverride Function creerFichevieActivation(ByVal pAgent As Agent) As Boolean

    Public Shared Function getNiveauAlerte(pType As NiveauAlerte.Enum_typeMateriel) As NiveauAlerte
        Dim bReturn As GlobalsCRODIP.ALERTE
        bReturn = GlobalsCRODIP.ALERTE.NONE
        Dim lstNiveauAlerte As List(Of NiveauAlerte)
        lstNiveauAlerte = Alertes.readXML().NiveauxAlertes
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
    Public Function getAlerte(pDate As Date, oNiveau As NiveauAlerte) As GlobalsCRODIP.ALERTE
        Dim bReturn As GlobalsCRODIP.ALERTE
        bReturn = GlobalsCRODIP.ALERTE.NONE

        Dim dernCtrl As Date = pDate
        Dim n As Integer
        Dim DL As Date
        'Alerte Noire ( 1 mois et 7 jours)
        If (oNiveau.Noire <> 0) Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Noire * -1, Now) '1 mois et 7 jours
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                bReturn = GlobalsCRODIP.ALERTE.NOIRE
            End If
        End If
        If bReturn = GlobalsCRODIP.ALERTE.NONE And oNiveau.Rouge <> 0 Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Rouge * -1, Now) '1 mois 
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return GlobalsCRODIP.ALERTE.ROUGE
            End If
        End If
        If bReturn = GlobalsCRODIP.ALERTE.NONE And oNiveau.Orange <> 0 Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Orange * -1, Now) '2 semaines
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return GlobalsCRODIP.ALERTE.ORANGE
            End If
        End If
        If bReturn = GlobalsCRODIP.ALERTE.NONE And oNiveau.Jaune <> 0 Then
            DL = DateAdd(DateInterval.DayOfYear, oNiveau.Jaune * -1, Now) '1 semaine
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return GlobalsCRODIP.ALERTE.JAUNE
            End If
        End If

        Return bReturn
    End Function

End Class