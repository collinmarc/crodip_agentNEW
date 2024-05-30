Imports MaterialSkin
Public Class Form1
    Inherits MaterialSkin.Controls.MaterialForm

    Private _MesureEncours As GPSMesure = Nothing
    Dim m1 As GPSMesure
    Dim m2 As GPSMesure
    Public elapsedTime As TimeSpan
    Private startTime As DateTime

    Private Enum EtatFom As Integer
        GPSNONACTIF = 0
        ENATTENTE = 1
        MESUREENCOURS = 2
        MESUREARRETABLE = 3
        MESURESEFFECTUEES = 4
        GPSACTIF = 5
    End Enum
    Private _Etat As EtatFom
    Private WithEvents gpsManager As New GPSManager()
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

        m1 = New GPSMesure()
        m_bsrcGPSMesure.Add(m1)
        m1.Vitesse = 15.6
        m2 = New GPSMesure()
        m_bsrcGPSMesure.Add(m2)
        m_bsrcGPSMesure.MoveFirst()
        SetEtat0GPSNONACTIF()
        TraceMsg("initialisation")
        portName = gpsManager.TrouverPortGPS()

        If portName IsNot Nothing Then
            SetEtat1ENATTENTE()
            TraceMsg("Configurer Port " & portName)
            gpsManager.ConfigurerPortSerie(portName, 9600)
            TraceMsg("Activer le GPS")
            gpsManager.ActiverGPS()
            startTime = DateTime.Now
            elapsedTime = TimeSpan.MinValue


        End If
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
                Timer1.Enabled = True
                Timer1.Start()

                '            Case EtatFom.MESUREENCOURS
 '               SetEtat4MESURESEFFECTUEES()
            Case EtatFom.MESUREARRETABLE
                Timer1.Stop()
                gpsManager.DesactiverGPS()
                SetEtat4MESURESEFFECTUEES()
            Case Else
                'SetEtat1ENATTENTE()
        End Select

    End Sub

    Private Sub CbMesureSuivante_Click(sender As Object, e As EventArgs) Handles CbMesureSuivante.Click
        rbMesure2.Checked = True
        CbMesureSuivante.Enabled = False
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
    End Sub
    Private Sub SetEtat6GPSACTIF()
        TraceMsg("Etat6")
        _Etat = EtatFom.GPSACTIF
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.Text = "Démarrer"
        cbMesure.UseAccentColor = False
        cbMesure.Enabled = False
        CbMesureSuivante.Enabled = False
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
        Else
            _Etat = EtatFom.ENATTENTE
        End If
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        cbMesure.UseAccentColor = False
        cbMesure.Text = "Démarrer"
        cbMesure.Enabled = True
        cbMesure.Tag = "ARRETEE"
        CbMesureSuivante.Enabled = (_Etat = EtatFom.ENATTENTE)
    End Sub
    Private _n As Integer
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        '        If gpsManager.GPSActif Then
        'TraceMsg("Ecoute[" & gpsManager.lastLatitude & "," & gpsManager.lastLongitude & "]")
        Randomize()
        _MesureEncours.Distance = _MesureEncours.Distance + (Rnd() * 10)
        '_MesureEncours.Distance = gpsManager.Distance
        elapsedTime = DateTime.Now - startTime
        _MesureEncours.Temps = elapsedTime.Seconds

        If _Etat = EtatFom.GPSACTIF Then
            'On Attend d'avoir une vitesse Stable
            If isVitesseStable() Then
                SetEtat1ENATTENTE()
                Timer1.Stop() 'On arrete la lecture
            End If
        Else
            If _Etat <> EtatFom.MESUREARRETABLE Then
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
            m_bsrcGPSMesure.ResetBindings(False)
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
        cbExporter.Enabled = False
        If m_bsrcGPSMesure.Count = 2 Then
            If m1.Distance > 0 And m2.Distance > 0 Then
                cbExporter.Enabled = True
            End If
        End If
    End Sub

    Private Sub gpsManager_GPSActifEvent(sender As Object, e As EventArgs) Handles gpsManager.GPSActifEvent
        SetEtat6GPSACTIF()
        startTime = DateTime.Now
        elapsedTime = TimeSpan.MinValue
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub TraceMsg(pMessage As String)
        Console.WriteLine(pMessage)

    End Sub

    Private Sub ckGPSActif_CheckedChanged(sender As Object, e As EventArgs) Handles ckGPSActif.CheckedChanged
        gpsManager.GPSActif = True
    End Sub
    Dim _FichierExport As String
    Private Sub cbExporter_Click(sender As Object, e As EventArgs) Handles cbExporter.Click
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
            m1.ToCsv(pFile)
            m2.ToCsv(pFile)
            bReturn = True
        Catch ex As Exception
            TraceMsg(ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class