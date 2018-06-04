<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAgent
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
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbNumNationalAgent = New System.Windows.Forms.TextBox()
        Me.btnRechercher = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpDateSynchro = New System.Windows.Forms.DateTimePicker()
        Me.grpAgent = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbNomagent = New System.Windows.Forms.TextBox()
        Me.btnMAJ = New System.Windows.Forms.Button()
        Me.lblURLServeur = New System.Windows.Forms.Label()
        Me.grpAgent.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 140)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "numéro national Agent :"
        '
        'tbNumNationalAgent
        '
        Me.tbNumNationalAgent.Location = New System.Drawing.Point(145, 137)
        Me.tbNumNationalAgent.Name = "tbNumNationalAgent"
        Me.tbNumNationalAgent.Size = New System.Drawing.Size(116, 20)
        Me.tbNumNationalAgent.TabIndex = 1
        '
        'btnRechercher
        '
        Me.btnRechercher.Location = New System.Drawing.Point(281, 135)
        Me.btnRechercher.Name = "btnRechercher"
        Me.btnRechercher.Size = New System.Drawing.Size(75, 23)
        Me.btnRechercher.TabIndex = 2
        Me.btnRechercher.Text = "Rechercher"
        Me.btnRechercher.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(680, 24)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cet outil permet de mettre à jour la date de dernière synchronisation d'un agent." &
    " "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(63, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(566, 24)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Ceci aura des conséquences sur les prochaines synchronisations."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(125, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "date de synchronisation :"
        '
        'dtpDateSynchro
        '
        Me.dtpDateSynchro.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDateSynchro.Location = New System.Drawing.Point(137, 55)
        Me.dtpDateSynchro.Name = "dtpDateSynchro"
        Me.dtpDateSynchro.Size = New System.Drawing.Size(106, 20)
        Me.dtpDateSynchro.TabIndex = 6
        '
        'grpAgent
        '
        Me.grpAgent.Controls.Add(Me.btnMAJ)
        Me.grpAgent.Controls.Add(Me.tbNomagent)
        Me.grpAgent.Controls.Add(Me.dtpDateSynchro)
        Me.grpAgent.Controls.Add(Me.Label5)
        Me.grpAgent.Controls.Add(Me.Label4)
        Me.grpAgent.Location = New System.Drawing.Point(8, 176)
        Me.grpAgent.Name = "grpAgent"
        Me.grpAgent.Size = New System.Drawing.Size(489, 133)
        Me.grpAgent.TabIndex = 7
        Me.grpAgent.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Nom-Prénom :"
        '
        'tbNomagent
        '
        Me.tbNomagent.Location = New System.Drawing.Point(137, 20)
        Me.tbNomagent.Name = "tbNomagent"
        Me.tbNomagent.ReadOnly = True
        Me.tbNomagent.Size = New System.Drawing.Size(346, 20)
        Me.tbNomagent.TabIndex = 1
        '
        'btnMAJ
        '
        Me.btnMAJ.Location = New System.Drawing.Point(408, 88)
        Me.btnMAJ.Name = "btnMAJ"
        Me.btnMAJ.Size = New System.Drawing.Size(75, 23)
        Me.btnMAJ.TabIndex = 7
        Me.btnMAJ.Text = "Mettre à jour"
        Me.btnMAJ.UseVisualStyleBackColor = True
        '
        'lblURLServeur
        '
        Me.lblURLServeur.AutoSize = True
        Me.lblURLServeur.ForeColor = System.Drawing.Color.DarkRed
        Me.lblURLServeur.Location = New System.Drawing.Point(16, 97)
        Me.lblURLServeur.Name = "lblURLServeur"
        Me.lblURLServeur.Size = New System.Drawing.Size(85, 13)
        Me.lblURLServeur.TabIndex = 8
        Me.lblURLServeur.Text = "Adresse Serveur"
        '
        'frmAgent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.lblURLServeur)
        Me.Controls.Add(Me.grpAgent)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRechercher)
        Me.Controls.Add(Me.tbNumNationalAgent)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAgent"
        Me.Text = "Mise à jour  de  la date de synchronisation d'un agent"
        Me.grpAgent.ResumeLayout(False)
        Me.grpAgent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbNumNationalAgent As TextBox
    Friend WithEvents btnRechercher As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpDateSynchro As DateTimePicker
    Friend WithEvents grpAgent As GroupBox
    Friend WithEvents btnMAJ As Button
    Friend WithEvents tbNomagent As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents lblURLServeur As Label
End Class
