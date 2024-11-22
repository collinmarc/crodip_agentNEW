
Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
''' <summary>
''' SynchronisationElmtIdentifiantPulverisateur
''' Element de Synchronistation d'un Diagnostic
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationElmtPulverisateur
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

    Public Sub New(pIdDiag As String)
        MyBase.New(getLabelGet(), New SynchroBooleans)
        IdentifiantEntier = 0
        IdentifiantChaine = pIdDiag
        ValeurAuxiliaire = ""
    End Sub
    Public Shared Function getLabelGet() As String
        Return "GetPulverisateur"
    End Function
    'On reste avec les méthodes Publiques de Synchro
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim breturn As Boolean = False
        If (m_SynchroBoolean.m_bSynchDescPulve) Then
            Dim tmpObject As New Pulverisateur
            Try
                SetStatus("Réception MAJ Pulvérisateur n°" & Me.IdentifiantChaine & "...")
                tmpObject = PulverisateurManager.WSgetById(Me.IdentifiantEntier, Me.IdentifiantChaine)
                If tmpObject IsNot Nothing Then
                    PulverisateurManager.save(tmpObject, Nothing, pAgent, True)
                End If
                breturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetPulverisateur) : " & ex.Message.ToString)
                breturn = False
            End Try
        End If
        Return breturn
    End Function


End Class
