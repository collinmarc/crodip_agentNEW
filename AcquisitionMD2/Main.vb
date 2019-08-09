Imports CRODIPAcquisition

Public Class Main
    Implements IMain


    Public Function CreateInstance() As ICRODIPAcquisition Implements IMain.CreateInstance
        Return New AcquisitionMD2()
    End Function
End Class
