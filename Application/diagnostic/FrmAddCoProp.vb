Imports System.Collections.Generic
Imports System.Linq
Imports CRODIPWS

Public Class FrmAddCoProp

    Private m_lstExploit As List(Of ExploitationTOPulverisateur)
    Private m_oAgent As Agent
    Private m_odiag As Diagnostic
    Private m_oPulverisateur As Pulverisateur

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
    End Sub

    Public Sub Setcontext(pDiag As Diagnostic, pAgent As Agent)
        m_odiag = pDiag
        m_lstExploit = ExploitationTOPulverisateurManager.getListByPulverisateurId(m_odiag.pulverisateurId)
        m_oAgent = pAgent
        m_oPulverisateur = PulverisateurManager.getPulverisateurById(m_odiag.pulverisateurId)

    End Sub

    Private Sub FrmAddCoProp_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_lstExploit.ForEach(Sub(oExploit)
                                 m_bsrcExploitant.Add(oExploit)
                             End Sub)
    End Sub

    Private Sub btnNewExploitant_Click(sender As Object, e As EventArgs) Handles btnNewExploitant.Click
        CreerExploitant()
    End Sub

    Private Sub CreerExploitant()
        Dim frm As New fiche_exploitant()
        Dim OExploit As New Exploitation()
        OExploit.raisonSociale = "Nouveau."
        frm.setContexte(False, OExploit, m_oAgent, Nothing)
        If frm.ShowDialog() = DialogResult.OK Then
            Dim oExploit2Pulve As New ExploitationTOPulverisateur(OExploit, m_oPulverisateur)
            m_lstExploit.Add(oExploit2Pulve)
            m_bsrcExploitant.Add(oExploit2Pulve)
        End If
        frm.Close()
    End Sub

    Private Sub btnAjoutExploitant_Click(sender As Object, e As EventArgs) Handles btnAjoutExploitant.Click
        Dim ofrm As New dlgListExploitant()
        ofrm.SetContexte(m_oAgent)
        If ofrm.ShowDialog() = DialogResult.OK Then

            If m_lstExploit.Where(Function(oExploit)
                                      Return oExploit.id = ofrm.oExploit.id
                                  End Function).Count() = 0 Then
                Dim oExploit2Pulve As New ExploitationTOPulverisateur(ofrm.oExploit, m_oPulverisateur)
                m_lstExploit.Add(oExploit2Pulve)
                m_bsrcExploitant.Add(oExploit2Pulve)
                m_bsrcExploitant.MoveLast()
            End If
        End If

    End Sub

    Private Sub btnSupprCoProp_Click(sender As Object, e As EventArgs) Handles btnSupprCoProp.Click
        SuppressionCoProp()
    End Sub

    Private Sub SuppressionCoProp()
        Dim oExploit2Pulve As ExploitationTOPulverisateur
        If m_bsrcExploitant.Current IsNot Nothing Then
            oExploit2Pulve = m_bsrcExploitant.Current
            oExploit2Pulve.isSupprimeCoProp = True
            If m_dgvCoProp.CurrentRow IsNot Nothing Then
                m_dgvCoProp.Rows.Remove(m_dgvCoProp.CurrentRow)
            End If
        End If
    End Sub
    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        SauvegarderExploitants()
        Me.Close()
    End Sub
    Private Sub SauvegarderExploitants()
        'Sauvegarde des Exploitants
        m_lstExploit.ForEach(Sub(oExploit)
                                 ExploitationTOPulverisateurManager.save(oExploit, m_oAgent, False)
                             End Sub)
    End Sub

    Private Sub btnImprimer_Click(sender As Object, e As EventArgs) Handles btnImprimer.Click
        Dim oEtat As New EtatDocumentCoPropriete(m_odiag)
        m_lstExploit.ForEach(Sub(oExploit)
                                 oEtat.AddCoProprietaire(oExploit.raisonSociale & " / " & oExploit.nomExploitant & " " & oExploit.prenomExploitant)
                             End Sub
            )

        If oEtat.genereEtat() Then
            oEtat.Open()
        End If
        DiagnosticManager.UpdateFileNames(m_odiag)
    End Sub
End Class