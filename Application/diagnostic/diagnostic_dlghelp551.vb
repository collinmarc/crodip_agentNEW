Imports System.Windows.Forms

Public Class diagnostic_dlghelp551
    Implements IfrmCRODIP


    Private m_Mode As DiagnosticHelp551.Help551Mode
    Private m_oDiag As Diagnostic
    Private m_oHelp As DiagnosticHelp551
    Private m_bDuringLoad551 As Boolean
    Private m_bVisu As Boolean
    ''' <summary>
    ''' Etablit le contexte d'execution
    ''' le mode d'utilisaation 551 ou 5621
    ''' le diagnostic support
    ''' </summary>
    ''' <param name="pMode"></param>
    ''' <param name="pDiag"></param>
    ''' <remarks></remarks>
    Public Sub setContexte(pMode As DiagnosticHelp551.Help551Mode, pDiag As Diagnostic, pTitre As String, pVisu As Boolean)
        m_oDiag = pDiag
        m_Mode = pMode
        laTitre.Text = pTitre
        Select Case m_Mode
            Case DiagnosticHelp551.Help551Mode.Mode551
                m_oHelp = m_oDiag.diagnosticHelp551.Clone()
            Case DiagnosticHelp551.Help551Mode.Mode5621
                m_oHelp = m_oDiag.diagnosticHelp5621.Clone()
            Case DiagnosticHelp551.Help551Mode.Mode12323
                m_oHelp = m_oDiag.diagnosticHelp12323.Clone()

        End Select
        m_bVisu = pVisu
        popup_help551_init()
    End Sub

    Private Sub btnValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValider.Click
        Valider()
    End Sub
    Protected Overridable Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Select m_Mode
                Case DiagnosticHelp551.Help551Mode.Mode551
                    m_oDiag.diagnosticHelp551 = m_oHelp
                Case DiagnosticHelp551.Help551Mode.Mode5621
                    m_oDiag.diagnosticHelp5621 = m_oHelp
                Case DiagnosticHelp551.Help551Mode.Mode12323
                    m_oDiag.diagnosticHelp12323 = m_oHelp
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_dlghelp552.Valider Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub btnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnuler.Click
        Annuler()
    End Sub
    Protected Overridable Sub Annuler() Implements IfrmCRODIP.Annuler
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
    Private Function tab551_isDistanceTempsFilled(ByVal idMesure As Integer) As Boolean
        Dim bReturn As Boolean
        Dim tmpTemps As Double

        Select Case idMesure
            Case 1
                If Trim(help551_m1_distance.Text) <> "" And IsNumeric(help551_m1_distance.Text) And _
                   Trim(help551_m1_temps.Text) <> "" And IsNumeric(help551_m1_temps.Text) Then
                    tmpTemps = Globals.StringToDouble(help551_m1_temps.Text)
                    bReturn = (tmpTemps > 0)
                Else
                    bReturn = False
                End If
            Case 2
                If Trim(help551_m2_distance.Text) <> "" And IsNumeric(help551_m2_distance.Text) _
                    And Trim(help551_m2_temps.Text) <> "" And IsNumeric(help551_m2_temps.Text) Then
                    tmpTemps = Globals.StringToDouble(help551_m2_temps.Text)
                    bReturn = (tmpTemps > 0)
                Else
                    bReturn = False
                End If
        End Select
        Return bReturn
    End Function
    Private Function tab551_isAllFilled(ByVal idMesure As Integer) As Boolean
        Dim bReturn As Boolean
        Dim tmpTemps As Double

        Select Case idMesure
            Case 1
                If Trim(help551_m1_distance.Text) <> "" And IsNumeric(help551_m1_distance.Text) And _
                   Trim(help551_m1_temps.Text) <> "" And IsNumeric(help551_m1_temps.Text) And _
                   Trim(help551_m1_vitesseLue.Text) <> "" And IsNumeric(help551_m1_vitesseLue.Text) Then
                    tmpTemps = Globals.StringToDouble(help551_m1_temps.Text)
                    bReturn = (tmpTemps > 0)
                Else
                    bReturn = False
                End If
            Case 2
                If Trim(help551_m2_distance.Text) <> "" And IsNumeric(help551_m2_distance.Text) _
                    And Trim(help551_m2_temps.Text) <> "" And IsNumeric(help551_m2_temps.Text) And _
                    Trim(help551_m2_vitesseLue.Text) <> "" And IsNumeric(help551_m2_vitesseLue.Text) Then
                    tmpTemps = Globals.StringToDouble(help551_m2_temps.Text)
                    bReturn = (tmpTemps > 0)
                Else
                    bReturn = False
                End If
        End Select
        Return bReturn
    End Function
    Private Function tab551_isAllFilled() As Boolean
        If tab551_isAllFilled(1) And tab551_isAllFilled(2) Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub popup_help551_init()
        m_bDuringLoad551 = True
        help551_m1_distance.Text = ""
        help551_m1_temps.Text = ""
        help551_m1_vitesseLue.Text = ""
        help551_m1_vitesseReelle.Text = ""
        help551_m1_ecart.Text = ""
        help551_m2_distance.Text = ""
        help551_m2_temps.Text = ""
        help551_m2_vitesseLue.Text = ""
        help551_m2_vitesseReelle.Text = ""
        help551_m2_ecart.Text = ""
        If m_bVisu Then
            help551_m1_distance.Enabled = False
            help551_m1_temps.Enabled = False
            help551_m1_vitesseLue.Enabled = False
            help551_m1_vitesseReelle.Enabled = False
            help551_m1_ecart.Enabled = False
            help551_m2_distance.Enabled = False
            help551_m2_temps.Enabled = False
            help551_m2_vitesseLue.Enabled = False
            help551_m2_vitesseReelle.Enabled = False
            help551_m2_ecart.Enabled = False
            help551_m1_result.Enabled = False
            help551_m2_result.Enabled = False
            help551_result.Enabled = False
            btnValider.Enabled = False
        End If
        'Récupération des infos de help551
        If m_oHelp.HasValue Then
            help551_m1_distance.Text = m_oHelp.Distance1
            help551_m1_temps.Text = m_oHelp.Temps1
            help551_m1_vitesseLue.Text = m_oHelp.VitesseLue1
            help551_m1_vitesseReelle.Text = m_oHelp.VitesseReelle1
            help551_m1_ecart.Text = m_oHelp.Ecart1
            help551_m1_result.Text = m_oHelp.Resultat1
            help551_m2_distance.Text = m_oHelp.Distance2
            help551_m2_temps.Text = m_oHelp.Temps2
            help551_m2_vitesseLue.Text = m_oHelp.VitesseLue2
            help551_m2_vitesseReelle.Text = m_oHelp.VitesseReelle2
            help551_m2_ecart.Text = m_oHelp.Ecart2
            help551_m2_result.Text = m_oHelp.Resultat2
            help551_result.Text = m_oHelp.Resultat
            help551_erreurMoyenne.Text = m_oHelp.ErreurMoyenne
        End If
        m_bDuringLoad551 = False
        If Not m_bVisu Then
            calc_help_551()
        End If
        Select Case m_Mode
            Case DiagnosticHelp551.Help551Mode.Mode551
                lblCodeDefaut.Text = "5.5.1.2"
            Case DiagnosticHelp551.Help551Mode.Mode5621
                lblCodeDefaut.Text = "5.6.2.1"
            Case DiagnosticHelp551.Help551Mode.Mode12323
                lblCodeDefaut.Text = "12.3.2.3"
        End Select
    End Sub
    Private Sub help551_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Private Sub help551_m1_distance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help551_m1_distance.TextChanged
        'calc_help_551_vitesseReelle(1)
        calc_help_551()
    End Sub
    Private Sub help551_m1_temps_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help551_m1_temps.TextChanged
        'calc_help_551_vitesseReelle(1)
        calc_help_551()
    End Sub
    Private Sub help551_m1_vitesseLue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help551_m1_vitesseLue.TextChanged
        calc_help_551()
    End Sub
    Private Sub help551_m2_distance_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help551_m2_distance.TextChanged
        'calc_help_551_vitesseReelle(2)
        calc_help_551()
    End Sub
    Private Sub help551_m2_temps_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help551_m2_temps.TextChanged
        'calc_help_551_vitesseReelle(2)
        calc_help_551()
    End Sub
    Private Sub help551_m2_vitesseLue_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help551_m2_vitesseLue.TextChanged
        calc_help_551()
    End Sub
    Public Sub calc_help_551()
        If Not m_bDuringLoad551 Then
            ' Initialisation des vars
            Dim tmpDistance As Double = 0
            Dim tmpTemps As Double = 0
            Dim tmpVitesseReelle As Double = 0
            Dim tmpVitesseLue As Double = 0
            Dim tmpEcart As Double = 0
            Dim tmpErreurMoyenne As Double = 0
            Dim isOk As Boolean = True
            Dim isFinish As Boolean = True
            Dim tmpMoyenneVitesseReelle As Double = 0
            Dim tmpMoyenneVitesseLue As Double = 0



            'Récupération des valeurs saisies
            m_oHelp.Distance1 = help551_m1_distance.DecimalValue
            m_oHelp.Temps1 = help551_m1_temps.DecimalValue
            m_oHelp.VitesseLue1 = help551_m1_vitesseLue.DecimalValue

            m_oHelp.Distance2 = help551_m2_distance.DecimalValue
            m_oHelp.Temps2 = help551_m2_temps.DecimalValue
            m_oHelp.VitesseLue2 = help551_m2_vitesseLue.DecimalValue

            'Calcul des Valeurs
            m_oHelp.calc(5.0)

            'Affichage des Résultats
            If m_oHelp.VitesseReelle1 <> 0 Then
                help551_m1_vitesseReelle.Text = m_oHelp.VitesseReelle1
                help551_m1_ecart.Text = m_oHelp.Ecart1
            End If
            If Not String.IsNullOrEmpty(m_oHelp.Resultat1) Then
                help551_m1_result.Text = m_oHelp.Resultat1
                If help551_m1_result.Text = "IMPRECISION" Then
                    help551_m1_result.ForeColor = System.Drawing.Color.Red
                Else
                    help551_m1_result.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
                End If
            End If

            If m_oHelp.VitesseReelle2 <> 0 Then
                help551_m2_vitesseReelle.Text = m_oHelp.VitesseReelle2
                help551_m2_ecart.Text = m_oHelp.Ecart2
            End If
            If Not String.IsNullOrEmpty(m_oHelp.Resultat2) Then
                help551_m2_result.Text = m_oHelp.Resultat2
                If help551_m2_result.Text = "IMPRECISION" Then
                    help551_m2_result.ForeColor = System.Drawing.Color.Red
                Else
                    help551_m2_result.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
                End If
            End If
            If Not String.IsNullOrEmpty(m_oHelp.Resultat1) And Not String.IsNullOrEmpty(m_oHelp.Resultat2) Then
                help551_erreurMoyenne.Text = m_oHelp.ErreurMoyenneSigned
            Else
                help551_erreurMoyenne.Text = ""
            End If


            ' On affiche le résultat Global du tableau
            help551_result.Text = m_oHelp.Resultat
            If m_oHelp.Resultat = "OK" Then
                help551_result.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
            Else
                help551_result.ForeColor = System.Drawing.Color.Red
            End If
        End If


    End Sub
    Dim prevSelectedOnglet_tabAvancement As Integer = -1
    Private Sub TabControl3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
    Public Function getHelp551() As DiagnosticHelp551
        Return m_oHelp
    End Function

    Private Sub diagnostic_dlghelp551_Load(sender As Object, e As EventArgs) Handles Me.Load
        formload()
    End Sub
    Protected Overridable Sub formload() Implements IfrmCRODIP.formLoad
    End Sub
End Class
