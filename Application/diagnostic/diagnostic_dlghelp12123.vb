Imports System.Windows.Forms

Public Class diagnostic_dlghelp12123
    Implements IfrmCRODIP
    Private m_DiagHelp12123 As DiagnosticHelp12123
    Private m_bModeVisu As Boolean

    ''' <summary>
    ''' </summary>
    ''' <param name="pMode"></param>
    ''' <param name="pDiag"></param>
    ''' <remarks></remarks>
    ''' 
    Public Sub setContexte(pDiagH12123 As DiagnosticHelp12123, pbModeVisu As Boolean)
        m_bModeVisu = pbModeVisu
        If m_bModeVisu Then
            pnlPrinc.Enabled = False
            btnValider.Enabled = False
        End If
        BindingSource1.Clear()
        m_DiagHelp12123 = pDiagH12123.Clone()
        m_DiagHelp12123.calcule()
        BindingSource1.Add(m_DiagHelp12123)


    End Sub
    Public Function getContexte() As DiagnosticHelp12123
        Return m_DiagHelp12123
    End Function

    Private Sub btnValider_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValider.Click
        Valider()
    End Sub
    Protected Overridable Function Valider() As Boolean Implements IfrmCRODIP.Valider
    End Function

    Private Sub btnAnnuler_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnuler.Click
        Annuler()
    End Sub
    Protected Overridable Sub Annuler() Implements IfrmCRODIP.Annuler
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub
    Private Sub diagnostic_dlghelp551_Load(sender As Object, e As EventArgs) Handles Me.Load
        formload()
    End Sub
    Protected Overridable Sub formload() Implements IfrmCRODIP.formLoad
    End Sub



    Private Sub BindingSource1_CurrentItemChanged(sender As Object, e As EventArgs) Handles BindingSource1.CurrentItemChanged
        If Not String.IsNullOrEmpty(m_DiagHelp12123.Resultat) Then
            Select Case m_DiagHelp12123.Resultat
                Case DiagnosticItem.EtatDiagItemOK
                    laResult.Text = "OK"
                    laResult.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLOROK
                Case DiagnosticItem.EtatDiagItemMINEUR
                    laResult.Text = "FAIBLE"
                    laResult.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLORMINEUR
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    laResult.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLORMAJEUR
                    laResult.Text = "MAJEURE"
            End Select
        End If
    End Sub

    Private Sub TbNumeric11_Validated(sender As Object, e As EventArgs)
        BindingSource1.ResetBindings(False)
    End Sub

    Private Sub TbNumeric3_Validated(sender As Object, e As EventArgs)
        BindingSource1.ResetBindings(False)

    End Sub


End Class
