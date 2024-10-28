Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports Crodip_agent

<TestClass()> Public Class EtatFactureTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenerationRapport()

        Dim oFacture As EtatFacture

        m_oExploitation = createExploitation()
        m_oPulve = createPulve(m_oExploitation)
        m_oDiag = createDiagnostic(m_oExploitation, m_oPulve)

        oFacture = New EtatFacture(m_oDiag, m_oStructure.DernierNumFact, "TEST")
        oFacture.AddPresta("TEST", "300", 1, 20, 30, 50)

        Assert.IsTrue(oFacture.genereEtat())
        Assert.IsTrue(oFacture.getFileName().EndsWith("FACTURE.pdf"))
    End Sub

End Class