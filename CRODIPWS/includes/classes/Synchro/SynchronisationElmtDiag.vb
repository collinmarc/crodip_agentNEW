
Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports Crodip_agent
''' <summary>
''' SynchronisationElmtIdentifiantPulverisateur
''' Element de Synchronistation d'un Diagnostic
''' </summary>
''' <remarks></remarks>
Public Class SynchronisationElmtDiag
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
        Return "GetDiagnostic"
    End Function
    ''' <summary>
    ''' Synhcronisation descendante d'un dig
    ''' => synhcro des DiagItems, DigBuses, diagbusesdetail,Mano542, troncon833
    ''' </summary>
    ''' <param name="pAgent"></param>
    ''' <returns></returns>
    Public Overrides Function SynchroDesc(pAgent As Agent) As Boolean

        Dim bReturn As Boolean
        If (m_SynchroBoolean.m_bSynchDescDiag) Then
            Dim oDiag As New Diagnostic
            Try
                SetStatus("Réception MAJ contrôle n°" & Me.IdentifiantChaine & "...")
                oDiag = DiagnosticManager.getWSDiagnosticById(pAgent.id, Me.IdentifiantChaine)
                DiagnosticManager.save(oDiag, True)

                bReturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnostic) : " & ex.Message.ToString)
                bReturn = False
            End Try
        End If
        If (m_SynchroBoolean.m_bSynchDescDiag) Then
            Dim odiag As Diagnostic
            Try
                SetStatus("Réception MAJ item de contrôle n°" & Me.IdentifiantChaine & "...")
                Dim oCSDB As New CSDb(True)
                odiag = DiagnosticItemManager.getWSDiagnosticItemsByDiagnosticId(pAgent, Me.IdentifiantChaine)
                DiagnosticManager.SaveDiagItems(oCSDB, odiag, False, True)
                oCSDB.free()
                bReturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticItems) : " & ex.Message.ToString)
                bReturn = False
            End Try
        End If


        If (m_SynchroBoolean.m_bSynchDescDiag) Then
            Dim tmpObjectList As DiagnosticBusesList
            Dim tmpObject As DiagnosticBuses
            Try
                SetStatus("Réception MAJ buse de contrôle n°" & Me.IdentifiantChaine & "...")
                tmpObjectList = DiagnosticBusesManager.getWSDiagnosticBusesByDiagId(pAgent.id, Me.IdentifiantChaine)
                Dim oCSDB As New CSDb(True)
                For Each tmpObject In tmpObjectList.Liste
                    DiagnosticBusesManager.save(tmpObject, oCSDB, True)
                Next
                oCSDB.free()
                bReturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBuses) : " & ex.Message.ToString)
                bReturn = False
            End Try
        End If
        If (m_SynchroBoolean.m_bSynchDescDiag) Then
            Dim tmpObjectList As New DiagnosticBusesDetailList
            Dim tmpObject As New DiagnosticBusesDetail
            Try
                SetStatus("Réception MAJ détail des buse de contrôle n°" & Me.IdentifiantChaine & "...")
                tmpObjectList = DiagnosticBusesDetailManager.getWSDiagnosticBusesDetailByDiagId(pAgent.id, Me.IdentifiantChaine)
                For Each tmpObject In tmpObjectList.Liste
                    DiagnosticBusesDetailManager.save(tmpObject, True)
                Next
                bReturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBusesDetail) : " & ex.Message.ToString)
                bReturn = False
            End Try
        End If
        If (m_SynchroBoolean.m_bSynchDescDiag) Then
            Dim tmpObjectList As New DiagnosticMano542List
            Dim tmpObject As New DiagnosticMano542
            Try
                SetStatus("Réception MAJ DiagnosticMano542 n°" & Me.IdentifiantChaine & "...")
                Dim oCSDB As New CSDb(True)
                tmpObjectList = DiagnosticMano542Manager.getWSDiagnosticMano542ByDiagId(pAgent.id, Me.IdentifiantChaine)
                For Each tmpObject In tmpObjectList.Liste
                    DiagnosticMano542Manager.save(tmpObject, oCSDB, True)
                Next
                oCSDB.free()
                bReturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBusesDetail) : " & ex.Message.ToString)
                bReturn = False
            End Try
        End If
        If (m_SynchroBoolean.m_bSynchDescDiag) Then
            Dim oManoTroncon833 As New DiagnosticTroncons833
            Dim oListManotroncon833 As New DiagnosticTroncons833List
            Try
                SetStatus("Réception MAJ DiagnosticTroncons833 n°" & Me.IdentifiantChaine & "...")
                Dim oCSDB As New CSDb(True)
                oListManotroncon833 = DiagnosticTroncons833Manager.getWSDiagnosticTroncons833ByDiagId(pAgent.id, Me.IdentifiantChaine)
                For Each oManoTroncon833 In oListManotroncon833.Liste
                    DiagnosticTroncons833Manager.save(oManoTroncon833, oCSDB, True)
                Next
                oCSDB.free()
                bReturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnosticBusesDetail) : " & ex.Message.ToString)
                bReturn = False
            End Try
        End If

    End Function
End Class
