Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CRODIPWS

<TestClass()> Public Class PoolbuseTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPoolbuse As New PoolBuse()
        Dim oPoolbuse2 As PoolBuse
        oPoolbuse.uid = 12345
        oPoolbuse.aid = "P12345"
        oPoolbuse.namepool = "NOM12345"
        oPoolbuse.uidbuse = 456
        oPoolbuse.idBuse = '0456'
        oPoolbuse.uidstructure = m_oAgent.idStructure
        oPoolbuse.dateAssociation = New Date(2025, 3, 25, 10, 27, 0)

        Assert.IsTrue(PoolBuseManager.Save(oPoolbuse))

        oPoolbuse2 = PoolBuseManager.GetByuid(12345)
        Assert.IsNotNull(oPoolbuse2)
        Assert.AreEqual(oPoolbuse.uid, oPoolbuse2.uid)
        Assert.AreEqual(oPoolbuse.aid, oPoolbuse2.aid)
        Assert.AreEqual(oPoolbuse.namepool, oPoolbuse2.namepool)
        Assert.AreEqual(oPoolbuse.uidbuse, oPoolbuse2.uidbuse)
        Assert.AreEqual(oPoolbuse.idBuse, oPoolbuse2.idBuse)
        Assert.AreEqual(oPoolbuse.uidstructure, oPoolbuse2.uidstructure)
        Assert.AreEqual(oPoolbuse.dateAssociation, oPoolbuse2.dateAssociation)

        oPoolbuse.namepool = "TEST2"
        PoolBuseManager.Save(oPoolbuse)
        oPoolbuse2 = PoolBuseManager.GetByuid(12345)
        Assert.IsNotNull(oPoolbuse2)
        Assert.AreEqual(oPoolbuse.namepool, oPoolbuse2.namepool)

    End Sub
    <TestMethod()> Public Sub WSCRUD()
        Dim oPoolbuse As PoolBuse
        Dim oPool2 As PoolBuse = Nothing
        Dim nReturn As Integer

        oPoolbuse = PoolBuseManager.WSgetById(1, "")

        Assert.AreEqual(1, oPoolbuse.uid)

        oPoolbuse.namepool = "Poolbuse2"
        oPoolbuse.dateAssociation = New Date(2025, 3, 25, 15, 3, 0)
        Assert.IsTrue(PoolBuseManager.Save(oPoolbuse))

        nReturn = PoolBuseManager.WSSend(oPoolbuse, oPool2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")

        oPoolbuse = PoolBuseManager.WSgetById(oPool2.uid, oPool2.aid)

        Assert.AreEqual("Poolbuse2", oPoolbuse.namepool)
        Assert.AreEqual(New Date(2025, 3, 25, 15, 3, 0), oPoolbuse.dateAssociation)

    End Sub




End Class