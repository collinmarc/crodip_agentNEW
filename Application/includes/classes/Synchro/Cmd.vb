''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
Public Class Cmd


    Public Function execute(ByVal pFileName As String) As Boolean
        Dim bReturn As Boolean
        Try
            If My.Computer.FileSystem.FileExists(pFileName) Then
                Dim streamReader As New System.IO.StreamReader(pFileName)
                Dim ligne As String
                ligne = streamReader.ReadLine
                bReturn = True
                While Not ligne Is Nothing And bReturn
                    executeLine(ligne)
                    ligne = streamReader.ReadLine()
                End While
                streamReader.Close()



            End If


            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Cmd.execute Err " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function executeLine(ByVal pcmdLine As String) As Boolean
        Dim bReturn As Boolean
        Try
            If pcmdLine.ToUpper.StartsWith("DELETE ") Then
                Dim strFileName As String
                strFileName = pcmdLine.Replace("DELETE ", "").Trim()
                If My.Computer.FileSystem.FileExists(strFileName) Then
                    My.Computer.FileSystem.DeleteFile(strFileName)
                Else
                    If My.Computer.FileSystem.DirectoryExists(strFileName) Then
                        My.Computer.FileSystem.DeleteDirectory(strFileName, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    End If

                End If

            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Cmd.executeLine Err " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class
