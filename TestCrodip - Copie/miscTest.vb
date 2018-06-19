Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO

<TestClass()>
Public Class MiscTest

    <TestMethod()>
    Public Sub StringFormatToDecTest()
        Assert.AreEqual("123,9", CDec(123.85693).ToString("###.#"))
        Assert.AreEqual("123,85690", CDec(123.8569).ToString("#####.00000"))
        Assert.AreEqual("123,857", FormatStringDecimal("123,85693", 3))
        Assert.AreEqual("123,850", FormatStringDecimal("123,85", 3))
        Assert.AreEqual("123,850", FormatStringDecimal("123.85", 3))
        Assert.AreEqual("123,000", FormatStringDecimal("123", 3))
        Assert.AreEqual("0,950", FormatStringDecimal(".95", 3))


    End Sub



End Class
