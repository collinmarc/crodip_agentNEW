Imports Crodip_agent
Public Class frmMain
    Private m_nIdDiagItem As Integer = 18000
    Private m_nIdExploitationToPulve As Integer = 1000
    Private Sub AddMsg(msg As String)
        ListBox1.Items.Add(msg)
        ListBox1.SelectedIndex = ListBox1.Items.Count - 1
        ListBox1.Refresh()
        System.IO.File.AppendAllText("./UpdateIdAgent.txt", msg)
        Console.Write(msg)

    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click

        Dim oCSDB As CSDb
        Dim oAgentList As AgentList
        Dim oAgent As Agent
        Dim oAgentSRV As Agent
        Dim OldID As Integer
        Dim NewId As Integer

        ListBox1.Items.Clear()
        oCSDB = New CSDb(True)
        If oCSDB.getConnection.State <> ConnectionState.Open Then
            AddMsg("Erreur en connection à la BD" & oCSDB.getConnection().ConnectionString)
            Exit Sub
        End If
        AddMsg("Connexion à la base de données OK")
        oAgentList = AgentManager.getAgentList()
        For Each oAgent In oAgentList.items
            AddMsg("Vérification de l'agent : " & oAgent.id & ":" & oAgent.nom)

            oAgentSRV = AgentManager.getWSAgentById(oAgent.numeroNational)
            AddMsg("AgentID = " & oAgent.id & "AgentID = " & oAgentSRV.id)
            If oAgent.id = oAgentSRV.id Then
                AddMsg("Pas de différence , on passe au suivant")
            Else
                OldID = oAgent.id
                NewId = oAgentSRV.id

                'UpdateAll(OldID, NewId)
            End If

        Next

    End Sub
    Private Sub UpdateAll(OldID As Integer, NewId As Integer, Optional pCode As Integer = 0)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader

        Me.Cursor = Cursors.WaitCursor
        oCmd = oCSDB.getConnection.CreateCommand()
        If pCode = 0 Or pCode = 1 Then
            'Maj des Id de Diagnostic
            oCmd.CommandText = "SELECT id FROM DIAGNOSTIC WHERE ID LIKE '%-" & OldID & "-%'"
            oRd = oCmd.ExecuteReader()
            If oRd.HasRows Then
                While oRd.Read
                    Dim sOldDiagId As String
                    sOldDiagId = oRd.GetString(0)
                    AddMsg("Mise a jour Diagnostic : " & sOldDiagId & "(" & OldID & "->" & NewId & ")")
                    UpdateDiagnostique(sOldDiagId, OldID, NewId)
                End While
            End If
            oRd.Close()
        End If

        If pCode = 0 Or pCode = 2 Then
            'Maj des pulverisateurs
            oCmd.CommandText = "SELECT id FROM pulverisateur WHERE ID LIKE '%-" & OldID & "-%'"
            oRd = oCmd.ExecuteReader()
            If oRd.HasRows Then
                While oRd.Read
                    Dim sOldPulveId As String
                    sOldPulveId = oRd.GetString(0)
                    AddMsg("Mise a jour Pulverisateur : " & sOldPulveId & "(" & OldID & "->" & NewId & ")")
                    UpdatePulverisateur(sOldPulveId, OldID, NewId)
                End While
            End If
            oRd.Close()
        End If

        If pCode = 0 Or pCode = 3 Then
            'Maj des Exploitation
            oCmd.CommandText = "SELECT id FROM Exploitation WHERE ID LIKE '%-" & OldID & "-%'"
            oRd = oCmd.ExecuteReader()
            If oRd.HasRows Then
                While oRd.Read
                    Dim sOldExploitId As String
                    sOldExploitId = oRd.GetString(0)
                    AddMsg("Mise a jour Exploitation : " & sOldExploitId & "(" & OldID & "->" & NewId & ")")
                    UpdateExploitation(sOldExploitId, OldID, NewId)
                End While
            End If
            oRd.Close()
        End If

        If pCode = 0 Or pCode = 4 Then

            'Maj des busesElatons
            oCmd.CommandText = "SELECT NumeroNational FROM AgentBuseEtalon WHERE NumeroNational LIKE '%-" & OldID & "-%'"
            oRd = oCmd.ExecuteReader()
            If oRd.HasRows Then
                While oRd.Read
                    Dim sOldBuseId As String
                    sOldBuseId = oRd.GetString(0)
                    AddMsg("Mise a jour Buses : " & sOldBuseId & "(" & OldID & "->" & NewId & ")")
                    UpdateBusesEtalons(sOldBuseId, OldID, NewId)
                End While
            End If
            oRd.Close()
        End If

        If pCode = 0 Or pCode = 5 Then
            'Maj des ManoContrles
            oCmd.CommandText = "SELECT NumeroNational FROM AgentManoControle WHERE NumeroNational LIKE '%-" & OldID & "-%'"
            oRd = oCmd.ExecuteReader()
            If oRd.HasRows Then
                While oRd.Read
                    Dim sOldManoId As String
                    sOldManoId = oRd.GetString(0)
                    AddMsg("Mise a jour ManoControle : " & sOldManoId & "(" & OldID & "->" & NewId & ")")
                    UpdateManoControle(sOldManoId, OldID, NewId)
                End While
            End If
            oRd.Close()
        End If

        If pCode = 0 Or pCode = 6 Then
            'Maj des ManoEtalon
            oCmd.CommandText = "SELECT NumeroNational FROM AgentManoEtalon WHERE NumeroNational LIKE '%-" & OldID & "-%'"
            oRd = oCmd.ExecuteReader()
            If oRd.HasRows Then
                While oRd.Read
                    Dim sOldManoId As String
                    sOldManoId = oRd.GetString(0)
                    AddMsg("Mise a jour ManoEtalon : " & sOldManoId & "(" & OldID & "->" & NewId & ")")
                    UpdateManoEtalon(sOldManoId, OldID, NewId)
                End While
            End If
            oRd.Close()
        End If

        If pCode = 0 Or pCode = 7 Then
            'Maj des ControleBancMesures
            oCmd.CommandText = "SELECT id FROM ControleBancMesure WHERE id LIKE '%-" & OldID & "-%'"
            oRd = oCmd.ExecuteReader()
            If oRd.HasRows Then
                While oRd.Read
                    Dim sOldManoId As String
                    sOldManoId = oRd.GetString(0)
                    AddMsg("Mise a jour ControleBancMEsure : " & sOldManoId & "(" & OldID & "->" & NewId & ")")
                    UpdateControleBancMesure(sOldManoId, OldID, NewId)
                End While
            End If
            oRd.Close()
        End If
        If pCode = 0 Or pCode = 8 Then
            'Maj des ControleReguliers
            AddMsg("Mise à jour des controle reguliers")
            UpdateControleRegulier(OldID, NewId)
            'oRd.Close()
        End If
        If pCode = 0 Or pCode = 9 Then
            'Maj des FichesVies
            AddMsg("Mise à jour des Fiches de vies")
            UpdateFichesVies(OldID, NewId)
            'oRd.Close()
        End If
        If pCode = 0 Or pCode = 10 Then
            'Maj des Agents
            AddMsg("Mise à jour de l'agent")
            UpdateAgent(OldID, NewId)
            'oRd.Close()
        End If
        AddMsg("Mise à jour Terminée")
        oCSDB.free()
        Me.Cursor = Cursors.Default

    End Sub
    Private Sub UpdateAgent(nOldAgentId As Integer, nNewAgentID As Integer)

        Dim oAgentSRV As Agent
        Dim oAgent As Agent

        'Charegement de l'agent
        oAgent = AgentManager.getAgentById(nOldAgentId)
        'Récupération de l'agent depuis le SRV
        oAgentSRV = AgentManager.getWSAgentById(oAgent.numeroNational)
        'Sauevgarde de l'agent Serveur
        AgentManager.save(oAgentSRV)

    End Sub
    Private Sub UpdateFichesVies(nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader
        Dim n As Integer
        Dim nNewId As Integer
        Dim tabId As String()
        Dim snewId As String
        Dim sOldId As String


        'FicheVieBancMesure
        '======================================
        'Récupération de l'Id Max avec le nouvel Id
        nNewId = 0
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "SELECT ID from FicheVieBancMesure WHERE ID LIKE '%-" & nNewAgentID & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nNewId Then
                nNewId = n
            End If
        End While
        oRd.Close()
        nNewId = nNewId + 1
        Console.WriteLine("NNewId = " & nNewId)

        oCmd = oCSDB.getConnection().CreateCommand()
        oCmd.CommandText = "SELECT id FROM  FicheVieBancMesure WHERE Id Like '%-" & nOldAgentId & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            snewId = tabId(0) & "-" & nNewAgentID & "-" & nNewId
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE FicheVieBancMesure SET ID = '" & sNewId & "', idAgentControleur = " & nNewAgentID & ", dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where ID = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
            nNewId = nNewId + 1
        End While
        oRd.Close()

        'FicheVieManometreControle Id+idAgentControleur
        '======================================
        'Récupération de l'Id Max avec le nouvel Id
        nNewId = 0
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "SELECT ID from FicheVieManometreControle WHERE ID LIKE '%-" & nNewAgentID & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nNewId Then
                nNewId = n
            End If
        End While
        oRd.Close()
        nNewId = nNewId + 1

        oCmd.CommandText = "SELECT id FROM  FicheVieManometreControle WHERE Id Like '%-" & nOldAgentId & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            snewId = tabId(0) & "-" & nNewAgentID & "-" & nNewId
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE FicheVieManometreControle SET ID = '" & sNewId & "', idAgentControleur = " & nNewAgentID & ", dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where ID = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
            nNewId = nNewId + 1
        End While
        oRd.Close()

        'FicheVieManometreEtalon Id+idAgentControleur
        'Récupération de l'Id Max avec le nouvel Id
        nNewId = 0
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "SELECT ID from FicheVieManometreEtalon WHERE ID LIKE '%-" & nNewAgentID & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nNewId Then
                nNewId = n
            End If
        End While
        oRd.Close()
        nNewId = nNewId + 1

        oCmd.CommandText = "SELECT id FROM  FicheVieManometreEtalon WHERE Id Like '%-" & nOldAgentId & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            snewId = tabId(0) & "-" & nNewAgentID & "-" & nNewId
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE FicheVieManometreEtalon SET ID = '" & sNewId & "', idAgentControleur = " & nNewAgentID & ", dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where ID = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
            nNewId = nNewId + 1
        End While
        oRd.Close()

        oCSDB.free()
    End Sub

    Private Sub UpdateControleRegulier(nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader

        Dim tabId As String()
        Dim sNewManoId As String


        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE Controle_Regulier SET ctrg_numagent = '" & nNewAgentID & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  ctrg_numagent = '" & nOldAgentId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()


        oCSDB.free()
    End Sub
    Private Sub UpdateControleBancMesure(sOldManoId As String, nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader

        Dim tabId As String()
        Dim sNewManoId As String
        Dim oMano As ManometreEtalon
        Dim nNewID As Integer
        Dim n As Integer

        tabId = Split(sOldManoId, "-", -1)

        'Récupération de l'Id Max avec le nouvel Id
        nNewId = 0
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "SELECT ID from ControleBancMesure WHERE ID LIKE '%-" & nNewAgentID & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nNewId Then
                nNewId = n
            End If
        End While
        oRd.Close()
        nNewId = nNewId + 1

        'Reconstruction de l'Id 
        sNewManoId = tabId(0) & "-" & nNewAgentID & "-" & nNewID


        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE ControleBancMesure SET id = '" & sNewManoId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  id = '" & sOldManoId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()


        oCSDB.free()
    End Sub
    Private Sub UpdateManoEtalon(sOldManoId As String, nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader

        Dim tabId As String()
        Dim sNewManoId As String
        Dim oMano As ManometreEtalon
        tabId = Split(sOldManoId, "-", -1)
        'Reconstruction de l'Id 
        sNewManoId = tabId(0) & "-" & nNewAgentID & "-" & tabId(2)

        oMano = ManometreEtalonManager.getManometreEtalonByNumeroNational(sNewManoId)
        If oMano.numeroNational = sNewManoId Then
            AddMsg("Erreur il existe déjà une Mano Etalon  " & sNewManoId)
            Exit Sub
        End If

        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE AgentManoEtalon SET numeroNational = '" & sNewManoId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  numeroNational = '" & sOldManoId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        'ControleAgentMano => Table inutilisée

        'ControleManoMesure IdMano
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE ControleManoMesure SET ManoEtalon = '" & sNewManoId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  ManoEtalon = '" & sOldManoId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()

        'FicheVieManomètreEtalon IdManometre
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE FicheVieManometreEtalon SET IdManometre = '" & sNewManoId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  IdManometre = '" & sOldManoId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()

        oCSDB.free()
    End Sub
    Private Sub UpdateManoControle(sOldManoId As String, nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader
        Dim sId As String
        Dim nId As Integer = 0
        Dim tabId As String()
        Dim sNewManoId As String
        Dim oMano As ManometreControle
        Dim sracine As String
        Dim n As Integer


        'Recherche du numéro Max
        tabId = Split(sOldManoId, "-", -1)
        sId = ""
        nId = 1
        oCmd = oCSDB.getConnection.CreateCommand()
        sRacine = tabId(0) & "-" & nNewAgentID & "-"
        oCmd.CommandText = "SELECT numeroNational from AgentManoControle WHERE numeroNational LIKE '" & sracine & "%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nId Then
                nId = n
            End If
        End While
        oRd.Close()
        nId = nId + 1
        sNewManoId = sracine & nId
        AddMsg("AgentManoControle New = " & sNewManoId)



        oMano = ManometreControleManager.getManometreControleByNumeroNational(sNewManoId)
        If oMano.numeroNational = sNewManoId Then
            AddMsg("Erreur il existe déjà une Mano de controle  " & sNewManoId)
            Exit Sub
        End If

        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE AgentManoControle SET numeroNational = '" & sNewManoId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  numeroNational = '" & sOldManoId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        'ControleAgentMano => Table inutilisée


        'ControleManoMesure IdMano
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE ControleManoMesure SET idMano = '" & sNewManoId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  idMano = '" & sOldManoId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()

        'Recherche de l'ID MAx sur controle ManoMesure
        'Recherche du numéro Max
        tabId = Split(sOldManoId, "-", -1)
        sId = ""
        nId = 1
        oCmd = oCSDB.getConnection.CreateCommand()
        sracine = tabId(0) & "-" & nNewAgentID & "-"
        oCmd.CommandText = "SELECT ID from ControleManoMesure WHERE id LIKE '" & sracine & "%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nId Then
                nId = n
            End If
        End While
        oRd.Close()
        nId = nId + 1
        sNewManoId = sracine & nId
        AddMsg("ControleManoMesure New = " & sNewManoId)
        'ControleManoMesure Id
        oCmd.CommandText = "SELECT id FROM  ControleManoMesure WHERE Id Like '%-" & nOldAgentId & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            Dim sOldId As String
            Dim sNewId As String
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            sNewId = tabId(0) & "-" & nNewAgentID & "-" & nId
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE ControleManoMesure SET ID = '" & sNewId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where ID = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
            nId = nId + 1
        End While
        oRd.Close()

        'FicheVieBancMesure : IdManometreControle
        'ControleManoMesure Id
        oCmd.CommandText = "SELECT idManometreControle FROM  FicheVieBancMesure WHERE idManometreControle = '" & sOldManoId & "'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            Dim sOldId As String
            Dim sNewId As String
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            sNewId = tabId(0) & "-" & nNewAgentID & "-" & tabId(2)
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE FicheVieBancMesure SET idManometreControle = '" & sNewId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where idManometreControle = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
        End While
        oRd.Close()

        'FichevieManometreControle : idManometreControleur
        'ControleManoMesure Id
        oCmd.CommandText = "SELECT idManometreControleur FROM  FichevieManometreControle WHERE idManometreControleur = '" & sOldManoId & "'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            Dim sOldId As String
            Dim sNewId As String
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            sNewId = tabId(0) & "-" & nNewAgentID & "-" & tabId(2)
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE FichevieManometreControle SET idManometreControleur = '" & sNewId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where idManometreControleur = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
        End While
        oRd.Close()

        'FichevieManometreEtalon : idManometreControleur
        'ControleManoMesure Id
        oCmd.CommandText = "SELECT idManometreControleur FROM  FichevieManometreEtalon WHERE idManometreControleur = '" & sOldManoId & "'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            Dim sOldId As String
            Dim sNewId As String
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            sNewId = tabId(0) & "-" & nNewAgentID & "-" & tabId(2)
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE FichevieManometreEtalon SET idManometreControleur = '" & sNewId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where idManometreControleur = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
        End While
        oRd.Close()
        oCSDB.free()
    End Sub
    Private Sub UpdateBusesEtalons(sOldBuseId As String, nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader
        Dim tabId As String()
        Dim sNewBuseId As String
        Dim oBuse As Buse
        Dim nId As Integer
        Dim sracine As String
        Dim n As Integer

        tabId = Split(sOldBuseId, "-", -1)
        'Reconstruction de l'Id 
        'Reconstruction de l'Id 
        sNewBuseId = ""
        nId = 1
        oCmd = oCSDB.getConnection.CreateCommand()
        sRacine = tabId(0) & "-" & nNewAgentID & "-"
        oCmd.CommandText = "SELECT NumeroNational from AgentBuseEtalon WHERE NumeroNational LIKE '" & sRacine & "%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nId Then
                nId = n
            End If
        End While
        oRd.Close()
        nId = nId + 1
        sNewBuseId = sracine & nId
        AddMsg("AgentBuseEtalon OLD=" & sOldBuseId & "New = " & sNewBuseId)


        oBuse = BuseManager.getBuseByNumeroNational(sNewBuseId)
        If oBuse.numeroNational = sNewBuseId Then
            AddMsg("Erreur il existe déjà une Buse " & sNewBuseId)
            Exit Sub
        End If

        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE AgentBuseEtalon SET NumeroNational = '" & sNewBuseId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  NumeroNational = '" & sOldBuseId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()

        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE ControleBancMesure SET buse1 = '" & sNewBuseId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  buse1 = '" & sOldBuseId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE ControleBancMesure SET buse2 = '" & sNewBuseId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  buse2 = '" & sOldBuseId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE ControleBancMesure SET buse3 = '" & sNewBuseId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  buse3 = '" & sOldBuseId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE ControleBancMesure SET buse4 = '" & sNewBuseId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  buse4 = '" & sOldBuseId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE ControleBancMesure SET buse5 = '" & sNewBuseId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  buse5 = '" & sOldBuseId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE ControleBancMesure SET buse6 = '" & sNewBuseId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  buse6 = '" & sOldBuseId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()

        'FicheVieBancMesure : IdBuseEtalon
        'ControleManoMesure Id
        oCmd.CommandText = "SELECT idBuseEtalon FROM  FicheVieBancMesure WHERE idBuseEtalon = '" & sOldBuseId & "'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            Dim sOldId As String
            Dim sNewId As String
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            sNewId = tabId(0) & "-" & nNewAgentID & "-" & tabId(2)
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE FicheVieBancMesure SET idBuseEtalon = '" & sNewId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where idBuseEtalon = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
        End While
        oRd.Close()

        oCSDB.free()
    End Sub
    Private Sub UpdateExploitation(sOldExploitationId As String, nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim oRd As OleDb.OleDbDataReader
        Dim tabId As String()
        Dim sNewExploitationId As String
        Dim sRacineId As String
        Dim oExploit As Exploitation
        Dim nId As Integer
        Dim bFound As Boolean
        Dim sRacine As String
        Dim n As Integer

        tabId = Split(sOldExploitationId, "-", -1)
        'Reconstruction de l'Id 
        sNewExploitationId = ""
        nId = 1
        bFound = True
        oCmd = oCSDB.getConnection.CreateCommand()
        sRacine = tabId(0) & "-" & nNewAgentID & "-"
        oCmd.CommandText = "SELECT ID from EXPLOITATION WHERE ID LIKE '" & sRacine & "%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nId Then
                nId = n
            End If
        End While
        oRd.Close()
        nId = nId + 1
        sNewExploitationId = sRacine & nId
        AddMsg("Exploitation OLD=" & sOldExploitationId & "New = " & sNewExploitationId)

        oExploit = getClientById(sNewExploitationId)
        If oExploit.id = sNewExploitationId Then
            AddMsg("Erreur il existe déjà une Exploitation " & sNewExploitationId)
            Exit Sub
        End If

        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE EXPLOITATION SET id = '" & sNewExploitationId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  id = '" & sOldExploitationId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE DIAGNOSTIC SET proprietaireId = '" & sNewExploitationId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  proprietaireId = '" & sOldExploitationId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE ExploitationToPulverisateur SET idExploitation = '" & sNewExploitationId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  idExploitation = '" & sOldExploitationId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "SELECT id FROM  ExploitationToPulverisateur WHERE Id Like '%-" & nOldAgentId & "-%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            Dim sOldId As String
            Dim sNewId As String
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            sNewId = tabId(0) & "-" & nNewAgentID & "-" & m_nIdExploitationToPulve
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE ExploitationToPulverisateur SET ID = '" & sNewId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where ID = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            oCmd2.ExecuteNonQuery()
            m_nIdExploitationToPulve = m_nIdExploitationToPulve + 1
        End While
        oRd.Close()
        oCSDB.free()
    End Sub
    Private Sub UpdatePulverisateur(sOldPulveId As String, nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim tabId As String()
        Dim sNewPulveId As String
        Dim sRacine As String
        Dim oPulve As Pulverisateur
        Dim oRd As OleDb.OleDbDataReader = Nothing
        Dim bFound As Boolean
        Dim nId As Integer
        Dim n As Integer

        tabId = Split(sOldPulveId, "-", -1)
        'Reconstruction de l'Id du Pulverisateur

        sNewPulveId = ""
        nId = 1
        bFound = True
        oCmd = oCSDB.getConnection.CreateCommand()
        sRacine = tabId(0) & "-" & nNewAgentID & "-"
        oCmd.CommandText = "SELECT ID from PULVERISATEUR WHERE ID LIKE '" & sRacine & "%'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            n = CInt(Split(oRd.GetString(0), "-")(2))
            If n > nId Then
                nId = n
            End If
        End While
        oRd.Close()
        nId = nId + 1
        sNewPulveId = sRacine & nId
        AddMsg("Pulverisateur OLD=" & sOldPulveId & "New = " & sNewPulveId)
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE PULVERISATEUR SET id = '" & sNewPulveId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  id = '" & sOldPulveId & "'"
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE ExploitationToPulverisateur SET idPulverisateur = '" & sNewPulveId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  idPulverisateur = '" & sOldPulveId & "'"
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE DIAGNOSTIC SET pulverisateurId = '" & sNewPulveId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  PulverisateurId = '" & sOldPulveId & "'"
        oCmd.ExecuteNonQuery()
        oCSDB.free()
    End Sub
    Private Sub UpdateDiagnostique(sOldDiagId As String, nOldAgentId As Integer, nNewAgentID As Integer)
        Dim oCSDB As New CSDb(True)
        Dim oCmd As OleDb.OleDbCommand
        Dim tabId As String()
        Dim sNewDiagId As String
        Dim sRacineDiag As String
        Dim oRd As OleDb.OleDbDataReader
        Dim bFound As Boolean
        Dim nId As Integer
        tabId = Split(sOldDiagId, "-", -1)
        'Reconstruction de l'Id du Diagnostic
        If String.IsNullOrEmpty(tabId(2)) Then
            nId = 10
        Else
            nId = tabId(2)
        End If
        sNewDiagId = ""
        bFound = True
        oCmd = oCSDB.getConnection.CreateCommand()
        '        While bFound
        sRacineDiag = tabId(0) & "-" & nNewAgentID & "-"
        oCmd.CommandText = " SELECT MAX (CINT(Mid(Diagnostic.id," & sRacineDiag.Length + 1 & "))) as N FROM DIAGNOSTIC WHERE ID LIKE '" & tabId(0) & "-" & nNewAgentID & "-%'"
        Console.WriteLine(oCmd.CommandText)
        oRd = oCmd.ExecuteReader()
        oRd.Read()
        nId = oRd.GetValue(0)
        nId = nId + 1
        sNewDiagId = tabId(0) & "-" & nNewAgentID & "-" & nId
        '            If nb > 0 Then
        'bFound = True
        'nId = nId + 1
        'Else
        'bFound = False
        'End If
        oRd.Close()
        'End While
        AddMsg("Diagnostic OLD=" & sOldDiagId & "New = " & sNewDiagId)
        oCmd = oCSDB.getConnection.CreateCommand()
        oCmd.CommandText = "UPDATE DIAGNOSTIC SET id = '" & sNewDiagId & "', inspecteurId = '" & nNewAgentID & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  id = '" & sOldDiagId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE DIAGNOSTICBUSES SET IdDiagnostic = '" & sNewDiagId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  IdDiagnostic = '" & sOldDiagId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE DIAGNOSTICBUSESDETAIL SET IdDiagnostic = '" & sNewDiagId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  IdDiagnostic = '" & sOldDiagId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE DIAGNOSTICMano542 SET IdDiagnostic = '" & sNewDiagId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  IdDiagnostic = '" & sOldDiagId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "UPDATE DIAGNOSTICTroncons833 SET IdDiagnostic = '" & sNewDiagId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  IdDiagnostic = '" & sOldDiagId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        'DiagnosticItem
        oCmd.CommandText = "UPDATE DIAGNOSTICItem SET IdDiagnostic = '" & sNewDiagId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where  IdDiagnostic = '" & sOldDiagId & "'"
        AddMsg(oCmd.CommandText)
        oCmd.ExecuteNonQuery()
        oCmd.CommandText = "SELECT id FROM  DIAGNOSTICItem WHERE IdDiagnostic = '" & sNewDiagId & "'"
        oRd = oCmd.ExecuteReader()
        While oRd.Read()
            Dim sOldId As String
            Dim sNewId As String
            sOldId = oRd.GetString(0)
            tabId = Split(sOldId, "-", -1)
            sNewId = tabId(0) & "-" & nNewAgentID & "-" & m_nIdDiagItem
            Dim oCmd2 As OleDb.OleDbCommand
            oCmd2 = oCSDB.getConnection().CreateCommand()
            oCmd2.CommandText = "UPDATE DiagnosticItem SET ID = '" & sNewId & "', dateModificationAgent = '" & CSDate.access2mysql(Date.Now).ToString & "' where ID = '" & sOldId & "'"
            AddMsg(oCmd2.CommandText)
            Try

                oCmd2.ExecuteNonQuery()
            Catch ex As Exception
                AddMsg(ex.Message)
            End Try
            m_nIdDiagItem = m_nIdDiagItem + 1
        End While
        oRd.Close()
        oCSDB.free()

    End Sub
#Region "Methodes recopiée de ClientManager car il est resté en Module"
    Public Function getClientById(ByVal client_id As String)
        ' déclarations
        Dim tmpClient As New Exploitation
        If client_id <> "" Then

            'Dim bddCommande As New OleDb.OleDbCommand
            '' On test si la connexion est déjà ouverte ou non
            'If bddConnection.State() = 0 Then
            '    ' Si non, on la configure et on l'ouvre
            '    bddConnection.ConnectionString = bddConnectString
            '    bddConnection.Open()
            'End If
            'bddCommande.Connection = bddConnection
            'bddCommande.CommandText = "SELECT * FROM Exploitation WHERE Exploitation.id='" & client_id & "'"
            Dim bdd As New CSDb(True)
            Try
                ' On récupère les résultats
                'Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bdd.getResults("SELECT * FROM Exploitation WHERE Exploitation.id='" & client_id & "'")
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        FillClient(tmpClient, tmpListProfils, tmpColId)
                        tmpColId = tmpColId & 1
                    End While
                End While
            Catch ex As Exception ' On intercepte l'erreur
                'CSDebug.dispFatal("ClientManager - getbyid : " & ex.Message)
            End Try

            ' Test pour fermeture de connection BDD
            'If bddConnection.State() <> 0 Then
            '    ' On ferme la connexion
            '    bddConnection.Close()
            'End If
            bdd.free()

        End If
        'on retourne le client ou un objet vide en cas d'erreur
        Return tmpClient
    End Function

    Private Sub FillClient(tmpClient As Exploitation, tmpListProfils As OleDb.OleDbDataReader, tmpColId As Integer)
        Select Case tmpListProfils.GetName(tmpColId)
            Case "id"
                tmpClient.id = tmpListProfils.Item(tmpColId).ToString()
            Case "numeroSiren"
                tmpClient.numeroSiren = tmpListProfils.Item(tmpColId).ToString()
            Case "codeApe"
                tmpClient.codeApe = tmpListProfils.Item(tmpColId).ToString()
            Case "raisonSociale"
                tmpClient.raisonSociale = tmpListProfils.Item(tmpColId).ToString()
            Case "nombreExploitant"
                tmpClient.nombreExploitant = tmpListProfils.Item(tmpColId)
            Case "nomExploitant"
                tmpClient.nomExploitant = tmpListProfils.Item(tmpColId).ToString()
            Case "prenomExploitant"
                tmpClient.prenomExploitant = tmpListProfils.Item(tmpColId).ToString()
            Case "adresse"
                tmpClient.adresse = tmpListProfils.Item(tmpColId).ToString()
            Case "codePostal"
                tmpClient.codePostal = tmpListProfils.Item(tmpColId).ToString()
            Case "commune"
                tmpClient.commune = tmpListProfils.Item(tmpColId).ToString()
            Case "codeInsee"
                tmpClient.codeInsee = tmpListProfils.Item(tmpColId).ToString()
            Case "telephoneFixe"
                tmpClient.telephoneFixe = tmpListProfils.Item(tmpColId).ToString()
            Case "telephonePortable"
                tmpClient.telephonePortable = tmpListProfils.Item(tmpColId).ToString()
            Case "telephoneFax"
                tmpClient.telephoneFax = tmpListProfils.Item(tmpColId).ToString()
            Case "eMail"
                tmpClient.eMail = tmpListProfils.Item(tmpColId).ToString()
            Case "isProdGrandeCulture"
                tmpClient.isProdGrandeCulture = tmpListProfils.Item(tmpColId).ToString()
            Case "isProdElevage"
                tmpClient.isProdElevage = tmpListProfils.Item(tmpColId).ToString()
            Case "isProdArboriculture"
                tmpClient.isProdArboriculture = tmpListProfils.Item(tmpColId).ToString()
            Case "isProdLegume"
                tmpClient.isProdLegume = tmpListProfils.Item(tmpColId).ToString()
            Case "isProdViticulture"
                tmpClient.isProdViticulture = tmpListProfils.Item(tmpColId).ToString()
            Case "isProdAutre"
                tmpClient.isProdAutre = tmpListProfils.Item(tmpColId).ToString()
            Case "productionAutre"
                tmpClient.productionAutre = tmpListProfils.Item(tmpColId).ToString()
            Case "idStructure"
                tmpClient.idStructure = tmpListProfils.Item(tmpColId)
            Case "isSupprime"
                tmpClient.isSupprime = tmpListProfils.Item(tmpColId).ToString()
            Case "dateModificationAgent"
                tmpClient.dateModificationAgent = CSDate.access2mysql(tmpListProfils.Item(tmpColId).ToString())
            Case "dateModificationCrodip"
                tmpClient.dateModificationCrodip = CSDate.access2mysql(tmpListProfils.Item(tmpColId).ToString())
            Case "dateDernierControle"
                tmpClient.dateDernierControle = CSDate.access2mysql(tmpListProfils.Item(tmpColId).ToString())
            Case "surfaceAgricoleUtile"
                tmpClient.surfaceAgricoleUtile = tmpListProfils.Item(tmpColId).ToString()
        End Select

    End Sub
#End Region

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged
        GroupBox1.Enabled = CheckBox1.Checked
    End Sub

    Private Sub btnTest_Click_1(sender As System.Object, e As System.EventArgs) Handles btnTest.Click
        Dim OldID As Integer
        Dim NewId As Integer
        Dim nCode As Integer

        ListBox1.Items.Clear()
        OldID = tbOldId.Text
        NewId = tbNewId.Text
        nCode = tbCode.Text

        UpdateAll(OldID, NewId, nCode)

    End Sub
End Class
