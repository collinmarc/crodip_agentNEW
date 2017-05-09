Module CSTime

    Friend Sub pause(ByVal ms_to_wait As Long)
        Dim endwait As Double
        endwait = Environment.TickCount + ms_to_wait
        While Environment.TickCount < endwait
            System.Threading.Thread.Sleep(1)
            Application.DoEvents()
        End While
    End Sub

End Module
