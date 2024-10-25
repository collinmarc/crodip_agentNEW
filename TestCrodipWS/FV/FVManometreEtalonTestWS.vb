Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class FVManometreEtalonTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim FVManometreEtalon As CRODIPWS.FVManometreEtalon
        FVManometreEtalon = FVManometreEtalonManager.WSgetById(7180, "")
        Assert.IsNotNull(FVManometreEtalon)
        Assert.AreEqual(7180, FVManometreEtalon.uid)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oFVManometreEtalon As CRODIPWS.FVManometreEtalon
        oFVManometreEtalon = FVManometreEtalonManager.WSgetById(7180, "")
        Assert.IsNotNull(oFVManometreEtalon)
        Dim marque As String = "COUL" + Now
        oFVManometreEtalon.FVFileName = marque
        Dim oreturn As CRODIPWS.FVManometreEtalon
        Dim nReturn As Integer
        nReturn = FVManometreEtalonManager.WSSend(oFVManometreEtalon, oreturn)
        Assert.AreEqual(2, nReturn)
        oFVManometreEtalon = FVManometreEtalonManager.WSgetById(7180, "")
        Assert.AreEqual(oFVManometreEtalon.FVFileName, marque)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oFVManometreEtalon As New FVManometreEtalon()
        oFVManometreEtalon.uidstructure = 22
        oFVManometreEtalon.FVFileName = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As FVManometreEtalon
        nreturn = FVManometreEtalonManager.WSSend(oFVManometreEtalon, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)
        Assert.AreEqual(22, oReturn.uidstructure)

        'Lecture de l'objet
        oFVManometreEtalon = FVManometreEtalonManager.WSgetById(oReturn.uid, oReturn.aid)
        '        Assert.AreEqual(22, oFVManometreEtalon.uidstructure)
        Assert.AreEqual("TESTMCO", oFVManometreEtalon.FVFileName)
        Assert.AreEqual(22, oFVManometreEtalon.uidstructure)

        'Update de l'objet
        oFVManometreEtalon.FVFileName = "TESTUPDATE"
        nreturn = FVManometreEtalonManager.WSSend(oFVManometreEtalon, oReturn)
        Assert.AreEqual(oFVManometreEtalon.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        'Assert.AreEqual(22, oFVManometreEtalon.uidstructure)
        Assert.AreEqual("TESTUPDATE", oFVManometreEtalon.FVFileName)

    End Sub
    '<TestMethod()> Public Sub WSSerialize()
    '    Dim oFVManometreEtalon As New CRODIPWS.FVManometreEtalon()
    '    oFVManometreEtalon.marque = "TEST"
    '    Dim serializer As New XmlSerializer(oFVManometreEtalon.GetType())
    '    Using writer As New StringWriter()
    '        serializer.Serialize(writer, oFVManometreEtalon)
    '        Dim xmlOutput As String = writer.ToString()
    '        ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
    '        Trace.WriteLine(xmlOutput)
    '    End Using

    'End Sub


End Class