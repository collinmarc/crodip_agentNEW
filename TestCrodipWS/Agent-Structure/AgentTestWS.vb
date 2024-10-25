Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class AgentTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim Agent As CRODIPWS.Agent
        Agent = AgentManager.WSgetByNumeroNational("TSTVT")
        Assert.AreEqual("TSTVT", Agent.numeroNational)
        Assert.IsNotNull(Agent)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oAgent As CRODIPWS.Agent
        oAgent = AgentManager.WSgetByNumeroNational("TSTVT")
        Assert.IsNotNull(oAgent)
        Dim Nom As String = "TEST" + Now
        oAgent.nom = Nom
        Dim oreturn As CRODIPWS.Agent
        Dim nReturn As Integer
        nReturn = AgentManager.WSSend(oAgent, oreturn)
        Assert.AreEqual(2, nReturn)
        oAgent = AgentManager.WSgetByNumeroNational("TSTVT")
        Assert.AreEqual(oAgent.nom, Nom)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oAgent As New Agent()
        oAgent.uidStructure = 22
        oAgent.numeroNational = "TU_MCO"
        oAgent.nom = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As Agent
        nreturn = AgentManager.WSSend(oAgent, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oAgent = AgentManager.WSgetByNumeroNational(oReturn.numeroNational)

        'Update de l'objet
        oAgent.nom = "TESTUPDATE"
        nreturn = AgentManager.WSSend(oAgent, oReturn)
        Assert.AreEqual(oAgent.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)

        'test sans modification
        oAgent = oReturn
        nreturn = AgentManager.WSSend(oAgent, oReturn)
        'Assert.AreEqual(0, nreturn)


    End Sub
    <TestMethod()> Public Sub CRUDWSIsGestionnaire()
        Dim nreturn As Integer
        Dim oAgent As New Agent()
        oAgent.uidstructure = 22
        oAgent.nom = "TESTMCO"
        oAgent.isGestionnaire = True

        ' Création de l'objet
        Dim oReturn As Agent
        nreturn = AgentManager.WSSend(oAgent, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oAgent = AgentManager.WSgetByNumeroNational(oReturn.numeroNational)
        Assert.AreEqual(True, oAgent.isGestionnaire)

        'Update de l'objet
        oAgent.nom = "TESTUPDATE"
        oAgent.isGestionnaire = False
        nreturn = AgentManager.WSSend(oAgent, oReturn)
        Assert.AreEqual(oAgent.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)

        'Lecture de l'objet
        oAgent = AgentManager.WSgetByNumeroNational(oAgent.numeroNational)
        Assert.AreEqual(False, oAgent.isGestionnaire)



    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oAgent As New CRODIPWS.Agent()
        oAgent.nom = "TEST"
        Dim serializer As New XmlSerializer(oAgent.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oAgent)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class