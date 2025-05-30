
Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq
Imports CRODIPWS.WSCRODIP
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
<Serializable(), XmlInclude(GetType(Synchronisation))>
Public Class Synchronisation
    Inherits Observe

    Private _sens As String
    Private _dateSync As String
    Private _checksumCalc As String
    Private m_bTraitee As Boolean
    Private m_Agent As Agent
    Public m_SynchroBoolean As New SynchroBooleans
    'Boolean de synchronisation

    Private m_ListeElementSynchroASC As New List(Of SynchronisationElmt)

    Sub New(pAgent As Agent)
        m_bTraitee = False
        setAllSynchroTrue()
        m_Agent = pAgent
        If GlobalsCRODIP.GLOB_ENV_DEBUG Then
            setAllSynchroToDBG()
        End If
    End Sub
    Private Sub setAllSynchroTrue()
        m_SynchroBoolean.m_bSynchAscDiag = True
        m_SynchroBoolean.m_bSynchAscAgent = True
        m_SynchroBoolean.m_bSynchAscExploitation = True
        m_SynchroBoolean.m_bSynchAscBanc = True
        m_SynchroBoolean.m_bSynchAscMano = True
        m_SynchroBoolean.m_bSynchAscPrestation = True
        m_SynchroBoolean.m_bSynchAscBuse = True
        m_SynchroBoolean.m_bsynchAscFV = True
        m_SynchroBoolean.m_bSynchAscPulve = True
        m_SynchroBoolean.m_bSynchAscAutotests = True
        m_SynchroBoolean.m_bSynchDescPrestation = True
        m_SynchroBoolean.m_bSynchDescDiag = True
        m_SynchroBoolean.m_bSynchDescReferentiel = True
        m_SynchroBoolean.m_bSynchDescExploitation = True
        m_SynchroBoolean.m_bSynchDescAgent = True
        m_SynchroBoolean.m_bSynchDescBuse = True
        m_SynchroBoolean.m_bSynchDescMano = True
        m_SynchroBoolean.m_bSynchDescBanc = True
        m_SynchroBoolean.m_bSynchDescFV = True
        m_SynchroBoolean.m_bSynchDescPulve = True
        m_SynchroBoolean.m_bSynchDescDocument = True
    End Sub
    Private Sub setAllSynchroToDBG()
        m_SynchroBoolean.m_bSynchAscDiag = True
        m_SynchroBoolean.m_bSynchAscAgent = True
        m_SynchroBoolean.m_bSynchAscExploitation = True
        m_SynchroBoolean.m_bSynchAscBanc = True
        m_SynchroBoolean.m_bSynchAscMano = True
        m_SynchroBoolean.m_bSynchAscPrestation = True
        m_SynchroBoolean.m_bSynchAscBuse = True
        m_SynchroBoolean.m_bsynchAscFV = True
        m_SynchroBoolean.m_bSynchAscPulve = True
        m_SynchroBoolean.m_bSynchAscAutotests = True
        m_SynchroBoolean.m_bSynchDescPrestation = True
        m_SynchroBoolean.m_bSynchDescDiag = True
        m_SynchroBoolean.m_bSynchDescReferentiel = True
        m_SynchroBoolean.m_bSynchDescExploitation = True
        m_SynchroBoolean.m_bSynchDescAgent = True
        m_SynchroBoolean.m_bSynchDescBuse = True
        m_SynchroBoolean.m_bSynchDescMano = True
        m_SynchroBoolean.m_bSynchDescBanc = True
        m_SynchroBoolean.m_bSynchDescFV = True
        m_SynchroBoolean.m_bSynchDescPulve = True
        m_SynchroBoolean.m_bSynchDescDocument = True
    End Sub

    Public Sub setAllsynchroFalse()
        m_SynchroBoolean.m_bSynchAscDiag = False
        m_SynchroBoolean.m_bSynchAscAgent = False
        m_SynchroBoolean.m_bSynchAscExploitation = False
        m_SynchroBoolean.m_bSynchAscBanc = False
        m_SynchroBoolean.m_bSynchAscMano = False
        m_SynchroBoolean.m_bSynchAscPrestation = False
        m_SynchroBoolean.m_bSynchAscBuse = False
        m_SynchroBoolean.m_bsynchAscFV = False
        m_SynchroBoolean.m_bSynchAscPulve = False
        m_SynchroBoolean.m_bSynchAscAutotests = False
        m_SynchroBoolean.m_bSynchDescPrestation = False
        m_SynchroBoolean.m_bSynchDescDiag = False
        m_SynchroBoolean.m_bSynchDescReferentiel = False
        m_SynchroBoolean.m_bSynchDescExploitation = False
        m_SynchroBoolean.m_bSynchDescAgent = False
        m_SynchroBoolean.m_bSynchDescBuse = False
        m_SynchroBoolean.m_bSynchDescMano = False
        m_SynchroBoolean.m_bSynchDescBanc = False
        m_SynchroBoolean.m_bSynchDescFV = False
        m_SynchroBoolean.m_bSynchDescPulve = False
        m_SynchroBoolean.m_bSynchDescDocument = False

    End Sub
    ''' <summary>
    ''' Mise � jour des bool�ens de synchro dans le cas du gestionnaire
    ''' on ne synhcronise que les pulv�s et les exploitations et les ref�rentiels
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSynchroGestionnaire()
        setAllsynchroFalse()
        m_SynchroBoolean.m_bSynchAscExploitation = True
        m_SynchroBoolean.m_bSynchAscPulve = True
        m_SynchroBoolean.m_bSynchDescExploitation = True
        m_SynchroBoolean.m_bSynchDescPulve = True
        m_SynchroBoolean.m_bSynchDescDocument = True
        m_SynchroBoolean.m_bSynchDescReferentiel = True

    End Sub
    Public Property sens() As String
        Get
            Return _sens
        End Get
        Set(ByVal Value As String)
            _sens = Value
        End Set
    End Property

    Public Property dateSync() As String
        Get
            Return _dateSync
        End Get
        Set(ByVal Value As String)
            _dateSync = Value
        End Set
    End Property

    'Public Property checksumMD5() As String
    '    Get
    '        Return _checksumMD5
    '    End Get
    '    Set(ByVal Value As String)
    '        _checksumMD5 = Value
    '    End Set
    'End Property
    Public Property checksumCalc() As String
        Get
            Return _checksumCalc
        End Get
        Set(ByVal Value As String)
            _checksumCalc = Value
        End Set
    End Property

    Public Property Traitee As Boolean
        Get
            Return m_bTraitee
        End Get
        Set(ByVal Value As Boolean)
            m_bTraitee = Value
        End Set
    End Property


    Public Function Synchro(psynchroAsc As Boolean, psynchroDesc As Boolean) As Boolean
        Dim bReturn As Boolean
        Try
            If CSEnvironnement.checkNetwork() = True Then
                If CSEnvironnement.checkWebService() = True Then

                    '#######################################################################
                    '######################### Synchro Montantes ###########################
                    '#######################################################################
                    If (psynchroAsc) Then
                        Me.runAscSynchro()
                    End If

                    '#######################################################################
                    '####################### Synchro Descendantes ##########################
                    '#######################################################################
                    If psynchroDesc Then
                        Me.runDescSynchro()
                    End If
                    bReturn = True
                End If
            End If
        Catch Ex As Exception
            CSDebug.dispError("Synhcro.synchro ERR " & Ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    ''' <summary>
    ''' Execute la synchro ascendante 
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub runAscSynchro()

        If CSEnvironnement.checkWebService() = True Then

            ' On commence par redescendre l'�tat actif/inactif de l'agent courant
            Dim tmpObject As New Agent
            Try
                'Statusbar_display("R�ception MAJ Agent n�" & agent.numeroNational & "...")
                tmpObject = AgentManager.WSgetByNumeroNational(m_Agent.numeroNational, False)
                If tmpObject.id <> 0 Then
                    If m_Agent.isActif <> tmpObject.isActif Then
                        m_Agent.isActif = tmpObject.isActif
                    End If
                    AgentManager.save(m_Agent, True)
                End If
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runAscSynchro(GetAgent) : " & ex.Message.ToString)
            End Try

            SynchronisationManager.LogSynchroStart("ASC")
            m_listSynchro = ""
            Notice("Debut Synchro Ascendante")
            ' Synchro d'un agent
            ' On r�cup�re les mises � jours
            If (m_SynchroBoolean.m_bSynchAscAgent) Then
                Dim arrUpdatesAgent() As Agent = AgentManager.getUpdates(m_Agent)
                For Each tmpUpdateAgent As Agent In arrUpdatesAgent
                    Try
                        Dim UpdatedObject As New Agent
                        Dim tmpAgentUpdated As Agent
                        Notice("Agent n�" & tmpUpdateAgent.id)
                        Dim response As Integer = AgentManager.WSSend(tmpUpdateAgent, tmpAgentUpdated)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSAgent) - Erreur Locale")
                            Case 0 ' OK
                                AgentManager.setSynchro(tmpUpdateAgent)
                            Case 2 ' SENDPROFILAGENT_UPDATE
                                'A Suppr
                                'm_Agent = tmpAgentUpdated
                                'agentCourant = m_Agent
                                AgentManager.save(tmpAgentUpdated, True)
                                'm_Agent = AgentManager.getAgentById(tmpAgentUpdated.id)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro : Envoi Agent n�" & tmpUpdateAgent.id & " Erreur : Agent inconnu.")
                            Case 3 ' NOAGENT
                                CSDebug.dispWarn("Synchronisation::runAscSynchro : Envoi Agent n�" & tmpUpdateAgent.id & " Erreur : Agent inconnu.")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSAgent) - Le web service a r�pondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchro Asc Agent : " & ex.Message.ToString)
                    End Try
                Next
            End If
            If (m_SynchroBoolean.m_bSynchAscAgent) Then

                ' Synchro d'une structure
                ' On r�cup�re les mises � jours
                Dim arrUpdatesStructuree() As [Structure] = StructureManager.getUpdates(m_Agent)
                For Each oStructure As [Structure] In arrUpdatesStructuree
                    Try
                        Dim UpdatedObject As New [Structure]
                        Notice("Organisme n�" & oStructure.id)
                        Dim response As Integer = StructureManager.WSSend(oStructure, UpdatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSStructuree) - Erreur Locale")
                            Case 0 ' OK
                                StructureManager.setSynchro(oStructure)
                            Case 2 ' SENDPROFILAGENT_UPDATE
                                StructureManager.setSynchro(oStructure)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSStructuree) - Le web service a r�pondu : NOK")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSStructuree) - Le web service a r�pondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Structure) : " & ex.Message.ToString)
                    End Try
                Next
            End If
            If (m_SynchroBoolean.m_bSynchAscAgent) Then

                ' Synchro des PC (idRegistre)
                ' On r�cup�re les mises � jours
                Dim arrUpdates() As AgentPc = AgentPcManager.getUpdates(m_Agent)
                For Each oItem As AgentPc In arrUpdates
                    Try
                        Dim UpdatedObject As New AgentPc
                        Notice("AgentPC n�" & oItem.uid)
                        Dim response As Integer = AgentPcManager.WSSend(oItem, UpdatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSAgentPC) - Erreur Locale")
                            Case 0 ' OK
                                AgentPcManager.setSynchro(oItem)
                            Case 2 ' SENDPROFILAGENT_UPDATE
                                AgentPcManager.setSynchro(oItem)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSStructuree) - Le web service a r�pondu : NOK")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSStructuree) - Le web service a r�pondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Structure) : " & ex.Message.ToString)
                    End Try
                Next
            End If

            If (m_SynchroBoolean.m_bSynchAscExploitation) Then
                ' Synchro d'une exploitation
                Try
                    Dim arrUpdatesExploitation() As Exploitation = ExploitationManager.getUpdates(m_Agent)
                    For Each oExploitation As Exploitation In arrUpdatesExploitation
                        RunASCSynchroExploit(oExploitation)
                    Next

                Catch ex As Exception
                    CSDebug.dispError("SynchronisationElmtIdentifiantPulverisateur.SynhcroAsc ERR" & ex.Message)
                End Try


                ' Synchro d'un Pulverisateur
                Dim arrUpdatesPulverisateur() As Pulverisateur = PulverisateurManager.getUpdates(m_Agent)
                For Each oPulverisateur As Pulverisateur In arrUpdatesPulverisateur
                    RunAscSynchroPulve(oPulverisateur)
                Next

                ' Synchro d'un ExploitationTOPulverisateur
                Dim arrUpdatesExploitationTOPulverisateur() As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getUpdates(m_Agent)
                For Each oExploitationTOPulverisateur As ExploitationTOPulverisateur In arrUpdatesExploitationTOPulverisateur
                    RunAscSynchroExploit2Pulve(oExploitationTOPulverisateur)
                Next
            End If

            runASCSynchroPresta()

            'runACSSynchroMateriel()

            ' Synchro diagnostics
            Dim bsynchro As Boolean
            If (m_SynchroBoolean.m_bSynchAscDiag) Then
                Dim arrUpdatesDiagnostic() As Diagnostic = DiagnosticManager.getUpdates(m_Agent)
                For Each tmpUpdateDiagnostic As Diagnostic In arrUpdatesDiagnostic
                    bsynchro = runascSynchroDiag(m_Agent, tmpUpdateDiagnostic)
                    If (bsynchro) Then
                        'Ajout du Diag dans la liste des element Synchroniser
                        Dim oElement As SynchronisationElmt
                        oElement = SynchronisationElmt.CreateSynchronisationElmt(SynchronisationElmtDiag.getLabelGet(), m_SynchroBoolean)
                        oElement.IdentifiantChaine = tmpUpdateDiagnostic.id
                        oElement.IdentifiantEntier = tmpUpdateDiagnostic.uid
                        m_ListeElementSynchroASC.Add(oElement)
                    End If

                Next
            End If

            If (m_SynchroBoolean.m_bSynchAscPulve) Then
                Notice("IdentifiantsPulverisateurs ")
                Dim bReturn As Boolean = SynchronisationElmtIdentifiantPulverisateur.SynchroAsc(m_Agent)
                If Not bReturn Then
                    CSDebug.dispError("Synchronisation::runAscSynchro(sendWSIdentifiantPulvarisateur) - Erreur Locale")
                End If

            End If
            If (m_SynchroBoolean.m_bSynchAscAutotests) Then
                ' Synchro des AutoTest()

                Notice("Controles Reguliers ")
                Dim bReturn As Integer = AutoTestManager.WSSendList(m_Agent)
                If bReturn = -1 Then
                    CSDebug.dispError("Synchronisation::runAscSynchro(sendWSControlesReguliers) - Erreur Locale")
                End If
            End If


            'Fin de Synchro ascendante
            Notice("Fin synchro ascendante")
            SynchronisationManager.LogSynchroEnd()
            SynchronisationManager.DBsaveSynchro(m_Agent, "asc", m_listSynchro)


        Else
            CSDebug.dispWarn("Synchronisation::runDescSynchro : Serveur CRODIP Ping Timeout")
            Notice("Synchronisation impossible, serveur Crodip momentan�ment indisponible.")
        End If

    End Sub

    'Private Sub runACSSynchroMateriel()
    '    If (m_SynchroBoolean.m_bSynchAscBuse) Then
    '        ' Synchro d'un Buse
    '        Dim arrUpdatesBuse() As Buse = BuseManager.getUpdates(m_Agent)
    '        Dim pBuseReturn As New Buse
    '        For Each tmpUpdateBuse As Buse In arrUpdatesBuse
    '            Try
    '                Notice("Buse n�" & tmpUpdateBuse.numeroNational)
    '                Dim response As Integer = BuseManager.WSSend(tmpUpdateBuse, pBuseReturn)
    '                Select Case response
    '                    Case -1 ' ERROR
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBuse) - Erreur Locale" & vbNewLine)
    '                    Case 0, 2 ' OK
    '                        BuseManager.setSynchro(tmpUpdateBuse)
    '                    Case 4 ' CREATE
    '                        tmpUpdateBuse.uid = pBuseReturn.uid
    '                        BuseManager.save(pBuseReturn, True)
    '                    Case 1 ' NOK
    '                        CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSBuse) - Le web service a r�pondu : Non-Ok")
    '                    Case 9 ' BADREQUEST
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBuse) - Le web service a r�pondu : BadRequest")
    '                End Select
    '            Catch ex As Exception
    '                CSDebug.dispFatal("Synchronisation::runAscSynchro(Buse) : " & ex.Message.ToString)
    '            End Try

    '            'Ajout d'un element d�j� Synchroniser
    '            Dim oElement As SynchronisationElmt
    '            oElement = SynchronisationElmt.CreateSynchronisationElmt("GetBuse", m_SynchroBoolean)
    '            oElement.IdentifiantChaine = tmpUpdateBuse.aid
    '            oElement.IdentifiantEntier = tmpUpdateBuse.uid
    '            oElement.Traitee = True
    '            m_ListeElementSynchroASC.Add(oElement)
    '        Next


    '    End If
    '    If (m_SynchroBoolean.m_bSynchAscMano) Then
    '        ' Synchro d'un ManometreControle
    '        ' On r�cup�re les mises � jours
    '        Dim arrUpdatesManometreControle() As ManometreControle = ManometreControleManager.getUpdates(m_Agent)
    '        Dim oManoReturn As New ManometreControle
    '        For Each tmpUpdateManometreControle As ManometreControle In arrUpdatesManometreControle
    '            Try
    '                Dim UpdatedObject As New Object
    '                Notice("Manometre de Controle n�" & tmpUpdateManometreControle.numeroNational)
    '                Dim response As Integer = ManometreControleManager.WSSend(tmpUpdateManometreControle, oManoReturn)
    '                Select Case response
    '                    Case -1 ' ERROR
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreControle) - Erreur Locale")
    '                    Case 0, 2 ' OK
    '                        ManometreControleManager.setSynchro(tmpUpdateManometreControle)
    '                    Case 4 ' CREATE
    '                        tmpUpdateManometreControle.uid = oManoReturn.uid
    '                        ManometreControleManager.save(oManoReturn, True)
    '                    Case 1 ' NOK
    '                        CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSManometreControle) - Le web service a r�pondu : Non-Ok")
    '                    Case 9 ' BADREQUEST
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreControle) - Le web service a r�pondu : BadRequest")
    '                End Select
    '            Catch ex As Exception
    '                CSDebug.dispFatal("Synchronisation::runAscSynchro(Mano Contr�le) : " & ex.Message.ToString)
    '            End Try
    '            'Ajout d'un element d�j� Synchroniser
    '            Dim oElement As SynchronisationElmt
    '            oElement = SynchronisationElmt.CreateSynchronisationElmt("GetManometreControle", m_SynchroBoolean)
    '            oElement.IdentifiantChaine = tmpUpdateManometreControle.aid
    '            oElement.IdentifiantEntier = tmpUpdateManometreControle.uid
    '            oElement.Traitee = True
    '            m_ListeElementSynchroASC.Add(oElement)
    '        Next
    '    End If
    '    If (m_SynchroBoolean.m_bSynchAscMano) Then

    '        ' Synchro d'un ManometreEtalon
    '        ' On r�cup�re les mises � jours
    '        Dim arrUpdatesManometreEtalon() As ManometreEtalon = ManometreEtalonManager.getUpdates(m_Agent)
    '        Dim oManoEReturn As New ManometreEtalon
    '        For Each tmpUpdateManometreEtalon As ManometreEtalon In arrUpdatesManometreEtalon
    '            Try
    '                Dim UpdatedObject As New Object
    '                Notice("Manometre Etalon n�" & tmpUpdateManometreEtalon.numeroNational)
    '                Dim response As Integer = ManometreEtalonManager.WSSend(tmpUpdateManometreEtalon, oManoEReturn)
    '                Select Case response
    '                    Case -1 ' ERROR
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreEtalon) - Erreur Locale")
    '                    Case 0, 2 ' OK
    '                        ManometreEtalonManager.setSynchro(tmpUpdateManometreEtalon)
    '                    Case 4 ' SENDPROFILAGENT_UPDATE
    '                        tmpUpdateManometreEtalon.uid = oManoEReturn.uid
    '                        ManometreEtalonManager.save(oManoEReturn, True)
    '                    Case 1 ' NOK
    '                        CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSManometreEtalon) - Le web service a r�pondu : Non-Ok")
    '                    Case 9 ' BADREQUEST
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreEtalon) - Le web service a r�pondu : BadRequest")
    '                End Select
    '            Catch ex As Exception
    '                CSDebug.dispFatal("Synchronisation::runAscSynchro(Mano Etalon) : " & ex.Message.ToString)
    '            End Try
    '        Next

    '    End If
    '    If (m_SynchroBoolean.m_bSynchAscBanc) Then
    '        ' Synchro d'un Banc
    '        Dim arrUpdatesBanc() As Banc = BancManager.getUpdates(m_Agent)
    '        Dim pUpdated As New Banc
    '        For Each tmpUpdateBanc As Banc In arrUpdatesBanc
    '            Try
    '                Dim UpdatedObject As Banc = Nothing
    '                Notice("Banc de mesure n�" & tmpUpdateBanc.id)
    '                Dim response As Integer = BancManager.WSSend(tmpUpdateBanc, UpdatedObject)
    '                Select Case response
    '                    Case -1 ' ERROR
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBanc) - Erreur Locale")
    '                    Case 0, 2 ' OK
    '                        BancManager.setSynchro(tmpUpdateBanc)
    '                    Case 4 ' Create
    '                        tmpUpdateBanc.uid = UpdatedObject.uid
    '                        BancManager.save(UpdatedObject, True)
    '                    Case 1 ' NOK
    '                        CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSBanc) - Le web service a r�pondu : Non-Ok")
    '                    Case 9 ' BADREQUEST
    '                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBanc) - Le web service a r�pondu : BadRequest")
    '                End Select
    '            Catch ex As Exception
    '                CSDebug.dispFatal("Synchronisation::runAscSynchro(Banc) : " & ex.Message.ToString)
    '            End Try

    '            'Ajout d'un element d�j� Synchroniser
    '            Dim oElement As SynchronisationElmt
    '            oElement = SynchronisationElmt.CreateSynchronisationElmt("GetBanc", m_SynchroBoolean)
    '            oElement.IdentifiantChaine = tmpUpdateBanc.aid
    '            oElement.IdentifiantEntier = tmpUpdateBanc.uid
    '            oElement.Traitee = True
    '            m_ListeElementSynchroASC.Add(oElement)

    '        Next

    '    End If
    '    If (m_SynchroBoolean.m_bsynchAscFV) Then
    '        'Synhcronisation des Fiches de vies ManoDe Controle
    '        runascSynchroFVManoControle()

    '        ' Synchro d'un FVManometreEtalon
    '        runascSynchroFVManoEtalon()

    '        'Synhcro des FVBanc
    '        runascSynchroFVBanc()

    '    End If
    'End Sub

    Public Sub RunAscSynchroPulve(pPulverisateur As Pulverisateur)
        Try
            Dim UpdatedObject As Pulverisateur
            Notice("Pulverisateur n�" & pPulverisateur.id)
            Dim response As Integer = PulverisateurManager.WSSend(pPulverisateur, UpdatedObject)
            Select Case response
                Case -1 ' ERROR
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPulverisateur) - Erreur Locale")
                Case 0, 2, 4 ' OK
                    PulverisateurManager.save(UpdatedObject, Nothing, m_Agent, True)
                    'Mise � jour des Pulv� et des diagnostic
                    PulverisateurManager.UpdateExploit2Pulve(UpdatedObject)

                    'Ajout du pulv� dand la liste des element synchronis�
                    Dim oElement As SynchronisationElmt
                    oElement = SynchronisationElmt.CreateSynchronisationElmt(SynchronisationElmtPulverisateur.getLabelGet(), m_SynchroBoolean)
                    oElement.IdentifiantChaine = pPulverisateur.id
                    oElement.IdentifiantEntier = pPulverisateur.uid
                    m_ListeElementSynchroASC.Add(oElement)
                Case 1 ' NOK
                    CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSPulverisateur) - Le web service a r�pondu : Non-Ok")
                Case 9 ' BADREQUEST
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPulverisateur) - Le web service a r�pondu : BadRequest")
            End Select
        Catch ex As Exception
            CSDebug.dispFatal("Synchronisation::runAscSynchro(Pulverisateur) : " & ex.Message.ToString)
        End Try

    End Sub

    Public Sub RunAscSynchroExploit2Pulve(pExploitationTOPulverisateur As ExploitationTOPulverisateur)
        Dim UpdatedObject As New ExploitationTOPulverisateur
        Notice("ExploitationToPulverisateur n�" & pExploitationTOPulverisateur.idPulverisateur)
        Dim response As Integer = ExploitationTOPulverisateurManager.WSSend(pExploitationTOPulverisateur, UpdatedObject)
        Select Case response
            Case -1 ' ERROR
                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitationTOPulverisateur) - Erreur Locale")
            Case 0, 2, 4 ' OK
                ExploitationTOPulverisateurManager.save(UpdatedObject, m_Agent, True)
                Dim oElement As SynchronisationElmt
                oElement = SynchronisationElmt.CreateSynchronisationElmt(SynchronisationElmtExploitationToPulverisateur.getLabelGet(), m_SynchroBoolean)
                oElement.IdentifiantChaine = pExploitationTOPulverisateur.id
                oElement.IdentifiantEntier = pExploitationTOPulverisateur.uid
                m_ListeElementSynchroASC.Add(oElement)
            Case 1 ' NOK
                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSExploitationTOPulverisateur) - Le web service a r�pondu : Non-Ok")
            Case 9 ' BADREQUEST
                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitationTOPulverisateur) - Le web service a r�pondu : BadRequest")
        End Select


    End Sub
    Public Sub RunASCSynchroExploit(oExploitation As Exploitation)
        Try
            Notice("Exploitation n�" & oExploitation.id)

            Dim oReturn As New Exploitation
            Dim response As Integer = ExploitationManager.WSSend(oExploitation, oReturn)
            Select Case response
                Case -1 ' ERROR
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitation) - Erreur Locale")
                Case 2, 4 ' OK
                    ExploitationManager.save(oReturn, m_Agent, True)
                    'Mise � jour des Pulv� et des diagnostic
                    ExploitationManager.UpdateExploitToPulve(oReturn)
                    'Ajout de l'exploitation dans la liste des elements Synchronis�s 
                    Dim oElement As SynchronisationElmt
                    oElement = SynchronisationElmt.CreateSynchronisationElmt(SynchronisationElmtExploitation.getLabelGet(), m_SynchroBoolean)
                    oElement.IdentifiantChaine = oExploitation.id
                    oElement.IdentifiantEntier = oExploitation.uid
                    m_ListeElementSynchroASC.Add(oElement)

                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                '    ExploitationManager.save(ExploitationManager.xml2object(updatedObject), m_Agent, True)
                Case 1 ' NOK
                    CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSExploitation) - Le web service a r�pondu : Non-Ok")
                Case 9 ' BADREQUEST
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitation) - Le web service a r�pondu : BadRequest")
            End Select
        Catch ex As Exception
            CSDebug.dispFatal("Synchronisation::runAscSynchro(Exploitation) : " & ex.Message.ToString)
        End Try

    End Sub
    ''' <summary>
    ''' Execution de la synhcro Ascendate des prestations
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Sub runASCSynchroPresta()
        If (m_SynchroBoolean.m_bSynchAscPrestation) Then

            Notice("Synchronisation des tarifs")
            ' Synchro des prestationsCategories
            Dim arrUpdatesPrestationCategorie() As PrestationCategorie = PrestationCategorieManager.getUpdates(m_Agent)
            For Each tmpUpdatePrestationCategorie As PrestationCategorie In arrUpdatesPrestationCategorie
                If tmpUpdatePrestationCategorie.libelle <> "" Then
                    Try
                        CSDebug.dispInfo("Synchronisation.RunASCSynchroPRESTA - " & tmpUpdatePrestationCategorie.id)
                        Dim UpdatedObject As PrestationCategorie = Nothing
                        Dim response As Integer = PrestationCategorieManager.WSSend(tmpUpdatePrestationCategorie, UpdatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationCategorie) - Erreur Locale")
                            Case 0, 2 ' OK
                                PrestationCategorieManager.setSynchro(tmpUpdatePrestationCategorie)
                            '                            listSynchro = listSynchro & "Cat�gorie de tarif (n�" & tmpUpdatePrestationCategorie.id & ") ; "
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            '                           listSynchro = listSynchro & "Cat�gorie de tarif (n�" & tmpUpdatePrestationCategorie.id & ") ; "
                            'PrestationCategorieManager.save(PrestationCategorieManager.xml2object(updatedObject), m_Agent, True)
                            Case 4 ' CREATE
                                PrestationCategorieManager.save(UpdatedObject, m_Agent, True)
                                'Mise � jour des Pulv� et des diagnostic
                                PrestationCategorieManager.UpdateTarif(UpdatedObject)

                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSPrestationCategorie) - Le web service a r�pondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationCategorie) - Le web service a r�pondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationCategorie) : " & ex.Message.ToString)
                    End Try
                End If
            Next

        End If
        If (m_SynchroBoolean.m_bSynchAscPrestation) Then
            Dim UpdatedObjectT As PrestationTarif = Nothing
            ' Synchro des prestationsTarif
            Dim arrUpdatesPrestationTarif() As PrestationTarif = PrestationTarifManager.getUpdates(m_Agent)
            For Each tmpUpdatePrestationTarif As PrestationTarif In arrUpdatesPrestationTarif

                If tmpUpdatePrestationTarif.description <> "" Then
                    Try
                        Dim UpdatedObject As New Object
                        Dim response As Integer = PrestationTarifManager.WSSend(tmpUpdatePrestationTarif, UpdatedObjectT)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationTarif) - Erreur Locale")
                            Case 0, 2 ' OK
                                PrestationTarifManager.setSynchro(tmpUpdatePrestationTarif)
                            'listSynchro = listSynchro & "Tarif (n�" & tmpUpdatePrestationTarif.id & ") ; "
                            Case 4 ' CREATE
                                'listSynchro = listSynchro & "Tarif (n�" & tmpUpdatePrestationTarif.id & ") ; "
                                PrestationTarifManager.save(UpdatedObjectT, m_Agent, True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSPrestationTarif) - Le web service a r�pondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationTarif) - Le web service a r�pondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationTarif) : " & ex.Message.ToString)
                    End Try
                End If
            Next

        End If

    End Sub
    '''
    ''' Synchronisation des Fiches de vies Banc vers le Serveur

    'Public Function runascSynchroFVBanc() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = False
    '    ' Synchro d'un FVBanc
    '    Dim arrUpdatesFVBanc() As FVBanc = FVBancManager.getUpdates(m_Agent)
    '    For Each oFVBanc As FVBanc In arrUpdatesFVBanc
    '        Try
    '            Dim UpdatedObject As New FVBanc
    '            Notice("Fiche de Vie Banc de Mesure n�" & oFVBanc.id)
    '            Dim response As Integer = FVBancManager.WSSend(oFVBanc, UpdatedObject)
    '            Select Case response
    '                Case -1 ' ERROR
    '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVBanc) - Erreur Locale")
    '                Case 0, 2
    '                    FVBancManager.setSynchro(oFVBanc)
    '                    bReturn = FVBancManager.SendEtats(oFVBanc)

    '                Case 4 ' OK CREATE
    '                    oFVBanc.uid = UpdatedObject.uid
    '                    FVBancManager.save(oFVBanc, True)
    '                    bReturn = FVBancManager.SendEtats(oFVBanc)
    '                Case 1 ' NOK
    '                    CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSFVBanc) - Le web service a r�pondu : Non-Ok")
    '                Case 9 ' BADREQUEST
    '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVBanc) - Le web service a r�pondu : BadRequest")
    '            End Select
    '        Catch ex As Exception
    '            CSDebug.dispFatal("Synchronisation::runAscSynchro(FVBanc) : " & ex.Message.ToString)

    '        End Try

    '        'Ajout d'un element d�j� Synchroniser
    '        Dim oElement As SynchronisationElmt
    '        oElement = SynchronisationElmt.CreateSynchronisationElmt("GetFVBanc", m_SynchroBoolean)
    '        oElement.IdentifiantChaine = oFVBanc.aid
    '        oElement.IdentifiantEntier = oFVBanc.uid
    '        oElement.Traitee = True
    '        m_ListeElementSynchroASC.Add(oElement)

    '    Next
    '    Return bReturn
    'End Function
    Public Function runascSynchroDiag(ByVal pAgent As Agent, ByVal pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            Notice("Diagnostic " & pDiag.id)

            Dim bSynchroDiagOK As Boolean = False
            Dim oreturnDiag As New Diagnostic

            'Synchro des Rapports d'inspection et Synth�se des mesures
            '=========================================================
            Notice("Rapport Inspection, Synth�se des mesures et contrat commercial")
            bReturn = DiagnosticManager.SendEtats(pDiag)
            If bReturn Then
                'Transf�re du diag ssi le transfert des fichier est correct
                '============================================================
                'On Efface les propi�t�s de DiagItemList et DiagBusesList car elle n'ont pas besoin d'�tre serialis�es avec le diag vues qu'elle sont synchronis�es � part
                Dim oDiagItemList As DiagnosticItemList = pDiag.diagnosticItemsLst
                pDiag.diagnosticItemsLst = Nothing
                Dim oDiagBusesList As DiagnosticBusesList = pDiag.diagnosticBusesList
                pDiag.diagnosticBusesList = Nothing
                'Mise � jour des uidPulverisateur , uidExploitation si n�cessaire
                '================================================================
                If pDiag.uidexploitation = 0 Then
                    Dim oExploit As Exploitation
                    oExploit = ExploitationManager.getExploitationById(pDiag.proprietaireId)
                    If oExploit IsNot Nothing Then
                        If oExploit.uid <> 0 Then
                            pDiag.uidexploitation = oExploit.uid
                        End If
                    End If

                End If
                If pDiag.uidpulverisateur = 0 Then
                    Dim oPulve As Pulverisateur
                    oPulve = PulverisateurManager.getPulverisateurById(pDiag.pulverisateurId)
                    If oPulve IsNot Nothing Then
                        If oPulve.uid <> 0 Then
                            pDiag.uidpulverisateur = oPulve.uid
                        End If
                    End If

                End If
                Dim response As Integer = DiagnosticManager.WSSend(pDiag, oreturnDiag)
                'Apr�s Synchro on replace les propri�t�s
                pDiag.diagnosticItemsLst = oDiagItemList
                pDiag.diagnosticBusesList = oDiagBusesList

                Select Case response
                    Case -1 ' ERROR
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnostic) - Erreur Locale")
                    Case 0, 2, 4 ' OK
                        bSynchroDiagOK = True
                        pDiag.uid = oreturnDiag.uid
                        'transfert des uids dans les �lements constitutifs
                        For Each oDiagItem In pDiag.diagnosticItemsLst.Liste
                            oDiagItem.uiddiagnostic = oreturnDiag.uid
                        Next
                        For Each oDiagBuse In pDiag.diagnosticBusesList.Liste
                            oDiagBuse.uiddiagnostic = oreturnDiag.uid
                            For Each oDiagBuseDetail In oDiagBuse.diagnosticBusesDetailList.Liste
                                oDiagBuseDetail.uiddiagnostic = oreturnDiag.uid
                            Next
                        Next
                        For Each oDiag542 In pDiag.diagnosticMano542List.Liste
                            oDiag542.uiddiagnostic = oreturnDiag.uid
                        Next
                        For Each oDiag833 In pDiag.diagnosticTroncons833.Liste
                            oDiag833.uiddiagnostic = oreturnDiag.uid
                        Next
                        'La Sauvegarde se fera apr�s les Send
                        'DiagnosticManager.save(oreturnDiag, True)
                        'si le Diag est OK on passe au elements constitutifs
                        '====================================================
                        ' Synchro des items du diag courant
                        If pDiag.diagnosticItemsLst.Count > 0 Then
                            Dim updatedObjectDiagItem As New Object()
                            Notice("diagnostic items n�" & pDiag.id)
                            Dim responseDiagItem As Integer = DiagnosticItemManager.WSSend(pAgent, pDiag.diagnosticItemsLst)
                            Select Case responseDiagItem
                                Case -1 ' ERROR
                                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticItem) - Erreur Locale")
                                    bSynchroDiagOK = False
                                Case 0, 2 ' OK
                                    '�a ne sert � rien de marques les diagItems
                                    'For Each tmpXmlDiagItem As Object In updatedObjectDiagItem
                                    '    DiagnosticItemManager.setSynchro(DiagnosticItemManager.xml2object(tmpXmlDiagItem))
                                    'Next
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            '    Dim ocsdb As New CSDb(True)
                            '    For Each tmpXmlDiagItem As Object In updatedObjectDiagItem
                            '        DiagnosticItemManager.save(ocsdb, DiagnosticItemManager.xml2object(tmpXmlDiagItem), True)
                            '    Next
                            '    ocsdb.free()
                                Case 1 ' NOK
                                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticItem) - Le web service a r�pondu : Non-Ok")
                                    bSynchroDiagOK = False

                                Case 9 ' BADREQUEST
                                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticItem) - Le web service a r�pondu : BadRequest")
                                    bSynchroDiagOK = False

                            End Select
                        End If
                        ' Synchro des buses du diag courant
                        If Not pDiag.diagnosticBusesList Is Nothing Then
                            If pDiag.diagnosticBusesList.Liste.Count > 0 Then
                                Dim updatedObjectDiagBuse As New Object
                                Notice("diagnostic Buses n�" & pDiag.id)
                                Dim responseDiagBuse As Object = DiagnosticBusesManager.WSSend(pDiag)
                                Select Case CType(responseDiagBuse, Integer)
                                    Case -1 ' ERROR
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Erreur Locale")
                                        bSynchroDiagOK = False

                                    Case 0, 2 ' OK
                                        '�_a ne sert � rien de marquer les Buses
                                        'For Each tmpXmlDiagBuse As Object In updatedObjectDiagBuse
                                        '    DiagnosticBusesManager.setSynchro(DiagnosticBusesManager.xml2object(tmpXmlDiagBuse))
                                        'Next
                                        'Case 2 ' SENDPROFILAGENT_UPDATE
                                        '    For Each tmpXmlDiagBuse As Object In updatedObjectDiagBuse
                                        '        DiagnosticBusesManager.save(DiagnosticBusesManager.xml2object(tmpXmlDiagBuse), True)
                                        '    Next
                                    Case 1 ' NOK
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a r�pondu : Non-Ok")
                                        bSynchroDiagOK = False

                                    Case 9 ' BADREQUEST
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a r�pondu : BadRequest")
                                        bSynchroDiagOK = False

                                End Select

                                ' Synchro des d�tails des buses du diag courant
                                Dim responseDiagBuseDetail As Object = DiagnosticBusesDetailManager.WSSend(pDiag)
                                Select Case CType(responseDiagBuseDetail, Integer)
                                    Case -1 ' ERROR
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBusesDetail) - Erreur Locale")
                                        bSynchroDiagOK = False

                                    Case 0, 2 ' OK
                                                    '�a ne sert � rien
                                                    'For Each tmpXmlDiagBuseDetail As Object In updatedObjectDiagBuseDetail
                                                    '    DiagnosticBusesDetailManager.setSynchro(DiagnosticBusesDetailManager.xml2object(tmpXmlDiagBuseDetail))
                                                    'Next
                                            'Case 2 ' SENDPROFILAGENT_UPDATE
                                            '    For Each tmpXmlDiagBuseDetail As Object In updatedObjectDiagBuseDetail
                                            '        DiagnosticBusesDetailManager.save(DiagnosticBusesDetailManager.xml2object(tmpXmlDiagBuseDetail), True)
                                            '    Next
                                    Case 1 ' NOK
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a r�pondu : Non-Ok")
                                        bSynchroDiagOK = False

                                    Case 9 ' BADREQUEST
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a r�pondu : BadRequest")
                                        bSynchroDiagOK = False

                                End Select
                                ' FIN --- Synchro des d�tails des buses du diag courant
                            End If
                        End If
                        ' Synchro des 542
                        If Not pDiag.diagnosticMano542List Is Nothing Then
                            If pDiag.diagnosticMano542List.Liste.Count > 0 Then
                                Dim updatedObjectDiag542 As New Object
                                Dim responseDiag542 As Object = DiagnosticMano542Manager.WSSend(pDiag)
                                Notice("diagnostic mano 542 n�" & pDiag.id)
                                Select Case CType(responseDiag542, Integer)
                                    Case -1 ' ERROR
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticMano542) - Erreur Locale")
                                        bSynchroDiagOK = False

                                    Case 0, 2 ' OK
                                        'For Each tmpXmlDiag542 As Object In updatedObjectDiag542
                                        '    DiagnosticMano542Manager.setSynchro(DiagnosticMano542Manager.xml2object(tmpXmlDiag542))
                                        'Next
                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                '    For Each tmpXmlDiag542 As Object In updatedObjectDiag542
                                '        DiagnosticMano542Manager.save(DiagnosticMano542Manager.xml2object(tmpXmlDiag542), True)
                                '    Next
                                    Case 1 ' NOK
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticMano542) - Le web service a r�pondu : Non-Ok")
                                        bSynchroDiagOK = False
                                    Case 9 ' BADREQUEST
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticMano542) - Le web service a r�pondu : BadRequest")
                                        bSynchroDiagOK = False
                                End Select
                            End If
                        End If


                        ' Synchro des 833
                        If Not pDiag.diagnosticTroncons833 Is Nothing Then

                            If pDiag.diagnosticTroncons833.Liste.Count > 0 Then
                                Dim updatedObjectDiag833 As New Object
                                Notice("diagnostic Troncons 833 n�" & pDiag.id)
                                Dim responseDiag833 As Object = DiagnosticTroncons833Manager.WSSend(pDiag)
                                Select Case CType(responseDiag833, Integer)
                                    Case -1 ' ERROR
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticTroncons833) - Erreur Locale")
                                        bSynchroDiagOK = False
                                    Case 0, 2 ' OK
                                '        For Each tmpXmlDiag833 As Object In updatedObjectDiag833
                                '            DiagnosticTroncons833Manager.setSynchro(DiagnosticTroncons833Manager.xml2object(tmpXmlDiag833))
                                '        Next
                                ''Case 2 ' SENDPROFILAGENT_UPDATE
                                '    For Each tmpXmlDiag833 As Object In updatedObjectDiag833
                                '        DiagnosticTroncons833Manager.save(DiagnosticTroncons833Manager.xml2object(tmpXmlDiag833), True)
                                '    Next
                                    Case 1 ' NOK
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticTroncons833) - Le web service a r�pondu : Non-Ok")
                                        bSynchroDiagOK = False

                                    Case 9 ' BADREQUEST
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticTroncons833) - Le web service a r�pondu : BadRequest")
                                        bSynchroDiagOK = False

                                End Select
                            End If
                        End If


                    Case 1 ' NOK
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnostic) - Le web service a r�pondu : Non-Ok")
                        bSynchroDiagOK = False
                    Case 9 ' BADREQUEST
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnostic) - Le web service a r�pondu : BadRequest")
                        bSynchroDiagOK = False
                End Select
            End If
            'Sauvegarde du diag (il faut rester sur le pDiag, car le oReturnDiag n'a pas les Diagtitems, ...)
            If bSynchroDiagOK Then
                pDiag.uid = oreturnDiag.uid
                pDiag.dateModificationCrodip = oreturnDiag.dateModificationCrodip
                DiagnosticManager.save(pDiag, True)
            End If

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Synchronisation.runascSynchroDiag ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    'Public Function getListeElementsASynchroniserDESC() As List(Of SynchronisationElmt)
    '    Dim lstElementsASynchronisertotal As New List(Of SynchronisationElmt)
    '    Dim lstElementsASynchroniserAgent As New List(Of SynchronisationElmt)

    '    lstElementsASynchronisertotal = getListeElementsASynchroniserDESC(m_Agent.oPCcourant, m_Agent)

    '    Dim oList As AgentList
    '    oList = AgentManager.getAgentList(m_Agent.uidStructure)

    '    'On r�cup�re les �l�ments � synchroniser de chaque Agent
    '    For Each oAgent As Agent In oList.items
    '        If oAgent.id <> m_Agent.id Then
    '            lstElementsASynchroniserAgent = getListeElementsASynchroniserDESC(m_Agent.oPCcourant, oAgent)

    '            'et on les fusionne dans la liste Globale
    '            For Each oelmt As SynchronisationElmt In lstElementsASynchroniserAgent
    '                Dim n As Integer = (From o In lstElementsASynchronisertotal
    '                                    Where o.Type = oelmt.Type And o.IdentifiantChaine = oelmt.IdentifiantChaine And o.IdentifiantEntier = oelmt.IdentifiantEntier
    '                                    Select o) _
    '                                        .Count()
    '                If n = 0 Then
    '                    lstElementsASynchronisertotal.Add(oelmt)
    '                End If
    '            Next
    '        End If
    '    Next
    '    Return lstElementsASynchronisertotal
    'End Function
    Public Function getListeElementsASynchroniserDESC(pPC As AgentPc, pAgent As Agent) As List(Of SynchronisationElmt)
        Dim lstElementsASynchroniser As List(Of SynchronisationElmt)
        lstElementsASynchroniser = SynchronisationManager.getWSlstElementsASynchroniser(pPC, pAgent, m_SynchroBoolean)
        Return lstElementsASynchroniser
    End Function
    ''' <summary>
    ''' Synchronisation Descendante : R�cup�ration de la liste des elements � synchroniser
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function runDescSynchro() As Boolean
        Dim bReturn As Boolean
        Dim PCASynchroniser As AgentPc
        Dim lstElementsASynchroniserAgent As List(Of SynchronisationElmt)
        Dim lstElementsASynchroniserTotal As New List(Of SynchronisationElmt)
        Try
            PCASynchroniser = m_Agent.oPCcourant
            m_listSynchro = ""
            Notice("Debut synchro descendante")
            CSDebug.dispInfo("Debut synchro descendante")
            SynchronisationManager.LogSynchroStart("DESC")
            Dim oList As AgentList
            oList = AgentManager.getAgentList(m_Agent.uidstructure)
            lstElementsASynchroniserTotal = getListeElementsASynchroniserDESC(PCASynchroniser, m_Agent)

            'On r�cup�re les �l�ments � synchroniser de chaque Agent
            For Each oAgent As Agent In oList.items
                If Not oAgent.isGestionnaire And Not oAgent.isSupprime And oAgent.isActif Then
                    CSDebug.dispInfo("getListasynchroniser(" & oAgent.id & ")")

                    lstElementsASynchroniserAgent = getListeElementsASynchroniserDESC(PCASynchroniser, oAgent)

                    'et on les fusionne dans la liste Globale
                    CSDebug.dispInfo("Fusion [" & lstElementsASynchroniserAgent.Count & "]")
                    For Each oelmt As SynchronisationElmt In lstElementsASynchroniserAgent
                        'Elimination des elements d�j� trait�
                        Dim n As Integer = (From o In lstElementsASynchroniserTotal
                                            Where o.Type = oelmt.Type And o.IdentifiantChaine = oelmt.IdentifiantChaine And o.IdentifiantEntier = oelmt.IdentifiantEntier
                                            Select o) _
                                            .Count()
                        If n = 0 Then
                            oelmt.setAgent(m_Agent)
                            lstElementsASynchroniserTotal.Add(oelmt)
                        End If
                    Next
                End If
            Next

            CSDebug.dispInfo("RunDescSynchro [" & lstElementsASynchroniserTotal.Count & "]")
            bReturn = runDescSynchro(lstElementsASynchroniserTotal)
        Catch Ex As Exception
            CSDebug.dispError("Synchronisation.runDescSynchro Err : ", Ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Synchronisation Descendante � partir d'une liste des elements � synchroniser 
    ''' Utiliser en test
    ''' </summary>
    ''' <param name="lstElementsASynchroniser"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function runDescSynchro(lstElementsASynchroniser As List(Of SynchronisationElmt)) As Boolean
        Debug.Assert(lstElementsASynchroniser IsNot Nothing)
        Dim bReturn As Boolean
        Try

            m_listSynchro = ""
            'On Traite les synchro Pool d'abord
            For Each oSynchroElmt As SynchronisationElmt In lstElementsASynchroniser
                If oSynchroElmt.Type.ToUpper().Trim() = "GetPool".ToUpper().Trim() Then
                    Notice(" Pool")
                    oSynchroElmt.SynchroDesc(m_Agent)
                    oSynchroElmt.Traitee = True
                End If
            Next
            'puis les synchro Agent 
            For Each oSynchroElmt As SynchronisationElmt In lstElementsASynchroniser
                If oSynchroElmt.Type.ToUpper().Trim() = "GetAgent".ToUpper().Trim() Then
                    Notice(" Agent")
                    oSynchroElmt.SynchroDesc(m_Agent)
                    oSynchroElmt.Traitee = True
                End If
            Next
            'Puis les Exploitations
            For Each oSynchroElmt As SynchronisationElmt In lstElementsASynchroniser
                If oSynchroElmt.Type.ToUpper().Trim() = "GetExploitation".ToUpper().Trim() Then
                    Notice(" Exploitation")
                    oSynchroElmt.SynchroDesc(m_Agent)
                    oSynchroElmt.Traitee = True
                End If
            Next
            'Puis les Pulverisateurs
            For Each oSynchroElmt As SynchronisationElmt In lstElementsASynchroniser
                If oSynchroElmt.Type.ToUpper().Trim() = "GetPulverisateur".ToUpper().Trim() Then
                    Notice(" Pulverisateur")
                    oSynchroElmt.SynchroDesc(m_Agent)
                    oSynchroElmt.Traitee = True
                End If
            Next

            If Not String.IsNullOrEmpty(m_Agent.id) Then
                'On synchronise les �lements non trait� 
                For Each oSynchroElmt As SynchronisationElmt In lstElementsASynchroniser
                    If oSynchroElmt.Traitee = False Then
                        If Not IsElementDansSynchroASC(oSynchroElmt) Then
                            If oSynchroElmt.Type.ToUpper() <> "GETDOCUMENT" Then
                                Notice(oSynchroElmt.Type & "[" & oSynchroElmt.IdentifiantChaine & "]")
                            Else
                                If oSynchroElmt.Update Then
                                    Notice(oSynchroElmt.Type & "[" & oSynchroElmt.IdentifiantChaine & "]")
                                End If
                            End If

                            oSynchroElmt.SynchroDesc(m_Agent)
                            oSynchroElmt.Traitee = True
                        End If
                    End If
                Next
                '' On affiche le log

                ' Ensuite on met � jour la date de derni�re synchro
                Notice("MAJ date de derni�re Synchro")
                MAJDateDerniereSynchro()
                'Rechargement de l'agent courant
                '                agentCourant = AgentManager.getAgentById(m_Agent.id)
                bReturn = True
                SynchronisationManager.LogSynchroEnd()
                Notice("Fin Synchronisation descendante")
                SynchronisationManager.DBsaveSynchro(m_Agent, "desc", m_listSynchro)
            End If

        Catch ex As Exception
            CSDebug.dispError("Synchronisation.runDescSynchro2 Err : ", ex)
            bReturn = False
        End Try
        Return bReturn


    End Function

    Private Function IsElementDansSynchroASC(pElement As SynchronisationElmt) As Boolean
        Dim bReturn As Boolean
        Try

            Dim nbElement As Integer = (From elmt As SynchronisationElmt In m_ListeElementSynchroASC
                                        Where elmt.Type = pElement.Type And elmt.IdentifiantChaine = pElement.IdentifiantChaine And elmt.IdentifiantEntier = pElement.IdentifiantEntier
                                        Select elmt).Count

            bReturn = (nbElement > 0)
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    '''
    ''' Mise � jour de la date de dern�re synhcro
    ''' 
    Public Function MAJDateDerniereSynchro() As Boolean
        Dim bReturn As Boolean
        Try
            ' R�cup�ration de la date de synchro � partir du serveur
            Dim objWSCrodip As WSCRODIP.CrodipServer = WebServiceCRODIP.getWS()
            Dim synchroDateTime As Object = Nothing
            Dim reponse As GetSynchroDateTimeResponse
            reponse = objWSCrodip.GetSynchroDateTime()
            Dim sDateFromSRV As String = reponse.SynchroDateTime(0).InnerText().replace("/", "-")
            Dim dtSRV As Date
            Try
                dtSRV = New Date(sDateFromSRV)
            Catch Ex As Exception
                Try
                    dtSRV = CSDate.FromCrodipString(sDateFromSRV)
                Catch Ex2 As Exception
                    dtSRV = Date.Now
                End Try
            End Try
            'Ajout de 1 Secondes 
            dtSRV.AddSeconds(1)
            ''Maj des agents
            'Dim oList As AgentList
            'If m_Agent.oPool Is Nothing Then
            '    oList = AgentManager.getAgentList(m_Agent.idStructure)
            'Else
            '    oList = AgentManager.getAgentListByPool(m_Agent.oPool.uid)
            'End If

            'For Each oAgent As Agent In oList.items
            '    If Not oAgent.isGestionnaire And Not oAgent.isSupprime And oAgent.isActif Then
            '        oAgent.dateDerniereSynchro = CSDate.ToCRODIPString(dtSRV)
            '        AgentManager.save(oAgent, True)
            '        'Maj de la date de derni�re synchro de l'agent sur le SRV
            '        CSDebug.dispInfo("MAJ date dernier Synchro ID=" & oAgent.id & ",DateDernSynchro=" & oAgent.dateDerniereSynchro)
            '        objWSCrodip.SetDateSynchroAgent(oAgent.id, oAgent.dateDerniereSynchro)
            '    End If
            'Next
            'Maj du PC Courant
            If m_Agent.oPCcourant IsNot Nothing Then
                m_Agent.oPCcourant.dateDerniereSynchro = dtSRV
                AgentPcManager.WSSend(m_Agent.oPCcourant, m_Agent.oPCcourant)
                AgentPcManager.Save(m_Agent.oPCcourant, True)
                objWSCrodip.SetDateSynchroPc(m_Agent.oPCcourant.uid, m_Agent.oPCcourant.dateDerniereSynchroS)
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationManager.MAJDateDerniereSynchro ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' specify the path to a file and this routine will calculate your hash
    Public Function MD5CalcFile(ByVal filepath As String) As String

        ' open file (as read-only)
        Using reader As New System.IO.FileStream(filepath, IO.FileMode.Open, IO.FileAccess.Read)
            Using md5 As New System.Security.Cryptography.MD5CryptoServiceProvider

                ' hash contents of this stream
                Dim hash() As Byte = md5.ComputeHash(reader)

                ' return formatted hash
                Return ByteArrayToString(hash)

            End Using
        End Using

    End Function

    ' utility function to convert a byte array into a hex string
    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String

        Dim sb As New System.Text.StringBuilder(arrInput.Length * 2)

        For i As Integer = 0 To arrInput.Length - 1
            sb.Append(arrInput(i).ToString("X2"))
        Next

        Return sb.ToString().ToLower

    End Function
    '''
    ''' Synchronisation des Fiches de vies ManoControle vers le Serveur

    'Public Function runascSynchroFVManoControle() As Boolean
    '    Dim bReturn As Boolean
    '    bReturn = False

    '    ' On r�cup�re les mises � jours
    '    Dim arrUpdatesFVManometreControle() As FVManometreControle = FVManometreControleManager.getUpdates(m_Agent)
    '    For Each tmpUpdateFVManometreControle As FVManometreControle In arrUpdatesFVManometreControle
    '        Try
    '            Dim UpdatedObject As New FVManometreControle
    '            Notice("Fiche de Vie Manometre de Controle n�" & tmpUpdateFVManometreControle.id)
    '            Dim response As Integer = FVManometreControleManager.WSSend(tmpUpdateFVManometreControle, UpdatedObject)
    '            Select Case response
    '                Case -1 ' ERROR
    '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreControle) - Erreur Locale")
    '                Case 0, 2
    '                    FVManometreControleManager.setSynchro(tmpUpdateFVManometreControle)
    '                    bReturn = FVManometreControleManager.SendEtats(tmpUpdateFVManometreControle)
    '                Case 4
    '                    tmpUpdateFVManometreControle.uid = UpdatedObject.uid
    '                    FVManometreControleManager.save(m_Agent, tmpUpdateFVManometreControle, True)
    '                    bReturn = FVManometreControleManager.SendEtats(tmpUpdateFVManometreControle)

    '                Case 1 ' NOK
    '                    CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSFVManometreControle) - Le web service a r�pondu : Non-Ok")
    '                Case 9 ' BADREQUEST
    '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreControle) - Le web service a r�pondu : BadRequest")
    '            End Select
    '        Catch ex As Exception
    '            CSDebug.dispFatal("Synchronisation::runAscSynchro(FVManoControle) : " & ex.Message.ToString)
    '        End Try

    '        'Ajout d'un element d�j� Synchroniser
    '        Dim oElement As SynchronisationElmt
    '        oElement = SynchronisationElmt.CreateSynchronisationElmt("GetFVMAnometreControle", m_SynchroBoolean)
    '        oElement.IdentifiantChaine = tmpUpdateFVManometreControle.aid
    '        oElement.IdentifiantEntier = tmpUpdateFVManometreControle.uid
    '        oElement.Traitee = True
    '        m_ListeElementSynchroASC.Add(oElement)

    '    Next
    '    Return bReturn
    'End Function
    'Public Sub runascSynchroFVManoEtalon()

    '    ' On r�cup�re les mises � jours
    '    Dim arrUpdatesFVManometreEtalon() As FVManometreEtalon = FVManometreEtalonManager.getUpdates(m_Agent)
    '    Dim UpdatedObject As New FVManometreEtalon
    '    For Each tmpUpdateFVManometreEtalon As FVManometreEtalon In arrUpdatesFVManometreEtalon
    '        Try
    '            Notice("Fiche de Vie Manometre Etalon n�" & tmpUpdateFVManometreEtalon.id)
    '            Dim response As Integer = FVManometreEtalonManager.WSSend(tmpUpdateFVManometreEtalon, UpdatedObject)
    '            Select Case response
    '                Case -1 ' ERROR
    '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreEtalon) - Erreur Locale")
    '                Case 0, 2 ' OK
    '                    FVManometreEtalonManager.setSynchro(tmpUpdateFVManometreEtalon)
    '                Case 4 ' OK_CREATE
    '                    tmpUpdateFVManometreEtalon.uid = UpdatedObject.uid
    '                    FVManometreEtalonManager.save(tmpUpdateFVManometreEtalon, True)
    '                Case 1 ' NOK
    '                    CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSFVManometreEtalon) - Le web service a r�pondu : Non-Ok")
    '                Case 9 ' BADREQUEST
    '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreEtalon) - Le web service a r�pondu : BadRequest")
    '            End Select
    '        Catch ex As Exception
    '            CSDebug.dispFatal("Synchronisation::runAscSynchro(FVManoEtalon) : " & ex.Message.ToString)
    '        End Try

    '        'Ajout d'un element d�j� Synchroniser
    '        Dim oElement As SynchronisationElmt
    '        oElement = SynchronisationElmt.CreateSynchronisationElmt("GetFVManometreEtalon", m_SynchroBoolean)
    '        oElement.IdentifiantChaine = tmpUpdateFVManometreEtalon.aid
    '        oElement.IdentifiantEntier = tmpUpdateFVManometreEtalon.uid
    '        oElement.Traitee = True
    '        m_ListeElementSynchroASC.Add(oElement)

    '    Next
    'End Sub

End Class
