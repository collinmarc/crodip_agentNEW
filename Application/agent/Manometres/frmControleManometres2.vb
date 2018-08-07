Imports System.Threading
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports System.IO
Imports System.Collections.Generic
''' <summary>
''' Fenêtre de controle des manomètres
''' </summary>
''' <remarks></remarks>
Public Class frmControleManometres2
    Inherits frmCRODIP

    Private m_oAgent As Agent
    Public Sub New(pAgent As Agent)
        Me.New()
        m_oAgent = pAgent
    End Sub

#Region " Code généré par le Concepteur Windows Form "

    Private Sub New()
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
    Friend WithEvents TextBox41 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label82 As System.Windows.Forms.Label
    Friend WithEvents Panel64 As System.Windows.Forms.Panel
    Friend WithEvents btn_controleManos_suivant As System.Windows.Forms.Label
    Friend WithEvents list_manometresEtalon As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents ImageList_onglets As System.Windows.Forms.ImageList
    Friend WithEvents btn_controleBanc_annuler As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel_loading As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents lbMano As System.Windows.Forms.ListBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents tbPCMR2 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMR1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents tbPCMC1 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMC2 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMC3 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMC4 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMC5 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMC6 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMR3 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMR4 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMR5 As System.Windows.Forms.TextBox
    Friend WithEvents tbPCMR6 As System.Windows.Forms.TextBox
    Friend WithEvents tbIncertPC1 As System.Windows.Forms.TextBox
    Friend WithEvents tbIncertPC2 As System.Windows.Forms.TextBox
    Friend WithEvents tbIncertPC3 As System.Windows.Forms.TextBox
    Friend WithEvents tbIncertPC4 As System.Windows.Forms.TextBox
    Friend WithEvents tbIncertPC5 As System.Windows.Forms.TextBox
    Friend WithEvents tbIncertPC6 As System.Windows.Forms.TextBox
    Friend WithEvents tbFondPC6 As System.Windows.Forms.TextBox
    Friend WithEvents tbErrAbsPC6 As System.Windows.Forms.TextBox
    Friend WithEvents tbFondPC5 As System.Windows.Forms.TextBox
    Friend WithEvents tbErrAbsPC5 As System.Windows.Forms.TextBox
    Friend WithEvents tbFondPC4 As System.Windows.Forms.TextBox
    Friend WithEvents tbErrAbsPC4 As System.Windows.Forms.TextBox
    Friend WithEvents tbFondPC3 As System.Windows.Forms.TextBox
    Friend WithEvents tbErrAbsPC3 As System.Windows.Forms.TextBox
    Friend WithEvents tbFondPC2 As System.Windows.Forms.TextBox
    Friend WithEvents tbErrAbsPC2 As System.Windows.Forms.TextBox
    Friend WithEvents tbFondPC1 As System.Windows.Forms.TextBox
    Friend WithEvents tbErrAbsPC1 As System.Windows.Forms.TextBox
    Friend WithEvents tbEMTPC1 As System.Windows.Forms.TextBox
    Friend WithEvents tbEMTPC2 As System.Windows.Forms.TextBox
    Friend WithEvents tbEMTPC3 As System.Windows.Forms.TextBox
    Friend WithEvents tbEMTPC4 As System.Windows.Forms.TextBox
    Friend WithEvents tbEMTPC5 As System.Windows.Forms.TextBox
    Friend WithEvents tbEMTPC6 As System.Windows.Forms.TextBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox28 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox29 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox31 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox32 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox33 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox34 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox35 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox36 As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents m_bsCtrlMano As System.Windows.Forms.BindingSource
    Friend WithEvents m_bsManoControle As System.Windows.Forms.BindingSource
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmControleManometres2))
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.list_manometresEtalon = New System.Windows.Forms.ComboBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Panel64 = New System.Windows.Forms.Panel()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.lbMano = New System.Windows.Forms.ListBox()
        Me.m_bsManoControle = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.TextBox35 = New System.Windows.Forms.TextBox()
        Me.TextBox36 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.tbFondPC6 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC6 = New System.Windows.Forms.TextBox()
        Me.tbFondPC5 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC5 = New System.Windows.Forms.TextBox()
        Me.tbFondPC4 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC4 = New System.Windows.Forms.TextBox()
        Me.tbFondPC3 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC3 = New System.Windows.Forms.TextBox()
        Me.tbFondPC2 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC2 = New System.Windows.Forms.TextBox()
        Me.tbFondPC1 = New System.Windows.Forms.TextBox()
        Me.tbErrAbsPC1 = New System.Windows.Forms.TextBox()
        Me.tbPCMR2 = New System.Windows.Forms.TextBox()
        Me.tbPCMR1 = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.tbPCMC1 = New System.Windows.Forms.TextBox()
        Me.tbPCMC2 = New System.Windows.Forms.TextBox()
        Me.tbPCMC3 = New System.Windows.Forms.TextBox()
        Me.tbPCMC4 = New System.Windows.Forms.TextBox()
        Me.tbPCMC5 = New System.Windows.Forms.TextBox()
        Me.tbPCMC6 = New System.Windows.Forms.TextBox()
        Me.tbPCMR3 = New System.Windows.Forms.TextBox()
        Me.tbPCMR4 = New System.Windows.Forms.TextBox()
        Me.tbPCMR5 = New System.Windows.Forms.TextBox()
        Me.tbPCMR6 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC1 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC2 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC3 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC4 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC5 = New System.Windows.Forms.TextBox()
        Me.tbIncertPC6 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC1 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC2 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC3 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC4 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC5 = New System.Windows.Forms.TextBox()
        Me.tbEMTPC6 = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel_loading = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.btn_controleBanc_annuler = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.btn_controleManos_suivant = New System.Windows.Forms.Label()
        Me.ImageList_onglets = New System.Windows.Forms.ImageList(Me.components)
        Me.m_bsCtrlMano = New System.Windows.Forms.BindingSource(Me.components)
        Me.Panel64.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.m_bsManoControle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel_loading.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.m_bsCtrlMano, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox41
        '
        Me.TextBox41.Location = New System.Drawing.Point(926, 14)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New System.Drawing.Size(74, 20)
        Me.TextBox41.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(785, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(135, 16)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Température de l'air"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(464, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(151, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Manomètre de référence"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'list_manometresEtalon
        '
        Me.list_manometresEtalon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.list_manometresEtalon.ItemHeight = 13
        Me.list_manometresEtalon.Location = New System.Drawing.Point(621, 14)
        Me.list_manometresEtalon.Name = "list_manometresEtalon"
        Me.list_manometresEtalon.Size = New System.Drawing.Size(144, 21)
        Me.list_manometresEtalon.TabIndex = 1
        '
        'Label82
        '
        Me.Label82.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Label82.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label82.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.Label82.Image = CType(resources.GetObject("Label82.Image"), System.Drawing.Image)
        Me.Label82.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label82.Location = New System.Drawing.Point(8, 8)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(312, 25)
        Me.Label82.TabIndex = 4
        Me.Label82.Text = "     Vérifications des manomètres"
        '
        'Panel64
        '
        Me.Panel64.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(236, Byte), Integer))
        Me.Panel64.Controls.Add(Me.Label38)
        Me.Panel64.Controls.Add(Me.Label32)
        Me.Panel64.Controls.Add(Me.Label33)
        Me.Panel64.Controls.Add(Me.Label34)
        Me.Panel64.Controls.Add(Me.Label35)
        Me.Panel64.Controls.Add(Me.Label37)
        Me.Panel64.Controls.Add(Me.Label31)
        Me.Panel64.Controls.Add(Me.Label30)
        Me.Panel64.Controls.Add(Me.Label29)
        Me.Panel64.Controls.Add(Me.Label28)
        Me.Panel64.Controls.Add(Me.Label27)
        Me.Panel64.Controls.Add(Me.SplitContainer1)
        Me.Panel64.Controls.Add(Me.Panel_loading)
        Me.Panel64.Controls.Add(Me.btn_controleBanc_annuler)
        Me.Panel64.Controls.Add(Me.Label36)
        Me.Panel64.Controls.Add(Me.btn_controleManos_suivant)
        Me.Panel64.Controls.Add(Me.TextBox41)
        Me.Panel64.Controls.Add(Me.Label9)
        Me.Panel64.Controls.Add(Me.Label8)
        Me.Panel64.Controls.Add(Me.list_manometresEtalon)
        Me.Panel64.Controls.Add(Me.Label82)
        Me.Panel64.Location = New System.Drawing.Point(0, 0)
        Me.Panel64.Name = "Panel64"
        Me.Panel64.Size = New System.Drawing.Size(1008, 679)
        Me.Panel64.TabIndex = 20
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label38.Location = New System.Drawing.Point(744, 218)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(111, 13)
        Me.Label38.TabIndex = 43
        Me.Label38.Text = "Résultat de l'essai"
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label32.Location = New System.Drawing.Point(761, 192)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(103, 13)
        Me.Label32.TabIndex = 42
        Me.Label32.Text = "Fond d'échelle :"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label33.Location = New System.Drawing.Point(761, 179)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(103, 13)
        Me.Label33.TabIndex = 41
        Me.Label33.Text = "Classe :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label34
        '
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label34.Location = New System.Drawing.Point(761, 166)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(103, 13)
        Me.Label34.TabIndex = 40
        Me.Label34.Text = "Marque :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label35
        '
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(761, 149)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(103, 13)
        Me.Label35.TabIndex = 39
        Me.Label35.Text = "N° Identifiant :"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label37.Location = New System.Drawing.Point(761, 131)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(122, 13)
        Me.Label37.TabIndex = 38
        Me.Label37.Text = "Mano de référence :"
        '
        'Label31
        '
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(761, 106)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(103, 13)
        Me.Label31.TabIndex = 37
        Me.Label31.Text = "Fond d'échelle :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label30
        '
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(761, 93)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(103, 13)
        Me.Label30.TabIndex = 36
        Me.Label30.Text = "Classe :"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(761, 80)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(103, 13)
        Me.Label29.TabIndex = 35
        Me.Label29.Text = "Marque :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(761, 63)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(103, 13)
        Me.Label28.TabIndex = 34
        Me.Label28.Text = "N° Identifiant :"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(761, 45)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(103, 13)
        Me.Label27.TabIndex = 33
        Me.Label27.Text = "Mano à contrôler"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Location = New System.Drawing.Point(12, 41)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.lbMano)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.Blue
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TableLayoutPanel2)
        Me.SplitContainer1.Size = New System.Drawing.Size(726, 626)
        Me.SplitContainer1.SplitterDistance = 164
        Me.SplitContainer1.TabIndex = 32
        '
        'lbMano
        '
        Me.lbMano.DataSource = Me.m_bsManoControle
        Me.lbMano.DisplayMember = "idCrodip"
        Me.lbMano.FormattingEnabled = True
        Me.lbMano.Location = New System.Drawing.Point(3, 60)
        Me.lbMano.Name = "lbMano"
        Me.lbMano.Size = New System.Drawing.Size(158, 563)
        Me.lbMano.TabIndex = 31
        '
        'm_bsManoControle
        '
        Me.m_bsManoControle.DataSource = GetType(Crodip_agent.ManometreControle)
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel3.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel3.ColumnCount = 8
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox1, 7, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox2, 6, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox3, 7, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox4, 6, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox5, 7, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox6, 6, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox7, 7, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox8, 6, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox9, 7, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox10, 6, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox11, 7, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox12, 6, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox13, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox14, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label20, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label21, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label22, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label23, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label24, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label25, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label26, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox15, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox16, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox17, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox18, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox19, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox20, 2, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox21, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox22, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox23, 3, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox24, 3, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox25, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox26, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox27, 4, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox28, 4, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox29, 4, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox30, 4, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox31, 5, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox32, 5, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox33, 5, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox34, 5, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox35, 5, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.TextBox36, 5, 5)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 305)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(552, 201)
        Me.TableLayoutPanel3.TabIndex = 15
        '
        'TextBox1
        '
        Me.TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt6_err_fondEchelle", True))
        Me.TextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox1.Location = New System.Drawing.Point(486, 179)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(63, 20)
        Me.TextBox1.TabIndex = 60
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt6_err_abs", True))
        Me.TextBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox2.Location = New System.Drawing.Point(425, 179)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(54, 20)
        Me.TextBox2.TabIndex = 59
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt5_err_fondEchelle", True))
        Me.TextBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox3.Location = New System.Drawing.Point(486, 144)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.ReadOnly = True
        Me.TextBox3.Size = New System.Drawing.Size(63, 20)
        Me.TextBox3.TabIndex = 58
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt5_err_abs", True))
        Me.TextBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox4.Location = New System.Drawing.Point(425, 144)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(54, 20)
        Me.TextBox4.TabIndex = 57
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt4_err_fondEchelle", True))
        Me.TextBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox5.Location = New System.Drawing.Point(486, 109)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.ReadOnly = True
        Me.TextBox5.Size = New System.Drawing.Size(63, 20)
        Me.TextBox5.TabIndex = 56
        '
        'TextBox6
        '
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt4_err_abs", True))
        Me.TextBox6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox6.Location = New System.Drawing.Point(425, 109)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(54, 20)
        Me.TextBox6.TabIndex = 55
        '
        'TextBox7
        '
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt3_err_fondEchelle", True))
        Me.TextBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox7.Location = New System.Drawing.Point(486, 74)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.ReadOnly = True
        Me.TextBox7.Size = New System.Drawing.Size(63, 20)
        Me.TextBox7.TabIndex = 54
        '
        'TextBox8
        '
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt3_err_abs", True))
        Me.TextBox8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox8.Location = New System.Drawing.Point(425, 74)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(54, 20)
        Me.TextBox8.TabIndex = 53
        '
        'TextBox9
        '
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt2_err_fondEchelle", True))
        Me.TextBox9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox9.Location = New System.Drawing.Point(486, 39)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.ReadOnly = True
        Me.TextBox9.Size = New System.Drawing.Size(63, 20)
        Me.TextBox9.TabIndex = 52
        '
        'TextBox10
        '
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt2_err_abs", True))
        Me.TextBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox10.Location = New System.Drawing.Point(425, 39)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(54, 20)
        Me.TextBox10.TabIndex = 51
        '
        'TextBox11
        '
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt1_err_fondEchelle", True))
        Me.TextBox11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox11.Location = New System.Drawing.Point(486, 4)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.ReadOnly = True
        Me.TextBox11.Size = New System.Drawing.Size(63, 20)
        Me.TextBox11.TabIndex = 50
        '
        'TextBox12
        '
        Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt1_err_abs", True))
        Me.TextBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox12.Location = New System.Drawing.Point(425, 4)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.ReadOnly = True
        Me.TextBox12.Size = New System.Drawing.Size(54, 20)
        Me.TextBox12.TabIndex = 49
        '
        'TextBox13
        '
        Me.TextBox13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt2_pres_manoEtalon", True))
        Me.TextBox13.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox13.Location = New System.Drawing.Point(229, 39)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(69, 20)
        Me.TextBox13.TabIndex = 32
        '
        'TextBox14
        '
        Me.TextBox14.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt1_pres_manoEtalon", True))
        Me.TextBox14.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox14.Location = New System.Drawing.Point(229, 4)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(69, 20)
        Me.TextBox14.TabIndex = 31
        '
        'Label20
        '
        Me.Label20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(1, 1)
        Me.Label20.Margin = New System.Windows.Forms.Padding(0)
        Me.Label20.Name = "Label20"
        Me.TableLayoutPanel3.SetRowSpan(Me.Label20, 6)
        Me.Label20.Size = New System.Drawing.Size(83, 199)
        Me.Label20.TabIndex = 24
        Me.Label20.Text = "Pression décroissante"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(88, 1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(53, 27)
        Me.Label21.TabIndex = 0
        Me.Label21.Text = "1"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(88, 36)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(53, 27)
        Me.Label22.TabIndex = 1
        Me.Label22.Text = "2"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(88, 71)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(53, 27)
        Me.Label23.TabIndex = 2
        Me.Label23.Text = "3"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(88, 106)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(53, 27)
        Me.Label24.TabIndex = 3
        Me.Label24.Text = "4"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(88, 141)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(53, 27)
        Me.Label25.TabIndex = 4
        Me.Label25.Text = "5"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(88, 176)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(53, 24)
        Me.Label26.TabIndex = 5
        Me.Label26.Text = "6"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextBox15
        '
        Me.TextBox15.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt1_pres_manoCtrl", True))
        Me.TextBox15.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox15.Location = New System.Drawing.Point(148, 4)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.ReadOnly = True
        Me.TextBox15.Size = New System.Drawing.Size(74, 20)
        Me.TextBox15.TabIndex = 25
        '
        'TextBox16
        '
        Me.TextBox16.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt2_pres_manoCtrl", True))
        Me.TextBox16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox16.Location = New System.Drawing.Point(148, 39)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.ReadOnly = True
        Me.TextBox16.Size = New System.Drawing.Size(74, 20)
        Me.TextBox16.TabIndex = 26
        '
        'TextBox17
        '
        Me.TextBox17.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt3_pres_manoCtrl", True))
        Me.TextBox17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox17.Location = New System.Drawing.Point(148, 74)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.ReadOnly = True
        Me.TextBox17.Size = New System.Drawing.Size(74, 20)
        Me.TextBox17.TabIndex = 27
        '
        'TextBox18
        '
        Me.TextBox18.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt4_pres_manoCtrl", True))
        Me.TextBox18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox18.Location = New System.Drawing.Point(148, 109)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.ReadOnly = True
        Me.TextBox18.Size = New System.Drawing.Size(74, 20)
        Me.TextBox18.TabIndex = 28
        '
        'TextBox19
        '
        Me.TextBox19.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt5_pres_manoCtrl", True))
        Me.TextBox19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox19.Location = New System.Drawing.Point(148, 144)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.ReadOnly = True
        Me.TextBox19.Size = New System.Drawing.Size(74, 20)
        Me.TextBox19.TabIndex = 29
        '
        'TextBox20
        '
        Me.TextBox20.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt6_pres_manoCtrl", True))
        Me.TextBox20.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox20.Location = New System.Drawing.Point(148, 179)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.ReadOnly = True
        Me.TextBox20.Size = New System.Drawing.Size(74, 20)
        Me.TextBox20.TabIndex = 30
        '
        'TextBox21
        '
        Me.TextBox21.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt3_pres_manoEtalon", True))
        Me.TextBox21.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox21.Location = New System.Drawing.Point(229, 74)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(69, 20)
        Me.TextBox21.TabIndex = 33
        '
        'TextBox22
        '
        Me.TextBox22.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt4_pres_manoEtalon", True))
        Me.TextBox22.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox22.Location = New System.Drawing.Point(229, 109)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(69, 20)
        Me.TextBox22.TabIndex = 34
        '
        'TextBox23
        '
        Me.TextBox23.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt5_pres_manoEtalon", True))
        Me.TextBox23.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox23.Location = New System.Drawing.Point(229, 144)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(69, 20)
        Me.TextBox23.TabIndex = 35
        '
        'TextBox24
        '
        Me.TextBox24.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt6_pres_manoEtalon", True))
        Me.TextBox24.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox24.Location = New System.Drawing.Point(229, 179)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(69, 20)
        Me.TextBox24.TabIndex = 36
        '
        'TextBox25
        '
        Me.TextBox25.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt1_incertitude", True))
        Me.TextBox25.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox25.Location = New System.Drawing.Point(305, 4)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.ReadOnly = True
        Me.TextBox25.Size = New System.Drawing.Size(70, 20)
        Me.TextBox25.TabIndex = 37
        '
        'TextBox26
        '
        Me.TextBox26.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt2_incertitude", True))
        Me.TextBox26.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox26.Location = New System.Drawing.Point(305, 39)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.ReadOnly = True
        Me.TextBox26.Size = New System.Drawing.Size(70, 20)
        Me.TextBox26.TabIndex = 38
        '
        'TextBox27
        '
        Me.TextBox27.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt3_incertitude", True))
        Me.TextBox27.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox27.Location = New System.Drawing.Point(305, 74)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.ReadOnly = True
        Me.TextBox27.Size = New System.Drawing.Size(70, 20)
        Me.TextBox27.TabIndex = 39
        '
        'TextBox28
        '
        Me.TextBox28.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt4_incertitude", True))
        Me.TextBox28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox28.Location = New System.Drawing.Point(305, 109)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.ReadOnly = True
        Me.TextBox28.Size = New System.Drawing.Size(70, 20)
        Me.TextBox28.TabIndex = 40
        '
        'TextBox29
        '
        Me.TextBox29.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt5_incertitude", True))
        Me.TextBox29.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox29.Location = New System.Drawing.Point(305, 144)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.ReadOnly = True
        Me.TextBox29.Size = New System.Drawing.Size(70, 20)
        Me.TextBox29.TabIndex = 41
        '
        'TextBox30
        '
        Me.TextBox30.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt6_incertitude", True))
        Me.TextBox30.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox30.Location = New System.Drawing.Point(305, 179)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.ReadOnly = True
        Me.TextBox30.Size = New System.Drawing.Size(70, 20)
        Me.TextBox30.TabIndex = 42
        '
        'TextBox31
        '
        Me.TextBox31.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt1_EMT", True))
        Me.TextBox31.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox31.Location = New System.Drawing.Point(382, 4)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.ReadOnly = True
        Me.TextBox31.Size = New System.Drawing.Size(36, 20)
        Me.TextBox31.TabIndex = 43
        '
        'TextBox32
        '
        Me.TextBox32.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt2_EMT", True))
        Me.TextBox32.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox32.Location = New System.Drawing.Point(382, 39)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.ReadOnly = True
        Me.TextBox32.Size = New System.Drawing.Size(36, 20)
        Me.TextBox32.TabIndex = 44
        '
        'TextBox33
        '
        Me.TextBox33.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt3_EMT", True))
        Me.TextBox33.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox33.Location = New System.Drawing.Point(382, 74)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.ReadOnly = True
        Me.TextBox33.Size = New System.Drawing.Size(36, 20)
        Me.TextBox33.TabIndex = 45
        '
        'TextBox34
        '
        Me.TextBox34.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt4_EMT", True))
        Me.TextBox34.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox34.Location = New System.Drawing.Point(382, 109)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.ReadOnly = True
        Me.TextBox34.Size = New System.Drawing.Size(36, 20)
        Me.TextBox34.TabIndex = 46
        '
        'TextBox35
        '
        Me.TextBox35.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt5_EMT", True))
        Me.TextBox35.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox35.Location = New System.Drawing.Point(382, 144)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.ReadOnly = True
        Me.TextBox35.Size = New System.Drawing.Size(36, 20)
        Me.TextBox35.TabIndex = 47
        '
        'TextBox36
        '
        Me.TextBox36.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "down_pt6_EMT", True))
        Me.TextBox36.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBox36.Location = New System.Drawing.Point(382, 179)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.ReadOnly = True
        Me.TextBox36.Size = New System.Drawing.Size(36, 20)
        Me.TextBox36.TabIndex = 48
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 8
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.tbFondPC6, 7, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbErrAbsPC6, 6, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbFondPC5, 7, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbErrAbsPC5, 6, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbFondPC4, 7, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbErrAbsPC4, 6, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbFondPC3, 7, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbErrAbsPC3, 6, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbFondPC2, 7, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbErrAbsPC2, 6, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbFondPC1, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbErrAbsPC1, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMR2, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMR1, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label19, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label12, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label13, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label14, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label17, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label18, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMC1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMC2, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMC3, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMC4, 2, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMC5, 2, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMC6, 2, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMR3, 3, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMR4, 3, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMR5, 3, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbPCMR6, 3, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbIncertPC1, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbIncertPC2, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbIncertPC3, 4, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbIncertPC4, 4, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbIncertPC5, 4, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbIncertPC6, 4, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.tbEMTPC1, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbEMTPC2, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbEMTPC3, 5, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.tbEMTPC4, 5, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.tbEMTPC5, 5, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.tbEMTPC6, 5, 5)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 103)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 6
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(552, 201)
        Me.TableLayoutPanel1.TabIndex = 14
        '
        'tbFondPC6
        '
        Me.tbFondPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt6_err_fondEchelle", True))
        Me.tbFondPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC6.Location = New System.Drawing.Point(486, 179)
        Me.tbFondPC6.Name = "tbFondPC6"
        Me.tbFondPC6.ReadOnly = True
        Me.tbFondPC6.Size = New System.Drawing.Size(63, 20)
        Me.tbFondPC6.TabIndex = 60
        '
        'tbErrAbsPC6
        '
        Me.tbErrAbsPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt6_err_abs", True))
        Me.tbErrAbsPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC6.Location = New System.Drawing.Point(425, 179)
        Me.tbErrAbsPC6.Name = "tbErrAbsPC6"
        Me.tbErrAbsPC6.ReadOnly = True
        Me.tbErrAbsPC6.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC6.TabIndex = 59
        '
        'tbFondPC5
        '
        Me.tbFondPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt5_err_fondEchelle", True))
        Me.tbFondPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC5.Location = New System.Drawing.Point(486, 144)
        Me.tbFondPC5.Name = "tbFondPC5"
        Me.tbFondPC5.ReadOnly = True
        Me.tbFondPC5.Size = New System.Drawing.Size(63, 20)
        Me.tbFondPC5.TabIndex = 58
        '
        'tbErrAbsPC5
        '
        Me.tbErrAbsPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt5_err_abs", True))
        Me.tbErrAbsPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC5.Location = New System.Drawing.Point(425, 144)
        Me.tbErrAbsPC5.Name = "tbErrAbsPC5"
        Me.tbErrAbsPC5.ReadOnly = True
        Me.tbErrAbsPC5.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC5.TabIndex = 57
        '
        'tbFondPC4
        '
        Me.tbFondPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt4_err_fondEchelle", True))
        Me.tbFondPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC4.Location = New System.Drawing.Point(486, 109)
        Me.tbFondPC4.Name = "tbFondPC4"
        Me.tbFondPC4.ReadOnly = True
        Me.tbFondPC4.Size = New System.Drawing.Size(63, 20)
        Me.tbFondPC4.TabIndex = 56
        '
        'tbErrAbsPC4
        '
        Me.tbErrAbsPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt4_err_abs", True))
        Me.tbErrAbsPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC4.Location = New System.Drawing.Point(425, 109)
        Me.tbErrAbsPC4.Name = "tbErrAbsPC4"
        Me.tbErrAbsPC4.ReadOnly = True
        Me.tbErrAbsPC4.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC4.TabIndex = 55
        '
        'tbFondPC3
        '
        Me.tbFondPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt3_err_fondEchelle", True))
        Me.tbFondPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC3.Location = New System.Drawing.Point(486, 74)
        Me.tbFondPC3.Name = "tbFondPC3"
        Me.tbFondPC3.ReadOnly = True
        Me.tbFondPC3.Size = New System.Drawing.Size(63, 20)
        Me.tbFondPC3.TabIndex = 54
        '
        'tbErrAbsPC3
        '
        Me.tbErrAbsPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt3_err_abs", True))
        Me.tbErrAbsPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC3.Location = New System.Drawing.Point(425, 74)
        Me.tbErrAbsPC3.Name = "tbErrAbsPC3"
        Me.tbErrAbsPC3.ReadOnly = True
        Me.tbErrAbsPC3.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC3.TabIndex = 53
        '
        'tbFondPC2
        '
        Me.tbFondPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt2_err_fondEchelle", True))
        Me.tbFondPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC2.Location = New System.Drawing.Point(486, 39)
        Me.tbFondPC2.Name = "tbFondPC2"
        Me.tbFondPC2.ReadOnly = True
        Me.tbFondPC2.Size = New System.Drawing.Size(63, 20)
        Me.tbFondPC2.TabIndex = 52
        '
        'tbErrAbsPC2
        '
        Me.tbErrAbsPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt2_err_abs", True))
        Me.tbErrAbsPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC2.Location = New System.Drawing.Point(425, 39)
        Me.tbErrAbsPC2.Name = "tbErrAbsPC2"
        Me.tbErrAbsPC2.ReadOnly = True
        Me.tbErrAbsPC2.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC2.TabIndex = 51
        '
        'tbFondPC1
        '
        Me.tbFondPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt1_err_fondEchelle", True))
        Me.tbFondPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbFondPC1.Location = New System.Drawing.Point(486, 4)
        Me.tbFondPC1.Name = "tbFondPC1"
        Me.tbFondPC1.ReadOnly = True
        Me.tbFondPC1.Size = New System.Drawing.Size(63, 20)
        Me.tbFondPC1.TabIndex = 50
        '
        'tbErrAbsPC1
        '
        Me.tbErrAbsPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt1_err_abs", True))
        Me.tbErrAbsPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbErrAbsPC1.Location = New System.Drawing.Point(425, 4)
        Me.tbErrAbsPC1.Name = "tbErrAbsPC1"
        Me.tbErrAbsPC1.ReadOnly = True
        Me.tbErrAbsPC1.Size = New System.Drawing.Size(54, 20)
        Me.tbErrAbsPC1.TabIndex = 49
        '
        'tbPCMR2
        '
        Me.tbPCMR2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt2_pres_manoEtalon", True))
        Me.tbPCMR2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMR2.Location = New System.Drawing.Point(229, 39)
        Me.tbPCMR2.Name = "tbPCMR2"
        Me.tbPCMR2.Size = New System.Drawing.Size(69, 20)
        Me.tbPCMR2.TabIndex = 32
        '
        'tbPCMR1
        '
        Me.tbPCMR1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt1_pres_manoEtalon", True))
        Me.tbPCMR1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMR1.Location = New System.Drawing.Point(229, 4)
        Me.tbPCMR1.Name = "tbPCMR1"
        Me.tbPCMR1.Size = New System.Drawing.Size(69, 20)
        Me.tbPCMR1.TabIndex = 31
        '
        'Label19
        '
        Me.Label19.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(1, 1)
        Me.Label19.Margin = New System.Windows.Forms.Padding(0)
        Me.Label19.Name = "Label19"
        Me.TableLayoutPanel1.SetRowSpan(Me.Label19, 6)
        Me.Label19.Size = New System.Drawing.Size(83, 199)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "Pression croissante"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(88, 1)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(53, 27)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "1"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(88, 36)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(53, 27)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "2"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(88, 71)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 27)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "3"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(88, 106)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 27)
        Me.Label16.TabIndex = 3
        Me.Label16.Text = "4"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(88, 141)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 27)
        Me.Label17.TabIndex = 4
        Me.Label17.Text = "5"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(88, 176)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 24)
        Me.Label18.TabIndex = 5
        Me.Label18.Text = "6"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'tbPCMC1
        '
        Me.tbPCMC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt1_pres_manoCtrl", True))
        Me.tbPCMC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC1.Location = New System.Drawing.Point(148, 4)
        Me.tbPCMC1.Name = "tbPCMC1"
        Me.tbPCMC1.ReadOnly = True
        Me.tbPCMC1.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC1.TabIndex = 25
        '
        'tbPCMC2
        '
        Me.tbPCMC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt2_pres_manoCtrl", True))
        Me.tbPCMC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC2.Location = New System.Drawing.Point(148, 39)
        Me.tbPCMC2.Name = "tbPCMC2"
        Me.tbPCMC2.ReadOnly = True
        Me.tbPCMC2.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC2.TabIndex = 26
        '
        'tbPCMC3
        '
        Me.tbPCMC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt3_pres_manoCtrl", True))
        Me.tbPCMC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC3.Location = New System.Drawing.Point(148, 74)
        Me.tbPCMC3.Name = "tbPCMC3"
        Me.tbPCMC3.ReadOnly = True
        Me.tbPCMC3.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC3.TabIndex = 27
        '
        'tbPCMC4
        '
        Me.tbPCMC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt4_pres_manoCtrl", True))
        Me.tbPCMC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC4.Location = New System.Drawing.Point(148, 109)
        Me.tbPCMC4.Name = "tbPCMC4"
        Me.tbPCMC4.ReadOnly = True
        Me.tbPCMC4.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC4.TabIndex = 28
        '
        'tbPCMC5
        '
        Me.tbPCMC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt5_pres_manoCtrl", True))
        Me.tbPCMC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC5.Location = New System.Drawing.Point(148, 144)
        Me.tbPCMC5.Name = "tbPCMC5"
        Me.tbPCMC5.ReadOnly = True
        Me.tbPCMC5.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC5.TabIndex = 29
        '
        'tbPCMC6
        '
        Me.tbPCMC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt6_pres_manoCtrl", True))
        Me.tbPCMC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMC6.Location = New System.Drawing.Point(148, 179)
        Me.tbPCMC6.Name = "tbPCMC6"
        Me.tbPCMC6.ReadOnly = True
        Me.tbPCMC6.Size = New System.Drawing.Size(74, 20)
        Me.tbPCMC6.TabIndex = 30
        '
        'tbPCMR3
        '
        Me.tbPCMR3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt3_pres_manoEtalon", True))
        Me.tbPCMR3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMR3.Location = New System.Drawing.Point(229, 74)
        Me.tbPCMR3.Name = "tbPCMR3"
        Me.tbPCMR3.Size = New System.Drawing.Size(69, 20)
        Me.tbPCMR3.TabIndex = 33
        '
        'tbPCMR4
        '
        Me.tbPCMR4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt4_pres_manoEtalon", True))
        Me.tbPCMR4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMR4.Location = New System.Drawing.Point(229, 109)
        Me.tbPCMR4.Name = "tbPCMR4"
        Me.tbPCMR4.Size = New System.Drawing.Size(69, 20)
        Me.tbPCMR4.TabIndex = 34
        '
        'tbPCMR5
        '
        Me.tbPCMR5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt5_pres_manoEtalon", True))
        Me.tbPCMR5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMR5.Location = New System.Drawing.Point(229, 144)
        Me.tbPCMR5.Name = "tbPCMR5"
        Me.tbPCMR5.Size = New System.Drawing.Size(69, 20)
        Me.tbPCMR5.TabIndex = 35
        '
        'tbPCMR6
        '
        Me.tbPCMR6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt6_pres_manoEtalon", True))
        Me.tbPCMR6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbPCMR6.Location = New System.Drawing.Point(229, 179)
        Me.tbPCMR6.Name = "tbPCMR6"
        Me.tbPCMR6.Size = New System.Drawing.Size(69, 20)
        Me.tbPCMR6.TabIndex = 36
        '
        'tbIncertPC1
        '
        Me.tbIncertPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt1_incertitude", True))
        Me.tbIncertPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC1.Location = New System.Drawing.Point(305, 4)
        Me.tbIncertPC1.Name = "tbIncertPC1"
        Me.tbIncertPC1.ReadOnly = True
        Me.tbIncertPC1.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC1.TabIndex = 37
        '
        'tbIncertPC2
        '
        Me.tbIncertPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt2_incertitude", True))
        Me.tbIncertPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC2.Location = New System.Drawing.Point(305, 39)
        Me.tbIncertPC2.Name = "tbIncertPC2"
        Me.tbIncertPC2.ReadOnly = True
        Me.tbIncertPC2.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC2.TabIndex = 38
        '
        'tbIncertPC3
        '
        Me.tbIncertPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt3_incertitude", True))
        Me.tbIncertPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC3.Location = New System.Drawing.Point(305, 74)
        Me.tbIncertPC3.Name = "tbIncertPC3"
        Me.tbIncertPC3.ReadOnly = True
        Me.tbIncertPC3.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC3.TabIndex = 39
        '
        'tbIncertPC4
        '
        Me.tbIncertPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt4_incertitude", True))
        Me.tbIncertPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC4.Location = New System.Drawing.Point(305, 109)
        Me.tbIncertPC4.Name = "tbIncertPC4"
        Me.tbIncertPC4.ReadOnly = True
        Me.tbIncertPC4.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC4.TabIndex = 40
        '
        'tbIncertPC5
        '
        Me.tbIncertPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt5_incertitude", True))
        Me.tbIncertPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC5.Location = New System.Drawing.Point(305, 144)
        Me.tbIncertPC5.Name = "tbIncertPC5"
        Me.tbIncertPC5.ReadOnly = True
        Me.tbIncertPC5.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC5.TabIndex = 41
        '
        'tbIncertPC6
        '
        Me.tbIncertPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt6_incertitude", True))
        Me.tbIncertPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbIncertPC6.Location = New System.Drawing.Point(305, 179)
        Me.tbIncertPC6.Name = "tbIncertPC6"
        Me.tbIncertPC6.ReadOnly = True
        Me.tbIncertPC6.Size = New System.Drawing.Size(70, 20)
        Me.tbIncertPC6.TabIndex = 42
        '
        'tbEMTPC1
        '
        Me.tbEMTPC1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt1_EMT", True))
        Me.tbEMTPC1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC1.Location = New System.Drawing.Point(382, 4)
        Me.tbEMTPC1.Name = "tbEMTPC1"
        Me.tbEMTPC1.ReadOnly = True
        Me.tbEMTPC1.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC1.TabIndex = 43
        '
        'tbEMTPC2
        '
        Me.tbEMTPC2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt2_EMT", True))
        Me.tbEMTPC2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC2.Location = New System.Drawing.Point(382, 39)
        Me.tbEMTPC2.Name = "tbEMTPC2"
        Me.tbEMTPC2.ReadOnly = True
        Me.tbEMTPC2.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC2.TabIndex = 44
        '
        'tbEMTPC3
        '
        Me.tbEMTPC3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt3_EMT", True))
        Me.tbEMTPC3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC3.Location = New System.Drawing.Point(382, 74)
        Me.tbEMTPC3.Name = "tbEMTPC3"
        Me.tbEMTPC3.ReadOnly = True
        Me.tbEMTPC3.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC3.TabIndex = 45
        '
        'tbEMTPC4
        '
        Me.tbEMTPC4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt4_EMT", True))
        Me.tbEMTPC4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC4.Location = New System.Drawing.Point(382, 109)
        Me.tbEMTPC4.Name = "tbEMTPC4"
        Me.tbEMTPC4.ReadOnly = True
        Me.tbEMTPC4.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC4.TabIndex = 46
        '
        'tbEMTPC5
        '
        Me.tbEMTPC5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt5_EMT", True))
        Me.tbEMTPC5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC5.Location = New System.Drawing.Point(382, 144)
        Me.tbEMTPC5.Name = "tbEMTPC5"
        Me.tbEMTPC5.ReadOnly = True
        Me.tbEMTPC5.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC5.TabIndex = 47
        '
        'tbEMTPC6
        '
        Me.tbEMTPC6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.m_bsCtrlMano, "up_pt6_EMT", True))
        Me.tbEMTPC6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tbEMTPC6.Location = New System.Drawing.Point(382, 179)
        Me.tbEMTPC6.Name = "tbEMTPC6"
        Me.tbEMTPC6.ReadOnly = True
        Me.tbEMTPC6.Size = New System.Drawing.Size(36, 20)
        Me.tbEMTPC6.TabIndex = 48
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.BackColor = System.Drawing.SystemColors.Control
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 8
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 59.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label5, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label6, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label11, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label10, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(552, 100)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(302, 1)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.TableLayoutPanel2.SetRowSpan(Me.Label5, 2)
        Me.Label5.Size = New System.Drawing.Size(76, 98)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Incertitude"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(379, 1)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.TableLayoutPanel2.SetRowSpan(Me.Label6, 2)
        Me.Label6.Size = New System.Drawing.Size(42, 98)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "EMT"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label7, 2)
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(425, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 48)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Erreur"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label11
        '
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(486, 50)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 49)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Fond d'échelle (%)"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label10
        '
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(425, 50)
        Me.Label10.Name = "Label10"
        Me.Label10.Padding = New System.Windows.Forms.Padding(1)
        Me.Label10.Size = New System.Drawing.Size(54, 49)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Absolue (bar)"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(229, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 49)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Manomètre Référence"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(148, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 49)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Manomètre à contrôler"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.TableLayoutPanel2.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(148, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 48)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Pression (bar)"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(85, 1)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.TableLayoutPanel2.SetRowSpan(Me.Label1, 2)
        Me.Label1.Size = New System.Drawing.Size(59, 98)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Points d'essai"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel_loading
        '
        Me.Panel_loading.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(191, Byte), Integer))
        Me.Panel_loading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel_loading.Controls.Add(Me.Label15)
        Me.Panel_loading.Controls.Add(Me.PictureBox2)
        Me.Panel_loading.Location = New System.Drawing.Point(360, 299)
        Me.Panel_loading.Name = "Panel_loading"
        Me.Panel_loading.Size = New System.Drawing.Size(288, 80)
        Me.Panel_loading.TabIndex = 30
        Me.Panel_loading.Visible = False
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(8, 16)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(272, 23)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Chargement des mesures..."
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(89, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.PictureBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(34, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(220, 19)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'btn_controleBanc_annuler
        '
        Me.btn_controleBanc_annuler.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleBanc_annuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleBanc_annuler.ForeColor = System.Drawing.Color.White
        Me.btn_controleBanc_annuler.Image = CType(resources.GetObject("btn_controleBanc_annuler.Image"), System.Drawing.Image)
        Me.btn_controleBanc_annuler.Location = New System.Drawing.Point(328, 8)
        Me.btn_controleBanc_annuler.Name = "btn_controleBanc_annuler"
        Me.btn_controleBanc_annuler.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleBanc_annuler.TabIndex = 29
        Me.btn_controleBanc_annuler.Text = "    Quitter l'outil"
        Me.btn_controleBanc_annuler.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Red
        Me.Label36.Location = New System.Drawing.Point(744, 374)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(248, 218)
        Me.Label36.TabIndex = 10
        Me.Label36.Text = resources.GetString("Label36.Text")
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_controleManos_suivant
        '
        Me.btn_controleManos_suivant.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_controleManos_suivant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_controleManos_suivant.ForeColor = System.Drawing.Color.White
        Me.btn_controleManos_suivant.Image = CType(resources.GetObject("btn_controleManos_suivant.Image"), System.Drawing.Image)
        Me.btn_controleManos_suivant.Location = New System.Drawing.Point(864, 600)
        Me.btn_controleManos_suivant.Name = "btn_controleManos_suivant"
        Me.btn_controleManos_suivant.Size = New System.Drawing.Size(128, 24)
        Me.btn_controleManos_suivant.TabIndex = 27
        Me.btn_controleManos_suivant.Text = "    Mano suivant"
        Me.btn_controleManos_suivant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ImageList_onglets
        '
        Me.ImageList_onglets.ImageStream = CType(resources.GetObject("ImageList_onglets.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_onglets.TransparentColor = System.Drawing.Color.White
        Me.ImageList_onglets.Images.SetKeyName(0, "")
        '
        'm_bsCtrlMano
        '
        Me.m_bsCtrlMano.DataSource = GetType(Crodip_agent.ControleMano)
        '
        'frmControleManometres2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel64)
        Me.MinimizeBox = False
        Me.Name = "frmControleManometres2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Crodip .::. Contrôle des manomètres de l'agent"
        Me.Panel64.ResumeLayout(False)
        Me.Panel64.PerformLayout()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.m_bsManoControle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel_loading.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.m_bsCtrlMano, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region " Init Glob Vars "

    Private nbMesures As Integer = 6
    Private curManoEtalon As ManometreEtalon
    Private curManoControle As ManometreControle
    Private prevSelectedManoOnglet As Integer = -1

#End Region

    ' Chargement des mano / construction des onglets & forms
    Private Sub controle_manometres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        '''TODO : Réduire cette fonction 

        '####################################################
        '######### Chargement des manomètres étalon #########
        '####################################################
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmControleManometres))

        ' On récupère les mano étalons de l'agent
        Dim arrManoEtalon As List(Of ManometreEtalon) = ManometreEtalonManager.getManometreEtalonByStructureId(m_oAgent.idStructure)
        For Each tmpManoEtalon As ManometreEtalon In arrManoEtalon
            Dim objComboItem As New objComboItem(tmpManoEtalon.numeroNational, tmpManoEtalon.idCrodip)
            list_manometresEtalon.Items.Add(objComboItem)
        Next

        '####################################################
        '###### Chargement des manomètres de controle #######
        '####################################################
        ' On clear les onglets
        'ongletsManos.TabPages.Clear()

        ' On récupère la liste des manos de la structure de l'agent
        Dim arrManoControle As List(Of ManometreControle) = ManometreControleManager.getManoControleByStructureId(m_oAgent.idStructure, True)
        ' Création des contrôles a la volée
        Dim positionTop As Integer = 0
        Dim nTabIndex As Integer
        For Each tmpManoControle As ManometreControle In arrManoControle

            nTabIndex = 1

            ' Création d'une nouvelle page dans le controltab
            Dim tmpTab As New TabPage
            tmpTab.Name = "tabPage_mano_" & tmpManoControle.numeroNational
            tmpTab.Text = "Mano " & tmpManoControle.idCrodip
            'ongletsManos.TabPages.Add(tmpTab)
            tmpTab.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))


            '##########################
            '   Array global
            '##########################
            '
            'panelArrayglob
            '
            Dim tmpPanelArrayglob As New Panel
            tmpPanelArrayglob.Name = "panelArrayglob_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob)
            tmpPanelArrayglob.AutoScroll = True
            tmpPanelArrayglob.BackColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(123, Byte), CType(191, Byte))
            tmpPanelArrayglob.Location = New System.Drawing.Point(8, 8)
            tmpPanelArrayglob.Size = New System.Drawing.Size(720, 584)
            tmpPanelArrayglob.Parent = tmpTab

            '
            'panelArrayglob_blocEmpty
            '
            Dim tmpPanelArrayglob_blocEmpty As New Panel
            tmpPanelArrayglob_blocEmpty.Name = "panelArrayglob_blocEmpty_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_blocEmpty)
            tmpPanelArrayglob_blocEmpty.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_blocEmpty.Location = New System.Drawing.Point(0, 0)
            tmpPanelArrayglob_blocEmpty.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_blocEmpty.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionCroissante
            '
            Dim tmpPanelArrayglob_titlePressionCroissante As New Panel
            tmpPanelArrayglob_titlePressionCroissante.Name = "panelArrayglob_titlePressionCroissante_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionCroissante)
            tmpPanelArrayglob_titlePressionCroissante.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionCroissante.Location = New System.Drawing.Point(0, 80)
            tmpPanelArrayglob_titlePressionCroissante.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_titlePressionCroissante.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionDecroissante
            '
            Dim tmpPanelArrayglob_titlePressionDecroissante As New Panel
            tmpPanelArrayglob_titlePressionDecroissante.Name = "panelArrayglob_titlePressionDecroissante_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionDecroissante)
            tmpPanelArrayglob_titlePressionDecroissante.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionDecroissante.Parent = tmpPanelArrayglob
            tmpPanelArrayglob_titlePressionDecroissante.Location = New System.Drawing.Point(0, 336)
            tmpPanelArrayglob_titlePressionDecroissante.Size = New System.Drawing.Size(87, 255)

            '
            'panelArrayglob_titlePointEssai
            '
            Dim tmpPanelArrayglob_titlePointEssai As New Panel
            tmpPanelArrayglob_titlePointEssai.Name = "panelArrayglob_titlePointEssai_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePointEssai)
            tmpPanelArrayglob_titlePointEssai.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePointEssai.Location = New System.Drawing.Point(88, 0)
            tmpPanelArrayglob_titlePointEssai.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_titlePointEssai.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePression
            '
            Dim tmpPanelArrayglob_titlePression As New Panel
            tmpPanelArrayglob_titlePression.Name = "panelArrayglob_titlePression_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePression)
            tmpPanelArrayglob_titlePression.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePression.Location = New System.Drawing.Point(176, 0)
            tmpPanelArrayglob_titlePression.Size = New System.Drawing.Size(175, 39)
            tmpPanelArrayglob_titlePression.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionCapteurTeste
            '
            Dim tmpPanelArrayglob_titlePressionCapteurTeste As New Panel
            tmpPanelArrayglob_titlePressionCapteurTeste.Name = "panelArrayglob_titlePressionCapteurTeste_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionCapteurTeste)
            tmpPanelArrayglob_titlePressionCapteurTeste.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionCapteurTeste.Location = New System.Drawing.Point(176, 40)
            tmpPanelArrayglob_titlePressionCapteurTeste.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titlePressionCapteurTeste.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titlePressionInstrument
            '
            Dim tmpPanelArrayglob_titlePressionInstrument As New Panel
            tmpPanelArrayglob_titlePressionInstrument.Name = "panelArrayglob_titlePressionInstrument_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titlePressionInstrument)
            tmpPanelArrayglob_titlePressionInstrument.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titlePressionInstrument.Location = New System.Drawing.Point(264, 40)
            tmpPanelArrayglob_titlePressionInstrument.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titlePressionInstrument.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleIncertitude
            '
            Dim tmpPanelArrayglob_titleIncertitude As New Panel
            tmpPanelArrayglob_titleIncertitude.Name = "panelArrayglob_titleIncertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleIncertitude)
            tmpPanelArrayglob_titleIncertitude.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleIncertitude.Location = New System.Drawing.Point(352, 0)
            tmpPanelArrayglob_titleIncertitude.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_titleIncertitude.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleEMT
            '
            Dim tmpPanelArrayglob_titleEMT As New Panel
            tmpPanelArrayglob_titleEMT.Name = "panelArrayglob_titleEMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleEMT)
            tmpPanelArrayglob_titleEMT.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleEMT.Location = New System.Drawing.Point(440, 0)
            tmpPanelArrayglob_titleEMT.Size = New System.Drawing.Size(87, 79)
            tmpPanelArrayglob_titleEMT.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleErreur
            '
            Dim tmpPanelArrayglob_titleErreur As New Panel
            tmpPanelArrayglob_titleErreur.Name = "panelArrayglob_titleErreur_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleErreur)
            tmpPanelArrayglob_titleErreur.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleErreur.Location = New System.Drawing.Point(528, 0)
            tmpPanelArrayglob_titleErreur.Size = New System.Drawing.Size(175, 39)
            tmpPanelArrayglob_titleErreur.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleErreurAbsolue
            '
            Dim tmpPanelArrayglob_titleErreurAbsolue As New Panel
            tmpPanelArrayglob_titleErreurAbsolue.Name = "panelArrayglob_titleErreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleErreurAbsolue)
            tmpPanelArrayglob_titleErreurAbsolue.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleErreurAbsolue.Location = New System.Drawing.Point(528, 40)
            tmpPanelArrayglob_titleErreurAbsolue.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titleErreurAbsolue.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_titleErreurFondEchelle
            '
            Dim tmpPanelArrayglob_titleErreurFondEchelle As New Panel
            tmpPanelArrayglob_titleErreurFondEchelle.Name = "panelArrayglob_titleErreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_titleErreurFondEchelle)
            tmpPanelArrayglob_titleErreurFondEchelle.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_titleErreurFondEchelle.Location = New System.Drawing.Point(616, 40)
            tmpPanelArrayglob_titleErreurFondEchelle.Size = New System.Drawing.Size(87, 39)
            tmpPanelArrayglob_titleErreurFondEchelle.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_pointEssai
            '
            Dim tmpPanelArrayglob_croissant_pointEssai As New Panel
            tmpPanelArrayglob_croissant_pointEssai.Name = "panelArrayglob_croissant_pointEssai_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_pointEssai)
            tmpPanelArrayglob_croissant_pointEssai.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_pointEssai.Location = New System.Drawing.Point(88, 80)
            tmpPanelArrayglob_croissant_pointEssai.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_pointEssai.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_capteurTeste
            '
            Dim tmpPanelArrayglob_croissant_capteurTeste As New Panel
            tmpPanelArrayglob_croissant_capteurTeste.Name = "panelArrayglob_croissant_capteurTeste_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_capteurTeste)
            tmpPanelArrayglob_croissant_capteurTeste.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_capteurTeste.Location = New System.Drawing.Point(176, 80)
            tmpPanelArrayglob_croissant_capteurTeste.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_capteurTeste.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_instrumentReference
            '
            Dim tmpPanelArrayglob_croissant_instrumentReference As New Panel
            tmpPanelArrayglob_croissant_instrumentReference.Name = "panelArrayglob_croissant_instrumentReference_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_instrumentReference)
            tmpPanelArrayglob_croissant_instrumentReference.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_instrumentReference.Location = New System.Drawing.Point(264, 80)
            tmpPanelArrayglob_croissant_instrumentReference.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_instrumentReference.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_incertitude
            '
            Dim tmpPanelArrayglob_croissant_incertitude As New Panel
            tmpPanelArrayglob_croissant_incertitude.Name = "panelArrayglob_croissant_incertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_incertitude)
            tmpPanelArrayglob_croissant_incertitude.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_incertitude.Location = New System.Drawing.Point(352, 80)
            tmpPanelArrayglob_croissant_incertitude.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_incertitude.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_EMT
            '
            Dim tmpPanelArrayglob_croissant_EMT As New Panel
            tmpPanelArrayglob_croissant_EMT.Name = "panelArrayglob_croissant_EMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_EMT)
            tmpPanelArrayglob_croissant_EMT.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_EMT.Location = New System.Drawing.Point(440, 80)
            tmpPanelArrayglob_croissant_EMT.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_EMT.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_erreurAbsolue
            '
            Dim tmpPanelArrayglob_croissant_erreurAbsolue As New Panel
            tmpPanelArrayglob_croissant_erreurAbsolue.Name = "panelArrayglob_croissant_erreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_erreurAbsolue)
            tmpPanelArrayglob_croissant_erreurAbsolue.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_erreurAbsolue.Location = New System.Drawing.Point(528, 80)
            tmpPanelArrayglob_croissant_erreurAbsolue.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_erreurAbsolue.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_croissant_erreurFondEchelle
            '
            Dim tmpPanelArrayglob_croissant_erreurFondEchelle As New Panel
            tmpPanelArrayglob_croissant_erreurFondEchelle.Name = "panelArrayglob_croissant_erreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_croissant_erreurFondEchelle)
            tmpPanelArrayglob_croissant_erreurFondEchelle.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_croissant_erreurFondEchelle.Location = New System.Drawing.Point(616, 80)
            tmpPanelArrayglob_croissant_erreurFondEchelle.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_croissant_erreurFondEchelle.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_pointEssai
            '
            Dim tmpPanelArrayglob_decroissant_pointEssai As New Panel
            tmpPanelArrayglob_decroissant_pointEssai.Name = "panelArrayglob_decroissant_pointEssai_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_pointEssai)
            tmpPanelArrayglob_decroissant_pointEssai.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_pointEssai.Location = New System.Drawing.Point(88, 336)
            tmpPanelArrayglob_decroissant_pointEssai.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_pointEssai.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_capteurTeste
            '
            Dim tmpPanelArrayglob_decroissant_capteurTeste As New Panel
            tmpPanelArrayglob_decroissant_capteurTeste.Name = "panelArrayglob_decroissant_capteurTeste_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_capteurTeste)
            tmpPanelArrayglob_decroissant_capteurTeste.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_capteurTeste.Location = New System.Drawing.Point(176, 336)
            tmpPanelArrayglob_decroissant_capteurTeste.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_capteurTeste.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_instrumentReference
            '
            Dim tmpPanelArrayglob_decroissant_instrumentReference As New Panel
            tmpPanelArrayglob_decroissant_instrumentReference.Name = "panelArrayglob_decroissant_instrumentReference_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_instrumentReference)
            tmpPanelArrayglob_decroissant_instrumentReference.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_instrumentReference.Location = New System.Drawing.Point(264, 336)
            tmpPanelArrayglob_decroissant_instrumentReference.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_instrumentReference.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_incertitude
            '
            Dim tmpPanelArrayglob_decroissant_incertitude As New Panel
            tmpPanelArrayglob_decroissant_incertitude.Name = "panelArrayglob_decroissant_incertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_incertitude)
            tmpPanelArrayglob_decroissant_incertitude.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_incertitude.Location = New System.Drawing.Point(352, 336)
            tmpPanelArrayglob_decroissant_incertitude.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_incertitude.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_EMT
            '
            Dim tmpPanelArrayglob_decroissant_EMT As New Panel
            tmpPanelArrayglob_decroissant_EMT.Name = "panelArrayglob_decroissant_instrumentEMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_EMT)
            tmpPanelArrayglob_decroissant_EMT.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_EMT.Location = New System.Drawing.Point(440, 336)
            tmpPanelArrayglob_decroissant_EMT.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_EMT.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_erreurAbsolue
            '
            Dim tmpPanelArrayglob_decroissant_erreurAbsolue As New Panel
            tmpPanelArrayglob_decroissant_erreurAbsolue.Name = "panelArrayglob_decroissant_erreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_erreurAbsolue)
            tmpPanelArrayglob_decroissant_erreurAbsolue.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_erreurAbsolue.Location = New System.Drawing.Point(528, 336)
            tmpPanelArrayglob_decroissant_erreurAbsolue.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_erreurAbsolue.Parent = tmpPanelArrayglob

            '
            'panelArrayglob_decroissant_erreurFondEchelle
            '
            Dim tmpPanelArrayglob_decroissant_erreurFondEchelle As New Panel
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Name = "panelArrayglob_decroissant_erreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpPanelArrayglob_decroissant_erreurFondEchelle)
            tmpPanelArrayglob_decroissant_erreurFondEchelle.BackColor = System.Drawing.Color.FromArgb(CType(234, Byte), CType(234, Byte), CType(236, Byte))
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Location = New System.Drawing.Point(616, 336)
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Size = New System.Drawing.Size(87, 255)
            tmpPanelArrayglob_decroissant_erreurFondEchelle.Parent = tmpPanelArrayglob

            '##########################
            '   Libellés
            '##########################
            '
            'Title pression
            '
            Dim tmpLib_pressionCroissant As New Label
            tmpLib_pressionCroissant.Name = "tmpLib_pressionDecroissant_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionCroissant)
            tmpLib_pressionCroissant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionCroissant.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionCroissant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pressionCroissant.Location = New System.Drawing.Point(8, 16)
            'tmpLib_pressionCroissant.Size = New System.Drawing.Size(104, 232)
            tmpLib_pressionCroissant.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionCroissant.Text = "Pression croissante"
            tmpLib_pressionCroissant.Parent = tmpPanelArrayglob_titlePressionCroissante
            Dim tmpLib_pressionDecroissant As New Label
            tmpLib_pressionDecroissant.Name = "tmpLib_pressionDecroissant_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionDecroissant)
            tmpLib_pressionDecroissant.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionDecroissant.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionDecroissant.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pressionDecroissant.Location = New System.Drawing.Point(8, 16)
            'tmpLib_pressionDecroissant.Size = New System.Drawing.Size(104, 232)
            tmpLib_pressionDecroissant.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionDecroissant.Text = "Pression décroissante"
            tmpLib_pressionDecroissant.Parent = tmpPanelArrayglob_titlePressionDecroissante
            '
            'Title point essaie
            '
            Dim tmpLib_pointsEssaie As New Label
            tmpLib_pointsEssaie.Name = "tmpLib_pointsEssaie_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pointsEssaie)
            tmpLib_pointsEssaie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pointsEssaie.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pointsEssaie.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pointsEssaie.Location = New System.Drawing.Point(7, 8)
            'tmpLib_pointsEssaie.Size = New System.Drawing.Size(104, 56)
            tmpLib_pointsEssaie.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pointsEssaie.Text = "Points d'essai"
            tmpLib_pointsEssaie.Parent = tmpPanelArrayglob_titlePointEssai
            '
            'Title pression
            '
            Dim tmpLib_pression As New Label
            tmpLib_pression.Name = "tmpLib_pression_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pression)
            tmpLib_pression.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pression.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pression.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pression.Location = New System.Drawing.Point(8, 8)
            'tmpLib_pression.Size = New System.Drawing.Size(224, 16)
            tmpLib_pression.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pression.Text = "Pression (bar)"
            tmpLib_pression.Parent = tmpPanelArrayglob_titlePression
            '
            'Title pression capteur
            '
            Dim tmpLib_pressionCapteur As New Label
            tmpLib_pressionCapteur.Name = "tmpLib_pressionCapteur_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionCapteur)
            tmpLib_pressionCapteur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionCapteur.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionCapteur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_pressionCapteur.Location = New System.Drawing.Point(7, 8)
            'tmpLib_pressionCapteur.Size = New System.Drawing.Size(104, 24)
            tmpLib_pressionCapteur.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionCapteur.Text = "Manomètre à contrôler"
            tmpLib_pressionCapteur.Parent = tmpPanelArrayglob_titlePressionCapteurTeste
            '
            'Title pression instrument
            '
            Dim tmpLib_pressionInstrument As New Label
            tmpLib_pressionInstrument.Name = "tmpLib_pressionInstrument_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_pressionInstrument)
            tmpLib_pressionInstrument.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_pressionInstrument.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_pressionInstrument.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_pressionInstrument.Parent = tmpPanelArrayglob_titlePressionInstrument
            'tmpLib_pressionInstrument.Location = New System.Drawing.Point(7, 8)
            'tmpLib_pressionInstrument.Size = New System.Drawing.Size(104, 24)
            tmpLib_pressionInstrument.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_pressionInstrument.Text = "Manomètre Référence"
            '
            'Title point incertitude
            '
            Dim tmpLib_incertitude As New Label
            tmpLib_incertitude.Name = "tmpLib_incertitude_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_incertitude)
            tmpLib_incertitude.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_incertitude.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_incertitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_incertitude.Location = New System.Drawing.Point(7, 8)
            'tmpLib_incertitude.Size = New System.Drawing.Size(104, 56)
            tmpLib_incertitude.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_incertitude.Text = "Incertitude"
            tmpLib_incertitude.Parent = tmpPanelArrayglob_titleIncertitude
            '
            'Title point EMT
            '
            Dim tmpLib_EMT As New Label
            tmpLib_EMT.Name = "tmpLib_EMT_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_EMT)
            tmpLib_EMT.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_EMT.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_EMT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            'tmpLib_EMT.Location = New System.Drawing.Point(7, 8)
            'tmpLib_EMT.Size = New System.Drawing.Size(104, 56)
            tmpLib_EMT.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_EMT.Text = "EMT"
            tmpLib_EMT.Parent = tmpPanelArrayglob_titleEMT
            '
            'Title Erreur
            '
            Dim tmpLib_erreur As New Label
            tmpLib_erreur.Name = "tmpLib_erreur_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_erreur)
            tmpLib_erreur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_erreur.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_erreur.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_erreur.Parent = tmpPanelArrayglob_titleErreur
            'tmpLib_erreur.Location = New System.Drawing.Point(8, 8)
            'tmpLib_erreur.Size = New System.Drawing.Size(224, 16)
            tmpLib_erreur.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_erreur.Text = "Erreur"
            '
            'Title Erreur Absolue
            '
            Dim tmpLib_erreurAbsolue As New Label
            tmpLib_erreurAbsolue.Name = "tmpLib_erreurAbsolue_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_erreurAbsolue)
            tmpLib_erreurAbsolue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_erreurAbsolue.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_erreurAbsolue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_erreurAbsolue.Parent = tmpPanelArrayglob_titleErreurAbsolue
            'tmpLib_erreurAbsolue.Location = New System.Drawing.Point(7, 8)
            'tmpLib_erreurAbsolue.Size = New System.Drawing.Size(104, 24)
            tmpLib_erreurAbsolue.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_erreurAbsolue.Text = "Absolue (bar)"
            '
            'Title Erreur Fond D'Echelle
            '
            Dim tmpLib_erreurFondEchelle As New Label
            tmpLib_erreurFondEchelle.Name = "tmpLib_erreurFondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmpLib_erreurFondEchelle)
            tmpLib_erreurFondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmpLib_erreurFondEchelle.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmpLib_erreurFondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmpLib_erreurFondEchelle.Parent = tmpPanelArrayglob_titleErreurFondEchelle
            'tmpLib_erreurFondEchelle.Location = New System.Drawing.Point(7, 8)
            'tmpLib_erreurFondEchelle.Size = New System.Drawing.Size(104, 24)
            tmpLib_erreurFondEchelle.Dock = System.Windows.Forms.DockStyle.Fill
            tmpLib_erreurFondEchelle.Text = "Fond d'echelle (%)"

            '##########################
            '   Datas
            '##########################
            '
            'Labels points essais croissants / décroissants
            '

            Dim arrPressions_6bar() As String = {0, 1.2, 2.4, 3.6, 4.8, 6}
            Dim arrPressions_10bar() As String = {0, 2, 4, 6, 8, 10}
            Dim arrPressions_20bar() As String = {0, 4, 8, 12, 16, 20}
            Dim arrPressions_25bar() As String = {0, 5, 10, 15, 20, 25}
            Dim arrPressions_default() As String = {0, 2, 4, 6, 8, 10}

            Dim vPos As Integer = 8
            nTabIndex = 0
            For i As Integer = 1 To nbMesures
                nTabIndex = nTabIndex + 1
                Try

                    Dim tmpPressionsTest() As String
                    Select Case tmpManoControle.fondEchelle
                        Case "6"
                            tmpPressionsTest = arrPressions_6bar
                        Case "10"
                            tmpPressionsTest = arrPressions_10bar
                        Case "20"
                            tmpPressionsTest = arrPressions_20bar
                        Case "25"
                            tmpPressionsTest = arrPressions_25bar
                        Case Else
                            tmpPressionsTest = arrPressions_default
                    End Select

                    ' CROISSANT
                    Dim tmp_croissant_label_pointsEssai As New Label
                    tmp_croissant_label_pointsEssai.Name = "croissant_pointsEssai_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_label_pointsEssai)
                    tmp_croissant_label_pointsEssai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    tmp_croissant_label_pointsEssai.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                    tmp_croissant_label_pointsEssai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    tmp_croissant_label_pointsEssai.Location = New System.Drawing.Point(0, vPos)
                    tmp_croissant_label_pointsEssai.Size = New System.Drawing.Size(89, 16)
                    tmp_croissant_label_pointsEssai.Text = i
                    tmp_croissant_label_pointsEssai.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_label_pointsEssai.Parent = tmpPanelArrayglob_croissant_pointEssai
                    '
                    'Pression : capteur testé
                    '
                    Dim tmp_croissant_pression_capteurTeste As New TextBox
                    tmp_croissant_pression_capteurTeste.Name = "croissant_pression_capteurTeste_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_pression_capteurTeste)
                    tmp_croissant_pression_capteurTeste.Parent = tmpPanelArrayglob_croissant_capteurTeste
                    tmp_croissant_pression_capteurTeste.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_pression_capteurTeste.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_pression_capteurTeste.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    'tmp_croissant_pression_capteurTeste.TabStop = True
                    'tmp_croissant_pression_capteurTeste.TabIndex = nTabIndex + nbMesures
                    'tmp_croissant_pression_capteurTeste.Text = tmpPressionsTest((i - 1))
                    'AddHandler tmp_croissant_pression_capteurTeste.Validated, AddressOf updateResults
                    'AddHandler tmp_croissant_pression_capteurTeste.KeyPress, AddressOf checkKeyPress
                    tmp_croissant_pression_capteurTeste.TabStop = False
                    tmp_croissant_pression_capteurTeste.ReadOnly = True
                    tmp_croissant_pression_capteurTeste.Text = tmpPressionsTest((i - 1))
                    '
                    'Pression : capteur instrument de référence
                    '
                    Dim tmp_croissant_pression_instrumentReference As New TextBox
                    tmp_croissant_pression_instrumentReference.Name = "croissant_pression_instrumentReference_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_pression_instrumentReference)
                    tmp_croissant_pression_instrumentReference.Parent = tmpPanelArrayglob_croissant_instrumentReference
                    tmp_croissant_pression_instrumentReference.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_pression_instrumentReference.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_pression_instrumentReference.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_pression_instrumentReference.TabStop = True
                    tmp_croissant_pression_instrumentReference.TabIndex = nTabIndex
                    AddHandler tmp_croissant_pression_instrumentReference.Validated, AddressOf updateResults
                    AddHandler tmp_croissant_pression_instrumentReference.KeyPress, AddressOf checkKeyPress
                    '
                    'Incertitude
                    '
                    Dim tmp_croissant_incertitude As New TextBox
                    tmp_croissant_incertitude.Name = "croissant_incertitude_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_incertitude)
                    tmp_croissant_incertitude.Parent = tmpPanelArrayglob_croissant_incertitude
                    tmp_croissant_incertitude.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_incertitude.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_incertitude.ReadOnly = True
                    tmp_croissant_incertitude.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_incertitude.TabStop = False
                    '                    AddHandler tmp_croissant_incertitude.Validated, AddressOf updateResults
                    '                   AddHandler tmp_croissant_incertitude.KeyPress, AddressOf checkKeyPress
                    '
                    'EMT
                    '
                    Dim tmp_croissant_EMT As New TextBox
                    tmp_croissant_EMT.Name = "croissant_EMT_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_EMT)
                    tmp_croissant_EMT.Parent = tmpPanelArrayglob_croissant_EMT
                    tmp_croissant_EMT.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_EMT.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_EMT.ReadOnly = True
                    tmp_croissant_EMT.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_EMT.TabStop = False
                    '                  AddHandler tmp_croissant_EMT.TextChanged, AddressOf updateResults
                    '                 AddHandler tmp_croissant_EMT.KeyPress, AddressOf checkKeyPress
                    '
                    'Erreur : Absolue
                    '
                    Dim tmp_croissant_erreur_absolue As New TextBox
                    tmp_croissant_erreur_absolue.Name = "croissant_erreur_absolue_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_erreur_absolue)
                    tmp_croissant_erreur_absolue.Parent = tmpPanelArrayglob_croissant_erreurAbsolue
                    tmp_croissant_erreur_absolue.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_erreur_absolue.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_erreur_absolue.ReadOnly = True
                    tmp_croissant_erreur_absolue.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_erreur_absolue.TabStop = False
                    '
                    'Erreur : Fond Echelle
                    '
                    Dim tmp_croissant_erreur_fondEchelle As New TextBox
                    tmp_croissant_erreur_fondEchelle.Name = "croissant_erreur_fondEchelle_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_croissant_erreur_fondEchelle)
                    tmp_croissant_erreur_fondEchelle.Parent = tmpPanelArrayglob_croissant_erreurFondEchelle
                    tmp_croissant_erreur_fondEchelle.Location = New System.Drawing.Point(8, vPos)
                    tmp_croissant_erreur_fondEchelle.Size = New System.Drawing.Size(73, 20)
                    tmp_croissant_erreur_fondEchelle.ReadOnly = True
                    tmp_croissant_erreur_fondEchelle.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_croissant_erreur_fondEchelle.TabStop = False

                    ' DECROISSANT
                    Dim tmp_decroissant_label_pointsEssai As New Label
                    tmp_decroissant_label_pointsEssai.Name = "decroissant_pointsEssai_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_label_pointsEssai)
                    tmp_decroissant_label_pointsEssai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    tmp_decroissant_label_pointsEssai.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
                    tmp_decroissant_label_pointsEssai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
                    tmp_decroissant_label_pointsEssai.Location = New System.Drawing.Point(0, vPos)
                    tmp_decroissant_label_pointsEssai.Size = New System.Drawing.Size(89, 16)
                    tmp_decroissant_label_pointsEssai.Text = i
                    tmp_decroissant_label_pointsEssai.Parent = tmpPanelArrayglob_decroissant_pointEssai
                    tmp_decroissant_label_pointsEssai.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    '
                    'Pression : capteur testé
                    '
                    Dim tmp_decroissant_pression_capteurTeste As New TextBox
                    tmp_decroissant_pression_capteurTeste.Name = "decroissant_pression_capteurTeste_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_pression_capteurTeste)
                    tmp_decroissant_pression_capteurTeste.Parent = tmpPanelArrayglob_decroissant_capteurTeste
                    tmp_decroissant_pression_capteurTeste.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_pression_capteurTeste.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_pression_capteurTeste.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    'tmp_decroissant_pression_capteurTeste.Text = (nbMesures - i) * 2
                    tmp_decroissant_pression_capteurTeste.Text = tmpPressionsTest((nbMesures - i))
                    tmp_decroissant_pression_capteurTeste.TabStop = False
                    tmp_decroissant_pression_capteurTeste.ReadOnly = True
                    '
                    'Pression : capteur instrument de référence
                    '
                    Dim tmp_decroissant_pression_instrumentReference As New TextBox
                    tmp_decroissant_pression_instrumentReference.Name = "decroissant_pression_instrumentReference_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_pression_instrumentReference)
                    tmp_decroissant_pression_instrumentReference.Parent = tmpPanelArrayglob_decroissant_instrumentReference
                    tmp_decroissant_pression_instrumentReference.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_pression_instrumentReference.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_pression_instrumentReference.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    AddHandler tmp_decroissant_pression_instrumentReference.Validated, AddressOf updateResults
                    AddHandler tmp_decroissant_pression_instrumentReference.KeyPress, AddressOf checkKeyPress
                    '
                    'Incertitude
                    '
                    Dim tmp_decroissant_incertitude As New TextBox
                    tmp_decroissant_incertitude.Name = "decroissant_incertitude_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_incertitude)
                    tmp_decroissant_incertitude.Parent = tmpPanelArrayglob_decroissant_incertitude
                    tmp_decroissant_incertitude.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_incertitude.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_incertitude.ReadOnly = True
                    tmp_decroissant_incertitude.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    tmp_decroissant_incertitude.TabStop = False

                    '                    AddHandler tmp_decroissant_incertitude.TextChanged, AddressOf updateResults
                    '                   AddHandler tmp_decroissant_incertitude.KeyPress, AddressOf checkKeyPress
                    '
                    'EMT
                    '
                    Dim tmp_decroissant_EMT As New TextBox
                    tmp_decroissant_EMT.Name = "decroissant_EMT_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_EMT)
                    tmp_decroissant_EMT.Parent = tmpPanelArrayglob_decroissant_EMT
                    tmp_decroissant_EMT.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_EMT.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_EMT.ReadOnly = True
                    tmp_decroissant_EMT.TabStop = False
                    tmp_decroissant_EMT.Tag = "croissant|" & i & "|" & tmpManoControle.numeroNational
                    '                  AddHandler tmp_decroissant_EMT.TextChanged, AddressOf updateResults
                    '                 AddHandler tmp_decroissant_EMT.KeyPress, AddressOf checkKeyPress
                    '
                    'Erreur : Absolue
                    '
                    Dim tmp_decroissant_erreur_absolue As New TextBox
                    tmp_decroissant_erreur_absolue.Name = "decroissant_erreur_absolue_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_erreur_absolue)
                    tmp_decroissant_erreur_absolue.Parent = tmpPanelArrayglob_decroissant_erreurAbsolue
                    tmp_decroissant_erreur_absolue.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_erreur_absolue.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_erreur_absolue.ReadOnly = True
                    tmp_decroissant_erreur_absolue.TabStop = False
                    tmp_decroissant_erreur_absolue.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                    '
                    'Erreur : Absolue
                    '
                    Dim tmp_decroissant_erreur_fondEchelle As New TextBox
                    tmp_decroissant_erreur_fondEchelle.Name = "decroissant_erreur_fondEchelle_" & i & "_" & tmpManoControle.numeroNational
                    Controls.Add(tmp_decroissant_erreur_fondEchelle)
                    tmp_decroissant_erreur_fondEchelle.Parent = tmpPanelArrayglob_decroissant_erreurFondEchelle
                    tmp_decroissant_erreur_fondEchelle.Location = New System.Drawing.Point(8, vPos)
                    tmp_decroissant_erreur_fondEchelle.Size = New System.Drawing.Size(73, 20)
                    tmp_decroissant_erreur_fondEchelle.ReadOnly = True
                    tmp_decroissant_erreur_fondEchelle.TabStop = False
                    tmp_decroissant_erreur_fondEchelle.Tag = "decroissant|" & i & "|" & tmpManoControle.numeroNational
                Catch ex As Exception
                    CSDebug.dispError("Controle Mano - Chargement onglets : " & ex.Message.ToString)
                End Try

                vPos = vPos + 24
            Next i
            '
            'Titre Infos Mano
            '
            Dim tmp_titleInfosMano As New Label
            tmp_titleInfosMano.Name = "label_titleResultat_" & tmpManoControle.numeroNational
            Controls.Add(tmp_titleInfosMano)
            tmp_titleInfosMano.BackColor = System.Drawing.Color.Transparent
            tmp_titleInfosMano.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_titleInfosMano.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
            tmp_titleInfosMano.Image = CType(resources.GetObject("Label37.Image"), System.Drawing.Image)
            tmp_titleInfosMano.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            tmp_titleInfosMano.Location = New System.Drawing.Point(744, 8)
            tmp_titleInfosMano.Size = New System.Drawing.Size(230, 16)
            tmp_titleInfosMano.Text = "      Mano à contrôler"
            tmp_titleInfosMano.Parent = tmpTab
            '
            'Info mano marque
            '
            Dim tmp_libelleInfosMano_marque As New Label
            tmp_libelleInfosMano_marque.Name = "label_libelleInfosMano_marque_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_marque)
            tmp_libelleInfosMano_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_marque.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_marque.Location = New System.Drawing.Point(736, 48)
            tmp_libelleInfosMano_marque.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_marque.TabIndex = 10
            tmp_libelleInfosMano_marque.Text = "Marque :"
            tmp_libelleInfosMano_marque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_marque.Parent = tmpTab
            '
            'Info mano classe
            '
            Dim tmp_libelleInfosMano_classe As New Label
            tmp_libelleInfosMano_classe.Name = "label_libelleInfosMano_classe_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_classe)
            tmp_libelleInfosMano_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_classe.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_classe.Location = New System.Drawing.Point(736, 64)
            tmp_libelleInfosMano_classe.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_classe.TabIndex = 10
            tmp_libelleInfosMano_classe.Text = "Classe :"
            tmp_libelleInfosMano_classe.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_classe.Parent = tmpTab
            '
            'Info mano fond echelle
            '
            Dim tmp_libelleInfosMano_fondEchelle As New Label
            tmp_libelleInfosMano_fondEchelle.Name = "label_libelleInfosMano_fondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_fondEchelle)
            tmp_libelleInfosMano_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_fondEchelle.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_fondEchelle.Location = New System.Drawing.Point(736, 80)
            tmp_libelleInfosMano_fondEchelle.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_fondEchelle.TabIndex = 10
            tmp_libelleInfosMano_fondEchelle.Text = "Fond d'échelle :"
            tmp_libelleInfosMano_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_fondEchelle.Parent = tmpTab
            '
            'Info mano reference
            '
            Dim tmp_libelleInfosMano_reference As New Label
            tmp_libelleInfosMano_reference.Name = "label_libelleInfosMano_reference_" & tmpManoControle.numeroNational
            Controls.Add(tmp_libelleInfosMano_reference)
            tmp_libelleInfosMano_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_libelleInfosMano_reference.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(125, Byte), CType(192, Byte))
            tmp_libelleInfosMano_reference.Location = New System.Drawing.Point(736, 32)
            tmp_libelleInfosMano_reference.Size = New System.Drawing.Size(120, 16)
            tmp_libelleInfosMano_reference.TabIndex = 10
            tmp_libelleInfosMano_reference.Text = "N° identifiant :"
            tmp_libelleInfosMano_reference.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            tmp_libelleInfosMano_reference.Parent = tmpTab
            '
            'labelInfo_reference
            '
            Dim tmp_valueInfosMano_reference As New Label
            tmp_valueInfosMano_reference.Name = "label_valueInfosMano_reference_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_reference)
            tmp_valueInfosMano_reference.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_reference.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_reference.Location = New System.Drawing.Point(856, 32)
            tmp_valueInfosMano_reference.Name = "labelInfo_reference"
            tmp_valueInfosMano_reference.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_reference.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_reference.Parent = tmpTab
            tmp_valueInfosMano_reference.Text = tmpManoControle.idCrodip
            '
            'labelInfo_marque
            '
            Dim tmp_valueInfosMano_marque As New Label
            tmp_valueInfosMano_marque.Name = "label_valueInfosMano_marque_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_marque)
            tmp_valueInfosMano_marque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_marque.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_marque.Location = New System.Drawing.Point(856, 48)
            tmp_valueInfosMano_marque.Name = "labelInfo_marque"
            tmp_valueInfosMano_marque.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_marque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_marque.Parent = tmpTab
            tmp_valueInfosMano_marque.Text = tmpManoControle.marque
            '
            'labelInfo_classe
            '
            Dim tmp_valueInfosMano_classe As New Label
            tmp_valueInfosMano_classe.Name = "label_valueInfosMano_classe_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_classe)
            tmp_valueInfosMano_classe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_classe.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_classe.Location = New System.Drawing.Point(856, 64)
            tmp_valueInfosMano_classe.Name = "labelInfo_classe"
            tmp_valueInfosMano_classe.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_classe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_classe.Parent = tmpTab
            tmp_valueInfosMano_classe.Text = tmpManoControle.classe
            '
            'labelInfo_fondEchelle
            '
            Dim tmp_valueInfosMano_fondEchelle As New Label
            tmp_valueInfosMano_fondEchelle.Name = "label_valueInfosMano_fondEchelle_" & tmpManoControle.numeroNational
            Controls.Add(tmp_valueInfosMano_fondEchelle)
            tmp_valueInfosMano_fondEchelle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_valueInfosMano_fondEchelle.ForeColor = System.Drawing.Color.Black
            tmp_valueInfosMano_fondEchelle.Location = New System.Drawing.Point(856, 80)
            tmp_valueInfosMano_fondEchelle.Name = "labelInfo_fondEchelle"
            tmp_valueInfosMano_fondEchelle.Size = New System.Drawing.Size(104, 16)
            tmp_valueInfosMano_fondEchelle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            tmp_valueInfosMano_fondEchelle.Parent = tmpTab
            tmp_valueInfosMano_fondEchelle.Text = tmpManoControle.fondEchelle
            '
            'Titre Résultat
            '
            Dim tmp_titleResultat As New Label
            tmp_titleResultat.Name = "label_titleResultat_" & tmpManoControle.numeroNational
            Controls.Add(tmp_titleResultat)
            tmp_titleResultat.BackColor = System.Drawing.Color.Transparent
            tmp_titleResultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_titleResultat.ForeColor = System.Drawing.Color.FromArgb(CType(2, Byte), CType(129, Byte), CType(198, Byte))
            tmp_titleResultat.Image = CType(resources.GetObject("Label34.Image"), System.Drawing.Image)
            tmp_titleResultat.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            tmp_titleResultat.Location = New System.Drawing.Point(744, 208)
            tmp_titleResultat.Size = New System.Drawing.Size(160, 16)
            tmp_titleResultat.Text = "     Résultat de l'essai"
            tmp_titleResultat.Parent = tmpTab
            '
            'Résultat
            '
            Dim tmp_resultat As New Label
            tmp_resultat.Name = "label_resultat_" & tmpManoControle.numeroNational
            Controls.Add(tmp_resultat)
            tmp_resultat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_resultat.ForeColor = System.Drawing.Color.Green
            tmp_resultat.Location = New System.Drawing.Point(736, 224)
            tmp_resultat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmp_resultat.Size = New System.Drawing.Size(224, 87)
            tmp_resultat.Text = ""
            tmp_resultat.Parent = tmpTab
            '
            'btn_controleManos_valider
            '
            Dim tmp_btnValider As New Label
            tmp_btnValider.Name = "btn_valider_" & tmpManoControle.numeroNational
            Controls.Add(tmp_btnValider)
            tmp_btnValider.Parent = tmpTab
            tmp_btnValider.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            tmp_btnValider.ForeColor = System.Drawing.Color.White
            tmp_btnValider.Image = CType(resources.GetObject("btn_controleManos_valider.Image"), System.Drawing.Image)
            tmp_btnValider.Location = New System.Drawing.Point(852, 568)
            tmp_btnValider.Size = New System.Drawing.Size(128, 24)
            tmp_btnValider.Text = "    Valider / Quitter"
            tmp_btnValider.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            tmp_btnValider.Enabled = True

            AddHandler tmp_btnValider.Click, AddressOf btn_controleManos_valider_Click
            tmp_btnValider.Enabled = False
            btn_controleManos_suivant.Enabled = False
        Next

        ' Placer la puce sur onglet courant
        'prevSelectedManoOnglet = ongletsManos.SelectedTab.TabIndex
        SelectMano()

    End Sub

#Region " Récupération des données du controle "
    Private Function createControleMano(ByVal pMano As ManometreControle, pidManoEtalon As String) As ControleMano

        Dim oCtrlMano As ControleMano = New ControleMano(m_oAgent)
        '        newObject.id = ControleManoManager.create(pagent)
        '########################################################
        oCtrlMano.idStructure = pMano.idStructure
        oCtrlMano.idMano = pMano.numeroNational
        oCtrlMano.manoEtalon = pidManoEtalon
        oCtrlMano.tempAir = TextBox41.Text
        oCtrlMano.resultat = pMano.etat
        oCtrlMano.DateVerif = CSDate.ToCRODIPString(Date.Now).ToString
        '# Mesures Croissantes
        ' Mesure n°1
        Dim input_up_pt1_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_pres_manoCtrl = input_up_pt1_pres_manoCtrl.Text
        Dim input_up_pt1_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_pres_manoEtalon = input_up_pt1_pres_manoEtalon.Text
        Dim input_up_pt1_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_incertitude = input_up_pt1_incertitude.Text
        Dim input_up_pt1_EMT As TextBox = CSForm.getControlByName("croissant_EMT_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_EMT = input_up_pt1_EMT.Text
        Dim input_up_pt1_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_err_abs = input_up_pt1_err_abs.Text
        Dim input_up_pt1_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_1_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt1_err_fondEchelle = input_up_pt1_err_fondEchelle.Text
        oCtrlMano.up_pt1_conformite = "1"
        If input_up_pt1_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt1_conformite = "0"
        End If
        ' Mesure n°2
        Dim input_up_pt2_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_pres_manoCtrl = input_up_pt2_pres_manoCtrl.Text
        Dim input_up_pt2_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_pres_manoEtalon = input_up_pt2_pres_manoEtalon.Text
        Dim input_up_pt2_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_incertitude = input_up_pt2_incertitude.Text
        Dim input_up_pt2_EMT As TextBox = CSForm.getControlByName("croissant_EMT_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_EMT = input_up_pt2_EMT.Text
        Dim input_up_pt2_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_err_abs = input_up_pt2_err_abs.Text
        Dim input_up_pt2_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_2_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt2_err_fondEchelle = input_up_pt2_err_fondEchelle.Text
        oCtrlMano.up_pt2_conformite = "1"
        If input_up_pt2_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt2_conformite = "0"
        End If
        ' Mesure n°3
        Dim input_up_pt3_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_pres_manoCtrl = input_up_pt3_pres_manoCtrl.Text
        Dim input_up_pt3_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_pres_manoEtalon = input_up_pt3_pres_manoEtalon.Text
        Dim input_up_pt3_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_incertitude = input_up_pt3_incertitude.Text
        Dim input_up_pt3_EMT As TextBox = CSForm.getControlByName("croissant_EMT_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_EMT = input_up_pt3_EMT.Text
        Dim input_up_pt3_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_err_abs = input_up_pt3_err_abs.Text
        Dim input_up_pt3_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_3_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt3_err_fondEchelle = input_up_pt3_err_fondEchelle.Text
        oCtrlMano.up_pt3_conformite = "1"
        If input_up_pt3_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt3_conformite = "0"
        End If
        ' Mesure n°4
        Dim input_up_pt4_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_pres_manoCtrl = input_up_pt4_pres_manoCtrl.Text
        Dim input_up_pt4_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_pres_manoEtalon = input_up_pt4_pres_manoEtalon.Text
        Dim input_up_pt4_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_incertitude = input_up_pt4_incertitude.Text
        Dim input_up_pt4_EMT As TextBox = CSForm.getControlByName("croissant_EMT_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_EMT = input_up_pt4_EMT.Text
        Dim input_up_pt4_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_err_abs = input_up_pt4_err_abs.Text
        Dim input_up_pt4_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_4_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt4_err_fondEchelle = input_up_pt4_err_fondEchelle.Text
        oCtrlMano.up_pt4_conformite = "1"
        If input_up_pt4_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt4_conformite = "0"
        End If
        ' Mesure n°5
        Dim input_up_pt5_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_pres_manoCtrl = input_up_pt5_pres_manoCtrl.Text
        Dim input_up_pt5_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_pres_manoEtalon = input_up_pt5_pres_manoEtalon.Text
        Dim input_up_pt5_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_incertitude = input_up_pt5_incertitude.Text
        Dim input_up_pt5_EMT As TextBox = CSForm.getControlByName("croissant_EMT_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_EMT = input_up_pt5_EMT.Text
        Dim input_up_pt5_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_err_abs = input_up_pt5_err_abs.Text
        Dim input_up_pt5_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_5_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt5_err_fondEchelle = input_up_pt5_err_fondEchelle.Text
        oCtrlMano.up_pt5_conformite = "1"
        If input_up_pt5_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt5_conformite = "0"
        End If
        ' Mesure n°6
        Dim input_up_pt6_pres_manoCtrl As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_pres_manoCtrl = input_up_pt6_pres_manoCtrl.Text
        Dim input_up_pt6_pres_manoEtalon As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_pres_manoEtalon = input_up_pt6_pres_manoEtalon.Text
        Dim input_up_pt6_incertitude As TextBox = CSForm.getControlByName("croissant_incertitude_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_incertitude = input_up_pt6_incertitude.Text
        Dim input_up_pt6_EMT As TextBox = CSForm.getControlByName("croissant_EMT_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_EMT = input_up_pt6_EMT.Text
        Dim input_up_pt6_err_abs As TextBox = CSForm.getControlByName("croissant_erreur_absolue_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_err_abs = input_up_pt6_err_abs.Text
        Dim input_up_pt6_err_fondEchelle As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_6_" & pMano.numeroNational, Me)
        oCtrlMano.up_pt6_err_fondEchelle = input_up_pt6_err_fondEchelle.Text
        oCtrlMano.up_pt6_conformite = "1"
        If input_up_pt6_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.up_pt6_conformite = "0"
        End If

        '# Mesures Décroissantes
        ' Mesure n°1
        Dim input_down_pt1_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_pres_manoCtrl = input_down_pt1_pres_manoCtrl.Text
        Dim input_down_pt1_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_pres_manoEtalon = input_down_pt1_pres_manoEtalon.Text
        Dim input_down_pt1_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_incertitude = input_down_pt1_incertitude.Text
        Dim input_down_pt1_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_EMT = input_down_pt1_EMT.Text
        Dim input_down_pt1_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_err_abs = input_down_pt1_err_abs.Text
        Dim input_down_pt1_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_1_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt1_err_fondEchelle = input_down_pt1_err_fondEchelle.Text
        oCtrlMano.down_pt1_conformite = "1"
        If input_down_pt1_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt1_conformite = "0"
        End If
        ' Mesure n°2
        Dim input_down_pt2_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_pres_manoCtrl = input_down_pt2_pres_manoCtrl.Text
        Dim input_down_pt2_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_pres_manoEtalon = input_down_pt2_pres_manoEtalon.Text
        Dim input_down_pt2_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_incertitude = input_down_pt2_incertitude.Text
        Dim input_down_pt2_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_EMT = input_down_pt2_EMT.Text
        Dim input_down_pt2_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_err_abs = input_down_pt2_err_abs.Text
        Dim input_down_pt2_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_2_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt2_err_fondEchelle = input_down_pt2_err_fondEchelle.Text
        oCtrlMano.down_pt2_conformite = "1"
        If input_down_pt2_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt2_conformite = "0"
        End If
        ' Mesure n°3
        Dim input_down_pt3_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_pres_manoCtrl = input_down_pt3_pres_manoCtrl.Text
        Dim input_down_pt3_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_pres_manoEtalon = input_down_pt3_pres_manoEtalon.Text
        Dim input_down_pt3_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_incertitude = input_down_pt3_incertitude.Text
        Dim input_down_pt3_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_EMT = input_down_pt3_EMT.Text
        Dim input_down_pt3_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_err_abs = input_down_pt3_err_abs.Text
        Dim input_down_pt3_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_3_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt3_err_fondEchelle = input_down_pt3_err_fondEchelle.Text
        oCtrlMano.down_pt3_conformite = "1"
        If input_down_pt3_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt3_conformite = "0"
        End If
        ' Mesure n°4
        Dim input_down_pt4_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_pres_manoCtrl = input_down_pt4_pres_manoCtrl.Text
        Dim input_down_pt4_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_pres_manoEtalon = input_down_pt4_pres_manoEtalon.Text
        Dim input_down_pt4_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_incertitude = input_down_pt4_incertitude.Text
        Dim input_down_pt4_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_EMT = input_down_pt4_EMT.Text
        Dim input_down_pt4_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_err_abs = input_down_pt4_err_abs.Text
        Dim input_down_pt4_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_4_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt4_err_fondEchelle = input_down_pt4_err_fondEchelle.Text
        oCtrlMano.down_pt4_conformite = "1"
        If input_down_pt4_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt4_conformite = "0"
        End If
        ' Mesure n°5
        Dim input_down_pt5_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_pres_manoCtrl = input_down_pt5_pres_manoCtrl.Text
        Dim input_down_pt5_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_pres_manoEtalon = input_down_pt5_pres_manoEtalon.Text
        Dim input_down_pt5_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_incertitude = input_down_pt5_incertitude.Text
        Dim input_down_pt5_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_EMT = input_down_pt5_EMT.Text
        Dim input_down_pt5_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_err_abs = input_down_pt5_err_abs.Text
        Dim input_down_pt5_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_5_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt5_err_fondEchelle = input_down_pt5_err_fondEchelle.Text
        oCtrlMano.down_pt5_conformite = "1"
        If input_down_pt5_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt5_conformite = "0"
        End If
        ' Mesure n°6
        Dim input_down_pt6_pres_manoCtrl As TextBox = CSForm.getControlByName("decroissant_pression_capteurTeste_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_pres_manoCtrl = input_down_pt6_pres_manoCtrl.Text
        Dim input_down_pt6_pres_manoEtalon As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_pres_manoEtalon = input_down_pt6_pres_manoEtalon.Text
        Dim input_down_pt6_incertitude As TextBox = CSForm.getControlByName("decroissant_incertitude_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_incertitude = input_down_pt6_incertitude.Text
        Dim input_down_pt6_EMT As TextBox = CSForm.getControlByName("decroissant_EMT_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_EMT = input_down_pt6_EMT.Text
        Dim input_down_pt6_err_abs As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_err_abs = input_down_pt6_err_abs.Text
        Dim input_down_pt6_err_fondEchelle As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_6_" & pMano.numeroNational, Me)
        oCtrlMano.down_pt6_err_fondEchelle = input_down_pt6_err_fondEchelle.Text
        oCtrlMano.down_pt6_conformite = "1"
        If input_down_pt6_err_fondEchelle.ForeColor.Equals(System.Drawing.Color.Red) Then
            oCtrlMano.down_pt6_conformite = "0"
        End If

        '########################################################
        Dim tmpTab As TabPage
        'tmpTab = CSForm.getControlByName("tabPage_mano_" & curManoControle.numeroNational, ongletsManos)
        For i As Integer = 1 To nbMesures
            ' On récupère les controles
            Dim tmp_pression_capteurTeste As TextBox = CSForm.getControlByName("croissant_pression_capteurTeste_" & i & "_" & curManoControle.numeroNational, tmpTab)
            Dim tmp_pression_instrumentReference As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curManoControle.numeroNational, tmpTab)
            oCtrlMano.PressionControle = oCtrlMano.PressionControle & "|" & tmp_pression_instrumentReference.Text
            oCtrlMano.ValeursMesurees = oCtrlMano.ValeursMesurees & "|" & tmp_pression_capteurTeste.Text
        Next

        Return oCtrlMano

    End Function
#End Region

#Region " Calculs "

    ' Test si le mano est fiable
    Public Function checkMano(ByVal curMano As ManometreControle) As Boolean
        ' Init
        Dim nbMesures As Integer = 6
        Dim maxEcart As Double = 0

        ' 
        Dim isFiable As Boolean = True
        Dim isSaisieComplete As Boolean = True

        ' On récupère la classe de précision du mano courant
        'Dim tmpClassePrecision As Double
        'tmpClassePrecision = Globals.StringToDouble(curMano.classe)

        ' On récupère l'écart maximum
        For i As Integer = 1 To nbMesures
            Try
                Dim tmpInputCroissantIntrumentReference As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissantIntrumentReference As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputCroissant As TextBox = CSForm.getControlByName("croissant_erreur_fondEchelle_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissant As TextBox = CSForm.getControlByName("decroissant_erreur_fondEchelle_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputErreurAbsolueCroissant As TextBox = CSForm.getControlByName("croissant_erreur_absolue_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputErreurAbsolueDecroissant As TextBox = CSForm.getControlByName("decroissant_erreur_absolue_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputIncetitudeCroissant As TextBox = CSForm.getControlByName("croissant_incertitude_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputIncetitudeDecroissant As TextBox = CSForm.getControlByName("decroissant_incertitude_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputEmtCroissant As TextBox = CSForm.getControlByName("croissant_EMT_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputEmtDecroissant As TextBox = CSForm.getControlByName("decroissant_EMT_" & i & "_" & curMano.numeroNational, Me)

                Dim tmpValueCroissant As Double = 0.0
                Dim tmpValueDecroissant As Double = 0.0
                Dim tmpValueIncetitudeCroissant As Double = 0.0
                Dim tmpValueIncetitudeDecroissant As Double = 0.0
                Dim tmpValueEmtCroissant As Double = 0.0
                Dim tmpValueEmtDecroissant As Double = 0.0
                tmpValueCroissant = Globals.StringToDouble(tmpInputCroissant.Text)
                tmpValueDecroissant = Globals.StringToDouble(tmpInputDecroissant.Text)
                tmpValueIncetitudeCroissant = Globals.StringToDouble(tmpInputIncetitudeCroissant.Text)
                tmpValueIncetitudeDecroissant = Globals.StringToDouble(tmpInputIncetitudeDecroissant.Text)
                tmpValueEmtCroissant = Globals.StringToDouble(tmpInputEmtCroissant.Text)
                tmpValueEmtDecroissant = Globals.StringToDouble(tmpInputEmtDecroissant.Text)

                '##############################################################################################
                'If tmpValueCroissant > maxEcart Then
                '    maxEcart = tmpValueCroissant
                '    If tmpValueCroissant <= tmpClassePrecision Then
                '        tmpInputCroissant.ForeColor = System.Drawing.Color.Green
                '        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Green
                '    Else
                '        tmpInputCroissant.ForeColor = System.Drawing.Color.Red
                '        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Red
                '    End If
                'End If

                'If tmpValueDecroissant > maxEcart Then
                '    maxEcart = tmpValueDecroissant
                '    If tmpValueDecroissant <= tmpClassePrecision Then
                '        tmpInputDecroissant.ForeColor = System.Drawing.Color.Green
                '        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Green
                '    Else
                '        tmpInputDecroissant.ForeColor = System.Drawing.Color.Red
                '        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Red
                '    End If
                'End If
                '##############################################################################################

                '28/08/12 MCO Changement de mode de cacul
                'on compare l'ecart absolu avec l'EMT (Ecart Maximum toléré) sans prendre en compte l'incertitude
                ' Croissant
                If Not String.IsNullOrEmpty(tmpInputErreurAbsolueCroissant.Text) Then
                    If Math.Abs(Globals.StringToDouble(tmpInputErreurAbsolueCroissant.Text)) <= tmpValueEmtCroissant Then
                        tmpInputCroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputCroissantIntrumentReference.ForeColor = System.Drawing.Color.Green
                    Else
                        isFiable = False
                        tmpInputCroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputErreurAbsolueCroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputCroissantIntrumentReference.ForeColor = System.Drawing.Color.Red
                    End If
                Else
                    isSaisieComplete = False
                End If

                ' Decroissant
                If Not String.IsNullOrEmpty(tmpInputErreurAbsolueDecroissant.Text) Then
                    If Math.Abs(Globals.StringToDouble(tmpInputErreurAbsolueDecroissant.Text)) <= tmpValueEmtDecroissant Then
                        tmpInputDecroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Green
                        tmpInputDecroissantIntrumentReference.ForeColor = System.Drawing.Color.Green
                    Else
                        isFiable = False
                        tmpInputDecroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputErreurAbsolueDecroissant.ForeColor = System.Drawing.Color.Red
                        tmpInputDecroissantIntrumentReference.ForeColor = System.Drawing.Color.Red
                    End If
                Else
                    isSaisieComplete = False

                End If

                '##############################################################################################

            Catch ex As Exception
                CSDebug.dispError("controle_manomtres::checkMano(" & curMano.numeroNational & ") : " & ex.Message.ToString)
                Return False
            End Try
        Next

        '

        ' NEW
        Return isFiable

        ' On vérifie la fiabilité
        'If maxEcart <= tmpClassePrecision Then
        ' Return True
        ' Else
        'Return False
        'End If

    End Function

    Public Function isSaisieComplete(ByVal curMano As ManometreControle) As Boolean
        ' Init
        Dim nbMesures As Integer = 6
        Dim bisSaisieComplete As Boolean = True


        ' On récupère l'écart maximum
        For i As Integer = 1 To nbMesures
            Try
                Dim tmpInputCroissant As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissant As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)

                ' Croissant
                If String.IsNullOrEmpty(tmpInputCroissant.Text) Then
                    bisSaisieComplete = False
                End If

                ' Decroissant
                If String.IsNullOrEmpty(tmpInputDecroissant.Text) Then
                    bisSaisieComplete = False
                End If

                '##############################################################################################

            Catch ex As Exception
                CSDebug.dispError("controle_manomtres::isSaisieComplete() : " & ex.Message.ToString)
                Return False
            End Try
        Next

        '

        ' NEW
        Return bisSaisieComplete

    End Function
    Public Function isSaisieCommencee(ByVal curMano As ManometreControle) As Boolean
        ' Init
        Dim nbMesures As Integer = 6
        Dim bisSaisieCommence As Boolean = True
        Dim bbSaisie As Integer = 0

        ' On récupère l'écart maximum
        For i As Integer = 1 To nbMesures
            Try
                Dim tmpInputCroissant As TextBox = CSForm.getControlByName("croissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)
                Dim tmpInputDecroissant As TextBox = CSForm.getControlByName("decroissant_pression_instrumentReference_" & i & "_" & curMano.numeroNational, Me)

                ' Croissant
                If Not String.IsNullOrEmpty(tmpInputCroissant.Text) Then
                    bbSaisie = bbSaisie + 1
                End If

                ' Decroissant
                If Not String.IsNullOrEmpty(tmpInputDecroissant.Text) Then
                    bbSaisie = bbSaisie + 1
                End If

                bisSaisieCommence = bbSaisie > 0
                '##############################################################################################

            Catch ex As Exception
                CSDebug.dispError("controle_manomtres::isSaisieCommence() : " & ex.Message.ToString)
                bisSaisieCommence = True
            End Try
        Next

        Return bisSaisieCommence

    End Function
#End Region


#Region " Boutons "

    ' Fonction de validation du contrôle
    Private Function validControl() As Boolean
        Dim bReturn As Boolean
        Try

            'On met a jour le mano
            curManoControle.etat = checkMano(curManoControle)
            curManoControle.dateDernierControleS = CSDate.ToCRODIPString(Date.Now).ToString
            curManoControle.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            ManometreControleManager.save(curManoControle)


            ' On enregistre les mesures
            Dim oControleMano As ControleMano
            oControleMano = Me.createControleMano(curManoControle, list_manometresEtalon.SelectedItem.id)

            ' On construit notre nouvelle fiche de vie
            curManoControle.creerfFicheVieControle(m_oAgent, oControleMano)





            ' Message de confirmation
            Dim tmpMessageConfirm As String
            If curManoControle.etat Then
                tmpMessageConfirm = "Votre manomètre est fiable : il répond à sa classe de précision."
            Else
                tmpMessageConfirm = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
            End If

            ' On flag le mano etalon comme etant utilise
            ' On récupère le mano
            Dim tmpManometreEtalon As ManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational(list_manometresEtalon.SelectedItem.Id)
            ' On le flag
            ManometreEtalonManager.setUtilise(m_oAgent, tmpManometreEtalon)


            MsgBox(tmpMessageConfirm)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("controle_manometres::validControl : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Bouton "Suivant"
    Private Sub btn_controleManos_suivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleManos_suivant.Click
        If TextBox41.Text <> "" Then
            validControl()
            '            ongletsManos.SelectedIndex = ongletsManos.SelectedIndex() + 1
        Else
            MsgBox("Veuillez remplir le champ température pour continuer", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        End If
    End Sub

    ' Bouton "Valider"
    Private Sub btn_controleManos_valider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If TextBox41.Text <> "" Then
            validControl()
            TryCast(MdiParent, parentContener).ReturnToAccueil()
        Else
            MsgBox("Veuillez remplir le champ température pour continuer", MsgBoxStyle.OkOnly, "Crodip .::. Attention !")
        End If
    End Sub

    ' Bouton "Annuler"
    Private Sub btn_controleBanc_annuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_controleBanc_annuler.Click
        TryCast(MdiParent, parentContener).ReturnToAccueil()
    End Sub

#End Region

#Region " Events "

    ' Selection du manometre étalon
    Private Sub list_manometresEtalon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles list_manometresEtalon.SelectedIndexChanged
        Try
            ' On commence par récupérer le mano sélectionné
            Dim manoEtalon As New ManometreEtalon
            manoEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational(sender.SelectedItem.Id)
            Me.curManoEtalon = manoEtalon

            'labelInfoEtalon_reference.Text = manoEtalon.idCrodip
            'labelInfoEtalon_marque.Text = manoEtalon.marque
            'labelInfoEtalon_classe.Text = manoEtalon.classe
            'labelInfoEtalon_fondEchelle.Text = manoEtalon.fondEchelle
            'ongletsManos.Enabled = True
        Catch ex As Exception
            CSDebug.dispError("Select Mano Etalon : " & ex.Message.ToString)
        End Try
    End Sub

    ' Calcul au chagement de contenu
    Private Sub updateResults(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim thisMano As ManometreControle
        Try
            ' Init
            Dim thisInput As TextBox = sender
            Dim tmpTagsValues As String() = thisInput.Tag.ToString.Split("|")
            Dim thisType As String = CType(tmpTagsValues(0), String)
            Dim thisNum As Integer = CType(tmpTagsValues(1), Integer)
            Dim thisManoNum As String = CType(tmpTagsValues(2), String)

            thisMano = ManometreControleManager.getManometreControleByNumeroNational(thisManoNum)

            ' On récupère les inputs
            Dim inputCapteurTeste As TextBox = CSForm.getControlByName(thisType & "_pression_capteurTeste_" & thisNum & "_" & thisManoNum, Me)
            Dim inputInstrumentReference As TextBox = CSForm.getControlByName(thisType & "_pression_instrumentReference_" & thisNum & "_" & thisManoNum, Me)
            Dim inputIncertitude As TextBox = CSForm.getControlByName(thisType & "_incertitude_" & thisNum & "_" & thisManoNum, Me)
            Dim inputEMT As TextBox = CSForm.getControlByName(thisType & "_EMT_" & thisNum & "_" & thisManoNum, Me)
            Dim inputErrAbsolue As TextBox = CSForm.getControlByName(thisType & "_erreur_absolue_" & thisNum & "_" & thisManoNum, Me)
            Dim inputErrFondEchelle As TextBox = CSForm.getControlByName(thisType & "_erreur_fondEchelle_" & thisNum & "_" & thisManoNum, Me)
            Dim BtnValider As Label = CSForm.getControlByName("btn_valider_" & thisMano.numeroNational, Me)

            Dim valueCapteurTeste As Double
            Dim valueInstrumentReference As Double
            Dim valueManoEtalon_fondEchelle As Double
            Dim valueMano_fondEchelle As Double
            Dim valueIncertitude As Double
            '            Dim valueEmt As Double
            Dim bCalc As Boolean
            Dim bCheck As Boolean


            If String.IsNullOrEmpty(inputCapteurTeste.Text) Or String.IsNullOrEmpty(inputInstrumentReference.Text) Then
                bCalc = False
            Else
                bCalc = True
            End If
            If bCalc Then

                ' On récupère les valeurs
                valueCapteurTeste = Globals.StringToDouble(inputCapteurTeste.Text)
                valueInstrumentReference = Globals.StringToDouble(inputInstrumentReference.Text)
                '               valueManoEtalon_fondEchelle = Globals.StringToDouble(labelInfoEtalon_fondEchelle.Text)
                valueMano_fondEchelle = Globals.StringToDouble(thisMano.fondEchelle)


                ' Incertitude
                valueIncertitude = 0
                If thisMano.resolution <> "" And curManoEtalon.incertitudeEtalon <> "" Then
                    valueIncertitude = calcIncertitude(thisMano.resolution_d, curManoEtalon.incertitudeEtalon_d)
                End If
                inputIncertitude.Text = valueIncertitude.ToString()

                ' EMT
                inputEMT.Text = calcEMT(thisMano)

                ' Calcul err absolue
                inputErrAbsolue.Text = Math.Round(Math.Abs(valueCapteurTeste - valueInstrumentReference), 3)
                inputErrFondEchelle.Text = Math.Round(Math.Abs(Math.Abs(valueCapteurTeste - valueInstrumentReference)) * 100 / valueMano_fondEchelle, 3)
            End If


            Dim tmpLabelResult As Label = CSForm.getControlByName("label_resultat_" & thisMano.numeroNational, Me)

            bCheck = checkMano(thisMano)
            If (isSaisieComplete(thisMano)) Then
                If bCheck Then
                    tmpLabelResult.Text = "Votre manomètre est fiable : il répond à sa classe de précision."
                    tmpLabelResult.ForeColor = System.Drawing.Color.Green
                Else
                    tmpLabelResult.Text = "Votre manomètre n'est pas fiable : il ne répond pas à sa classe de précision. Faites le remettre en état ou changez le."
                    tmpLabelResult.ForeColor = System.Drawing.Color.Red
                End If
                btn_controleManos_suivant.Enabled = True
                BtnValider.Enabled = True
            Else
                tmpLabelResult.Text = ""
                btn_controleManos_suivant.Enabled = False
                BtnValider.Enabled = False
            End If
        Catch ex As Exception
            CSDebug.dispError("Controle Manomètre :: updateResults(" & sender.Tag.ToString & ") : " & ex.Message.ToString)
        End Try
    End Sub
    Private Function calcIncertitude(pResolution As Double, pIncertitudeEtalon As Double) As Double
        Dim dReturn As Double
        Try

            dReturn = CDbl(Math.Round(2 * Math.Sqrt((pResolution / (2 * Math.Sqrt(3))) ^ 2 + (pIncertitudeEtalon / 2) ^ 2), 2))
        Catch ex As Exception
            dReturn = 0
        End Try

        Return dReturn
    End Function
    Private Function calcEMT(pMano As ManometreControle) As Double
        '''TODO : Mettre cette méthode dans la classe ManomètreControle
        Dim dReturn As Double
        Select Case pMano.fondEchelle
            Case "6"
                dReturn = 0.1
            Case "10"
                dReturn = 0.1
            Case "20"
                dReturn = 0.2
            Case "25"
                dReturn = 0.25
            Case Else
                dReturn = CDbl(Math.Round((Globals.StringToDouble(pMano.classe) * Globals.StringToDouble(pMano.fondEchelle) / 100), 2))
        End Select

        Return dReturn

    End Function
    Private Sub checkKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        CSForm.typeAllowed(e, "numerique")
        CSForm.forceDot(e, sender)
    End Sub

    ' Changement d'onglet
    Private Sub ongletsManos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ' Placer la puce sur onglet courant
        Dim sMano As String
        Dim oMano As ManometreControle
        Try
            'Si on avait pas de précédent
            If prevSelectedManoOnglet <> -1 Then
                '                If ongletsManos.SelectedIndex = prevSelectedManoOnglet Then
                'L'actuel est égal au précédent (Surement un refus de chabgement car pas complet)
                'on ne fait rien
                '            Else
                'on teste si le mano précédent était complet
                'If isSaisieComplete(curManoControle) Or Not isSaisieCommencee(curManoControle) Then
                'On change d'onglet
                '               ongletsManos.TabPages(prevSelectedManoOnglet).ImageIndex = -1
                '              prevSelectedManoOnglet = ongletsManos.SelectedTab.TabIndex
                '             btn_controleManos_suivant.Enabled = False
                'Else
                'on revient sur le précédent
                'ongletsManos.SelectedIndex = prevSelectedManoOnglet

                'End If
                '        End If

                SelectMano()
            End If


        Catch ex As Exception
            CSDebug.dispError("Puce onglet : " & ex.Message.ToString & " prevSelectedManoOnglet: " & prevSelectedManoOnglet)
        End Try
    End Sub
    Private Sub SelectMano()
        'On Positionne la puce
        'ongletsManos.SelectedTab.ImageIndex = 0
        'On Met en mano come courant
        'curManoControle = ManometreControleManager.getManometreControleByNumeroNational(ongletsManos.SelectedTab.Name.Replace("tabPage_mano_", ""))

    End Sub

#End Region

#Region " Acquisition des données "
    ' Bouton acquisitin des données
    Private Sub btn_controleManos_acquiring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Panel_loading.Visible = True
        doAcqiring()
    End Sub

    Private _thread_doAcqiring As Thread
    Private Sub thr_doAcqiring()

        Dim curMano As ManometreControle
        ' curMano = ManometreControleManager.getManometreControleByNumeroNational(ongletsManos.SelectedTab.Name.Replace("tabPage_mano_", ""))
        Dim nbBusesAcquis As Integer = AcquiringManager.getNbBuses(2)
        Dim isok As Boolean = (Me.nbMesures = nbBusesAcquis)
        If isok Then
            ' On récupère les buses de la table d'échange
            Dim arrBuses() As Acquiring = AcquiringManager.GetAcquiring()
            Dim prevIdNiveau As Integer = 0
            Dim curIdBuse As Integer = 0
            For Each tmpResponse As Acquiring In arrBuses
                Try
                    If tmpResponse.idBuse <> 0 Then
                        ' On injecte les valeurs
                        Try

                            Dim x As Control

                            If tmpResponse.idNiveau = 1 Then ' Croissante
                                'x = CSForm.getControlByName("croissant_pression_instrumentReference_" & tmpResponse.idBuse & "_" & curMano.numeroNational, ongletsManos)
                            Else ' Decroissante
                                Dim tmpId As Integer = tmpResponse.idBuse - Me.nbMesures
                                'x = CSForm.getControlByName("decroissant_pression_instrumentReference_" & tmpId & "_" & curMano.numeroNational, ongletsManos)
                            End If

                            x.Text = tmpResponse.debit.ToString

                        Catch ex As Exception
                            CSDebug.dispError("[x0C0004] : " & ex.Message)
                        End Try
                    End If
                Catch ex As Exception
                    CSDebug.dispError("[x0C0003] : " & ex.Message.ToString)
                End Try
            Next
            ' On vide la table d'échange
            'AcquiringManager.clearResults()
        Else
            MsgBox("Le nombre de buses acquises est différent du nombre de mesures nécéssaires. Veuillez vérifiez.")
        End If

        Panel_loading.Visible = False
    End Sub

    Public Sub doAcqiring()
        _thread_doAcqiring = New Thread(AddressOf thr_doAcqiring) 'ThrFunc est la fonction exécutée par le thread.
        _thread_doAcqiring.Name = "thr_doAcqiring" 'Il est parfois pratique de nommer les threads surtout si on en créé plusieurs.
        _thread_doAcqiring.Start() ' Démarrage du thread.
    End Sub

#End Region

    Private Sub ongletsManos_Click(sender As System.Object, e As System.EventArgs)
        Console.WriteLine("OngletMano.click")
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click_1(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub
End Class
