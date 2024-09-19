Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(ManometreEtalon))> _
Public Class ManometreEtalon
    Inherits Manometre

    Private _incertitudeEtalon As String

    Sub New()

    End Sub


    Public Property incertitudeEtalon() As String
        Get
            Return _incertitudeEtalon
        End Get
        Set(ByVal Value As String)
            _incertitudeEtalon = Value
        End Set
    End Property

    Public ReadOnly Property incertitudeEtalon_d() As Double
        Get
            Try
                Return GlobalsCRODIP.StringToDouble(_incertitudeEtalon)
            Catch ex As Exception
                Return CDbl(0)
            End Try
        End Get
    End Property

    Public Overrides Property Libelle() As String
        Get
            Return "Manomètre Etalon : " + idCrodip
        End Get
        Set(value As String)

        End Set
    End Property
    Public Overrides Function Fill(pColName As String, pcolValue As Object) As Boolean
        Dim bReturn As Boolean
        Try

            Select Case pColName.Trim().ToUpper()
                Case "numeroNational".Trim().ToUpper()
                    Me.numeroNational = CType(pcolValue, String)
                Case "idCrodip".Trim().ToUpper()
                    Me.idCrodip = CType(pcolValue, String)
                Case "idStructure".Trim().ToUpper()
                    Me.idStructure = CType(pcolValue, Integer)
                Case "marque".Trim().ToUpper()
                    Me.marque = CType(pcolValue, String)
                Case "classe".Trim().ToUpper()
                    Me.classe = CType(pcolValue, String)
                Case "incertitudeEtalon".Trim().ToUpper()
                    Me.incertitudeEtalon = CType(pcolValue, String)
                Case "type".Trim().ToUpper()
                    Me.type = CType(pcolValue, String)
                Case "fondEchelle".Trim().ToUpper()
                    Me.fondEchelle = CType(pcolValue, String)
                Case "isSynchro".Trim().ToUpper()
                    Me.isSynchro = CType(pcolValue, Boolean)
                Case "dateDernierControle".Trim().ToUpper()
                    Me.dateDernierControleS = CSDate.ToCRODIPString(pcolValue)
                Case "dateModificationAgent".Trim().ToUpper()
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pcolValue)
                Case "dateModificationCrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pcolValue)
                Case "etat".Trim().ToUpper()
                    Me.etat = CType(pcolValue, Boolean)
                Case "isUtilise".Trim().ToUpper()
                    Me.isUtilise = CType(pcolValue, Boolean)
                Case "isSupprime".Trim().ToUpper()
                    Me.isSupprime = CType(pcolValue, Boolean)
                Case "nbControles".Trim().ToUpper()
                    If pcolValue.ToString() <> "" Then
                        Me.nbControles = CType(pcolValue, Integer)
                    End If
                Case "nbControlesTotal".Trim().ToUpper()
                    If pcolValue.ToString() <> "" Then
                        Me.nbControlesTotal = CType(pcolValue, Integer)
                    End If
                Case "agentsuppression".Trim().ToUpper()
                    Me.AgentSuppression = pcolValue.ToString()
                Case "raisonsuppression".Trim().ToUpper()
                    Me.RaisonSuppression = pcolValue.ToString()
                Case "datesuppression".Trim().ToUpper()
                    Dim strDateMin As String = CSDate.ToCRODIPString("")
                    Dim strDateValue As String = CSDate.ToCRODIPString(pcolValue)
                    If strDateValue <> strDateMin And strDateValue <> "1899-12-30 00:00:00" Then
                        Me.DateSuppression = CSDate.ToCRODIPString(pcolValue).ToString()
                    Else
                        Me.DateSuppression = ""
                    End If
                Case "jamaisServi".Trim().ToUpper()
                    Me.JamaisServi = pcolValue
                Case "dateActivation".Trim().ToUpper()
                    Me.DateActivation = pcolValue
            End Select
            bReturn = True

        Catch ex As Exception
            bReturn = False
            CSDebug.dispError("ManometreEtalon.Fill Err" & ex.Message)
        End Try
        Return bReturn
    End Function

    Public Overrides Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        creerFicheVieSuppression(pAgentSuppression)
        Me.agentSuppression = pAgentSuppression.nom
        Me.raisonSuppression = pRaison
        Me.dateSuppression = Now.ToString()
        Me.dateModificationAgent = Now()
        Me.isSupprime = True
        ManometreEtalonManager.save(Me)
    End Function

    'Public Function DesactiverMano(ByVal pAgent As Agent) As Boolean
    '    Dim bReturn As Boolean

    '    Try
    '        creerFicheVieDesactivation(pAgent)
    '        ' On bloque le mano
    '        Me.etat = False
    '        ManometreEtalonManager.save(Me)
    '        bReturn = True
    '    Catch ex As Exception
    '        CSDebug.dispError("ManometreControle.desactiverMano : " & ex.Message)
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function

    Public Overrides Function creerFicheVieActivation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVManometreControle.FVTYPE_MISENSERVICE, pAgent)
    End Function

    Public Function creerFicheViePremiereUtilisation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVManometreControle.FVTYPE_PREMIEREUTILISATION, pAgent)
    End Function
    Public Function creerFicheVieSuppression(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVManometreControle.FVTYPE_SUPPRESSION, pAgent)
    End Function
    'Public Function creerFicheVieDesactivation(ByVal pAgent As Agent) As Boolean
    '    Return creerFicheVie(FVManometreControle.FVTYPE_DESACTIVATION, pAgent)
    'End Function
    Public Function creerFicheVie(ByVal pType As String, ByVal pAgent As Agent) As Boolean
        Debug.Assert(pAgent IsNot Nothing)
        Dim bReturn As Boolean

        Try
            Dim newFicheVieManoEtalon As New FVManometreEtalon(pAgent)
            newFicheVieManoEtalon.idManometre = Me.idCrodip
            newFicheVieManoEtalon.type = pType
            newFicheVieManoEtalon.auteur = "AGENT"
            newFicheVieManoEtalon.idAgentControleur = pAgent.id
            newFicheVieManoEtalon.caracteristiques =
            Me.idCrodip & "|" &
            Me.marque & "|" &
            Me.classe & "|" &
            Me.type & "|" &
            Me.fondEchelle & "|" &
            Me.idStructure & "|" &
            Me.isSynchro & "|" &
            Me.dateDernierControleS & "|" &
            Me.dateModificationAgent & "|" &
            Me.dateModificationCrodip
            newFicheVieManoEtalon.dateModif = CSDate.ToCRODIPString(Date.Now)
            newFicheVieManoEtalon.dateModificationAgent = CSDate.ToCRODIPString(Date.Now)
            FVManometreEtalonManager.save(newFicheVieManoEtalon)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ManometreEtalon.creerFicheVie ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function 'CreerFicheVie
    Public Overloads Function getAlerte() As GlobalsCRODIP.ALERTE
        Dim bReturn As GlobalsCRODIP.ALERTE
        bReturn = GlobalsCRODIP.ALERTE.NONE

        Dim oNiveau As NiveauAlerte
        If Not String.IsNullOrEmpty(dateDernierControleS) Then
            oNiveau = getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.ManometreEtalon)

            bReturn = MyBase.getAlerte(dateDernierControle, oNiveau)

            If bReturn = GlobalsCRODIP.ALERTE.NONE And etat = False Then
                bReturn = GlobalsCRODIP.ALERTE.CONTROLE
            End If
        End If
        Return bReturn
    End Function
    '''
    ''' Calcul du nombre de jours restant avant L'alerteRouge
    Public Function getNbJoursAvantAlerteRouge() As Integer
        Dim tmpDateLCManoControle As Date = CSDate.FromCrodipString(Me.dateDernierControleS)
        Dim DL As Date
        Dim n As Integer
        Dim oNiveau As NiveauAlerte
        oNiveau = Materiel.getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.ManometreEtalon)
        Dim nbJRouge As Integer = oNiveau.Rouge
        DL = DateAdd(DateInterval.DayOfYear, -nbJRouge, Now) ''Date limit pour passer En alerte Rouge


        n = DateDiff(DateInterval.DayOfYear, DL, tmpDateLCManoControle)

        Return n
    End Function
End Class