Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class DiagnosticItemTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim lst As DiagnosticItemList
        lst = DiagnosticItemManager.WSGetList(145691, "998-TSTMCO-12345-1")
        Assert.IsNotNull(lst)
        Assert.AreEqual(18, lst.Liste.Count)
        Assert.AreEqual(145691, lst.Liste(0).uiddiagnostic)
        Assert.AreEqual(145691, lst.Liste(1).uiddiagnostic)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oDiagnostic As CRODIPWS.Diagnostic
        oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145688, "")
        Assert.IsNotNull(oDiagnostic)
        Dim oDiagItem As New DiagnosticItem(oDiagnostic.aid, "123", "0")
        oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiagnostic.aid, "456", "1")
        oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiagnostic.aid, "789", "2")
        oDiagnostic.AdOrReplaceDiagItem(oDiagItem)

        Dim nReturn As Integer = DiagnosticItemManager.WSSend(m_oAgent, oDiagnostic.diagnosticItemsLst)

        Assert.AreNotEqual(-1, nReturn)

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

        ' Création de l'objet
        Dim oReturn As Diagnostic
        nreturn = DiagnosticManager.WSSend(m_oDiag, oReturn)
        Assert.AreEqual(2, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        m_oDiag = DiagnosticManager.WSgetById(m_oAgent.uid, oReturn.uid, oReturn.aid)
        Assert.AreEqual("TU_MCO", m_oDiag.commentaire)

        'Update de l'objet
        m_oDiag.commentaire = "TU_UPDATE"
        nreturn = DiagnosticManager.WSSend(m_oDiag, oReturn)
        Assert.AreEqual(m_oDiag.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.AreEqual("TU_UPDATE", m_oDiag.commentaire)

    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oDiagnostic As CRODIPWS.Diagnostic
        oDiagnostic = createAndSaveDiagnostic()
        Dim oDiagItem As New DiagnosticItem(oDiagnostic.aid, "123", "0")
        oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiagnostic.aid, "456", "1")
        oDiagnostic.AdOrReplaceDiagItem(oDiagItem)
        oDiagItem = New DiagnosticItem(oDiagnostic.aid, "789", "2")
        oDiagnostic.AdOrReplaceDiagItem(oDiagItem)

        Dim tmpArr(1)() As DiagnosticItem
        tmpArr(0) = oDiagnostic.diagnosticItemsLst.items

        Dim serializer As New XmlSerializer(GetType(DiagnosticItemList))
        Using writer As New StringWriter()
            serializer.Serialize(writer, oDiagnostic.diagnosticItemsLst)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class