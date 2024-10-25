Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class diagnosticTroncons833TestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim lst As DiagnosticTroncons833List
        lst = DiagnosticTroncons833Manager.WSGetList(145691, "998-TSTMCO-12345-1")
        Assert.IsNotNull(lst)
        Assert.AreEqual(37, lst.Liste.Count)
        Assert.AreEqual(145691, lst.Liste(0).uiddiagnostic)
        Assert.AreEqual(145691, lst.Liste(1).uiddiagnostic)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oDiagnostic As CRODIPWS.Diagnostic
        oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697, "")
        oDiagnostic.diagnosticTroncons833.Liste.Clear()
        Assert.IsNotNull(oDiagnostic)
        Dim oDiagT833 As DiagnosticTroncons833
        oDiagT833 = New DiagnosticTroncons833(oDiagnostic)
        oDiagT833.idPression = 1
        oDiagT833.idColumn = 10
        oDiagT833.pressionSortie = 10.1
        oDiagnostic.diagnosticTroncons833.Liste.Add(oDiagT833)
        oDiagT833 = New DiagnosticTroncons833(oDiagnostic)
        oDiagT833.idPression = 2
        oDiagT833.idColumn = 20
        oDiagT833.pressionSortie = 20.2
        oDiagnostic.diagnosticTroncons833.Liste.Add(oDiagT833)
        oDiagT833 = New DiagnosticTroncons833(oDiagnostic)
        oDiagT833.idPression = 3
        oDiagT833.idColumn = 30
        oDiagT833.pressionSortie = 30.3
        oDiagnostic.diagnosticTroncons833.Liste.Add(oDiagT833)
        Dim nReturn As Integer
        nReturn = DiagnosticTroncons833Manager.WSSend(oDiagnostic)
        Assert.AreNotEqual(-1, nReturn)
        Assert.AreNotEqual(99, nReturn)

    End Sub
    <TestMethod()> Public Sub CRUDWS()
        Dim nreturn As Integer
        m_oExploitation = createExploitation()
        Dim updated As root
        nreturn = ExploitationManager.WSSend(m_oExploitation, updated)
        m_oExploitation = CType(updated, Exploitation)
        m_oPulve = createPulve(m_oExploitation)
        Dim updated2 As root
        nreturn = PulverisateurManager.WSSend(m_oPulve, updated2)
        m_oPulve = CType(updated2, Pulverisateur)


        m_oDiag = createAndSaveDiagnostic()
        m_oDiag.commentaire = "TU_MCO"

        Dim oReturn As Object
        nreturn = DiagnosticManager.WSSend(m_oDiag, oReturn)
        m_oDiag.uid = CType(oReturn, Diagnostic).uid

        m_oDiag.diagnosticTroncons833.Liste.Clear()
        Assert.IsNotNull(m_oDiag)
        Dim oDiagT833 As DiagnosticTroncons833
        oDiagT833 = New DiagnosticTroncons833(m_oDiag)
        oDiagT833.idPression = 1
        oDiagT833.idColumn = 10
        oDiagT833.pressionSortie = 10.1
        m_oDiag.diagnosticTroncons833.Liste.Add(oDiagT833)
        oDiagT833 = New DiagnosticTroncons833(m_oDiag)
        oDiagT833.idPression = 2
        oDiagT833.idColumn = 20
        oDiagT833.pressionSortie = 20.2
        m_oDiag.diagnosticTroncons833.Liste.Add(oDiagT833)
        oDiagT833 = New DiagnosticTroncons833(m_oDiag)
        oDiagT833.idPression = 3
        oDiagT833.idColumn = 30
        oDiagT833.pressionSortie = 30.3
        m_oDiag.diagnosticTroncons833.Liste.Add(oDiagT833)

        'CREATE
        DiagnosticTroncons833Manager.WSSend(m_oDiag)

        'read
        Dim lst As DiagnosticTroncons833List
        lst = DiagnosticTroncons833Manager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(3, lst.Liste.Count)
        m_oDiag.diagnosticTroncons833.Liste.Clear()
        For Each oDiagT833 In lst.Liste
            m_oDiag.diagnosticTroncons833.Liste.Add(oDiagT833)
        Next
        oDiagT833 = m_oDiag.diagnosticTroncons833.Liste(0)
        Assert.AreEqual("1", oDiagT833.idPression)
        Assert.AreEqual("10", oDiagT833.idColumn)
        Assert.AreEqual("10,1", oDiagT833.pressionSortie)
        oDiagT833 = m_oDiag.diagnosticTroncons833.Liste(1)
        Assert.AreEqual("2", oDiagT833.idPression)
        Assert.AreEqual("20", oDiagT833.idColumn)
        Assert.AreEqual("20,2", oDiagT833.pressionSortie)
        oDiagT833 = m_oDiag.diagnosticTroncons833.Liste(2)
        Assert.AreEqual("3", oDiagT833.idPression)
        Assert.AreEqual("30", oDiagT833.idColumn)
        Assert.AreEqual("30,3", oDiagT833.pressionSortie)
        'UPDATE
        oDiagT833 = m_oDiag.diagnosticTroncons833.Liste(0)
        oDiagT833.idPression = 1
        oDiagT833.idColumn = 100
        oDiagT833.pressionSortie = 100.1
        oDiagT833 = m_oDiag.diagnosticTroncons833.Liste(1)
        oDiagT833.idPression = 2
        oDiagT833.idColumn = 200
        oDiagT833.pressionSortie = 200.2
        oDiagT833 = m_oDiag.diagnosticTroncons833.Liste(2)
        oDiagT833.idPression = 3
        oDiagT833.idColumn = 300
        oDiagT833.pressionSortie = 300.3
        'Ajout d'un 4eme
        oDiagT833 = New DiagnosticTroncons833(m_oDiag)
        oDiagT833.idPression = 4
        oDiagT833.idColumn = 400
        oDiagT833.pressionSortie = 400.4
        m_oDiag.diagnosticTroncons833.Liste.Add(oDiagT833)
        'Il faut les sauvegarder pour Modifier les datesdeModifAgent
        DiagnosticManager.save(m_oDiag)


        'Send
        Dim codereponse As Integer
        codereponse = DiagnosticTroncons833Manager.WSSend(m_oDiag)
        'ReRead
        lst = DiagnosticTroncons833Manager.WSGetList(m_oDiag.uid, m_oDiag.aid)
        Assert.AreEqual(4, lst.Liste.Count)
        m_oDiag.diagnosticTroncons833.Liste.Clear()
        For Each oDiagT833 In lst.Liste
            m_oDiag.diagnosticTroncons833.Liste.Add(oDiagT833)
        Next

        oDiagT833 = lst.Liste(m_oDiag.diagnosticTroncons833.Liste.Count - 4)
        Assert.AreEqual("1", oDiagT833.idPression)
        Assert.AreEqual("100", oDiagT833.idColumn)
        Assert.AreEqual("100,1", oDiagT833.pressionSortie)
        oDiagT833 = lst.Liste(m_oDiag.diagnosticTroncons833.Liste.Count - 3)
        Assert.AreEqual("2", oDiagT833.idPression)
        Assert.AreEqual("200", oDiagT833.idColumn)
        Assert.AreEqual("200,2", oDiagT833.pressionSortie)
        oDiagT833 = lst.Liste(m_oDiag.diagnosticTroncons833.Liste.Count - 2)
        Assert.AreEqual("3", oDiagT833.idPression)
        Assert.AreEqual("300", oDiagT833.idColumn)
        Assert.AreEqual("300,3", oDiagT833.pressionSortie)
        oDiagT833 = lst.Liste(m_oDiag.diagnosticTroncons833.Liste.Count - 1)
        Assert.AreEqual("4", oDiagT833.idPression)
        Assert.AreEqual("400", oDiagT833.idColumn)
        Assert.AreEqual("400,4", oDiagT833.pressionSortie)

    End Sub
    '<TestMethod()> Public Sub WSSerialize()
    '    Dim oDiagnostic As CRODIPWS.Diagnostic
    '    oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697)
    '    Assert.IsNotNull(oDiagnostic)
    '    Dim oDiagItem As New diagnosticTroncons833(oDiagnostic.aid, "123", "0")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New diagnosticTroncons833(oDiagnostic.aid, "456", "1")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
    '    oDiagItem = New diagnosticTroncons833(oDiagnostic.aid, "789", "2")
    '    oDiagnostic.AdOrReplaceDiagItem(oDiagItem)


    '    Dim serializer As New XmlSerializer(GetType(DiagnosticBuseList))
    '    Using writer As New StringWriter()
    '        serializer.Serialize(writer, oDiagnostic.diagnosticTroncons833Lst)
    '        Dim xmlOutput As String = writer.ToString()
    '        Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
    '        Trace.WriteLine(xmlOutput)
    '    End Using

    'End Sub


End Class