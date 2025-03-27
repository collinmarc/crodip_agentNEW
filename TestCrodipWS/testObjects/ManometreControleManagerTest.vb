Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports CrodipWS
'''<summary>
'''Classe de test pour FVManometreControleManagerTest, destinée à contenir tous
'''les tests unitaires FVManometreControleManagerTest
'''</summary>
<TestClass()>
Public Class ManometreControleManagerTest
    Inherits CRODIPTest



    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod()>
    Public Sub ObjetTest()
        Dim objManometreControle As ManometreControle = Nothing
        Dim expected As Object = Nothing
        Dim objManometreControle2 As ManometreControle
        objManometreControle = New ManometreControle()
        objManometreControle.idCrodip = "MonManometreControle"
        objManometreControle.numeroNational = "MonNumeroNational"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.uidstructure = m_oAgent.idStructure
        objManometreControle.isSupprime = True
        objManometreControle.AgentSuppression = m_oAgent.nom
        objManometreControle.RaisonSuppression = "MaRaison"
        objManometreControle.DateSuppression = "06/02/1964"
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15
        objManometreControle.bAjusteur = True
        objManometreControle.resolutionLecture = 0.01
        objManometreControle.typeTraca = "B"
        objManometreControle.numTraca = 6
        objManometreControle.typeRaccord = "RA"

        Assert.AreEqual(objManometreControle.isSupprime, True)
        Assert.AreEqual(objManometreControle.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objManometreControle.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objManometreControle.dateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objManometreControle.nbControles, 5)
        Assert.AreEqual(objManometreControle.nbControlesTotal, 15)
        Assert.AreEqual(objManometreControle.idCrodip, "MonManometreControle")
        Assert.AreEqual(objManometreControle.numeroNational, "MonNumeroNational")
        Assert.AreEqual(objManometreControle.classe, "MaClasse")
        Assert.AreEqual(objManometreControle.type, "MonType")
        Assert.AreEqual(objManometreControle.fondEchelle, "MonFonEchelle")
        Assert.AreEqual(objManometreControle.bAjusteur, True)
        Assert.AreEqual(objManometreControle.resolutionLecture, "0,01")
        Assert.AreEqual(objManometreControle.typeTraca, "B")
        Assert.AreEqual(objManometreControle.numTraca, 6)
        Assert.AreEqual(objManometreControle.typeRaccord, "RA")


        Assert.IsTrue(ManometreControleManager.save(objManometreControle))

        objManometreControle2 = ManometreControleManager.getManometreControleByNumeroNational("MonNumeroNational")
        Assert.AreEqual("MonManometreControle", objManometreControle2.idCrodip)

        Assert.AreEqual(objManometreControle2.isSupprime, True)
        Assert.AreEqual(objManometreControle2.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objManometreControle2.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objManometreControle2.dateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objManometreControle2.nbControles, 5)
        Assert.AreEqual(objManometreControle2.nbControlesTotal, 15)
        Assert.AreEqual(objManometreControle2.idCrodip, "MonManometreControle")
        Assert.AreEqual(objManometreControle2.numeroNational, "MonNumeroNational")
        Assert.AreEqual(objManometreControle2.classe, "MaClasse")
        Assert.AreEqual(objManometreControle2.type, "MonType")
        Assert.AreEqual(objManometreControle2.fondEchelle, "MonFonEchelle")
        Assert.AreEqual(objManometreControle2.bAjusteur, True)
        Assert.AreEqual(objManometreControle2.resolutionLecture, "0,01")
        Assert.AreEqual(objManometreControle.typeTraca, "B")
        Assert.AreEqual(objManometreControle.numTraca, 6)
        Assert.AreEqual(objManometreControle.typeRaccord, "RA")

        'Mise à jour du ManometreControle
        objManometreControle2.isSupprime = False
        objManometreControle2.AgentSuppression = "MonAgentSuppression"
        objManometreControle2.RaisonSuppression = "MaRaison2"
        objManometreControle2.DateSuppression = CDate("06/02/1965").ToShortDateString()
        objManometreControle2.nbControles = 6
        objManometreControle2.nbControlesTotal = 16
        objManometreControle2.idCrodip = "MonManometreControle2"
        objManometreControle2.classe = "MaClasse2"
        objManometreControle2.type = "MonType2"
        objManometreControle2.fondEchelle = "MonFonEchelle2"
        objManometreControle2.bAjusteur = False
        objManometreControle2.resolutionLecture = 0.02
        objManometreControle2.typeTraca = "H"
        objManometreControle2.numTraca = 1
        objManometreControle2.typeRaccord = "RV"

        Assert.IsTrue(ManometreControleManager.save(objManometreControle2))

        'Rehcragement du ManometreControle pour vérifier l'update
        objManometreControle = ManometreControleManager.getManometreControleByNumeroNational("MonNumeroNational")

        Assert.AreEqual(objManometreControle.isSupprime, False)
        Assert.AreEqual(objManometreControle.agentSuppression, "MonAgentSuppression")
        Assert.AreEqual(objManometreControle.raisonSuppression, "MaRaison2")
        Assert.AreEqual(CDate(objManometreControle.dateSuppression), CDate("06/02/1965"))
        Assert.AreEqual(objManometreControle.nbControles, 6)
        Assert.AreEqual(objManometreControle.nbControlesTotal, 16)
        Assert.AreEqual(objManometreControle.idCrodip, "MonManometreControle2")
        Assert.AreEqual(objManometreControle.classe, "MaClasse2")
        Assert.AreEqual(objManometreControle.type, "MonType2")
        Assert.AreEqual(objManometreControle.fondEchelle, "MonFonEchelle2")
        Assert.AreEqual(objManometreControle.bAjusteur, False)
        Assert.AreEqual(objManometreControle.resolutionLecture, "0,02")
        Assert.AreEqual(objManometreControle.typeTraca, "H")
        Assert.AreEqual(objManometreControle.numTraca, 1)
        Assert.AreEqual(objManometreControle.typeRaccord, "RV")

        'Suppression du ManometreControle en base de donnée
        ManometreControleManager.delete(objManometreControle.numeroNational)
        objManometreControle2 = ManometreControleManager.getManometreControleByNumeroNational("MonNumeroNational")
        Assert.AreNotEqual("MonNumeroNational", objManometreControle2.numeroNational)

    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub Get_Send_WS_Test()
        Dim oManometreControle As ManometreControle
        Dim oManometreControle2 As ManometreControle
        Dim bReturn As Boolean
        Dim idManometreControle As String
        Dim UpdatedObject As New ManometreControle

        'Creation d'un ManometreControle
        oManometreControle = New ManometreControle()
        idManometreControle = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManometreControle.idCrodip = idManometreControle
        oManometreControle.numeroNational = idManometreControle
        oManometreControle.uidstructure = m_oAgent.idStructure
        oManometreControle.isSupprime = False
        oManometreControle.marque = "MaMarque"
        oManometreControle.etat = True
        oManometreControle.type = "MonType"
        oManometreControle.fondEchelle = "MonFond"
        oManometreControle.resolution = "MaResolution"
        oManometreControle.dateDernierControleS = CSDate.ToCRODIPString(CDate("07/02/1964"))
        oManometreControle.agentSuppression = m_oAgent.nom
        oManometreControle.raisonSuppression = "MaRaison"
        oManometreControle.dateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oManometreControle.nbControles = 5
        oManometreControle.nbControlesTotal = 15
        oManometreControle.bAjusteur = True
        oManometreControle.resolutionLecture = 0.01
        oManometreControle.typeTraca = "B"
        oManometreControle.numTraca = 6
        oManometreControle.typeRaccord = "RA"
        Assert.IsTrue(ManometreControleManager.save(oManometreControle))

        Dim response As Integer = ManometreControleManager.WSSend(oManometreControle, UpdatedObject)
        '        Assert.IsTrue(response = 0 Or response = 2)

        oManometreControle2 = ManometreControleManager.WSgetById(0, oManometreControle.numeroNational)
        Assert.AreEqual(oManometreControle.numeroNational, oManometreControle2.numeroNational)
        Assert.AreEqual(oManometreControle.idCrodip, oManometreControle2.idCrodip)
        Assert.AreEqual(oManometreControle.isSupprime, oManometreControle2.isSupprime, "IsSupprime")
        Assert.AreEqual(oManometreControle.etat, oManometreControle2.etat)

        Assert.AreEqual(oManometreControle.agentSuppression, oManometreControle2.agentSuppression)
        Assert.AreEqual(oManometreControle.raisonSuppression, oManometreControle2.raisonSuppression)
        Assert.AreEqual(oManometreControle.dateSuppression, oManometreControle2.dateSuppression)
        Assert.AreEqual(oManometreControle.type, oManometreControle2.type)
        Assert.AreEqual(oManometreControle.fondEchelle, oManometreControle2.fondEchelle)
        Assert.AreEqual(oManometreControle.resolution, oManometreControle2.resolution)
        Assert.AreEqual(oManometreControle.dateDernierControleS, oManometreControle2.dateDernierControleS)
        Assert.AreEqual(oManometreControle2.nbControles, 5)
        Assert.AreEqual(oManometreControle2.nbControlesTotal, 15)
        Assert.AreEqual(oManometreControle.bAjusteur, oManometreControle2.bAjusteur, "bAjusteur")
        Assert.AreEqual(CDec(oManometreControle.resolutionLecture), 0.01D)
        Assert.AreEqual(oManometreControle.typeTraca, "B")
        Assert.AreEqual(oManometreControle.numTraca, 6)
        Assert.AreEqual(oManometreControle.typeRaccord, "RA")

        oManometreControle.etat = False
        oManometreControle.isSupprime = True
        Assert.IsTrue(ManometreControleManager.save(oManometreControle))
        response = ManometreControleManager.WSSend(oManometreControle, UpdatedObject)
        oManometreControle2 = ManometreControleManager.WSgetById(oManometreControle.uid, oManometreControle.numeroNational)
        Assert.AreEqual(oManometreControle.etat, oManometreControle2.etat, "EtatFalse")
        Assert.AreEqual(oManometreControle.isSupprime, oManometreControle2.isSupprime, "isSupprimeTrue")



        '        bReturn = ManometreControleManager.delete(idManometreControle)
        '       Assert.IsTrue(bReturn)

    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub DeleteMaterielTest()
        Dim objManometreControle As ManometreControle
        Dim objManometreControle2 As ManometreControle
        Dim bReturn As Boolean

        'Creation d'un ManometreControle
        objManometreControle = New ManometreControle()
        objManometreControle.idCrodip = "MonManometreControle"
        objManometreControle.numeroNational = "MonNumeroNational"
        objManometreControle.classe = "MaClasse"
        objManometreControle.type = "MonType"
        objManometreControle.fondEchelle = "MonFonEchelle"
        objManometreControle.uidstructure = m_oAgent.idStructure
        objManometreControle.nbControles = 5
        objManometreControle.nbControlesTotal = 15

        Assert.IsTrue(ManometreControleManager.save(objManometreControle))

        objManometreControle2 = ManometreControleManager.getManometreControleByNumeroNational("MonNumeroNational")
        objManometreControle2.DeleteMateriel(m_oAgent, "MaRaison")

        objManometreControle = ManometreControleManager.getManometreControleByNumeroNational("MonNumeroNational")
        Assert.AreEqual(objManometreControle.isSupprime, True)
        Assert.AreEqual(objManometreControle.agentSuppression, m_oAgent.nom)
        Assert.AreEqual(objManometreControle.raisonSuppression, "MaRaison")
        Assert.IsNotNull(objManometreControle.dateSuppression)



        bReturn = ManometreControleManager.delete("MonNumeroNational")
        Assert.IsTrue(bReturn)

    End Sub
    'test l'echange par WS et la date de suppression qui reste a vide
    <TestMethod()>
    Public Sub DateDesuppressionTest()
        Dim oManoControle As ManometreControle
        Dim oManoControle2 As ManometreControle
        Dim bReturn As Boolean
        Dim idManoControle As String
        Dim UpdatedObject As New ManometreControle

        'Creation d'un ManoControle
        oManoControle = New ManometreControle()
        idManoControle = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        'oManoControle.numeroNational = idManoControle
        oManoControle.numeroNational = idManoControle
        oManoControle.uidstructure = m_oAgent.idStructure
        oManoControle.isSupprime = False
        oManoControle.etat = True
        Assert.IsTrue(ManometreControleManager.save(oManoControle))

        oManoControle = ManometreControleManager.getManometreControleByNumeroNational(oManoControle.numeroNational)
        Assert.IsTrue(String.IsNullOrEmpty(oManoControle.dateSuppression))

        Dim response As Integer = ManometreControleManager.WSSend(oManoControle, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2 Or response = 4)

        oManoControle2 = ManometreControleManager.WSgetById(oManoControle.uid, oManoControle.numeroNational)
        Assert.AreEqual(oManoControle2.isSupprime, False)
        Assert.IsTrue(String.IsNullOrEmpty(oManoControle2.DateSuppression))


    End Sub
    'test des nlle Propriétés Matériels (JamaisServis, DateActivation)
    <TestMethod()>
    Public Sub JamaisServiTest()
        Dim oMano As ManometreControle
        Dim idMano As String
        Dim oMano2 As ManometreControle

        'Creation d'un Banc
        oMano = New ManometreControle
        Assert.IsFalse(oMano.JamaisServi)
        idMano = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        'oBanc.numeroNational = idBanc
        oMano.numeroNational = idMano
        oMano.idCrodip = idMano
        oMano.uidstructure = m_oAgent.idStructure
        oMano.isSupprime = False
        oMano.etat = True

        Assert.IsTrue(ManometreControleManager.save(oMano))
        oMano2 = ManometreControleManager.getManometreControleByNumeroNational(idMano)

        Assert.AreEqual(oMano.JamaisServi, oMano2.JamaisServi)
        Assert.AreEqual(oMano.DateActivation, oMano2.DateActivation)
        Assert.AreEqual(oMano.DateActivationS, oMano2.DateActivationS)

        'Modification des propriétés
        oMano.JamaisServi = True
        oMano.DateActivation = CDate("06/02/1966")
        Assert.AreEqual("1966-02-06 00:00:00", oMano.DateActivationS)
        Assert.IsTrue(ManometreControleManager.save(oMano))

        oMano2 = ManometreControleManager.getManometreControleByNumeroNational(idMano)
        Assert.AreEqual(oMano.JamaisServi, oMano2.JamaisServi)
        Assert.AreEqual(oMano.DateActivation, oMano2.DateActivation)
        Assert.AreEqual(oMano.DateActivationS, oMano2.DateActivationS)


        ManometreControleManager.delete(idMano)

    End Sub 'JamaisServiTest
    <TestMethod()>
    Public Sub GetManoCByStructureTest()
        Dim oManometreControle As ManometreControle
        Dim idManometreControle As String
        Dim lstMano As List(Of ManometreControle)

        'Creation d'un ManometreControle
        oManometreControle = New ManometreControle()
        idManometreControle = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManometreControle.idCrodip = idManometreControle
        oManometreControle.numeroNational = idManometreControle
        oManometreControle.uidstructure = m_oAgent.idStructure
        oManometreControle.isSupprime = False
        oManometreControle.marque = "MaMarque"
        oManometreControle.etat = True
        oManometreControle.type = "MonType"
        oManometreControle.fondEchelle = "MonFond"
        oManometreControle.resolution = "MaResolution"
        oManometreControle.dateDernierControleS = CSDate.ToCRODIPString(CDate("07/02/1964"))
        oManometreControle.AgentSuppression = m_oAgent.nom
        oManometreControle.RaisonSuppression = "MaRaison"
        oManometreControle.DateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oManometreControle.nbControles = 5
        oManometreControle.nbControlesTotal = 15
        Assert.IsTrue(ManometreControleManager.save(oManometreControle))


        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        'Suppression du ManoC
        oManometreControle.isSupprime = True
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        oManometreControle.isSupprime = False
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        'Mano Jamais Servi
        oManometreControle.isSupprime = False
        oManometreControle.JamaisServi = True
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent, True)
        Assert.AreEqual(0, lstMano.Count)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent, False)
        Assert.AreEqual(0, lstMano.Count)

        oManometreControle.JamaisServi = False 'Le Mano n'a pas jamaisservi => il est actif
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent, True)
        Assert.AreEqual(1, lstMano.Count)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        oManometreControle.etat = False 'Mano non controlé
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent, True)
        Assert.AreEqual(1, lstMano.Count)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        oManometreControle.JamaisServi = False 'Le Mano n'a pas jamaisservi => il est actif
        oManometreControle.etat = False 'Mano non controlé
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)
        oManometreControle.etat = True 'Mano controlé
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        oManometreControle.JamaisServi = True 'Le Mano n'a jamaisservi 
        oManometreControle.etat = False 'Mano non controlé
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)
        oManometreControle.etat = True 'Mano controlé
        ManometreControleManager.save(oManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgentJamaisServi(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        ManometreControleManager.delete(idManometreControle)

    End Sub
    <TestMethod()>
    Public Sub GetManoCJamaisServi()
        Dim pMano As ManometreControle
        Dim idMano As String

        'Creation d'un Banc
        pMano = New ManometreControle()
        idMano = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        pMano.numeroNational = idMano
        pMano.idCrodip = idMano
        pMano.uidstructure = m_oAgent.idStructure
        pMano.isSupprime = False
        pMano.etat = True
        ManometreControleManager.save(pMano)

        'Vérification que le banc n'est pas dans les liste des jamais servi
        Assert.AreEqual(0, ManometreControleManager.getManoControleByAgentJamaisServi(m_oAgent).Count)

        pMano.JamaisServi = True
        ManometreControleManager.save(pMano)
        'Vérification que le banc est dans la liste des jamais servi
        Assert.AreEqual(1, ManometreControleManager.getManoControleByAgentJamaisServi(m_oAgent).Count)

        pMano.JamaisServi = False
        ManometreControleManager.save(pMano)
        'Vérification que le banc n'est plus dans la liste des jamais servi
        Assert.AreEqual(0, ManometreControleManager.getManoControleByAgentJamaisServi(m_oAgent).Count)

        ManometreControleManager.delete(idMano)
    End Sub

    ''' <summary>
    ''' Test de l'activation d'un Mano (JamaisServi true->false, dateActivation, dateDernControle, FicheVie)
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub ActiverManoCTest()
        Dim oManoC As ManometreControle
        Dim idMano As String
        Dim lstFV As List(Of FVManometreControle)
        Dim oFVManoC As FVManometreControle

        'Creation d'un Mano
        oManoC = New ManometreControle()
        idMano = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManoC.numeroNational = idMano
        oManoC.idCrodip = idMano
        oManoC.uidstructure = m_oAgent.idStructure
        oManoC.isSupprime = False
        oManoC.etat = False
        oManoC.JamaisServi = True
        ManometreControleManager.save(oManoC)
        'Récupération du uid
        ManometreControleManager.WSSend(oManoC, oManoC)
        ManometreControleManager.save(oManoC)


        lstFV = FVManometreControleManager.getLstFVManometreControleByuid(oManoC.uid)
        Assert.AreEqual(0, lstFV.Count)

        Assert.IsTrue(oManoC.ActiverMateriel(CDate("01/02/1987"), m_oAgent))

        'JAmaisServi True -> False
        Assert.IsFalse(oManoC.JamaisServi)
        'Etat True 
        Assert.IsTrue(oManoC.etat)

        Assert.AreEqual(CDate("01/02/1987"), oManoC.DateActivation)
        '        Assert.AreEqual(CDate("01/02/1987"), CDate(oManoC.dateDernierControleS))
        Assert.AreEqual("", oManoC.dateDernierControleS)

        lstFV = FVManometreControleManager.getLstFVManometreControleByuid(oManoC.uid)
        Assert.AreEqual(1, lstFV.Count)
        oFVManoC = lstFV(0)

        Assert.AreEqual("MISEENSERVICE", oFVManoC.type)
        Assert.AreEqual(idMano, oFVManoC.idManometre)
        Assert.AreEqual(m_oAgent.id, oFVManoC.idAgentControleur)


        ManometreControleManager.delete(idMano)
    End Sub

    ''' <summary>
    ''' Test de la gestion du flag Utilisé et dateDernierControle
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod()>
    Public Sub SetUtiliseTest()
        Dim oManoC As ManometreControle
        Dim idMano As String
        Dim lstFV As List(Of FVManometreControle)
        Dim oFVManoC As FVManometreControle

        'Creation d'un Mano
        oManoC = New ManometreControle()
        idMano = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManoC.numeroNational = idMano
        oManoC.idCrodip = idMano
        oManoC.uidstructure = m_oAgent.idStructure
        oManoC.isSupprime = False
        oManoC.etat = False
        oManoC.JamaisServi = True
        ManometreControleManager.save(oManoC)
        'Récupération du uid
        ManometreControleManager.WSSend(oManoC, oManoC)
        ManometreControleManager.save(oManoC)


        'Pas de Fiche de vie par défaut
        lstFV = FVManometreControleManager.getLstFVManometreControleByuid(oManoC.uid)
        Assert.AreEqual(0, lstFV.Count)

        'Première utilisation
        oManoC.setUtilise(m_oAgent)
        ManometreControleManager.save(oManoC)
        oManoC = ManometreControleManager.getManometreControleByNumeroNational(idMano) 'Rechargement
        'Vérification du flag utilise
        Assert.IsTrue(oManoC.isUtilise)
        'Vérification de la création de la fiche de vie
        lstFV = FVManometreControleManager.getLstFVManometreControleByuid(oManoC.uid)
        Assert.AreEqual(1, lstFV.Count)
        oFVManoC = lstFV(0)
        Assert.AreEqual(FVBanc.FVTYPE_PREMIEREUTILISATION, oFVManoC.type)
        Assert.AreEqual(idMano, oFVManoC.idManometre)
        Assert.AreEqual(m_oAgent.id, oFVManoC.idAgentControleur)

        'Seconde utilisation
        oManoC.setUtilise(m_oAgent)
        ManometreControleManager.save(oManoC)
        oManoC = ManometreControleManager.getManometreControleByNumeroNational(idMano) 'Rechargement
        'Vérification du flag utilise
        Assert.IsTrue(oManoC.isUtilise)
        'Pas de création d'une seconde fiche de vie
        lstFV = FVManometreControleManager.getLstFVManometreControleByuid(oManoC.uid)
        Assert.AreEqual(1, lstFV.Count)
        oFVManoC = lstFV(0)

    End Sub

    ''' <summary>
    ''' Test du chargement à partir d'un Pool
    ''' </summary>
    ''' <remarks></remarks>
    <TestMethod(), Ignore()>
    Public Sub GetByPoolTest()
        Dim oManoC As ManometreControle
        Dim idMano As String
        'Crodip_agent.My.Settings.GestionDesPools = True

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
        oManoC = New ManometreControle()
        idMano = ManometreControleManager.FTO_getNewNumeroNational(m_oAgent)
        oManoC.numeroNational = idMano
        oManoC.idCrodip = idMano
        oManoC.uidstructure = m_oAgent.idStructure
        oManoC.isSupprime = False
        oManoC.etat = True
        oManoC.JamaisServi = False
        oManoC.lstPools.Add(oPool)
        ManometreControleManager.save(oManoC)

        Dim lstMano As List(Of ManometreControle)
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)

        'Si l'agent utilise le Pool2 , il ne voit pas le Mano
        'm_oAgent.idCRODIPPool = oPool2.idCrodip
        AgentManager.save(m_oAgent)

        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(0, lstMano.Count)

        'Ajout du Pool2 dans le Mano
        oManoC.lstPools.Add(oPool2)
        ManometreControleManager.save(oManoC)
        'Le Mano est bien chargé
        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)
        'il appartient Bien aux 2 pool
        Assert.AreEqual(2, lstMano(0).lstPools.Count)
        'et on le retrouve bien sur le pool1
        'm_oAgent.idCRODIPPool = oPool.idCrodip
        AgentManager.save(m_oAgent)

        lstMano = ManometreControleManager.getManoControleByAgent(m_oAgent)
        Assert.AreEqual(1, lstMano.Count)


    End Sub

End Class
