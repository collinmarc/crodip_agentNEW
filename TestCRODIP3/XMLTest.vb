Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO

<TestClass()>
Public Class XMLTest

    <TestMethod()>
    Public Sub SerialiseTest()

        Dim oDiagItem As DiagnosticItem
        Dim oDiagItem2 As DiagnosticItem

        oDiagItem = New DiagnosticItem()

        oDiagItem.id = "999"
        oDiagItem.idDiagnostic = "999-999-999"
        oDiagItem.idItem = "9.9.9"
        oDiagItem.itemValue = "A"
        oDiagItem.itemCodeEtat = "9"
        oDiagItem.dateModificationAgent = CSDate.GetDateForWS("1964-02-06")
        oDiagItem.dateModificationCrodip = CSDate.GetDateForWS("1964-02-07")

        Dim oXS As New XmlSerializer(oDiagItem.GetType())
        Dim oStreamWriter As New StreamWriter("DiagItem.xml")

        oXS.Serialize(oStreamWriter, oDiagItem)
        oStreamWriter.Close()

        Dim oStreamReader As New StreamReader("DiagItem.xml")
        oDiagItem2 = oXS.Deserialize(oStreamReader)
        oStreamReader.Close()
        Assert.AreEqual(oDiagItem.id, oDiagItem2.id)
        Assert.AreEqual(oDiagItem.idDiagnostic, oDiagItem2.idDiagnostic)
        Assert.AreEqual(oDiagItem.idItem, oDiagItem2.idItem)
        Assert.AreEqual(oDiagItem.itemValue, oDiagItem2.itemValue)
        Assert.AreEqual(oDiagItem.itemCodeEtat, oDiagItem2.itemCodeEtat)
        Assert.AreEqual(oDiagItem.dateModificationAgent, oDiagItem2.dateModificationAgent)
        Assert.AreEqual(oDiagItem.dateModificationCrodip, oDiagItem2.dateModificationCrodip)

        System.IO.File.Delete("DiagItem.xml")



    End Sub

End Class
