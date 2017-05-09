Imports System.Collections.Generic

Public Class DiagnosticHelp571Manager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp571ByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticHelp571
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp571 As DiagnosticHelp571
        Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help571 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = '" & DiagnosticHelp571.DIAGITEM_ID & "' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            oHelp571 = New DiagnosticHelp571()
            oHelp571.id = 0
            oHelp571.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp571.id = oDRDiagnosticItem.GetString(0)
            End While
            If Not oHelp571.Load() Then
                oHelp571 = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp571Manager::getDiagnosticHelp571ByDiagnosticId : " & ex.Message)
            oHelp571 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp571
    End Function
    '''
    ''' Sauvegarde d'un Help571
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp571 As DiagnosticHelp571, ByVal pStructureId As String, ByVal pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp571.Save(pStructureId, pAgentId)
        Catch ex As Exception
            Console.Write("Erreur DiagnosticHelp571Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp571Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp571Id), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oHelp571 As New DiagnosticHelp571(pDiagnosticHelp571Id, pIdDiagnostic)
            bReturn = oHelp571.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp571Manager.delete(" & pDiagnosticHelp571Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
