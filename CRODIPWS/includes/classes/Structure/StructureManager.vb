Imports System.Collections.Generic
Imports System.Data.Common

Public Class StructureManager
    Inherits RootManager

#Region "Methodes Web Service"

    Public Shared Function getWSStructureeById(pAgent As Agent, ByVal pmanometre_uid As Integer) As Structuree
        Dim oreturn As Structuree
        oreturn = getWSByKey(Of Structuree)(pmanometre_uid, "")
        Return oreturn
    End Function

    Public Shared Function SendWSStructuree(pAgent As Agent, ByVal pobj As Structuree, ByRef pReturn As Structuree) As Integer
        Dim nreturn As Integer
        Try
            nreturn = SendWS(Of Structuree)(pobj, pReturn)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSStructuree : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function
#End Region

#Region "Methodes acces Local"

    Public Shared Function getStructureById(ByVal structure_id As Integer) As Structuree
        ' déclarations
        Dim tmpStructure As New Structuree
        If structure_id <> 0 Then

            Dim oCSDB As New CSDb(True)
            Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand
            bddCommande.CommandText = "SELECT * FROM Structure WHERE Structure.id=" & structure_id & ""
            Try
                ' On récupère les résultats
                Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
                ' Puis on les parcours
                While tmpListProfils.Read()
                    ' On rempli notre tableau
                    Dim tmpColId As Integer = 0
                    While tmpColId < tmpListProfils.FieldCount()
                        Select Case tmpListProfils.GetName(tmpColId)
                            Case "id"
                                tmpStructure.id = tmpListProfils.Item(tmpColId)
                            Case "idCrodip"
                                tmpStructure.idCrodip = tmpListProfils.Item(tmpColId).ToString()
                            Case "nom"
                                tmpStructure.nom = tmpListProfils.Item(tmpColId).ToString()
                            Case "type"
                                tmpStructure.type = tmpListProfils.Item(tmpColId).ToString()
                            Case "nomResponsable"
                                tmpStructure.nomResponsable = tmpListProfils.Item(tmpColId).ToString()
                            Case "nomContact"
                                tmpStructure.nomContact = tmpListProfils.Item(tmpColId).ToString()
                            Case "prenomContact"
                                tmpStructure.prenomContact = tmpListProfils.Item(tmpColId).ToString()
                            Case "adresse"
                                tmpStructure.adresse = tmpListProfils.Item(tmpColId).ToString()
                            Case "codePostal"
                                tmpStructure.codePostal = tmpListProfils.Item(tmpColId).ToString()
                            Case "commune"
                                tmpStructure.commune = tmpListProfils.Item(tmpColId).ToString()
                            Case "codeInsee"
                                tmpStructure.codeInsee = tmpListProfils.Item(tmpColId).ToString()
                            Case "telephoneFixe"
                                tmpStructure.telephoneFixe = tmpListProfils.Item(tmpColId).ToString()
                            Case "telephonePortable"
                                tmpStructure.telephonePortable = tmpListProfils.Item(tmpColId).ToString()
                            Case "telephoneFax"
                                tmpStructure.telephoneFax = tmpListProfils.Item(tmpColId).ToString()
                            Case "eMail"
                                tmpStructure.eMail = tmpListProfils.Item(tmpColId).ToString()
                            Case "commentaire"
                                tmpStructure.commentaire = tmpListProfils.Item(tmpColId).ToString()
                            Case "dateModificationAgent"
                                tmpStructure.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                            Case "dateModificationCrodip"
                                tmpStructure.dateModificationCrodip = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        End Select
                        tmpColId = tmpColId + 1
                    End While
                    tmpStructure.LireDernierNumFact()

                End While
            Catch ex As Exception ' On intercepte l'erreur
                CSDebug.dispError("StructureManager.getStructureById ERR", ex)
                tmpStructure = Nothing
            End Try

            If Not oCSDB Is Nothing Then
                oCSDB.free()
            End If
        End If
        'on retourne le client ou un objet vide en cas d'erreur
        Return tmpStructure
    End Function
    Public Shared Function getNewId() As Integer
        Dim iReturn As Integer
        Dim oCSDB As New CSDb(True)
        Try
            iReturn = 0
            Dim oCommand As DbCommand = oCSDB.getConnection().CreateCommand()
            oCommand.CommandText = " SELECT MAX(ID) from Structure"
            'Récupération du prochainID
            Dim oReader As DbDataReader = oCommand.ExecuteReader()
            If oReader.HasRows Then
                While oReader.Read()
                    If oReader.IsDBNull(0) Then
                        iReturn = 0
                    Else
                        Try
                            iReturn = oReader.GetInt32(0)
                        Catch ex As Exception
                            ex = Nothing
                            iReturn = 0
                        End Try

                    End If
                End While
            Else
                iReturn = 0
            End If
            iReturn = iReturn + 1
            oReader.Close()

            oCSDB.free()
        Catch ex As Exception
            CSDebug.dispFatal("StructureManager.getNewId ERR :" & ex.Message.ToString())
            iReturn = -1
            oCSDB.free()
        End Try
        Return iReturn
    End Function

    Private Shared Sub createStructure(ByVal structuree_id As String)
        Try
            Dim oCsdb As CSDb = Nothing
            oCsdb = New CSDb(True)
            Dim bddCommande As DbCommand = oCsdb.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO Structure (id) VALUES ('" & structuree_id & "')"
            bddCommande.ExecuteReader()

            oCsdb.free()
        Catch ex As Exception
            MsgBox("StructureManager.createStructure error : " & ex.Message)
        End Try
    End Sub

    Public Shared Sub save(ByVal objStructure As Structuree, Optional bSyncro As Boolean = False)
        If objStructure.id <> 0 Then


            ' On test si l'object existe ou non
            Dim existsObject As Object
            existsObject = StructureManager.getStructureById(objStructure.id)
            If existsObject.id = 0 Then
                ' Si il n'existe pas, on le crée
                createStructure(objStructure.id)
            End If


            Dim oCSDb As New CSDb(True)
            Dim bddCommande As DbCommand = oCSDb.getConnection().CreateCommand()

            Dim paramsQuery As String
            paramsQuery = "id=" & objStructure.id & ""
            ' Mise a jour de la date de derniere modification
            If Not bSyncro Then
                objStructure.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
            End If

            If Not objStructure.idCrodip Is Nothing Then
                paramsQuery = paramsQuery & " , idCrodip='" & CSDb.secureString(objStructure.idCrodip) & "'"
            End If
            If Not objStructure.nom Is Nothing Then
                paramsQuery = paramsQuery & " , nom='" & CSDb.secureString(objStructure.nom) & "'"
            End If
            If Not objStructure.type Is Nothing Then
                paramsQuery = paramsQuery & " , type='" & CSDb.secureString(objStructure.type) & "'"
            End If
            If Not objStructure.nomResponsable Is Nothing Then
                paramsQuery = paramsQuery & " , nomResponsable='" & CSDb.secureString(objStructure.nomResponsable) & "'"
            End If
            If Not objStructure.nomContact Is Nothing And objStructure.nomContact <> "" Then
                paramsQuery = paramsQuery & " , nomContact='" & CSDb.secureString(objStructure.nomContact) & "'"
            End If
            If Not objStructure.prenomContact Is Nothing And objStructure.prenomContact <> "" Then
                paramsQuery = paramsQuery & " , prenomContact='" & CSDb.secureString(objStructure.prenomContact) & "'"
            End If
            If Not objStructure.adresse Is Nothing Then
                paramsQuery = paramsQuery & " , adresse='" & CSDb.secureString(objStructure.adresse) & "'"
            End If
            If Not objStructure.codePostal Is Nothing Then
                paramsQuery = paramsQuery & " , codePostal='" & CSDb.secureString(objStructure.codePostal) & "'"
            End If
            If Not objStructure.commune Is Nothing Then
                paramsQuery = paramsQuery & " , commune='" & CSDb.secureString(objStructure.commune) & "'"
            End If
            If Not objStructure.codeInsee Is Nothing Then
                paramsQuery = paramsQuery & " , codeInsee='" & CSDb.secureString(objStructure.codeInsee) & "'"
            End If
            If Not objStructure.telephoneFixe Is Nothing Then
                paramsQuery = paramsQuery & " , telephoneFixe='" & CSDb.secureString(objStructure.telephoneFixe) & "'"
            End If
            If Not objStructure.telephonePortable Is Nothing Then
                paramsQuery = paramsQuery & " , telephonePortable='" & CSDb.secureString(objStructure.telephonePortable) & "'"
            End If
            If Not objStructure.telephoneFax Is Nothing Then
                paramsQuery = paramsQuery & " , telephoneFax='" & CSDb.secureString(objStructure.telephoneFax) & "'"
            End If
            If Not objStructure.eMail Is Nothing Then
                paramsQuery = paramsQuery & " , eMail='" & CSDb.secureString(objStructure.eMail) & "'"
            End If
            If Not objStructure.commentaire Is Nothing Then
                paramsQuery = paramsQuery & " , commentaire='" & CSDb.secureString(objStructure.commentaire) & "'"
            End If
            If Not objStructure.dateModificationAgent Is Nothing Then
                paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.TOCRODIPString(objStructure.dateModificationAgent) & "'"
            End If
            If Not objStructure.dateModificationCrodip Is Nothing Then
                paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.TOCRODIPString(objStructure.dateModificationCrodip) & "'"
            End If
            bddCommande.CommandText = "UPDATE Structure SET " & paramsQuery & " WHERE id=" & objStructure.id & ""
            bddCommande.ExecuteNonQuery()

            oCSDb.free()
        End If
    End Sub

    Public Shared Sub setSynchro(ByVal objStructure As Structuree)
        Try
            Dim dbLink As New CSDb(True)
            Dim newDate As String = Date.Now.ToString
            dbLink.queryString = "UPDATE Structure SET dateModificationCrodip='" & newDate & "',dateModificationAgent='" & newDate & "' WHERE id=" & objStructure.id & ""
            dbLink.Execute()
            dbLink.free()
        Catch ex As Exception
            CSDebug.dispFatal("StructureManager::setSynchro : " & ex.Message)
        End Try
    End Sub

    Public Shared Function getUpdates(ByVal agent As Agent) As Structuree()
        ' déclarations
        Dim arrItems(0) As Structuree
        Dim oCSDB As New CSDb(True)
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM Structure WHERE (Structure.dateModificationAgent<>Structure.dateModificationCrodip or Structure.dateModificationCrodip is null) AND Structure.id=" & agent.idStructure

        Try
            ' On récupère les résultats
            Dim tmpListProfils As DbDataReader = bddCommande.ExecuteReader
            Dim i As Integer = 0
            ' Puis on les parcours
            While tmpListProfils.Read()
                ' On rempli notre tableau
                Dim tmpStructuree As New Structuree
                Dim tmpColId As Integer = 0
                While tmpColId < tmpListProfils.FieldCount()
                    Select Case tmpListProfils.GetName(tmpColId)
                        Case "id"
                            tmpStructuree.id = tmpListProfils.Item(tmpColId)
                        Case "idCrodip"
                            tmpStructuree.idCrodip = tmpListProfils.Item(tmpColId).ToString()
                        Case "nom"
                            tmpStructuree.nom = tmpListProfils.Item(tmpColId).ToString()
                        Case "type"
                            tmpStructuree.type = tmpListProfils.Item(tmpColId).ToString()
                        Case "nomResponsable"
                            tmpStructuree.nomResponsable = tmpListProfils.Item(tmpColId).ToString()
                        Case "nomContact"
                            tmpStructuree.nomContact = tmpListProfils.Item(tmpColId).ToString()
                        Case "prenomContact"
                            tmpStructuree.prenomContact = tmpListProfils.Item(tmpColId).ToString()
                        Case "adresse"
                            tmpStructuree.adresse = tmpListProfils.Item(tmpColId).ToString()
                        Case "codePostal"
                            tmpStructuree.codePostal = tmpListProfils.Item(tmpColId).ToString()
                        Case "commune"
                            tmpStructuree.commune = tmpListProfils.Item(tmpColId).ToString()
                        Case "codeInsee"
                            tmpStructuree.codeInsee = tmpListProfils.Item(tmpColId).ToString()
                        Case "telephoneFixe"
                            tmpStructuree.telephoneFixe = tmpListProfils.Item(tmpColId).ToString()
                        Case "telephonePortable"
                            tmpStructuree.telephonePortable = tmpListProfils.Item(tmpColId).ToString()
                        Case "telephoneFax"
                            tmpStructuree.telephoneFax = tmpListProfils.Item(tmpColId).ToString()
                        Case "eMail"
                            tmpStructuree.eMail = tmpListProfils.Item(tmpColId).ToString()
                        Case "commentaire"
                            tmpStructuree.commentaire = tmpListProfils.Item(tmpColId).ToString()
                        Case "dateModificationCrodip"
                            tmpStructuree.dateModificationCrodip = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                        Case "dateModificationAgent"
                            tmpStructuree.dateModificationAgent = CSDate.ToCRODIPString(tmpListProfils.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                arrItems(i) = tmpStructuree
                i = i + 1
                ReDim Preserve arrItems(i)
            End While
            ReDim Preserve arrItems(i - 1)

        Catch ex As Exception ' On intercepte l'erreur
            MsgBox("Erreur - StructureeManager - getResult : " & ex.Message)
        End Try

        ' Test pour fermeture de connection BDD
        oCSDB.free()
        'on retourne les objet non synchro
        Return arrItems
    End Function

    Public Shared Function getList() As List(Of Structuree)
        Dim lstReturn As New List(Of Structuree)

        Dim oCSDB As New CSDb(True)
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand
        bddCommande.CommandText = "SELECT * FROM Structure"
        Try
            ' On récupère les résultats
            Dim oDR As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            While oDR.Read()
                Dim oStruct As New Structuree()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < oDR.FieldCount()
                    Select Case oDR.GetName(tmpColId).Trim().ToUpper()
                        Case "id".Trim().ToUpper()
                            oStruct.id = oDR.Item(tmpColId)
                        Case "idCrodip".Trim().ToUpper()
                            oStruct.idCrodip = oDR.Item(tmpColId).ToString()
                        Case "nom".Trim().ToUpper()
                            oStruct.nom = oDR.Item(tmpColId).ToString()
                        Case "type".Trim().ToUpper()
                            oStruct.type = oDR.Item(tmpColId).ToString()
                        Case "nomResponsable".Trim().ToUpper()
                            oStruct.nomResponsable = oDR.Item(tmpColId).ToString()
                        Case "nomContact".Trim().ToUpper()
                            oStruct.nomContact = oDR.Item(tmpColId).ToString()
                        Case "prenomContact".Trim().ToUpper()
                            oStruct.prenomContact = oDR.Item(tmpColId).ToString()
                        Case "adresse".Trim().ToUpper()
                            oStruct.adresse = oDR.Item(tmpColId).ToString()
                        Case "codePostal".Trim().ToUpper()
                            oStruct.codePostal = oDR.Item(tmpColId).ToString()
                        Case "commune".Trim().ToUpper()
                            oStruct.commune = oDR.Item(tmpColId).ToString()
                        Case "codeInsee".Trim().ToUpper()
                            oStruct.codeInsee = oDR.Item(tmpColId).ToString()
                        Case "telephoneFixe".Trim().ToUpper()
                            oStruct.telephoneFixe = oDR.Item(tmpColId).ToString()
                        Case "telephonePortable".Trim().ToUpper()
                            oStruct.telephonePortable = oDR.Item(tmpColId).ToString()
                        Case "telephoneFax".Trim().ToUpper()
                            oStruct.telephoneFax = oDR.Item(tmpColId).ToString()
                        Case "eMail".Trim().ToUpper()
                            oStruct.eMail = oDR.Item(tmpColId).ToString()
                        Case "commentaire".Trim().ToUpper()
                            oStruct.commentaire = oDR.Item(tmpColId).ToString()
                        Case "dateModificationAgent".Trim().ToUpper()
                            oStruct.dateModificationAgent = CSDate.ToCRODIPString(oDR.Item(tmpColId).ToString())
                        Case "dateModificationCrodip".Trim().ToUpper()
                            oStruct.dateModificationCrodip = CSDate.ToCRODIPString(oDR.Item(tmpColId).ToString())
                    End Select
                    tmpColId = tmpColId + 1
                End While
                oStruct.LireDernierNumFact()
                lstReturn.Add(oStruct)
            End While
        Catch ex As Exception ' On intercepte l'erreur
            MsgBox("StructureManager.GetList Err: " & ex.Message)
            lstReturn = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        'on retourne le client ou un objet vide en cas d'erreur
        Return lstReturn

    End Function

#End Region

    Public Shared Function delete(ByVal pStructureID As Integer) As Boolean
        Debug.Assert(pStructureID > 0, " le paramètre StructureID doit être initialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim nResult As Integer
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()
            bddCommande.CommandText = "DELETE FROM Structure WHERE id=" & pStructureID.ToString() & ""
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "Erreur en Delete, plus d'une ligne supprimée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("StructureManager.delete (" & pStructureID.ToString() & ") Error: " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function 'delete

End Class
