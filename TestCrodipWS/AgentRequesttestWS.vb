Imports System.Text
Imports CRODIPWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting
''' <summary>
''' Test avec la DLL de classes
''' </summary>
<TestClass()> Public Class AgentRequesttestWS

    <TestMethod()> Public Sub sendAgentAncienneVersion()
        Dim oAgent As New Agent()
        oAgent.uid = 1495
        oAgent.aid = ""
        oAgent.nom = "TEXIER ID WEB 5"

        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
        Dim pInfo As String = ""
        Dim puid As Integer = 0
        Dim codeResponse As Integer = 99
        Dim oResponse As Object
        codeResponse = objWSCrodip.SendAgent(oAgent, pInfo, oResponse)
        Assert.AreEqual(2, codeResponse)

    End Sub

End Class