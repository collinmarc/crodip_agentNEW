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
                    Using r1 As New cr_diagVerifMano()
                        strReportName = r1.ResourceName
                        r1.Close()
                    End Using

                    objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)

                    objReport.SetDataSource(m_ods)
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    Dim oMano As ManometreControle
                    oMano = ManometreControleManager.getManometreControleByNumeroNational(m_oControle.idMano)
                    m_FileName = CSDiagPdf.makeFilename(oMano.idCrodip, CSDiagPdf.TYPE_FV_MANOCTRL) & ".pdf"
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
            Dim oManoRef As ManometreEtalon
            oManoRef = ManometreEtalonManager.getManometreEtalonByNumeroNational(m_oControle.manoEtalon)
            Dim oMano As ManometreControle
            oMano = ManometreControleManager.getManometreControleByNumeroNational(m_oControle.idMano)
            ' Recupere la structure
            Dim objStructure As Structuree = StructureManager.getStructureById(m_oControle.idStructure)
            Dim PressionCroissante As String = "Pression croissante"
            Dim PressionDecroissante As String = "Pression décroissante"
            m_ods = New dsFvMano()
            m_ods.Diagramme.AddDiagrammeRow(Numero:=1, PressionCroissante:=+0.5, PressionDecroissante:=0.1, PressionRepetition:=-0.15)
            m_ods.Diagramme.AddDiagrammeRow(Numero:=2, PressionCroissante:=-0.5, PressionDecroissante:=0.2, PressionRepetition:=-0.25)
            Dim oRow As dsFvMano.DiagrammeRow
            oRow = m_ods.Diagramme.NewDiagrammeRow()
            oRow.Numero = 3
            oRow.PressionCroissante = +0.5
            oRow.PressionDecroissante = 0.3
            m_ods.Diagramme.AddDiagrammeRow(oRow)
            oRow = m_ods.Diagramme.NewDiagrammeRow()
            oRow.Numero = 4
            oRow.PressionCroissante = -0.5
            oRow.PressionDecroissante = 0.4
            m_ods.Diagramme.AddDiagrammeRow(oRow)
            oRow = m_ods.Diagramme.NewDiagrammeRow()
            oRow.Numero = 5
            oRow.PressionCroissante = -0.5
            oRow.PressionDecroissante = 0.5
            m_ods.Diagramme.AddDiagrammeRow(oRow)
            oRow = m_ods.Diagramme.NewDiagrammeRow()
            oRow.Numero = 6
            oRow.PressionCroissante = 0.5
            m_ods.Diagramme.AddDiagrammeRow(oRow)
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("EtatFVMAno.GenereDS ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function

End Class
