
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
Public Class SynchronisationElmtFVBanc
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
                oIdentPulve = IdentifiantPulverisateurManager.getWSIdentifiantPulverisateurById(pAgent, Me.identifiantEntier)
                If oIdentPulve.id <> 0 Then
                    bReturn = IdentifiantPulverisateurManager.Save(oIdentPulve, True)
                Else
                    bReturn = False
                End If
            Catch ex As Exception
                CSDebug.dispFatal("SynchronisationElmtIdentifiantPulverisateur.SynchroDesc ERR : " & ex.Message.ToString)
                bReturn = False
            End Try

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtIdentifiantPulverisateur.SynhcroDesc ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


End Class
