' Date : 19.05.2009
' Version : 1.0
' Auteur : Nicolas MATHEU <nicolas.matheu@cognix-systems.com>
Module CSCsv

    Public Function ListviewToCSV(ByVal oLV As ListView) As String
        Dim sFile As String = Environment.GetFolderPath(GlobalsCRODIP.CONST_PATH_TMP) & "\ListviewData.csv"
        Return ListviewToCSV(oLV, sFile)
    End Function

    Public Function ListviewToCSV(ByVal oLV As ListView, ByVal sFile As String) As String
        Return ListviewToCSV(oLV, sFile, False)
    End Function

    Public Function ListviewToCSV(ByVal oLV As ListView, ByVal sFile As String, ByVal bIncludeHidden As Boolean) As String
        Try
            Dim i As Integer
            Dim oItem As ListViewItem
            Dim sData As String = ""
            Dim sLine As String
            Dim Q As String = Chr(34)
            Dim QC As String = Chr(34) + ";"

            ' On crée les entêtes de colones
            sLine = Q + "ID" + QC
            For i = 0 To oLV.Columns.Count - 1
                ' On vérifie si on inclue les colones cachées
                If bIncludeHidden Or oLV.Columns(i).Width > 0 Then
                    ' On retire les espace pour les titres de colone
                    sLine += Q + Replace(oLV.Columns(i).Text, " ", "") + QC
                End If
            Next
            ' On supprime la dernière virgule
            sData += DropChar(sLine, 1) + vbNewLine

            For Each oItem In oLV.Items
                sLine = IIf(IsNumeric(oItem.Tag), oItem.Tag + ",", Q + oItem.Tag + QC)
                For i = 0 To oItem.SubItems.Count - 1
                    If bIncludeHidden Or oLV.Columns(i).Width > 0 Then
                        'wrap the nonnumeric fields in quotes
                        sLine += IIf(IsNumeric(oItem.SubItems(i).Text), oItem.SubItems(i).Text + ";", Q + oItem.SubItems(i).Text + QC)
                    End If
                Next
                sData += DropChar(sLine, 1) + vbNewLine
            Next

            ' On supprime le fichier s'il existe
            Dim oFI As New IO.FileInfo(sFile)
            If oFI.Exists Then
                oFI.Delete()
            End If
            Dim oFS As New IO.FileStream(sFile, IO.FileMode.CreateNew, IO.FileAccess.Write)
            Dim oSW As New IO.StreamWriter(oFS, System.Text.Encoding.Default)
            oSW.Write(sData)
            oSW.Flush()
            oSW.Close()
            oFS.Close()
            Return sFile
        Catch Exc As Exception
            Return Exc.Message
        End Try
    End Function

    Public Function DropChar(ByVal sText As String, Optional ByVal iCharToDrop As Integer = 1) As String
        Try
            Dim sTemp As String
            sTemp = Trim(LTrim(sText))
            sTemp = sTemp.Substring(0, sTemp.Length - iCharToDrop)
            Return sTemp
        Catch Exc As Exception
            Throw Exc
        End Try
    End Function

End Module
