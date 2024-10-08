Imports System.Text
Imports Crodip_agent
Imports Crodip_agent.WSCrodip_prod
Imports Microsoft.VisualStudio.TestTools.UnitTesting
''' <summary>
''' Test avec le projet CRODIP_Agent
''' </summary>
<TestClass()> Public Class testWebServiceExistant

    <TestMethod()> Public Sub TESTAVECServicesExistant()
        Dim oAgent As New Agent
        oAgent.id = 1495
        oAgent.numeroNational = ""
        oAgent.nom = "TEXIER ID WEB 5"

        Dim objWSCrodip As WSCrodip_prod.CrodipServer = New WSCrodip_prod.CrodipServer()
        objWSCrodip.Url = "http://admin-pp.crodip.net/server"
        Dim pInfo As String = ""
        Dim puid As Integer = 0
        Dim codeResponse As Integer = 99
        Dim oResponse As Object
        codeResponse = objWSCrodip.SendAgent(oAgent, oResponse)
        Assert.AreEqual(2, codeResponse)

    End Sub
    ''' <summary>
    ''' Test avec les WebServices regénérés à partir de la PreProd
    ''' </summary>
    <TestMethod()> Public Sub TESTAVECServicesANCREGENERE()
        Dim oAgent As New Agent
        oAgent.id = 1495
        oAgent.numeroNational = ""
        oAgent.nom = "TEXIER ID WEB 5"

        Dim objWSCrodip As WSCRODIP3.CrodipServer = New WSCRODIP3.CrodipServer()
        objWSCrodip.Url = "http://admin-pp.crodip.net/server"
        Dim pInfo As String = ""
        Dim puid As Integer = 0
        Dim codeResponse As Integer = 99
        Dim oResponse As Object
        codeResponse = objWSCrodip.SendAgent(oAgent, pInfo, oResponse)
        Assert.AreEqual(2, codeResponse)

    End Sub
    ''' <summary>
    ''' test avec les WebService ancienne version regenérés à partir du WSDL de la PROD
    ''' </summary>
    <TestMethod()> Public Sub TESTAVECServicesANCPREPISDELAPROD()
        Dim oAgent As New Crodip_agent.Agent
        oAgent.id = 1495
        oAgent.numeroNational = ""
        oAgent.nom = "TEXIER ID WEB 5"

        Dim objWSCrodip As WSCODIP4.CrodipServer = New WSCODIP4.CrodipServer()
        objWSCrodip.Url = "http://admin-pp.crodip.net/server"
        Dim pInfo As String = ""
        Dim puid As Integer = 0
        Dim codeResponse As Integer = 99
        Dim oResponse As Object
        codeResponse = objWSCrodip.SendAgent(oAgent, oResponse)
        Assert.AreEqual(2, codeResponse)

    End Sub
End Class