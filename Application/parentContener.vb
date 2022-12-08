Public Class parentContener
    Inherits Form
    Implements IObservateur


    '
    Private m_col As New Collection()
    Private m_nStep As Integer = 0
    Private m_bCloseByUpdate As Boolean = False

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        '        Me.UseWaitCursor = True
        '       loadSplash()

    End Sub


    Private Sub parentContener_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Cursor = Cursors.WaitCursor

        loadSplash()
        GlobalsCRODIP.Init()

        ExecuteCMD()

        If Not GlobalsCRODIP.GLOB_ENV_DEBUG Then
            mnuFenetre.Visible = False
        End If

        StructureManager.getList().ForEach(Sub(S)

                                               S.CreatePool()
                                           End Sub)


        If TestCrystalReport() Then
            globFormParent = Me
            Me.UseWaitCursor = False
            Load_CRODIPINDIGO()
        Else
            MsgBox("Erreur en Génération de PDF, Vérifier votre version de Crystal Report")
            Application.Exit()
        End If
    End Sub
    Protected Overridable Sub Load_CRODIPINDIGO()

        Application.CurrentCulture = New System.Globalization.CultureInfo("fr-FR")
        CSEnvironnement.createFolders()
        CSEnvironnement.Renamefiles()
        'Vérification de la version de la base de données
        If Not DBVersionManagerManager.checkVersion(My.Settings.DBVersionExpected) Then
            MsgBox("Votre base de données n'est pas à jour, contactez le CRODIP pour effectuer la mise à jour.", MsgBoxStyle.OkOnly, "ERREUR SUR BASE DE DONNEES")
            m_bCloseByUpdate = True
            Me.Close()
        End If
        CSDebug.dispInfo("ParentContainer.unloadSplash")
        unloadSplash()

        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Me.Text = ""
        Else
            ' Mises a jour
            If CSSoftwareUpdate.checkMAJ Then
                If CSSoftwareUpdate.MyUpdateInfo IsNot Nothing Then
                    Dim ofrm As New frmMAJVersion()
                    ofrm.Setcontexte(CSSoftwareUpdate.MyUpdateInfo)
                    ofrm.ShowDialog()
                Else
                    MsgBox("Une mise à jour est disponible.", MsgBoxStyle.OkOnly, "Mise à jour disponible !")
                End If
                CSSoftwareUpdate.runUpdater(False)
                m_bCloseByUpdate = True
                CSEnvironnement.delPid()
                Close()
                Exit Sub
            End If
            ' Initialisation du boot
            CSDebug.dispInfo("ParentContainer.CheckVersion")
        End If
        Try
            CSBoot.init()
            Statusbar.display("Démarrage en cours...", True)
        Catch ex As Exception
            CSDebug.dispError("parentContener::CSBoot.init()" & ex.Message)
        End Try

        CSDebug.dispInfo("ParentContainer.LoadLogin")

        ' Chargement du formulaire de login
        Try
            Dim loginMDIChild As New login
            loginMDIChild.Text = "Connexion"
            Statusbar.clear()
            DisplayForm(loginMDIChild)
        Catch ex As Exception
            CSDebug.dispError("parentContener::load" & ex.Message)
        End Try

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub parentContener_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not m_bCloseByUpdate Then
            Dim Title As String = "Logiciel Crodip/Agent"

            Dim Var As MsgBoxResult = MsgBox("Etes-vous sûr de vouloir fermer le logiciel ?", vbInformation + vbYesNo, Title)
            If Var = vbNo Then
                e.Cancel = True
            Else
                CSEnvironnement.delPid()
            End If
        Else
            CSEnvironnement.delPid()
        End If
    End Sub

#Region " Menu "

    Private Sub MenuItem_aide_apropos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem_aide_apropos.Click
        Dim formApropos As New apropos
        formApropos.ShowDialog()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        ' On ferme toutes les fenetres ouvertes
        Dim form As Form
        For Each form In Me.MdiChildren
            form.Close()
        Next

        ' On affiche l'écran de connexion
        Dim loginMDIChild As New login
        loginMDIChild.Text = "Connexion"

        DisplayForm(loginMDIChild)
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Me.Close()
    End Sub

    ' Vérification des mises à jour
    Private Sub mnuCheckupdates_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheckupdates.Click
        If CSSoftwareUpdate.checkMAJ Then
            Dim doMAJ As MsgBoxResult = MsgBox("Une mise à jour est disponible. Souhaitez-vous la récupérer maintenant ?", MsgBoxStyle.YesNo, "Mise à jour disponible !")
            If doMAJ = MsgBoxResult.Yes Then
                CSSoftwareUpdate.runUpdater(False)
            End If
        Else
            MsgBox("Aucune mise à jour n'est disponible.")
        End If
    End Sub

#End Region

#Region " Events "

    Private Sub notify_connexionStatus_nok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles notify_connexionStatus_nok.Click
        ' On ferme toutes les fenetres ouvertes
        Dim form As Form
        For Each form In Me.MdiChildren
            form.Close()
        Next
    End Sub

#End Region

    Private Sub MenuItem_aide_debug_exportLogs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem_aide_debug_exportLogs.Click

        If System.IO.File.Exists(GlobalsCRODIP.GLOB_ENV_DEBUGLOGFILE) Then
            CSFile.open(GlobalsCRODIP.GLOB_ENV_DEBUGLOGFILE)
        Else
            MsgBox("Aucun log d'erreur n'a été enregistré pour le moment.")
        End If

    End Sub


    Public Sub ReturnToAccueil()
        Dim ofrm As Form
        Dim ofrmAccueil As accueil
        For Each ofrm In MdiChildren
            If Not TypeOf ofrm Is accueil Then
                ofrm.Close()
            Else
                ofrmAccueil = ofrm
                '                ofrmAccueil.LoadListeExploitation()
                '                ofrmAccueil.loadListPulveExploitation(False)
                ofrmAccueil.WindowState = FormWindowState.Maximized
            End If
        Next
    End Sub

    Public Sub DisplayForm(oFrm As Form)

        oFrm.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable
        oFrm.ControlBox = False
        oFrm.MaximizeBox = False
        oFrm.MinimizeBox = False

        If GlobalsCRODIP.GLOB_ENV_MODEFORMATION Then
            Me.Icon = Nothing
            Me.ShowIcon = False
            oFrm.Icon = Nothing
            oFrm.ShowIcon = False
        Else
            oFrm.Icon = Crodip_agent.Resources.Transparent
            oFrm.ShowIcon = Not GlobalsCRODIP.GLOB_ENV_MODEFORMATION

        End If
        oFrm.ShowInTaskbar = True
        oFrm.WindowState = FormWindowState.Maximized
        oFrm.MdiParent = Me
        oFrm.Show()
    End Sub

    Public Sub Notice(pMsg As String) Implements IObservateur.Notice
        parentContener_statusBar.Text = "        " & pMsg
        parentContener_statusBar.Refresh()
    End Sub

    Private Sub MenuItem_aide_debug_exportSynchro_Click(sender As Object, e As EventArgs) Handles MenuItem_aide_debug_exportSynchro.Click
        If System.IO.File.Exists(GlobalsCRODIP.GLOB_ENV_SYNCHROLOGFILE) Then
            CSFile.open(GlobalsCRODIP.GLOB_ENV_SYNCHROLOGFILE)
        Else
            MsgBox("Aucun trace de Synchronisationn'a été enregistrée pour le moment.")
        End If

    End Sub

    Private Sub parentContener_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.KeyCode = Keys.Control) Then
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub parentContener_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate

    End Sub

    Private Sub parentContener_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        CSDebug.dispError(e.Control)
    End Sub

    Private Sub mniVaccum_Click(sender As Object, e As EventArgs) Handles mniVaccum.Click
        If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
            Me.Cursor = Cursors.WaitCursor
            CSDb.ExecuteSQL("VACUUM")
            Me.Cursor = Cursors.Default
        End If
    End Sub


    Public oEtatFDiag As EtatFDiag
    Public Sub Action(pAction As ActionFDiag)
        If oEtatFDiag.frmDiag IsNot Nothing Then
            oEtatFDiag.frmDiag.Hide()
            If oEtatFDiag.ShowDialog Then
                oEtatFDiag.frmDiag.Close()
            End If
        End If
        oEtatFDiag = oEtatFDiag.Action(pAction)
        DisplayFormDiag()
    End Sub

    Public Sub DisplayFormDiag()
        If oEtatFDiag Is Nothing Then
            CloseDiagnostic()
        Else
            If oEtatFDiag.ShowDialog Then
                oEtatFDiag.frmDiag.ShowDialog(Me)
            Else
                DisplayForm(oEtatFDiag.frmDiag)
            End If
        End If
    End Sub
    Private Sub CloseDiagnostic()
        ' On vide les infos de session
        diagnosticCourant = Nothing
        'Fermeture de fenêtres Filles de diag
        Dim ofrm As Form
        Dim ofrmAccueil As accueil
        For Each ofrm In MdiChildren
            If Not TypeOf ofrm Is accueil Then
                ofrm.Close()
            Else
                ofrmAccueil = ofrm
                ofrmAccueil.loadListPulveExploitation(False)
                ofrmAccueil.WindowState = FormWindowState.Maximized
            End If
        Next

        ' On ferme le contrôle
        Statusbar.clear()

    End Sub


End Class
