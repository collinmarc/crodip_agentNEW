Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class AgentPCTest

    <TestMethod()> Public Sub CRUD()

        Dim oAgentPC As New AgentPC()
        oAgentPC.cleUtilisation = "AQWZSX"
        oAgentPC.idCrodip = "123465"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))
        Dim nId As Integer = oAgentPC.id

        oAgentPC = AgentPCManager.getAgentPCById(nId)
        Assert.AreEqual(nId, oAgentPC.id)
        Assert.AreEqual("AQWZSX", oAgentPC.cleUtilisation)
        Assert.AreEqual("123465", oAgentPC.idCrodip)

        oAgentPC.cleUtilisation = "AZERTYUIOP"
        oAgentPC.idCrodip = "9999"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))

        oAgentPC = AgentPCManager.getAgentPCById(nId)
        Assert.AreEqual(nId, oAgentPC.id)
        Assert.AreEqual("AZERTYUIOP", oAgentPC.cleUtilisation)
        Assert.AreEqual("9999", oAgentPC.idCrodip)


    End Sub

End Class