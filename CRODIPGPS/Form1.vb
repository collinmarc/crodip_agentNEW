Imports System.ComponentModel
Imports System.Threading
Imports System.Timers
Imports MaterialSkin
Public Class Form1
    Inherits MaterialSkin.Controls.MaterialForm

    Private _MesureEncours As GPSMesure = Nothing
    Dim m1 As GPSMesure
    Dim m2 As GPSMesure
    Public elapsedTime As TimeSpan
    Private startTime As DateTime
    Dim TimerDetectionGPS As System.Timers.Timer

    Private Enum EtatFom As Integer
        GPSNONACTIF = 0
        ENATTENTE = 1
        MESUREENCOURS = 2
        MESUREARRETABLE = 3
        MESURESEFFECTUEES = 4
        GPSACTIF = 5
    End Enum
    Private _Etat As EtatFom
    Private WithEvents gpsManager As GPSManager
    Private portName As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(primary:=Primary.Blue800, darkPrimary:=Primary.Blue900, lightPrimary:=Primary.Blue500,
        accent:=Primary.Green900, textShade:=TextShade.WHITE)
        pbMesure.Maximum = 5
        pbMesure.Value = 0
        elapsedTime = TimeSpan.Zero
        If System.IO.File.Exists("CRODIPGPS.log") Then
            System.IO.File.Delete("CRODIPGPS.log")
        End If
        If System.IO.File.Exists("GPS.log") Then
            System.IO.File.Delete("GPS.log")
        End If

        If String.IsNullOrEmpty(_NumPulve) Then
            _NumPulve = InputBox("Numéro du pulvérisateur", "CRODIPGPS")
        End If

        m1 = New GPSMesure()
        m1.NumPulve = _NumPulve
        m1.Num = 1
        m_bsrcGPSMesure.Add(m1)
        m2 = New GPSMesure()
        m2.Num = 2
        m2.NumPulve = _NumPulve
        m_bsrcGPSMesure.Add(m2)

        m_bsrcGPSMesure.MoveFirst()
        SetEtat0GPSNONACTIF()

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Private Sub cbMesure_Click(sender As Object, e As EventArgs) Handles cbMesure.Click
        Select Case _Etat
            Case EtatFom.ENATTENTE, EtatFom.MESURESEFFECTUEES
                SetEtat2MESUREENCOURS()
                startTime = DateTime.Now()
                elapsedTime = TimeSpan.MinValue
                _MesureEncours.Distance = 0
                _MesureEncours.Temps = 0
                m_bsrcGPSMesure.ResetBindings(True)
                TimerLectureGPS.Enabled = True
                TimerLectureGPS.Start()
                gpsManager.StartMesure()

                '            Case EtatFom.MESUREENCOURS
 '               SetEtat4MESURESEFFECTUEES()
            Case EtatFom.MESUREARRETABLE
                '                TimerLectureGPS.Stop()
                '               gpsManager.DesactiverGPS()
                SetEtat4MESURESEFFECTUEES()
            Case Else
                'SetEtat1ENATTENTE()
        End Select

    End Sub

    Private Sub CbMesureSuivante_Click(sender As Object, e As EventArgs) Handles CbMesureSuivante.Click
        rbMesure2.Checked = True
        CbMesureSuivante.Enabled = False
        SetEtat1ENATTENTE()
    End Sub

    Private Sub cbQuitter_Click(sender As Object, e As EventArgs) Handles cbQuitter.Click
        Me.Close()
    End Sub


    Private Sub SetEtat0GPSNONACTIF()
        TraceMsg("Etat0")
        _Etat = EtatFom.GPSNONACTIF
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = False
        CbMesureSuivante.Enabled = False
        '        tbNumPulve.SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
    End Sub
    Private Sub SetEtat6GPSACTIF()
        TraceMsg("Etat6")
        _Etat = EtatFom.GPSACTIF
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = False
        CbMesureSuivante.Enabled = False
        ckVitessseStable.Checked = False
    End Sub
    Private Sub SetEtat1ENATTENTE()
        TraceMsg("Etat1")
        _Etat = EtatFom.ENATTENTE
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = True
        CbMesureSuivante.Enabled = Not rbMesure2.Checked
    End Sub
    Private Sub SetEtat2MESUREENCOURS()
        TraceMsg("Etat2")
        _Etat = EtatFom.MESUREENCOURS
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        cbMesure.Text = "En cours"
        cbMesure.UseAccentColor = True
        'cbMesure.Enabled = False
        _n = 0
        pbMesure.Value = 0
        CbMesureSuivante.Enabled = False
    End Sub
    Private Sub SetEtat3MESUREARRETABLE()
        TraceMsg("Etat3")

        _Etat = EtatFom.MESUREARRETABLE
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.UseAccentColor = True
        cbMesure.Text = "Arrêter"
        cbMesure.Enabled = True
        CbMesureSuivante.Enabled = False
    End Sub
    Private Sub SetEtat4MESURESEFFECTUEES()
        TraceMsg("Etat4")

        If m1.Distance > 0 And m2.Distance > 0 Then
            _Etat = EtatFom.MESURESEFFECTUEES
            cbSauvegarder.Enabled = True
        Else
            _Etat = EtatFom.ENATTENTE
            cbSauvegarder.Enabled = False
        End If
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.UseAccentColor = False
        cbMesure.Text = "Démarrer"
        cbMesure.Enabled = True
        CbMesureSuivante.Enabled = (_Etat = EtatFom.ENATTENTE)
    End Sub
    Private _n As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerLectureGPS.Tick
        If gpsManager.GPSActif Then
            If CkTest.Checked Then
                Randomize()
                _MesureEncours.Distance = _MesureEncours.Distance + (Rnd() * 10)
                TraceMsg("Ecoute generée[" & _MesureEncours.Distance & "]")
            Else
                TraceMsg("Ecoute[" & gpsManager.startLatitude & "," & gpsManager.startLongitude & "=" & gpsManager.distance & "]")
                _MesureEncours.Distance = gpsManager.distance
            End If
            elapsedTime = DateTime.Now - startTime
            _MesureEncours.Temps = elapsedTime.Hours * 3600 + elapsedTime.Minutes * 60 + elapsedTime.Seconds
            If Not VitesseConstante Then
                ajouteVitesse(_MesureEncours.Vitesse)
            End If

            If _Etat = EtatFom.GPSACTIF Then
                'On Attend d'avoir une vitesse Stable
                If Me.VitesseConstante Then
                    ckVitessseStable.Checked = True
                    SetEtat1ENATTENTE()
                    'TimerLectureGPS.Stop() 'On arrete la lecture
                End If
            Else
                    If _Etat = EtatFom.MESUREENCOURS Then
                        If _MesureEncours.Vitesse < 15 Then
                            If _MesureEncours.Distance > 50 Then
                                SetEtat3MESUREARRETABLE()
                            End If
                        Else
                            If _MesureEncours.Distance > 100 Then
                                SetEtat3MESUREARRETABLE()
                            End If

                        End If
                    End If
                    If _Etat = EtatFom.MESUREENCOURS Or _Etat = EtatFom.MESUREARRETABLE Then
                        m_bsrcGPSMesure.ResetBindings(False)
                    End If
                End If
            End If

    End Sub
    Private Function isVitesseStable() As Boolean
        Return ckVitessseStable.Checked
    End Function

    Private Sub rbMesure1_CheckedChanged(sender As Object, e As EventArgs) Handles rbMesure1.CheckedChanged
        If rbMesure1.Checked Then
            m_bsrcGPSMesure.MoveFirst()
            CbMesureSuivante.Enabled = True
        Else
            m_bsrcGPSMesure.MoveLast()
            CbMesureSuivante.Enabled = False
        End If

    End Sub

    Private Sub m_bsrcGPSMesure_PositionChanged(sender As Object, e As EventArgs) Handles m_bsrcGPSMesure.PositionChanged
        _MesureEncours = m_bsrcGPSMesure.Current
        cbSauvegarder.Enabled = False
        If m_bsrcGPSMesure.Count = 2 Then
            If m1.Distance > 0 And m2.Distance > 0 Then
                cbSauvegarder.Enabled = True
            End If
        End If
    End Sub
    Private Sub GPSActif()
        TraceMsg("GPSActif()")
        TimerDetectionGPS.Enabled = False
        '        checkGPSActif(True)
        ckGPSActif.Checked = True
        SetEtat6GPSACTIF()
        startTime = DateTime.Now
        elapsedTime = TimeSpan.MinValue
        TimerLectureGPS.Enabled = True
        TimerLectureGPS.Start()
    End Sub

    Private Sub TraceMsg(pMessage As String)
        Console.WriteLine(pMessage)
        System.IO.File.AppendAllText("./CRODIPGPS.LOG", pMessage & vbCrLf)
    End Sub

    Private Sub ckGPSActif_CheckedChanged(sender As Object, e As EventArgs) Handles ckGPSActif.CheckedChanged
        If gpsManager.GPSActif <> ckGPSActif.Checked Then
            gpsManager.GPSActif = ckGPSActif.Checked
            If Not gpsManager.GPSActif Then
                TimerDetectionGPS.Enabled = True
                TimerDetectionGPS.Start()
            End If
        End If
    End Sub
    Dim _FichierExport As String
    Private Sub cbExporter_Click(sender As Object, e As EventArgs) Handles cbSauvegarder.Click
        SaveFileDialog1.FileName = System.IO.Path.GetFileName(My.Settings.FichierExport)
        SaveFileDialog1.InitialDirectory = System.IO.Path.GetDirectoryName(My.Settings.FichierExport)
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            _FichierExport = SaveFileDialog1.FileName
        End If
        Exporter(_FichierExport)
    End Sub

    Private Function Exporter(pFile As String) As Boolean
        Dim bReturn As Boolean
        Try
            If System.IO.File.Exists(pFile) Then
                System.IO.File.Delete(pFile)
            End If
            m1.ToCsv(pFile)
            m2.ToCsv(pFile)
            bReturn = True
        Catch ex As Exception
            TraceMsg(ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub ckVitessseStable_CheckedChanged(sender As Object, e As EventArgs) Handles ckVitessseStable.CheckedChanged
        If gpsManager.GPSActif Then
            If ckVitessseStable.Checked <> Me.VitesseConstante Then
                Me.VitesseConstante = ckVitessseStable.Checked
            End If
        End If
    End Sub

    Private Sub TimerDetectionGPS_Tick(sender As Object, e As EventArgs)
        portName = gpsManager.TrouverPortGPS()

        If portName IsNot Nothing Then
            gpsManager.ConfigurerPortSerie(portName, 9600)
            gpsManager.EcouterGPS()
            BackgroundWorker1.ReportProgress(1, portName)
        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        gpsManager = New GPSManager()
        TimerDetectionGPS = New System.Timers.Timer(My.Settings.intervalGPS)
        AddHandler TimerDetectionGPS.Elapsed, AddressOf TimerDetectionGPS_Tick
        TimerDetectionGPS.Enabled = True
        TimerDetectionGPS.Start()

        While Not gpsManager.GPSActif And Not Me.VitesseConstante
            Thread.Sleep(My.Settings.intervalGPS)
        End While
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1 'Port Serie Trouvé
                SetEtat1ENATTENTE()
                TraceMsg("Configurer Port " & portName)
        End Select


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        GPSActif()
    End Sub

    Private Sub checkGPSActif(pValue As Boolean)

        If (ckGPSActif.InvokeRequired) Then

            ckGPSActif.Invoke(Sub()
                                  checkGPSActif(pValue)
                              End Sub)

        Else
            ckGPSActif.Checked = pValue
        End If

    End Sub

    Private Sub CkTest_CheckedChanged(sender As Object, e As EventArgs) Handles CkTest.CheckedChanged
        PnlCacheCkTest.Visible = Not CkTest.Checked
        ' CkTest.Visible = CkTest.Checked
        ckGPSActif.Visible = CkTest.Checked
        ckVitessseStable.Visible = CkTest.Checked
        ckGPSActif.Enabled = CkTest.Checked
        ckVitessseStable.Enabled = CkTest.Checked
    End Sub

    '==================================
    Private _tabVitesse As New Queue(Of Decimal)(My.Settings.nbIntervalleVitesseConstante)
    Private _VitesseConstante As Boolean
    Private _NumPulve As String
    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub
    Public Sub New(pNumPulve As String)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        _NumPulve = pNumPulve

    End Sub

    Public Property VitesseConstante() As Boolean
        Get
            Return _VitesseConstante
        End Get
        Set(ByVal value As Boolean)
            _VitesseConstante = value
        End Set
    End Property
    Private Sub ajouteVitesse(pVitesse As Decimal)
        If _tabVitesse.Count >= My.Settings.nbIntervalleVitesseConstante Then
            _tabVitesse.Dequeue()
        End If
        _tabVitesse.Enqueue(pVitesse)
        If _tabVitesse.Count = My.Settings.nbIntervalleVitesseConstante Then
            'Calcule de la vitesse Moyenne
            Dim moy As Decimal = 0
            For Each vitesse As Decimal In _tabVitesse
                moy = moy + vitesse
            Next
            moy = moy / _tabVitesse.Count
            Dim bEcart As Boolean = True
            'Vérification s'il y a un ecart de plus de 5%
            For Each oV As Decimal In _tabVitesse
                If ((oV - moy) / moy) > My.Settings.EcartMAx Then
                    bEcart = False
                End If
            Next
            VitesseConstante = bEcart
        Else
            VitesseConstante = False
        End If
    End Sub


End Class