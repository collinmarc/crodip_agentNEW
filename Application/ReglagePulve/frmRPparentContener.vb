Public Class frmRPparentContener
    Inherits frmCRODIP
    Enum CtrlLoad
        XMLFILE
        CRODIP
        PARAMETER
    End Enum
    Enum EnumModeLancement
        StandAlone
        CRODIP
    End Enum
    Private m_NumCtrlCRODIP As String
    Private m_idAgent As String
    Private m_ModeLancement As EnumModeLancement
#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()
        m_NumCtrlCRODIP = ""
        m_ModeLancement = EnumModeLancement.StandAlone
    End Sub
    Public Sub New(pNumCtrlCRPDIP As String, pidAgent As String)
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()
        '        System.IO.File.AppendAllText("ReglagePulve.log", "New avec 2 param (" & pNumCtrlCRPDIP & "," & pidAgent & ")")
        m_NumCtrlCRODIP = pNumCtrlCRPDIP
        m_idAgent = pidAgent
        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()
        m_ModeLancement = EnumModeLancement.CRODIP

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
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

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Public WithEvents parentContener_statusBar As System.Windows.Forms.StatusBar
    Friend WithEvents MnuApropos As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MnuQuitter As System.Windows.Forms.MenuItem
    Friend WithEvents notify_connexionStatus_nok As System.Windows.Forms.NotifyIcon
    Friend WithEvents notify_connexionStatus_ok As System.Windows.Forms.NotifyIcon
    Friend WithEvents notify_connexionStatus_wait As System.Windows.Forms.NotifyIcon
    Friend WithEvents statusBar_img_loader As System.Windows.Forms.PictureBox
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents miSuivant As System.Windows.Forms.MenuItem
    Friend WithEvents miPrecedant As System.Windows.Forms.MenuItem
    Friend WithEvents tsbDemarer As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbDemarrer As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSuivant As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents tsbPulv�risateur As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbVitesse As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDebit As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDiag As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbrecap As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCalcul As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRapport As System.Windows.Forms.ToolStripButton
    Friend WithEvents miVitesseFonctionnement As System.Windows.Forms.MenuItem
    Friend WithEvents mnuParam As MenuItem
    Friend WithEvents mnuLoadCtrlCRODIP As MenuItem
    Friend WithEvents tsbLoad As ToolStripButton
    Friend WithEvents m_OpenFileDialog1 As OpenFileDialog
    Friend WithEvents m_SaveFileDialog1 As SaveFileDialog
    Friend WithEvents tsbSave As ToolStripButton
    Friend WithEvents tsbPrecedent As ToolStripButton
    Friend WithEvents MenuItem2 As MenuItem
    Friend WithEvents mnuLoadFile As MenuItem
    Friend WithEvents mnuSave As MenuItem
    Friend WithEvents mnuLoadCRODIP As MenuItem
    Friend WithEvents tsbLoadCrodip As ToolStripButton
    Friend WithEvents tsbQuitter As System.Windows.Forms.ToolStripButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRPparentContener))
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MnuQuitter = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MnuApropos = New System.Windows.Forms.MenuItem()
        Me.mnuParam = New System.Windows.Forms.MenuItem()
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
        Me.mnuLoadCtrlCRODIP = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.mnuLoadFile = New System.Windows.Forms.MenuItem()
        Me.mnuSave = New System.Windows.Forms.MenuItem()
        Me.mnuLoadCRODIP = New System.Windows.Forms.MenuItem()
        Me.notify_connexionStatus_nok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_ok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_wait = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tsbDemarer = New System.Windows.Forms.ToolStrip()
        Me.tsbQuitter = New System.Windows.Forms.ToolStripButton()
        Me.tsbDemarrer = New System.Windows.Forms.ToolStripButton()
        Me.tsbLoad = New System.Windows.Forms.ToolStripButton()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.tsbPrecedent = New System.Windows.Forms.ToolStripButton()
        Me.tsbSuivant = New System.Windows.Forms.ToolStripButton()
        Me.tsbLoadCrodip = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbExploitant = New System.Windows.Forms.ToolStripButton()
        Me.tsbPulv�risateur = New System.Windows.Forms.ToolStripButton()
        Me.tsbVitesse = New System.Windows.Forms.ToolStripButton()
        Me.tsbDebit = New System.Windows.Forms.ToolStripButton()
        Me.tsbDiag = New System.Windows.Forms.ToolStripButton()
        Me.tsbrecap = New System.Windows.Forms.ToolStripButton()
        Me.tsbCalcul = New System.Windows.Forms.ToolStripButton()
        Me.tsbRapport = New System.Windows.Forms.ToolStripButton()
        Me.statusBar_img_loader = New System.Windows.Forms.PictureBox()
        Me.parentContener_statusBar = New System.Windows.Forms.StatusBar()
        Me.m_OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.m_SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
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
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MnuQuitter, Me.MenuItem3, Me.MnuApropos, Me.mnuParam})
        Me.MenuItem1.Text = "?"
        '
        'MnuQuitter
        '
        Me.MnuQuitter.Index = 0
        Me.MnuQuitter.Text = "Quitter"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "-"
        '
        'MnuApropos
        '
        Me.MnuApropos.Index = 2
        Me.MnuApropos.Text = "A Propos ?"
        '
        'mnuParam
        '
        Me.mnuParam.Index = 3
        Me.mnuParam.Text = "Param�trage"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miDemarer, Me.miSuivant, Me.miPrecedant, Me.MenuItem8, Me.miExploitant, Me.miPulve, Me.mivitesse, Me.miVitesseFonctionnement, Me.miDebit, Me.miDiag, Me.miRecap, Me.miCalcul, Me.miRapport, Me.mnuLoadCtrlCRODIP, Me.MenuItem2, Me.mnuLoadFile, Me.mnuSave, Me.mnuLoadCRODIP})
        Me.MenuItem5.Text = "ReglagePulv�risateur"
        '
        'miDemarer
        '
        Me.miDemarer.Index = 0
        Me.miDemarer.Text = "D�marrer"
        '
        'miSuivant
        '
        Me.miSuivant.Index = 1
        Me.miSuivant.Text = "Suivant"
        '
        'miPrecedant
        '
        Me.miPrecedant.Index = 2
        Me.miPrecedant.Text = "Pr�c�dent"
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
        Me.miPulve.Text = "Pulv�risateur"
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
        Me.miDebit.Text = "D�bit"
        '
        'miDiag
        '
        Me.miDiag.Index = 9
        Me.miDiag.Text = "Mano/Buses"
        '
        'miRecap
        '
        Me.miRecap.Index = 10
        Me.miRecap.Text = "D�fauts"
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
        'mnuLoadCtrlCRODIP
        '
        Me.mnuLoadCtrlCRODIP.Index = 13
        Me.mnuLoadCtrlCRODIP.Text = "Controle Crodip"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 14
        Me.MenuItem2.Text = "-"
        '
        'mnuLoadFile
        '
        Me.mnuLoadFile.Index = 15
        Me.mnuLoadFile.Shortcut = System.Windows.Forms.Shortcut.CtrlO
        Me.mnuLoadFile.Text = "Chargement d'un r�glage"
        '
        'mnuSave
        '
        Me.mnuSave.Index = 16
        Me.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
        Me.mnuSave.Text = "Sauvegarde d'un reglage"
        '
        'mnuLoadCRODIP
        '
        Me.mnuLoadCRODIP.Index = 17
        Me.mnuLoadCRODIP.Shortcut = System.Windows.Forms.Shortcut.CtrlT
        Me.mnuLoadCRODIP.Text = "Chargement d'un controle CRODIP"
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
        Me.tsbDemarer.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbQuitter, Me.tsbDemarrer, Me.tsbLoad, Me.tsbSave, Me.tsbPrecedent, Me.tsbSuivant, Me.tsbLoadCrodip, Me.ToolStripSeparator1, Me.tsbExploitant, Me.tsbPulv�risateur, Me.tsbVitesse, Me.tsbDebit, Me.tsbDiag, Me.tsbrecap, Me.tsbCalcul, Me.tsbRapport})
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
        Me.tsbDemarrer.Text = "D�marrer "
        '
        'tsbLoad
        '
        Me.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLoad.Image = Global.Crodip_agent.Resources.Open36
        Me.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLoad.Name = "tsbLoad"
        Me.tsbLoad.Size = New System.Drawing.Size(36, 36)
        Me.tsbLoad.Text = "Charger un r�glage"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = Global.Crodip_agent.Resources.save36
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(36, 36)
        Me.tsbSave.Text = "Sauvegarde"
        '
        'tsbPrecedent
        '
        Me.tsbPrecedent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrecedent.Image = CType(resources.GetObject("tsbPrecedent.Image"), System.Drawing.Image)
        Me.tsbPrecedent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrecedent.Name = "tsbPrecedent"
        Me.tsbPrecedent.Size = New System.Drawing.Size(36, 36)
        Me.tsbPrecedent.Text = "Pr�c�dent"
        '
        'tsbSuivant
        '
        Me.tsbSuivant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSuivant.Image = Global.Crodip_agent.Resources.Next36
        Me.tsbSuivant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSuivant.Name = "tsbSuivant"
        Me.tsbSuivant.Size = New System.Drawing.Size(36, 36)
        Me.tsbSuivant.Text = "Suivant"
        '
        'tsbLoadCrodip
        '
        Me.tsbLoadCrodip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbLoadCrodip.Image = Global.Crodip_agent.Resources.ico_crodipIndigo36
        Me.tsbLoadCrodip.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLoadCrodip.Name = "tsbLoadCrodip"
        Me.tsbLoadCrodip.Size = New System.Drawing.Size(36, 36)
        Me.tsbLoadCrodip.Text = "Chargement d'un controle CRODIP"
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
        Me.tsbExploitant.Size = New System.Drawing.Size(64, 36)
        Me.tsbExploitant.Text = "Exploitant"
        '
        'tsbPulv�risateur
        '
        Me.tsbPulv�risateur.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsbPulv�risateur.Image = CType(resources.GetObject("tsbPulv�risateur.Image"), System.Drawing.Image)
        Me.tsbPulv�risateur.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPulv�risateur.Name = "tsbPulv�risateur"
        Me.tsbPulv�risateur.Size = New System.Drawing.Size(79, 36)
        Me.tsbPulv�risateur.Text = "Pulv�risateur"
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
        Me.tsbDebit.Text = "D�bit"
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
        Me.tsbrecap.Text = "D�fauts"
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
        'm_OpenFileDialog1
        '
        Me.m_OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.m_OpenFileDialog1.Filter = "Fichier CRODIP|*.CRODIP"
        Me.m_OpenFileDialog1.Title = "Chargement d'un fichier de reglage Pulv�risateur"
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
        Me.MinimizeBox = False
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

    'Cr�ation des fen�tres Filles
    Private oFRMExploit As frmRPFicheExlpoitant
    Private oFRMPulve As frmRPFichePulve
    Private odlgHelp551 As frmRPDlgHelp551
    Private odlgHelp552 As frmRPDlgHelp552
    Private ofrmdiag As frmRPDiagnostique
    Private ofrmRecap As frmRPRecap
    Private ofrmCalculs As frmRPCalculVolumeHa
    Private ofrmRapport As frmRPRapport

    Private m_nOldStep As Integer
    Private m_oAgent As Agent

    Private Sub parentContener_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        formLoad()
    End Sub
    Private Sub formLoad()
        GlobalsCRODIP.Init()

        'Test pour V�rifier si on est dans une configuation Agent
        Dim oCSdb As New CSDb(False)
        If System.IO.File.Exists(oCSdb.getbddPathName()) Then
            mnuLoadCRODIP.Enabled = True
            mnuLoadCRODIP.Visible = True
            tsbLoadCrodip.Enabled = True
            tsbLoadCrodip.Visible = True
            m_ModeLancement = EnumModeLancement.CRODIP
            '            System.IO.File.AppendAllText("ReglagePulve.log", "Formload avec 2 param (" & m_NumCtrlCRODIP & "," & m_idAgent & ")")
            If String.IsNullOrEmpty(m_idAgent) Then
                Dim oFRM As New RPloginAgent()
                oFRM.ShowDialog(Me)
                m_oAgent = oFRM.AgentCourant
            Else
                '               System.IO.File.AppendAllText("ReglagePulve.log", "Formload chargement de l'agent : " & m_idAgent & ")")
                m_oAgent = AgentManager.getAgentById(m_idAgent)
                If m_oAgent.id <> m_idAgent Then
                    MessageBox.Show("Agent Inconnu")
                    Application.Exit()
                End If
            End If

        Else
            '          System.IO.File.AppendAllText("ReglagePulve.log", "Formload la base " & oCSdb.getbddPathName() & " n'existe pas")
            mnuLoadCRODIP.Enabled = False
            mnuLoadCRODIP.Visible = False
            tsbLoadCrodip.Enabled = False
            tsbLoadCrodip.Visible = False
            Dim oFRM As New RPloginStandAlone()
            oFRM.ShowDialog(Me)
            m_oAgent = oFRM.RPuser
            m_ModeLancement = EnumModeLancement.StandAlone
        End If
        If m_oAgent IsNot Nothing Then
            If m_oAgent.isGestionnaire Then
                mnuParam.Enabled = True
                mnuParam.Visible = True
            Else
                mnuParam.Visible = False
                mnuParam.Enabled = False

            End If
        End If
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
        Me.MinimizeBox = True

        If Not String.IsNullOrEmpty(m_NumCtrlCRODIP) AndAlso m_ModeLancement = EnumModeLancement.CRODIP Then
            loadFile(CtrlLoad.PARAMETER)
        End If
    End Sub


#Region " Menu "

    Private Sub MenuItem_aide_apropos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuApropos.Click
        Dim formApropos As New RPapropos
        formApropos.ShowDialog()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuQuitter.Click
        Me.Close()
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
        Me.Cursor = Cursors.WaitCursor
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
        Me.Cursor = Cursors.Default
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
            Dim tabtsb As ToolStripButton() = {tsbExploitant, tsbPulv�risateur, tsbVitesse, tsbDebit, tsbDiag, tsbrecap, tsbCalcul, tsbRapport}
            For Each otsb As ToolStripButton In tabtsb
                otsb.ForeColor = SystemColors.ControlText
                otsb.BackColor = SystemColors.Control
            Next
            tabtsb(m_nStep).BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
            tabtsb(m_nStep).ForeColor = System.Drawing.Color.White
        Catch ex As Exception
        End Try


    End Sub

    Public Function doPrecedent() As Boolean
        Dim bReturn As Boolean
        Try
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
            clientCourant = New Exploitation()
            pulverisateurCourant = New Pulverisateur()
            agentCourant = Me.m_oAgent
            m_nStep = 0
            m_RPDiagnostic = New RPDiagnostic()
            m_RPDiagnostic.oClientCourant = clientCourant
            m_RPDiagnostic.oPulverisateurCourant = pulverisateurCourant



#If DEBUG Then
            clientCourant.raisonSociale = "ZZZZZZZZZZZZZZZZZZZZZZ"
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
            pulverisateurCourant.largeur = "3.5"
            pulverisateurCourant.attelage = "PORTE"
            pulverisateurCourant.pulverisation = "Pneumatique"
            pulverisateurCourant.capacite = "300"
            pulverisateurCourant.regulation = "DPM"
            pulverisateurCourant.buseType = "BUSES A FENTE"
            pulverisateurCourant.buseFonctionnement = "STANDARD"
            pulverisateurCourant.largeurPlantation = "25"
            pulverisateurCourant.buseNbniveaux = "2"
            pulverisateurCourant.nombreBuses = "5"



            'Cr�ation des objets de references
            m_RPDiagnostic.SetProprietaire(clientCourant)
            m_RPDiagnostic.setPulverisateur(pulverisateurCourant)

            m_RPDiagnostic.CalcVitesseRotation = "1000"
            m_RPDiagnostic.CalcNbreDescentes = 20
            m_RPDiagnostic.CalcNbreNiveauParDescente = 5

            m_RPDiagnostic.diagnosticHelp551.VitesseReelle1 = 5.5
            m_RPDiagnostic.diagnosticHelp551.VitesseReelle1 = 6.7
            m_RPDiagnostic.manometrePressionTravail = 3.5
            m_RPDiagnostic.buseDebitMoyenPM = 2.8
            m_RPDiagnostic.diagnosticHelp551.VitesseReelle1 = 5.5
            m_RPDiagnostic.diagnosticHelp551.VitesseReelle2 = 6.7
            For nlot As Integer = 1 To 2
                Dim oDiagbuse As New DiagnosticBuses
                oDiagbuse.idLot = nlot
                For nBuse As Integer = 1 To 4
                    Dim oDiagBuseDet As DiagnosticBusesDetail = New DiagnosticBusesDetail()
                    oDiagBuseDet.idLot = nlot
                    oDiagBuseDet.idBuse = nBuse
                    oDiagBuseDet.debit = 2.8
                    oDiagbuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDet)
                Next

                oDiagbuse.nombre = oDiagbuse.diagnosticBusesDetailList.Liste.Count
                m_RPDiagnostic.diagnosticBusesList.Liste.Add(oDiagbuse)
            Next
            m_RPDiagnostic.CalcDebitMoyenPM = 2.8
            m_RPDiagnostic.CalcPressionDeMesure = 3.5

#End If



            'Cr�ation des fen�tres Filles
            SuspendLayout()
            oFRMExploit = New frmRPFicheExlpoitant()
            oFRMExploit.setContexte(False, clientCourant, m_RPDiagnostic)
            oFRMExploit.WindowState = FormWindowState.Maximized
            oFRMExploit.MdiParent = Me
            '            oFRMExploit.Show()

            oFRMPulve = New frmRPFichePulve()
            oFRMPulve.setContexte(2, New Agent(), pulverisateurCourant, clientCourant, m_RPDiagnostic)
            oFRMPulve.WindowState = FormWindowState.Maximized
            oFRMPulve.MdiParent = Me
            'oFRMPulve.Show()

            odlgHelp551 = New frmRPDlgHelp551()
            odlgHelp551.Setcontexte(DiagnosticHelp551.Help551Mode.Mode551, m_RPDiagnostic, "Vitesse d'avancement", False)
            odlgHelp551.WindowState = FormWindowState.Maximized
            odlgHelp551.MdiParent = Me
            'odlgHelp551.Show()


            odlgHelp552 = New frmRPDlgHelp552
            odlgHelp552.Setcontexte(frmRPDlgHelp552.Help552Mode.Mode552, m_RPDiagnostic, m_RPDiagnostic.buseDebit, m_RPDiagnostic.manometrePressionTravail)
            odlgHelp552.Text = "D�bits"
            odlgHelp552.WindowState = FormWindowState.Maximized
            odlgHelp552.MdiParent = Me
            'odlgHelp552.Show()


            ofrmdiag = New frmRPDiagnostique()
            ofrmdiag.setContexte(m_RPDiagnostic, GlobalsCRODIP.DiagMode.CTRL_COMPLET, pulverisateurCourant, clientCourant)
            ofrmdiag.WindowState = FormWindowState.Maximized
            ofrmdiag.MdiParent = Me
            'ofrmdiag.Show()


            ofrmRecap = New frmRPRecap()
            ofrmRecap.setContexte(m_RPDiagnostic, pulverisateurCourant)
            ofrmRecap.WindowState = FormWindowState.Maximized
            ofrmRecap.MdiParent = Me
            'ofrmRecap.Show()


            ofrmCalculs = New frmRPCalculVolumeHa()
            ofrmCalculs.setContexte(m_RPDiagnostic)
            ofrmCalculs.WindowState = FormWindowState.Maximized
            ofrmCalculs.MdiParent = Me
            'ofrmCalculs.Show()

            ofrmRapport = New frmRPRapport()
            ofrmRapport.setContexte(m_RPDiagnostic)
            ofrmRapport.WindowState = FormWindowState.Maximized
            ofrmRapport.MdiParent = Me
            ofrmRapport.MdiParent = Me
            'ofrmRapport.Show()

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

            Me.ResumeLayout(False)
            Me.PerformLayout()
            m_nStep = 0
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

    Private Sub tsbPrecedant_Click(sender As Object, e As EventArgs)
        doPrecedent()
    End Sub

    Private Sub mnuRPSuivant_Click(sender As Object, e As EventArgs) Handles miSuivant.Click
        Suivant()
    End Sub

    Private Sub mnuRPPrec_Click(sender As Object, e As EventArgs) Handles miPrecedant.Click
        doPrecedent()
    End Sub

    Private Sub MenuItem6_Click(sender As Object, e As EventArgs) Handles miDemarer.Click
        Demarrer()
    End Sub

    Private Sub tsbExploitant_Click(sender As Object, e As EventArgs) Handles tsbExploitant.Click
        m_nStep = 0
        AfficherFenetre()
    End Sub

    Private Sub tsbPulv�risateur_Click(sender As Object, e As EventArgs) Handles tsbPulv�risateur.Click
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
        tsbPulv�risateur.Enabled = pbEnable

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
        tsbPrecedent.Enabled = pbEnable

    End Sub
    Private Sub enableSuivant(pbEnable As Boolean)
        miSuivant.Enabled = pbEnable
        tsbSuivant.Enabled = pbEnable

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

    Private Sub mnuParam_Click(sender As Object, e As EventArgs) Handles mnuParam.Click
        RPParamUser.ShowDialog(Me)
    End Sub

    Private Sub mnuLoadCtrlCRODIP_Click(sender As Object, e As EventArgs) Handles mnuLoadCtrlCRODIP.Click
        Dim oFRM As New frmLoadCtrlCRODIP()
        If oFRM.ShowDialog(Me) = DialogResult.OK Then
            m_RPDiagnostic = oFRM.m_oDiag
        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles tsbPrecedent.Click
        doPrecedent()
    End Sub

    Private Sub tsbSave_Click(sender As Object, e As EventArgs) Handles tsbSave.Click
        'Validation de la page en cours
        Dim ofrm As IfrmCRODIP
        ofrm = ActiveMdiChild
        If ofrm IsNot Nothing Then
            If ValiderFRM(ofrm) Then
                Save()
            End If
        End If
    End Sub
    Private Sub Save()
        m_SaveFileDialog1.FileName = m_RPDiagnostic.createXMLFileName()
        If (m_SaveFileDialog1.ShowDialog = DialogResult.OK) Then
            m_RPDiagnostic.writeXML(m_SaveFileDialog1.FileName)
        End If

    End Sub

    Private Sub setClientCourant(pClient As Exploitation)
        clientCourant.raisonSociale = pClient.raisonSociale
        clientCourant.nomExploitant = pClient.nomExploitant
        clientCourant.prenomExploitant = pClient.prenomExploitant
        clientCourant.adresse = "adresseTest"
        clientCourant.codePostal = "35250"
        clientCourant.commune = "CHASNE SUR ILLET"
        clientCourant.codeApe = "0112Z"

    End Sub
    Private Sub tsbLoad_Click(sender As Object, e As EventArgs) Handles tsbLoad.Click
        loadFile(CtrlLoad.XMLFILE)
    End Sub
    Private Sub loadFile(pType As CtrlLoad)
        If pType = CtrlLoad.XMLFILE Then
            If m_OpenFileDialog1.ShowDialog = DialogResult.OK Then

                CSDebug.dispInfo("Chargement Fichier")
                m_RPDiagnostic = RPDiagnostic.readXML(m_OpenFileDialog1.FileName)
                m_RPDiagnostic.ParamDiag = m_RPDiagnostic.getParamDiag()
            Else
                Exit Sub
            End If
        End If
        If pType = CtrlLoad.CRODIP Then
            Dim oFrm As New frmLoadCtrlCRODIP()
            If oFrm.ShowDialog(Me) = DialogResult.OK Then
                m_RPDiagnostic = RPDiagnosticManager.getRPDiagnosticById(oFrm.NumCTRL)
            Else
                Exit Sub
            End If
        End If
        If pType = CtrlLoad.PARAMETER Then
            m_RPDiagnostic = RPDiagnosticManager.getRPDiagnosticById(m_NumCtrlCRODIP)
        End If
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        clientCourant = m_RPDiagnostic.oClientCourant
        pulverisateurCourant = m_RPDiagnostic.oPulverisateurCourant

        Me.Enabled = False
        For Each oForm As Form In MdiChildren
            oForm.Close()
        Next

        CSDebug.dispInfo("frmExploit")
        oFRMExploit = New frmRPFicheExlpoitant()
        oFRMExploit.setContexte(False, clientCourant, m_RPDiagnostic)
        oFRMExploit.WindowState = FormWindowState.Maximized
        oFRMExploit.MdiParent = Me


        CSDebug.dispInfo("frmPulve")
        oFRMPulve = New frmRPFichePulve()
        oFRMPulve.setContexte(2, New Agent(), pulverisateurCourant, clientCourant, m_RPDiagnostic)
        oFRMPulve.WindowState = FormWindowState.Maximized
        oFRMPulve.MdiParent = Me

        CSDebug.dispInfo("frm551")
        odlgHelp551 = New frmRPDlgHelp551()
        odlgHelp551.Setcontexte(DiagnosticHelp551.Help551Mode.Mode551, m_RPDiagnostic, "Vitesse d'avancement", False)
        odlgHelp551.WindowState = FormWindowState.Maximized
        odlgHelp551.MdiParent = Me


        CSDebug.dispInfo("frm552")
        odlgHelp552 = New frmRPDlgHelp552
        odlgHelp552.Setcontexte(frmRPDlgHelp552.Help552Mode.Mode552, m_RPDiagnostic, m_RPDiagnostic.buseDebit, m_RPDiagnostic.manometrePressionTravail)
        odlgHelp552.Text = "D�bits"
        odlgHelp552.WindowState = FormWindowState.Maximized
        odlgHelp552.MdiParent = Me


        CSDebug.dispInfo("frmDiagnostique")
        CSDebug.dispInfo("frmDiagnostique New")
        ofrmdiag = New frmRPDiagnostique()
        CSDebug.dispInfo("frmDiagnostique SetContexte")
        ofrmdiag.setContexte(m_RPDiagnostic, GlobalsCRODIP.DiagMode.CTRL_COMPLET, pulverisateurCourant, clientCourant)
        CSDebug.dispInfo("frmDiagnostique WindowsState")
        ofrmdiag.WindowState = FormWindowState.Maximized
        CSDebug.dispInfo("frmDiagnostique Parent")
        ofrmdiag.MdiParent = Me
        CSDebug.dispInfo("frmDiagnostique End")


        CSDebug.dispInfo("frmRecap")
        ofrmRecap = New frmRPRecap()
        ofrmRecap.setContexte(m_RPDiagnostic, pulverisateurCourant)
        ofrmRecap.WindowState = FormWindowState.Maximized
        ofrmRecap.MdiParent = Me

        CSDebug.dispInfo("frmCalcule")

        ofrmCalculs = New frmRPCalculVolumeHa()
        ofrmCalculs.setContexte(m_RPDiagnostic)
        ofrmCalculs.WindowState = FormWindowState.Maximized
        ofrmCalculs.MdiParent = Me

        CSDebug.dispInfo("frmRapport")
        ofrmRapport = New frmRPRapport()
        ofrmRapport.setContexte(m_RPDiagnostic)
        ofrmRapport.WindowState = FormWindowState.Maximized
        ofrmRapport.MdiParent = Me


        CSDebug.dispInfo("frm Fin")


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
        Me.Cursor = Windows.Forms.Cursors.Default
        CSDebug.dispInfo("Afficher Fen�tre")

        m_nStep = 0
        AfficherFenetre()
        Me.Enabled = True

    End Sub

    Private Sub mnuSave_Click(sender As Object, e As EventArgs) Handles mnuSave.Click
        Save()
    End Sub

    Private Sub MnuLoadFile_Click(sender As Object, e As EventArgs) Handles mnuLoadFile.Click
        loadFile(CtrlLoad.XMLFILE)
    End Sub

    Private Sub tsbLoadCrodip_Click(sender As Object, e As EventArgs) Handles tsbLoadCrodip.Click
        loadFile(CtrlLoad.CRODIP)
    End Sub

    Private Sub mnuLoadCRODIP_Click(sender As Object, e As EventArgs) Handles mnuLoadCRODIP.Click
        loadFile(CtrlLoad.CRODIP)
    End Sub

    Private Sub frmRPparentContener_DockChanged(sender As Object, e As EventArgs) Handles Me.DockChanged

    End Sub

    Private Sub frmRPparentContener_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated

    End Sub
End Class
