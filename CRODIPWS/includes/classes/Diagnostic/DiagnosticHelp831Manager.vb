Imports System.Collections.Generic
Imports System.Data.Common

Public Class DiagnosticHelp831Manager
    ' Variables
    Dim query As String
    Dim arrParametres(0) As String
    Dim nbParametres As Integer = 0



#Region "Methodes acces Local"


    Public Shared Function getDiagnosticHelp8312ByDiagnosticId(oCSDB As CSDb, ByVal pDiagnostic As Diagnostic) As DiagnosticHelp831
        Return getDiagnosticHelp831ByDiagnosticId(oCSDB, DiagnosticHelp831.ModeHelp831.Mode8312, pDiagnostic)
    End Function
    Public Shared Function getDiagnosticHelp8314ByDiagnosticId(oCSDB As CSDb, ByVal pDiagnostic As Diagnostic) As DiagnosticHelp831
        Return getDiagnosticHelp831ByDiagnosticId(oCSDB, DiagnosticHelp831.ModeHelp831.Mode8314, pDiagnostic)
    End Function

    Private Shared Function getDiagnosticHelp831ByDiagnosticId(oCSDB As CSDb, pMode As DiagnosticHelp831.ModeHelp831, ByVal pDiagnostic As Diagnostic) As DiagnosticHelp831
        ' On récupère les items du diagnostic
        Dim oHelp831 As DiagnosticHelp831
        Dim bddCommande As DbCommand = oCSDB.getConnection().CreateCommand()
        Try
            'Lecture de l'id pour le diagitem help831
            Dim strIdItem As String
            If pMode = DiagnosticHelp831.ModeHelp831.Mode8312 Then
                strIdItem = "help8312"
            Else
                strIdItem = "help8314"
            End If
            bddCommande.CommandText = "SELECT id FROM DiagnosticItem WHERE DiagnosticItem.idDiagnostic='" & pDiagnostic.id & "' and DiagnosticItem.idItem = '" & strIdItem & "' ORDER BY IdItem, ItemValue"
            ' On récupère les résultats
            Dim oDRDiagnosticItem As DbDataReader = bddCommande.ExecuteReader
            oHelp831 = New DiagnosticHelp831(pMode)
            oHelp831.id = 0
            oHelp831.idDiag = pDiagnostic.id
            While oDRDiagnosticItem.Read()
                oHelp831.id = oDRDiagnosticItem.GetString(0)
                oHelp831.Load()
            End While
            oDRDiagnosticItem.Close()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp831Manager::getDiagnosticHelp831ByDiagnosticId : " & ex.Message)
            oHelp831 = Nothing
        End Try

        Return oHelp831
    End Function
    '''
    ''' Sauvegarde d'un Help831
    ''' Paramètres :
    Public Shared Function save(ByVal pHelp831 As DiagnosticHelp831, ByVal pStructureId As String, ByVal pAgentId As String, pCSDb As CSDb) As Boolean
        Debug.Assert(pCSDb.isOpen(), "La Connection Doit être ouverte")

        Dim breturn As Boolean
        Try
            breturn = False
            breturn = pHelp831.Save(pStructureId, pAgentId, pCSDb)
        Catch ex As Exception
            CSDebug.dispError("Erreur DiagnosticHelp831Manager - save" & ex.Message.ToString)
            breturn = False
        End Try
        Return breturn
    End Function

    Public Shared Function delete(ByVal pDiagnosticHelp831Id As String, ByVal pIdDiagnostic As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pDiagnosticHelp831Id), "DiagnosticItemid doit être inialisé")
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
