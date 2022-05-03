Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports Crodip_agent

<TestClass()> Public Class PoolTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPool As New Pool()
        oPool.nbPastillesVertes = 15
        oPool.idCrodip = "123465"
        oPool.idStructure = m_oAgent.idStructure

        Assert.IsTrue(PoolManager.Save(oPool))
        Dim nId As Integer = oPool.id

        oPool = PoolManager.getPoolById(nId)
        Assert.AreEqual(nId, oPool.id)
        Assert.AreEqual(15, oPool.nbPastillesVertes)
        Assert.AreEqual("123465", oPool.idCrodip)

        oPool.nbPastillesVertes = 5
        oPool.idCrodip = "9999"

        Assert.IsTrue(PoolManager.Save(oPool))

        oPool = PoolManager.getPoolById(nId)
        Assert.AreEqual(nId, oPool.id)
        Assert.AreEqual(5, oPool.nbPastillesVertes)
        Assert.AreEqual("9999", oPool.idCrodip)


    End Sub

    <TestMethod()> Public Sub REST()
        Dim oPool As Pool

        oPool = New Pool()
        oPool.idCrodip = "123456"
        PoolManager.Save(oPool)


    End Sub
    <TestMethod()> Public Sub AgentPool()

        m_oAgent.idPool = 0
        AgentManager.save(m_oAgent)

        m_oAgent = AgentManager.getAgentById(m_oAgent.id)
        Assert.AreEqual(0, m_oAgent.idPool)
        Assert.IsNull(m_oAgent.oPool)

        'Création du PC
        Dim oPC As AgentPC
        oPC = New AgentPC()
        oPC.idCrodip = "123"
        oPC.libelle = "VAIO"

        Assert.IsTrue(AgentPCManager.save(oPC))

        'Création d'un pool
        Dim oPool As Pool
        oPool = New Pool()
        oPool.idCrodip = "P1"
        oPool.idPC = oPC.id
        oPool.idStructure = m_oStructure.id

        Assert.IsTrue(PoolManager.Save(oPool))

        'Rattachement de l'agent au pool
        m_oAgent.idPool = oPool.id
        Assert.IsTrue(AgentManager.save(m_oAgent))

        'Rechargement de l'agent
        m_oAgent = AgentManager.getAgentById(m_oAgent.id)
        Assert.AreEqual(oPool.id, m_oAgent.idPool)
        Assert.IsNotNull(m_oAgent.oPool)

        Assert.AreEqual("P1", m_oAgent.oPool.idCrodip)
        Assert.AreEqual(oPC.id, m_oAgent.oPool.idPC)
        Assert.AreEqual(oPC.idCrodip, m_oAgent.oPool.IDCRODIPPC)

        'Création d'un banc
        Dim obanc As Banc

        obanc = New Banc()
        obanc.id = "B1"
        BancManager.save(obanc)

        oPool.idBanc = obanc.id
        PoolManager.Save(oPool)

        oPool = PoolManager.getPoolById(oPool.id)

        Assert.AreEqual(obanc.id, oPool.idBanc)



    End Sub



End Class