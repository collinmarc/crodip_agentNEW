Imports CRODIPWS
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Collections.Generic
Imports System.IO


Public Class EtatFacture2
    Inherits EtatCrodip


    Private m_oFacture As Facture
    Private m_oAgent As Agent
    Private m_oStructure As [Structure]
    Private m_ods As ds_EtatFacture
    Private m_ReportName As String

    Public Sub New(pFacture As Facture, pAgent As Agent, pStructure As [Structure])
        m_Path = GlobalsCRODIP.CONST_PATH_EXP_FACTURE
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
                    m_FileName = Format(Date.Now, "yyyyMMddhhmmss") & "_" & m_oFacture.idFacture & "_" & CSDiagPdf.cleanString(m_oFacture.oExploit.raisonSociale) & "_" & "FACT" & ".pdf"
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
            oRow.idFacture = m_oFacture.idFacture
            oRow.DateFacture = m_oFacture.dateFacture
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
            oRow.EnteteFacture = m_oFacture.msgEntetete
            oRow.Commentaire = m_oFacture.Commentaire
            oRow.ModeReglement = m_oFacture.modeReglement
            oRow.DateEcheance = m_oFacture.dateEcheance
            oRow.CoordBanK = m_oStructure.CoordBancaires
            oRow.FReglee = m_oFacture.isReglee
            oRow.RefReglement = m_oFacture.refReglement
            oRow.PiedPage = m_oStructure.PiedPage
            oRow.MontantHT = m_oFacture.TotalHT
            oRow.MontantTVA = m_oFacture.TotalTVA
            oRow.MontantTTC = m_oFacture.TotalTTC
            oRow.TxTVA = m_oStructure.txTVA
            'If m_oFacture.oDiagnostic IsNot Nothing Then
            oRow.NumNatPulve = m_oFacture.numNatPulve
            oRow.NumDiag = m_oFacture.idDiag
            '   End If
            oRow.Fax = m_oFacture.oExploit.telephoneFax

            m_ods.Facture.AddFactureRow(oRow)

            m_oFacture.Lignes.ForEach(Sub(olg) m_ods.LigneFact.AddLigneFactRow(oRow,
                                                olg.categorie & " " & olg.prestation,
                                                olg.pu,
                                                olg.quantite,
                                                olg.totalHT,
                                                m_oStructure.txTVA,
                                                olg.idDiag, ""
                                                        )
                                    )

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("EtatFacture2.genereDS ERR : " & ex.Message)
            m_ods = New ds_EtatFacture()
            bReturn = False
        End Try


        Return bReturn

    End Function
End Class
