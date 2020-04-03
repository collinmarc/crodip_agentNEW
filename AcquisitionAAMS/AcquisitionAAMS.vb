Imports CRODIPAcquisition
Imports NLog
Imports System.Data.OleDb
Imports System.Linq
Imports System.IO
Imports CsvHelper

Public Class AcquisitionAAMS
    Implements ICRODIPAcquisition
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()
    Public Sub New()
        m_fichierAAMS = My.Settings.FileName
    End Sub

    Private m_fichierAAMS As String
    Function GetValues() As List(Of AcquisitionValue) Implements ICRODIPAcquisition.GetValues
        logger.Info("AcquisitionAAMS.GetValues Start")

        Dim oReturn As New List(Of AcquisitionValue)
#Region "ConversionFormat"

        'Dim bConvert As Boolean = False 'conversion de Format (OUI /NON)
        'Using oReader As System.IO.TextReader = System.IO.File.OpenText(m_fichierAAMS)
        '    Dim strline As String
        '    Try

        '        strline = oReader.ReadLine() ' 1ere ligne =  l'entete
        '        If Not strline.StartsWith("Ref.,") Then
        '            oReader.Close()
        '            Trace.WriteLine("AcquisistionAAMS.getValues ERR : L'enete ne commence pas par Ref.")
        '            Return oReturn
        '        End If
        '        strline = oReader.ReadLine() ' 2eme ligne =  Data
        '        If strline.StartsWith("""") Then
        '            'Si la Deuxoème ligne commence par un " => conversion de format
        '            bConvert = True
        '        End If
        '    Catch ex As Exception
        '        oReader.Close()
        '        Trace.WriteLine("AcquisistionAAMS.getValues ERR : Erreur en lecture du fichier" & ex.Message)
        '        Return oReturn
        '    End Try
        'End Using
        'If bConvert Then
        '    'transformation du format
        '    Using oReader As System.IO.TextReader = New System.IO.StreamReader(m_fichierAAMS, Text.Encoding.GetEncoding(1252))
        '        Using oWriter As System.IO.TextWriter = System.IO.File.CreateText("./tmp/" & System.IO.Path.GetFileName(m_fichierAAMS))
        '            Dim line As String = ""
        '            line = oReader.ReadLine()
        '            While (line IsNot Nothing)
        '                If line.StartsWith("""") Then
        '                    line = line.Remove(0, 1) 'suppression du premier Car
        '                    line = line.Remove(line.Length - 1) ' suppression du Dernier Car
        '                    line = line.Replace("""""", """") 'Remplacement des "" par des "
        '                End If
        '                'Dim Win1252 As Text.Encoding = Text.Encoding.GetEncoding(1252)
        '                'Dim utf8 As Text.Encoding = Text.Encoding.UTF8
        '                'Dim Bytes As Byte()
        '                'Dim BytesUTF8 As Byte()
        '                'Bytes = Win1252.GetBytes(line)
        '                'BytesUTF8 = Text.Encoding.Convert(Win1252, utf8, Bytes)
        '                'Dim LineUTF8 = Text.Encoding.UTF8.GetString(BytesUTF8)
        '                'oWriter.WriteLine(LineUTF8)
        '                oWriter.WriteLine(line)
        '                line = oReader.ReadLine()
        '            End While
        '        End Using
        '    End Using
        '    m_fichierAAMS = "./tmp/" & System.IO.Path.GetFileName(m_fichierAAMS)
        '    'Dim tabString(2) As String
        '    'tabString(0) = "[" & System.IO.Path.GetFileName(m_fichierAAMS) & "]"
        '    'tabString(1) = "characterSet=OEM"
        '    'System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(m_fichierAAMS) & "/Schema.ini", tabString)
        'End If
#End Region
        Dim olstValueAAMS As New List(Of ValueAAMS)
        Using sr As New StreamReader(m_fichierAAMS)

            Using csvR As New CsvReader(sr, Globalization.CultureInfo.CurrentCulture)
                olstValueAAMS = csvR.GetRecords(Of ValueAAMS)().ToList()
            End Using
        End Using
        ' Parcourt des résultats
        Dim i As Integer = 0
        For Each oValueAAMS As ValueAAMS In olstValueAAMS
            Dim tmpResponse As New CRODIPAcquisition.AcquisitionValue()
            Dim tmpColId As Integer = 0
            Dim nNum As Integer
            nNum = oValueAAMS.Numero
            tmpResponse.Niveau = calcNiveau(nNum)
            tmpResponse.NumBuse = calcNumBuse(nNum)

            tmpResponse.Debit = oValueAAMS.Debit.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            tmpResponse.Pression = oValueAAMS.Pression.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
            tmpResponse.Ref = oValueAAMS.Ref
            oReturn.Add(tmpResponse)

        Next

        logger.Info("AcquisitionAAMS.GetValues Return " & oReturn.Count & "elements")
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
        logger.Info("AcquisitionAAMS.getnbNiveaux Start")
        Dim lstValues As New List(Of AcquisitionValue)
        Dim nReturn As Integer = 0
        lstValues = GetValues()
        nReturn = lstValues.Max(Function(oVal) _
                          oVal.Niveau)
        logger.Info("AcquisitionAAMS.getnbNiveaux Return " & nReturn)
        Return nReturn
    End Function

    Public Function GetNbBuses(pNiveau As Integer) As Integer Implements ICRODIPAcquisition.GetNbBuses
        logger.Info("AcquisitionAAMS.getnbBuses Start")
        Dim lstValues As New List(Of AcquisitionValue)
        Dim nReturn As Integer = 0
        lstValues = GetValues()
        nReturn = lstValues.Where(Function(oVal) oVal.Niveau = pNiveau).Max(Function(oVal) oVal.NumBuse)
        logger.Info("AcquisitionAAMS.getnbBuses return " & nReturn)
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
        Return m_fichierAAMS
    End Function

    Public Sub setFichier(pFichier As String) Implements ICRODIPAcquisition.setFichier
        m_fichierAAMS = pFichier
    End Sub

    Public Function getGestionDesNiveaux() As Boolean Implements ICRODIPAcquisition.getGestionDesNiveaux
        Return False
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
