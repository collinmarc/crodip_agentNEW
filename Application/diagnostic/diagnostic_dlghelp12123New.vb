﻿Imports System.Windows.Forms
Imports CRODIPWS

Public Class diagnostic_dlghelp12123new
    Implements IfrmCRODIP, IdlgHelp12123
    Private m_DiagHelp12123 As DiagnosticHelp12123
    Private m_bModeVisu As Boolean



    ''' <summary>
    ''' </summary>
    ''' <param name="pMode"></param>
    ''' <param name="pDiag"></param>
    ''' <remarks></remarks>
    ''' 
    Public Sub setContexte(pDiagH12123 As DiagnosticHelp12123, pbModeVisu As Boolean) Implements IdlgHelp12123.setContexte
        m_bModeVisu = pbModeVisu
        If m_bModeVisu Then
            'pnlPrinc.Enabled = False
            btnValider.Enabled = False
        End If

        m_bsrcH12123.Clear()
        m_DiagHelp12123 = pDiagH12123.Clone()
        m_bsrcH12123.Add(m_DiagHelp12123)


    End Sub
    Public Function getContexte() As DiagnosticHelp12123 Implements IdlgHelp12123.getContexte
        Return m_DiagHelp12123
    End Function

    Public Overloads Function ShowDialog() As DialogResult Implements IdlgHelp12123.ShowDialog
        Return MyBase.ShowDialog
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
        Try
            nupNbPompes.Value = m_DiagHelp12123.lstPompes.Count

        Catch ex As Exception

        End Try
        DisplayPompes()
    End Sub

    Private Sub DisplayPompes()
        Dim ImageIndex As Integer = 1
        Dim oOldNode As Integer = -1
        If TreeView1.SelectedNode IsNot Nothing Then
            oOldNode = TreeView1.SelectedNode.Index
        End If

        TreeView1.Nodes.Clear()

        For Each oPompe As DiagnosticHelp12123Pompe In m_DiagHelp12123.lstPompes
            Select Case oPompe.Resultat
                Case ""
                    ImageIndex = 2
                Case DiagnosticItem.EtatDiagItemOK
                    ImageIndex = 1
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    ImageIndex = 0
            End Select
            Dim oNode As TreeNode
            oNode = TreeView1.Nodes.Add(oPompe.Nom, ImageIndex)
            oNode.Text = oPompe.Nom
            oNode.SelectedImageIndex = ImageIndex
            oNode.ImageIndex = ImageIndex
        Next
        Try

            If oOldNode <> -1 Then
                TreeView1.SelectedNode = TreeView1.Nodes(oOldNode)
            Else
                TreeView1.SelectedNode = TreeView1.Nodes(0)
                'Mise en surbrillance du noeud par defaut
                TreeView1.SelectedNode.BackColor = SystemColors.Highlight
                TreeView1.SelectedNode.ForeColor = SystemColors.HighlightText
                PreviousSelectedNode = TreeView1.SelectedNode

            End If
            m_bsrcPompes.Position = TreeView1.SelectedNode.Index
        Catch ex As Exception
            TreeView1.SelectedNode = TreeView1.Nodes(0)
            'Mise en surbrillance du noeud par defaut
            TreeView1.SelectedNode.BackColor = SystemColors.Highlight
            TreeView1.SelectedNode.ForeColor = SystemColors.HighlightText
            PreviousSelectedNode = TreeView1.SelectedNode
            m_bsrcPompes.Position = 0
        End Try
    End Sub


    Private Sub BindingSource1_CurrentItemChanged(sender As Object, e As EventArgs) Handles m_bsrcH12123.CurrentItemChanged
    End Sub

    Private Sub TbNumeric11_Validated(sender As Object, e As EventArgs)
        m_bsrcH12123.ResetBindings(False)
    End Sub

    Private Sub TbNumeric3_Validated(sender As Object, e As EventArgs)
        m_bsrcH12123.ResetBindings(False)
    End Sub
    Private Sub btnvaliderNbPompes_Click(sender As Object, e As EventArgs) Handles btnvaliderNbPompes.Click
        If nupNbPompes.Value > m_DiagHelp12123.lstPompes.Count Then
            While m_DiagHelp12123.lstPompes.Count < nupNbPompes.Value
                m_DiagHelp12123.AjoutePompe()
            End While
        End If
        If nupNbPompes.Value < m_DiagHelp12123.lstPompes.Count Then
            While m_DiagHelp12123.lstPompes.Count > nupNbPompes.Value
                m_DiagHelp12123.lstPompes.RemoveAt(m_DiagHelp12123.lstPompes.Count - 1)
            End While
        End If
        m_DiagHelp12123.calcule()
        DisplayPompes()
        Refresh()
    End Sub


    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        Dim oNode As TreeNode
        oNode = e.Node
        If oNode IsNot Nothing Then
            m_bsrcPompes.Position = oNode.Index
        End If
    End Sub


    Private Sub m_bsrcPompes_CurrentChanged(sender As Object, e As EventArgs) Handles m_bsrcPompes.CurrentChanged
        Dim oPompe As DiagnosticHelp12123Pompe
        oPompe = m_bsrcPompes.Current
        'If oPompe.Resultat = DiagnosticItem.EtatDiagItemOK Then
        '    laResultat.ForeColor = System.Drawing.Color.OliveDrab
        'Else
        '    laResultat.ForeColor = System.Drawing.Color.Red
        'End If

        nupMesures.Value = oPompe.lstMesures.Count
        If m_bsrcPompes.Position + 1 >= m_bsrcPompes.Count Then
            btn_PompeSuivante.Enabled = False
        Else
            btn_PompeSuivante.Enabled = True
        End If
    End Sub

    Private Sub btnValiderNbMesures_Click(sender As Object, e As EventArgs) Handles btnValiderNbMesures.Click
        Dim oPompe As DiagnosticHelp12123Pompe
        oPompe = m_bsrcPompes.Current

        If nupMesures.Value > oPompe.lstMesures.Count Then
            While oPompe.lstMesures.Count < nupMesures.Value
                oPompe.AjouteMesure()
            End While
        End If
        If nupMesures.Value < oPompe.lstMesures.Count Then
            While oPompe.lstMesures.Count > nupMesures.Value
                oPompe.lstMesures.RemoveAt(oPompe.lstMesures.Count - 1)
            End While
        End If
        m_bsrcMesures.ResetBindings(False)
    End Sub

    Private Sub TbNumeric2_Validated(sender As Object, e As EventArgs) Handles TbNumeric2.Validated
        m_bsrcMesures.ResetBindings(False)
    End Sub

    Private Sub TbNumeric1_Validated(sender As Object, e As EventArgs) Handles TbNumeric1.Validated
        m_bsrcMesures.ResetBindings(False)
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        If TypeOf (e.Exception) Is FormatException Then

            Dim strValue As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue
            strValue = strValue.Replace(".", ",")
            If IsNumeric(strValue) Then
                DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = strValue
                '            e.Cancel = True
            End If
        End If

    End Sub

    Private Sub m_bsrcMesures_CurrentItemChanged(sender As Object, e As EventArgs) Handles m_bsrcMesures.CurrentItemChanged

        RefreshGrid()
    End Sub

    Private Sub RefreshGrid()
        Try

            Dim oPompe As DiagnosticHelp12123Pompe
            oPompe = m_bsrcPompes.Current
            If oPompe IsNot Nothing Then
                If oPompe.Resultat = DiagnosticItem.EtatDiagItemOK Then
                    laResultat.ForeColor = System.Drawing.Color.OliveDrab
                Else
                    laResultat.ForeColor = System.Drawing.Color.Red
                End If
                laEcartMoyen.ForeColor = laResultat.ForeColor
                tbEcartMoyen.BackColor = laResultat.ForeColor
                laResultat.Text = oPompe.LabelResultat
                pctResultat.Image = getImage(oPompe.Resultat)
                If oPompe.EcartReglageMoyen.HasValue Then
                    tbEcartMoyen.Text = oPompe.EcartReglageMoyen.Value
                Else
                    tbEcartMoyen.Text = ""
                End If

                Dim ImageIndex As Integer
                Select Case oPompe.Resultat
                    Case ""
                        ImageIndex = 2
                    Case DiagnosticItem.EtatDiagItemOK
                        ImageIndex = 1
                    Case DiagnosticItem.EtatDiagItemMAJEUR
                        ImageIndex = 0
                End Select
                'Récupération du noeud correspondant à la pompe (on ne peut pas faire confiance au selectedNode)
                Dim oNode As TreeNode
                For Each oNode In TreeView1.Nodes
                    If oNode.Text = oPompe.Nom Then
                        oNode.ImageIndex = ImageIndex
                        oNode.SelectedImageIndex = ImageIndex
                    End If
                Next
                Dim oh12123 As DiagnosticHelp12123
                oh12123 = m_bsrcH12123.Current
                If oh12123 IsNot Nothing Then
                    If oh12123.Resultat = DiagnosticItem.EtatDiagItemOK Then
                        laResultatGlobal.ForeColor = System.Drawing.Color.OliveDrab
                    Else
                        laResultatGlobal.ForeColor = System.Drawing.Color.Red
                    End If
                    laResultatGlobal.Text = oh12123.LabelResultat
                    If oh12123.Resultat = "" Then
                        btnValider.Enabled = False
                    Else
                        btnValider.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            CSDebug.dispError("dlgHelp12123.Refresh ERR " & ex.Message)
        End Try

    End Sub
    Private Function getImage(pResultat As String) As Bitmap
        If pResultat = DiagnosticItem.EtatDiagItemOK Then
            Return Resources.PuceVerteT
        Else
            If pResultat = DiagnosticItem.EtatDiagItemMAJEUR Then
                Return Resources.PuceRougeT
            Else
                Return Resources.PuceGriseT
            End If
        End If
    End Function

    Private PreviousSelectedNode As TreeNode = Nothing
    Private Sub TreeView1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TreeView1.Validating
        TreeView1.SelectedNode.BackColor = SystemColors.Highlight
        TreeView1.SelectedNode.ForeColor = Color.White
        PreviousSelectedNode = TreeView1.SelectedNode
    End Sub
    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        If PreviousSelectedNode IsNot Nothing Then
            PreviousSelectedNode.BackColor = TreeView1.BackColor
            PreviousSelectedNode.ForeColor = TreeView1.ForeColor
        End If
    End Sub

    Private Sub btn_PompeSuivante_Click(sender As Object, e As EventArgs) Handles btn_PompeSuivante.Click
        TreeView1.SelectedNode = TreeView1.SelectedNode.NextNode
        TreeView1_Validating(TreeView1, New System.ComponentModel.CancelEventArgs())
        m_bsrcPompes.MoveNext()
    End Sub
End Class
