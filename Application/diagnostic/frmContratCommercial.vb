Imports System.IO
Imports System.Collections.Generic
Imports CRODIPWS

Public Class frmContratCommercial

    Private m_Diag As Diagnostic
    Private m_Agent As Agent
    Private m_bContexteOK As Boolean
    Public Sub setcontexte(pAgent As Agent, pDiag As Diagnostic)
        m_Diag = pDiag
        m_Agent = pAgent
        m_bsrcDiag.Clear()
        m_bsrcDiag.Add(pDiag)
        m_bsrcAgent.Clear()
        m_bsrcAgent.Add(pAgent)

        ActiveDesactiveBtnSignatures()
    End Sub

    Private Sub frmContratCommercial_Load(sender As Object, e As EventArgs) Handles Me.Load
        Debug.Assert(m_bsrcAgent.Count > 0, "L'agent doit être renseigné")
        Debug.Assert(m_bsrcDiag.Count > 0, "Le diagnostic doit être renseigné")
        AfficheContrat(False)
        ActiveDesactiveBtnSignatures()
    End Sub

    Private Sub ActiveDesactiveBtnSignatures()
        btnSignClient.Enabled = Not m_Diag.isSignCCClient
        btnSignAgent.Enabled = Not m_Diag.isSignCCAgent
        btn_facturation_suivant.Enabled = (m_Diag.isSignCCClient And m_Diag.isSignCCAgent)
    End Sub

    Private Function AfficheContrat(pExportDPF As Boolean) As Boolean
        Dim bReturn As Boolean
        Dim pathRapport As String
        Try
            Dim oEtat As New EtatContratCommercial(m_Diag)
            oEtat.genereEtat(pExportDPF)
            If pExportDPF Then
                pathRapport = oEtat.getFileName()
                m_Diag.CCFileName = pathRapport
                bReturn = File.Exists(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC & pathRapport)
            Else
                CrystalReportViewer1.ReportSource = oEtat.getReportdocument
            End If
        Catch ex As Exception
            CSDebug.dispError("frmContratCommercial.AfficheDocument ERR : " & ex.Message.ToString)
            bReturn = False
        End Try
        Return bReturn
    End Function 'AfficheDocument

    Private Sub btnSignClient_Click(sender As Object, e As EventArgs) Handles btnSignClient.Click
        Signatureclient()
    End Sub
    Public Sub Signatureclient()
        Dim ofrm As frmSignClient
        ofrm = frmSignClient.getfrmSignature(m_Diag, SignMode.CCCLIENT, m_Agent)
        ofrm.ShowDialog()
        AfficheContrat(False)
        ActiveDesactiveBtnSignatures()
    End Sub
    Public Sub SignatureAgent()
        Dim ofrm As frmSignClient
        ofrm = frmSignClient.getfrmSignature(m_Diag, SignMode.CCAGENT, m_Agent)
        ofrm.ShowDialog()
        AfficheContrat(False)
        ActiveDesactiveBtnSignatures()
    End Sub

    Private Sub btnSignAgent_Click(sender As Object, e As EventArgs) Handles btnSignAgent.Click
        SignatureAgent()
    End Sub


    Private Sub btn_Quitter_Click(sender As Object, e As EventArgs) Handles btn_Quitter.Click
        'Annulation de la signature
        m_Diag.isSignCCAgent = False
        m_Diag.isSignCCClient = False
        m_Diag.SignCCAgent = Nothing
        m_Diag.SignCCClient = Nothing
        Me.DialogResult = DialogResult.Cancel

        Me.Close()
    End Sub

    Private Sub btn_facturation_suivant_Click(sender As Object, e As EventArgs) Handles btn_facturation_suivant.Click
        'La Génération des pdfs se fait dans la fenêtre appelante
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub
End Class