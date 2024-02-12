Imports System.Data.OleDb

Module Module1

    Sub Main(args() As String)
        Try
            Dim oConn As OleDb.OleDbConnection
            oConn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + My.Settings.FichierMD2)
            oConn.Open()
            ' Initialisation de la DB
            Dim ocmd As OleDbCommand
            ocmd = oConn.CreateCommand()

            If args.Length > 0 Then
                If args(0) = "CLEAR" Then
                    ocmd.CommandText = "DELETE FROM tmpDataAcquiring"
                    ocmd.ExecuteNonQuery()
                    oConn.Close()
                    Exit Sub
                End If
            End If
            ocmd.CommandText = "SELECT IdNiveau,debit,pression FROM tmpDataAcquiring ORDER BY IdNiveau, IdBuse"
            Dim dataResults As System.Data.OleDb.OleDbDataReader = ocmd.ExecuteReader()

            ' Parcourt des résultats
            Dim i As Integer = 0
            Dim olst As New List(Of md2Enr)

            While dataResults.Read()

                Dim tmpResponse As New md2Enr
                ' On rempli notre tableau
                Dim tmpColId As Integer = 0
                While tmpColId < dataResults.FieldCount()
                    If Not dataResults.IsDBNull(tmpColId) Then
                        Select Case dataResults.GetName(tmpColId).ToUpper().Trim()
                            Case "idBuse".ToUpper().Trim()
                                tmpResponse.idBuse = dataResults.GetValue(tmpColId)
                            Case "idNiveau".ToUpper().Trim()
                                tmpResponse.idNiveau = dataResults.GetValue(tmpColId)
                            Case "debit".ToUpper().Trim()
                                tmpResponse.debit = dataResults.GetValue(tmpColId)
                            Case "pression".ToUpper().Trim()
                                tmpResponse.pression = dataResults.GetValue(tmpColId)
                        End Select
                    End If
                    tmpColId = tmpColId + 1
                End While
                olst.Add(tmpResponse)
            End While
            dataResults.Close()
            oConn.Close()

            'Transfert des données vers un fichier CSV
            Dim omd2enr As md2Enr
            Dim Filename As String
            Dim oFI As IO.FileInfo
            Dim oFS As IO.FileStream
            Dim oSW As IO.StreamWriter
            Dim strLine As String


            Filename = My.Settings.CSVMD2

            ' On supprime le fichier s'il existe
            oFI = New IO.FileInfo(Filename)
            If oFI.Exists Then
                oFI.Delete()
            End If

            oFS = New IO.FileStream(Filename, IO.FileMode.CreateNew, IO.FileAccess.Write)
            oSW = New IO.StreamWriter(oFS, System.Text.Encoding.Default)



            strLine = "idBuse;idNiveau;debit;pression"
            oSW.WriteLine(strLine)

            For Each omd2enr In olst
                strLine = omd2enr.idBuse & ";"
                strLine = strLine & omd2enr.idNiveau & ";"
                strLine = strLine & omd2enr.debit & ";"
                strLine = strLine & omd2enr.pression
                oSW.WriteLine(strLine)
            Next
            oSW.Close()
            oFS.Close()
        Catch ex As Exception
            Console.WriteLine("Erreur : " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Console.WriteLine("Erreur : " & ex.InnerException.Message)
            End If
        End Try



    End Sub

End Module
