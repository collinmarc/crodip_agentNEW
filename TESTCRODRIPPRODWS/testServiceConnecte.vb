Imports System.Text
Imports Crodip_agent
Imports Microsoft.VisualStudio.TestTools.UnitTesting
''' <summary>
''' Test avec le projet CRODIP_Agent
''' </summary>

<TestClass()> Public Class testServiceConnecte

    <TestMethod()> Public Sub TESTAVECagentRequest()
        Dim oAgent As New WSCRODIP2.AgentRequest
        oAgent.uid = 1495
        oAgent.aid = ""
        oAgent.nom = "TEXIER ID WEB 5"

        Dim objWSCrodip As WSCRODIP2.CrodipServerClient = New WSCRODIP2.CrodipServerClient()
        Dim pInfo As String = ""
        Dim puid As Integer = 0
        Dim codeResponse As Integer = 99
        Dim oResponse As Object
        codeResponse = objWSCrodip.SendAgent(oAgent, pInfo, oResponse)
        Assert.AreEqual(2, codeResponse)

    End Sub
    <TestMethod()> Public Sub TESTAVECAgent()
        Dim oAgent As New Agent
        oAgent.id = 1495
        oAgent.numeroNational = ""
        oAgent.nom = "TEXIER ID WEB 5"

        Dim objWSCrodip As WSCRODIP2.CrodipServerClient = New WSCRODIP2.CrodipServerClient()
        Dim pInfo As String = ""
        Dim puid As Integer = 0
        Dim codeResponse As Integer = 99
        Dim oResponse As Object
        codeResponse = objWSCrodip.SendAgent(oAgent, pInfo, oResponse)
        Assert.AreEqual(2, codeResponse)

    End Sub

End Class