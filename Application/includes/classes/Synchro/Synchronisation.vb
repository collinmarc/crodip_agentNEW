
Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports System.Collections.Generic
Imports System.Linq
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
<Serializable(), XmlInclude(GetType(Synchronisation))> _
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
        If Globals.GLOB_ENV_DEBUG Then
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
    ''' Mise à jour des booléens de synchro dans le cas du gestionnaire
    ''' on ne synhcronise que les pulvés et les exploitations et les reférentiels
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

    Public Function getListSynchro() As String
        Return m_listSynchro
    End Function

    Public Function Synchro() As Boolean
        Dim bReturn As Boolean
        Try
            If CSEnvironnement.checkNetwork() = True Then
                If CSEnvironnement.checkWebService() = True Then

                    '#######################################################################
                    '######################### Synchro Montantes ###########################
                    '#######################################################################
                    Me.runAscSynchro()

                    '#######################################################################
                    '####################### Synchro Descendantes ##########################
                    '#######################################################################
                    Me.runDescSynchro()
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

            ' On commence par redescendre l'état actif/inactif de l'agent courant
            Dim tmpObject As New Agent
            Try
                'Statusbar_display("Réception MAJ Agent n°" & agent.numeroNational & "...")
                tmpObject = AgentManager.getWSAgentById(m_Agent.numeroNational)
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
            Dim bSynhcro As Boolean
            Notice("Debut Synchro Ascendante")
            ' Synchro diagnostics
            If (m_SynchroBoolean.m_bSynchAscDiag) Then
                Dim arrUpdatesDiagnostic() As Diagnostic = DiagnosticManager.getUpdates(m_Agent)
                For Each tmpUpdateDiagnostic As Diagnostic In arrUpdatesDiagnostic
                    bSynhcro = runascSynchroDiag(m_Agent, tmpUpdateDiagnostic)
                    If (bSynhcro) Then
                        'Ajout du Diag dans la liste des element Synchroniser
                        Dim oElement As SynchronisationElmt
                        oElement = SynchronisationElmt.createSynchronisationElmt(SynchronisationElmtDiag.getLabelGet(), m_SynchroBoolean)
                        oElement.identifiantChaine = tmpUpdateDiagnostic.id
                        m_ListeElementSynchroASC.Add(oElement)
                    End If

                Next
            End If
            ' Synchro d'un agent
            ' On récupère les mises à jours
            If (m_SynchroBoolean.m_bSynchAscAgent) Then
                Dim arrUpdatesAgent() As Agent = AgentManager.getUpdates(m_Agent)
                For Each tmpUpdateAgent As Agent In arrUpdatesAgent
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Agent n°" & tmpUpdateAgent.id)
                        Dim response As integer = AgentManager.sendWSAgent(tmpUpdateAgent, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSAgent) - Erreur Locale")
                            Case 0 ' OK
                                AgentManager.setSynchro(tmpUpdateAgent)
                            Case 2 ' SENDPROFILAGENT_UPDATE
                                Dim tmpAgentUpdated As Agent = AgentManager.xml2object(updatedObject)
                                m_Agent = tmpAgentUpdated
                                agentCourant = m_Agent
                                AgentManager.save(tmpAgentUpdated, True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro : Envoi Agent n°" & tmpUpdateAgent.id & " Erreur : Agent inconnu.")
                            Case 3 ' NOAGENT
                                CSDebug.dispWarn("Synchronisation::runAscSynchro : Envoi Agent n°" & tmpUpdateAgent.id & " Erreur : Agent inconnu.")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSAgent) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchro Asc Agent : " & ex.Message.ToString)
                    End Try
                Next
            End If
            If (m_SynchroBoolean.m_bSynchAscAgent) Then

                ' Synchro d'une structure
                ' On récupère les mises à jours
                Dim arrUpdatesStructuree() As Structuree = StructureManager.getUpdates(m_Agent)
                For Each tmpUpdateStructuree As Structuree In arrUpdatesStructuree
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Organisme n°" & tmpUpdateStructuree.id)
                        Dim response As integer = StructureManager.sendWSStructuree(tmpUpdateStructuree, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSStructuree) - Erreur Locale")
                            Case 0 ' OK
                                StructureManager.setSynchro(tmpUpdateStructuree)
                            Case 2 ' SENDPROFILAGENT_UPDATE
                                StructureManager.setSynchro(StructureManager.xml2object(updatedObject))
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSStructuree) - Le web service a répondu : NOK")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSStructuree) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Structure) : " & ex.Message.ToString)
                    End Try
                Next
            End If
            If (m_SynchroBoolean.m_bSynchAscExploitation) Then

                ' Synchro d'un exploitant
                ' On récupère les mises à jours
                Dim arrUpdatesExploitation() As Exploitation = ExploitationManager.getUpdates(m_Agent)
                For Each tmpUpdateExploitation As Exploitation In arrUpdatesExploitation
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Exploitation n°" & tmpUpdateExploitation.id)
                        Dim response As integer = ExploitationManager.sendWSExploitation(tmpUpdateExploitation, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitation) - Erreur Locale")
                            Case 0, 2 ' OK
                                ExploitationManager.setSynchro(tmpUpdateExploitation)
                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                '    ExploitationManager.save(ExploitationManager.xml2object(updatedObject), m_Agent, True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSExploitation) - Le web service a répondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitation) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Exploitation) : " & ex.Message.ToString)
                    End Try
                Next

            End If
            If (m_SynchroBoolean.m_bSynchAscBanc) Then
                ' Synchro d'un ControleBancMesure
                ' On récupère les mises à jours
                'Dim arrUpdatesControleBanc() As ControleBanc = ControleBancManager.getUpdates()
                'For Each tmpUpdateControleBanc As ControleBanc In arrUpdatesControleBanc
                '    Try
                '        Dim UpdatedObject As Object = nothing
                '        Dim response As integer = ControleBancManager.sendWSControleBanc(tmpUpdateControleBanc, updatedObject)
                '        Select Case response
                '            Case -1 ' ERROR
                '                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSControleBanc) - Erreur Locale")
                '            Case 0 ' OK
                '                Statusbar_display("Envoi Controle Banc n°" & tmpUpdateControleBanc.id & " Ok : Déjà à jour.")
                '                ControleBancManager.setSynchro(tmpUpdateControleBanc)
                '                listSynchro = listSynchro & "Controle Banc (n°" & tmpUpdateControleBanc.id & ") ; "
                '            Case 2 ' SENDPROFILAGENT_UPDATE
                '                Statusbar_display("Envoi Controle Banc n°" & tmpUpdateControleBanc.id & " Ok : Mise à jour effectuée.")
                '                listSynchro = listSynchro & "Controle Banc (n°" & tmpUpdateControleBanc.id & ") ; "
                '                ControleBancManager.save(ControleBancManager.xml2object(updatedObject), m_Agent, True)
                '            Case 1 ' NOK
                '                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSControleBanc) - Le web service a répondu : Non-Ok")
                '            Case 9 ' BADREQUEST
                '                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSControleBanc) - Le web service a répondu : BadRequest")
                '        End Select
                '    Catch ex As Exception
                '        CSDebug.dispFatal("Synchronisation::runAscSynchro(ControleBanc) : " & ex.Message.ToString)
                '    End Try
                'Next
            End If
            If (m_SynchroBoolean.m_bSynchAscMano) Then

                ' Synchro d'un ControleManoMesure
                ' On récupère les mises à jours
                '    Dim arrUpdatesControleMano() As ControleMano = ControleManoManager.getUpdates()
                '    For Each tmpUpdateControleMano As ControleMano In arrUpdatesControleMano
                '        Try
                '            Dim UpdatedObject As Object = nothing
                '            Dim response As integer = ControleManoManager.sendWSControleMano(tmpUpdateControleMano, updatedObject)
                '            Select Case response
                '                Case -1 ' ERROR
                '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSControleMano) - Erreur Locale")
                '                Case 0 ' OK
                '                    Statusbar_display("Envoi Controle Mano n°" & tmpUpdateControleMano.id & " Ok : Déjà à jour.")
                '                    ControleManoManager.setSynchro(tmpUpdateControleMano)
                '                    listSynchro = listSynchro & "Controle Mano (n°" & tmpUpdateControleMano.id & ") ; "
                '                Case 2 ' SENDPROFILAGENT_UPDATE
                '                    Statusbar_display("Envoi Controle Mano n°" & tmpUpdateControleMano.id & " Ok : Mise à jour effectuée.")
                '                    listSynchro = listSynchro & "Controle Mano (n°" & tmpUpdateControleMano.id & ") ; "
                '                    ControleManoManager.save(ControleManoManager.xml2object(updatedObject), m_Agent, True)
                '                Case 1 ' NOK
                '                    CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSControleMano) - Le web service a répondu : Non-Ok")
                '                Case 9 ' BADREQUEST
                '                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSControleMano) - Le web service a répondu : BadRequest")
                '            End Select
                '        Catch ex As Exception
                '            CSDebug.dispFatal("Synchronisation::runAscSynchro(ControleMano) : " & ex.Message.ToString)
                '        End Try
                '    Next
            End If

            runASCSynchroPresta()


            If (m_SynchroBoolean.m_bSynchAscBuse) Then
                ' Synchro d'un Buse
                Dim arrUpdatesBuse() As Buse = BuseManager.getUpdates(m_Agent)
                For Each tmpUpdateBuse As Buse In arrUpdatesBuse
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Buse n°" & tmpUpdateBuse.numeroNational)
                        Dim response As integer = BuseManager.sendWSBuse(tmpUpdateBuse, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBuse) - Erreur Locale" & vbNewLine)
                            Case 0, 2 ' OK
                                BuseManager.setSynchro(tmpUpdateBuse)
                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                '    BuseManager.save(BuseManager.xml2object(updatedObject), True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSBuse) - Le web service a répondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBuse) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Buse) : " & ex.Message.ToString)
                    End Try
                Next

            End If
            If (m_SynchroBoolean.m_bSynchAscMano) Then
                ' Synchro d'un ManometreControle
                ' On récupère les mises à jours
                Dim arrUpdatesManometreControle() As ManometreControle = ManometreControleManager.getUpdates(m_Agent)
                For Each tmpUpdateManometreControle As ManometreControle In arrUpdatesManometreControle
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Manometre de Controle n°" & tmpUpdateManometreControle.numeroNational)
                        Dim response As integer = ManometreControleManager.sendWSManometreControle(m_Agent, tmpUpdateManometreControle, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreControle) - Erreur Locale")
                            Case 0, 2 ' OK
                                ManometreControleManager.setSynchro(tmpUpdateManometreControle)
                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                '    ManometreControleManager.save(ManometreControleManager.xml2object(updatedObject), True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSManometreControle) - Le web service a répondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreControle) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Mano Contrôle) : " & ex.Message.ToString)
                    End Try
                Next
            End If
            If (m_SynchroBoolean.m_bSynchAscMano) Then

                ' Synchro d'un ManometreEtalon
                ' On récupère les mises à jours
                Dim arrUpdatesManometreEtalon() As ManometreEtalon = ManometreEtalonManager.getUpdates(m_Agent)
                For Each tmpUpdateManometreEtalon As ManometreEtalon In arrUpdatesManometreEtalon
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Manometre Etalon n°" & tmpUpdateManometreEtalon.numeroNational)
                        Dim response As integer = ManometreEtalonManager.sendWSManometreEtalon(m_Agent, tmpUpdateManometreEtalon, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreEtalon) - Erreur Locale")
                            Case 0, 2 ' OK
                                ManometreEtalonManager.setSynchro(tmpUpdateManometreEtalon)
                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                '    ManometreEtalonManager.save(ManometreEtalonManager.xml2object(updatedObject), True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSManometreEtalon) - Le web service a répondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSManometreEtalon) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Mano Etalon) : " & ex.Message.ToString)
                    End Try
                Next

            End If
            If (m_SynchroBoolean.m_bSynchAscBanc) Then
                ' Synchro d'un Banc
                Dim arrUpdatesBanc() As Banc = BancManager.getUpdates(m_Agent)
                For Each tmpUpdateBanc As Banc In arrUpdatesBanc
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Banc de mesure n°" & tmpUpdateBanc.id)
                        Dim response As integer = BancManager.sendWSBanc(m_Agent, tmpUpdateBanc, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBanc) - Erreur Locale")
                            Case 0, 2 ' OK
                                BancManager.setSynchro(tmpUpdateBanc)
                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                '    BancManager.save(BancManager.xml2object(updatedObject), True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSBanc) - Le web service a répondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSBanc) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Banc) : " & ex.Message.ToString)
                    End Try
                Next

            End If
            If (m_SynchroBoolean.m_bsynchAscFV) Then
                'Synhcronisation des Fiches de vies ManoDe Controle
                runascSynchroFVManoControle()

                ' Synchro d'un FVManometreEtalon
                runascSynchroFVManoEtalon()

                'Synhcro des FVBanc
                runascSynchroFVBanc()

            End If
            If (m_SynchroBoolean.m_bSynchAscPulve) Then
                ' Synchro d'un Pulverisateur
                Dim arrUpdatesPulverisateur() As Pulverisateur = PulverisateurManager.getUpdates(m_Agent)
                For Each oPulverisateur As Pulverisateur In arrUpdatesPulverisateur
                    Try
                        Dim UpdatedObject As Object = nothing
                        Notice("Pulverisateur n°" & oPulverisateur.id)
                        Dim response As integer = PulverisateurManager.sendWSPulverisateur(m_Agent, oPulverisateur, updatedObject)
                        Select Case response
                            Case -1 ' ERROR
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPulverisateur) - Erreur Locale")
                            Case 0, 2 ' OK
                                PulverisateurManager.setSynchro(oPulverisateur)
                                'Case 2 ' SENDPROFILAGENT_UPDATE
                                'PulverisateurManager.save(PulverisateurManager.xml2object(updatedObject), "0", m_Agent, True)
                            Case 1 ' NOK
                                CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSPulverisateur) - Le web service a répondu : Non-Ok")
                            Case 9 ' BADREQUEST
                                CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPulverisateur) - Le web service a répondu : BadRequest")
                        End Select
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(Pulverisateur) : " & ex.Message.ToString)
                    End Try
                Next

            End If
            If (m_SynchroBoolean.m_bSynchAscPulve) Then
                ' Synchro d'un ExploitationTOPulverisateur
                Dim arrUpdatesExploitationTOPulverisateur() As ExploitationTOPulverisateur = ExploitationTOPulverisateurManager.getUpdates(m_Agent)
                For Each oExploitationTOPulverisateur As ExploitationTOPulverisateur In arrUpdatesExploitationTOPulverisateur
                    Dim UpdatedObject As Object = nothing
                    Notice("ExploitationToPulverisateur n°" & oExploitationTOPulverisateur.idPulverisateur)
                    Dim response As integer = ExploitationTOPulverisateurManager.sendWSExploitationTOPulverisateur(oExploitationTOPulverisateur, updatedObject)
                    Select Case response
                        Case -1 ' ERROR
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitationTOPulverisateur) - Erreur Locale")
                        Case 0, 2 ' OK
                            ExploitationTOPulverisateurManager.setSynchro(oExploitationTOPulverisateur)
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            'ExploitationTOPulverisateurManager.save(ExploitationTOPulverisateurManager.xml2object(updatedObject), m_Agent, True)
                        Case 1 ' NOK
                            CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSExploitationTOPulverisateur) - Le web service a répondu : Non-Ok")
                        Case 9 ' BADREQUEST
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSExploitationTOPulverisateur) - Le web service a répondu : BadRequest")
                    End Select
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
                Notice("des Controles Reguliers ")
                Dim bReturn As Boolean = AutoTestManager.sendWSControlesReguliers(m_Agent)
                If Not bReturn Then
                    CSDebug.dispError("Synchronisation::runAscSynchro(sendWSControlesReguliers) - Erreur Locale")
                End If
            End If


            'Fin de Synchro ascendante
            Notice("Fin synchro ascendante")
            SynchronisationManager.LogSynchroEnd()
            SynchronisationManager.DBsaveSynchro("asc", m_listSynchro)


        Else
            CSDebug.dispWarn("Synchronisation::runDescSynchro : Serveur CRODIP Ping Timeout")
            Notice("Synchronisation impossible, serveur Crodip momentanément indisponible.")
        End If

    End Sub
    ''' <summary>
    ''' Execution de la synhcro Ascendate des prestations
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Sub runASCSynchroPresta()
        If (m_SynchroBoolean.m_bSynchAscPrestation) Then

            ' Synchro des prestationsCategories
            Dim arrUpdatesPrestationCategorie() As PrestationCategorie = PrestationCategorieManager.getUpdates
            For Each tmpUpdatePrestationCategorie As PrestationCategorie In arrUpdatesPrestationCategorie
                Try
                    Dim UpdatedObject As Object = nothing
                    Dim response As integer = PrestationCategorieManager.sendWSPrestationCategorie(tmpUpdatePrestationCategorie, m_Agent, updatedObject)
                    Notice("PrestationCategorie n°" & tmpUpdatePrestationCategorie.id)
                    Select Case response
                        Case -1 ' ERROR
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationCategorie) - Erreur Locale")
                        Case 0, 2 ' OK
                            PrestationCategorieManager.setSynchro(tmpUpdatePrestationCategorie)
                            '                            listSynchro = listSynchro & "Catégorie de tarif (n°" & tmpUpdatePrestationCategorie.id & ") ; "
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            '                           listSynchro = listSynchro & "Catégorie de tarif (n°" & tmpUpdatePrestationCategorie.id & ") ; "
                            'PrestationCategorieManager.save(PrestationCategorieManager.xml2object(updatedObject), m_Agent, True)
                        Case 1 ' NOK
                            CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSPrestationCategorie) - Le web service a répondu : Non-Ok")
                        Case 9 ' BADREQUEST
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationCategorie) - Le web service a répondu : BadRequest")
                    End Select
                Catch ex As Exception
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationCategorie) : " & ex.Message.ToString)
                End Try
            Next

        End If
        If (m_SynchroBoolean.m_bSynchAscPrestation) Then
            ' Synchro des prestationsTarif
            Dim arrUpdatesPrestationTarif() As PrestationTarif = PrestationTarifManager.getUpdates
            For Each tmpUpdatePrestationTarif As PrestationTarif In arrUpdatesPrestationTarif
                Try
                    Dim UpdatedObject As Object = nothing
                    Notice("PrestationTarif n°" & tmpUpdatePrestationTarif.id)
                    Dim response As integer = PrestationTarifManager.sendWSPrestationTarif(tmpUpdatePrestationTarif, m_Agent, updatedObject)
                    Select Case response
                        Case -1 ' ERROR
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationTarif) - Erreur Locale")
                        Case 0, 2 ' OK
                            PrestationTarifManager.setSynchro(tmpUpdatePrestationTarif)
                            'listSynchro = listSynchro & "Tarif (n°" & tmpUpdatePrestationTarif.id & ") ; "
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            'listSynchro = listSynchro & "Tarif (n°" & tmpUpdatePrestationTarif.id & ") ; "
                            'PrestationTarifManager.save(PrestationTarifManager.xml2object(updatedObject), m_Agent, True)
                        Case 1 ' NOK
                            CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSPrestationTarif) - Le web service a répondu : Non-Ok")
                        Case 9 ' BADREQUEST
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationTarif) - Le web service a répondu : BadRequest")
                    End Select
                Catch ex As Exception
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSPrestationTarif) : " & ex.Message.ToString)
                End Try
            Next

        End If

    End Sub
    '''
    ''' Synchronisation des Fiches de vies Banc vers le Serveur

    Public Sub runascSynchroFVBanc()
        ' Synchro d'un FVBanc
        Dim arrUpdatesFVBanc() As FVBanc = FVBancManager.getUpdates(m_Agent)
        For Each oFVBanc As FVBanc In arrUpdatesFVBanc
            Try
                Dim UpdatedObject As Object = nothing
                Notice("Fiche de Vie Banc de Mesure n°" & oFVBanc.id)
                Dim response As integer = FVBancManager.sendWSFVBanc(oFVBanc, updatedObject)
                Select Case response
                    Case -1 ' ERROR
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVBanc) - Erreur Locale")
                    Case 0, 2 ' OK
                        FVBancManager.setSynchro(oFVBanc)
                        FVBancManager.SendFTPEtats(oFVBanc)
                    Case 1 ' NOK
                        CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSFVBanc) - Le web service a répondu : Non-Ok")
                    Case 9 ' BADREQUEST
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVBanc) - Le web service a répondu : BadRequest")
                End Select
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runAscSynchro(FVBanc) : " & ex.Message.ToString)
            End Try
        Next

    End Sub
    Public Function runascSynchroDiag(ByVal pAgent As Agent, ByVal pDiag As Diagnostic) As Boolean
        Dim bReturn As Boolean
        Try
            Notice("Diagnostic " & pDiag.id)

            Dim UpdatedObject As Object = nothing
            'On Efface les propiétés de DiagItemList et DiagBusesList car elle n'ont pas besoin d'être serialisées avec le diag vues qu'elle sont synchronisées à part
            Dim oDiagItemList As DiagnosticItemsList = pDiag.diagnosticItemsLst
            pDiag.diagnosticItemsLst = Nothing
            Dim oDiagBusesList As DiagnosticBusesList = pDiag.diagnosticBusesList
            pDiag.diagnosticBusesList = Nothing
            Dim response As integer = DiagnosticManager.sendWSDiagnostic(pAgent, pDiag, updatedObject)
            'Après Synchro on replace les propriétés
            pDiag.diagnosticItemsLst = oDiagItemList
            pDiag.diagnosticBusesList = oDiagBusesList

            Select Case response
                Case -1 ' ERROR
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnostic) - Erreur Locale")
                Case 0, 2 ' OK
                    'If response = 0 Then
                    DiagnosticManager.setSynchro(pDiag)
                    ' Else
                    'DiagnosticManager.save(DiagnosticManager.xml2object(updatedObject), True)
                    'End If
                Case 1 ' NOK
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnostic) - Le web service a répondu : Non-Ok")
                Case 9 ' BADREQUEST
                    CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnostic) - Le web service a répondu : BadRequest")
            End Select

            ' Synchro des items du diag courant
            If pDiag.diagnosticItemsLst.Count > 0 Then
                Dim updatedObjectDiagItem As Object
                Notice("diagnostic items n°" & pDiag.id)
                Dim responseDiagItem As Integer = DiagnosticItemManager.sendWSDiagnosticItem(pAgent, pDiag.diagnosticItemsLst, updatedObjectDiagItem)
                Select Case responseDiagItem
                    Case -1 ' ERROR
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticItem) - Erreur Locale")
                    Case 0, 2 ' OK
                        For Each tmpXmlDiagItem As Object In updatedObjectDiagItem
                            DiagnosticItemManager.setSynchro(DiagnosticItemManager.xml2object(tmpXmlDiagItem))
                        Next
                        'Case 2 ' SENDPROFILAGENT_UPDATE
                        '    Dim ocsdb As New CSDb(True)
                        '    For Each tmpXmlDiagItem As Object In updatedObjectDiagItem
                        '        DiagnosticItemManager.save(ocsdb, DiagnosticItemManager.xml2object(tmpXmlDiagItem), True)
                        '    Next
                        '    ocsdb.free()
                    Case 1 ' NOK
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticItem) - Le web service a répondu : Non-Ok")
                    Case 9 ' BADREQUEST
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticItem) - Le web service a répondu : BadRequest")
                End Select
            End If
            ' Synchro des buses du diag courant
            If Not pDiag.diagnosticBusesList Is Nothing Then
                If pDiag.diagnosticBusesList.Liste.Count > 0 Then
                    Dim updatedObjectDiagBuse As Object
                    Notice("diagnostic Buses n°" & pDiag.id)
                    Dim responseDiagBuse As Object = DiagnosticBusesManager.sendWSDiagnosticBuses(pAgent, pDiag.diagnosticBusesList, updatedObjectDiagBuse)
                    Select Case responseDiagBuse
                        Case -1 ' ERROR
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Erreur Locale")
                        Case 0, 2 ' OK
                            For Each tmpXmlDiagBuse As Object In updatedObjectDiagBuse
                                DiagnosticBusesManager.setSynchro(DiagnosticBusesManager.xml2object(tmpXmlDiagBuse))
                            Next
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            '    For Each tmpXmlDiagBuse As Object In updatedObjectDiagBuse
                            '        DiagnosticBusesManager.save(DiagnosticBusesManager.xml2object(tmpXmlDiagBuse), True)
                            '    Next
                        Case 1 ' NOK
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a répondu : Non-Ok")
                        Case 9 ' BADREQUEST
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a répondu : BadRequest")
                    End Select

                    ' Synchro des détails des buses du diag courant
                    For Each tmpUpdateDiagnosticBuses As DiagnosticBuses In pDiag.diagnosticBusesList.Liste
                        If Not tmpUpdateDiagnosticBuses.diagnosticBusesDetailList Is Nothing Then
                            If tmpUpdateDiagnosticBuses.diagnosticBusesDetailList.Liste.Count > 0 Then
                                Dim updatedObjectDiagBuseDetail As Object
                                Notice("diagnostic Buse Detail n°" & pDiag.id)
                                Dim responseDiagBuseDetail As Object = DiagnosticBusesDetailManager.sendWSDiagnosticBusesDetail(pAgent, tmpUpdateDiagnosticBuses.diagnosticBusesDetailList, updatedObjectDiagBuseDetail)
                                Select Case responseDiagBuseDetail
                                    Case -1 ' ERROR
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBusesDetail) - Erreur Locale")
                                    Case 0, 2 ' OK
                                        For Each tmpXmlDiagBuseDetail As Object In updatedObjectDiagBuseDetail
                                            DiagnosticBusesDetailManager.setSynchro(DiagnosticBusesDetailManager.xml2object(tmpXmlDiagBuseDetail))
                                        Next
                                        'Case 2 ' SENDPROFILAGENT_UPDATE
                                        '    For Each tmpXmlDiagBuseDetail As Object In updatedObjectDiagBuseDetail
                                        '        DiagnosticBusesDetailManager.save(DiagnosticBusesDetailManager.xml2object(tmpXmlDiagBuseDetail), True)
                                        '    Next
                                    Case 1 ' NOK
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a répondu : Non-Ok")
                                    Case 9 ' BADREQUEST
                                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticBuses) - Le web service a répondu : BadRequest")
                                End Select
                            End If
                        End If
                    Next
                    ' FIN --- Synchro des détails des buses du diag courant
                End If
            End If
            ' Synchro des 542
            If Not pDiag.diagnosticMano542List Is Nothing Then
                If pDiag.diagnosticMano542List.Liste.Count > 0 Then
                    Dim updatedObjectDiag542 As Object
                    Dim responseDiag542 As Object = DiagnosticMano542Manager.sendWSDiagnosticMano542(pAgent, pDiag.diagnosticMano542List, updatedObjectDiag542)
                    Notice("diagnostic mano 542 n°" & pDiag.id)
                    Select Case responseDiag542
                        Case -1 ' ERROR
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticMano542) - Erreur Locale")
                        Case 0, 2 ' OK
                            For Each tmpXmlDiag542 As Object In updatedObjectDiag542
                                DiagnosticMano542Manager.setSynchro(DiagnosticMano542Manager.xml2object(tmpXmlDiag542))
                            Next
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            '    For Each tmpXmlDiag542 As Object In updatedObjectDiag542
                            '        DiagnosticMano542Manager.save(DiagnosticMano542Manager.xml2object(tmpXmlDiag542), True)
                            '    Next
                        Case 1 ' NOK
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticMano542) - Le web service a répondu : Non-Ok")
                        Case 9 ' BADREQUEST
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticMano542) - Le web service a répondu : BadRequest")
                    End Select
                End If
            End If


            ' Synchro des 833
            If Not pDiag.diagnosticTroncons833 Is Nothing Then
                If pDiag.diagnosticTroncons833.Liste.Count > 0 Then
                    Dim updatedObjectDiag833 As Object
                    Notice("diagnostic Troncons 833 n°" & pDiag.id)
                    Dim responseDiag833 As Object = DiagnosticTroncons833Manager.sendWSDiagnosticTroncons833(pAgent, pDiag.diagnosticTroncons833, updatedObjectDiag833)
                    Select Case responseDiag833
                        Case -1 ' ERROR
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticTroncons833) - Erreur Locale")
                        Case 0, 2 ' OK
                            For Each tmpXmlDiag833 As Object In updatedObjectDiag833
                                DiagnosticTroncons833Manager.setSynchro(DiagnosticTroncons833Manager.xml2object(tmpXmlDiag833))
                            Next
                            'Case 2 ' SENDPROFILAGENT_UPDATE
                            '    For Each tmpXmlDiag833 As Object In updatedObjectDiag833
                            '        DiagnosticTroncons833Manager.save(DiagnosticTroncons833Manager.xml2object(tmpXmlDiag833), True)
                            '    Next
                        Case 1 ' NOK
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticTroncons833) - Le web service a répondu : Non-Ok")
                        Case 9 ' BADREQUEST
                            CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSDiagnosticTroncons833) - Le web service a répondu : BadRequest")
                    End Select
                End If
            End If
            'Synchro des Rapports d'inspection et Synthèse des mesures
            Notice("Rapport Inspection et Synthese des mesures")
            DiagnosticManager.SendFTPEtats(pDiag)


            'Ajout du Diag 


            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Synchronisation.runascSynchroDiag ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function getListeElementsASynchroniserDESC() As List(Of SynchronisationElmt)
        Dim lstElementsASynchroniser As List(Of SynchronisationElmt)
        lstElementsASynchroniser = SynchronisationManager.getWSlstElementsASynchroniser(m_Agent, m_SynchroBoolean)
        Return lstElementsASynchroniser
    End Function
    ''' <summary>
    ''' Synchronisation Descendante : Récupération de la liste des elements à synchroniser
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function runDescSynchro() As Boolean
        Dim bReturn As Boolean
        Try
            m_listSynchro = ""
            Notice("Debut synchro descendante")
            SynchronisationManager.LogSynchroStart("DESC")
            'On récupère les éléments à synchroniser
            Dim lstElementsASynchroniser As List(Of SynchronisationElmt)
            lstElementsASynchroniser = getListeElementsASynchroniserDESC()

            bReturn = runDescSynchro(lstElementsASynchroniser)
        Catch Ex As Exception
            CSDebug.dispError("Synchronisation.runDescSynchro Err : " & Ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Synchronisation Descendante à partir d'une liste des elements à synchroniser 
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
            'On Traite les synchro Agent D'abord
            For Each oSynchroElmt As SynchronisationElmt In lstElementsASynchroniser
                If oSynchroElmt.type.ToUpper().Trim() = "GetAgent".ToUpper().Trim() Then
                    Notice(" Agent")
                    oSynchroElmt.SynchroDesc(m_Agent)
                    oSynchroElmt.Traitee = True
                End If
            Next

            'On recharge l'agent courant
            m_Agent = AgentManager.getAgentById(m_Agent.id)
            agentCourant = m_Agent
            'Si l'agent n'est pas supprimé
            If Not String.IsNullOrEmpty(m_Agent.id) Then
                'On synchronise les élements non traité (<> GetAgent)
                For Each oSynchroElmt As SynchronisationElmt In lstElementsASynchroniser
                    If oSynchroElmt.Traitee = False Then
                        If Not IsElementDansSynchroASC(oSynchroElmt) Then
                            If oSynchroElmt.type.ToUpper() <> "GETDOCUMENT" Then
                                Notice(oSynchroElmt.type & "[" & oSynchroElmt.identifiantChaine & "]")
                            Else
                                If oSynchroElmt.update Then
                                    Notice(oSynchroElmt.type & "[" & oSynchroElmt.identifiantChaine & "]")
                                End If
                            End If

                            oSynchroElmt.SynchroDesc(m_Agent)
                            oSynchroElmt.Traitee = True
                        End If
                    End If
                Next
                '' On affiche le log

                ' Ensuite on met à jour la date de dernière synchro
                Notice("MAJ date de dernière Synchro")
                MAJDateDerniereSynchro()
                bReturn = True
                SynchronisationManager.LogSynchroEnd()
                Notice("Fin Synchronisation descendante")
                SynchronisationManager.DBsaveSynchro("desc", m_listSynchro)
            End If

        Catch ex As Exception
            CSDebug.dispError("Synchronisation.runDescSynchro Err : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn


    End Function

    Private Function IsElementDansSynchroASC(pElement As SynchronisationElmt) As Boolean
        Dim bReturn As Boolean
        Try

            Dim nbElement As Integer = (From elmt As SynchronisationElmt In m_ListeElementSynchroASC
                         Where elmt.type = pElement.type And elmt.identifiantChaine = pElement.identifiantChaine
                         Select elmt).Count

            bReturn = (nbElement > 0)
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    '''
    ''' Mise à jour de la date de dernère synhcro
    ''' 
    Private Function MAJDateDerniereSynchro() As Boolean
        Dim bReturn As Boolean
        Try
            ' Récupération de la date de synchro à partir du serveur
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim synchroDateTime As Object = Nothing
            objWSCrodip.GetSynchroDateTime(synchroDateTime)
            Dim sDateFromSRV As String = synchroDateTime(0).InnerText().replace("/", "-")
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
            'Ajout de 10 Secondes 
            dtSRV.AddSeconds(10)
            'Maj de l'agent 
            m_Agent.dateDerniereSynchro = CSDate.ToCRODIPString(dtSRV)
            If Not m_Agent.isSupprime Then
                AgentManager.save(m_Agent)
            End If
            'Maj de la date de dernière synchro de l'agent sur le SRV
            CSDebug.dispInfo("MAJ date dernier Synchro ID=" & m_Agent.id & ",DateDernSynchro=" & m_Agent.dateDerniereSynchro)
            objWSCrodip.SetDateSynchroAgent(m_Agent.id, m_Agent.dateDerniereSynchro)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationManager.MAJDateDerniereSynchro ERR" & ex.Message)
            bReturn = False
        End Try
        agentCourant = m_Agent
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

    Public Sub runascSynchroFVManoControle()
        ' On récupère les mises à jours
        Dim arrUpdatesFVManometreControle() As FVManometreControle = FVManometreControleManager.getUpdates(m_Agent)
        For Each tmpUpdateFVManometreControle As FVManometreControle In arrUpdatesFVManometreControle
            Try
                Dim UpdatedObject As Object = nothing
                Notice("Fiche de Vie Manometre de Controle n°" & tmpUpdateFVManometreControle.id)
                Dim response As integer = FVManometreControleManager.sendWSFVManometreControle(tmpUpdateFVManometreControle, updatedObject)
                Select Case response
                    Case -1 ' ERROR
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreControle) - Erreur Locale")
                    Case 0, 2
                        FVManometreControleManager.setSynchro(tmpUpdateFVManometreControle)
                        FVManometreControleManager.SendFTPEtats(tmpUpdateFVManometreControle)

                    Case 1 ' NOK
                        CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSFVManometreControle) - Le web service a répondu : Non-Ok")
                    Case 9 ' BADREQUEST
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreControle) - Le web service a répondu : BadRequest")
                End Select
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runAscSynchro(FVManoControle) : " & ex.Message.ToString)
            End Try
        Next
    End Sub
    Public Sub runascSynchroFVManoEtalon()

        ' On récupère les mises à jours
        Dim arrUpdatesFVManometreEtalon() As FVManometreEtalon = FVManometreEtalonManager.getUpdates(m_Agent)
        For Each tmpUpdateFVManometreEtalon As FVManometreEtalon In arrUpdatesFVManometreEtalon
            Try
                Dim UpdatedObject As Object = nothing
                Notice("Fiche de Vie Manometre Etalon n°" & tmpUpdateFVManometreEtalon.id)
                Dim response As integer = FVManometreEtalonManager.sendWSFVManometreEtalon(tmpUpdateFVManometreEtalon, updatedObject)
                Select Case response
                    Case -1 ' ERROR
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreEtalon) - Erreur Locale")
                    Case 0, 2 ' OK
                        FVManometreEtalonManager.setSynchro(tmpUpdateFVManometreEtalon)
                        'Case 2 ' OK
                        '    FVManometreEtalonManager.setSynchro(tmpUpdateFVManometreEtalon)
                    Case 1 ' NOK
                        CSDebug.dispWarn("Synchronisation::runAscSynchro(sendWSFVManometreEtalon) - Le web service a répondu : Non-Ok")
                    Case 9 ' BADREQUEST
                        CSDebug.dispFatal("Synchronisation::runAscSynchro(sendWSFVManometreEtalon) - Le web service a répondu : BadRequest")
                End Select
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runAscSynchro(FVManoEtalon) : " & ex.Message.ToString)
            End Try
        Next
    End Sub

End Class
