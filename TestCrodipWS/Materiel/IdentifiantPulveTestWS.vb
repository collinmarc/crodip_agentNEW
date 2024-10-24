Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class IdentifiantPulverisateurTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim IdentifiantPulverisateur As CRODIPWS.IdentifiantPulverisateur
        IdentifiantPulverisateur = IdentifiantPulverisateurManager.WSgetById(34446)
        Assert.AreEqual(39171, IdentifiantPulverisateur.uid)
        Assert.IsNotNull(IdentifiantPulverisateur)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oIdentifiantPulverisateur As New CRODIPWS.IdentifiantPulverisateur()

        oIdentifiantPulverisateur.SetEtatUTILISE()
        oIdentifiantPulverisateur.idStructure = 22
        oIdentifiantPulverisateur.libelle = "TESTMCO"
        oIdentifiantPulverisateur.numeroNational = "741852"
        oIdentifiantPulverisateur.uidstructure = 22

        Dim oreturn As CRODIPWS.IdentifiantPulverisateur
        Dim nReturn As Integer
        nReturn = IdentifiantPulverisateurManager.WSSend(oIdentifiantPulverisateur, oreturn)
        Assert.AreEqual(4, nReturn)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oIdentifiantPulverisateur As New IdentifiantPulverisateur()
        oIdentifiantPulverisateur.uidstructure = 22
        oIdentifiantPulverisateur.etat = 2

        ' Création de l'objet
        Dim oReturn As IdentifiantPulverisateur
        nreturn = IdentifiantPulverisateurManager.WSSend(oIdentifiantPulverisateur, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oIdentifiantPulverisateur = IdentifiantPulverisateurManager.WSgetById(oReturn.uid)
        Assert.AreEqual(22, oIdentifiantPulverisateur.uidstructure)
        Assert.AreEqual(2, oIdentifiantPulverisateur.etat)

        'Update de l'objet
        oIdentifiantPulverisateur.etat = 3
        nreturn = IdentifiantPulverisateurManager.WSSend(oIdentifiantPulverisateur, oReturn)
        Assert.AreEqual(oIdentifiantPulverisateur.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.AreEqual(22, oIdentifiantPulverisateur.uidstructure)
        Assert.AreEqual(3, oIdentifiantPulverisateur.etat)

    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oIdentifiantPulverisateur As New CRODIPWS.IdentifiantPulverisateur()
        oIdentifiantPulverisateur.etat = 1
        Dim serializer As New XmlSerializer(oIdentifiantPulverisateur.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oIdentifiantPulverisateur)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class