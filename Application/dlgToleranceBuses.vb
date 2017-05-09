Imports System.Windows.Forms
Imports System.Collections.Generic

Imports System.Xml.Serialization


Public Class dlgToleranceBuses
    Private m_lst As lstToleranceBuse
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        m_lst.Serialize()
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub


    Private Sub dlgToleranceBuses_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        m_lst = New lstToleranceBuse()
        m_lst.DeSerialize()
        m_bsToleranceBuses.DataSource = m_lst
    End Sub
End Class
