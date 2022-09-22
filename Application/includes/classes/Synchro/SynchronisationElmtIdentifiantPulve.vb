Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
''' <summary>
''' SynchronisationElmtIdentifiantPulverisateur
''' Element de Synchronistation d'un identifiant Pulvérisateur
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
    'constructeur Sans paramètre utilisé uniquement pour la sérialisation
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
                oIdentPulve = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(pAgent, Me.IdentifiantEntier)
                If oIdentPulve.id <> 0 Then
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
        Dim bReturn As Boolean
        Try
            bReturn = True
            ' Synchro des Identifiants Pulvés
            Dim arrUpdatesIdentifiantPulverisateur() As IdentifiantPulverisateur = IdentifiantPulverisateurManager.getUpdates(pAgent)
            For Each oIdentPulve As IdentifiantPulverisateur In arrUpdatesIdentifiantPulverisateur
                bReturn = IdentifiantPulverisateurManager.sendWSIdentifiantPulverisateur(pAgent, oIdentPulve)
            Next

        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtIdentifiantPulverisateur.SynhcroAsc ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function

End Class
