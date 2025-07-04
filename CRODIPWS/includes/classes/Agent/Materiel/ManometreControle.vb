Imports System.Data.Common
Imports System.IO
Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(ManometreControle))>
Public Class ManometreControle
    Inherits Manometre
    Implements IComparable

    Private _resolution As String = ""
    Private _resolutionLecture As String = ""
    Private m_bIsUpdated As Boolean
    Sub New()
        m_bIsUpdated = False
        bAjusteur = False
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
    <XmlIgnore>
    Public Property resolution_d() As Double
        Get
            Try
                Return GlobalsCRODIP.StringToDouble(_resolution)
            Catch ex As Exception
                Return CDbl(0)
            End Try
        End Get
        Set
        End Set
    End Property
    Public Property resolutionLecture() As String
        Get
            Return _resolutionLecture
        End Get
        Set(ByVal Value As String)
            _resolutionLecture = Value
        End Set
    End Property
    <XmlIgnore>
    Public Property resolutionLecture_d() As Double
        Get
            Try
                Return GlobalsCRODIP.StringToDouble(_resolutionLecture)
            Catch ex As Exception
                Return CDbl(0)
            End Try
        End Get
        Set
        End Set
    End Property
    <XmlElement("bAjusteur")>
    Public Property bAjusteurWS() As Integer
        Get
            Return CInt(_bAjusteur)
        End Get
        Set(ByVal value As Integer)
            _bAjusteur = CBool(value)
        End Set
    End Property
    Private _bAjusteur As Boolean
    <XmlIgnore>
    Public Property bAjusteur() As Boolean
        Get
            Return _bAjusteur
        End Get
        Set(ByVal value As Boolean)
            _bAjusteur = value
        End Set
    End Property
    <XmlIgnore>
    Public Overrides Property libelle() As String
        Get
            Dim sLibelle As String = "   "
            If m_bIsUpdated Then
                sLibelle = " * "
            End If
            sLibelle = sLibelle + numeroNational
            sLibelle = sLibelle + "[" + Traca + "]"
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
    Public Function getPressionCtrl(pNum As Integer) As String
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
    Private _typeTraca As String = ""
    Public Property typeTraca() As String
        Get
            Return _typeTraca
        End Get
        Set(ByVal value As String)
            _typeTraca = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property IsTypeTracaH() As Boolean
        Get
            If Not String.IsNullOrEmpty(typeTraca) Then
                Return (typeTraca.Equals("H"))
            Else
                Return False

            End If
        End Get
        Set(ByVal value As Boolean)
            If value Then
                typeTraca = "H"
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property IsTypeTracaB() As Boolean
        Get
            If Not String.IsNullOrEmpty(typeTraca) Then
                Return (typeTraca.Equals("B"))
            Else
                Return False

            End If
        End Get
        Set(ByVal value As Boolean)
            If value Then
                typeTraca = "B"
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property IsTypeRaccordRA() As Boolean
        Get
            If Not String.IsNullOrEmpty(typeRaccord) Then
                Return (typeRaccord.Equals("RA"))
            Else
                Return False

            End If
        End Get
        Set(ByVal value As Boolean)
            If value Then
                typeRaccord = "RA"
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property IsTypeRaccordRV() As Boolean
        Get
            If Not String.IsNullOrEmpty(typeRaccord) Then
                Return (typeRaccord.Equals("RV"))
            Else
                Return False

            End If
        End Get
        Set(ByVal value As Boolean)
            If value Then
                typeRaccord = "RV"
            End If
        End Set
    End Property
    Private _numTraca As Integer
    <XmlIgnoreAttribute()>
    Public Property numTraca() As Integer
        Get
            Return _numTraca
        End Get
        Set(ByVal value As Integer)
            _numTraca = value
        End Set
    End Property
    <XmlElement("numTraca")>
    Public Property numTracaS() As String
        Get
            Return numTraca.ToString()
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                numTraca = CInt(value)
            End If
        End Set
    End Property
    Private _typeRaccord As String = ""
    Public Property typeRaccord() As String
        Get
            Return _typeRaccord
        End Get
        Set(ByVal value As String)
            _typeRaccord = value
        End Set
    End Property
    Public ReadOnly Property Traca() As String
        Get
            If String.IsNullOrEmpty(typeTraca) Then
                Return ""
            Else
                Return typeTraca & numTraca
            End If
        End Get
    End Property


    Public Overrides Function Fill(ByVal pColName As String, ByVal pValue As Object) As Boolean
        Dim bReturn As Boolean = True
        If Not MyBase.Fill(pColName, pValue) Then
            bReturn = True
            Select Case pColName.Trim().ToUpper()
                Case "numeroNational".Trim.ToUpper()
                    Me.numeroNational = pValue.ToString() 'Public numeroNational As String
                Case "idCrodip".Trim.ToUpper()
                    Me.idCrodip = pValue.ToString()
                Case "idStructure".Trim.ToUpper(), "uidstructure".Trim.ToUpper()
                    Me.uidStructure = pValue.ToString()
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
                Case "bajusteur".Trim().ToUpper()
                    Me.bAjusteur = CType(pValue, Boolean)
                Case "dateDernierControle".Trim.ToUpper()
                    Dim dateC As Date
                    Try
                        dateC = CDate(pValue)
                        If dateC.Year <> 1899 And dateC.Year <> 0 Then
                            Me.dateDernierControleS = CSDate.ToCRODIPString(pValue).ToString 'Public dateAchat As String
                        End If
                    Catch ex As Exception

                    End Try
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
                Case "resolutionLecture".Trim.ToUpper()
                    Me.resolutionLecture = pValue.ToString()
                Case "agentsuppression".Trim().ToUpper()
                    Me.agentSuppression = pValue.ToString()
                Case "raisonsuppression".Trim().ToUpper()
                    Me.raisonSuppression = pValue.ToString()
                Case "datesuppression".Trim().ToUpper()
                    Dim strDateMin As String = CSDate.ToCRODIPString("")
                    Dim strDateValue As String = CSDate.ToCRODIPString(pValue)
                    If strDateValue <> strDateMin And strDateValue <> "1899-12-30 00:00:00" Then
                        Me.dateSuppression = CSDate.ToCRODIPString(pValue).ToString()
                    Else
                        Me.dateSuppression = ""
                    End If
                Case "jamaisServi".Trim().ToUpper()
                    Me.jamaisServi = pValue
                Case "dateActivation".Trim().ToUpper()
                    Me.DateActivation = pValue
                Case "typeTraca".Trim().ToUpper()
                    Me.typeTraca = pValue
                Case "numTraca".Trim().ToUpper()
                    Me.numTraca = pValue
                Case "typeRaccord".Trim().ToUpper()
                    Me.typeRaccord = pValue
                Case Else
                    bReturn = False
            End Select
        End If

        Return bReturn
    End Function
    Public Overrides Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Me.creerFicheVieSuppression(pAgentSuppression)
        Me.agentSuppression = pAgentSuppression.nom
        Me.raisonSuppression = pRaison
        Me.dateSuppression = Now.ToString()
        Me.dateModificationAgent = Now()
        Me.isSupprime = True
        ManometreControleManager.save(Me)
    End Function

    Public Function Desactiver(ByVal pAgent As Agent) As Boolean
        Dim bReturn As Boolean

        Try
            ' On bloque le mano
            Me.etat = False
            creerFicheVieDesactivation(pAgent)
            ManometreControleManager.save(Me)
            If GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
                Dim oReturn As ManometreControle = Nothing
                ManometreControleManager.WSSend(Me, oReturn)
            End If
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
        Dim dateDernCtrl As Date

        If Not String.IsNullOrEmpty(dateDernierControleS) Then
            dateDernCtrl = dateDernierControle
        Else
            dateDernCtrl = dateActivation
        End If

        Dim oNiveau As NiveauAlerte
        oNiveau = getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.ManometreControle)

        bReturn = MyBase.getAlerte(dateDernCtrl, oNiveau)

        If bReturn = GlobalsCRODIP.ALERTE.NONE And etat = False Then
                    bReturn = GlobalsCRODIP.ALERTE.CONTROLE
                End If
        Return bReturn
    End Function
    '''
    ''' Calcul du nombre de jours restant avant L'alerteRouge
    Public Function getNbJoursAvantAlerteRouge() As Integer
        Dim tmpDateLCManoControle As Date = CSDate.FromCrodipString(Me.dateDernierControleS)
        'Dim dateDernCtrl As Date

        If Not String.IsNullOrEmpty(dateDernierControleS) Then
            tmpDateLCManoControle = dateDernierControle
        Else
            tmpDateLCManoControle = dateActivation
        End If
        Dim DL As Date
        Dim n As Integer
        Dim oNiveau As NiveauAlerte
        oNiveau = Materiel.getNiveauAlerte(NiveauAlerte.Enum_typeMateriel.ManometreControle)
        Dim nbJRouge As Integer = oNiveau.Rouge
        DL = DateAdd(DateInterval.DayOfYear, -nbJRouge, Now) ''Date limit pour passer En alerte Rouge


        n = DateDiff(DateInterval.DayOfYear, DL, tmpDateLCManoControle)

        Return Math.Abs(n)
    End Function
    Public Function getDernFicheActivation() As FVManometreControle
        Dim olst As List(Of FVManometreControle) = FVManometreControleManager.getLstFVManometreControleByuid(Me.uid)
        'Filtre sur le Type de FV
        olst = olst.Where(Function(oFV)
                              Try
                                  Return oFV.type = FVManometreControle.FVTYPE_MISENSERVICE
                              Catch ex As Exception
                                  Return False
                              End Try
                          End Function).ToList()
        'Tri sur la date de Modif
        olst = olst.OrderBy(Function(oFV)
                                Return oFV.dateModif
                            End Function).ToList()
        'Return de la plus grande
        If olst.Count > 0 Then
            Return olst.Last
        Else
            Return Nothing
        End If
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
    Public Function creerfFicheVieControle(ByVal pAgent As Agent, pControleMano As ControleMano, pFileName As String) As FVManometreControle
        Dim oReturn As FVManometreControle = Nothing
        Try
            Dim oFV As FVManometreControle
            CSDebug.dispInfo("ManometreControle.creerfFicheVieControle() :  Creation FV")

            oFV = creerFicheVie(FVMateriel.FVTYPE_CONTROLE, pAgent)
            If oFV IsNot Nothing Then


                oFV.idManometre = Me.idCrodip
                oFV.caracteristiques =
                Me.idCrodip & "|" &
                Me.marque & "|" &
                Me.classe & "|" &
                Me.type & "|" &
                Me.fondEchelle & "|" &
                Me.uidstructure & "|" &
                Me.isSynchro & "|" &
                Me.dateDernierControleS & "|" &
                Me.dateModificationAgent & "|" &
                Me.dateModificationCrodip

                oFV.idReetalonnage = ""
                oFV.nomLaboratoire = ""
                oFV.dateReetalonnage = ""
                oFV.idManometreControleur = pControleMano.manoEtalon

                ' On r�cup�re les pressions de controle
                oFV.pressionControle = pControleMano.PressionControle
                oFV.valeursMesurees = pControleMano.ValeursMesurees
                ' Contr�le OK ou NOK
                oFV.blocage = Not Me.etat
                oFV.dateModif = pControleMano.DateVerif
                ' On GlobalsCRODIP.CONSTruit le PDF de rapport � partir de l'objet m_oControleBanc
                CSDebug.dispInfo("ManometreControle.creerfFicheVieControle() :  buildPDF")
                'Dim sFileName As String = pControleMano.buildPDF()
                oFV.FVFileName = pFileName


                CSDebug.dispInfo("ManometreControle.creerfFicheVieControle() :  Save oFV")
                FVManometreControleManager.save(pAgent, oFV)

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
            oFV.uidmanometre = Me.uid
            oFV.type = pType
            oFV.auteur = "AGENT"
            oFV.idAgentControleur = pAgent.id
            oFV.blocage = Not Me.etat
            oFV.caracteristiques =
        Me.idCrodip & "|" &
        Me.marque & "|" &
        Me.classe & "|" &
        Me.type & "|" &
        Me.fondEchelle & "|" &
        Me.uidStructure & "|" &
        Me.isSynchro & "|" &
        Me.dateDernierControleS & "|" &
        Me.dateModificationAgent & "|" &
        Me.dateModificationCrodip
            oFV.dateModif = CSDate.ToCRODIPString(Date.Now).ToString
            oFV.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            FVManometreControleManager.save(pAgent, oFV)
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
    ''' incr�ement du nombre de controle r�alis� par un Mano
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

    Public Function creerControle(pAgent As Agent) As ControleMano
        Me.controle = New ControleMano(Me, pAgent)
        Return controle
    End Function

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        If obj Is Nothing Then
            Return 1
        Else
            Return Me.numTraca.CompareTo(obj.numTraca)
        End If
    End Function
    Public Overrides Function ActiverMateriel(ByVal pDateActivation As Date, ByVal pAgent As Agent) As Boolean
        Debug.Assert(Not CSDate.isDateNull(pDateActivation), "Date non nulle")
        Debug.Assert(pAgent IsNot Nothing, "Agent initialis�")
        Dim bReturn As Boolean
        Try
            GlobalsCRODIP.GLOB_NETWORKAVAILABLE = CSEnvironnement.checkNetwork()

            If GlobalsCRODIP.GLOB_NETWORKAVAILABLE Then
                jamaisServi = False
                etat = True
                dateActivation = pDateActivation
                dateDernierControle = pDateActivation
                bReturn = creerFicheVieActivation(pAgent)
                Dim oFV As FVManometreControle = getDernFicheActivation()
                SynchronisationASCManos(pAgent, oFV, Nothing)
            Else
                MsgBox("Vous devez �tre connect� � internet pour valider votre controle", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
            End If


        Catch ex As Exception
            CSDebug.dispError("Materiel.ActiverMateriel ERR: " & ex.Message)
            bReturn = False

        End Try
        Return bReturn
    End Function 'ActiverMateriel
    Public Sub SynchronisationASCManos(pAgent As Agent, oFV As FVManometreControle, Optional tmpManometreEtalon As ManometreEtalon = Nothing)
        'Remont�e des infos vers le serveur
        Dim oReturn As ManometreControle = Nothing
        Dim oReturnFV As FVManometreControle = Nothing
        Dim oReturnME As ManometreEtalon = Nothing
        ManometreControleManager.WSSend(Me, oReturn)
        If oReturn IsNot Nothing Then
            ManometreControleManager.save(oReturn, True)
        End If
        If oFV IsNot Nothing Then
            FVManometreControleManager.WSSend(oFV, oReturnFV)
            FVManometreControleManager.SendEtats(oFV)
            If oReturnFV IsNot Nothing Then
                FVManometreControleManager.save(pAgent, oReturnFV, True)
            End If
        End If
        If tmpManometreEtalon IsNot Nothing Then
            ManometreEtalonManager.WSSend(tmpManometreEtalon, oReturnME)
            If oReturnME IsNot Nothing Then
                ManometreEtalonManager.save(oReturnME, True)
            End If
        End If
    End Sub
End Class
