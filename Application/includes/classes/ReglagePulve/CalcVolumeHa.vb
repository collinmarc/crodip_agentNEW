'classe de stokage des infos de calcul du volume/ha
Public Class CalcVolumeHa
    Public LargeurPlantation As Decimal
    Public VitesseRotation As Decimal
    Public EmplacementPriseAir As Boolean
    Public NbreDescentes As Integer
    Public NbreBusesParDescente As Integer
    Public NbreNiveauParDescente As Integer
    Public PressionDeMesure As Decimal
    Public DebitMoyenPM As Decimal
    Public NombreBuses As Integer
    Public PressionTravail As Decimal
    Public PressionTravailMoinsPC As Decimal
    Public DebitPressionTravailMoinsPerteCharge As Decimal
    Public VolHaPMV1 As Decimal
    Public VolHaPMV2 As Decimal
    Public VolHaPTV1 As Decimal
    Public VolHaPTV2 As Decimal
    Public NombreNiveauxBuses As Decimal
    Public VitesseReelle1 As Decimal
    Public VitesseReelle2 As Decimal
    Public LargeurApp As Decimal
    Public lstBuseUsees As String
    Public Pression1 As Decimal
    Public Debit1 As Decimal
    Public Vitesse1 As Decimal
    Public Ecartement1 As Decimal
    Public VolEauHa1 As Decimal
    Public Pression2 As Decimal
    Public Debit2 As Decimal
    Public Vitesse2 As Decimal
    Public Ecartement2 As Decimal
    Public VolEauHa2 As Decimal
    Public Distance As Decimal
    Public Temps As Decimal
    Public Vitesse As Decimal

    Public Sub calcDebitPressionTravailMoinsPerteCharge()
        DebitPressionTravailMoinsPerteCharge = Math.Sqrt(DebitMoyenPM * DebitMoyenPM * PressionTravailMoinsPC) / PressionDeMesure
    End Sub

    Public Sub calcVolHaPMV1()
        VolHaPMV1 = (DebitMoyenPM * NombreBuses) * 600 / (LargeurApp * VitesseReelle1)
    End Sub

    Public Sub calcVolHaPMV2()
        VolHaPMV2 = (DebitMoyenPM * NombreBuses) * 600 / (LargeurApp * VitesseReelle2)
    End Sub

    Public Sub calcVolHaPTV1()
        VolHaPTV1 = (DebitPressionTravailMoinsPerteCharge * NombreBuses) * 600 / (LargeurApp * VitesseReelle1)
    End Sub

    Public Sub calcVolHaPTV2()
        VolHaPTV2 = (DebitPressionTravailMoinsPerteCharge * NombreBuses) * 600 / (LargeurApp * VitesseReelle2)
    End Sub

    Public Sub calcDebit1()
        Debit1 = Math.Sqrt(DebitMoyenPM * DebitMoyenPM * Pression1) / PressionDeMesure
    End Sub

    Public Sub calcVolha1()
        VolEauHa1 = (Debit1 * NombreBuses) * 600 / (Ecartement1 * Vitesse1)
    End Sub
    Public Sub calcDebit2()
        Debit2 = Math.Sqrt(DebitMoyenPM * DebitMoyenPM * Pression2) / PressionDeMesure
    End Sub
    Public Sub calcVolha2()
        VolEauHa2 = (Debit2 * NombreBuses) * 600 / (Ecartement2 * Vitesse2)
    End Sub

    Public Sub Calcul()
        Try
            calcDebitPressionTravailMoinsPerteCharge()
        Catch ex As Exception

        End Try
        Try

            calcVolHaPMV1()
        Catch ex As Exception

        End Try
        Try

            calcVolHaPMV2()
        Catch ex As Exception

        End Try
        Try
            calcVolHaPTV1()

        Catch ex As Exception

        End Try
        Try
            calcVolHaPTV2()
        Catch ex As Exception

        End Try
        Try

            calcDebit1()
        Catch ex As Exception

        End Try
        Try

            calcVolha1()
        Catch ex As Exception

        End Try
        Try
            calcDebit2()
        Catch ex As Exception

        End Try
        Try
            calcVolha2()
        Catch ex As Exception

        End Try


    End Sub
End Class
