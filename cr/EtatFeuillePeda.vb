Imports CRODIPWS
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatFeuillePeda
    Inherits EtatCrodip
    Private m_oFeuille As FeuillePeda
    Private m_ods As dsEnquete
    Private m_ReportName As String

    Public Sub New(pDiag As FeuillePeda)
        m_Path = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC
        m_oFeuille = pDiag
        'Récupération du nom du modème Crystal pour un chargement ultérieur
        Using r1 As New cr_FeuillePedagogique()
            m_ReportName = r1.ResourceName
            r1.Close()
        End Using
        m_ods = New dsEnquete
    End Sub

    Protected Overrides Function GenereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Using objReport As New ReportDocument
                    objReport.Load(MySettings.Default.RepertoireParametres & "/" & m_ReportName)

                    objReport.SetDataSource(m_ods)
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    m_FileName = CSDiagPdf.makeFilename(m_oFeuille.oDiag.pulverisateurId, m_oFeuille.oDiag.proprietaireId, CSDiagPdf.TYPE_FEUILLE_PEDAGOGIQUE) & ".pdf"
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
            CSDebug.dispError("EtatFeuillePega.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try
            m_ods.FeuillePedagogique.AddFeuillePedagogiqueRow(
                ConseilsInspecteur:=m_oFeuille.Conseils,
                InfosMesures:=m_oFeuille.Infos,
                NomOrganisme:=m_oFeuille.oDiag.organismePresNom,
                NumeroOrganisme:=m_oFeuille.oDiag.organismePresNumero
            )



            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("EtatFeuillePeda.genereDS ERR : " & ex.Message)
            m_ods = New dsEnquete()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
