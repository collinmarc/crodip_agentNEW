Public Class frmGPS
    Public Enum EtatAnalyse As Integer
        Arret
        Encoursdebut
        EnCoursfin
    End Enum
    Private _AnalyseEncours As EtatAnalyse
    Public Property AnalyseEnCours() As EtatAnalyse
        Get
            Return _AnalyseEncours
        End Get
        Set(ByVal value As EtatAnalyse)
            _AnalyseEncours = value
            If _AnalyseEncours = EtatAnalyse.Arret Then
                bntDemarrer.Text = "Démarrer"
                bntDemarrer.BackColor = Color.ForestGreen
            ElseIf _AnalyseEncours = EtatAnalyse.Encoursdebut Then
                bntDemarrer.Text = "En cours"
                bntDemarrer.BackColor = Color.Yellow
                bntDemarrer.Enabled = False
            Else
                bntDemarrer.Text = "Arrêter"
                bntDemarrer.BackColor = Color.Blue
                bntDemarrer.Enabled = True
            End If
        End Set
    End Property
    Private _NMesuresenCours As Integer
    Private _MesureCourante As GPSMesure
    Public Property NumMesureEnCours() As Integer
        Get
            Return _NMesuresenCours
        End Get
        Set(ByVal value As Integer)
            _NMesuresenCours = value
            NumericUpDown1.Value = value
        End Set
    End Property


    Private Sub bntDemarrer_Click(sender As Object, e As EventArgs) Handles bntDemarrer.Click
        If _AnalyseEncours = EtatAnalyse.Arret Then
            Actiondemarrer()
        Else
            ActionTerminer()
        End If
    End Sub

    Public Sub Actiondemarrer()
        btnExporter.Enabled = False
        btnRAZ.Enabled = False
        btnNlleMesure.Enabled = False
        NumericUpDown1.Enabled = False
        _MesureCourante = New GPSMesure()
        _MesureCourante.Num = NumericUpDown1.Value
        _bsrcGPSMesure.Add(_MesureCourante)
        _bsrcGPSMesure.MoveLast()
        AnalyseEnCours = EtatAnalyse.Encoursdebut
        _Timer1.Enabled = True
    End Sub
    Public Sub ActionTerminer()
        _Timer1.Enabled = False

        btnExporter.Enabled = True
        btnRAZ.Enabled = True
        btnNlleMesure.Enabled = True
        bntDemarrer.Text = "Démarrer"
        bntDemarrer.BackColor = Color.ForestGreen
        _AnalyseEncours = EtatAnalyse.Arret
    End Sub
    Public Sub ActionRAZ()
        btnExporter.Enabled = False
        btnRAZ.Enabled = False
        btnNlleMesure.Enabled = False
        bntDemarrer.Text = "Démarrer"
        bntDemarrer.BackColor = Color.ForestGreen
        NumMesureEnCours = 0
        _bsrcGPSMesure.Clear()
    End Sub
    Public Sub ActionTick()
        'J'ai reçu tick du timer
        'Lecture de la position GPS
        'Calcul de la distance depuis le Dernier point
        _MesureCourante.SetValues(_MesureCourante.Distance + Rnd(), _MesureCourante.Temps + 1)
        _bsrcGPSMesure.ResetBindings(False)
        If _MesureCourante.Temps > 10 Then
            AnalyseEnCours = EtatAnalyse.EnCoursfin
        End If
    End Sub

    Public Sub ActionSelectMesure()
        _bsrcGPSMesure.Position = NumericUpDown1.Value
    End Sub
    Public Sub ActionNouvelleMesure()
        NumericUpDown1.Maximum = NumericUpDown1.Value + 1
        NumericUpDown1.Value = NumericUpDown1.Value + 1
    End Sub

    Private Sub frmGPS_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActionRAZ()
        ActionNouvelleMesure()
    End Sub

    Private Sub btnRAZ_Click(sender As Object, e As EventArgs) Handles btnRAZ.Click
        ActionRAZ()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        ActionSelectMesure()
    End Sub

    Private Sub _bgwGPS_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles _bgwGPS.DoWork
        'Init GPS
        _Timer1.Start()
        _Timer1.Enabled = True
        While Not _bgwGPS.CancellationPending
            '
        End While

    End Sub

    Private Sub _bgwGPS_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles _bgwGPS.ProgressChanged

    End Sub

    Private Sub _bgwGPS_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles _bgwGPS.RunWorkerCompleted

    End Sub

    Private Sub _Timer1_Tick(sender As Object, e As EventArgs) Handles _Timer1.Tick
        ActionTick()
    End Sub

    Private Sub btnNlleMesure_Click(sender As Object, e As EventArgs) Handles btnNlleMesure.Click
        ActionNouvelleMesure()
    End Sub
End Class

