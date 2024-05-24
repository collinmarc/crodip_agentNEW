Imports System.device.Location
Public Module GPSAPP
    Public Sub Main2()

        Dim SerialPort As String
        SerialPort = FindGpsPort()
        Dim gpsReader As New GpsReader(SerialPort, 9600)

        AddHandler gpsReader.GpsDataReceived, Sub(sender As Object, e As GpsDataEventArgs)
                                                  Dim gpsData = e.GpsData
                                                  Console.WriteLine($"Latitude: {gpsData.Latitude}, Longitude: {gpsData.Longitude}, Altitude: {gpsData.Altitude}")
                                              End Sub

        gpsReader.Start()

        Dim n = 0
        While n < 10000
            n = n + 1
        End While
        gpsReader.Stop()
    End Sub

    Public Function FindGpsPort() As String
        Dim strReturn As String
        For Each portname As String In System.IO.Ports.SerialPort.GetPortNames()

            ' using to make shure that the testport Is closed after test
            Using testport As New System.IO.Ports.SerialPort(portname)
                ' maybe neccessary to set baudrate, parity, ... of com port
                testport.Open()
                ' to do if error Or exception this Is Not the 
                ' gps port Or some software already uses the gps-port

                ' to do read some data from port And verify If it Is GPS-Data
                Return portname
            End Using
        Next
        ' All com ports tried but Not found. throw exception Or return error code
        Return ""


    End Function
End Module
