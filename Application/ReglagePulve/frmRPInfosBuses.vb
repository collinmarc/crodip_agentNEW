Public Class frmRPInfosBuses

    Private m_oDiag As RPDiagnostic
    Public Sub setContexte(pDiag As RPDiagnostic)
        Dim oColDescente As DataGridViewTextBoxColumn
        Dim oColSep As DataGridViewTextBoxColumn

        m_oDiag = pDiag
        m_bsrcDiagnostic.Clear()



        m_bsrcDiagnostic.DataSource = m_oDiag.ListInfosBuses
        m_bsrcDiagnostic.DataMember = ""

        DataGridView1.Columns.Clear()
        Dim StyleSep As DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        StyleSep.BackColor = System.Drawing.Color.FromArgb(2, 129, 198)
        Dim StyleDesc As DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        StyleSep.ForeColor = System.Drawing.Color.FromArgb(2, 129, 198)
        For n As Integer = 1 To m_oDiag.CalcNbreDescentes
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
                oColSep.HeaderCell.Style.BackColor = StyleSep.BackColor
                oColSep.DefaultCellStyle = StyleSep
                oColSep.ReadOnly = True
                oColSep.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
                oColSep.Width = 10
                oColSep.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                DataGridView1.Columns.Add(oColSep)
            End If

        Next
        Me.Height = 166 + m_oDiag.CalcNbreNiveauParDescente * 20
    End Sub

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        If DataGridView1.CurrentRow.Cells(e.ColumnIndex).ReadOnly Then
            SendKeys.Send("{tab}")
        End If
    End Sub

    Private Sub frmRPInfosBuses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        For n As Integer = 1 To m_oDiag.CalcNbreDescentes
            'Dim oCkCell As New DataGridViewCheckBoxCell()
            'oCkCell.FalseValue = ""
            'oCkCell.TrueValue = "OUI"
            'oCkCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'oCkCell.Style.NullValue = False
            DataGridView1.Rows(DataGridView1.Rows.Count - 1).HeaderCell.Value = "Prise d'air"
            Try
                '   DataGridView1.Rows(DataGridView1.Rows.Count - 1).Cells((n - 1) * 2) = oCkCell
            Catch ex As Exception

            End Try

        Next

    End Sub
End Class