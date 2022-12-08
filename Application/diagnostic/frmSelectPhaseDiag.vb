Public Class frmSelectPhaseDiag
    Private ckEsx As String
    Public Property bTrtExploitation() As Boolean
        Get
            Return ckExploitant.Checked
        End Get
        Set(ByVal value As Boolean)
            ckExploitant.Checked = value
        End Set
    End Property

    Public Property bTrtPulve() As Boolean
        Get
            Return ckPulve.Checked
        End Get
        Set(ByVal value As Boolean)
            ckPulve.Checked = value
        End Set
    End Property
    Public Property bTrtContexte() As Boolean
        Get
            Return ckContexte.Checked
        End Get
        Set(ByVal value As Boolean)
            ckContexte.Checked = value
        End Set
    End Property
    Public Property bTrtContrat() As Boolean
        Get
            Return ckContrat.Checked
        End Get
        Set(ByVal value As Boolean)
            ckContrat.Checked = value
        End Set
    End Property
    Public Property bTrtDefauts() As Boolean
        Get
            Return ckDefaut.Checked
        End Get
        Set(ByVal value As Boolean)
            ckDefaut.Checked = value
        End Set
    End Property

    Private Sub btnValider_Click(sender As Object, e As EventArgs) Handles btnValider.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class