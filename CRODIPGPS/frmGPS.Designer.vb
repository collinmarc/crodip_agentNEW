<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGPS
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.bntDemarrer = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown1 = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.laDistance = New System.Windows.Forms.Label()
        Me._bsrcGPSMesure = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.laTemps = New System.Windows.Forms.Label()
        Me.laVitesse = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnNlleMesure = New System.Windows.Forms.Button()
        Me.btnExporter = New System.Windows.Forms.Button()
        Me.btnRAZ = New System.Windows.Forms.Button()
        Me._bgwGPS = New System.ComponentModel.BackgroundWorker()
        Me._Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._bsrcGPSMesure, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bntDemarrer
        '
        Me.bntDemarrer.BackColor = System.Drawing.Color.Yellow
        Me.bntDemarrer.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntDemarrer.Location = New System.Drawing.Point(22, 73)
        Me.bntDemarrer.Name = "bntDemarrer"
        Me.bntDemarrer.Size = New System.Drawing.Size(305, 126)
        Me.bntDemarrer.TabIndex = 0
        Me.bntDemarrer.Text = "Démarrer"
        Me.bntDemarrer.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(164, 31)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mesure N° : "
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NumericUpDown1.Location = New System.Drawing.Point(186, 9)
        Me.NumericUpDown1.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.Size = New System.Drawing.Size(91, 38)
        Me.NumericUpDown1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(378, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(190, 31)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Distance (m) : "
        '
        'laDistance
        '
        Me.laDistance.AutoSize = True
        Me.laDistance.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me._bsrcGPSMesure, "Distance", True))
        Me.laDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laDistance.Location = New System.Drawing.Point(594, 75)
        Me.laDistance.Name = "laDistance"
        Me.laDistance.Size = New System.Drawing.Size(54, 31)
        Me.laDistance.TabIndex = 4
        Me.laDistance.Text = "....."
        '
        '_bsrcGPSMesure
        '
        Me._bsrcGPSMesure.DataSource = GetType(CRODIPGPS.GPSMesure)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(378, 110)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(158, 31)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Temps (s) : "
        '
        'laTemps
        '
        Me.laTemps.AutoSize = True
        Me.laTemps.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me._bsrcGPSMesure, "Temps", True))
        Me.laTemps.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laTemps.Location = New System.Drawing.Point(594, 110)
        Me.laTemps.Name = "laTemps"
        Me.laTemps.Size = New System.Drawing.Size(54, 31)
        Me.laTemps.TabIndex = 6
        Me.laTemps.Text = "....."
        '
        'laVitesse
        '
        Me.laVitesse.AutoSize = True
        Me.laVitesse.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me._bsrcGPSMesure, "Vitesse", True))
        Me.laVitesse.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.laVitesse.Location = New System.Drawing.Point(594, 168)
        Me.laVitesse.Name = "laVitesse"
        Me.laVitesse.Size = New System.Drawing.Size(54, 31)
        Me.laVitesse.TabIndex = 8
        Me.laVitesse.Text = "....."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(378, 168)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(210, 31)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Vitesse (km/h) : "
        '
        'btnNlleMesure
        '
        Me.btnNlleMesure.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNlleMesure.Location = New System.Drawing.Point(22, 282)
        Me.btnNlleMesure.Name = "btnNlleMesure"
        Me.btnNlleMesure.Size = New System.Drawing.Size(305, 68)
        Me.btnNlleMesure.TabIndex = 10
        Me.btnNlleMesure.Text = "Nouvelle mesure"
        Me.btnNlleMesure.UseVisualStyleBackColor = True
        '
        'btnExporter
        '
        Me.btnExporter.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExporter.Location = New System.Drawing.Point(361, 282)
        Me.btnExporter.Name = "btnExporter"
        Me.btnExporter.Size = New System.Drawing.Size(305, 68)
        Me.btnExporter.TabIndex = 11
        Me.btnExporter.Text = "Exporter"
        Me.btnExporter.UseVisualStyleBackColor = True
        '
        'btnRAZ
        '
        Me.btnRAZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRAZ.Location = New System.Drawing.Point(316, 9)
        Me.btnRAZ.Name = "btnRAZ"
        Me.btnRAZ.Size = New System.Drawing.Size(288, 38)
        Me.btnRAZ.TabIndex = 12
        Me.btnRAZ.Text = "Remise à zéro"
        Me.btnRAZ.UseVisualStyleBackColor = True
        '
        '_bgwGPS
        '
        Me._bgwGPS.WorkerReportsProgress = True
        Me._bgwGPS.WorkerSupportsCancellation = True
        '
        '_Timer1
        '
        Me._Timer1.Interval = 1000
        '
        'frmGPS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnRAZ)
        Me.Controls.Add(Me.btnExporter)
        Me.Controls.Add(Me.btnNlleMesure)
        Me.Controls.Add(Me.laVitesse)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.laTemps)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.laDistance)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.NumericUpDown1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.bntDemarrer)
        Me.Name = "frmGPS"
        Me.Text = "Acquisition GPS"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._bsrcGPSMesure, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents bntDemarrer As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents NumericUpDown1 As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents laDistance As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents laTemps As Label
    Friend WithEvents laVitesse As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnNlleMesure As Button
    Friend WithEvents btnExporter As Button
    Friend WithEvents btnRAZ As Button
    Friend WithEvents _bsrcGPSMesure As BindingSource
    Friend WithEvents _bgwGPS As System.ComponentModel.BackgroundWorker
    Friend WithEvents _Timer1 As Timer
End Class
