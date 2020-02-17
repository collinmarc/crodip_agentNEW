Imports CRODIPAcquisition
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Module D'acquisition
        Dim oModuleAcquisition As CRODIPAcquisition.ModuleAcq
        If rbMD2.Checked Then
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule("MD2")
        Else
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule("ITEQ")
        End If
        Dim pModule As CRODIPAcquisition.ICRODIPAcquisition = oModuleAcquisition.Instance

        If Not System.IO.File.Exists(pModule.getFichier()) Then
            Dim oDLG As New OpenFileDialog()
            oDLG.Multiselect = False
            If oDLG.ShowDialog() = DialogResult.OK Then
                pModule.setFichier(oDLG.FileName)
            Else
                Exit Sub
            End If
        End If
        Dim olst As List(Of CRODIPAcquisition.AcquisitionValue) = oModuleAcquisition.getValues()

        Dim str As String
        Dim nNivMax As Integer
        nNivMax = oModuleAcquisition.getNbNiveaux()
        str = "Niveaux = " & nNivMax
        str = str & "("
        For n = 1 To nNivMax
            str = str & oModuleAcquisition.getNbBuses(n)
            If n < nNivMax Then
                str = str & " - "
            End If
        Next
        str = str & ")"

        tbNiveaux.Text = str
        AcquisitionValueBindingSource.Clear()
        For Each oValue As AcquisitionValue In olst
            AcquisitionValueBindingSource.Add(oValue)
        Next

    End Sub
End Class
