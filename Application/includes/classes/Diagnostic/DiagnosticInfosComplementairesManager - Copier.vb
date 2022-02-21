Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticInfosComplementaireManager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticInfosComplementairesByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticInfosComplementaires
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oInfosComplementaires As DiagnosticInfosComplementaires
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem InfosComplementaires 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = '" & DiagnosticInfosComplementaires.DIAGITEM_ID & "' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oInfosComplementaires = New DiagnosticInfosComplementaires()
            oInfosComplementaires.id = 0
            oInfosComplementaires.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oInfosComplementaires.id = oDRDiagnosticItem.GetString(0)
            End While
            If Not oInfosComplementaires.Load() Then
                oInfosComplementaires = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticInfosComplementairesManager::getDiagnosticInfosComplementairesByDiagnosticId : " & ex.Message)
            oInfosComplementaires = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oInfosComplementaires
    End Function
    '''
    ''' Sauvegarde d'un InfosComplementaires
    ''' Paramètres :
    Public Shared Function save(ByVal pInfosComplementaires As DiagnosticInfosComplementaires, ByVal pStructureId As String, ByVal pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pInfosComplementaires.Save(pStructureId, pAgentId)
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticInfosComplementairesManager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticInfosComplementairesId As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticInfosComplementairesId), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oInfosComplementaires As New DiagnosticInfosComplementaires(pDiagnosticInfosComplementairesId, pIdDiagnostic)
            bReturn = oInfosComplementaires.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticInfosComplementairesManager.delete(" & pDiagnosticInfosComplementairesId & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
