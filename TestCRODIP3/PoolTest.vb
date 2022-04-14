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


End Class