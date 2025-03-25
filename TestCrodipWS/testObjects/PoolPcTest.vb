Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CRODIPWS

<TestClass()> Public Class PoolPcTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPoolPc As New PoolPc()
        Dim oPoolPc2 As PoolPc
        oPoolPc.uid = 12345
        oPoolPc.aid = "P12345"
        oPoolPc.namepool = "NOM12345"
        oPoolPc.uidpc = m_oAgent.uid
        oPoolPc.idPc = m_oAgent.aid
        oPoolPc.uidstructure = m_oAgent.idStructure
        oPoolPc.dateAssociation = New Date(2025, 3, 25, 10, 27, 0)

        Assert.IsTrue(PoolPcManager.Save(oPoolPc))

        oPoolPc2 = PoolPcManager.GetByuid(12345)
        Assert.IsNotNull(oPoolPc2)
        Assert.AreEqual(oPoolPc.uid, oPoolPc2.uid)
        Assert.AreEqual(oPoolPc.aid, oPoolPc2.aid)
        Assert.AreEqual(oPoolPc.namepool, oPoolPc2.namepool)
        Assert.AreEqual(oPoolPc.uidpc, oPoolPc2.uidpc)
        Assert.AreEqual(oPoolPc.idPc, oPoolPc2.idPc)
        Assert.AreEqual(oPoolPc.uidstructure, oPoolPc2.uidstructure)
        Assert.AreEqual(oPoolPc.dateAssociation, oPoolPc2.dateAssociation)

        oPoolPc.namepool = "TEST2"
        PoolPcManager.Save(oPoolPc)
        oPoolPc2 = PoolPcManager.GetByuid(12345)
        Assert.IsNotNull(oPoolPc2)
        Assert.AreEqual(oPoolPc.namepool, oPoolPc2.namepool)

    End Sub
    <TestMethod()> Public Sub WSCRUD()
        Dim oPoolPc As PoolPc
        Dim oPool2 As PoolPc = Nothing
        Dim nReturn As Integer

        oPoolPc = PoolPcManager.WSgetById(1, "")

        Assert.AreEqual(1, oPoolPc.uid)

        oPoolPc.namepool = "PoolPc2"
        oPoolPc.dateAssociation = New Date(2025, 3, 25, 14, 13, 0)
        Assert.IsTrue(PoolPcManager.Save(oPoolPc))

        nReturn = PoolPcManager.WSSend(oPoolPc, oPool2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")

        oPoolPc = PoolPcManager.WSgetById(oPool2.uid, oPool2.aid)

        Assert.AreEqual("PoolPc2", oPoolPc.namepool)
        Assert.AreEqual(New Date(2025, 3, 25, 14, 13, 0), oPoolPc.dateAssociation)

    End Sub




End Class