Public Class tool_Calculettelha
    Inherits System.Windows.Forms.Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()
    End Sub
    Public Sub New(ByVal _objInfos As Object, ByVal _formFichePedagogique As diagnostic_infosInspecteur)
        Me.new()
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
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents tblmin1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tblmin2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbLmin3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tblha1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tblha2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tblha3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbLargeur1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbLargeur2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbLargeur3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbVitesse1 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbVitesse2 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents tbVitesse3 As CRODIP_ControlLibrary.TBNumeric
    Friend WithEvents btnOK As System.Windows.Forms.Label
    Friend WithEvents diag_client_raisonSociale As System.Windows.Forms.Label

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(tool_Calculettelha))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tblmin1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tblmin2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbLmin3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tblha1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tblha2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tblha3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbLargeur1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbLargeur2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbLargeur3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbVitesse1 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbVitesse2 = New CRODIP_ControlLibrary.TBNumeric()
        Me.tbVitesse3 = New CRODIP_ControlLibrary.TBNumeric()
        Me.btnOK = New System.Windows.Forms.Label()
        Me.diag_client_raisonSociale = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 104.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tblmin1, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tblmin2, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbLmin3, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tblha1, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tblha2, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tblha3, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbLargeur1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbLargeur2, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbLargeur3, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbVitesse1, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbVitesse2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbVitesse3, 3, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(9, 12)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 4
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(428, 123)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(4, 97)
        Me.Label4.Margin = New System.Windows.Forms.Padding(3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "L/min"
        '
        'tblmin1
        '
        Me.tblmin1.ForceBindingOnTextChanged = False
        Me.tblmin1.Location = New System.Drawing.Point(124, 97)
        Me.tblmin1.Name = "tblmin1"
        Me.tblmin1.ReadOnly = True
        Me.tblmin1.Size = New System.Drawing.Size(94, 20)
        Me.tblmin1.TabIndex = 13
        '
        'tblmin2
        '
        Me.tblmin2.ForceBindingOnTextChanged = False
        Me.tblmin2.Location = New System.Drawing.Point(225, 97)
        Me.tblmin2.Name = "tblmin2"
        Me.tblmin2.ReadOnly = True
        Me.tblmin2.Size = New System.Drawing.Size(94, 20)
        Me.tblmin2.TabIndex = 14
        '
        'tbLmin3
        '
        Me.tbLmin3.ForceBindingOnTextChanged = False
        Me.tbLmin3.Location = New System.Drawing.Point(326, 97)
        Me.tbLmin3.Name = "tbLmin3"
        Me.tbLmin3.ReadOnly = True
        Me.tbLmin3.Size = New System.Drawing.Size(94, 20)
        Me.tbLmin3.TabIndex = 15
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(4, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "L/ha"
        '
        'tblha1
        '
        Me.tblha1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tblha1.ForceBindingOnTextChanged = False
        Me.tblha1.Location = New System.Drawing.Point(124, 66)
        Me.tblha1.Name = "tblha1"
        Me.tblha1.Size = New System.Drawing.Size(94, 20)
        Me.tblha1.TabIndex = 6
        '
        'tblha2
        '
        Me.tblha2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tblha2.ForceBindingOnTextChanged = False
        Me.tblha2.Location = New System.Drawing.Point(225, 66)
        Me.tblha2.Name = "tblha2"
        Me.tblha2.Size = New System.Drawing.Size(94, 20)
        Me.tblha2.TabIndex = 7
        '
        'tblha3
        '
        Me.tblha3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tblha3.ForceBindingOnTextChanged = False
        Me.tblha3.Location = New System.Drawing.Point(326, 66)
        Me.tblha3.Name = "tblha3"
        Me.tblha3.Size = New System.Drawing.Size(94, 20)
        Me.tblha3.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(4, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Largeur de rampe (m)"
        '
        'tbLargeur1
        '
        Me.tbLargeur1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbLargeur1.ForceBindingOnTextChanged = False
        Me.tbLargeur1.Location = New System.Drawing.Point(124, 4)
        Me.tbLargeur1.Name = "tbLargeur1"
        Me.tbLargeur1.Size = New System.Drawing.Size(94, 20)
        Me.tbLargeur1.TabIndex = 0
        '
        'tbLargeur2
        '
        Me.tbLargeur2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbLargeur2.ForceBindingOnTextChanged = False
        Me.tbLargeur2.Location = New System.Drawing.Point(225, 4)
        Me.tbLargeur2.Name = "tbLargeur2"
        Me.tbLargeur2.Size = New System.Drawing.Size(94, 20)
        Me.tbLargeur2.TabIndex = 1
        '
        'tbLargeur3
        '
        Me.tbLargeur3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbLargeur3.ForceBindingOnTextChanged = False
        Me.tbLargeur3.Location = New System.Drawing.Point(326, 4)
        Me.tbLargeur3.Name = "tbLargeur3"
        Me.tbLargeur3.Size = New System.Drawing.Size(94, 20)
        Me.tbLargeur3.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(4, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Vitesse"
        '
        'tbVitesse1
        '
        Me.tbVitesse1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbVitesse1.ForceBindingOnTextChanged = False
        Me.tbVitesse1.Location = New System.Drawing.Point(124, 35)
        Me.tbVitesse1.Name = "tbVitesse1"
        Me.tbVitesse1.Size = New System.Drawing.Size(94, 20)
        Me.tbVitesse1.TabIndex = 3
        '
        'tbVitesse2
        '
        Me.tbVitesse2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbVitesse2.ForceBindingOnTextChanged = False
        Me.tbVitesse2.Location = New System.Drawing.Point(225, 35)
        Me.tbVitesse2.Name = "tbVitesse2"
        Me.tbVitesse2.Size = New System.Drawing.Size(94, 20)
        Me.tbVitesse2.TabIndex = 4
        '
        'tbVitesse3
        '
        Me.tbVitesse3.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.tbVitesse3.ForceBindingOnTextChanged = False
        Me.tbVitesse3.Location = New System.Drawing.Point(326, 35)
        Me.tbVitesse3.Name = "tbVitesse3"
        Me.tbVitesse3.Size = New System.Drawing.Size(94, 20)
        Me.tbVitesse3.TabIndex = 5
        '
        'btnOK
        '
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Image = CType(resources.GetObject("btnOK.Image"), System.Drawing.Image)
        Me.btnOK.Location = New System.Drawing.Point(309, 152)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(128, 24)
        Me.btnOK.TabIndex = 7
        Me.btnOK.Text = "    OK"
        Me.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diag_client_raisonSociale
        '
        Me.diag_client_raisonSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.diag_client_raisonSociale.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.diag_client_raisonSociale.Location = New System.Drawing.Point(12, 158)
        Me.diag_client_raisonSociale.Name = "diag_client_raisonSociale"
        Me.diag_client_raisonSociale.Size = New System.Drawing.Size(296, 16)
        Me.diag_client_raisonSociale.TabIndex = 8
        Me.diag_client_raisonSociale.Text = "D=(qlv/600)"
        '
        'tool_Calculettelha
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(449, 185)
        Me.Controls.Add(Me.diag_client_raisonSociale)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "tool_Calculettelha"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "outil de conversion des l/ha"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region



    ' Chargement de l'outil
    Private Sub tool_diagBuses_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


    End Sub
    Private Sub Calc()
        If Not String.IsNullOrEmpty(tbLargeur1.Text) And Not String.IsNullOrEmpty(tbVitesse1.Text) And Not String.IsNullOrEmpty(tblha1.Text) Then
            tblmin1.Text = Math.Round((tbLargeur1.DecimalValue * tbVitesse1.DecimalValue * tblha1.DecimalValue) / 600, 3)

        End If
        If Not String.IsNullOrEmpty(tbLargeur2.Text) And Not String.IsNullOrEmpty(tbVitesse2.Text) And Not String.IsNullOrEmpty(tblha2.Text) Then
            tblmin2.Text = Math.Round((tbLargeur2.DecimalValue * tbVitesse2.DecimalValue * tblha2.DecimalValue) / 600, 3)

        End If
        If Not String.IsNullOrEmpty(tbLargeur3.Text) And Not String.IsNullOrEmpty(tbVitesse3.Text) And Not String.IsNullOrEmpty(tblha3.Text) Then
            tbLmin3.Text = Math.Round((tbLargeur3.DecimalValue * tbVitesse3.DecimalValue * tblha3.DecimalValue) / 600, 3)

        End If

    End Sub
    Private Sub tbLargeur1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLargeur1.TextChanged
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.Close()
    End Sub

    Private Sub tbVitesse1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVitesse1.TextChanged
        Calc()
    End Sub

    Private Sub tblha1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblha1.TextChanged
        Calc()
    End Sub

    Private Sub tbLargeur2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLargeur2.TextChanged
        Calc()
    End Sub

    Private Sub tbVitesse2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVitesse2.TextChanged
        Calc()
    End Sub

    Private Sub tblha2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblha2.TextChanged
        Calc()
    End Sub

    Private Sub tbLargeur3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbLargeur3.TextChanged
        Calc()
    End Sub

    Private Sub tbVitesse3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbVitesse3.TextChanged
        Calc()
    End Sub

    Private Sub tblha3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tblha3.TextChanged
        Calc()
    End Sub
End Class