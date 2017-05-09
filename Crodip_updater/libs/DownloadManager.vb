Imports System.IO
Imports System.Net

Public Class DownloadManager

    ' Paramètres
    Private _fileUrl() As String
    Private _destinationPath As String
    Private _basePath As String

    ' Info progression

    ' Info fichier courant
    Private _curFileName As String
    Private _curFilenameLabel As Label
    Private _curFilesizeLabel As Label
    Private m_pgbFiles As ProgressBar
    Private m_lblFiles As Label

    ' Info download
    Private _download_totalFiles As Integer
    Private _download_totalSize As Integer

    ' Constructeur
    Sub New(ByVal tmpFileUrl() As String, ByVal destinationPath As String)

        Me.new(tmpFileUrl, destinationPath, "")

    End Sub
    Sub New(ByVal tmpFileUrl() As String, ByVal destinationPath As String, ByVal baseFolder As String)

        '# Liste des fichiers à télécharger
        Me._fileUrl = tmpFileUrl
        Me._download_totalFiles = Me._fileUrl.Length

        '# Dossier où seront stockés les fichiers téléchargés
        Me._destinationPath = destinationPath

        If baseFolder <> "" Then
            Me._basePath = baseFolder
        End If

    End Sub

    '################################################################################
    ' Ajout des composants

    ' Barre de progression générale
    Public Sub setControles(ByVal pLblFiles As Label, ppgbFiles As ProgressBar)
        m_lblFiles = pLblFiles
        m_pgbFiles = ppgbFiles
    End Sub

    '################################################################################

    Public Function doDownload() As Boolean
        Dim bReturn As Boolean
        Try
            Me.m_pgbFiles.Minimum = 0
            Me.m_pgbFiles.Value = Me.m_pgbFiles.Minimum
            Me.m_pgbFiles.Maximum = Me._download_totalFiles
            ' Implémentation progressBar
            If Not IsNothing(m_lblFiles) Then
                m_lblFiles.Text = Me.m_pgbFiles.Value & "/" & Me._download_totalFiles & " fichiers"
            End If
            ' FIN -- Implémentation progressBar

            ' On boucle tous les fichiers a télécharger
            For Each fileUrl As String In Me._fileUrl

                ' On récupère le nom du fichier à download
                Dim arrFileUrl() As String
                arrFileUrl = fileUrl.Split("/")
                Array.Reverse(arrFileUrl)
                Me._curFileName = Split(arrFileUrl(0).ToString, "?")(0)
                Dim curFilePath As String = fileUrl.Replace(Me._basePath, "").Replace("/", "\")

                Dim destinationFichier As String
                Dim arrFileFolders() As String
                If Me._basePath <> "" Then
                    destinationFichier = Me._destinationPath & curFilePath
                    ' création en casquade des dossiers/sousdossiers
                    arrFileFolders = curFilePath.Split("\")
                    If arrFileFolders.Length > 1 Then
                        ReDim Preserve arrFileFolders(arrFileFolders.Length - 2)
                        Dim tmpDestinationPath As String = Me._destinationPath
                        For Each newFolder As String In arrFileFolders
                            If Not Directory.Exists(tmpDestinationPath & newFolder) Then
                                MkDir(tmpDestinationPath & newFolder)
                            End If
                            tmpDestinationPath = tmpDestinationPath & newFolder & "\"
                        Next
                    End If
                Else
                    destinationFichier = Me._destinationPath & Me._curFileName
                End If

                ' Récupération du fichier sous forme de tableau de bytes
                Dim returnArray() As Byte
                Dim bOk As Boolean
                bOk = False
                For nEssai As Integer = 1 To 100
                    returnArray = GetURLDataBin(fileUrl)
                    If returnArray.Length > 0 Then
                        bOk = True
                        Exit For
                    Else
                        CSDebug.dispWarn("DownloadManager.doDownLoad ERR: 0 Bytes download for " & fileUrl & " Retry " & nEssai)
                    End If
                Next nEssai
                If Not bOk Then
                    CSDebug.dispError("DownloadManager.doDownLoad ERR: Impossible de télécharger " & fileUrl)
                    bReturn = False
                    'On sort immédiatement avec False
                    Return bReturn
                End If
                ' On boucle le tableau, et on écrit dans le fichier cible
                Dim bw As BinaryWriter
                If File.Exists(destinationFichier) Then
                    File.Delete(destinationFichier)
                End If
                If Not File.Exists(destinationFichier) Then
                    'Le fichier n'existe pas. On le crée
                    bw = New BinaryWriter(File.Create(destinationFichier))
                    For Each lineImg As Byte In returnArray
                        bw.Write(lineImg)
                    Next lineImg
                    bw.Close()
                End If

                ' Implémentation progressBar
                Me.m_pgbFiles.Value += 1
                Me.m_pgbFiles.Refresh()
                If Not IsNothing(m_lblFiles) Then
                    m_lblFiles.Text = Me.m_pgbFiles.Value & "/" & Me._download_totalFiles & " fichiers"
                    m_lblFiles.Refresh()
                End If
                ' FIN -- Implémentation progressBar

            Next fileUrl
                bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DownloadManager.doDowload ERR" & ex.Message)
            bReturn = False
        End Try

        Return bReturn
    End Function

    ' Fonction de téléchargement du fichier
    Private Function GetURLDataBin(ByVal URL As String, Optional ByRef UserName As String = "", Optional ByRef Password As String = "") As Byte()
        Dim Req As HttpWebRequest
        Dim SourceStream As System.IO.Stream
        Dim Response As HttpWebResponse

        Try
            ' Création de la requete HTTP
            Req = HttpWebRequest.Create(URL)

            '###########################################################

            ' Set username and password if required
            If Len(UserName) > 0 Then
                Req.Credentials = New NetworkCredential("root", "mmanasek")
            End If

            ' Récupération de la réponse
            Response = Req.GetResponse()

            'Source stream with requested document
            SourceStream = Response.GetResponseStream()

            ' FIN -- Implémentation progressBar

            'SourceStream has no ReadAll, so we must read data block-by-block
            'Temporary Buffer and block size
            Dim Buffer(4096) As Byte, BlockSize As Integer

            'Memory stream to store data
            Dim TempStream As New MemoryStream
            Do
                BlockSize = SourceStream.Read(Buffer, 0, 4096)
                If BlockSize > 0 Then
                    TempStream.Write(Buffer, 0, BlockSize)
                    ' FIN -- Implémentation progressBar
                End If
            Loop While BlockSize > 0
            ' Implémentation progressBar

            'return the document binary data
            Return TempStream.ToArray()
        Catch ex As Exception
            CSDebug.dispError("DownloadManager.GetUrlDataBin : Une erreur est survenue [" & ex.Message & "] durant le téléchargement du fichier suivant :" & URL)
            '            Dim matches As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(ex.Message.ToString, "404", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            '            If matches.Count > 0 Then
            'MsgBox("Une erreur est survenue durant le téléchargement du fichier suivant :" & vbNewLine & URL)
            'Else
            'CSDebug.dispWarn("GetURLDataBin error : " & ex.Message.ToString)
            'End If
        Finally
            Try
                SourceStream.Close()
            Catch ex As Exception
            End Try
            Try
                Response.Close()
            Catch ex As Exception
            End Try
        End Try
        Dim errStream As New MemoryStream
        Return errStream.ToArray()
    End Function

    ' Fonction permettant de vérifier que la configuration du proxy est OK
    Private Function checkProxyConf()

        '@TODO : PINg | telnet pour tester les parametres

    End Function

End Class
