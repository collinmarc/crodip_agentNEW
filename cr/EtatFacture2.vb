Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatFacture2
    Inherits EtatCrodip


    Private m_oFacture As Facture
    Private m_oAgent As Agent
    Private m_oStructure As Structuree
    Private m_ods As ds_EtatFacture
    Private m_ReportName As String

    Public Sub New(pFacture As Facture, pAgent As Agent, pStructure As Structuree)
        m_Path = GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC
        m_oFacture = pFacture
        m_oAgent = pAgent
        If pStructure Is Nothing Then
            m_oStructure = StructureManager.getStructureById(m_oAgent.idStructure)
        Else
            m_oStructure = pStructure
        End If
        Using r1 As New cr_Facture2()
            m_ReportName = r1.ResourceName
            r1.Dispose()
        End Using
        m_ods = New ds_EtatFacture
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
                    m_FileName = CSDiagPdf.makeFilename(m_oFacture.oDiagnostic.pulverisateurId, CSDiagPdf.TYPE_FACTURE) & ".pdf"
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

            Dim FACTURATION_XML_CONFIG As CSXml = New CSXml(GlobalsCRODIP.GLOB_STR_FACTURATIONCONFIG_FILENAME)


            ' On ajoute le logo
            'Dim logoFilename As String = FACTURATION_XML_CONFIG.getElementValue("/root/logo_tn")
            Dim logoFilename As String = FACTURATION_XML_CONFIG.getElementValue("/root/logo")
            If Not File.Exists(logoFilename) Then
                logoFilename = GlobalsCRODIP.CONST_PATH_IMG & GlobalsCRODIP.CR_LOGO_DEFAULT_TN_NAME
            End If
            Dim oRow As ds_EtatFacture.FactureRow
            oRow = m_ods.Facture.NewFactureRow()
            oRow.refFacture = m_oFacture.RefFacture
            oRow.DateFacture = m_oFacture.DateFacture
            oRow.logoFileName = logoFilename
            Dim newImage As System.Drawing.Image = System.Drawing.Image.FromFile(logoFilename)
            Dim ms As New MemoryStream
            newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
            oRow.logo = ms.ToArray()
            oRow.NomOrga = m_oStructure.nom
            oRow.AdresseOrga = m_oStructure.adresse
            oRow.CPOrga = m_oStructure.codePostal
            oRow.CommuneOrga = m_oStructure.commune
            oRow.TelOrga = m_oStructure.telephoneFixe
            oRow.SIRENORGA = m_oStructure.SIREN
            oRow.TVAOrga = m_oStructure.TVA
            oRow.RCSOrga = m_oStructure.RCS
            oRow.RSCli = m_oFacture.oExploit.raisonSociale
            oRow.NomCli = m_oFacture.oExploit.nomExploitant & " " & m_oFacture.oExploit.prenomExploitant
            oRow.AdresseCli = m_oFacture.oExploit.adresse
            oRow.CPCli = m_oFacture.oExploit.codePostal
            oRow.CommuneCli = m_oFacture.oExploit.commune
            oRow.TelFixeCli = m_oFacture.oExploit.telephoneFixe
            oRow.TelPortCli = m_oFacture.oExploit.telephonePortable
            oRow.mailCli = m_oFacture.oExploit.eMail
            oRow.EnteteFacture = m_oFacture.MsgEntetete
            If m_oFacture.oDiagnostic IsNot Nothing Then
                oRow.NumNatPulve = m_oFacture.oDiagnostic.pulverisateurNumNational
                oRow.NumDiag = m_oFacture.oDiagnostic.id
            End If
            oRow.Commentaire = m_oFacture.Commentaire
            oRow.ModeReglement = m_oFacture.Modereglement
            oRow.DateEcheance = m_oFacture.DateEcheance
            oRow.CoordBanK = m_oStructure.CoordBank
            oRow.FReglee = m_oFacture.Reglee
            oRow.RefReglement = m_oFacture.RefPaiement
            oRow.PiedPage = m_oStructure.PiedPage
            oRow.MontantHT = m_oFacture.TotalHT
            oRow.MontantTVA = m_oFacture.TotalTVA
            oRow.MontantTTC = m_oFacture.TotalTTC
            oRow.TxTVA = m_oStructure.TxTVA

            m_ods.Facture.AddFactureRow(oRow)

            m_oFacture.Lignes.ForEach(Sub(olg) m_ods.LigneFact.AddLigneFactRow(oRow,
                                                olg.Categorie & " " & olg.Prestation,
                                                olg.PU,
                                                olg.Quantite,
                                                olg.TotalHT,
                                                m_oStructure.TxTVA
                                                )
                                    )
            'For Each oLg As lgContratCommercial In m_oFacture.Lignes
            '    m_ods.LigneFact.AddLigneFactRow(oRow,
            '                                    oLg.Categorie & " " & oLg.Prestation,
            '                                    oLg.PU,
            '                                    oLg.Quantite,
            '                                    oLg.TotalHT,
            '                                    m_oStructure.TxTVA
            '                                    )
            'Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("EtatFacture2.genereDS ERR : " & ex.Message)
            m_ods = New ds_EtatFacture()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
