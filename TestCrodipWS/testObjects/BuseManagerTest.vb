Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CRODIPWS



'''<summary>
'''Classe de test pour BuseManagerTest, destinée à contenir tous
'''les tests unitaires FVBuseManagerTest
'''</summary>
<TestClass()> _
Public Class BuseManagerTest
    Inherits CRODIPTest


    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod()> _
    Public Sub ObjetTest()
        Dim objBuse As Buse = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objBuse2 As Buse
        objBuse = New Buse()
        objBuse.idCrodip = "MonBuse"
        objBuse.idStructure = m_oAgent.idStructure
        objBuse.couleur = "Bleue"
        objBuse.numeroNational = "001"
        objBuse.etat = True
        objBuse.isSupprime = True
        objBuse.debitEtalonnage = 15.5
        objBuse.pressionEtalonnage = 16.5
        objBuse.AgentSuppression = m_oAgent.nom
        objBuse.RaisonSuppression = "MaRaison"
        objBuse.DateSuppression = "06/02/1964"

        Assert.AreEqual(objBuse.idCrodip, "MonBuse")
        Assert.AreEqual(objBuse.idStructure, m_oAgent.idStructure)
        Assert.AreEqual(objBuse.couleur, "Bleue")
        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)
        Assert.AreEqual(objBuse.numeroNational, "001")
        Assert.AreEqual(objBuse.etat, True)
        Assert.IsTrue(objBuse.isSupprime)
        Assert.AreEqual(objBuse.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBuse.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objBuse.dateSuppression), CDate("06/02/1964"))

        Assert.IsTrue(BuseManager.save(objBuse))

        objBuse2 = BuseManager.getBuseByNumeroNational("001")
        Assert.AreEqual("001", objBuse2.numeroNational)

        Assert.AreEqual(objBuse2.idCrodip, "MonBuse")
        Assert.AreEqual(objBuse2.idStructure, m_oAgent.idStructure)
        Assert.AreEqual(objBuse2.couleur, "Bleue")
        Assert.AreEqual(objBuse2.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse2.pressionEtalonnage, 16.5)
        Assert.AreEqual(objBuse2.numeroNational, "001")
        Assert.AreEqual(objBuse2.etat, True)
        Assert.IsTrue(objBuse2.isSupprime)
        Assert.AreEqual(objBuse2.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBuse2.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objBuse2.dateSuppression), CDate("06/02/1964"))

        'Mise à jour du Buse
        objBuse2.isSupprime = False
        objBuse2.AgentSuppression = "MonAgentSuppression"
        objBuse2.RaisonSuppression = "MaRaison2"
        objBuse2.DateSuppression = CDate("06/02/1965").ToShortDateString()

        Assert.IsTrue(BuseManager.save(objBuse2))

        'Rehcragement du Buse pour vérifier l'update
        objBuse = BuseManager.getBuseByNumeroNational("001")

        Assert.AreEqual(objBuse.isSupprime, 0)
        Assert.AreEqual(objBuse.AgentSuppression, "MonAgentSuppression")
        Assert.AreEqual(objBuse.RaisonSuppression, "MaRaison2")
        Assert.AreEqual(CDate(objBuse.dateSuppression), CDate("06/02/1965"))
        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)

        'Suppression du Buse en base de donnée
        BuseManager.delete(objBuse.numeroNational)
        objBuse2 = BuseManager.getBuseByNumeroNational("001")
        Assert.AreNotEqual("001", objBuse2.numeroNational)

    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub Get_Send_WS_Test()
        Dim oBuse As Buse
        Dim oBuse2 As Buse
        Dim bReturn As Boolean
        Dim idBuse As String

        'Creation d'un Buse
        oBuse = New Buse()
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        oBuse.numeroNational = idBuse
        oBuse.idStructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        oBuse.couleur = "Bleue"
        oBuse.debitEtalonnage = 15.5
        oBuse.pressionEtalonnage = 16.5
        oBuse.AgentSuppression = m_oAgent.nom
        oBuse.RaisonSuppression = "MaRaison"
        oBuse.dateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oBuse.AgentSuppression = m_oAgent.nom
        oBuse.RaisonSuppression = "MaRaison"
        Assert.IsTrue(BuseManager.save(oBuse))
        Dim oReturn As Buse
        Dim response As Integer = BuseManager.WSSend(oBuse, oReturn)
        Assert.IsTrue(response = 0 Or response = 2 Or response = 4)

        oBuse2 = BuseManager.WSgetById(oBuse.uid, oBuse.numeroNational)
        Assert.AreEqual(oBuse.numeroNational, oBuse2.numeroNational)
        Assert.AreEqual(oBuse2.isSupprime, 0)
        Assert.AreEqual(oBuse2.etat, oBuse.etat)
        Assert.AreEqual(oBuse2.dateAchat, oBuse.dateAchat)
        Assert.AreEqual(oBuse2.couleur, oBuse.couleur)
        Assert.AreEqual(oBuse2.debitEtalonnage, oBuse.debitEtalonnage)
        Assert.AreEqual(oBuse2.debitEtalonnage, oBuse.debitEtalonnage)
        Assert.AreEqual(oBuse2.agentSuppression, oBuse.agentSuppression)
        Assert.AreEqual(oBuse2.raisonSuppression, oBuse.raisonSuppression)
        Assert.AreEqual(oBuse2.dateSuppression, oBuse.dateSuppression)

        bReturn = BuseManager.delete(idBuse)
        Assert.IsTrue(bReturn)

    End Sub

    'test l'echange par WS
    <TestMethod(), Ignore()>
    Public Sub DateDesuppressionTest()
        Dim oBuse As Buse
        Dim oBuse2 As Buse
        Dim bReturn As Boolean
        Dim idBuse As String

        'Creation d'un Buse
        oBuse = New Buse()
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        oBuse.numeroNational = idBuse
        oBuse.idstructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        oBuse.couleur = "Bleue"
        oBuse.debitEtalonnage = 15.5
        oBuse.pressionEtalonnage = 16.5
        Assert.IsTrue(BuseManager.save(oBuse))

        oBuse = BuseManager.getBuseByNumeroNational(oBuse.numeroNational)
        Assert.AreEqual("1899-12-30 00:00:00", oBuse.dateSuppression)
        Dim oReturn As Buse
        Dim response As Integer = BuseManager.WSSend(oBuse, oReturn)
        Assert.IsTrue(response = 0 Or response = 2)

        oBuse2 = BuseManager.WSgetById(oBuse.uid, oBuse.numeroNational)
        Assert.AreEqual(oBuse.numeroNational, oBuse2.numeroNational)
        Assert.AreEqual(oBuse2.isSupprime, 0)
        Assert.AreEqual(oBuse2.dateSuppression, oBuse.dateSuppression)


    End Sub
    <TestMethod()>
    Public Sub DeleteMaterielTest()
        Dim objBuse As Buse
        Dim objBuse2 As Buse
        Dim bReturn As Boolean
        Dim idBuse As String

        'Creation d'un Buse
        objBuse = New Buse()
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        objBuse.idCrodip = "MonBuse"
        objBuse.idstructure = m_oAgent.idStructure
        objBuse.couleur = "Bleue"
        objBuse.debitEtalonnage = 15.5
        objBuse.numeroNational = "001"
        objBuse.etat = True
        objBuse.pressionEtalonnage = 16.5
        Assert.IsTrue(BuseManager.save(objBuse))

        objBuse2 = BuseManager.getBuseByNumeroNational("001")
        objBuse2.DeleteMateriel(m_oAgent, "MaRaison")

        objBuse = BuseManager.getBuseByNumeroNational("001")
        Assert.IsTrue(objBuse.isSupprime, 1)
        Assert.AreEqual(objBuse.agentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBuse.raisonSuppression, "MaRaison")
        Assert.IsNotNull(objBuse.dateSuppression)




    End Sub

    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod()>
    Public Sub SymboleDecimalTest()
        Dim objBuse As Buse = Nothing
        Dim expected As Object = Nothing
        Dim objBuse2 As Buse

        objBuse = New Buse()
        objBuse.idCrodip = "MonBuse"
        objBuse.idstructure = m_oAgent.idStructure
        objBuse.numeroNational = "001"
        objBuse.etat = True
        objBuse.debitEtalonnage = 15.5
        objBuse.pressionEtalonnage = 16.5

        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)

        Assert.IsTrue(BuseManager.save(objBuse))

        objBuse2 = BuseManager.getBuseByNumeroNational("001")
        Assert.AreEqual("001", objBuse2.numeroNational)

        Assert.AreEqual(objBuse2.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse2.pressionEtalonnage, 16.5)

        'Modification de la buse en utilisant Stringtodouble
        Assert.AreEqual(objBuse.debitEtalonnage, GlobalsCRODIP.StringToDouble("15.5"))
        Assert.AreEqual(objBuse.pressionEtalonnage, GlobalsCRODIP.StringToDouble("16.5"))
        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)

        Assert.AreEqual(objBuse.debitEtalonnage, GlobalsCRODIP.StringToDouble("15,5"))
        Assert.AreEqual(objBuse.pressionEtalonnage, GlobalsCRODIP.StringToDouble("16,5"))
        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)
        Dim oReturn As Buse
        BuseManager.WSSend(objBuse, oReturn)

        objBuse2 = BuseManager.WSgetById(objBuse.uid, objBuse.numeroNational)
        Assert.AreEqual(objBuse2.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse2.pressionEtalonnage, 16.5)


        'Suppression du Buse en base de donnée
        BuseManager.delete(objBuse.numeroNational)
        objBuse2 = BuseManager.getBuseByNumeroNational("001")
        Assert.AreNotEqual("001", objBuse2.numeroNational)

    End Sub

    '===============================
    'test des nlle Propriétés Matériels (JamaisServis, DateActivation)
    <TestMethod()>
    Public Sub JamaisServiTest()
        Dim oBuse As Buse
        Dim idBuse As String
        Dim oBuse2 As Buse

        'Creation d'un Buse
        oBuse = New Buse()
        Assert.IsFalse(oBuse.jamaisServi)
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        'oBuse.numeroNational = idBuse
        oBuse.idCrodip = idBuse
        oBuse.numeroNational = idBuse
        oBuse.idstructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))

        Assert.IsTrue(BuseManager.save(oBuse))
        oBuse2 = BuseManager.getBuseByNumeroNational(idBuse)

        Assert.AreEqual(oBuse.jamaisServi, oBuse2.jamaisServi)
        Assert.AreEqual(oBuse.DateActivation, oBuse2.DateActivation)
        Assert.AreEqual(oBuse.DateActivationS, oBuse2.DateActivationS)

        'Modification des propriétés
        oBuse.jamaisServi = True
        oBuse.DateActivation = CDate("06/02/1966")
        Assert.AreEqual("1966-02-06 00:00:00", oBuse.DateActivationS)
        Assert.IsTrue(BuseManager.save(oBuse))

        oBuse2 = BuseManager.getBuseByNumeroNational(idBuse)
        Assert.AreEqual(oBuse.jamaisServi, oBuse2.jamaisServi)
        Assert.AreEqual(oBuse.DateActivation, oBuse2.DateActivation)
        Assert.AreEqual(oBuse.DateActivationS, oBuse2.DateActivationS)


        BuseManager.delete(idBuse)

    End Sub 'JamaisServiTest
    <TestMethod()>
    Public Sub GetBuseByStructureTest()
        Dim oBuse As Buse
        Dim idBuse As String
        Dim tabBuse As List(Of Buse)

        'Creation d'un Buse
        oBuse = New Buse()
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        oBuse.numeroNational = idBuse
        oBuse.idCrodip = idBuse
        oBuse.idstructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))

        Assert.IsTrue(BuseManager.save(oBuse))
        tabBuse = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(1, tabBuse.Count)

        'Suppression du Buse
        oBuse.isSupprime = True
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(0, tabBuse.Count)

        'Buse Jamais Servi
        oBuse.isSupprime = False
        oBuse.jamaisServi = True
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesByAgent(m_oAgent, True)
        Assert.AreEqual(0, tabBuse.Count)
        tabBuse = BuseManager.getBusesByAgent(m_oAgent, False)
        Assert.AreEqual(0, tabBuse.Count)

        oBuse.jamaisServi = False 'Le Buse n'a pas jamaisservi => il est actif
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesByAgent(m_oAgent, True)
        Assert.AreEqual(1, tabBuse.Count)
        tabBuse = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(1, tabBuse.Count)

        oBuse.etat = False 'Buse non controlé
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesByAgent(m_oAgent, True)
        Assert.AreEqual(1, tabBuse.Count)
        tabBuse = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(0, tabBuse.Count)


    End Sub
    <TestMethod()>
    Public Sub GetBuseJamaisServi()
        Dim oBuse As Buse
        Dim idBuse As String

        'Creation d'un Buse
        oBuse = New Buse()
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        oBuse.idCrodip = idBuse
        oBuse.numeroNational = idBuse
        oBuse.idstructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        BuseManager.save(oBuse)

        'Vérification que le Buse n'est pas dans les liste des jamais servi
        Assert.AreEqual(0, BuseManager.getBusesEtalonByStructureIdJamaisServi(m_oAgent.idStructure.ToString).Count)

        oBuse.jamaisServi = True
        BuseManager.save(oBuse)
        'Vérification que le Buse est dans la liste des jamais servi
        Assert.AreEqual(1, BuseManager.getBusesEtalonByStructureIdJamaisServi(m_oAgent.idStructure.ToString).Count)

        oBuse.jamaisServi = False
        BuseManager.save(oBuse)
        'Vérification que le Buse n'est plus dans la liste des jamais servi
        Assert.AreEqual(0, BuseManager.getBusesEtalonByStructureIdJamaisServi(m_oAgent.idStructure.ToString).Count)

        BuseManager.delete(idBuse)
    End Sub

    ''' <summary>
    ''' Test de l'activation d'un Buse (JamaisServi true->false, dateActivation, dateDernControle, FicheVie)
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ActiverBuseTest()
        Dim oBuse As Buse
        Dim idBuse As String

        'Creation d'un Buse
        oBuse = New Buse()
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        oBuse.numeroNational = idBuse
        oBuse.idCrodip = idBuse
        oBuse.idstructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = False
        oBuse.jamaisServi = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        BuseManager.save(oBuse)


        Assert.IsTrue(oBuse.ActiverMateriel(CDate("01/02/1987"), m_oAgent))

        'JAmaisServi True -> False
        Assert.IsFalse(oBuse.jamaisServi)
        'Etat True 
        Assert.IsTrue(oBuse.etat)

        Assert.AreEqual(CDate("01/02/1987"), oBuse.DateActivation)
        '        Assert.AreEqual(CDate("01/02/1987"), CDate(oBuse.dateDernierControleS))


        BuseManager.delete(idBuse)
    End Sub
    <TestMethod()>
    Public Sub getAlertesBuses_Test()
        'Generation du fichier de paramétrage
        Dim oAlertes As New Alertes
        Dim oNiveau As NiveauAlerte
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Banc
        oNiveau.Noire = 47
        oNiveau.Rouge = 20
        oNiveau.Orange = 10
        oNiveau.Jaune = 5
        oNiveau.EcartTolere = 0
        oAlertes.NiveauxAlertes.Add(oNiveau)
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.ManometreControle
        oNiveau.Noire = 147
        oNiveau.Rouge = 120
        oNiveau.Orange = 110
        oNiveau.Jaune = 15
        oNiveau.EcartTolere = 17.5D
        oAlertes.NiveauxAlertes.Add(oNiveau)
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Buse
        oNiveau.Noire = 36
        oNiveau.Rouge = 30
        oNiveau.Orange = 0
        oNiveau.Jaune = 0
        oNiveau.EcartTolere = 0
        oAlertes.NiveauxAlertes.Add(oNiveau)

        Assert.IsTrue(Alertes.FTO_writeXml(oAlertes))


        Dim oBuse As Buse
        oBuse = New Buse
        oBuse.dateAchat = Now.ToShortDateString()
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.NONE, oBuse.getAlerte())

        oBuse.dateAchat = DateAdd(DateInterval.DayOfYear, -37, Now).ToString()
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.NOIRE, oBuse.getAlerte())

        oBuse.dateAchat = DateAdd(DateInterval.DayOfYear, -31, Now).ToShortDateString()
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.ROUGE, oBuse.getAlerte())


        oBuse.dateAchat = DateAdd(DateInterval.DayOfYear, -29, Now).ToShortDateString()
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.NONE, oBuse.getAlerte())

    End Sub
    <TestMethod(), Ignore("Pool")>
    Public Sub GetByPoolTest()
        Dim oBuse As Buse
        Dim idMano As String

        'Creation d'un Pool
        Dim oPool = New Pool()
        oPool.idCrodip = "P1"
        oPool.libelle = "LIbP1"
        PoolManager.Save(oPool)

        Dim oPool2 = New Pool()
        oPool2.idCrodip = "P2"
        oPool2.libelle = "LIbP2"
        PoolManager.Save(oPool2)

        m_oAgent.idCRODIPPool = oPool.idCrodip
        AgentManager.save(m_oAgent)

        'Creation d'un Mano
        oBuse = New Buse()
        idMano = "M1E"
        oBuse.numeroNational = idMano
        oBuse.idCrodip = idMano
        oBuse.idStructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.JamaisServi = False
        oBuse.lstPools.Add(oPool)
        BuseManager.save(oBuse)

        Dim lst As List(Of Buse)
        lst = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(1, lst.Count)

        'Si l'agent utilise le Pool2 , il ne voit pas le Mano
        m_oAgent.idCRODIPPool = oPool2.idCrodip
        AgentManager.save(m_oAgent)

        lst = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(0, lst.Count)

        'Ajout du Pool2 dans le Mano
        oBuse.lstPools.Add(oPool2)
        BuseManager.save(oBuse)
        'Le Mano est bien chargé
        lst = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(1, lst.Count)
        'il appartient Bien aux 2 pool
        Assert.AreEqual(2, lst(0).lstPools.Count)
        'et on le retrouve bien sur le pool1
        m_oAgent.idCRODIPPool = oPool.idCrodip
        AgentManager.save(m_oAgent)

        lst = BuseManager.getBusesByAgent(m_oAgent)
        Assert.AreEqual(1, lst.Count)


    End Sub

End Class
