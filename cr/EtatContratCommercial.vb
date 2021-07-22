Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatContratCommercial
    Inherits EtatCrodip
    Private m_oDiag As Diagnostic
    Private m_ods As dsContratCommercial
    Private m_ReportName As String

    Public Sub New(pDiag As Diagnostic)
        m_Path = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC
        m_oDiag = pDiag
        'Récupération du nom du modème Crystal pour un chargement ultérieur
        Using r1 As New cr_ContratCommercial()
            m_ReportName = r1.ResourceName
            r1.Close()
        End Using
    End Sub

    protected Overrides Function GenereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean
        Dim strReportName As String
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Using r1 As New cr_RapportInspection
                    strReportName = r1.ResourceName
                    r1.Close()
                End Using

                m_oReportDocument = New ReportDocument()

                If System.IO.File.Exists(MySettings.Default.RepertoireParametres & "/" & m_ReportName) Then
                    m_oReportDocument.Load(MySettings.Default.RepertoireParametres & "/" & m_ReportName)
                Else
                    CSDebug.dispFatal(MySettings.Default.RepertoireParametres & "/" & m_ReportName & " n'existe pas")
                End If

                m_oReportDocument.SetDataSource(m_ods)
                If (pExportPDF) Then
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    m_FileName = CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_CONTRAT_COMMERCIAL) & ".pdf"
                    CrDiskFileDestinationOptions.DiskFileName = m_Path & m_FileName
                    If File.Exists(m_Path & m_FileName) Then
                        File.Delete(m_Path & m_FileName)
                    End If

                    CrExportOptions = m_oReportDocument.ExportOptions
                    With CrExportOptions
                        .ExportDestinationType = ExportDestinationType.DiskFile
                        .ExportFormatType = ExportFormatType.PortableDocFormat
                        .DestinationOptions = CrDiskFileDestinationOptions
                        .FormatOptions = CrFormatTypeOptions
                    End With

                    m_oReportDocument.Export()
                    m_oReportDocument.Close()
                End If

            End If
        Catch ex As Exception
            CSDebug.dispError("EtatContratCommercial.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try
            Dim rsProp As String
            rsProp = m_oDiag.proprietaireNom & "  " & m_oDiag.proprietairePrenom
            m_ods = New dsContratCommercial()

            'Dim msCL As New MemoryStream
            'Dim img1 As Image = Nothing
            'Dim img2 As Image = Nothing
            'If (m_oDiag.SignRIClient IsNot Nothing) Then
            '    msCL = New MemoryStream(m_oDiag.SignRIClient)
            '    img1 = Image.FromStream(msCL)
            '    img2 = New Bitmap(img1, New Size(151, 37))
            '    img2.Save(msCL, Imaging.ImageFormat.Bmp)
            'End If

            'Dim msAG As New MemoryStream
            'If (m_oDiag.SignRIAgent IsNot Nothing) Then
            '    msAG = New MemoryStream(m_oDiag.SignRIAgent)
            '    img1 = Image.FromStream(msAG)
            '    img2 = New Bitmap(img1, New Size(151, 37))
            '    img2.Save(msAG, Imaging.ImageFormat.Bmp)
            'End If

            m_ods.ContratCommercial.AddContratCommercialRow(dateControle:=m_oDiag.controleDateDebut,
                                                            adresse1Exploit:=m_oDiag.proprietaireAdresse,
                                                            cpExploit:=m_oDiag.proprietaireCodePostal,
                                                             NomPrenomInspecteur:=m_oDiag.inspecteurNom & " " & m_oDiag.inspecteurPrenom,
                                                             NomRepresentant:=m_oDiag.proprietaireRepresentant,
                                                             NumInspecteur:=m_oDiag.inspecteurNumeroNational,
                                                             numStruct:=m_oDiag.organismePresNumero,
                                                             MarquePulve:=m_oDiag.pulverisateurMarque,
                                                             NumnatPulve:=m_oDiag.pulverisateurNumNational,
                                                             MontantHT:=m_oDiag.TotalHT,
                                                             RSExploitant:=m_oDiag.proprietaireRaisonSociale,
                                                             villeExploit:=m_oDiag.proprietaireCommune,
                                                             NomPrenomExploit:=rsProp,
                                                             bSignClient:=m_oDiag.isSignCCClient,
                                                        SignClient:=m_oDiag.SignCCClient,
                                                        DateSignclient:=m_oDiag.dateSignCCClientS,
                                                        bSignAgent:=m_oDiag.isSignCCAgent,
                                                        SignAgent:=m_oDiag.SignCCAgent,
                                                        DateSignAgent:=m_oDiag.dateSignCCAgentS)


            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("EtatContratCommercial.genereDS ERR : " & ex.Message)
            m_ods = New dsContratCommercial()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
