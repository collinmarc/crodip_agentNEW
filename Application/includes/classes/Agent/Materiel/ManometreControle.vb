Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(ManometreControle))> _
Public Class ManometreControle
    Inherits Manometre

    Private _resolution As String


    Sub New()

    End Sub


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
                Return StringToDouble(_resolution)
            Catch ex As Exception
                Return CDbl(0)
            End Try
        End Get
    End Property

    Public Overrides ReadOnly Property Libelle() As String
        Get
            Return "Manométre de contrôle : " + idCrodip
        End Get
    End Property
    Public Function Fill(ByVal oDataReader As OleDb.OleDbDataReader) As Boolean
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
                Me.dateDernierControle = CSDate.ToCRODIPString(pValue).ToString 'Public dateAchat As String
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
                Me.DateSuppression = CSDate.ToCRODIPString(pValue).ToString()
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

    Public Function DesactiverMano(ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean

        Try
            creerFicheVieDesactivation(pAgent)
            ' On bloque le mano
            Me.etat = False
            ManometreControleManager.save(Me)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ManometreControle.desactiverMano : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function getAlerte() As ALERTE
        Dim bReturn As ALERTE
        bReturn = ALERTE.NONE

        Dim tmpDateLCManoControle As Date = CSDate.FromCrodipString(Me.dateDernierControle)
        Dim n As Integer
        Dim DL As Date
        DL = DateAdd(DateInterval.DayOfYear, -7, DateAdd(DateInterval.Month, -1, Now)) '1 mois et 7 jours
        n = tmpDateLCManoControle.CompareTo(DL)
        If n < 0 Then
            bReturn = ALERTE.NOIRE
        End If
        If bReturn = ALERTE.NONE Then
            DL = DateAdd(DateInterval.Month, -1, Now) '1 mois 
            n = tmpDateLCManoControle.CompareTo(DL)
            If n < 0 Then
                Return ALERTE.ROUGE
            End If
        End If
        If bReturn = ALERTE.NONE Then
            DL = DateAdd(DateInterval.Month, -1, Now) '1 mois 
            DL = DateAdd(DateInterval.DayOfYear, +15, DL) '1 mois 
            n = tmpDateLCManoControle.CompareTo(DL)
            If n < 0 Then
                Return ALERTE.ORANGE
            End If
        End If

        Return bReturn
    End Function
    '''
    ''' Calcul du nombre de jours restant avant la date limite de controle
    Public Function getNbJoursAvantDateLimite() As Integer
        Dim tmpDateLCManoControle As Date = CSDate.FromCrodipString(Me.dateDernierControle)
        Dim DL As Date
        Dim n As Integer
        DL = DateAdd(DateInterval.Month, -1, Now) '1 mois 

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
        Dim oReturn As FVManometreControle
        Try
            Dim oFV As FVManometreControle
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
                Me.dateDernierControle & "|" & _
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

                ' On construit le PDF de rapport à partir de l'objet m_oControleBanc
                Dim sFileName As String = pControleMano.buildPDF()
                oFV.FVFileName = sFileName

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
            Me.dateDernierControle & "|" & _
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