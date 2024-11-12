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
        IdentifiantPulverisateur = IdentifiantPulverisateurManager.WSgetById(1187, 34443, "")
        Assert.AreEqual(34443, IdentifiantPulverisateur.uid)
        Assert.IsNotNull(IdentifiantPulverisateur)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oIdentifiantPulverisateur As CRODIPWS.IdentifiantPulverisateur
        oIdentifiantPulverisateur = IdentifiantPulverisateurManager.WSgetById(1187, 34443, "")
        If oIdentifiantPulverisateur Is Nothing Then
            Exit Sub
        End If

        oIdentifiantPulverisateur.SetEtatUTILISE()
        oIdentifiantPulverisateur.libelle = "TESTMCO"
        oIdentifiantPulverisateur.numeroNational = "741852"

        Dim oreturn As CRODIPWS.IdentifiantPulverisateur
        Dim nReturn As Integer
        nReturn = IdentifiantPulverisateurManager.WSSend(1187, oIdentifiantPulverisateur, oreturn)
        Assert.AreEqual(2, nReturn)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oIdentifiantPulverisateur As CRODIPWS.IdentifiantPulverisateur
        oIdentifiantPulverisateur = IdentifiantPulverisateurManager.WSgetById(1187, 34443, "")
        oIdentifiantPulverisateur.SetEtatINUTILISABLE()

        ' Création de l'objet
        Dim oReturn As IdentifiantPulverisateur
        nreturn = IdentifiantPulverisateurManager.WSSend(1187, oIdentifiantPulverisateur, oReturn)
        Assert.AreEqual(2, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oIdentifiantPulverisateur = IdentifiantPulverisateurManager.WSgetById(1187, oReturn.uid, oReturn.aid)
        Assert.IsTrue(oIdentifiantPulverisateur.isEtatINUTILISABLE)

        'Update de l'objet
        oIdentifiantPulverisateur.SetEtatINUTILISE()
        nreturn = IdentifiantPulverisateurManager.WSSend(1187, oIdentifiantPulverisateur, oReturn)
        Assert.AreEqual(oIdentifiantPulverisateur.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.IsTrue(oIdentifiantPulverisateur.isEtatINUTILISE())

    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oIdentifiantPulverisateur As New CRODIPWS.IdentifiantPulverisateur()
        oIdentifiantPulverisateur.SetEtatINUTILISE()
        Dim serializer As New XmlSerializer(oIdentifiantPulverisateur.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oIdentifiantPulverisateur)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class