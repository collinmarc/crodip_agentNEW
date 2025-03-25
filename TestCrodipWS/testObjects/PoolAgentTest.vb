Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CRODIPWS

<TestClass()> Public Class PoolAgentTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPoolAgent As New PoolAgent()
        Dim oPoolAgent2 As PoolAgent
        oPoolAgent.uid = 12345
        oPoolAgent.aid = "P12345"
        oPoolAgent.namepool = "NOM12345"
        oPoolAgent.uidagent = m_oAgent.uid
        oPoolAgent.aidagent = m_oAgent.aid
        oPoolAgent.uidstructure = m_oAgent.idStructure
        oPoolAgent.dateAssociation = New Date(2025, 3, 25, 10, 27, 0)

        Assert.IsTrue(PoolAgentManager.Save(oPoolAgent))

        oPoolAgent2 = PoolAgentManager.GetByuid(12345)
        Assert.IsNotNull(oPoolAgent2)
        Assert.AreEqual(oPoolAgent.uid, oPoolAgent2.uid)
        Assert.AreEqual(oPoolAgent.aid, oPoolAgent2.aid)
        Assert.AreEqual(oPoolAgent.namepool, oPoolAgent2.namepool)
        Assert.AreEqual(oPoolAgent.uidagent, oPoolAgent2.uidagent)
        Assert.AreEqual(oPoolAgent.aidagent, oPoolAgent2.aidagent)
        Assert.AreEqual(oPoolAgent.uidstructure, oPoolAgent2.uidstructure)
        Assert.AreEqual(oPoolAgent.dateAssociation, oPoolAgent2.dateAssociation)

        oPoolAgent.namepool = "TEST2"
        PoolAgentManager.Save(oPoolAgent)
        oPoolAgent2 = PoolAgentManager.GetByuid(12345)
        Assert.IsNotNull(oPoolAgent2)
        Assert.AreEqual(oPoolAgent.namepool, oPoolAgent2.namepool)

    End Sub
    <TestMethod()> Public Sub WSCRUD()
        Dim oPoolAgent As PoolAgent
        Dim oPool2 As PoolAgent = Nothing
        Dim nReturn As Integer

        oPoolAgent = PoolAgentManager.WSgetById(1, "")

        Assert.AreEqual(1, oPoolAgent.uid)

        oPoolAgent.namepool = "PoolAgent2"
        oPoolAgent.dateAssociation = New Date(2025, 3, 25, 14, 13, 0)
        Assert.IsTrue(PoolAgentManager.Save(oPoolAgent))

        nReturn = PoolAgentManager.WSSend(oPoolAgent, oPool2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")

        oPoolAgent = PoolAgentManager.WSgetById(oPool2.uid, oPool2.aid)

        Assert.AreEqual("PoolAgent2", oPoolAgent.namepool)
        Assert.AreEqual(New Date(2025, 3, 25, 14, 13, 0), oPoolAgent.dateAssociation)



    End Sub




End Class