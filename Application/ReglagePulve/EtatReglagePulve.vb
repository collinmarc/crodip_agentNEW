Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EtatReglagePulve
    Inherits EtatCrodip

    Private m_oDiag As RPDiagnostic
    Private m_ods As ds_Etat_ReglagePulve

    Public Sub New(pDiag As RPDiagnostic)
        m_oDiag = pDiag
        m_oDiag.FileName = getFileName()
    End Sub

    Public Function getDs() As DataSet
        Return m_ods
    End Function
    Public Overrides Function getFileName() As String
        If String.IsNullOrEmpty(m_FileName) Then
            m_FileName = "Rapport" & Format(Date.Now, "yyyyMMddhhmmss") & ".pdf"
        End If
        Return m_FileName
    End Function


    ''' <summary>
    ''' Génération de l'état reglage Pulve
    ''' Attention : Les objets Lignes doivent être correctement nommés
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GenereEtat() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Dim objReport As ReportDocument
                Dim objsubReport As ReportDocument
                Dim r1 As New cr_ReglagePulve()
                Dim strReportName As String = r1.ResourceName
                r1 = Nothing
                Dim o As New cr_ReglagePulveSyntheseBuses15
                Dim strSubReportName As String = o.ResourceName
                o = Nothing
                objReport = New ReportDocument
                objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)
                If m_oDiag.diagnosticBusesList.Liste.Count > 0 Then
                    objsubReport = objReport.Subreports(strSubReportName)
                    CSDebug.dispInfo(objsubReport.Name)
                    If objsubReport IsNot Nothing Then
                        Dim oLineMax15 As LineObject = Nothing
                        Dim oLineMin15 As LineObject = Nothing
                        Dim oLineMax10 As LineObject = Nothing
                        Dim oLineMin10 As LineObject = Nothing
                        Try
                            oLineMax15 = objsubReport.ReportDefinition.ReportObjects("Line8")
                            oLineMin15 = objsubReport.ReportDefinition.ReportObjects("Line10")
                            oLineMax10 = objsubReport.ReportDefinition.ReportObjects("Line12")
                            oLineMin10 = objsubReport.ReportDefinition.ReportObjects("Line13")
                        Catch ex As Exception

                        End Try
                        If m_oDiag.diagnosticBusesList.Liste(0).ecartTolere = 10 Then
                            'Si l'écart toléré est de 10, on cache les limites de 15
                            If oLineMax15 IsNot Nothing Then
                                oLineMax15.LineStyle = LineStyle.NoLine
                            End If
                            If oLineMin15 IsNot Nothing Then
                                oLineMin15.LineStyle = LineStyle.NoLine
                            End If
                        Else
                            'Si l'écart toléré est de 15, on cache les limites de 10
                            If oLineMax10 IsNot Nothing Then
                                oLineMax10.LineStyle = LineStyle.NoLine
                            End If
                            If oLineMin10 IsNot Nothing Then
                                oLineMin10.LineStyle = LineStyle.NoLine
                            End If

                        End If
                    End If
                End If

                objReport.SetDataSource(m_ods)
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                CrDiskFileDestinationOptions.DiskFileName = m_oDiag.FilePath & "/" & getFileName()
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
            CSDebug.dispError("EtatReglagePulve.GenereEtat ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Génération udu dataSet qui servira de base au rapport
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function genereDS() As Boolean
        Dim bReturn As Boolean
        Try
            ''' Generation du dataset en vue la la construction du rapport de synthese

            m_ods = New ds_Etat_ReglagePulve()
            Dim oDiagRow As ds_Etat_ReglagePulve.DiagnosticRow
            Dim oMaterielRow As ds_Etat_ReglagePulve.MaterielRow

            Dim sCode As String = ""
            Dim sUtilisation As String = ""
            Dim sAcessoires As String = ""
            sUtilisation = m_oDiag.pulverisateurModeUtilisation
            If m_oDiag.pulverisateurNbreExploitants <> "" Then
                sUtilisation = sUtilisation & " (" & m_oDiag.pulverisateurNbreExploitants & ")"
            End If
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
            Dim sTypeLargeurNbRang As String = "L"
            If Not String.IsNullOrEmpty(m_oDiag.pulverisateurNbRangs) Then
                sTypeLargeurNbRang = "R"
            End If

            m_ods.EtatReglagePulve.AddEtatReglagePulveRow(idDiag:=m_oDiag.id,
                                                          bSectionEntete:=m_oDiag.bSectionEntete,
                                                          ReferenceAgent:=m_oDiag.Reference,
                                                          Commentaires:=m_oDiag.Commentaires,
                                                          ImagePath:=m_oDiag.imagePath,
                                                          bSectionDefauts:=m_oDiag.bSectionDefauts,
                                                          bSectionSyntheseMesures:=m_oDiag.bSectionSyntheseMesures,
                                                          bSectionSyntheseBuses:=m_oDiag.bSectionSyntheseBuses,
                                                          bSectionSynthese833:=m_oDiag.bSectionSynthese833,
                                                          bSectionSynthese542:=m_oDiag.bSectionSynthese542,
                                                          bSectionCapteurVitesse:=m_oDiag.bSectionSyntheseCapteurVitesse,
                                                          bSectionCapteurDebitmetre:=m_oDiag.bSectionSyntheseCapteurDebit,
                                                          bSectionCalculs:=m_oDiag.bSectionCalculs,
                                                          bSectionCommentaires:=m_oDiag.bSectionCommentaires)


            oMaterielRow = m_ods.Materiel.AddMaterielRow(Identifiant:=m_oDiag.pulverisateurNumNational, _
                                                         Marque:=m_oDiag.pulverisateurMarque.ToUpper(), _
                                                         Modele:=m_oDiag.pulverisateurModele.ToUpper(), _
                                                         Capacite:=m_oDiag.pulverisateurCapacite.ToUpper(),
                                                         LargeurNbRangs:=Trim(m_oDiag.pulverisateurLargeur + m_oDiag.pulverisateurNbRangs).ToUpper(),
                                                         Annee:=m_oDiag.pulverisateurAnneeAchat,
                                                         Type:=m_oDiag.pulverisateurType.ToUpper(),
                                                         Categorie:=m_oDiag.pulverisateurCategorie.ToUpper(),
                                                         Attelage:=m_oDiag.pulverisateurAttelage,
                                                         Regulation:=m_oDiag.pulverisateurRegulation.ToUpper() & m_oDiag.pulverisateurRegulationOptions.Replace("|", ",").ToUpper(),
                                                         TypeBuse:=m_oDiag.buseType.ToUpper(),
                                                         Fonctionnement:=m_oDiag.buseFonctionnement.ToUpper(),
                                                         TypeDeJet:=m_oDiag.pulverisateurPulverisation.ToUpper(),
                                                         DebitBuse:=m_oDiag.buseDebit.ToUpper(),
                                                         EmplacementIdentifiant:=m_oDiag.pulverisateurEmplacementIdentification.ToUpper(),
                                                         idDiag:=m_oDiag.id,
                                                         BuseMarque:=m_oDiag.buseMarque.ToUpper(),
                                                         BuseModele:=m_oDiag.buseModele.ToUpper(),
                                                         Utilisation:=sUtilisation.ToUpper(),
                                                         Accessoires:=sAcessoires.ToUpper(),
                                                         TypeLargeurNbRangs:=sTypeLargeurNbRang)

            m_ods.Proprietaire.AddProprietaireRow(RaisonSociale:=m_oDiag.proprietaireRaisonSociale, _
                                                  Nom:=m_oDiag.proprietaireNom & " " & m_oDiag.proprietairePrenom,
                                                  Representant:=m_oDiag.proprietaireRepresentant,
                                                  Adresse:=m_oDiag.proprietaireAdresse,
                                                  CodePostal:=m_oDiag.proprietaireCodePostal,
                                                  Ville:=m_oDiag.proprietaireCommune,
                                                  APE:=m_oDiag.proprietaireCodeApe,
                                                  idDiag:=m_oDiag.id,
                                                  SIREN:=m_oDiag.proprietaireNumeroSiren)

            'Diagnostic
            Dim dateLimiteControle As Date
            If String.IsNullOrEmpty(m_oDiag.pulverisateurDateProchainControle) Then
                dateLimiteControle = Now()
            Else
                dateLimiteControle = CDate(m_oDiag.pulverisateurDateProchainControle)
            End If
            oDiagRow = m_ods.Diagnostic.AddDiagnosticRow(NumeroControle:=m_oDiag.id, dateControle:=CDate(m_oDiag.controleDateDebut), IdentifiantMateriel:=m_oDiag.pulverisateurNumNational)
            '''DiagnosticItems
            Dim bDiagItemOPresent As Boolean = False
            Dim bDiagItemPCPresent as Boolean = False
            For Each oDiagItem As DiagnosticItem In m_oDiag.diagnosticItemsLst.items
                If oDiagItem.itemCodeEtat <> "B" Then
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
                    m_ods.Diagitem.AddDiagitemRow(NumeroControle:=m_oDiag.id, code:=sCode, Libelle:=oDiagItem.LibelleLong, Etat:=oDiagItem.itemCodeEtat)
                    If oDiagItem.itemCodeEtat = "O" Then
                        bDiagItemOPresent = True
                    End If
                    If oDiagItem.itemCodeEtat = "P" Or oDiagItem.itemCodeEtat = "X" Then
                        bDiagItemPCPresent = True
                    End If
                End If
            Next
            If Not bDiagItemOPresent Then
                m_ods.Diagitem.AddDiagitemRow(m_oDiag.id, "", "", "O")
            End If
            If Not bDiagItemPCPresent Then
                m_ods.Diagitem.AddDiagitemRow(m_oDiag.id, "", "", "P")
            End If
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

            'Synthese des mesures
            m_ods.Synthese.AddSyntheseRow(m_oDiag.id,
                                          m_oDiag.syntheseErreurMoyenneMano,
                                          m_oDiag.syntheseErreurMaxiMano,
                                          m_oDiag.syntheseErreurDebitmetre,
                                          m_oDiag.syntheseErreurMoyenneCinemometre,
                                          m_oDiag.syntheseUsureMoyenneBuses,
                                          m_oDiag.syntheseNbBusesUsees,
                                          m_oDiag.synthesePerteChargeMoyenne,
                                          m_oDiag.synthesePerteChargeMaxi,
                                          strCumuldesErreurs)

            'Syntheses des mesures buses
            'Buses
            Dim pctBusesUsees As Decimal
            Dim debit As Decimal
            For Each oLot As DiagnosticBuses In m_oDiag.diagnosticBusesList.Liste
                If oLot.nombre <> 0 Then
                    pctBusesUsees = Math.Round((oLot.nombrebusesusees / oLot.nombre) * 100, 2)
                Else
                    pctBusesUsees = 100%
                End If
                m_ods.debitBuses_infos.AdddebitBuses_infosRow(debitNominal:=oLot.debitNominal, couleur:=oLot.couleur, ecartTolere:=oLot.ecartTolere, debitMoyen:=oLot.debitMoyen, marque:=oLot.marque, nombreBuses:=oLot.nombre, IdLot:=oLot.idLot, DebitMax:=oLot.debitMax, DebitMin:=oLot.debitMin, nombreBusesUsees:=oLot.nombrebusesusees, type:=m_oDiag.buseType, pressionControle:=m_oDiag.manometrePressionTravailD, usuremoyenne:=m_oDiag.syntheseUsureMoyenneBusesD, idDiag:=m_oDiag.id, Fonctionnement:=m_oDiag.buseFonctionnement, modele:=oLot.genre, calibre:=oLot.calibre, PctBusesUsees:=pctBusesUsees, conclusion:=oLot.Resultat)
                For Each oDetail As DiagnosticBusesDetail In oLot.diagnosticBusesDetail.Liste
                    Dim dDebit As Decimal
                    Dim dEcart As Decimal
                    If IsNumeric(oDetail.debit) Then
                        dDebit = CDec(oDetail.debit)
                    End If
                    If IsNumeric(oDetail.ecart) Then
                        dEcart = CDec(oDetail.ecart)
                    End If
                    m_ods.debitBuses.AdddebitBusesRow(numBuse:=oDetail.idBuse + 1, IdLot:=oDetail.idLot, debit:=dDebit, ecartPourcentage:=dEcart, ssgroupe:=0, idDiag:=m_oDiag.id)
                Next

            Next

            'Controle des Pressions (833)
            m_ods.Synthese833.AddSynthese833Row(idDiag:=m_oDiag.id, NbreNiveaux:=m_oDiag.controleNbreNiveaux, NbreTroncons:=m_oDiag.controleNbreTroncons)
            If m_oDiag.relevePression833_1 IsNot Nothing Then
                m_ods.synthese833Pression.Addsynthese833PressionRow(idDiag:=m_oDiag.id, nPression:=1, PressionMesure:=m_oDiag.relevePression833_1.PressionMano, EcartBars:=m_oDiag.relevePression833_1.Result_EcartBars(), MoyennePression:=m_oDiag.relevePression833_1.Result_Moyenne(), PressionParDefaut:=m_oDiag.relevePression833_1.PressionManoPourCalculDefaut)
            End If
            If m_oDiag.relevePression833_2 IsNot Nothing Then
                m_ods.synthese833Pression.Addsynthese833PressionRow(idDiag:=m_oDiag.id, nPression:=2, PressionMesure:=m_oDiag.relevePression833_2.PressionMano, EcartBars:=m_oDiag.relevePression833_2.Result_EcartBars(), MoyennePression:=m_oDiag.relevePression833_2.Result_Moyenne(), PressionParDefaut:=m_oDiag.relevePression833_2.PressionManoPourCalculDefaut)
            End If
            If m_oDiag.relevePression833_3 IsNot Nothing Then
                m_ods.synthese833Pression.Addsynthese833PressionRow(idDiag:=m_oDiag.id, nPression:=3, PressionMesure:=m_oDiag.relevePression833_3.PressionMano, EcartBars:=m_oDiag.relevePression833_3.Result_EcartBars(), MoyennePression:=m_oDiag.relevePression833_3.Result_Moyenne(), PressionParDefaut:=m_oDiag.relevePression833_3.PressionManoPourCalculDefaut)
            End If
            If m_oDiag.relevePression833_4 IsNot Nothing Then
                m_ods.synthese833Pression.Addsynthese833PressionRow(idDiag:=m_oDiag.id, nPression:=4, PressionMesure:=m_oDiag.relevePression833_4.PressionMano, EcartBars:=m_oDiag.relevePression833_4.Result_EcartBars(), MoyennePression:=m_oDiag.relevePression833_4.Result_Moyenne(), PressionParDefaut:=m_oDiag.relevePression833_4.PressionManoPourCalculDefaut)
            End If
            For Each oMesure833 As DiagnosticTroncons833 In m_oDiag.diagnosticTroncons833.diagnosticTroncons833
                m_ods.synthese833Detail.Addsynthese833DetailRow(idDiag:=m_oDiag.id, nPression:=oMesure833.idPression, nDetail:=oMesure833.idColumn, PressionLue:=oMesure833.pressionSortie, EcartBar:=oMesure833.EcartBar, EcartPct:=oMesure833.Ecartpct, MoyenneAutrePression:=oMesure833.MoyenneAutrePression, HeterogeneiteBar:=oMesure833.HeterogeneiteBar, HeterogeneitePct:=oMesure833.HeterogeneitePct, nNiveau:=oMesure833.nNiveau, nTroncon:=oMesure833.nTroncon)
            Next

            'Controle du Manometre 542
            m_ods.Mano542.AddMano542Row(idDiag:=m_oDiag.id, useCalibrateur:=m_oDiag.controleUseCalibrateur, EcartMaxi:=m_oDiag.syntheseErreurMaxiManoD, EcartMoyen:=m_oDiag.syntheseErreurMoyenneManoD, Resultat:=m_oDiag.syntheseImprecision542)
            For Each oMesure542 As DiagnosticMano542 In m_oDiag.diagnosticMano542List.diagnosticMano542
                m_ods.Mano542Detail.AddMano542DetailRow(PressionPulve:=oMesure542.pressionPulved, pressionControle:=oMesure542.pressionControled, Ecart:=oMesure542.Ecart, Imprecision:=oMesure542.Erreur.ToString(), idDiag:=m_oDiag.id)
            Next

            'Capteur de vitesse 551
            If m_oDiag.diagnosticHelp551.HasValue() Then
                m_ods.SyntheseCapteurVitesse.AddSyntheseCapteurVitesseRow(idDiag:=m_oDiag.id, ErreurMoyenne:=m_oDiag.diagnosticHelp551.ErreurMoyenne, type:=m_oDiag.diagnosticHelp551.iditem, _
                                                                            Distance1:=m_oDiag.diagnosticHelp551.Distance1, VitesseLue1:=m_oDiag.diagnosticHelp551.VitesseLue1, Temps1:=m_oDiag.diagnosticHelp551.Temps1, Ecart1:=m_oDiag.diagnosticHelp551.Ecart1, VitesseReelle1:=m_oDiag.diagnosticHelp551.VitesseReelle1, _
                                                                            Distance2:=m_oDiag.diagnosticHelp551.Distance2, VitesseLue2:=m_oDiag.diagnosticHelp551.VitesseLue2, Temps2:=m_oDiag.diagnosticHelp551.Temps2, Ecart2:=m_oDiag.diagnosticHelp551.Ecart2, VitesseReelle2:=m_oDiag.diagnosticHelp551.VitesseReelle2, Conclusion:=m_oDiag.diagnosticHelp551.Resultat)
            End If
            'Capteur de vitesse 5621
            If m_oDiag.diagnosticHelp5621.HasValue() Then
                m_ods.SyntheseCapteurVitesse.AddSyntheseCapteurVitesseRow(idDiag:=m_oDiag.id, ErreurMoyenne:=m_oDiag.diagnosticHelp5621.ErreurMoyenne, type:=m_oDiag.diagnosticHelp5621.iditem, _
                                                                            Distance1:=m_oDiag.diagnosticHelp5621.Distance1, VitesseLue1:=m_oDiag.diagnosticHelp5621.VitesseLue1, Temps1:=m_oDiag.diagnosticHelp5621.Temps1, Ecart1:=m_oDiag.diagnosticHelp5621.Ecart1, VitesseReelle1:=m_oDiag.diagnosticHelp5621.VitesseReelle1, _
                                                                            Distance2:=m_oDiag.diagnosticHelp5621.Distance2, VitesseLue2:=m_oDiag.diagnosticHelp5621.VitesseLue2, Temps2:=m_oDiag.diagnosticHelp5621.Temps2, Ecart2:=m_oDiag.diagnosticHelp5621.Ecart2, VitesseReelle2:=m_oDiag.diagnosticHelp5621.VitesseReelle2, Conclusion:=m_oDiag.diagnosticHelp5621.Resultat)
            End If

            'Controle du DébitMetre (552
            If m_oDiag.diagnosticHelp552.hasValue() Then
                m_ods.SyntheseDebitmetre.AddSyntheseDebitmetreRow(idDiag:=m_oDiag.id, ErreurDebitMetre:=m_oDiag.diagnosticHelp552.ErreurDebitMetre, type:=m_oDiag.diagnosticHelp552.iditem, _
                                                                    NbreBuses1:=m_oDiag.diagnosticHelp552.NbBuses_m1, _
                                                                    NbreBuses2:=m_oDiag.diagnosticHelp552.NbBuses_m2, _
                                                                    NbreBuses3:=m_oDiag.diagnosticHelp552.NbBuses_m3, _
                                                                    PressionBar1:=m_oDiag.diagnosticHelp552.Pression_m1, _
                                                                    PressionBar2:=m_oDiag.diagnosticHelp552.Pression_m2, _
                                                                    PressionBar3:=m_oDiag.diagnosticHelp552.Pression_m3, _
                                                                    DebitAfficheur1:=m_oDiag.diagnosticHelp552.DebitAfficheur_m1, _
                                                                    DebitAfficheur2:=m_oDiag.diagnosticHelp552.DebitAfficheur_m2, _
                                                                    DebitAfficheur3:=m_oDiag.diagnosticHelp552.DebitAfficheur_m3, _
                                                                    EcartPct1:=m_oDiag.diagnosticHelp552.EcartPct_m1, _
                                                                    EcartPct2:=m_oDiag.diagnosticHelp552.EcartPct_m2, _
                                                                    EcartPct3:=m_oDiag.diagnosticHelp552.EcartPct_m3, _
                                                                    DebitEtalon1:=m_oDiag.diagnosticHelp552.DebitEtalon_m1,
                                                                    DebitEtalon2:=m_oDiag.diagnosticHelp552.DebitEtalon_m2,
                                                                    DebitEtalon3:=m_oDiag.diagnosticHelp552.DebitEtalon_m3,
                                                                    conclusion:=m_oDiag.diagnosticHelp552.Resultat _
                                                                    )
            End If
            If m_oDiag.diagnosticHelp5622.hasValue() Then
                m_ods.SyntheseDebitmetre.AddSyntheseDebitmetreRow(idDiag:=m_oDiag.id, ErreurDebitMetre:=m_oDiag.diagnosticHelp5622.ErreurDebitMetre, type:=m_oDiag.diagnosticHelp5622.iditem, _
                                                                    NbreBuses1:=m_oDiag.diagnosticHelp5622.NbBuses_m1, _
                                                                    NbreBuses2:=m_oDiag.diagnosticHelp5622.NbBuses_m2, _
                                                                    NbreBuses3:=m_oDiag.diagnosticHelp5622.NbBuses_m3, _
                                                                    PressionBar1:=m_oDiag.diagnosticHelp5622.Pression_m1, _
                                                                    PressionBar2:=m_oDiag.diagnosticHelp5622.Pression_m2, _
                                                                    PressionBar3:=m_oDiag.diagnosticHelp5622.Pression_m3, _
                                                                    DebitAfficheur1:=m_oDiag.diagnosticHelp5622.DebitAfficheur_m1, _
                                                                    DebitAfficheur2:=m_oDiag.diagnosticHelp5622.DebitAfficheur_m2, _
                                                                    DebitAfficheur3:=m_oDiag.diagnosticHelp5622.DebitAfficheur_m3, _
                                                                    EcartPct1:=m_oDiag.diagnosticHelp5622.EcartPct_m1, _
                                                                    EcartPct2:=m_oDiag.diagnosticHelp5622.EcartPct_m2, _
                                                                    EcartPct3:=m_oDiag.diagnosticHelp5622.EcartPct_m3, _
                                                                    DebitEtalon1:=m_oDiag.diagnosticHelp5622.DebitEtalon_m1,
                                                                    DebitEtalon2:=m_oDiag.diagnosticHelp5622.DebitEtalon_m2,
                                                                    DebitEtalon3:=m_oDiag.diagnosticHelp5622.DebitEtalon_m3,
                                                                    conclusion:=m_oDiag.diagnosticHelp5622.Resultat _
                                                                    )
            End If

            'Feuille de Calcul
            m_ods.CalculVolumeha.AddCalculVolumehaRow(LargeurPlantation:=m_oDiag.CalcLargeurPlantation,
                                                      VitesseRotation:=m_oDiag.CalcVitesseRotation,
                                                      RegimeMoteur:=m_oDiag.CalcRegimeMoteur,
                                                      nbBusesDescente:=m_oDiag.CalcNbreBusesParDescente,
                                                      nbdescentes:=m_oDiag.CalcNbreDescentes,
                                                      nbreNiveauDescente:=m_oDiag.CalcNbreNiveauParDescente,
                                                    EmplacementPriseAir:=m_oDiag.CalcEmplacementPriseAir,
                                                    PressionMesure:=m_oDiag.CalcPressionDeMesure,
                                                    DébitMoyenPM:=m_oDiag.CalcDebitMoyenPM,
                                                    PressionTravail:=m_oDiag.CalcPressionTravail,
                                                    PTmoinsPC:=m_oDiag.CalcPressionTravailMoinsPC,
                                                    DebitPTMoinsPC:=m_oDiag.CalcDebitPTlMoinsPC,
                                                    VitesseReelle1:=m_oDiag.CalcVitesseReelle1,
                                                    VitesseReelle2:=m_oDiag.CalcVitesseReelle2,
                                                    Largeur:=m_oDiag.CalcLargeurApp,
                                                    VolHaPMV1:=m_oDiag.CalcVolHaPMV1,
                                                    VolHaPMV2:=m_oDiag.CalcVolHaPMV2,
                                                    VolHaPTV1:=m_oDiag.CalcVolHaPTV1,
                                                    VolHaPTV2:=m_oDiag.CalcVolHaPTV2,
                                                    NbBuses:=m_oDiag.CalcNombreBuses,
                                                    NbreNiveauxBuses:=m_oDiag.CalcNombreNiveauxBuses,
                                                    NumBusesUsees:=m_oDiag.CalclstBuseUsees,
                                                    Pression1:=m_oDiag.CalcPression1,
                                                    Debit1:=m_oDiag.CalcDebit1,
                                                    Vitesse1:=m_oDiag.CalcVitesse1,
                                                    Ecartement1:=m_oDiag.CalcLargeur1,
                                                    VolEauHA1:=m_oDiag.CalcVolEauHa1,
                                                    Pression2:=m_oDiag.CalcPression2,
                                                    Debit2:=m_oDiag.CalcDebit2,
                                                    Vitesse2:=m_oDiag.CalcVitesse2,
                                                    Ecartement2:=m_oDiag.CalcLargeur2,
                                                    VolEauHa2:=m_oDiag.CalcVolEauHa2
                                                )
            Dim nNiveau As Integer = 0
            For Each oRPInfosBuses As RPInfosBuses In m_oDiag.ListInfosBuses
                nNiveau = nNiveau + 1
                Dim strType As String
                strType = "infos"
                If nNiveau = m_oDiag.ListInfosBuses.Count Then
                    strType = "Prise"
                End If
                For ndesc As Integer = 1 To oRPInfosBuses.NbDescentes
                    Dim strValue As String = oRPInfosBuses.Infos(ndesc)
                    If strType = "Prise" Then
                        strValue = IIf(strValue = "0", "NON", "OUI")
                    End If
                    m_ods.InfosBuses.AddInfosBusesRow(type:=strType, NumDescente:=ndesc, NumNiveau:=nNiveau, Infos:=strValue)
                Next
            Next
            bReturn = True


        Catch ex As Exception
            CSDebug.dispError("EtatSytheseMesures.GenereDS ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function

    ''' <summary>
    ''' Ouvre le fichier avec l'application par défaut
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overrides Function Open() As Boolean
        Dim bReturn As Boolean

        If Not String.IsNullOrEmpty(getFileName()) Then
            CSFile.open(m_oDiag.FilePath & "/" & m_oDiag.FileName)
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn
    End Function

End Class
