Module CSTime

    Friend Sub pause(ByVal ms_to_wait As Long)
        System.Threading.Thread.Sleep(ms_to_wait)
    End Sub

End Module
