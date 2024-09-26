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

    Private gpsManager As GPSManager
    Private portName As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(primary:=Primary.Blue800, darkPrimary:=Primary.Blue900, lightPrimary:=Primary.Blue500,
        accent:=Primary.Green900, textShade:=TextShade.WHITE)

        PnlCacheCkTest.Top = TableLayoutPanel2.Top
        PnlCacheCkTest.Left = TableLayoutPanel2.Left


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
        _EtatForm = ETAT.Etat_0GPSINACTIF
        SetEtat0GPSNONACTIF()
        TimerLectureGPS.Interval = My.Settings.intervalGPS

        BackgroundWorker1.RunWorkerAsync()
        'TimerDetectionGPS.Enabled = True
        'TimerDetectionGPS.Start()

#If DEBUG Then
        'CkTest.Checked = True

#End If

    End Sub

    Private Sub cbMesure_Click(sender As Object, e As EventArgs) Handles cbMesure.Click

        Select Case _EtatForm
            Case ETAT.Etat_2ENATTENTE
                SetAction(ACTION.Action_DEMARRER)
                'SetEtat2MESUREENCOURS()
                startTime = DateTime.Now()
                elapsedTime = TimeSpan.MinValue
                _MesureEncours.Distance = 0
                _MesureEncours.Temps = 0
                _MesureEncours.VitesseLue = 0
                m_bsrcGPSMesure.ResetBindings(True)
                TimerLectureGPS.Enabled = True
                TimerLectureGPS.Start()
                gpsManager.StartMesure()
                '            Case Etat.MESUREENCOURS
            Case ETAT.Etat_4MESUREARRETABLE
                TimerLectureGPS.Stop()
                _MesureEncours.VitesseLue = My.Settings.VitesseLue
                m_bsrcGPSMesure.ResetCurrentItem()
                SetAction(ACTION.Action_DEMARRER)

            Case Else
                SetAction(ACTION.Action_DEMARRER)
        End Select

    End Sub

    Private Sub CbMesureSuivante_Click(sender As Object, e As EventArgs) Handles CbMesureSuivante.Click
        cbMesure.Text = "Démarrer"
        m_bsrcGPSMesure.MoveNext()
        CbMesureSuivante.Enabled = False
        SetEtat1GPSACTIF()
    End Sub

    Private Sub cbQuitter_Click(sender As Object, e As EventArgs) Handles cbQuitter.Click
        Me.Close()
    End Sub


    Private Sub SetEtat0GPSNONACTIF()
        TraceMsg("Etat0")
        _EtatForm = ETAT.Etat_0GPSINACTIF
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = False
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        CbMesureSuivante.Enabled = False
        cbValiderVitesseLue.Visible = False
        '        tbNumPulve.SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
    End Sub
    Private Sub SetEtat1GPSACTIF()
        TraceMsg("Etat1 GPS ACTIF")
        _EtatForm = ETAT.Etat_1GPSACTIF
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        'cbMesure.Text = "Démarrer"
        Dim p As Integer
        p = m_bsrcGPSMesure.Position
        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = False
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        m_bsrcGPSMesure.Position = p
        CbMesureSuivante.Enabled = False
        ckVitessseStable.Checked = False
        laVitesseMesuree.Visible = False
        tbVitesseMesuree.Visible = False
        _MesureEncours.Distance = 0
        _MesureEncours.Temps = 0
        _MesureEncours.VitesseLue = 0
        _MesureEncours.VitesseConstante = False
        m_bsrcGPSMesure.ResetBindings(False)
        cbValiderVitesseLue.Visible = False
        TimerLectureGPS.Start() 'on le démarre pour attendre la vitesse constante
    End Sub
    Private Sub SetEtat2ENATTENTE()
        TraceMsg("Etat2")
        _EtatForm = ETAT.Etat_2ENATTENTE
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT

        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = True
        CbMesureSuivante.Enabled = Not rbMesure2.Checked And _MesureEncours.Distance > 0
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        cbValiderVitesseLue.Visible = False
        laVitesseLue.Visible = False
        TableLayoutPanelVitesseLue.Visible = False
        cbValiderVitesseLue.Visible = False
    End Sub
    Private Sub SetEtat3MESUREENCOURS()
        TraceMsg("Etat3 Mesure en cours")
        _EtatForm = ETAT.Etat_3MESUREENCOURS
        SkinManager.Theme = MaterialSkinManager.Themes.DARK
        cbMesure.Text = "En cours"
        cbMesure.UseAccentColor = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 2)
        cbReset.Visible = True
        cbReset.Enabled = True
        cbReset.BackColor = Color.Red
        'cbMesure.Enabled = False
        _n = 0
        pbMesure.Value = 0
        CbMesureSuivante.Enabled = False
        'La Vitesse mesurée n'est pas affichée encours d'acquiqition
        tbVitesseMesuree.Visible = False
        laVitesseMesuree.Visible = False
        rbMesure1.Enabled = False
        rbMesure2.Enabled = False
        cbValiderVitesseLue.Visible = False

    End Sub
    Private Sub SetEtat4MESUREARRETABLE()
        TraceMsg("Etat4 Arretable")

        _EtatForm = ETAT.Etat_4MESUREARRETABLE
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.UseAccentColor = True
        cbMesure.Text = "Arrêter"
        cbMesure.Enabled = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 2)
        cbReset.Visible = True
        cbReset.Enabled = True
        cbReset.BackColor = Color.Red
        CbMesureSuivante.Enabled = False
        cbValiderVitesseLue.Visible = False
    End Sub
    Private Sub SetEtat5MESUREEFFECTUEE()
        TraceMsg("Etat5 effectuée")

        _EtatForm = ETAT.Etat_5MESUREEFFECTUEE
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.UseAccentColor = True
        cbMesure.Enabled = False
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        CbMesureSuivante.Enabled = False
        'Positionnement sur la vitesse Lue
        Me.SelectNextControl(laVitesseLue, True, False, False, True)
        laVitesseLue.Visible = True
        TableLayoutPanelVitesseLue.Visible = True
        cbValiderVitesseLue.Visible = True
        cbValiderVitesseLue.Enabled = True

    End Sub
    Private Sub SetEtat67MESURESEFFECTUEES()
        TraceMsg("Etat67 Mesures Effectuées")
        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.Text = "Recommencer"
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        ckVitessseStable.Checked = False
        If m1.Distance > 0 And m2.Distance > 0 Then
            _EtatForm = ETAT.Etat_7_2MESUREOK
            cbSauvegarder.Enabled = True
        Else
            _EtatForm = ETAT.Etat_6MESUREOK
            cbSauvegarder.Enabled = False
        End If
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = True
        If m1.Distance > 0 And m2.Distance = 0 Then
            CbMesureSuivante.Enabled = True
        End If
        If CkTest.Checked Then
            tbVitesseMesuree.Visible = True
            laVitesseMesuree.Visible = True
        End If
        rbMesure1.Enabled = True
        rbMesure2.Enabled = True

    End Sub
    Private _n As Integer
    ''' <summary>
    ''' Ecoute du port GPS déclencher une fois que le GPS est actif
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles TimerLectureGPS.Tick
        Trace.WriteLine("Timer1_Tick Auto")
        If gpsManager.GPSActif Then
            Dim distance As Decimal
            Dim vitesse As Decimal
            Dim temps As Double
            'Récupération du temps
            elapsedTime = DateTime.Now - startTime
            temps = elapsedTime.TotalSeconds
            'Récupération de la distance
            If gpsManager.IsSerialPortOpen Then
                TraceMsg("Ecoute[" & gpsManager.startLatitude & "," & gpsManager.startLongitude & "=" & gpsManager.distance & "]")
                distance = gpsManager.distance
            Else
                Randomize()
                distance = _MesureEncours.Distance + (Rnd() * 10)
                TraceMsg("Ecoute generée[" & distance & "]")
            End If

            'Calcul de vitesse
            If _EtatForm = ETAT.Etat_3MESUREENCOURS Or _EtatForm = ETAT.Etat_4MESUREARRETABLE Then
                _MesureEncours.Distance = distance
                _MesureEncours.Temps = CDec(temps)
                vitesse = _MesureEncours.Vitesse
            Else
                vitesse = _MesureEncours.calculeVitesse(distance, temps)
            End If
            _MesureEncours.Vitesse = vitesse
            TraceMsg("Vitesse[" & vitesse & "]")

            'Vérification de la vitesse Constante
            If Not _MesureEncours.VitesseConstante Then
                If vitesse > 0 Then
                    _MesureEncours.ajouteVitesse(vitesse)
                End If
                If _MesureEncours.VitesseConstante Then
                    SetAction(ACTION.Action_VITESSESTABLE)
                End If
            End If


            'La Mesure est-elle complête ?
            If _EtatForm = ETAT.Etat_3MESUREENCOURS Then
                If _MesureEncours.Vitesse < My.Settings.LimiteVitesse Then
                    If _MesureEncours.Distance > My.Settings.Distance1 Then
                        SetAction(ACTION.Action_ARRETABLE)
                    End If
                Else
                    If _MesureEncours.Distance > My.Settings.Distance2 Then
                        SetAction(ACTION.Action_ARRETABLE)
                    End If

                End If
            End If

            m_bsrcGPSMesure.ResetBindings(False)
        End If

    End Sub
    Private Function isVitesseStable() As Boolean
        Return ckVitessseStable.Checked
    End Function

    Private Sub rbMesure1_CheckedChanged(sender As Object, e As EventArgs) Handles rbMesure1.CheckedChanged
        If rbMesure1.Checked Then
            m_bsrcGPSMesure.MoveFirst()
            If m2 IsNot Nothing Then
                If m2.Distance = 0 Then
                    CbMesureSuivante.Enabled = True
                End If
            End If
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
        ckGPSActif.Checked = True
        SetEtat1GPSACTIF()
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
    Private Sub cbSauvegarder_Click(sender As Object, e As EventArgs) Handles cbSauvegarder.Click
        _FichierExport = _NumPulve + "_" + Now.Date.ToString("yyyyMMdd") + ".csv"
        If Not System.IO.Directory.Exists(My.Settings.RepertoireExport) Then
            System.IO.Directory.CreateDirectory(My.Settings.RepertoireExport)
        End If

        _FichierExport = My.Settings.RepertoireExport + "/" + _FichierExport

        'If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
        ' _FichierExport = SaveFileDialog1.FileName
        ' End If
        TraceMsg("Enregistrement dans : " & _FichierExport)
        Exporter(_FichierExport)
        Me.Close()
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
            _MesureEncours.VitesseConstante = ckVitessseStable.Checked
            SetAction(ACTION.Action_VITESSESTABLE)
        End If
    End Sub


    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        gpsManager = New GPSManager()
        TimerDetectionGPS = New System.Timers.Timer(My.Settings.intervalGPS)
        AddHandler TimerDetectionGPS.Elapsed, AddressOf RechercherleportserieGPS
        TimerDetectionGPS.Enabled = True
        TimerDetectionGPS.Start()

        While Not gpsManager.GPSActif
            Thread.Sleep(My.Settings.intervalGPS)
        End While
    End Sub
    ''' <summary>
    ''' Ecoute regulière pour trouver le port GPS
    ''' 'Methode non utilisée une fois que le GPS est Actif
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub RechercherleportserieGPS(sender As Object, e As EventArgs)
        Trace.WriteLine("RechercherleportserieGPS")
        portName = gpsManager.TrouverPortGPS()

        If portName IsNot Nothing Then
            gpsManager.ConfigurerPortSerie(portName, My.Settings.VitessePort)
            BackgroundWorker1.ReportProgress(1, portName)
        End If

    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1 'Port Serie Trouvé
                'SetEtat1ENATTENTE()
                SetAction(ACTION.Action_GPSACTIF)
                TraceMsg("Configurer Port " & portName)
        End Select


    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        GPSActif()
    End Sub

    'Private Sub checkGPSActif(pValue As Boolean)

    '    If (ckGPSActif.InvokeRequired) Then

    '        ckGPSActif.Invoke(Sub()
    '                              checkGPSActif(pValue)
    '                          End Sub)

    '    Else
    '        ckGPSActif.Checked = pValue
    '    End If

    'End Sub

    Private Sub CkTest_CheckedChanged(sender As Object, e As EventArgs) Handles CkTest.CheckedChanged
        PnlCacheCkTest.Top = TableLayoutPanel2.Top
        PnlCacheCkTest.Left = TableLayoutPanel2.Left
        PnlCacheCkTest.Visible = Not CkTest.Checked
        laVitesse.Visible = CkTest.Checked 'Visible en mode test
        ' CkTest.Visible = CkTest.Checked
        ckGPSActif.Visible = CkTest.Checked
        ckVitessseStable.Visible = CkTest.Checked
        ckGPSActif.Enabled = CkTest.Checked
        ckVitessseStable.Enabled = CkTest.Checked
        tbVitesseMesuree.ForeColor = tbVitesseMesuree.BackColor
    End Sub

    '==================================
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



    Public Enum ACTION As Integer
        Action_GPSACTIF
        Action_VITESSESTABLE
        Action_VITESSENONSTABLE
        Action_DEMARRER
        Action_ARRETABLE
        Action_ARRETER
        Action_VITESSELUEOK
        Action_MESURESUIVANTE
        Action_RESET
    End Enum

    Public Enum ETAT As Integer
        Etat_0GPSINACTIF
        Etat_1GPSACTIF
        Etat_2ENATTENTE
        Etat_3MESUREENCOURS
        Etat_4MESUREARRETABLE
        Etat_5MESUREEFFECTUEE
        Etat_6MESUREOK
        Etat_7_2MESUREOK
    End Enum

    Private _EtatForm As ETAT

    Public Function SetAction(paction As ACTION) As ETAT

        Select Case _EtatForm
            Case ETAT.Etat_0GPSINACTIF
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                        SetEtat1GPSACTIF()
                    Case ACTION.Action_VITESSESTABLE
                    Case ACTION.Action_VITESSENONSTABLE
                    Case ACTION.Action_DEMARRER
                    Case ACTION.Action_ARRETABLE
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                End Select
            Case ETAT.Etat_1GPSACTIF
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                    Case ACTION.Action_VITESSESTABLE
                        SetEtat2ENATTENTE()
                    Case ACTION.Action_VITESSENONSTABLE
                    Case ACTION.Action_DEMARRER
                    Case ACTION.Action_ARRETABLE
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                End Select
            Case ETAT.Etat_2ENATTENTE
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                    Case ACTION.Action_VITESSESTABLE
                    Case ACTION.Action_VITESSENONSTABLE
                        SetEtat1GPSACTIF()
                    Case ACTION.Action_DEMARRER
                        SetEtat3MESUREENCOURS()
                    Case ACTION.Action_ARRETABLE
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                End Select
            Case ETAT.Etat_3MESUREENCOURS
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                    Case ACTION.Action_VITESSESTABLE
                    Case ACTION.Action_VITESSENONSTABLE
                    Case ACTION.Action_DEMARRER
                    Case ACTION.Action_ARRETABLE
                        SetEtat4MESUREARRETABLE()
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                        SetEtat1GPSACTIF()
                End Select
            Case ETAT.Etat_4MESUREARRETABLE
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                    Case ACTION.Action_VITESSESTABLE
                    Case ACTION.Action_VITESSENONSTABLE
                    Case ACTION.Action_DEMARRER
                        'Arrêter
                        SetEtat5MESUREEFFECTUEE()
                    Case ACTION.Action_ARRETABLE
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                        SetEtat1GPSACTIF()
                End Select
            Case ETAT.Etat_5MESUREEFFECTUEE
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                    Case ACTION.Action_VITESSESTABLE
                    Case ACTION.Action_VITESSENONSTABLE
                    Case ACTION.Action_DEMARRER
                    Case ACTION.Action_ARRETABLE
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                        SetEtat67MESURESEFFECTUEES()
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                End Select
            Case ETAT.Etat_6MESUREOK
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                    Case ACTION.Action_VITESSESTABLE
                    Case ACTION.Action_VITESSENONSTABLE
                    Case ACTION.Action_DEMARRER
                        'Redemarrer
                        SetEtat1GPSACTIF()
                    Case ACTION.Action_ARRETABLE
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                End Select
            Case ETAT.Etat_7_2MESUREOK
                Select Case paction
                    Case ACTION.Action_GPSACTIF
                    Case ACTION.Action_VITESSESTABLE
                    Case ACTION.Action_VITESSENONSTABLE
                    Case ACTION.Action_DEMARRER
                        'Redemarrer
                        SetEtat1GPSACTIF()
                    Case ACTION.Action_ARRETABLE
                    Case ACTION.Action_ARRETER
                    Case ACTION.Action_VITESSELUEOK
                    Case ACTION.Action_MESURESUIVANTE
                    Case ACTION.Action_RESET
                End Select

        End Select
        Return _EtatForm
    End Function

    Private Sub cbValiderVitesseLue_Click(sender As Object, e As EventArgs) Handles cbValiderVitesseLue.Click

        SetAction(ACTION.Action_VITESSELUEOK)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PnlCacheCkTest.Top = TableLayoutPanel2.Top
    End Sub

    Private Sub MaterialSlider1_onValueChanged(sender As Object, newValue As Integer)
        Dim valeur As Decimal = newValue / 10
        _MesureEncours.VitesseLue = valeur
        m_bsrcGPSMesure.ResetBindings(False)
    End Sub

    Private Sub VitesseLueMoins_Click(sender As Object, e As EventArgs) Handles VitesseLueMoins.Click
        _MesureEncours.VitesseLue = _MesureEncours.VitesseLue - 0.1D
        m_bsrcGPSMesure.ResetBindings(False)
    End Sub

    Private Sub VitesseLuePlus_Click(sender As Object, e As EventArgs) Handles VitesseLuePlus.Click
        _MesureEncours.VitesseLue = _MesureEncours.VitesseLue + 0.1D
        m_bsrcGPSMesure.ResetBindings(False)

    End Sub

    Private Sub cbReset_Click(sender As Object, e As EventArgs) Handles cbReset.Click
        SetAction(ACTION.Action_RESET)
    End Sub
End Class