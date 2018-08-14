Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

<TestClass()> Public Class EtatSyntheseMesuresTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestMesures12123()

        Dim m_FileName As String

        Dim oDs As New ds_Etat_SM
        oDs.Synth12123.AddSynth12123Row(NumPompe:=1,
                                        NumMesure:=1,
                                        PressionMesurePompe:=2,
                                        DebitPompe:=1.006,
                                        PressionMoyenne:=2.2,
                                        NbBuses:=8,
                                        DebitReel:=1.06,
                                        DebitTotal:=8.44,
                                        Reglage:=2,
                                        DebitTheo:=0.161,
                                        TempMesure:=90,
                                        QteEau:=12.661,
                                        MasseMoins:=3.756,
                                        MassePlus:=3.492,
                                        QteProduit:=0.264,
                                        DosageReel:=2.08,
                                        Ecart:=-4.081,
                                        ResultatMesure:="IMPRECISION",
                                        ResultatPompe:="IMPRECISION")
        oDs.Synth12123.AddSynth12123Row(NumPompe:=1,
                                        NumMesure:=2,
                                        PressionMesurePompe:=2,
                                        DebitPompe:=1.006,
                                        PressionMoyenne:=2.2,
                                        NbBuses:=8,
                                        DebitReel:=1.06,
                                        DebitTotal:=8.44,
                                        Reglage:=2,
                                        DebitTheo:=0.161,
                                        TempMesure:=90,
                                        QteEau:=12.661,
                                        MasseMoins:=3.756,
                                        MassePlus:=3.492,
                                        QteProduit:=0.264,
                                        DosageReel:=2.08,
                                        Ecart:=-4.081,
                                        ResultatMesure:="IMPRECISION",
                                        ResultatPompe:="IMPRECISION")

        oDs.Synth12123.AddSynth12123Row(NumPompe:=1,
                                        NumMesure:=3,
                                        PressionMesurePompe:=2,
                                        DebitPompe:=1.006,
                                        PressionMoyenne:=2.2,
                                        NbBuses:=8,
                                        DebitReel:=1.06,
                                        DebitTotal:=8.44,
                                        Reglage:=2,
                                        DebitTheo:=0.161,
                                        TempMesure:=90,
                                        QteEau:=12.661,
                                        MasseMoins:=3.756,
                                        MassePlus:=3.492,
                                        QteProduit:=0.264,
                                        DosageReel:=2.08,
                                        Ecart:=-4.081,
                                        ResultatMesure:="IMPRECISION",
                                        ResultatPompe:="IMPRECISION")

        oDs.Synth12123.AddSynth12123Row(NumPompe:=2,
                                        NumMesure:=1,
                                        PressionMesurePompe:=2,
                                        DebitPompe:=1.006,
                                        PressionMoyenne:=2.2,
                                        NbBuses:=8,
                                        DebitReel:=1.06,
                                        DebitTotal:=8.44,
                                        Reglage:=2,
                                        DebitTheo:=0.161,
                                        TempMesure:=90,
                                        QteEau:=12.661,
                                        MasseMoins:=3.756,
                                        MassePlus:=3.492,
                                        QteProduit:=0.264,
                                        DosageReel:=2.08,
                                        Ecart:=-4.081,
                                        ResultatMesure:="IMPRECISION",
                                        ResultatPompe:="IMPRECISION")
        oDs.Synth12123.AddSynth12123Row(NumPompe:=2,
                                        NumMesure:=2,
                                        PressionMesurePompe:=2,
                                        DebitPompe:=1.006,
                                        PressionMoyenne:=2.2,
                                        NbBuses:=8,
                                        DebitReel:=1.06,
                                        DebitTotal:=8.44,
                                        Reglage:=2,
                                        DebitTheo:=0.161,
                                        TempMesure:=90,
                                        QteEau:=12.661,
                                        MasseMoins:=3.756,
                                        MassePlus:=3.492,
                                        QteProduit:=0.264,
                                        DosageReel:=2.08,
                                        Ecart:=-4.081,
                                        ResultatMesure:="IMPRECISION",
                                        ResultatPompe:="IMPRECISION")

        oDs.Synth12123.AddSynth12123Row(NumPompe:=2,
                                        NumMesure:=3,
                                        PressionMesurePompe:=2,
                                        DebitPompe:=1.006,
                                        PressionMoyenne:=2.2,
                                        NbBuses:=8,
                                        DebitReel:=1.06,
                                        DebitTotal:=8.44,
                                        Reglage:=2,
                                        DebitTheo:=0.161,
                                        TempMesure:=90,
                                        QteEau:=12.661,
                                        MasseMoins:=3.756,
                                        MassePlus:=3.492,
                                        QteProduit:=0.264,
                                        DosageReel:=2.08,
                                        Ecart:=-4.081,
                                        ResultatMesure:="IMPRECISION",
                                        ResultatPompe:="IMPRECISION")


        Dim objReport As ReportDocument
        Dim r1 As New cr_Synthese12123
        Dim strReportName As String = r1.ResourceName

        objReport = New ReportDocument
        objReport.Load("ModuleDocumentaire//_parametres" & "/" & strReportName)

        objReport.SetDataSource(oDs)
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
        m_FileName = CSDiagPdf.makeFilename("test", "SM12123") & "_" & "test" & ".pdf"
        CrDiskFileDestinationOptions.DiskFileName = Globals.CONST_PATH_EXP & m_FileName
        CrExportOptions = objReport.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        objReport.Export()

        CSFile.open(Globals.CONST_PATH_EXP & m_FileName)
    End Sub

    <TestMethod()> Public Sub TestMesures12123TrtSem()

        Dim m_FileName As String

        Dim oDs As New ds_Etat_SM
        oDs.Synth12123trtSem.AddSynth12123trtSemRow(NumPompe:=1,
                                                    NumMesure:=1,
                                                    VolumeAttendu:=5000,
                                                    Pesee1:=4990,
                                                    Ecart1:=(10 / 5000) * 100,
                                                    Pesee2:=49980,
                                                    Ecart2:=(20 / 5000) * 100, Pesee3:=5000, Ecart3:=0, ResultatMesure:="IMPRECISSION", ResultatGlobal:=
                                                    "OK", R1:="OK", R2:="IMPRECISION", R3:="OK")

        oDs.Synth12123trtSem.AddSynth12123trtSemRow(NumPompe:=1,
                                                    NumMesure:=2,
                                                    VolumeAttendu:=5000,
                                                    Pesee1:=4990,
                                                    Ecart1:=(10 / 5000) * 100,
                                                    Pesee2:=49980,
                                                    Ecart2:=(20 / 5000) * 100, Pesee3:=5000, Ecart3:=0, ResultatMesure:="IMPRECISSION", ResultatGlobal:=
                                                    "OK", R1:="OK", R2:="IMPRECISION", R3:="OK")
        oDs.Synth12123trtSem.AddSynth12123trtSemRow(NumPompe:=1,
                                                    NumMesure:=3,
                                                    VolumeAttendu:=5000,
                                                    Pesee1:=4990,
                                                    Ecart1:=(10 / 5000) * 100,
                                                    Pesee2:=49980,
                                                    Ecart2:=(20 / 5000) * 100, Pesee3:=5000, Ecart3:=0, ResultatMesure:="IMPRECISSION", ResultatGlobal:=
                                                    "OK", R1:="OK", R2:="IMPRECISION", R3:="OK")

        Dim objReport As ReportDocument
        Dim r1 As New cr_Synthese12123TrtSem
        Dim strReportName As String = r1.ResourceName

        objReport = New ReportDocument
        objReport.Load(MySettings.Default.RepertoireParametres & "/" & strReportName)

        objReport.SetDataSource(oDs)
        Dim CrExportOptions As ExportOptions
        Dim CrDiskFileDestinationOptions As New DiskFileDestinationOptions
        Dim CrFormatTypeOptions As New PdfRtfWordFormatOptions
        m_FileName = CSDiagPdf.makeFilename("test", "SM12123TrtSem") & "_" & "test" & ".pdf"
        CrDiskFileDestinationOptions.DiskFileName = Globals.CONST_PATH_EXP & m_FileName
        CrExportOptions = objReport.ExportOptions
        With CrExportOptions
            .ExportDestinationType = ExportDestinationType.DiskFile
            .ExportFormatType = ExportFormatType.PortableDocFormat
            .DestinationOptions = CrDiskFileDestinationOptions
            .FormatOptions = CrFormatTypeOptions
        End With
        objReport.Export()

        CSFile.open(Globals.CONST_PATH_EXP & m_FileName)
    End Sub


    <TestMethod()>
    Public Sub TestGenereSM_12123()
        Dim oEtat As EtatSyntheseMesures
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oPulve.isPompesDoseuses = True
        oPulve.nbPompesDoseuses = 2
        PulverisateurManager.save(oPulve, oExploit.id, m_oAgent)

        oDiag = createDiagnostic(oExploit, oPulve)
        Dim oPompe As DiagnosticHelp12123Pompe
        Dim oMesure As DiagnosticHelp12123Mesure
        oPompe = oDiag.diagnosticHelp12123.lstPompes(0)
        oPompe.debitMesure = 10.1
        oPompe.PressionMesure = 3.7
        oPompe.PressionMoyenne = 2.6
        oPompe.NbBuses = 3

        oMesure = oPompe.lstMesures(0)
        oMesure.ReglageDispositif = 10
        oMesure.TempsMesure = 11
        oMesure.MasseInitiale = 12
        oMesure.MasseAspire = 13

        oMesure = oPompe.lstMesures(1)
        oMesure.ReglageDispositif = 20
        oMesure.TempsMesure = 21
        oMesure.MasseInitiale = 22
        oMesure.MasseAspire = 23
        oMesure = oPompe.lstMesures(2)
        oMesure.ReglageDispositif = 30
        oMesure.TempsMesure = 31
        oMesure.MasseInitiale = 32
        oMesure.MasseAspire = 33

        oPompe = oDiag.diagnosticHelp12123.lstPompes(1)
        oPompe.debitMesure = 110.1
        oPompe.PressionMesure = 13.7
        oPompe.PressionMoyenne = 12.6
        oPompe.NbBuses = 13

        oMesure = oPompe.lstMesures(0)
        oMesure.ReglageDispositif = 110
        oMesure.TempsMesure = 111
        oMesure.MasseInitiale = 112
        oMesure.MasseAspire = 113
        oMesure = oPompe.lstMesures(1)
        oMesure.ReglageDispositif = 120
        oMesure.TempsMesure = 121
        oMesure.MasseInitiale = 122
        oMesure.MasseAspire = 123
        oMesure = oPompe.lstMesures(2)
        oMesure.ReglageDispositif = 130
        oMesure.TempsMesure = 131
        oMesure.MasseInitiale = 132
        oMesure.MasseAspire = 133


        oEtat = New EtatSyntheseMesures(oDiag)
        Assert.IsTrue(oEtat.GenereEtat())
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub

End Class