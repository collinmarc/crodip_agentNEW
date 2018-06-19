Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class RPParamTest

    <TestMethod()> Public Sub TestXML()
        Dim oParam As RPParam

        If System.IO.File.Exists(RPParam.xmlFileName) Then
            System.IO.File.Delete(RPParam.xmlFileName)
        End If

        'Chargement sans fichier

        oParam = RPParam.readXML()
        Assert.IsNotNull(oParam)
        Assert.IsTrue(String.IsNullOrEmpty(oParam.ImagePath))


        oParam.ImagePath = "MyPath"
        oParam.ReferenceAgent = "LG0"
        oParam.ReportPath = "MyReport"

        Assert.IsTrue(oParam.writeXML())
        Assert.IsTrue(System.IO.File.Exists(RPParam.xmlFileName))

        'chargement avec un fichier
        oParam = Nothing
        oParam = RPParam.readXML()
        Assert.IsNotNull(oParam)
        Assert.AreEqual(oParam.ImagePath, "MyPath")
        Assert.AreEqual(oParam.ReferenceAgent, "LG0")
        Assert.AreEqual(oParam.ReportPath, "MyReport")

        oParam.ImagePath = "MyPath2"
        oParam.ReferenceAgent = "LG00"
        oParam.ReportPath = "MyReport2"
        Assert.IsTrue(oParam.writeXML())

        oParam = Nothing
        oParam = RPParam.readXML()
        Assert.IsNotNull(oParam)
        Assert.AreEqual(oParam.ImagePath, "MyPath2")
        Assert.AreEqual(oParam.ReferenceAgent, "LG00")
        Assert.AreEqual(oParam.ReportPath, "MyReport2")


    End Sub

    <TestMethod()> Public Sub Testeference()
        Dim oParam As RPParam

        If System.IO.File.Exists(RPParam.xmlFileName) Then
            System.IO.File.Delete(RPParam.xmlFileName)
        End If

        'Chargement sans fichier

        oParam = RPParam.readXML()

        Dim strRefrence = "LG0" & vbCrLf & "LG1"

        oParam.ReferenceAgent = strRefrence
        Assert.AreEqual(oParam.ReferenceAgentToXML_, "LG0|LG1")
        Assert.AreEqual(oParam.ReferenceAgent, strRefrence)

        oParam.writeXML()
        oParam = Nothing
        oParam = RPParam.readXML()
        Assert.AreEqual(oParam.ReferenceAgent, strRefrence)

        Dim oRPDiag As New RPDiagnostic()
        oRPDiag.Reference = strRefrence
        Assert.AreEqual(oRPDiag.Reference, strRefrence)

    End Sub

    <TestMethod()> Public Sub GenerateXMLTest()
        Dim oReglagePulve As New ParamReglagePulve
        Dim oUser As New RPUser()
        oUser.Code = "a"
        oUser.setPassword("*")
        oUser.setDateExp(Now)
        oUser.setDateExp(New Date(2017, 12, 31))
        oReglagePulve.coluser.Add(oUser)

        oUser = New RPUser()
        oUser.Code = "test2"
        oUser.setPassword("test")
        oUser.setDateExp(New Date(2018, 12, 31))
        oReglagePulve.coluser.Add(oUser)

        ParamReglagePulve.GenerateXML(".", oReglagePulve)
        Assert.IsFalse(System.IO.File.Exists("./aqwzsx.crodip"))
        Assert.IsTrue(System.IO.File.Exists("./aqwzsx.crodipz"))

    End Sub

    <TestMethod()> Public Sub ReadXMLTest()
        Dim oReglagePulve As New ParamReglagePulve
        Dim oUser As New RPUser()
        oUser.Code = "a"
        oUser.setPassword("*")
        oUser.setDateExp(Now)
        oUser.setDateExp(New Date(2017, 12, 31))
        oReglagePulve.coluser.Add(oUser)

        oUser = New RPUser()
        oUser.Code = "test2"
        oUser.setPassword("test")
        oUser.setDateExp(New Date(2018, 12, 31))
        oReglagePulve.coluser.Add(oUser)

        ParamReglagePulve.GenerateXML(".", oReglagePulve)
        Assert.IsFalse(System.IO.File.Exists("./aqwzsx.crodip"))

        Dim oParamReglagePulve As ParamReglagePulve = ParamReglagePulve.ReadXML(".")
        Assert.IsNotNull(oParamReglagePulve)
        Assert.AreEqual(2, oParamReglagePulve.coluser.Count)
        Assert.AreEqual("a", oParamReglagePulve.coluser(0).Code)
    End Sub


End Class