﻿Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



'''<summary>
'''Classe de test pour FVManometreEtalonManagerTest, destinée à contenir tous
'''les tests unitaires FVManometreEtalonManagerTest
'''</summary>
<TestClass()>
Public Class ManometreEtalonManagerTest
    Inherits CRODIPTest



    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod(), Ignore("pool")>
    Public Sub ObjetTest()
        Dim objManometreEtalon As ManometreEtalon = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objManometreEtalon2 As ManometreEtalon
        objManometreEtalon = New ManometreEtalon()
        objManometreEtalon.idCrodip = "MonManometreEtalon"
        objManometreEtalon.numeroNational = "MonNumeroNational"
        objManometreEtalon.classe = "MaClasse"
        objManometreEtalon.type = "MonType"
        objManometreEtalon.fondEchelle = "MonFonEchelle"
        objManometreEtalon.incertitudeEtalon = "0.562"
        objManometreEtalon.uidstructure = m_oAgent.idStructure
        objManometreEtalon.isSupprime = True
        objManometreEtalon.AgentSuppression = m_oAgent.nom
        objManometreEtalon.RaisonSuppression = "MaRaison"
        objManometreEtalon.DateSuppression = "06/02/1964"
        objManometreEtalon.nbControles = 5
        objManometreEtalon.nbControlesTotal = 15

        Assert.AreEqual(objManometreEtalon.isSupprime, True)
        Assert.AreEqual(objManometreEtalon.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objManometreEtalon.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objManometreEtalon.dateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objManometreEtalon.nbControles, 5)
        Assert.AreEqual(objManometreEtalon.nbControlesTotal, 15)
        Assert.AreEqual(objManometreEtalon.idCrodip, "MonManometreEtalon")
        Assert.AreEqual(objManometreEtalon.numeroNational, "MonNumeroNational")
        Assert.AreEqual(objManometreEtalon.classe, "MaClasse")
        Assert.AreEqual(objManometreEtalon.type, "MonType")
        Assert.AreEqual(objManometreEtalon.fondEchelle, "MonFonEchelle")
        Assert.AreEqual(objManometreEtalon.incertitudeEtalon, "0.562")
        Assert.AreEqual(objManometreEtalon.incertitudeEtalon_d, CDbl(0.562))


        Assert.IsTrue(ManometreEtalonManager.save(objManometreEtalon))

        objManometreEtalon2 = ManometreEtalonManager.getManometreEtalonByNumeroNational("MonNumeroNational")
        Assert.AreEqual("MonManometreEtalon", objManometreEtalon2.idCrodip)

        Assert.AreEqual(objManometreEtalon2.isSupprime, True)
        Assert.AreEqual(objManometreEtalon2.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objManometreEtalon2.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objManometreEtalon2.dateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objManometreEtalon2.nbControles, 5)
        Assert.AreEqual(objManometreEtalon2.nbControlesTotal, 15)
        Assert.AreEqual(objManometreEtalon2.idCrodip, "MonManometreEtalon")
        Assert.AreEqual(objManometreEtalon2.numeroNational, "MonNumeroNational")
        Assert.AreEqual(objManometreEtalon2.classe, "MaClasse")
        Assert.AreEqual(objManometreEtalon2.type, "MonType")
        Assert.AreEqual(objManometreEtalon2.fondEchelle, "MonFonEchelle")
        Assert.AreEqual(objManometreEtalon2.incertitudeEtalon, "0.562")
        Assert.AreEqual(objManometreEtalon2.incertitudeEtalon_d, CDbl(0.562))

        'Mise à jour du ManometreEtalon
        objManometreEtalon2.isSupprime = False
        objManometreEtalon2.AgentSuppression = "MonAgentSuppression"
        objManometreEtalon2.RaisonSuppression = "MaRaison2"
        objManometreEtalon2.DateSuppression = CDate("06/02/1965").ToShortDateString()
        objManometreEtalon2.nbControles = 6
        objManometreEtalon2.nbControlesTotal = 16
        objManometreEtalon2.idCrodip = "MonManometreEtalon2"
        objManometreEtalon2.classe = "MaClasse2"
        objManometreEtalon2.type = "MonType2"
        objManometreEtalon2.fondEchelle = "MonFonEchelle2"
        objManometreEtalon2.incertitudeEtalon = "0.654"

        Assert.IsTrue(ManometreEtalonManager.save(objManometreEtalon2))

        'Rehcragement du ManometreEtalon pour vérifier l'update
        objManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational("MonNumeroNational")

        Assert.AreEqual(objManometreEtalon.isSupprime, False)
        Assert.AreEqual(objManometreEtalon.AgentSuppression, "MonAgentSuppression")
        Assert.AreEqual(objManometreEtalon.RaisonSuppression, "MaRaison2")
        Assert.AreEqual(CDate(objManometreEtalon.dateSuppression), CDate("06/02/1965"))
        Assert.AreEqual(objManometreEtalon.nbControles, 6)
        Assert.AreEqual(objManometreEtalon.nbControlesTotal, 16)
        Assert.AreEqual(objManometreEtalon.idCrodip, "MonManometreEtalon2")
        Assert.AreEqual(objManometreEtalon.classe, "MaClasse2")
        Assert.AreEqual(objManometreEtalon.type, "MonType2")
        Assert.AreEqual(objManometreEtalon.fondEchelle, "MonFonEchelle2")
        Assert.AreEqual(objManometreEtalon.incertitudeEtalon, "0.654")
        Assert.AreEqual(objManometreEtalon.incertitudeEtalon_d, CDbl(0.654))

        'Suppression du ManometreEtalon en base de donnée
        ManometreEtalonManager.delete(objManometreEtalon.numeroNational)
        objManometreEtalon2 = ManometreEtalonManager.getManometreEtalonByNumeroNational("MonNumeroNational")
        Assert.AreNotEqual("MonNumeroNational", objManometreEtalon2.numeroNational)

    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub Get_Send_WS_Test()
        Dim oManometreEtalon As ManometreEtalon
        Dim oManometreEtalon2 As ManometreEtalon
        Dim bReturn As Boolean
        Dim idManometreEtalon As String
        Dim oSynchro As New Synchronisation(m_oAgent)
        oSynchro.runAscSynchro()

        'Creation d'un ManometreEtalon
        oManometreEtalon = New ManometreEtalon()
        idManometreEtalon = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        oManometreEtalon.idCrodip = idManometreEtalon
        oManometreEtalon.numeroNational = "00447"
        oManometreEtalon.uidstructure = 2
        oManometreEtalon.isSupprime = True
        oManometreEtalon.jamaisServi = True
        oManometreEtalon.isUtilise = True
        oManometreEtalon.etat = True
        oManometreEtalon.dateActivation = DateTime.Now
        oManometreEtalon.dateDernierControle = DateTime.Now
        oManometreEtalon.marque = "BD SENSOR"
        oManometreEtalon.classe = "0.1"
        oManometreEtalon.type = "Capteur / Transmetteur de pression"
        oManometreEtalon.fondEchelle = "25"
        '        oManometreEtalon.agentSuppression = m_oAgent.nom
        '        oManometreEtalon.RaisonSuppression = "MaRaison"
        '        oManometreEtalon.dateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oManometreEtalon.nbControles = 0
        oManometreEtalon.nbControlesTotal = 0
        oManometreEtalon.incertitudeEtalon = "0,004"
        Assert.IsTrue(ManometreEtalonManager.save(oManometreEtalon))
        oManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational(oManometreEtalon.numeroNational)
        m_oAgent.idStructure = 2
        oSynchro = New Synchronisation(m_oAgent)
        oSynchro.runAscSynchro()
        oManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational("00447")

        oManometreEtalon2 = ManometreEtalonManager.WSgetById(oManometreEtalon.uid, oManometreEtalon.aid)
        Assert.AreEqual(oManometreEtalon.idCrodip, oManometreEtalon2.idCrodip)
        Assert.AreEqual(oManometreEtalon.numeroNational, oManometreEtalon2.numeroNational)
        Assert.AreEqual(oManometreEtalon2.isSupprime, oManometreEtalon.isSupprime)
        Assert.AreEqual(oManometreEtalon2.jamaisServi, oManometreEtalon.jamaisServi)
        Assert.AreEqual(oManometreEtalon2.isUtilise, oManometreEtalon.isUtilise)
        Assert.AreEqual(oManometreEtalon2.etat, oManometreEtalon.etat)

        Assert.AreEqual(oManometreEtalon2.marque, oManometreEtalon.marque)
        Assert.AreEqual(oManometreEtalon.type, oManometreEtalon2.type)
        Assert.AreEqual(oManometreEtalon.fondEchelle, oManometreEtalon2.fondEchelle)
        Assert.AreEqual(oManometreEtalon.classe, oManometreEtalon2.classe)
        Assert.AreEqual(oManometreEtalon.dateDernierControleS, oManometreEtalon2.dateDernierControleS)
        Assert.AreEqual(oManometreEtalon2.agentSuppression, oManometreEtalon2.agentSuppression)
        Assert.AreEqual(oManometreEtalon2.raisonSuppression, oManometreEtalon.raisonSuppression)
        Assert.AreEqual(oManometreEtalon2.dateSuppression, oManometreEtalon.dateSuppression)
        Assert.AreEqual(oManometreEtalon.nbControles, oManometreEtalon2.nbControles)
        Assert.AreEqual(oManometreEtalon.nbControlesTotal, oManometreEtalon2.nbControlesTotal)
        Assert.AreEqual(oManometreEtalon.incertitudeEtalon, oManometreEtalon2.incertitudeEtalon)


        oManometreEtalon2.isSupprime = False
        oManometreEtalon2.jamaisServi = False
        oManometreEtalon2.isUtilise = False
        oManometreEtalon2.etat = False
        ManometreEtalonManager.save(oManometreEtalon2)

        oSynchro = New Synchronisation(m_oAgent)
        oSynchro.runAscSynchro()

        oManometreEtalon = ManometreEtalonManager.WSgetById(oManometreEtalon2.uid, oManometreEtalon2.aid)
        Assert.AreEqual(oManometreEtalon.numeroNational, oManometreEtalon2.numeroNational)
        Assert.AreEqual(oManometreEtalon2.isSupprime, oManometreEtalon.isSupprime)
        Assert.AreEqual(oManometreEtalon2.jamaisServi, oManometreEtalon.jamaisServi)
        Assert.AreEqual(oManometreEtalon2.isUtilise, oManometreEtalon.isUtilise)
        Assert.AreEqual(oManometreEtalon2.etat, oManometreEtalon.etat)


    End Sub
    <TestMethod()>
    Public Sub DeleteMaterielTest()
        Dim objManometreEtalon As ManometreEtalon
        Dim objManometreEtalon2 As ManometreEtalon
        Dim bReturn As Boolean

        'Creation d'un ManometreEtalon
        objManometreEtalon = New ManometreEtalon()
        objManometreEtalon.idCrodip = "MonManometreEtalon"
        objManometreEtalon.numeroNational = "MonNumeroNational"
        objManometreEtalon.classe = "MaClasse"
        objManometreEtalon.type = "MonType"
        objManometreEtalon.fondEchelle = "MonFonEchelle"
        objManometreEtalon.uidstructure = m_oAgent.idStructure
        objManometreEtalon.nbControles = 5
        objManometreEtalon.nbControlesTotal = 15

        Assert.IsTrue(ManometreEtalonManager.save(objManometreEtalon))

        objManometreEtalon2 = ManometreEtalonManager.getManometreEtalonByNumeroNational("MonNumeroNational")
        objManometreEtalon2.DeleteMateriel(m_oAgent, "MaRaison")

        objManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational("MonNumeroNational")
        Assert.AreEqual(objManometreEtalon.isSupprime, True)
        Assert.AreEqual(objManometreEtalon.agentSuppression, m_oAgent.nom)
        Assert.AreEqual(objManometreEtalon.raisonSuppression, "MaRaison")
        Assert.IsNotNull(objManometreEtalon.dateSuppression)



        bReturn = ManometreEtalonManager.delete("MonNumeroNational")
        Assert.IsTrue(bReturn)

    End Sub
    'test l'echange par WS et la date de suppression qui reste a vide
    <TestMethod()>
    Public Sub DateDesuppressionTest()
        Dim oManometreEtalon As ManometreEtalon
        Dim oManometreEtalon2 As ManometreEtalon
        Dim bReturn As Boolean
        Dim idManometreEtalon As String

        'Creation d'un ManometreEtalon
        oManometreEtalon = New ManometreEtalon()
        idManometreEtalon = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        oManometreEtalon.idCrodip = idManometreEtalon
        oManometreEtalon.numeroNational = idManometreEtalon
        oManometreEtalon.uidstructure = m_oAgent.idStructure
        oManometreEtalon.isSupprime = False
        oManometreEtalon.etat = True
        Assert.IsTrue(ManometreEtalonManager.save(oManometreEtalon))

        oManometreEtalon = ManometreEtalonManager.getManometreEtalonByNumeroNational(oManometreEtalon.numeroNational)
        Assert.IsTrue(String.IsNullOrEmpty(oManometreEtalon.dateSuppression))
        Dim reponse As ManometreEtalon = Nothing
        Dim response As Integer = ManometreEtalonManager.WSSend(oManometreEtalon, reponse)
        Assert.IsTrue(response = 0 Or response = 2 Or response = 4)

        oManometreEtalon2 = ManometreEtalonManager.WSgetById(-1, oManometreEtalon.numeroNational)
        Assert.AreEqual(oManometreEtalon.numeroNational, oManometreEtalon2.numeroNational)
        Assert.AreEqual(oManometreEtalon2.isSupprime, False)
        Assert.AreEqual(oManometreEtalon2.dateSuppression, oManometreEtalon.dateSuppression)

        bReturn = ManometreEtalonManager.delete(idManometreEtalon)
        Assert.IsTrue(bReturn)

    End Sub
    'test des nlle Propriétés Matériels (JamaisServis, DateActivation)
    <TestMethod()>
    Public Sub JamaisServiTest()
        Dim oMano As ManometreEtalon
        Dim idMano As String
        Dim oMano2 As ManometreEtalon

        'Creation d'un Banc
        oMano = New ManometreEtalon
        Assert.IsFalse(oMano.jamaisServi)
        idMano = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        oMano.idCrodip = idMano
        oMano.numeroNational = idMano
        oMano.idCrodip = idMano
        oMano.uidstructure = m_oAgent.idStructure
        oMano.isSupprime = False
        oMano.etat = True

        Assert.IsTrue(ManometreEtalonManager.save(oMano))
        oMano2 = ManometreEtalonManager.getManometreEtalonByNumeroNational(idMano)

        Assert.AreEqual(oMano.jamaisServi, oMano2.jamaisServi)
        Assert.AreEqual(oMano.DateActivation, oMano2.DateActivation)
        Assert.AreEqual(oMano.DateActivationS, oMano2.DateActivationS)

        'Modification des propriétés
        oMano.jamaisServi = True
        oMano.DateActivation = CDate("06/02/1966")
        Assert.AreEqual("1966-02-06 00:00:00", oMano.DateActivationS)
        Assert.IsTrue(ManometreEtalonManager.save(oMano))

        oMano2 = ManometreEtalonManager.getManometreEtalonByNumeroNational(idMano)
        Assert.AreEqual(oMano.jamaisServi, oMano2.jamaisServi)
        Assert.AreEqual(oMano.DateActivation, oMano2.DateActivation)
        Assert.AreEqual(oMano.DateActivationS, oMano2.DateActivationS)


        ManometreEtalonManager.delete(idMano)

    End Sub 'JamaisServiTest
    <TestMethod()>
    Public Sub GetManoEByStructureTest()
        Dim oManometreEtalon As ManometreEtalon
        Dim idManometreEtalon As String
        Dim lstMano As List(Of ManometreEtalon)

        'Creation d'un ManometreEtalon
        oManometreEtalon = New ManometreEtalon()
        idManometreEtalon = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        oManometreEtalon.idCrodip = idManometreEtalon
        oManometreEtalon.numeroNational = idManometreEtalon
        oManometreEtalon.uidstructure = m_oAgent.idStructure
        oManometreEtalon.isSupprime = False
        oManometreEtalon.marque = "MaMarque"
        oManometreEtalon.etat = True
        oManometreEtalon.type = "MonType"
        oManometreEtalon.fondEchelle = "MonFond"
        oManometreEtalon.dateDernierControleS = CSDate.ToCRODIPString(CDate("07/02/1964"))
        oManometreEtalon.agentSuppression = m_oAgent.nom
        oManometreEtalon.raisonSuppression = "MaRaison"
        oManometreEtalon.dateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oManometreEtalon.nbControles = 5
        oManometreEtalon.nbControlesTotal = 15
        Assert.IsTrue(ManometreEtalonManager.save(oManometreEtalon))


        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        'Suppression du banc
        oManometreEtalon.isSupprime = True
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        oManometreEtalon.isSupprime = False
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        'banc Jamais Servi
        oManometreEtalon.isSupprime = False
        oManometreEtalon.jamaisServi = True
        oManometreEtalon.etat = True

        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent, True)
        Assert.AreEqual(1, lstMano.Count)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent, False)
        Assert.AreEqual(0, lstMano.Count)

        oManometreEtalon.jamaisServi = False 'Le Mano n'a pas jamaisservi => il est actif
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent, True)
        Assert.AreEqual(1, lstMano.Count)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        oManometreEtalon.etat = False 'Mano non controlé
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent, True)
        Assert.AreEqual(1, lstMano.Count)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        oManometreEtalon.jamaisServi = False 'Le Mano n'a pas jamaisservi => il est actif
        oManometreEtalon.etat = False 'Mano non controlé
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)
        oManometreEtalon.etat = True 'Mano controlé
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        oManometreEtalon.jamaisServi = True 'Le Mano n'a jamaisservi 
        oManometreEtalon.etat = False 'Mano non controlé
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)
        oManometreEtalon.etat = True 'Mano controlé
        ManometreEtalonManager.save(oManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        ManometreEtalonManager.delete(idManometreEtalon)

    End Sub
    <TestMethod()>
    Public Sub GetManoEJamaisServi()
        Dim pMano As ManometreEtalon
        Dim idMano As String

        'Creation d'un Banc
        pMano = New ManometreEtalon()
        idMano = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        pMano.numeroNational = idMano
        pMano.idCrodip = idMano
        pMano.uidstructure = m_oAgent.idStructure
        pMano.isSupprime = False
        pMano.etat = True
        ManometreEtalonManager.save(pMano)

        'Vérification que le banc n'est pas dans les liste des jamais servi
        Assert.AreEqual(0, ManometreEtalonManager.getManometreEtalonByAgentJamaisServi(m_oAgent).Count)

        pMano.jamaisServi = True
        ManometreEtalonManager.save(pMano)
        'Vérification que le banc est dans la liste des jamais servi
        Assert.AreEqual(1, ManometreEtalonManager.getManometreEtalonByAgentJamaisServi(m_oAgent).Count)

        pMano.jamaisServi = False
        ManometreEtalonManager.save(pMano)
        'Vérification que le banc n'est plus dans la liste des jamais servi
        Assert.AreEqual(0, ManometreEtalonManager.getManometreEtalonByAgentJamaisServi(m_oAgent).Count)

        ManometreEtalonManager.delete(idMano)
    End Sub

    ''' <summary>
    ''' Test de l'activation d'un Mano (JamaisServi true->false, dateActivation, dateDernControle, FicheVie)
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ActiverManoETest()
        Dim oManoE As ManometreEtalon
        Dim idMano As String
        Dim lstFV As List(Of FVManometreEtalon)
        Dim oFVManoC As FVManometreEtalon

        'Creation d'un Mano
        oManoE = New ManometreEtalon()
        idMano = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        oManoE.numeroNational = idMano
        oManoE.idCrodip = idMano
        oManoE.uidstructure = m_oAgent.idStructure
        oManoE.isSupprime = False
        oManoE.etat = False
        oManoE.jamaisServi = True
        ManometreEtalonManager.save(oManoE)

        lstFV = FVManometreEtalonManager.getArrFVManometreEtalon(idMano)
        Assert.AreEqual(0, lstFV.Count)

        Assert.IsTrue(oManoE.ActiverMateriel(CDate("01/02/1987"), m_oAgent))

        'JAmaisServi True -> False
        Assert.IsFalse(oManoE.jamaisServi)
        'Etat True 
        Assert.IsTrue(oManoE.etat)

        Assert.AreEqual(CDate("01/02/1987"), oManoE.DateActivation)
        'Assert.AreEqual(CDate("01/02/1987"), CDate(oManoE.dateDernierControleS))

        lstFV = FVManometreEtalonManager.getArrFVManometreEtalon(idMano)
        Assert.AreEqual(1, lstFV.Count)
        oFVManoC = lstFV(0)

        Assert.AreEqual("MISEENSERVICE", oFVManoC.type)
        Assert.AreEqual(idMano, oFVManoC.idManometre)
        Assert.AreEqual(m_oAgent.id, oFVManoC.idAgentControleur)


        ManometreEtalonManager.delete(idMano)
    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub Get_Send_WS_JamaisServiTest()
        Dim oManometreEtalon As ManometreEtalon
        Dim oManometreEtalon2 As ManometreEtalon
        Dim idManometreEtalon As String

        'Creation d'un ManometreEtalon
        oManometreEtalon = New ManometreEtalon()
        idManometreEtalon = ManometreEtalonManager.FTO_getNewId(m_oAgent)
        oManometreEtalon.idCrodip = idManometreEtalon
        oManometreEtalon.numeroNational = idManometreEtalon
        oManometreEtalon.uidstructure = m_oAgent.idStructure
        oManometreEtalon.isSupprime = False
        oManometreEtalon.marque = "MaMarque"
        oManometreEtalon.etat = True

        oManometreEtalon.jamaisServi = True
        oManometreEtalon.DateActivation = CDate("08/05/1981")

        Assert.IsTrue(ManometreEtalonManager.save(oManometreEtalon))
        Dim oreturn As ManometreEtalon = Nothing
        Dim response As Integer = ManometreEtalonManager.WSSend(oManometreEtalon, oreturn)
        Assert.IsTrue(response = 0 Or response = 2)

        oManometreEtalon2 = ManometreEtalonManager.WSgetById(oManometreEtalon.uid, oManometreEtalon.numeroNational)
        Assert.AreEqual(oManometreEtalon.idCrodip, oManometreEtalon2.idCrodip)
        Assert.AreEqual(oManometreEtalon.numeroNational, oManometreEtalon2.numeroNational)
        Assert.AreEqual(oManometreEtalon2.isSupprime, False)
        Assert.AreEqual(oManometreEtalon2.etat, oManometreEtalon.etat)
        Assert.AreEqual(oManometreEtalon2.JamaisServi, oManometreEtalon.JamaisServi)
        Assert.AreEqual(oManometreEtalon2.dateActivation, oManometreEtalon.dateActivation)



    End Sub

    ''' <summary>
    ''' Test du chargement à partir d'un Pool
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod(), Ignore("Pool")>
    Public Sub GetByPoolTest()
        Dim oMano As ManometreEtalon
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
        oMano = New ManometreEtalon()
        idMano = "M1E"
        oMano.numeroNational = idMano
        oMano.idCrodip = idMano
        oMano.uidstructure = m_oAgent.idStructure
        oMano.isSupprime = False
        oMano.etat = True
        oMano.JamaisServi = False
        oMano.lstPools.Add(oPool)
        ManometreEtalonManager.save(oMano)

        Dim lstMano As List(Of ManometreEtalon)
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        'Si l'agent utilise le Pool2 , il ne voit pas le Mano
        m_oAgent.idCRODIPPool = oPool2.idCrodip
        AgentManager.save(m_oAgent)

        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        'Ajout du Pool2 dans le Mano
        oMano.lstPools.Add(oPool2)
        ManometreEtalonManager.save(oMano)
        'Le Mano est bien chargé
        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)
        'il appartient Bien aux 2 pool
        Assert.AreEqual(2, lstMano(0).lstPools.Count)
        'et on le retrouve bien sur le pool1
        m_oAgent.idCRODIPPool = oPool.idCrodip
        AgentManager.save(m_oAgent)

        lstMano = ManometreEtalonManager.getManometreEtalonByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)


    End Sub
End Class
