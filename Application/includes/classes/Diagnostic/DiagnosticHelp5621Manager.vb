Imports System.Collections.Generic
Imports System.Data.Common

''' Classe de gestion du DiagnosticHelp5621
'''     Elle crée les objets , donc difficile à hériter de help551
Public Class DiagnosticHelp5621Manager
    ' Variables



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp5621ByDiagnosticId(ByVal pDiagnostic As Diagnostic) As DiagnosticHelp5621
        ' On récupère les items du diagnostic
        Dim oCSDB As New CSDb(True)
        Dim oHelp5621 As DiagnosticHelp5621
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help5621 
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = 'help5621' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp5621 = New DiagnosticHelp5621()
            oHelp5621.id = 0
            oHelp5621.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp5621.id = oDRDiagnosticItem.GetString(0)
            End While
            If Not oHelp5621.Load() Then
                oHelp5621 = Nothing
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp5621Manager::getDiagnosticHelp5621ByDiagnosticId : " & ex.Message)
            oHelp5621 = Nothing
        End Try

        If Not oCSDB Is Nothing Then
            oCSDB.free()
        End If
        Return oHelp5621
    End Function
    '''
    ''' Sauvegarde d'un Help5621
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp5621 As DiagnosticHelp5621, ByVal pStructureId As String, ByVal pAgentId As String) As Boolean

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp5621.Save(pStructureId, pAgentId)
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticHelp5621Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp5621Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp5621Id), "DiagnosticItemid doit être inialisé")
        Dim bReturn As Boolean
        Try
            Dim oHelp5621 As New DiagnosticHelp5621(pDiagnosticHelp5621Id, pIdDiagnostic)
            bReturn = oHelp5621.Delete()
        Catch ex As Exception
            CSDebug.dispFatal("DiagnosticHelp5621Manager.delete(" & pDiagnosticHelp5621Id & "," & pIdDiagnostic & ")" & ex.Message.ToString)
            bReturn = False
        End Try

        Return bReturn
    End Function 'delete

#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
