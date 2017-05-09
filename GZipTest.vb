Imports System
Imports System.IO
Imports System.IO.Compression



Public Class GZipTest
    Shared msg As String
    Private Const buffer_size As Integer = 100

    Public Shared Function ReadAllBytesFromStream(ByVal stream As Stream, ByVal buffer() As Byte) As Integer
        ' Use this method is used to read all bytes from a stream.
        Dim offset As Integer = 0
        Dim totalCount As Integer = 0
        While True
            Dim bytesRead As Integer = stream.Read(buffer, offset, buffer_size)
            If bytesRead = 0 Then
                Exit While
            End If
            offset += bytesRead
            totalCount += bytesRead
        End While
        Return totalCount
    End Function 'ReadAllBytesFromStream


    Public Shared Function CompareData(ByVal buf1() As Byte, ByVal len1 As Integer, ByVal buf2() As Byte, ByVal len2 As Integer) As Boolean
        ' Use this method to compare data from two different buffers.
        If len1 <> len2 Then
            msg = "Number of bytes in two buffer are different" & len1 & ":" & len2
            MsgBox(msg)
            Return False
        End If

        Dim i As Integer
        For i = 0 To len1 - 1
            If buf1(i) <> buf2(i) Then
                msg = "byte " & i & " is different " & buf1(i) & "|" & buf2(i)
                MsgBox(msg)
                Return False
            End If
        Next i
        msg = "All bytes compare."
        MsgBox(msg)
        Return True
    End Function 'CompareData


    Public Shared Sub GZipCompressDecompress(ByVal filename As String)
        msg = "Test compression and decompression on file " & filename
        MsgBox(msg)

        Dim infile As FileStream
        Try
            ' Open the file as a FileStream object.
            infile = New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim buffer(infile.Length - 1) As Byte
            ' Read the file to ensure it is readable.
            Dim count As Integer = infile.Read(buffer, 0, buffer.Length)
            If count <> buffer.Length Then
                infile.Close()
                msg = "Test Failed: Unable to read data from file"
                MsgBox(msg)
                Return
            End If
            infile.Close()
            Dim ms As New MemoryStream()
            ' Use the newly created memory stream for the compressed data.
            Dim compressedzipStream As New GZipStream(ms, CompressionMode.Compress, True)
            compressedzipStream.Write(buffer, 0, buffer.Length)
            ' Close the stream.
            compressedzipStream.Close()

            msg = "Original size: " & buffer.Length & ", Compressed size: " & ms.Length
            MsgBox(msg)

            ' Reset the memory stream position to begin decompression.
            ms.Position = 0
            Dim zipStream As New GZipStream(ms, CompressionMode.Decompress)
            Dim decompressedBuffer(buffer.Length + buffer_size) As Byte
            ' Use the ReadAllBytesFromStream to read the stream.
            Dim totalCount As Integer = GZipTest.ReadAllBytesFromStream(zipStream, decompressedBuffer)
            msg = "Decompressed " & totalCount & " bytes"
            MsgBox(msg)

            If Not GZipTest.CompareData(buffer, buffer.Length, decompressedBuffer, totalCount) Then
                msg = "Error. The two buffers did not compare."
                MsgBox(msg)

            End If
            zipStream.Close()
        Catch e As Exception
            msg = "Error: The file being read contains invalid data."
            MsgBox(msg)
        End Try

    End Sub 'GZipCompressDecompress

End Class 'GZipTest 