﻿Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour CSEnvironnement
'''</summary>
<TestClass()> _
Public Class CSDateTest


    Private testContextInstance As TestContext

    '''<summary>
    '''Obtient ou définit le contexte de test qui fournit
    '''des informations sur la série de tests active ainsi que ses fonctionnalités.
    '''</summary>
    Public Property TestContext() As TestContext
        Get
            Return testContextInstance
        End Get
        Set(ByVal value As TestContext)
            testContextInstance = value
        End Set
    End Property

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
    '<TestCleanup()>  _
    'Public Sub MyTestCleanup()
    'End Sub
    '
#End Region


    '''<summary>
    '''Test pour RenameFiles
    '''</summary>
    <TestMethod()> _
    Public Sub CheckHoursTest()

        Assert.IsTrue(CSDate.CheckHours("10:00"))
        Assert.IsTrue(CSDate.CheckHours("14:00"))
        Assert.IsFalse(CSDate.CheckHours("10:"))
        Assert.IsFalse(CSDate.CheckHours("14:"))
        Assert.IsFalse(CSDate.CheckHours("10:63"))
        Assert.IsFalse(CSDate.CheckHours("23:63"))
        Assert.IsFalse(CSDate.CheckHours("25:00"))
        Assert.IsFalse(CSDate.CheckHours("25:63"))
        Assert.IsFalse(CSDate.CheckHours("25:"))
    End Sub


End Class
