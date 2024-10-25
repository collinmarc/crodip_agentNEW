Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class FVManometreControleTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim FVManometreControle As CRODIPWS.FVManometreControle
        FVManometreControle = FVManometreControleManager.WSgetById(125255, "")
        Assert.IsNotNull(FVManometreControle)
        Assert.AreEqual(125255, FVManometreControle.uid)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oFVManometreControle As CRODIPWS.FVManometreControle
        oFVManometreControle = FVManometreControleManager.WSgetById(125255, "")
        Assert.IsNotNull(oFVManometreControle)
        Dim marque As String = "COUL" + Now
        oFVManometreControle.FVFileName = marque
        Dim oreturn As CRODIPWS.FVManometreControle
        Dim nReturn As Integer
        nReturn = FVManometreControleManager.WSSend(oFVManometreControle, oreturn)
        Assert.AreEqual(2, nReturn)
        oFVManometreControle = FVManometreControleManager.WSgetById(125255, "")
        Assert.AreEqual(oFVManometreControle.FVFileName, marque)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oFVManometreControle As New FVManometreControle()
        oFVManometreControle.uidstructure = 22
        oFVManometreControle.FVFileName = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As FVManometreControle
        nreturn = FVManometreControleManager.WSSend(oFVManometreControle, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)
        Assert.AreEqual(22, oReturn.uidstructure)

        'Lecture de l'objet
        oFVManometreControle = FVManometreControleManager.WSgetById(oReturn.uid, oReturn.aid)
        '        Assert.AreEqual(22, oFVManometreControle.uidstructure)
        Assert.AreEqual("TESTMCO", oFVManometreControle.FVFileName)
        Assert.AreEqual(22, oFVManometreControle.uidstructure)

        'Update de l'objet
        oFVManometreControle.FVFileName = "TESTUPDATE"
        nreturn = FVManometreControleManager.WSSend(oFVManometreControle, oReturn)
        Assert.AreEqual(oFVManometreControle.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        'Assert.AreEqual(22, oFVManometreControle.uidstructure)
        Assert.AreEqual("TESTUPDATE", oFVManometreControle.FVFileName)

    End Sub
    '<TestMethod()> Public Sub WSSerialize()
    '    Dim oFVManometreControle As New CRODIPWS.FVManometreControle()
    '    oFVManometreControle.marque = "TEST"
    '    Dim serializer As New XmlSerializer(oFVManometreControle.GetType())
    '    Using writer As New StringWriter()
    '        serializer.Serialize(writer, oFVManometreControle)
    '        Dim xmlOutput As String = writer.ToString()
    '        ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
    '        Trace.WriteLine(xmlOutput)
    '    End Using

    'End Sub


End Class