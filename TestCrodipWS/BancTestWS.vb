Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class BancTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim Banc As CRODIPWS.Banc
        Banc = BancManager.WSgetById(2)
        Assert.AreEqual(2, Banc.uid)
        Assert.IsNotNull(Banc)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oBanc As CRODIPWS.Banc
        oBanc = BancManager.WSgetById(2)
        Assert.IsNotNull(oBanc)
        Dim marque As String = "COUL" + Now
        oBanc.marque = marque
        Dim oreturn As CRODIPWS.Banc
        Dim nReturn As Integer
        nReturn = BancManager.WSSend(oBanc, oreturn)
        Assert.AreEqual(2, nReturn)
        oBanc = BancManager.WSgetById(2)
        Assert.AreEqual(oBanc.marque, marque)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oBanc As New Banc()
        oBanc.uidstructure = 22
        oBanc.marque = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As Banc
        nreturn = BancManager.WSSend(oBanc, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oBanc = BancManager.WSgetById(oReturn.uid)
        Assert.AreEqual(22, oBanc.uidstructure)
        Assert.AreEqual("TESTMCO", oBanc.marque)

        'Update de l'objet
        oBanc.marque = "TESTUPDATE"
        nreturn = BancManager.WSSend(oBanc, oReturn)
        Assert.AreEqual(oBanc.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.AreEqual(22, oBanc.uidstructure)
        Assert.AreEqual("TESTUPDATE", oBanc.marque)

    End Sub
    <TestMethod()> Public Sub CRUDWSnbControle()
        Dim nreturn As Integer
        Dim oBanc As New Banc()
        oBanc.uidstructure = 22
        oBanc.nbControles = 0
        oBanc.nbControlesTotal = 0

        ' Création de l'objet
        Dim oReturn As Banc
        nreturn = BancManager.WSSend(oBanc, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oBanc = BancManager.WSgetById(oReturn.uid)
        Assert.AreEqual(22, oBanc.uidstructure)
        Assert.AreEqual(0, oBanc.nbControles)
        Assert.AreEqual(0, oBanc.nbControlesTotal)

        'Update de l'objet
        oBanc.nbControles = 10
        oBanc.nbControlesTotal = 15
        nreturn = BancManager.WSSend(oBanc, oReturn)
        Assert.AreEqual(oBanc.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.AreEqual(10, oBanc.nbControles)
        Assert.AreEqual(15, oBanc.nbControlesTotal)

    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oBanc As New CRODIPWS.Banc()
        oBanc.marque = "TEST"
        Dim serializer As New XmlSerializer(oBanc.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oBanc)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class