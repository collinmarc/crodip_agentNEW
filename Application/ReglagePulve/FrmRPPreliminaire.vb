Public Class FrmRPPreliminaire
    Dim bModeAutonome As Boolean

    Protected _RPDiagnosticCourant As RPDiagnostic
    Public Sub New(pDiag As RPDiagnostic)
        _RPDiagnosticCourant = pDiag
    End Sub
    Private Sub FrmRPPreliminaire_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bModeAutonome = True
        If System.IO.File.Exists("LogicielCrodipAgent.exe") Then
            bModeAutonome = False
        End If
        If bModeAutonome Then
            lblIdDiag.Visible = False
            tbIdDiag.Visible = False
        End If
    End Sub
End Class