Module StartApplication
    Public Sub Main()
        Dim ofrm As Form
#If REGLAGEPULVE Then
        ofrm = New frmRPparentContener()
#Else
        ofrm = New parentContener()
#End If
        ofrm.ShowDialog()
    End Sub

End Module
