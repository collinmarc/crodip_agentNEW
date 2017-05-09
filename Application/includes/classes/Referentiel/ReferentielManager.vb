Public Class ReferentielManager

    Public Function getWSReferentielCodesAPE() As Boolean
        Dim bReturn As Boolean
        Try
            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Dim objWSCrodip_response As Object
            ' Appel au WS
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Erreur - ReferentielCodesAPEManager.getWSReferentielCodesAPE : " & ex.Message)
            bReturn = False
        End Try

        Return bReturn
    End Function

End Class