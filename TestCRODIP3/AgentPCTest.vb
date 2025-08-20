Imports System.Text
Imports CRODIPWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting


<TestClass()> Public Class AgentPCTest

    <TestMethod()> Public Sub CRUD()

        Dim oAgentPC As New AgentPC()
        oAgentPC.idRegistre = "AQWZSX"
        oAgentPC.idCrodip = "123465"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))
        Dim sIdCrodip As String = oAgentPC.idCrodip

        oAgentPC = AgentPcManager.GetByidPc("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AQWZSX", oAgentPC.idRegistre)
        Assert.AreEqual("123465", oAgentPC.idCrodip)

        oAgentPC.idRegistre = "AZERTYUIOP"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))

        oAgentPC = AgentPcManager.GetByidPc("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AZERTYUIOP", oAgentPC.idRegistre)
        Assert.AreEqual("123465", oAgentPC.idCrodip)


    End Sub

End Class