Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatContratCommercialTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereContratCommercial()
        Dim oEtat As EtatContratCommercial
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oPulve.type = "Arbres"
        oDiag = createDiagnostic(oExploit, oPulve)
        oDiag.controleIsComplet = False
        oDiag.inspecteurNom = "Collin"
        oDiag.inspecteurPrenom = "Marc"
        oDiag.proprietaireRepresentant = "Rault Marc Antoine"
        oDiag.TotalHT = 165.2D
        oDiag.TotalTVA = oDiag.TotalHT * 0.2D
        oDiag.TotalTTC = oDiag.TotalHT + oDiag.TotalTVA



        oEtat = New EtatContratCommercial(oDiag)
        Assert.IsTrue(oEtat.GenereEtat(True))
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())


    End Sub

End Class