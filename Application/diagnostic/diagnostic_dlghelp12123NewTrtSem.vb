Imports System.Windows.Forms

Public Class diagnostic_dlghelp12123newTrtSem
    Implements IfrmCRODIP, IdlgHelp12123
    '    Private m_DiagHelp12123 As DiagnosticHelp12123
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
        nupNbPompes.Minimum = 1
        nupNbPompes.Maximum = 10
        nupMesures.Minimum = 2
        nupMesures.Maximum = 10
        m_bsrcH12123.Clear()
        Dim oH12123 As DiagnosticHelp12123
        oH12123 = pDiagH12123.Clone()
        nupMesures.Value = oH12123.lstPompesTrtSem(0).lstMesures.Count
        m_bsrcH12123.Add(oH12123)


    End Sub
    Public Function getContexte() As DiagnosticHelp12123 Implements IdlgHelp12123.getContexte
        Dim oH12123 As DiagnosticHelp12123
        oH12123 = m_bsrcH12123.Current
        Return oH12123
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

        nupNbPompes.Value = getContexte().lstPompesTrtSem.Count
        DisplayPompes()
    End Sub

    Private Sub DisplayPompes()
        Dim ImageIndex As Integer = 1
        Dim oOldNode As Integer = -1
        If TreeView1.SelectedNode IsNot Nothing Then
            oOldNode = TreeView1.SelectedNode.Index
        End If

        TreeView1.Nodes.Clear()

        For Each oPompe As DiagnosticHelp12123PompeTrtSem In getContexte().lstPompesTrtSem
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
        If nupNbPompes.Value > getContexte().lstPompesTrtSem.Count Then
            While getContexte().lstPompesTrtSem.Count < nupNbPompes.Value
                getContexte().AjoutePompeTrtSem()
            End While
            calcbtnPompes()
        End If
        If nupNbPompes.Value < getContexte().lstPompesTrtSem.Count Then
            While getContexte().lstPompesTrtSem.Count > nupNbPompes.Value
                getContexte().lstPompesTrtSem.RemoveAt(getContexte().lstPompesTrtSem.Count - 1)
            End While
        End If
        getContexte().calcule()
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
        calcbtnPompes()

    End Sub
    Private Sub calcbtnPompes()
        Dim oPompe As DiagnosticHelp12123PompeTrtSem
        oPompe = m_bsrcPompes.Current
        If oPompe IsNot Nothing Then
            nupMesures.Value = oPompe.lstMesures.Count
            If m_bsrcPompes.Position + 1 >= m_bsrcPompes.Count Then
                btn_PompeSuivante.Enabled = False
            Else
                btn_PompeSuivante.Enabled = True
            End If
            If m_bsrcPompes.Position = 0 Then
                btnSupprimer.Enabled = False
            Else
                btnSupprimer.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnValiderNbMesures_Click(sender As Object, e As EventArgs) Handles btnValiderNbMesures.Click
        Dim oPompe As DiagnosticHelp12123PompeTrtSem
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

    Private Sub TbNumeric2_Validated(sender As Object, e As EventArgs)
        m_bsrcMesures.ResetBindings(False)
    End Sub

    Private Sub TbNumeric1_Validated(sender As Object, e As EventArgs)
        m_bsrcMesures.ResetBindings(False)
    End Sub

    Private Sub DataGridView1_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        If TypeOf (e.Exception) Is FormatException Then

            Dim strValue As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).EditedFormattedValue
            strValue = strValue.replace(".", ",")
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

            Dim oPompe As DiagnosticHelp12123PompeTrtSem
            oPompe = m_bsrcPompes.Current
            If oPompe IsNot Nothing Then
                Select Case oPompe.Resultat
                    Case DiagnosticItem.EtatDiagItemOK
                        laResultat.ForeColor = System.Drawing.Color.OliveDrab
                    Case DiagnosticItem.EtatDiagItemMAJEUR
                        laResultat.ForeColor = System.Drawing.Color.Red
                    Case Else
                        laResultat.ForeColor = Color.Gray

                End Select

                laEcartMoyen.ForeColor = laResultat.ForeColor
                tbEcartMoyen.BackColor = laResultat.ForeColor
                laPesseMoyenne.ForeColor = laResultat.ForeColor
                tbPeseeMoyenne.BackColor = laResultat.ForeColor
                laResultat.Text = oPompe.LabelResultat
                pctResultat.Image = oPompe.Image
                If oPompe.EcartReglageMoyen.HasValue Then
                    tbEcartMoyen.Text = oPompe.EcartReglageMoyen.Value
                Else
                    tbEcartMoyen.Text = ""
                End If
                If oPompe.PeseeMoyenne.HasValue Then
                    tbPeseeMoyenne.Text = oPompe.PeseeMoyenne.Value
                Else
                    tbPeseeMoyenne.Text = ""
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
                    Select Case oh12123.Resultat
                        Case DiagnosticItem.EtatDiagItemOK
                            laResultatGlobal.ForeColor = System.Drawing.Color.OliveDrab
                        Case DiagnosticItem.EtatDiagItemMAJEUR

                            laResultatGlobal.ForeColor = System.Drawing.Color.Red
                        Case Else
                            laResultat.ForeColor = Color.Gray
                    End Select

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



    Private Sub rbFonctionnementCuillère_CheckedChanged(sender As Object, e As EventArgs) Handles rbFonctionnementCuillère.CheckedChanged
        If rbFonctionnementCuillère.Checked Then
            Dim oH12123 As DiagnosticHelp12123
            oH12123 = m_bsrcH12123.Current
            oH12123.fonctionnementBuses = "CUILLERE"
            m_bsrcH12123.ResetCurrentItem()
            DisplayPompes()
            btn_PompeSuivante.Text = "  Mécanisme suivant"
        End If
    End Sub

    Private Sub rbFonctinonementInjection_CheckedChanged(sender As Object, e As EventArgs) Handles rbFonctinonementInjection.CheckedChanged
        If rbFonctinonementInjection.Checked Then
            Dim oH12123 As DiagnosticHelp12123
            oH12123 = m_bsrcH12123.Current
            oH12123.fonctionnementBuses = "INJECTION"
            m_bsrcH12123.ResetCurrentItem()
            'Le treevieuw ne se met pas à jour automatiquement...
            DisplayPompes()
            btn_PompeSuivante.Text = "  Pompe suivante"
        End If

    End Sub

    Private Sub btnSupprimer_Click(sender As Object, e As EventArgs) Handles btnSupprimer.Click
        m_bsrcPompes.RemoveCurrent()
        Dim oH12123 As DiagnosticHelp12123
        oH12123 = m_bsrcH12123.Current
        oH12123.calcule()
        DisplayPompes()
        If oH12123.Resultat = "" Then
            btnValider.Enabled = False
        Else
            btnValider.Enabled = True
        End If

    End Sub

End Class
