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
        oEtat.AddPresta(pLib:="TEST", pPU:=61.5D, pQte:=0.5D, pTxTVA:=20, pTotalHT:=30.25D, pTotalTTC:=30.25D * 1.2)

        Assert.IsTrue(oEtat.GenereEtat())
        Assert.IsTrue(oEtat.getFileName().EndsWith("BL.pdf"))
        CSFile.open(oEtat.getFileNameFullPath())
    End Sub

End Class