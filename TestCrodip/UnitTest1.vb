Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class UnitTest1

    'Test uniquement pour MAJ base ASCAR
    <TestMethod(), Ignore()>
    Public Sub TestASCAR()
        Dim olst As List(Of Pulverisateur)
        Dim oPulve As Pulverisateur
        Dim oAgent As Agent
        olst = PulverisateurManager.FTOgetUpdates()

        WSCrodip.Init("http://admin.crodip.fr/server")
        oAgent = AgentManager.getAgentById("1048")
        PulverisateurManager.MAJetatPulverisateurs(oAgent, olst)

        For Each oPulve In olst
            If oPulve.numeroNational <> "E001" Then
                Dim oReturn As Object
                Dim nRet As Integer
                'nRet = PulverisateurManager.sendWSPulverisateur(oAgent, oPulve, oReturn)
                Select Case nRet
                    Case 0

                End Select

            End If
        Next

        'ceci est un test
    End Sub

End Class