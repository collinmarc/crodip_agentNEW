
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            MsgBox("Début")
            Dim oReport As ReportDocument
            MsgBox("Déclaré")
            oReport = New ReportDocument()
            MsgBox("Créé")
            oReport.Load("./CrystalReport1.rpt")
            MsgBox("Chargé")
            CrystalReportViewer1.ReportSource = oReport
            MsgBox("Affiché")

            If System.IO.File.Exists("./test.pdf") Then
                System.IO.File.Delete("./test.pdf")
            End If

            Dim CrExportOptions As ExportOptions
            Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
            Dim CrFormatTypeOptions As New PdfFormatOptions
            CrDiskFileDestinationOptions.DiskFileName = "./test.pdf"
            CrExportOptions = oReport.ExportOptions
            With CrExportOptions

                .ExportDestinationType = ExportDestinationType.DiskFile
                .ExportFormatType = ExportFormatType.PortableDocFormat

                .DestinationOptions = CrDiskFileDestinationOptions
                .FormatOptions = CrFormatTypeOptions
            End With
            oReport.Export()
            If System.IO.File.Exists("./test.pdf") Then
                MsgBox("Exporté")
            End If

        Catch ex As Exception
            MsgBox("TestCrystalReport ERR" & ex.Message)
        End Try

    End Sub
End Class