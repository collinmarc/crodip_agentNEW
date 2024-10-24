Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticHelp5622Manager



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp5622ByDiagnosticId(oCSDB As CSDb, ByVal pDiagnostic As Diagnostic) As DiagnosticHelp5622
        ' On r�cup�re les items du diagnostic
        Dim oHelp5622 As DiagnosticHelp5622
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help5622 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = 'help5622' ORDER BY IdItem, ItemValue"
            ' On r�cup�re les r�sultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp5622 = New DiagnosticHelp5622()
            oHelp5622.id = 0
            oHelp5622.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp5622.id = oDRDiagnosticItem.GetString(0)
                oHelp5622.Load()
            End While
            oDRDiagnosticItem.Close()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp5622Manager::getDiagnosticHelp5622ByDiagnosticId : " & ex.Message)
            oHelp5622 = Nothing
        End Try

        Return oHelp5622
    End Function
    '''
    ''' Sauvegarde d'un Help5622
    ''' Param�tres :
    Public Shared Function save(ByVal pHelp5622 As DiagnosticHelp5622, ByVal pStructureId As String, ByVal pAgentId As String, pCSDb As CSDb) As Boolean
        Debug.Assert(pCSDb.isOpen(), "La Connection Doit �tre ouverte")

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp5622.Save(pStructureId, pAgentId, pCSDb)
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticHelp5622Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp5622Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp5622Id), "DiagnosticItemid doit �tre inialis�")
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
