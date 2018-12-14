Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.IO

<TestClass()> Public Class EtatFeuillePedaTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub TestGenereFeuillePedagogique()
        Dim oEtat As EtatFeuillePeda
        Dim oDiag As Diagnostic
        Dim oPulve As Pulverisateur
        Dim oExploit As Exploitation

        oExploit = createExploitation()
        oPulve = createPulve(oExploit)


        oDiag = New Diagnostic(m_oAgent, oPulve, oExploit)
        oDiag.controleLieu = "Bouessay"
        oDiag.controleCodePostal = "35250"
        oDiag.controleCommune = "Chasné sur illet"

        oDiag.id = "2-852-963"
        oDiag.controleIsComplet = False
        oDiag.buseDebitD = "2.5"
        oDiag.controleInitialId = "010101"
        oDiag.controleDateDernierControle = Date.Now().AddMonths(-1)
        oDiag.controleEtat = Diagnostic.controleEtatNOKCV 'Défauts sur le Pulvé


        Dim oFeuill As New FeuillePeda(oDiag)
        oFeuill.Conseils = "ceci est un conseil"
        For i = 1 To 3
            oFeuill.Infos = oFeuill.Infos & " Ligne" & i & vbCrLf
        Next
        oEtat = New EtatFeuillePeda(oFeuill)

        Assert.IsTrue(oEtat.GenereEtat)
        Assert.IsNotNull(oEtat.getFileName())
        Assert.IsTrue(oEtat.Open())
    End Sub
End Class