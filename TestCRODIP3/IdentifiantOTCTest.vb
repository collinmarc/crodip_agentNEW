Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports CrodipWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class IdentifiantOTCTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub IdentOTCTest()
        Dim oListe As New List(Of IdentifiantOTC)

        oListe.Add(New IdentifiantOTC("E001123546"))
        oListe.Add(New IdentifiantOTC("E001123547"))
        oListe.Add(New IdentifiantOTC("E001123548"))
        oListe.Add(New IdentifiantOTC("E001123549"))
        oListe.Add(New IdentifiantOTC("E001123540"))

        IdentifiantOTCManager.SaveList(oListe)

        Assert.IsTrue(IdentifiantOTCManager.exists("E001123548"))
        Assert.IsFalse(IdentifiantOTCManager.exists("Z001123458"))
    End Sub
    <TestMethod()> Public Sub IdentOTCWSGetListTest()
        Dim oListe As New List(Of IdentifiantOTC)
        oListe = IdentifiantOTCManager.WSGetList()
        Assert.IsNotNull(oListe)
        Assert.IsTrue(IdentifiantOTCManager.SaveList(oListe))

    End Sub
    <TestMethod()> Public Sub WSGetIdentifiantOTCTest()
        Dim oIdentOTC As IdentifiantOTC
        Dim oCSDB As New CSDb(True)
        oCSDB.Execute("DELETE FROM IdentifiantOTC where IdentOTC = 'E001000000'")
        Assert.IsFalse(IdentifiantOTCManager.exists("E001000000"))
        oIdentOTC = IdentifiantOTCManager.WSgetById(0, "E001000000", m_oAgent.uid)
        IdentifiantOTCManager.Save(oIdentOTC)
        Assert.IsTrue(IdentifiantOTCManager.exists("E001000000"))


    End Sub

End Class