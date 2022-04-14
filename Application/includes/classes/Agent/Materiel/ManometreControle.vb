Imports System.Data.Common
Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(ManometreControle))>
Public Class ManometreControle
    Inherits Manometre

    Private _resolution As String
    'Private arrPressions_6bar() As String = {0, 1.2, 2.4, 3.6, 4.8, 6}
    'Private arrPressions_10bar() As String = {0, 2, 4, 6, 8, 10}
    'Private arrPressions_20bar() As String = {0, 4, 8, 12, 16, 20}
    'Private arrPressions_25bar() As String = {0, 5, 10, 15, 20, 25}
    'Private arrPressions_default() As String = {0, 2, 4, 6, 8, 10}
    'Private arrPressions() As String

    Private m_bIsUpdated As Boolean
    Sub New()
        m_bIsUpdated = False
    End Sub
    Private _controle As ControleMano
    <XmlIgnore>
    Public Property controle() As ControleMano
        Get
            Return _controle
        End Get
        Set(ByVal value As ControleMano)
            _controle = value
        End Set
    End Property


    Public Property resolution() As String
        Get
            Return _resolution
        End Get
        Set(ByVal Value As String)
            _resolution = Value
        End Set
    End Property
    Public ReadOnly Property resolution_d() As Double
        Get
            Try
                Return GlobalsCRODIP.StringToDouble(_resolution)
            Catch ex As Exception
                Return CDbl(0)
            End Try
        End Get
    End Property

    Public Overrides Property Libelle() As String
        Get
            Dim sLibelle As String = "   "
            If m_bIsUpdated Then
                sLibelle = " * "
            End If
            sLibelle = sLibelle + idCrodip
            If etat Then
                sLibelle = sLibelle + " (OK) "
            Else
                sLibelle = sLibelle + " (ERR) "
            End If
            Return sLibelle
        End Get
        Set(value As String)

        End Set
    End Property
    Private Function getPressionCtrl(pNum As Integer) As String
        Try
            Dim nFond As Integer = CInt(fondEchelle)
            Return Math.Round(nFond * (0.2 * (pNum - 1)), 1).ToString()
        Catch ex As Exception
            Return ""
        End Try
        'Select Case fondEchelle
        '    Case "6"
        '        arrPressions = arrPressions_6bar
        '    Case "10"
        '        arrPressions = arrPressions_10bar
        '    Case "20"
        '        arrPressions = arrPressions_20bar
        '    Case "25"
        '        arrPressions = arrPressions_25bar
        '    Case Else
        '        arrPressions = arrPressions_default
        'End Select
        'Return arrPressions(0)
    End Function
    <XmlIgnore>
    Public ReadOnly Property Pression1Ctrl() As String
        Get
            Return getPressionCtrl(1)
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property Pression2Ctrl() As String
        Get
            Return getPressionCtrl(2)
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property Pression3Ctrl() As String
        Get
            Return getPressionCtrl(3)
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property Pression4Ctrl() As String
        Get
            Return getPressionCtrl(4)
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property Pression5Ctrl() As String
        Get
            Return getPressionCtrl(5)
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property Pression6Ctrl() As String
        Get
            Return getPressionCtrl(6)
        End Get
    End Property

    Public Function calcEMT() As Double
        Dim dReturn As Double
        Select Case fondEchelle
            Case "6"
                dReturn = 0.1
            Case "10"
                dReturn = 0.1
            Case "20"
                dReturn = 0.2
            Case "25"
                dReturn = 0.25
            Case Else
                dReturn = CDbl(Math.Round((GlobalsCRODIP.StringToDouble(classe) * GlobalsCRODIP.StringToDouble(fondEchelle) / 100), 2))
        End Select

        Return dReturn

    End Function



    Public Function Fill(ByVal oDataReader As DbDataReader) As Boolean
        Dim bReturn As Boolean
        Try

            Dim tmpColId As Integer = 0
            While tmpColId < oDataReader.FieldCount()
                If Not oDataReader.IsDBNull(tmpColId) Then
                    Fill(oDataReader.GetName(tmpColId), oDataReader.Item(tmpColId))
                End If
                tmpColId = tmpColId + 1
            End While
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ManomettreControle.Fill Err: " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function Fill(ByVal pColName As String, ByVal pValue As Object) As Boolean
        Select Case pColName.Trim().ToUpper()
            Case "numeroNational".Trim.ToUpper()
                Me.numeroNational = pValue.ToString() 'Public numeroNational As String
            Case "idCrodip".Trim.ToUpper()
                Me.idCrodip = pValue.ToString() 'Public numeroNational As String
            Case "idStructure".Trim.ToUpper()
                Me.idStructure = pValue.ToString() 'Public idAgent As String
            Case "marque".Trim.ToUpper()
                Me.marque = pValue.ToString() 'Public marque As String
            Case "classe".Trim.ToUpper()
                Me.classe = pValue.ToString() 'Public classe As String
            Case "type".Trim.ToUpper()
                Me.type = pValue.ToString() 'Public type As String
            Case "fondEchelle".Trim.ToUpper()
                Me.fondEchelle = pValue.ToString() 'Public fondEchelle As String
            Case "etat".Trim.ToUpper()
                Me.etat = CType(pValue, Boolean) 'Public etat As Boolean
            Case "isSynchro".Trim.ToUpper()
                Me.isSynchro = CType(pValue, Boolean) 'Public isSynchro As Boolean
            Case "isSupprime".Trim.ToUpper()
                Me.isSupprime = CType(pValue, Boolean) 'Public isSupprime As Boolean
            Case "isutilise".Trim().ToUpper()
                Me.isUtilise = CType(pValue, Boolean)
            Case "dateDernierControle".Trim.ToUpper()
                Dim dateC As Date
                Try
                    dateC = CDate(pValue)
                    If dateC.Year <> 1899 And dateC.Year <> 0 Then
                        Me.dateDernierControleS = CSDate.ToCRODIPString(pValue).ToString 'Public dateAchat As String
                    End If
                Catch ex As Exception

                End Try
            Case "dateModificationAgent".Trim.ToUpper()
                Me.dateModificationAgent = CSDate.ToCRODIPString(pValue).ToString 'Public dateModificationAgent As String
            Case "dateModificationCrodip".Trim.ToUpper()
                Me.dateModificationCrodip = CSDate.ToCRODIPString(pValue).ToString 'Public dateModificationCrodip As String
            Case "etat".Trim.ToUpper()
                Me.etat = CType(pValue, Boolean) 'Public etat As Boolean
            Case "nbControles".Trim().ToUpper()
                If pValue.ToString() <> "" Then
                    Me.nbControles = CType(pValue, Integer)
                End If
            Case "nbControlesTotal".Trim().ToUpper()
                If pValue.ToString() <> "" Then
                    Me.nbControlesTotal = CType(pValue, Integer)
                End If
            Case "resolution".Trim.ToUpper()
                Me.resolution = pValue.ToString()
            Case "agentsuppression".Trim().ToUpper()
                Me.AgentSuppression = pValue.ToString()
            Case "raisonsuppression".Trim().ToUpper()
                Me.RaisonSuppression = pValue.ToString()
            Case "datesuppression".Trim().ToUpper()
                Dim strDateMin As String = CSDate.ToCRODIPString("")
                Dim strDateValue As String = CSDate.ToCRODIPString(pValue)
                If strDateValue <> strDateMin And strDateValue <> "1899-12-30 00:00:00" Then
                    Me.DateSuppression = CSDate.ToCRODIPString(pValue).ToString()
                Else
                    Me.DateSuppression = ""
                End If
            Case "jamaisServi".Trim().ToUpper()
                Me.JamaisServi = pValue
            Case "dateActivation".Trim().ToUpper()
                Me.DateActivation = pValue
        End Select

    End Function
    Public Overrides Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Me.creerFicheVieSuppression(pAgentSuppression)
        Me.AgentSuppression = pAgentSuppression.nom
        Me.RaisonSuppression = pRaison
        Me.DateSuppression = Now.ToString()
        Me.dateModificationAgent = Now()
        Me.isSupprime = True
        ManometreControleManager.save(Me)
    End Function

    Public Function Desactiver(ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean

        Try
            creerFicheVieDesactivation(pAgent)
            ' On bloque le mano
            Me.etat = False
            ManometreControleManager.save(Me)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ManometreControle.desactiver : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Renvoie le niveau d'alter concernant le materiel
    ''' ALERTE.NONE par defaut
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function getAlerte() As GlobalsCRODIP.ALERTE
        Dim bReturn As GlobalsCRODIP.ALERTE
        bReturn = GlobalsCRODIP.ALERTE.NONE

        Dim oNiveau As NiveauAlerte
        If Not String.IsNullOrEmpty(dateDernierControleS) Then
            oNiveau = getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.ManometreControle)

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
        oNiveau = Materiel.getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.ManometreControle)
        Dim nbJRouge As Integer = oNiveau.Rouge
        DL = DateAdd(DateInterval.DayOfYear, -nbJRouge, Now) ''Date limit pour passer En alerte Rouge


        n = DateDiff(DateInterval.DayOfYear, DL, tmpDateLCManoControle)

        Return n
    End Function
    Public Overrides Function creerFicheVieActivation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVManometreControle.FVTYPE_MISENSERVICE, pAgent) IsNot Nothing
    End Function

    Public Function creerFicheViePremiereUtilisation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVManometreControle.FVTYPE_PREMIEREUTILISATION, pAgent) IsNot Nothing
    End Function
    Public Function creerFicheVieSuppression(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVManometreControle.FVTYPE_SUPPRESSION, pAgent) IsNot Nothing
    End Function
    Public Function creerFicheVieDesactivation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVManometreControle.FVTYPE_DESACTIVATION, pAgent) IsNot Nothing
    End Function
    Public Function creerfFicheVieControle(ByVal pAgent As Agent, pControleMano As ControleMano) As FVManometreControle
        Dim oReturn As FVManometreControle = Nothing
        Try
            Dim oFV As FVManometreControle
            CSDebug.dispInfo("ManometreControle.creerfFicheVieControle() :  Creation FV")

            oFV = creerFicheVie(FVMateriel.FVTYPE_CONTROLE, pAgent)
            If oFV IsNot Nothing Then


                oFV.idManometre = Me.idCrodip
                oFV.caracteristiques = _
                Me.idCrodip & "|" & _
                Me.marque & "|" & _
                Me.classe & "|" & _
                Me.type & "|" & _
                Me.fondEchelle & "|" & _
                Me.idStructure & "|" & _
                Me.isSynchro & "|" & _
                Me.dateDernierControleS & "|" & _
                Me.dateModificationAgent & "|" & _
                Me.dateModificationCrodip

                oFV.idReetalonnage = ""
                oFV.nomLaboratoire = ""
                oFV.dateReetalonnage = ""
                oFV.idManometreControleur = pControleMano.manoEtalon

                ' On récupère les pressions de controle
                oFV.pressionControle = pControleMano.PressionControle
                oFV.valeursMesurees = pControleMano.ValeursMesurees
                ' Contrôle OK ou NOK
                oFV.blocage = Not Me.etat
                oFV.dateModif = pControleMano.DateVerif
                ' On GlobalsCRODIP.CONSTruit le PDF de rapport à partir de l'objet m_oControleBanc
                CSDebug.dispInfo("ManometreControle.creerfFicheVieControle() :  buildPDF")
                Dim sFileName As String = pControleMano.buildPDF()
                oFV.FVFileName = sFileName


                CSDebug.dispInfo("ManometreControle.creerfFicheVieControle() :  Save oFV")
                FVManometreControleManager.save(oFV)

                oReturn = oFV

            End If
        Catch ex As Exception
            CSDebug.dispError("ManometreControle.CreerFicheVieControle : ERR" & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Private Function creerFicheVie(ByVal pType As String, ByVal pAgent As Agent) As FVManometreControle
        Debug.Assert(pAgent IsNot Nothing)
        Dim oReturn As FVManometreControle

        Try
            Dim oFV As New FVManometreControle(pAgent)
            oFV.idManometre = Me.idCrodip
            oFV.type = pType
            oFV.auteur = "AGENT"
            oFV.idAgentControleur = pAgent.id
            oFV.caracteristiques = _
            Me.idCrodip & "|" & _
            Me.marque & "|" & _
            Me.classe & "|" & _
            Me.type & "|" & _
            Me.fondEchelle & "|" & _
            Me.idStructure & "|" & _
            Me.isSynchro & "|" & _
            Me.dateDernierControleS & "|" & _
            Me.dateModificationAgent & "|" & _
            Me.dateModificationCrodip
            oFV.dateModif = CSDate.ToCRODIPString(Date.Now).ToString
            oFV.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            FVManometreControleManager.save(oFV)
            oReturn = oFV
        Catch ex As Exception
            CSDebug.dispError("ManometreControle.creerFicheVie : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Function setUtilise(ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            If Not isUtilise() Then
                If Me.creerFicheViePremiereUtilisation(pAgent) Then
                    Me.isUtilise = True
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ManometreControle.setUtilise() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' incréement du nombre de controle réalisé par un Mano
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub incNbControles()
        nbControles = nbControles + 1
        nbControlesTotal = nbControlesTotal + 1
    End Sub


    Public Sub SetUpdated()
        m_bIsUpdated = True
    End Sub
    Public Function isUpdated() As Boolean
        Return m_bIsUpdated
    End Function
    'Public Shared Sub incNbControles(ByVal objManometreControle As ManometreControle)
    '    Try
    '        Dim dbLink As New CSDb(True)
    '        dbLink.queryString = "UPDATE AgentManoControle SET nbControles=(nbControles+1), nbControlesTotal=(nbControlesTotal+1) WHERE numeroNational='" & objManometreControle.numeroNational & "'"
    '        dbLink.getResults()
    '        dbLink.free()
    '    Catch ex As Exception
    '        CSDebug.dispFatal("ManometreControleManager::incNbControles : " & ex.Message)
    '    End Try
    'End Sub



    'Public Function creerFicheVie(ByVal pType As String, ByVal pAgent As Agent) As Boolean
    '    Debug.Assert(pAgent IsNot Nothing)
    '    Dim bReturn As Boolean

    '    Try
    '        Dim newFicheVieManoControle As New FVManometreControle(pAgent)
    '        newFicheVieManoControle.idManometre = Me.idCrodip
    '        newFicheVieManoControle.type = pType
    '        newFicheVieManoControle.auteur = "AGENT"
    '        newFicheVieManoControle.idAgentControleur = pAgent.id
    '        newFicheVieManoControle.caracteristiques = _
    '        Me.idCrodip & "|" & _
    '        Me.marque & "|" & _
    '        Me.classe & "|" & _
    '        Me.type & "|" & _
    '        Me.fondEchelle & "|" & _
    '        Me.idStructure & "|" & _
    '        Me.isSynchro & "|" & _
    '        Me.dateDernierControle & "|" & _
    '        Me.dateModificationAgent & "|" & _
    '        Me.dateModificationCrodip
    '        newFicheVieManoControle.dateModif = CSDate.ToCRODIPString(Date.Now).ToString
    '        newFicheVieManoControle.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
    '        FVManometreControleManager.save(newFicheVieManoControle)
    '        bReturn = True
    '    Catch ex As Exception
    '        CSDebug.dispError("ManometreControle.creerFicheVieActivation ERR : " & ex.Message)
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function 'CreerFiche


End Class