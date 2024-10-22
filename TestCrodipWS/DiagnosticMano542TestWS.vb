Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class DiagnosticMano542TestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim lst As DiagnosticMano542List
        lst = DiagnosticMano542Manager.WSGetList(145691, "998-TSTMCO-12345-1")
        Assert.IsNotNull(lst)
        Assert.AreEqual(9, lst.Liste.Count)
        Assert.AreEqual(145691, lst.Liste(0).uiddiagnostic)
        Assert.AreEqual(145691, lst.Liste(1).uiddiagnostic)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oDiagnostic As CRODIPWS.Diagnostic
        oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697)
        oDiagnostic.diagnosticMano542List.Liste.Clear()
        Assert.IsNotNull(oDiagnostic)
        Dim oDiagM542 As DiagnosticMano542
        oDiagM542 = New DiagnosticMano542(oDiagnostic)
        oDiagM542.pressionControle = 10
        oDiagM542.pressionPulve = 11
        oDiagnostic.diagnosticMano542List.Liste.Add(oDiagM542)
        oDiagM542 = New DiagnosticMano542(oDiagnostic)
        oDiagM542.pressionControle = 30
        oDiagM542.pressionPulve = 20
        oDiagnostic.diagnosticMano542List.Liste.Add(oDiagM542)
        oDiagM542 = New DiagnosticMano542(oDiagnostic)
        oDiagM542.pressionControle = 30
        oDiagM542.pressionPulve = 30
        oDiagnostic.diagnosticMano542List.Liste.Add(oDiagM542)

        DiagnosticMano542Manager.WSSend(oDiagnostic)


    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        m_oExploitation = createExploitation()
        Dim updated As root
        ExploitationManager.WSSend(m_oExploitation, updated)
        m_oExploitation = CType(updated, Exploitation)
        m_oPulve = createPulve(m_oExploitation)
        Dim updated2 As root
        PulverisateurManager.WSSend(m_oPulve, updated2)
        m_oPulve = CType(updated2, Pulverisateur)


        m_oDiag = createAndSaveDiagnostic()
        m_oDiag.commentaire = "TU_MCO"

        Dim oReturn As Object
        DiagnosticManager.WSSend(m_oDiag, oReturn)
        m_oDiag.uid = CType(oReturn, Diagnostic).uid

        m_oDiag.diagnosticMano542List.Liste.Clear()
        Assert.IsNotNull(m_oDiag)
        Dim oDiagM542 As DiagnosticMano542
        oDiagM542 = New DiagnosticMano542(m_oDiag)
        oDiagM542.pressionControle = 10
        oDiagM542.pressionPulve = 11
        m_oDiag.diagnosticMano542List.Liste.Add(oDiagM542)
        oDiagM542 = New DiagnosticMano542(m_oDiag)
        oDiagM542.pressionControle = 20
        oDiagM542.pressionPulve = 21
        m_oDiag.diagnosticMano542List.Liste.Add(oDiagM542)
        oDiagM542 = New DiagnosticMano542(m_oDiag)
        oDiagM542.pressionControle = 30
        oDiagM542.pressionPulve = 31
        m_oDiag.diagnosticMano542List.Liste.Add(oDiagM542)

        'CREATE
        DiagnosticMano542Manager.WSSend(m_oDiag)

        'read
        Dim lst As DiagnosticMano542List
        lst = DiagnosticMano542Manager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(3, lst.Liste.Count)
        m_oDiag.diagnosticMano542List.Liste.Clear()
        For Each oDiagM542 In lst.Liste
            m_oDiag.diagnosticMano542List.Liste.Add(oDiagM542)
        Next
        oDiagM542 = m_oDiag.diagnosticMano542List.Liste(0)
        Assert.AreEqual("10", oDiagM542.pressionControle)
        Assert.AreEqual("11", oDiagM542.pressionPulve)
        oDiagM542 = m_oDiag.diagnosticMano542List.Liste(1)
        Assert.AreEqual("20", oDiagM542.pressionControle)
        Assert.AreEqual("21", oDiagM542.pressionPulve)
        oDiagM542 = m_oDiag.diagnosticMano542List.Liste(2)
        Assert.AreEqual("30", oDiagM542.pressionControle)
        Assert.AreEqual("31", oDiagM542.pressionPulve)
        'UPDATE
        oDiagM542 = m_oDiag.diagnosticMano542List.Liste(0)
        oDiagM542.pressionControle = 100
        oDiagM542.pressionPulve = 110
        oDiagM542 = m_oDiag.diagnosticMano542List.Liste(1)
        oDiagM542.pressionControle = 200
        oDiagM542.pressionPulve = 210
        oDiagM542 = m_oDiag.diagnosticMano542List.Liste(2)
        oDiagM542.pressionControle = 300
        oDiagM542.pressionPulve = 310
        oDiagM542 = New DiagnosticMano542(m_oDiag)
        oDiagM542.pressionControle = 400
        oDiagM542.pressionPulve = 410
        m_oDiag.diagnosticMano542List.Liste.Add(oDiagM542)
        'Il faut les sauvegarder pour Modifier les datesdeModifAgent
        DiagnosticManager.save(m_oDiag)


        'Send
        Dim codereponse As Integer
        codereponse = DiagnosticMano542Manager.WSSend(m_oDiag)
        'ReRead
        lst = DiagnosticMano542Manager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(4, lst.Liste.Count)
        m_oDiag.diagnosticMano542List.Liste.Clear()
        For Each oDiagM542 In lst.Liste
            m_oDiag.diagnosticMano542List.Liste.Add(oDiagM542)
        Next

        oDiagM542 = lst.Liste(m_oDiag.diagnosticMano542List.Liste.Count - 4)
        Assert.AreEqual("100", oDiagM542.pressionControle)
        Assert.AreEqual("110", oDiagM542.pressionPulve)
        oDiagM542 = lst.Liste(m_oDiag.diagnosticMano542List.Liste.Count - 3)
        Assert.AreEqual("200", oDiagM542.pressionControle)
        Assert.AreEqual("210", oDiagM542.pressionPulve)
        oDiagM542 = lst.Liste(m_oDiag.diagnosticMano542List.Liste.Count - 2)
        Assert.AreEqual("300", oDiagM542.pressionControle)
        Assert.AreEqual("310", oDiagM542.pressionPulve)
        oDiagM542 = lst.Liste(m_oDiag.diagnosticMano542List.Liste.Count - 1)
        Assert.AreEqual("400", oDiagM542.pressionControle)
        Assert.AreEqual("410", oDiagM542.pressionPulve)

    End Sub
    '<TestMethod()> Public Sub CRUDWS()

    '    Dim nreturn As Integer
    '    m_oExploitation = createExploitation()
    '    Dim updated As root
    '    ExploitationManager.WSSend(m_oExploitation, updated)
    '    m_oExploitation = CType(updated, Exploitation)
    '    m_oPulve = createPulve(m_oExploitation)
    '    Dim updated2 As root
    '    PulverisateurManager.WSSend(m_oPulve, updated2)
    '    m_oPulve = CType(updated2, Pulverisateur)


    '    m_oDiag = createAndSaveDiagnostic()
    '    m_oDiag.commentaire = "TU_MCO"

    '    Création de l'objet
    '    Dim oReturn As Diagnostic
    '    nreturn = DiagnosticManager.WSSend(m_oDiag, oReturn)
    '    Assert.AreEqual(4, nreturn)
    '    Assert.IsNotNull(oReturn.uid)

    '    Lecture de l'objet
    '    m_oDiag = DiagnosticManager.WSgetById(m_oAgent.uid, oReturn.uid)
    '    Assert.AreEqual("TU_MCO", m_oDiag.commentaire)

    '    Update de l'objet
    '    m_oDiag.commentaire = "TU_UPDATE"
    '    nreturn = DiagnosticManager.WSSend(m_oDiag, oReturn)
    '    Assert.AreEqual(m_oDiag.uid, oReturn.uid)
    '    Assert.AreEqual(2, nreturn)
    '    Assert.AreEqual("TU_UPDATE", m_oDiag.commentaire)

    'End Sub
    '<TestMethod()> Public Sub WSSerialize()
    '    Dim oDiagnostic As CRODIPWS.Diagnostic
    '    oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697)
    '    Assert.IsNotNull(oDiagnostic)
    '    Dim oDiagItem As New DiagnosticMano542(oDiagnostic.aid, "123", "0")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New DiagnosticMano542(oDiagnostic.aid, "456", "1")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New DiagnosticMano542(oDiagnostic.aid, "789", "2")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)


    '    Dim serializer As New XmlSerializer(GetType(DiagnosticBuseList))
    '    Using writer As New StringWriter()
    '        serializer.Serialize(writer, oDiagnostic.DiagnosticMano542Lst)
    '        Dim xmlOutput As String = writer.ToString()
    '        Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
    '        Trace.WriteLine(xmlOutput)
    '    End Using

    'End Sub


End Class