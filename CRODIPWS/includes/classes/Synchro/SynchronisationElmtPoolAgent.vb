Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
''' <summary>
''' SynchronisationElmtIdentifiantPulverisateur
''' Element de Synchronistation d'un identifiant Pulv�risateur
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationElmtPoolAgent
    Inherits SynchronisationElmt
    Public Sub New(pSynchroBoleans As SynchroBooleans)
        MyBase.New(getLabelGet(), pSynchroBoleans)
        IdentifiantEntier = 0
        IdentifiantChaine = ""
        ValeurAuxiliaire = ""
    End Sub
    'constructeur Sans param�tre utilis� uniquement pour la s�rialisation
    Public Sub New()
        MyBase.New(getLabelGet(), New SynchroBooleans)
        IdentifiantEntier = 0
        IdentifiantChaine = ""
        ValeurAuxiliaire = ""
    End Sub

    Public Shared Function getLabelGet() As String
        Return "GetPoolAgent"
    End Function
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            Dim obj As New PoolAgent
            Try
                obj = PoolAgentManager.WSgetById(Me.IdentifiantEntier, Me.IdentifiantChaine)
                If obj.uid <> 0 Then
                    bReturn = PoolAgentManager.Save(obj, True)
                    Dim oAgent As Agent = AgentManager.getByKey(obj.uidagent)
                    If oAgent Is Nothing Then
                        oAgent = AgentManager.WSgetByNumeroNational(obj.aidagent, False)
                        If oAgent IsNot Nothing Then
                            AgentManager.save(oAgent)
                        End If
                    End If
                Else
                    bReturn = False
                End If
            Catch ex As Exception
                CSDebug.dispError("SynchronisationElmtPoolAgent.SynchroDesc(" & Me.IdentifiantEntier & ") ERR : " & ex.Message.ToString)
                bReturn = False
            End Try

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtPoolAgent.SynhcroDesc (" & Me.IdentifiantEntier & ")ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Synhcronisation Ascendante des PoolAgent
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function SynchroAsc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean = False
        Return bReturn
    End Function

End Class
