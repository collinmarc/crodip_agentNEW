Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging

Public Class facturation2
    Inherits frmCRODIP

    Private FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label104 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents facturation_siren As System.Windows.Forms.TextBox
    Friend WithEvents btn_facturation_valider As System.Windows.Forms.Label
    Friend WithEvents btn_facturation_annuler As System.Windows.Forms.Label
    Friend WithEvents facturation_tva As System.Windows.Forms.TextBox
    Friend WithEvents facturation_rcs As System.Windows.Forms.TextBox
    Friend WithEvents panel_logo_bg As System.Windows.Forms.Panel
    Friend WithEvents facturation_footer As System.Windows.Forms.RichTextBox
    Friend WithEvents facturation_isActivated As System.Windows.Forms.CheckBox
    Friend WithEvents btn_facturation_ajouterLogo As System.Windows.Forms.Label
    Friend WithEvents facturation_logo As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbRacineNumerotation As TextBox
    Friend WithEvents tbDernNumero As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents tbHeader As RichTextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbCoordonnesBancaires As RichTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tbModeReglement As TextBox
    Friend WithEvents tbTxTVA As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents lblError As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(facturation2))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.facturation_siren = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.btn_facturation_valider = New System.Windows.Forms.Label()
        Me.btn_facturation_annuler = New System.Windows.Forms.Label()
        Me.facturation_tva = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.facturation_rcs = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.panel_logo_bg = New System.Windows.Forms.Panel()
        Me.facturation_logo = New System.Windows.Forms.PictureBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.facturation_footer = New System.Windows.Forms.RichTextBox()
        Me.facturation_isActivated = New System.Windows.Forms.CheckBox()
        Me.btn_facturation_ajouterLogo = New System.Windows.Forms.Label()
        Me.lblError = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbRacineNumerotation = New System.Windows.Forms.TextBox()
        Me.tbDernNumero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbHeader = New System.Windows.Forms.RichTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbCoordonnesBancaires = New System.Windows.Forms.RichTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbModeReglement = New System.Windows.Forms.TextBox()
        Me.tbTxTVA = New CRODIP_ControlLibrary.TBNumeric()
        Me.panel_logo_bg.SuspendLayout()
        CType(Me.facturation_logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label1.Image = CType(resources.GetObject("Label1.Image"), System.Drawing.Image)
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "     Facturation"
        '
        'facturation_siren
        '
        Me.facturation_siren.Location = New System.Drawing.Point(188, 128)
        Me.facturation_siren.Name = "facturation_siren"
        Me.facturation_siren.Size = New System.Drawing.Size(232, 20)
        Me.facturation_siren.TabIndex = 28
        '
        'Label104
        '
        Me.Label104.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label104.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label104.Location = New System.Drawing.Point(70, 129)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(68, 16)
        Me.Label104.TabIndex = 27
        Me.Label104.Text = "N°SIREN"
        Me.Label104.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btn_facturation_valider
        '
        Me.btn_facturation_valider.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_facturation_valider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturation_valider.ForeColor = System.Drawing.Color.White
        Me.btn_facturation_valider.Image = CType(resources.GetObject("btn_facturation_valider.Image"), System.Drawing.Image)
        Me.btn_facturation_valider.Location = New System.Drawing.Point(559, 594)
        Me.btn_facturation_valider.Name = "btn_facturation_valider"
        Me.btn_facturation_valider.Size = New System.Drawing.Size(128, 24)
        Me.btn_facturation_valider.TabIndex = 32
        Me.btn_facturation_valider.Text = "    Valider / Quitter"
        Me.btn_facturation_valider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_facturation_annuler
        '
        Me.btn_facturation_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_facturation_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturation_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_facturation_annuler.Image = CType(resources.GetObject("btn_facturation_annuler.Image"), System.Drawing.Image)
        Me.btn_facturation_annuler.Location = New System.Drawing.Point(391, 594)
        Me.btn_facturation_annuler.Name = "btn_facturation_annuler"
        Me.btn_facturation_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_facturation_annuler.TabIndex = 31
        Me.btn_facturation_annuler.Text = "    Annuler"
        Me.btn_facturation_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'facturation_tva
        '
        Me.facturation_tva.Location = New System.Drawing.Point(188, 154)
        Me.facturation_tva.Name = "facturation_tva"
        Me.facturation_tva.Size = New System.Drawing.Size(232, 20)
        Me.facturation_tva.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(70, 155)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 16)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "N°TVA"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(70, 181)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 16)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "RCS"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'facturation_rcs
        '
        Me.facturation_rcs.Location = New System.Drawing.Point(188, 180)
        Me.facturation_rcs.Name = "facturation_rcs"
        Me.facturation_rcs.Size = New System.Drawing.Size(232, 20)
        Me.facturation_rcs.TabIndex = 28
        '
        'panel_logo_bg
        '
        Me.panel_logo_bg.BackColor = System.Drawing.SystemColors.ControlDark
        Me.panel_logo_bg.Controls.Add(Me.facturation_logo)
        Me.panel_logo_bg.Location = New System.Drawing.Point(456, 8)
        Me.panel_logo_bg.Name = "panel_logo_bg"
        Me.panel_logo_bg.Size = New System.Drawing.Size(200, 216)
        Me.panel_logo_bg.TabIndex = 33
        '
        'facturation_logo
        '
        Me.facturation_logo.Image = CType(resources.GetObject("facturation_logo.Image"), System.Drawing.Image)
        Me.facturation_logo.Location = New System.Drawing.Point(8, 8)
        Me.facturation_logo.Name = "facturation_logo"
        Me.facturation_logo.Size = New System.Drawing.Size(184, 200)
        Me.facturation_logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.facturation_logo.TabIndex = 40
        Me.facturation_logo.TabStop = False
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(22, 504)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(168, 16)
        Me.Label4.TabIndex = 34
        Me.Label4.Text = "Pied de page de la facture"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'facturation_footer
        '
        Me.facturation_footer.Location = New System.Drawing.Point(25, 534)
        Me.facturation_footer.Name = "facturation_footer"
        Me.facturation_footer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.facturation_footer.Size = New System.Drawing.Size(648, 47)
        Me.facturation_footer.TabIndex = 35
        Me.facturation_footer.Text = ""
        '
        'facturation_isActivated
        '
        Me.facturation_isActivated.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.facturation_isActivated.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.facturation_isActivated.Location = New System.Drawing.Point(40, 40)
        Me.facturation_isActivated.Name = "facturation_isActivated"
        Me.facturation_isActivated.Size = New System.Drawing.Size(181, 16)
        Me.facturation_isActivated.TabIndex = 37
        Me.facturation_isActivated.Text = "Activation du module"
        '
        'btn_facturation_ajouterLogo
        '
        Me.btn_facturation_ajouterLogo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_facturation_ajouterLogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_facturation_ajouterLogo.ForeColor = System.Drawing.Color.White
        Me.btn_facturation_ajouterLogo.Image = CType(resources.GetObject("btn_facturation_ajouterLogo.Image"), System.Drawing.Image)
        Me.btn_facturation_ajouterLogo.Location = New System.Drawing.Point(496, 232)
        Me.btn_facturation_ajouterLogo.Name = "btn_facturation_ajouterLogo"
        Me.btn_facturation_ajouterLogo.Size = New System.Drawing.Size(128, 24)
        Me.btn_facturation_ajouterLogo.TabIndex = 39
        Me.btn_facturation_ajouterLogo.Text = "       Choisir un logo"
        Me.btn_facturation_ajouterLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblError
        '
        Me.lblError.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblError.ForeColor = System.Drawing.Color.Red
        Me.lblError.Location = New System.Drawing.Point(152, 8)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(296, 24)
        Me.lblError.TabIndex = 73
        Me.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(10, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(128, 16)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Racine numérotation"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbRacineNumerotation
        '
        Me.tbRacineNumerotation.Location = New System.Drawing.Point(188, 74)
        Me.tbRacineNumerotation.Name = "tbRacineNumerotation"
        Me.tbRacineNumerotation.Size = New System.Drawing.Size(232, 20)
        Me.tbRacineNumerotation.TabIndex = 75
        '
        'tbDernNumero
        '
        Me.tbDernNumero.Location = New System.Drawing.Point(188, 100)
        Me.tbDernNumero.Name = "tbDernNumero"
        Me.tbDernNumero.Size = New System.Drawing.Size(232, 20)
        Me.tbDernNumero.TabIndex = 76
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(12, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 16)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Dernier Numéro"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbHeader
        '
        Me.tbHeader.Location = New System.Drawing.Point(25, 283)
        Me.tbHeader.Name = "tbHeader"
        Me.tbHeader.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.tbHeader.Size = New System.Drawing.Size(648, 44)
        Me.tbHeader.TabIndex = 79
        Me.tbHeader.Text = ""
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(22, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(168, 16)
        Me.Label7.TabIndex = 78
        Me.Label7.Text = "Entete de facture"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbCoordonnesBancaires
        '
        Me.tbCoordonnesBancaires.Location = New System.Drawing.Point(25, 380)
        Me.tbCoordonnesBancaires.Name = "tbCoordonnesBancaires"
        Me.tbCoordonnesBancaires.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.tbCoordonnesBancaires.Size = New System.Drawing.Size(324, 98)
        Me.tbCoordonnesBancaires.TabIndex = 81
        Me.tbCoordonnesBancaires.Text = ""
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(22, 350)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(168, 16)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Coordonnées bancaires"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(378, 350)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(168, 16)
        Me.Label9.TabIndex = 82
        Me.Label9.Text = "Taux TVA par défaut :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(378, 381)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(192, 16)
        Me.Label10.TabIndex = 83
        Me.Label10.Text = "Mode de réglement par défaut :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbModeReglement
        '
        Me.tbModeReglement.Location = New System.Drawing.Point(383, 410)
        Me.tbModeReglement.Name = "tbModeReglement"
        Me.tbModeReglement.Size = New System.Drawing.Size(289, 20)
        Me.tbModeReglement.TabIndex = 85
        '
        'tbTxTVA
        '
        Me.tbTxTVA.ForceBindingOnTextChanged = False
        Me.tbTxTVA.Location = New System.Drawing.Point(572, 346)
        Me.tbTxTVA.Name = "tbTxTVA"
        Me.tbTxTVA.Size = New System.Drawing.Size(100, 20)
        Me.tbTxTVA.TabIndex = 86
        '
        'facturation2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(801, 627)
        Me.ControlBox = False
        Me.Controls.Add(Me.tbTxTVA)
        Me.Controls.Add(Me.tbModeReglement)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.tbCoordonnesBancaires)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.tbHeader)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbDernNumero)
        Me.Controls.Add(Me.tbRacineNumerotation)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.btn_facturation_ajouterLogo)
        Me.Controls.Add(Me.facturation_isActivated)
        Me.Controls.Add(Me.facturation_footer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.panel_logo_bg)
        Me.Controls.Add(Me.btn_facturation_valider)
        Me.Controls.Add(Me.btn_facturation_annuler)
        Me.Controls.Add(Me.facturation_siren)
        Me.Controls.Add(Me.Label104)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.facturation_tva)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.facturation_rcs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MinimizeBox = False
        Me.Name = "facturation2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paramétrage du module facturation"
        Me.TopMost = True
        Me.panel_logo_bg.ResumeLayout(False)
        CType(Me.facturation_logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    '########################################################################################

#Region " Loader "

    ' Chargement des information de facturation
    Private Sub facturation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.loadParams()
    End Sub

#End Region

    '####################################################################################

#Region " Boutons "

    ' Fermeture sans enregistrement
    Private Sub btn_facturation_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturation_annuler.Click
        TryCast(Me.MdiParent, parentContener).ReturnToAccueil()
    End Sub

    ' Enregistrement
    Private Sub btn_facturation_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturation_valider.Click
        If Me.saveParams() Then
            TryCast(MdiParent, parentContener).ReturnToAccueil()
        End If
    End Sub

    ' Activation / desactivation de la facturation
    Private Sub facturation_isActivated_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles facturation_isActivated.CheckedChanged
        Me.toggleForm(facturation_isActivated.Checked)
    End Sub

    ' Ajout d'un logo
    Private Sub btn_facturation_ajouterLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_facturation_ajouterLogo.Click

        Dim filesBrowserDialogReturn As System.Windows.Forms.DialogResult
        Dim filesBrowserDialog As OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        filesBrowserDialog.Title = "Sélèctionnez votre logo"
        filesBrowserDialog.DefaultExt = "jpg"
        filesBrowserDialog.Filter = "Fichier image|*.bmp;*.jpg;*.jpeg;*.png"
        filesBrowserDialog.InitialDirectory = Environment.SpecialFolder.Desktop.ToString
        filesBrowserDialogReturn = filesBrowserDialog.ShowDialog()
        If filesBrowserDialogReturn = DialogResult.OK Or filesBrowserDialogReturn = DialogResult.Yes Then
            Dim selectedFile As String = filesBrowserDialog.FileName
            Dim selectedFileName As String = System.IO.Path.GetFileName(selectedFile)
            'Dim newFilepath As String = GlobalsCRODIP.CONST_PATH_PUBLIC & "\" & selectedFileName
            Dim logoFilepath As String = GlobalsCRODIP.CONST_PATH_PUBLIC & "\" & GlobalsCRODIP.CR_LOGO_NAME
            If selectedFile <> Nothing Then
                ' Copie du nouveau fichier
                File.Copy(selectedFile, logoFilepath, True)

                '' Thumb 184
                'Dim newImage As Image = Image.FromFile(newFilepath)
                'Dim newImage_w As Integer = newImage.Width()
                'Dim newImage_h As Integer = newImage.Height()

                '' On save
                'Try
                '    newImage.Save(GlobalsCRODIP.CONST_PATH_PUBLIC & "\" & GlobalsCRODIP.CR_LOGO_NAME)
                'Catch ex As Exception
                '    CSDebug.dispError("Facturation.ajoutLogo.save() : " & ex.Message)
                'End Try

                '' On libère
                'newImage.Dispose()
                ''newImage_thumb.Dispose()
                ''newImage_thumbTn.Dispose()

                ' Enregistrement en conf
                Me.FACTURATION_XML_CONFIG.setElementValue("/root/logo", GlobalsCRODIP.CONST_PATH_PUBLIC & GlobalsCRODIP.CR_LOGO_NAME)
                'Me.FACTURATION_XML_CONFIG.setElementValue("/root/logo_tn", GlobalsCRODIP.CONST_PATH_PUBLIC & CR_LOGO_TN_NAME)

                '######################################################################################

                ' Chargement IHM
                Me.loadLogo()

                ' Suppression image temporaire
                'File.Delete(newFilepath)

            End If
        End If

    End Sub

#End Region

#Region " Fonctions "

    ' Activation / desactivation du formulaire
    Private Sub toggleForm(ByVal isActivated As Boolean)
        facturation_siren.Enabled = isActivated
        facturation_tva.Enabled = isActivated
        facturation_rcs.Enabled = isActivated
        facturation_footer.Enabled = isActivated
    End Sub

    ' Chargement de la configuration
    Private Sub loadParams()

        Me.loadLogo()
        Dim x As Xml.XmlNode = Me.FACTURATION_XML_CONFIG.getXmlNode("/root")
        If x IsNot Nothing Then
            Dim y As Integer = x.ChildNodes.Count
            For i As Integer = 0 To y - 1
                Select Case x.ChildNodes.Item(i).Name().ToUpper().Trim()
                    Case "isActive".ToUpper().Trim()
                        facturation_isActivated.Checked = CType(x.ChildNodes.Item(i).InnerText, Boolean)
                        Me.toggleForm(facturation_isActivated.Checked)
                    Case "siren".ToUpper().Trim()
                        facturation_siren.Text = x.ChildNodes.Item(i).InnerText
                    Case "tva".ToUpper().Trim()
                        facturation_tva.Text = x.ChildNodes.Item(i).InnerText
                    Case "rcs".ToUpper().Trim()
                        facturation_rcs.Text = x.ChildNodes.Item(i).InnerText
                    Case "footer".ToUpper().Trim()
                        facturation_footer.Text = x.ChildNodes.Item(i).InnerText
                    Case "racinenumerotation".ToUpper().Trim()
                        tbRacineNumerotation.Text = x.ChildNodes.Item(i).InnerText
                    Case "derniernumero".ToUpper().Trim()
                        tbDernNumero.Text = x.ChildNodes.Item(i).InnerText
                    Case "txTVA".ToUpper().Trim()
                        tbTxTVA.Text = x.ChildNodes.Item(i).InnerText
                    Case "header".ToUpper().Trim()
                        tbHeader.Text = x.ChildNodes.Item(i).InnerText
                    Case "coordonneesBancaires".ToUpper().Trim()
                        tbCoordonnesBancaires.Text = x.ChildNodes.Item(i).InnerText
                    Case "modereglement".ToUpper().Trim()
                        tbModeReglement.Text = x.ChildNodes.Item(i).InnerText
                    Case "header".ToUpper().Trim()
                        tbHeader.Text = x.ChildNodes.Item(i).InnerText
                End Select
            Next
        End If
    End Sub

    ' Sauvegarde la configuration
    Private Function saveParams() As Boolean

        ' On test les champs obligatoires
        If facturation_isActivated.Checked And (facturation_siren.Text = "" Or facturation_tva.Text = "" Or facturation_rcs.Text = "") Then
            lblError.Text = "Veuillez remplir tous les champs."
            Return False
        End If
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/isActive", facturation_isActivated.Checked.ToString)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/siren", facturation_siren.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/tva", facturation_tva.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/rcs", facturation_rcs.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/footer", facturation_footer.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/header", tbHeader.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/racinenumerotation", tbRacineNumerotation.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/derniernumero", tbDernNumero.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/txTVA", tbTxTVA.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/coordonneesBancaires", tbCoordonnesBancaires.Text)
        Me.FACTURATION_XML_CONFIG.setElementValue("/root/modereglement", tbModeReglement.Text)

        Return True
    End Function

    Private Sub loadLogo(ByVal Optional isDefaultLogo As Boolean = False)
        Dim logoFilename As String = GlobalsCRODIP.CONST_PATH_IMG & GlobalsCRODIP.CR_LOGO_DEFAULT_NAME
        If Not isDefaultLogo Then
            logoFilename = Me.FACTURATION_XML_CONFIG.getElementValue("/root/logo")
        End If
        If Not File.Exists(logoFilename) Then
            logoFilename = GlobalsCRODIP.CONST_PATH_IMG & GlobalsCRODIP.CR_LOGO_DEFAULT_NAME
        End If
        facturation_logo.ImageLocation = logoFilename
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

#End Region

End Class
