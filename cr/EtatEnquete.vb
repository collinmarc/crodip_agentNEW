Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatEnquete
    Inherits EtatCrodip
    Private m_oDiag As Diagnostic
    Private m_ods As dsEnquete
    Private m_ReportName As String

    Public Sub New(pDiag As Diagnostic)
        m_oDiag = pDiag
        'Récupération du nom du modème Crystal pour un chargement ultérieur
        Dim r1 As New cr_EnqueteSatisfaction()
        m_ReportName = r1.ResourceName
        r1.Dispose()
    End Sub

    Public Function GenereEtat() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Dim objReport As ReportDocument

                objReport = New ReportDocument
                objReport.Load(MySettings.Default.RepertoireParametres & "/" & m_ReportName)

                objReport.SetDataSource(m_ods)
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                m_FileName = CSDiagPdf.makeFilename(pulverisateurCourant.id, CSDiagPdf.TYPE_FEUILLE_ENQSAT) & ".pdf"
                CrDiskFileDestinationOptions.DiskFileName = CONST_PATH_EXP & m_FileName
                CrExportOptions = objReport.ExportOptions
                With CrExportOptions
                    .ExportDestinationType = ExportDestinationType.DiskFile
                    .ExportFormatType = ExportFormatType.PortableDocFormat
                    .DestinationOptions = CrDiskFileDestinationOptions
                    .FormatOptions = CrFormatTypeOptions
                End With
                objReport.Export()

            End If
        Catch ex As Exception
            CSDebug.dispError("EtatEnquete.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try
            Dim rsProp As String
            rsProp = m_oDiag.proprietaireRaisonSociale & "  /  " & m_oDiag.proprietaireNom & "  " & m_oDiag.proprietairePrenom
            m_ods = New dsEnquete()

            Dim dateCtrl As Date
            If String.IsNullOrEmpty(m_oDiag.controleDateFin) Then
                dateCtrl = Now()
            Else
                dateCtrl = CDate(m_oDiag.controleDateFin)
            End If

            'Type de controle (Controlecomplet ou Cv)
            'Dans le cas d'une contre visite immédiate, on récupére le type du diag initial
            Dim bCtrlComplet As Boolean
            Dim bContreVisite As Boolean
            bCtrlComplet = m_oDiag.controleIsComplet
            bContreVisite = Not m_oDiag.controleIsComplet
            If m_oDiag.isContrevisiteImmediate Then
                'on recharge le controle initial
                Dim odiagInitial As Diagnostic
                odiagInitial = DiagnosticManager.getDiagnosticById(m_oDiag.controleInitialId)
                bCtrlComplet = odiagInitial.controleIsComplet
            End If
            m_ods.Enquete.AddEnqueteRow(dateControle:=dateCtrl,
                                        nomExploitant:=m_oDiag.proprietaireNom & "  " & m_oDiag.proprietairePrenom,
                                        adresse1Exploit:=m_oDiag.proprietaireAdresse,
                                        adresse2Exploit:="",
                                        cpExploit:=m_oDiag.proprietaireCodePostal,
                                        villeExploit:=m_oDiag.proprietaireCommune,
                                        bctrlComplet:=bCtrlComplet,
                                        bContreVisite:=bContreVisite,
                                        typePulve:=m_oDiag.pulverisateurType,
                                        nomStruct:=m_oDiag.organismePresNom,
                                        inspecteur:=m_oDiag.inspecteurNom & " " & m_oDiag.inspecteurPrenom,
                                        RSExploitant:=m_oDiag.proprietaireRaisonSociale, Email:=m_oDiag.proprietaireEmail
            )



            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("EtatEnquete.genereDS ERR : " & ex.Message)
            m_ods = New dsEnquete()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
