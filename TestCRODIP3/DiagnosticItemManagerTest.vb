Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class DiagnosticItemManagerTest
    Inherits CRODIPTest

    <TestMethod()>
    Public Sub TST_SendDiagWS1DiagItem()
        Dim oExploit As Exploitation = createExploitation()
        Dim oPulve As Pulverisateur = createPulve(oExploit)
        'Création d'un diag sans Sauvegarde
        Dim oDiag As Diagnostic = createDiagnostic(oExploit, oPulve, False)
        'Création d'un Defaut
        oDiag.diagnosticItemsLst.Clear()
        Dim oDiagItem As DiagnosticItem
        'Item1
        oDiagItem = New DiagnosticItem()
        oDiagItem.idItem = "111"
        oDiagItem.itemValue = "1"
        oDiagItem.itemCodeEtat = "O"
        oDiagItem.cause = "1"
        oDiag.AdOrReplaceDiagItem(oDiagItem)

        'Sauvegarde 
        Dim idDiag As String
        idDiag = oDiag.id
        DiagnosticManager.save(oDiag)

        'Synhcronisation ASC
        Dim oSynchro As New Synchronisation(m_oAgent)
        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        'Synhcronisation DESC
        Dim oElem As SynchronisationElmtDiag = New SynchronisationElmtDiag(idDiag)
        oElem.SynchroDesc(m_oAgent)

        'Après Synhcro on a bien 1 diagItem en base
        oDiag.diagnosticItemsLst.Clear()
        Dim oCSDB As New CSDb(True)
        DiagnosticItemManager.getDiagnosticItemByDiagnosticId(oCSDB, oDiag)
        oCSDB.free()
        Assert.AreEqual(1, oDiag.diagnosticItemsLst.Count())

        'on Signe le Diag a postériori
        oDiag.isSignRIClient = True
        oDiag.dateSignRIClient = CDate("2022/04/22")

        DiagnosticManager.save(oDiag)

        'Synhcronisation ASC
        'Dim oSynchro As New Synchronisation(m_oAgent)
        Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, oDiag))

        'Synhcronisation DESC
        'Dim oElem As SynchronisationElmtDiag = New SynchronisationElmtDiag(idDiag)
        oElem.SynchroDesc(m_oAgent)

        'Après Synhcro on a bien 1 diagItem en base
        oDiag.diagnosticItemsLst.Clear()
        oCSDB = New CSDb(True)
        DiagnosticItemManager.getDiagnosticItemByDiagnosticId(oCSDB, oDiag)
        oCSDB.free()
        Assert.AreEqual(1, oDiag.diagnosticItemsLst.Count())




    End Sub

End Class