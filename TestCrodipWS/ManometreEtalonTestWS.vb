Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class ManometreEtalonTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim oMano As CRODIPWS.ManometreEtalon
        oMano = ManometreEtalonManager.WSgetById(150)
        Assert.AreEqual(150, oMano.uid)
        Assert.IsNotNull(oMano)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oMano As CRODIPWS.ManometreEtalon
        oMano = ManometreEtalonManager.WSgetById(150)
        Assert.IsNotNull(oMano)
        Dim marque As String = "TEST" + Now
        oMano.marque = marque
        oMano.classe = "CL8"
        Dim oreturn As CRODIPWS.ManometreEtalon
        Dim nReturn As Integer
        nReturn = ManometreEtalonManager.WSSend(oMano, oreturn)
        Assert.AreEqual(2, nReturn)
        oMano = ManometreEtalonManager.WSgetById(150)
        Assert.AreEqual(oMano.marque, marque)
        Assert.AreEqual(oMano.classe, "CL8")

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oMano As New ManometreEtalon()
        oMano.uidstructure = 22
        oMano.numeroNational = "MANO22"
        oMano.marque = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As ManometreEtalon
        nreturn = ManometreEtalonManager.WSSend(oMano, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oMano = ManometreEtalonManager.WSgetById(oReturn.uid)

        'Update de l'objet
        oMano.marque = "TESTUPDATE"
        nreturn = ManometreEtalonManager.WSSend(oMano, oReturn)
        Assert.AreEqual(oMano.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)

        'test sans modification
        oMano = oReturn
        nreturn = ManometreEtalonManager.WSSend(oMano, oReturn)
        'Assert.AreEqual(0, nreturn)


    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oMano As New CRODIPWS.ManometreEtalon()
        oMano.marque = "TEST"
        oMano.classe = "CL8"
        oMano.incertitudeEtalon = "9"
        Dim serializer As New XmlSerializer(oMano.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oMano)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class