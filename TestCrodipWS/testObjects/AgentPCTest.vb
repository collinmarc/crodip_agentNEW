Imports System.Text
Imports CRODIPWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting


<TestClass()> Public Class AgentPCTest

    <TestMethod()> Public Sub CRUD()

        Dim oAgentPC As New AgentPC()
        oAgentPC.numInterne = "AQWZSX"
        oAgentPC.idCrodip = "123465"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))
        Dim sIdCrodip As String = oAgentPC.idCrodip

        oAgentPC = AgentPCManager.getAgentPCByIdCRODIP("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AQWZSX", oAgentPC.numInterne)
        Assert.AreEqual("123465", oAgentPC.idCrodip)

        oAgentPC.numInterne = "AZERTYUIOP"

        Assert.IsTrue(AgentPCManager.save(oAgentPC))

        oAgentPC = AgentPCManager.getAgentPCByIdCRODIP("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AZERTYUIOP", oAgentPC.numInterne)
        Assert.AreEqual("123465", oAgentPC.idCrodip)


    End Sub

End Class