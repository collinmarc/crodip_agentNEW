Imports CRODIPAcquisition
Imports System.Data.OleDb
Imports System.Linq

Public Class AcquisitionMD2
    Implements ICRODIPAcquisition
    Public Sub New()
        m_fichierMD2 = My.Settings.FichierMD2
    End Sub

    Private m_fichierMD2 As String
    Public Property fichierMD2() As String
        Get
            Return m_fichierMD2
        End Get
        Set(ByVal value As String)
            m_fichierMD2 = value
        End Set
    End Property

    Function GetValues() As List(Of AcquisitionValue) Implements ICRODIPAcquisition.GetValues

        Dim oReturn As New List(Of AcquisitionValue)


        Dim oConn As OleDb.OleDbConnection
        oConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fichierMD2)
        oConn.Open()
        ' Initialisation de la DB
        Dim ocmd As OleDbCommand
        ocmd = oConn.CreateCommand()
        ocmd.CommandText = "SELECT IdNiveau,debit,pression FROM tmpDataAcquiring ORDER BY IdNiveau, IdBuse"
        Dim dataResults As System.Data.OleDb.OleDbDataReader = ocmd.ExecuteReader()

        ' Parcourt des résultats
        Dim i As Integer = 0
        Dim prevIdNiveau As Integer = 0
        Dim curIdBuse As Integer = 0

        While dataResults.Read()

            Dim tmpResponse As New CRODIPAcquisition.AcquisitionValue()
            ' On rempli notre tableau
            Dim tmpColId As Integer = 0
            While tmpColId < dataResults.FieldCount()
                If Not dataResults.IsDBNull(tmpColId) Then
                    Select Case dataResults.GetName(tmpColId).ToUpper().Trim()
                        Case "idBuse".ToUpper().Trim()

'                            tmpResponse.NumBuse = curIdBuse
                        Case "idNiveau".ToUpper().Trim()
                            tmpResponse.Niveau = dataResults.GetValue(tmpColId)
                            'S'il y a rupture de niveau => Renumérotation de la buse
                            If tmpResponse.Niveau <> prevIdNiveau Then
                                curIdBuse = 0
                            End If
                            prevIdNiveau = tmpResponse.Niveau
                            curIdBuse += 1
                            tmpResponse.NumBuse = curIdBuse
                        Case "debit".ToUpper().Trim()
                            tmpResponse.Debit = dataResults.GetValue(tmpColId)
                        Case "pression".ToUpper().Trim()
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
        Dim oValues As List(Of AcquisitionValue)
        Dim prevNiveau As Integer = -1
        Dim nNiveaux As Integer = 0

        oValues = GetValues()
        For Each oValue As AcquisitionValue In oValues
            If oValue.Niveau <> prevNiveau Then
                prevNiveau = oValue.Niveau
                nNiveaux = nNiveaux + 1
            End If
        Next
        Return nNiveaux
    End Function

    Public Function GetNbBuses(pNiveau As Integer) As Integer Implements ICRODIPAcquisition.GetNbBuses
        Dim oValues As List(Of AcquisitionValue)
        Dim nBuses As Integer = 0

        oValues = GetValues()
        For Each oValue As AcquisitionValue In oValues
            If oValue.Niveau = pNiveau Then
                nBuses = nBuses + 1
            End If
        Next
        Return nBuses
    End Function

    Public Sub FTO_SaveData(plst As List(Of AcquisitionValue)) Implements ICRODIPAcquisition.FTO_SaveData
        Dim oConn As OleDb.OleDbConnection
        oConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fichierMD2)
        oConn.Open()
        ' Initialisation de la DB
        Dim ocmd As OleDbCommand
        ocmd = oConn.CreateCommand()
        Dim n As Integer = 0
        ocmd.CommandText = String.Format("DELETE FROM tmpDataAcquiring ")
        ocmd.ExecuteNonQuery()
        ocmd.CommandText = "Insert INTO tmpDataAcquiring (IdBuse,IdNiveau,debit,pression) VALUES (?,?,?,?)"

        For Each oVal In plst
            n = n + 1
            ocmd.Parameters.Clear()
            ocmd.Parameters.Add("?", OleDb.OleDbType.Integer).Value = n
            ocmd.Parameters.Add("?", OleDb.OleDbType.Integer).Value = oVal.Niveau
            ocmd.Parameters.Add("?", OleDb.OleDbType.Double).Value = oVal.Debit
            ocmd.Parameters.Add("?", OleDb.OleDbType.Double).Value = oVal.Pression
            ocmd.ExecuteNonQuery()
        Next

        oConn.Close()

    End Sub

    Public Function clearResults() As Boolean Implements ICRODIPAcquisition.clearResults
        Dim bReturn As Boolean = False
        Try
            Dim oConn As OleDb.OleDbConnection
            oConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fichierMD2)
            oConn.Open()
            ' Initialisation de la DB
            Dim ocmd As OleDbCommand
            ocmd = oConn.CreateCommand()
            Dim n As Integer = 0
            ocmd.CommandText = String.Format("DELETE FROM tmpDataAcquiring ")
            ocmd.ExecuteNonQuery()

            oConn.Close()
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function getFichier() As String Implements ICRODIPAcquisition.getFichier
        Return m_fichierMD2
    End Function

    Public Sub setFichier(pFichier As String) Implements ICRODIPAcquisition.setFichier
        m_fichierMD2 = pFichier
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
