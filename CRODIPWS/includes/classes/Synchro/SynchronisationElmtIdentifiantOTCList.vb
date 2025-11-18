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
Public Class SynchronisationElmtIdentifiantOTCList
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
        Return "GetIdentifiantOTCList"
    End Function
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oListe As New List(Of IdentifiantOTC)
            oListe = IdentifiantOTCManager.WSGetList(IdentifiantChaine)
            IdentifiantOTCManager.SaveList(oListe, False)
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("SynchronisationElmtIdentifiantOTCList.SynhcroDesc (" & Me.IdentifiantChaine & ")ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Overloads Shared Function SynchroAsc(pAgent As Agent) As Boolean
        Dim bReturn As Boolean = False
        Return bReturn

    End Function

End Class
