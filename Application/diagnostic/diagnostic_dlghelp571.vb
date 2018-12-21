Imports System.Windows.Forms

Public Class diagnostic_dlghelp571
    Implements IfrmCRODIP
    Public m_Mode As Calc571Mode
    Private m_bVisu As Boolean

    Public Enum Calc571Mode
        ModePRS = 1
        ModeDEB = 2

    End Enum


    Private m_DiagHelp571 As DiagnosticHelp571
    ''' <summary>
    ''' Etablit le contexte d'execution
    ''' le mode d'utilisaation 551 ou 5621
    ''' le diagnostic support
    ''' </summary>
    ''' <param name="pMode"></param>
    ''' <param name="pDiag"></param>
    ''' <remarks></remarks>
    Public Sub setContexte(p_Mode As Calc571Mode, pDiagH571 As DiagnosticHelp571, pbVisu As Boolean)
        m_Mode = p_Mode
        m_bVisu = pbVisu
        BindingSource1.Clear()
        m_DiagHelp571 = pDiagH571.Clone()
        BindingSource1.Add(m_DiagHelp571)
        If pbVisu Then
            pnl_Pression.Enabled = False
            pnl_Debit.Enabled = False
            btnValider.Enabled = False
        End If
        lblCodeDefaut.Text = "5.7.1"
    End Sub
    Public Function getContexte() As DiagnosticHelp571
        Return m_DiagHelp571
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
        Select Case m_Mode
            Case Calc571Mode.ModeDEB
                TabControl1.SelectedIndex = 1
            Case Calc571Mode.ModePRS
                TabControl1.SelectedIndex = 0
        End Select
    End Sub



    Private Sub BindingSource1_CurrentItemChanged(sender As Object, e As EventArgs) Handles BindingSource1.CurrentItemChanged
        If Not String.IsNullOrEmpty(m_DiagHelp571.ResultPRS) Then
            Select Case m_DiagHelp571.ResultPRS
                Case DiagnosticItem.EtatDiagItemOK
                    laResultPRS.Text = "OK"
                    laResultPRS.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLOROK
                Case DiagnosticItem.EtatDiagItemMINEUR
                    laResultPRS.Text = "FAIBLE"
                    laResultPRS.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLORMINEUR
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    laResultPRS.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLORMAJEUR
                    laResultPRS.Text = "MAJEURE"
            End Select
        End If
        If Not String.IsNullOrEmpty(m_DiagHelp571.ResultDEB) Then
            Select Case m_DiagHelp571.ResultDEB
                Case DiagnosticItem.EtatDiagItemOK
                    laResultDEB.Text = "OK"
                    laResultDEB.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLOROK
                Case DiagnosticItem.EtatDiagItemMINEUR
                    laResultDEB.Text = "FAIBLE"
                    laResultDEB.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLORMINEUR
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    laResultDEB.ForeColor = CRODIP_ControlLibrary.CtrlDiag2.ITEMCOLORMAJEUR
                    laResultDEB.Text = "MAJEURE"
            End Select
        End If
    End Sub
End Class
