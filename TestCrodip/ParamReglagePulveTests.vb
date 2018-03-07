Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent

Namespace Crodip_agent.Tests
    <TestClass()> Public Class ParamReglagePulveTests



        <TestMethod()> Public Sub GenerateXMLTest()
            Dim oReglagePulve As New ParamReglagePulve
            Dim oUser As New RPUser()
            oUser.Code = "MARC"
            oUser.setPassword("COLLIN")
            oUser.setDateExp(Now)
            oReglagePulve.coluser.Add(oUser)

            ParamReglagePulve.GenerateXML(oReglagePulve)
            Assert.IsTrue(System.IO.File.Exists("./aqwzsx.crodip"))

            Dim oReglagePulve2 As ParamReglagePulve
            Dim ouser2 As RPUser
            oReglagePulve2 = ParamReglagePulve.ReadXML()
            ouser2 = oReglagePulve2.getUSer("TEST")
            Assert.IsNull(ouser2)
            ouser2 = oReglagePulve2.getUSer("MARC")
            Assert.IsNotNull(ouser2)
            Assert.AreEqual(ouser2.Code, oUser.Code)
            Assert.IsTrue(ouser2.TestPassword("COLLIN"))
            Assert.IsTrue(ouser2.TestDateExp(Now))
        End Sub

    End Class


End Namespace


