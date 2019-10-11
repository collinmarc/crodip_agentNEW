Imports System.Collections.Generic
Public Class NiveauBusePulveManager
    Public Shared Function Save(pList As List(Of NiveauBusePulve)) As Boolean
        Dim bReturn As Boolean = False
        Try
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("NiveauBusePulveManager.save ERR:" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function LoadByPulveID(pIDPulve As Integer) As List(Of NiveauBusePulve)
        Dim oReturn As New List(Of NiveauBusePulve)
        Try
        Catch ex As Exception
            CSDebug.dispError("NiveauBusePulveManager.LoadByPulveID ERR:" & ex.Message)
            oReturn = New List(Of NiveauBusePulve)
        End Try
        Return oReturn

    End Function
End Class
