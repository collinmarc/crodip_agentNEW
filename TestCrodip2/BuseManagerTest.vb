Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



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
        objBuse.dateSuppression = CDate("06/02/1964")

        Assert.AreEqual(objBuse.idCrodip, "MonBuse")
        Assert.AreEqual(objBuse.idStructure, m_oAgent.idStructure)
        Assert.AreEqual(objBuse.couleur, "Bleue")
        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)
        Assert.AreEqual(objBuse.numeroNational, "001")
        Assert.AreEqual(objBuse.etat, True)
        Assert.AreEqual(objBuse.isSupprime, True)
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
        Assert.AreEqual(objBuse2.isSupprime, True)
        Assert.AreEqual(objBuse2.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBuse2.RaisonSuppression, "MaRaison")
        Assert.AreEqual(CDate(objBuse2.dateSuppression), CDate("06/02/1964"))

        'Mise à jour du Buse
        objBuse2.isSupprime = False
        objBuse2.AgentSuppression = "MonAgentSuppression"
        objBuse2.RaisonSuppression = "MaRaison2"
        objBuse2.dateSuppression = CDate("06/02/1965")

        Assert.IsTrue(BuseManager.save(objBuse2))

        'Rehcragement du Buse pour vérifier l'update
        objBuse = BuseManager.getBuseByNumeroNational("001")

        Assert.AreEqual(objBuse.isSupprime, False)
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
        Dim UpdatedObject As Object

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

        Dim response As Integer = BuseManager.sendWSBuse(oBuse, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oBuse2 = BuseManager.getWSBuseById(oBuse.numeroNational)
        Assert.AreEqual(oBuse.numeroNational, oBuse2.numeroNational)
        Assert.AreEqual(oBuse2.isSupprime, False)
        Assert.AreEqual(oBuse2.etat, oBuse.etat)
        Assert.AreEqual(oBuse2.dateAchat, oBuse.dateAchat)
        Assert.AreEqual(oBuse2.couleur, oBuse.couleur)
        Assert.AreEqual(oBuse2.debitEtalonnage, oBuse.debitEtalonnage)
        Assert.AreEqual(oBuse2.debitEtalonnage, oBuse.debitEtalonnage)
        Assert.AreEqual(oBuse2.AgentSuppression, oBuse.AgentSuppression)
        Assert.AreEqual(oBuse2.RaisonSuppression, oBuse.RaisonSuppression)
        Assert.AreEqual(oBuse2.dateSuppression, oBuse.dateSuppression)

        bReturn = BuseManager.delete(idBuse)
        Assert.IsTrue(bReturn)

    End Sub

    'test l'echange par WS
    <TestMethod()>
    Public Sub DateDesuppressionTest()
        Dim oBuse As Buse
        Dim oBuse2 As Buse
        Dim bReturn As Boolean
        Dim idBuse As String
        Dim UpdatedObject As Object

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
        Assert.IsTrue(BuseManager.save(oBuse))

        oBuse = BuseManager.getBuseByNumeroNational(oBuse.numeroNational)
        Assert.IsNull(oBuse.DateSuppression)

        Dim response As Integer = BuseManager.sendWSBuse(oBuse, UpdatedObject)
        Assert.IsTrue(response = 0 Or response = 2)

        oBuse2 = BuseManager.getWSBuseById(oBuse.numeroNational)
        Assert.AreEqual(oBuse.numeroNational, oBuse2.numeroNational)
        Assert.AreEqual(oBuse2.isSupprime, False)
        Assert.AreEqual(oBuse2.DateSuppression, oBuse.DateSuppression)

        bReturn = BuseManager.delete(idBuse)
        Assert.IsTrue(bReturn)

    End Sub
    <TestMethod()>
    Public Sub DeleteMaterielTest()
        Dim objBuse As Buse
        Dim objBuse2 As Buse
        Dim bReturn As Boolean
        Dim idBuse As String
        Dim UpdatedObject As Object

        'Creation d'un Buse
        objBuse = New Buse()
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        objBuse.idCrodip = "MonBuse"
        objBuse.idStructure = m_oAgent.idStructure
        objBuse.couleur = "Bleue"
        objBuse.debitEtalonnage = 15.5
        objBuse.numeroNational = "001"
        objBuse.etat = True
        objBuse.pressionEtalonnage = 16.5
        Assert.IsTrue(BuseManager.save(objBuse))

        objBuse2 = BuseManager.getBuseByNumeroNational("001")
        objBuse2.DeleteMateriel(m_oAgent, "MaRaison")

        objBuse = BuseManager.getBuseByNumeroNational("001")
        Assert.AreEqual(objBuse.isSupprime, True)
        Assert.AreEqual(objBuse.AgentSuppression, m_oAgent.nom)
        Assert.AreEqual(objBuse.RaisonSuppression, "MaRaison")
        Assert.IsNotNull(objBuse.dateSuppression)



        bReturn = BuseManager.delete("001")
        Assert.IsTrue(bReturn)

    End Sub

    '''<summary>
    '''Test pour save
    '''</summary>
    <TestMethod()> _
    Public Sub SymboleDecimalTest()
        Dim objBuse As Buse = Nothing
        Dim expected As Object = Nothing
        Dim objBuse2 As Buse
        Dim UpdatedObject As Object

        objBuse = New Buse()
        objBuse.idCrodip = "MonBuse"
        objBuse.idStructure = m_oAgent.idStructure
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
        Assert.AreEqual(objBuse.debitEtalonnage, Globals.StringToDouble("15.5"))
        Assert.AreEqual(objBuse.pressionEtalonnage, Globals.StringToDouble("16.5"))
        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)

        Assert.AreEqual(objBuse.debitEtalonnage, Globals.StringToDouble("15,5"))
        Assert.AreEqual(objBuse.pressionEtalonnage, Globals.StringToDouble("16,5"))
        Assert.AreEqual(objBuse.debitEtalonnage, 15.5)
        Assert.AreEqual(objBuse.pressionEtalonnage, 16.5)

        BuseManager.sendWSBuse(objBuse, UpdatedObject)

        objBuse2 = BuseManager.getWSBuseById(objBuse.numeroNational)
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
        Assert.IsFalse(oBuse.JamaisServi)
        idBuse = BuseManager.getNewNumeroNationalforTestOnly(m_oAgent)
        'oBuse.numeroNational = idBuse
        oBuse.idCrodip = idBuse
        oBuse.numeroNational = idBuse
        oBuse.idStructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))

        Assert.IsTrue(BuseManager.save(oBuse))
        oBuse2 = BuseManager.getBuseByNumeroNational(idBuse)

        Assert.AreEqual(oBuse.JamaisServi, oBuse2.JamaisServi)
        Assert.AreEqual(oBuse.DateActivation, oBuse2.DateActivation)
        Assert.AreEqual(oBuse.DateActivationS, oBuse2.DateActivationS)

        'Modification des propriétés
        oBuse.JamaisServi = True
        oBuse.DateActivation = CDate("06/02/1966")
        Assert.AreEqual("1966-02-06 00:00:00", oBuse.DateActivationS)
        Assert.IsTrue(BuseManager.save(oBuse))

        oBuse2 = BuseManager.getBuseByNumeroNational(idBuse)
        Assert.AreEqual(oBuse.JamaisServi, oBuse2.JamaisServi)
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
        oBuse.idStructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))

        Assert.IsTrue(BuseManager.save(oBuse))
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(1, tabBuse.Count)

        'Suppression du Buse
        oBuse.isSupprime = True
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(0, tabBuse.Count)

        'Buse Jamais Servi
        oBuse.isSupprime = False
        oBuse.JamaisServi = True
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure, True)
        Assert.AreEqual(0, tabBuse.Count)
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure, False)
        Assert.AreEqual(0, tabBuse.Count)

        oBuse.JamaisServi = False 'Le Buse n'a pas jamaisservi => il est actif
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure, True)
        Assert.AreEqual(1, tabBuse.Count)
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(1, tabBuse.Count)

        oBuse.etat = False 'Buse non controlé
        BuseManager.save(oBuse)
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure, True)
        Assert.AreEqual(1, tabBuse.Count)
        tabBuse = BuseManager.getBusesEtalonByStructureId(m_oAgent.idStructure)
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
        oBuse.idStructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        BuseManager.save(oBuse)

        'Vérification que le Buse n'est pas dans les liste des jamais servi
        Assert.AreEqual(0, BuseManager.getBusesEtalonByStructureIdJamaisServi(m_oAgent.idStructure).Count)

        oBuse.JamaisServi = True
        BuseManager.save(oBuse)
        'Vérification que le Buse est dans la liste des jamais servi
        Assert.AreEqual(1, BuseManager.getBusesEtalonByStructureIdJamaisServi(m_oAgent.idStructure).Count)

        oBuse.JamaisServi = False
        BuseManager.save(oBuse)
        'Vérification que le Buse n'est plus dans la liste des jamais servi
        Assert.AreEqual(0, BuseManager.getBusesEtalonByStructureIdJamaisServi(m_oAgent.idStructure).Count)

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
        oBuse.idStructure = m_oAgent.idStructure
        oBuse.isSupprime = False
        oBuse.etat = False
        oBuse.JamaisServi = True
        oBuse.dateAchat = CSDate.ToCRODIPString(CDate("06/02/1965"))
        BuseManager.save(oBuse)


        Assert.IsTrue(oBuse.ActiverMateriel(CDate("01/02/1987"), m_oAgent))

        'JAmaisServi True -> False
        Assert.IsFalse(oBuse.JamaisServi)
        'Etat True 
        Assert.IsTrue(oBuse.etat)

        Assert.AreEqual(CDate("01/02/1987"), oBuse.DateActivation)
        Assert.AreEqual(CDate("01/02/1987"), CDate(oBuse.dateDernierControleS))


        BuseManager.delete(idBuse)
    End Sub

End Class
