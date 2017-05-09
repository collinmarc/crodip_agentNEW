Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports Crodip_agent



'''<summary>
'''Classe de test pour PulverisateurManagerTest, destinée à contenir tous
'''les tests unitaires PulverisateurManagerTest
'''</summary>
<TestClass()> _
Public Class DiagnosticBusesTest
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
    <TestMethod()> _
    Public Sub TST_Object()
    End Sub

    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_Create_Save_Update()
        Dim oDiagBuse As DiagnosticBuses
        Dim iD As Integer
        oDiagBuse = New DiagnosticBuses

        oDiagBuse.idDiagnostic = "99"
        oDiagBuse.marque = "marque"
        oDiagBuse.nombre = "nombre"
        oDiagBuse.genre = "genre"
        oDiagBuse.calibre = "calibre"
        oDiagBuse.debitMoyen = "1,5"
        oDiagBuse.debitNominal = "1,6"
        oDiagBuse.idLot = "1"
        oDiagBuse.ecartTolere = "ecartTolere"

        DiagnosticBusesManager.save(oDiagBuse)
        iD = oDiagBuse.id
        Assert.IsFalse(String.IsNullOrEmpty(oDiagBuse.id))
        oDiagBuse = DiagnosticBusesManager.getDiagnosticBusesById(oDiagBuse.id, oDiagBuse.idDiagnostic)

        Assert.AreEqual(oDiagBuse.id, iD)
        Assert.AreEqual(oDiagBuse.idDiagnostic, "99")
        Assert.AreEqual(oDiagBuse.marque, "marque")
        Assert.AreEqual(oDiagBuse.nombre, "nombre")
        Assert.AreEqual(oDiagBuse.genre, "genre")
        Assert.AreEqual(oDiagBuse.calibre, "calibre")
        Assert.AreEqual(oDiagBuse.debitMoyen, "1,5")
        Assert.AreEqual(oDiagBuse.debitNominal, "1,6")
        Assert.AreEqual(oDiagBuse.idLot, "1")
        Assert.AreEqual(oDiagBuse.ecartTolere, "ecartTolere")

        'Maj de l'objet
        oDiagBuse.marque = "marque2"
        oDiagBuse.nombre = "nombre2"
        oDiagBuse.genre = "genre2"
        oDiagBuse.calibre = "calibre2"
        oDiagBuse.debitMoyen = "2.5"
        oDiagBuse.debitNominal = "2.6"
        oDiagBuse.idLot = "2"
        oDiagBuse.ecartTolere = "ecartTolere2"
        DiagnosticBusesManager.save(oDiagBuse)
        oDiagBuse = DiagnosticBusesManager.getDiagnosticBusesById(oDiagBuse.id, oDiagBuse.idDiagnostic)

        Assert.AreEqual(oDiagBuse.marque, "marque2")
        Assert.AreEqual(oDiagBuse.nombre, "nombre2")
        Assert.AreEqual(oDiagBuse.genre, "genre2")
        Assert.AreEqual(oDiagBuse.calibre, "calibre2")
        Assert.AreEqual(oDiagBuse.debitMoyen, "2,5")
        Assert.AreEqual(oDiagBuse.debitNominal, "2,6")
        Assert.AreEqual(oDiagBuse.idLot, "2")
        Assert.AreEqual(oDiagBuse.ecartTolere, "ecartTolere2")

        DiagnosticBusesManager.delete(oDiagBuse.id, oDiagBuse.idDiagnostic)


    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_LOAD_SAVE_DETAIL()
        Dim odiag As Diagnostic

        Dim oDiagBuse As DiagnosticBuses
        Dim iD As Integer

        odiag = New Diagnostic()
        odiag.id = "99-99"
        oDiagBuse = New DiagnosticBuses

        oDiagBuse.idDiagnostic = odiag.id
        oDiagBuse.marque = "marque"
        oDiagBuse.nombre = "nombre"
        oDiagBuse.genre = "genre"
        oDiagBuse.calibre = "calibre"
        oDiagBuse.debitMoyen = "debitMoyen"
        oDiagBuse.debitNominal = "debitNominal"
        oDiagBuse.idLot = "1"
        oDiagBuse.ecartTolere = "ecartTolere"

        Dim oDiagBuseDetail As DiagnosticBusesDetail
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idBuse = 1
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.debit = "1,6"
        oDiagBuseDetail.ecart = "0.67"
        oDiagBuse.diagnosticBusesDetail.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idBuse = 2
        oDiagBuseDetail.idLot = 1
        oDiagBuseDetail.debit = "1,6"
        oDiagBuseDetail.ecart = "0.67"
        oDiagBuse.diagnosticBusesDetail.Liste.Add(oDiagBuseDetail)

        DiagnosticBusesManager.save(oDiagBuse)
        'Rechargement par le diagnostic
        DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(odiag)
        'Vérification que les Buses Détail sopnt bien lus
        Assert.AreEqual(2, odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetail.Liste.Count)

        oDiagBuseDetail = odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetail.Liste(0)
        Assert.AreEqual(oDiagBuseDetail.idDiagnostic, oDiagBuse.idDiagnostic)
        Assert.AreEqual(oDiagBuseDetail.idBuse, 1)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.debit, "1,6")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.67")

        oDiagBuseDetail = odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetail.Liste(1)
        Assert.AreEqual(oDiagBuseDetail.idDiagnostic, oDiagBuse.idDiagnostic)
        Assert.AreEqual(oDiagBuseDetail.idBuse, 2)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.debit, "1,6")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.67")

        'Maj de la buse 2
        oDiagBuseDetail.debit = "2,5"
        oDiagBuseDetail.ecart = "0.85"

        DiagnosticBusesManager.save(odiag.diagnosticBusesList.Liste(0))

        'Relecture des items
        DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(odiag)

        Assert.AreEqual(1, odiag.diagnosticBusesList.Liste.Count)
        oDiagBuse = odiag.diagnosticBusesList.Liste(0)
        Assert.AreEqual(2, oDiagBuse.diagnosticBusesDetail.Liste.Count)
        oDiagBuseDetail = oDiagBuse.diagnosticBusesDetail.Liste(1)
        Assert.AreEqual(oDiagBuseDetail.debit, "2,5")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.85")

        DiagnosticBusesManager.delete(oDiagBuse.id, oDiagBuse.idDiagnostic)


    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_GetByID()

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()> _
    Public Sub TST_SEND_GET_WS()
        'Annullation dela synchro de tous les anciens Diags
        Dim oCSDB As New CSDb(True)
        oCSDB.getResults("UPDATE DIAGNOSTIC SET dateModificationAgent = dateModificationCrodip")
        oCSDB.free()

        Dim odiag As Diagnostic

        Dim oDiagBuse As DiagnosticBuses
        Dim oDiagBuseDetail As DiagnosticBusesDetail
        Dim idDiag As String

        odiag = New Diagnostic()
        idDiag = DiagnosticManager.getNewId(m_oAgent)
        odiag.id = idDiag
        odiag.setOrganisme(m_oAgent)
        odiag.controleNomSite = "MonSite"
        odiag.controleIsPulveRepare = True
        odiag.controleIsPreControleProfessionel = True
        odiag.controleIsAutoControle = True
        odiag.proprietaireRepresentant = "REP1"
        odiag.inspecteurId = m_oAgent.id
        odiag.dateModificationCrodip = CDate("06/02/1964")
        odiag.controleEtat = Diagnostic.controleEtatNOKCV
        odiag.controleDateFin = Date.Today
        odiag.organismeOrigineInspAgrement = "AgrementOrigine"
        odiag.organismeOrigineInspNom = "NomOrigine"
        odiag.organismeOriginePresId = 98
        odiag.organismeOriginePresNom = "PresNomOrigine"
        odiag.organismeOriginePresNumero = "PresNumeroOrigine"
        odiag.inspecteurOrigineId = 1114
        odiag.inspecteurOrigineNom = "inspecteurNomOrigine"
        odiag.inspecteurOriginePrenom = "inspecteurNomOrigine"
        odiag.pulverisateurEmplacementIdentification = "DERRIERE"
        odiag.controleManoControleNumNational = "TEST"
        odiag.controleNbreNiveaux = 2
        odiag.controleNbreTroncons = 5
        odiag.controleUseCalibrateur = True
        odiag.controleBancMesureId = "IDBANC"

        'Lot1
        oDiagBuse = New DiagnosticBuses
        oDiagBuse.idDiagnostic = odiag.id
        oDiagBuse.idLot = "1"
        oDiagBuse.marque = "marque"
        oDiagBuse.nombre = "2"
        oDiagBuse.genre = "genre"
        oDiagBuse.calibre = "cal1"
        oDiagBuse.debitMoyen = "10"
        oDiagBuse.debitNominal = "11"
        oDiagBuse.ecartTolere = "12"

        'Detail du lot1
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idBuse = 1
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.1"
        oDiagBuseDetail.ecart = "1.2"
        oDiagBuse.diagnosticBusesDetail.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idBuse = 2
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.3"
        oDiagBuseDetail.ecart = "1.4"
        oDiagBuse.diagnosticBusesDetail.Liste.Add(oDiagBuseDetail)

        'Ajour du lot1 dans le Diag
        odiag.diagnosticBusesList.Liste.Add(oDiagBuse)

        'Lot2
        oDiagBuse = New DiagnosticBuses
        oDiagBuse.idDiagnostic = odiag.id
        oDiagBuse.idLot = "2"
        oDiagBuse.marque = "marque2"
        oDiagBuse.nombre = "2"
        oDiagBuse.genre = "genre2"
        oDiagBuse.calibre = "cal2"
        oDiagBuse.debitMoyen = "20"
        oDiagBuse.debitNominal = "21"
        oDiagBuse.ecartTolere = "22"

        odiag.diagnosticBusesList.Liste.Add(oDiagBuse)

        'Detail du lot2
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idBuse = 1
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "2.1"
        oDiagBuseDetail.ecart = "2.2"
        oDiagBuse.diagnosticBusesDetail.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.idBuse = 2
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "2.3"
        oDiagBuseDetail.ecart = "2.4"
        oDiagBuse.diagnosticBusesDetail.Liste.Add(oDiagBuseDetail)

        'Ajout du lot2 dans le diag
        odiag.diagnosticBusesList.Liste.Add(oDiagBuse)

        DiagnosticManager.save(odiag)

        odiag = DiagnosticManager.getDiagnosticById(idDiag)

        'Il y a bien 2 lot
        Assert.AreEqual(odiag.diagnosticBusesList.Liste.Count, 2)


        'Synchronisation Ascendante du Diag
        '========================
        Dim oDiags As Diagnostic() = DiagnosticManager.getUpdates(m_oAgent)
        Assert.AreEqual(1, oDiags.Count)
        Dim oSynchro As New Synchronisation(m_oAgent)
        For Each odiag In oDiags
            Assert.IsTrue(oSynchro.runascSynchroDiag(m_oAgent, odiag))
        Next



        'on Simule la date de dernière synchro de l'agent à -1 munites
        '======================================
        m_oAgent.dateDerniereSynchro = CDate(odiag.dateModificationAgent).AddMinutes(-1)
        AgentManager.save(m_oAgent)

        'Suppression du diag par sécurité 
        DiagnosticManager.delete(odiag.id)

        'Synhcro descendante du diag
        Dim oLstSynchro As List(Of SynchronisationElmt)
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC()
        Assert.AreNotEqual(0, oLstSynchro.Count)

        For Each oSynchroElmt As SynchronisationElmt In oLstSynchro
            Console.WriteLine(oSynchroElmt.type & "(" & oSynchroElmt.identifiantChaine & "," & oSynchroElmt.identifiantEntier & ")")
            oSynchroElmt.SynchroDesc(m_oAgent)
        Next oSynchroElmt

        'Vérification du nombre de lot
        odiag = DiagnosticManager.getDiagnosticById(idDiag)

        'Il y a bien 2 lots
        Assert.AreEqual(2, odiag.diagnosticBusesList.Liste.Count)

        'Vérification des Lots
        For Each oDiagBuse In odiag.diagnosticBusesList.Liste
            If oDiagBuse.idLot = "1" Then
                'Vérification du Lot1
                Assert.AreEqual(oDiagBuse.idDiagnostic, odiag.id)
                Assert.AreEqual(oDiagBuse.idLot, "1")
                Assert.AreEqual(oDiagBuse.marque, "marque")
                Assert.AreEqual(oDiagBuse.nombre, "2")
                Assert.AreEqual(oDiagBuse.genre, "genre")
                Assert.AreEqual(oDiagBuse.calibre, "cal1")
                Assert.AreEqual(oDiagBuse.debitMoyen, "10")
                Assert.AreEqual(oDiagBuse.debitNominal, "11")
                Assert.AreEqual(oDiagBuse.ecartTolere, "12")
                Assert.AreEqual(oDiagBuse.diagnosticBusesDetail.Liste.Count, 2)
                'Vérification du détail des buses du lot1
                For Each oDiagBuseDetail In oDiagBuse.diagnosticBusesDetail.Liste
                    Assert.AreEqual(oDiagBuseDetail.idLot, oDiagBuse.idLot)

                    If oDiagBuseDetail.idBuse = 1 Then
                        'Vérification de la buse 1 du Lot1
                        Assert.AreEqual(oDiagBuseDetail.idBuse, 1)
                        Assert.AreEqual(oDiagBuseDetail.debit, "1.1")
                        Assert.AreEqual(oDiagBuseDetail.ecart, "1.2")
                    End If
                    If oDiagBuseDetail.idBuse = 2 Then
                        'Vérification de la buse 2 du Lot1
                        Assert.AreEqual(oDiagBuseDetail.idBuse, 2)
                        Assert.AreEqual(oDiagBuseDetail.debit, "1.3")
                        Assert.AreEqual(oDiagBuseDetail.ecart, "1.4")
                    End If


                Next

            End If
            If oDiagBuse.idLot = "2" Then
                'Vérification du Lot2
                Assert.AreEqual(oDiagBuse.idDiagnostic, odiag.id)
                Assert.AreEqual(oDiagBuse.idLot, "2")
                Assert.AreEqual(oDiagBuse.marque, "marque2")
                Assert.AreEqual(oDiagBuse.nombre, "2")
                Assert.AreEqual(oDiagBuse.genre, "genre2")
                Assert.AreEqual(oDiagBuse.calibre, "cal2")
                Assert.AreEqual(oDiagBuse.debitMoyen, "20")
                Assert.AreEqual(oDiagBuse.debitNominal, "21")
                Assert.AreEqual(oDiagBuse.ecartTolere, "22")
                'Vérification du détail des buses du lot2
                Assert.AreEqual(oDiagBuse.diagnosticBusesDetail.Liste.Count, 2)
                For Each oDiagBuseDetail In oDiagBuse.diagnosticBusesDetail.Liste
                    Assert.AreEqual(oDiagBuseDetail.idLot, oDiagBuse.idLot)
                    If oDiagBuseDetail.idBuse = 1 Then
                        'Vérification de la buse 1 du Lot2
                        Assert.AreEqual(oDiagBuseDetail.idBuse, 1)
                        Assert.AreEqual(oDiagBuseDetail.debit, "2.1")
                        Assert.AreEqual(oDiagBuseDetail.ecart, "2.2")
                    End If
                    If oDiagBuseDetail.idBuse = 2 Then
                        'Vérification de la buse 2 du Lot2
                        Assert.AreEqual(oDiagBuseDetail.idBuse, 2)
                        Assert.AreEqual(oDiagBuseDetail.debit, "2.3")
                        Assert.AreEqual(oDiagBuseDetail.ecart, "2.4")
                    End If


                Next
            End If
        Next

        Dim bReturn As Boolean
        bReturn = DiagnosticManager.delete(idDiag)
        Assert.IsTrue(bReturn)



    End Sub
    <TestMethod()> _
    Public Sub TST_Nbdecimales()
        Dim oDiagBuse As DiagnosticBuses

        oDiagBuse = New DiagnosticBuses()
        oDiagBuse.debitMax = "1,465789"
        Assert.AreEqual("1,466", oDiagBuse.debitMax)
        oDiagBuse.debitMax = "1.465789"
        Assert.AreEqual("1,466", oDiagBuse.debitMax)
        oDiagBuse.debitMax = "1?465789"
        Assert.AreEqual("1,466", oDiagBuse.debitMax)
        oDiagBuse.debitMax = "1;465789"
        Assert.AreEqual("1,466", oDiagBuse.debitMax)

        oDiagBuse.debitMin = "1.465789"
        Assert.AreEqual("1,466", oDiagBuse.debitMin)
        oDiagBuse.debitMoyen = "1.465789"
        Assert.AreEqual("1,466", oDiagBuse.debitMoyen)
        oDiagBuse.debitNominal = "1.465789"
        Assert.AreEqual("1,466", oDiagBuse.debitNominal)


    End Sub
End Class
