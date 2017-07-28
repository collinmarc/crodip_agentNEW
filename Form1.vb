Public Class Form1


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CtrlDiag21.Text = "Test"
        CtrlDiag21.Libelle = "Test"
        CtrlDiag21.LibelleLong = "TestLong"
        CtrlDiag21.Code = "9.9.9.9"
        CtrlDiag21.Categorie = CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
        CtrlDiag21.NiveauCause_max = 3
        CtrlDiag21.cause1 = False
        CtrlDiag21.cause2 = False
        CtrlDiag21.cause3 = True

    End Sub
End Class