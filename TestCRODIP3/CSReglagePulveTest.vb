Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class CSReglagePulveTest
    Inherits CRODIPTest
    <TestMethod()> Public Sub TestExecute()
        Dim oExploit As Exploitation
        Dim oPulverisateur As Pulverisateur
        Dim oDiag As Diagnostic

        oExploit = createExploitation()
        ExploitationManager.save(oExploit, m_oAgent)
        oPulverisateur = createPulve(oExploit)
        PulverisateurManager.save(oPulverisateur, oExploit.id, m_oAgent)
        oDiag = createDiagnostic(oExploit, oPulverisateur, True)

        Assert.IsTrue(CSReglagePulve.Execute(oDiag.id, m_oAgent.id.ToString))
        Threading.Thread.Sleep(1000)
    End Sub

End Class