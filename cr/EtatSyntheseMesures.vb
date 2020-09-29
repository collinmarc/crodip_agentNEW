Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Linq

Public Class EtatSyntheseMesures
    Inherits EtatCrodip
    Implements IDisposable

    Private m_oDiag As Diagnostic
    Private m_ods As ds_Etat_SM
    Public Sub New(pDiag As Diagnostic)
        m_Path = Globals.CONST_PATH_EXP_DIAGNOSTIC
        m_oDiag = pDiag
    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        If (m_oReportDocument IsNot Nothing) Then
            m_oReportDocument.Dispose()
        End If
    End Sub

    Public Function getDs() As DataSet
        Return m_ods
    End Function


    protected Overrides Function GenereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean
        Dim strReportName As String
        Try
            CSDebug.dispInfo("TBD : GenereEtat")
            bReturn = genereDS()
            If (bReturn) Then
                Using r1 As New cr_EtatSynthese()
                    strReportName = r1.ResourceName
                    r1.Close()
                End Using
                m_oReportDocument = New ReportDocument
                CSDebug.dispInfo("TBD : Load" & MySettings.Default.RepertoireParametres & "/" & strReportName)
                m_oReportDocument.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)
                'Dim olst As ReportObjects
                'For Each oSubReport As ReportDocument In m_oReportDocument.Subreports
                '    If oSubReport.Name = "cr_syntheseBuses10.rpt" Then
                '        olst = oSubReport.ReportDefinition.ReportObjects
                '        For Each obj As ReportObject In olst
                '            If obj.Name = "LinePlus" Then
                '                Dim oLine As LineObject
                '                oLine = obj
                '                Console.Write("Trouvé !!!" & oLine.Top & "/" & oLine.Bottom)
                '                '                                oLine.LineColor = Color.Blue
                '                '                                oLine.Bottom = 4996
                '                '                               oLine.Top = 4996
                '            End If
                '        Next

                '    End If
                'Next
                ''On Recherche le Sous Rapport qui contient un champ LinePlus
                'For nSR As Integer = 0 To m_oReportDocument.Subreports.Count

                'Next

                CSDebug.dispInfo("TBD : setDataSource")
                m_oReportDocument.SetDataSource(m_ods)
                CSDebug.dispInfo("TBD : setParameter")
                m_oReportDocument.SetParameterValue("ModeSimplifie", Globals.GLOB_ENV_MODESIMPLIFIE)
                If pExportPDF Then
                    Dim CrExportOptions As ExportOptions
                    Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
                    Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
                    m_FileName = CSDiagPdf.makeFilename(m_oDiag.pulverisateurId, CSDiagPdf.TYPE_SYNTHESE_MESURES) & "_" & m_oDiag.id & ".pdf"
                    CrDiskFileDestinationOptions.DiskFileName = m_Path & m_FileName
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
        CSDebug.dispInfo("TBD : GenereEtat End")
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
            m_ods.Diag.AddDiagRow(idDiag:=m_oDiag.id,
                                  DateControle:=m_oDiag.controleDateDebut,
                                  NumPulve:=m_oDiag.pulverisateurNumNational,
                                  NomPropriétaire:=m_oDiag.proprietaireNom & " " & m_oDiag.proprietairePrenom,
                                  NomOrganisme:=m_oDiag.organismePresNom,
                                  EcartTolereBuses:=EcartTolere,
                                  PulveisPompeDoseuses:=opulve.isPompesDoseuses,
                                  PulveIsTrtSemences:=opulve.isTraitementdesSemences)

            'Buses
            Dim pctBusesUsees As Decimal
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
                    m_ods.debitBuses.AdddebitBusesRow(numBuse:=oDetail.idBuse + 1, IdLot:=oDetail.idLot, debit:=dDebit, ecartPourcentage:=dEcart, ssgroupe:=0, idDiag:=m_oDiag.id, EcartTolere:=EcartTolere)
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
                        Dim NumPompe As String = oPompe.numero
                        Dim PressionMesurePompe As String = IIf(oPompe.PressionMesure.HasValue, oPompe.PressionMesure, "")
                        Dim DebitPompe As String = IIf(oPompe.debitMesure.HasValue, oPompe.debitMesure, "")
                        Dim NumMesure As String = oMesure.numeroMesure
                        Dim PressionMoyenne As String = IIf(oPompe.PressionMoyenne.HasValue, oPompe.PressionMoyenne, "")
                        Dim NbBuses As String = IIf(oPompe.NbBuses.HasValue, oPompe.NbBuses, "")
                        Dim DebitReel As String = IIf(oPompe.DebitReelRND.HasValue, oPompe.DebitReelRND, "")
                        Dim DebitTotal As String = IIf(oPompe.DebitTotalRND.HasValue, oPompe.DebitTotalRND, "")
                        Dim Reglage As String = IIf(oMesure.ReglageDispositif.HasValue, oMesure.ReglageDispositif, "")
                        Dim DebitTheo As String = IIf(oMesure.DebitTheoriqueRND.HasValue, oMesure.DebitTheoriqueRND, "")
                        Dim TempMesure As String = IIf(oMesure.TempsMesure.HasValue, oMesure.TempsMesure, "")
                        Dim QteEau As String = IIf(oMesure.QteEauPulverisee.HasValue, oMesure.QteEauPulveriseeRND, "")
                        Dim MassePlus As String = IIf(oMesure.MasseInitiale.HasValue, oMesure.MasseInitiale, "")
                        Dim MasseMoins As String = IIf(oMesure.MasseAspire.HasValue, oMesure.MasseAspire, "")
                        Dim QteProduit As Decimal = IIf(oMesure.QteProduitConso.HasValue, oMesure.QteProduitConso, 0D)
                        Dim DosageReel As String = IIf(oMesure.DosageReelRND.HasValue, oMesure.DosageReelRND, "")
                        Dim Ecart As Decimal = IIf(oMesure.EcartReglageRND.HasValue, oMesure.EcartReglageRND, 0D)

                        m_ods.Synth12123.AddSynth12123Row(NumPompe:=NumPompe,
                                                          PressionMesurePompe:=PressionMesurePompe,
                                                          DebitPompe:=DebitPompe,
                                                          ResultatPompe:=ResultatPompe,
                                                          NumMesure:=NumMesure,
                                                          PressionMoyenne:=PressionMoyenne,
                                                          NbBuses:=NbBuses,
                                                          DebitReel:=DebitReel,
                                                          DebitTotal:=DebitTotal,
                                                          Reglage:=Reglage,
                                                          DebitTheo:=DebitTheo,
                                                          TempMesure:=TempMesure,
                                                          QteEau:=QteEau,
                                                          MassePlus:=MassePlus,
                                                          MasseMoins:=MasseMoins,
                                                          QteProduit:=QteProduit,
                                                          DosageReel:=DosageReel,
                                                          Ecart:=Ecart,
                                                          ResultatMesure:=ResultatMesure)
                    Next

                Next
            End If
            If opulve.isTraitementdesSemences Then
                Dim ResultatPompe As String
                Dim ResultatMesure As String
                Dim ResultatGlobal As String
                ResultatGlobal = m_oDiag.diagnosticHelp12123.LabelResultat
                Dim EcartMoyenGlobal As String
                For Each oPompe As DiagnosticHelp12123PompeTrtSem In m_oDiag.diagnosticHelp12123.lstPompesTrtSem

                Next
                Try

                    EcartMoyenGlobal = (From oPompe As DiagnosticHelp12123PompeTrtSem
                                        In m_oDiag.diagnosticHelp12123.lstPompesTrtSem
                                        Select oPompe.EcartReglageMoyen).Average()
                Catch ex As Exception
                    EcartMoyenGlobal = ""
                End Try


                For Each oPompe As DiagnosticHelp12123PompeTrtSem In m_oDiag.diagnosticHelp12123.lstPompesTrtSem
                    If oPompe.Resultat = DiagnosticItem.EtatDiagItemOK Then
                        ResultatPompe = "OK"
                    Else
                        ResultatPompe = "IMPRECISION"

                    End If
                    For Each oMesure As DiagnosticHelp12123MesuresTrtSem In oPompe.lstMesures
                        If oMesure.Resultat = DiagnosticItem.EtatDiagItemOK Then
                            ResultatMesure = "OK"
                        Else
                            ResultatMesure = "IMPRECISION"

                        End If
                        Dim NumPompe As String = oPompe.Nom
                        Dim PeseeMoyennePompe As String = ""
                        If (oPompe.PeseeMoyenne.HasValue) Then
                            PeseeMoyennePompe = oPompe.PeseeMoyenne
                        End If
                        Dim EcartMoyen As String = ""
                        If (oPompe.EcartReglageMoyen.HasValue) Then
                            EcartMoyen = oPompe.EcartReglageMoyen
                        End If
                        Dim NumMesure As String = oMesure.numeroMesurestr
                        Dim QteGains As String = oMesure.qteGrains
                        Dim DebitSouhaite As String = oMesure.DebitSouhaite
                        Dim Pesee1 As String = IIf(oMesure.Pesee1 <> 0, oMesure.Pesee1, "")
                        Dim Ecart1 As String = IIf(oMesure.Pesee1 <> 0, oMesure.Ecart1, "")
                        Dim Pesee2 As String = IIf(oMesure.Pesee2 <> 0, oMesure.Pesee2, "")
                        Dim Ecart2 As String = IIf(oMesure.Pesee2 <> 0, oMesure.Ecart2, "")
                        Dim Pesee3 As String = IIf(oMesure.Pesee3 <> 0, oMesure.Pesee3, "")
                        Dim Ecart3 As String = IIf(oMesure.Pesee3 <> 0, oMesure.Ecart3, "")
                        Dim PeseeMoyenneMesure As String = IIf(oMesure.PeseeMoyenne <> 0, oMesure.PeseeMoyenne, "")
                        Dim EcartMoyenMesure As String = IIf(oMesure.PeseeMoyenne <> 0, oMesure.EcartMoyen, "")

                        m_ods.Synth12123trtSem.AddSynth12123trtSemRow(NumPompe:=NumPompe,
                                                                      Pesee1:=Pesee1,
                                                                      Ecart1:=Ecart1,
                                                                      Pesee2:=Pesee2,
                                                                      Ecart2:=Ecart2,
                                                                      Pesee3:=Pesee3,
                                                                      Ecart3:=Ecart3,
                                                                      PeseeMoyenneMesure:=PeseeMoyenneMesure,
                                                                      EcartMoyenMesure:=EcartMoyenMesure,
                                                                      ResultatMesure:=ResultatMesure,
                                                                      PreseeMoyennePompe:=PeseeMoyennePompe,
                                                                      EcartMoyenPompte:=EcartMoyen,
                                                                      ResultatPompe:=ResultatPompe,
                                                                      DebitSouhaite:=DebitSouhaite, QteGrains:=QteGains,
                                                                      NumMesure:=NumMesure,
                                                                      ResultatGlobal:=ResultatGlobal,
                                                                      EcartMoyenGlobal:=EcartMoyenGlobal,
                                                                      FonctionnementBuses:=opulve.buseFonctionnement)

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
