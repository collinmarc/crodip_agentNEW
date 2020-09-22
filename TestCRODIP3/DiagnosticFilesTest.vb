Imports System.IO
Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class DiagnosticFilesTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CreateFilesTest()
        Dim oEtat As EtatRapportInspection
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation
        Dim oDiagItem As DiagnosticItem

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)

        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "DANS LA COUR"
        oDiagItem = New DiagnosticItem(oDiag.id, "256", "1", "2", "P")
        oDiagItem.LibelleCourt = "LIBCourt2561"
        oDiagItem.LibelleLong = "Ceci est le libelle Long de 2561 ce libellé est sur plusieurs lignes et tout doit apparaoitre même ces dernièrs mots bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb ccccccccccccccccccc dddddddddddddddddddddddddddddd eeeeeeeeeeeeeeeeee ffffffffffffffffffff Z"

        oEtat = New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(File.Exists(Globals.CONST_PATH_EXP & "/" & oEtat.getFileName()))

        If File.Exists("systemPDF1.zip") Then
            File.Delete("SystemPDF1.zip")
        End If


        Assert.IsTrue(oDiag.AddPDFs(oEtat.getFileName()))
        'Suppression du Fichier

        File.Delete(Globals.CONST_PATH_EXP & "/" & oEtat.getFileName())

        'Extraction du fichier
        oDiag.getPDFs(oEtat.getFileName())
        Assert.IsTrue(File.Exists(Globals.CONST_PATH_EXP & "/" & oEtat.getFileName()))

        CSFile.open(Globals.CONST_PATH_EXP & "/" & oEtat.getFileName())

    End Sub

End Class