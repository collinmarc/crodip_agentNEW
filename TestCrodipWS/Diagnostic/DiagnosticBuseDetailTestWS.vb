Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class DiagnosticBuseDetailTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim lst As DiagnosticBusesDetailList
        lst = DiagnosticBusesDetailManager.WSGetList(145691, "998-TSTMCO-12345-1")
        Assert.IsNotNull(lst)
        Assert.AreEqual(47, lst.Liste.Count)
        Assert.AreEqual(145691, lst.Liste(0).uiddiagnostic)
        Assert.AreEqual(145691, lst.Liste(1).uiddiagnostic)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oDiagnostic As CRODIPWS.Diagnostic
        oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697, "")
        Assert.IsNotNull(oDiagnostic)
        Dim obuse As DiagnosticBuses
        obuse = New DiagnosticBuses(oDiagnostic)
        oDiagnostic.diagnosticBusesList.Liste.Add(obuse)

        obuse.diagnosticBusesDetailList.Liste.Clear()

        Dim oDiagBuseDetail As DiagnosticBusesDetail
        oDiagBuseDetail = New DiagnosticBusesDetail(obuse)
        oDiagBuseDetail.debit = 10.5
        obuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail(obuse)
        oDiagBuseDetail.debit = 20.5
        obuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail(obuse)
        oDiagBuseDetail.debit = 30.5
        obuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        DiagnosticBusesDetailManager.WSSend(oDiagnostic)


    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer = 99
        Dim obuse As DiagnosticBuses

        m_oDiag = createAndSaveDiagnostic()
        m_oDiag.commentaire = "TU_MCO"
        DiagnosticManager.getDiagnosticById(m_oDiag.id)

        m_oDiag.diagnosticBusesList.Liste.Clear()
        Dim oDiagBuses As New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque1"
        oDiagBuses.nombre = "5"
        oDiagBuses.genre = "DBGenre1"
        oDiagBuses.calibre = "DBCalibre1"
        oDiagBuses.couleur = "DBCouleur1"
        oDiagBuses.debitMoyen = "3,1"
        oDiagBuses.debitNominal = "3,1"
        oDiagBuses.idLot = "1"
        oDiagBuses.ecartTolere = "7"
        m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Ajout des Détails des buses 
        'Detail 1
        Dim oDiagBusesDetail As New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.6"
        oDiagBusesDetail.ecart = "0.6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "1.7"
        oDiagBusesDetail.ecart = "0.7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)

        oDiagBuses = New DiagnosticBuses()
        oDiagBuses.marque = "DBMarque2"
        oDiagBuses.nombre = "5"
        oDiagBuses.genre = "DBGenre2"
        oDiagBuses.calibre = "DBCalibre2"
        oDiagBuses.couleur = "DBCouleur2"
        oDiagBuses.debitMoyen = "3,2"
        oDiagBuses.debitNominal = "3,3"
        oDiagBuses.idLot = "2"
        oDiagBuses.ecartTolere = "3,4"
        m_oDiag.diagnosticBusesList.Liste.Add(oDiagBuses)
        'Detail 1
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2,6"
        oDiagBusesDetail.ecart = "0,6"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)
        'Détail2
        oDiagBusesDetail = New DiagnosticBusesDetail()
        oDiagBusesDetail.debit = "2,7"
        oDiagBusesDetail.ecart = "0,7"
        oDiagBuses.diagnosticBusesDetailList.Liste.Add(oDiagBusesDetail)


        Dim oReturn As Diagnostic = Nothing
        Dim codeReponse As Integer
        codeReponse = DiagnosticManager.WSSend(m_oDiag, oReturn)
        m_oDiag.uid = CType(oReturn, Diagnostic).uid
        'Envoie sur le serveur des buses
        DiagnosticBusesManager.WSSend(m_oDiag)
        'Récupération depuis le serveur et ajout au diag pour les buses avec un uid
        Dim olst As DiagnosticBusesList
        olst = DiagnosticBusesManager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(2, olst.Liste.Count)
        m_oDiag.diagnosticBusesList.Liste.Clear()
        For Each oBuse In olst.Liste
            Assert.AreEqual(m_oDiag.uid, obuse.uiddiagnostic)
            Assert.AreEqual(m_oDiag.aid, obuse.aiddiagnostic)
            m_oDiag.diagnosticBusesList.Liste.Add(obuse)
        Next
        DiagnosticManager.save(m_oDiag)
        DiagnosticManager.getDiagnosticById(m_oDiag.id)


        oBuse = m_oDiag.diagnosticBusesList.Liste(0)
        'Creatin du detail
        Dim oDiagBuseDetail As DiagnosticBusesDetail
        oDiagBuseDetail = New DiagnosticBusesDetail(oBuse)
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.debit = 10
        oDiagBuseDetail.ecart = 11
        oBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail(oBuse)
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.debit = 20
        oDiagBuseDetail.ecart = 21
        oBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail(oBuse)
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.debit = 30
        oDiagBuseDetail.ecart = 31
        oBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        'CREATE ON SERVER
        DiagnosticBusesDetailManager.WSSend(m_oDiag)

        'read
        Dim lst As DiagnosticBusesDetailList
        lst = DiagnosticBusesDetailManager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(3, lst.Liste.Count)

        oDiagBuseDetail = lst.Liste(0)
        Assert.AreEqual("10", oDiagBuseDetail.debit)
        Assert.AreEqual("11", oDiagBuseDetail.ecart)
        oDiagBuseDetail = lst.Liste(1)
        Assert.AreEqual("20", oDiagBuseDetail.debit)
        Assert.AreEqual("21", oDiagBuseDetail.ecart)
        oDiagBuseDetail = lst.Liste(2)
        Assert.AreEqual("30", oDiagBuseDetail.debit)
        Assert.AreEqual("31", oDiagBuseDetail.ecart)

        oBuse.diagnosticBusesDetailList.Liste.Clear()
        For Each oDiagBusDetail In lst.Liste
            If oDiagBusDetail.uid <> 0 Then
                oBuse.diagnosticBusesDetailList.Liste.Add(oDiagBusDetail)
            End If
        Next

        'UPDATE
        oDiagBuseDetail = oBuse.diagnosticBusesDetailList.Liste(0)
        oDiagBuseDetail.debit = 100
        oDiagBuseDetail.ecart = 110
        oDiagBuseDetail = oBuse.diagnosticBusesDetailList.Liste(1)
        oDiagBuseDetail.debit = 200
        oDiagBuseDetail.ecart = 210
        oDiagBuseDetail = oBuse.diagnosticBusesDetailList.Liste(2)
        oDiagBuseDetail.debit = 300
        oDiagBuseDetail.ecart = 310
        oDiagBuseDetail = New DiagnosticBusesDetail(oBuse)
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.debit = 400
        oDiagBuseDetail.ecart = 410
        oBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)
        DiagnosticManager.save(m_oDiag) 'Sauvegarde pour Modifier les dates Agent
        'Send
        'Dim codereponse As Integer
        codeReponse = DiagnosticBusesDetailManager.WSSend(m_oDiag)

        'ReRead
        'read
        lst = DiagnosticBusesDetailManager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(4, lst.Liste.Count) 'on ne devrait en avoir que  4 !!!!

        oDiagBuseDetail = lst.Liste(lst.Liste.Count - 4)
        Assert.AreNotEqual(0, oDiagBuseDetail.uid)
        Assert.AreEqual("100", oDiagBuseDetail.debit)
        Assert.AreEqual("110", oDiagBuseDetail.ecart)
        oDiagBuseDetail = lst.Liste(lst.Liste.Count - 3)
        Assert.AreEqual("200", oDiagBuseDetail.debit)
        Assert.AreEqual("210", oDiagBuseDetail.ecart)
        oDiagBuseDetail = lst.Liste(lst.Liste.Count - 2)
        Assert.AreEqual("300", oDiagBuseDetail.debit)
        Assert.AreEqual("310", oDiagBuseDetail.ecart)
        oDiagBuseDetail = lst.Liste(lst.Liste.Count - 1)
        Assert.AreEqual("400", oDiagBuseDetail.debit)
        Assert.AreEqual("410", oDiagBuseDetail.ecart)

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
    '    Dim oDiagItem As New DiagnosticBusesDetail(oDiagnostic.aid, "123", "0")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New DiagnosticBusesDetail(oDiagnostic.aid, "456", "1")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New DiagnosticBusesDetail(oDiagnostic.aid, "789", "2")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)


    '    Dim serializer As New XmlSerializer(GetType(DiagnosticBuseList))
    '    Using writer As New StringWriter()
    '        serializer.Serialize(writer, oDiagnostic.DiagnosticBusesDetailLst)
    '        Dim xmlOutput As String = writer.ToString()
    '        Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
    '        Trace.WriteLine(xmlOutput)
    '    End Using

    'End Sub


End Class