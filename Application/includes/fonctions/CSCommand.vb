Imports System.Data.Common
Public Class CrodipManager


    Public Shared Function AddParameter(pCmd As DbCommand, pName As String, pValue As Object, Optional pdbType As DbType = DbType.Object) As DbParameter
        Dim oParam As DbParameter = pCmd.CreateParameter()
        With oParam
            .ParameterName = pName
            .Value = pValue
            If pdbType <> DbType.Object Then
                .DbType = pdbType
            End If
        End With
        pCmd.Parameters.Add(oParam)
        Return oParam
    End Function
End Class
