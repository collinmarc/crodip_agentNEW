Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EtatFVBanc
    Inherits EtatCrodip

    Private m_oControle As ControleBanc
    Private m_ods As dsFvBanc

    Public Sub New(pControle As ControleBanc)
        m_oControle = pControle
    End Sub



    Public Function GenereEtat() As Boolean
        Dim bReturn As Boolean
        Dim strReportName As String
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Using objReport As New ReportDocument
                    Using r1 As New cr_FicheVerifBanc()
                        strReportName = r1.ResourceName
                        r1.Close()
                    End Using

                    objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)

                        objReport.SetDataSource(m_ods)
                        Dim CrExportOptions As ExportOptions
                        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                        m_FileName = CSDiagPdf.makeFilename(m_oControle.idBanc, CSDiagPdf.TYPE_FV_BANCMESURE) & ".pdf"
                        CrDiskFileDestinationOptions.DiskFileName = Globals.CONST_PATH_EXP & m_FileName
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

            m_ods = New dsFvBanc()
            m_ods.Verif.AddVerifRow(dateVerification:=CDate(m_oControle.DateVerif).ToShortDateString(), agentVerif:=m_oControle.AgentVerif, idBanc:=m_oControle.idBanc, proprietaire:=m_oControle.Proprietaire, tempExt:=m_oControle.tempExt, tempEau:=m_oControle.tempEau, Resultat:=m_oControle.resultat)

            For Each oMesure As ControleBancBuse In m_oControle.lstMesures
                If Not String.IsNullOrEmpty(oMesure.Couleur) Then
                    Dim sResult As String = IIf(oMesure.resultat_3bar, "1", "0")
                    m_ods.Buse.AddBuseRow(couleur:=oMesure.Couleur, Numero:=oMesure.NumNatBuse, PressionEtalonage:=oMesure.pressionEtal, debit3bars:=oMesure.debitEtal, Mesure1:=oMesure.m1_3bar, Mesure2:=oMesure.m2_3bar, Mesure3:=oMesure.m3_3bar, Moyenne:=oMesure.moy_3bar, Ecart:=oMesure.ecart_3bar, Resultat:=sResult, pctEcart3bar:=oMesure.pctEcart_3bar, pctEcartTolerance:=oMesure.pctTolerance_3bar)
                End If
            Next
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("EtatRapportInspection.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
End Class
