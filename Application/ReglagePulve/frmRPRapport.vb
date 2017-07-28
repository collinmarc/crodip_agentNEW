Public Class frmRPRapport
    Implements IfrmCRODIP
    Protected m_oDiag As RPDiagnostic
    Protected m_EtatReglagePulve As EtatReglagePulve

    Public Overridable Sub setContexte(pDiag As RPDiagnostic)
        m_oDiag = pDiag
    End Sub

    Private Sub RPRapport_Load(sender As Object, e As EventArgs) Handles Me.Load
        formload()
    End Sub

    Protected Overridable Sub formload() Implements IfrmCRODIP.formLoad
        MinimizeBox = False
        MaximizeBox = False

        m_bsRPDiagnostic.Add(m_oDiag)
        lbSections.SetItemChecked(0, m_oDiag.bSectionSyntheseCapteurVitesse)
        lbSections.SetItemChecked(2, m_oDiag.bSectionSyntheseCapteurDebit)
        lbSections.SetItemChecked(4, m_oDiag.bSectionSyntheseBuses)
        '        lbSections.SetItemChecked(4, m_rpdiag.bSectionSyntheseMesures)
        lbSections.SetItemChecked(5, m_oDiag.bSectionSynthese833)
        lbSections.SetItemChecked(6, m_oDiag.bSectionSynthese542)
        lbSections.SetItemChecked(7, m_oDiag.bSectionDefauts)
        '        m_rpdiag.bSectionEntete = True


        tbReferences.Text = "LG0" & vbCrLf & "LG1"
        m_EtatReglagePulve = New EtatReglagePulve(m_oDiag)
    End Sub

    Public Sub Annuler() Implements IfrmCRODIP.Annuler

    End Sub

    Protected Overridable Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("RPRapport.Valider Err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        GenereRapport()
    End Sub

    Private Sub btnChoisirImg_Click(sender As Object, e As EventArgs) Handles btnChoisirImg.Click
        Dim oResulat As DialogResult
        oResulat = m_dlgImage.ShowDialog()
        If oResulat = Windows.Forms.DialogResult.OK Then
            m_oDiag.imagePath = m_dlgImage.FileName
            m_bsRPDiagnostic.ResetBindings(False)
        End If
    End Sub

    Private Sub GenereRapport()
        m_oDiag.bSectionSyntheseCapteurVitesse = lbSections.GetItemChecked(0)
        m_oDiag.bSectionSyntheseCapteurDebit = lbSections.GetItemChecked(2)
        m_oDiag.bSectionSyntheseBuses = lbSections.GetItemChecked(4)
        m_oDiag.bSectionSyntheseMesures = lbSections.GetItemChecked(4)
        m_oDiag.bSectionSynthese833 = lbSections.GetItemChecked(5)
        m_oDiag.bSectionSynthese542 = lbSections.GetItemChecked(6)
        m_oDiag.bSectionDefauts = lbSections.GetItemChecked(7)
        m_oDiag.bSectionCommentaires = lbSections.GetItemChecked(8)
        m_oDiag.bSectionCalculs = lbSections.GetItemChecked(9)
        m_oDiag.bSectionEntete = True

        If (m_EtatReglagePulve.GenereEtat()) Then
            m_EtatReglagePulve.Open()
        End If

        CSDebug.dispInfo(tbReferences.Text)
        m_oDiag.saveParam()
    End Sub

    Private Sub tbChoisirPath_Click(sender As Object, e As EventArgs) Handles tbChoisirPath.Click
        Dim oResulat As DialogResult
        oResulat = m_FolderBrowserDialog.ShowDialog()
        If oResulat = Windows.Forms.DialogResult.OK Then
            m_oDiag.FilePath = m_FolderBrowserDialog.SelectedPath
            tbPath.Text = m_FolderBrowserDialog.SelectedPath
        End If

    End Sub
End Class