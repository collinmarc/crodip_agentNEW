Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class EtatSyntheseMesures
    Inherits EtatCrodip

    Private m_oDiag As Diagnostic
    Private m_ods As ds_Etat_SM
    Public Sub New(pDiag As Diagnostic)
        m_oDiag = pDiag
    End Sub

    Public Function getDs() As DataSet
        Return m_ods
    End Function


    Public Function GenereEtat() As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = genereDS()
            If (bReturn) Then
                Dim objReport As ReportDocument
                Dim r1 As New cr_EtatSynthese()
                Dim strReportName As String = r1.ResourceName

                objReport = New ReportDocument
                objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)

                objReport.SetDataSource(m_ods)
                Dim CrExportOptions As ExportOptions
                Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                m_FileName = CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_SYNTHESE_MESURES) & "_" & m_oDiag.id & ".pdf"
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
            ''' Generation du dataset en vue la la construction du rapport de synthese

            m_ods = New ds_Etat_SM()
            'Charegement du pulvérisateur
            Dim opulve As Pulverisateur

            opulve = PulverisateurManager.getPulverisateurById(m_oDiag.pulverisateurId)
            If opulve Is Nothing Then
                opulve = New Pulverisateur()
            End If
            'L'écart toléré des buses est constant qq soit le niveau 
            'En rampe il peut peut 10 ou 15 mais un seul niveau
            'En ArboViti , il peut y avoir plusieurs niveau mais toujours à 15
            'on récupère donc l'écart toléré du premier niveau pour l'affecter au diag
            'on l'utilise pour sélectionner le rapport de synthèse des buses (cr_syntheseBuses10 ou cr_syntheseBuses15)
            Dim EcartTolere As Integer
            If m_oDiag.diagnosticBusesList.Liste.Count > 0 Then
                EcartTolere = m_oDiag.diagnosticBusesList.Liste(0).ecartTolere
            Else
                EcartTolere = 10
            End If
            'Diagnostic
            m_ods.Diag.AddDiagRow(idDiag:=m_oDiag.id, DateControle:=m_oDiag.controleDateDebut, NumPulve:=m_oDiag.pulverisateurNumNational, NomPropriétaire:=m_oDiag.proprietaireNom & " " & m_oDiag.proprietairePrenom, NomOrganisme:=m_oDiag.organismePresNom, EcartTolereBuses:=EcartTolere, PulveisPompeDoseuses:=opulve.isPompesDoseuses)

            'Buses
            Dim pctBusesUsees As Decimal
            Dim debit As Decimal
            For Each oLot As DiagnosticBuses In m_oDiag.diagnosticBusesList.Liste
                If oLot.nombre <> 0 Then
                    pctBusesUsees = Math.Round((oLot.nombrebusesusees / oLot.nombre) * 100, 2)
                Else
                    pctBusesUsees = 100%
                End If
                m_ods.debitBuses_infos.AdddebitBuses_infosRow(debitNominal:=oLot.debitNominal, couleur:=oLot.couleur, ecartTolere:=oLot.ecartTolere, debitMoyen:=oLot.debitMoyen, marque:=oLot.marque, nombreBuses:=oLot.nombre, IdLot:=oLot.idLot, DebitMax:=oLot.debitMax, DebitMin:=oLot.debitMin, nombreBusesUsees:=oLot.nombrebusesusees, type:=opulve.buseType, pressionControle:=m_oDiag.manometrePressionTravailD, usuremoyenne:=m_oDiag.syntheseUsureMoyenneBusesD, idDiag:=m_oDiag.id, Fonctionnement:=opulve.buseFonctionnement, modele:=oLot.genre, calibre:=oLot.calibre, PctBusesUsees:=pctBusesUsees, conclusion:=oLot.Resultat)
                For Each oDetail As DiagnosticBusesDetail In oLot.diagnosticBusesDetailList.Liste
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

            'Controle du Manometre 542
            m_ods.Mano542.AddMano542Row(idDiag:=m_oDiag.id, useCalibrateur:=m_oDiag.controleUseCalibrateur, EcartMaxi:=m_oDiag.syntheseErreurMaxiManoD, EcartMoyen:=m_oDiag.syntheseErreurMoyenneManoD, Resultat:=m_oDiag.syntheseImprecision542)
            For Each oMesure542 As DiagnosticMano542 In m_oDiag.diagnosticMano542List.diagnosticMano542
                m_ods.Mano542Detail.AddMano542DetailRow(PressionPulve:=oMesure542.pressionPulved, pressionControle:=oMesure542.pressionControled, Ecart:=oMesure542.Ecart, Imprecision:=oMesure542.Erreur.ToString(), idDiag:=m_oDiag.id)
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
                'm_ods.SyntheseDebitmetreDetail.AddSyntheseDebitmetreDetailRow(idDiag:=m_odiag.id, nMesure:=1, NbreBuses:=diagnosticHelp552.NbBuses_m1, Pressionbar:=diagnosticHelp552.Pression_m1, DebitAfficheur:=diagnosticHelp552.DebitAfficheur_m1, debitEtalon:=diagnosticHelp552.DebitEtalon_m1, Ecartpct:=diagnosticHelp552.EcartPct_m1, type:=diagnosticHelp552.iditem)
                'm_ods.SyntheseDebitmetreDetail.AddSyntheseDebitmetreDetailRow(idDiag:=m_odiag.id, nMesure:=2, NbreBuses:=diagnosticHelp552.NbBuses_m2, Pressionbar:=diagnosticHelp552.Pression_m2, DebitAfficheur:=diagnosticHelp552.DebitAfficheur_m2, debitEtalon:=diagnosticHelp552.DebitEtalon_m2, Ecartpct:=diagnosticHelp552.EcartPct_m2, type:=diagnosticHelp552.iditem)
                'm_ods.SyntheseDebitmetreDetail.AddSyntheseDebitmetreDetailRow(idDiag:=m_odiag.id, nMesure:=3, NbreBuses:=diagnosticHelp552.NbBuses_m3, Pressionbar:=diagnosticHelp552.Pression_m3, DebitAfficheur:=diagnosticHelp552.DebitAfficheur_m3, debitEtalon:=diagnosticHelp552.DebitEtalon_m3, Ecartpct:=diagnosticHelp552.EcartPct_m3, type:=diagnosticHelp552.iditem)
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
                'm_ods.SyntheseDebitmetreDetail.AddSyntheseDebitmetreDetailRow(idDiag:=m_odiag.id, nMesure:=1, NbreBuses:=diagnosticHelp5622.NbBuses_m1, Pressionbar:=diagnosticHelp5622.Pression_m1, DebitAfficheur:=diagnosticHelp5622.DebitAfficheur_m1, debitEtalon:=diagnosticHelp5622.DebitEtalon_m1, Ecartpct:=diagnosticHelp5622.EcartPct_m1, type:=diagnosticHelp5622.iditem)
                'm_ods.SyntheseDebitmetreDetail.AddSyntheseDebitmetreDetailRow(idDiag:=m_odiag.id, nMesure:=2, NbreBuses:=diagnosticHelp5622.NbBuses_m2, Pressionbar:=diagnosticHelp5622.Pression_m2, DebitAfficheur:=diagnosticHelp5622.DebitAfficheur_m2, debitEtalon:=diagnosticHelp5622.DebitEtalon_m2, Ecartpct:=diagnosticHelp5622.EcartPct_m2, type:=diagnosticHelp5622.iditem)
                'm_ods.SyntheseDebitmetreDetail.AddSyntheseDebitmetreDetailRow(idDiag:=m_odiag.id, nMesure:=3, NbreBuses:=diagnosticHelp5622.NbBuses_m3, Pressionbar:=diagnosticHelp5622.Pression_m3, DebitAfficheur:=diagnosticHelp5622.DebitAfficheur_m3, debitEtalon:=diagnosticHelp5622.DebitEtalon_m3, Ecartpct:=diagnosticHelp5622.EcartPct_m3, type:=diagnosticHelp5622.iditem)
            End If
            If opulve.isPompesDoseuses Then
                Dim ResultatPompe As String
                Dim ResultatMesure As String
                For Each oPompe As DiagnosticHelp12123Pompe In m_oDiag.diagnosticHelp12123.lstPompes
                    If oPompe.Resultat = DiagnosticItem.EtatDiagItemOK Then
                        ResultatPompe = "OK"
                    Else
                        ResultatPompe = "IMPRECISION"

                    End If
                    For Each oMesure As DiagnosticHelp12123Mesure In oPompe.lstMesures
                        If oMesure.Resultat = DiagnosticItem.EtatDiagItemOK Then
                            ResultatMesure = "OK"
                        Else
                            ResultatMesure = "IMPRECISION"

                        End If
                        m_ods.Synth12123.AddSynth12123Row(NumPompe:=oPompe.numero,
                                                          PressionMesurePompe:=oPompe.PressionMesure,
                                                          DebitPompe:=oPompe.debitMesure,
                                                          ResultatPompe:=ResultatPompe,
                                                          NumMesure:=oMesure.numeroMesure,
                                                          PressionMoyenne:=oPompe.PressionMoyenne,
                                                          NbBuses:=oPompe.NbBuses,
                                                          DebitReel:=oPompe.DebitReelRND,
                                                          DebitTotal:=oPompe.DebitTotalRND,
                                                          Reglage:=oMesure.ReglageDispositif,
                                                          DebitTheo:=oMesure.DebitTheoriqueRND,
                                                          TempMesure:=oMesure.TempsMesure,
                                                          QteEau:=oMesure.QteEauPulverisee,
                                                          MassePlus:=oMesure.MasseInitiale,
                                                          MasseMoins:=oMesure.MasseAspire,
                                                          QteProduit:=oMesure.QteProduitConso,
                                                          DosageReel:=oMesure.DosageReelRND,
                                                          Ecart:=oMesure.EcartReglageRND,
                                                          ResultatMesure:=ResultatMesure)
                    Next

                Next
            End If


            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("EtatSytheseMesures.GenereDS ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
End Class
