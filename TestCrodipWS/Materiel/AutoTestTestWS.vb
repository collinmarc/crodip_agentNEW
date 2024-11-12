Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class AutoTestTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim AutoTest As CRODIPWS.AutoTest
        AutoTest = AutoTestManager.WSgetById(39171, "")
        Assert.AreEqual(39171, AutoTest.uid)
        Assert.IsNotNull(AutoTest)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oAutoTest As CRODIPWS.AutoTest
        oAutoTest = AutoTestManager.WSgetById(39171, "")
        Assert.IsNotNull(oAutoTest)
        oAutoTest.etat = 1
        Dim oreturn As CRODIPWS.AutoTest
        Dim nReturn As Integer
        nReturn = AutoTestManager.WSSend(oAutoTest, oreturn)
        Assert.AreEqual(2, nReturn)
        oAutoTest = AutoTestManager.WSgetById(39171, "")
        Assert.AreEqual(1, oAutoTest.etat)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oAutoTest As New AutoTest(m_oAgent)
        oAutoTest.etat = 2

        ' Création de l'objet
        Dim oReturn As AutoTest
        nreturn = AutoTestManager.WSSend(oAutoTest, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oAutoTest = AutoTestManager.WSgetById(oReturn.uid, oReturn.aid)
        Assert.AreEqual(22, oAutoTest.uidstructure)
        Assert.AreEqual(2, oAutoTest.etat)

        'Update de l'objet
        oAutoTest.etat = 3
        nreturn = AutoTestManager.WSSend(oAutoTest, oReturn)
        Assert.AreEqual(oAutoTest.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.AreEqual(22, oAutoTest.uidstructure)
        Assert.AreEqual(3, oAutoTest.etat)

    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oAutoTest As New CRODIPWS.AutoTest()
        oAutoTest.etat = 1
        Dim serializer As New XmlSerializer(oAutoTest.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oAutoTest)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class