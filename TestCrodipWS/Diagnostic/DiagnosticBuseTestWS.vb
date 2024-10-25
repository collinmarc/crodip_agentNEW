Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class DiagnosticBuseTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim lst As DiagnosticBusesList
        lst = DiagnosticBusesManager.WSGetList(145691, "998-TSTMCO-12345-1")
        Assert.IsNotNull(lst)
        Assert.AreEqual(13, lst.Liste.Count)
        Assert.AreEqual(145691, lst.Liste(0).uiddiagnostic)
        Assert.AreEqual(145691, lst.Liste(1).uiddiagnostic)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oDiagnostic As CRODIPWS.Diagnostic
        oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697, "")
        oDiagnostic.diagnosticBusesList.Liste.Clear()
        Assert.IsNotNull(oDiagnostic)
        Dim oDiagBuse As DiagnosticBuses
        oDiagBuse = New DiagnosticBuses(oDiagnostic)
        oDiagBuse.calibre = 10
        oDiagBuse.debitNominal = 10
        oDiagnostic.diagnosticBusesList.Liste.Add(oDiagBuse)
        oDiagBuse = New DiagnosticBuses(oDiagnostic)
        oDiagBuse.calibre = 20
        oDiagBuse.debitNominal = 20
        oDiagnostic.diagnosticBusesList.Liste.Add(oDiagBuse)
        oDiagBuse = New DiagnosticBuses(oDiagnostic)
        oDiagBuse.calibre = 30
        oDiagBuse.debitNominal = 30
        oDiagnostic.diagnosticBusesList.Liste.Add(oDiagBuse)

        DiagnosticBusesManager.WSSend(oDiagnostic)


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

        m_oDiag.diagnosticBusesList.Liste.Clear()
        Assert.IsNotNull(m_oDiag)
        Dim oDiagBuse As DiagnosticBuses
        oDiagBuse = New DiagnosticBuses(m_oDiag)
        oDiagBuse.calibre = 10
        oDiagBuse.debitNominal = 11
        m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
        oDiagBuse = New DiagnosticBuses(m_oDiag)
        oDiagBuse.calibre = 20
        oDiagBuse.debitNominal = 21
        m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
        oDiagBuse = New DiagnosticBuses(m_oDiag)
        oDiagBuse.calibre = 30
        oDiagBuse.debitNominal = 31
        m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)

        'CREATE
        DiagnosticBusesManager.WSSend(m_oDiag)

        'read
        Dim lst As DiagnosticBusesList
        lst = DiagnosticBusesManager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(3, lst.Liste.Count)
        m_oDiag.diagnosticBusesList.Liste.Clear()
        For Each oDiagBuse In lst.Liste
            m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
        Next
        oDiagBuse = m_oDiag.diagnosticBusesList.Liste(0)
        Assert.AreEqual("10", oDiagBuse.calibre)
        Assert.AreEqual("11", oDiagBuse.debitNominal)
        oDiagBuse = m_oDiag.diagnosticBusesList.Liste(1)
        Assert.AreEqual("20", oDiagBuse.calibre)
        Assert.AreEqual("21", oDiagBuse.debitNominal)
        oDiagBuse = m_oDiag.diagnosticBusesList.Liste(2)
        Assert.AreEqual("30", oDiagBuse.calibre)
        Assert.AreEqual("31", oDiagBuse.debitNominal)
        'UPDATE
        oDiagBuse = m_oDiag.diagnosticBusesList.Liste(0)
        oDiagBuse.calibre = 100
        oDiagBuse.debitNominal = 110
        oDiagBuse = m_oDiag.diagnosticBusesList.Liste(1)
        oDiagBuse.calibre = 200
        oDiagBuse.debitNominal = 210
        oDiagBuse = m_oDiag.diagnosticBusesList.Liste(2)
        oDiagBuse.calibre = 300
        oDiagBuse.debitNominal = 310
        oDiagBuse = New DiagnosticBuses(m_oDiag)
        oDiagBuse.calibre = 400
        oDiagBuse.debitNominal = 410
        m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
        'Il faut les sauvegarder pour Modifier les datesdeModifAgent
        DiagnosticManager.save(m_oDiag)


        'Send
        Dim codereponse As Integer
        codereponse = DiagnosticBusesManager.WSSend(m_oDiag)
        'ReRead
        lst = DiagnosticBusesManager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(4, lst.Liste.Count)
        m_oDiag.diagnosticBusesList.Liste.Clear()
        For Each oDiagBuse In lst.Liste
            m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
        Next

        oDiagBuse = lst.Liste(m_oDiag.diagnosticBusesList.Liste.Count - 4)
        Assert.AreEqual("100", oDiagBuse.calibre)
        Assert.AreEqual("110", oDiagBuse.debitNominal)
        oDiagBuse = lst.Liste(m_oDiag.diagnosticBusesList.Liste.Count - 3)
        Assert.AreEqual("200", oDiagBuse.calibre)
        Assert.AreEqual("210", oDiagBuse.debitNominal)
        oDiagBuse = lst.Liste(m_oDiag.diagnosticBusesList.Liste.Count - 2)
        Assert.AreEqual("300", oDiagBuse.calibre)
        Assert.AreEqual("310", oDiagBuse.debitNominal)
        oDiagBuse = lst.Liste(m_oDiag.diagnosticBusesList.Liste.Count - 1)
        Assert.AreEqual("400", oDiagBuse.calibre)
        Assert.AreEqual("410", oDiagBuse.debitNominal)

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
    '    Dim oDiagItem As New DiagnosticBuses(oDiagnostic.aid, "123", "0")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New DiagnosticBuses(oDiagnostic.aid, "456", "1")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New DiagnosticBuses(oDiagnostic.aid, "789", "2")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)


    '    Dim serializer As New XmlSerializer(GetType(DiagnosticBuseList))
    '    Using writer As New StringWriter()
    '        serializer.Serialize(writer, oDiagnostic.DiagnosticBusesLst)
    '        Dim xmlOutput As String = writer.ToString()
    '        Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
    '        Trace.WriteLine(xmlOutput)
    '    End Using

    'End Sub


End Class