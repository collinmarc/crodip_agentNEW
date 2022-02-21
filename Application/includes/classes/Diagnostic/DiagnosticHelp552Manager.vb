Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticHelp552Manager
    ' Variables
    Dim query As String
    'Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp552ByDiagnosticId(pDiagnostic As Diagnostic) As DiagnosticHelp552
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp552 As DiagnosticHelp552
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help552 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = 'help552' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp552 = New DiagnosticHelp552()
            oHelp552.id = 0
            oHelp552.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp552.id = oDRDiagnosticItem.GetString(0)
            End While
            If Not oHelp552.Load() Then
                oHelp552 = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp552Manager::getDiagnosticHelp552ByDiagnosticId : " & ex.Message)
            oHelp552 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp552
    End Function
    '''
    ''' Sauvegarde d'un Help552
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp552 As DiagnosticHelp552, pStructureId As String, pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp552.Save(pStructureId, pAgentId)
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticHelp552Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp552Id As String, pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp552Id), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oHelp552 As New DiagnosticHelp552(pDiagnosticHelp552Id, pIdDiagnostic)
            bReturn = oHelp552.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp552Manager.delete(" & pDiagnosticHelp552Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
