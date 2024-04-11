Imports System.IO
Imports System.Xml.Serialization

Module main

    Public Sub Main()
        Dim oWS As New WSCRODIP2.CrodipServer()


        Dim oAgentPC As New AgentPC()
        Dim oUpdated As Object
        oWS.GetAgentPC("0001", oUpdated)



        Dim objWSCrodip_responseItem As System.Xml.XmlNode
        For Each objWSCrodip_responseItem In oUpdated
            If Not String.IsNullOrEmpty(objWSCrodip_responseItem.InnerText()) Then
                oAgentPC.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
            End If
        Next


        oAgentPC.uid = Nothing
        oAgentPC.idCrodip = "0001"

        oAgentPC.libelle = "AgentPCsansUid"

        Dim oXS As New XmlSerializer(oAgentPC.GetType())



        ' Create a memory stream and a formatter.
        Dim sw As New StringWriter()
        ' Serialize the object into the stream.
        oXS.Serialize(sw, oAgentPC)
        ' Position streem pointer back to first byte.
        Console.Write(sw.ToString())


        'Il faut ajouter le XmlInclude(GetType(AgentPC)) dans le fichier REFERENCE.vb
        'Soit à la déclaration de la classe crodipserver, soit avant chaque send
        'Pas besoin de la déclarer dans la classe elle-même , juste qu'elle soit Serializable

        oWS.SendAgentPC("001", oAgentPC, oUpdated)

        '        oAgentPC.uid = Nothing
        '        oAgentPC.idCrodip = "0002"
        '
        '        oAgentPC.libelle = "Nouveau AgentPCsansUid"
        '        oWS.SendAgentPC("001", oAgentPC, oUpdated)

    End Sub

End Module
