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
        oPool.uidStructure = m_oAgent.uidStructure

        Assert.IsTrue(PoolManager.Save(oPool))
        Dim nId As String = oPool.idCrodip

        oPool = PoolManager.getPoolByIdPool(nId)
        Assert.AreEqual(nId, oPool.idCrodip)
        Assert.AreEqual(15, oPool.nbPastillesVertes)
        Assert.AreEqual("123465", oPool.idCrodip)

        oPool.nbPastillesVertes = 5

        Assert.IsTrue(PoolManager.Save(oPool))

        oPool = PoolManager.getPoolByIdPool(nId)
        Assert.AreEqual(nId, oPool.idCrodip)
        Assert.AreEqual(5, oPool.nbPastillesVertes)


    End Sub

    <TestMethod()> Public Sub AgentPool()

        m_oAgent.oPool = Nothing
        AgentManager.save(m_oAgent)

        m_oAgent = AgentManager.getAgentById(m_oAgent.id)
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
        'oPool.idCRODIPPC = oPC.idCrodip
        oPool.uidStructure = m_oStructure.id

        Assert.IsTrue(PoolManager.Save(oPool))

        'Rattachement de l'agent au pool
        m_oAgent.oPool = oPool
        Assert.IsTrue(AgentManager.save(m_oAgent))

        'Rechargement de l'agent
        m_oAgent = AgentManager.getAgentById(m_oAgent.id)
        Assert.AreEqual(oPool.idCrodip, m_oAgent.oPool.idCrodip)
        Assert.IsNotNull(m_oAgent.oPool)

        Assert.AreEqual("P1", m_oAgent.oPool.idCrodip)
        Assert.AreEqual(oPC.idCrodip, m_oAgent.oPCcourant.idCrodip)

        'Création d'un banc
        Dim obanc As Banc

        obanc = New Banc()
        obanc.id = "B1"
        BancManager.save(obanc)

        oPool.uidbanc = obanc.uid
        PoolManager.Save(oPool)

        oPool = PoolManager.getPoolByIdPool(oPool.idCrodip)

        Assert.AreEqual(obanc.uid, oPool.uidbanc)



    End Sub



End Class