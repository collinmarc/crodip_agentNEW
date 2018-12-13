Public Class frmSaisieNumFact
    Private m_agent As Agent
    Public NUMFACT As String
    Public Sub SetContext(pAgent As Agent)
        m_agent = pAgent
    End Sub

    Public Sub New(pAgent As Agent)
        InitializeComponent()
        SetContext(pAgent)

    End Sub

    Private Sub frmSaisieNumFact_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strDernRef As String = DiagnosticFactureManager.getDernReference(m_agent)
        tbDernNumFact.Text = strDernRef
        tbNumFact.Text = "FA" & Format(Date.Now, "yyyy") & m_agent.numeroNational
    End Sub

    Private Sub btn_facturation_suivant_Click(sender As Object, e As EventArgs) Handles btn_facturation_suivant.Click
        If tbDernNumFact.Text = "" Or tbDernNumFact.Text = tbNumFact.Text Then
            MsgBox("Numéro de facture incorrect")
        Else
            NUMFACT = tbNumFact.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
End Class