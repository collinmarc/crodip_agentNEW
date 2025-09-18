Imports System.IO
Imports System.Text
Imports System.Xml.Serialization
Imports CrodipWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class IdentifiantPulverisateurTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub IdentifiantPulveristeurTestObject()
        Dim oIdent As IdentifiantPulverisateur

        oIdent = New IdentifiantPulverisateur()
        oIdent.id = 9999
        oIdent.libelle = "Mon Ident"
        oIdent.uidStructure = m_oStructure.id
        oIdent.numeroNational = "999-123-123"

        Assert.AreEqual(CLng(9999), oIdent.id)
        Assert.AreEqual("Mon Ident", oIdent.libelle)
        Assert.AreEqual(CLng(m_oStructure.id), oIdent.uidStructure)
        Assert.AreEqual("999-123-123", oIdent.numeroNational)

        oIdent.SetEtatINUTILISE()
        Assert.AreEqual("INUTILISE", oIdent.etat)
        Assert.IsTrue(oIdent.isEtatINUTILISE)
        Assert.IsFalse(oIdent.isEtatUTILISE)
        Assert.IsFalse(oIdent.isEtatINUTILISABLE)
        oIdent.SetEtatUTILISE()
        Assert.AreEqual("UTILISE", oIdent.etat)
        Assert.IsFalse(oIdent.isEtatINUTILISE)
        Assert.IsTrue(oIdent.isEtatUTILISE)
        Assert.IsFalse(oIdent.isEtatINUTILISABLE)
        oIdent.SetEtatINUTILISABLE()
        Assert.AreEqual("INUTILISABLE", oIdent.etat)
        Assert.IsFalse(oIdent.isEtatINUTILISE)
        Assert.IsFalse(oIdent.isEtatUTILISE)
        Assert.IsTrue(oIdent.isEtatINUTILISABLE)

        oIdent.dateUtilisation = DateTime.Today.ToShortDateString()
        Assert.AreEqual(CSDate.ToCRODIPString(DateTime.Today.ToShortDateString(), "yyyy-MM-dd"), oIdent.dateUtilisation)

    End Sub
    <TestMethod()> Public Sub IdentifiantPulveristeurTestCRUD()
        Dim oIdent As IdentifiantPulverisateur
        Dim oIdent2 As IdentifiantPulverisateur

        oIdent = New IdentifiantPulverisateur()
        oIdent.id = 0
        oIdent.libelle = "Mon Ident"
        oIdent.uidStructure = m_oStructure.id
        oIdent.numeroNational = "999-123-123"
        oIdent.SetEtatINUTILISE()


        IdentifiantPulverisateurManager.Save(oIdent)
        Assert.AreNotEqual(0, oIdent.id)
        Dim nid As Long
        nid = oIdent.id

        oIdent2 = IdentifiantPulverisateurManager.Load(nid)
        Assert.IsNotNull(oIdent2)
        Assert.AreEqual(oIdent.id, oIdent2.id)
        Assert.AreEqual(oIdent.libelle, oIdent2.libelle)
        Assert.AreEqual(oIdent.numeroNational, oIdent2.numeroNational)
        Assert.AreEqual(oIdent.etat, oIdent2.etat)
        'Assert.AreEqual("", oIdent2.dateUtilisation)

        oIdent2.SetEtatUTILISE()
        oIdent2.dateUtilisation = DateTime.Today.ToShortDateString()
        IdentifiantPulverisateurManager.Save(oIdent2)

        oIdent = IdentifiantPulverisateurManager.Load(nid)
        Assert.IsNotNull(oIdent)
        Assert.AreEqual(oIdent2.id, oIdent.id)
        Assert.AreEqual(oIdent2.libelle, oIdent.libelle)
        Assert.AreEqual(oIdent2.numeroNational, oIdent.numeroNational)
        Assert.IsTrue(oIdent.isEtatUTILISE())
        Assert.AreEqual(oIdent2.dateUtilisation, oIdent2.dateUtilisation)


    End Sub
    <TestMethod(), Ignore()> Public Sub IdentifiantPulveristeurTestWS()
        Dim oIdent As IdentifiantPulverisateur
        Dim oIdent2 As IdentifiantPulverisateur
        Dim nId As Long

        nId = 144
        ''Récupération des Idnentifiant Pulves
        'Dim oSynchro As New Synchronisation(m_oAgent)
        'Dim oLst As New List(Of SynchronisationElmt)()
        'oLst = oSynchro.getListeElementsASynchroniserDESC(m_oAgent)
        'For Each oelmt As SynchronisationElmt In oLst
        '    If TypeOf oelmt Is SynchronisationElmtIdentifiantPulverisateur Then
        '        oIdent = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(m_oAgent, oelmt.IdentifiantEntier)
        '        IdentifiantPulverisateurManager.Save(oIdent)
        '        'on mémorise le dernier Indetifiant
        '        nId = oIdent.id
        '    End If
        'Next

        'Rechargement du dernier Identifiant
        oIdent2 = IdentifiantPulverisateurManager.WSgetById(0, nId.ToString(), m_oAgent.uid)
        oIdent2.libelle = "TEST"
        oIdent2.SetEtatINUTILISABLE()
        IdentifiantPulverisateurManager.Save(oIdent2)
        IdentifiantPulverisateurManager.WSSend(oIdent2, oIdent, m_oAgent.uid)

        oIdent = IdentifiantPulverisateurManager.WSgetById(0, oIdent2.id.ToString, m_oAgent.uid)
        Assert.AreEqual(oIdent2.id, oIdent.id)
        Assert.AreEqual(oIdent2.libelle, oIdent.libelle)
        Assert.AreEqual(oIdent2.numeroNational, oIdent.numeroNational)
        Assert.AreEqual(oIdent2.etat, oIdent.etat)
        Assert.AreEqual(oIdent2.dateUtilisation, oIdent.dateUtilisation)
        oIdent.libelle = "TEST2"
        oIdent.SetEtatUTILISE()
        oIdent.dateUtilisation = DateTime.Today.ToShortDateString()

        IdentifiantPulverisateurManager.Save(oIdent)
        IdentifiantPulverisateurManager.WSSend(oIdent, oIdent2, m_oAgent.uid)
        oIdent2 = IdentifiantPulverisateurManager.WSgetById(0, oIdent2.id.ToString, m_oAgent.uid)

        Assert.AreEqual(oIdent.id, oIdent2.id)
        Assert.AreEqual(oIdent.libelle, oIdent2.libelle)
        Assert.AreEqual(oIdent.numeroNational, oIdent2.numeroNational)
        Assert.AreEqual(oIdent.etat, oIdent2.etat)
        Assert.AreEqual(oIdent.dateUtilisation, oIdent2.dateUtilisation)

    End Sub
    <TestMethod()> Public Sub IdentOTCTest()
        Dim oListe As New List(Of IdentifiantOTC)

        oListe.Add(New IdentifiantOTC("E001123546"))
        oListe.Add(New IdentifiantOTC("E001123547"))
        oListe.Add(New IdentifiantOTC("E001123548"))
        oListe.Add(New IdentifiantOTC("E001123549"))
        oListe.Add(New IdentifiantOTC("E001123540"))

        IdentifiantOTCManager.SaveList(oListe)

        Assert.IsTrue(IdentifiantOTCManager.exists("E001123548"))
        Assert.IsFalse(IdentifiantOTCManager.exists("Z001123458"))
    End Sub
End Class