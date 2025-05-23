﻿Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



'''<summary>
'''Classe de test pour DiagnosticBusesDetail, destinée à contenir tous
'''les tests unitaires 
'''</summary>
<TestClass()> _
Public Class DiagnosticBusesDetailTest
    Inherits CRODIPTest



#Region "Attributs de tests supplémentaires"
    '
    'Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
    '
    'Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test dans la classe
    '<ClassInitialize()>  _
    'Public Shared Sub MyClassInitialize(ByVal testContext As TestContext)
    'End Sub
    '
    'Utilisez ClassCleanup pour exécuter du code après que tous les tests ont été exécutés dans une classe
    '<ClassCleanup()>  _
    'Public Shared Sub MyClassCleanup()
    'End Sub
    '
    'Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test
    '<TestInitialize()>  _
    'Public Sub MyTestInitialize()
    'End Sub
    '
    'Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
    '<TestCleanup()> _
    'Public Sub MyTestCleanup()
    'End Sub
#End Region


    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Object()
    End Sub

    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()>
    Public Sub TST_Create_Save_Update()
        Dim oExploit As Exploitation = createExploitation()
        Dim oPulve As Pulverisateur = createPulve(oExploit)

        Dim oDiag As Diagnostic = createDiagnostic(oExploit, oPulve, True)
        Dim oDiagBuse As DiagnosticBusesDetail
        Dim iD As Integer
        oDiagBuse = New DiagnosticBusesDetail

        oDiagBuse.idDiagnostic = oDiag.id
        oDiagBuse.numBuse = 1
        oDiagBuse.idLot = "1"
        oDiagBuse.debit = "debit"
        oDiagBuse.ecart = "ecart"

        DiagnosticBusesDetailManager.save(oDiagBuse)
        iD = oDiagBuse.id
        oDiagBuse = DiagnosticBusesDetailManager.getDiagnosticBusesDetailById(oDiagBuse.id.ToString, oDiagBuse.idDiagnostic.ToString)

        Assert.AreEqual(oDiagBuse.id, iD)
        Assert.AreEqual(oDiagBuse.idDiagnostic, oDiag.id)
        Assert.AreEqual(oDiagBuse.numBuse, 1)
        Assert.AreEqual(oDiagBuse.idLot, "1")
        Assert.AreEqual(oDiagBuse.debit, "debit")
        Assert.AreEqual(oDiagBuse.ecart, "ecart")

        'Maj de l'objet
        oDiagBuse.numBuse = 2
        oDiagBuse.idLot = "2"
        oDiagBuse.debit = "debit2"
        oDiagBuse.ecart = "ecart2"
        DiagnosticBusesDetailManager.save(oDiagBuse)
        oDiagBuse = DiagnosticBusesDetailManager.getDiagnosticBusesDetailById(oDiagBuse.id.ToString, oDiagBuse.idDiagnostic.ToString)

        Assert.AreEqual(oDiagBuse.id, iD)
        Assert.AreEqual(oDiagBuse.idDiagnostic, oDiag.id)
        Assert.AreEqual(oDiagBuse.numBuse, 2)
        Assert.AreEqual(oDiagBuse.idLot, "2")
        Assert.AreEqual(oDiagBuse.debit, "debit2")
        Assert.AreEqual(oDiagBuse.ecart, "ecart2")

        DiagnosticBusesDetailManager.delete(oDiagBuse.id.ToString, oDiagBuse.idDiagnostic.ToString)


    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetByID()

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetUpdates()

    End Sub
End Class
