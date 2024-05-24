Imports System.IO.Ports

Public Class GpsReader
    Private WithEvents serialPort As SerialPort

    Public Event GpsDataReceived As EventHandler(Of GpsDataEventArgs)

    Public Sub New(portName As String, baudRate As Integer)
        serialPort = New SerialPort(portName, baudRate, Parity.None, 8, StopBits.One)
    End Sub

    Public Sub Start()
        If Not serialPort.IsOpen Then
            serialPort.Open()
        End If
    End Sub

    Public Sub [Stop]()
        If serialPort.IsOpen Then
            serialPort.Close()
        End If
    End Sub

    Private Sub serialPort_DataReceived(sender As Object, e As SerialDataReceivedEventArgs) Handles serialPort.DataReceived
        Dim data As String = serialPort.ReadLine()
        Dim gpsData = ParseGpsData(data)
        If gpsData IsNot Nothing Then
            RaiseEvent GpsDataReceived(Me, New GpsDataEventArgs(gpsData))
        End If
    End Sub

    Private Function ParseGpsData(data As String) As GpsData
        ' Assuming NMEA 0183 format, we handle GPGGA sentence for example
        If data.StartsWith("$GPGGA") Then
            Dim parts = data.Split(","c)
            If parts.Length > 9 Then
                Dim latitude = ParseLatitude(parts(2), parts(3))
                Dim longitude = ParseLongitude(parts(4), parts(5))
                Dim altitude = ParseDouble(parts(9))
                Return New GpsData(latitude, longitude, altitude)
            End If
        End If
        Return Nothing
    End Function

    Private Function ParseLatitude(value As String, direction As String) As Double
        Dim deg As Double = Double.Parse(value.Substring(0, 2))
        Dim min As Double = Double.Parse(value.Substring(2))
        Dim lat As Double = deg + (min / 60)
        If direction = "S" Then lat = -lat
        Return lat
    End Function

    Private Function ParseLongitude(value As String, direction As String) As Double
        Dim deg As Double = Double.Parse(value.Substring(0, 3))
        Dim min As Double = Double.Parse(value.Substring(3))
        Dim lon As Double = deg + (min / 60)
        If direction = "W" Then lon = -lon
        Return lon
    End Function

    Private Function ParseDouble(value As String) As Double
        Return If(Double.TryParse(value, Nothing), Double.Parse(value), 0)
    End Function
End Class

Public Class GpsDataEventArgs
    Inherits EventArgs

    Public Property GpsData As GpsData

    Public Sub New(data As GpsData)
        GpsData = data
    End Sub
End Class

Public Class GpsData
    Public Property Latitude As Double
    Public Property Longitude As Double
    Public Property Altitude As Double

    Public Sub New(lat As Double, lon As Double, alt As Double)
        Latitude = lat
        Longitude = lon
        Altitude = alt
    End Sub
End Class
