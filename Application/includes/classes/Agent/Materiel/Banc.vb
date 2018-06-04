Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(Banc))> _
Public Class Banc
    Inherits Materiel

    Private _id As String
    Private _marque As String
    Private _modele As String
    Private _dateAchat As String
    Private _isUtilise As Boolean
    Private _nbControles As Integer
    Private _nbControlesTotal As Integer


    Sub New()
        JamaisServi = True

    End Sub

    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal Value As String)
            _id = Value
        End Set
    End Property


    Public Property marque() As String
        Get
            Return _marque
        End Get
        Set(ByVal Value As String)
            _marque = Value
        End Set
    End Property

    Public Property modele() As String
        Get
            Return _modele
        End Get
        Set(ByVal Value As String)
            _modele = Value
        End Set
    End Property

    Public Property dateAchat() As String
        Get
            Return _dateAchat
        End Get
        Set(ByVal Value As String)
            _dateAchat = Value
        End Set
    End Property


    Public Property isUtilise() As Boolean
        Get
            Return _isUtilise
        End Get
        Set(ByVal Value As Boolean)
            _isUtilise = Value
        End Set
    End Property


    Public Property nbControles() As Integer
        Get
            Return _nbControles
        End Get
        Set(ByVal Value As Integer)
            _nbControles = Value
        End Set
    End Property

    Public Property nbControlesTotal() As Integer
        Get
            Return _nbControlesTotal
        End Get
        Set(ByVal Value As Integer)
            _nbControlesTotal = Value
        End Set
    End Property

    Public Overrides ReadOnly Property Libelle() As String
        Get
            Return "Banc de mesure : " + id
        End Get
    End Property

    Public Overrides Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Dim bReturn As Boolean
        Try
            If Not isUtilise Then
                'Création de la Fiche de vie de suppression
                If creerFicheVieSuppression(pAgentSuppression) Then
                    'Le banc est marqué comme supprimé

                    bReturn = True
                    Me.AgentSuppression = pAgentSuppression.nom
                    Me.RaisonSuppression = pRaison
                    Me.DateSuppression = Now()
                    Me.isSupprime = True
                    bReturn = BancManager.save(Me)
                End If
            End If

        Catch ex As Exception
            CSDebug.dispError("Banc.DeleteMateriel : Error : " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function Fill(oDataReader As OleDb.OleDbDataReader) As Boolean
        Dim bReturn As Boolean
        Try
            Dim tmpColId As Integer = 0
            bReturn = True
            While tmpColId < oDataReader.FieldCount()
                If Not oDataReader.IsDBNull(tmpColId) Then
                    bReturn = bReturn And Fill(oDataReader.GetName(tmpColId).Trim().ToLower(), oDataReader.Item(tmpColId))
                End If
                tmpColId = tmpColId + 1
            End While

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Banc.Fill ERR : " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function Fill(pColName As String, pcolValue As Object) As Boolean
        Dim bReturn As Boolean
        Try

            Select Case pColName.Trim().ToUpper()
                Case "id".Trim().ToUpper()
                    Me.id = pcolValue.ToString() 'Public id As String
                    Me.numeroNational = pcolValue.ToString() 'Public id As String
                Case "idstructure".Trim().ToUpper()
                    Me.idStructure = pcolValue.ToString() 'Public idAgent As String
                Case "marque".Trim().ToUpper()
                    Me.marque = pcolValue.ToString() 'Public marque As String
                Case "modele".Trim().ToUpper()
                    Me.modele = pcolValue.ToString() 'Public modele As String
                Case "dateachat".Trim().ToUpper()
                    If Not CDate(pcolValue).Equals(CDate("30/12/1899")) Then
                        Me.dateAchat = CSDate.ToCRODIPString(pcolValue.ToString()) 'Public dateAchat As String
                    End If
                Case "datederniercontrole".Trim().ToUpper()
                    Me.dateDernierControleS = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateAchat As String
                Case "datemodificationagent".Trim().ToUpper()
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateModificationAgent As String
                Case "datemodificationcrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateModificationCrodip As String
                Case "etat".Trim().ToUpper()
                    Me.etat = CType(pcolValue, Boolean) 'Public etat As String
                Case "issupprime".Trim().ToUpper()
                    Me.isSupprime = CType(pcolValue, Boolean)
                Case "isutilise".Trim().ToUpper()
                    Me.isUtilise = CType(pcolValue, Boolean)
                Case "nbcontroles".Trim().ToUpper()
                    Me.nbControles = CType(pcolValue, Integer)
                Case "nbcontrolestotal".Trim().ToUpper()
                    Me.nbControlesTotal = CType(pcolValue, Integer)
                Case "issupprime".Trim().ToUpper()
                    Me.isSupprime = CType(pcolValue, Boolean) 'Public isSupprime As Boolean
                Case "agentsuppression".Trim().ToUpper()
                    Me.AgentSuppression = pcolValue.ToString()
                Case "raisonsuppression".Trim().ToUpper()
                    Me.RaisonSuppression = pcolValue.ToString()
                Case "datesuppression".Trim().ToUpper()
                    Me.DateSuppression = CSDate.ToCRODIPString(pcolValue).ToString()
                Case "jamaisServi".Trim().ToUpper()
                    Me.JamaisServi = pcolValue
                Case "dateActivation".Trim().ToUpper()
                    Me.DateActivation = pcolValue
            End Select

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Banc.Fill  (" + pColName + "," + pcolValue.ToString + ") ERR : " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Désactivation du banc (le controle du banc n'a pas été effectué)
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function DesactiverBanc(ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean

        Try
            bReturn = False
            If creerFicheVieDesactivation(pAgent) Then
                ' On bloque le banc
                Me.etat = False
                BancManager.save(Me)
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispError("Banc.desactiverBanc : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function getAlerte() As Globals.ALERTE
        Dim bReturn As Globals.ALERTE
        bReturn = Globals.ALERTE.NONE

        Dim dernCtrl As Date = CSDate.FromCrodipString(Me.dateDernierControleS)
        Dim n As Integer
        Dim DL As Date
        DL = DateAdd(DateInterval.DayOfYear, -7, DateAdd(DateInterval.Month, -1, Now)) '1 mois et 7 jours
        n = dernCtrl.CompareTo(DL)
        If n < 0 Then
            bReturn = Globals.ALERTE.NOIRE
        End If
        If bReturn = Globals.ALERTE.NONE Then
            DL = DateAdd(DateInterval.Month, -1, Now) '1 mois 
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return Globals.ALERTE.ROUGE
            End If
        End If
        If bReturn = Globals.ALERTE.NONE Then
            DL = DateAdd(DateInterval.Month, -1, Now) '1 mois 
            DL = DateAdd(DateInterval.DayOfYear, +15, DL) '1 mois 
            n = dernCtrl.CompareTo(DL)
            If n < 0 Then
                Return Globals.ALERTE.ORANGE
            End If
        End If

        Return bReturn
    End Function
    '''
    ''' Calcul du nombre de jours restant avant la date limite de controle
    Public Function getNbJoursAvantDateLimite() As Integer
        Dim dernCtrl As Date = CSDate.FromCrodipString(Me.dateDernierControleS)
        Dim DL As Date
        Dim n As Integer
        DL = DateAdd(DateInterval.Month, -1, Now) '1 mois 

        n = DateDiff(DateInterval.DayOfYear, DL, dernCtrl)

        Return n
    End Function
    Public Function setUtilise(ByVal pAgent As Agent) As Boolean

        Dim bReturn As Boolean
        Try
            If Not Me.isUtilise Then
                'Création de La FV de première utilisation
                If Me.creerFicheViePremiereUtilisation(pAgent) Then
                    ' On met a jour en base
                    Me.isUtilise = True
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("Banc.setUtilise() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Sub incNbControles()
        Me.nbControles = nbControles + 1
        Me.nbControlesTotal = nbControlesTotal + 1
    End Sub

    Public Overrides Function creerFicheVieActivation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVBanc.FVTYPE_MISENSERVICE, pAgent) IsNot Nothing
    End Function

    Public Function creerFicheViePremiereUtilisation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVBanc.FVTYPE_PREMIEREUTILISATION, pAgent) IsNot Nothing
    End Function
    Public Function creerFicheVieSuppression(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVBanc.FVTYPE_SUPPRESSION, pAgent) IsNot Nothing
    End Function
    Public Function creerFicheVieDesactivation(ByVal pAgent As Agent) As Boolean
        Return creerFicheVie(FVBanc.FVTYPE_DESACTIVATION, pAgent) IsNot Nothing
    End Function
    Public Function creerfFicheVieControle(ByVal pAgent As Agent, pControleBanc As ControleBanc) As FVBanc
        Dim oReturn As FVBanc = Nothing
        Try
            Dim oFV As FVBanc
            oFV = creerFicheVie(FVBanc.FVTYPE_CONTROLE, pAgent)
            If oFV IsNot Nothing Then

                ' Contrôle OK ou NOK
                If Me.etat Then
                    oFV.blocage = False
                Else
                    oFV.blocage = True
                End If

                ' On Globals.CONSTruit le PDF de rapport à partir de l'objet m_oControleBanc
                Dim sFileName As String = pControleBanc.buildPDF(Me, pAgent)
                oFV.FVFileName = sFileName

                FVBancManager.save(oFV)
                oReturn = oFV

            End If
        Catch ex As Exception
            CSDebug.dispError("Banc.CreerFicheVieControle : ERR" & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Private Function creerFicheVie(ByVal pType As String, ByVal pAgent As Agent) As FVBanc
        Debug.Assert(pAgent IsNot Nothing)
        Dim oReturn As FVBanc

        Try
            Dim newFicheVieBanc As New FVBanc(pAgent)
            newFicheVieBanc.idBancMesure = Me.id
            newFicheVieBanc.type = pType
            newFicheVieBanc.auteur = "AGENT"
            newFicheVieBanc.caracteristiques = _
            Me.id & "|" & _
            Me.marque & "|" & _
            Me.modele & "|" & _
            Me.dateAchat & "|" & _
            Me.idStructure & "|" & _
            Me.DateActivation & "|" & _
            Me.dateDernierControleS & "|" & _
            Me.dateModificationAgent & "|" & _
            Me.dateModificationCrodip
            newFicheVieBanc.dateModif = CSDate.ToCRODIPString(Date.Now).ToString
            newFicheVieBanc.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            newFicheVieBanc.blocage = False
            FVBancManager.save(newFicheVieBanc)
            oReturn = newFicheVieBanc
        Catch ex As Exception
            CSDebug.dispError("Banc.creerFicheVie : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function


End Class