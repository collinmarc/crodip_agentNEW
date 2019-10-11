Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmTestSignature

    'Private Sub btnSign_Click(sender As Object, e As EventArgs) Handles btnSign.Click
    '    Dim ofrm As New frmSignClient()
    '    ofrm.Show()

    'End Sub

    '  Private Sub btnAffiche_Click(sender As Object, e As EventArgs) Handles btnAffiche.Click

    'Dim ods As New dsSign()

    'Using newImage As System.Drawing.Image = System.Drawing.Image.FromFile("sign.bmp")
    '    Dim ms As New MemoryStream
    '    newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
    '    ods.ta1.Addta1Row(ms.ToArray(), tbLibelle.Text)
    'End Using

    'If System.IO.File.Exists("testSignature.pdf") Then
    '    System.IO.File.Delete("testSignature.pdf")
    'End If

    'Using objReport As New ReportDocument
    '    objReport.Load("signature\crTestSignature.rpt")

    '    objReport.SetDataSource(ods)

    '    Dim CrExportOptions As ExportOptions
    '    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
    '    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
    '    CrDiskFileDestinationOptions.DiskFileName = "testSignature.pdf"
    '    CrExportOptions = objReport.ExportOptions
    '    With CrExportOptions
    '        .ExportDestinationType = ExportDestinationType.DiskFile
    '        .ExportFormatType = ExportFormatType.PortableDocFormat
    '        .DestinationOptions = CrDiskFileDestinationOptions
    '        .FormatOptions = CrFormatTypeOptions
    '    End With
    '    objReport.Export()
    '    objReport.Close()

    'End Using

    'End Sub
End Class
