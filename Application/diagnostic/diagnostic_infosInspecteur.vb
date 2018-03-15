Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports iTextSharp
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.xml
Imports System.IO

Public Class diagnostic_infosInspecteur
    Inherits frmCRODIP

    'Private objInfos(15) As Object

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents diag_conseils As System.Windows.Forms.RichTextBox
    Friend WithEvents btn_finalisationDiag_imprimer As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents diagnosticRecap_infosInspecteur_nomOrganisme As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_infosInspecteur_numOrganisme As System.Windows.Forms.TextBox
    Friend WithEvents diagnosticRecap_infosInspecteur_prixControle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents listBusesUsed As System.Windows.Forms.ListBox
    Friend WithEvents btnOpenTool_volHa As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents panelTabRecapVolHa As System.Windows.Forms.Panel
    Friend WithEvents panelDosageBusesNeuves As System.Windows.Forms.Panel
    Friend WithEvents panelVitesse As System.Windows.Forms.Panel
    Friend WithEvents panelRapportBoite As System.Windows.Forms.Panel
    Friend WithEvents panelPressionBuses As System.Windows.Forms.Panel
    Friend WithEvents panelPressionManoPulve As System.Windows.Forms.Panel
    Friend WithEvents panelDosageBusesAppareil As System.Windows.Forms.Panel
    Friend WithEvents lblPressionManoPulve_1 As System.Windows.Forms.Label
    Friend WithEvents lblPressionBuses_1 As System.Windows.Forms.Label
    Friend WithEvents lblRapportBoite_1 As System.Windows.Forms.Label
    Friend WithEvents lblVitesse_1 As System.Windows.Forms.Label
    Friend WithEvents lblDosageBusesAppareil_1 As System.Windows.Forms.Label
    Friend WithEvents lblDosageBusesNeuves_1 As System.Windows.Forms.Label
    Friend WithEvents lblDosageBusesNeuves_2 As System.Windows.Forms.Label
    Friend WithEvents lblDosageBusesAppareil_2 As System.Windows.Forms.Label
    Friend WithEvents lblVitesse_2 As System.Windows.Forms.Label
    Friend WithEvents lblRapportBoite_2 As System.Windows.Forms.Label
    Friend WithEvents lblPressionBuses_2 As System.Windows.Forms.Label
    Friend WithEvents lblPressionManoPulve_2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btn_finalisationDiag_quitter As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(diagnostic_infosInspecteur))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.diag_conseils = New System.Windows.Forms.RichTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.diagnosticRecap_infosInspecteur_nomOrganisme = New System.Windows.Forms.TextBox()
        Me.diagnosticRecap_infosInspecteur_numOrganisme = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.diagnosticRecap_infosInspecteur_prixControle = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_imprimer = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.listBusesUsed = New System.Windows.Forms.ListBox()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.panelTabRecapVolHa = New System.Windows.Forms.Panel()
        Me.panelDosageBusesNeuves = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblDosageBusesNeuves_2 = New System.Windows.Forms.Label()
        Me.lblDosageBusesNeuves_1 = New System.Windows.Forms.Label()
        Me.panelVitesse = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblVitesse_2 = New System.Windows.Forms.Label()
        Me.lblVitesse_1 = New System.Windows.Forms.Label()
        Me.panelRapportBoite = New System.Windows.Forms.Panel()
        Me.lblRapportBoite_2 = New System.Windows.Forms.Label()
        Me.lblRapportBoite_1 = New System.Windows.Forms.Label()
        Me.panelPressionBuses = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblPressionBuses_2 = New System.Windows.Forms.Label()
        Me.lblPressionBuses_1 = New System.Windows.Forms.Label()
        Me.panelPressionManoPulve = New System.Windows.Forms.Panel()
        Me.lblPressionManoPulve_2 = New System.Windows.Forms.Label()
        Me.lblPressionManoPulve_1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.panelDosageBusesAppareil = New System.Windows.Forms.Panel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.lblDosageBusesAppareil_2 = New System.Windows.Forms.Label()
        Me.lblDosageBusesAppareil_1 = New System.Windows.Forms.Label()
        Me.btnOpenTool_volHa = New System.Windows.Forms.Label()
        Me.btn_finalisationDiag_quitter = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.panelTabRecapVolHa.SuspendLayout()
        Me.panelDosageBusesNeuves.SuspendLayout()
        Me.panelVitesse.SuspendLayout()
        Me.panelRapportBoite.SuspendLayout()
        Me.panelPressionBuses.SuspendLayout()
        Me.panelPressionManoPulve.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.panelDosageBusesAppareil.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.diag_conseils)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(992, 288)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Informations / Conseils de l'inspecteur"
        '
        'diag_conseils
        '
        Me.diag_conseils.Location = New System.Drawing.Point(16, 24)
        Me.diag_conseils.Name = "diag_conseils"
        Me.diag_conseils.Size = New System.Drawing.Size(968, 256)
        Me.diag_conseils.TabIndex = 0
        Me.diag_conseils.Text = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.diagnosticRecap_infosInspecteur_nomOrganisme)
        Me.GroupBox2.Controls.Add(Me.diagnosticRecap_infosInspecteur_numOrganisme)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox2.Location = New System.Drawing.Point(8, 544)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(488, 88)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Organisme préstataire"
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(44, 24)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(144, 16)
        Me.Label16.TabIndex = 16
        Me.Label16.Text = "Nom : "
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'diagnosticRecap_infosInspecteur_nomOrganisme
        '
        Me.diagnosticRecap_infosInspecteur_nomOrganisme.Location = New System.Drawing.Point(196, 24)
        Me.diagnosticRecap_infosInspecteur_nomOrganisme.Name = "diagnosticRecap_infosInspecteur_nomOrganisme"
        Me.diagnosticRecap_infosInspecteur_nomOrganisme.ReadOnly = True
        Me.diagnosticRecap_infosInspecteur_nomOrganisme.Size = New System.Drawing.Size(248, 20)
        Me.diagnosticRecap_infosInspecteur_nomOrganisme.TabIndex = 15
        '
        'diagnosticRecap_infosInspecteur_numOrganisme
        '
        Me.diagnosticRecap_infosInspecteur_numOrganisme.Location = New System.Drawing.Point(196, 48)
        Me.diagnosticRecap_infosInspecteur_numOrganisme.Name = "diagnosticRecap_infosInspecteur_numOrganisme"
        Me.diagnosticRecap_infosInspecteur_numOrganisme.ReadOnly = True
        Me.diagnosticRecap_infosInspecteur_numOrganisme.Size = New System.Drawing.Size(248, 20)
        Me.diagnosticRecap_infosInspecteur_numOrganisme.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(44, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "N° organisme prestataire : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.diagnosticRecap_infosInspecteur_prixControle)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox3.Location = New System.Drawing.Point(512, 544)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(488, 88)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Facturation"
        Me.GroupBox3.Visible = False
        '
        'diagnosticRecap_infosInspecteur_prixControle
        '
        Me.diagnosticRecap_infosInspecteur_prixControle.Location = New System.Drawing.Point(196, 24)
        Me.diagnosticRecap_infosInspecteur_prixControle.Name = "diagnosticRecap_infosInspecteur_prixControle"
        Me.diagnosticRecap_infosInspecteur_prixControle.ReadOnly = True
        Me.diagnosticRecap_infosInspecteur_prixControle.Size = New System.Drawing.Size(248, 20)
        Me.diagnosticRecap_infosInspecteur_prixControle.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(44, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(144, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Prix du contrôle € HT * : "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(472, 32)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "* Comme précisé dans le contrat commercial, le règlement du contrôle s’effectue a" & _
    "u comptant et sur place. Toutes les opérations de réparation ou maintenance sont" & _
    " facturées à part."
        '
        'btn_finalisationDiag_imprimer
        '
        Me.btn_finalisationDiag_imprimer.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_imprimer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_imprimer.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_imprimer.Image = CType(resources.GetObject("btn_finalisationDiag_imprimer.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_imprimer.Location = New System.Drawing.Point(872, 648)
        Me.btn_finalisationDiag_imprimer.Name = "btn_finalisationDiag_imprimer"
        Me.btn_finalisationDiag_imprimer.Size = New System.Drawing.Size(128, 24)
        Me.btn_finalisationDiag_imprimer.TabIndex = 34
        Me.btn_finalisationDiag_imprimer.Text = "    Imprimer"
        Me.btn_finalisationDiag_imprimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.listBusesUsed)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox4.Location = New System.Drawing.Point(8, 304)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(368, 232)
        Me.GroupBox4.TabIndex = 35
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Buse usées"
        '
        'listBusesUsed
        '
        Me.listBusesUsed.Items.AddRange(New Object() {"Niveau 1 : 1 ; 5 ; 10", "Niveau 2 : 1 ; 7", "Niveau 4 : 4 ; 5 ; 9 ; 10"})
        Me.listBusesUsed.Location = New System.Drawing.Point(8, 24)
        Me.listBusesUsed.Name = "listBusesUsed"
        Me.listBusesUsed.Size = New System.Drawing.Size(352, 199)
        Me.listBusesUsed.TabIndex = 0
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.panelTabRecapVolHa)
        Me.GroupBox5.Controls.Add(Me.btnOpenTool_volHa)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.GroupBox5.Location = New System.Drawing.Point(392, 304)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(608, 232)
        Me.GroupBox5.TabIndex = 35
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Calcul du volume/ha."
        '
        'panelTabRecapVolHa
        '
        Me.panelTabRecapVolHa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelTabRecapVolHa.Controls.Add(Me.panelDosageBusesNeuves)
        Me.panelTabRecapVolHa.Controls.Add(Me.panelVitesse)
        Me.panelTabRecapVolHa.Controls.Add(Me.panelRapportBoite)
        Me.panelTabRecapVolHa.Controls.Add(Me.panelPressionBuses)
        Me.panelTabRecapVolHa.Controls.Add(Me.panelPressionManoPulve)
        Me.panelTabRecapVolHa.Controls.Add(Me.Panel4)
        Me.panelTabRecapVolHa.Controls.Add(Me.Panel2)
        Me.panelTabRecapVolHa.Controls.Add(Me.Panel3)
        Me.panelTabRecapVolHa.Controls.Add(Me.Panel7)
        Me.panelTabRecapVolHa.Controls.Add(Me.Panel6)
        Me.panelTabRecapVolHa.Controls.Add(Me.Panel5)
        Me.panelTabRecapVolHa.Controls.Add(Me.panelDosageBusesAppareil)
        Me.panelTabRecapVolHa.Location = New System.Drawing.Point(16, 64)
        Me.panelTabRecapVolHa.Name = "panelTabRecapVolHa"
        Me.panelTabRecapVolHa.Size = New System.Drawing.Size(576, 152)
        Me.panelTabRecapVolHa.TabIndex = 35
        '
        'panelDosageBusesNeuves
        '
        Me.panelDosageBusesNeuves.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelDosageBusesNeuves.Controls.Add(Me.Label18)
        Me.panelDosageBusesNeuves.Controls.Add(Me.Label17)
        Me.panelDosageBusesNeuves.Controls.Add(Me.lblDosageBusesNeuves_2)
        Me.panelDosageBusesNeuves.Controls.Add(Me.lblDosageBusesNeuves_1)
        Me.panelDosageBusesNeuves.Location = New System.Drawing.Point(470, 40)
        Me.panelDosageBusesNeuves.Name = "panelDosageBusesNeuves"
        Me.panelDosageBusesNeuves.Size = New System.Drawing.Size(104, 110)
        Me.panelDosageBusesNeuves.TabIndex = 8
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(64, 46)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(29, 16)
        Me.Label18.TabIndex = 8
        Me.Label18.Text = "L/Ha"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(64, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(29, 16)
        Me.Label17.TabIndex = 7
        Me.Label17.Text = "L/Ha"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDosageBusesNeuves_2
        '
        Me.lblDosageBusesNeuves_2.Location = New System.Drawing.Point(7, 46)
        Me.lblDosageBusesNeuves_2.Name = "lblDosageBusesNeuves_2"
        Me.lblDosageBusesNeuves_2.Size = New System.Drawing.Size(57, 16)
        Me.lblDosageBusesNeuves_2.TabIndex = 2
        Me.lblDosageBusesNeuves_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDosageBusesNeuves_1
        '
        Me.lblDosageBusesNeuves_1.Location = New System.Drawing.Point(8, 16)
        Me.lblDosageBusesNeuves_1.Name = "lblDosageBusesNeuves_1"
        Me.lblDosageBusesNeuves_1.Size = New System.Drawing.Size(56, 16)
        Me.lblDosageBusesNeuves_1.TabIndex = 1
        Me.lblDosageBusesNeuves_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelVitesse
        '
        Me.panelVitesse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelVitesse.Controls.Add(Me.Label13)
        Me.panelVitesse.Controls.Add(Me.Label12)
        Me.panelVitesse.Controls.Add(Me.lblVitesse_2)
        Me.panelVitesse.Controls.Add(Me.lblVitesse_1)
        Me.panelVitesse.Location = New System.Drawing.Point(256, 40)
        Me.panelVitesse.Name = "panelVitesse"
        Me.panelVitesse.Size = New System.Drawing.Size(96, 110)
        Me.panelVitesse.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(56, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 16)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Km/h"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(56, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 16)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Km/h"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblVitesse_2
        '
        Me.lblVitesse_2.Location = New System.Drawing.Point(7, 46)
        Me.lblVitesse_2.Name = "lblVitesse_2"
        Me.lblVitesse_2.Size = New System.Drawing.Size(49, 16)
        Me.lblVitesse_2.TabIndex = 2
        Me.lblVitesse_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblVitesse_1
        '
        Me.lblVitesse_1.Location = New System.Drawing.Point(7, 16)
        Me.lblVitesse_1.Name = "lblVitesse_1"
        Me.lblVitesse_1.Size = New System.Drawing.Size(49, 16)
        Me.lblVitesse_1.TabIndex = 1
        Me.lblVitesse_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelRapportBoite
        '
        Me.panelRapportBoite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelRapportBoite.Controls.Add(Me.lblRapportBoite_2)
        Me.panelRapportBoite.Controls.Add(Me.lblRapportBoite_1)
        Me.panelRapportBoite.Location = New System.Drawing.Point(184, 40)
        Me.panelRapportBoite.Name = "panelRapportBoite"
        Me.panelRapportBoite.Size = New System.Drawing.Size(72, 110)
        Me.panelRapportBoite.TabIndex = 5
        '
        'lblRapportBoite_2
        '
        Me.lblRapportBoite_2.Location = New System.Drawing.Point(7, 46)
        Me.lblRapportBoite_2.Name = "lblRapportBoite_2"
        Me.lblRapportBoite_2.Size = New System.Drawing.Size(56, 16)
        Me.lblRapportBoite_2.TabIndex = 2
        Me.lblRapportBoite_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRapportBoite_1
        '
        Me.lblRapportBoite_1.Location = New System.Drawing.Point(8, 16)
        Me.lblRapportBoite_1.Name = "lblRapportBoite_1"
        Me.lblRapportBoite_1.Size = New System.Drawing.Size(56, 16)
        Me.lblRapportBoite_1.TabIndex = 1
        Me.lblRapportBoite_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelPressionBuses
        '
        Me.panelPressionBuses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPressionBuses.Controls.Add(Me.Label11)
        Me.panelPressionBuses.Controls.Add(Me.Label10)
        Me.panelPressionBuses.Controls.Add(Me.lblPressionBuses_2)
        Me.panelPressionBuses.Controls.Add(Me.lblPressionBuses_1)
        Me.panelPressionBuses.Location = New System.Drawing.Point(96, 40)
        Me.panelPressionBuses.Name = "panelPressionBuses"
        Me.panelPressionBuses.Size = New System.Drawing.Size(88, 110)
        Me.panelPressionBuses.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(56, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 16)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Bar"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(56, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 16)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Bar"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPressionBuses_2
        '
        Me.lblPressionBuses_2.Location = New System.Drawing.Point(3, 46)
        Me.lblPressionBuses_2.Name = "lblPressionBuses_2"
        Me.lblPressionBuses_2.Size = New System.Drawing.Size(53, 16)
        Me.lblPressionBuses_2.TabIndex = 2
        Me.lblPressionBuses_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressionBuses_1
        '
        Me.lblPressionBuses_1.Location = New System.Drawing.Point(3, 16)
        Me.lblPressionBuses_1.Name = "lblPressionBuses_1"
        Me.lblPressionBuses_1.Size = New System.Drawing.Size(53, 16)
        Me.lblPressionBuses_1.TabIndex = 1
        Me.lblPressionBuses_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelPressionManoPulve
        '
        Me.panelPressionManoPulve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelPressionManoPulve.Controls.Add(Me.lblPressionManoPulve_2)
        Me.panelPressionManoPulve.Controls.Add(Me.lblPressionManoPulve_1)
        Me.panelPressionManoPulve.Location = New System.Drawing.Point(0, 40)
        Me.panelPressionManoPulve.Name = "panelPressionManoPulve"
        Me.panelPressionManoPulve.Size = New System.Drawing.Size(96, 110)
        Me.panelPressionManoPulve.TabIndex = 3
        '
        'lblPressionManoPulve_2
        '
        Me.lblPressionManoPulve_2.Location = New System.Drawing.Point(7, 46)
        Me.lblPressionManoPulve_2.Name = "lblPressionManoPulve_2"
        Me.lblPressionManoPulve_2.Size = New System.Drawing.Size(80, 16)
        Me.lblPressionManoPulve_2.TabIndex = 1
        Me.lblPressionManoPulve_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPressionManoPulve_1
        '
        Me.lblPressionManoPulve_1.Location = New System.Drawing.Point(8, 16)
        Me.lblPressionManoPulve_1.Name = "lblPressionManoPulve_1"
        Me.lblPressionManoPulve_1.Size = New System.Drawing.Size(80, 16)
        Me.lblPressionManoPulve_1.TabIndex = 0
        Me.lblPressionManoPulve_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Location = New System.Drawing.Point(184, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(72, 40)
        Me.Panel4.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(6, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 22)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Rapport de boîte"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(96, 40)
        Me.Panel2.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(6, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 22)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Mano du pulvé (pression)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Location = New System.Drawing.Point(96, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(88, 40)
        Me.Panel3.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(6, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 22)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Pression lue aux buses"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.Label9)
        Me.Panel7.Location = New System.Drawing.Point(470, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(104, 40)
        Me.Panel7.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(6, 9)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 22)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "Dosage avec buses neuves"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Location = New System.Drawing.Point(352, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(118, 40)
        Me.Panel6.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(6, 9)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 22)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Dosage avec buses de l'appareil"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label7)
        Me.Panel5.Location = New System.Drawing.Point(256, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(96, 40)
        Me.Panel5.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(6, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 22)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Vitesse d'avancement"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'panelDosageBusesAppareil
        '
        Me.panelDosageBusesAppareil.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelDosageBusesAppareil.Controls.Add(Me.Label15)
        Me.panelDosageBusesAppareil.Controls.Add(Me.Label14)
        Me.panelDosageBusesAppareil.Controls.Add(Me.lblDosageBusesAppareil_2)
        Me.panelDosageBusesAppareil.Controls.Add(Me.lblDosageBusesAppareil_1)
        Me.panelDosageBusesAppareil.Location = New System.Drawing.Point(352, 40)
        Me.panelDosageBusesAppareil.Name = "panelDosageBusesAppareil"
        Me.panelDosageBusesAppareil.Size = New System.Drawing.Size(118, 110)
        Me.panelDosageBusesAppareil.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(80, 46)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 16)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "L/Ha"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(80, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 16)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "L/Ha"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDosageBusesAppareil_2
        '
        Me.lblDosageBusesAppareil_2.Location = New System.Drawing.Point(6, 46)
        Me.lblDosageBusesAppareil_2.Name = "lblDosageBusesAppareil_2"
        Me.lblDosageBusesAppareil_2.Size = New System.Drawing.Size(74, 16)
        Me.lblDosageBusesAppareil_2.TabIndex = 2
        Me.lblDosageBusesAppareil_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDosageBusesAppareil_1
        '
        Me.lblDosageBusesAppareil_1.Location = New System.Drawing.Point(8, 16)
        Me.lblDosageBusesAppareil_1.Name = "lblDosageBusesAppareil_1"
        Me.lblDosageBusesAppareil_1.Size = New System.Drawing.Size(72, 16)
        Me.lblDosageBusesAppareil_1.TabIndex = 1
        Me.lblDosageBusesAppareil_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOpenTool_volHa
        '
        Me.btnOpenTool_volHa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpenTool_volHa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenTool_volHa.ForeColor = System.Drawing.Color.White
        Me.btnOpenTool_volHa.Image = CType(resources.GetObject("btnOpenTool_volHa.Image"), System.Drawing.Image)
        Me.btnOpenTool_volHa.Location = New System.Drawing.Point(16, 24)
        Me.btnOpenTool_volHa.Name = "btnOpenTool_volHa"
        Me.btnOpenTool_volHa.Size = New System.Drawing.Size(128, 24)
        Me.btnOpenTool_volHa.TabIndex = 34
        Me.btnOpenTool_volHa.Text = "    Ouvrir l'outil"
        Me.btnOpenTool_volHa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn_finalisationDiag_quitter
        '
        Me.btn_finalisationDiag_quitter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_finalisationDiag_quitter.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_finalisationDiag_quitter.ForeColor = System.Drawing.Color.White
        Me.btn_finalisationDiag_quitter.Image = CType(resources.GetObject("btn_finalisationDiag_quitter.Image"), System.Drawing.Image)
        Me.btn_finalisationDiag_quitter.Location = New System.Drawing.Point(738, 648)
        Me.btn_finalisationDiag_quitter.Name = "btn_finalisationDiag_quitter"
        Me.btn_finalisationDiag_quitter.Size = New System.Drawing.Size(128, 24)
        Me.btn_finalisationDiag_quitter.TabIndex = 38
        Me.btn_finalisationDiag_quitter.Text = "    Quitter"
        Me.btn_finalisationDiag_quitter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'diagnostic_infosInspecteur
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1008, 679)
        Me.ControlBox = False
        Me.Controls.Add(Me.btn_finalisationDiag_quitter)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.btn_finalisationDiag_imprimer)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox5)
        Me.MinimizeBox = False
        Me.Name = "diagnostic_infosInspecteur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "diagnostic_infosInspecteur"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.panelTabRecapVolHa.ResumeLayout(False)
        Me.panelDosageBusesNeuves.ResumeLayout(False)
        Me.panelVitesse.ResumeLayout(False)
        Me.panelRapportBoite.ResumeLayout(False)
        Me.panelPressionBuses.ResumeLayout(False)
        Me.panelPressionManoPulve.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.panelDosageBusesAppareil.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim pathFichePedago As String
    Private Sub createFichePedago()
        Dim pdfReader As PdfReader
        Dim pdfStamper As PdfStamper
        Dim pdfFormFields As AcroFields
        ' On génère le PDF
        Try

            ' Init
            'Dim pdfTemplate As String = CONST_PATH_DOCS & CONST_DOC_FPEDA
            'Dim newFile As String = CONST_PATH_EXP & CONST_DOC_FPEDAv
            Dim pdfTemplate As String = CONST_PATH_DOCS & CONST_DOC_FPEDA & ".pdf"
            'pathFichePedago = CONST_PATH_EXP & CONST_DOC_FPEDA & "_" & CSDate.getDateId(Date.Now) & "_" & diagnosticCourant.id & ".pdf"
            pathFichePedago = CONST_PATH_EXP & CSDiagPdf.makeFilename(pulverisateurCourant.id, CSDiagPdf.TYPE_FEUILLE_PEDAGOGIQUE) & ".pdf"
            Dim newFile As String = pathFichePedago
            ' Ouverture des pdf
            pdfReader = New PdfReader(pdfTemplate)
            pdfStamper = New PdfStamper(pdfReader, New FileStream(newFile, FileMode.Create))
            pdfFormFields = pdfStamper.AcroFields

            ' Et on rempli les champs
            ' Organisme Prestataire
            pdfFormFields.SetField("orgaPNom", diagnosticCourant.organismePresNom)
            pdfFormFields.SetField("orgaPNum", diagnosticCourant.organismePresNumero)
            ' Infos Diag
            pdfFormFields.SetField("conseilsInspecteur", diag_conseils.Text)
            Dim tmpLstBuses As String = ""
            For i As Integer = 0 To listBusesUsed.Items.Count - 1
                tmpLstBuses += listBusesUsed.Items(i).ToString & vbNewLine
            Next
            pdfFormFields.SetField("listBusesUsed", tmpLstBuses)
            ' Infos calcul Vol/Ha
            pdfFormFields.SetField("pressionManoPulve_1", lblPressionManoPulve_1.Text)
            pdfFormFields.SetField("pressionBuses_1", lblPressionBuses_1.Text)
            pdfFormFields.SetField("rapportBoite_1", lblRapportBoite_1.Text)
            pdfFormFields.SetField("vitesseAvancement_1", lblVitesse_1.Text)
            pdfFormFields.SetField("dosageBusesAppareil_1", lblDosageBusesAppareil_1.Text)
            pdfFormFields.SetField("dosageBusesNeuves_1", lblDosageBusesNeuves_1.Text)
            pdfFormFields.SetField("pressionManoPulve_2", lblPressionManoPulve_2.Text)
            pdfFormFields.SetField("pressionBuses_2", lblPressionBuses_2.Text)
            pdfFormFields.SetField("rapportBoite_2", lblRapportBoite_2.Text)
            pdfFormFields.SetField("vitesseAvancement_2", lblVitesse_2.Text)
            pdfFormFields.SetField("dosageBusesAppareil_2", lblDosageBusesAppareil_2.Text)
            pdfFormFields.SetField("dosageBusesNeuves_2", lblDosageBusesNeuves_2.Text)


            ' On referme le PDF
            pdfStamper.FormFlattening = True
            pdfStamper.Close()
            pdfReader.Close()
        Catch ex As Exception
            CSDebug.dispError("diagnostic_infosInspecteur::createFichePedago(Génération feuille pédagogique) : " & ex.Message)
        End Try
    End Sub
    Private Sub btn_finalisationDiag_imprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_finalisationDiag_imprimer.Click
        sender.Enabled = False

        ' On génère le PDF
        Try
            createFichePedago()
            CSFile.open(pathFichePedago)
            CloseDiagnostic()
        Catch ex As Exception
            CSDebug.dispError("diagnostic_infosInspecteur::createFichePedago(Ouverture feuille pédagogique) : " & ex.Message)
        End Try


    End Sub

    Private Sub CloseDiagnostic()
        ' On vide les infos de session
        diagnosticCourant = Nothing
        pulverisateurCourant = Nothing
        'Fermeture de fenpetres Filles de diag
        Dim ofrm As Form
        Dim ofrmAccueil As accueil
        For Each ofrm In MdiParent.MdiChildren
            If Not TypeOf ofrm Is accueil Then
                ofrm.Close()
            Else
                ofrmAccueil = ofrm
                ofrmAccueil.LoadListeExploitation()
                ofrmAccueil.loadListPulveExploitation(False)
                ofrmAccueil.WindowState = FormWindowState.Maximized
            End If
        Next

        ' On ferme le contrôle
        Statusbar.clear()

    End Sub
    Private Sub diagnostic_infosInspecteur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' On charge les buses usées
        Try
            listBusesUsed.Items.Clear()
            diagnosticRecap_infosInspecteur_nomOrganisme.Text = diagnosticCourant.organismePresNom
            diagnosticRecap_infosInspecteur_numOrganisme.Text = diagnosticCourant.organismePresNumero
            If Not arrBusesUsed Is Nothing Then
                For i As Integer = 0 To arrBusesUsed.Length - 1
                    If arrBusesUsed(i) <> "" Then
                        listBusesUsed.Items.Add("Niveau " & i & " : " & arrBusesUsed(i).Substring(0, (arrBusesUsed(i).Length - 2)))
                    End If
                Next
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostic Info Inspecteur::Loading : " & ex.Message)
        End Try
    End Sub

    Private Sub btnOpenTool_volHa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenTool_volHa.Click

        CSReglagePulve.Execute(diagnosticCourant.id, agentCourant.id)

    End Sub

    Private Sub btn_finalisationDiag_quitter_Click(sender As System.Object, e As System.EventArgs) Handles btn_finalisationDiag_quitter.Click
        CloseDiagnostic()
    End Sub
End Class
