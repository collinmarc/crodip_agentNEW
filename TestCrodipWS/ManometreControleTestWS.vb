Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class ManometreControleTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim oMano As CRODIPWS.ManometreControle
        oMano = ManometreControleManager.WSgetById(2197)
        Assert.AreEqual(2197, oMano.uid)
        Assert.IsNotNull(oMano)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oMano As CRODIPWS.ManometreControle
        oMano = ManometreControleManager.WSgetById(2197)
        Dim marque As String = "TEST" + Now
        oMano.marque = marque
        oMano.classe = "CL8"
        Dim oreturn As CRODIPWS.ManometreControle
        Dim nReturn As Integer
        nReturn = ManometreControleManager.WSSend(oMano, oreturn)
        Assert.AreEqual(2, nReturn)
        oMano = ManometreControleManager.WSgetById(2197)
        Assert.AreEqual(oMano.marque, marque)
        Assert.AreEqual(oMano.classe, "CL8")

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        Dim oMano As New ManometreControle()
        oMano.uidstructure = 22
        oMano.numeroNational = "MANO22"
        oMano.marque = "TESTMCO"

        ' Création de l'objet
        Dim oReturn As ManometreControle
        nreturn = ManometreControleManager.WSSend(oMano, oReturn)
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        oMano = ManometreControleManager.WSgetById(oReturn.uid)

        'Update de l'objet
        oMano.marque = "TESTUPDATE"
        nreturn = ManometreControleManager.WSSend(oMano, oReturn)
        Assert.AreEqual(oMano.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)

        'test sans modification
        oMano = oReturn
        nreturn = ManometreControleManager.WSSend(oMano, oReturn)
        'Assert.AreEqual(0, nreturn)


    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oMano As New CRODIPWS.ManometreControle()
        oMano.marque = "TEST"
        oMano.classe = "CL8"
        Dim serializer As New XmlSerializer(GetType(CRODIPWS.ManometreControle))
        Using writer As New StringWriter()
            serializer.Serialize(writer, oMano)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub

    '    ''' <summary>
    '    ''' Test avec la DLL + Service Web AncVersion + xmlInclude
    '    ''' </summary>
    '    <TestMethod()> Public Sub sendWSManoControle_WSANC_XMLINCLUDE()
    '        Dim oMano As New ManometreControle()
    '        oMano.marque = "TEST"
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
    '        Dim pInfo As String = ""
    '        Dim puid As Integer = 0
    '        Dim codeResponse As Integer = 99
    '        Dim oResponse As Integer
    '        codeResponse = objWSCrodip.SendManometreControle(oMano, pInfo, puid)
    '        Assert.AreEqual(codeResponse, 0)

    '        'Dim oAgent As New Agent()
    '        'oAgent.uid = 1495
    '        'oAgent.aid = ""
    '        'oAgent.nom = "TEXIER ID WEB 5"
    '        'Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
    '        'Dim pInfo As String = ""
    '        'Dim puid As Integer = 0
    '        'Dim codeResponse As Integer = 99
    '        'Dim oResponse As Object
    '        'codeResponse = objWSCrodip.SendAgent(oAgent, pInfo, oResponse)
    '        'Assert.AreEqual(2, codeResponse)

    '    End Sub
    '    ''' <summary>
    '    ''' test avec la DLL + WebServices Anc version + xmlInclude()
    '    ''' </summary>
    '    <TestMethod()> Public Sub sendWSManoEtalon_WSANC_XMLINCLUDE()
    '        Dim oMano As New ManometreEtalon()
    '        oMano.marque = "TEST"
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
    '        Dim pInfo As String = ""
    '        Dim puid As Integer = 0
    '        Dim codeResponse As Integer = 99
    '        Dim oResponse As Integer
    '        oResponse = objWSCrodip.SendManometreEtalon(oMano, pInfo, puid, oResponse)
    '        Assert.AreEqual(codeResponse, 0)

    '    End Sub
    '    ''' <summary>
    '    ''' test avec la DLL + WebServices Anc version + xmlInclude()
    '    ''' </summary>
    '    <TestMethod()> Public Sub sendWSAgent_WSANC_XMLINCLUDE()
    '        Dim oToSend As New AgentRequest()
    '        oToSend.uid = 1495
    '        oToSend.nom = "TEST"
    '        Dim objWSCrodip As WSCRODIP.CrodipServer = New WSCRODIP.CrodipServer()
    '        Dim pInfo As String = ""
    '        Dim puid As Integer = 0
    '        Dim codeResponse As Integer = 99
    '        Dim nResponse As Integer
    '        Dim oResponse As Object = Nothing
    '        nResponse = objWSCrodip.SendAgent(oToSend, pInfo, oResponse)
    '        Assert.AreEqual(nResponse, 0)

    '    End Sub
    '    Public Function CreateSoapEnvelope(parameter As Integer) As String
    '        Return $"""<?xml version=""1.0"" encoding=""utf-8""?>
    '<soap:Envelope xmlns:soap=""http//schemas.xmlsoap.org/soap/envelope/"">
    '  <soap:Body>
    '    <SendManometreControleRequest xmlns=""http://www.example.org/crodip/"">
    '    <ManometreControle>
    '     	        <uid></uid>
    '                <aid></aid>
    '                <idManometre>9988</idManometre>
    '                <uidstructure>22</uidstructure>
    '                <marque>BD SENSOR2</marque>
    '                <classe>2</classe>
    '                <type>Analogique</type>
    '                <fondEchelle>6</fondEchelle>
    '                <etat>1</etat>
    '                <resolution>2</resolution>
    '                <isSynchro>0</isSynchro>
    '                <dateDernierControle/>
    '                <dateModificationAgent>2024-08-28 00:00:00</dateModificationAgent>
    '                <dateModificationCrodip>2024-08-28 00:00:00</dateModificationCrodip>
    '                <isUtilise>0</isUtilise>
    '                <isSupprime>0</isSupprime>
    '                <agentSuppression/>
    '                <raisonSuppression/>
    '                <dateSuppression/>
    '                <jamaisServi>0</jamaisServi>
    '                <dateActivation/>
    '                <nbControles/>
    '                <nbControlesTotal/>
    '                <bAjusteur>0</bAjusteur>
    '                <resolutionLecture/>
    '                <typeTraca/>
    '                <numTraca/>
    '    </ManometreControle>
    '    </SendManometreControleRequest>
    '  </soap:Body>
    '</soap:Envelope>"""
    '    End Function


    '    <TestMethod()> Public Sub TestSendSoapRequestAsync()
    '        Dim parameter As Integer = 1 ' Paramètre d'entrée
    '        Dim url As String = "http://admin-pp.crodip.net/server" ' URL de votre service

    '        ' Créer l'enveloppe SOAP
    '        Dim soapEnvelope As String = CreateSoapEnvelope(parameter)

    '        Using client As New HttpClient()
    '            ' Préparer la requête
    '            Dim request As New HttpRequestMessage(HttpMethod.Post, url)
    '            request.Content = New StringContent(soapEnvelope, Encoding.UTF8, "text/xml")
    '            request.Headers.Add("SOAPAction", "http://example.org/crodip/SendManometre") ' Mettez à jour l'action SOAP

    '            Try
    '                ' Envoyer la requête
    '                Dim response As HttpResponseMessage = client.PostAsync(url, request.Content).GetAwaiter().GetResult()
    '                If response.IsSuccessStatusCode Then
    '                    ' Lire la réponse
    '                    Dim responseXml As String = response.Content.ReadAsStringAsync().Result
    '                    Console.WriteLine("Réponse reçue :")
    '                    Console.WriteLine(responseXml)
    '                Else
    '                    Console.WriteLine($"Erreur: {response.StatusCode}")
    '                End If
    '            Catch ex As Exception
    '                Console.WriteLine($"Exception : {ex.Message}")
    '            End Try
    '        End Using
    '    End Sub


End Class