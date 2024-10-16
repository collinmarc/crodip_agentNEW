Imports System.Collections.Generic
Imports System.Data.Common

Public Class PulverisateurManager
    Inherits RootManager

#Region "Methodes Web Service"
    Public Shared Function WSgetById(ByVal p_uid As Integer, Optional paid As String = "") As Pulverisateur
        Dim oreturn As Pulverisateur
        oreturn = getWSByKey(Of Pulverisateur)(p_uid, paid)
        Return oreturn
    End Function

    Public Shared Function WSSend(ByVal pObjIn As Pulverisateur, ByRef pobjOut As Pulverisateur) As Integer
        Dim nreturn As Integer
        Try
            nreturn = SendWS(Of Pulverisateur)(pObjIn, pobjOut)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSPulverisateur : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function

    'Public Shared Function getWSPulverisateurById(pAgent As Agent, ByVal pmanometre_uid As Integer) As Pulverisateur
    '    Dim oreturn As Pulverisateur
    '    oreturn = getWSByKey(Of Pulverisateur)(pmanometre_uid, "")
    '    Return oreturn
    'End Function

    'Public Shared Function SendWSPulverisateur(pAgent As Agent, ByVal pobj As Pulverisateur, ByRef pReturn As Pulverisateur) As Integer
    '    Dim nreturn As Integer
    '    Try
    '        nreturn = SendWS(Of Pulverisateur)(pobj, pReturn)

    '    Catch ex As Exception
    '        CSDebug.dispFatal("sendWSPulverisateur : " & ex.Message)
    '        nreturn = -1
    '    End Try
    '    Return nreturn
    'End Function
#End Region

#Region "Methodes acces Local"

    Public Shared Function isAlerte(ByVal pulverisateur_id As String) As Boolean
        Dim ncontrole As Integer
        Dim oCSDB As New CSDb(True)
        If pulverisateur_id <> "" Then
            Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT count(*) FROM Diagnostic WHERE Diagnostic.controleEtat=0 AND Diagnostic.pulverisateurId='" & pulverisateur_id & "'"
            Try
                ' On récupère les résultats
                Dim tmpListResults As DbDataReader = bddCommande.ExecuteReader
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
    '''
    Friend Shared Function getNewId(pAgent As Agent) As String
        If pAgent.oPool IsNot Nothing Then
            Return getNewIdNew(pAgent)
        Else
            Return getNewIdOLD(pAgent)
        End If
    End Function

    Public Shared Function getNewIdNew(pAgent As Agent) As String
        Debug.Assert(Not pAgent Is Nothing, "L'agent doit être renseigné")
        Debug.Assert(pAgent.id <> 0, "L'agent id doit être renseigné")
        Debug.Assert(pAgent.uidStructure <> 0, "La structure id doit être renseignée")
        Debug.Assert(pAgent.oPool IsNot Nothing, "Le pool doit être renseigné")
        ' déclarations
        Dim idCrodipStructure As String = StructureManager.getStructureById(pAgent.uidStructure).idCrodip
        Dim idPC As String
        idPC = pAgent.oPool.idCRODIPPC
        Dim Racine As String = idCrodipStructure & "-" & pAgent.numeroNational & "-" & idPC & "-"
        Dim nIndex As Integer = 1

        If pAgent.uidStructure <> 0 Then

            ' On test si la table est vide

            Dim oCSDb As New CSDb(True)
            Dim res As Object = oCSDb.getValue("SELECT MAX(CAST (REPLACE(Id,'" & Racine & "','') as INT)) as ID  from Pulverisateur where id Like '" & Racine & "%'")
            oCSDb.free()
            If TypeOf res IsNot DBNull Then
                nIndex = CInt(res) + 1
            End If
        End If

        'on retourne le nouvel id
        Return Racine & nIndex
    End Function

    Private Shared Function getNewIdOLD(ByVal curAgent As Agent) As String
        ' déclarations
        Dim tmpPulveId As String = ""
        Dim oCsdb As CSDb = Nothing
        If Not curAgent.numeroNational Is Nothing Then
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = oCsdb.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT `Pulverisateur`.`id` FROM `Pulverisateur` WHERE `Pulverisateur`.`id` LIKE '" & curAgent.uidStructure & "-" & curAgent.id & "-%' ORDER BY `Pulverisateur`.`id` DESC"
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                Dim newId As Integer = 0
                While tmpListProfils.Read()
                    ' On récupère le dernier ID
                    Dim tmpId As Integer = 0
                    tmpPulveId = tmpListProfils.Item(0).ToString
                    tmpId = CInt(tmpPulveId.Replace(curAgent.uidStructure & "-" & curAgent.id & "-", ""))
                    If tmpId > newId Then
                        newId = tmpId
                    End If
                End While
                tmpPulveId = curAgent.uidStructure & "-" & curAgent.id & "-" & (newId + 1)
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
        Debug.Assert(poPulve.uidStructure <> -1, "L'idStructure du pulve doit être renseigné")
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO Pulverisateur (id, idStructure ) VALUES ('" & poPulve.id & "','" & poPulve.uidStructure & "')"
            bddCommande.ExecuteNonQuery()
            oCSDB.free()
            'En synchro, le ClientId n'est pas connu
            If client_id <> "0" Then
                ExploitationTOPulverisateurManager.save(poPulve.id, client_id, False, pAgent)
            End If
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

    Public Shared Function save(ByVal pPulve As Pulverisateur, ByVal client_id As String, ByVal pAgent As Agent, Optional bSynchro As Boolean = False) As Boolean
        Debug.Assert(Not pPulve Is Nothing)
        Debug.Assert(client_id <> "", "L'id Client doit être spécifié")

        Dim bReturn As Boolean
        Dim bdd As New CSDb(True)
        Dim paramsQuery As String = ""

        If pPulve.id = "" Then
            pPulve.id = getNewId(pAgent)
        End If
        Try
            bReturn = False
            If pPulve.id <> "" Then

                ' On test si le Pulverisateur existe ou non
                Dim existsPulverisateur As Object
                If Not pAgent.isGestionnaire Then
                    pPulve.uidStructure = pAgent.uidStructure
                End If
                existsPulverisateur = PulverisateurManager.getPulverisateurById(pPulve.id)
                If existsPulverisateur.id = "" Then
                    createPulve(pPulve, client_id, pAgent)
                End If
                Dim bddCommande As DbCommand
                bddCommande = bdd.getConnection().CreateCommand()

                ' Initialisation de la requete
                paramsQuery = "id='" & pPulve.id & "'"

                ' Mise a jour de la date de derniere modification
                If Not bSynchro Then
                    pPulve.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                End If

                If Not pPulve.numeroNational Is Nothing Then
                    paramsQuery = paramsQuery & " , numeroNational='" & pPulve.numeroNational & "'"
                End If
                If Not pPulve.type Is Nothing Then
                    paramsQuery = paramsQuery & " , type='" & pPulve.type & "'"
                End If
                If Not pPulve.marque Is Nothing Then
                    paramsQuery = paramsQuery & " , marque='" & CSDb.secureString(pPulve.marque) & "'"
                End If
                If Not pPulve.modele Is Nothing Then
                    paramsQuery = paramsQuery & " , modele='" & CSDb.secureString(pPulve.modele) & "'"
                End If
                If Not pPulve.anneeAchat Is Nothing And pPulve.anneeAchat <> "" Then
                    paramsQuery = paramsQuery & " , anneeAchat='" & pPulve.anneeAchat & "'"
                End If
                paramsQuery = paramsQuery & " , categorie='" & CSDb.secureString(pPulve.categorie) & "'"
                If Not pPulve.attelage Is Nothing Then
                    paramsQuery = paramsQuery & " , attelage='" & CSDb.secureString(pPulve.attelage) & "'"
                End If
                paramsQuery = paramsQuery & " , pulverisation='" & CSDb.secureString(pPulve.pulverisation) & "'"
                paramsQuery = paramsQuery & " , capacite=" & pPulve.capacite & ""
                paramsQuery = paramsQuery & " , largeur='" & pPulve.largeur & "'"
                paramsQuery = paramsQuery & " , nombreRangs='" & pPulve.nombreRangs & "'"
                If Not pPulve.largeurPlantation Is Nothing Then
                    paramsQuery = paramsQuery & " , largeurPlantation='" & pPulve.largeurPlantation & "'"
                End If
                If Not pPulve.surfaceParAn Is Nothing Then
                    paramsQuery = paramsQuery & " , surfaceParAn='" & pPulve.surfaceParAn & "'"
                End If
                If Not pPulve.nombreUtilisateurs Is Nothing Then
                    paramsQuery = paramsQuery & " , nombreUtilisateurs='" & pPulve.nombreUtilisateurs & "'"
                End If
                paramsQuery = paramsQuery & " , isVentilateur=" & pPulve.isVentilateur & ""
                paramsQuery = paramsQuery & " , isDebrayage=" & pPulve.isDebrayage & ""
                paramsQuery = paramsQuery & " , isCuveRincage=" & pPulve.isCuveRincage & ""
                If Not pPulve.capaciteCuveRincage Is Nothing Then
                    paramsQuery = paramsQuery & " , capaciteCuveRincage='" & pPulve.capaciteCuveRincage & "'"
                End If
                paramsQuery = paramsQuery & " , isRotobuse=" & pPulve.isRotobuse & ""
                paramsQuery = paramsQuery & " , isCuveIncorporation=" & pPulve.isCuveIncorporation & ""
                paramsQuery = paramsQuery & " , isRinceBidon=" & pPulve.isRinceBidon & ""
                paramsQuery = paramsQuery & " , isBidonLaveMain=" & pPulve.isBidonLaveMain & ""
                paramsQuery = paramsQuery & " , isLanceLavage=" & pPulve.isLanceLavage & ""
                paramsQuery = paramsQuery & " , Regulation='" & CSDb.secureString(pPulve.regulation) & "'"
                paramsQuery = paramsQuery & " , RegulationOptions='" & CSDb.secureString(pPulve.regulationOptions) & "'"
                paramsQuery = paramsQuery & " , nombreBuses=" & pPulve.nombreBuses & ""
                paramsQuery = paramsQuery & " , buseIsIso=" & pPulve.buseIsIso & ""
                If Not pPulve.buseMarque Is Nothing Then
                    paramsQuery = paramsQuery & " , buseMarque='" & CSDb.secureString(pPulve.buseMarque) & "'"
                End If
                If Not pPulve.buseType Is Nothing Then
                    paramsQuery = paramsQuery & " , buseType='" & CSDb.secureString(pPulve.buseType) & "'"
                End If
                If Not pPulve.buseFonctionnement Is Nothing Then
                    paramsQuery = paramsQuery & " , buseFonctionnement='" & CSDb.secureString(pPulve.buseFonctionnement) & "'"
                End If
                If Not pPulve.buseAge = "" Then
                    'Le Champs BuseAge est stocké en boolean mais la prop est du String
                    paramsQuery = paramsQuery & " , buseAge=" & pPulve.buseAge & ""
                End If
                If Not pPulve.buseAngle Is Nothing Then
                    paramsQuery = paramsQuery & " , buseAngle='" & pPulve.buseAngle & "'"
                End If
                If Not pPulve.buseCouleur Is Nothing Then
                    paramsQuery = paramsQuery & " , buseCouleur='" & pPulve.buseCouleur & "'"
                End If
                If Not pPulve.manometreMarque Is Nothing Then
                    paramsQuery = paramsQuery & " , manometreMarque='" & CSDb.secureString(pPulve.manometreMarque) & "'"
                End If
                If Not pPulve.manometreType Is Nothing Then
                    paramsQuery = paramsQuery & " , manometreType='" & CSDb.secureString(pPulve.manometreType) & "'"
                End If
                If Not pPulve.manometreFondEchelle Is Nothing Then
                    paramsQuery = paramsQuery & " , manometreFondEchelle='" & pPulve.manometreFondEchelle & "'"
                End If
                If Not pPulve.manometreDiametre Is Nothing Then
                    paramsQuery = paramsQuery & " , manometreDiametre='" & pPulve.manometreDiametre & "'"
                End If
                If Not pPulve.manometrePressionTravail Is Nothing Then
                    paramsQuery = paramsQuery & " , manometrePressionTravail='" & pPulve.manometrePressionTravail & "'"
                End If
                paramsQuery = paramsQuery & " , isSynchro=" & pPulve.isSynchro & ""
                paramsQuery = paramsQuery & " , isSupprime=" & pPulve.isSupprime & ""
                If Not pPulve.dateProchainControle Is Nothing And pPulve.dateProchainControle <> "" And pPulve.dateProchainControle <> "0000-00-00 00:00:00" Then
                    paramsQuery = paramsQuery & " , dateProchainControle='" & CSDate.ToCRODIPString(pPulve.dateProchainControle) & "'"
                End If
                If Not pPulve.dateModificationCrodipS Is Nothing And pPulve.dateModificationCrodip <> "" Then
                    paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(pPulve.dateModificationCrodip) & "'"
                End If
                If Not pPulve.dateModificationAgentS Is Nothing And pPulve.dateModificationAgent <> "" Then
                    paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(pPulve.dateModificationAgent) & "'"
                End If
                paramsQuery = paramsQuery & " , idStructure=" & pPulve.uidStructure & ""
                ' Emplacement Identification
                If Not pPulve.emplacementIdentification Is Nothing Then
                    paramsQuery = paramsQuery & " , emplacementIdentification='" & CSDb.secureString(pPulve.emplacementIdentification) & "'"
                End If
                ' ancien Identifiant
                If Not pPulve.ancienIdentifiant Is Nothing Then
                    paramsQuery = paramsQuery & " , ancienIdentifiant='" & CSDb.secureString(pPulve.ancienIdentifiant) & "'"
                End If
                paramsQuery = paramsQuery & " , isEclairageRampe=" & pPulve.isEclairageRampe & ""
                paramsQuery = paramsQuery & " , isBarreGuidage=" & pPulve.isBarreGuidage & ""
                paramsQuery = paramsQuery & " , isCoupureAutoTroncons=" & pPulve.isCoupureAutoTroncons & ""
                paramsQuery = paramsQuery & " , isRincageAutoAssiste=" & pPulve.isRincageAutoAssiste & ""
                paramsQuery = paramsQuery & " , buseModele='" & pPulve.buseModele & "'"
                paramsQuery = paramsQuery & " , buseNbniveaux=" & pPulve.buseNbniveaux & ""
                paramsQuery = paramsQuery & " , manometreNbNiveaux=" & pPulve.manometreNbniveaux & ""
                paramsQuery = paramsQuery & " , manometreNbTroncons=" & pPulve.manometreNbtroncons & ""
                paramsQuery = paramsQuery & " , modeUtilisation='" & CSDb.secureString(pPulve.modeUtilisation) & "'"
                paramsQuery = paramsQuery & " , nombreExploitants='" & CSDb.secureString(pPulve.nombreExploitants) & "'"
                paramsQuery = paramsQuery & " , controleEtat='" & CSDb.secureString(pPulve.controleEtat) & "'"
                paramsQuery = paramsQuery & " , isAspirationExt=" & pPulve.isAspirationExt & ""
                paramsQuery = paramsQuery & " , isDispoAntiRetour=" & pPulve.isDispoAntiRetour & ""
                paramsQuery = paramsQuery & " , isReglageAutoHauteur=" & pPulve.isReglageAutoHauteur & ""
                paramsQuery = paramsQuery & " , isFiltrationAspiration=" & pPulve.isFiltrationAspiration & ""
                paramsQuery = paramsQuery & " , isFiltrationRefoulement=" & pPulve.isFiltrationRefoulement & ""
                paramsQuery = paramsQuery & " , isFiltrationTroncons=" & pPulve.isFiltrationTroncons & ""
                paramsQuery = paramsQuery & " , isFiltrationBuses=" & pPulve.isFiltrationBuses & ""
                paramsQuery = paramsQuery & " , isPulveAdditionnel=" & pPulve.isPulveAdditionnel & ""
                paramsQuery = paramsQuery & " , pulvePrincipalNumNat='" & CSDb.secureString(pPulve.pulvePrincipalNumNat) & "'"
                paramsQuery = paramsQuery & " , isRincagecircuit=" & pPulve.isRincagecircuit & ""
                paramsQuery = paramsQuery & " , isPompesDoseuses=" & pPulve.isPompesDoseuses & ""
                paramsQuery = paramsQuery & " , nbPompesDoseuses=" & pPulve.nbPompesDoseuses & ""
                paramsQuery = paramsQuery & " , numeroChassis='" & CSDb.secureString(pPulve.numeroChassis) & "'"
                paramsQuery = paramsQuery & " , immatCertificat='" & CSDb.secureString(pPulve.immatCertificat) & "'"
                paramsQuery = paramsQuery & " , immatPlaque='" & CSDb.secureString(pPulve.immatPlaque) & "'"

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE Pulverisateur SET " & paramsQuery & " WHERE id='" & pPulve.id & "'"
                bddCommande.ExecuteNonQuery()

                ' Vérificatin du lien entre le pulvérisateur et l'exploitation
                If client_id <> "0" Then
                    Dim oExploit2Pulve As New ExploitationTOPulverisateur()
                    oExploit2Pulve.idPulverisateur = pPulve.id
                    oExploit2Pulve.idExploitation = client_id
                    oExploit2Pulve.isSupprimeCoProp = False
                    ExploitationTOPulverisateurManager.save(oExploit2Pulve, pAgent)
                End If

                'Liaison avec les pulvérisateurs additionels
                If pPulve.numeroNationalBis <> "" And pPulve.numeroNationalBis <> pPulve.numeroNational Then
                    'Il y a eu une modification du numéro national
                    UpdateNumeroNationnalPulveAdditionnel(pPulve.numeroNationalBis, pPulve.numeroNational)
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
            dbLink.queryString = "UPDATE Pulverisateur SET dateModificationCrodip='" & newDate & "' , dateModificationAgent='" & newDate & "' WHERE id='" & objPulverisateur.id & "'"
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
        Return getPulverisateurSQL("SELECT p.* FROM Pulverisateur p, ExploitationTOPulverisateur p2e WHERE p2e.idPulverisateur= p.id and p.numeroNational='" & pNumNat & "' and p2e.idExploitation = '" & pclientId & "' AND NOT isSupprimeCoProp")
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

        Dim bddCommande As DbCommand
        bddCommande = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = pSQL
        Try
            ' On récupère les résultats
            Dim oDataReader As DbDataReader = bddCommande.ExecuteReader
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
            Dim dataResults As DbDataReader = bdd.getResult2s(query)

            bReturn = dataResults.HasRows
            dataResults.Close()
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
            bdd.Execute(query)
            bdd.free()
            'Suppression de la relation vers les exploitations
            query = "DELETE FROM `ExploitationTOPulverisateur` WHERE `ExploitationTOPulverisateur`.`idPulverisateur`='" & pPulveId & "'"
            Dim bdd2 As New CSDb(True)
            bdd2.Execute(query)
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
    Public Shared Function getPulverisateurByClientId(ByVal client_id As String, pDroitsPulves As String, Optional pTous As Boolean = False) As Pulverisateur()
        ' déclarations
        Dim arrItems(0) As Pulverisateur
        Dim oCSDB As New CSDb(True)
        If client_id <> "" Then

            Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
            bddCommande.CommandText = "SELECT distinct Pulverisateur.* FROM Pulverisateur INNER JOIN (Exploitation INNER JOIN ExploitationTOPulverisateur ON Exploitation.id = ExploitationTOPulverisateur.idExploitation) ON Pulverisateur.id = ExploitationTOPulverisateur.idPulverisateur WHERE (((ExploitationTOPulverisateur.idExploitation)='" & client_id & "'))"
            If Not pTous Then
                bddCommande.CommandText = bddCommande.CommandText & " AND NOT isSupprimeCoProp "
            End If

            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                Dim i As Integer = 0
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpPulverisateur As New Pulverisateur()
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

            Dim strQuery As String = ""
            'strQuery = "SELECT Pulverisateur.*, Exploitation.raisonsociale, Exploitation.prenomExploitant, Exploitation.nomExploitant, Exploitation.codepostal,Exploitation.commune " _
            '                         & " FROM (ExploitationTOPulverisateur INNER JOIN (Diagnostic RIGHT JOIN Pulverisateur ON Diagnostic.pulverisateurId = Pulverisateur.id) ON ExploitationTOPulverisateur.idPulverisateur = Pulverisateur.id) INNER JOIN Exploitation ON ExploitationTOPulverisateur.idExploitation = Exploitation.id "
            'strQuery = strQuery & " WHERE Not isSupprimeCoProp And"
            'strQuery = strQuery & " (Diagnostic.controleDateFin = (SELECT Max(controleDateFin) from Diagnostic where Diagnostic.pulverisateurId = Pulverisateur.id) Or Diagnostic.controleDateFin Is NULL) And "
            'strQuery = strQuery & " pulverisateur.idStructure = " & pAgent.idStructure
            'strQuery = strQuery & " ORDER BY  Pulverisateur.dateProchainControle ASC"

            strQuery = "SELECT p.*,  e.raisonSociale,e.prenomExploitant,e.nomExploitant,e.codePostal, e.commune"
            strQuery = strQuery & " From Pulverisateur p inner  join ExploitationTOPulverisateur e2p on e2p.idPulverisateur = p.id inner join Exploitation e on e2p.idExploitation = e.id "
            strQuery = strQuery & " WHERE e2p.isSupprimecoProp=0 and p.idStructure = " & pAgent.uidStructure
            strQuery = strQuery & " ORDER BY  P.dateProchainControle ASC"

            Dim oDataReader As DbDataReader = bdd.getResult2s(strQuery)

            Dim i As Integer = 0
            ' Puis on les parcours
            While oDataReader.Read()
                ' On rempli notre tableau
                Dim tmpPulverisateur As New Pulverisateur
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < oDataReader.FieldCount()
                    If Not oDataReader.IsDBNull(tmpColId) Then
                        tmpPulverisateur.Fill(oDataReader.GetName(tmpColId), oDataReader.Item(tmpColId))
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
            oDataReader.Close()
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager.PulverisateurList ERR  ", ex)
        End Try
        bdd.free()
        'on retourne les pulvé
        Return oReturn
    End Function

    Public Shared Function getPulverisateurList2(ByVal pAgent As Agent, pDroitsPulves As String, Optional pTous As Boolean = False) As List(Of Pulverisateur)
        ' déclarations
        Dim oReturn As New List(Of Pulverisateur)

        Dim bdd As New CSDb(True)
        Try
            ' On récupère les résultats

            Dim strQuery As String = "SELECT Pulverisateur.*, Exploitation.raisonsociale, Exploitation.prenomExploitant, Exploitation.nomExploitant, Exploitation.codepostal,Exploitation.commune " _
                                      & " FROM (ExploitationTOPulverisateur INNER JOIN Pulverisateur On ExploitationTOPulverisateur.idPulverisateur = Pulverisateur.id) INNER JOIN Exploitation On ExploitationTOPulverisateur.idExploitation = Exploitation.id "
            '            strQuery = strQuery & " (Diagnostic.controleDateFin = (SELECT Max(controleDateFin) from Diagnostic where Diagnostic.pulverisateurId = Pulverisateur.id) Or Diagnostic.controleDateFin Is NULL) And "
            strQuery = strQuery & " WHERE pulverisateur.idStructure = " & pAgent.uidStructure
            If Not pTous Then
                strQuery = strQuery & " And  Not ExploitationTOPulverisateur.isSupprimeCoProp"
            End If
            strQuery = strQuery & " ORDER BY  Pulverisateur.dateProchainControle ASC"
            Dim tmpListProfils As DbDataReader = bdd.getResult2s(strQuery)

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
            tmpListProfils.Close()
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispError("PulverisateurManager - getListeOfPulverisateur  " & ex.Message)
        End Try
        bdd.free()
        'on retourne les pulvé
        Return oReturn
    End Function

    Public Shared Function getUpdates(ByVal agent As Agent) As Pulverisateur()
        ' déclarations
        Dim arrItems(0) As Pulverisateur
        Dim oCSdb As New CSDb(True)
        Dim bddCommande As DbCommand = oCSdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Pulverisateur WHERE (dateModificationAgent<>dateModificationCrodip Or  dateModificationCrodip Is null)"
        bddCommande.CommandText = bddCommande.CommandText & " And idStructure=" & agent.uidStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
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
            Dim returnVal As Integer = CInt(bdd.getValue("SELECT Count(*) AS existsPulve FROM Pulverisateur WHERE numeroNational='" & numeroNational & "' AND id <> '" & pulveId & "'"))
        Catch ex As Exception
        End Try
        bdd.free()
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
            returnVal = bdd.getValue("SELECT Count(*) AS existsPulve FROM Pulverisateur WHERE numeroNational='" & numeroNational & "'")
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
        Dim oCmd As DbCommand
        Dim oDR As DbDataReader
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



            oCsdb = New CSDb(True)

            oCmd = oCsdb.getConnection().CreateCommand()
            'Recherche des Pulve qui ont un diag
            Dim strSQL As String = "SELECT Pulverisateur.*, exploitation.* " &
                "FROM (ExploitationTOPulverisateur INNER JOIN Pulverisateur ON ExploitationTOPulverisateur.idPulverisateur = Pulverisateur.id) INNER JOIN Exploitation ON ExploitationTOPulverisateur.idExploitation = Exploitation.id" &
                " WHERE NOT isSupprimeCoProp"

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
            oCsdb.free()
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
                If Not CSDate.FromCrodipString(oPulve.dateProchainControle).ToShortDateString().Equals(CSDate.FromCrodipString(odiag.CalculDateProchainControle()).ToShortDateString()) Then
                    oExploit = ExploitationManager.GetExploitationByPulverisateurId(oPulve.id)
                    CSDebug.dispError("Modification de la date du prochain CRL : " & oPulve.id & "/" & oPulve.numeroNational & "Exploitant : " & oExploit.raisonSociale & " date de dernier controle = " & odiag.controleDateDebut & ", DiagId = " & odiag.id & " ancienne date Prch ctrl= " & oPulve.dateProchainControle & " nouvelle date =" & odiag.CalculDateProchainControle())
                    oPulve.dateProchainControle = odiag.CalculDateProchainControle()
                    PulverisateurManager.save(oPulve, oExploit.id, pAgent)
                End If
            End If
        Next
    End Sub
    ''' <summary>
    ''' Met à jour la base Pulve à partir des diagnostic et renvoie le nombre de ligne Modifiée
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function MAJPulveDepuisdiagnostic() As Integer
        Dim paramsQuery As String = ""
        Dim bReturn As Integer = 0
        Try

            Dim bdd As New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = bdd.getConnection().CreateCommand()
            Dim sDate As String = CSDate.ToCRODIPString(Now)

            paramsQuery = "UPDATE Pulverisateur 
        set (dateModificationAgent,
               marque ,  
               modele , 
               Type, 
               capacite, 
               Largeur, 
               LargeurPlantation, 
               IsVentilateur, 
               IsDebrayage, 
               AnneeAchat, 
               nombreUtilisateurs, 
               IsCuveRincage, 
               CapaciteCuveRincage, 
               IsRotobuse, 
               IsRinceBidon, 
               IsBidonLaveMain, 
               isLanceLavage, 
               IsCuveIncorporation, 
               Attelage, 
               buseMarque, 
               buseCouleur, 
               buseAge, 
               nombreBuses, 
               buseType, 
               buseAngle, 
               buseIsIso, 
               manometreDiametre, 
               manometreType, 
               manometreFondEchelle, 
               manometrePressionTravail, 
               emplacementIdentification, 
               Regulation, 
               regulationOptions, 
               ModeUtilisation, 
               buseFonctionnement, 
               Categorie, 
               Pulverisation, 
               isCoupureAutoTroncons, 
               isReglageAutoHauteur, 
               isRincagecircuit, 
               Numchassis) 
               = (SELECT '" & sDate & "',
               pulverisateurMarque, 
               pulverisateurModele, 
               pulverisateurType, 
               Diagnostic.pulverisateurCapacite, 
               Diagnostic.pulverisateurLargeur, 
               Diagnostic.pulverisateurLargeurPlantation, 
               Diagnostic.pulverisateurIsVentilateur, 
               Diagnostic.pulverisateurIsDebrayage, 
               Diagnostic.pulverisateurAnneeAchat, 
               Diagnostic.pulverisateurNbUtilisateurs, 
               Diagnostic.pulverisateurIsCuveRincage, 
               Diagnostic.pulverisateurCapaciteCuveRincage, 
               Diagnostic.pulverisateurIsRotobuse, 
               Diagnostic.pulverisateurIsRinceBidon, 
               Diagnostic.pulverisateurIsBidonLaveMain, 
               Diagnostic.pulverisateurIsLanceLavageExterieur, 
               Diagnostic.pulverisateurIsCuveIncorporation, 
               Diagnostic.pulverisateurAttelage, 
               Diagnostic.buseMarque, 
               Diagnostic.buseCouleur, 
               Diagnostic.buseAge, 
               Diagnostic.buseNbBuses, 
               Diagnostic.buseType, 
               Diagnostic.buseAngle, 
               Diagnostic.buseIsISO, 
               Diagnostic.manometreDiametre, 
               Diagnostic.manometreType, 
               Diagnostic.manometreFondEchelle, 
               Diagnostic.manometrePressionTravail, 
               Diagnostic.pulverisateurEmplacementIdentification, 
               Diagnostic.pulverisateurRegulation, 
               Diagnostic.pulverisateurRegulationOptions, 
               Diagnostic.pulverisateurModeUtilisation, 
               Diagnostic.buseFonctionnement, 
               Diagnostic.pulverisateurCategorie, 
               Diagnostic.pulverisateurPulverisation, 
               CASE Diagnostic.pulverisateurCoupureAutoTroncons WHEN 'OUI'THEN 1 ELSE 0 END, 
               CASE Diagnostic.pulverisateurReglageAutoHauteur WHEN 'OUI'THEN 1 ELSE 0 END, 
               CASE Diagnostic.pulverisateurRincagecircuit WHEN 'OUI'THEN 1 ELSE 0 END, 
               Diagnostic.pulverisateurNumChassis 
               From Diagnostic  
               Where Diagnostic.pulverisateurId = Pulverisateur.Id Order By controleDateDebut desc LIMIT 1)  
               Where categorie = '' OR Categorie is null "

            ' On finalise la requete et en l'execute
            bddCommande.CommandText = paramsQuery
            bddCommande.ExecuteNonQuery()

            bddCommande.CommandText = "SELECT Count(*) FROM Pulverisateur where dateModificationAgent = '" & sDate & "'"
            bReturn = bddCommande.ExecuteScalar()

            bdd.free()
        Catch ex As Exception
            CSDebug.dispError("PulverisateurManager.MAJPulveFromDiagnostic", ex)
            bReturn = -1
        End Try
        Return bReturn
    End Function
    Public Shared Function UpdateNumeroNationnalPulveAdditionnel(pNumNatAncien As String, pNumNatNouv As String) As Boolean
        Dim paramsQuery As String = ""
        Dim bReturn As Boolean
        Try

            Dim bdd As New CSDb(True)
            Dim bddCommande As DbCommand
            bddCommande = bdd.getConnection().CreateCommand()
            Dim sDate As String = CSDate.ToCRODIPString(Now)

            paramsQuery = "UPDATE Pulverisateur " &
                "set pulvePrincipalNumNat = '" & pNumNatNouv & "'" &
                ", dateModificationAgent = '" & CSDate.ToCRODIPString(Date.Now) & "'" &
                "WHERE pulvePrincipalNumNat = '" & pNumNatAncien & "' AND isPulveAdditionnel = 1"


            ' On finalise la requete et en l'execute
            bddCommande.CommandText = paramsQuery
            bddCommande.ExecuteNonQuery()

            bdd.free()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("PulverisateurManager.updateNumeroNationnalPulveAdditionnel", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function
End Class
