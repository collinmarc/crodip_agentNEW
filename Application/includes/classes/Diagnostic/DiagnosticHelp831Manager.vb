Imports System.Collections.Generic

Public Class DiagnosticHelp831Manager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp8312ByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticHelp831
        Return getDiagnosticHelp831ByDiagnosticId(DiagnosticHelp831.ModeHelp831.Mode8312, pDiagnostic)
    End Function
    Public Shared Function getDiagnosticHelp8314ByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticHelp831
        Return getDiagnosticHelp831ByDiagnosticId(DiagnosticHelp831.ModeHelp831.Mode8314, pDiagnostic)
    End Function

    Private Shared Function getDiagnosticHelp831ByDiagnosticId(pMode As DiagnosticHelp831.ModeHelp831, ByVal pDiagnostic As Diagnostic) As DiagnosticHelp831
        ' On r�cup�re les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp831 As DiagnosticHelp831
        Dim bddCommande As OleDb.OleDbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help831
            Dim strIdItem As String
            If pMode = DiagnosticHelp831.ModeHelp831.Mode8312 Then
                strIdItem = "help8312"
            Else
                strIdItem = "help8314"
            End If
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = '" & strIdItem & "' ORDER BY IdItem, ItemValue"
            ' On r�cup�re les r�sultats
            Dim oDRDiagnosticItem As System.Data.OleDb.OleDbDataReader = bddCommande.ExecuteReader
            oHelp831 = New DiagnosticHelp831(pMode)
            oHelp831.id = 0
            oHelp831.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp831.id = oDRDiagnosticItem.GetString(0)
            End While
            If Not oHelp831.Load() Then
                oHelp831 = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp831Manager::getDiagnosticHelp831ByDiagnosticId : " & ex.Message)
            oHelp831 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp831
    End Function
    '''
    ''' Sauvegarde d'un Help831
    ''' Param�tres :
    Public Shared Function save(ByVal pHelp831 As DiagnosticHelp831, ByVal pStructureId As String, ByVal pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp831.Save(pStructureId, pAgentId)
        Catch ex As Exception
            Console.Write("Erreur DiagnosticHelp831Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp831Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp831Id), "DiagnosticItemid doit �tre inialis�")
        Dim bReturn As Boolean
        Try
            Dim oHelp831 As New DiagnosticHelp831(pDiagnosticHelp831Id, pIdDiagnostic)
            bReturn = oHelp831.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp831Manager.delete(" & pDiagnosticHelp831Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
