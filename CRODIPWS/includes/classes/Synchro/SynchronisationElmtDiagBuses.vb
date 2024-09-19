
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
Public Class SynchronisationElmtDiagBuses
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
        Return "GetDiagnosticBuses"
    End Function

    'On reste avec les méthodes Publiques de Synchro
End Class
