﻿Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CRODIPWS




'''<summary>
'''Classe de test pour FVBancManagerTest, destinée à contenir tous
'''les tests unitaires FVBancManagerTest
'''</summary>
<TestClass()> _
Public Class BancManagerTest
    Inherits CRODIPTest


    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod()> _
    Public Sub BancObjectDBTest()
        Dim objBanc As Banc = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objBanc2 As Banc
        objBanc = New Banc()
        objBanc.id = "MonBanc"
        objBanc.uidstructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.DateSuppression = "06/02/1964"
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15
        objBanc.ModuleAcquisition = "MD2"

        Assert.AreEqual(objBanc.isSupprime, -1)
        Assert.AreEqual(objBanc.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBanc.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objBanc.DateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objBanc.nbControles, 5)
        Assert.AreEqual(objBanc.nbControlesTotal, 15)
        Assert.AreEqual("MD2", objBanc.ModuleAcquisition)

        Assert.IsTrue(BancManager.save(objBanc))

        objBanc2 = BancManager.getBancById("MonBanc")
        Assert.AreEqual("MonBanc", objBanc2.id)

        Assert.AreEqual(objBanc2.isSupprime, -1)
        Assert.AreEqual(objBanc2.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBanc2.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objBanc2.DateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objBanc2.nbControles, 5)
        Assert.AreEqual(objBanc2.nbControlesTotal, 15)
        Assert.AreEqual("MD2", objBanc2.ModuleAcquisition)

        'Mise à jour du banc
        objBanc2.isSupprime = False
        objBanc2.AgentSuppression = "MonAgentSuppression"
        objBanc2.RaisonSuppression = "MaRaison2"
        objBanc2.DateSuppression = CDate("06/02/1965").ToShortDateString()
        objBanc2.nbControles = 6
        objBanc2.nbControlesTotal = 16
        objBanc2.ModuleAcquisition = "ITEQ"

        Assert.IsTrue(BancManager.save(objBanc2))

        'Rehcragement du banc pour vérifier l'update
        objBanc = BancManager.getBancById("MonBanc")

        Assert.AreEqual(objBanc.isSupprime, 0)
        Assert.AreEqual(objBanc.AgentSuppression, "MonAgentSuppression")
        Assert.AreEqual(objBanc.RaisonSuppression, "MaRaison2")
        Assert.AreEqual(CDate(objBanc.DateSuppression), CDate("06/02/1965"))
        Assert.AreEqual(objBanc.nbControles, 6)
        Assert.AreEqual(objBanc.nbControlesTotal, 16)
        Assert.AreEqual("ITEQ", objBanc.ModuleAcquisition)

        'Suppression du banc en base de donnée
        BancManager.delete(objBanc.id)
        objBanc2 = BancManager.getBancById("MonBanc")
        Assert.AreNotEqual("MonBanc", objBanc2.id)

    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub Get_Send_WS_BancDateDernControle()
        Dim oBanc As Banc
        Dim oBanc2 As Banc
        Dim idBanc As String
        'agentCourant = m_oAgent
        'Creation d'un Banc
        oBanc = m_oBanc
        idBanc = m_oBanc.id

        oBanc.dateDernierControle = CDate("06-02-1966")
        BancManager.save(oBanc)
        Dim oreturn As Banc
        Dim response As Integer = BancManager.WSSend(oBanc, oreturn)
        Assert.IsTrue(response = 0 Or response = 2)
        oBanc2 = BancManager.WSgetById(oBanc.uid, oBanc.id)
        Assert.AreEqual(oBanc2.dateDernierControle, oBanc.dateDernierControle)

    End Sub
    <TestMethod()>
    Public Sub DeleteMaterielTest()
        Dim oBanc As Banc
        Dim oBanc2 As Banc
        Dim bReturn As Boolean
        Dim idBanc As String

        'Creation d'un Banc
        oBanc = m_oBanc
        idBanc = m_oBanc.id
        oBanc.isSupprime = False
        oBanc.marque = "MaMarque"
        oBanc.modele = "Modele"
        oBanc.etat = True
        oBanc.dateAchat = CDate("02/06/1965").ToString()
        oBanc.nbControles = 5
        oBanc.nbControlesTotal = 15
        oBanc.isUtilise = False   'Le Banc n'est pas utilisé 

        Assert.IsTrue(BancManager.save(oBanc))

        oBanc2 = BancManager.getBancById(idBanc)
        Assert.IsFalse(oBanc2.isUtilise)
        oBanc2.DeleteMateriel(m_oAgent, "MaRaison")

        oBanc = BancManager.getBancById(idBanc)
        Assert.AreEqual(oBanc.isSupprime, -1)
        Assert.AreEqual(oBanc.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(oBanc.RaisonSuppression, "MaRaison")
        Assert.IsNotNull(oBanc.DateSuppression)



        bReturn = BancManager.delete(idBanc)
        Assert.IsTrue(bReturn)

    End Sub

    'test l'echange par WS
    <TestMethod()>
    Public Sub DateDesuppressionTest()
        Dim oBanc As Banc
        Dim oBanc2 As Banc
        Dim bReturn As Boolean
        Dim idBanc As String

        'Creation d'un Banc
        oBanc = m_oBanc
        idBanc = m_oBanc.id
        oBanc.isSupprime = False
        oBanc.etat = True
        oBanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        oBanc.DateSuppression = ""
        Assert.IsTrue(BancManager.save(oBanc))

        oBanc = BancManager.getBancById(oBanc.id)
        Assert.AreEqual("", oBanc.DateSuppression)
        Dim oReturn As Banc
        Dim response As Integer = BancManager.WSSend(oBanc, oReturn)
        Assert.IsTrue(response = 0 Or response = 2)

        oBanc2 = BancManager.WSgetById(oBanc.uid, oBanc.aid)
        Assert.AreEqual(oBanc.aid, oBanc2.aid)
        Assert.AreEqual(oBanc2.isSupprime, 0)
        Assert.AreEqual(oBanc2.dateSuppression, oBanc.dateSuppression)

        bReturn = BancManager.delete(idBanc)
        Assert.IsTrue(bReturn)

    End Sub

    'test des nlle Propriétés Matériels (JamaisServis, DateActivation)
    <TestMethod()>
    Public Sub JamaisServiTest()
        Dim obanc As Banc
        Dim idBanc As String
        Dim obanc2 As Banc

        'Creation d'un Banc
        obanc = m_oBanc
        idBanc = m_oBanc.id
        obanc.isSupprime = False
        obanc.etat = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))

        Assert.IsTrue(BancManager.save(obanc))
        obanc2 = BancManager.getBancById(idBanc)

        Assert.AreEqual(obanc.jamaisServi, obanc2.jamaisServi)
        Assert.AreEqual(obanc.DateActivation, obanc2.DateActivation)
        Assert.AreEqual(obanc.DateActivationS, obanc2.DateActivationS)

        'Modification des propriétés
        obanc.jamaisServi = True
        obanc.DateActivation = CDate("06/02/1966")
        Assert.AreEqual("1966-02-06 00:00:00", obanc.DateActivationS)
        Assert.IsTrue(BancManager.save(obanc))

        obanc2 = BancManager.getBancById(idBanc)
        Assert.AreEqual(obanc.jamaisServi, obanc2.jamaisServi)
        Assert.AreEqual(obanc.DateActivation, obanc2.DateActivation)
        Assert.AreEqual(obanc.DateActivationS, obanc2.DateActivationS)


        BancManager.delete(idBanc)

    End Sub 'JamaisServiTest
    <TestMethod()>
    Public Sub GetBancByStructureTest()
        Dim obanc As Banc
        Dim idBanc As String
        Dim tabBanc As List(Of Banc)

        'Creation d'un Pool
        Dim oPool = New Pool()
        oPool.idCrodip = "P1"
        oPool.libelle = "LIbP1"
        PoolManager.Save(oPool)

        Dim oPool2 = New Pool()
        oPool2.idCrodip = "P2"
        oPool2.libelle = "LIbP2"
        PoolManager.Save(oPool2)

        'm_oAgent.idCRODIPPool = oPool.idCrodip
        AgentManager.save(m_oAgent)


        'Suppression de tous les bancs
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure, True)
        For Each obanc In tabBanc
            BancManager.delete(obanc.id)
        Next
        'Creation d'un Banc
        obanc = m_oBanc
        idBanc = m_oBanc.id
        obanc.isSupprime = False
        obanc.etat = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        obanc.jamaisServi = False

        Assert.IsTrue(BancManager.save(obanc))
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(1, tabBanc.Count)

        'Suppression du banc
        obanc.isSupprime = True
        BancManager.save(obanc)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(0, tabBanc.Count)

        'banc Jamais Servi
        obanc.isSupprime = False
        obanc.jamaisServi = True
        BancManager.save(obanc)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure, True)
        Assert.AreEqual(0, tabBanc.Count)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure, False)
        Assert.AreEqual(0, tabBanc.Count)

        obanc.jamaisServi = False 'Le Banc n'a pas jamaisservi => il est actif
        BancManager.save(obanc)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure, True)
        Assert.AreEqual(1, tabBanc.Count)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(1, tabBanc.Count)

        obanc.etat = False 'Banc non controlé
        BancManager.save(obanc)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure, True)
        Assert.AreEqual(1, tabBanc.Count)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(0, tabBanc.Count)


    End Sub
    <TestMethod()>
    Public Sub GetBancJamaisServi()
        Dim obanc As Banc
        Dim idBanc As String
        'Suppression de tous les bancs

        CSDb.ExecuteSQL("DELETE FROM BancMesure where idStructure=" & m_oAgent.idStructure)
        'Creation d'un Banc
        obanc = m_oBanc
        idBanc = m_oBanc.id
        obanc.isSupprime = False
        obanc.etat = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        obanc.jamaisServi = True
        BancManager.save(obanc)

        'Vérification que le banc n'est pas dans les liste des jamais servi
        Assert.AreEqual(1, BancManager.getBancByStructureIdJamaisServi(m_oAgent.idStructure).Count)

        obanc.jamaisServi = True
        BancManager.save(obanc)
        'Vérification que le banc est dans la liste des jamais servi
        Assert.AreEqual(1, BancManager.getBancByStructureIdJamaisServi(m_oAgent.idStructure.ToString).Count)

        obanc.jamaisServi = False
        BancManager.save(obanc)
        'Vérification que le banc n'est plus dans la liste des jamais servi
        Assert.AreEqual(0, BancManager.getBancByStructureIdJamaisServi(m_oAgent.idStructure.ToString).Count)

        BancManager.delete(idBanc)
    End Sub

    ''' <summary>
    ''' Test de l'activation d'un banc (JamaisServi true->false, dateActivation, dateDernControle, FicheVie)
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ActiverBancTest()
        Dim obanc As Banc
        Dim idBanc As String
        Dim lstFV As List(Of FVBanc)
        Dim oFVBanc As FVBanc

        'Creation d'un Banc
        obanc = m_oBanc
        idBanc = m_oBanc.id
        obanc.isSupprime = False
        obanc.etat = False
        obanc.jamaisServi = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        BancManager.save(obanc)

        lstFV = FVBancManager.getlstFVBancByBancId(idBanc)
        Assert.AreEqual(0, lstFV.Count)

        Assert.IsTrue(obanc.ActiverMateriel(CDate("01/02/1987"), m_oAgent))

        'JAmaisServi True -> False
        Assert.IsFalse(obanc.jamaisServi)
        'Etat True 
        Assert.IsTrue(obanc.etat)

        Assert.AreEqual(CDate("01/02/1987"), obanc.DateActivation)

        lstFV = FVBancManager.getlstFVBancByBancId(idBanc)
        Assert.AreEqual(1, lstFV.Count)
        oFVBanc = lstFV(0)

        Assert.AreEqual("MISEENSERVICE", oFVBanc.type)
        Assert.AreEqual(idBanc, oFVBanc.idBancMesure)
        Assert.AreEqual(m_oAgent.id, oFVBanc.idAgentControleur)


        BancManager.delete(idBanc)
    End Sub

    ''' <summary>
    ''' Test de la gestion du flag Utilisé et dateDernierControle
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub SetUtiliseTest()
        Dim obanc As Banc
        Dim idBanc As String
        Dim lstFV As List(Of FVBanc)
        Dim oFVBanc As FVBanc

        'Creation d'un Banc
        obanc = m_oBanc
        idBanc = m_oBanc.id
        obanc.isSupprime = False
        obanc.etat = True
        obanc.jamaisServi = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        obanc.isUtilise = False
        BancManager.save(obanc)

        'Pas de Fiche de vie par défaut
        lstFV = FVBancManager.getlstFVBancByBancId(idBanc)
        Assert.AreEqual(0, lstFV.Count)

        'Première utilisation
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id) 'Rechargement
        'Vérification du flag utilise
        Assert.IsTrue(obanc.isUtilise)
        'Vérification de la création de la fiche de vie
        lstFV = FVBancManager.getlstFVBancByBancId(idBanc)
        Assert.AreEqual(1, lstFV.Count)
        oFVBanc = lstFV(0)
        Assert.AreEqual(FVBanc.FVTYPE_PREMIEREUTILISATION, oFVBanc.type)
        Assert.AreEqual(idBanc, oFVBanc.idBancMesure)
        Assert.AreEqual(m_oAgent.id, oFVBanc.idAgentControleur)

        'Seconde utilisation
        obanc.setUtilise(m_oAgent)
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id) 'Rechargement
        'Vérification du flag utilise
        Assert.IsTrue(obanc.isUtilise)
        'Vérification de la non création d'une seconde fiche de vie
        lstFV = FVBancManager.getlstFVBancByBancId(idBanc)
        Assert.AreEqual(1, lstFV.Count)


        obanc.isUtilise = False
        BancManager.save(obanc)
        obanc = BancManager.getBancById(obanc.id) 'Rechargement
        'Vérification du flag utilise
        Assert.IsFalse(obanc.isUtilise)


    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub Get_Send_WS_Banc()
        Dim oBanc As Banc
        Dim oBanc2 As Banc

        'Creation d'un Banc
        oBanc = m_oBanc

        oBanc.isSupprime = False
        oBanc.marque = "MaMarque"
        oBanc.modele = "Modele"
        oBanc.etat = True
        oBanc.dateAchat = CSDate.ToCRODIPString(CDate("02/06/1965"))
        oBanc.agentSuppression = m_oAgent.nom
        oBanc.raisonSuppression = "MaRaison"
        oBanc.dateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oBanc.dateDernierControle = CDate("06/02/1964")
        oBanc.jamaisServi = True
        '        oBanc.DateActivation = CDate("06-02-1966")
        oBanc.nbControles = 7
        oBanc.nbControlesTotal = 17
        oBanc.ModuleAcquisition = "MD2"
        BancManager.save(oBanc)

        Dim oreturn As Banc
        Dim response As Integer = BancManager.WSSend(oBanc, oreturn)
        Assert.IsTrue(response = 0 Or response = 2)
        oBanc2 = BancManager.WSgetById(oBanc.uid, oBanc.id)
        Assert.AreEqual(oBanc.id, oBanc2.id)
        Assert.AreEqual(oBanc.isSupprime, oBanc2.isSupprime)
        Assert.AreEqual(oBanc2.etat, oBanc.etat)

        Assert.AreEqual(oBanc2.dateAchat, oBanc.dateAchat)
        Assert.AreEqual(oBanc2.marque, oBanc.marque)
        Assert.AreEqual(oBanc2.modele, oBanc.modele)
        Assert.AreEqual(oBanc2.RaisonSuppression, oBanc.RaisonSuppression)
        Assert.AreEqual(oBanc2.dateSuppression, oBanc.dateSuppression)
        Assert.AreEqual(oBanc2.JamaisServi, oBanc.JamaisServi)
        Assert.AreEqual(oBanc2.dateDernierControle, oBanc.dateDernierControle)
        Assert.AreEqual(oBanc2.agentSuppression, m_oAgent.nom)
        Assert.AreEqual(oBanc2.ModuleAcquisition, oBanc.ModuleAcquisition)
        'BUG ces champs ne sont pas synhcronisé ...
        '        Assert.AreEqual(oBanc2.nbControles, oBanc.nbControles)
        '       Assert.AreEqual(oBanc2.nbControlesTotal, oBanc.nbControlesTotal)
        'Assert.AreEqual(oBanc2.DateActivation, oBanc.DateActivation)

    End Sub
    ''' <summary>
    ''' Test du niveau d'alerte
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub getAlerte_banc()
        'Generation du fichier de paramétrage
        Dim oAlertes As New Alertes
        Dim oNiveau As NiveauAlerte
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.Banc
        oNiveau.Noire = 47
        oNiveau.Rouge = 20
        oNiveau.Orange = 10
        oNiveau.Jaune = 5
        oNiveau.EcartTolere = 7.5D
        oAlertes.NiveauxAlertes.Add(oNiveau)
        oNiveau = New NiveauAlerte
        oNiveau.Materiel = NiveauAlerte.Enum_typeMateriel.ManometreControle
        oNiveau.Noire = 147
        oNiveau.Rouge = 120
        oNiveau.Orange = 110
        oNiveau.Jaune = 15
        oNiveau.EcartTolere = 17.5D
        oAlertes.NiveauxAlertes.Add(oNiveau)

        Assert.IsTrue(Alertes.FTO_writeXml(oAlertes))


        Dim obanc As Banc
        obanc = m_oBanc
        obanc.dateDernierControle = Now
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.NONE, obanc.getAlerte())

        obanc.dateDernierControle = DateAdd(DateInterval.DayOfYear, -50, Now)
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.NOIRE, obanc.getAlerte())

        obanc.dateDernierControle = DateAdd(DateInterval.DayOfYear, -21, Now)
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.ROUGE, obanc.getAlerte())

        obanc.dateDernierControle = DateAdd(DateInterval.DayOfYear, -11, Now)
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.ORANGE, obanc.getAlerte())

        obanc.dateDernierControle = DateAdd(DateInterval.DayOfYear, -6, Now)
        Assert.AreEqual(CRODIPWS.GlobalsCRODIP.ALERTE.JAUNE, obanc.getAlerte())
    End Sub

    <TestMethod(), Ignore("pool")>
    Public Sub GetByPoolTest()
        Dim oBanc As Banc
        Dim idBanc As String

        'Creation d'un Pool
        Dim oPool = New Pool()
        oPool.idCrodip = "P1"
        oPool.libelle = "LIbP1"
        PoolManager.Save(oPool)

        Dim oPool2 = New Pool()
        oPool2.idCrodip = "P2"
        oPool2.libelle = "LIbP2"
        PoolManager.Save(oPool2)

        'm_oAgent.idCRODIPPool = oPool.idCrodip
        AgentManager.save(m_oAgent)

        'Creation d'un Mano
        oBanc = New Banc()
        idBanc = "M1E"
        oBanc.id = idBanc
        oBanc.idCrodip = idBanc
        oBanc.uidstructure = m_oAgent.idStructure
        oBanc.isSupprime = False
        oBanc.etat = True
        oBanc.JamaisServi = False
        oBanc.lstPools.Add(oPool)
        BancManager.save(oBanc)

        Dim lst As List(Of Banc)
        lst = BancManager.getBancByAgent(m_oAgent)
        Assert.AreEqual(1, lst.Count)

        'Si l'agent utilise le Pool2 , il ne voit pas le Mano
        'm_oAgent.idCRODIPPool = oPool2.idCrodip
        AgentManager.save(m_oAgent)

        lst = BancManager.getBancByAgent(m_oAgent)
        Assert.AreEqual(0, lst.Count)

        'Ajout du Pool2 dans le Mano
        oBanc.lstPools.Add(oPool2)
        BancManager.save(oBanc)
        'Le Mano est bien chargé
        lst = BancManager.getBancByAgent(m_oAgent)
        Assert.AreEqual(1, lst.Count)
        'il appartient Bien aux 2 pool
        Assert.AreEqual(2, lst(0).lstPools.Count)
        'et on le retrouve bien sur le pool1
        'm_oAgent.idCRODIPPool = oPool.idCrodip
        AgentManager.save(m_oAgent)

        lst = BancManager.getBancByAgent(m_oAgent)
        Assert.AreEqual(1, lst.Count)


    End Sub

End Class
