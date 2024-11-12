Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Data.Common

<Serializable(), XmlInclude(GetType(Banc))>
Public Class Banc
    Inherits Materiel

    Private Shadows _id As String
    Private _marque As String
    Private _modele As String
    Private _dateAchat As String
    Private _isUtilise As Boolean
    Private _nbControles As Integer
    Private _nbControlesTotal As Integer
    Private _ModuleAcquisition As String
    <XmlIgnore>
    Public Overloads Property id() As String
        Get
            Return aid
        End Get
        Set(ByVal value As String)
            aid = value
        End Set
    End Property
    Sub New()
        MyBase.New()
        jamaisServi = True
        _lstPools = New List(Of Pool)
    End Sub

    Private _lstPools As List(Of Pool)
    <XmlIgnore>
    Public Property lstPools() As List(Of Pool)
        Get
            Return _lstPools
        End Get
        Set(ByVal value As List(Of Pool))
            _lstPools = value
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
    <XmlElement("nbControles")>
    Public Property nbControlesS() As String
        Get
            Return _nbControles
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                nbControles = CInt(Value)
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property nbControles() As Integer
        Get
            Return _nbControles
        End Get
        Set(ByVal Value As Integer)
            _nbControles = Value
        End Set
    End Property

    <XmlElement("nbControlesTotal")>
    Public Property nbControlesTotalS() As String
        Get
            Return nbControlesTotal
        End Get
        Set(ByVal Value As String)
            If Not String.IsNullOrEmpty(Value) Then
                _nbControlesTotal = Value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property nbControlesTotal() As Integer
        Get
            Return _nbControlesTotal
        End Get
        Set(ByVal Value As Integer)
            _nbControlesTotal = Value
        End Set
    End Property
    Public Property moduleAcquisition() As String
        Get
            Return _ModuleAcquisition
        End Get
        Set(ByVal Value As String)
            _ModuleAcquisition = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Overrides Property Libelle() As String
        Get
            Return "Banc de mesure : " + id
        End Get
        Set(value As String)

        End Set
    End Property

    Public Overrides Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Dim bReturn As Boolean
        Try
            If Not isUtilise Then
                'Création de la Fiche de vie de suppression
                If creerFicheVieSuppression(pAgentSuppression) Then
                    'Le banc est marqué comme supprimé

                    bReturn = True
                    Me.agentSuppression = pAgentSuppression.nom
                    Me.raisonSuppression = pRaison
                    Me.dateSuppression = Now()
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

    Public Overrides Function Fill(pColName As String, pcolValue As Object) As Boolean
        Dim bReturn As Boolean = True
        Try
            If Not MyBase.Fill(pColName, pcolValue) Then
                bReturn = True
                ' Console.WriteLine(pColName & " . " & pcolValue.ToString())
                Select Case pColName.Trim().ToUpper()
                    Case "id".Trim().ToUpper()
                        Me.id = pcolValue.ToString() 'Public id As String
                        Me.numeroNational = pcolValue.ToString() 'Public id As String
                    Case "idstructure".Trim().ToUpper()
                        Me.uidstructure = pcolValue.ToString() 'Public idAgent As String
                    Case "marque".Trim().ToUpper()
                        Me.marque = pcolValue.ToString() 'Public marque As String
                    Case "modele".Trim().ToUpper()
                        Me.modele = pcolValue.ToString() 'Public modele As String
                    Case "dateachat".Trim().ToUpper()
                        If Not CDate(pcolValue).Equals(CDate("1899-12-30")) Then
                            Me.dateAchat = CSDate.ToCRODIPString(pcolValue.ToString()) 'Public dateAchat As String
                        End If
                    Case "datederniercontrole".Trim().ToUpper()
                        Me.dateDernierControleS = CSDate.ToCRODIPString(pcolValue).ToString 'Public dateAchat As String
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
                    Case "ModuleAcquisition".Trim().ToUpper()
                        Me.ModuleAcquisition = pcolValue
                    Case "idCrodipPool".Trim().ToUpper()
                    Case "uidstructure".Trim().ToUpper()
                        Me.uidstructure = pcolValue
                    Case Else
                        CSDebug.dispError("Banc.Fill  (" + pColName + "," + pcolValue.ToString + ") ERR : Champs inconnu")
                        bReturn = False


                End Select

            End If
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
    Public Function Desactiver(ByVal pAgent As Agent) As Boolean
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

        oNiveau = getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.Banc)
        If IsDateControle() Then
            bReturn = MyBase.getAlerte(dateDernierControle, oNiveau)
        End If
        If bReturn = GlobalsCRODIP.ALERTE.NONE Then
            If etat = False Then
                bReturn = GlobalsCRODIP.ALERTE.CONTROLE
            End If
        End If
        Return bReturn
    End Function
    '''
    ''' Calcul du nombre de jours restant avant la date limite de controle
    Public Function getNbJoursAvantAlerteRouge() As Integer
        Dim dernCtrl As Date = CSDate.FromCrodipString(Me.dateDernierControleS)
        Dim DL As Date
        Dim n As Integer
        Dim oNiveau As NiveauAlerte
        oNiveau = getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.Banc)
        DL = DateAdd(DateInterval.DayOfYear, oNiveau.Rouge * -1, Now) '1 mois 

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
    Public Function creerfFicheVieControle(ByVal pAgent As Agent, pControleBanc As ControleBanc, pFileName As String) As FVBanc
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

                ' On CONSTruit le PDF de rapport à partir de l'objet m_oControleBanc
                'Dim sFileName As String = pControleBanc.buildPDF(Me, pAgent)
                oFV.FVFileName = pFileName

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
            newFicheVieBanc.caracteristiques =
            Me.id & "|" &
            Me.marque & "|" &
            Me.modele & "|" &
            Me.dateAchat & "|" &
            Me.uidstructure & "|" &
            Me.DateActivation & "|" &
            Me.dateDernierControleS & "|" &
            Me.dateModificationAgent & "|" &
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