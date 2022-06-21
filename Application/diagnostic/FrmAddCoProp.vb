Imports System.Collections.Generic
Imports System.Linq

Public Class FrmAddCoProp

    Private m_lstExploit As List(Of Exploitation)
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
        m_lstExploit = ExploitationManager.GetListExploitationByPulverisateurId(m_odiag.pulverisateurId)
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
        frm.setContexte(False, OExploit, m_oAgent)
        If frm.ShowDialog() = DialogResult.OK Then
            m_lstExploit.Add(OExploit)
            m_bsrcExploitant.Add(OExploit)
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
                m_lstExploit.Add(ofrm.oExploit)
                m_bsrcExploitant.Add(ofrm.oExploit)
                m_bsrcExploitant.MoveLast()
            End If
        End If

    End Sub

    Private Sub btnSupprCoProp_Click(sender As Object, e As EventArgs) Handles btnSupprCoProp.Click
        SuppressionCoProp()
    End Sub

    Private Sub SuppressionCoProp()
        Dim m_oExploit As Exploitation
        If m_bsrcExploitant.Current IsNot Nothing Then
            m_oExploit = m_bsrcExploitant.Current
            m_oExploit.isSuppressionCoprop = True
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
                                 ExploitationManager.save(oExploit, m_oAgent)
                                 ExploitationTOPulverisateurManager.save(m_oPulverisateur.id, oExploit.id, oExploit.isSuppressionCoprop, m_oAgent)
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