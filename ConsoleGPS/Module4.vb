Module Module4
    Sub Main()
        Dim gpgga1 As String = "$GPGGA,123519,4813.91843,N,00132.45206,W,1,08,0.9,545.4,M,46.9,M,,*47"
        Dim gpgga2 As String = "$GPGGA,123520,4813.91843,N,00132.45306,W,1,08,0.9,545.4,M,46.9,M,,*47"

        Dim coords1 As (Double, Double) = ParseGPGGA(gpgga1)
        Dim coords2 As (Double, Double) = ParseGPGGA(gpgga2)

        Dim distance As Double = HaversineDistance(coords1.Item1, coords1.Item2, coords2.Item1, coords2.Item2)

        Console.WriteLine("Distance: " & distance & " km")
    End Sub

    Function ParseGPGGA(ByVal gpgga As String) As (Double, Double)
        Dim parts As String() = gpgga.Split(","c)
        Dim lat As Double = ConvertToDecimalDegrees(parts(2), parts(3)(0))
        Dim lon As Double = ConvertToDecimalDegrees(parts(4), parts(5)(0))
        Return (lat, lon)
    End Function

    Function ConvertToDecimalDegrees(ByVal degreesMinutes As String, ByVal direction As Char) As Double
        Dim dotIndex As Integer = degreesMinutes.IndexOf("."c)
        Dim degrees As Double = Convert.ToDouble(degreesMinutes.Substring(0, dotIndex - 2))
        Dim minutes As Double = Convert.ToDouble(degreesMinutes.Substring(dotIndex - 2).Replace(".", ","))
        Dim seconds As Double = Convert.ToDouble(degreesMinutes.Substring(dotIndex + 2).Replace(".", ",")) * 60 / 10000
        Dim decimalDegrees As Double = degrees + (minutes / 60) + (seconds / 3600)

        If direction = "S"c Or direction = "W"c Then
            decimalDegrees = -decimalDegrees
        End If

        Return decimalDegrees
    End Function

    Function HaversineDistance(ByVal lat1 As Double, ByVal lon1 As Double, ByVal lat2 As Double, ByVal lon2 As Double) As Double
        Const R As Double = 6371 ' Rayon de la Terre en kilomètres
        Dim dLat As Double = DegreesToRadians(lat2 - lat1)
        Dim dLon As Double = DegreesToRadians(lon2 - lon1)

        Dim a As Double =
            Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
            Math.Cos(DegreesToRadians(lat1)) * Math.Cos(DegreesToRadians(lat2)) *
            Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
        Dim c As Double = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a))
        Dim distance As Double = R * c

        Return distance ' Distance en kilomètres
    End Function

    Function DegreesToRadians(ByVal degrees As Double) As Double
        Return degrees * (Math.PI / 180)
    End Function
End Module
