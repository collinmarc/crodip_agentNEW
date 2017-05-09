Public Class controle_preliminaire
    Inherits frmCRODIP

#Region " - Vars - "
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btn_toutCocher As System.Windows.Forms.Label
    'Private modeAffichage As String = "default"
    Private Const CHK_OK As Integer = 1
    Private Const CHK_DEFAUT_MINEUR As Integer = 2
    Private Const CHK_DEFAUT_MAJEUR As Integer = 3
    Private Const CHK_DEFAUT_MAJEURPRELIM As Integer = 4
    Private m_bDuringLoad As Boolean
    Private m_oParamdiag As CRODIP_ControlLibrary.ParamDiag
    Private m_Mode As DiagMode
    Private m_Diagnostic As Diagnostic
    Private m_Pulverisateur As Pulverisateur
    Private m_Exploit As Exploitation

#End Region

#Region " Code généré par le Concepteur Windows Form "

    Private Sub New()
        MyBase.New()
        m_bDuringLoad = True

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        m_Mode = DiagMode.CTRL_COMPLET
        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
        m_bDuringLoad = False
    End Sub
    Public Sub New(ByVal pMode As DiagMode, pDiag As Diagnostic, pPulve As Pulverisateur, pclient As Exploitation)
        Me.New()
        m_bDuringLoad = True
        m_Mode = pMode
        m_Diagnostic = pDiag
        m_Pulverisateur = pPulve
        m_Exploit = pclient
        ' contreVisite
        '        If _isContreVisite Then
        '        modeAffichage = "CV"
        '       End If
        '      isContreVisite = _isContreVisite
        m_bDuringLoad = False
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox_diagnostic_111 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_diagnostic_11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox_diagnostic_112 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_diagnostic_113 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox_diagnostic_123 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_diagnostic_125 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_diagnostic_122 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_diagnostic_124 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox_diagnostic_121 As System.Windows.Forms.GroupBox
    Friend WithEvents Label_diagnostic_12 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents lbl_controlePreliminaire_etatDiag_nok As System.Windows.Forms.Label
    Friend WithEvents lbl_controlePreliminaire_etatDiag_ok As System.Windows.Forms.Label
    Friend WithEvents diagPreliminaire_client_proprioSiren As System.Windows.Forms.Label
    Friend WithEvents diagPreliminaire_client_raisonSociale As System.Windows.Forms.Label
    Friend WithEvents diagPreliminaire_pulve_marqueModele As System.Windows.Forms.Label
    Friend WithEvents diagPreliminaire_pulve_numNatio As System.Windows.Forms.Label
    '    Friend WithEvents RadioButton_diagnostic_2319 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1111 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1110 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1113 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1112 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1123 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1120 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1122 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1121 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1132 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1130 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1133 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1131 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1230 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1232 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1231 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1251 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1224 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1223 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1220 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1222 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1221 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1247 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1246 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1245 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1244 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1243 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1240 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1242 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1241 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1213 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1210 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1212 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents RadioButton_diagnostic_1211 As CRODIP_ControlLibrary.CtrlDiag2
    Friend WithEvents btn_controlePreliminaire_annuler As System.Windows.Forms.Label
    Friend WithEvents btn_controlePreliminaire_poursuivre As System.Windows.Forms.Label
    Friend WithEvents Label_diagnostic_1 As System.Windows.Forms.Label
    Friend WithEvents btn_controlePreliminaire_imprimerRapport As System.Windows.Forms.Label
    Friend WithEvents RadioButton_diagnostic_1250 As CRODIP_ControlLibrary.CtrlDiag2
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(controle_preliminaire))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lbl_controlePreliminaire_etatDiag_nok = New System.Windows.Forms.Label()
        Me.lbl_controlePreliminaire_etatDiag_ok = New System.Windows.Forms.Label()
        Me.btn_controlePreliminaire_poursuivre = New System.Windows.Forms.Label()
        Me.btn_controlePreliminaire_imprimerRapport = New System.Windows.Forms.Label()
        Me.btn_controlePreliminaire_annuler = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_toutCocher = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_111 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1113 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1110 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1112 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1111 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Label_diagnostic_11 = New System.Windows.Forms.Label()
        Me.GroupBox_diagnostic_112 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1123 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1120 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1122 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1121 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_113 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1132 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1130 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1133 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1131 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label_diagnostic_1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.diagPreliminaire_client_proprioSiren = New System.Windows.Forms.Label()
        Me.diagPreliminaire_client_raisonSociale = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.diagPreliminaire_pulve_numNatio = New System.Windows.Forms.Label()
        Me.diagPreliminaire_pulve_marqueModele = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.GroupBox_diagnostic_123 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1230 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1232 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1231 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_125 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1250 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1251 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_122 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1224 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1223 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1220 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1222 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1221 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_124 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1247 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1246 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1245 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1244 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1243 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1240 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1242 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1241 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.GroupBox_diagnostic_121 = New System.Windows.Forms.GroupBox()
        Me.RadioButton_diagnostic_1213 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1210 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1212 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.RadioButton_diagnostic_1211 = New CRODIP_ControlLibrary.CtrlDiag2()
        Me.Label_diagnostic_12 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox_diagnostic_111.SuspendLayout()
        Me.GroupBox_diagnostic_112.SuspendLayout()
        Me.GroupBox_diagnostic_113.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.GroupBox_diagnostic_123.SuspendLayout()
        Me.GroupBox_diagnostic_125.SuspendLayout()
        Me.GroupBox_diagnostic_122.SuspendLayout()
        Me.GroupBox_diagnostic_124.SuspendLayout()
        Me.GroupBox_diagnostic_121.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1646, 1023)
        Me.Panel1.TabIndex = 2
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Controls.Add(Me.lbl_controlePreliminaire_etatDiag_nok)
        Me.Panel5.Controls.Add(Me.lbl_controlePreliminaire_etatDiag_ok)
        Me.Panel5.Controls.Add(Me.btn_controlePreliminaire_poursuivre)
        Me.Panel5.Controls.Add(Me.btn_controlePreliminaire_imprimerRapport)
        Me.Panel5.Controls.Add(Me.btn_controlePreliminaire_annuler)
        Me.Panel5.Location = New System.Drawing.Point(246, 529)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(710, 96)
        Me.Panel5.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label7.Image = CType(resources.GetObject("Label7.Image"), System.Drawing.Image)
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label7.Location = New System.Drawing.Point(8, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(368, 32)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "     Résultat examens préliminaires"
        '
        'lbl_controlePreliminaire_etatDiag_nok
        '
        Me.lbl_controlePreliminaire_etatDiag_nok.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_controlePreliminaire_etatDiag_nok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(31, Byte), Integer))
        Me.lbl_controlePreliminaire_etatDiag_nok.Location = New System.Drawing.Point(104, 64)
        Me.lbl_controlePreliminaire_etatDiag_nok.Name = "lbl_controlePreliminaire_etatDiag_nok"
        Me.lbl_controlePreliminaire_etatDiag_nok.Size = New System.Drawing.Size(328, 40)
        Me.lbl_controlePreliminaire_etatDiag_nok.TabIndex = 9
        Me.lbl_controlePreliminaire_etatDiag_nok.Text = "Etat non satisfaisant"
        Me.lbl_controlePreliminaire_etatDiag_nok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl_controlePreliminaire_etatDiag_ok
        '
        Me.lbl_controlePreliminaire_etatDiag_ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_controlePreliminaire_etatDiag_ok.ForeColor = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.lbl_controlePreliminaire_etatDiag_ok.Location = New System.Drawing.Point(104, 64)
        Me.lbl_controlePreliminaire_etatDiag_ok.Name = "lbl_controlePreliminaire_etatDiag_ok"
        Me.lbl_controlePreliminaire_etatDiag_ok.Size = New System.Drawing.Size(328, 40)
        Me.lbl_controlePreliminaire_etatDiag_ok.TabIndex = 8
        Me.lbl_controlePreliminaire_etatDiag_ok.Text = "Etat satisfaisant"
        Me.lbl_controlePreliminaire_etatDiag_ok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lbl_controlePreliminaire_etatDiag_ok.Visible = False
        '
        'btn_controlePreliminaire_poursuivre
        '
        Me.btn_controlePreliminaire_poursuivre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controlePreliminaire_poursuivre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controlePreliminaire_poursuivre.ForeColor = System.Drawing.Color.White
        Me.btn_controlePreliminaire_poursuivre.Image = CType(resources.GetObject("btn_controlePreliminaire_poursuivre.Image"), System.Drawing.Image)
        Me.btn_controlePreliminaire_poursuivre.Location = New System.Drawing.Point(456, 72)
        Me.btn_controlePreliminaire_poursuivre.Name = "btn_controlePreliminaire_poursuivre"
        Me.btn_controlePreliminaire_poursuivre.Size = New System.Drawing.Size(128, 24)
        Me.btn_controlePreliminaire_poursuivre.TabIndex = 27
        Me.btn_controlePreliminaire_poursuivre.Text = "    Poursuivre"
        Me.btn_controlePreliminaire_poursuivre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_controlePreliminaire_poursuivre.Visible = False
        '
        'btn_controlePreliminaire_imprimerRapport
        '
        Me.btn_controlePreliminaire_imprimerRapport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controlePreliminaire_imprimerRapport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controlePreliminaire_imprimerRapport.ForeColor = System.Drawing.Color.White
        Me.btn_controlePreliminaire_imprimerRapport.Image = CType(resources.GetObject("btn_controlePreliminaire_imprimerRapport.Image"), System.Drawing.Image)
        Me.btn_controlePreliminaire_imprimerRapport.Location = New System.Drawing.Point(456, 72)
        Me.btn_controlePreliminaire_imprimerRapport.Name = "btn_controlePreliminaire_imprimerRapport"
        Me.btn_controlePreliminaire_imprimerRapport.Size = New System.Drawing.Size(180, 24)
        Me.btn_controlePreliminaire_imprimerRapport.TabIndex = 35
        Me.btn_controlePreliminaire_imprimerRapport.Text = "      Récapitulatif"
        Me.btn_controlePreliminaire_imprimerRapport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btn_controlePreliminaire_imprimerRapport.Visible = False
        '
        'btn_controlePreliminaire_annuler
        '
        Me.btn_controlePreliminaire_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controlePreliminaire_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_controlePreliminaire_annuler.Image = CType(resources.GetObject("btn_controlePreliminaire_annuler.Image"), System.Drawing.Image)
        Me.btn_controlePreliminaire_annuler.Location = New System.Drawing.Point(456, 72)
        Me.btn_controlePreliminaire_annuler.Name = "btn_controlePreliminaire_annuler"
        Me.btn_controlePreliminaire_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_controlePreliminaire_annuler.TabIndex = 28
        Me.btn_controlePreliminaire_annuler.Text = "    Annuler le diag"
        Me.btn_controlePreliminaire_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel3.Controls.Add(Me.btn_toutCocher)
        Me.Panel3.Controls.Add(Me.GroupBox_diagnostic_111)
        Me.Panel3.Controls.Add(Me.Label_diagnostic_11)
        Me.Panel3.Controls.Add(Me.GroupBox_diagnostic_112)
        Me.Panel3.Controls.Add(Me.GroupBox_diagnostic_113)
        Me.Panel3.Location = New System.Drawing.Point(0, 137)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(245, 488)
        Me.Panel3.TabIndex = 2
        '
        'btn_toutCocher
        '
        Me.btn_toutCocher.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_toutCocher.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_toutCocher.ForeColor = System.Drawing.Color.White
        Me.btn_toutCocher.Image = CType(resources.GetObject("btn_toutCocher.Image"), System.Drawing.Image)
        Me.btn_toutCocher.Location = New System.Drawing.Point(55, 464)
        Me.btn_toutCocher.Name = "btn_toutCocher"
        Me.btn_toutCocher.Size = New System.Drawing.Size(128, 24)
        Me.btn_toutCocher.TabIndex = 28
        Me.btn_toutCocher.Text = "    Tout cocher OK"
        Me.btn_toutCocher.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox_diagnostic_111
        '
        Me.GroupBox_diagnostic_111.Controls.Add(Me.RadioButton_diagnostic_1113)
        Me.GroupBox_diagnostic_111.Controls.Add(Me.RadioButton_diagnostic_1110)
        Me.GroupBox_diagnostic_111.Controls.Add(Me.RadioButton_diagnostic_1112)
        Me.GroupBox_diagnostic_111.Controls.Add(Me.RadioButton_diagnostic_1111)
        Me.GroupBox_diagnostic_111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_111.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_111.Location = New System.Drawing.Point(16, 48)
        Me.GroupBox_diagnostic_111.Name = "GroupBox_diagnostic_111"
        Me.GroupBox_diagnostic_111.Size = New System.Drawing.Size(224, 104)
        Me.GroupBox_diagnostic_111.TabIndex = 3
        Me.GroupBox_diagnostic_111.TabStop = False
        Me.GroupBox_diagnostic_111.Text = "1.1.1 - Fonctionnalité du pulvé"
        '
        'RadioButton_diagnostic_1113
        '
        Me.RadioButton_diagnostic_1113.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1113.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1113.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1113.cause1 = False
        Me.RadioButton_diagnostic_1113.cause2 = False
        Me.RadioButton_diagnostic_1113.cause3 = False
        Me.RadioButton_diagnostic_1113.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1113.Checked = False
        Me.RadioButton_diagnostic_1113.Code = Nothing
        Me.RadioButton_diagnostic_1113.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1113.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1113.Libelle = "1.1.1.3 - Défaut de remplissage"
        Me.RadioButton_diagnostic_1113.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1113.Location = New System.Drawing.Point(1, 56)
        Me.RadioButton_diagnostic_1113.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1113.Name = "RadioButton_diagnostic_1113"
        Me.RadioButton_diagnostic_1113.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1113.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1113.TabIndex = 7
        '
        'RadioButton_diagnostic_1110
        '
        Me.RadioButton_diagnostic_1110.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1110.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1110.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1110.cause1 = False
        Me.RadioButton_diagnostic_1110.cause2 = False
        Me.RadioButton_diagnostic_1110.cause3 = False
        Me.RadioButton_diagnostic_1110.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1110.Checked = False
        Me.RadioButton_diagnostic_1110.Code = Nothing
        Me.RadioButton_diagnostic_1110.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1110.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1110.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1110.Libelle = "OK"
        Me.RadioButton_diagnostic_1110.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1110.Location = New System.Drawing.Point(1, 72)
        Me.RadioButton_diagnostic_1110.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1110.Name = "RadioButton_diagnostic_1110"
        Me.RadioButton_diagnostic_1110.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1110.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1110.TabIndex = 6
        '
        'RadioButton_diagnostic_1112
        '
        Me.RadioButton_diagnostic_1112.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1112.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1112.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1112.cause1 = False
        Me.RadioButton_diagnostic_1112.cause2 = False
        Me.RadioButton_diagnostic_1112.cause3 = False
        Me.RadioButton_diagnostic_1112.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1112.Checked = False
        Me.RadioButton_diagnostic_1112.Code = Nothing
        Me.RadioButton_diagnostic_1112.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1112.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1112.Libelle = "1.1.1.2 - Fuites excessives"
        Me.RadioButton_diagnostic_1112.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1112.Location = New System.Drawing.Point(1, 40)
        Me.RadioButton_diagnostic_1112.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1112.Name = "RadioButton_diagnostic_1112"
        Me.RadioButton_diagnostic_1112.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1112.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1112.TabIndex = 5
        '
        'RadioButton_diagnostic_1111
        '
        Me.RadioButton_diagnostic_1111.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1111.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1111.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1111.cause1 = False
        Me.RadioButton_diagnostic_1111.cause2 = False
        Me.RadioButton_diagnostic_1111.cause3 = False
        Me.RadioButton_diagnostic_1111.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1111.Checked = False
        Me.RadioButton_diagnostic_1111.Code = Nothing
        Me.RadioButton_diagnostic_1111.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1111.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1111.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1111.Libelle = "1.1.1.1 - Non fonctionnement"
        Me.RadioButton_diagnostic_1111.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1111.Location = New System.Drawing.Point(1, 24)
        Me.RadioButton_diagnostic_1111.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1111.Name = "RadioButton_diagnostic_1111"
        Me.RadioButton_diagnostic_1111.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1111.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1111.TabIndex = 4
        '
        'Label_diagnostic_11
        '
        Me.Label_diagnostic_11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_11.Image = CType(resources.GetObject("Label_diagnostic_11.Image"), System.Drawing.Image)
        Me.Label_diagnostic_11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_diagnostic_11.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_11.Name = "Label_diagnostic_11"
        Me.Label_diagnostic_11.Size = New System.Drawing.Size(224, 25)
        Me.Label_diagnostic_11.TabIndex = 2
        Me.Label_diagnostic_11.Text = "     Etat du matériel"
        '
        'GroupBox_diagnostic_112
        '
        Me.GroupBox_diagnostic_112.Controls.Add(Me.RadioButton_diagnostic_1123)
        Me.GroupBox_diagnostic_112.Controls.Add(Me.RadioButton_diagnostic_1120)
        Me.GroupBox_diagnostic_112.Controls.Add(Me.RadioButton_diagnostic_1122)
        Me.GroupBox_diagnostic_112.Controls.Add(Me.RadioButton_diagnostic_1121)
        Me.GroupBox_diagnostic_112.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_112.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_112.Location = New System.Drawing.Point(16, 168)
        Me.GroupBox_diagnostic_112.Name = "GroupBox_diagnostic_112"
        Me.GroupBox_diagnostic_112.Size = New System.Drawing.Size(224, 104)
        Me.GroupBox_diagnostic_112.TabIndex = 7
        Me.GroupBox_diagnostic_112.TabStop = False
        Me.GroupBox_diagnostic_112.Text = "1.1.2 - Propreté matériel"
        '
        'RadioButton_diagnostic_1123
        '
        Me.RadioButton_diagnostic_1123.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1123.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1123.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1123.cause1 = False
        Me.RadioButton_diagnostic_1123.cause2 = False
        Me.RadioButton_diagnostic_1123.cause3 = False
        Me.RadioButton_diagnostic_1123.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1123.Checked = False
        Me.RadioButton_diagnostic_1123.Code = Nothing
        Me.RadioButton_diagnostic_1123.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1123.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1123.Libelle = "1.1.2.3 - Filtres non vérifiés"
        Me.RadioButton_diagnostic_1123.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1123.Location = New System.Drawing.Point(2, 56)
        Me.RadioButton_diagnostic_1123.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1123.Name = "RadioButton_diagnostic_1123"
        Me.RadioButton_diagnostic_1123.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1123.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1123.TabIndex = 7
        '
        'RadioButton_diagnostic_1120
        '
        Me.RadioButton_diagnostic_1120.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1120.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1120.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1120.cause1 = False
        Me.RadioButton_diagnostic_1120.cause2 = False
        Me.RadioButton_diagnostic_1120.cause3 = False
        Me.RadioButton_diagnostic_1120.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1120.Checked = False
        Me.RadioButton_diagnostic_1120.Code = Nothing
        Me.RadioButton_diagnostic_1120.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1120.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1120.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1120.Libelle = "OK"
        Me.RadioButton_diagnostic_1120.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1120.Location = New System.Drawing.Point(2, 72)
        Me.RadioButton_diagnostic_1120.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1120.Name = "RadioButton_diagnostic_1120"
        Me.RadioButton_diagnostic_1120.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1120.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1120.TabIndex = 6
        '
        'RadioButton_diagnostic_1122
        '
        Me.RadioButton_diagnostic_1122.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1122.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1122.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1122.cause1 = False
        Me.RadioButton_diagnostic_1122.cause2 = False
        Me.RadioButton_diagnostic_1122.cause3 = False
        Me.RadioButton_diagnostic_1122.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1122.Checked = False
        Me.RadioButton_diagnostic_1122.Code = Nothing
        Me.RadioButton_diagnostic_1122.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1122.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1122.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1122.Libelle = "1.1.2.2 - Intérieur sale"
        Me.RadioButton_diagnostic_1122.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1122.Location = New System.Drawing.Point(2, 40)
        Me.RadioButton_diagnostic_1122.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1122.Name = "RadioButton_diagnostic_1122"
        Me.RadioButton_diagnostic_1122.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1122.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1122.TabIndex = 5
        '
        'RadioButton_diagnostic_1121
        '
        Me.RadioButton_diagnostic_1121.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1121.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1121.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1121.cause1 = False
        Me.RadioButton_diagnostic_1121.cause2 = False
        Me.RadioButton_diagnostic_1121.cause3 = False
        Me.RadioButton_diagnostic_1121.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1121.Checked = False
        Me.RadioButton_diagnostic_1121.Code = Nothing
        Me.RadioButton_diagnostic_1121.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1121.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1121.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1121.Libelle = "1.1.2.1 - Extérieur sale"
        Me.RadioButton_diagnostic_1121.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1121.Location = New System.Drawing.Point(2, 24)
        Me.RadioButton_diagnostic_1121.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1121.Name = "RadioButton_diagnostic_1121"
        Me.RadioButton_diagnostic_1121.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1121.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1121.TabIndex = 4
        '
        'GroupBox_diagnostic_113
        '
        Me.GroupBox_diagnostic_113.Controls.Add(Me.RadioButton_diagnostic_1132)
        Me.GroupBox_diagnostic_113.Controls.Add(Me.RadioButton_diagnostic_1130)
        Me.GroupBox_diagnostic_113.Controls.Add(Me.RadioButton_diagnostic_1133)
        Me.GroupBox_diagnostic_113.Controls.Add(Me.RadioButton_diagnostic_1131)
        Me.GroupBox_diagnostic_113.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_113.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_113.Location = New System.Drawing.Point(16, 288)
        Me.GroupBox_diagnostic_113.Name = "GroupBox_diagnostic_113"
        Me.GroupBox_diagnostic_113.Size = New System.Drawing.Size(224, 104)
        Me.GroupBox_diagnostic_113.TabIndex = 8
        Me.GroupBox_diagnostic_113.TabStop = False
        Me.GroupBox_diagnostic_113.Text = "1.1.3 - Contexte"
        '
        'RadioButton_diagnostic_1132
        '
        Me.RadioButton_diagnostic_1132.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1132.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_1132.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1132.cause1 = False
        Me.RadioButton_diagnostic_1132.cause2 = False
        Me.RadioButton_diagnostic_1132.cause3 = False
        Me.RadioButton_diagnostic_1132.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1132.Checked = False
        Me.RadioButton_diagnostic_1132.Code = Nothing
        Me.RadioButton_diagnostic_1132.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_1132.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1132.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1132.Libelle = "1.1.3.2 - Non suivi de l’inspection"
        Me.RadioButton_diagnostic_1132.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1132.Location = New System.Drawing.Point(2, 40)
        Me.RadioButton_diagnostic_1132.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1132.Name = "RadioButton_diagnostic_1132"
        Me.RadioButton_diagnostic_1132.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1132.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1132.TabIndex = 7
        '
        'RadioButton_diagnostic_1130
        '
        Me.RadioButton_diagnostic_1130.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1130.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1130.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1130.cause1 = False
        Me.RadioButton_diagnostic_1130.cause2 = False
        Me.RadioButton_diagnostic_1130.cause3 = False
        Me.RadioButton_diagnostic_1130.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1130.Checked = False
        Me.RadioButton_diagnostic_1130.Code = Nothing
        Me.RadioButton_diagnostic_1130.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1130.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1130.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1130.Libelle = "OK"
        Me.RadioButton_diagnostic_1130.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1130.Location = New System.Drawing.Point(2, 72)
        Me.RadioButton_diagnostic_1130.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1130.Name = "RadioButton_diagnostic_1130"
        Me.RadioButton_diagnostic_1130.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1130.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1130.TabIndex = 6
        '
        'RadioButton_diagnostic_1133
        '
        Me.RadioButton_diagnostic_1133.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1133.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1133.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1133.cause1 = False
        Me.RadioButton_diagnostic_1133.cause2 = False
        Me.RadioButton_diagnostic_1133.cause3 = False
        Me.RadioButton_diagnostic_1133.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1133.Checked = False
        Me.RadioButton_diagnostic_1133.Code = Nothing
        Me.RadioButton_diagnostic_1133.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1133.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1133.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1133.Libelle = "1.1.3.3 - Tracteur absent"
        Me.RadioButton_diagnostic_1133.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1133.Location = New System.Drawing.Point(2, 56)
        Me.RadioButton_diagnostic_1133.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1133.Name = "RadioButton_diagnostic_1133"
        Me.RadioButton_diagnostic_1133.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1133.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1133.TabIndex = 5
        '
        'RadioButton_diagnostic_1131
        '
        Me.RadioButton_diagnostic_1131.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1131.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_1131.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1131.cause1 = False
        Me.RadioButton_diagnostic_1131.cause2 = False
        Me.RadioButton_diagnostic_1131.cause3 = False
        Me.RadioButton_diagnostic_1131.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1131.Checked = False
        Me.RadioButton_diagnostic_1131.Code = Nothing
        Me.RadioButton_diagnostic_1131.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        Me.RadioButton_diagnostic_1131.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1131.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1131.Libelle = "1.1.3.1 - Absence de l’agriculteur"
        Me.RadioButton_diagnostic_1131.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1131.Location = New System.Drawing.Point(2, 24)
        Me.RadioButton_diagnostic_1131.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1131.Name = "RadioButton_diagnostic_1131"
        Me.RadioButton_diagnostic_1131.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1131.Size = New System.Drawing.Size(217, 16)
        Me.RadioButton_diagnostic_1131.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label_diagnostic_1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(956, 136)
        Me.Panel2.TabIndex = 1
        '
        'Label_diagnostic_1
        '
        Me.Label_diagnostic_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_1.Image = CType(resources.GetObject("Label_diagnostic_1.Image"), System.Drawing.Image)
        Me.Label_diagnostic_1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.Label_diagnostic_1.Location = New System.Drawing.Point(16, 16)
        Me.Label_diagnostic_1.Name = "Label_diagnostic_1"
        Me.Label_diagnostic_1.Size = New System.Drawing.Size(648, 32)
        Me.Label_diagnostic_1.TabIndex = 2
        Me.Label_diagnostic_1.Text = "     Examens préliminaires"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(858, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(76, 84)
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(68, 26)
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(67, 22)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.diagPreliminaire_client_proprioSiren)
        Me.GroupBox1.Controls.Add(Me.diagPreliminaire_client_raisonSociale)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(24, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(312, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Client"
        '
        'diagPreliminaire_client_proprioSiren
        '
        Me.diagPreliminaire_client_proprioSiren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagPreliminaire_client_proprioSiren.Location = New System.Drawing.Point(8, 48)
        Me.diagPreliminaire_client_proprioSiren.Name = "diagPreliminaire_client_proprioSiren"
        Me.diagPreliminaire_client_proprioSiren.Size = New System.Drawing.Size(296, 26)
        Me.diagPreliminaire_client_proprioSiren.TabIndex = 1
        Me.diagPreliminaire_client_proprioSiren.Text = "M. Fegeant Pierre - N° SIREN : 17756237125"
        '
        'diagPreliminaire_client_raisonSociale
        '
        Me.diagPreliminaire_client_raisonSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagPreliminaire_client_raisonSociale.Location = New System.Drawing.Point(8, 16)
        Me.diagPreliminaire_client_raisonSociale.Name = "diagPreliminaire_client_raisonSociale"
        Me.diagPreliminaire_client_raisonSociale.Size = New System.Drawing.Size(296, 26)
        Me.diagPreliminaire_client_raisonSociale.TabIndex = 0
        Me.diagPreliminaire_client_raisonSociale.Text = "Exploitation des monts dorés"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.diagPreliminaire_pulve_numNatio)
        Me.GroupBox2.Controls.Add(Me.diagPreliminaire_pulve_marqueModele)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(352, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(312, 80)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pulvérisateur"
        '
        'diagPreliminaire_pulve_numNatio
        '
        Me.diagPreliminaire_pulve_numNatio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagPreliminaire_pulve_numNatio.Location = New System.Drawing.Point(128, 24)
        Me.diagPreliminaire_pulve_numNatio.Name = "diagPreliminaire_pulve_numNatio"
        Me.diagPreliminaire_pulve_numNatio.Size = New System.Drawing.Size(176, 16)
        Me.diagPreliminaire_pulve_numNatio.TabIndex = 3
        '
        'diagPreliminaire_pulve_marqueModele
        '
        Me.diagPreliminaire_pulve_marqueModele.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diagPreliminaire_pulve_marqueModele.Location = New System.Drawing.Point(128, 48)
        Me.diagPreliminaire_pulve_marqueModele.Name = "diagPreliminaire_pulve_marqueModele"
        Me.diagPreliminaire_pulve_marqueModele.Size = New System.Drawing.Size(176, 16)
        Me.diagPreliminaire_pulve_marqueModele.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Marque modèle : "
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(16, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 16)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Num. National : "
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel4.Controls.Add(Me.GroupBox_diagnostic_123)
        Me.Panel4.Controls.Add(Me.GroupBox_diagnostic_125)
        Me.Panel4.Controls.Add(Me.GroupBox_diagnostic_122)
        Me.Panel4.Controls.Add(Me.GroupBox_diagnostic_124)
        Me.Panel4.Controls.Add(Me.GroupBox_diagnostic_121)
        Me.Panel4.Controls.Add(Me.Label_diagnostic_12)
        Me.Panel4.Location = New System.Drawing.Point(246, 137)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(710, 391)
        Me.Panel4.TabIndex = 3
        '
        'GroupBox_diagnostic_123
        '
        Me.GroupBox_diagnostic_123.Controls.Add(Me.RadioButton_diagnostic_1230)
        Me.GroupBox_diagnostic_123.Controls.Add(Me.RadioButton_diagnostic_1232)
        Me.GroupBox_diagnostic_123.Controls.Add(Me.RadioButton_diagnostic_1231)
        Me.GroupBox_diagnostic_123.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_123.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_123.Location = New System.Drawing.Point(8, 296)
        Me.GroupBox_diagnostic_123.Name = "GroupBox_diagnostic_123"
        Me.GroupBox_diagnostic_123.Size = New System.Drawing.Size(354, 88)
        Me.GroupBox_diagnostic_123.TabIndex = 12
        Me.GroupBox_diagnostic_123.TabStop = False
        Me.GroupBox_diagnostic_123.Text = "1.2.3 - Transmission mécanique au niveau du pulvérisateur"
        '
        'RadioButton_diagnostic_1230
        '
        Me.RadioButton_diagnostic_1230.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1230.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1230.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1230.cause1 = False
        Me.RadioButton_diagnostic_1230.cause2 = False
        Me.RadioButton_diagnostic_1230.cause3 = False
        Me.RadioButton_diagnostic_1230.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1230.Checked = False
        Me.RadioButton_diagnostic_1230.Code = Nothing
        Me.RadioButton_diagnostic_1230.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1230.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1230.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1230.Libelle = "OK"
        Me.RadioButton_diagnostic_1230.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1230.Location = New System.Drawing.Point(3, 56)
        Me.RadioButton_diagnostic_1230.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1230.Name = "RadioButton_diagnostic_1230"
        Me.RadioButton_diagnostic_1230.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1230.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1230.TabIndex = 6
        '
        'RadioButton_diagnostic_1232
        '
        Me.RadioButton_diagnostic_1232.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1232.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1232.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1232.cause1 = False
        Me.RadioButton_diagnostic_1232.cause2 = False
        Me.RadioButton_diagnostic_1232.cause3 = False
        Me.RadioButton_diagnostic_1232.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1232.Checked = False
        Me.RadioButton_diagnostic_1232.Code = Nothing
        Me.RadioButton_diagnostic_1232.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1232.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1232.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1232.Libelle = "1.2.3.2 - Protection insuffisante d’autre(s) pièce(s) mobile(s)"
        Me.RadioButton_diagnostic_1232.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1232.Location = New System.Drawing.Point(3, 40)
        Me.RadioButton_diagnostic_1232.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1232.Name = "RadioButton_diagnostic_1232"
        Me.RadioButton_diagnostic_1232.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1232.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1232.TabIndex = 5
        '
        'RadioButton_diagnostic_1231
        '
        Me.RadioButton_diagnostic_1231.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1231.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1231.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1231.cause1 = False
        Me.RadioButton_diagnostic_1231.cause2 = False
        Me.RadioButton_diagnostic_1231.cause3 = False
        Me.RadioButton_diagnostic_1231.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1231.Checked = False
        Me.RadioButton_diagnostic_1231.Code = Nothing
        Me.RadioButton_diagnostic_1231.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1231.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1231.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1231.Libelle = "1.2.3.1 - Protection insuffisante d’arbre(s) tournant(s)"
        Me.RadioButton_diagnostic_1231.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1231.Location = New System.Drawing.Point(3, 24)
        Me.RadioButton_diagnostic_1231.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1231.Name = "RadioButton_diagnostic_1231"
        Me.RadioButton_diagnostic_1231.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1231.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1231.TabIndex = 4
        '
        'GroupBox_diagnostic_125
        '
        Me.GroupBox_diagnostic_125.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_125.Controls.Add(Me.RadioButton_diagnostic_1250)
        Me.GroupBox_diagnostic_125.Controls.Add(Me.RadioButton_diagnostic_1251)
        Me.GroupBox_diagnostic_125.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_125.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_125.Location = New System.Drawing.Point(368, 232)
        Me.GroupBox_diagnostic_125.Name = "GroupBox_diagnostic_125"
        Me.GroupBox_diagnostic_125.Size = New System.Drawing.Size(330, 72)
        Me.GroupBox_diagnostic_125.TabIndex = 11
        Me.GroupBox_diagnostic_125.TabStop = False
        Me.GroupBox_diagnostic_125.Text = "1.2.5 - Débrayage du/des ventilateur(s)"
        '
        'RadioButton_diagnostic_1250
        '
        Me.RadioButton_diagnostic_1250.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1250.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1250.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1250.cause1 = False
        Me.RadioButton_diagnostic_1250.cause2 = False
        Me.RadioButton_diagnostic_1250.cause3 = False
        Me.RadioButton_diagnostic_1250.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1250.Checked = False
        Me.RadioButton_diagnostic_1250.Code = Nothing
        Me.RadioButton_diagnostic_1250.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1250.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1250.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1250.Libelle = "OK"
        Me.RadioButton_diagnostic_1250.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1250.Location = New System.Drawing.Point(3, 40)
        Me.RadioButton_diagnostic_1250.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1250.Name = "RadioButton_diagnostic_1250"
        Me.RadioButton_diagnostic_1250.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1250.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1250.TabIndex = 6
        '
        'RadioButton_diagnostic_1251
        '
        Me.RadioButton_diagnostic_1251.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1251.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1251.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1251.cause1 = False
        Me.RadioButton_diagnostic_1251.cause2 = False
        Me.RadioButton_diagnostic_1251.cause3 = False
        Me.RadioButton_diagnostic_1251.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1251.Checked = False
        Me.RadioButton_diagnostic_1251.Code = Nothing
        Me.RadioButton_diagnostic_1251.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1251.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1251.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1251.Libelle = "1.2.5.1 - Débrayage impossible"
        Me.RadioButton_diagnostic_1251.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1251.Location = New System.Drawing.Point(3, 24)
        Me.RadioButton_diagnostic_1251.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1251.Name = "RadioButton_diagnostic_1251"
        Me.RadioButton_diagnostic_1251.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1251.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1251.TabIndex = 5
        '
        'GroupBox_diagnostic_122
        '
        Me.GroupBox_diagnostic_122.Controls.Add(Me.RadioButton_diagnostic_1224)
        Me.GroupBox_diagnostic_122.Controls.Add(Me.RadioButton_diagnostic_1223)
        Me.GroupBox_diagnostic_122.Controls.Add(Me.RadioButton_diagnostic_1220)
        Me.GroupBox_diagnostic_122.Controls.Add(Me.RadioButton_diagnostic_1222)
        Me.GroupBox_diagnostic_122.Controls.Add(Me.RadioButton_diagnostic_1221)
        Me.GroupBox_diagnostic_122.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_122.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_122.Location = New System.Drawing.Point(8, 168)
        Me.GroupBox_diagnostic_122.Name = "GroupBox_diagnostic_122"
        Me.GroupBox_diagnostic_122.Size = New System.Drawing.Size(354, 120)
        Me.GroupBox_diagnostic_122.TabIndex = 10
        Me.GroupBox_diagnostic_122.TabStop = False
        Me.GroupBox_diagnostic_122.Text = "1.2.2 - Transmission mécanique entre tracteur et pulvérisateur"
        '
        'RadioButton_diagnostic_1224
        '
        Me.RadioButton_diagnostic_1224.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1224.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1224.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1224.cause1 = False
        Me.RadioButton_diagnostic_1224.cause2 = False
        Me.RadioButton_diagnostic_1224.cause3 = False
        Me.RadioButton_diagnostic_1224.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1224.Checked = False
        Me.RadioButton_diagnostic_1224.Code = Nothing
        Me.RadioButton_diagnostic_1224.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1224.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1224.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1224.Libelle = "1.2.2.4 - Protection insuffisante accouplement côté pulvé."
        Me.RadioButton_diagnostic_1224.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1224.Location = New System.Drawing.Point(3, 72)
        Me.RadioButton_diagnostic_1224.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1224.Name = "RadioButton_diagnostic_1224"
        Me.RadioButton_diagnostic_1224.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1224.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1224.TabIndex = 8
        '
        'RadioButton_diagnostic_1223
        '
        Me.RadioButton_diagnostic_1223.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1223.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1223.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1223.cause1 = False
        Me.RadioButton_diagnostic_1223.cause2 = False
        Me.RadioButton_diagnostic_1223.cause3 = False
        Me.RadioButton_diagnostic_1223.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1223.Checked = False
        Me.RadioButton_diagnostic_1223.Code = Nothing
        Me.RadioButton_diagnostic_1223.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1223.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1223.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1223.Libelle = "1.2.2.3 - Protection insuffisante accouplement côté tracteur"
        Me.RadioButton_diagnostic_1223.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1223.Location = New System.Drawing.Point(3, 56)
        Me.RadioButton_diagnostic_1223.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1223.Name = "RadioButton_diagnostic_1223"
        Me.RadioButton_diagnostic_1223.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1223.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1223.TabIndex = 7
        '
        'RadioButton_diagnostic_1220
        '
        Me.RadioButton_diagnostic_1220.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1220.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1220.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1220.cause1 = False
        Me.RadioButton_diagnostic_1220.cause2 = False
        Me.RadioButton_diagnostic_1220.cause3 = False
        Me.RadioButton_diagnostic_1220.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1220.Checked = False
        Me.RadioButton_diagnostic_1220.Code = Nothing
        Me.RadioButton_diagnostic_1220.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1220.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1220.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1220.Libelle = "OK"
        Me.RadioButton_diagnostic_1220.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1220.Location = New System.Drawing.Point(3, 88)
        Me.RadioButton_diagnostic_1220.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1220.Name = "RadioButton_diagnostic_1220"
        Me.RadioButton_diagnostic_1220.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1220.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1220.TabIndex = 6
        '
        'RadioButton_diagnostic_1222
        '
        Me.RadioButton_diagnostic_1222.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1222.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1222.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1222.cause1 = False
        Me.RadioButton_diagnostic_1222.cause2 = False
        Me.RadioButton_diagnostic_1222.cause3 = False
        Me.RadioButton_diagnostic_1222.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1222.Checked = False
        Me.RadioButton_diagnostic_1222.Code = Nothing
        Me.RadioButton_diagnostic_1222.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1222.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1222.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1222.Libelle = "1.2.2.2 - Immobilisation impossible ou douteuse de la protection"
        Me.RadioButton_diagnostic_1222.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1222.Location = New System.Drawing.Point(3, 40)
        Me.RadioButton_diagnostic_1222.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1222.Name = "RadioButton_diagnostic_1222"
        Me.RadioButton_diagnostic_1222.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1222.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1222.TabIndex = 5
        '
        'RadioButton_diagnostic_1221
        '
        Me.RadioButton_diagnostic_1221.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1221.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1221.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1221.cause1 = False
        Me.RadioButton_diagnostic_1221.cause2 = False
        Me.RadioButton_diagnostic_1221.cause3 = False
        Me.RadioButton_diagnostic_1221.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1221.Checked = False
        Me.RadioButton_diagnostic_1221.Code = Nothing
        Me.RadioButton_diagnostic_1221.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1221.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1221.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1221.Libelle = "1.2.2.1 - Protection insuffisante de l'arbre tournant"
        Me.RadioButton_diagnostic_1221.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1221.Location = New System.Drawing.Point(3, 24)
        Me.RadioButton_diagnostic_1221.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1221.Name = "RadioButton_diagnostic_1221"
        Me.RadioButton_diagnostic_1221.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1221.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1221.TabIndex = 4
        '
        'GroupBox_diagnostic_124
        '
        Me.GroupBox_diagnostic_124.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1247)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1246)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1245)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1244)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1243)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1240)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1242)
        Me.GroupBox_diagnostic_124.Controls.Add(Me.RadioButton_diagnostic_1241)
        Me.GroupBox_diagnostic_124.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_124.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_124.Location = New System.Drawing.Point(368, 48)
        Me.GroupBox_diagnostic_124.Name = "GroupBox_diagnostic_124"
        Me.GroupBox_diagnostic_124.Size = New System.Drawing.Size(330, 168)
        Me.GroupBox_diagnostic_124.TabIndex = 9
        Me.GroupBox_diagnostic_124.TabStop = False
        Me.GroupBox_diagnostic_124.Text = "1.2.4 - Fixations au châssis"
        '
        'RadioButton_diagnostic_1247
        '
        Me.RadioButton_diagnostic_1247.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1247.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1247.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1247.cause1 = False
        Me.RadioButton_diagnostic_1247.cause2 = False
        Me.RadioButton_diagnostic_1247.cause3 = False
        Me.RadioButton_diagnostic_1247.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1247.Checked = False
        Me.RadioButton_diagnostic_1247.Code = Nothing
        Me.RadioButton_diagnostic_1247.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1247.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1247.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1247.Libelle = "1.2.4.7 - Blocage des rampes transport non assuré"
        Me.RadioButton_diagnostic_1247.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1247.Location = New System.Drawing.Point(3, 120)
        Me.RadioButton_diagnostic_1247.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1247.Name = "RadioButton_diagnostic_1247"
        Me.RadioButton_diagnostic_1247.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1247.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1247.TabIndex = 11
        '
        'RadioButton_diagnostic_1246
        '
        Me.RadioButton_diagnostic_1246.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1246.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1246.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1246.cause1 = False
        Me.RadioButton_diagnostic_1246.cause2 = False
        Me.RadioButton_diagnostic_1246.cause3 = False
        Me.RadioButton_diagnostic_1246.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1246.Checked = False
        Me.RadioButton_diagnostic_1246.Code = Nothing
        Me.RadioButton_diagnostic_1246.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1246.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1246.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1246.Libelle = "1.2.4.6 - Support de rampe/distribution non solidaire du châssis"
        Me.RadioButton_diagnostic_1246.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1246.Location = New System.Drawing.Point(3, 104)
        Me.RadioButton_diagnostic_1246.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1246.Name = "RadioButton_diagnostic_1246"
        Me.RadioButton_diagnostic_1246.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1246.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1246.TabIndex = 10
        '
        'RadioButton_diagnostic_1245
        '
        Me.RadioButton_diagnostic_1245.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1245.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1245.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1245.cause1 = False
        Me.RadioButton_diagnostic_1245.cause2 = False
        Me.RadioButton_diagnostic_1245.cause3 = False
        Me.RadioButton_diagnostic_1245.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1245.Checked = False
        Me.RadioButton_diagnostic_1245.Code = Nothing
        Me.RadioButton_diagnostic_1245.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1245.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1245.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1245.Libelle = "1.2.4.5 - Modification structurelle importante"
        Me.RadioButton_diagnostic_1245.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1245.Location = New System.Drawing.Point(3, 88)
        Me.RadioButton_diagnostic_1245.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1245.Name = "RadioButton_diagnostic_1245"
        Me.RadioButton_diagnostic_1245.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1245.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1245.TabIndex = 9
        '
        'RadioButton_diagnostic_1244
        '
        Me.RadioButton_diagnostic_1244.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1244.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1244.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1244.cause1 = False
        Me.RadioButton_diagnostic_1244.cause2 = False
        Me.RadioButton_diagnostic_1244.cause3 = False
        Me.RadioButton_diagnostic_1244.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1244.Checked = False
        Me.RadioButton_diagnostic_1244.Code = Nothing
        Me.RadioButton_diagnostic_1244.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1244.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1244.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1244.Libelle = "1.2.4.4 - Ventilateur non solidaire du châssis"
        Me.RadioButton_diagnostic_1244.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1244.Location = New System.Drawing.Point(3, 72)
        Me.RadioButton_diagnostic_1244.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1244.Name = "RadioButton_diagnostic_1244"
        Me.RadioButton_diagnostic_1244.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1244.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1244.TabIndex = 8
        '
        'RadioButton_diagnostic_1243
        '
        Me.RadioButton_diagnostic_1243.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1243.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1243.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1243.cause1 = False
        Me.RadioButton_diagnostic_1243.cause2 = False
        Me.RadioButton_diagnostic_1243.cause3 = False
        Me.RadioButton_diagnostic_1243.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1243.Checked = False
        Me.RadioButton_diagnostic_1243.Code = Nothing
        Me.RadioButton_diagnostic_1243.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1243.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1243.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1243.Libelle = "1.2.4.3 - Elément de structure non solidaire du châssis"
        Me.RadioButton_diagnostic_1243.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1243.Location = New System.Drawing.Point(3, 56)
        Me.RadioButton_diagnostic_1243.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1243.Name = "RadioButton_diagnostic_1243"
        Me.RadioButton_diagnostic_1243.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1243.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1243.TabIndex = 7
        '
        'RadioButton_diagnostic_1240
        '
        Me.RadioButton_diagnostic_1240.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1240.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1240.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1240.cause1 = False
        Me.RadioButton_diagnostic_1240.cause2 = False
        Me.RadioButton_diagnostic_1240.cause3 = False
        Me.RadioButton_diagnostic_1240.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1240.Checked = False
        Me.RadioButton_diagnostic_1240.Code = Nothing
        Me.RadioButton_diagnostic_1240.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1240.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1240.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1240.Libelle = "OK"
        Me.RadioButton_diagnostic_1240.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1240.Location = New System.Drawing.Point(3, 136)
        Me.RadioButton_diagnostic_1240.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1240.Name = "RadioButton_diagnostic_1240"
        Me.RadioButton_diagnostic_1240.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1240.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1240.TabIndex = 6
        '
        'RadioButton_diagnostic_1242
        '
        Me.RadioButton_diagnostic_1242.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1242.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1242.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1242.cause1 = False
        Me.RadioButton_diagnostic_1242.cause2 = False
        Me.RadioButton_diagnostic_1242.cause3 = False
        Me.RadioButton_diagnostic_1242.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1242.Checked = False
        Me.RadioButton_diagnostic_1242.Code = Nothing
        Me.RadioButton_diagnostic_1242.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1242.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1242.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1242.Libelle = "1.2.4.2 - Pompe non solidaire du châssis"
        Me.RadioButton_diagnostic_1242.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1242.Location = New System.Drawing.Point(3, 40)
        Me.RadioButton_diagnostic_1242.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1242.Name = "RadioButton_diagnostic_1242"
        Me.RadioButton_diagnostic_1242.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1242.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1242.TabIndex = 5
        '
        'RadioButton_diagnostic_1241
        '
        Me.RadioButton_diagnostic_1241.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1241.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1241.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1241.cause1 = False
        Me.RadioButton_diagnostic_1241.cause2 = False
        Me.RadioButton_diagnostic_1241.cause3 = False
        Me.RadioButton_diagnostic_1241.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1241.Checked = False
        Me.RadioButton_diagnostic_1241.Code = Nothing
        Me.RadioButton_diagnostic_1241.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1241.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1241.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1241.Libelle = "1.2.4.1 - Cuve non solidaire du châssis"
        Me.RadioButton_diagnostic_1241.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1241.Location = New System.Drawing.Point(3, 24)
        Me.RadioButton_diagnostic_1241.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1241.Name = "RadioButton_diagnostic_1241"
        Me.RadioButton_diagnostic_1241.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1241.Size = New System.Drawing.Size(321, 16)
        Me.RadioButton_diagnostic_1241.TabIndex = 4
        '
        'GroupBox_diagnostic_121
        '
        Me.GroupBox_diagnostic_121.Controls.Add(Me.RadioButton_diagnostic_1213)
        Me.GroupBox_diagnostic_121.Controls.Add(Me.RadioButton_diagnostic_1210)
        Me.GroupBox_diagnostic_121.Controls.Add(Me.RadioButton_diagnostic_1212)
        Me.GroupBox_diagnostic_121.Controls.Add(Me.RadioButton_diagnostic_1211)
        Me.GroupBox_diagnostic_121.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox_diagnostic_121.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox_diagnostic_121.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox_diagnostic_121.Name = "GroupBox_diagnostic_121"
        Me.GroupBox_diagnostic_121.Size = New System.Drawing.Size(354, 104)
        Me.GroupBox_diagnostic_121.TabIndex = 5
        Me.GroupBox_diagnostic_121.TabStop = False
        Me.GroupBox_diagnostic_121.Text = "1.2.1 - Transmission hydraulique entre tracteur et pulvérisateur"
        '
        'RadioButton_diagnostic_1213
        '
        Me.RadioButton_diagnostic_1213.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1213.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1213.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1213.cause1 = False
        Me.RadioButton_diagnostic_1213.cause2 = False
        Me.RadioButton_diagnostic_1213.cause3 = False
        Me.RadioButton_diagnostic_1213.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1213.Checked = False
        Me.RadioButton_diagnostic_1213.Code = Nothing
        Me.RadioButton_diagnostic_1213.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1213.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1213.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1213.Libelle = "1.2.1.3 - Pliures excessives"
        Me.RadioButton_diagnostic_1213.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1213.Location = New System.Drawing.Point(3, 56)
        Me.RadioButton_diagnostic_1213.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1213.Name = "RadioButton_diagnostic_1213"
        Me.RadioButton_diagnostic_1213.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1213.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1213.TabIndex = 6
        '
        'RadioButton_diagnostic_1210
        '
        Me.RadioButton_diagnostic_1210.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1210.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1210.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1210.cause1 = False
        Me.RadioButton_diagnostic_1210.cause2 = False
        Me.RadioButton_diagnostic_1210.cause3 = False
        Me.RadioButton_diagnostic_1210.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1210.Checked = False
        Me.RadioButton_diagnostic_1210.Code = Nothing
        Me.RadioButton_diagnostic_1210.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
        Me.RadioButton_diagnostic_1210.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1210.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1210.Libelle = "OK"
        Me.RadioButton_diagnostic_1210.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1210.Location = New System.Drawing.Point(3, 72)
        Me.RadioButton_diagnostic_1210.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1210.Name = "RadioButton_diagnostic_1210"
        Me.RadioButton_diagnostic_1210.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1210.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1210.TabIndex = 7
        '
        'RadioButton_diagnostic_1212
        '
        Me.RadioButton_diagnostic_1212.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1212.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1212.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1212.cause1 = False
        Me.RadioButton_diagnostic_1212.cause2 = False
        Me.RadioButton_diagnostic_1212.cause3 = False
        Me.RadioButton_diagnostic_1212.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1212.Checked = False
        Me.RadioButton_diagnostic_1212.Code = Nothing
        Me.RadioButton_diagnostic_1212.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1212.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1212.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1212.Libelle = "1.2.1.2 - Usure importante"
        Me.RadioButton_diagnostic_1212.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1212.Location = New System.Drawing.Point(3, 40)
        Me.RadioButton_diagnostic_1212.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1212.Name = "RadioButton_diagnostic_1212"
        Me.RadioButton_diagnostic_1212.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1212.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1212.TabIndex = 5
        '
        'RadioButton_diagnostic_1211
        '
        Me.RadioButton_diagnostic_1211.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton_diagnostic_1211.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1211.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.NONE
        Me.RadioButton_diagnostic_1211.cause1 = False
        Me.RadioButton_diagnostic_1211.cause2 = False
        Me.RadioButton_diagnostic_1211.cause3 = False
        Me.RadioButton_diagnostic_1211.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1211.Checked = False
        Me.RadioButton_diagnostic_1211.Code = Nothing
        Me.RadioButton_diagnostic_1211.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
        Me.RadioButton_diagnostic_1211.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton_diagnostic_1211.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RadioButton_diagnostic_1211.Libelle = "1.2.1.1 - Dispositif anti-décrochage défectueux"
        Me.RadioButton_diagnostic_1211.LibelleLong = Nothing
        Me.RadioButton_diagnostic_1211.Location = New System.Drawing.Point(3, 24)
        Me.RadioButton_diagnostic_1211.Margin = New System.Windows.Forms.Padding(0)
        Me.RadioButton_diagnostic_1211.Name = "RadioButton_diagnostic_1211"
        Me.RadioButton_diagnostic_1211.NiveauCause_max = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.ZERO
        Me.RadioButton_diagnostic_1211.Size = New System.Drawing.Size(348, 16)
        Me.RadioButton_diagnostic_1211.TabIndex = 4
        '
        'Label_diagnostic_12
        '
        Me.Label_diagnostic_12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label_diagnostic_12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label_diagnostic_12.Image = CType(resources.GetObject("Label_diagnostic_12.Image"), System.Drawing.Image)
        Me.Label_diagnostic_12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label_diagnostic_12.Location = New System.Drawing.Point(8, 8)
        Me.Label_diagnostic_12.Name = "Label_diagnostic_12"
        Me.Label_diagnostic_12.Size = New System.Drawing.Size(368, 25)
        Me.Label_diagnostic_12.TabIndex = 4
        Me.Label_diagnostic_12.Text = "     Eléments de sécurité"
        '
        'controle_preliminaire
        '
        Me.ClientSize = New System.Drawing.Size(955, 623)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "controle_preliminaire"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Crodip  .::. Contrôle préliminaire"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.GroupBox_diagnostic_111.ResumeLayout(False)
        Me.GroupBox_diagnostic_112.ResumeLayout(False)
        Me.GroupBox_diagnostic_113.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.GroupBox_diagnostic_123.ResumeLayout(False)
        Me.GroupBox_diagnostic_125.ResumeLayout(False)
        Me.GroupBox_diagnostic_122.ResumeLayout(False)
        Me.GroupBox_diagnostic_124.ResumeLayout(False)
        Me.GroupBox_diagnostic_121.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Variables "

    'Fonctions de traitement des RadioButton
    Dim nbRadioButton_green As Integer = 0
    Dim nbRadioButton_orange As Integer = 0
    Dim nbRadioButton_red As Integer = 0

#End Region

#Region " Au chargement "

    ' Chargement du form
    Private Sub controle_preliminaire_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Propriété a mettre obligatoirement par programme
        Me.WindowState = FormWindowState.Maximized
        Me.ControlBox = False
        m_bDuringLoad = True
        globFormControlePreliminaire = Me

        Me.Cursor = Cursors.WaitCursor
        'Lecture du paramétrage associé au pulvérisateur
        m_oParamdiag = m_Pulverisateur.getParamDiag()
        If String.IsNullOrEmpty(m_oParamdiag.fichierConfig) Then
            CSDebug.dispFatal("Impossible de Trouver le fichier de configuration du controle pour le Pulve type = " & m_Pulverisateur.type & ", categorie = " & m_Pulverisateur.categorie)
        End If
        Dim sParamFile As String = My.Settings.RepertoireParametres & "/" & m_oParamdiag.fichierConfig
        If Not System.IO.File.Exists(sParamFile) Then
            CSDebug.dispFatal("le fichier de configuration du controle pour le Pulve type = " & m_Pulverisateur.type & ", categorie = " & m_Pulverisateur.categorie & " Fichier de config " & sParamFile & "n'existe pas")
        End If
        Dim bRead As Boolean
        bRead = LectureParametresAffichage(sParamFile)
        If Not bRead Then
            CSDebug.dispFatal("Impossible de lire le fichier de configuration du controle pour le Pulve type = " & m_Pulverisateur.type & ", categorie = " & m_Pulverisateur.categorie & "fichier de config " & sParamFile)
        End If



        ' Init
        lbl_controlePreliminaire_etatDiag_ok.Visible = False
        lbl_controlePreliminaire_etatDiag_nok.Visible = False
        btn_controlePreliminaire_annuler.Visible = False
        btn_controlePreliminaire_imprimerRapport.Visible = False
        btn_controlePreliminaire_poursuivre.Visible = False

        ' Affichage des informations du client (i faut prendre les données dans le Diag pour avoir les infos au moment du diag)
        diagPreliminaire_client_raisonSociale.Text = m_Diagnostic.proprietaireRaisonSociale
        diagPreliminaire_client_proprioSiren.Text = "M. " & m_Diagnostic.proprietaireNom & " " & m_Diagnostic.proprietairePrenom & " - N° SIREN : " & m_Diagnostic.proprietaireNumeroSiren
        ' Affichage des informations du pulvé
        diagPreliminaire_pulve_numNatio.Text = m_Pulverisateur.numeroNational
        diagPreliminaire_pulve_marqueModele.Text = m_Pulverisateur.marque & " - " & m_Pulverisateur.modele

        ' On charge les infos du diagnostic
        'Il faut désactiver le duringLoad , car ce sont les Click qui déclenche le bouton "poursuivre"
        m_bDuringLoad = False
        If m_Mode <> DiagMode.CTRL_COMPLET Then
            loadExistingDiag()
        End If

        btn_controlePreliminaire_poursuivre.Visible = False
        btn_toutCocher.Visible = False

        Select Case m_Mode
            Case DiagMode.CTRL_COMPLET
                btn_toutCocher.Visible = True
            Case DiagMode.CTRL_CV
                btn_controlePreliminaire_poursuivre.Visible = True
            Case DiagMode.CTRL_VISU
                btn_controlePreliminaire_poursuivre.Visible = True
                CSForm.disableAllCheckBox(Me)
        End Select
        Me.Cursor = Cursors.Default
    End Sub

    ' Chargement des infos d'un diagnostic existant
    Private Sub loadExistingDiag()
        ' On liste les boutons radio du form
        'Dim listRadioButtons(0) As RadioButton
        'CSForm.getListRadioButtons(Me, listRadioButtons)
        'ReDim Preserve listRadioButtons(listRadioButtons.Length - 1)

        ' Chargement des informations du diag
        Dim tmpDiagnosticItem As DiagnosticItem
        Dim isLoaded As Boolean = False
        Try
            If Not m_Diagnostic Is Nothing Then
                If Not m_Diagnostic.diagnosticItemsLst Is Nothing Then
                    If Not m_Diagnostic.diagnosticItemsLst.items Is Nothing Then
                        For Each tmpDiagnosticItem In m_Diagnostic.diagnosticItemsLst.items
                            If Not tmpDiagnosticItem Is Nothing Then
                                Dim TestIdVar As String = tmpDiagnosticItem.idItem & "" & tmpDiagnosticItem.itemValue
                                Dim TestNameVar As String = "RadioButton_diagnostic_" & TestIdVar
                                isLoaded = True
                                Try
                                    Dim tmpControl As CRODIP_ControlLibrary.CtrlDiag2 = CSForm.getControlByName(TestNameVar, Me)
                                    If Not tmpControl Is Nothing Then
                                        tmpControl.Checked = True
                                    End If

                                Catch ex As Exception
                                    CSDebug.dispWarn("Contrôle Préliminaire - Load infos diag. : " & ex.Message)
                                End Try
                            End If
                        Next
                    End If
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("Controle preliminaire - loadExistingDiag : " & ex.Message.ToString)
        End Try

        'If isLoaded Then
        '    btn_toutCocher.Enabled = False
        'End If
    End Sub

#End Region

#Region " Gestion Checkbox "

    Private Sub checkAnswer2(ByVal sender As CRODIP_ControlLibrary.CtrlDiag2, ByVal pOngletId As Integer)

        If Not m_bDuringLoad Then

            'Si l'objet n'a pas de nom on sort (Evnmt déclenché lors de la création du controle)
            If String.IsNullOrEmpty(sender.Name) Or sender.Name.ToUpper() = "CTRLDIAG2" Then
                Exit Sub
            End If

            'Conversion des codes Nlleversion=> ancienne versions
            Dim strCode As String
            Dim nTypeCheckBox As Integer
            strCode = ""
            If sender.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.UN Then
                strCode = "1"
            End If
            If sender.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.DEUX Then
                strCode = "2"
            End If
            If sender.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSEMAX.TROIS Then
                strCode = "3"
            End If
            nTypeCheckBox = CHK_OK
            Select Case sender.Categorie
                Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
                    nTypeCheckBox = CHK_OK
                Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
                    nTypeCheckBox = CHK_DEFAUT_MINEUR
                Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
                    nTypeCheckBox = CHK_DEFAUT_MAJEUR
                Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEURPRELIM
                    nTypeCheckBox = CHK_DEFAUT_MAJEURPRELIM
            End Select
            checkAnswer(sender, nTypeCheckBox, pOngletId, strCode)
        End If
    End Sub

    Private Sub checkAnswer(ByVal sender As System.Object, ByVal typeCheckbox As Integer, ByVal ongletId As Integer, Optional ByVal codeId As String = "")

        Try
            'Si l'objet n'a pas de nom on sort (Evnmt déclenché lors de la création du controle)
            If String.IsNullOrEmpty(sender.name) Then
                Exit Sub
            End If
            'On construit l'item
            Dim curDiagnosticItem As New DiagnosticItem(sender)

            If sender.checked = True Then
                m_Diagnostic.AddDiagItem(curDiagnosticItem)
            Else
                m_Diagnostic.RemoveDiagItem(curDiagnosticItem)
            End If

            ' Mise a jour du flag de l'onglet suivant les checkbox cochées
            checkIsOk()
        Catch ex As Exception
            CSDebug.dispError("diagnostique::checkAnswer (" & sender.name & ") : " & ex.Message)
        End Try

    End Sub

    Private Sub checkIsOk()

        If checkIsAllFilled() Then
            If Not checkIsError() Then
                lbl_controlePreliminaire_etatDiag_ok.Visible = True
                btn_controlePreliminaire_poursuivre.Visible = True
                lbl_controlePreliminaire_etatDiag_nok.Visible = False
                btn_controlePreliminaire_annuler.Visible = False
                btn_controlePreliminaire_imprimerRapport.Visible = False
            Else
                lbl_controlePreliminaire_etatDiag_ok.Visible = False
                btn_controlePreliminaire_poursuivre.Visible = False
                lbl_controlePreliminaire_etatDiag_nok.Visible = True
                btn_controlePreliminaire_annuler.Visible = False
                btn_controlePreliminaire_imprimerRapport.Visible = True
            End If
        Else
            lbl_controlePreliminaire_etatDiag_ok.Visible = False
            lbl_controlePreliminaire_etatDiag_nok.Visible = False
            btn_controlePreliminaire_annuler.Visible = False
            btn_controlePreliminaire_imprimerRapport.Visible = False
            btn_controlePreliminaire_poursuivre.Visible = False
        End If
    End Sub

    Private Function checkIsAllFilled() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Try
            '1.1.1
            bReturn = bReturn And (RadioButton_diagnostic_1111.Checked Or RadioButton_diagnostic_1112.Checked Or RadioButton_diagnostic_1113.Checked Or RadioButton_diagnostic_1110.Checked)
            '1.1.2
            bReturn = bReturn And (RadioButton_diagnostic_1121.Checked Or RadioButton_diagnostic_1122.Checked Or RadioButton_diagnostic_1123.Checked Or RadioButton_diagnostic_1120.Checked)
            '1.1.3
            bReturn = bReturn And (RadioButton_diagnostic_1131.Checked Or RadioButton_diagnostic_1132.Checked Or RadioButton_diagnostic_1133.Checked Or RadioButton_diagnostic_1130.Checked)
            '1.2.1
            bReturn = bReturn And (RadioButton_diagnostic_1211.Checked Or RadioButton_diagnostic_1212.Checked Or RadioButton_diagnostic_1213.Checked Or RadioButton_diagnostic_1210.Checked)
            '1.2.2
            bReturn = bReturn And (RadioButton_diagnostic_1221.Checked Or RadioButton_diagnostic_1222.Checked Or RadioButton_diagnostic_1223.Checked Or RadioButton_diagnostic_1224.Checked Or RadioButton_diagnostic_1220.Checked)
            '1.2.3
            bReturn = bReturn And (RadioButton_diagnostic_1231.Checked Or RadioButton_diagnostic_1232.Checked Or RadioButton_diagnostic_1230.Checked)
            '1.2.4
            bReturn = bReturn And (RadioButton_diagnostic_1241.Checked Or RadioButton_diagnostic_1242.Checked Or RadioButton_diagnostic_1243.Checked Or RadioButton_diagnostic_1244.Checked Or RadioButton_diagnostic_1245.Checked Or RadioButton_diagnostic_1246.Checked Or RadioButton_diagnostic_1247.Checked Or RadioButton_diagnostic_1240.Checked)
            '1.2.5
            bReturn = bReturn And (RadioButton_diagnostic_1251.Checked Or RadioButton_diagnostic_1250.Checked)

        Catch ex As Exception
            CSDebug.dispError("CheckIsAllFilled ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function checkIsError() As Boolean
        Dim bReturn As Boolean
        bReturn = False
        Try
            '1.1.1
            bReturn = bReturn Or (RadioButton_diagnostic_1111.Checked Or RadioButton_diagnostic_1112.Checked Or RadioButton_diagnostic_1113.Checked)
            '1.1.2
            bReturn = bReturn Or (RadioButton_diagnostic_1121.Checked Or RadioButton_diagnostic_1122.Checked Or RadioButton_diagnostic_1123.Checked)
            '1.1.3
            bReturn = bReturn Or (RadioButton_diagnostic_1133.Checked)
            '1.2.1
            bReturn = bReturn Or (RadioButton_diagnostic_1211.Checked Or RadioButton_diagnostic_1212.Checked Or RadioButton_diagnostic_1213.Checked)
            '1.2.2
            bReturn = bReturn Or (RadioButton_diagnostic_1221.Checked Or RadioButton_diagnostic_1222.Checked Or RadioButton_diagnostic_1223.Checked Or RadioButton_diagnostic_1224.Checked)
            '1.2.3
            bReturn = bReturn Or (RadioButton_diagnostic_1231.Checked Or RadioButton_diagnostic_1232.Checked)
            '1.2.4
            bReturn = bReturn Or (RadioButton_diagnostic_1241.Checked Or RadioButton_diagnostic_1242.Checked Or RadioButton_diagnostic_1243.Checked Or RadioButton_diagnostic_1244.Checked Or RadioButton_diagnostic_1245.Checked Or RadioButton_diagnostic_1246.Checked Or RadioButton_diagnostic_1247.Checked)
            '1.2.5
            bReturn = bReturn Or (RadioButton_diagnostic_1251.Checked)

        Catch ex As Exception
            CSDebug.dispError("CheckIsAllFilled ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
#End Region

#Region " Soumission "

    ' Annulation du diag
    Private Sub btn_controlePreliminaire_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controlePreliminaire_annuler.Click
        Statusbar.clear()
        Me.Close()
    End Sub

    ' Poursuite du diag
    Private Sub btn_controlePreliminaire_poursuivre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controlePreliminaire_poursuivre.Click
        sender.Enabled = False

        ' Ouverture form diagnostic
        Statusbar.clear()
        Me.Cursor = Cursors.WaitCursor
        globFormDiagnostic = New frmDiagnostique(m_Mode, m_Diagnostic, m_Pulverisateur, m_Exploit)
        TryCast(Me.MdiParent, parentContener).DisplayForm(globFormDiagnostic)
        Me.Cursor = Cursors.Default

        Me.Hide()
    End Sub

#End Region

    '######################################################################
    '########                   Liste des checkbox                 ########
    '######################################################################

#Region " RadioButton rouges "
    Private Sub RadioButton_diagnostic_etatMateriel_fonctionnalite_nonFonctionnement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1111.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_fonctionnalite_fuitesExcessives_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1112.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_fonctionnalite_remplissageInsuffisant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1113.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1222.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton27_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1224.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton29_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1244.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_elementsSecurite_transmissionHydraulique_pliuresExcessives_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1213.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton30_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1245.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_proprete_exterieurSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1121.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton21_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1251.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_proprete_interieurSale_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1122.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton31_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1246.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton16_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1241.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton24_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1232.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton32_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1247.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1242.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_contexte_mauvaisTracteur_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1133.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_elementsSecurite_transmissionHydraulique_antiDecroDefecueux_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1211.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_proprete_filtresNonNettoyes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1123.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton26_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1223.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1231.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_elementsSecurite_transmissionHydraulique_usureImportante_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1212.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_elementsSecurite_transmissionMecaniqueTracPulve_protecInsuffisanteArbreTournant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1221.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton28_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1243.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub
#End Region

#Region " RadioButton verts "
    Private Sub RadioButton_diagnostic_etatMateriel_proprete_pulvePropre_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1120.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_fonctionnalite_bonFonctionnement_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1110.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_etatMateriel_contexte_bonContexte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1130.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1220.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton14_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1240.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1250.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton23_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1230.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub

    Private Sub RadioButton_diagnostic_elementsSecurite_transmissionHydraulique_aucunDefaut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1210.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub
#End Region

#Region " RadioButton oranges "
    Private Sub RadioButton_diagnostic_etatMateriel_contexte_agriculteurAbsentPendant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1132.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub
    Private Sub RadioButton_diagnostic_etatMateriel_contexte_agriculteurAbsentDebutFin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton_diagnostic_1131.CheckedChanged
        checkAnswer2(sender, 0)
    End Sub
#End Region

    '######################################################################


    Private Sub btn_controlePreliminaire_imprimerRapport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controlePreliminaire_imprimerRapport.Click
        'Dim objInfos(15) As Object
        '        diagnosticCourant.ChargeArrAnswers(arrAnswers)
        m_Diagnostic.ParamDiag = m_oParamdiag
        Dim ofrm As New diagnostic_recap(m_Mode, m_Diagnostic, m_Pulverisateur, m_Exploit)
        TryCast(Me.MdiParent, parentContener).DisplayForm(oFrm)

        Statusbar.clear()
    End Sub


    Private Sub checkAll()
        RadioButton_diagnostic_1110.Checked = True
        RadioButton_diagnostic_1120.Checked = True
        RadioButton_diagnostic_1130.Checked = True
        RadioButton_diagnostic_1210.Checked = True
        RadioButton_diagnostic_1220.Checked = True
        RadioButton_diagnostic_1230.Checked = True
        RadioButton_diagnostic_1240.Checked = True
        RadioButton_diagnostic_1250.Checked = True
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        checkAll()
    End Sub

    Private Sub btn_toutCocher_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_toutCocher.Click
        checkAll()

    End Sub
    '''
    ''' Lecture des paramètres d'affichage dans ParamDiag.xml
    '''
    '''
    ''' Lecture des paramètres d'affichage dans ParamDiag.xml
    '''
    Private Function LectureParametresAffichage(ByVal pFichierParametrage As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCtrl1 As Control
            Dim olst As New CRODIP_ControlLibrary.LstParamCtrlDiag()
            If olst.readXML(pFichierParametrage) Then
                'Parours de la liste des params lus
                For Each oParam As CRODIP_ControlLibrary.ParamCtrlDiag In olst.ListeParam
                    Dim strCode As String = oParam.Code
                    If strCode.StartsWith("1.") Then
                        'inclusion des paramètes 'Préliminaires"
                        Dim nNiveau As Integer
                        strCode = strCode.Replace(".", "") 'Remplace les codes par rien
                        If oParam.DefaultCategorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_GROUPE Then
                            'C'est un Label ou un Group
                            oCtrl1 = CSForm.getControlByName("Label_diagnostic_" & strCode, Me)
                            If oCtrl1 IsNot Nothing Then
                                Dim oLbl As Label = TryCast(oCtrl1, Label)
                                If oLbl IsNot Nothing Then
                                    If oLbl.Image Is Nothing Then
                                        oLbl.Text = oParam.Code & " " & oParam.Libelle
                                    Else
                                        oLbl.Text = "     " & oParam.Code & " " & oParam.Libelle 'Décalage à cause de l'image !!!!
                                    End If
                                End If
                            Else
                                'Si ce n'est pas Label c'est peut-être un groupe
                                oCtrl1 = CSForm.getControlByName("GroupBox_diagnostic_" & strCode, Me)
                                If oCtrl1 IsNot Nothing Then
                                    Dim ogrp As GroupBox = TryCast(oCtrl1, GroupBox)
                                    If ogrp IsNot Nothing Then
                                        ogrp.Text = oParam.Code & " " & oParam.Libelle
                                        If Not oParam.Actif Then
                                            ogrp.Enabled = False
                                        End If
                                    End If
                                End If

                            End If

                        Else
                            oCtrl1 = CSForm.getControlByName("RadioButton_diagnostic_" & strCode, Me)
                            If oCtrl1 IsNot Nothing Then
                                If TypeOf oCtrl1 Is CRODIP_ControlLibrary.CtrlDiag2 Then
                                    oParam.Affecte(oCtrl1)
                                End If
                            End If
                        End If
                    End If

                Next
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.LectureParametresAffichage ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
