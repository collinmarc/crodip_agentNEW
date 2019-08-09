Imports CRODIPAcquisition

Public Class AcquisitionMD2
    Implements CRODIPAcquisition.ICRODIPAcquisition

    Public Function GetValues() As List(Of IAcquisitionValue) Implements ICRODIPAcquisition.GetValues
        Dim oReturn As New List(Of IAcquisitionValue)

        oReturn.Add(New AcquisitionValue(1, 1, 1.5D))
        oReturn.Add(New AcquisitionValue(1, 2, 2.5D))
        Return oReturn

    End Function
End Class
