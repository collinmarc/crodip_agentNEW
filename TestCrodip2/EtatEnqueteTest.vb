Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatenquteTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereEnquete()
        Dim oEtat As EtatEnquete
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)
        oPulve.type = "Arbres"
        oDiag = createDiagnostic(oExploit, oPulve)
        oDiag.controleIsComplet = False
        oDiag.inspecteurNom = "NomInspecteur"
        oDiag.inspecteurPrenom = "Prénom"


        oEtat = New EtatEnquete(oDiag)
        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())

        'oDiag.controleIsComplet = False
        'Assert.IsTrue(oEtat.GenereEtat)
        'Assert.IsNotNull(oEtat.getFileName())
        'Assert.IsTrue(oEtat.Open())

    End Sub

End Class