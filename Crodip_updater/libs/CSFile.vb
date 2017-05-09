Imports System.IO

Module CSFile

    Public Function exists(ByVal fileName As String)
        If System.IO.File.Exists(fileName) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function open(ByVal fileName As String)
        Try
            Dim monProcess As New Process
            monProcess.StartInfo.FileName = fileName
            monProcess.StartInfo.Verb = "Open"
            monProcess.StartInfo.CreateNoWindow = True
            monProcess.Start()
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::open : " & ex.Message)
        End Try
    End Function

    Public Function delete(ByVal fileName As String)
        Try
            System.IO.File.Delete(fileName)
        Catch ex As Exception
            CSDebug.dispWarn("CSFile::delete : " & ex.Message)
        End Try
    End Function

    Public Function create(ByVal fileName As String, ByVal fileBody As String)
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
    End Function
    Public Function create(ByVal fileName As String)
        CSFile.create(fileName, "")
    End Function

    Public Function append(ByVal fileName As String, ByVal fileContent As String)
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
    End Function

    Public Function write(ByVal fileName As String, ByVal fileContent As String)
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
    End Function

End Module
