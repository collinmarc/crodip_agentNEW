Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class StructureTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim oStruct As CRODIPWS.Structure
        oStruct = StructureManager.WSgetById(22, "")
        Assert.AreEqual(22, oStruct.uid)
        Assert.IsNotNull(oStruct)

    End Sub
        <TestMethod()> Public Sub sendWS()
            Dim oStructure As CRODIPWS.Structure
        oStructure = StructureManager.WSgetById(22, "")
        Assert.IsNotNull(oStructure)
        oStructure.nom = "TESTMCO"
        Dim oreturn As CRODIPWS.Structure
            Dim nReturn As Integer
            nReturn = StructureManager.WSSend(oStructure, oreturn)
            Assert.AreEqual(2, nReturn)
        oStructure = StructureManager.WSgetById(22, "")
        Assert.AreEqual("TESTMCO", oStructure.nom)

    End Sub
        <TestMethod()> Public Sub CRUDWS()
            Dim nreturn As Integer
            Dim oStructure As New [Structure]()
        oStructure.nom = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As [Structure]
            nreturn = StructureManager.WSSend(oStructure, oReturn)
            Assert.AreEqual(4, nreturn)
            Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oStructure = StructureManager.WSgetById(oReturn.uid, oReturn.aid)
        Assert.AreEqual("TESTMCO", oStructure.nom)

        'Update de l'objet
        oStructure.nom = "TESTUPDATE"
        nreturn = StructureManager.WSSend(oStructure, oReturn)
            Assert.AreEqual(oStructure.uid, oReturn.uid)
            Assert.AreEqual(2, nreturn)
        Assert.AreEqual("TESTUPDATE", oStructure.nom)

    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oStructure As New CRODIPWS.Structure()
        oStructure.nom = "TEST"
        Dim serializer As New XmlSerializer(oStructure.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oStructure)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class