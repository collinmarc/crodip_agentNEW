Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CrodipWS

<TestClass()> Public Class StructureTest

    <TestMethod>
    Public Sub TestchampsNumerotation()
        Dim oStructure As New [Structure]()
        oStructure.RacineNumFact = "RACINE"
        oStructure.DernierNumFact = "002"

        Assert.AreEqual("RACINE", oStructure.RacineNumFact)
        Assert.AreEqual("002", oStructure.DernierNumFact)


    End Sub
    <DataTestMethod()> Public Sub TestMethod2()
    End Sub

End Class