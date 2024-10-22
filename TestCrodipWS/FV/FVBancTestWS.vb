Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class FVFVBancTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim FVFVBanc As CRODIPWS.FVBanc
        FVFVBanc = FVBancManager.WSgetById(9491)
        Assert.IsNotNull(FVFVBanc)
        Assert.AreEqual(9491, FVFVBanc.uid)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oFVBanc As CRODIPWS.FVBanc
        oFVBanc = FVBancManager.WSgetById(9491)
        Assert.IsNotNull(oFVBanc)
        Dim marque As String = "COUL" + Now
        oFVBanc.FVFileName = marque
        Dim oreturn As CRODIPWS.FVBanc
        Dim nReturn As Integer
        nReturn = FVBancManager.WSSend(oFVBanc, oreturn)
        Assert.AreEqual(2, nReturn)
        oFVBanc = FVBancManager.WSgetById(9491)
        Assert.AreEqual(oFVBanc.FVFileName, marque)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oFVBanc As New FVBanc()
        oFVBanc.uidstructure = 22
        oFVBanc.FVFileName = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As FVBanc
        nreturn = FVBancManager.WSSend(oFVBanc, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oFVBanc = FVBancManager.WSgetById(oReturn.uid)
        Assert.AreEqual(22, oFVBanc.uidstructure)
        Assert.AreEqual("TESTMCO", oFVBanc.FVFileName)

        'Update de l'objet
        oFVBanc.FVFileName = "TESTUPDATE"
        nreturn = FVBancManager.WSSend(oFVBanc, oReturn)
        Assert.AreEqual(oFVBanc.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.AreEqual(22, oFVBanc.uidstructure)
        Assert.AreEqual("TESTUPDATE", oFVBanc.FVFileName)

    End Sub
    '<TestMethod()> Public Sub WSSerialize()
    '    Dim oFVBanc As New CRODIPWS.FVBanc()
    '    oFVBanc.marque = "TEST"
    '    Dim serializer As New XmlSerializer(oFVBanc.GetType())
    '    Using writer As New StringWriter()
    '        serializer.Serialize(writer, oFVBanc)
    '        Dim xmlOutput As String = writer.ToString()
    '        ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
    '        Trace.WriteLine(xmlOutput)
    '    End Using

    'End Sub


End Class