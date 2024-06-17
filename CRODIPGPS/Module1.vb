Module Module1

    Public Sub Main()
        Dim tArgs As String()

        tArgs = Environment.GetCommandLineArgs()
        Dim mainForm As Form1
        If tArgs.Count = 2 Then
            mainForm = New Form1(tArgs(1))
        Else
            mainForm = New Form1()
        End If

        mainForm.ShowDialog()

    End Sub

End Module
