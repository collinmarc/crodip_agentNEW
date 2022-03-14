<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class parentContener
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
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
    Friend WithEvents MenuItem_aide_debug_exportSynchro As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem


    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(parentContener))
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
        Me.MenuItem_aide_debug_exportSynchro = New System.Windows.Forms.MenuItem()
        Me.parentContener_statusBar = New System.Windows.Forms.StatusBar()
        Me.notify_connexionStatus_nok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_ok = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.notify_connexionStatus_wait = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.statusBar_img_loader = New System.Windows.Forms.PictureBox()
        Me.mniVaccum = New System.Windows.Forms.MenuItem()
        CType(Me.statusBar_img_loader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem4, Me.MenuItem3, Me.mnuCheckupdates, Me.MenuItem7, Me.MenuItem_aide_apropos, Me.MenuItem_aide_debug, Me.mniVaccum})
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
        Me.MenuItem_aide_debug.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem_aide_debug_exportLogs, Me.MenuItem_aide_debug_exportSynchro})
        Me.MenuItem_aide_debug.Text = "Debug"
        '
        'MenuItem_aide_debug_exportLogs
        '
        Me.MenuItem_aide_debug_exportLogs.Index = 0
        Me.MenuItem_aide_debug_exportLogs.Text = "Extraire le fichier de logs"
        '
        'MenuItem_aide_debug_exportSynchro
        '
        Me.MenuItem_aide_debug_exportSynchro.Index = 1
        Me.MenuItem_aide_debug_exportSynchro.Text = "Extraire la trace de synchronisation"
        '
        'parentContener_statusBar
        '
        Me.parentContener_statusBar.Location = New System.Drawing.Point(0, 684)
        Me.parentContener_statusBar.Name = "parentContener_statusBar"
        Me.parentContener_statusBar.Size = New System.Drawing.Size(1012, 22)
        Me.parentContener_statusBar.TabIndex = 1
        '
        'notify_connexionStatus_nok
        '
        Me.notify_connexionStatus_nok.Text = "Logiciel Agent Crodip: Hors Ligne !"
        Me.notify_connexionStatus_nok.Visible = True
        '
        'notify_connexionStatus_ok
        '
        Me.notify_connexionStatus_ok.Text = "Logiciel Agent Crodip: En Ligne !"
        '
        'notify_connexionStatus_wait
        '
        Me.notify_connexionStatus_wait.Text = "Logiciel Agent Crodip: En Ligne !"
        '
        'statusBar_img_loader
        '
        Me.statusBar_img_loader.Location = New System.Drawing.Point(6, 688)
        Me.statusBar_img_loader.Name = "statusBar_img_loader"
        Me.statusBar_img_loader.Size = New System.Drawing.Size(16, 16)
        Me.statusBar_img_loader.TabIndex = 13
        Me.statusBar_img_loader.TabStop = False
        Me.statusBar_img_loader.Visible = False
        '
        'mniVaccum
        '
        Me.mniVaccum.Index = 7
        Me.mniVaccum.Text = "Nettoyage Base de données"
        '
        'parentContener
        '
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(1012, 706)
        Me.Controls.Add(Me.statusBar_img_loader)
        Me.Controls.Add(Me.parentContener_statusBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "parentContener"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip"
        CType(Me.statusBar_img_loader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents mniVaccum As MenuItem
End Class
