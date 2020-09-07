Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <DataTestMethod>
    <DataRow(-1)>
    Public Sub TestMethod1(p As Integer)
        Assert.AreEqual(-1, p)
    End Sub
    <DataTestMethod()> Public Sub TestMethod2()
    End Sub

End Class