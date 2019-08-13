Imports CRODIPAcquisition
Imports System.Data.OleDb
Imports System.Linq

Public Class AcquisitionITEQ
    Implements ICRODIPAcquisition

    Function GetValues() As List(Of AcquisitionValue) Implements ICRODIPAcquisition.GetValues

        Dim oReturn As New List(Of AcquisitionValue)


        Dim oConn As OleDb.OleDbConnection
        oConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Text;Data Source=" & My.Settings.FolderName)
        oConn.Open()
        ' Initialisation de la DB
        Dim ocmd As OleDbCommand
        ocmd = oConn.CreateCommand()
        ocmd.CommandText = "SELECT * FROM " & My.Settings.FileName
        Dim dataResults As System.Data.OleDb.OleDbDataReader = ocmd.ExecuteReader()

        ' Parcourt des résultats
        Dim i As Integer = 0
        While dataResults.Read()

            Dim tmpResponse As New CRODIPAcquisition.AcquisitionValue()
            ' On rempli notre tableau
            Dim tmpColId As Integer = 0
            While tmpColId < dataResults.FieldCount()
                If Not dataResults.IsDBNull(tmpColId) Then
                    Select Case dataResults.GetName(tmpColId).ToUpper().Trim()
                        Case "Jeu N°".ToUpper().Trim()
                            tmpResponse.NumBuse = dataResults.GetValue(tmpColId)
                        Case "N° buse".ToUpper().Trim()
                            tmpResponse.Niveau = dataResults.GetValue(tmpColId)
                        Case "Débit mesuré (l/min)".ToUpper().Trim()
                            tmpResponse.Debit = dataResults.GetValue(tmpColId)
                        Case "Pression mesurée (bar)".ToUpper().Trim()
                            tmpResponse.Pression = dataResults.GetValue(tmpColId)
                    End Select
                End If
                tmpColId = tmpColId + 1
            End While
            oReturn.Add(tmpResponse)
        End While
        dataResults.Close()
        oConn.Close()
        Return oReturn

    End Function

    Public Function GetNbNiveaux() As Integer Implements ICRODIPAcquisition.GetNbNiveaux
        Return 0
    End Function

    Public Function GetNbBuses(pNiveau As Integer) As Integer Implements ICRODIPAcquisition.GetNbBuses
        Return 0
    End Function

    Public Sub FTO_SaveData(plst As List(Of AcquisitionValue))
        Throw New NotImplementedException()
    End Sub

    Private Sub ICRODIPAcquisition_FTO_SaveData(plst As List(Of AcquisitionValue)) Implements ICRODIPAcquisition.FTO_SaveData
        Throw New NotImplementedException()
    End Sub


    'Function GetValues() As List(Of AcquisitionValue) Implements ICRODIPAcquisition.GetValues
    '    Dim oReturn As New List(Of AcquisitionValue)
    '    Dim oValue As New AcquisitionValue()
    '    oValue.Niveau = 1
    '    oValue.NumBuse = 1
    '    oValue.Debit = 1.5D
    '    oValue.Pression = 2.5D
    '    oReturn.Add(oValue)
    '    oValue = New AcquisitionValue()
    '    oValue.Niveau = 2
    '    oValue.NumBuse = 1
    '    oValue.Debit = 2.5D
    '    oValue.Pression = 3.5D
    '    oReturn.Add(oValue)

    '    Return oReturn
    'End Function
End Class
