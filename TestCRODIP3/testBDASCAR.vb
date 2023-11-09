Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Crodip_agent

<TestClass()> Public Class testBDASCAR
 Inherits CRODIPTest
    'Test uniquement pour MAJ base ASCAR
    'Mettre la base crodip_agent_dev(ASCAROK).mdb active avant l'executio du test
    <TestMethod(), Ignore()>
    Public Sub TestASCAR()
        Dim olst As List(Of Pulverisateur)
        Dim oPulve As Pulverisateur
        Dim oAgent As Agent
        olst = FTOgetUpdates()


        WSCrodip.Init("http://admin.crodip.fr/server")
        oAgent = AgentManager.getAgentById(1048)
        PulverisateurManager.MAJetatPulverisateurs(oAgent, olst)

        For Each oPulve In olst
            If oPulve.numeroNational <> "E001" Then
                Dim nRet As Integer
                nRet = PulverisateurManager.sendWSPulverisateur(oAgent, oPulve)

            End If
        Next

        'ceci est un test
    End Sub

    Public Shared Function FTOgetUpdates() As List(Of Pulverisateur)
        ' déclarations
        Dim oLst As New List(Of Pulverisateur)
        Dim oCSdb As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand = oCSdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Pulverisateur WHERE dateModificationAgent>=#2017/06/29 00:00:01#"
        '        bddCommande.CommandText = bddCommande.CommandText & " and id = '5-1074-680'"
        '"

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpPulverisateur As New Pulverisateur
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpPulverisateur.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                oLst.Add(tmpPulverisateur)
            End While

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager - getUpdates : " & ex.Message)
        End Try

        oCSdb.free()
        'on retourne les objet non synchro
        Return oLst
    End Function
    <TestMethod(), Ignore()>
    Public Sub TestGetManoControle()

        WSCrodip.Init("http://admin.crodip.fr/server")
        Dim oagent = New Agent
        oagent.id = 1165
        oagent.numeroNational = "138"
        oagent.nom = "MICKAEL"
        oagent.prenom = "PIERRE"
        oagent.dateDerniereSynchro = "2020-11-25 16:39:00"
        oagent.idStructure = 515
        oagent.isActif = True
        oagent.dateDerniereConnexion = "2020-03-03 09:32:00"
        Dim oSynchro As New Synchronisation(oagent)
        Dim oLst As List(Of SynchronisationElmt) = oSynchro.getListeElementsASynchroniserDESC()
        For Each oElem In oLst
            Console.WriteLine(oElem.identifiantChaine & oElem.type)
        Next


    End Sub

    <TestMethod(), Ignore()>
    Public Sub TestGetControleFromProd()

        WSCrodip.Init("http://admin.crodip.fr/server")
        Dim oagent = New Agent
        oagent.id = 1144
        oagent.numeroNational = "128"
        oagent.nom = "CHAPON"
        oagent.prenom = "KEVIN"
        oagent.dateDerniereSynchro = "2018-05-17 14:51:00"
        agentCourant = oagent

        Dim oExploit As Exploitation
        oExploit = ExploitationManager.getWSExploitationById(1144, "5-1144-100")
        Assert.AreEqual("5-1144-100", oExploit.id)
        ExploitationManager.save(oExploit, oagent)

        Dim oPulve As Pulverisateur

        oPulve = PulverisateurManager.getWSPulverisateurById(oagent.id, "5-1144-241")
        Assert.AreEqual("5-1144-241", oPulve.id)
        PulverisateurManager.save(oPulve, oExploit.id, oagent)

        Dim oDiag As Diagnostic
        oDiag = DiagnosticManager.getWSDiagnosticById(128, "5-1144-687")
        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticItemManager.getWSDiagnosticItemsByDiagnosticId(oagent, "5-1144-687")

        DiagnosticManager.save(oDiag)

        oDiag = DiagnosticManager.getDiagnosticById(oDiag.id)



        Assert.AreEqual("5-1144-687", oDiag.id)

        Dim oEtat As New EtatRapportInspection(oDiag)
        Assert.IsTrue(oEtat.GenereEtat())

        oEtat.Open()



    End Sub
End Class