Partial Class frmRPDlgHelp552
    Inherits Diagnostic_dlghelp552
    Implements IfrmCRODIP

    Protected m_oDiag As RPDiagnostic
    Protected m_mode As Help552Mode


    Protected Overrides Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            MyBase.Valider()
            m_oDiag.oRPParam.bSectionSyntheseCapteurDebit = True
            If m_oDiag.diagnosticHelp552.hasValue() Then
                m_oDiag.syntheseErreurDebitmetre = m_oDiag.diagnosticHelp552.ErreurDebitMetre
            End If
            createDiagItems()
            m_oDiag.RaiseEventLstDiagItemUpdated()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmRPDlgHelp552.Valider Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overrides Sub Annuler() Implements IfrmCRODIP.Annuler

    End Sub
    Protected Overrides Sub formload() Implements IfrmCRODIP.formLoad
        '06/03/2018 : #110
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable

        Call AjoutLabeltitre()
        btnAnnuler.Visible = False
        btnValider.Visible = False
        MinimizeBox = False
        MaximizeBox = False

    End Sub
    Public Overloads Sub Setcontexte(pMode As Help552Mode, pDiag As RPDiagnostic, debitMoyen As String, PressionMesure As String)
        m_oDiag = pDiag
        m_mode = pMode
        MyBase.setContexte(pMode, pDiag, debitMoyen, PressionMesure, (GlobalsCRODIP.DiagMode.CTRL_VISU = m_mode))
        Me.Text = "Debits"
    End Sub

    Private Sub AjoutLabeltitre()
        'Me.Panel122.Anchor = AnchorStyles.None
        'Me.Panel122.Top = 37
        'Me.Panel122.Width = Me.Width - 27
        'Me.Panel122.Height = Me.Height - 84
        'Me.Panel122.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
        '    Or System.Windows.Forms.AnchorStyles.Left) _
        '    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

        'm_Labeltitre = New Label
        'm_Labeltitre.Text = Me.Text
        'm_Labeltitre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
        '    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        'm_Labeltitre.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'm_Labeltitre.ForeColor = System.Drawing.Color.White
        'm_Labeltitre.Location = New System.Drawing.Point(0, Me.Panel122.Left)
        'm_Labeltitre.AutoSize = True
        'm_Labeltitre.Name = "lbl_titre"
        'm_Labeltitre.Size = New System.Drawing.Size(250, 16)
        'm_Labeltitre.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        'm_Labeltitre.Text = Me.Text

        'Me.Controls.Add(m_Labeltitre)

    End Sub




    ''' <summary>
    ''' Creation des diagItem correspondant pour les 2 modes
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub createDiagItems()
        'En mode reglage pulvé, les 2 mode sont activés
        If m_oDiag.diagnosticHelp552.Resultat = "IMPRECISION" Then
            m_oDiag.AdOrReplaceDiagItem(New DiagnosticItem(m_oDiag.id, "552", "2", "", "P"))
            m_oDiag.RemoveDiagItem(New DiagnosticItem(m_oDiag.id, "552", "3", "", "B"))
        Else
            m_oDiag.RemoveDiagItem(New DiagnosticItem(m_oDiag.id, "552", "2", "", "P"))
            m_oDiag.AdOrReplaceDiagItem(New DiagnosticItem(m_oDiag.id, "552", "3", "", "B"))

        End If
    End Sub

    Private Sub frmRPDlgHelp552_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        System.Diagnostics.Trace.WriteLine("Load")
        help552_debitMoyen0bar.Text = m_oDiag.buseDebit
        help552_pressionMesure.Text = m_oDiag.manometrePressionTravail
        calc_help_552()
    End Sub

    Private Sub frmRPDlgHelp552_Leave(sender As Object, e As EventArgs) Handles MyBase.Leave
        'Valider()
    End Sub

    Private Sub frmRPDlgHelp552_Load(sender As Object, e As EventArgs) Handles Me.Load
        System.Diagnostics.Trace.WriteLine("Load")
        formload()
    End Sub

End Class