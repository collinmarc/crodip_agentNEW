Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EtatRapportInspection
    Inherits EtatCrodip
    Implements IDisposable

    Private m_oDiag As Diagnostic
    Private m_oPulve As Pulverisateur
    Private m_ods As ds_Etat_RI

    Public Sub New()
        m_oPulve = PulverisateurManager.getPulverisateurById(m_oDiag.pulverisateurId)
    End Sub
    Public Sub New(pDiag As Diagnostic)
        m_oDiag = pDiag
        m_oPulve = PulverisateurManager.getPulverisateurById(m_oDiag.pulverisateurId)
    End Sub



    Public Function GenereEtat(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean
        Dim strReportName As String
        Try
            bReturn = genereDS()
            If (bReturn) Then

                Using r1 As New cr_RapportInspection
                    strReportName = r1.ResourceName
                    r1.Close()
                End Using

                m_oReportDocument = New ReportDocument
                m_oReportDocument.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)
                m_oReportDocument.SetDataSource(m_ods)
                m_oReportDocument.SetParameterValue("ModeSimplifie", Globals.GLOB_ENV_MODESIMPLIFIE)
                If pExportPDF Then
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    m_FileName = CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_RAPPORT_INSPECTION) & "_" & m_oDiag.id & ".pdf"
                    CrDiskFileDestinationOptions.DiskFileName = Globals.CONST_PATH_EXP & m_FileName
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
            CSDebug.dispError("EtatRapportInspection.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Génération des pages final du rapport d'inspection
    ''' utilisé uniquement pour les tests, car ces pages sont incluses dans le rapport d'inspection
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function FTO_GenereEtatDefauts() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = genereDSDefauts()
            If (bReturn) Then
                Dim objReport As ReportDocument
                Dim r1 As New crRapportInspectionFin2()
                Dim strReportName As String = r1.ResourceName

                objReport = New ReportDocument
                objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)

                objReport.SetDataSource(m_ods)
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                m_FileName = CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_RAPPORT_INSPECTION) & "_" & m_oDiag.id & ".pdf"
                CrDiskFileDestinationOptions.DiskFileName = Globals.CONST_PATH_EXP & m_FileName
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
            CSDebug.dispError("EtatRapportInspection.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try
            Dim oDiagRow As ds_Etat_RI.DiagnosticRow
            Dim oMaterielRow As ds_Etat_RI.MaterielRow
            Dim sCode As String = ""
            Dim sUtilisation As String = ""
            Dim sAcessoires As String = ""

            m_ods = New ds_Etat_RI()

            genereDSDefauts()
            'Calcul du nobre de page du rapport final (164 Lignes /pages)
            Dim nbPagefinal As Integer = Int(m_ods.Defauts.Rows.Count / 164) + 1

            sUtilisation = m_oDiag.pulverisateurModeUtilisation
            If m_oDiag.pulverisateurNbreExploitants <> "" And sUtilisation.ToUpper <> "INDIVIDUEL" Then
                sUtilisation = sUtilisation & " (" & m_oDiag.pulverisateurNbreExploitants & ")"
            End If
            If Not m_oPulve.isPulveAdditionnel Then
                If m_oDiag.pulverisateurIsCuveRincage Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " "
                    End If
                    sAcessoires = sAcessoires & "Cuve de rinçage"
                End If
                If m_oDiag.pulverisateurIsLanceLavageExterieur Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Lance de lavage extérieure"
                End If
                If m_oDiag.pulverisateurIsRotobuse Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Rotobuse"
                End If
                If m_oDiag.pulverisateurIsCuveIncorporation Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Cuve d'incorporation"
                End If
                If m_oDiag.pulverisateurIsRinceBidon Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Rince bidon"
                End If
                If m_oPulve.isAspirationExt Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Dispositif aspiration ext"
                End If
                'If m_oPulve.isDispoAntiRetour Then
                '    If Not String.IsNullOrEmpty(sAcessoires) Then
                '        sAcessoires = sAcessoires & " / "
                '    End If
                '    sAcessoires = sAcessoires & "Dispositif anti-retour"
                'End If
                If m_oPulve.isRincagecircuit Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Rincage circuits"
                End If
                If m_oPulve.isFiltrationAspiration Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Filtre aspiration"
                End If
                If m_oPulve.isFiltrationRefoulement Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Filtre refoulement"
                End If
                If m_oPulve.isFiltrationTroncons Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Filtre tronçons"
                End If
                If m_oPulve.isFiltrationBuses Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Filtre buses"
                End If
                If m_oPulve.isBidonLaveMain Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Bidon lave-main"
                End If
                If m_oPulve.isCoupureAutoTroncons Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Coupure auto tronçons"
                End If
                If m_oPulve.isReglageAutoHauteur Then
                    If Not String.IsNullOrEmpty(sAcessoires) Then
                        sAcessoires = sAcessoires & " / "
                    End If
                    sAcessoires = sAcessoires & "Reglage auto hauteur"
                End If
            End If
            'Dim s As String
            's = m_oDiag.pulverisateurNumNational
            's = m_oDiag.pulverisateurMarque.ToUpper()
            's = m_oDiag.pulverisateurModele.ToUpper()
            's = m_oDiag.pulverisateurCapacite.ToUpper()
            's = Trim(m_oDiag.pulverisateurLargeur + m_oDiag.pulverisateurNbRangs).ToUpper()
            's = m_oDiag.pulverisateurAnneeAchat
            's = m_oDiag.pulverisateurType.ToUpper()
            's = m_oDiag.categorie.ToUpper()
            's = m_oDiag.pulverisateurAttelage
            's = m_oDiag.pulverisateurRegulation.ToUpper()
            's = m_oDiag.pulverisateurRegulationOptions.Replace("|", ",").ToUpper()
            's = m_oDiag.buseType.ToUpper()
            's = m_oDiag.getbuseFonctionnement().ToUpper()
            's = m_oDiag.getPulverisation.ToUpper()
            's = m_oDiag.buseDebit.ToUpper()
            's = m_oDiag.pulverisateurEmplacementIdentification.ToUpper()
            's = m_oDiag.id
            's = m_oDiag.buseMarque.ToUpper()
            's = m_oDiag.buseModele.ToUpper()
            's = sUtilisation.ToUpper()
            's = sAcessoires.ToUpper()
            'Type d'information L = Largeur, R = Nbre de rangs
            Dim sTypeLargeurNbRang As String = "L"
            If Not String.IsNullOrEmpty(m_oDiag.pulverisateurNbRangs) Then
                sTypeLargeurNbRang = "R"
            End If
            Dim oPulvePrinc As New Pulverisateur
            If m_oPulve.isPulveAdditionnel Then
                oPulvePrinc = PulverisateurManager.getPulverisateurByNumNat(m_oPulve.pulvePrincipalNumNat, m_oDiag.proprietaireId)
            End If
            oMaterielRow = m_ods.Materiel.AddMaterielRow(m_oDiag.pulverisateurNumNational,
                                                         m_oDiag.pulverisateurMarque.ToUpper(),
                                                         m_oDiag.pulverisateurModele.ToUpper(),
                                                         m_oDiag.pulverisateurCapacite.ToUpper(),
                                                         Trim(m_oDiag.pulverisateurLargeur + m_oDiag.pulverisateurNbRangs).ToUpper(),
                                                         m_oDiag.pulverisateurAnneeAchat,
                                                         m_oDiag.pulverisateurType.ToUpper(),
                                                         m_oDiag.pulverisateurCategorie.ToUpper(),
                                                         m_oDiag.pulverisateurAttelage,
                                                         m_oDiag.pulverisateurRegulation.ToUpper() & m_oDiag.pulverisateurRegulationOptions.Replace("|", ",").ToUpper(),
                                                         m_oDiag.buseType.ToUpper(),
                                                         m_oDiag.buseFonctionnement.ToUpper(),
                                                         m_oDiag.pulverisateurPulverisation.ToUpper(),
                                                         m_oDiag.buseDebit.ToUpper(),
                                                         m_oDiag.pulverisateurEmplacementIdentification.ToUpper(),
                                                         m_oDiag.proprietaireNumeroSiren.ToUpper(),
                                                         NumeroControle:=m_oDiag.id,
                                                         BuseMarque:=m_oDiag.buseMarque.ToUpper(),
                                                         BuseModele:=m_oDiag.buseModele.ToUpper(),
                                                         Utilisation:=sUtilisation.ToUpper(),
                                                         Accessoires:=sAcessoires.ToUpper(),
                                                         TypeLargeurNbRangs:=sTypeLargeurNbRang,
                                                         AncienIdentifiant:=m_oDiag.pulverisateurAncienId,
                                                         isPulveAdditionnel:=m_oPulve.isPulveAdditionnel,
                                                         PrincAttelage:=oPulvePrinc.attelage,
                                                         PrincCapacite:=oPulvePrinc.capacite,
                                                         PrincCategorie:=oPulvePrinc.categorie,
                                                         PrincEmplIdent:=oPulvePrinc.emplacementIdentification,
                                                         PrincMarque:=oPulvePrinc.marque,
                                                         PrincModele:=oPulvePrinc.modele,
                                                         PrincType:=oPulvePrinc.type,
                                                         PrincNumNat:=oPulvePrinc.numeroNational)

            Dim dateLimiteControle As Date
            If String.IsNullOrEmpty(m_oDiag.pulverisateurDateProchainControle) Then
                dateLimiteControle = Now()
            Else
                dateLimiteControle = CDate(m_oDiag.pulverisateurDateProchainControle)
            End If


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


            ''            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

            oDiagRow = m_ods.Diagnostic.AddDiagnosticRow(m_oDiag.id, m_oDiag.organismeInspAgrement, CDate(m_oDiag.controleDateDebut), m_oDiag.controleLieu, CDate(m_oDiag.controleDateDebut).ToShortTimeString(), CDate(m_oDiag.controleDateFin).ToShortTimeString(), m_oDiag.controleIsPreControleProfessionel, m_oDiag.controleIsComplet, m_oDiag.controleInitialId, oMaterielRow, Conclusion:=m_oDiag.controleEtat, dateLimiteControle:=dateLimiteControle, DateEmission:=Date.Now,
                                                         DateControleInitial:=m_oDiag.getDateDernierControleDate(),
                                                         OrganismeInitial:=m_oDiag.organismeOriginePresNom,
                                                         InspecteurInitial:=m_oDiag.inspecteurOrigineNom & " " & m_oDiag.inspecteurOriginePrenom,
                                                         NbPageRFinal:=nbPagefinal,
                                                         Commentaire:=m_oDiag.Commentaire,
                                                         bSignAgent:=m_oDiag.bSignRIAgent,
                                                         DateSignAgent:=m_oDiag.dateSignRIAgent,
                                                         SignAgent:=m_oDiag.SignRIAgent,
                                                         bSignClient:=m_oDiag.bSignRIClient,
                                                         DateSignClient:=m_oDiag.dateSignRIClient,
                                                         SignClient:=m_oDiag.SignRIClient)
            'If img1 IsNot Nothing Then
            '    img1.Dispose()
            'End If
            'If img2 IsNot Nothing Then
            '    img2.Dispose()
            'End If

            Dim strPrestataire As String = ""
            Dim oStructure As Structuree
            Dim oAgent As Agent
            oAgent = AgentManager.getAgentById(m_oDiag.inspecteurId)
            If (oAgent.idStructure <> 0) Then
                oStructure = StructureManager.getStructureById(oAgent.idStructure)
                strPrestataire = oStructure.commentaire
            End If

            m_ods.Organisme.AddOrganismeRow(oDiagRow, m_oDiag.organismePresNom, m_oDiag.inspecteurNom & " " & m_oDiag.inspecteurPrenom, m_oDiag.inspecteurNumeroNational, strPrestataire)

            Dim strCumuldesErreurs As String
            If m_oDiag.diagnosticHelp571.ErreurGlobalePRSRND.HasValue Or m_oDiag.diagnosticHelp571.erreurGlobaleDEB.HasValue Then
                If m_oDiag.diagnosticHelp571.ErreurGlobalePRSRND.HasValue Then
                    strCumuldesErreurs = m_oDiag.diagnosticHelp571.ErreurGlobalePRSRND
                Else
                    strCumuldesErreurs = m_oDiag.diagnosticHelp571.ErreurGlobaleDEBRND
                End If
            Else
                strCumuldesErreurs = ""
            End If
            m_ods.Synthese.AddSyntheseRow(oDiagRow,
                                          m_oDiag.syntheseErreurMoyenneMano,
                                          m_oDiag.syntheseErreurMaxiMano,
                                          m_oDiag.syntheseErreurDebitmetre,
                                          m_oDiag.syntheseErreurMoyenneCinemometre,
                                          m_oDiag.syntheseUsureMoyenneBuses,
                                          m_oDiag.syntheseNbBusesUsees,
                                          m_oDiag.synthesePerteChargeMoyenne,
                                          m_oDiag.synthesePerteChargeMaxi,
                                          strCumuldesErreurs)
            m_ods.Proprietaire.AddProprietaireRow(m_oDiag.proprietaireRaisonSociale, m_oDiag.proprietaireNom & " " & m_oDiag.proprietairePrenom, m_oDiag.proprietaireRepresentant, m_oDiag.proprietaireAdresse, m_oDiag.proprietaireCodePostal, m_oDiag.proprietaireCommune, oMaterielRow, m_oDiag.proprietaireCodeApe)
            '''DiagnosticItems
            Dim bDiagItemOPresent As Boolean = False
            Dim bDiagItemPCPresent As Boolean = False
            For Each oDiagItem As DiagnosticItem In m_oDiag.diagnosticItemsLst.items
                If oDiagItem.itemCodeEtat <> DiagnosticItem.EtatDiagItemOK And oDiagItem.itemCodeEtat <> DiagnosticItem.EtatDiagItemABSENCE Then
                    sCode = oDiagItem.idItem & oDiagItem.itemValue
                    If sCode.Length <= 4 Then
                        sCode = "  " & sCode
                    End If
                    If oDiagItem.cause <> "" And oDiagItem.cause <> "0" And oDiagItem.cause <> "-1" Then
                        sCode = sCode & "(" & oDiagItem.cause & ")"
                    End If
                    If oDiagItem.LibelleLong = "" Then
                        oDiagItem.LibelleLong = "--"
                    End If
                    m_ods.Diagitem.AddDiagitemRow(oDiagRow, sCode, oDiagItem.LibelleLong, oDiagItem.itemCodeEtat)
                    If oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMINEUR Then
                        bDiagItemOPresent = True
                    End If
                    If oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR Or oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJPRELIM Then
                        bDiagItemPCPresent = True
                    End If
                End If
            Next
            If Not bDiagItemOPresent Then
                m_ods.Diagitem.AddDiagitemRow(oDiagRow, "", "", DiagnosticItem.EtatDiagItemMINEUR)
            End If
            If Not bDiagItemPCPresent Then
                m_ods.Diagitem.AddDiagitemRow(oDiagRow, "", "", DiagnosticItem.EtatDiagItemMAJEUR)
            End If
            bReturn = True



        Catch ex As Exception
            CSDebug.dispError("EtatRapportInspection.GenereDS ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function

    Public Function genereDSDefauts() As Boolean
        Dim pFichierParametrage As String
        Dim bReturn As Boolean
        Dim dOrdre As Decimal
        Try
            If m_ods Is Nothing Then
                m_ods = New ds_Etat_RI()
            End If
            pFichierParametrage = My.Settings.RepertoireParametres & "/" & m_oPulve.getParamDiag().fichierConfig

            Dim olst As New CRODIP_ControlLibrary.LstParamCtrlDiag()
            If olst.readXML(pFichierParametrage) Then
                'Parours de la liste des params lus
                For Each oParam As CRODIP_ControlLibrary.ParamCtrlDiag In olst.ListeParam
                    If oParam.DefaultCategorie <> CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK And oParam.Actif Then
                        dOrdre = 0
                        Dim npos1 As Integer = oParam.Code.IndexOf(".")
                        If npos1 > 0 Then
                            'Il y a au moins un .
                            'Recherche des suivants
                            Dim npos2 As Integer = oParam.Code.Substring(npos1 + 1).IndexOf(".")
                            If npos2 > 0 Then
                                'Il y a plusieurs .
                                Dim sFin As String = oParam.Code.Substring(npos1 + 1).Replace(".", "")
                                Dim sCode As String = oParam.Code.Substring(0, npos1 + 1) & sFin
                                dOrdre = CDec(sCode.Replace(".", ","))
                            Else
                                'Il n'y qu'un seul .
                                dOrdre = CDec(oParam.Code.Replace(".", ","))
                            End If
                        Else
                            'Pas de .
                            dOrdre = CDec(oParam.Code)
                            If m_ods.Defauts.Rows.Count > 0 Then
                                m_ods.Defauts.AddDefautsRow("", "", dOrdre, 0)
                            End If
                        End If
                        Dim nNiveau As Integer
                        nNiveau = 0
                        For i As Integer = 1 To oParam.Code.Length
                            If Mid(oParam.Code, i, 1) = "." Then
                                nNiveau = nNiveau + 1
                            End If
                        Next i
                        m_ods.Defauts.AddDefautsRow(oParam.Code, oParam.Libelle, dOrdre, nNiveau)
                    End If
                Next
                'le 194 correspond au dernier elément de la Première page
                Dim orow As DataRow = m_ods.Defauts.Select("", "Ordre")(194)
                'BUG CRYSTAL REPORT
                'On ajoute des défauts fictifs coorespondant à la taille de l'entete de page
                Dim dRupture As Decimal = orow.Field(Of Decimal)("Ordre")
                dRupture = dRupture + 0.00001
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)
                m_ods.Defauts.AddDefautsRow("", "test", dRupture, 3)

                'Pour pallier à un bug de pagination il faut avoir aumoins 312 Enr !!!
                While m_ods.Defauts.Rows.Count <= 312
                    m_ods.Defauts.AddDefautsRow("", "test", dOrdre, 3)
                    'les défauts marqués test seront imprimés en Blanc/blanc
                    dOrdre = dOrdre + 1
                End While
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostique.LectureParametresAffichage ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn


    End Function

    Public Sub Dispose() Implements IDisposable.Dispose
        If m_oReportDocument IsNot Nothing Then
            m_oReportDocument.Dispose()
        End If
    End Sub
End Class
