
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
    Private _Update As Boolean 'A télécharger (0 = Non , 1 = Oui)
    Private _Status As String
    Protected m_SynchroBoolean As SynchroBooleans
    Private _Agent As Agent

    Public Sub New(pAgent As Agent)
        _type = ""
        m_bTraitee = False
        _Update = True
        m_SynchroBoolean = New SynchroBooleans
        _Agent = pAgent
    End Sub

    Protected Sub New(pType As String, pSynchroBooleans As SynchroBooleans)
        _type = pType
        m_bTraitee = False
        _Update = True
        m_SynchroBoolean = pSynchroBooleans
    End Sub

    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property

    Public Property IdentifiantEntier() As Integer
        Get
            Return _identifiantEntier
        End Get
        Set(ByVal Value As Integer)
            _identifiantEntier = Value
        End Set
    End Property

    Public Property IdentifiantChaine() As String
        Get
            Return _identifiantChaine
        End Get
        Set(ByVal Value As String)
            _identifiantChaine = Value
        End Set
    End Property
    Public Property ValeurAuxiliaire() As String
        Get
            Return _valeurAuxiliaire
        End Get
        Set(ByVal Value As String)
            _valeurAuxiliaire = Value
        End Set
    End Property
    Public Property ChecksumMD5() As String
        Get
            Return _checksumMD5
        End Get
        Set(ByVal Value As String)
            _checksumMD5 = Value
        End Set
    End Property
    Public Property ChecksumCalc() As String
        Get
            Return _checksumCalc
        End Get
        Set(ByVal Value As String)
            _checksumCalc = Value
        End Set
    End Property
    Public Property Update() As Boolean
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

    Public Overridable Function Fill(ByVal PNAme As String, ByVal pValue As String) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case PNAme.ToUpper.Trim()
                Case "type".ToUpper.Trim()
                    If Type = "" Then
                        Type = Trim(pValue)
                    End If
                Case "identifiantEntier".ToUpper.Trim()
                    If Not String.IsNullOrEmpty(pValue) Then
                        IdentifiantEntier = CInt(Trim(pValue))
                    End If
                Case "identifiantChaine".ToUpper.Trim()
                    IdentifiantChaine = Trim(pValue)
                Case "valeurAuxiliaire".ToUpper.Trim()
                    ValeurAuxiliaire = Trim(pValue)
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
    Public Sub SetStatus(pString As String)
        _Status = pString
    End Sub
    Public Function GetStatus() As String
        Return _Status
    End Function
    Public Overridable Function SynchroDesc(pAgent As Agent) As Boolean
        Dim pElement As SynchronisationElmt
        Dim bReturn As Boolean
        pElement = Me
        Select Case pElement.Type.ToUpper().Trim()

            Case "GetPrestationCategorie".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescPrestation) Then

                    Dim tmpObject As New PrestationCategorie
                    Try
                        SetStatus("Réception MAJ Catégorie de prestation n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = PrestationCategorieManager.getWSPrestationCategorieById(pAgent, CType(pElement.IdentifiantChaine, Integer))
                        If tmpObject.libelle <> "" Then
                            PrestationCategorieManager.save(tmpObject, pAgent, True)
                        End If
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
                        ' Récup id's
                        Dim tmpSplit() As String = pElement.IdentifiantChaine.Split("-")
                        Dim idObject As Integer = CType(tmpSplit(0), Integer)
                        Dim idCategorie As Integer = CType(tmpSplit(1), Integer)
                        SetStatus("Réception MAJ Tarif de prestation n°" & idObject & "...")
                        tmpObject = PrestationTarifManager.getWSPrestationTarifById(idObject, idCategorie, pAgent)
                        If tmpObject.description <> "" Then
                            PrestationTarifManager.save(tmpObject, pAgent, True)
                        End If
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetPrestationTarif) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If

                'Case "GetReferentielBuse".ToUpper().Trim()
                '    If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
                '        SynchronisationManager.LogSynchroElmt(pElement)
                '        Try
                '            Statusbar_display("Réception MAJ référentiel de buses...")
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
                        SetStatus("Réception MAJ référentiel des marques de mmanomètre...")
                        ReferentielManometreManager.getWSReferentielManometre(_Agent)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetReferentielManometre) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            'Case "GetReferentielPulverisateur".ToUpper().Trim()
            '    If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
            '        Try
            '            setStatus("Réception MAJ référentiel des marques de pulvérisateur...")
            '            ReferentielPulverisateurManager.getWSReferentielPulverisateur()
            '            bReturn = True
            '        Catch ex As Exception
            '            CSDebug.dispFatal("Synchronisation::runDescSynchro(GetReferentielPulverisateur) : " & ex.Message.ToString)
            '            bReturn = False
            '        End Try
            '    End If
            Case "GetReferentielPulverisateurMarquesModeles".ToUpper().Trim()
                If (m_SynchroBoolean.m_bSynchDescReferentiel) Then
                    Try
                        SetStatus("Réception MAJ référentiel des marques et des modèles de pulvérisateur...")
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
                        SetStatus("Réception MAJ référentiel des types et des catgories de pulvérisateur...")
                        ReferentielPulverisateurManager.getWSReferentielPulverisateurTypesCategories()
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(getWSReferentielPulverisateurTypesCategories) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            'Case "GetReferentielTerritoire".ToUpper().Trim()
            '    If (m_SynchroBoolean.m_bSynchDescReferentiel) Then

            '        Try
            '            setStatus("Réception MAJ référentiel des territoires...")
            '            ReferentielTerritoireManager.getWSReferentielTerritoire()
            '            bReturn = True
            '        Catch ex As Exception
            '            CSDebug.dispFatal("Synchronisation::runDescSynchro(GetReferentielTerritoire) : " & ex.Message.ToString)
            '            bReturn = False
            '        End Try
            '    End If

            Case "GetVersionLogicielAgent".ToUpper().Trim()
                'If CSEnvironnement.checkVersion = False Then
                '    MsgBox(CSEnvironnement.versionMessage & vbNewLine & CSEnvironnement.versionUrl)
                '    globFormParent.Close()
                '    Return False
                'End If

                'Case "GetExploitation".ToUpper().Trim() ' Synchro d'un client
                '    If (m_SynchroBoolean.m_bSynchDescExploitation) Then
                '        Try
                '            SetStatus("Réception MAJ Exploitation n°" & pElement.IdentifiantChaine & "...")
                '            pElement.SynchroDesc(pAgent)
                '            tmpObject = ExploitationManager.getWSExploitationById(pElement.IdentifiantChaine)
                '            ExploitationManager.save(tmpObject, pAgent, True)
                '            bReturn = True
                '        Catch ex As Exception
                '            CSDebug.dispFatal("Synchronisation::runDescSynchro(GetExploitation) : " & ex.Message.ToString)
                '            bReturn = False
                '        End Try
                '    End If

                'Case "GetPulverisateur".ToUpper().Trim() ' Synchro d'un Pulverisateur
                '    If (m_SynchroBoolean.m_bSynchDescPulve) Then
                '        Dim tmpObject As New Pulverisateur
                '        Try
                '            SetStatus("Réception MAJ Pulvérisateur n°" & pElement.IdentifiantChaine & "...")
                '            tmpObject = PulverisateurManager.getWSPulverisateurById(pAgent, pElement.IdentifiantChaine)
                '            If tmpObject IsNot Nothing Then
                '                PulverisateurManager.save(tmpObject, "0", pAgent, True)
                '            End If
                '            bReturn = True
                '        Catch ex As Exception
                '            CSDebug.dispFatal("Synchronisation::runDescSynchro(GetPulverisateur) : " & ex.Message.ToString)
                '            bReturn = False
                '        End Try
                '    End If
                ''Case "GetExploitationTOPulverisateur".ToUpper().Trim() ' Synchro d'un Partage de pulvé (ExploitationTOPulverisateur)
                'If (m_SynchroBoolean.m_bSynchDescPulve) Then
                '    Dim tmpObject As New ExploitationTOPulverisateur
                '    Try
                '        SetStatus("Réception MAJ Partages pulvés...")
                '        tmpObject = ExploitationTOPulverisateurManager.getWSExploitationTOPulverisateurById(pElement.IdentifiantChaine)
                '        ExploitationTOPulverisateurManager.save(tmpObject, pAgent, True)
                '        bReturn = True
                '    Catch ex As Exception
                '        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetExploitationTOPulverisateur) : " & ex.Message.ToString)
                '        bReturn = False
                '    End Try
                'End If

            Case "GetAgent".ToUpper().Trim() ' Synchro d'un agent
                If (m_SynchroBoolean.m_bSynchDescAgent) Then
                    Dim tmpObject As New Agent
                    Try
                        SetStatus("Réception MAJ Agent n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = AgentManager.WSgetByNumeroNational(pElement.IdentifiantChaine)
                        If tmpObject.id <> 0 Then
                            pAgent = tmpObject
                            CSDebug.dispInfo("Synchronisation::runDescSynchro(GetAgent) Mot de passe = " & tmpObject.motDePasse)
                            AgentManager.save(tmpObject, True)
                            _Agent = pAgent
                        End If
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetAgent) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetBuse".ToUpper().Trim() ' Synchro d'une buse étalon
                If (m_SynchroBoolean.m_bSynchDescBuse) Then
                    Dim oBuseE As Buse
                    Try
                        SetStatus("Réception MAJ Buse n°" & pElement.IdentifiantChaine & "...")
                        oBuseE = BuseManager.WSgetById(pElement.IdentifiantEntier, pElement.IdentifiantChaine)
                        Dim bOld As Boolean = oBuseE.etat
                        'Modif du 6/12/2018
                        'Recalcul de l'état des buses après synhcro
                        If oBuseE.getAlerte() = GlobalsCRODIP.ALERTE.NOIRE Then
                            oBuseE.Desactiver()
                            Dim objReturn As Buse
                            BuseManager.WSSend(oBuseE, objReturn)
                            oBuseE = objReturn
                        Else
                            oBuseE.etat = True
                        End If

                        If My.Settings.GestiondesPools Then
                            BuseManager.getLstPoolById(oBuseE)
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
                        SetStatus("Réception MAJ Manomètre de Controle n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = ManometreControleManager.WSgetById(pElement.IdentifiantEntier, pElement.IdentifiantChaine)
                        If My.Settings.GestiondesPools Then
                            ManometreControleManager.getLstPoolById(tmpObject)
                        End If
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
                '        setStatus("Réception MAJ Controle Banc n°" & pElement.identifiantChaine & "...")
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
                '        setStatus("Réception MAJ Controle Banc n°" & pElement.identifiantChaine & "...")
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
                        SetStatus("Réception MAJ Fiche de vie Manomètre de Controle n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = FVManometreControleManager.WSgetById(pElement.IdentifiantEntier, pElement.IdentifiantChaine)
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
                        SetStatus("Réception MAJ Manomètre Etalon n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = ManometreEtalonManager.WSgetById(pElement.IdentifiantEntier, pElement.IdentifiantChaine)
                        If My.Settings.GestiondesPools Then
                            ManometreEtalonManager.getLstPoolById(tmpObject)
                        End If
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
                        SetStatus("Réception MAJ Fiche de vie Manomètre Etalon n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = FVManometreEtalonManager.WSgetById(pElement.IdentifiantEntier, pElement.IdentifiantChaine)
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
                        SetStatus("Réception MAJ Banc n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = BancManager.WSgetById(pElement.IdentifiantEntier, pElement.IdentifiantChaine)
                        If My.Settings.GestiondesPools Then
                            BancManager.getLstPoolById(tmpObject)
                        End If

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
                        SetStatus("Réception MAJ Fiche de vie Banc n°" & pElement.IdentifiantChaine & "...")
                        tmpObject = FVBancManager.WSgetById(pElement.IdentifiantChaine, "")
                        If Not tmpObject Is Nothing Then
                            FVBancManager.save(tmpObject, True)
                        Else
                            CSDebug.dispFatal("Synchronisation::runDescSynchro(GetFVBanc) : [" & pElement.IdentifiantChaine & "]" & "Banc introuvable sur le server")

                        End If
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispError("Synchronisation::runDescSynchro(GetFVBanc) : [" & pElement.IdentifiantChaine & "]" & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetStructure".ToUpper().Trim() ' Synchro d'une structure
                If (m_SynchroBoolean.m_bSynchDescAgent) Then
                    Dim tmpObject As New [Structure]
                    Try
                        SetStatus("Réception MAJ Organisme n°" & pElement.IdentifiantEntier & "...")
                        tmpObject = StructureManager.WSgetById(pElement.IdentifiantEntier, "")
                        StructureManager.save(tmpObject, True)
                        bReturn = True
                    Catch ex As Exception
                        CSDebug.dispFatal("Synchronisation::runDescSynchro(GetStructure) : " & ex.Message.ToString)
                        bReturn = False
                    End Try
                End If
            Case "GetDocument".ToUpper().Trim() ' Récupération d'un fichier pour stockage dans le ModuleDocumentaire
                'Fait dans la classe SynchronisationElmtDocument
            Case "GetIdentifiantPulverisateur".ToUpper().Trim() ' Synchro d'un Identifint De Pulvérisateur
                'Fait dans la classe SynchronisationElmtIdentifiantPulverisateur
        End Select
        Return bReturn

    End Function

    ''' <summary>
    ''' Fabrique des elements de Synchronisation
    ''' </summary>
    ''' <param name="pType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function CreateSynchronisationElmt(pType As String, pSynchroBooleans As SynchroBooleans) As SynchronisationElmt
        Dim oReturn As SynchronisationElmt
        Select Case pType.ToUpper().Trim()
            Case SynchronisationElmtDocument.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDocument(pSynchroBooleans)
            Case SynchronisationElmtIdentifiantPulverisateur.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtIdentifiantPulverisateur(pSynchroBooleans)
            Case SynchronisationElmtDiag.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtDiag(pSynchroBooleans)
            Case SynchronisationElmtDiagItem.getLabelGet.ToUpper().Trim()
                oReturn = Nothing
            Case SynchronisationElmtDiagBuses.getLabelGet.ToUpper().Trim()
                oReturn = Nothing
            Case SynchronisationElmtDiagBusesDetail.getLabelGet.ToUpper().Trim()
                oReturn = Nothing
            Case SynchronisationElmtDiagMano542.getLabelGet.ToUpper().Trim()
                oReturn = Nothing
            Case SynchronisationElmtDiagMano833.getLabelGet.ToUpper().Trim()
                oReturn = Nothing
            Case SynchronisationGetVersionLogicielAgent.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationGetVersionLogicielAgent(pSynchroBooleans)
            Case SynchronisationGetSynchroDateTime.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationGetSynchroDateTime(pSynchroBooleans)

            Case SynchronisationElmtExploitation.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtExploitation(pSynchroBooleans)
            Case SynchronisationElmtExploitationToPulverisateur.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtExploitationToPulverisateur(pSynchroBooleans)
            Case SynchronisationElmtPulverisateur.getLabelGet.ToUpper().Trim()
                oReturn = New SynchronisationElmtPulverisateur(pSynchroBooleans)

            Case Else
                oReturn = New SynchronisationElmt(pType, pSynchroBooleans)

        End Select
        Return oReturn

    End Function

End Class
