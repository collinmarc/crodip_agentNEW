Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CrodipWS

<TestClass()> Public Class PoolTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPool As New Pool()
        oPool.nbPastillesVertes = 15
        oPool.idCrodip = "123465"
        oPool.idStructure = m_oAgent.idStructure

        Assert.IsTrue(PoolManager.Save(oPool))
        Dim nId As String = oPool.idCrodip

        oPool = PoolManager.getPoolByIdCRODIP(nId)
        Assert.AreEqual(nId, oPool.idCrodip)
        Assert.AreEqual(15, oPool.nbPastillesVertes)
        Assert.AreEqual("123465", oPool.idCrodip)

        oPool.nbPastillesVertes = 5

        Assert.IsTrue(PoolManager.Save(oPool))

        oPool = PoolManager.getPoolByIdCRODIP(nId)
        Assert.AreEqual(nId, oPool.idCrodip)
        Assert.AreEqual(5, oPool.nbPastillesVertes)


    End Sub

    <TestMethod()> Public Sub AgentPool()

        m_oAgent.idCRODIPPool = ""
        AgentManager.save(m_oAgent)

        m_oAgent = AgentManager.getAgentById(m_oAgent.id)
        Assert.AreEqual("", m_oAgent.idCRODIPPool)
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
        oPool.idCRODIPPC = oPC.idCrodip
        oPool.idStructure = m_oStructure.id

        Assert.IsTrue(PoolManager.Save(oPool))

        'Rattachement de l'agent au pool
        m_oAgent.idCRODIPPool = oPool.idCrodip
        Assert.IsTrue(AgentManager.save(m_oAgent))

        'Rechargement de l'agent
        m_oAgent = AgentManager.getAgentById(m_oAgent.id)
        Assert.AreEqual(oPool.idCrodip, m_oAgent.idCRODIPPool)
        Assert.IsNotNull(m_oAgent.oPool)

        Assert.AreEqual("P1", m_oAgent.oPool.idCrodip)
        Assert.AreEqual(oPC.idCrodip, m_oAgent.oPool.idCRODIPPC)

        'Création d'un banc
        Dim obanc As Banc

        obanc = New Banc()
        obanc.id = "B1"
        BancManager.save(obanc)

        oPool.idBanc = obanc.id
        PoolManager.Save(oPool)

        oPool = PoolManager.getPoolByIdCRODIP(oPool.idCrodip)

        Assert.AreEqual(obanc.id, oPool.idBanc)



    End Sub



End Class