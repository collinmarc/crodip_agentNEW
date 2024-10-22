Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CRODIPWS
Imports System.Xml.Serialization
Imports System.IO
Imports System.Net.Http

<TestClass()> Public Class DiagnosticTestWS
    Inherits CRODIPTest

    <TestMethod()> Public Sub getWS()
        Dim Diagnostic As CRODIPWS.Diagnostic
        Diagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697)
        Assert.IsNotNull(Diagnostic)
        Assert.AreEqual(145697, Diagnostic.uid)

    End Sub
    <TestMethod()> Public Sub sendWS()
        Dim oDiagnostic As CRODIPWS.Diagnostic
        oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697)
        Assert.IsNotNull(oDiagnostic)
        oDiagnostic.commentaire = "TESTUMCO"
        Dim oreturn As CRODIPWS.Diagnostic
        Dim nReturn As Integer
        nReturn = DiagnosticManager.WSSend(oDiagnostic, oreturn)
        Assert.AreEqual(2, nReturn)
        oDiagnostic = DiagnosticManager.WSgetById(m_oAgent.uid, 145697)
        Assert.AreEqual("TESTUMCO", oDiagnostic.commentaire)

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
        Assert.AreEqual(4, nreturn)
        Assert.IsNotNull(oReturn.uid)

        'Lecture de l'objet
        m_oDiag = DiagnosticManager.WSgetById(m_oAgent.uid, oReturn.uid)
        Assert.AreEqual("TU_MCO", m_oDiag.commentaire)

        'Update de l'objet
        m_oDiag.commentaire = "TU_UPDATE"
        nreturn = DiagnosticManager.WSSend(m_oDiag, oReturn)
        Assert.AreEqual(m_oDiag.uid, oReturn.uid)
        Assert.AreEqual(2, nreturn)
        Assert.AreEqual("TU_UPDATE", m_oDiag.commentaire)

    End Sub
    <TestMethod()> Public Sub WSSerialize()
        Dim oDiagnostic As New CRODIPWS.Diagnostic()
        oDiagnostic.commentaire = "TU_MCO"
        Dim serializer As New XmlSerializer(oDiagnostic.GetType())
        Using writer As New StringWriter()
            serializer.Serialize(writer, oDiagnostic)
            Dim xmlOutput As String = writer.ToString()
            ' Vous pouvez maintenant vérifier ou envoyer cette chaîne sérialisée
            Trace.WriteLine(xmlOutput)
        End Using

    End Sub


End Class