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
Public Class SynchronisationElmtIdentifiantPulverisateur
    Inherits SynchronisationElmt
    Public Sub New(pSynchroBoleans As SynchroBooleans)
        MyBase.New(getLabelGet(), pSynchroBoleans)
        identifiantEntier = 0
        identifiantChaine = ""
        valeurAuxiliaire = ""
    End Sub
    'constructeur Sans param�tre utilis� uniquement pour la s�rialisation
    Public Sub New()
        MyBase.New(getLabelGet(), New SynchroBooleans)
        identifiantEntier = 0
        identifiantChaine = ""
        valeurAuxiliaire = ""
    End Sub

    Public Shared Function getLabelGet() As String
        Return "GetIdentifiantPulverisateur"
    End Function
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oIdentPulve As New IdentifiantPulverisateur
            Try
                oIdentPulve = IdentifiantPulverisateurManager.WSgetById(Me.IdentifiantEntier, Me.IdentifiantChaine, pAgent.uid)
                If oIdentPulve.uid <> 0 Then
                    bReturn = IdentifiantPulverisateurManager.Save(oIdentPulve, True)
                Else
                    bReturn = False
                End If
            Catch ex As Exception
                CSDebug.dispError("SynchronisationElmtIdentifiantPulverisateur.SynchroDesc(" & Me.identifiantEntier & ") ERR : " & ex.Message.ToString)
                bReturn = False
            End Try

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtIdentifiantPulverisateur.SynhcroDesc (" & Me.identifiantEntier & ")ERR" & ex.Message)
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
            ' Synchro des Identifiants Pulv�s
            Dim arrUpdatesIdentifiantPulverisateur() As IdentifiantPulverisateur = IdentifiantPulverisateurManager.getUpdates(pAgent)
            bReturn = True
            For Each oIdentPulve As IdentifiantPulverisateur In arrUpdatesIdentifiantPulverisateur
                Dim oReturn As IdentifiantPulverisateur = Nothing
                codereponse = IdentifiantPulverisateurManager.WSSend(oIdentPulve, oReturn, pAgent.uid)
                Select Case codereponse
                    Case -1 ' ERROR
                        CSDebug.dispFatal("SynchronisationElmtIdentifiantPulverisateur::SynchrAsc - Erreur Locale")
                    Case 0, 2 ' OK
                        IdentifiantPulverisateurManager.Save(oReturn, True)
                    Case 1 ' NOK
                        CSDebug.dispWarn("SynchronisationElmtIdentifiantPulverisateur::SynchrAsc - Le web service a r�pondu : Non-Ok")
                    Case 9 ' BADREQUEST
                        CSDebug.dispFatal("SynchronisationElmtIdentifiantPulverisateur::SynchrAsc - Le web service a r�pondu : BadRequest")
                End Select
            Next

        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtIdentifiantPulverisateur.SynhcroAsc ERR", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function

End Class
