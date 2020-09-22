Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatDocumentCoPropriete
    Inherits EtatCrodip
    Private m_oDiag As Diagnostic
    Private m_ods As dsDocCoPropriete
    Private m_lstCoProp As List(Of String)
    Private m_ReportName As String

    Public Sub New(pDiag As Diagnostic)
        m_oDiag = pDiag
        m_lstCoProp = New List(Of String)
        'Récupération du nom du modème Crystal pour un chargement ultérieur
        Using r1 As New cr_DocCopropiete()
            m_ReportName = r1.ResourceName
            r1.Close()
        End Using
    End Sub



    Public Function AddCoProprietaire(pCoProp As String) As Boolean
        Dim bReturn As Boolean
        Try
            m_lstCoProp.Add(pCoProp)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("EtatDocumentCoPropriete.AddCoProprietaire ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Public Overrides Function GenereEtat(Optional pExportPDF As Boolean = True) As Boolean
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
                    m_FileName = CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_DOC_COPROP) & ".pdf"
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
            CSDebug.dispError("EtatDocumentCoPropriete.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try
            Dim rsProp As String
            rsProp = m_oDiag.proprietaireRaisonSociale & "  /  " & m_oDiag.proprietaireNom & "  " & m_oDiag.proprietairePrenom
            m_ods = New dsDocCoPropriete()

            Dim dateCtrl As String
            If String.IsNullOrEmpty(m_oDiag.controleDateFin) Then
                dateCtrl = Now().ToShortDateString
            Else
                dateCtrl = CDate(m_oDiag.controleDateFin).ToShortDateString()
            End If
            Dim strLargeurNbRangs As String = ""
            If Not String.IsNullOrEmpty(m_oDiag.pulverisateurLargeur) Then
                strLargeurNbRangs = m_oDiag.pulverisateurLargeur
            End If
            If Not String.IsNullOrEmpty(m_oDiag.pulverisateurNbRangs) Then
                strLargeurNbRangs = m_oDiag.pulverisateurNbRangs
            End If
            m_ods.Prop1.AddProp1Row(RSNomPrenom:=rsProp,
                                    Conclusion:=m_oDiag.controleEtat,
                                    DateControle:=dateCtrl,
                                    Inspecteur:=m_oDiag.inspecteurNom & " " & m_oDiag.inspecteurPrenom,
                                    LieuControle:=m_oDiag.controleCommune,
                                    PulveCapacite:=m_oDiag.pulverisateurCapacite,
                                    PulveLargNbRangs:=strLargeurNbRangs,
                                    PulveMarque:=m_oDiag.pulverisateurMarque,
                                    PulveModele:=m_oDiag.pulverisateurModele,
                                    PulveNumNat:=m_oDiag.pulverisateurNumNational,
                                    NumControle:=m_oDiag.id)
            For Each s As String In m_lstCoProp
                m_ods.PropN.AddPropNRow(s)
            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("EtatDocumentCoPropriete.genereDS ERR : " & ex.Message)
            m_ods = New dsDocCoPropriete()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
