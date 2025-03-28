Imports System.Collections.Generic
Imports System.Data.Common
Imports Microsoft.Win32

Public Class AgentPCOLDManager
    Inherits RootManager

#Region "Methodes Web Service"

    Public Shared Function getWSAgentPCOLDById(pAgent As Agent, ByVal pmanometre_uid As Integer) As AgentPCOLD
        Dim oreturn As AgentPCOLD
        oreturn = RootWSGetById(Of AgentPCOLD)(pmanometre_uid, "")
        Return oreturn
    End Function

    Public Shared Function SendWSAgentPCOLD(pAgent As Agent, ByVal pManometre As AgentPCOLD, ByRef pReturn As AgentPCOLD) As Integer
        Dim nreturn As Integer
        Try
            nreturn = RootWSSend(Of AgentPCOLD)(pManometre, pReturn)

        Catch ex As Exception
            CSDebug.dispFatal("sendWSAgentPCOLD : " & ex.Message)
            nreturn = -1
        End Try
        Return nreturn
    End Function
#End Region
#Region "Methodes Locales"
    ''' Cette méthode n'est plus utilisée depuis la 2.5.4.3 , car les matériels sont créés sur le Serveur 

    Public Shared Function save(ByVal objAgentPCOLD As AgentPCOLD, Optional bsynchro As Boolean = False) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(objAgentPCOLD.idCrodip), "L'Id doit être inititialisé")
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Try
            oCsdb = New CSDb(True)
            Dim n As Integer = oCsdb.getValue("SELECT Count(*) FROM AgentPCOLD Where IDCRODIP = '" & objAgentPCOLD.idCrodip & "'")
            oCsdb.free()
            bReturn = True
            If n = 0 Then
                bReturn = createAgentPCOLD(objAgentPCOLD)
            End If
            If bReturn Then
                oCsdb = New CSDb(True)
                bddCommande = oCsdb.getConnection().CreateCommand()

                ' Initialisation de la requete
                Dim paramsQuery As String = "idCrodip=" & objAgentPCOLD.idCrodip & ""

                ' Mise a jour de la date de derniere modification
                If Not bsynchro Then
                    objAgentPCOLD.dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
                Else
                    objAgentPCOLD.dateModificationAgent = objAgentPCOLD.dateModificationCrodip

                End If


                If objAgentPCOLD.uidstructure <> 0 Then
                    paramsQuery = paramsQuery & " , idStructure=" & objAgentPCOLD.uidstructure & ""
                End If
                If Not objAgentPCOLD.idCrodip Is Nothing Then
                    paramsQuery = paramsQuery & " , idCrodip='" & CSDb.secureString(objAgentPCOLD.idCrodip) & "'"
                End If
                If Not String.IsNullOrEmpty(objAgentPCOLD.libelle) Then
                    paramsQuery = paramsQuery & " , libelle='" & CSDb.secureString(objAgentPCOLD.libelle) & "'"
                End If
                If Not String.IsNullOrEmpty(objAgentPCOLD.numInterne) Then
                    paramsQuery = paramsQuery & " , numInterne='" & CSDb.secureString(objAgentPCOLD.numInterne) & "'"
                End If
                paramsQuery = paramsQuery & " , dateModificationAgent='" & CSDate.ToCRODIPString(objAgentPCOLD.dateModificationAgent) & "'"
                paramsQuery = paramsQuery & " , dateModificationCrodip='" & CSDate.ToCRODIPString(objAgentPCOLD.dateModificationCrodip) & "'"

                ' On finalise la requete et en l'execute
                bddCommande.CommandText = "UPDATE AgentPCOLD SET " & paramsQuery & " WHERE idCrodip='" & objAgentPCOLD.idCrodip & "'"
                bddCommande.ExecuteNonQuery()
                bReturn = True
            End If

        Catch ex As Exception
            CSDebug.dispError("AgentPCOLDManager.Save ERR: ", ex)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function

    Public Shared Function getAgentPCOLDByIdCRODIP(ByVal pid As String) As AgentPCOLD
        'Debug.Assert(pid <> 0, "ID doit être initialisé")
        Dim oReturn As AgentPCOLD = Nothing
        Try

            oReturn = getByKey(Of AgentPCOLD)("SELECT * FROM AgentPCOLD WHERE idCRODIP='" & pid & "'")


        Catch ex As Exception
            CSDebug.dispError("AgentPCOLDManager.getAgentPCOLDByIdCRODIP ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
#End Region
    '''
    ''' Marque l'utilisation du AgentPCOLD (Flag isUtilisé, date de dernier controle, création de la fiche de vie)
    '''
    '''
    ''' création d'un enregistrement AgentPCOLD
    ''' L'ID doit êre initialisé
    '''
    Private Shared Function createAgentPCOLD(ByVal pAgentPCOLD As AgentPCOLD) As Boolean
        Debug.Assert(pAgentPCOLD IsNot Nothing, "pAgentPCOLD doit être initialisé")
        Debug.Assert(Not String.IsNullOrEmpty(pAgentPCOLD.idCrodip), "IDCrodip doit être initialisé")
        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)
        Try
            Dim bddCommande As DbCommand
            bddCommande = oCSDB.getConnection().CreateCommand()

            ' Création
            bddCommande.CommandText = "INSERT INTO AgentPCOLD (idCrodip) values ('" & pAgentPCOLD.idCrodip & "')"
            bddCommande.ExecuteNonQuery()

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("AgentPCOLDManager.createAgentPCOLD error : " & ex.Message)
            bReturn = False
        End Try
        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return bReturn
    End Function 'CreateAgentPCOLD

    Public Overloads Shared Function GetListe() As List(Of AgentPCOLD)
        Dim oList As New List(Of AgentPCOLD)
        Try
            oList = getListe(Of AgentPCOLD)("SELECT* FROM AgentPCOLD")

        Catch ex As Exception
            CSDebug.dispError("PoolManager.GetListe ERR", ex)
            oList = New List(Of AgentPCOLD)()
        End Try
        Return oList

    End Function

    'Public Shared Function RESTgetAgentPCOLDByIDCrodip(pAgent As Agent, pidCrodip As String) As AgentPCOLD
    '    Dim oReturn As AgentPCOLD = Nothing
    '    Try
    '        oReturn = RESTgetByID(Of AgentPCOLD)("getAgentPCOLD", pAgent, pidCrodip)
    '    Catch ex As Exception
    '        CSDebug.dispError("AgentPCOLDManager.RESTgetAgentPCOLDByidCrodip ERR", ex)
    '    End Try
    '    Return oReturn
    'End Function

    'Public Shared Function RESTgetAgentPCOLDs(pAgent As Agent) As List(Of AgentPCOLD)
    '    Dim oReturn As New List(Of AgentPCOLD)
    '    Try

    '        oReturn = RESTgetList(Of AgentPCOLD)("getAgentPCOLD", pAgent)
    '    Catch ex As Exception
    '        CSDebug.dispError("PoolManager.RESTgetPools ERR", ex)
    '    End Try
    '    Return oReturn
    'End Function

    'Public Shared Function RESTsetAgentPCOLD(pAgent As Agent, pobj As AgentPCOLD) As Boolean
    '    Dim oReturn As Boolean
    '    Try
    '        oReturn = RESTset(Of AgentPCOLD)("setAgentPCOLD", pAgent, pobj)

    '    Catch ex As Exception
    '        CSDebug.dispError("AgentPCOLDManager.RESTsetPool ERR", ex)
    '    End Try
    '    Return oReturn
    'End Function

    Public Shared Sub RAZInstall()
        Try

            Dim oCSDB As New CSDb(True)
            oCSDB.Execute("UPDATE POOL SET idCRODIPPC = NULL")
            oCSDB.Execute("DELETE FROM AgentPCOLD")
            oCSDB.free()
            Registry.CurrentUser.DeleteSubKeyTree("CRODIP")
        Catch ex As Exception
            CSDebug.dispError("AgentPCOLDManager.RAZInstall ERR", ex)
        End Try

    End Sub
    Public Shared Sub ResetDB()

        Dim oCSDB As New CSDb(True)
        oCSDB.Execute("DELETE FROM AgentPCOLD;")
        oCSDB.Execute("DELETE FROM POOL;")
        oCSDB.Execute("DELETE FROM POOLMANOC;")
        oCSDB.Execute("DELETE FROM POOLMANOE;")
        oCSDB.Execute("ALTER TABLE Agent DROP COLUMN idCRODIPPOOL;")
        oCSDB.Execute("ALTER TABLE IdentifiantPulverisateur DROP COLUMN idCRODIPPOOL;")


    End Sub



End Class
