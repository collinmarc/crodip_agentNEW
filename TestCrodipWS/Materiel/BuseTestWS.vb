Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class BuseTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim oMano As CRODIPWS.Buse
        oMano = BuseManager.WSgetById(1473, "")
        Assert.AreEqual(1473, oMano.uid)
        Assert.IsNotNull(oMano)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oBuse As CRODIPWS.Buse
        oBuse = BuseManager.WSgetById(1473, "")
        Assert.IsNotNull(oBuse)
        Dim couleur As String = "COUL" + Now
        oBuse.couleur = couleur
        Dim oreturn As CRODIPWS.Buse
        Dim nReturn As Integer
        nReturn = BuseManager.WSSend(oBuse, oreturn)
        Assert.AreEqual(2, nReturn)
        oBuse = BuseManager.WSgetById(1473, "")
        Assert.AreEqual(oBuse.couleur, couleur)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oBuse As New Buse()
        oBuse.uidstructure = 22
        oBuse.couleur = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As Buse
        nreturn = BuseManager.WSSend(oBuse, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oBuse = BuseManager.WSgetById(oReturn.uid, "")
        Assert.AreEqual("TESTMCO", oBuse.couleur)

        'Update de l'objet
        oBuse.couleur = "TESTUPDATE"
        nreturn = BuseManager.WSSend(oBuse, oReturn)
        Assert.AreEqual(oBuse.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        'Lecture de l'objet
        oBuse = BuseManager.WSgetById(oReturn.uid, "")
        Assert.AreEqual("TESTUPDATE", oBuse.couleur)



    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oMano As New CRODIPWS.Buse()
        oMano.couleur = "TEST"
        Dim serializer As New XmlSerializer(oMano.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oMano)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class