Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticHelp571Manager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp571ByDiagnosticId(oCSDB As CSDb, ByVal pDiagnostic As Diagnostic) As DiagnosticHelp571
        ' On r�cup�re les items du diagnostic
        Dim oHelp571 As DiagnosticHelp571
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help571 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = '" & DiagnosticHelp571.DIAGITEM_ID & "' ORDER BY IdItem, ItemValue"
            ' On r�cup�re les r�sultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp571 = New DiagnosticHelp571()
            oHelp571.id = 0
            oHelp571.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp571.id = oDRDiagnosticItem.GetString(0)
                oHelp571.Load()
            End While
            oDRDiagnosticItem.Close()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp571Manager::getDiagnosticHelp571ByDiagnosticId : " & ex.Message)
            oHelp571 = Nothing
        End Try

        Return oHelp571
    End Function
    '''
    ''' Sauvegarde d'un Help571
    ''' Param�tres :
    Public Shared Function save(ByVal pHelp571 As DiagnosticHelp571, ByVal pStructureId As String, ByVal pAgentId As String, pCSDb As CSDb) As Boolean
        Debug.Assert(pCSDb.isOpen(), "La Connection Doit �tre ouverte")

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp571.Save(pStructureId, pAgentId, pCSDb)
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticHelp571Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp571Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp571Id), "DiagnosticItemid doit �tre inialis�")
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
