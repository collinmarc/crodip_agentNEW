Imports System.Windows.Forms

Public Class Diagnostic_dlghelp552
    Implements IfrmCRODIP
    Public Enum Help552Mode As Integer
        Mode552 = 1
        Mode5622 = 2
        '        Mode522_5622 = 3 'Ajout a cause du Reglage Pulvé
    End Enum
    '=================================
    'Il a fallu ajouter dans la classe initiale le mode Miste a cause du reglage Pulve
    'Car dans ce mode Les 2 Help cohabitent dans un tabControl
    'En mode diagnostic il n'y qu'un seul onglet du tabControl qui est affiché à la fois
    '===================================

    Private m_Mode As Help552Mode
    Private m_oDiag As Diagnostic
    Private m_oHelp As DiagnosticHelp552
    Private m_oHelpbis As DiagnosticHelp552
    Private m_bDuringLoad552 As Boolean
    Private m_bVisu As Boolean

    Private m_calculs_m1_nbBuses As CRODIP_ControlLibrary.TBNumeric
    Private m_calculs_m1_pression As CRODIP_ControlLibrary.TBNumeric
    Private m_etalon_m1_debitEtalon As CRODIP_ControlLibrary.TBNumeric
    Private m_etalon_m1_debitAfficheur As CRODIP_ControlLibrary.TBNumeric
    Private m_m1_ecart As CRODIP_ControlLibrary.TBNumeric

    Private m_calculs_m2_nbBuses As CRODIP_ControlLibrary.TBNumeric
    Private m_calculs_m2_pression As CRODIP_ControlLibrary.TBNumeric
    Private m_etalon_m2_debitEtalon As CRODIP_ControlLibrary.TBNumeric
    Private m_etalon_m2_debitAfficheur As CRODIP_ControlLibrary.TBNumeric
    Private m_m2_ecart As CRODIP_ControlLibrary.TBNumeric

    Private m_calculs_m3_nbBuses As CRODIP_ControlLibrary.TBNumeric
    Private m_calculs_m3_pression As CRODIP_ControlLibrary.TBNumeric
    Private m_etalon_m3_debitEtalon As CRODIP_ControlLibrary.TBNumeric
    Private m_etalon_m3_debitAfficheur As CRODIP_ControlLibrary.TBNumeric
    Private m_m3_ecart As CRODIP_ControlLibrary.TBNumeric

    Private M_erreurDebimetre As CRODIP_ControlLibrary.TBNumeric
    Private m_result As Label

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Public Sub setContexte(pMode As Help552Mode, pDiag As Diagnostic, pDdebitMoyen As String, pPressionMesure As String, pbVisu As Boolean)
        m_oDiag = pDiag
        m_Mode = pMode
        m_bVisu = pbVisu
        Select Case m_Mode
            Case Help552Mode.Mode552
                m_oHelp = m_oDiag.diagnosticHelp552.Clone()
                SetControls(Help552Mode.Mode552)
                TabControl1.TabPages.RemoveByKey(tpHelp5622.Name)
            Case Help552Mode.Mode5622
                m_oHelp = m_oDiag.diagnosticHelp5622.Clone()
                SetControls(Help552Mode.Mode5622)
                TabControl1.TabPages.RemoveByKey(tpHelp552.Name)
        End Select
        help552_debitMoyen3bar.Text = pDdebitMoyen
        help552_pressionMesure.Text = pPressionMesure
        Popuphelp552_init(m_oHelp)
    End Sub


    Private Sub m_calculs_m1_nbBuses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_calculs_m1_nbBuses.TextChanged, help552_calculs_m1_nbBuses.TextChanged
        calc_help_552()
    End Sub
    Private Sub m_calculs_m1_pression_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_calculs_m1_pression.TextChanged, help552_calculs_m1_pression.TextChanged
        calc_help_552()
    End Sub
    Private Sub m_calculs_m2_nbBuses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_calculs_m2_nbBuses.TextChanged, help552_calculs_m2_nbBuses.TextChanged
        calc_help_552()
    End Sub
    Private Sub m_calculs_m2_pression_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_calculs_m2_pression.TextChanged, help552_calculs_m2_pression.TextChanged
        calc_help_552()
    End Sub
    Private Sub m_calculs_m3_nbBuses_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_calculs_m3_nbBuses.TextChanged, help552_calculs_m3_pression.TextChanged, help552_calculs_m3_nbBuses.TextChanged
        calc_help_552()
    End Sub
    Private Sub m_calculs_m3_pression_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_calculs_m3_pression.TextChanged
        calc_help_552()
    End Sub

    Private Sub m_etalon_m1_debitEtalon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calc_help_552()
    End Sub
    Private Sub m_etalon_m1_debitAfficheur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_etalon_m1_debitAfficheur.TextChanged, help552_etalon_m1_debitAfficheur.TextChanged
        calc_help_552()
    End Sub
    Private Sub m_etalon_m2_debitEtalon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calc_help_552()
    End Sub
    Private Sub m_etalon_m2_debitAfficheur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_etalon_m2_debitAfficheur.TextChanged, help552_etalon_m2_debitAfficheur.TextChanged
        calc_help_552()
    End Sub
    Private Sub m_etalon_m3_debitEtalon_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        calc_help_552()
    End Sub
    Private Sub m_etalon_m3_debitAfficheur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles help5622_etalon_m3_debitAfficheur.TextChanged, help552_etalon_m3_debitAfficheur.TextChanged
        calc_help_552()
    End Sub
    Private Function tab552_isAllFilled() As Boolean
        If m_calculs_m1_nbBuses.Text <> "" And m_calculs_m1_pression.Text <> "" And m_calculs_m2_nbBuses.Text <> "" And m_calculs_m2_pression.Text <> "" And m_calculs_m3_nbBuses.Text <> "" And m_calculs_m3_pression.Text <> "" And m_etalon_m1_debitAfficheur.Text <> "" And m_etalon_m2_debitAfficheur.Text <> "" And m_etalon_m3_debitAfficheur.Text <> "" Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Sub calc_help_552()
        ' Vars Init
        Dim oHelp As DiagnosticHelp552
        oHelp = m_oHelp

        If m_bDuringLoad552 Then
            Exit Sub
        End If

        If tab552_isAllFilled() Then
            'si on prend le débit Ramené à 3 bar, alors on prend la pression = 3
            oHelp.DebitMoyen3bar = help552_debitMoyen3bar.DecimalValue
            'oHelp.PressionMesure = help552_pressionMesure.DecimalValue
            oHelp.PressionMesure = 3

            oHelp.NbBuses_m1 = m_calculs_m1_nbBuses.DecimalValue
            oHelp.Pression_m1 = m_calculs_m1_pression.DecimalValue
            oHelp.DebitEtalon_m1 = m_etalon_m1_debitEtalon.DecimalValue
            oHelp.DebitAfficheur_m1 = m_etalon_m1_debitAfficheur.DecimalValue

            oHelp.NbBuses_m2 = m_calculs_m2_nbBuses.DecimalValue
            oHelp.Pression_m2 = m_calculs_m2_pression.DecimalValue
            oHelp.DebitEtalon_m2 = m_etalon_m2_debitEtalon.DecimalValue
            oHelp.DebitAfficheur_m2 = m_etalon_m2_debitAfficheur.DecimalValue

            oHelp.NbBuses_m3 = m_calculs_m3_nbBuses.DecimalValue
            oHelp.Pression_m3 = m_calculs_m3_pression.DecimalValue
            oHelp.DebitEtalon_m3 = m_etalon_m3_debitEtalon.DecimalValue
            oHelp.DebitAfficheur_m3 = m_etalon_m3_debitAfficheur.DecimalValue

            oHelp.calc()

            AfficheResultat(oHelp)


        Else

            m_result.Text = ""

        End If

    End Sub

    Private Sub AfficheResultat(pHelp As DiagnosticHelp552)
        'Affichage des ecarts
        m_m1_ecart.Text = pHelp.EcartPct_m1
        m_m2_ecart.Text = pHelp.EcartPct_m2
        m_m3_ecart.Text = pHelp.EcartPct_m3
        M_erreurDebimetre.Text = pHelp.ErreurDebitMetre

        ' Résultat
        m_result.Text = pHelp.Resultat
        If pHelp.Resultat = "IMPRECISION" Then
            m_result.ForeColor = System.Drawing.Color.Red
        Else
            ' OK
            m_result.ForeColor = System.Drawing.Color.FromArgb(CType(0, Byte), CType(192, Byte), CType(0, Byte))
        End If

    End Sub
    Private Sub Popuphelp552_init(pHelp As DiagnosticHelp552)

        Try

            m_bDuringLoad552 = True
            'Récupération des infos de help552
            m_calculs_m1_nbBuses.Text = ""
            m_calculs_m1_pression.Text = ""
            m_etalon_m1_debitEtalon.Text = ""
            m_etalon_m1_debitAfficheur.Text = ""
            m_calculs_m2_nbBuses.Text = ""
            m_calculs_m2_pression.Text = ""
            m_etalon_m2_debitEtalon.Text = ""
            m_etalon_m2_debitAfficheur.Text = ""
            m_calculs_m3_nbBuses.Text = ""
            m_calculs_m3_pression.Text = ""
            m_etalon_m3_debitEtalon.Text = ""
            m_etalon_m3_debitAfficheur.Text = ""

            If pHelp.hasValue() Then
                m_calculs_m1_nbBuses.Text = pHelp.NbBuses_m1
                m_calculs_m1_pression.Text = pHelp.Pression_m1
                m_etalon_m1_debitEtalon.Text = pHelp.DebitEtalon_m1
                m_etalon_m1_debitAfficheur.Text = pHelp.DebitAfficheur_m1

                m_calculs_m2_nbBuses.Text = pHelp.NbBuses_m2
                m_calculs_m2_pression.Text = pHelp.Pression_m2
                m_etalon_m2_debitEtalon.Text = pHelp.DebitEtalon_m2
                m_etalon_m2_debitAfficheur.Text = pHelp.DebitAfficheur_m2

                m_calculs_m3_nbBuses.Text = pHelp.NbBuses_m3
                m_calculs_m3_pression.Text = pHelp.Pression_m3
                m_etalon_m3_debitEtalon.Text = pHelp.DebitEtalon_m3
                m_etalon_m3_debitAfficheur.Text = pHelp.DebitAfficheur_m3

                m_calculs_m3_nbBuses.Text = pHelp.NbBuses_m3
                m_calculs_m3_pression.Text = pHelp.Pression_m3
                m_etalon_m3_debitEtalon.Text = pHelp.DebitEtalon_m3
                m_etalon_m3_debitAfficheur.Text = pHelp.DebitAfficheur_m3

                'Affichage des ecarts
                m_m1_ecart.Text = pHelp.EcartPct_m1
                m_m2_ecart.Text = pHelp.EcartPct_m2
                m_m3_ecart.Text = pHelp.EcartPct_m3
                M_erreurDebimetre.Text = pHelp.ErreurDebitMetre
            End If
            'Calcul des ecarts et de l'erreur DebitMetre
            If m_bVisu Then
                m_calculs_m1_nbBuses.Enabled = False
                m_calculs_m1_pression.Enabled = False
                m_etalon_m1_debitEtalon.Enabled = False
                m_etalon_m1_debitAfficheur.Enabled = False
                m_calculs_m2_nbBuses.Enabled = False
                m_calculs_m2_pression.Enabled = False
                m_etalon_m2_debitEtalon.Enabled = False
                m_etalon_m2_debitAfficheur.Enabled = False
                m_calculs_m3_nbBuses.Enabled = False
                m_calculs_m3_pression.Enabled = False
                m_etalon_m3_debitEtalon.Enabled = False
                m_etalon_m3_debitAfficheur.Enabled = False
                btnValider.Enabled = False
            Else
                AfficheResultat(pHelp)
            End If

            Select Case m_Mode
                Case Help552Mode.Mode552
                    lblCodeDefaut.Text = "5.5.2.2"
                Case Help552Mode.Mode5622
                    lblCodeDefaut.Text = "5.6.2.2"
                Case Else

            End Select

            m_bDuringLoad552 = False
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_dlghelp552.PopupHelp552_init ERR : " & ex.Message)

        End Try


    End Sub

    '    Public Function getResult() As String
    '       Return help552_result.Text
    '  End Function
    Public Function getHelp552() As DiagnosticHelp552
        Return m_oHelp
    End Function
    '                m_oDiag.syntheseErreurDebitmetre = oHelp.ErreurDebitMetre

    Private Sub OK_Button_Click_1(sender As Object, e As EventArgs) Handles btnValider.Click
        Valider()
    End Sub

    Private Sub Cancel_Button_Click_1(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Annuler()
    End Sub

    Protected Overridable Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Select Case m_Mode
                Case Help552Mode.Mode552
                    m_oDiag.diagnosticHelp552 = m_oHelp
                Case Help552Mode.Mode5622
                    m_oDiag.diagnosticHelp5622 = m_oHelp
            End Select
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_dlghelp552.Valider Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overridable Sub Annuler() Implements IfrmCRODIP.Annuler
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Diagnostic_dlgm_Load(sender As Object, e As EventArgs) Handles Me.Load
        formload()
    End Sub

    Protected Overridable Sub formload() Implements IfrmCRODIP.formLoad

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs)
        If TabControl1.SelectedTab.Name = tpHelp552.Name Then
            SetControls(Help552Mode.Mode552)
            Popuphelp552_init(m_oHelp)
        End If
        If TabControl1.SelectedTab.Name = tpHelp5622.Name Then
            SetControls(Help552Mode.Mode5622)
            Popuphelp552_init(m_oHelpbis)
        End If
    End Sub

    Private Sub SetControls(pMode As Help552Mode)
        Select Case pMode
            Case Help552Mode.Mode552
                m_calculs_m1_nbBuses = help552_calculs_m1_nbBuses
                m_calculs_m1_pression = help552_calculs_m1_pression
                m_etalon_m1_debitEtalon = help552_etalon_m1_debitEtalon
                m_etalon_m1_debitAfficheur = help552_etalon_m1_debitAfficheur
                m_m1_ecart = help552_m1_ecart

                m_calculs_m2_nbBuses = help552_calculs_m2_nbBuses
                m_calculs_m2_pression = help552_calculs_m2_pression
                m_etalon_m2_debitEtalon = help552_etalon_m2_debitEtalon
                m_etalon_m2_debitAfficheur = help552_etalon_m2_debitAfficheur
                m_m2_ecart = help552_m2_ecart

                m_calculs_m3_nbBuses = help552_calculs_m3_nbBuses
                m_calculs_m3_pression = help552_calculs_m3_pression
                m_etalon_m3_debitEtalon = help552_etalon_m3_debitEtalon
                m_etalon_m3_debitAfficheur = help552_etalon_m3_debitAfficheur
                m_m3_ecart = help552_m3_ecart

                M_erreurDebimetre = help552_erreurDebimetre
                m_result = help552_result
            Case Help552Mode.Mode5622
                m_calculs_m1_nbBuses = help5622_calculs_m1_nbBuses
                m_calculs_m1_pression = help5622_calculs_m1_pression
                m_etalon_m1_debitEtalon = help5622_etalon_m1_debitEtalon
                m_etalon_m1_debitAfficheur = help5622_etalon_m1_debitAfficheur
                m_m1_ecart = help5622_m1_ecart

                m_calculs_m2_nbBuses = help5622_calculs_m2_nbBuses
                m_calculs_m2_pression = help5622_calculs_m2_pression
                m_etalon_m2_debitEtalon = help5622_etalon_m2_debitEtalon
                m_etalon_m2_debitAfficheur = help5622_etalon_m2_debitAfficheur
                m_m2_ecart = help5622_m2_ecart

                m_calculs_m3_nbBuses = help5622_calculs_m3_nbBuses
                m_calculs_m3_pression = help5622_calculs_m3_pression
                m_etalon_m3_debitEtalon = help5622_etalon_m3_debitEtalon
                m_etalon_m3_debitAfficheur = help5622_etalon_m3_debitAfficheur
                m_m3_ecart = help5622_m3_ecart

                M_erreurDebimetre = help5622_erreurDebimetre
                m_result = help5622_result

        End Select


    End Sub

    Private Sub TableLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles TableLayoutPanel1.Paint

    End Sub
End Class
