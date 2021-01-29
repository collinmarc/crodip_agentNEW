Public Class Form1
    Private Sub CtrlParamNiveau1_CheckedChanged(sender As Object, e As EventArgs) Handles CtrlParamNiveau1.CheckedChanged, CtrlParamNiveau4.CheckedChanged, CtrlParamNiveau3.CheckedChanged, CtrlParamNiveau2.CheckedChanged
        Dim octrl As CRODIP_ControlLibrary.CtrlParamNiveau
        octrl = sender
        Console.WriteLine(octrl.Name & ":" & octrl.Niveau & "," & octrl.Label & "," & octrl.Checked)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CtrlParamNiveau1.bMultiLine = False
        CtrlParamNiveau1.bValidBloc = False
        CtrlParamNiveau1.Niveau = 1
        CtrlParamNiveau1.Label = "2. Etat général"
        CtrlParamNiveau2.bMultiLine = False
        CtrlParamNiveau2.Niveau = 1
        CtrlParamNiveau2.bValidBloc = True
        CtrlParamNiveau2.Label = "2. Dispositif Attelage"

        CtrlParamNiveau3.Label = "3.1 Dispositif Anti-fuites etc ...."
        CtrlParamNiveau3.Niveau = 2
        CtrlParamNiveau3.bValidBloc = False
        CtrlParamNiveau4.Label = "3.1 Dispositif Anti-fuites etc ....BlaBla"
        CtrlParamNiveau4.Niveau = 2
        CtrlParamNiveau4.bValidBloc = True

    End Sub
End Class
