''' <summary>
''' https://stackoverflow.com/a/15020157/1307504
''' THANKS
''' </summary>


Class SurroundingClass
    Private Const WM_SETREDRAW As Integer = 11

    Public Shared Sub BeginControlUpdate(ByVal control As Control)
        Dim msgSuspendUpdate As Message = Message.Create(control.Handle, WM_SETREDRAW, IntPtr.Zero, IntPtr.Zero)
        Dim window As NativeWindow = NativeWindow.FromHandle(control.Handle)
        window.DefWndProc(msgSuspendUpdate)
    End Sub

    Public Shared Sub EndControlUpdate(ByVal control As Control)
        Dim wparam As IntPtr = New IntPtr(1)
        Dim msgResumeUpdate As Message = Message.Create(control.Handle, WM_SETREDRAW, wparam, IntPtr.Zero)
        Dim window As NativeWindow = NativeWindow.FromHandle(control.Handle)
        window.DefWndProc(msgResumeUpdate)
        control.Invalidate()
        control.Refresh()
    End Sub
End Class