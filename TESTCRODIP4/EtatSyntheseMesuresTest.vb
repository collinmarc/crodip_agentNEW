Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatSyntheseMesuresTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereEtatsynthese()
        Dim oEtat As EtatSyntheseMesures
        Dim oDiag As Diagnostic

        oDiag = createAndSaveDiagnostic()
        oDiag.controleNbreNiveaux = 1
        oDiag.controleNbreTroncons = 4

        oEtat = New EtatSyntheseMesures(oDiag)
        Assert.IsTrue(oEtat.genereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub

    <TestMethod()> Public Sub TestMod()
        Dim oTroncon833 As New DiagnosticTroncons833()
        oTroncon833.idColumn = 1
        oTroncon833.CalcNiveauTroncons(4)
        Assert.AreEqual(1, oTroncon833.nNiveau)
        Assert.AreEqual(1, oTroncon833.nTroncon)

        oTroncon833.idColumn = 3
        oTroncon833.CalcNiveauTroncons(4)
        Assert.AreEqual(1, oTroncon833.nNiveau)
        Assert.AreEqual(3, oTroncon833.nTroncon)

        oTroncon833.idColumn = 4
        oTroncon833.CalcNiveauTroncons(4)
        Assert.AreEqual(1, oTroncon833.nNiveau)
        Assert.AreEqual(4, oTroncon833.nTroncon)

        oTroncon833.idColumn = 5
        oTroncon833.CalcNiveauTroncons(4)
        Assert.AreEqual(2, oTroncon833.nNiveau)
        Assert.AreEqual(1, oTroncon833.nTroncon)
        oTroncon833.idColumn = 8
        oTroncon833.CalcNiveauTroncons(4)
        Assert.AreEqual(2, oTroncon833.nNiveau)
        Assert.AreEqual(4, oTroncon833.nTroncon)
        oTroncon833.idColumn = 9
        oTroncon833.CalcNiveauTroncons(4)
        Assert.AreEqual(3, oTroncon833.nNiveau)
        Assert.AreEqual(1, oTroncon833.nTroncon)

    End Sub

End Class