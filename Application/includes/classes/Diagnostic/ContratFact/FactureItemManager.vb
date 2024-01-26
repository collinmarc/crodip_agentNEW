Imports System.Collections.Generic
Imports System.Data.Common

Public Class FactureItemManager
    Inherits CrodipManager

    Public Shared Function Exists(pFactureID As String, pNumero As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand
            oCmd = oCSDB.getConnection.CreateCommand
            oCmd.CommandText = "SELECT Count(*) from factureItem where idFacture = @1 and nFactureItem = @2"
            AddParameter(oCmd, "@1", pFactureID)
            AddParameter(oCmd, "@2", pNumero)

            Dim n As Integer
            n = oCmd.ExecuteScalar()
            bReturn = (n > 0)
            oCSDB.free()

        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.exists ERR ", ex)
            bReturn = False
        End Try
        Return bReturn

    End Function



    Public Shared Function save(pFactureItem As FactureItem, Optional bSyncro As Boolean = False) As Boolean
        Debug.Assert(pFactureItem IsNot Nothing)

        Dim bReturn As Boolean
        Dim oCSDB As New CSDb(True)

        If Not bSyncro Then
            pFactureItem.dateModificationAgent = DateTime.Now
        End If
        Try
            If Exists(pFactureItem.idFacture, pFactureItem.nFactureItem) Then
                bReturn = update(pFactureItem, bSyncro)
            Else
                bReturn = insert(pFactureItem, bSyncro)
            End If
        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.save ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Private Shared Function update(pfactureItem As FactureItem, bsynchro As Boolean) As Boolean
        Dim breturn As Boolean

        Dim oCSDB As New CSDb(True)
        Try

            Dim oCmd As DbCommand
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "Update FACTUREITEM SET " &
                "categorie = '" & pfactureItem.categorie & "' , " &'1
                "prestation = '" & pfactureItem.prestation & "' , " &'2
                "quantite = '" & pfactureItem.quantite & "', " &'3'
                "pu = '" & pfactureItem.pu & "', " &'4
                "totalhtitem = '" & pfactureItem.totalHT & "', " &'5'
                "totaltvaItem = '" & pfactureItem.totalTVA & "', " &'6
                "totalTTCItem = '" & pfactureItem.totalTTC & "', " &'7
                "txTVAItem = '" & pfactureItem.txTVA & "', " &'8
                "dateModificationAgent = '" & CSDate.ToCRODIPString(pfactureItem.dateModificationAgent) & "', " &'9
                "dateModificationCrodip = '" & CSDate.ToCRODIPString(pfactureItem.dateModificationCrodip) & "'" &'10
                "WHERE " &
                "idFacture = '" & pfactureItem.idFacture & "' And " &'11
                "nFactureitem = '" & pfactureItem.nFactureItem & "' " '12


            'AddParameter(oCmd, "@_1", pfactureItem.categorie)
            'AddParameter(oCmd, "@_2", pfactureItem.prestation)
            'AddParameter(oCmd, "@_3", pfactureItem.quantite)
            'AddParameter(oCmd, "@_4", pfactureItem.pu)
            'AddParameter(oCmd, "@_5", pfactureItem.totalHT)
            'AddParameter(oCmd, "@_6", pfactureItem.totalTVA)
            'AddParameter(oCmd, "@_7", pfactureItem.totalTTC)
            'AddParameter(oCmd, "@_8", pfactureItem.txTVA)
            'AddParameter(oCmd, "@_9", CSDate.ToCRODIPString(pfactureItem.dateModificationAgent))
            'AddParameter(oCmd, "@_10", CSDate.ToCRODIPString(pfactureItem.dateModificationCrodip))
            'AddParameter(oCmd, "@_11", pfactureItem.idFacture)
            'AddParameter(oCmd, "@_12", pfactureItem.nFactureItem)

            oCmd.ExecuteNonQuery()

            breturn = True
        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.update ERR", ex)
            breturn = False
        End Try
        oCSDB.free()
        Return breturn
    End Function
    Private Shared Function insert(pfactureItem As FactureItem, bsynchro As Boolean) As Boolean
        Dim breturn As Boolean

        Try
            Dim oCSDB As New CSDb(True)

            Dim oCmd As IDbCommand
            'If CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE Then
            '    Dim oCmd As Microsoft.Data.Sqlite.SqliteCommand
            'Else
            '    Dim oCmd As System.Data.OleDb.OleDbCommand
            'End If

            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "insert into FACTUREITEM (" &
                "categorie , " &'1
                "prestation , " &'2
                "quantite , " &'3'
                "pu , " &'4
                "totalhtitem , " &'5'
                "totaltvaItem , " &'6
                "totalTTCItem , " &'7
                "txTVAItem, " &'8
                "dateModificationAgent , " &'9
                "dateModificationCrodip, " &'10
                "idFacture ," &'11
                "nFactureitem  " &  '12
                " ) VALUES ( " &
                    "@1 , " &'1
                "@2 , " &'2
                "@3, " &'3'
                "@4, " &'4
                "@5, " &'5'
                "@6, " &'6
                "@7, " &'7
                "@8, " &'8
                "@9, " &'9
                "@10," &'10
                "@11," &'11
                "@12 " & '12
                ")"

            AddParameter(oCmd, "@1", pfactureItem.categorie)
            AddParameter(oCmd, "@2", pfactureItem.prestation)
            AddParameter(oCmd, "@3", pfactureItem.quantite, DbType.Currency)
            AddParameter(oCmd, "@4", pfactureItem.pu, DbType.Currency)
            AddParameter(oCmd, "@5", pfactureItem.totalHT, DbType.Currency)
            AddParameter(oCmd, "@6", pfactureItem.totalTVA, DbType.Currency)
            AddParameter(oCmd, "@7", pfactureItem.totalTTC, DbType.Currency)
            AddParameter(oCmd, "@8", pfactureItem.txTVA, DbType.Currency)
            AddParameter(oCmd, "@9", CSDate.TOCRODIPString(pfactureItem.dateModificationAgent))
            AddParameter(oCmd, "@10", CSDate.TOCRODIPString(pfactureItem.dateModificationCrodip))
            AddParameter(oCmd, "@11", pfactureItem.idFacture)
            AddParameter(oCmd, "@12", pfactureItem.nFactureItem)


            oCmd.ExecuteNonQuery()

            oCSDB.free()
            breturn = True
        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.insert ERR", ex)


            breturn = False
        End Try
        Return breturn
    End Function
    Public Shared Function getFactureById(pFactureId As String) As List(Of FactureItem)
        Debug.Assert(Not String.IsNullOrEmpty(pFactureId), "PFactureId must be set")

        Dim oReturn As New List(Of FactureItem)
        Try
            Dim oCSDB As New CSDb(True)
            Dim oCmd As DbCommand
            Dim oDR As DbDataReader
            Dim n As Integer = 1
            oCmd = oCSDB.getConnection().CreateCommand
            oCmd.CommandText = "SELECT * FROM FactureItem where idFacture = @1 ORDER BY nfactureitem asc"
            AddParameter(oCmd, "@1", pFactureId)
            oDR = oCmd.ExecuteReader()

            While oDR.Read()
                Dim olg As New FactureItem()
                Dim nChamp As Integer
                For nChamp = 0 To oDR.FieldCount() - 1
                    If Not oDR.IsDBNull(nChamp) Then
                        Fill(olg, oDR.GetName(nChamp), oDR.GetValue(nChamp))
                    End If
                Next
                olg.idFacture = pFactureId
                oReturn.Add(olg)
                '                olg.nFactureItem = n
                n = n + 1
            End While
            oDR.Close()
            oCSDB.free()


        Catch ex As Exception
            CSDebug.dispError("FactureItemManager.getFactureById ERR", ex)
            oReturn = New List(Of FactureItem)()
        End Try
        Return oReturn
    End Function

    Public Shared Sub Fill(pLg As FactureItem, pNomchamp As String, pValue As Object)
        Try

            Select Case Trim(pNomchamp).ToUpper()
                Case Trim("categorie").ToUpper()
                    pLg.categorie = pValue.ToString()
                Case Trim("prestation").ToUpper()
                    pLg.prestation = pValue
                Case Trim("quantite").ToUpper()
                    pLg.quantite = pValue
                Case Trim("pu").ToUpper()
                    pLg.pu = pValue
                Case Trim("totalhtitem").ToUpper()
                    pLg.totalHT = pValue
                Case Trim("totaltvaItem").ToUpper()
                    pLg.totalTVA = pValue
                Case Trim("totalTTCItem").ToUpper()
                    pLg.totalTTC = pValue
                Case Trim("txTVAItem").ToUpper()
                    pLg.txTVA = pValue
                Case Trim("idFacture").ToUpper()
                    pLg.idFacture = pValue
                Case Trim("nFactureItem").ToUpper()
                    pLg.nFactureItem = pValue
                Case Trim("dateModificationAgent").ToUpper()
                    pLg.dateModificationAgent = pValue
                Case Trim("dateModificationCrodip").ToUpper()
                    pLg.dateModificationCrodip = pValue
            End Select
        Catch ex As Exception
            CSDebug.dispError("Facture.Fill(" & pNomchamp & "," & pValue & ")", ex)
        End Try

    End Sub



End Class
