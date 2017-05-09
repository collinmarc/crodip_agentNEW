Class CSListViewItemComparer
    Implements IComparer

    Private col As Integer
    Private ord As System.Windows.Forms.SortOrder
    Private type As String = "String"

    Public Sub New()
        col = 0
        ord = SortOrder.Ascending
    End Sub

    Public Sub New(ByVal column As Integer)
        col = column
        ord = SortOrder.Ascending
    End Sub

    Public Sub New(ByVal column As Integer, ByVal orderSort As System.Windows.Forms.SortOrder)
        col = column
        ord = orderSort
    End Sub

    Public Sub New(ByVal column As Integer, ByVal orderSort As System.Windows.Forms.SortOrder, ByVal _type As String)
        col = column
        ord = orderSort
        type = _type
    End Sub

    Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Try
            Select Case type

                Case "String"
                    If ord = SortOrder.Ascending Then
                        Return [String].Compare(CType(x, ListViewItem).SubItems(col).Text, CType(y, ListViewItem).SubItems(col).Text)
                    Else
                        Return [String].Compare(CType(y, ListViewItem).SubItems(col).Text, CType(x, ListViewItem).SubItems(col).Text)
                    End If

                Case "Date"
                    Dim xString As String = CType(x, ListViewItem).SubItems(col).Text
                    Dim yString As String = CType(y, ListViewItem).SubItems(col).Text

                    If xString = "" Then
                        xString = "01/01/1970"
                    End If
                    If yString = "" Then
                        yString = "01/01/1970"
                    End If

                    If ord = SortOrder.Ascending Then
                        Return [Date].Compare(CSDate.FromCrodipString(CSDate.ToCRODIPString(xString)), CSDate.FromCrodipString(CSDate.ToCRODIPString(yString)))
                    Else
                        Return [Date].Compare(CSDate.FromCrodipString(CSDate.ToCRODIPString(yString)), CSDate.FromCrodipString(CSDate.ToCRODIPString(xString)))
                    End If

            End Select
        Catch ex As Exception
            Return 0
        End Try
    End Function

End Class