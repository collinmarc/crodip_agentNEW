Public Class Class1

    Public Sub test()
        Dim oWS As New WSCRODIP.CrodipServer()

        Dim oAgentPC As New Crodip_agent.AgentPC()
        oAgentPC.idCrodip = "TEST"

        Dim UpdatedObject As Object = Nothing

        oWS.SendAgent(oAgentPC, UpdatedObject)

    End Sub

End Class
