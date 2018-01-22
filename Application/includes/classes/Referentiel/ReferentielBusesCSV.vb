Imports System.Collections.Generic
Public Class ReferentielBusesCSV

    Private m_ods As New dsReferentielBuses()

    Public Property ods As dsReferentielBuses
        Get
            Return m_ods
        End Get
        Set(value As dsReferentielBuses)

        End Set
    End Property
    Public Function load() As Boolean
        Return load(GLOB_STR_REFERENTIELBUSES_FILENAME)
    End Function
    Public Function load(pFileName As String) As Boolean
        Dim bReturn As Boolean
        bReturn = False
        Try
            Dim lines As String() = IO.File.ReadAllLines(pFileName)

            Dim line As String
            Dim Marque As String
            Dim Modele As String
            Dim Type As String
            Dim Fonctionnement As String
            Dim ISO As String
            Dim Angle As String
            Dim AngleLu As String
            Dim Couleur As String
            Dim Calibre As String
            Dim Debit2bar As String
            Dim debit3bar As String
            Dim debit5bar As String
            Dim tolerance As String
            Dim bPremiereLigne As Boolean = True
            For Each line In lines
                If Not bPremiereLigne Then

                    Dim tab As String() = line.Split(";")
                    If tab.Length <= 12 Then
                        'Traitement des agnles Multipes
                        If Not String.IsNullOrEmpty(tab(5)) Then
                            AngleLu = tab(5).ToUpper()
                        End If
                        Dim tabAngles As String() = AngleLu.Split("-")
                        For Each sAngle As String In tabAngles

                            If Not String.IsNullOrEmpty(tab(0)) Then
                                Marque = tab(0).ToUpper()
                            End If
                            If Not String.IsNullOrEmpty(tab(1)) Then
                                Modele = tab(1).ToUpper()
                            End If
                            If Not String.IsNullOrEmpty(tab(2)) Then
                                Type = tab(2).ToUpper()
                            End If
                            If Not String.IsNullOrEmpty(tab(3)) Then
                                Fonctionnement = tab(3).ToUpper()
                            End If
                            If Not String.IsNullOrEmpty(tab(4)) Then
                                ISO = tab(4).ToUpper()
                            End If
                            Angle = sAngle
                            Couleur = tab(6).ToUpper()
                            Calibre = tab(7).ToUpper()
                            Debit2bar = tab(8).ToUpper()
                            debit3bar = tab(9).ToUpper()
                            debit5bar = tab(10).ToUpper()
                            tolerance = tab(11).ToUpper()

                            m_ods.ReferentieBuses.AddReferentieBusesRow(Marque, Modele, Type, Fonctionnement, ISO, Angle, Couleur, Calibre, Debit2bar, debit3bar, debit5bar, tolerance)
                        Next sAngle
                    Else
                        CSDebug.dispWarn("ReferentielBusesCSV.load WRN Referentiel incotrect : " & line)
                    End If
                Else
                    bPremiereLigne = False
                End If
            Next
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("ReferentielBusesCSV.load ERR" & ex.Message)
            bReturn = False
        End Try

        Return bReturn
    End Function

    Public Function getMarques() As List(Of String)
        Dim odt As DataTable
        odt = ods.ReferentieBuses.DefaultView.ToTable(True, ods.ReferentieBuses.MarqueColumn.ColumnName)
        Dim oReturn As New List(Of String)
        For Each oRow As DataRow In odt.Rows
            oReturn.Add(oRow(0))
        Next
        Return oReturn
    End Function

    Public Function getModeles(pMarque As String) As List(Of String)
        Dim odt As DataTable
        Dim odv As New DataView(ods.ReferentieBuses)
        odv.RowFilter = " Marque = '" & pMarque & "'"
        odt = odv.ToTable(True, ods.ReferentieBuses.ModeleColumn.ColumnName)

        Dim oReturn As New List(Of String)
        For Each oRow As DataRow In odt.Rows
            oReturn.Add(oRow(0))
        Next
        Return oReturn
    End Function
    Public Function getTypesBuse(pMarque As String, pModele As String) As List(Of String)
        Dim odt As DataTable
        Dim odv As New DataView(ods.ReferentieBuses)
        odv.RowFilter = ods.ReferentieBuses.MarqueColumn.ColumnName & "  = '" & pMarque & "' And " & ods.ReferentieBuses.ModeleColumn.ColumnName & " = '" & pModele & "'"
        odt = odv.ToTable(True, ods.ReferentieBuses.TypeBuseColumn.ColumnName)

        Dim oReturn As New List(Of String)
        For Each oRow As DataRow In odt.Rows
            oReturn.Add(oRow(0))
        Next
        Return oReturn
    End Function

    Public Function getTypesBuse() As List(Of String)
        Dim odt As DataTable
        Dim odv As New DataView(ods.ReferentieBuses)
        '        odv.RowFilter = ods.ReferentieBuses.MarqueColumn.ColumnName & "  = '" & pMarque & "' And " & ods.ReferentieBuses.ModeleColumn.ColumnName & " = '" & pModele & "'"
        odt = odv.ToTable(True, ods.ReferentieBuses.TypeBuseColumn.ColumnName)

        Dim oReturn As New List(Of String)
        For Each oRow As DataRow In odt.Rows
            oReturn.Add(oRow(0))
        Next
        Return oReturn
    End Function
    Public Function getFonctionnementsBuse(pMarque As String, pModele As String) As List(Of String)
        Dim odt As DataTable
        Dim odv As New DataView(ods.ReferentieBuses)
        odv.RowFilter = ods.ReferentieBuses.MarqueColumn.ColumnName & "  = '" & pMarque & "' And " & ods.ReferentieBuses.ModeleColumn.ColumnName & " = '" & pModele & "'"
        odt = odv.ToTable(True, ods.ReferentieBuses.FonctionnementColumn.ColumnName)

        Dim oReturn As New List(Of String)
        For Each oRow As DataRow In odt.Rows
            oReturn.Add(oRow(0))
        Next
        Return oReturn
    End Function
    ''' <summary>
    ''' Retourne une liste de fonctionnement en fonction des types de buses
    ''' </summary>
    ''' <param name="pType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getFonctionnementsBuse(pType As String) As List(Of String)
        Dim odt As DataTable
        Dim odv As New DataView(ods.ReferentieBuses)
        odv.RowFilter = ods.ReferentieBuses.TypeBuseColumn.ColumnName & "  = '" & pType & "'"
        odt = odv.ToTable(True, ods.ReferentieBuses.FonctionnementColumn.ColumnName)

        Dim oReturn As New List(Of String)
        For Each oRow As DataRow In odt.Rows
            oReturn.Add(oRow(0))
        Next
        Return oReturn
    End Function
    Public Function getISOsBuseByMarqueModele(pMarque As String, pModele As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, "", "", ods.ReferentieBuses.ISOColumn.ColumnName)
    End Function
    Public Function getISOsBuseByTypeFonctionnement(pType As String, pFonctionnement As String) As List(Of String)
        Return getParamsBuse("", "", pType, pFonctionnement, ods.ReferentieBuses.ISOColumn.ColumnName)
    End Function
    Public Function getAnglesBuseByMarqueModele(pMarque As String, pModele As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, "", "", ods.ReferentieBuses.AngleColumn.ColumnName)
    End Function
    Public Function getAnglesBuseByTypeFonctionnement(pType As String, pFonctionnement As String) As List(Of String)
        Return getParamsBuse("", "", pType, pFonctionnement, ods.ReferentieBuses.AngleColumn.ColumnName)
    End Function
    Public Function getCouleursBuseByMarqueModele(pMarque As String, pModele As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, "", "", ods.ReferentieBuses.CouleurColumn.ColumnName)
    End Function
    Public Function getCouleursBuseByTypeFonctionnement(pType As String, pFonctionnement As String) As List(Of String)
        Return getParamsBuse("", "", pType, pFonctionnement, ods.ReferentieBuses.CouleurColumn.ColumnName)
    End Function
    Private Function AddFilter(pFilter As String, pColumnName As String, pValue As String) As String
        Dim sReturn As String
        sReturn = pFilter
        If Not String.IsNullOrEmpty(sReturn) Then
            sReturn = sReturn & " AND "
        End If
        sReturn = sReturn & pColumnName & " = '" & CSDb.secureString(pValue) & "'"
        Return sReturn
    End Function
    Public Function getParamsBuse(pMarque As String, pModele As String, pType As String, pFonctionnement As String, pColumName As String) As List(Of String)
        Dim odt As DataTable
        Dim odv As New DataView(ods.ReferentieBuses)
        If Not String.IsNullOrEmpty(pMarque) Then
            odv.RowFilter = AddFilter(odv.RowFilter, ods.ReferentieBuses.MarqueColumn.ColumnName, pMarque)
        End If
        If Not String.IsNullOrEmpty(pModele) Then
            odv.RowFilter = AddFilter(odv.RowFilter, ods.ReferentieBuses.ModeleColumn.ColumnName, pModele)
        End If
        If Not String.IsNullOrEmpty(pType) Then
            odv.RowFilter = AddFilter(odv.RowFilter, ods.ReferentieBuses.TypeBuseColumn.ColumnName, pType)
        End If
        If Not String.IsNullOrEmpty(pFonctionnement) Then
            odv.RowFilter = AddFilter(odv.RowFilter, ods.ReferentieBuses.FonctionnementColumn.ColumnName, pFonctionnement)
        End If

        'On passe par la méthode ToTable pour simuler le DISTINCT 
        odt = odv.ToTable(True, pColumName)

        Dim oReturn As New List(Of String)
        For Each oRow As DataRow In odt.Rows
            oReturn.Add(oRow(0))
        Next
        Return oReturn
    End Function
    Public Function getParamsBuse(pMarque As String, pModele As String, pCouleur As String, pColumName As String) As List(Of String)
        Dim odt As DataTable
        Dim odv As New DataView(ods.ReferentieBuses)
        If Not String.IsNullOrEmpty(pMarque) Then
            odv.RowFilter = AddFilter(odv.RowFilter, ods.ReferentieBuses.MarqueColumn.ColumnName, pMarque)
        End If
        If Not String.IsNullOrEmpty(pModele) Then
            odv.RowFilter = AddFilter(odv.RowFilter, ods.ReferentieBuses.ModeleColumn.ColumnName, pModele)
        End If
        'If Not String.IsNullOrEmpty(pCouleur) Then
        odv.RowFilter = AddFilter(odv.RowFilter, ods.ReferentieBuses.CouleurColumn.ColumnName, pCouleur)
        'End If
        odt = odv.ToTable(True, pColumName)

        Dim oReturn As New List(Of String)
        If odt.Rows.Count = 0 Then
            oReturn.Add("")
        Else
            For Each oRow As DataRow In odt.Rows
                oReturn.Add(oRow(0))
            Next
        End If
        Return oReturn
    End Function
    'Méthodes appellées depuis le Diagnostique
    Public Function getCalibresBuse(pMarque As String, pModele As String, pCouleur As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, pCouleur, ods.ReferentieBuses.calibreColumn.ColumnName)
    End Function
    Public Function getDebit2barBuse(pMarque As String, pModele As String, pCouleur As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, pCouleur, ods.ReferentieBuses.Debit2barColumn.ColumnName)
    End Function
    Public Function getDebit3barBuse(pMarque As String, pModele As String, pCouleur As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, pCouleur, ods.ReferentieBuses.Debit3barColumn.ColumnName)
    End Function
    Public Function getDebit5barBuse(pMarque As String, pModele As String, pCouleur As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, pCouleur, ods.ReferentieBuses.Debit5barColumn.ColumnName)
    End Function
    Public Function getToleranceBuse(pMarque As String, pModele As String, pCouleur As String) As List(Of String)
        Return getParamsBuse(pMarque, pModele, pCouleur, ods.ReferentieBuses.ToleranceColumn.ColumnName)
    End Function
End Class
