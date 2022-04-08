Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatBL
    Inherits EtatCrodip
    Private Class LgPrestation
        Public m_Libelle As String
        Public m_PU As Decimal
        Public m_qte As Decimal
        Public m_TxTVA As Decimal
        Public m_TotalHT As Decimal
        Public m_TotalTTC As Decimal

        Public Sub New(pLib As String, pPU As Decimal, pQte As Decimal, pTxTVA As Decimal, pTotalHT As Decimal, pTotalTTC As Decimal)
            m_Libelle = pLib
            m_PU = pPU
            m_qte = pQte
            m_TxTVA = pTxTVA
            m_TotalHT = pTotalHT
            m_TotalTTC = pTotalTTC

        End Sub
    End Class

    Private m_oDiag As Diagnostic
    Private m_ods As ds_EtatBL
    Private m_lstPresta As List(Of LgPrestation)
    Private m_ReportName As String

    Public Sub New(pDiag As Diagnostic)
        m_Path = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC
        m_oDiag = pDiag
        m_lstPresta = New List(Of LgPrestation)
        'Récupération du nom du modème Crystal pour un chargement ultérieur
        Using r1 As New cr_BL()
            m_ReportName = r1.ResourceName
            r1.Close()
        End Using
    End Sub



    Public Function AddPresta(pLib As String, pPU As Decimal, pQte As Decimal, pTxTVA As Decimal, pTotalHT As Decimal, pTotalTTC As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oPresta As LgPrestation = New LgPrestation(pLib:=pLib, pPU:=pPU, pQte:=pQte, pTxTVA:=pTxTVA, pTotalHT:=pTotalHT, pTotalTTC:=pTotalTTC)
            m_lstPresta.Add(oPresta)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("etatFacture.AddPresta ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Protected Overrides Function GenereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Using objReport As New ReportDocument()
                    objReport.Load(MySettings.Default.RepertoireParametres & "/" & m_ReportName)

                    objReport.SetDataSource(m_ods)
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    m_FileName = CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_BON_LIVRAISON) & ".pdf"
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
            CSDebug.dispError("EtatFacture.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try



            '
            m_ods = m_oDiag.generateDataSetForBL("")
            For Each oPresta As LgPrestation In m_lstPresta
                m_ods.Prestation.AddPrestationRow(Description:=oPresta.m_Libelle, TotalHT:=oPresta.m_TotalHT, TxTVA:=oPresta.m_TxTVA, TotalTTC:=oPresta.m_TotalTTC, Qte:=oPresta.m_qte, PrixUnitaire:=oPresta.m_PU)

            Next

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_finalisation ERR : " & ex.Message)
            m_ods = New ds_EtatBL()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
