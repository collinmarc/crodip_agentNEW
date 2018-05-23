Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



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
    Public Sub ObjetTest()
        Dim objBanc As Banc = Nothing ' TODO: initialisez à une valeur appropriée
        Dim expected As Object = Nothing ' TODO: initialisez à une valeur appropriée
        Dim objBanc2 As Banc
        objBanc = New Banc()
        objBanc.id = "MonBanc"
        objBanc.idStructure = m_oAgent.idStructure
        objBanc.isSupprime = True
        objBanc.AgentSuppression = m_oAgent.nom
        objBanc.RaisonSuppression = "MaRaison"
        objBanc.DateSuppression = CDate("06/02/1964")
        objBanc.nbControles = 5
        objBanc.nbControlesTotal = 15

        Assert.AreEqual(objBanc.isSupprime, True)
        Assert.AreEqual(objBanc.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBanc.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objBanc.DateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objBanc.nbControles, 5)
        Assert.AreEqual(objBanc.nbControlesTotal, 15)

        Assert.IsTrue(BancManager.save(objBanc))

        objBanc2 = BancManager.getBancById("MonBanc")
        Assert.AreEqual("MonBanc", objBanc2.id)

        Assert.AreEqual(objBanc2.isSupprime, True)
        Assert.AreEqual(objBanc2.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBanc2.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objBanc2.DateSuppression), CDate("06/02/1964"))
        Assert.AreEqual(objBanc2.nbControles, 5)
        Assert.AreEqual(objBanc2.nbControlesTotal, 15)

        'Mise à jour du banc
        objBanc2.isSupprime = False
        objBanc2.AgentSuppression = "MonAgentSuppression"
        objBanc2.RaisonSuppression = "MaRaison2"
        objBanc2.DateSuppression = CDate("06/02/1965")
        objBanc2.nbControles = 6
        objBanc2.nbControlesTotal = 16

        Assert.IsTrue(BancManager.save(objBanc2))

        'Rehcragement du banc pour vérifier l'update
        objBanc = BancManager.getBancById("Monbanc")

        Assert.AreEqual(objBanc.isSupprime, False)
        Assert.AreEqual(objBanc.AgentSuppression, "MonAgentSuppression")
        Assert.AreEqual(objBanc.RaisonSuppression, "MaRaison2")
        Assert.AreEqual(CDate(objBanc.DateSuppression), CDate("06/02/1965"))
        Assert.AreEqual(objBanc.nbControles, 6)
        Assert.AreEqual(objBanc.nbControlesTotal, 16)

        'Suppression du banc en base de donnée
        BancManager.delete(objBanc.id)
        objBanc2 = BancManager.getBancById("MonBanc")
        Assert.AreNotEqual("MonBanc", objBanc2.id)

    End Sub
    'test l'echange par WS
    <TestMethod()>
    Public Sub Get_Send_WS_Test()
        Dim oBanc As Banc
        Dim oBanc2 As Banc
        Dim bReturn As Boolean
        Dim idBanc As String
        Dim UpdatedObject As Object

        'Creation d'un Banc
        oBanc = New Banc()
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        oBanc.id = idBanc
        oBanc.idStructure = m_oAgent.idStructure
        oBanc.isSupprime = False
        oBanc.marque = "MaMarque"
        oBanc.modele = "Modele"
        oBanc.etat = True
        oBanc.dateAchat = CSDate.ToCRODIPString(CDate("02/06/1965"))
        oBanc.AgentSuppression = m_oAgent.nom
        oBanc.RaisonSuppression = "MaRaison"
        oBanc.DateSuppression = CSDate.ToCRODIPString(CDate("06/02/1964"))
        oBanc.nbControles = 5
        oBanc.nbControlesTotal = 15
        oBanc.JamaisServi = True
        '        oBanc.DateActivation = CDate("06-02-1966")
        BancManager.save(oBanc)

        Dim response As Integer = BancManager.sendWSBanc(oBanc, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)
        'Impossible à tester car normalement on ne peut pas créer de banc à partir de l'agent
        oBanc2 = BancManager.getWSBancById(oBanc.id)
        'Assert.AreEqual(oBanc.id, oBanc2.id)
        'Assert.AreEqual(oBanc2.isSupprime, False)
        'Assert.AreEqual(oBanc2.etat, oBanc.etat)

        'Assert.AreEqual(oBanc2.dateAchat, oBanc.dateAchat)
        'Assert.AreEqual(oBanc2.marque, oBanc.marque)
        'Assert.AreEqual(oBanc2.modele, oBanc.modele)
        'Assert.AreEqual(oBanc2.AgentSuppression, m_oAgent.nom)
        'Assert.AreEqual(oBanc2.RaisonSuppression, oBanc.RaisonSuppression)
        'Assert.AreEqual(oBanc2.DateSuppression, oBanc.DateSuppression)
        'Assert.AreEqual(oBanc2.nbControles, 5)
        'Assert.AreEqual(oBanc2.nbControlesTotal, 15)
        'Assert.AreEqual(oBanc2.JamaisServi, oBanc.JamaisServi)
        'Assert.AreEqual(oBanc2.DateActivation, oBanc.DateActivation)



        bReturn = BancManager.delete(idBanc)
        Assert.IsTrue(bReturn)

    End Sub
    <TestMethod()>
    Public Sub DeleteMaterielTest()
        Dim oBanc As Banc
        Dim oBanc2 As Banc
        Dim bReturn As Boolean
        Dim idBanc As String
        Dim UpdatedObject As Object

        'Creation d'un Banc
        oBanc = New Banc()
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        oBanc.id = idBanc
        oBanc.idStructure = m_oAgent.idStructure
        oBanc.isSupprime = False
        oBanc.marque = "MaMarque"
        oBanc.modele = "Modele"
        oBanc.etat = True
        oBanc.dateAchat = CDate("02/06/1965").ToString()
        oBanc.nbControles = 5
        oBanc.nbControlesTotal = 15

        Assert.IsTrue(BancManager.save(oBanc))

        oBanc2 = BancManager.getBancById(idBanc)
        oBanc2.DeleteMateriel(m_oAgent, "MaRaison")

        oBanc = BancManager.getBancById(idBanc)
        Assert.AreEqual(oBanc.isSupprime, True)
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
        Dim UpdatedObject As Object

        'Creation d'un Banc
        oBanc = New Banc()
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        'oBanc.numeroNational = idBanc
        oBanc.id = idBanc
        oBanc.idStructure = m_oAgent.idStructure
        oBanc.isSupprime = False
        oBanc.etat = True
        oBanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        Assert.IsTrue(BancManager.save(oBanc))

        oBanc = BancManager.getBancById(oBanc.id)
        Assert.IsNull(oBanc.DateSuppression)

        Dim response As Integer = BancManager.sendWSBanc(oBanc, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oBanc2 = BancManager.getWSBancById(oBanc.numeroNational)
        Assert.AreEqual(oBanc.numeroNational, oBanc2.numeroNational)
        Assert.AreEqual(oBanc2.isSupprime, False)
        Assert.AreEqual(oBanc2.DateSuppression, oBanc.DateSuppression)

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
        obanc = New Banc()
        Assert.IsTrue(obanc.JamaisServi)
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        'oBanc.numeroNational = idBanc
        obanc.id = idBanc
        obanc.idStructure = m_oAgent.idStructure
        obanc.isSupprime = False
        obanc.etat = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))

        Assert.IsTrue(BancManager.save(obanc))
        obanc2 = BancManager.getBancById(idBanc)

        Assert.AreEqual(obanc.JamaisServi, obanc2.JamaisServi)
        Assert.AreEqual(obanc.DateActivation, obanc2.DateActivation)
        Assert.AreEqual(obanc.DateActivationS, obanc2.DateActivationS)

        'Modification des propriétés
        obanc.JamaisServi = True
        obanc.DateActivation = CDate("06/02/1966")
        Assert.AreEqual("1966-02-06 00:00:00", obanc.DateActivationS)
        Assert.IsTrue(BancManager.save(obanc))

        obanc2 = BancManager.getBancById(idBanc)
        Assert.AreEqual(obanc.JamaisServi, obanc2.JamaisServi)
        Assert.AreEqual(obanc.DateActivation, obanc2.DateActivation)
        Assert.AreEqual(obanc.DateActivationS, obanc2.DateActivationS)


        BancManager.delete(idBanc)

    End Sub 'JamaisServiTest
    <TestMethod()>
    Public Sub GetBancByStructureTest()
        Dim obanc As Banc
        Dim idBanc As String
        Dim tabBanc As List(Of Banc)

        'Creation d'un Banc
        obanc = New Banc()
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        obanc.id = idBanc
        obanc.idStructure = m_oAgent.idStructure
        obanc.isSupprime = False
        obanc.etat = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        obanc.JamaisServi = False

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
        obanc.JamaisServi = True
        BancManager.save(obanc)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure, True)
        Assert.AreEqual(0, tabBanc.Count)
        tabBanc = BancManager.getBancByStructureId(m_oAgent.idStructure, False)
        Assert.AreEqual(0, tabBanc.Count)

        obanc.JamaisServi = False 'Le Banc n'a pas jamaisservi => il est actif
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

        'Creation d'un Banc
        obanc = New Banc()
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        obanc.id = idBanc
        obanc.idStructure = m_oAgent.idStructure
        obanc.isSupprime = False
        obanc.etat = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        obanc.JamaisServi = False
        BancManager.save(obanc)

        'Vérification que le banc n'est pas dans les liste des jamais servi
        Assert.AreEqual(0, BancManager.getBancByStructureIdJamaisServi(m_oAgent.idStructure).Count)

        obanc.JamaisServi = True
        BancManager.save(obanc)
        'Vérification que le banc est dans la liste des jamais servi
        Assert.AreEqual(1, BancManager.getBancByStructureIdJamaisServi(m_oAgent.idStructure).Count)

        obanc.JamaisServi = False
        BancManager.save(obanc)
        'Vérification que le banc n'est plus dans la liste des jamais servi
        Assert.AreEqual(0, BancManager.getBancByStructureIdJamaisServi(m_oAgent.idStructure).Count)

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
        obanc = New Banc()
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        obanc.id = idBanc
        obanc.idStructure = m_oAgent.idStructure
        obanc.isSupprime = False
        obanc.etat = False
        obanc.JamaisServi = True
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        BancManager.save(obanc)

        lstFV = FVBancManager.getlstFVBancByBancId(idBanc)
        Assert.AreEqual(0, lstFV.Count)

        Assert.IsTrue(obanc.ActiverMateriel(CDate("01/02/1987"), m_oAgent))

        'JAmaisServi True -> False
        Assert.IsFalse(obanc.JamaisServi)
        'Etat True 
        Assert.IsTrue(obanc.etat)

        Assert.AreEqual(CDate("01/02/1987"), obanc.DateActivation)
        Assert.AreEqual(CDate("01/02/1987"), CDate(obanc.dateDernierControleS))

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
        obanc = New Banc()
        idBanc = BancManager.FTO_getNewId(m_oAgent)
        obanc.id = idBanc
        obanc.idStructure = m_oAgent.idStructure
        obanc.isSupprime = False
        obanc.etat = True
        obanc.JamaisServi = False
        obanc.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
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

    End Sub
End Class
