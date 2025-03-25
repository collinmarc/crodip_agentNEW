Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32
Imports CRODIPWS

<TestClass()> Public Class PoolManoEtalonTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()
        Dim oPoolManoEtalon As New PoolManoEtalon()
        Dim oPoolManoEtalon2 As PoolManoEtalon
        oPoolManoEtalon.uid = 12345
        oPoolManoEtalon.aid = "P12345"
        oPoolManoEtalon.namepool = "NOM12345"
        oPoolManoEtalon.uidmanoe = 456
        oPoolManoEtalon.idManometre = '0456'
        oPoolManoEtalon.uidstructure = m_oAgent.idStructure
        oPoolManoEtalon.dateAssociation = New Date(2025, 3, 25, 10, 27, 0)

        Assert.IsTrue(PoolManoEtalonManager.Save(oPoolManoEtalon))

        oPoolManoEtalon2 = PoolManoEtalonManager.GetByuid(12345)
        Assert.IsNotNull(oPoolManoEtalon2)
        Assert.AreEqual(oPoolManoEtalon.uid, oPoolManoEtalon2.uid)
        Assert.AreEqual(oPoolManoEtalon.aid, oPoolManoEtalon2.aid)
        Assert.AreEqual(oPoolManoEtalon.namepool, oPoolManoEtalon2.namepool)
        Assert.AreEqual(oPoolManoEtalon.uidmanoe, oPoolManoEtalon2.uidmanoe)
        Assert.AreEqual(oPoolManoEtalon.idManometre, oPoolManoEtalon2.idManometre)
        Assert.AreEqual(oPoolManoEtalon.uidstructure, oPoolManoEtalon2.uidstructure)
        Assert.AreEqual(oPoolManoEtalon.dateAssociation, oPoolManoEtalon2.dateAssociation)

        oPoolManoEtalon.namepool = "TEST2"
        PoolManoEtalonManager.Save(oPoolManoEtalon)
        oPoolManoEtalon2 = PoolManoEtalonManager.GetByuid(12345)
        Assert.IsNotNull(oPoolManoEtalon2)
        Assert.AreEqual(oPoolManoEtalon.namepool, oPoolManoEtalon2.namepool)

    End Sub
    <TestMethod()> Public Sub WSCRUD()
        Dim oPoolManoEtalon As PoolManoEtalon
        Dim oPool2 As PoolManoEtalon = Nothing
        Dim nReturn As Integer

        oPoolManoEtalon = PoolManoEtalonManager.WSgetById(1, "")

        Assert.AreEqual(1, oPoolManoEtalon.uid)

        oPoolManoEtalon.namepool = "PoolManoEtalon2"
        oPoolManoEtalon.dateAssociation = New Date(2025, 3, 25, 15, 3, 0)
        Assert.IsTrue(PoolManoEtalonManager.Save(oPoolManoEtalon))

        nReturn = PoolManoEtalonManager.WSSend(oPoolManoEtalon, oPool2)
        Assert.AreEqual(2, nReturn, "Code Retour = 2")

        oPoolManoEtalon = PoolManoEtalonManager.WSgetById(oPool2.uid, oPool2.aid)

        Assert.AreEqual("PoolManoEtalon2", oPoolManoEtalon.namepool)
        Assert.AreEqual(New Date(2025, 3, 25, 15, 3, 0), oPoolManoEtalon.dateAssociation)

    End Sub
End Class