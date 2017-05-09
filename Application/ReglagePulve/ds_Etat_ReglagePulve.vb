Partial Class ds_Etat_ReglagePulve
    Partial Class SyntheseCapteurVitesseDataTable

        Private Sub SyntheseCapteurVitesseDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.Temps2Column.ColumnName) Then
                'Ajoutez le code utilisateur ici
            End If

        End Sub

    End Class

End Class
