Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CrodipWS

<TestClass()> Public Class PoolTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPool As New Pool()
        oPool.libelle = "Pool1"
        oPool.idPool = "123465"
        oPool.uidstructure = m_oAgent.idStructure

        Assert.IsTrue(PoolManager.Save(oPool))
        Dim nIdPool As String = oPool.idPool

        oPool = PoolManager.getPoolByIdPool(nIdPool)
        Assert.AreEqual(nIdPool, oPool.idCrodip)
        Assert.AreEqual("Pool1", oPool.libelle)
        Assert.AreEqual("123465", oPool.idPool)

        oPool.libelle = "Pool2"

        Assert.IsTrue(PoolManager.Save(oPool))

        oPool = PoolManager.getPoolByIdPool(nIdPool)
        Assert.AreEqual(nIdPool, oPool.idPool)
        Assert.AreEqual("Pool2", oPool.libelle)


    End Sub
    <TestMethod()> Public Sub WSCRUD()
        Dim oPool As New Pool()
        Dim oPool2 As Pool = Nothing
        Dim nReturn As Integer
        oPool.libelle = "Pool1"
        oPool.idCrodip = "123465"
        oPool.uidstructure = m_oAgent.idStructure

        Assert.IsTrue(PoolManager.Save(oPool))
        Dim nId As String = oPool.idPool

        Assert.IsTrue(PoolManager.Save(oPool))

        nReturn = PoolManager.WSSend(oPool, oPool2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")
        Assert.IsNotNull(oPool2)
        Assert.AreNotEqual(0, oPool2.uid)
        Assert.AreEqual(oPool.idPool, oPool2.idPool)
        Assert.AreEqual(oPool.libelle, oPool2.libelle)

        oPool = PoolManager.WSgetById(oPool2.uid, oPool2.idPool)

        Assert.AreEqual(oPool2.uid, oPool.uid)
        Assert.AreEqual(oPool2.idPool, oPool.idPool)
        Assert.AreEqual(oPool2.libelle, oPool.libelle)


        oPool.libelle = "Pool2"
        Assert.IsTrue(PoolManager.Save(oPool))

        nReturn = PoolManager.WSSend(oPool, oPool2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")

        oPool = PoolManager.WSgetById(oPool2.uid, oPool2.idPool)

        Assert.AreEqual("Pool2", oPool.libelle)



    End Sub




End Class