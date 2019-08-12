Imports CRODIPAcquisition

Public Class Main
    Implements IMain


    Public Function CreateInstance() As ICRODIPAcquisition Implements IMain.CreateInstance
        Return New AcquisitionITEQ()
    End Function
End Class
