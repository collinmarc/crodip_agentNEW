Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour DiagnosticTroncons833 et DiagnosticTroncons833Manager
'''</summary>
<TestClass()> _
Public Class DiagnosticTroncons833Test
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
    <TestMethod()> _
    Public Sub TST_Create_Save_Update()
        Dim oDiagTroncons833 As DiagnosticTroncons833
        Dim iD As Integer
        Dim oCSDB As New CSDb(True)

        oDiagTroncons833 = New DiagnosticTroncons833

        createAndSaveDiagnostic()

        oDiagTroncons833.idDiagnostic = m_oDiag.id
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "1.7"
        oDiagTroncons833.ManocId = 123

        DiagnosticTroncons833Manager.save(oDiagTroncons833, oCSDB)
        iD = oDiagTroncons833.id
        oDiagTroncons833 = DiagnosticTroncons833Manager.getDiagnosticTroncons833ById(oDiagTroncons833.id.ToString, oDiagTroncons833.idDiagnostic)

        Assert.AreEqual(oDiagTroncons833.id, iD)
        Assert.AreEqual(oDiagTroncons833.idDiagnostic, m_oDiag.id)
        Assert.AreEqual(oDiagTroncons833.idPression, "1")
        Assert.AreEqual(oDiagTroncons833.idColumn, "1")
        Assert.AreEqual(oDiagTroncons833.pressionSortie, "1.7")
        Assert.AreEqual(oDiagTroncons833.ManocId, "123")

        'Maj de l'objet
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "2.7"
        oDiagTroncons833.ManocId = 456
        DiagnosticTroncons833Manager.save(oDiagTroncons833, oCSDB)
        oDiagTroncons833 = DiagnosticTroncons833Manager.getDiagnosticTroncons833ById(oDiagTroncons833.id.ToString, oDiagTroncons833.idDiagnostic)

        Assert.AreEqual(oDiagTroncons833.idPression, "2")
        Assert.AreEqual(oDiagTroncons833.idColumn, "2")
        Assert.AreEqual(oDiagTroncons833.pressionSortie, "2.7")
        Assert.AreEqual(oDiagTroncons833.ManocId, "456")

        DiagnosticTroncons833Manager.delete(oDiagTroncons833.id.ToString, oDiagTroncons833.idDiagnostic)


    End Sub
    '''<summary>
    '''Test de charegement déchargement depuis le Diag
    '''</summary>
    <TestMethod()>
    Public Sub TST_LOAD_SAVE_DIAG()
        Dim odiag As Diagnostic

        Dim oDiagTroncons833 As DiagnosticTroncons833

        odiag = createAndSaveDiagnostic()
        odiag.diagnosticTroncons833.Liste.Clear()
        oDiagTroncons833 = New DiagnosticTroncons833

        oDiagTroncons833.idDiagnostic = odiag.id
        oDiagTroncons833.idPression = "1"
        oDiagTroncons833.idColumn = "1"
        oDiagTroncons833.pressionSortie = "1.7"
        oDiagTroncons833.ManocId = "123"
        odiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        oDiagTroncons833 = New DiagnosticTroncons833
        oDiagTroncons833.idDiagnostic = odiag.id
        oDiagTroncons833.idPression = "2"
        oDiagTroncons833.idColumn = "2"
        oDiagTroncons833.pressionSortie = "2.7"
        oDiagTroncons833.ManocId = "456"
        odiag.diagnosticTroncons833.Liste.Add(oDiagTroncons833)

        DiagnosticManager.save(odiag)

        'Rechargement par le diagnostic
        Dim oCSDB As New CSDb(True)
        DiagnosticTroncons833Manager.getDiagnosticTroncons833ByDiagnostic(oCSDB, odiag)
        'Vérification que les Troncons833 sopnt bien lus
        Assert.AreEqual(2, odiag.diagnosticTroncons833.Liste.Count)

        oDiagTroncons833 = odiag.diagnosticTroncons833.Liste(0)
        Assert.AreEqual(oDiagTroncons833.idDiagnostic, odiag.id)
        Assert.AreEqual(oDiagTroncons833.idPression, "1")
        Assert.AreEqual(oDiagTroncons833.idColumn, "1")
        Assert.AreEqual(oDiagTroncons833.pressionSortie, "1.7")
        Assert.AreEqual(oDiagTroncons833.ManocId, "123")

        oDiagTroncons833 = odiag.diagnosticTroncons833.Liste(1)
        Assert.AreEqual(oDiagTroncons833.idDiagnostic, odiag.id)
        Assert.AreEqual(oDiagTroncons833.idPression, "2")
        Assert.AreEqual(oDiagTroncons833.idColumn, "2")
        Assert.AreEqual(oDiagTroncons833.pressionSortie, "2.7")
        Assert.AreEqual(oDiagTroncons833.ManocId, "456")

        'Maj de la Pression 2
        oDiagTroncons833.idPression = "3"
        oDiagTroncons833.idColumn = "3"
        oDiagTroncons833.pressionSortie = "3.7"
        oDiagTroncons833.ManocId = "789"

        DiagnosticTroncons833Manager.save(oDiagTroncons833, oCSDB)

        'Relecture des items
        DiagnosticTroncons833Manager.getDiagnosticTroncons833ByDiagnostic(oCSDB, odiag)

        Assert.AreEqual(2, odiag.diagnosticTroncons833.Liste.Count)
        oDiagTroncons833 = odiag.diagnosticTroncons833.Liste(1)
        Assert.AreEqual(oDiagTroncons833.idPression, "3")
        Assert.AreEqual(oDiagTroncons833.idColumn, "3")
        Assert.AreEqual(oDiagTroncons833.pressionSortie, "3.7")
        Assert.AreEqual(oDiagTroncons833.ManocId, "789")

        DiagnosticTroncons833Manager.deleteByDiagnosticID(oDiagTroncons833.idDiagnostic)

        oCSDB.free()

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetUpdates()

    End Sub
End Class
