
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
                oDiag = DiagnosticManager.WSgetById(pAgent.uid, Me.IdentifiantEntier, Me.IdentifiantChaine)
                If oDiag IsNot Nothing Then
                    Dim lst As DiagnosticItemList
                    'Récupération des DiagItems
                    lst = DiagnosticItemManager.WSGetList(oDiag.uid, oDiag.aid)
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
                                                                          Return b.idLot = oDetail.idLot
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


                    'Vérification du propriétaire
                    Dim oExploit As Exploitation
                    Dim oPulve As Pulverisateur
                    If oDiag.uidexploitation <> 0 Then
                        oExploit = ExploitationManager.getExploitationById(oDiag.proprietaireId)
                        If oExploit.id = "" Then
                            CSDebug.dispInfo("SynchronisationDiag.SynchroDesc, le propriétaireId[" & oDiag.proprietaireId & "] est absent, je le récupère par WS")
                            oExploit = ExploitationManager.WSgetById(oDiag.uidexploitation, oDiag.proprietaireId)
                            If oExploit IsNot Nothing Then 'pour eviter des msg d'erreurs dans le log si pblm de UTF8
                                ExploitationManager.save(oExploit, _Agent)
                            End If
                        End If
                        If oDiag.uidpulverisateur <> 0 Then
                            oPulve = PulverisateurManager.getPulverisateurById(oDiag.pulverisateurId)
                            If oPulve.id = "" Then
                                CSDebug.dispInfo("SynchronisationDiag.SynchroDesc, le pulverisateurId[" & oDiag.pulverisateurId & "] est absent, je le récupère par WS")
                                oPulve = PulverisateurManager.WSgetById(oDiag.uidpulverisateur, oDiag.pulverisateurId)
                                PulverisateurManager.save(oPulve, oExploit, _Agent)
                            End If
                        End If
                    End If

                    'Sauvegarde du Diag
                    DiagnosticManager.save(oDiag, True)

                    bReturn = True
                Else
                    CSDebug.dispFatal("SynchronisationElmtDiag.SynchroDesc : Diagnostic non trouvé uid=[" & Me.IdentifiantEntier & "], aid=[" & Me.IdentifiantChaine & "]")
                End If
            Catch ex As Exception
                CSDebug.dispFatal("SynchronisationElmtDiag.SynchroDesc ERR: ", ex)
                bReturn = False
            End Try
        End If
        Return bReturn

    End Function
End Class
