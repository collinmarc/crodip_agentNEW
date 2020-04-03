Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatFacture
    Inherits EtatCrodip

    ''' <summary>
    ''' classe interne représentant une ligne de prestation
    ''' </summary>
    ''' <remarks></remarks>
    Private Class facturePrestation
        Public m_Libelle As String
        Public m_PU As Decimal
        Public m_qte As Decimal
        Public m_TVA As Decimal
        Public m_TotalHT As Decimal
        Public m_TotalTTC As Decimal

        Public Sub New(pLib As String, pPU As String, pQte As Decimal, pTVA As Decimal, pTotalHT As Decimal, pTotalTTC As Decimal)
            m_Libelle = pLib
            m_PU = pPU
            m_qte = pQte
            m_TVA = pTVA
            m_TotalHT = pTotalHT
            m_TotalTTC = pTotalTTC

        End Sub
    End Class

    Private m_oDiag As Diagnostic
    Private m_ods As ds_EtatBL
    Private m_lstPresta As List(Of facturePrestation)
    Private m_Reference As String
    Private m_ReportName As String

    Private m_rsClient As String
    Private m_NomPrenomClient As String
    Private m_adresseClient As String
    Private m_cpClient As String
    Private m_communeClient As String
    Private m_Commentaire As String
    Public Sub New(pDiag As Diagnostic, pReference As String, pCommentaire As String, Optional pExploitation As Exploitation = Nothing)
        m_oDiag = pDiag
        If pExploitation Is Nothing Then
            'Par Défaut les Coordonnées sont celle prises dans le Diag
            m_rsClient = m_oDiag.proprietaireRaisonSociale
            m_NomPrenomClient = m_oDiag.proprietaireNom & " " & m_oDiag.proprietairePrenom
            m_adresseClient = m_oDiag.proprietaireAdresse
            m_cpClient = m_oDiag.proprietaireCodePostal
            m_communeClient = m_oDiag.proprietaireCommune
        Else
            m_rsClient = pExploitation.raisonSociale
            m_NomPrenomClient = pExploitation.nomExploitant & " " & pExploitation.prenomExploitant
            m_adresseClient = pExploitation.adresse
            m_cpClient = pExploitation.codePostal
            m_communeClient = pExploitation.commune
        End If

        m_lstPresta = New List(Of facturePrestation)
        m_Reference = pReference
        m_Commentaire = pCommentaire
        Using r1 As New cr_Facture()
            m_ReportName = r1.ResourceName
            r1.Close()
        End Using
    End Sub

    Public Function AddPresta(pLib As String, pPU As String, pQte As Decimal, pTVA As Decimal, pTotalHT As Decimal, pTotalTTC As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oPresta As facturePrestation = New facturePrestation(pLib, pPU, pQte, pTVA, pTotalHT, pTotalTTC)
            m_lstPresta.Add(oPresta)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("etatFacture.AddPresta ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


    Public Function GenereEtat() As Boolean
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
                m_FileName = Globals.CONST_PATH_EXP & CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_FACTURE) & ".pdf"
                CrDiskFileDestinationOptions.DiskFileName = m_FileName
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

            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(Globals.GLOB_STR_FACTURATIONCONFIG_FILENAME)
            Dim oStruct As Structuree
            oStruct = StructureManager.getStructureById(m_oDiag.organismePresId)


            'Génération du DataSet par le DiagNostic (Idem BL)
            m_ods = m_oDiag.generateDataSetForBL(m_Commentaire)
            m_ods.Proprio.Clear()
            m_ods.Proprio.AddProprioRow(RS:=m_rsClient,
                                        Nom:=m_NomPrenomClient,
                                        Adresse:=m_adresseClient,
                                        CodePostal:=m_cpClient,
                                        Commune:=m_communeClient,
                                        Fax:="",
                                        CodeAPE:="",
                                        Mail:="",
                                        Port:="",
                                        SIREN:="",
                                        Tel:="")
            For Each oPresta As facturePrestation In m_lstPresta
                m_ods.Prestation.AddPrestationRow(oPresta.m_Libelle, oPresta.m_TotalHT, oPresta.m_TVA, oPresta.m_TotalTTC, oPresta.m_qte, oPresta.m_PU)

            Next
            m_ods.Facture(0).refacture = m_Reference
            ' On ajoute le logo
            'Dim logoFilename As String = FACTURATION_XML_CONFIG.getElementValue("/root/logo_tn")
            Dim logoFilename As String = FACTURATION_XML_CONFIG.getElementValue("/root/logo")
            If Not File.Exists(logoFilename) Then
                logoFilename = Globals.CONST_PATH_IMG & Globals.CR_LOGO_DEFAULT_TN_NAME
            End If
            m_ods.Facture(0).LogoFileName = logoFilename
            Dim newImage As System.Drawing.Image = System.Drawing.Image.FromFile(logoFilename)
            Dim ms As New MemoryStream
            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

            m_ods.Facture(0).LogoFileName = logoFilename
            m_ods.Organisme(0).TelFax = oStruct.telephoneFixe & " / " & oStruct.telephoneFax
            m_ods.Organisme(0).SIREN = FACTURATION_XML_CONFIG.getElementValue("/root/siren")
            m_ods.Organisme(0).TVA = FACTURATION_XML_CONFIG.getElementValue("/root/tva")
            m_ods.Organisme(0).RCS = FACTURATION_XML_CONFIG.getElementValue("/root/rcs")
            m_ods.Facture(0).Logo = ms.ToArray()

            ' CLIENT

            ' FOOTER
            m_ods.Facture(0).Footer = FACTURATION_XML_CONFIG.getElementValue("/root/footer")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Diagnostic_finalisation ERR : " & ex.Message)
            m_ods = New ds_EtatBL()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
