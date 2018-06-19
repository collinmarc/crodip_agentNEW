Imports System.Text
'Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
Imports System.Data

Public Class FTO_RPinfosBuses
    Inherits RPInfosBuses
    Sub New(pNbDescente As Integer)
        MyBase.New(pNbDescente)
    End Sub
    Public Property FTO_ListInfosDescentes() As List(Of String)
        Get
            Return MyBase.m_infosDescentes
        End Get
        Set(ByVal value As List(Of String))
            MyBase.m_infosDescentes = value
        End Set
    End Property
End Class
<TestClass()>
Public Class RPInfosBusesTest

    'Private _testContext As TestContext
    'Public Property TestContext As TestContext
    '    Get
    '        Return _testContext
    '    End Get
    '    Set(ByVal value As TestContext)
    '        _testContext = value
    '    End Set
    'End Property
    '<DataTestMethod()>
    '<DataRow(0, 4)>
    'Public Sub TestUpdateNbDscente(pValinit As Integer, pValNew As Integer)

    '    Dim oRPInfosBuses As FTO_RPinfosBuses

    '    oRPInfosBuses = New FTO_RPinfosBuses(pValinit)
    '    Assert.AreEqual(oRPInfosBuses.NbDescentes, oRPInfosBuses.FTO_ListInfosDescentes.Count)

    '    oRPInfosBuses.NbDescentes = pValNew
    '    Assert.AreEqual(pValNew, oRPInfosBuses.NbDescentes)
    '    Assert.AreEqual(pValNew, oRPInfosBuses.FTO_ListInfosDescentes.Count)

    'End Sub

    <TestMethod()>
    Public Sub TestUpdateNbDscente1()

        Dim oRPInfosBuses As FTO_RPinfosBuses

        oRPInfosBuses = New FTO_RPinfosBuses(0)
        Assert.AreEqual(oRPInfosBuses.NbDescentes, oRPInfosBuses.FTO_ListInfosDescentes.Count)

        oRPInfosBuses.NbDescentes = 4
        Assert.AreEqual(4, oRPInfosBuses.NbDescentes)
        Assert.AreEqual(4, oRPInfosBuses.FTO_ListInfosDescentes.Count)
        oRPInfosBuses.NbDescentes = 10
        Assert.AreEqual(10, oRPInfosBuses.NbDescentes)
        Assert.AreEqual(10, oRPInfosBuses.FTO_ListInfosDescentes.Count)
        oRPInfosBuses.NbDescentes = 3
        Assert.AreEqual(3, oRPInfosBuses.NbDescentes)
        Assert.AreEqual(3, oRPInfosBuses.FTO_ListInfosDescentes.Count)

    End Sub
    <TestMethod()>
    Public Sub TestUpdateNbNiveaux()

        Dim oRPDiag As RPDiagnostic

        oRPDiag = New RPDiagnostic()
        oRPDiag.CalcNbreDescentes = 5
        oRPDiag.CalcNbreNiveauParDescente = 2
        Assert.AreEqual(2 + 1, oRPDiag.ListInfosBuses.Count)
        oRPDiag.CalcNbreNiveauParDescente = 5
        Assert.AreEqual(5 + 1, oRPDiag.ListInfosBuses.Count)

        oRPDiag.CalcNbreDescentes = 6
        For Each oRPInfoBuses As RPInfosBuses In oRPDiag.ListInfosBuses
            Assert.AreEqual(6, oRPInfoBuses.NbDescentes)
        Next


    End Sub
End Class