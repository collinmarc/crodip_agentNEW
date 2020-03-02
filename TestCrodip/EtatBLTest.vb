Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class EtatBLTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenerationRapport()

        Dim oEtat As EtatBL

        m_oExploitation = createExploitation()
        m_oPulve = createPulve(m_oExploitation)
        m_oDiag = createDiagnostic(m_oExploitation, m_oPulve)
        oEtat = New EtatBL(m_oDiag)
        oEtat.AddPresta("TEST", 300.5D, 0.5D, 20, 30, 50)

        Assert.IsTrue(oEtat.GenereEtat())
        Assert.IsTrue(oEtat.getFileName().EndsWith("BL.pdf"))
        CSFile.open(oEtat.getFileName())
    End Sub

End Class