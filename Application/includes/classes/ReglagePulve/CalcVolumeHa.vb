'classe de stokage des infos de calcul du volume/ha
Public Class CalcVolumeHa
    Public LargeurPlantation As Decimal
    Public VitesseRotation As Decimal
    Public RegimeMoteur As Decimal
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
    Private m_Pression1 As Decimal
    Private m_Debit1 As Decimal
    Public Vitesse1 As Decimal
    Public Ecartement1 As Decimal
    Public VolEauHa1 As Decimal
    Private m_Pression2 As Decimal
    Private m_Debit2 As Decimal
    Public Vitesse2 As Decimal
    Public Ecartement2 As Decimal
    Public VolEauHa2 As Decimal
    Public Distance As Decimal
    Public Temps As Decimal
    Public Vitesse As Decimal

    Public Property Debit1 As Decimal
        Get
            Return m_Debit1
        End Get
        Set(value As Decimal)
            m_Debit1 = value
            calcPression1()
        End Set
    End Property

    Public Property Debit2 As Decimal
        Get
            Return m_Debit2
        End Get
        Set(value As Decimal)
            m_Debit2 = value
        End Set
    End Property
    Public Property Pression1 As Decimal
        Get
            Return m_Pression1
        End Get
        Set(value As Decimal)
            m_Pression1 = value
            calcDebit1()
        End Set
    End Property

    Public Property Pression2 As Decimal
        Get
            Return m_Pression2
        End Get
        Set(value As Decimal)
            m_Pression2 = value
            calcDebit2()
        End Set
    End Property
    Public Sub calcDebitPressionTravailMoinsPerteCharge()
        DebitPressionTravailMoinsPerteCharge = DebitMoyenPM * Math.Sqrt(PressionTravailMoinsPC / PressionDeMesure)
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

    Public Sub calcPression1()
        ' m_Pression1 = (Debit1 * PressionDeMesure) * (Debit1 * PressionDeMesure) * DebitMoyenPM
    End Sub

    Public Sub calcPression2()
        ' m_Pression2 = (Debit1 * PressionDeMesure) * (Debit1 * PressionDeMesure) * DebitMoyenPM
    End Sub
    Public Sub calcDebit1()
        m_Debit1 = DebitMoyenPM * Math.Sqrt(Pression1 / PressionDeMesure)
    End Sub
    Public Sub calcVolha1()
        VolEauHa1 = (m_Debit1 * NombreBuses) * 600 / (Ecartement1 * Vitesse1)
    End Sub
    Public Sub calcDebit2()
        Debit2 = DebitMoyenPM * Math.Sqrt(Pression2 / PressionDeMesure)
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
