Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
''' <summary>
''' SynchronisationElmtIdentifiantOTC
''' Element de Synchronistation d'un identifiant Pulvérisateur
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationElmtIdentifiantOTC
    Inherits SynchronisationElmt
    Public Sub New(pSynchroBoleans As SynchroBooleans)
        MyBase.New(getLabelGet(), pSynchroBoleans)
        IdentifiantEntier = 0
        IdentifiantChaine = ""
        ValeurAuxiliaire = ""
    End Sub
    'constructeur Sans paramètre utilisé uniquement pour la sérialisation
    Public Sub New()
        MyBase.New(getLabelGet(), New SynchroBooleans)
        IdentifiantEntier = 0
        IdentifiantChaine = ""
        ValeurAuxiliaire = ""
    End Sub

    Public Shared Function getLabelGet() As String
        Return "GetIdentifiantOTC"
    End Function
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oIdentPulve As New IdentifiantOTC
            Try
                oIdentPulve = IdentifiantOTCManager.WSgetById(Me.IdentifiantEntier, Me.IdentifiantChaine, pAgent.uid)
                If oIdentPulve.identifiant <> "" Then
                    bReturn = IdentifiantOTCManager.Save(oIdentPulve)
                Else
                    bReturn = False
                End If
            Catch ex As Exception
                CSDebug.dispError("SynchronisationElmtIdentifiantOTC.SynchroDesc(" & Me.IdentifiantEntier & ") ERR : " & ex.Message.ToString)
                bReturn = False
            End Try

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtIdentifiantOTC.SynhcroDesc (" & Me.IdentifiantEntier & ")ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Synhcronisation Ascendante des IdentifiantPulverisateur
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Shared Function SynchroAsc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean = False
        Try
            Dim codereponse As Integer = 99
            ' Synchro des Identifiants Pulvés
            Dim arrUpdatesIdentifiantPulverisateur() As IdentifiantPulverisateur = IdentifiantPulverisateurManager.getUpdates(pAgent)
            bReturn = True
            For Each oIdentPulve As IdentifiantPulverisateur In arrUpdatesIdentifiantPulverisateur
                Dim oReturn As IdentifiantPulverisateur = Nothing
                codereponse = IdentifiantPulverisateurManager.WSSend(oIdentPulve, oReturn, pAgent.uid)
                Select Case codereponse
                    Case -1 ' ERROR
                        CSDebug.dispFatal("SynchronisationElmtIdentifiantOTC::SynchrAsc - Erreur Locale")
                    Case 0, 2 ' OK
                        IdentifiantPulverisateurManager.Save(oReturn, True)
                    Case 1 ' NOK
                        CSDebug.dispWarn("SynchronisationElmtIdentifiantOTC::SynchrAsc - Le web service a répondu : Non-Ok")
                    Case 9 ' BADREQUEST
                        CSDebug.dispFatal("SynchronisationElmtIdentifiantOTC::SynchrAsc - Le web service a répondu : BadRequest")
                End Select
            Next

        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtIdentifiantOTC.SynhcroAsc ERR", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function

End Class
