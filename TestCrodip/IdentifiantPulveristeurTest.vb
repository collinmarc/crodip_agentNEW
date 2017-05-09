Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent
<TestClass()> Public Class IdentifiantPulveristeurTest
    Inherits CRODIPTest
    <TestMethod()> Public Sub TestObject()

        Dim obj As New IdentifiantPulverisateur
        obj.id = 1
        obj.idStructure = 2
        obj.numeroNational = "2-123-001"
        obj.etat = "INUTILISE"
        obj.dateUtilisation = CSDate.ToCRODIPString("1964/02/06")
        obj.libelle = "libre"

        Assert.AreEqual(obj.id, 1L)
        Assert.AreEqual(obj.idStructure, 2L)
        Assert.AreEqual(obj.numeroNational, "2-123-001")
        Assert.AreEqual(obj.etat, "INUTILISE")
        Assert.AreEqual(obj.dateUtilisation, CSDate.ToCRODIPString("1964/02/06", "yyyy-MM-dd"))
        Assert.AreEqual(obj.libelle, "libre")

        obj.SetEtatUTILISE()
        Assert.AreEqual(obj.etat, "UTILISE")
        obj.SetEtatINUTILISE()
        Assert.AreEqual(obj.etat, "INUTILISE")
        obj.SetEtatINUTILISABLE()
        Assert.AreEqual(obj.etat, "INUTILISABLE")

    End Sub

    <TestMethod()> Public Sub TestDB()

        Dim obj As New IdentifiantPulverisateur
        obj.id = 1
        obj.idStructure = 2
        obj.numeroNational = "2-123-001"
        obj.etat = "INUTILISE"
        obj.dateUtilisation = CSDate.ToCRODIPString("06/02/1964").ToString
        obj.libelle = "libre"


        If IdentifiantPulverisateurManager.exists(obj.id) Then
            IdentifiantPulverisateurManager.Delete(obj)
        End If
        Assert.IsFalse(IdentifiantPulverisateurManager.exists(obj.id))
        Assert.IsTrue(IdentifiantPulverisateurManager.save(obj))
        Assert.IsTrue(IdentifiantPulverisateurManager.exists(obj.id))
        obj = New IdentifiantPulverisateur
        obj = IdentifiantPulverisateurManager.Load(1)
        Assert.AreEqual(obj.id, 1L)
        Assert.AreEqual(obj.idStructure, 2L)
        Assert.AreEqual(obj.numeroNational, "2-123-001")
        Assert.AreEqual(obj.etat, "INUTILISE")
        Assert.AreEqual(obj.dateUtilisation, CSDate.ToCRODIPString("1964/02/06", "yyyy-MM-dd"))
        Assert.AreEqual(obj.libelle, "libre")



        obj.numeroNational = "2-124-002"
        obj.etat = "UTILISE"
        obj.dateUtilisation = CSDate.ToCRODIPString("06/02/1965").ToString
        obj.libelle = "PasLibre"

        Assert.IsTrue(IdentifiantPulverisateurManager.save(obj))
        Assert.IsTrue(IdentifiantPulverisateurManager.exists(obj.id))

        obj = New IdentifiantPulverisateur
        obj = IdentifiantPulverisateurManager.Load(1)
        Assert.AreEqual(obj.id, 1L)
        Assert.AreEqual(obj.idStructure, 2L)
        Assert.AreEqual(obj.numeroNational, "2-124-002")
        Assert.AreEqual(obj.etat, "UTILISE")
        Assert.AreEqual(obj.dateUtilisation, CSDate.ToCRODIPString("1965/02/06", "yyyy-MM-dd"))
        Assert.AreEqual(obj.libelle, "PasLibre")

    End Sub
    <TestMethod()> Public Sub TestWS()
        Dim obj As IdentifiantPulverisateur
        'Les identifiants pulvé sont créés sur le serveur et récupéré par WS
        'Mise à jour sur l'Agent puis renvoyés au Serveur
        m_oAgent.idStructure = 2
        m_oAgent.id = 1110

        obj = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(m_oAgent, 3)
        IdentifiantPulverisateurManager.Save(obj) 'C'est la synchro descendate qui fera le save
        Assert.IsTrue(IdentifiantPulverisateurManager.exists(3))


        obj = IdentifiantPulverisateurManager.Load(3)
        Assert.AreEqual(obj.id, 3L)
        Assert.AreEqual(obj.idStructure, 2L)
        Assert.AreEqual(obj.numeroNational, "E001900001")
        '        Assert.IsTrue(obj.isEtatUTILISE)
        'Assert.AreEqual(obj.dateUtilisation, CSDate.ToCRODIPString("2016/05/02"))
        'Assert.AreEqual(obj.libelle, "")


        'Mise à jour par l'agent
        pause(2000)
        obj.SetEtatINUTILISABLE()
        obj.libelle = "MAJ par l'agent"
        Assert.IsTrue(IdentifiantPulverisateurManager.Save(obj))
        obj = IdentifiantPulverisateurManager.Load(3)
        Assert.IsTrue(obj.isEtatINUTILISABLE)
        Assert.AreEqual(obj.libelle, "MAJ par l'agent")

        'Récupération du nombre d'identifiant Pulvé mise à jour
        m_oAgent.idStructure = 2
        Dim tabIdentPulve As IdentifiantPulverisateur()
        tabIdentPulve = IdentifiantPulverisateurManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, tabIdentPulve.Length)
        obj = tabIdentPulve(0)
        Assert.AreEqual(obj.id, 3L)
        Assert.AreEqual(obj.idStructure, 2L)
        Assert.AreEqual(obj.numeroNational, "E001900001")
        Assert.IsTrue(obj.isEtatINUTILISABLE)
        Assert.AreEqual(obj.libelle, "MAJ par l'agent")

        'Envoi par WS
        IdentifiantPulverisateurManager.sendWSIdentifiantPulverisateur(m_oAgent, obj)
        IdentifiantPulverisateurManager.setSynchro(obj)

        'Vérification que par lr GetUpdates on ne récupére plus rien
        tabIdentPulve = IdentifiantPulverisateurManager.getUpdates(m_oAgent)
        Assert.AreEqual(0, tabIdentPulve.Length)

        'Récupération de l'élément pas le WS (Synchro descendante)
        obj.isEtatINUTILISE()
        IdentifiantPulverisateurManager.Save(obj)
        obj = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(m_oAgent, 3)
        IdentifiantPulverisateurManager.Save(obj, True)

        'Vérification de l'objet récupéré
        obj = IdentifiantPulverisateurManager.Load(3L)
        Assert.AreEqual(obj.id, 3L)
        Assert.AreEqual(obj.idStructure, 2L)
        Assert.AreEqual(obj.numeroNational, "E001900001")
        'Pour le moment le WS n'est pas à jour et renvoie toujour UTILISE et Identifiant de pulvé de test
        Assert.IsTrue(obj.isEtatINUTILISABLE)
        Assert.AreEqual(obj.libelle, "MAJ par l'agent")

        'Vérification que par lr GetUpdates on ne récupére plus rien
        tabIdentPulve = IdentifiantPulverisateurManager.getUpdates(m_oAgent)
        Assert.AreEqual(0, tabIdentPulve.Length)

    End Sub
    <TestMethod()> Public Sub TestUtilisationIdentifiant()

        Dim obj As IdentifiantPulverisateur
        'Création de 3 Identifiant Pulvé
        obj = New IdentifiantPulverisateur
        obj.id = 1
        obj.idStructure = m_oAgent.idStructure
        obj.numeroNational = "E001000001"
        obj.SetEtatINUTILISE()
        obj.dateUtilisation = ""
        obj.libelle = ""
        IdentifiantPulverisateurManager.Save(obj, True)

        obj = New IdentifiantPulverisateur
        obj.id = 2
        obj.idStructure = m_oAgent.idStructure
        obj.numeroNational = "E001000002"
        obj.SetEtatINUTILISE()
        obj.dateUtilisation = ""
        obj.libelle = ""
        IdentifiantPulverisateurManager.Save(obj, True)

        obj = New IdentifiantPulverisateur
        obj.id = 3
        obj.idStructure = m_oAgent.idStructure
        obj.numeroNational = "E001000003"
        obj.SetEtatINUTILISE()
        obj.dateUtilisation = ""
        obj.libelle = ""
        IdentifiantPulverisateurManager.Save(obj, True)

        'Chargement des Identiiants inutilisé
        Dim olst As List(Of IdentifiantPulverisateur)
        olst = IdentifiantPulverisateurManager.getListeInutilise(m_oAgent.idStructure)
        Assert.AreEqual(3, olst.Count)

        'Utilisation du numéro national E001002
        IdentifiantPulverisateurManager.setIdentifiantPulveUtilise(m_oAgent, "E001000002")

        'Vérification du Status
        obj = IdentifiantPulverisateurManager.Load(2)
        Assert.IsTrue(obj.isEtatUTILISE)
        Assert.AreEqual(CSDate.ToCRODIPString(Date.Now, "yyyy-MM-dd"), obj.dateUtilisation)

        'Vérification de la liste des numéros inutilisé
        olst = IdentifiantPulverisateurManager.getListeInutilise(m_oAgent.idStructure)
        Assert.AreEqual(2, olst.Count)

        For Each obj In olst
            Assert.AreNotEqual("E001000002", obj.numeroNational)
        Next

    End Sub

    <TestMethod()> Public Sub TestSynchro()

        m_oAgent.idStructure = 2
        m_oAgent.numeroNational = "MAR"
        m_oAgent.id = 1110
        Dim oSynchroBooleans As New SynchroBooleans
        Dim olst As List(Of SynchronisationElmt)
        Dim bElemtExists As Boolean = False
        olst = SynchronisationManager.getWSlstElementsASynchroniser(m_oAgent, oSynchroBooleans)
        For Each oElmt As SynchronisationElmt In olst
            If oElmt.type = "GetIdentifiantPulverisateur" Then
                bElemtExists = True
                Assert.IsTrue(oElmt.SynchroDesc(m_oAgent))
            End If
        Next
        Assert.IsTrue(bElemtExists)

        Dim olstIdent As List(Of IdentifiantPulverisateur)
        olstIdent = IdentifiantPulverisateurManager.getListe(m_oAgent.idStructure)
        Assert.AreNotEqual(0, olstIdent.Count())
        olstIdent(0).SetEtatINUTILISABLE()
        IdentifiantPulverisateurManager.Save(olstIdent(0))

        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.runAscSynchro()




    End Sub

End Class