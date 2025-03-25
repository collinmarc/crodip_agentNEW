Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CRODIPWS

<TestClass()> Public Class PoolManoControleTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPoolManoControle As New PoolManoControle()
        Dim oPoolManoControle2 As PoolManoControle
        oPoolManoControle.uid = 12345
        oPoolManoControle.aid = "P12345"
        oPoolManoControle.namepool = "NOM12345"
        oPoolManoControle.uidmanoc = 456
        oPoolManoControle.idManometre = '0456'
        oPoolManoControle.uidstructure = m_oAgent.idStructure
        oPoolManoControle.dateAssociation = New Date(2025, 3, 25, 10, 27, 0)

        Assert.IsTrue(PoolManoControleManager.Save(oPoolManoControle))

        oPoolManoControle2 = PoolManoControleManager.GetByuid(12345)
        Assert.IsNotNull(oPoolManoControle2)
        Assert.AreEqual(oPoolManoControle.uid, oPoolManoControle2.uid)
        Assert.AreEqual(oPoolManoControle.aid, oPoolManoControle2.aid)
        Assert.AreEqual(oPoolManoControle.namepool, oPoolManoControle2.namepool)
        Assert.AreEqual(oPoolManoControle.uidmanoc, oPoolManoControle2.uidmanoc)
        Assert.AreEqual(oPoolManoControle.idManometre, oPoolManoControle2.idManometre)
        Assert.AreEqual(oPoolManoControle.uidstructure, oPoolManoControle2.uidstructure)
        Assert.AreEqual(oPoolManoControle.dateAssociation, oPoolManoControle2.dateAssociation)

        oPoolManoControle.namepool = "TEST2"
        PoolManoControleManager.Save(oPoolManoControle)
        oPoolManoControle2 = PoolManoControleManager.GetByuid(12345)
        Assert.IsNotNull(oPoolManoControle2)
        Assert.AreEqual(oPoolManoControle.namepool, oPoolManoControle2.namepool)

    End Sub
    <TestMethod()> Public Sub WSCRUD()
        Dim oPoolManoControle As PoolManoControle
        Dim oPool2 As PoolManoControle = Nothing
        Dim nReturn As Integer

        oPoolManoControle = PoolManoControleManager.WSgetById(1, "")

        Assert.AreEqual(1, oPoolManoControle.uid)

        oPoolManoControle.namepool = "PoolManoControle2"
        oPoolManoControle.dateAssociation = New Date(2025, 3, 25, 15, 3, 0)
        Assert.IsTrue(PoolManoControleManager.Save(oPoolManoControle))

        nReturn = PoolManoControleManager.WSSend(oPoolManoControle, oPool2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")

        oPoolManoControle = PoolManoControleManager.WSgetById(oPool2.uid, oPool2.aid)

        Assert.AreEqual("PoolManoControle2", oPoolManoControle.namepool)
        Assert.AreEqual(New Date(2025, 3, 25, 15, 3, 0), oPoolManoControle.dateAssociation)

    End Sub




End Class