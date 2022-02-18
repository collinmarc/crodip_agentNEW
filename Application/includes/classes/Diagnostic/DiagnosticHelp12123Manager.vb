Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticHelp12123Manager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp12123ByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticHelp12123
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp12123 As DiagnosticHelp12123
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help12123 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = '" & DiagnosticHelp12123.DIAGITEM_ID & "' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp12123 = New DiagnosticHelp12123()
            oHelp12123.id = 0
            oHelp12123.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp12123.id = oDRDiagnosticItem.GetString(0)
            End While
            oDRDiagnosticItem.Close()
            If Not oHelp12123.Load() Then
                oHelp12123 = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123Manager::getDiagnosticHelp12123ByDiagnosticId : " & ex.Message)
            oHelp12123 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp12123
    End Function
    '''
    ''' Sauvegarde d'un Help12123
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp12123 As DiagnosticHelp12123, ByVal pStructureId As String, ByVal pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp12123.Save(pStructureId, pAgentId)
        Catch ex As Exception
            Console.Write("Erreur DiagnosticHelp12123Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp12123Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp12123Id), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oHelp12123 As New DiagnosticHelp12123(pDiagnosticHelp12123Id, pIdDiagnostic)
            bReturn = oHelp12123.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp12123Manager.delete(" & pDiagnosticHelp12123Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
