Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class MiscTest


    <TestMethod()>
    Public Sub ConvertToDecimalTest()
        Assert.AreEqual(0.5D, Convert.ToDecimal("0,5"))
        Assert.IsTrue(Convert.ToDecimal("0,5"))
        '        Assert.AreEqual(0.55D, Convert.ToDecimal("0.5"))
        '       Assert.IsTrue(Convert.ToDecimal("0.5"))

        Assert.AreEqual(0.55D, Convert.ToDecimal("0,55"))
        Assert.IsTrue(Convert.ToDecimal("0,55"))
        Assert.AreEqual(0D, Convert.ToDecimal("0"))
        Assert.IsFalse(Convert.ToDecimal("0"))

        Assert.AreEqual("0,55", String.Format("{0:0.00}", 0.55D))
        Assert.AreEqual("0,56", String.Format("{0:0.00}", 0.555D))
        Assert.AreEqual("0,55", String.Format("{0:0.00}", 0.554D))
        Assert.AreEqual("0,50", String.Format("{0:0.00}", 0.5D))
        Assert.AreEqual("0,00", String.Format("{0:0.00}", 0D))

        '        Assert.AreEqual(0D, Convert.ToDecimal("TEST"))
        '        Assert.IsFalse(Convert.ToDecimal("TEST"))
    End Sub




End Class
