Imports System.Windows.Forms
Imports System.Collections.Generic

Public Class dlgAquisition

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim oModuleAcq As CRODIPAcquisition.ModuleAcq
        oModuleAcq = CRODIPAcquisition.ModuleAcq.GetModule("MD2")
        Dim oLst As New List(Of CRODIPAcquisition.AcquisitionValue)
        For Each oVal As CRODIPAcquisition.AcquisitionValue In BindingSource1
            oLst.Add(oVal)
        Next
        oModuleAcq.Instance.FTO_SaveData(oLst)
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub dlgAquisition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Chargement du contenu de la base
        Dim oModuleAcq As CRODIPAcquisition.ModuleAcq
        oModuleAcq = CRODIPAcquisition.ModuleAcq.GetModule("MD2")
        Dim lst As List(Of CRODIPAcquisition.AcquisitionValue)
        lst = oModuleAcq.getValues()
        For Each oValue As CRODIPAcquisition.AcquisitionValue In lst
            BindingSource1.Add(oValue)
        Next
    End Sub
End Class
