Imports CRODIPWS

Public Class apropos
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents btn_ficheAddClient_annuler As System.Windows.Forms.Label
    Friend WithEvents label_numVersion As System.Windows.Forms.Label
    Friend WithEvents label_projetName As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents label_description As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblDBVersion As System.Windows.Forms.Label
    Friend WithEvents btn_RAZBase As System.Windows.Forms.Button
    Friend WithEvents lblDB As Label
    Friend WithEvents btnReinitPool As Button
    Friend WithEvents label_dateVersion As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(apropos))
        Me.label_projetName = New System.Windows.Forms.Label()
        Me.label_numVersion = New System.Windows.Forms.Label()
        Me.btn_ficheAddClient_annuler = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.label_description = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblDB = New System.Windows.Forms.Label()
        Me.btn_RAZBase = New System.Windows.Forms.Button()
        Me.lblDBVersion = New System.Windows.Forms.Label()
        Me.label_dateVersion = New System.Windows.Forms.Label()
        Me.btnReinitPool = New System.Windows.Forms.Button()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'label_projetName
        '
        Me.label_projetName.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_projetName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.label_projetName.Location = New System.Drawing.Point(96, 8)
        Me.label_projetName.Name = "label_projetName"
        Me.label_projetName.Size = New System.Drawing.Size(168, 16)
        Me.label_projetName.TabIndex = 23
        Me.label_projetName.Text = "Logiciel Agent CRODIP"
        '
        'label_numVersion
        '
        Me.label_numVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_numVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.label_numVersion.Location = New System.Drawing.Point(96, 32)
        Me.label_numVersion.Name = "label_numVersion"
        Me.label_numVersion.Size = New System.Drawing.Size(152, 16)
        Me.label_numVersion.TabIndex = 23
        Me.label_numVersion.Text = "NumVersion"
        '
        'btn_ficheAddClient_annuler
        '
        Me.btn_ficheAddClient_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ficheAddClient_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_ficheAddClient_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_ficheAddClient_annuler.Image = CType(resources.GetObject("btn_ficheAddClient_annuler.Image"), System.Drawing.Image)
        Me.btn_ficheAddClient_annuler.Location = New System.Drawing.Point(342, 168)
        Me.btn_ficheAddClient_annuler.Name = "btn_ficheAddClient_annuler"
        Me.btn_ficheAddClient_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_ficheAddClient_annuler.TabIndex = 25
        Me.btn_ficheAddClient_annuler.Text = "    Fermer"
        Me.btn_ficheAddClient_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(8, 8)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(76, 84)
        Me.PictureBox2.TabIndex = 0
        Me.PictureBox2.TabStop = False
        '
        'label_description
        '
        Me.label_description.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_description.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.label_description.Location = New System.Drawing.Point(272, 16)
        Me.label_description.Name = "label_description"
        Me.label_description.Size = New System.Drawing.Size(200, 112)
        Me.label_description.TabIndex = 23
        Me.label_description.Text = "description"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.btnReinitPool)
        Me.Panel1.Controls.Add(Me.lblDB)
        Me.Panel1.Controls.Add(Me.btn_RAZBase)
        Me.Panel1.Controls.Add(Me.lblDBVersion)
        Me.Panel1.Controls.Add(Me.label_dateVersion)
        Me.Panel1.Controls.Add(Me.btn_ficheAddClient_annuler)
        Me.Panel1.Controls.Add(Me.label_numVersion)
        Me.Panel1.Controls.Add(Me.label_projetName)
        Me.Panel1.Controls.Add(Me.label_description)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Location = New System.Drawing.Point(8, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(480, 198)
        Me.Panel1.TabIndex = 26
        '
        'lblDB
        '
        Me.lblDB.AutoSize = True
        Me.lblDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lblDB.Location = New System.Drawing.Point(8, 99)
        Me.lblDB.Name = "lblDB"
        Me.lblDB.Size = New System.Drawing.Size(56, 13)
        Me.lblDB.TabIndex = 29
        Me.lblDB.Text = "DBName"
        '
        'btn_RAZBase
        '
        Me.btn_RAZBase.BackgroundImage = Global.Crodip_agent.Resources.btn_delete
        Me.btn_RAZBase.FlatAppearance.BorderSize = 0
        Me.btn_RAZBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_RAZBase.ForeColor = System.Drawing.Color.White
        Me.btn_RAZBase.Location = New System.Drawing.Point(344, 111)
        Me.btn_RAZBase.Name = "btn_RAZBase"
        Me.btn_RAZBase.Size = New System.Drawing.Size(128, 24)
        Me.btn_RAZBase.TabIndex = 28
        Me.btn_RAZBase.Text = "Réinitialisation BD"
        Me.btn_RAZBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btn_RAZBase.UseVisualStyleBackColor = True
        '
        'lblDBVersion
        '
        Me.lblDBVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDBVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.lblDBVersion.Location = New System.Drawing.Point(96, 74)
        Me.lblDBVersion.Name = "lblDBVersion"
        Me.lblDBVersion.Size = New System.Drawing.Size(152, 21)
        Me.lblDBVersion.TabIndex = 27
        Me.lblDBVersion.Text = "DBVersion"
        '
        'label_dateVersion
        '
        Me.label_dateVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label_dateVersion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(193, Byte), Integer))
        Me.label_dateVersion.Location = New System.Drawing.Point(96, 48)
        Me.label_dateVersion.Name = "label_dateVersion"
        Me.label_dateVersion.Size = New System.Drawing.Size(152, 26)
        Me.label_dateVersion.TabIndex = 26
        Me.label_dateVersion.Text = "dateVersion"
        '
        'btnReinitPool
        '
        Me.btnReinitPool.BackgroundImage = Global.Crodip_agent.Resources.btn_delete
        Me.btnReinitPool.FlatAppearance.BorderSize = 0
        Me.btnReinitPool.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReinitPool.ForeColor = System.Drawing.Color.White
        Me.btnReinitPool.Location = New System.Drawing.Point(344, 141)
        Me.btnReinitPool.Name = "btnReinitPool"
        Me.btnReinitPool.Size = New System.Drawing.Size(128, 24)
        Me.btnReinitPool.TabIndex = 30
        Me.btnReinitPool.Text = "Réinitialisation Pool"
        Me.btnReinitPool.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnReinitPool.UseVisualStyleBackColor = True
        '
        'apropos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(490, 209)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "apropos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. A Propos"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btn_ficheAddClient_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ficheAddClient_annuler.Click
        Me.Close()
    End Sub

    Private Sub apropos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ' On récupère le numéro de version
            label_numVersion.Text = "N° de version : " & GlobalsCRODIP.GLOB_APPLI_VERSION
            label_dateVersion.Text = "Build: " & GlobalsCRODIP.GLOB_APPLI_BUILD
            lblDBVersion.Text = "DB : " & DBVersionManagerManager.getDBVersion().NUM
            lblDB.Text = New CSDb(False).getbddPathName()
            ' On récupère le copyright

            ' On récupère la description
            label_description.Text = "Le présent logiciel permet la réalisation diagnostics et contrôles terrain et doit répondre aux besoins identifiés par l'application du futur protocole « diagnostics pulvérisateurs »."

            ' On récupère le nom du projet
            label_projetName.Text = Application.ProductName

        Catch ex As Exception
            CSDebug.dispError("apropos_Load" & ex.Message)
        End Try

    End Sub

    Private Sub btn_RAZBase_Click(sender As Object, e As EventArgs) Handles btn_RAZBase.Click
        If InputBox("Mot de passe", "Réinitialisation de la base") = "Crodip35" Then

            If MsgBox("ATTENTION, Cette action supprime toutes les données de votre base, il faudra faire une synchronisation complête pour retrouver vos données, Etes-vous sur de vouloir supprimer toutes les données de votre Base ?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Réinitialisation de la base de données") = MsgBoxResult.Yes Then
                If MsgBox("Etes-vous sur de vouloir supprimer toutes les données de votre Base ?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Réinitialisation de la base de données") = MsgBoxResult.Yes Then
                    Try

                        Dim oCSDB As New CSDb(True)
                        oCSDB.RAZ_BASE_DONNEES()
                        oCSDB.free()
                        MsgBox("Votre base de données a été réinitialisée, veuillez vous reconnecter pour réaliser un synchronisation complête", MsgBoxStyle.OkOnly)
                        CSEnvironnement.delPid()
                        Application.Exit()
                    Catch ex As Exception
                        CSDebug.dispFatal("Apropos.RAZBASE ERR" & ex.Message)
                    End Try
                End If
            End If
        End If
    End Sub

    Private Sub btnReinitPool_Click(sender As Object, e As EventArgs) Handles btnReinitPool.Click

        If MsgBox("ATTENTION, Cette action supprime toutes les données de pool de votre PC. Voulez-vous continuer ?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Réinitialisation des pools") = MsgBoxResult.Yes Then
                If MsgBox("Etes-vous sur de vouloir supprimer toutes les données des pools ?", MsgBoxStyle.Critical + MsgBoxStyle.YesNo, "Réinitialisation des pools") = MsgBoxResult.Yes Then
                    Try

                        Dim oCSDB As New CSDb(True)
                        oCSDB.RAZ_Pool()
                        oCSDB.free()
                        MsgBox("Vos données de pool ont été supprimées, veuillez vous reconnecter pour les regénérer", MsgBoxStyle.OkOnly)
                        CSEnvironnement.delPid()
                        Application.Exit()
                    Catch ex As Exception
                    CSDebug.dispFatal("Apropos.RAZPool ERR" & ex.Message)
                End Try
                End If
            End If

    End Sub
End Class
