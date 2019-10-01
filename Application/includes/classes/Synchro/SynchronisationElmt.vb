
Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationElmt

    Private _type As String
    Private _identifiantEntier As Integer
    Private _identifiantChaine As String
    Private _valeurAuxiliaire As String
    Private _checksumMD5 As String
    Private _checksumCalc As String
    Private m_bTraitee As Boolean
    Private _Update As Boolean 'A t�l�charger (0 = Non , 1 = Oui)
    Private _Status As String
    Private m_SynchroBoolean As SynchroBooleans

    Public Sub New()
        _type = ""
        m_bTraitee = False
        _Update = True
        m_SynchroBoolean = New SynchroBooleans
    End Sub

    Protected Sub New(pType As String, pSynchroBooleans As SynchroBooleans)
        _type = pType
        m_bTraitee = False
        _Update = True
        m_SynchroBoolean = pSynchroBooleans
    End Sub

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public Property identifiantEntier() As Integer
        Get
            Return _identifiantEntier
        End Get
        Set(ByVal Value As Integer)
            _identifiantEntier = Value
        End Set
    End Property

    Public Property identifiantChaine() As String
        Get
            Return _identifiantChaine
        End Get
        Set(ByVal Value As String)
            _identifiantChaine = Value
        End Set
    End Property
    Public Property valeurAuxiliaire() As String
        Get
            Return _valeurAuxiliaire
        End Get
        Set(ByVal Value As String)
            _valeurAuxiliaire = Value
        End Set
    End Property
    Public Property checksumMD5() As String
        Get
            Return _checksumMD5
        End Get
        Set(ByVal Value As String)
            _checksumMD5 = Value
        End Set
    End Property
    Public Property checksumCalc() As String
        Get
            Return _checksumCalc
        End Get
        Set(ByVal Value As String)
            _checksumCalc = Value
        End Set
    End Property
    Public Property update() As Boolean
        Get
            Return _Update
        End Get
        Set(ByVal Value As Boolean)
            _Update = Value
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

    Public Function Fill(ByVal PNAme As String, ByVal pValue As String) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case PNAme.ToUpper.Trim()
                Case "type".ToUpper.Trim()
                    If type = "" Then
                        type = Trim(pValue)
                    End If
                Case "identifiantEntier".ToUpper.Trim()
                    If Not String.IsNullOrEmpty(pValue) Then
                        identifiantEntier = CInt(Trim(pValue))
                    End If
                Case "identifiantChaine".ToUpper.Trim()
                    identifiantChaine = Trim(pValue)
                Case "valeurAuxiliaire".ToUpper.Trim()
                    valeurAuxiliaire = Trim(pValue)
                Case "md5".ToUpper.Trim()
                    _checksumMD5 = Trim(pValue)
                Case "update".ToUpper.Trim()
                    If pValue = "1" Then
                        _Update = True
                    Else
                        _Update = False
                    End If
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Synchronisation.Fill Err" & ex.Message)
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
    Public Sub setStatus(pString As String)
        _Status = pString
    End Sub
    Public Function getStatus() As String
        Return _Status
    End Function
    Public Overridable Function SynchroDesc(pAgent As Agent) As Boolean
        Dim pElement As SynchronisationElmt
        Dim bReturn As Boolean
        pElement = Me
        Select Case pElement.type.ToUpper().Trim()

            Case "GetPrestationCategorie".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescPrestation) Then

                    Dim tmpObject As New PrestationCategorie
                    Try
                        setStatus("R�ception MAJ Cat�gorie de prestation n�" & pElement.identifiantChaine & "...")
                        tmpObject = PrestationCategorieManager.getWSPrestationCategorieById(pAgent, CType(pElement.identifiantChaine, Integer))
                        PrestationCategorieManager.save(tmpObject, pAgent, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetPrestationCategorie) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetPrestationTarif".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescPrestation) Then
                    Dim tmpObject As New PrestationTarif
                    Try
                        ' R�cup id's
                        Dim tmpSplit() As String = pElement.identifiantChaine.Split("-")
                        Dim idObject As Integer = CType(tmpSplit(0), Integer)
                        Dim idCategorie As Integer = CType(tmpSplit(1), Integer)
                        setStatus("R�ception MAJ Tarif de prestation n�" & idObject & "...")
                        tmpObject = PrestationTarifManager.getWSPrestationTarifById(idObject, idCategorie, pAgent)
                        PrestationTarifManager.save(tmpObject, pAgent, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetPrestationTarif) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

            Case SynchronisationElmtDiag.getLabelGet.ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescDiag) Then
                    Dim tmpObject As New Diagnostic
                    Try
                        setStatus("R�ception MAJ contr�le n�" & pElement.identifiantChaine & "...")
                        tmpObject = DiagnosticManager.getWSDiagnosticById(pAgent.id, pElement.identifiantChaine)
                        DiagnosticManager.save(tmpObject, True)
                        'R�cup�ration des etats du diagnostic s'ils n'existent pas
                        If Not String.IsNullOrEmpty(tmpObject.RIFileName) Then
                            If Not File.Exists(Globals.CONST_PATH_EXP & "/" & tmpObject.RIFileName) Then
                                DiagnosticManager.getFTPEtats(tmpObject)
                            End If
                        End If

                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnostic) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case SynchronisationElmtDiagItem.getLabelGet.ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescDiag) Then
                    Dim tmpObject As Diagnostic
                    Try
                        setStatus("R�ception MAJ item de contr�le n�" & pElement.identifiantChaine & "...")
                        tmpObject = DiagnosticItemManager.getWSDiagnosticItemsByDiagnosticId(pAgent, pElement.identifiantChaine)
                        DiagnosticManager.SaveDiagItems(tmpObject, False, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticItems) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

            Case SynchronisationElmtDiagBuses.getLabelGet.ToUpper().Trim()

                If (m_SynchroBoolean.m_bSynchDescDiag) Then
                    Dim tmpObjectList As DiagnosticBusesList
                    Dim tmpObject As DiagnosticBuses
                    Try
                        setStatus("R�ception MAJ buse de contr�le n�" & pElement.identifiantChaine & "...")
                        tmpObjectList = DiagnosticBusesManager.getWSDiagnosticBusesById(pElement.identifiantChaine)
                        For Each tmpObject In tmpObjectList.Liste
                            DiagnosticBusesManager.save(tmpObject, True)
                        Next
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBuses) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case SynchronisationElmtDiagBusesDetail.getLabelGet.ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescDiag) Then
                    Dim tmpObjectList As New DiagnosticBusesDetailList
                    Dim tmpObject As New DiagnosticBusesDetail
                    Try
                        setStatus("R�ception MAJ d�tail des buse de contr�le n�" & pElement.identifiantChaine & "...")
                        tmpObjectList = DiagnosticBusesDetailManager.getWSDiagnosticBusesDetailById(pElement.identifiantChaine)
                        For Each tmpObject In tmpObjectList.Liste
                            DiagnosticBusesDetailManager.save(tmpObject, True)
                        Next
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBusesDetail) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case SynchronisationElmtDiagMano542.getLabelGet.ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescDiag) Then
                    Dim tmpObjectList As New DiagnosticMano542List
                    Dim tmpObject As New DiagnosticMano542
                    Try
                        setStatus("R�ception MAJ DiagnosticMano542 n�" & pElement.identifiantChaine & "...")
                        tmpObjectList = DiagnosticMano542Manager.getWSDiagnosticMano542ById(pElement.identifiantChaine)
                        For Each tmpObject In tmpObjectList.Liste
                            DiagnosticMano542Manager.save(tmpObject, True)
                        Next
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBusesDetail) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case SynchronisationElmtDiagMano833.getLabelGet.ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescDiag) Then
                    Dim tmpObject As New DiagnosticTroncons833
                    Dim tmpObjectList As New DiagnosticTroncons833List
                    Try
                        setStatus("R�ception MAJ DiagnosticTroncons833 n�" & pElement.identifiantChaine & "...")
                        tmpObjectList = DiagnosticTroncons833Manager.getWSDiagnosticTroncons833ById(pElement.identifiantChaine)
                        For Each tmpObject In tmpObjectList.Liste
                            DiagnosticTroncons833Manager.save(tmpObject, True)
                        Next
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBusesDetail) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
                'Case "GetReferentielBuse".ToUpper().Trim()
                '    If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
                '        SynchronisationManager.LogSynchroElmt(pElement)
                '        Try
                '            Statusbar_display("R�ception MAJ r�f�rentiel de buses...")
                '            ReferentielBuseManager.getWSReferentielBuse()
                '            bReturn = True
                '        Catch ex As Exception
                '            CSDebug.dispFatal("Synchronisation::runDescSynchro(GetReferentielBuse) : " & ex.Message.ToString)
                '            bReturn = False
                '        End Try
                '    End If

            Case "GetReferentielManometre".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
                    Try
                        setStatus("R�ception MAJ r�f�rentiel des marques de mmanom�tre...")
                        ReferentielManometreManager.getWSReferentielManometre()
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetReferentielManometre) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetReferentielPulverisateur".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
                    Try
                        setStatus("R�ception MAJ r�f�rentiel des marques de pulv�risateur...")
                        ReferentielPulverisateurManager.getWSReferentielPulverisateur()
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetReferentielPulverisateur) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetReferentielPulverisateurMarquesModeles".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
                    Try
                        setStatus("R�ception MAJ r�f�rentiel des marques et des mod�les de pulv�risateur...")
                        ReferentielPulverisateurManager.getWSReferentielPulverisateurMarquesModeles()
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(getWSReferentielPulverisateurMarquesModeles) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetReferentielPulverisateurTypesCategories".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
                    Try
                        setStatus("R�ception MAJ r�f�rentiel des types et des catgories de pulv�risateur...")
                        ReferentielPulverisateurManager.getWSReferentielPulverisateurTypesCategories()
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(getWSReferentielPulverisateurTypesCategories) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetReferentielTerritoire".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescReferentiel) Then

                    Try
                        setStatus("R�ception MAJ r�f�rentiel des territoires...")
                        ReferentielTerritoireManager.getWSReferentielTerritoire()
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetReferentielTerritoire) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

            Case "GetVersionLogicielAgent".ToUpper().Trim()
                'If CSEnvironnement.checkVersion = False Then
                '    MsgBox(CSEnvironnement.versionMessage & vbNewLine & CSEnvironnement.versionUrl)
                '    globFormParent.Close()
                '    Return False
                'End If

            Case "GetExploitation".ToUpper().Trim() ' Synchro d'un client
                If (m_SynchroBoolean.m_bSynchDescExploitation) Then
                    Dim tmpObject As New Exploitation
                    Try
                        setStatus("R�ception MAJ Exploitation n�" & pElement.identifiantChaine & "...")
                        tmpObject = ExploitationManager.getWSExploitationById(pElement.identifiantChaine)
                        ExploitationManager.save(tmpObject, pAgent, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetExploitation) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

            Case "GetAgent".ToUpper().Trim() ' Synchro d'un agent
                If (m_SynchroBoolean.m_bSynchDescAgent) Then
                    Dim tmpObject As New Agent
                    Try
                        setStatus("R�ception MAJ Agent n�" & pElement.identifiantChaine & "...")
                        tmpObject = AgentManager.getWSAgentById(pElement.identifiantChaine)
                        If tmpObject.id <> 0 Then
                            pAgent = tmpObject
                            CSDebug.dispInfo("Synchronisation::runDescSynchro(GetAgent) Mot de passe = " & tmpObject.motDePasse)
                            AgentManager.save(tmpObject, True)
                            agentCourant = pAgent
                        End If
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetAgent) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetBuse".ToUpper().Trim() ' Synchro d'une buse �talon
                If (m_SynchroBoolean.m_bSynchDescBuse) Then
                    Dim oBuseE As Buse
                    Try
                        setStatus("R�ception MAJ Buse n�" & pElement.identifiantChaine & "...")
                        oBuseE = BuseManager.getWSBuseById(pElement.identifiantChaine)
                        Dim bOld As Boolean = oBuseE.etat
                        'Modif du 6/12/2018
                        'Recalcul de l'�tat des buses apr�s synhcro
                        If oBuseE.getAlerte() = Globals.ALERTE.NOIRE Then
                            oBuseE.Desactiver()
                            BuseManager.sendWSBuse(oBuseE)
                        Else
                            oBuseE.etat = True
                        End If

                        BuseManager.save(oBuseE, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetBuse) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If


            Case "GetManometreControle".ToUpper().Trim() ' Synchro d'un Manometre de Controle
                If (m_SynchroBoolean.m_bSynchDescMano) Then
                    Dim tmpObject As New ManometreControle
                    Try
                        setStatus("R�ception MAJ Manom�tre de Controle n�" & pElement.identifiantChaine & "...")
                        tmpObject = ManometreControleManager.getWSManometreControleById(pAgent, pElement.identifiantChaine)
                        ManometreControleManager.save(tmpObject, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetManometreControle) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

            Case "GetControleBancMesure".ToUpper().Trim() ' Synchro ControleBanc
                'If (m_SynchroBoolean.m_bSynchDescBanc) Then
                '    SynchronisationManager.LogSynchroElmt(pElement)
                '    Dim tmpObject As New ControleBanc
                '    Try
                '        setStatus("R�ception MAJ Controle Banc n�" & pElement.identifiantChaine & "...")
                '        tmpObject = ControleBancManager.getWSControleBancById(pElement.identifiantChaine)
                '        ControleBancManager.save(tmpObject, pAgent, True)
                '        bReturn = True
                '    Catch ex As Exception
                '        CSDebug.dispFatal("Synchronisation::runDescSynchro(ControleBanc) : " & ex.Message.ToString)
                '        bReturn = False
                '    End Try
                'End If

            Case "GetControleManoMesure".ToUpper().Trim() ' Synchro ControleMano
                'If (m_SynchroBoolean.m_bSynchDescMano) Then
                '    SynchronisationManager.LogSynchroElmt(pElement)
                '    Dim tmpObject As New ControleMano
                '    Try
                '        setStatus("R�ception MAJ Controle Banc n�" & pElement.identifiantChaine & "...")
                '        tmpObject = ControleManoManager.getWSControleManoById(pElement.identifiantChaine)
                '        ControleManoManager.save(tmpObject, pAgent, True)
                '        bReturn = True
                '    Catch ex As Exception
                '        CSDebug.dispFatal("Synchronisation::runDescSynchro(ControleMano) : " & ex.Message.ToString)
                '        bReturn = False
                '    End Try
                'End If


            Case "GetFVManometreControle".ToUpper().Trim() ' Synchro d'une fiche de vie d'un Manometre de Controle
                If (m_SynchroBoolean.m_bSynchDescFV) Then
                    Dim tmpObject As New FVManometreControle()
                    Try
                        setStatus("R�ception MAJ Fiche de vie Manom�tre de Controle n�" & pElement.identifiantChaine & "...")
                        tmpObject = FVManometreControleManager.getWSFVManometreControleById(pElement.identifiantChaine)
                        FVManometreControleManager.save(tmpObject, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetFVManometreControle) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

            Case "GetManometreEtalon".ToUpper().Trim() ' Synchro d'un Manometre Etalon
                If (m_SynchroBoolean.m_bSynchDescFV) Then
                    Dim tmpObject As New ManometreEtalon
                    Try
                        setStatus("R�ception MAJ Manom�tre Etalon n�" & pElement.identifiantChaine & "...")
                        tmpObject = ManometreEtalonManager.getWSManometreEtalonById(pAgent, pElement.identifiantChaine)
                        ManometreEtalonManager.save(tmpObject, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetManometreEtalon) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetFVManometreEtalon".ToUpper().Trim() ' Synchro d'une fiche de vie d'un Manometre de Etalon
                If (m_SynchroBoolean.m_bSynchDescFV) Then
                    Dim tmpObject As New FVManometreEtalon(New Agent())
                    Try
                        setStatus("R�ception MAJ Fiche de vie Manom�tre Etalon n�" & pElement.identifiantChaine & "...")
                        tmpObject = FVManometreEtalonManager.getWSFVManometreEtalonById(pElement.identifiantChaine)
                        FVManometreEtalonManager.save(tmpObject, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetFVManometreEtalon) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

            Case "GetBanc".ToUpper().Trim() ' Synchro d'un Banc de mesure
                If (m_SynchroBoolean.m_bSynchDescBanc) Then
                    Dim tmpObject As New Banc
                    Try
                        setStatus("R�ception MAJ Banc n�" & pElement.identifiantChaine & "...")
                        tmpObject = BancManager.getWSBancById(pAgent, pElement.identifiantChaine)
                        BancManager.save(tmpObject, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetBanc) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetFVBanc".ToUpper().Trim() ' Synchro d'une fiche de vie d'un Banc de mesure
                If (m_SynchroBoolean.m_bSynchDescFV) Then
                    Dim tmpObject As New FVBanc(pAgent)
                    Try
                        setStatus("R�ception MAJ Fiche de vie Banc n�" & pElement.identifiantChaine & "...")
                        tmpObject = FVBancManager.getWSFVBancById(pElement.identifiantChaine)
                        If Not tmpObject Is Nothing Then
                            FVBancManager.save(tmpObject, True)
                        Else
                            CSDebug.dispFatal("Synchronisation::runDescSynchro(GetFVBanc) : [" & pElement.identifiantChaine & "]" & "Banc introuvable sur le server")

                        End If
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispError("Synchronisation::runDescSynchro(GetFVBanc) : [" & pElement.identifiantChaine & "]" & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetStructure".ToUpper().Trim() ' Synchro d'une structure
                If (m_SynchroBoolean.m_bSynchDescAgent) Then
                    Dim tmpObject As New Structuree
                    Try
                        setStatus("R�ception MAJ Organisme n�" & pElement.identifiantEntier & "...")
                        tmpObject = StructureManager.getWSStructureeById(pElement.identifiantEntier)
                        StructureManager.save(tmpObject, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetStructure) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetPulverisateur".ToUpper().Trim() ' Synchro d'un Pulverisateur
                If (m_SynchroBoolean.m_bSynchDescPulve) Then
                    Dim tmpObject As New Pulverisateur
                    Try
                        setStatus("R�ception MAJ Pulv�risateur n�" & pElement.identifiantChaine & "...")
                        tmpObject = PulverisateurManager.getWSPulverisateurById(pAgent, pElement.identifiantChaine)
                        If tmpObject IsNot Nothing Then
                            PulverisateurManager.save(tmpObject, "0", pAgent, True)
                        End If
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetPulverisateur) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetExploitationTOPulverisateur".ToUpper().Trim() ' Synchro d'un Partage de pulv� (ExploitationTOPulverisateur)
                If (m_SynchroBoolean.m_bSynchDescPulve) Then
                    Dim tmpObject As New ExploitationTOPulverisateur
                    Try
                        setStatus("R�ception MAJ Partages pulv�s...")
                        tmpObject = ExploitationTOPulverisateurManager.getWSExploitationTOPulverisateurById(pElement.identifiantChaine)
                        ExploitationTOPulverisateurManager.save(tmpObject, pAgent, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetExploitationTOPulverisateur) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetDocument".ToUpper().Trim() ' R�cup�ration d'un fichier pour stockage dans le ModuleDocumentaire
                'Fait dans la classe SynchronisationElmtDocument
            Case "GetIdentifiantPulverisateur".ToUpper().Trim() ' Synchro d'un Identifint De Pulv�risateur
                'Fait dans la classe SynchronisationElmtIdentifiantPulverisateur
        End Select
        Return bReturn

    End Function

    Public Shared Function SynchroAsc(pAgent As Agent) As Boolean

    End Function

    ''' <summary>
    ''' Fabrique des elements de Synchronisation
    ''' </summary>
    ''' <param name="pType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function createSynchronisationElmt(pType As String, pSynchroBooleans As SynchroBooleans) As SynchronisationElmt
        Dim oReturn As SynchronisationElmt
        Select Case pType.ToUpper().Trim()
            Case SynchroElementDocument.getLabelGet.ToUpper().Trim()
                oReturn = New SynchroElementDocument(pSynchroBooleans)
            Case SynchronisationElmtIdentifiantPulverisateur.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtIdentifiantPulverisateur(pSynchroBooleans)
            Case SynchronisationElmtDiag.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDiag(pSynchroBooleans)
            Case SynchronisationElmtDiagItem.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDiagItem(pSynchroBooleans)
            Case SynchronisationElmtDiagBuses.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDiagBuses(pSynchroBooleans)
            Case SynchronisationElmtDiagBusesDetail.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDiagBusesDetail(pSynchroBooleans)
            Case SynchronisationElmtDiagMano542.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDiagMano542(pSynchroBooleans)
            Case SynchronisationElmtDiagMano833.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDiagMano833(pSynchroBooleans)
            Case SynchronisationGetVersionLogicielAgent.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationGetVersionLogicielAgent(pSynchroBooleans)
            Case SynchronisationGetSynchroDateTime.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationGetSynchroDateTime(pSynchroBooleans)

            Case Else
                oReturn = New SynchronisationElmt(pType, pSynchroBooleans)

        End Select
        Return oReturn

    End Function

End Class
