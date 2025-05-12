Imports System.Windows.Forms
Imports CRODIPWS

Public Class dlgDHDebutControle
    Private m_oDiag As Diagnostic

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub
    Public Sub New(pDiag As CRODIPWS.Diagnostic)

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().
        m_oDiag = pDiag
    End Sub
    Private Sub btn_retour_Click(sender As Object, e As EventArgs) Handles btn_retour.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btn_poursuivre_Click(sender As Object, e As EventArgs) Handles btn_poursuivre.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        If m_oDiag IsNot Nothing Then
            m_oDiag.controleDateDebut = dtpDateDebutControle.Value.ToShortDateString() & " " & dtpHeuredebutcontrole.Value.ToShortTimeString()
        End If
        Me.Close()
    End Sub
End Class
