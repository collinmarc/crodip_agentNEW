
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
                ''Lecture du Diag
                oDiag = DiagnosticManager.WSgetById(pAgent.uid, Me.IdentifiantChaine)
                Dim lst As DiagnosticItemList
                'Récupération des DiagItems
                lst = DiagnosticItemManager.WSGetList(oDiag.uid, oDiag.id)
                For Each oDiagItem In lst.Liste
                    oDiag.AdOrReplaceDiagItem(oDiagItem)
                Next
                'Récupération des buses
                Dim lstdiagbuses As DiagnosticBusesList
                lstdiagbuses = DiagnosticBusesManager.WSGetList(oDiag.uid, oDiag.aid)
                For Each oDiagBuse As DiagnosticBuses In lstdiagbuses.Liste
                    oDiag.diagnosticBusesList.Liste.Add(oDiagBuse)
                Next
                'Récupération du détail des buses
                Dim lstDiagbusesDetail As DiagnosticBusesDetailList
                lstDiagbusesDetail = DiagnosticBusesDetailManager.WSGetList(oDiag.uid, oDiag.aid)
                For Each oDetail As DiagnosticBusesDetail In lstDiagbusesDetail.Liste
                    Dim obuse As DiagnosticBuses
                    obuse = oDiag.diagnosticBusesList.Liste.Where(Function(b)
                                                                      Return b.id = oDetail.idBuse
                                                                  End Function).FirstOrDefault()
                    If obuse IsNot Nothing Then
                        obuse.diagnosticBusesDetailList.Liste.Add(oDetail)
                    End If
                Next
                'Récupération des Mano542
                Dim lstdiagMano542 As DiagnosticMano542List
                lstdiagMano542 = DiagnosticMano542Manager.WSGetList(oDiag.uid, oDiag.aid)
                For Each oDiagMano542 As DiagnosticMano542 In lstdiagMano542.Liste
                    oDiag.diagnosticMano542List.Liste.Add(oDiagMano542)
                Next
                'Récupération des Troncons833
                Dim lstdiagT833 As DiagnosticTroncons833List
                lstdiagT833 = DiagnosticTroncons833Manager.WSGetList(oDiag.uid, oDiag.aid)
                For Each oDiagT833 As DiagnosticTroncons833 In lstdiagT833.Liste
                    oDiag.diagnosticTroncons833.Liste.Add(oDiagT833)
                Next


                'Sauvegarde du Diag
                DiagnosticManager.save(oDiag, True)

                bReturn = True
            Catch ex As Exception
                CSDebug.dispFatal("Synchronisation::runDescSynchro(GetDiagnostic) : " & ex.Message.ToString)
                bReturn = False
            End Try
        End If

    End Function
End Class
