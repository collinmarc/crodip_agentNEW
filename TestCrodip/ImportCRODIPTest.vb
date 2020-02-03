Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent
Imports System.IO
Imports CsvHelper

'''<summary>
'''Classe de test pour PulverisateurManagerTest, destinée à contenir tous
'''les tests unitaires PulverisateurManagerTest
'''</summary>
<TestClass()>
Public Class ImportCRODIPTest
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
    <TestMethod()>
    Public Sub TST_Object()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.nomExploitant = "TEST2"
        obj.numeroSiren = "789456123"
        obj.numeroNational = "E001002"
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)


        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(2, oResult.nClientimport)
        Assert.AreEqual(2, oResult.nPulveimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitapres, nExploitAvant + 2)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveApres, nPulveAvant + 2)

    End Sub

    <TestMethod()>
    Public Sub TST_ImportPulveSansNumNat()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.nomExploitant = "TEST2"
        obj.numeroSiren = "789456123"
        'obj.numeroNational = "E001002" 'Pas de numéro national pour le second Pulvé
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)


        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(2, oResult.nClientimport)
        Assert.AreEqual(1, oResult.nPulveimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitapres, nExploitAvant + 2)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveApres, nPulveAvant + 1)

    End Sub

    <TestMethod()>
    Public Sub TST_Import2Pulve1Client()

        Dim obj As importCRODIP
        Dim olstin = New List(Of importCRODIP)

        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001001"
        olstin.Add(obj)
        obj = New importCRODIP()
        obj.nomExploitant = "TEST1"
        obj.numeroSiren = "1235467"
        obj.numeroNational = "E001002"
        olstin.Add(obj)

        Dim sw As New StreamWriter("./TEST.CSV")
        Using csv As New CsvWriter(sw, Globalization.CultureInfo.CurrentCulture)
            csv.WriteRecords(olstin)


        End Using
        Dim nExploitAvant = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Dim nPulveAvant = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count

        Dim oResult As importCRODIP.ImportCrodipResult
        oResult = importCRODIP.import("./TEST.CSV", m_oAgent)

        Assert.AreEqual(1, oResult.nClientimport)
        Assert.AreEqual(2, oResult.nPulveimport)
        Dim nExploitapres = ExploitationManager.getListeExploitation(m_oAgent, Now).Count
        Assert.AreEqual(nExploitapres, nExploitAvant + 1)

        Dim nPulveApres = PulverisateurManager.getPulverisateurList(m_oAgent, "").Count
        Assert.AreEqual(nPulveApres, nPulveAvant + 2)

    End Sub

End Class
