Imports System.Collections.Generic
Imports System.Data.Common
Imports Microsoft.Win32

Public Class AgentPCManager
    Inherits RootManager

#Region "Methodes Web Service"




#End Region

#Region "Methodes Locales"
    ''' Cette méthode n'est plus utilisée depuis la 2.5.4.3 , car les matériels sont créés sur le Serveur 

    Public Shared Function save(ByVal objAgentPC As AgentPC, Optional bsynchro As Boolean = False) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(objAgentPC.idCrodip), "L'Id doit être inititialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)
            Dim n As Integer = oCsdb.getValue("SELECT Count(*) FROM AgentPC Where IDCRODIP = '" & objAgentPC.idCrodip & "'")
            oCsdb.free()
            bReturn = True
            If n = 0 Then
                bReturn = createAgentPC(objAgentPC)
            End If
            If bReturn Then
                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()

                ' Initialisation de la requete
                Dim paramsQuery As String = "idCrodip=" & objAgentPC.idCrodip & ""

                ' Mise a jour de la date de derniere modification
                If Not bsynchro Then
                    objAgentPC.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                Else
                    objAgentPC.dateModificationAgent = objAgentPC.dateModificationCrodip

                End If


                If objAgentPC.idStructure <> 0 Then
                    paramsQuery = paramsQuery & " , idStructure=" & objAgentPC.idStructure & ""
                End If
                If Not objAgentPC.idCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , idCrodip='" & CSDb.secureString(objAgentPC.idCrodip) & "'"
                End If
                If Not String.IsNullOrEmpty(objAgentPC.libelle) Then
                    paramsQuery = paramsQuery & " , libelle='" & CSDb.secureString(objAgentPC.libelle) & "'"
                End If
                If Not String.IsNullOrEmpty(objAgentPC.numInterne) Then
                    paramsQuery = paramsQuery & " , numInterne='" & CSDb.secureString(objAgentPC.numInterne) & "'"
                End If
                paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(objAgentPC.dateModificationAgent) & "'"
                paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(objAgentPC.dateModificationCrodip) & "'"

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentPC SET " & paramsQuery & " WHERE idCrodip='" & objAgentPC.idCrodip & "'"
                bddCommande.ExecuteNonQuery()
                bReturn = True
            End If

        Catch ex As Exception
            CSDebug.dispError("AgentPCManager.Save ERR: ", ex)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function

    Public Shared Function getAgentPCByIdCRODIP(ByVal pid As String) As AgentPC
        Debug.Assert(pid <> 0, "ID doit être initialisé")
        Dim oReturn As AgentPC = Nothing
        Try

            oReturn = getByKey(Of AgentPC)("SELECT * FROM AgentPC WHERE idCRODIP='" & pid & "'")


        Catch ex As Exception
            CSDebug.dispError("AgentPCManager.getAgentPCByIdCRODIP ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
#End Region
    '''
    ''' Marque l'utilisation du AgentPC (Flag isUtilisé, date de dernier controle, création de la fiche de vie)
    '''
    '''
    ''' création d'un enregistrement AgentPC
    ''' L'ID doit êre initialisé
    '''
    Private Shared Function createAgentPC(ByVal pAgentPC As AgentPC) As Boolean
        Debug.Assert(pAgentPC IsNot Nothing, "pAgentPC doit être initialisé")
        Debug.Assert(Not String.IsNullOrEmpty(pAgentPC.idCrodip), "IDCrodip doit être initialisé")
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO AgentPC (idCrodip) values ('" & pAgentPC.idCrodip & "')"
            bddCommande.ExecuteNonQuery()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("AgentPCManager.createAgentPC error : " & ex.Message)
            bReturn = False
        End Try
        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return bReturn
    End Function 'CreateAgentPC

    Public Overloads Shared Function GetListe() As List(Of AgentPC)
        Dim oList As New List(Of AgentPC)
        Try
            oList = getListe(Of AgentPC)("SELECT* FROM AgentPC")

        Catch ex As Exception
            CSDebug.dispError("PoolManager.GetListe ERR", ex)
            oList = New List(Of AgentPC)()
        End Try
        Return oList

    End Function

    Public Shared Function RESTgetAgentPCByIDCrodip(pAgent As Agent, pidCrodip As String) As AgentPC
        Dim oReturn As AgentPC = Nothing
        Try
            oReturn = RESTgetByID(Of AgentPC)("getAgentPC", pAgent, pidCrodip)
        Catch ex As Exception
            CSDebug.dispError("AgentPCManager.RESTgetAgentPCByidCrodip ERR", ex)
        End Try
        Return oReturn
    End Function

    Public Shared Function RESTgetAgentPCs(pAgent As Agent) As List(Of AgentPC)
        Dim oReturn As New List(Of AgentPC)
        Try

            oReturn = RESTgetList(Of AgentPC)("getAgentPC", pAgent)
        Catch ex As Exception
            CSDebug.dispError("PoolManager.RESTgetPools ERR", ex)
        End Try
        Return oReturn
    End Function

    Public Shared Function RESTsetAgentPC(pAgent As Agent, pobj As AgentPC) As Boolean
        Dim oReturn As Boolean
        Try
            oReturn = RESTset(Of AgentPC)("setAgentPC", pAgent, pobj)

        Catch ex As Exception
            CSDebug.dispError("AgentPCManager.RESTsetPool ERR", ex)
        End Try
        Return oReturn
    End Function

    Public Shared Sub RAZInstall()
        Try

            Dim oCSDB As New CSDb(True)
            oCSDB.Execute("UPDATE POOL SET idCRODIPPC = NULL")
            oCSDB.Execute("DELETE FROM AgentPC")
            oCSDB.free()
            Registry.CurrentUser.DeleteSubKeyTree("CRODIP")
        Catch ex As Exception
            CSDebug.dispError("AgentPCManager.RAZInstall ERR", ex)
        End Try

    End Sub
    Public Shared Sub ResetDB()

        Dim oCSDB As New CSDb(True)
        oCSDB.Execute("DELETE FROM AGENTPC;")
        oCSDB.Execute("DELETE FROM POOL;")
        oCSDB.Execute("DELETE FROM POOLMANOC;")
        oCSDB.Execute("DELETE FROM POOLMANOE;")
        oCSDB.Execute("ALTER TABLE Agent DROP COLUMN idCRODIPPOOL;")
        oCSDB.Execute("ALTER TABLE IdentifiantPulverisateur DROP COLUMN idCRODIPPOOL;")


    End Sub



End Class
