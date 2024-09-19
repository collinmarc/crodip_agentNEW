Imports System.IO
Imports System.Net
Public Class Referentiel


    Public Enum RETOURSYNCHRO As Integer
        ERREUR = -1
        PAS_DE_SYNCHRO = 0
        SYNCHRO_EFFECTUEE = 1
    End Enum

    ' Fonction de t�l�chargement du fichier
    Protected Shared Function GetURLDataBin(ByVal URL As String, Optional ByRef UserName As String = "", Optional ByRef Password As String = "") As Byte()
        Dim Req As HttpWebRequest
        Dim SourceStream As System.IO.Stream = Nothing
        Dim Response As HttpWebResponse = Nothing

        Try
            ' Cr�ation de la requete HTTP
            Req = HttpWebRequest.Create(URL)

            '###########################################################

            ' Set username and password if required
            If Len(UserName) > 0 Then
                Req.Credentials = New NetworkCredential("root", "mmanasek")
            End If

            ' R�cup�ration de la r�ponse
            Response = Req.GetResponse()

            'Source stream with requested document
            SourceStream = Response.GetResponseStream()


            'SourceStream has no ReadAll, so we must read data block-by-block
            'Temporary Buffer and block size
            Dim Buffer(4096) As Byte, BlockSize As Integer

            'Memory stream to store data
            Dim TempStream As New MemoryStream
            Do
                BlockSize = SourceStream.Read(Buffer, 0, 4096)
                If BlockSize > 0 Then
                    TempStream.Write(Buffer, 0, BlockSize)
                    ' FIN -- Impl�mentation progressBar
                End If
            Loop While BlockSize > 0
            ' FIN -- Impl�mentation progressBar

            'return the document binary data
            Return TempStream.ToArray()
        Catch ex As Exception
            Dim matches As System.Text.RegularExpressions.MatchCollection = System.Text.RegularExpressions.Regex.Matches(ex.Message.ToString, "404", System.Text.RegularExpressions.RegexOptions.IgnoreCase)
            If matches.Count > 0 Then
                MsgBox("Une erreur est survenue durant le t�l�chargement du fichier suivant :" & vbNewLine & URL)
            Else
                'CSDebug.dispWarn("GetURLDataBin error : " & ex.Message.ToString)
            End If
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

    Public Shared Function WriteFile(Contenu As Byte(), destination As String) As Boolean
        Dim bReturn As Boolean
        Try

            ' On boucle le tableau, et on �crit dans le fichier cible
            Dim bw As BinaryWriter
            If File.Exists(destination) Then
                File.Delete(destination)
            End If
            If Not File.Exists(destination) Then
                'Le fichier n'existe pas. On le cr�e
                bw = New BinaryWriter(File.Create(destination))
                For Each lineImg As Byte In Contenu
                    bw.Write(lineImg)
                Next lineImg
                bw.Close()
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Referentiel.WriteFile Error " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class