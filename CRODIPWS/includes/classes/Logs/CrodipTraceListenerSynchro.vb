Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Text

Public Class CrodipTraceListenerSynchro
    Inherits TraceListener

    Private ReadOnly _filePath As String

    ' Permet d'éviter que deux threads écrivent
    ' simultanément dans le même fichier.
    Private ReadOnly _syncLock As New Object()

    Public Sub New(filePath As String)

        If String.IsNullOrWhiteSpace(filePath) Then
            Throw New ArgumentException(
                "Le chemin du fichier de log ne peut pas être vide.",
                NameOf(filePath))
        End If

        _filePath = filePath

        ' Création automatique du répertoire
        ' s'il n'existe pas.
        Dim directory As String = Path.GetDirectoryName(_filePath)

        If Not String.IsNullOrEmpty(directory) AndAlso
           Not System.IO.Directory.Exists(directory) Then

            System.IO.Directory.CreateDirectory(directory)
        End If

    End Sub

    ''' <summary>
    ''' Appelé pour les écritures simples.
    ''' </summary>
    Public Overrides Sub Write(message As String)

        If message Is Nothing Then
            Return
        End If

        'WriteLog("INFO", message)

    End Sub

    ''' <summary>
    ''' Appelé pour les écritures simples avec retour à la ligne.
    ''' </summary>
    Public Overrides Sub WriteLine(message As String)

        If message Is Nothing Then
            Return
        End If

        WriteLog("INFO", message)

    End Sub

    ''' <summary>
    ''' Méthode principale utilisée par My.Application.Log.
    ''' </summary>
    Public Overrides Sub TraceEvent(
        eventCache As TraceEventCache,
        source As String,
        eventType As TraceEventType,
        id As Integer,
        message As String)

        Dim level As String = GetLevelName(eventType)

        WriteLog(level, message)

    End Sub

    ''' <summary>
    ''' Conversion du TraceEventType vers le niveau affiché
    ''' dans le fichier.
    ''' </summary>
    Private Function GetLevelName(
        eventType As TraceEventType) As String

        Select Case eventType

            Case TraceEventType.Critical
                Return "CRITICAL"

            Case TraceEventType.Error
                Return "ERROR"

            Case TraceEventType.Warning
                Return "WARNING"

            Case TraceEventType.Information
                Return "INFO"

            Case TraceEventType.Verbose
                Return "VERBOSE"

            Case TraceEventType.Start
                Return "START"

            Case TraceEventType.Stop
                Return "STOP"

            Case TraceEventType.Suspend
                Return "SUSPEND"

            Case TraceEventType.Resume
                Return "RESUME"

            Case TraceEventType.Transfer
                Return "TRANSFER"

            Case Else
                Return eventType.ToString().ToUpperInvariant()

        End Select

    End Function

    ''' <summary>
    ''' Écrit une ligne dans le fichier.
    ''' </summary>
    Private Sub WriteLog(
        level As String,
        message As String)

        If message Is Nothing Then
            message = String.Empty
        End If


        SyncLock _syncLock

            ' AppendAllText écrit immédiatement dans le fichier.
            ' Il n'est donc pas nécessaire d'attendre la fermeture
            ' de l'application.
            File.AppendAllText(
                _filePath,
                message & Environment.NewLine,
                New UTF8Encoding(False))


        End SyncLock

    End Sub

End Class