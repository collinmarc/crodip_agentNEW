Imports CRODIPAcquisition
Imports CsvHelper
Imports CsvHelper.Configuration
Imports NLog
Imports System.IO
Imports System.Diagnostics

Public Class AcquisitionMD2
    Implements ICRODIPAcquisition
    Private Shared logger As Logger = LogManager.GetCurrentClassLogger()
    Private bFichiercsvCree As Boolean = False

    Public Sub New()
        m_fichierMD2 = My.Settings.fichier
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
        logger.Info("AcquisitionMD2.GetValues Start")

        Dim oReturn As New List(Of AcquisitionValue)

        'Transfert des donnés depuis la base ACCESS vers le fichier CSV
        If Not bFichiercsvCree Then
            If System.IO.File.Exists(My.Settings.ProgTransfert) Then
                logger.Info("AcquisitionMD2.GetValues Lancement de " & My.Settings.ProgTransfert)
                Dim pInfo As ProcessStartInfo = New ProcessStartInfo()
                pInfo.FileName = My.Settings.ProgTransfert
                Dim p As Process = Process.Start(pInfo)
                'p.WaitForInputIdle()
                p.WaitForExit()

                '                Process.Start(My.Settings.ProgTransfert)
            End If
            bFichiercsvCree = True
        End If
        If File.Exists(My.Settings.CSVMD2) Then
            Dim lst As System.Collections.Generic.List(Of md2Enr)
            Using reader As StreamReader = New StreamReader(My.Settings.CSVMD2)
                Dim csvConfig As New CsvConfiguration(Globalization.CultureInfo.CurrentCulture)
                csvConfig.Delimiter = ";"
                csvConfig.MissingFieldFound = Nothing

                Using csv As CsvReader = New CsvReader(reader, csvConfig)
                    lst = csv.GetRecords(Of md2Enr)().ToList()
                End Using
                reader.Close()
            End Using
            Dim curIdBuse As Integer = 0
            Dim prevIdNiveau As Integer = 0

            For Each omd2enr As md2Enr In lst
                Dim tmpResponse As New CRODIPAcquisition.AcquisitionValue()
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                tmpResponse.Niveau = omd2enr.idNiveau
                'S'il y a rupture de niveau => Renumérotation de la buse
                If tmpResponse.Niveau <> prevIdNiveau Then
                    curIdBuse = 0
                End If
                prevIdNiveau = tmpResponse.Niveau
                curIdBuse += 1
                tmpResponse.NumBuse = curIdBuse

                If Not String.IsNullOrEmpty(omd2enr.debit) Then
                    tmpResponse.Debit = omd2enr.debit
                End If
                If Not String.IsNullOrEmpty(omd2enr.pression) Then
                    tmpResponse.Pression = omd2enr.pression
                End If
                oReturn.Add(tmpResponse)
            Next
        Else
            logger.Info("AcquisitionMD2.getValues fichier CSV " & My.Settings.CSVMD2 & " introuvable")
        End If
        Return oReturn

    End Function

    Public Function GetNbNiveaux() As Integer Implements ICRODIPAcquisition.GetNbNiveaux
        logger.Info("AcquisitionMD2.getnbNiveaux Start")
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
        logger.Info("AcquisitionMD2.getnbNiveaux return" & nNiveaux)
        Return nNiveaux
    End Function

    Public Function GetNbBuses(pNiveau As Integer) As Integer Implements ICRODIPAcquisition.GetNbBuses
        logger.Info("AcquisitionMD2.getnbBuses Start")
        Dim oValues As List(Of AcquisitionValue)
        Dim nBuses As Integer = 0

        oValues = GetValues()
        For Each oValue As AcquisitionValue In oValues
            If oValue.Niveau = pNiveau Then
                nBuses = nBuses + 1
            End If
        Next
        logger.Info("AcquisitionMD2.getnbBuses return" & nBuses)
        Return nBuses
    End Function

    Public Sub FTO_SaveData(plst As List(Of AcquisitionValue)) Implements ICRODIPAcquisition.FTO_SaveData
        Throw New NotImplementedException()

    End Sub

    Public Function clearResults() As Boolean Implements ICRODIPAcquisition.clearResults
        Dim bReturn As Boolean = False
        Try
            If System.IO.File.Exists(My.Settings.ProgTransfert) Then
                Process.Start(My.Settings.ProgTransfert & " " & "CLEAR")
            End If
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

    Public Function getGestionDesNiveaux() As Boolean Implements ICRODIPAcquisition.getGestionDesNiveaux
        Return True
    End Function

    Public Sub setNbBusesParNiveau(pNbreBuses As Integer) Implements ICRODIPAcquisition.setNbBusesParNiveau
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
