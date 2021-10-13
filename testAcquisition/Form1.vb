Imports CRODIPAcquisition
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Module D'acquisition
        Dim oModuleAcquisition As CRODIPAcquisition.ModuleAcq = Nothing
        If rbMD2.Checked Then
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule("MD2")
        End If
        If rbITEQ.Checked Then
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule("ITEQ")
        End If
        If rbAAMS.Checked Then
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule("AAMS")

        End If
        If rbERECA.Checked Then
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule("ERECA")

        End If
        If rbIteq2.Checked Then
            oModuleAcquisition = CRODIPAcquisition.ModuleAcq.GetModule("ITEQ2")

        End If
        If (oModuleAcquisition Is Nothing) Then
            MessageBox.Show("Impossible de charger le Module d'acquisition")
            Exit Sub
        End If
        Dim pModule As CRODIPAcquisition.ICRODIPAcquisition = oModuleAcquisition.Instance
        If Not pModule.getGestionDesNiveaux Then
            pModule.setNbBusesParNiveau(tbNbreBuseParNiveauAAMS.Text)
        End If
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

    Private Sub rbAAMS_CheckedChanged(sender As Object, e As EventArgs) Handles rbAAMS.CheckedChanged
        FlowPanelAAMS.Visible = rbAAMS.Checked
    End Sub

    Private Sub rbIteq2_CheckedChanged(sender As Object, e As EventArgs) Handles rbIteq2.CheckedChanged
        FlowPanelAAMS.Visible = rbIteq2.Checked

    End Sub
End Class
