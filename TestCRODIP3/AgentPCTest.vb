Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class AgentPCTest

    <TestMethod()> Public Sub CRUD()

        Dim oAgentPC As New AgentPC()
        oAgentPC.numInterne = "AQWZSX"
        oAgentPC.idCrodip = "123465"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))
        Dim nId As Integer = oAgentPC.id

        oAgentPC = AgentPCManager.getAgentPCByIdCRODIP("123465")
        Assert.AreEqual(nId, oAgentPC.id)
        Assert.AreEqual("AQWZSX", oAgentPC.numInterne)
        Assert.AreEqual("123465", oAgentPC.idCrodip)

        oAgentPC.numInterne = "AZERTYUIOP"
        oAgentPC.idCrodip = "9999"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))

        oAgentPC = AgentPCManager.getAgentPCByIdCRODIP("123465")
        Assert.AreEqual(nId, oAgentPC.id)
        Assert.AreEqual("AZERTYUIOP", oAgentPC.numInterne)
        Assert.AreEqual("9999", oAgentPC.idCrodip)


    End Sub

End Class