Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticHelp5622Manager



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp5622ByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticHelp5622
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp5622 As DiagnosticHelp5622
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help5622 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = 'help5622' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp5622 = New DiagnosticHelp5622()
            oHelp5622.id = 0
            oHelp5622.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp5622.id = oDRDiagnosticItem.GetString(0)
            End While
            If Not oHelp5622.Load() Then
                oHelp5622 = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp5622Manager::getDiagnosticHelp5622ByDiagnosticId : " & ex.Message)
            oHelp5622 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp5622
    End Function
    '''
    ''' Sauvegarde d'un Help5622
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp5622 As DiagnosticHelp5622, ByVal pStructureId As String, ByVal pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp5622.Save(pStructureId, pAgentId)
        Catch ex As Exception
            Console.Write("Erreur DiagnosticHelp5622Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp5622Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp5622Id), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oHelp5622 As New DiagnosticHelp5622(pDiagnosticHelp5622Id, pIdDiagnostic)
            bReturn = oHelp5622.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp5622Manager.delete(" & pDiagnosticHelp5622Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
