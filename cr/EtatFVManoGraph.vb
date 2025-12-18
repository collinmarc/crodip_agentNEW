Imports System.Linq
Imports CRODIPWS
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EtatFVManoGrpah
    Inherits EtatCrodip

    Private m_oControle As ControleMano
    Private m_ods As dsFvMano

    Public Sub New(pControle As ControleMano)
        m_Path = GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE
        m_oControle = pControle
    End Sub

    Protected Overrides Function GenereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean
        Dim strReportName As String
        Try
            CSDebug.dispInfo("etatFVMano.GenereEtatLocal() :  GenereDS")
            bReturn = genereDS()
            If (bReturn) Then
                CSDebug.dispInfo("etatFVMano.GenereEtatLocal() :  GenerePDF")
                Using objReport As New ReportDocument
                    Using r1 As New cr_diagVerifMano
                        strReportName = r1.ResourceName
                        r1.Close()
                    End Using

                    objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)

                    objReport.SetDataSource(m_ods)
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    Dim oMano As ManometreControle
                    oMano = ManometreControleManager.getManometreControleByidCrodip(m_oControle.idMano)
                    m_FileName = CSDiagPdf.makeFilename(oMano.idCrodip, " ", CSDiagPdf.TYPE_FV_MANOCTRL) & ".pdf"
                    CrDiskFileDestinationOptions.DiskFileName = m_Path & m_FileName
                    CrExportOptions = objReport.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions
                    End With
                    objReport.Export()
                    objReport.Close()
                End Using

            End If
        Catch ex As Exception
            CSDebug.dispError("EtatRapportInspection.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try

            Dim nPC As Integer = m_oControle.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "UP"
                                                                                End Function).Count()
            Dim nPD As Integer = m_oControle.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "DOWN"
                                                                                End Function).Count()
            Dim nPR As Integer = m_oControle.lstControleManoDetail.Values.Where(Function(D)
                                                                                    Return D.type = "REPE"
                                                                                End Function).Count()
            Dim nMax As Integer = Math.Max(nPR, Math.Max(nPC, nPD))

            m_ods = New dsFvMano()
            For nIndex As Integer = 0 To nMax - 1
                Dim oRow As dsFvMano.DiagrammeRow
                oRow = m_ods.Diagramme.NewDiagrammeRow()
                oRow.Numero = nIndex + 1
                If nIndex < nPC Then
                    oRow.PressionCroissante = m_oControle.lstControleManoDetail_pres_manoEtalon("UP" & nIndex + 1)
                Else
                    oRow.SetPressionCroissanteNull()
                End If
                If nIndex < nPD Then
                    oRow.PressionDecroissante = m_oControle.lstControleManoDetail_pres_manoEtalon("DOWN" & nIndex + 1)
                Else
                    oRow.SetPressionDecroissanteNull()
                End If
                If nIndex < nPR Then
                    oRow.PressionRepetition = m_oControle.lstControleManoDetail_pres_manoEtalon("REPE" & nIndex + 1)
                Else
                    oRow.SetPressionRepetitionNull()
                End If
                m_ods.Diagramme.AddDiagrammeRow(oRow)



            Next


            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("EtatFVMAno.GenereDS ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function

End Class
