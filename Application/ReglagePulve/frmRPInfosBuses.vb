Public Class frmRPInfosBuses

    Private m_oDiag As RPDiagnostic
    Public Sub setContexte(pDiag As RPDiagnostic)
        m_oDiag = pDiag
        m_bsrcDiagnostic.Clear()

        m_bsrcDiagnostic.DataSource = m_oDiag.ListInfosBuses
        m_bsrcDiagnostic.DataMember = ""

        DataGridView1.Columns.Clear()
        Dim StyleSep As DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        StyleSep.BackColor = System.Drawing.Color.Black
        Dim StyleDesc As DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        StyleSep.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
        For n As Integer = 1 To m_oDiag.CalcNbreDescentes
            Dim oColDescente As DataGridViewTextBoxColumn
            Dim oColSep As DataGridViewTextBoxColumn
            oColDescente = New DataGridViewTextBoxColumn()
            oColDescente.HeaderText = n
            oColDescente.DataPropertyName = "Infos" & n
            oColDescente.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            oColDescente.HeaderCell.Style.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(198, Byte), Integer))
            oColDescente.DefaultCellStyle = StyleDesc
            DataGridView1.Columns.Add(oColDescente)

            If n < m_oDiag.CalcNbreDescentes Then
                oColSep = New DataGridViewTextBoxColumn()
                oColSep.HeaderText = ""
                oColSep.DefaultCellStyle = StyleSep
                oColSep.ReadOnly = True
                oColSep.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
                oColSep.Width = 10
                oColSep.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                DataGridView1.Columns.Add(oColSep)
            End If

        Next

    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If DataGridView1.CurrentRow.Cells(e.ColumnIndex).ReadOnly Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub frmRPInfosBuses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For n As Integer = 1 To m_oDiag.CalcNbreDescentes
            Dim oCkCell As New DataGridViewCheckBoxCell()
            oCkCell.FalseValue = "0"
            oCkCell.TrueValue = "1"
            oCkCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            Try
                DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells((n - 1) * 2) = oCkCell
                DataGridView1.Rows(DataGridView1.Rows.Count - 1).HeaderCell.Value = "Prise d'air"
            Catch ex As Exception

            End Try

        Next

    End Sub
End Class