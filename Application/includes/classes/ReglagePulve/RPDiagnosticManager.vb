Public Class RPDiagnosticManager
    Inherits DiagnosticManager

    Public Shared Function getRPDiagnosticById(ByVal pdiagnostic_id As String) As RPDiagnostic
        ' déclarations
        Dim oRPDiag As New RPDiagnostic
        oRPDiag.id = pdiagnostic_id
        If loadDiagnostic(oRPDiag) Then
            oRPDiag.oClientCourant = ExploitationManager.getExploitationById(oRPDiag.proprietaireId)
            oRPDiag.oPulverisateurCourant = PulverisateurManager.getPulverisateurById(oRPDiag.pulverisateurId)
            'Chargement du Paramètre de Diag
            oRPDiag.ParamDiag = oRPDiag.getParamDiag()
            If oRPDiag.ParamDiag IsNot Nothing Then
                'chargement des ParamCtrl
                Dim olstParamStrlDiag As New CRODIP_ControlLibrary.LstParamCtrlDiag()
                If olstParamStrlDiag.readXML(My.Settings.RepertoireParametres & "/" & oRPDiag.ParamDiag.fichierConfig) Then
                    'Maj des libellé courts et Libellé Long des DiagItem à partir de la liste des ParamCtrlDiag
                    For Each oDiagItem As DiagnosticItem In oRPDiag.diagnosticItemsLst.items
                        'uniquement pour les NON OK
                        If oDiagItem.itemCodeEtat <> DiagnosticItem.EtatDiagItemOK Then
                            Dim oParam As CRODIP_ControlLibrary.ParamCtrlDiag
                            oParam = olstParamStrlDiag.FindDiagItem(oDiagItem.getItemCode())
                            If oParam IsNot Nothing Then
                                oDiagItem.LibelleCourt = oParam.Libelle
                                oDiagItem.LibelleLong = oParam.LibelleLong
                            End If
                        End If
                    Next
                End If
            End If
            Return oRPDiag
        Else
            Return New RPDiagnostic()
        End If
    End Function

End Class
