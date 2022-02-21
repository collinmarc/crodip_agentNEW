Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticHelp551Manager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"

    Public Shared Function getDiagnosticHelp551ByDiagnosticId(pDiagnostic As Diagnostic) As DiagnosticHelp551
        Return getDiagnosticHelp551ByDiagnosticId(DiagnosticHelp551.Help551Mode.Mode551, pDiagnostic)
    End Function
    Public Shared Function getDiagnosticHelp12323ByDiagnosticId(pDiagnostic As Diagnostic) As DiagnosticHelp551
        Return getDiagnosticHelp551ByDiagnosticId(DiagnosticHelp551.Help551Mode.Mode12323, pDiagnostic)
    End Function

    Private Shared Function getDiagnosticHelp551ByDiagnosticId(pMode As DiagnosticHelp551.Help551Mode, pDiagnostic As Diagnostic) As DiagnosticHelp551
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp551 As DiagnosticHelp551
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            Dim strIdItem As String = ""
            Select Case pMode
                Case DiagnosticHelp551.Help551Mode.Mode551
                    strIdItem = "help551"
                Case DiagnosticHelp551.Help551Mode.Mode5621
                    strIdItem = "help5621"
                Case DiagnosticHelp551.Help551Mode.Mode12323
                    strIdItem = "help12323"
            End Select
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = '" & strIdItem & "' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp551 = New DiagnosticHelp551(pMode)
            oHelp551.id = "0"
            oHelp551.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp551.id = oDRDiagnosticItem.GetString(0)
                oHelp551.Load()
            End While
            oDRDiagnosticItem.Close()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp551Manager::getDiagnosticHelp551ByDiagnosticId : " & ex.Message)
            oHelp551 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp551
    End Function
    '''
    ''' Sauvegarde d'un Help551
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp551 As DiagnosticHelp551, pStructureId As String, pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp551.Save(pStructureId, pAgentId)
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticHelp551Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp551Id As String, pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp551Id), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oHelp551 As New DiagnosticHelp551(pDiagnosticHelp551Id, pIdDiagnostic)
            bReturn = oHelp551.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp551Manager.delete(" & pDiagnosticHelp551Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
