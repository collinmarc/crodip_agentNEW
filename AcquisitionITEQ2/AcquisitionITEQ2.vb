Imports CRODIPAcquisition
Imports CsvHelper
Imports CsvHelper.Configuration
Imports NLog
Imports System.Data.OleDb
Imports System.IO
Imports System.Linq

Public Class AcquisitionITEQ2
    Implements ICRODIPAcquisition
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()
    Public Sub New()
        m_fichierITEQ = My.Settings.FileName
    End Sub

    Private m_fichierITEQ As String
    Function GetValues() As List(Of AcquisitionValue) Implements ICRODIPAcquisition.GetValues
        logger.Info("AcquisitionITEQ.GetValues Start")

        Dim oReturn As New List(Of AcquisitionValue)
        Dim bConvert As Boolean = False 'conversion de Format (OUI /NON)
        Dim delimiter As String
        Using oReader As System.IO.TextReader = System.IO.File.OpenText(m_fichierITEQ)
            Dim strline As String
            Try

                strline = oReader.ReadLine() ' 1ere ligne =  l'entete
                If Not strline.StartsWith("Ref.") Then
                    oReader.Close()
                    Trace.WriteLine("AcquisistionITEQ2.getValues ERR : L'enete ne commence pas par Ref.")
                    Return oReturn
                End If
                delimiter = strline(4)
                strline = oReader.ReadLine() ' 2eme ligne =  Data
                If strline.StartsWith("""") Then
                    'Si la Deuxoème ligne commence par un " => conversion de format
                    bConvert = True
                End If
            Catch ex As Exception
                oReader.Close()
                Trace.WriteLine("AcquisistionITEQ2.getValues ERR : Erreur en lecture du fichier" & ex.Message)
                Return oReturn
            End Try
        End Using
        If bConvert Then
            'transformation du format
            Using oReader As System.IO.TextReader = New System.IO.StreamReader(m_fichierITEQ, Text.Encoding.GetEncoding(1252))
                Using oWriter As System.IO.TextWriter = System.IO.File.CreateText("./tmp/" & System.IO.Path.GetFileName(m_fichierITEQ))
                    Dim line As String = ""
                    line = oReader.ReadLine()
                    While (line IsNot Nothing)
                        If line.StartsWith("""") Then
                            line = line.Remove(0, 1) 'suppression du premier Car
                            line = line.Remove(line.Length - 1) ' suppression du Dernier Car
                            line = line.Replace("""""", """") 'Remplacement des "" par des "
                        End If
                        'Dim Win1252 As Text.Encoding = Text.Encoding.GetEncoding(1252)
                        'Dim utf8 As Text.Encoding = Text.Encoding.UTF8
                        'Dim Bytes As Byte()
                        'Dim BytesUTF8 As Byte()
                        'Bytes = Win1252.GetBytes(line)
                        'BytesUTF8 = Text.Encoding.Convert(Win1252, utf8, Bytes)
                        'Dim LineUTF8 = Text.Encoding.UTF8.GetString(BytesUTF8)
                        'oWriter.WriteLine(LineUTF8)
                        oWriter.WriteLine(line)
                        line = oReader.ReadLine()
                    End While
                End Using
            End Using
            m_fichierITEQ = "./tmp/" & System.IO.Path.GetFileName(m_fichierITEQ)
            'Dim tabString(2) As String
            'tabString(0) = "[" & System.IO.Path.GetFileName(m_fichierITEQ) & "]"
            'tabString(1) = "characterSet=OEM"
            'System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(m_fichierITEQ) & "/Schema.ini", tabString)
        End If

        If bConvert Then
            Dim oConn As OleDb.OleDbConnection
            oConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Extended Properties=Text;Data Source=" & System.IO.Path.GetDirectoryName(m_fichierITEQ))
            oConn.Open()
            ' Initialisation de la DB
            Dim ocmd As OleDbCommand
            ocmd = oConn.CreateCommand()
            ocmd.CommandText = "SELECT *   FROM [" & System.IO.Path.GetFileName(m_fichierITEQ) & "]"
            Dim dataResults As System.Data.OleDb.OleDbDataReader = ocmd.ExecuteReader()

            ' Parcourt des résultats
            Dim i As Integer = 0
            While dataResults.Read()

                Dim tmpResponse As New CRODIPAcquisition.AcquisitionValue()
                'Comme on a des problème de conversion d'encodage
                'on prend les champs fixes dans le fichier convertit
                'Jeu N°'
                If Not dataResults.IsDBNull(6) Then
                    tmpResponse.Niveau = dataResults.GetValue(6)
                End If
                'N° buse'
                If Not dataResults.IsDBNull(7) Then
                    tmpResponse.NumBuse = dataResults.GetValue(7)
                End If
                '"Débit mesuré (l/min)"
                If Not dataResults.IsDBNull(8) Then
                    tmpResponse.Debit = dataResults.GetValue(8)
                End If
                'Pression mesurée (bar)
                If Not dataResults.IsDBNull(9) Then
                    tmpResponse.Pression = dataResults.GetValue(9)
                End If
                oReturn.Add(tmpResponse)
            End While
            dataResults.Close()
            oConn.Close()
        Else
            Dim olstValueITEQ As New List(Of ValueITEQ2)
            Using sr As New StreamReader(m_fichierITEQ)
                Dim csvConfig As New CsvConfiguration(Globalization.CultureInfo.CurrentCulture)
                csvConfig.Delimiter = delimiter

                Using csvR As New CsvReader(sr, csvConfig)
                    olstValueITEQ = csvR.GetRecords(Of ValueITEQ2)().ToList()
                End Using
            End Using
            ' Parcourt des résultats
            Dim Niveau As Integer = 1
            Dim bPremLigne As Boolean = True
            For Each oValueITEQ As ValueITEQ2 In olstValueITEQ
                Try

                    Dim tmpResponse As New CRODIPAcquisition.AcquisitionValue()
                    'Qd le numéro de buse revient à 1 on incrémente le Niveau
                    If Not bPremLigne And oValueITEQ.NumeroBuse = 1 Then
                        Niveau = Niveau + 1
                    End If
                    If getGestionDesNiveaux() Then
                        tmpResponse.Niveau = Niveau
                        tmpResponse.NumBuse = oValueITEQ.NumeroBuse
                    Else
                        Dim nNum As Integer
                        nNum = oValueITEQ.NumeroBuse
                        tmpResponse.Niveau = calcNiveau(nNum)
                        tmpResponse.NumBuse = calcNumBuse(nNum)
                    End If

                    tmpResponse.Debit = oValueITEQ.Debit.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    If Not String.IsNullOrEmpty(oValueITEQ.Pression) Then
                        tmpResponse.Pression = oValueITEQ.Pression.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                    End If
                    tmpResponse.Ref = oValueITEQ.Ref
                    oReturn.Add(tmpResponse)
                    If bPremLigne Then
                        bPremLigne = False 'On n'est plus sur la première ligne
                    End If
                Catch ex As Exception

                End Try

            Next

        End If

        logger.Info("AcquisitionITEQ.GetValues Return " & oReturn.Count & "elements")
        Return oReturn

    End Function

    Private Function calcNiveau(pNum) As Integer
        Dim nreturn As Integer

        If pNum Mod m_NbreBusesParniveaux = 0 Then
            nreturn = pNum / m_NbreBusesParniveaux
        Else
            nreturn = Fix(pNum / m_NbreBusesParniveaux) + 1
        End If
        Return nreturn

    End Function
    Private Function calcNumBuse(pNum) As Integer
        Dim nreturn As Integer

        If (pNum Mod m_NbreBusesParniveaux = 0) Then
            nreturn = m_NbreBusesParniveaux
        Else
            nreturn = pNum Mod m_NbreBusesParniveaux
        End If

        Return nreturn

    End Function

    Public Function GetNbNiveaux() As Integer Implements ICRODIPAcquisition.GetNbNiveaux
        logger.Info("AcquisitionITEQ.getnbNiveaux Start")
        Dim lstValues As New List(Of AcquisitionValue)
        Dim nReturn As Integer = 0
        lstValues = GetValues()
        Try

            nReturn = lstValues.Max(Function(oVal) _
                              oVal.Niveau)
        Catch ex As Exception

        End Try
        logger.Info("AcquisitionITEQ.getnbNiveaux Return " & nReturn)
        Return nReturn
    End Function

    Public Function GetNbBuses(pNiveau As Integer) As Integer Implements ICRODIPAcquisition.GetNbBuses
        logger.Info("AcquisitionITEQ.getnbBuses Start")
        Dim lstValues As New List(Of AcquisitionValue)
        Dim nReturn As Integer = 0
        lstValues = GetValues()
        nReturn = lstValues.Where(Function(oVal) oVal.Niveau = pNiveau).Max(Function(oVal) oVal.NumBuse)
        logger.Info("AcquisitionITEQ.getnbBuses return " & nReturn)
        Return nReturn
    End Function

    Public Sub FTO_SaveData(plst As List(Of AcquisitionValue))
        Throw New NotImplementedException()
    End Sub

    Private Sub ICRODIPAcquisition_FTO_SaveData(plst As List(Of AcquisitionValue)) Implements ICRODIPAcquisition.FTO_SaveData
        Throw New NotImplementedException()
    End Sub

    Public Function clearResults() As Boolean Implements ICRODIPAcquisition.clearResults

        Dim bReturn As Boolean = False
        Try
            'Dim oConn As OleDb.OleDbConnection
            'oConn = New OleDbConnection(My.Settings.BDD)
            'oConn.Open()
            '' Initialisation de la DB
            'Dim ocmd As OleDbCommand
            'ocmd = oConn.CreateCommand()
            'Dim n As Integer = 0
            'ocmd.CommandText = String.Format("DELETE FROM tmpDataAcquiring ")
            'ocmd.ExecuteNonQuery()

            'oConn.Close()
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function getFichier() As String Implements ICRODIPAcquisition.getFichier
        Return m_fichierITEQ
    End Function

    Public Sub setFichier(pFichier As String) Implements ICRODIPAcquisition.setFichier
        m_fichierITEQ = pFichier
    End Sub

    Public Function getGestionDesNiveaux() As Boolean Implements ICRODIPAcquisition.getGestionDesNiveaux
        Return True
    End Function

    Private m_NbreBusesParniveaux As String
    Public Sub setNbBusesParNiveau(pNbreBuses As Integer) Implements ICRODIPAcquisition.setNbBusesParNiveau
        m_NbreBusesParniveaux = pNbreBuses
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
