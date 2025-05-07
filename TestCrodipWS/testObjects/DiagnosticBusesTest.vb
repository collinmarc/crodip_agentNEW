Imports System

Imports Microsoft.VisualStudio.TestTools.UnitTesting

Imports CrodipWS



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

        createAndSaveDiagnostic()

        oDiagBuse = New DiagnosticBuses

        oDiagBuse.idDiagnostic = m_oDiag.id
        oDiagBuse.marque = "marque"
        oDiagBuse.nombre = "nombre"
        oDiagBuse.genre = "genre"
        oDiagBuse.calibre = "calibre"
        oDiagBuse.debitMoyen = "1,5"
        oDiagBuse.debitNominal = "1,6"
        oDiagBuse.idLot = "1"
        oDiagBuse.ecartTolere = "ecartTolere"

        Dim oCSDB As New CSDb(True)
        DiagnosticBusesManager.save(oDiagBuse, oCSDB)
        oCSDB.free()
        iD = oDiagBuse.id
        oDiagBuse = DiagnosticBusesManager.getDiagnosticBusesById(iD, oDiagBuse.idDiagnostic)

        Assert.AreEqual(iD, oDiagBuse.id)
        Assert.AreEqual(oDiagBuse.idDiagnostic, m_oDiag.id)
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
        oCSDB.getInstance()
        DiagnosticBusesManager.save(oDiagBuse, oCSDB)
        oCSDB.free()
        oDiagBuse = DiagnosticBusesManager.getDiagnosticBusesById(oDiagBuse.id, oDiagBuse.idDiagnostic)

        Assert.AreEqual(oDiagBuse.marque, "marque2")
        Assert.AreEqual(oDiagBuse.nombre, "nombre2")
        Assert.AreEqual(oDiagBuse.genre, "genre2")
        Assert.AreEqual(oDiagBuse.calibre, "calibre2")
        Assert.AreEqual(oDiagBuse.debitMoyen, "2,5")
        Assert.AreEqual(oDiagBuse.debitNominal, "2,6")
        Assert.AreEqual(oDiagBuse.idLot, "2")
        Assert.AreEqual(oDiagBuse.ecartTolere, "ecartTolere2")



    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()>
    Public Sub TST_LOAD_SAVE_DETAIL()
        Dim odiag As Diagnostic

        Dim oDiagBuse As DiagnosticBuses

        odiag = createAndSaveDiagnostic()
        Dim oCSDb As New CSDb(True)
        odiag.diagnosticBusesList.Liste.Clear()
        oCSDb.Execute("DELETE FROM DIAGNOSTICBUSES WHERE idDiagnostic = '" & odiag.id & "'")
        oCSDb.Execute("DELETE FROM DIAGNOSTICBUSESDETAIL WHERE idDiagnostic = '" & odiag.id & "'")
        oCSDb.free()

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
        oDiagBuseDetail.numBuse = 1
        oDiagBuseDetail.idLot = "1"
        oDiagBuseDetail.debit = "1,6"
        oDiagBuseDetail.ecart = "0.67"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.numBuse = 2
        oDiagBuseDetail.idLot = "1"
        oDiagBuseDetail.debit = "1,6"
        oDiagBuseDetail.ecart = "0.67"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)
        oCSDb.getInstance()
        DiagnosticBusesManager.save(oDiagBuse, oCSDb)
        oCSDb.free()
        'Rechargement par le diagnostic
        DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(oCSDb, odiag)
        'Vérification que les Buses Détail sopnt bien lus
        Assert.AreEqual(2, odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste.Count)

        oDiagBuseDetail = odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBuseDetail.idDiagnostic, oDiagBuse.idDiagnostic)
        Assert.AreEqual(oDiagBuseDetail.numBuse, 1)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.debit, "1,6")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.67")

        oDiagBuseDetail = odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBuseDetail.idDiagnostic, oDiagBuse.idDiagnostic)
        Assert.AreEqual(oDiagBuseDetail.numBuse, 2)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.debit, "1,6")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.67")

        'Maj de la buse 2
        oDiagBuseDetail.debit = "2,5"
        oDiagBuseDetail.ecart = "0.85"

        oCSDb.getInstance()
        DiagnosticBusesManager.save(odiag.diagnosticBusesList.Liste(0), oCSDb)
        'Relecture des items
        DiagnosticBusesManager.getDiagnosticBusesByDiagnostic(oCSDb, odiag)
        oCSDb.free()
        Assert.AreEqual(1, odiag.diagnosticBusesList.Liste.Count)
        oDiagBuse = odiag.diagnosticBusesList.Liste(0)
        Assert.AreEqual(2, oDiagBuse.diagnosticBusesDetailList.Liste.Count)
        oDiagBuseDetail = oDiagBuse.diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBuseDetail.debit, "2,5")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.85")

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()>
    Public Sub TST_GetByID()

    End Sub
    '''<summary>
    '''Test pour D'init de l'objet + properties
    '''</summary>
    <TestMethod()>
    Public Sub TST_SynchrobusesWS()
        'Annullation dela synchro de tous les anciens Diags
        Dim oCSDB As New CSDb(True)
        oCSDB.Execute("UPDATE DIAGNOSTIC SET dateModificationAgent = dateModificationCrodip")
        oCSDB.free()

        Dim odiag As Diagnostic

        Dim oDiagBuse As DiagnosticBuses
        Dim oDiagBuseDetail As DiagnosticBusesDetail
        Dim idDiag As String

        odiag = createAndSaveDiagnostic()
        oCSDB.getInstance()
        odiag.diagnosticBusesList.Liste.Clear()
        oCSDB.Execute("DELETE FROM DIAGNOSTICBUSES WHERE idDiagnostic = '" & odiag.id & "'")
        oCSDB.Execute("DELETE FROM DIAGNOSTICBUSESDETAIL WHERE idDiagnostic = '" & odiag.id & "'")
        oCSDB.free()

        idDiag = odiag.id
        odiag.setOrganisme(m_oAgent)
        odiag.controleNomSite = "MonSite"
        odiag.controleIsPulveRepare = True
        odiag.controleIsPreControleProfessionel = True
        odiag.controleIsAutoControle = True
        odiag.proprietaireRepresentant = "REP1"
        odiag.dateModificationCrodip = CDate("06/02/1964").ToShortDateString()
        odiag.controleEtat = Diagnostic.controleEtatNOKCV
        odiag.controleDateFin = Date.Today.ToShortDateString()
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
        oDiagBuseDetail.numBuse = 1
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.1"
        oDiagBuseDetail.ecart = "1.2"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.numBuse = 2
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.3"
        oDiagBuseDetail.ecart = "1.4"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

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
        oDiagBuseDetail.numBuse = 1
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "2.1"
        oDiagBuseDetail.ecart = "2.2"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.numBuse = 2
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "2.3"
        oDiagBuseDetail.ecart = "2.4"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

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
        m_oAgent.dateDerniereSynchro = CDate(odiag.dateModificationAgent).AddMinutes(-1).ToShortDateString()
        AgentManager.save(m_oAgent)

        'Suppression du diag par sécurité 
        DiagnosticManager.delete(odiag.id)

        'Synhcro descendante du diag
        Dim oLstSynchro As List(Of SynchronisationElmt)
        oLstSynchro = oSynchro.getListeElementsASynchroniserDESC(m_oPc, m_oAgent)
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
                Assert.AreEqual(2, oDiagBuse.diagnosticBusesDetailList.Liste.Count)
                'Vérification du détail des buses du lot1
                For Each oDiagBuseDetail In oDiagBuse.diagnosticBusesDetailList.Liste
                    Assert.AreEqual(oDiagBuseDetail.idLot, oDiagBuse.idLot)

                    If oDiagBuseDetail.numBuse = 1 Then
                        'Vérification de la buse 1 du Lot1
                        Assert.AreEqual(oDiagBuseDetail.numBuse, 1)
                        Assert.AreEqual(oDiagBuseDetail.debit, "1.1")
                        Assert.AreEqual(oDiagBuseDetail.ecart, "1.2")
                    End If
                    If oDiagBuseDetail.numBuse = 2 Then
                        'Vérification de la buse 2 du Lot1
                        Assert.AreEqual(oDiagBuseDetail.numBuse, 2)
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
                Assert.AreEqual(oDiagBuse.diagnosticBusesDetailList.Liste.Count, 2)
                For Each oDiagBuseDetail In oDiagBuse.diagnosticBusesDetailList.Liste
                    Assert.AreEqual(oDiagBuseDetail.idLot, oDiagBuse.idLot)
                    If oDiagBuseDetail.numBuse = 1 Then
                        'Vérification de la buse 1 du Lot2
                        Assert.AreEqual(oDiagBuseDetail.numBuse, 1)
                        Assert.AreEqual(oDiagBuseDetail.debit, "2.1")
                        Assert.AreEqual(oDiagBuseDetail.ecart, "2.2")
                    End If
                    If oDiagBuseDetail.numBuse = 2 Then
                        'Vérification de la buse 2 du Lot2
                        Assert.AreEqual(oDiagBuseDetail.numBuse, 2)
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
    <TestMethod(), Ignore()>
    Public Sub TST_SEND_WSDiagnosticBuses()


        Dim oDiagBuseList As New DiagnosticBusesList()
        Dim oDiagBuse As DiagnosticBuses
        Dim oDiagBuseDetail As DiagnosticBusesDetail


        'Lot1
        oDiagBuse = New DiagnosticBuses
        oDiagBuse.idDiagnostic = "99-999-99"
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
        oDiagBuseDetail.numBuse = 1
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.1"
        oDiagBuseDetail.ecart = "1.2"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.numBuse = 2
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.3"
        oDiagBuseDetail.ecart = "1.4"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        'Ajour du lot1 dans le Diag
        oDiagBuseList.Liste.Add(oDiagBuse)

        'Lot2
        oDiagBuse = New DiagnosticBuses
        oDiagBuse.idDiagnostic = "99-999-99"
        oDiagBuse.idLot = "2"
        oDiagBuse.marque = "marque2"
        oDiagBuse.nombre = "2"
        oDiagBuse.genre = "genre2"
        oDiagBuse.calibre = "cal2"
        oDiagBuse.debitMoyen = "20"
        oDiagBuse.debitNominal = "21"
        oDiagBuse.ecartTolere = "22"

        oDiagBuseList.Liste.Add(oDiagBuse)

        'Detail du lot2
        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.numBuse = 1
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "2.1"
        oDiagBuseDetail.ecart = "2.2"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.numBuse = 2
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "2.3"
        oDiagBuseDetail.ecart = "2.4"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        'Ajout du lot2 dans le diag
        oDiagBuseList.Liste.Add(oDiagBuse)

        Dim response As New Object

        Dim nResponse As Integer = DiagnosticBusesManager.WSSend(oDiagBuseList)

        '        Assert.AreNotEqual(-1, nResponse)

        nResponse = DiagnosticBusesDetailManager.WSSend(oDiagBuse.diagnosticBusesDetailList)


        'Assert.AreNotEqual(-1, nResponse)



    End Sub
    <TestMethod()>
    Public Sub TST_SeialiseXMLDiagnosticBuseDetail()


        Dim oDiagBuseList As New DiagnosticBusesList()
        Dim oDiagBuse As DiagnosticBuses
        Dim oDiagBuseDetail As DiagnosticBusesDetail


        'Lot1
        oDiagBuse = New DiagnosticBuses
        oDiagBuse.idDiagnostic = "99-999-99"
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
        oDiagBuseDetail.numBuse = 1
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.1"
        oDiagBuseDetail.ecart = "1.2"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        oDiagBuseDetail = New DiagnosticBusesDetail()
        oDiagBuseDetail.numBuse = 2
        oDiagBuseDetail.idLot = oDiagBuse.idLot
        oDiagBuseDetail.debit = "1.3"
        oDiagBuseDetail.ecart = "1.4"
        oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)

        'Ajour du lot1 dans le Diag
        oDiagBuseList.Liste.Add(oDiagBuse)

        Dim oSer As New System.Xml.Serialization.XmlSerializer(GetType(DiagnosticBuses))

        Dim osw As New System.IO.StringWriter()

        oSer.Serialize(osw, oDiagBuse)

        System.Console.WriteLine(osw.ToString())



    End Sub

    <TestMethod()>
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

    <TestMethod()>
    Public Sub TST_LOAD_SAVE_200_DETAIL()
        Dim odiag As Diagnostic

        Dim oDiagBuse As DiagnosticBuses

        odiag = createAndSaveDiagnostic()
        oDiagBuse = New DiagnosticBuses
        odiag.diagnosticBusesList.Liste.Add(oDiagBuse)

        oDiagBuse.marque = "marque"
        oDiagBuse.nombre = "nombre"
        oDiagBuse.genre = "genre"
        oDiagBuse.calibre = "calibre"
        oDiagBuse.debitMoyen = "debitMoyen"
        oDiagBuse.debitNominal = "debitNominal"
        oDiagBuse.idLot = "1"
        oDiagBuse.ecartTolere = "ecartTolere"

        Dim oDiagBuseDetail As DiagnosticBusesDetail
        For n As Integer = 1 To 200
            oDiagBuseDetail = New DiagnosticBusesDetail()
            oDiagBuseDetail.numBuse = n
            oDiagBuseDetail.idLot = "1"
            oDiagBuseDetail.debit = "1,6"
            oDiagBuseDetail.ecart = "0.67"
            oDiagBuse.diagnosticBusesDetailList.Liste.Add(oDiagBuseDetail)
        Next

        DiagnosticManager.save(odiag)

        odiag = DiagnosticManager.getDiagnosticById(odiag.id)
        Assert.AreEqual(200, odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste.Count)

        oDiagBuseDetail = odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste(0)
        Assert.AreEqual(oDiagBuseDetail.idDiagnostic, oDiagBuse.idDiagnostic)
        Assert.AreEqual(oDiagBuseDetail.numBuse, 1)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.debit, "1,6")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.67")

        oDiagBuseDetail = odiag.diagnosticBusesList.Liste(0).diagnosticBusesDetailList.Liste(1)
        Assert.AreEqual(oDiagBuseDetail.idDiagnostic, oDiagBuse.idDiagnostic)
        Assert.AreEqual(oDiagBuseDetail.numBuse, 2)
        Assert.AreEqual(oDiagBuseDetail.idLot, "1")
        Assert.AreEqual(oDiagBuseDetail.debit, "1,6")
        Assert.AreEqual(oDiagBuseDetail.ecart, "0.67")



    End Sub

End Class
