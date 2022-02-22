Imports System.Text
Imports Crodip_agent
Imports System.Xml.Serialization
Imports System.IO
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class PrestationTest
    Inherits CRODIPTest

    <TestMethod()>
    Public Sub AddPrestationTarifTest()
        Dim oTarif As PrestationTarif
        Dim ArrTarif As PrestationTarif()
        Dim oCategorie As PrestationCategorie
        oCategorie = New PrestationCategorie()
        oCategorie.idStructure = m_oAgent.idStructure
        oCategorie.libelle = "TEST CAT"
        PrestationCategorieManager.save(oCategorie, m_oAgent)


        ArrTarif = PrestationTarifManager.getArrayByStructureId(m_oAgent.idStructure)
        Dim n As Integer
        n = ArrTarif.Length


        oTarif = New PrestationTarif()
        oTarif.idCategorie = oCategorie.id
        oTarif.idStructure = m_oAgent.idStructure
        oTarif.tarifHT = 10
        oTarif.tva = 20
        oTarif.tarifTTC = 12

        PrestationTarifManager.save(oTarif, m_oAgent)
        ArrTarif = PrestationTarifManager.getArrayByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(n + 1, ArrTarif.Length)
        oTarif = ArrTarif(ArrTarif.Length - 1)
        Assert.AreEqual(oCategorie.id, oTarif.idCategorie)
        Assert.AreEqual(10D, oTarif.tarifHT)
        Assert.AreEqual(20D, oTarif.tva)
        Assert.AreEqual(12D, oTarif.tarifTTC)
    End Sub

    <TestMethod()>
    Public Sub AddPrestationTarifTestTvaNull()
        Dim oTarif As PrestationTarif
        Dim ArrTarif As PrestationTarif()
        Dim oCategorie As PrestationCategorie
        oCategorie = New PrestationCategorie()
        oCategorie.idStructure = m_oAgent.idStructure
        oCategorie.libelle = "TEST CAT"
        PrestationCategorieManager.save(oCategorie, m_oAgent)

        ArrTarif = PrestationTarifManager.getArrayByStructureId(m_oAgent.idStructure)
        Dim n As Integer
        n = ArrTarif.Length


        oTarif = New PrestationTarif()
        oTarif.idCategorie = oCategorie.id
        oTarif.idStructure = m_oAgent.idStructure
        oTarif.tarifHT = 10
        oTarif.tarifTTC = 12
        oTarif.tva = 20

        PrestationTarifManager.save(oTarif, m_oAgent)
        ArrTarif = PrestationTarifManager.getArrayByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(n + 1, ArrTarif.Length)
        oTarif = ArrTarif(ArrTarif.Length - 1)
        Assert.AreEqual(oCategorie.id, oTarif.idCategorie)
        Assert.AreEqual(10D, oTarif.tarifHT)
        Assert.AreEqual(20D, oTarif.tva)
        Assert.AreEqual(12D, oTarif.tarifTTC)
    End Sub

    <TestMethod(), Ignore()>
    Public Sub VerifPrestation2Structures()

        'ces données ont été initialisée dans l'interface CRODIP de test
        Dim oStructure1 As New Structuree()
        oStructure1.id = 497
        'StructureManager.save(oStructure1)
        Dim oAgent1 As New Agent()
        oAgent1.numeroNational = "TEST"
        oAgent1.id = 1114
        oAgent1.idStructure = oStructure1.id
        'AgentManager.save(oAgent1)

        Dim oStructure2 As Structuree = m_oStructure
        Dim oAgent2 As Agent = m_oAgent

        'Création Presta / Tarif Structure 1
        Dim oPrestaCategorie1 As New PrestationCategorie()
        oPrestaCategorie1.idStructure = oStructure1.id
        oPrestaCategorie1.libelle = "CAT STRUCTURE1"
        Assert.IsTrue(PrestationCategorieManager.save(oPrestaCategorie1, oAgent1))

        Dim oPrestaTarif1 As New PrestationTarif()
        oPrestaTarif1.idCategorie = oPrestaCategorie1.id
        oPrestaTarif1.idStructure = oStructure1.id
        oPrestaTarif1.description = "TARIF STRUCTURE1"
        Assert.IsTrue(PrestationTarifManager.save(oPrestaTarif1, oAgent1))


        'Création Presta / Tarif Structure 2
        Dim oPrestaCategorie2 As New PrestationCategorie()
        oPrestaCategorie2.idStructure = oStructure2.id
        oPrestaCategorie2.libelle = "CAT STRUCTURE2"
        Assert.IsTrue(PrestationCategorieManager.save(oPrestaCategorie2, oAgent2))

        Dim oPrestaTarif2 As New PrestationTarif()
        oPrestaTarif2.idCategorie = oPrestaCategorie2.id
        oPrestaTarif2.idStructure = oStructure2.id
        oPrestaTarif2.description = "TARIF STRUCTURE2"
        Assert.IsTrue(PrestationTarifManager.save(oPrestaTarif2, oAgent1))

        'Vérif Presta/Atrif Structure1
        oPrestaCategorie1 = PrestationCategorieManager.getCategoryById(oPrestaCategorie1.id, oStructure1.id)
        Assert.AreEqual("CAT STRUCTURE1", oPrestaCategorie1.libelle)
        oPrestaTarif1 = PrestationTarifManager.getById(oPrestaTarif1.id, oStructure1.id)
        Assert.AreEqual("TARIF STRUCTURE1", oPrestaTarif1.description)
        'Vérif Presta/Atrif Structure2
        oPrestaCategorie2 = PrestationCategorieManager.getCategoryById(oPrestaCategorie2.id, oStructure2.id)
        Assert.AreEqual("CAT STRUCTURE2", oPrestaCategorie2.libelle)
        oPrestaTarif2 = PrestationTarifManager.getById(oPrestaTarif2.id, oStructure2.id)
        Assert.AreEqual("TARIF STRUCTURE2", oPrestaTarif2.description)
        'Synchro ASC Structure1
        Dim obj As New Object()
        PrestationCategorieManager.sendWSPrestationCategorie(oPrestaCategorie1, oAgent1, obj)
        PrestationTarifManager.sendWSPrestationTarif(oPrestaTarif1, oAgent1, obj)
        'Synchro ASC Structure2
        PrestationCategorieManager.sendWSPrestationCategorie(oPrestaCategorie2, oAgent2, obj)
        PrestationTarifManager.sendWSPrestationTarif(oPrestaTarif2, oAgent2, obj)
        'Synhcro DESC Structure1
        PrestationCategorieManager.getWSPrestationCategorieById(oAgent1, oPrestaCategorie1.id)
        PrestationTarifManager.getWSPrestationTarifById(oPrestaTarif1.id, oPrestaTarif1.idCategorie, oAgent1)
        'Synhcro DESC Structure2
        PrestationCategorieManager.getWSPrestationCategorieById(oAgent2, oPrestaCategorie2.id)
        PrestationTarifManager.getWSPrestationTarifById(oPrestaTarif2.id, oPrestaTarif2.idCategorie, oAgent2)
        'Vérif Presta/Atrif Structure1
        oPrestaCategorie1 = PrestationCategorieManager.getCategoryById(oPrestaCategorie1.id, oStructure1.id)
        Assert.AreEqual("CAT STRUCTURE1", oPrestaCategorie1.libelle)
        oPrestaTarif1 = PrestationTarifManager.getById(oPrestaTarif1.id, oStructure1.id)
        Assert.AreEqual("TARIF STRUCTURE1", oPrestaTarif1.description)
        'Vérif Presta/Atrif Structure2
        oPrestaCategorie2 = PrestationCategorieManager.getCategoryById(oPrestaCategorie2.id, oStructure2.id)
        Assert.AreEqual("CAT STRUCTURE2", oPrestaCategorie2.libelle)
        oPrestaTarif2 = PrestationTarifManager.getById(oPrestaTarif2.id, oStructure2.id)
        Assert.AreEqual("TARIF STRUCTURE2", oPrestaTarif2.description)


    End Sub

    <TestMethod()>
    Public Sub testCreateDoublons()
        Dim oTarif As PrestationTarif
        Dim ArrTarif As PrestationTarif()

        Dim oCategorie As PrestationCategorie
        oCategorie = New PrestationCategorie()
        oCategorie.idStructure = m_oAgent.idStructure
        oCategorie.libelle = "TEST CAT"
        PrestationCategorieManager.save(oCategorie, m_oAgent)


        'Création d'un tarif (Normalement il n'y en a pas dans la base)
        oTarif = New PrestationTarif()
        oTarif.idCategorie = oCategorie.id
        oTarif.idStructure = m_oAgent.idStructure
        oTarif.tarifHT = 10
        oTarif.tva = 20
        oTarif.tarifTTC = 12
        PrestationTarifManager.save(oTarif, m_oAgent)

        'Récupération du tarif
        ArrTarif = PrestationTarifManager.getArrayByStructureId(m_oAgent.idStructure)
        oTarif = ArrTarif(0)
        'Modififcation du tarif
        oTarif.tarifHT = 25
        PrestationTarifManager.save(oTarif, m_oAgent)

        'Vérification de la sauvegarde
        ArrTarif = PrestationTarifManager.getArrayByStructureId(m_oAgent.idStructure)
        oTarif = ArrTarif(0)
        Assert.AreEqual(25D, oTarif.tarifHT)

        PrestationTarifManager.delete(oTarif)
        ArrTarif = PrestationTarifManager.getArrayByStructureId(m_oAgent.idStructure)
        Assert.AreEqual(0, ArrTarif.Length)

    End Sub


End Class
