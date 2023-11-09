Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class testProduction
    Inherits CRODIPTest
    'Attention ce test va chercher des données dans la base de prod
    <TestMethod()>
    Public Sub TestAGRITEST()
        Dim oAgent As Agent


        WSCrodip.Init("http://admin.crodip.fr/server")
        oAgent = New Agent
        oAgent.id = 1186
        oAgent.numeroNational = "167"
        Dim oDiag As Diagnostic
        Dim oExploit As Exploitation
        Dim oPulve As Pulverisateur

        oDiag = DiagnosticManager.getWSDiagnosticById(1186, "079-167-03485-51")
        oExploit = ExploitationManager.getWSExploitationById("1186", oDiag.proprietaireId)
        oPulve = PulverisateurManager.getWSPulverisateurById(oAgent.id, oDiag.pulverisateurId)

        ExploitationManager.save(oExploit, oAgent)
        PulverisateurManager.save(oPulve, oExploit.id, oAgent)
        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticItemManager.getWSDiagnosticItemsByDiagnosticId(oAgent, "079-167-03485-51")
        DiagnosticManager.save(oDiag)
        Dim oDiagnosticTroncons833List As DiagnosticTroncons833List
        oDiagnosticTroncons833List = DiagnosticTroncons833Manager.getWSDiagnosticTroncons833ByDiagId(oAgent.id, oDiag.id)
        oDiag.diagnosticTroncons833.Liste.AddRange(oDiagnosticTroncons833List.Liste)
        Dim oDiag542List As DiagnosticMano542List
        oDiag542List = DiagnosticMano542Manager.getWSDiagnosticMano542ByDiagId(oAgent.id, oDiag.id)
        oDiag.diagnosticMano542List.Liste.AddRange(oDiag542List.Liste)

        Dim oDiagBusesList As DiagnosticBusesList
        oDiagBusesList = DiagnosticBusesManager.getWSDiagnosticBusesByDiagId(oAgent.id, oDiag.id)
        oDiag.diagnosticBusesList.Liste.AddRange(oDiagBusesList.Liste)

        Dim oDiagBusesDList As DiagnosticBusesDetailList
        oDiagBusesDList = DiagnosticBusesDetailManager.getWSDiagnosticBusesDetailByDiagId(oAgent.id, oDiag.id)
        For Each oDetail As DiagnosticBusesDetail In oDiagBusesDList.Liste
            For Each oBuse As DiagnosticBuses In oDiag.diagnosticBusesList.Liste
                If oBuse.id = oDetail.idBuse And oBuse.idLot = oDetail.idLot Then
                    oBuse.diagnosticBusesDetailList.Liste.Add(oDetail)
                End If
            Next

        Next

        DiagnosticManager.save(oDiag)
        oDiag = DiagnosticManager.getDiagnosticById(oDiag.id)
        Dim oEtat As New EtatSyntheseMesures(oDiag)
        oEtat.genereEtat(True)
        oEtat.Open()
        'ceci est un test
    End Sub

End Class