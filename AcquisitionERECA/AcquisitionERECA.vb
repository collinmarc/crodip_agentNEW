Imports CRODIPAcquisition
Imports NLog
Imports System.Data.OleDb
Imports System.Linq
Imports System.IO
Imports CsvHelper

Public Class AcquisitionERECA
    Implements ICRODIPAcquisition
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()
    Public Sub New()
        m_fichierERECA = My.Settings.FileName
    End Sub

    Private m_fichierERECA As String
    Function GetValues() As List(Of AcquisitionValue) Implements ICRODIPAcquisition.GetValues
        logger.Info("AcquisitionERECA.GetValues Start")

        Dim oReturn As New List(Of AcquisitionValue)
#Region "ConversionFormat"

        'Dim bConvert As Boolean = False 'conversion de Format (OUI /NON)
        'Using oReader As System.IO.TextReader = System.IO.File.OpenText(m_fichierERECA)
        '    Dim strline As String
        '    Try

        '        strline = oReader.ReadLine() ' 1ere ligne =  l'entete
        '        If Not strline.StartsWith("Ref.,") Then
        '            oReader.Close()
        '            Trace.WriteLine("AcquisistionERECA.getValues ERR : L'enete ne commence pas par Ref.")
        '            Return oReturn
        '        End If
        '        strline = oReader.ReadLine() ' 2eme ligne =  Data
        '        If strline.StartsWith("""") Then
        '            'Si la Deuxoème ligne commence par un " => conversion de format
        '            bConvert = True
        '        End If
        '    Catch ex As Exception
        '        oReader.Close()
        '        Trace.WriteLine("AcquisistionERECA.getValues ERR : Erreur en lecture du fichier" & ex.Message)
        '        Return oReturn
        '    End Try
        'End Using
        'If bConvert Then
        '    'transformation du format
        '    Using oReader As System.IO.TextReader = New System.IO.StreamReader(m_fichierERECA, Text.Encoding.GetEncoding(1252))
        '        Using oWriter As System.IO.TextWriter = System.IO.File.CreateText("./tmp/" & System.IO.Path.GetFileName(m_fichierERECA))
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
        '    m_fichierERECA = "./tmp/" & System.IO.Path.GetFileName(m_fichierERECA)
        '    'Dim tabString(2) As String
        '    'tabString(0) = "[" & System.IO.Path.GetFileName(m_fichierERECA) & "]"
        '    'tabString(1) = "characterSet=OEM"
        '    'System.IO.File.WriteAllLines(System.IO.Path.GetDirectoryName(m_fichierERECA) & "/Schema.ini", tabString)
        'End If
#End Region
        Dim olstValueERECA As New List(Of ValueERECA)
        Using sr As New StreamReader(m_fichierERECA)

            Using csvR As New CsvReader(sr, Globalization.CultureInfo.CurrentCulture)
                csvR.Configuration.MissingFieldFound = Nothing
                csvR.Configuration.Delimiter = ","
                csvR.Configuration.HasHeaderRecord = False
                olstValueERECA = csvR.GetRecords(Of ValueERECA)().ToList()
            End Using
        End Using
        ' Parcourt des résultats
        Dim olstValueERECAControleBuses As New List(Of ValueERECA)
        Dim bLigneCoontroleBuses As Boolean = False
        For Each oValueERECA As ValueERECA In olstValueERECA
            If bLigneCoontroleBuses Then
                If oValueERECA.Ref.StartsWith("***") Then
                    'fin du controle de buses au debut de la section Suivante
                    bLigneCoontroleBuses = False
                End If
            Else
                If oValueERECA.Ref.Equals("***Controle buse***") Then
                    'fin du controle de buses au debut de la section Suivante
                    bLigneCoontroleBuses = True
                End If
            End If

            If bLigneCoontroleBuses Then
                'On est dans la bonne Section
                If oValueERECA.Ref.StartsWith("***") Or oValueERECA.Ref = "Ref" Then
                Else
                    olstValueERECAControleBuses.Add(oValueERECA)
                End If
            End If
        Next



        Dim i As Integer = 0
        For Each oValueERECA As ValueERECA In olstValueERECAControleBuses
            If oValueERECA.Troncon = "1" Then
                Dim oValueCRODIP As New CRODIPAcquisition.AcquisitionValue()

                oValueCRODIP.Niveau = oValueERECA.Niveau
                oValueCRODIP.NumBuse = oValueERECA.NumeroBuse
                oValueCRODIP.Ref = oValueERECA.Ref
                oValueCRODIP.HV = oValueERECA.HV
                oValueCRODIP.MarqueTypeFonctionement = oValueERECA.MarqueType
                oValueCRODIP.Calibre = oValueERECA.Calibre
                If Not String.IsNullOrEmpty(oValueERECA.PressionControle) Then
                    oValueCRODIP.PressionCtrl = oValueERECA.PressionControle
                End If
                If Not String.IsNullOrEmpty(oValueERECA.DebitNominal) Then
                    oValueCRODIP.DebitNominal = oValueERECA.DebitNominal.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                End If

                If Not String.IsNullOrEmpty(oValueERECA.DebitMesure) Then
                    oValueCRODIP.Debit = oValueERECA.DebitMesure.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                End If
                If Not String.IsNullOrEmpty(oValueERECA.PressionMesuree) Then
                    oValueCRODIP.Pression = oValueERECA.PressionMesuree.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
                End If
                oReturn.Add(oValueCRODIP)
            End If
        Next

        logger.Info("AcquisitionERECA.GetValues Return " & oReturn.Count & "elements")
        Return oReturn

    End Function
    'Private Function calcNiveau(pNum) As Integer
    '    Dim nreturn As Integer

    '    If pNum Mod m_NbreBusesParniveaux = 0 Then
    '        nreturn = pNum / m_NbreBusesParniveaux
    '    Else
    '        nreturn = Fix(pNum / m_NbreBusesParniveaux) + 1
    '    End If
    '    Return nreturn

    'End Function
    'Private Function calcNumBuse(pNum) As Integer
    '    Dim nreturn As Integer

    '    If (pNum Mod m_NbreBusesParniveaux = 0) Then
    '        nreturn = m_NbreBusesParniveaux
    '    Else
    '        nreturn = pNum Mod m_NbreBusesParniveaux
    '    End If

    '    Return nreturn

    'End Function


    Public Function GetNbNiveaux() As Integer Implements ICRODIPAcquisition.GetNbNiveaux
        logger.Info("AcquisitionERECA.getnbNiveaux Start")
        Dim lstValues As New List(Of AcquisitionValue)
        Dim nReturn As Integer = 0
        lstValues = GetValues()
        nReturn = lstValues.Max(Function(oVal) _
                          oVal.Niveau)
        logger.Info("AcquisitionERECA.getnbNiveaux Return " & nReturn)
        Return nReturn
    End Function

    Public Function GetNbBuses(pNiveau As Integer) As Integer Implements ICRODIPAcquisition.GetNbBuses
        logger.Info("AcquisitionERECA.getnbBuses Start")
        Dim lstValues As New List(Of AcquisitionValue)
        Dim nReturn As Integer = 0
        lstValues = GetValues()
        nReturn = lstValues.Where(Function(oVal) oVal.Niveau = pNiveau).Max(Function(oVal) oVal.NumBuse)
        logger.Info("AcquisitionERECA.getnbBuses return " & nReturn)
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
        Return m_fichierERECA
    End Function

    Public Sub setFichier(pFichier As String) Implements ICRODIPAcquisition.setFichier
        m_fichierERECA = pFichier
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
