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
    <TestMethod()> Public Sub GetListeTest()

        Dim oPool As New Pool()
        oPool.uid = 999
        oPool.idPool = "TEST"
        oPool.libelle = "POOLTEST"
        PoolManager.Save(oPool)

        Dim oPoolAgent As PoolAgent
        oPoolAgent = New PoolAgent()
        oPoolAgent.uid = 156
        oPoolAgent.uidagent = m_oAgent.uid
        oPoolAgent.uidpool = oPool.uid
        Assert.IsTrue(PoolAgentManager.Save(oPoolAgent))

        Dim lstPool As List(Of Pool)
        lstPool = PoolAgentManager.getListe(m_oAgent)

        Assert.AreNotEqual(0, lstPool.Count)
        oPool = lstPool(0)
        Assert.AreEqual(999, oPool.uid)
        Assert.AreEqual("TEST", oPool.idPool)
        Assert.AreEqual("POOLTEST", oPool.libelle)

        'Suppression du PoolAgent
        oPoolAgent = PoolAgentManager.GetByuid(oPoolAgent.uid)
        oPoolAgent.isSupprime = True
        PoolAgentManager.Save(oPoolAgent)

        lstPool = PoolAgentManager.getListe(m_oAgent)
        Assert.AreEqual(0, lstPool.Count)

    End Sub



End Class