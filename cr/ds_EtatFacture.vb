

Partial Public Class ds_EtatFacture
    Partial Public Class LigneFactDataTable
        Private Sub LigneFactDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.DiagIdColumn.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If

        End Sub

    End Class
End Class
