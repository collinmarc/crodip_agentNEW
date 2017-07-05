Public Class frmRPparentContener
    Inherits frmCRODIP

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Public WithEvents parentContener_statusBar As System.Windows.Forms.StatusBar
    Friend WithEvents MenuItem_aide_apropos As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents notify_connexionStatus_nok As System.Windows.Forms.NotifyIcon
    Friend WithEvents notify_connexionStatus_ok As System.Windows.Forms.NotifyIcon
    Friend WithEvents notify_connexionStatus_wait As System.Windows.Forms.NotifyIcon
    Friend WithEvents statusBar_img_loader As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItem_aide_debug As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem_aide_debug_exportLogs As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCheckupdates As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents miSuivant As System.Windows.Forms.MenuItem
    Friend WithEvents miPrecedant As System.Windows.Forms.MenuItem
    Friend WithEvents tsbDemarer As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDemarrer As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSuivant As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPrecedant As System.Windows.Forms.ToolStripButton
    Friend WithEvents miDemarer As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents miExploitant As System.Windows.Forms.MenuItem
    Friend WithEvents miPulve As System.Windows.Forms.MenuItem
    Friend WithEvents mivitesse As System.Windows.Forms.MenuItem
    Friend WithEvents miDebit As System.Windows.Forms.MenuItem
    Friend WithEvents miDiag As System.Windows.Forms.MenuItem
    Friend WithEvents miRecap As System.Windows.Forms.MenuItem
    Friend WithEvents miCalcul As System.Windows.Forms.MenuItem
    Friend WithEvents miRapport As System.Windows.Forms.MenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbExploitant As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPulvérisateur As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbVitesse As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDebit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDiag As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbrecap As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCalcul As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRapport As System.Windows.Forms.ToolStripButton
    Friend WithEvents miVitesseFonctionnement As System.Windows.Forms.MenuItem
    Friend WithEvents tsbQuitter As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRPparentContener))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuCheckupdates = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem_aide_apropos = New System.Windows.Forms.MenuItem()
        Me.MenuItem_aide_debug = New System.Windows.Forms.MenuItem()
        Me.MenuItem_aide_debug_exportLogs = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.miDemarer = New System.Windows.Forms.MenuItem()
        Me.miSuivant = New System.Windows.Forms.MenuItem()
        Me.miPrecedant = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.miExploitant = New System.Windows.Forms.MenuItem()
        Me.miPulve = New System.Windows.Forms.MenuItem()
        Me.mivitesse = New System.Windows.Forms.MenuItem()
        Me.miVitesseFonctionnement = New System.Windows.Forms.MenuItem()
        Me.miDebit = New System.Windows.Forms.MenuItem()
        Me.miDiag = New System.Windows.Forms.MenuItem()
        Me.miRecap = New System.Windows.Forms.MenuItem()
        Me.miCalcul = New System.Windows.Forms.MenuItem()
        Me.miRapport = New System.Windows.Forms.MenuItem()
        Me.notify_connexionStatus_nok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_ok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_wait = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tsbDemarer = New System.Windows.Forms.ToolStrip()
        Me.tsbQuitter = New System.Windows.Forms.ToolStripButton()
        Me.tsbDemarrer = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrecedant = New System.Windows.Forms.ToolStripButton()
        Me.tsbSuivant = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExploitant = New System.Windows.Forms.ToolStripButton()
        Me.tsbPulvérisateur = New System.Windows.Forms.ToolStripButton()
        Me.tsbVitesse = New System.Windows.Forms.ToolStripButton()
        Me.tsbDebit = New System.Windows.Forms.ToolStripButton()
        Me.tsbDiag = New System.Windows.Forms.ToolStripButton()
        Me.tsbrecap = New System.Windows.Forms.ToolStripButton()
        Me.tsbCalcul = New System.Windows.Forms.ToolStripButton()
        Me.tsbRapport = New System.Windows.Forms.ToolStripButton()
        Me.statusBar_img_loader = New System.Windows.Forms.PictureBox()
        Me.parentContener_statusBar = New System.Windows.Forms.StatusBar()
        Me.tsbDemarer.SuspendLayout()
        CType(Me.statusBar_img_loader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem5})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem4, Me.MenuItem3, Me.mnuCheckupdates, Me.MenuItem7, Me.MenuItem_aide_apropos, Me.MenuItem_aide_debug})
        Me.MenuItem1.Text = "?"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Déconnexion"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 1
        Me.MenuItem4.Text = "Quitter"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "-"
        '
        'mnuCheckupdates
        '
        Me.mnuCheckupdates.Index = 3
        Me.mnuCheckupdates.Text = "Vérifier les mises à jour"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 4
        Me.MenuItem7.Text = "-"
        '
        'MenuItem_aide_apropos
        '
        Me.MenuItem_aide_apropos.Index = 5
        Me.MenuItem_aide_apropos.Text = "A Propos ?"
        '
        'MenuItem_aide_debug
        '
        Me.MenuItem_aide_debug.Index = 6
        Me.MenuItem_aide_debug.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_aide_debug_exportLogs})
        Me.MenuItem_aide_debug.Text = "Debug"
        '
        'MenuItem_aide_debug_exportLogs
        '
        Me.MenuItem_aide_debug_exportLogs.Index = 0
        Me.MenuItem_aide_debug_exportLogs.Text = "Extraire le fichier de logs"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miDemarer, Me.miSuivant, Me.miPrecedant, Me.MenuItem8, Me.miExploitant, Me.miPulve, Me.mivitesse, Me.miVitesseFonctionnement, Me.miDebit, Me.miDiag, Me.miRecap, Me.miCalcul, Me.miRapport})
        Me.MenuItem5.Text = "ReglagePulvérisateur"
        '
        'miDemarer
        '
        Me.miDemarer.Index = 0
        Me.miDemarer.Text = "Démarrer"
        '
        'miSuivant
        '
        Me.miSuivant.Index = 1
        Me.miSuivant.Text = "Suivant"
        '
        'miPrecedant
        '
        Me.miPrecedant.Index = 2
        Me.miPrecedant.Text = "Précédent"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 3
        Me.MenuItem8.Text = "-"
        '
        'miExploitant
        '
        Me.miExploitant.Index = 4
        Me.miExploitant.Text = "Exploitant"
        '
        'miPulve
        '
        Me.miPulve.Index = 5
        Me.miPulve.Text = "Pulvérisateur"
        '
        'mivitesse
        '
        Me.mivitesse.Index = 6
        Me.mivitesse.Text = "Vitesse"
        '
        'miVitesseFonctionnement
        '
        Me.miVitesseFonctionnement.Index = 7
        Me.miVitesseFonctionnement.Text = "Vitesse Fonctionnement"
        '
        'miDebit
        '
        Me.miDebit.Index = 8
        Me.miDebit.Text = "Débit"
        '
        'miDiag
        '
        Me.miDiag.Index = 9
        Me.miDiag.Text = "Mano/Buses"
        '
        'miRecap
        '
        Me.miRecap.Index = 10
        Me.miRecap.Text = "Défauts"
        '
        'miCalcul
        '
        Me.miCalcul.Index = 11
        Me.miCalcul.Text = "Calcul V/ha"
        '
        'miRapport
        '
        Me.miRapport.Index = 12
        Me.miRapport.Text = "Rapport"
        '
        'notify_connexionStatus_nok
        '
        Me.notify_connexionStatus_nok.Icon = CType(resources.GetObject("notify_connexionStatus_nok.Icon"), System.Drawing.Icon)
        Me.notify_connexionStatus_nok.Text = "Logiciel Agent Crodip: Hors Ligne !"
        Me.notify_connexionStatus_nok.Visible = True
        '
        'notify_connexionStatus_ok
        '
        Me.notify_connexionStatus_ok.Icon = CType(resources.GetObject("notify_connexionStatus_ok.Icon"), System.Drawing.Icon)
        Me.notify_connexionStatus_ok.Text = "Logiciel Agent Crodip: En Ligne !"
        '
        'notify_connexionStatus_wait
        '
        Me.notify_connexionStatus_wait.Icon = CType(resources.GetObject("notify_connexionStatus_wait.Icon"), System.Drawing.Icon)
        Me.notify_connexionStatus_wait.Text = "Logiciel Agent Crodip: En Ligne !"
        '
        'tsbDemarer
        '
        Me.tsbDemarer.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsbDemarer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbQuitter, Me.tsbDemarrer, Me.tsbPrecedant, Me.tsbSuivant, Me.ToolStripSeparator1, Me.tsbExploitant, Me.tsbPulvérisateur, Me.tsbVitesse, Me.tsbDebit, Me.tsbDiag, Me.tsbrecap, Me.tsbCalcul, Me.tsbRapport})
        Me.tsbDemarer.Location = New System.Drawing.Point(0, 0)
        Me.tsbDemarer.Name = "tsbDemarer"
        Me.tsbDemarer.Size = New System.Drawing.Size(1012, 39)
        Me.tsbDemarer.Stretch = True
        Me.tsbDemarer.TabIndex = 15
        Me.tsbDemarer.Text = "ToolStrip1"
        '
        'tsbQuitter
        '
        Me.tsbQuitter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbQuitter.Image = Global.Crodip_agent.Resources.ClosePreviewHH
        Me.tsbQuitter.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbQuitter.Name = "tsbQuitter"
        Me.tsbQuitter.Size = New System.Drawing.Size(36, 36)
        Me.tsbQuitter.Text = "Quitter"
        '
        'tsbDemarrer
        '
        Me.tsbDemarrer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDemarrer.Image = Global.Crodip_agent.Resources.AddTableHH
        Me.tsbDemarrer.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsbDemarrer.Name = "tsbDemarrer"
        Me.tsbDemarrer.Size = New System.Drawing.Size(36, 36)
        Me.tsbDemarrer.Text = "Démarrer "
        '
        'tsbPrecedant
        '
        Me.tsbPrecedant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrecedant.Image = CType(resources.GetObject("tsbPrecedant.Image"), System.Drawing.Image)
        Me.tsbPrecedant.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbPrecedant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrecedant.Name = "tsbPrecedant"
        Me.tsbPrecedant.Size = New System.Drawing.Size(23, 36)
        Me.tsbPrecedant.Text = "Précédant"
        '
        'tsbSuivant
        '
        Me.tsbSuivant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSuivant.Image = CType(resources.GetObject("tsbSuivant.Image"), System.Drawing.Image)
        Me.tsbSuivant.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.tsbSuivant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSuivant.Name = "tsbSuivant"
        Me.tsbSuivant.Size = New System.Drawing.Size(23, 36)
        Me.tsbSuivant.Text = "Suivant"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'tsbExploitant
        '
        Me.tsbExploitant.CheckOnClick = True
        Me.tsbExploitant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbExploitant.Image = CType(resources.GetObject("tsbExploitant.Image"), System.Drawing.Image)
        Me.tsbExploitant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbExploitant.Name = "tsbExploitant"
        Me.tsbExploitant.Size = New System.Drawing.Size(63, 36)
        Me.tsbExploitant.Text = "Exploitant"
        '
        'tsbPulvérisateur
        '
        Me.tsbPulvérisateur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbPulvérisateur.Image = CType(resources.GetObject("tsbPulvérisateur.Image"), System.Drawing.Image)
        Me.tsbPulvérisateur.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPulvérisateur.Name = "tsbPulvérisateur"
        Me.tsbPulvérisateur.Size = New System.Drawing.Size(79, 36)
        Me.tsbPulvérisateur.Text = "Pulvérisateur"
        '
        'tsbVitesse
        '
        Me.tsbVitesse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbVitesse.Image = CType(resources.GetObject("tsbVitesse.Image"), System.Drawing.Image)
        Me.tsbVitesse.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbVitesse.Name = "tsbVitesse"
        Me.tsbVitesse.Size = New System.Drawing.Size(47, 36)
        Me.tsbVitesse.Text = "Vitesse"
        '
        'tsbDebit
        '
        Me.tsbDebit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDebit.Image = CType(resources.GetObject("tsbDebit.Image"), System.Drawing.Image)
        Me.tsbDebit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDebit.Name = "tsbDebit"
        Me.tsbDebit.Size = New System.Drawing.Size(39, 36)
        Me.tsbDebit.Text = "Débit"
        '
        'tsbDiag
        '
        Me.tsbDiag.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbDiag.Image = CType(resources.GetObject("tsbDiag.Image"), System.Drawing.Image)
        Me.tsbDiag.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDiag.Name = "tsbDiag"
        Me.tsbDiag.Size = New System.Drawing.Size(77, 36)
        Me.tsbDiag.Text = "Mano/Buses"
        '
        'tsbrecap
        '
        Me.tsbrecap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbrecap.Image = CType(resources.GetObject("tsbrecap.Image"), System.Drawing.Image)
        Me.tsbrecap.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbrecap.Name = "tsbrecap"
        Me.tsbrecap.Size = New System.Drawing.Size(51, 36)
        Me.tsbrecap.Text = "Défauts"
        '
        'tsbCalcul
        '
        Me.tsbCalcul.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbCalcul.Image = CType(resources.GetObject("tsbCalcul.Image"), System.Drawing.Image)
        Me.tsbCalcul.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCalcul.Name = "tsbCalcul"
        Me.tsbCalcul.Size = New System.Drawing.Size(72, 36)
        Me.tsbCalcul.Text = "Calcul V/ha"
        '
        'tsbRapport
        '
        Me.tsbRapport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbRapport.Image = CType(resources.GetObject("tsbRapport.Image"), System.Drawing.Image)
        Me.tsbRapport.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRapport.Name = "tsbRapport"
        Me.tsbRapport.Size = New System.Drawing.Size(53, 36)
        Me.tsbRapport.Text = "Rapport"
        '
        'statusBar_img_loader
        '
        Me.statusBar_img_loader.Image = CType(resources.GetObject("statusBar_img_loader.Image"), System.Drawing.Image)
        Me.statusBar_img_loader.Location = New System.Drawing.Point(6, 688)
        Me.statusBar_img_loader.Name = "statusBar_img_loader"
        Me.statusBar_img_loader.Size = New System.Drawing.Size(16, 16)
        Me.statusBar_img_loader.TabIndex = 13
        Me.statusBar_img_loader.TabStop = False
        Me.statusBar_img_loader.Visible = False
        '
        'parentContener_statusBar
        '
        Me.parentContener_statusBar.Location = New System.Drawing.Point(0, 642)
        Me.parentContener_statusBar.Name = "parentContener_statusBar"
        Me.parentContener_statusBar.Size = New System.Drawing.Size(1012, 22)
        Me.parentContener_statusBar.TabIndex = 1
        '
        'frmRPparentContener
        '
        Me.ClientSize = New System.Drawing.Size(1012, 664)
        Me.Controls.Add(Me.tsbDemarer)
        Me.Controls.Add(Me.statusBar_img_loader)
        Me.Controls.Add(Me.parentContener_statusBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmRPparentContener"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip"
        Me.tsbDemarer.ResumeLayout(False)
        Me.tsbDemarer.PerformLayout()
        CType(Me.statusBar_img_loader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    '
    Private m_nStep As Integer = 0
    Private m_RPDiagnostic As RPDiagnostic
    Private m_RPParam As RPParam

    'Création des fenêtres Filles
    Private oFRM As frmRPFicheExlpoitant
    Private oFRMPulve As frmRPFichePulve
    Private odlgHelp551 As frmRPDlgHelp551
    Private odlgHelp552 As frmRPDlgHelp552
    Private ofrmdiag As frmRPDiagnostique
    Private ofrmRecap As frmRPRecap
    Private ofrmCalculs As frmRPCalculVolumeHa
    Private ofrmRapport As frmRPRapport

    Private m_nOldStep As Integer
  
    Private Sub parentContener_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        formLoad()
    End Sub
    Private Sub formLoad()

        '        Me.AutoScroll = True
        miDemarer.Enabled = True
        tsbDemarer.Enabled = True

        enableSuivant(False)
        enablePrecedant(False)
        enableExploitant(False)
        enablePulve(False)
        enableVitesse(False)
        enableDebit(False)
        enableDiag(False)
        enableRecap(False)
        enableCalcul(False)
        enableRapport(False)

        m_nOldStep = -1
        m_nStep = -1
    End Sub


#Region " Menu "

    Private Sub MenuItem_aide_apropos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem_aide_apropos.Click
        Dim formApropos As New apropos
        formApropos.MdiParent = Me
        formApropos.Show()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click

        ' On ferme toutes les fenetres ouvertes
        Dim form As Form
        For Each form In Me.MdiChildren
            form.Close()
        Next

        ' On affiche l'écran de connexion
        Dim loginMDIChild As New login
        loginMDIChild.MdiParent = Me
        loginMDIChild.Show()
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



    Public Function Suivant() As Boolean
        Dim bReturn As Boolean
        Try
            Dim ofrm As IfrmCRODIP
            ofrm = ActiveMdiChild
            If ofrm IsNot Nothing Then
                If ValiderFRM(ofrm) Then
                    m_nStep = m_nStep + 1
                    AfficherFenetre()
                End If
            Else
                AfficherFenetre()
            End If
        Catch ex As Exception
            CSDebug.dispError("DoReglage ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub AfficherFenetre()
        Try
            MdiChildren(m_nStep).Activate()
            MdiChildren(m_nStep).WindowState = FormWindowState.Maximized
            MdiChildren(m_nStep).AutoScroll = True
            MdiChildren(m_nStep).Show()

            'Rafraichissement de la Liste des boutons
            enablePrecedant(True)
            enableSuivant(True)
            If m_nStep = 0 Then
                enablePrecedant(False)
            End If

            If m_nStep = MdiChildren.Length - 1 Then
                enableSuivant(False)
            End If


            'Tableau des boutons dans l'ordre
            Dim tabtsb As ToolStripButton() = {tsbExploitant, tsbPulvérisateur, tsbVitesse, tsbDebit, tsbDiag, tsbrecap, tsbCalcul, tsbRapport}
            For Each otsb As ToolStripButton In tabtsb
                otsb.ForeColor = SystemColors.ControlText
                otsb.BackColor = SystemColors.Control
            Next
            tabtsb(m_nStep).BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
            tabtsb(m_nStep).ForeColor = System.Drawing.Color.White
        Catch ex As Exception
        End Try


    End Sub

    Public Function doPrecedant() As Boolean
        Dim bReturn As Boolean
        Try
            Dim oDiaglogResult As Windows.Forms.DialogResult
            Dim ofrm As Form
            m_nStep = m_nStep - 1
            AfficherFenetre()
        Catch ex As Exception
            CSDebug.dispError("DoReglage ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Protected Function Demarrer() As Boolean
        Dim bReturn As Boolean
        Try

            Me.Cursor = Windows.Forms.Cursors.WaitCursor
            For Each oForm As Form In MdiChildren
                oForm.Close()
            Next
            m_nStep = 0
            m_RPDiagnostic = New RPDiagnostic()



#If DEBUG Then
            clientCourant.raisonSociale = "RSexploitantTest"
            clientCourant.nomExploitant = "exploitantTest"
            clientCourant.prenomExploitant = "exploitantTest"
            clientCourant.adresse = "adresseTest"
            clientCourant.codePostal = "35250"
            clientCourant.commune = "CHASNE SUR ILLET"
            clientCourant.codeApe = "0112Z"

            pulverisateurCourant.marque = "ACP"
            pulverisateurCourant.modele = "INCONNU"
            pulverisateurCourant.anneeAchat = 1974
            pulverisateurCourant.type = "Cultures basses"
            pulverisateurCourant.categorie = "Rampe"
            pulverisateurCourant.largeur = "1"
            pulverisateurCourant.attelage = "PORTE"
            pulverisateurCourant.pulverisation = "Pneumatique"
            pulverisateurCourant.capacite = "300"
            pulverisateurCourant.regulation = "DPM"
            pulverisateurCourant.buseType = "BUSES A FENTE"
            pulverisateurCourant.buseFonctionnement = "STANDARD"

            'Création des objets de references
            m_RPDiagnostic.SetProprietaire(clientCourant)
            m_RPDiagnostic.setPulverisateur(pulverisateurCourant)
#End If



            'Création des fenêtres Filles
            oFRM = New frmRPFicheExlpoitant()
            oFRM.setContexte(False, clientCourant, m_RPDiagnostic)
            oFRM.WindowState = FormWindowState.Maximized
            oFRM.MdiParent = Me


            oFRMPulve = New frmRPFichePulve()
            oFRMPulve.setContexte(2, New Agent(), pulverisateurCourant, m_RPDiagnostic)
            oFRMPulve.WindowState = FormWindowState.Maximized
            oFRMPulve.MdiParent = Me

            odlgHelp551 = New frmRPDlgHelp551()
            odlgHelp551.Setcontexte(DiagnosticHelp551.Help551Mode.Mode551, m_RPDiagnostic, "Vitesse d'avancement", False)
            odlgHelp551.WindowState = FormWindowState.Maximized
            odlgHelp551.MdiParent = Me


            odlgHelp552 = New frmRPDlgHelp552
            odlgHelp552.Setcontexte(frmRPDlgHelp552.Help552Mode.Mode552, m_RPDiagnostic, 3, 2.5)
            odlgHelp552.Text = "Débits"
            odlgHelp552.WindowState = FormWindowState.Maximized
            odlgHelp552.MdiParent = Me

            CSDebug.dispInfo("Création de frmRPDiagnostique")

            ofrmdiag = New frmRPDiagnostique()
            CSDebug.dispInfo("Fin Création de frmRPDiagnostique")
            ofrmdiag.setContexte(m_RPDiagnostic, DiagMode.CTRL_COMPLET, pulverisateurCourant, clientCourant)
            ofrmdiag.WindowState = FormWindowState.Maximized
            ofrmdiag.MdiParent = Me


            ofrmRecap = New frmRPRecap()
            ofrmRecap.setContexte(m_RPDiagnostic, pulverisateurCourant)
            ofrmRecap.WindowState = FormWindowState.Maximized
            ofrmRecap.MdiParent = Me


            ofrmCalculs = New frmRPCalculVolumeHa()
            ofrmCalculs.setContexte(m_RPDiagnostic)
            ofrmCalculs.WindowState = FormWindowState.Maximized
            ofrmCalculs.MdiParent = Me

            ofrmRapport = New frmRPRapport()
            ofrmRapport.setContexte(m_RPDiagnostic)
            ofrmRapport.WindowState = FormWindowState.Maximized
            ofrmRapport.MdiParent = Me

            enableSuivant(True)
            enablePrecedant(False)

            enableExploitant(True)
            enablePulve(True)
            enableVitesse(True)
            enableDebit(True)
            enableDiag(True)
            enableRecap(True)
            enableCalcul(True)
            enableRapport(True)

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmRParentcontainer.demarrer ERR" & ex.Message)
            bReturn = False
        End Try
        Me.Cursor = Windows.Forms.Cursors.Default
        Return bReturn
    End Function

    Private Sub tsbDemarrer_Click(sender As Object, e As EventArgs) Handles tsbDemarrer.Click
        Demarrer()
        Suivant()
    End Sub

    Private Sub tsbSuivant_Click(sender As Object, e As EventArgs) Handles tsbSuivant.Click
        Suivant()
    End Sub

    Private Sub tsbPrecedant_Click(sender As Object, e As EventArgs) Handles tsbPrecedant.Click
        doPrecedant()
    End Sub

    Private Sub mnuRPSuivant_Click(sender As Object, e As EventArgs) Handles miSuivant.Click
        Suivant()
    End Sub

    Private Sub mnuRPPrec_Click(sender As Object, e As EventArgs) Handles miPrecedant.Click
        doPrecedant()
    End Sub

    Private Sub MenuItem6_Click(sender As Object, e As EventArgs) Handles miDemarer.Click
        Demarrer()
    End Sub

    Private Sub tsbExploitant_Click(sender As Object, e As EventArgs) Handles tsbExploitant.Click
        m_nStep = 0
        AfficherFenetre()
    End Sub

    Private Sub tsbPulvérisateur_Click(sender As Object, e As EventArgs) Handles tsbPulvérisateur.Click
        m_nStep = 1
        AfficherFenetre()
    End Sub

    Private Sub tsbVitesse_Click(sender As Object, e As EventArgs) Handles tsbVitesse.Click
        m_nStep = 2
        AfficherFenetre()

    End Sub

    Private Sub tsbDebit_Click(sender As Object, e As EventArgs) Handles tsbDebit.Click
        m_nStep = 3
        AfficherFenetre()

    End Sub

    Private Sub tsbDiag_Click(sender As Object, e As EventArgs) Handles tsbDiag.Click
        m_nStep = 4
        AfficherFenetre()

    End Sub

    Private Sub tsbrecap_Click(sender As Object, e As EventArgs) Handles tsbrecap.Click
        m_nStep = 5
        AfficherFenetre()

    End Sub

    Private Sub tsbCalcul_Click(sender As Object, e As EventArgs) Handles tsbCalcul.Click
        m_nStep = 6
        AfficherFenetre()

    End Sub

    Private Sub tsbRapport_Click(sender As Object, e As EventArgs) Handles tsbRapport.Click
        m_nStep = 7
        AfficherFenetre()

    End Sub

    Private Sub miExploitant_Click(sender As Object, e As EventArgs) Handles miExploitant.Click
        m_nStep = 0
        AfficherFenetre()

    End Sub

    Private Sub miPulve_Click(sender As Object, e As EventArgs) Handles miPulve.Click
        m_nStep = 1
        AfficherFenetre()

    End Sub

    Private Sub mivitesse_Click(sender As Object, e As EventArgs) Handles mivitesse.Click
        m_nStep = 2
        AfficherFenetre()

    End Sub

    Private Sub miDebit_Click(sender As Object, e As EventArgs) Handles miDebit.Click
        m_nStep = 4
        AfficherFenetre()

    End Sub

    Private Sub miDiag_Click(sender As Object, e As EventArgs) Handles miDiag.Click
        m_nStep = 5
        AfficherFenetre()

    End Sub

    Private Sub miRecap_Click(sender As Object, e As EventArgs) Handles miRecap.Click
        m_nStep = 6
        AfficherFenetre()

    End Sub

    Private Sub miCalcul_Click(sender As Object, e As EventArgs) Handles miCalcul.Click
        m_nStep = 7
        AfficherFenetre()

    End Sub

    Private Sub miRapport_Click(sender As Object, e As EventArgs) Handles miRapport.Click
        m_nStep = 8
        AfficherFenetre()

    End Sub

    Private Sub enableExploitant(pbEnable As Boolean)
        miExploitant.Enabled = pbEnable

        tsbExploitant.Enabled = pbEnable

    End Sub

    Private Sub enablePulve(pbEnable As Boolean)
        miPulve.Enabled = pbEnable
        tsbPulvérisateur.Enabled = pbEnable

    End Sub
    Private Sub enableVitesse(pbEnable As Boolean)
        mivitesse.Enabled = pbEnable
        tsbVitesse.Enabled = pbEnable
    End Sub
    Private Sub enableDebit(pbEnable As Boolean)
        miDebit.Enabled = pbEnable
        tsbDebit.Enabled = pbEnable
    End Sub
    Private Sub enableDiag(pbEnable As Boolean)
        miDiag.Enabled = pbEnable
        tsbDiag.Enabled = pbEnable
    End Sub
    Private Sub enableRecap(pbEnable As Boolean)
        miRecap.Enabled = pbEnable
        tsbrecap.Enabled = pbEnable
    End Sub
    Private Sub enableCalcul(pbEnable As Boolean)
        miCalcul.Enabled = pbEnable
        tsbCalcul.Enabled = pbEnable
    End Sub
    Private Sub enableRapport(pbEnable As Boolean)
        miRapport.Enabled = pbEnable
        tsbRapport.Enabled = pbEnable

    End Sub
    Private Sub enablePrecedant(pbEnable As Boolean)
        miPrecedant.Enabled = pbEnable
        tsbPrecedant.Enabled = pbEnable

    End Sub
    Private Sub enableSuivant(pbEnable As Boolean)
        miSuivant.Enabled = pbEnable
        tsbSuivant.Enabled = pbEnable

    End Sub

    Private Sub frmRPparentContener_MdiChildActivate(sender As Object, e As EventArgs) Handles MyBase.MdiChildActivate

        If m_nOldStep <> -1 Then
            If m_nOldStep <> m_nStep Then
                Dim ofrm As IfrmCRODIP
                ofrm = MdiChildren(m_nOldStep)
                If ValiderFRM(ofrm) Then
                    m_nOldStep = m_nStep
                Else
                    'on reste sur la même page
                    m_nStep = m_nOldStep
                    AfficherFenetre()
                End If
            End If
        Else
            m_nOldStep = m_nStep
        End If
    End Sub

    Private Function ValiderFRM(pfrm As IfrmCRODIP) As Boolean
        Dim bReturn As Boolean
        bReturn = pfrm.Valider()
        Return bReturn
    End Function

    Private Sub tsbVFonction_Click(sender As Object, e As EventArgs)
        m_nStep = 3
        AfficherFenetre()

    End Sub

    Private Sub tsbQuitter_Click(sender As Object, e As EventArgs) Handles tsbQuitter.Click
        Me.Close()
    End Sub
End Class
