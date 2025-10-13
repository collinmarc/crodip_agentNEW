Imports System.ComponentModel
Imports System.Threading
Imports System.Timers
Imports MaterialSkin
Imports CRODIPGPS

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
        MettreAJourThemeLight()
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

        gpsManager = New GPSManager()

        'on lance un premier Timer pour Trouver le Port GPS
        TimerLectureGPS.Interval = My.Settings.intervalGPS
        TimerLectureGPS.Enabled = True

        CkTest.Checked = My.Settings.Test
        ModeTest(My.Settings.Test)

        laTempsClick.Visible = My.Settings.AffichageTempsClick

        AddHandler TimerLectureGPS.Tick, AddressOf GPS_Rechercherleportserie
        TimerLectureGPS.Start()
    End Sub

    Private Sub cbMesure_Click(sender As Object, e As EventArgs) Handles cbMesure.Click

        Select Case _EtatForm
            Case ETAT.Etat_2ENATTENTE
                'Demarrage d'une Mesure
                'SetEtat2MESUREENCOURS()
                startTime = DateTime.Now()
                elapsedTime = TimeSpan.MinValue
                _MesureEncours.Distance = 0
                _MesureEncours.Temps = 0
                _MesureEncours.VitesseLue = 0
                _MesureEncours.startClick = DateTime.Now
                _MesureEncours.EndClick = DateTime.MinValue
                _MesureEncours.lstTraces.Clear()
                gpsManager.init(pPrendreEnCompteLADerniereTraceGGA:=True)
                m_bsrcGPSMesure.ResetBindings(False)
                SetAction(ACTIONFORM.Action_DEMARRER)

                'on redemarre le timer pour récupérer les données
                'On recupère la dernière donnée
                GPS_RecupDonnees(Nothing, Nothing)
                AddHandler TimerLectureGPS.Tick, AddressOf GPS_RecupDonnees
                TimerLectureGPS.Interval = My.Settings.intervalGPS
                TimerLectureGPS.Start()

            Case ETAT.Etat_4MESUREARRETABLE
                _MesureEncours.EndClick = DateTime.Now
                'Arret du Timer
                TimerLectureGPS.Stop()
                RemoveHandler TimerLectureGPS.Tick, AddressOf GPS_RecupDonnees
                GPS_RecupDonnees(Nothing, Nothing)

                _MesureEncours.VitesseLue = My.Settings.VitesseLue
                _MesureEncours.lstTraces.AddRange(gpsManager.getTraces())
                m_bsrcGPSMesure.ResetCurrentItem()
                SetAction(ACTIONFORM.Action_DEMARRER)

            Case Else
                'Recommencer
                SetAction(ACTIONFORM.Action_DEMARRER)
        End Select

    End Sub

    Private Sub CbMesureSuivante_Click(sender As Object, e As EventArgs) Handles CbMesureSuivante.Click
        cbMesure.Text = "Démarrer"
        m_bsrcGPSMesure.MoveNext()
        CbMesureSuivante.Enabled = False
        rbMesure1.Enabled = False
        SetEtat1GPSACTIF()
    End Sub

    Private Sub cbQuitter_Click(sender As Object, e As EventArgs) Handles cbQuitter.Click
        TimerLectureGPS.Stop()
        gpsManager.Close()
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub


    Private Sub SetEtat0GPSNONACTIF()
        TraceMsg("Etat0")
        lblEtat.Text = "GPS INACTIF"
        _EtatForm = ETAT.Etat_0GPSINACTIF
        MettreAJourThemeDARK()
        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = False
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        CbMesureSuivante.Enabled = False
        laVitesseMesuree.Visible = CkTest.Checked
        tbVitesseMesuree.Visible = CkTest.Checked
        SetVitesseLueVisible(False)
    End Sub
    Private Sub SetEtat1GPSACTIF()
        TraceMsg("Etat1 GPS ACTIF")
        lblEtat.Text = "GPSACTIF(" & portName & "," & My.Settings.VitessePort & ")"
        _EtatForm = ETAT.Etat_1GPSACTIF
        MettreAJourThemeLight()
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
        laVitesseMesuree.Visible = CkTest.Checked
        tbVitesseMesuree.Visible = CkTest.Checked
        SetVitesseLueVisible(False)
        gpsManager.init()
        gpsManager.VitesseConstante = False

        _MesureEncours.Distance = 0
        _MesureEncours.Temps = 0
        _MesureEncours.VitesseLue = 0
        _MesureEncours.VitesseConstante = False
        _MesureEncours.startClick = DateTime.MinValue
        _MesureEncours.EndClick = DateTime.MinValue
        m_bsrcGPSMesure.ResetBindings(False)

        'on redemarre le timer pour attendre la vitesse stable
        RemoveHandler TimerLectureGPS.Tick, AddressOf GPS_RecupDonnees
        AddHandler TimerLectureGPS.Tick, AddressOf GPS_AttentevitesseStable
        TimerLectureGPS.Interval = My.Settings.intervalGPS
        TimerLectureGPS.Start()
    End Sub
    Private Sub SetEtat2ENATTENTE()
        TraceMsg("Etat2 en attente de demarrage")
        lblEtat.Text = "VITESSE STABLE[" & gpsManager.getVitesse & "]"

        _EtatForm = ETAT.Etat_2ENATTENTE
        MettreAJourThemeLight()
        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = True
        CbMesureSuivante.Enabled = Not rbMesure2.Checked And _MesureEncours.Distance > 0
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        SetVitesseLueVisible(False)

        TimerLectureGPS.Stop()
        RemoveHandler TimerLectureGPS.Tick, AddressOf GPS_AttentevitesseStable

    End Sub
    Private Sub SetEtat3MESUREENCOURS()
        TraceMsg("Etat3 Mesure en cours")
        lblEtat.Text = "MESURE EN COURS"
        _EtatForm = ETAT.Etat_3MESUREENCOURS
        MettreAJourThemeDARK()
        cbMesure.Text = "En cours"
        cbMesure.UseAccentColor = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 2)
        cbReset.Visible = True
        cbReset.Enabled = True
        cbReset.BackColor = Color.Red
        'cbMesure.Enabled = False
        _n = 0
        'pbMesure.Value = 0
        CbMesureSuivante.Enabled = False
        'La Vitesse mesurée n'est pas affichée encours d'acquiqition
        tbVitesseMesuree.Visible = CkTest.Checked
        laVitesseMesuree.Visible = CkTest.Checked
        rbMesure1.Enabled = False
        rbMesure2.Enabled = False
        SetVitesseLueVisible(False)

    End Sub
    Private Sub SetEtat4MESUREARRETABLE()
        TraceMsg("Etat4 Arretable")
        lblEtat.Text = "MESURE ARRETABLE"

        _EtatForm = ETAT.Etat_4MESUREARRETABLE
        MettreAJourThemeLight()
        cbMesure.UseAccentColor = True
        cbMesure.Text = "Arrêter"
        cbMesure.Enabled = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 2)
        cbReset.Visible = True
        cbReset.Enabled = True
        cbReset.BackColor = Color.Red
        CbMesureSuivante.Enabled = False
        SetVitesseLueVisible(False)
    End Sub
    Private Sub SetEtat5MESUREEFFECTUEE()
        TraceMsg("Etat5 effectuée")
        lblEtat.Text = "MESURE ARRETEE"

        _EtatForm = ETAT.Etat_5MESUREEFFECTUEE
        MettreAJourThemeLight()
        cbReset.Visible = False
        cbReset.Enabled = False
        'cbMesure.UseAccentColor = True
        cbMesure.Text = "Recommencer"
        cbMesure.Enabled = True
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        CbMesureSuivante.Enabled = False
        'Positionnement sur la vitesse Lue
        Me.SelectNextControl(laVitesseLue, True, False, False, True)
        SetVitesseLueVisible(True)

    End Sub
    Private Sub SetVitesseLueVisible(pVisible As Boolean)
        laVitesseLue.Visible = pVisible
        cbVitesseLueMoins1.Visible = pVisible
        VitesseLueMoins.Visible = pVisible
        VitesseLuePlus.Visible = pVisible
        cbVitesseLuePlus1.Visible = pVisible
        tbVitesseLue.Visible = pVisible
        TableLayoutPanelVitesseLue.Visible = pVisible
        cbValiderVitesseLue.Visible = pVisible
        cbValiderVitesseLue.Enabled = pVisible

    End Sub
    Private Sub SetEtat67MESURESEFFECTUEES()
        TraceMsg("Etat67 Mesures Effectuées")
        cbReset.Visible = False
        cbReset.Enabled = False
        cbMesure.Text = "Recommencer"
        Me.TableLayoutPanel2.SetColumnSpan(Me.cbMesure, 3)
        If m1.Distance > 0 And m2.Distance > 0 Then
            _EtatForm = ETAT.Etat_7_2MESUREOK
            cbSauvegarder.Enabled = True
        Else
            _EtatForm = ETAT.Etat_6MESUREOK
            cbSauvegarder.Enabled = False
        End If
        MettreAJourThemeLight()
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = True
        If m1.Distance > 0 And m2.Distance = 0 Then
            CbMesureSuivante.Enabled = True
        End If
        tbVitesseMesuree.Visible = CkTest.Checked
        laVitesseMesuree.Visible = CkTest.Checked

        rbMesure1.Enabled = True
        rbMesure2.Enabled = True

    End Sub
    Private _n As Integer

    ''' <summary>
    ''' Ecoute regulière pour trouver le port GPS
    ''' 'Methode non utilisée une fois que le GPS est Actif
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' 
    Private Sub GPS_Rechercherleportserie(sender As Object, e As EventArgs)
        portName = gpsManager.TrouverPortGPS(My.Settings.Port)

        If portName IsNot Nothing Then
            TimerLectureGPS.Stop()
            RemoveHandler TimerLectureGPS.Tick, AddressOf GPS_Rechercherleportserie
            gpsManager.ConfigurerPortSerie(portName, My.Settings.VitessePort)
            SetAction(ACTIONFORM.Action_GPSACTIF)
        End If

    End Sub
    Private Sub GPS_AttentevitesseStable(sender As Object, e As EventArgs)
        Trace.WriteLine("AttenteVitesseStable")
        'Vérification de la vitesse Constante
        Dim distance As Decimal
        Dim vitesse As Decimal
        Dim temps As Double
        'Récupération de la distance
        If Not String.IsNullOrEmpty(portName) Then
            TraceMsg("Ecoute[Position Depart=(" & gpsManager.startLatitude & "|" & gpsManager.startLongitude & ") distance=" & gpsManager.distance & "]")
            distance = gpsManager.distance
            Else
                Randomize()
            TraceMsg("Ecoute generée[" & distance & "]")
            distance = _MesureEncours.Distance + (Rnd() * 10)
        End If

        'Calcul de vitesse
        temps = (gpsManager.EndTime - gpsManager.startTime).TotalSeconds
        vitesse = gpsManager.calculeVitesse(distance, temps)


        If Not gpsManager.VitesseConstante Then
            If vitesse > 0 Then
                gpsManager.ajouteVitesse(vitesse)
            End If
            If gpsManager.VitesseConstante Then
                TraceMsg("Vitesse stabilisée à " & vitesse)
                TimerLectureGPS.Stop() 'on arrête le Timer
                RemoveHandler TimerLectureGPS.Tick, AddressOf GPS_AttentevitesseStable
                SetAction(ACTIONFORM.Action_VITESSESTABLE)
            End If
        End If

    End Sub

    Private Sub GPS_RecupDonnees(sender As Object, e As EventArgs)
        Dim distance As Decimal
        Dim vitesse As Decimal
        Dim temps As Double

        'Récupération de la distance
        If Not String.IsNullOrEmpty(portName) Then
            'If Not gpsManager.bDataUpdated Then
            '    'Pas de Data Mise à jour , on sort
            '    Console.WriteLine("Pas de donnée")
            '    Exit Sub
            'End If
            _MesureEncours.lstTraces.AddRange(gpsManager.getTraces())
            'TraceMsg("Ecoute[Position Depart=(" & gpsManager.startLatitude & "|" & gpsManager.startLongitude & ") distance=" & gpsManager.distance & "]")
            distance = gpsManager.distance
            Else
                Randomize()
            'TraceMsg("Ecoute generée[" & distance & "]")
            distance = _MesureEncours.Distance + (Rnd() * 10)
        End If

        'Calcul de vitesse
        If _EtatForm = ETAT.Etat_3MESUREENCOURS Or _EtatForm = ETAT.Etat_4MESUREARRETABLE Then
            vitesse = _MesureEncours.Vitesse
            _MesureEncours.HeureDepart = gpsManager.startTime
            _MesureEncours.PositionDepart = gpsManager.PositionDepart
            _MesureEncours.HeureArrivee = gpsManager.EndTime
            _MesureEncours.PositionArrivee = gpsManager.PositionArrivee
            gpsManager.bDataUpdated = False 'on a récupéreré les données
            temps = (_MesureEncours.HeureArrivee - _MesureEncours.HeureDepart).TotalSeconds
            _MesureEncours.Temps = temps
            _MesureEncours.Distance = distance
            vitesse = _MesureEncours.calculeVitesse(distance, temps)
        Else
            elapsedTime = DateTime.Now - startTime
            temps = elapsedTime.TotalSeconds

            vitesse = _MesureEncours.calculeVitesse(distance, temps)
            _MesureEncours.Distance = 0
            _MesureEncours.Temps = 0
            _MesureEncours.Vitesse = vitesse
        End If


        'La Mesure est-elle complête ?
        If _EtatForm = ETAT.Etat_3MESUREENCOURS Then
            If _MesureEncours.Vitesse < My.Settings.LimiteVitesse Then
                If _MesureEncours.Distance > My.Settings.Distance1 Then
                    SetAction(ACTIONFORM.Action_ARRETABLE)
                End If
            Else
                If _MesureEncours.Distance > My.Settings.Distance2 Then
                    SetAction(ACTIONFORM.Action_ARRETABLE)
                End If

            End If
        End If
        m_bsrcGPSMesure.ResetBindings(False)
    End Sub

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

    Private Sub TraceMsg(pMessage As String)
        Console.WriteLine(pMessage)
        If My.Settings.Log Then
            System.IO.File.AppendAllText("./CRODIPGPS.LOG", pMessage & vbCrLf)
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
        If CkTest.Checked Then
            Process.Start("notepad.exe", _FichierExport)
        Else
            Me.Close()
            Me.DialogResult = DialogResult.OK
        End If
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

    Private Sub CkTest_CheckedChanged(sender As Object, e As EventArgs) Handles CkTest.CheckedChanged

        ModeTest(CkTest.Checked)

    End Sub

    Public Sub ModeTest(pTest As Boolean)
        PnlCacheCkTest.Top = TableLayoutPanel2.Top
        PnlCacheCkTest.Left = TableLayoutPanel2.Left
        PnlCacheCkTest.Visible = Not pTest
        laMesure.Visible = pTest 'Visible en mode test
        ' CkTest.Visible = CkTest.Checked
        tbVitesseMesuree.ForeColor = tbVitesseMesuree.BackColor
        laVitesseMesuree.Visible = pTest
        tbVitesseMesuree.Visible = pTest
        lblEtat.Visible = pTest
        pnlTest.Visible = pTest

        If pTest Then
            Me.Width = 801
        Else
            Me.Width = 441
        End If

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



    Public Enum ACTIONFORM As Integer
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

    Public Function SetAction(paction As ACTIONFORM) As ETAT

        Select Case _EtatForm
            Case ETAT.Etat_0GPSINACTIF
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                        SetEtat1GPSACTIF()
                    Case ACTIONFORM.Action_VITESSESTABLE
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                    Case ACTIONFORM.Action_DEMARRER
                    Case ACTIONFORM.Action_ARRETABLE
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                End Select
            Case ETAT.Etat_1GPSACTIF
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                    Case ACTIONFORM.Action_VITESSESTABLE
                        SetEtat2ENATTENTE()
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                    Case ACTIONFORM.Action_DEMARRER
                    Case ACTIONFORM.Action_ARRETABLE
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                End Select
            Case ETAT.Etat_2ENATTENTE
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                    Case ACTIONFORM.Action_VITESSESTABLE
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                        SetEtat1GPSACTIF()
                    Case ACTIONFORM.Action_DEMARRER
                        SetEtat3MESUREENCOURS()
                    Case ACTIONFORM.Action_ARRETABLE
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                End Select
            Case ETAT.Etat_3MESUREENCOURS
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                    Case ACTIONFORM.Action_VITESSESTABLE
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                    Case ACTIONFORM.Action_DEMARRER
                    Case ACTIONFORM.Action_ARRETABLE
                        SetEtat4MESUREARRETABLE()
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                        SetEtat1GPSACTIF()
                End Select
            Case ETAT.Etat_4MESUREARRETABLE
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                    Case ACTIONFORM.Action_VITESSESTABLE
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                    Case ACTIONFORM.Action_DEMARRER
                        'Arrêter
                        SetEtat5MESUREEFFECTUEE()
                    Case ACTIONFORM.Action_ARRETABLE
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                        SetEtat1GPSACTIF()
                End Select
            Case ETAT.Etat_5MESUREEFFECTUEE
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                    Case ACTIONFORM.Action_VITESSESTABLE
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                    Case ACTIONFORM.Action_DEMARRER
                        'Recommencer
                        SetEtat1GPSACTIF()
                    Case ACTIONFORM.Action_ARRETABLE
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                        SetEtat67MESURESEFFECTUEES()
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                End Select
            Case ETAT.Etat_6MESUREOK
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                    Case ACTIONFORM.Action_VITESSESTABLE
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                    Case ACTIONFORM.Action_DEMARRER
                        'ReCommencer
                        SetEtat1GPSACTIF()
                    Case ACTIONFORM.Action_ARRETABLE
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                End Select
            Case ETAT.Etat_7_2MESUREOK
                Select Case paction
                    Case ACTIONFORM.Action_GPSACTIF
                    Case ACTIONFORM.Action_VITESSESTABLE
                    Case ACTIONFORM.Action_VITESSENONSTABLE
                    Case ACTIONFORM.Action_DEMARRER
                        'Redemarrer
                        SetEtat1GPSACTIF()
                    Case ACTIONFORM.Action_ARRETABLE
                    Case ACTIONFORM.Action_ARRETER
                    Case ACTIONFORM.Action_VITESSELUEOK
                    Case ACTIONFORM.Action_MESURESUIVANTE
                    Case ACTIONFORM.Action_RESET
                End Select

        End Select
        Return _EtatForm
    End Function

    Private Sub cbValiderVitesseLue_Click(sender As Object, e As EventArgs) Handles cbValiderVitesseLue.Click

        SetAction(ACTIONFORM.Action_VITESSELUEOK)
    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PnlCacheCkTest.Top = TableLayoutPanel2.Top
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
        SetAction(ACTIONFORM.Action_RESET)
    End Sub

    Private Sub cbVitesseLueMoins1_Click(sender As Object, e As EventArgs) Handles cbVitesseLueMoins1.Click
        _MesureEncours.VitesseLue = _MesureEncours.VitesseLue - 1D
        m_bsrcGPSMesure.ResetBindings(False)
    End Sub

    Private Sub cbVitesseLuePlus1_Click(sender As Object, e As EventArgs) Handles cbVitesseLuePlus1.Click
        _MesureEncours.VitesseLue = _MesureEncours.VitesseLue + 1D
        m_bsrcGPSMesure.ResetBindings(False)
    End Sub

    Private Sub MettreAJourThemeLight()
        ' Vérifier si nous sommes sur le thread UI
        If Me.InvokeRequired Then
            ' Si nous ne sommes pas sur le thread UI, utiliser Invoke
            Me.Invoke(New Action(AddressOf MettreAJourThemeLight))
        Else
            ' Nous sommes sur le thread UI, mettre à jour le thème
            SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        End If
    End Sub
    Private Sub MettreAJourThemeDARK()
        ' Vérifier si nous sommes sur le thread UI
        If Me.InvokeRequired Then
            ' Si nous ne sommes pas sur le thread UI, utiliser Invoke
            Me.Invoke(New Action(AddressOf MettreAJourThemeDARK))
        Else
            ' Nous sommes sur le thread UI, mettre à jour le thème
            SkinManager.Theme = MaterialSkinManager.Themes.DARK
        End If
    End Sub

    Private Sub RechercherleportserieGPS(sender As Object, e As EventArgs)
        Trace.WriteLine("RechercherleportserieGPS")
        portName = gpsManager.TrouverPortGPS(My.Settings.Port)

        If portName IsNot Nothing Then
            gpsManager.ConfigurerPortSerie(portName, My.Settings.VitessePort)
            m_BackgroundWorker.ReportProgress(1, portName)
        End If

    End Sub


    Private Sub m_BackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles m_BackgroundWorker.DoWork
        gpsManager = New GPSManager()
        While gpsManager.TrouverPortGPS(My.Settings.Port) = ""
            Thread.Sleep(My.Settings.intervalGPS)
        End While

        While Not gpsManager.GPSActif
            Thread.Sleep(My.Settings.intervalGPS)
        End While

    End Sub

    Private Sub m_BackgroundWorker_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles m_BackgroundWorker.ProgressChanged
        Select Case e.ProgressPercentage
            Case 1 'Port Serie Trouvé
                'SetEtat1ENATTENTE()
                SetAction(ACTIONFORM.Action_GPSACTIF)
                TraceMsg("Configurer Port " & portName)
        End Select


    End Sub

    Private Sub m_BackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles m_BackgroundWorker.RunWorkerCompleted
        gpsManager.Close()
    End Sub

    Private Sub cbMesure_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbMesure.KeyPress

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim TSTgpsManager As New GPSManager
        TSTgpsManager.ProcessNMEAData(tbCoord1.Text)
        TSTgpsManager.ProcessNMEAData(tbCoord2.Text)
        tbDistance.Text = Math.Round(TSTgpsManager.distance, My.Settings.PrecisionDistance)
        tbTemps.Text = (TSTgpsManager.EndTime - TSTgpsManager.startTime).TotalSeconds
    End Sub
End Class