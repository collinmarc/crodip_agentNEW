Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class FacturationConfigTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CreationfichierTest()
        If (System.IO.File.Exists("./config/facturation.xml")) Then
            System.IO.File.Delete("./config/facturation.xml")
        End If

        FacturationConfig.WriteXml()

        Assert.IsTrue(System.IO.File.Exists("./config/facturation.xml"))
    End Sub

End Class