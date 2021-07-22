Imports System.Collections.Generic
''' <summary>
''' Classe de lecture du référentiel des communes
''' Ce fichier est extrait de https://www.data.gouv.fr/fr/datasets/base-officielle-des-codes-postaux/
''' </summary>
''' <remarks></remarks>
Public Class ReferentielCommunesCSV

    Private m_ods As New dsCommunes()

    Public Property ods As dsCommunes
        Get
            Return m_ods
        End Get
        Set(value As dsCommunes)

        End Set
    End Property
    Public Function load() As Boolean
        Return load(GlobalsCRODIP.GLOB_STR_COMMUNES_FILENAME)
    End Function
    Public Function load(pFileName As String) As Boolean
        Dim bReturn As Boolean
        bReturn = False
        Try
            Dim lines As String() = IO.File.ReadAllLines(pFileName)

            Dim line As String
            Dim CodeInsee As String = ""
            Dim NomCommune As String = ""
            Dim CodePostal As String = ""
            Dim LibelleAcheminement As String = ""
            Dim bPremiereLigne As Boolean = True
            For Each line In lines
                If Not bPremiereLigne Then

                    Dim tab As String() = line.Split(";")

                    If Not String.IsNullOrEmpty(tab(0)) Then
                        CodeInsee = tab(0).ToUpper()
                    End If
                    If Not String.IsNullOrEmpty(tab(1)) Then
                        NomCommune = tab(1).ToUpper()
                    End If
                    If Not String.IsNullOrEmpty(tab(2)) Then
                        CodePostal = tab(2).ToUpper()
                    End If
                    If Not String.IsNullOrEmpty(tab(3)) Then
                        LibelleAcheminement = tab(3).ToUpper()
                    End If
                    m_ods.Communes.AddCommunesRow(CodeInsee, NomCommune, CodePostal, LibelleAcheminement)
                Else
                    bPremiereLigne = False
                End If

            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ReferentielCommunesCSV.load ERR" & ex.Message)
            bReturn = False
        End Try

        Return bReturn
    End Function

    ''' <summary>
    ''' Retourne une liste de communes an fonction du code postal
    ''' </summary>
    ''' <param name="pCodePostal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCommunes(pCodePostal As String) As List(Of Commune)
        Dim odt As DataTable
        If ods.Communes.Count = 0 Then
            load()
        End If
        Dim odv As New DataView(ods.Communes)
        odv.RowFilter = " CodePostal like '" & pCodePostal & "%'"
        odt = odv.ToTable()

        Dim oReturn As New List(Of Commune)
        Dim oCommune As Commune
        For Each oRow As DataRow In odt.Rows
            oCommune = New Commune(oRow("NomCommune"), oRow("CodeInsee"), oRow("CodePostal"))
            oReturn.Add(oCommune)
        Next
        Return oReturn
    End Function
    ''' <summary>
    ''' Retourne le code insee d'une commune
    ''' </summary>
    ''' <param name="pCodePostal"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getCodeINSEE(pCodePostal As String, pNomCommune As String) As String
        Dim odt As DataTable
        Dim odv As New DataView(ods.Communes)
        odv.RowFilter = " CodePostal = '" & pCodePostal & "' and NomCommune = '" & pNomCommune & "'"
        odt = odv.ToTable(True, ods.Communes.codeInseeColumn.ColumnName)

        Dim oReturn As String = ""
        For Each oRow As DataRow In odt.Rows
            oReturn = oRow(0)
        Next
        Return oReturn
    End Function
End Class
