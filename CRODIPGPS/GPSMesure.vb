Public Class GPSMesure
    Private _num As Integer
    Public Property Num() As Integer
        Get
            Return _num
        End Get
        Set(ByVal value As Integer)
            _num = value
        End Set
    End Property
    Private _distance As Decimal
    Public Property Distance() As Decimal
        Get
            Return Math.Round(_distance, 1)
        End Get
        Set(ByVal value As Decimal)
            If value <> _distance Then
                _distance = value
                calculeVitesse()
            End If
        End Set
    End Property
    Private _temps As Decimal
    Public Property Temps() As Integer
        Get
            Return _temps
        End Get
        Set(ByVal value As Integer)
            If value <> _temps Then
                _temps = value
                calculeVitesse()
            End If
        End Set
    End Property
    Private Sub calculeVitesse()
        If Temps <> 0 And Distance <> 0 Then
            Vitesse = (Distance / 1000 / Temps) * 3600
        End If
    End Sub
    Private _vitesse As Decimal
    Public Property Vitesse() As Decimal
        Get
            Return Math.Round(_vitesse, 2)
        End Get
        Set(ByVal value As Decimal)

            _vitesse = value
        End Set
    End Property
    Private _VitessseLue As Decimal
    Public Property VitesseLue() As Decimal
        Get
            Return _VitessseLue
        End Get
        Set(ByVal value As Decimal)
            _VitessseLue = value
        End Set
    End Property
    Public Sub SetValues(pDistance As Decimal, pTemps As Decimal)
        _distance = pDistance
        _temps = pTemps
        'Vitesse = Distance(m)/Temps(S)*(3600 / 1000)
        Vitesse = Distance / Temps * 3.6

    End Sub
    Private _NumPulve As String
    Public Property NumPulve() As String
        Get
            Return _NumPulve
        End Get
        Set(ByVal value As String)
            _NumPulve = value
        End Set
    End Property
    Public Function ToCsv(pFile As String) As Boolean
        Dim bReturn As Boolean
        Try

            System.IO.File.AppendAllText(pFile, NumPulve & ";" & Num & ";" & Distance & ";" & Temps & ";" & Vitesse & ";" & VitesseLue & vbCrLf)
            bReturn = True
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class
