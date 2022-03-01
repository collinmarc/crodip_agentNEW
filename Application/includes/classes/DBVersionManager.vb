Imports System.Data.Common

Public Class DBVersionManagerManager


#Region "Methodes acces Local"

    Public Shared Function checkVersion(ByVal pNumVersion As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oDBVersion As DBVersion
            oDBVersion = getDBVersion()
            If oDBVersion.NUM.ToUpper().Trim() = pNumVersion.ToUpper.Trim() Then
                bReturn = True
            Else
                bReturn = False
            End If
        Catch ex As Exception
            CSDebug.dispError("DBVersion.CheckVersion Error : ", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    ' Methode OK
    ''' <summary>
    ''' renvoie un La version de la base de données
    ''' </summary>
    ''' <returns> une instance de dbVersion</returns>
    ''' <remarks></remarks>
    Public Shared Function getDBVersion() As DBVersion
        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim oDBVersion As New DBVersion()

        oCsdb = New CSDb(True)

        bddCommande = oCsdb.getConnection().CreateCommand()
        bddCommande.CommandText = "SELECT * FROM VERSION ORDER BY VERSION_DATE DESC"
        Try
            ' On récupère les résultats
            Dim oDBReader As DbDataReader = bddCommande.ExecuteReader
            ' Puis on les parcours
            If oDBReader.HasRows() Then
                oDBReader.Read()
                Dim tmpcolID As Integer = 0
                While tmpcolID < oDBReader.FieldCount()
                    If Not oDBReader.IsDBNull(tmpcolID) Then
                        oDBVersion.Fill(oDBReader.GetName(tmpcolID), oDBReader.Item(tmpcolID))
                    End If
                    tmpcolID = tmpcolID + 1
                End While
            End If
        Catch ex As Exception ' On intercepte l'erreur
            CSDebug.dispFatal("DBVersionManager - GetDBVersion() Erreur : " & ex.Message)
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        'on retourne l'agent ou un objet vide en cas d'erreur
        Return oDBVersion

    End Function 'getDBversion


    Public Shared Function save(ByVal pDBVersion As DBVersion) As Boolean
        Debug.Assert(Not pDBVersion Is Nothing, "La version doit être renseignée")
        Debug.Assert(Not String.IsNullOrEmpty(pDBVersion.NUM), "La version doit être renseignée")

        Dim oCsdb As CSDb = Nothing
        Dim bddCommande As DbCommand
        Dim bReturn As Boolean
        Dim nResult As Integer

        Try
            bReturn = False

            oCsdb = New CSDb(True)

            bddCommande = oCsdb.getConnection.CreateCommand()

            Dim paramsQuery As String
            paramsQuery = "VERSION_NUM='" & pDBVersion.NUM & "'"
            paramsQuery = paramsQuery & " , " & "VERSION_DATE='" & CSDate.TOCRODIPString(pDBVersion.DateVersion) & "'"
            paramsQuery = paramsQuery & " , " & "VERSION_COMM='" & pDBVersion.Commentaire & "'"

            bddCommande.CommandText = "UPDATE `VERSION` SET " & paramsQuery
            nResult = bddCommande.ExecuteNonQuery()
            Debug.Assert(nResult = 1, "DBVersionManager.save: Erreur en update 0 ou  plus d'une ligne concernée")
            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DBVersionManager.save ERREUR : " & ex.Message.ToString)
            bReturn = False
        End Try
        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function
    Public Shared Function insert(ByVal pDBVersion As DBVersion) As Boolean
        Debug.Assert(Not pDBVersion Is Nothing, "La version doit être renseignée")
        Debug.Assert(Not String.IsNullOrEmpty(pDBVersion.NUM), "La version doit être renseignée")

        Dim oCsdb As CSDb = Nothing
        Dim bReturn As Boolean

        Try
            bReturn = False

            oCsdb = New CSDb(True)


            Dim paramsQuery As String
            paramsQuery = "VERSION_NUM='" & pDBVersion.NUM & "'"
            paramsQuery = paramsQuery & " , " & "VERSION_DATE='" & CSDate.TOCRODIPString(pDBVersion.DateVersion) & "'"
            paramsQuery = paramsQuery & " , " & "VERSION_COMM='" & pDBVersion.Commentaire & "'"

            paramsQuery = "insert into VERSION (VERSION_NUM, VERSION_DATE,VERSION_COMM) VALUES"
            paramsQuery = paramsQuery & "('" & pDBVersion.NUM & "','" & CSDate.TOCRODIPString(pDBVersion.DateVersion) & "','" & pDBVersion.Commentaire & "') "
            oCsdb.Execute(paramsQuery)

            bReturn = True
        Catch ex As Exception
            CSDebug.dispFatal("DBVersionManager.insert ERREUR : " & ex.Message.ToString)
            bReturn = False
        End Try

        If Not oCsdb Is Nothing Then
            oCsdb.free()
        End If
        Return bReturn
    End Function


#End Region


End Class
