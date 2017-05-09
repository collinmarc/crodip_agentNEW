Imports System.Collections.Generic

Public Class DiagnosticHelp811Manager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp811ByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticHelp811
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp811 As DiagnosticHelp811
        Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help811 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = 'help811' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            oHelp811 = New DiagnosticHelp811()
            oHelp811.id = 0
            oHelp811.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp811.id = oDRDiagnosticItem.GetString(0)
            End While
            If Not oHelp811.Load() Then
                oHelp811 = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp811Manager::getDiagnosticHelp811ByDiagnosticId : " & ex.Message)
            oHelp811 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp811
    End Function
    '''
    ''' Sauvegarde d'un Help811
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp811 As DiagnosticHelp811, ByVal pStructureId As String, ByVal pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp811.Save(pStructureId, pAgentId)
        Catch ex As Exception
            Console.Write("Erreur DiagnosticHelp811Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp811Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp811Id), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oHelp811 As New DiagnosticHelp811(pDiagnosticHelp811Id, pIdDiagnostic)
            bReturn = oHelp811.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp811Manager.delete(" & pDiagnosticHelp811Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
