Imports System.Collections.Generic
Public Class PulverisateurManager

#Region "Methodes acces Web Service"

    Public Shared Function getWSPulverisateurById(pAgent As Agent, ByVal pulverisateur_id As String) As Pulverisateur
        Dim objPulverisateur As New Pulverisateur
        Try

            ' déclarations
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            objWSCrodip.Timeout = 10000
            Dim objWSCrodip_response As New Object
            ' Appel au WS
            Dim codeResponse As Integer = objWSCrodip.GetPulverisateur(pAgent.id, pulverisateur_id, objWSCrodip_response)
            Select Case codeResponse
                Case 0 ' OK
                    ' construction de l'objet
                    Dim objWSCrodip_responseItem As System.Xml.XmlNode
                    For Each objWSCrodip_responseItem In objWSCrodip_response
                        If objWSCrodip_responseItem.InnerText() <> "" Then
                            objPulverisateur.Fill(objWSCrodip_responseItem.Name(), objWSCrodip_responseItem.InnerText())
                        End If
                    Next
                Case 1 ' NOK
                    CSDebug.dispError("Erreur - PulverisateurManager - Code 1 : Non-Trouvée")
                Case 9 ' BADREQUEST
                    CSDebug.dispError("Erreur - PulverisateurManager - Code 9 : Bad Request")
            End Select
        Catch ex As Exception
            CSDebug.dispError("Erreur - PulverisateurManager - getWSPulverisateurById (" & pulverisateur_id & "): " & ex.Message)
            objPulverisateur = Nothing
        End Try
        Return objPulverisateur

    End Function

    Public Shared Function sendWSPulverisateur(pAgent As Agent, ByVal pulverisateur As Pulverisateur) As Integer
        Try
            Dim updatedObject As New Object
            ' Appel au Web Service
            Dim objWSCrodip As WSCrodip_prod.CrodipServer = WSCrodip.getWS()
            Return objWSCrodip.SendPulverisateur(pAgent.id, pulverisateur, updatedObject)
        Catch ex As Exception
            Return -1
        End Try
    End Function

    Public Shared Function xml2object(ByVal arrXml As Object) As Pulverisateur
        Dim objPulverisateur As New Pulverisateur

        For Each tmpSerializeItem As System.Xml.XmlElement In arrXml
            If tmpSerializeItem.InnerText() <> "" Then
                objPulverisateur.Fill(tmpSerializeItem.Name(), tmpSerializeItem.InnerText())
            End If
        Next

        Return objPulverisateur
    End Function

#End Region

#Region "Methodes acces Local"

    Public Shared Function isAlerte(ByVal pulverisateur_id As String) As Boolean
        Dim ncontrole As Integer
        Dim oCSDB As New CSDb(True)
        If pulverisateur_id <> "" Then
            Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT count(*) FROM Diagnostic WHERE Diagnostic.controleEtat=0 AND Diagnostic.pulverisateurId='" & pulverisateur_id & "'"
            Try
                ' On récupère les résultats
                Dim tmpListResults As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                While tmpListResults.Read()
                    ncontrole = tmpListResults.GetInt32(0)
                End While
                tmpListResults.Close()
            Catch ex As Exception ' On intercepte l'erreur
                ncontrole = 0
            End Try
        End If
        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return (ncontrole <> 0)
    End Function
    ''' <summary>
    ''' Renvoie un nouvel id pour un pulvérisateur en fonction de l'agent
    ''' </summary>
    ''' <param name="curAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getNewId(ByVal curAgent As Agent) As String
        ' déclarations
        Dim tmpPulveId As String = ""
        Dim oCsdb As CSDb = Nothing
        If Not curAgent.numeroNational Is Nothing Then
            oCsdb = New CSDb(True)
            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT `Pulverisateur`.`id` FROM `Pulverisateur` WHERE `Pulverisateur`.`id` LIKE '" & curAgent.idStructure & "-" & curAgent.id & "-%' ORDER BY `Pulverisateur`.`id` DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpPulveId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpPulveId.Replace(curAgent.idStructure & "-" & curAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpPulveId = curAgent.idStructure & "-" & curAgent.id & "-" & (newId + 1)
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispFatal("PulverisateurManager - getNewId : " & ex.Message)
            End Try

            ' Test pour fermeture de connection BDD
            If Not oCsdb Is Nothing Then
                ' On ferme la connexion
                oCsdb.free()
            End If

        End If
        'on retourne le nouvel id
        Return tmpPulveId
    End Function

    ''' <summary>
    ''' Création d'un enregitrement de pulve ET de la relation ExploitToPulve
    ''' </summary>
    ''' <param name="pulve_id"></param>
    ''' <param name="client_id"></param>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function createPulve(ByVal poPulve As Pulverisateur, ByVal client_id As String, ByVal pAgent As Agent) As Boolean
        Debug.Assert(poPulve IsNot Nothing)
        Debug.Assert(Not String.IsNullOrEmpty(poPulve.id), "L'id du pulve doit être renseigné")
        Debug.Assert(poPulve.idStructure <> -1, "L'idStructure du pulve doit être renseigné")
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As OleDb.OleDbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO Pulverisateur (id, idStructure ) VALUES ('" & poPulve.id & "','" & poPulve.idStructure & "')"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            ExploitationTOPulverisateurManager.createExploitationTOPulverisateur(client_id, poPulve.id, pAgent)
            ' Test pour fermeture de connection BDD
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("PulverisateurManager - create : " & ex.Message)
            bReturn = False
        End Try
        If Not oCSDB Is Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If
        Return bReturn
    End Function

    Public Shared Function save(ByVal objPulverisateur As Pulverisateur, ByVal client_id As String, ByVal pAgent As Agent, Optional bSynchro As Boolean = False) As Boolean
        Debug.Assert(Not objPulverisateur Is Nothing)
        Debug.Assert(objPulverisateur.id <> "")
        Debug.Assert(client_id <> "")

        Dim bReturn As Boolean
        Dim bdd As New CSDb(True)
        Dim paramsQuery As String = ""
        Try
            bReturn = False
            If objPulverisateur.id <> "" Then

                ' On test si le Pulverisateur existe ou non
                Dim existsPulverisateur As Object
                existsPulverisateur = PulverisateurManager.getPulverisateurById(objPulverisateur.id)
                If existsPulverisateur.id = "" Then
                    createPulve(objPulverisateur, client_id, pAgent)
                End If

                Dim bddCommande As OleDb.OleDbCommand
                bddCommande = bdd.getConnection().CreateCommand()

                ' Initialisation de la requete
                paramsQuery = "`Pulverisateur`.`id`='" & objPulverisateur.id & "'"

                ' Mise a jour de la date de derniere modification
                If Not bSynchro Then
                    objPulverisateur.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not objPulverisateur.numeroNational Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`numeroNational`='" & objPulverisateur.numeroNational & "'"
                End If
                If Not objPulverisateur.type Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`type`='" & objPulverisateur.type & "'"
                End If
                If Not objPulverisateur.marque Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`marque`='" & CSDb.secureString(objPulverisateur.marque) & "'"
                End If
                If Not objPulverisateur.modele Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`modele`='" & CSDb.secureString(objPulverisateur.modele) & "'"
                End If
                If Not objPulverisateur.anneeAchat Is Nothing And objPulverisateur.anneeAchat <> "" Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`anneeAchat`='" & objPulverisateur.anneeAchat & "'"
                End If
                paramsQuery = paramsQuery & " , Pulverisateur.categorie='" & CSDb.secureString(objPulverisateur.categorie) & "'"
                If Not objPulverisateur.attelage Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`attelage`='" & CSDb.secureString(objPulverisateur.attelage) & "'"
                End If
                paramsQuery = paramsQuery & " , Pulverisateur.pulverisation='" & CSDb.secureString(objPulverisateur.pulverisation) & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`capacite`=" & objPulverisateur.capacite & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`largeur`='" & objPulverisateur.largeur & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`nombreRangs`='" & objPulverisateur.nombreRangs & "'"
                If Not objPulverisateur.largeurPlantation Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`largeurPlantation`='" & objPulverisateur.largeurPlantation & "'"
                End If
                If Not objPulverisateur.surfaceParAn Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`surfaceParAn`='" & objPulverisateur.surfaceParAn & "'"
                End If
                If Not objPulverisateur.nombreUtilisateurs Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`nombreUtilisateurs`='" & objPulverisateur.nombreUtilisateurs & "'"
                End If
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isVentilateur`=" & objPulverisateur.isVentilateur & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isDebrayage`=" & objPulverisateur.isDebrayage & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isCuveRincage`=" & objPulverisateur.isCuveRincage & ""
                If Not objPulverisateur.capaciteCuveRincage Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`capaciteCuveRincage`='" & objPulverisateur.capaciteCuveRincage & "'"
                End If
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isRotobuse`=" & objPulverisateur.isRotobuse & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isCuveIncorporation`=" & objPulverisateur.isCuveIncorporation & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isRinceBidon`=" & objPulverisateur.isRinceBidon & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isBidonLaveMain`=" & objPulverisateur.isBidonLaveMain & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isLanceLavage`=" & objPulverisateur.isLanceLavage & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`Regulation`='" & CSDb.secureString(objPulverisateur.regulation) & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`RegulationOptions`='" & CSDb.secureString(objPulverisateur.regulationOptions) & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`nombreBuses`=" & objPulverisateur.nombreBuses & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`buseIsIso`=" & objPulverisateur.buseIsIso & ""
                If Not objPulverisateur.buseMarque Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`buseMarque`='" & CSDb.secureString(objPulverisateur.buseMarque) & "'"
                End If
                If Not objPulverisateur.buseType Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`buseType`='" & CSDb.secureString(objPulverisateur.buseType) & "'"
                End If
                If Not objPulverisateur.buseFonctionnement Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`buseFonctionnement`='" & CSDb.secureString(objPulverisateur.buseFonctionnement) & "'"
                End If
                If Not objPulverisateur.buseAge = "" Then
                    'Le Champs BuseAge est stocké en boolean mais la prop est du String
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`buseAge`=" & objPulverisateur.buseAge & ""
                End If
                If Not objPulverisateur.buseAngle Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`buseAngle`='" & objPulverisateur.buseAngle & "'"
                End If
                If Not objPulverisateur.buseCouleur Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`buseCouleur`='" & objPulverisateur.buseCouleur & "'"
                End If
                If Not objPulverisateur.manometreMarque Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`manometreMarque`='" & CSDb.secureString(objPulverisateur.manometreMarque) & "'"
                End If
                If Not objPulverisateur.manometreType Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`manometreType`='" & CSDb.secureString(objPulverisateur.manometreType) & "'"
                End If
                If Not objPulverisateur.manometreFondEchelle Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`manometreFondEchelle`='" & objPulverisateur.manometreFondEchelle & "'"
                End If
                If Not objPulverisateur.manometreDiametre Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`manometreDiametre`='" & objPulverisateur.manometreDiametre & "'"
                End If
                If Not objPulverisateur.manometrePressionTravail Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`manometrePressionTravail`='" & objPulverisateur.manometrePressionTravail & "'"
                End If
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isSynchro`=" & objPulverisateur.isSynchro & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isSupprime`=" & objPulverisateur.isSupprime & ""
                If Not objPulverisateur.dateProchainControle Is Nothing And objPulverisateur.dateProchainControle <> "" And objPulverisateur.dateProchainControle <> "0000-00-00 00:00:00" Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`dateProchainControle`='" & objPulverisateur.dateProchainControle & "'"
                End If
                If Not objPulverisateur.dateModificationCrodip Is Nothing And objPulverisateur.dateModificationCrodip <> "" Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`dateModificationCrodip`='" & objPulverisateur.dateModificationCrodip & "'"
                End If
                If Not objPulverisateur.dateModificationAgent Is Nothing And objPulverisateur.dateModificationAgent <> "" Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`dateModificationAgent`='" & objPulverisateur.dateModificationAgent & "'"
                End If
                paramsQuery = paramsQuery & " , `Pulverisateur`.`idStructure`=" & objPulverisateur.idStructure & ""
                ' Emplacement Identification
                If Not objPulverisateur.emplacementIdentification Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`emplacementIdentification`='" & CSDb.secureString(objPulverisateur.emplacementIdentification) & "'"
                End If
                ' ancien Identifiant
                If Not objPulverisateur.ancienIdentifiant Is Nothing Then
                    paramsQuery = paramsQuery & " , `Pulverisateur`.`ancienIdentifiant`='" & CSDb.secureString(objPulverisateur.ancienIdentifiant) & "'"
                End If
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isEclairageRampe`=" & objPulverisateur.isEclairageRampe & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isBarreGuidage`=" & objPulverisateur.isBarreGuidage & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isCoupureAutoTroncons`=" & objPulverisateur.isCoupureAutoTroncons & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isRincageAutoAssiste`=" & objPulverisateur.isRincageAutoAssiste & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`buseModele`='" & objPulverisateur.buseModele & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`buseNbniveaux`=" & objPulverisateur.buseNbniveaux & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`manometreNbNiveaux`=" & objPulverisateur.manometreNbniveaux & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`manometreNbTroncons`=" & objPulverisateur.manometreNbtroncons & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`modeUtilisation`='" & CSDb.secureString(objPulverisateur.modeUtilisation) & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`nombreExploitants`='" & CSDb.secureString(objPulverisateur.nombreExploitants) & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`controleEtat`='" & CSDb.secureString(objPulverisateur.controleEtat) & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isAspirationExt`=" & objPulverisateur.isAspirationExt & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isDispoAntiRetour`=" & objPulverisateur.isDispoAntiRetour & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isReglageAutoHauteur`=" & objPulverisateur.isReglageAutoHauteur & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isFiltrationAspiration`=" & objPulverisateur.isFiltrationAspiration & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isFiltrationRefoulement`=" & objPulverisateur.isFiltrationRefoulement & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isFiltrationTroncons`=" & objPulverisateur.isFiltrationTroncons & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isFiltrationBuses`=" & objPulverisateur.isFiltrationBuses & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isPulveAdditionnel`=" & objPulverisateur.isPulveAdditionnel & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`pulvePrincipalNumNat`='" & CSDb.secureString(objPulverisateur.pulvePrincipalNumNat) & "'"
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isRincagecircuit`=" & objPulverisateur.isRincagecircuit & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`isPompesDoseuses`=" & objPulverisateur.isPompesDoseuses & ""
                paramsQuery = paramsQuery & " , `Pulverisateur`.`nbPompesDoseuses`=" & objPulverisateur.nbPompesDoseuses & ""

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE `Pulverisateur` SET " & paramsQuery & " WHERE `Pulverisateur`.`id`='" & objPulverisateur.id & "'"
                bddCommande.ExecuteNonQuery()

                ' Vérificatin du lien entre le pulvérisateur et l'exploitation
                Dim oExploit2Pulve As ExploitationTOPulverisateur
                If client_id <> "0" And client_id <> "" Then
                    oExploit2Pulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(client_id, objPulverisateur.id)
                    If String.IsNullOrEmpty(oExploit2Pulve.id) Then
                        'Création du lien
                        ExploitationTOPulverisateurManager.createExploitationTOPulverisateur(client_id, objPulverisateur.id, pAgent)
                        oExploit2Pulve = ExploitationTOPulverisateurManager.getExploitationTOPulverisateurByExploitIdAndPulverisateurId(client_id, objPulverisateur.id)
                    End If
                    'Validation du lien pour forcer la synchro
                    ExploitationTOPulverisateurManager.save(oExploit2Pulve, pAgent)
                End If
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispError("PulverisateurManager::save() : " & ex.Message.ToString)
            CSDebug.dispError("PulverisateurManager::save() : " & paramsQuery)
            bReturn = False
        End Try
        If Not bdd Is Nothing Then
            bdd.free()
        End If
        Return bReturn
    End Function

    Public Shared Sub setSynchro(ByVal objPulverisateur As Pulverisateur)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE `Pulverisateur` SET `Pulverisateur`.`dateModificationCrodip`='" & newDate & "',`Pulverisateur`.`dateModificationAgent`='" & newDate & "' WHERE `Pulverisateur`.`id`='" & objPulverisateur.id & "'"
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("PulverisateurManager::setSynchro : " & ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Lecture d'un Pulverisateur à partir de son Id
    ''' </summary>
    ''' <param name="pulverisateur_id"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPulverisateurById(ByVal pulverisateur_id As String) As Pulverisateur
        Return getPulverisateurSQL("SELECT * FROM Pulverisateur WHERE Pulverisateur.id='" & pulverisateur_id & "'")
    End Function

    ''' <summary>
    ''' Lecture d'un Pulverisateur à partir de son numéro national
    ''' Retourne le premier Element
    ''' </summary>
    ''' <param name="pNumNat">Numéro national</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPulverisateurByNumNat(ByVal pNumNat As String, pclientId As String) As Pulverisateur
        Return getPulverisateurSQL("SELECT p.* FROM Pulverisateur p, ExploitationTOPulverisateur p2e WHERE p2e.idPulverisateur= p.id and p.numeroNational='" & pNumNat & "' and p2e.idExploitation = '" & pclientId & "'")
    End Function
    ''' <summary>
    ''' Execution de la requete et retour udu pulvé associé
    ''' </summary>
    ''' <param name="pSQL"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function getPulverisateurSQL(ByVal pSQL As String) As Pulverisateur
        ' déclarations
        Dim tmpPulverisateur As New Pulverisateur
        Dim oCSDB As New CSDb(True)

        Dim bddCommande As OleDb.OleDbCommand
        bddCommande = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = pSQL
        Try
            ' On récupère les résultats
            Dim oDataReader As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            If oDataReader.HasRows() Then
                oDataReader.Read()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < oDataReader.FieldCount()
                    If Not oDataReader.IsDBNull(tmpColId) Then
                        tmpPulverisateur.Fill(oDataReader.GetName(tmpColId), oDataReader.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
            End If

            oDataReader.Close()
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager.getPulverisateurSQL Error: " & ex.Message)
        End Try


        ' Test pour fermeture de connection BDD
        If Not oCSDB Is Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If

        'on retourne le pulverisateur ou un objet vide en cas d'erreur
        Return tmpPulverisateur
    End Function


#Region " - Suppression - "
    Public Shared Function isUsedPulverisateur(ByVal pulverisateur_id As String) As Boolean
        Dim bReturn As Boolean
        Try

            ' On vérifie que le pulvé n'a pas servi dans un diag
            Dim query As String = "SELECT * FROM Diagnostic WHERE Diagnostic.pulverisateurId = '" & pulverisateur_id & "'"
            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(query)

            bReturn = dataResults.HasRows
            bdd.free()
            Return bReturn
        Catch ex As Exception
            CSDebug.dispError("PulverisateurManager.isUsedPulverisateur() : " & ex.Message)
            Return True
        End Try
    End Function
    ''' <summary>
    ''' Suppression d'un pulvérisateur qui n'as pas de diagnostic
    ''' </summary>
    ''' <param name="objPulve"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function deletePulverisateur(ByVal objPulve As Pulverisateur) As Boolean
        Dim bReturn As Boolean
        Try
            If Not PulverisateurManager.isUsedPulverisateur(objPulve.id) Then
                bReturn = deletePulverisateurID(objPulve.id)
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispFatal("PulverisateurManager.deletePulverisateur() : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Suppresssion du pulverisateur et du lien vers l'exploitation
    ''' </summary>
    ''' <param name="pPulveId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function deletePulverisateurID(ByVal pPulveId As String) As Boolean
        Try
            ' On supprime le Pulverisateur de la base
            Dim query As String = "DELETE FROM `Pulverisateur` WHERE Pulverisateur.id='" & pPulveId & "'"
            Dim bdd As New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(query)
            bdd.free()
            'Suppression de la relation vers les exploitations
            query = "DELETE FROM `ExploitationTOPulverisateur` WHERE `ExploitationTOPulverisateur`.`idPulverisateur`='" & pPulveId & "'"
            Dim bdd2 As New CSDb(True)
            Dim dataResults2 As System.Data.OleDb.OleDbDataReader = bdd2.getResult2s(query)
            bdd2.free()

            Return True
        Catch ex As Exception
            CSDebug.dispFatal("PulverisateurManager.deletePulverisateur() : " & ex.Message)
            Return False
        End Try
    End Function
#End Region

    ''' <summary>
    ''' Récupération des pulvérisateurs d'un client en fonction des droits de l'agent
    ''' </summary>
    ''' <param name="client_id">Identifiant du client</param>
    ''' <param name="pDroitsPulves">Droits de l'agent sur les types de pulvés (inutilisés en Version 4 Lot2)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPulverisateurByClientId(ByVal client_id As String, pDroitsPulves As String) As Pulverisateur()
        ' déclarations
        Dim arrItems(0) As Pulverisateur
        Dim oCSDB As New CSDb(True)
        If client_id <> "" Then

            Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT distinct Pulverisateur.* FROM Pulverisateur INNER JOIN (Exploitation INNER JOIN ExploitationTOPulverisateur ON Exploitation.id = ExploitationTOPulverisateur.idExploitation) ON Pulverisateur.id = ExploitationTOPulverisateur.idPulverisateur WHERE (((ExploitationTOPulverisateur.idExploitation)='" & client_id & "'))"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
                Dim i As Integer = 0
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpPulverisateur As New Pulverisateur
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        If Not tmpListProfils.IsDBNull(tmpColId) Then
                            tmpPulverisateur.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                        End If
                        tmpColId = tmpColId + 1
                    End While
                    If String.IsNullOrEmpty(pDroitsPulves) Then
                        arrItems(i) = tmpPulverisateur
                        i = i + 1
                        ReDim Preserve arrItems(i)
                    Else
                        If pDroitsPulves.ToUpper().Contains("|" & tmpPulverisateur.type.ToUpper() & "." & tmpPulverisateur.categorie.ToUpper() & "|") Or pDroitsPulves.ToUpper().Contains("|" & tmpPulverisateur.type.ToUpper() & "|") Or pDroitsPulves.ToUpper().Contains("|" & tmpPulverisateur.categorie.ToUpper() & "|") Then

                            arrItems(i) = tmpPulverisateur
                            i = i + 1
                            ReDim Preserve arrItems(i)
                        End If
                    End If
                End While
                ReDim Preserve arrItems(i - 1)
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("PulverisateurManager - getByClientId : " & ex.Message)
            End Try
            ' Test pour fermeture de connection BDD
            If Not oCSDB Is Nothing Then
                ' On ferme la connexion
                oCSDB.free()
            End If
        End If
        'on retourne le client ou un objet vide en cas d'erreur
        Return arrItems
    End Function

    ''' <summary>
    ''' Récupération des informayion d'une exploitation pour un pulvérisateur
    ''' </summary>
    ''' <param name="client_id">Identifiant du client</param>
    ''' <param name="pDroitsPulves">Droits de l'agent sur les types de pulvés (inutilisés en Version 4 Lot2)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getExploitationPulverisateurByPulve(ByVal pPulve As Pulverisateur) As Boolean
        Debug.Assert(pPulve IsNot Nothing)
        Debug.Assert(Not String.IsNullOrEmpty(pPulve.id))
        ' déclarations
        Dim bReturn As Boolean = False
        Dim oCSDB As New CSDb(True)

        Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT Pulverisateur.id, Exploitation.* " _
                                   & "FROM (ExploitationTOPulverisateur INNER JOIN Pulverisateur ON ExploitationTOPulverisateur.idPulverisateur = Pulverisateur.id) INNER JOIN Exploitation ON ExploitationTOPulverisateur.idExploitation = Exploitation.id " _
                                     & " WHERE pulverisateur.id = '" & pPulve.id & "'"

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        pPulve.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
            End While
            bReturn = True
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager - getExploitationPulverisateurByPulve : " & ex.Message)
            bReturn = False
        End Try
        ' Test pour fermeture de connection BDD
        If Not oCSDB Is Nothing Then
            ' On ferme la connexion
            oCSDB.free()
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Chargement de la Liste des pulvérisateurs d'une structure
    ''' </summary>
    ''' <param name="structure_id">N° de la Structure</param>
    ''' <param name="pDroitsPulves">Droits d'affichage (Vide = Tous)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function getPulverisateurList(ByVal pAgent As Agent, pDroitsPulves As String) As List(Of Pulverisateur)
        ' déclarations
        Dim oReturn As New List(Of Pulverisateur)

        Dim bdd As New CSDb(True)
        Try
            ' On récupère les résultats

            Dim strQuery As String = "SELECT Pulverisateur.*, Exploitation.raisonsociale, Exploitation.prenomExploitant, Exploitation.nomExploitant, Exploitation.codepostal,Exploitation.commune " _
                                     & " FROM (ExploitationTOPulverisateur INNER JOIN (Diagnostic RIGHT JOIN Pulverisateur ON Diagnostic.pulverisateurId = Pulverisateur.id) ON ExploitationTOPulverisateur.idPulverisateur = Pulverisateur.id) INNER JOIN Exploitation ON ExploitationTOPulverisateur.idExploitation = Exploitation.id "
            strQuery = strQuery & " WHERE "
            strQuery = strQuery & " (Diagnostic.controleDateFin = (SELECT Max(controleDateFin) from Diagnostic where Diagnostic.pulverisateurId = Pulverisateur.id) OR Diagnostic.controleDateFin IS NULL) "
            strQuery = strQuery & " AND pulverisateur.idStructure = " & pAgent.idStructure
            strQuery = strQuery & " ORDER BY  Pulverisateur.dateProchainControle ASC"
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bdd.getResult2s(strQuery)

            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpPulverisateur As New Pulverisateur
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    If Not tmpListProfils.IsDBNull(tmpColId) Then
                        tmpPulverisateur.Fill(tmpListProfils.GetName(tmpColId), tmpListProfils.Item(tmpColId))
                    End If
                    tmpColId = tmpColId + 1
                End While
                'Vérification que le type ou la catégorie du pulve sont dans les droits
                If String.IsNullOrEmpty(pDroitsPulves) Then
                    oReturn.Add(tmpPulverisateur)
                Else
                    If Not pDroitsPulves.StartsWith("|") Then
                        pDroitsPulves = "|" & pDroitsPulves & "|"
                    End If
                    If pDroitsPulves.ToUpper().Contains("|" & tmpPulverisateur.type.ToUpper() & "|") Or pDroitsPulves.ToUpper().Contains("|" & tmpPulverisateur.categorie.ToUpper() & "|") Then

                        oReturn.Add(tmpPulverisateur)
                    End If
                End If
            End While
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager - getListeOfPulverisateur : " & ex.Message)
        End Try
        bdd.free()
        'on retourne les pulvé
        Return oReturn
    End Function

    Public Shared Function getUpdates(ByVal agent As Agent) As Pulverisateur()
        ' déclarations
        Dim arrItems(0) As Pulverisateur
        Dim oCSdb As New CSDb(True)
        Dim bddCommande As OleDb.OleDbCommand = oCSdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Pulverisateur WHERE dateModificationAgent<>dateModificationCrodip "
        bddCommande.CommandText = bddCommande.CommandText & " AND idStructure=" & agent.idStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
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
                arrItems(i) = tmpPulverisateur
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager - getUpdates : " & ex.Message)
        End Try

        oCSdb.free()
        'on retourne les objet non synchro
        Return arrItems
    End Function

    Public Shared Function existsPulverisateur(ByVal pulveId As String, ByVal numeroNational As String) As Integer
        Dim bdd As CSDb
        bdd = New CSDb(True)
        Try
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s("SELECT Count(*) AS existsPulve FROM Pulverisateur WHERE numeroNational='" & numeroNational & "' AND id <> '" & pulveId & "'")
            While dataResults.Read()
                Dim returnVal As Integer = CInt(Trim(dataResults.Item(0).ToString))
                bdd.free()
                Return returnVal
            End While
        Catch ex As Exception
            bdd.free()
            Return 0
        End Try
    End Function
    ''' <summary>
    ''' Rend le nobre de publvérisateur par numéro national
    ''' </summary>
    ''' <param name="numeroNational">Numéro complet</param>
    ''' <returns>Nbre de pulvé</returns>
    ''' <remarks></remarks>

    Public Shared Function getNbrePulverisateursParNumeroNational(ByVal numeroNational As String) As Integer
        Dim bdd As CSDb
        bdd = New CSDb(True)
        Dim returnVal As Integer
        Try
            bdd = New CSDb(True)
            Dim dataResults As System.Data.OleDb.OleDbDataReader = bdd.getResult2s("SELECT Count(*) AS existsPulve FROM Pulverisateur WHERE numeroNational='" & numeroNational & "'")
            While dataResults.Read()
                returnVal = CInt(Trim(dataResults.Item(0).ToString))
            End While
            dataResults.Close()
        Catch ex As Exception
            returnVal = 0
        End Try
        bdd.free()
        Return returnVal
    End Function


#End Region
#Region "ExportCSV"
    Public Shared Function exportToCSV(ByVal Filename As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(Filename))

        Dim bReturn As Boolean
        Dim oCsdb As CSDb = Nothing
        Dim oCmd As OleDb.OleDbCommand
        Dim oDR As OleDb.OleDbDataReader
        Dim oFI As IO.FileInfo
        Dim oFS As IO.FileStream
        Dim oSW As IO.StreamWriter
        Dim strLine As String
        Try
            ' On supprime le fichier s'il existe
            oFI = New IO.FileInfo(Filename)
            If oFI.Exists Then
                oFI.Delete()
            End If

            oFS = New IO.FileStream(Filename, IO.FileMode.CreateNew, IO.FileAccess.Write)
            oSW = New IO.StreamWriter(oFS, System.Text.Encoding.Default)



            oCSdb = New CSDb(True)

            oCmd = oCSdb.getConnection().CreateCommand()
            'Recherche des Pulve qui ont un diag
            Dim strSQL As String = "SELECT Pulverisateur.*, exploitation.* " & _
                "FROM (ExploitationTOPulverisateur INNER JOIN Pulverisateur ON ExploitationTOPulverisateur.idPulverisateur = Pulverisateur.id) INNER JOIN Exploitation ON ExploitationTOPulverisateur.idExploitation = Exploitation.id"

            oCmd.CommandText = strSQL
            oDR = oCmd.ExecuteReader()
            If oDR.HasRows() Then
                strLine = ""
                For i As Integer = 0 To oDR.FieldCount - 1
                    strLine = strLine & oDR.GetName(i) & ";"
                Next i
                oSW.WriteLine(strLine)
                While oDR.Read()
                    strLine = ""
                    For i As Integer = 0 To oDR.FieldCount - 1
                        strLine = strLine & """" & oDR.GetValue(i) & """;"
                    Next i
                    oSW.WriteLine(strLine)
                    oSW.Flush()
                End While
                oDR.Close()

            End If
            oSW.Close()
            oFS.Close()
            oCSdb.free()
            bReturn = True
        Catch ex As Exception
            bReturn = False
            CSDebug.dispError("PulverisateurManager.ExportToCSV Err : " & ex.Message)
        End Try
        Return bReturn
    End Function
#End Region
    ''' <summary>
    ''' Mise à jour de l'état des pulvérisateurs d'une structure
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <param name="pLstPulve"> Liste de spulvé à mettre à jour (Si vide => chargement de tous les pulves de la structure)</param>
    ''' <remarks></remarks>
    Public Shared Sub MAJetatPulverisateurs(pAgent As Agent, Optional pLstPulve As List(Of Pulverisateur) = Nothing)
        Dim oLstPulve As List(Of Pulverisateur)
        Dim oLstDiag As List(Of Diagnostic)
        Dim odiag As Diagnostic
        Dim oExploit As Exploitation
        If pLstPulve Is Nothing Then
            oLstPulve = PulverisateurManager.getPulverisateurList(pAgent, "")
        Else
            oLstPulve = pLstPulve
        End If
        For Each oPulve As Pulverisateur In oLstPulve
            oLstDiag = DiagnosticManager.getlstDiagnosticByPulveId(oPulve.id)
            If oLstDiag.Count > 0 Then
                'La Liste des diag est triée par Date de début descendant, donc le premier est le plus récent
                odiag = oLstDiag(0)
                Dim ancEtat As String
                ancEtat = oPulve.controleEtat
                oPulve.SetControleEtat(odiag)
                If ancEtat <> oPulve.controleEtat Then
                    oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
                    CSDebug.dispError("Modification de l'état du pulvé : " & oPulve.id & "/" & oPulve.numeroNational & "Exploitant : " & oExploit.raisonSociale & " ancien etat = " & ancEtat & ", nouvel etat = " & oPulve.controleEtat & " date de dernier controle = " & odiag.controleDateDebut & ", DiagId = " & odiag.id)
                    PulverisateurManager.save(oPulve, oExploit.id, pAgent)
                End If
                If oPulve.dateProchainControle <> odiag.CalculDateProchainControle() Then
                    oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
                    CSDebug.dispError("Modification de la date du prochain CRL : " & oPulve.id & "/" & oPulve.numeroNational & "Exploitant : " & oExploit.raisonSociale & " date de dernier controle = " & odiag.controleDateDebut & ", DiagId = " & odiag.id & " ancienne date Prch ctrl= " & oPulve.dateProchainControle & " nouvelle date =" & odiag.CalculDateProchainControle())
                    oPulve.dateProchainControle = odiag.CalculDateProchainControle()
                    PulverisateurManager.save(oPulve, oExploit.id, pAgent)
                End If
            End If
        Next
    End Sub

End Class
