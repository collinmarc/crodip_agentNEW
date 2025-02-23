Imports System.IO

Public Class CSFile

    Public Shared Sub open(ByVal fileName As String)
        Try
            If System.IO.File.Exists(fileName) Then

                Using monProcess As New Process
                    monProcess.StartInfo.FileName = fileName.Replace("/", "\\")
                    monProcess.StartInfo.Verb = "Open"
                    monProcess.StartInfo.CreateNoWindow = True
                    monProcess.Start()
                End Using
            End If
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::open : " & ex.Message)
        End Try
    End Sub

    Public Shared Sub delete(ByVal fileName As String)
        Try
            System.IO.File.Delete(fileName)
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::delete : " & ex.Message)
        End Try
    End Sub

    Public Shared Sub create(ByVal fileName As String, ByVal fileBody As String)
        Try
            Dim curFile As StreamWriter
            If Not File.Exists(fileName) Then
                curFile = New StreamWriter(fileName)
                If fileBody <> "" Then
                    curFile.Write(fileBody)
                End If
                curFile.Close()
            End If
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::create : " & ex.Message)
        End Try
    End Sub
    Public Shared Sub create(ByVal fileName As String)
        CSFile.create(fileName, "")
    End Sub

    Public Shared Sub append(ByVal fileName As String, ByVal fileContent As String)
        Try
            Dim curFile As StreamWriter
            If File.Exists(fileName) Then
                curFile = New StreamWriter(fileName, True)
                If fileContent <> "" Then
                    curFile.WriteLine(fileContent)
                End If
                curFile.Close()
            End If
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::append : " & ex.Message)
        End Try
    End Sub

    Public Shared Sub write(ByVal fileName As String, ByVal fileContent As String)
        Try
            Dim curFile As StreamWriter
            If File.Exists(fileName) Then
                curFile = New StreamWriter(fileName, False)
                If fileContent <> "" Then
                    curFile.WriteLine(fileContent)
                End If
                curFile.Close()
            End If
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::append : " & ex.Message)
        End Try
    End Sub

End Class
