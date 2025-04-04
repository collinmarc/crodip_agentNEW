Imports System.Text
Imports CRODIPWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting


<TestClass()> Public Class AgentPCTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()

        Dim oAgentPC As New AgentPc()
        oAgentPC.idRegistre = "AQWZSX"
        oAgentPC.idCrodip = "123465"

        Assert.IsTrue(AgentPcManager.Save(oAgentPC))
        Dim sIdCrodip As String = oAgentPC.idCrodip

        oAgentPC = AgentPcManager.GetByuid("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AQWZSX", oAgentPC.idRegistre)
        Assert.AreEqual("123465", oAgentPC.idCrodip)

        oAgentPC.idRegistre = "AZERTYUIOP"

        Assert.IsTrue(AgentPcManager.Save(oAgentPC))

        oAgentPC = AgentPcManager.GetByuid("123465")
        Assert.AreEqual(sIdCrodip, oAgentPC.idCrodip)
        Assert.AreEqual("AZERTYUIOP", oAgentPC.idRegistre)
        Assert.AreEqual("123465", oAgentPC.idCrodip)


    End Sub
    <TestMethod()> Public Sub GetPCListTest()
        'l'agent contient le pool
        Assert.IsNotNull(m_oAgent.oPool)
        Dim lstPc As List(Of AgentPc)
        lstPc = AgentPcManager.WSGetListByPool(m_oAgent.oPool)
        Assert.AreNotEqual(0, lstPc)
        For Each oAgentPc As AgentPc In lstPc
            Assert.AreEqual(m_oAgent.uidstructure, oAgentPc.uidstructure)
        Next


    End Sub



End Class