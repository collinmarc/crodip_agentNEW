Imports CRODIPAcquisition
Imports System.Data.OleDb
Imports System.Linq

Public Class AcquisitionMD2
    Implements ICRODIPAcquisition

    'Public Function GetValues() As List(Of IAcquisitionValue) Implements ICRODIPAcquisition.GetValues

    '    Dim oReturn As New List(Of IAcquisitionValue)


    '    Dim oConn As OleDb.OleDbConnection
    '    oConn = New OleDbConnection(My.Settings.BDD)
    '    ' Initialisation de la DB
    '    Dim ocmd As OleDbCommand
    '    ocmd = oConn.CreateCommand()
    '    ocmd.CommandText = "SELECT * FROM tmpDataAcquiring"
    '    Dim dataResults As System.Data.OleDb.OleDbDataReader = ocmd.ExecuteReader()

    '    ' Parcourt des résultats
    '    Dim i As Integer = 0
    '    While dataResults.Read()

    '        Dim tmpResponse As New CRODIPAcquisition.AcquisitionValue()
    '        ' On rempli notre tableau
    '        Dim tmpColId As Integer = 0
    '        While tmpColId < dataResults.FieldCount()
    '            If Not dataResults.IsDBNull(tmpColId) Then
    '                Select Case dataResults.GetName(tmpColId)
    '                    Case "idBuse".ToUpper().Trim()
    '                        'tmpResponse.NumBuse = dataResults.GetInt32(dataResults.GetOrdinal(dataResults.GetName(tmpColId)))
    '                    Case "idNiveau".ToUpper().Trim()
    '                        'tmpResponse.Niveau = dataResults.GetInt32(dataResults.GetOrdinal(dataResults.GetName(tmpColId)))
    '                    Case "debit".ToUpper().Trim()
    '                        'tmpResponse.Debit = dataResults.GetDecimal(dataResults.GetOrdinal(dataResults.GetName(tmpColId)))
    '                    Case "pression".ToUpper().Trim()
    '                        'tmpResponse.Pression = dataResults.GetDecimal(dataResults.GetOrdinal(dataResults.GetName(tmpColId)))
    '                End Select
    '            End If
    '            tmpColId = tmpColId + 1
    '        End While
    '    End While
    '    dataResults.Close()
    '    oConn.Close()
    '    Return oReturn

    'End Function


    Function GetValues() As List(Of AcquisitionValue) Implements ICRODIPAcquisition.GetValues
        Dim oReturn As New List(Of AcquisitionValue)
        Dim oValue As New AcquisitionValue()
        oValue.Niveau = 1
        oValue.NumBuse = 1
        oValue.Debit = 1.5D
        oValue.Pression = 2.5D
        oReturn.Add(oValue)
        oValue = New AcquisitionValue()
        oValue.Niveau = 2
        oValue.NumBuse = 1
        oValue.Debit = 2.5D
        oValue.Pression = 3.5D
        oReturn.Add(oValue)

        Return oReturn
    End Function
End Class
