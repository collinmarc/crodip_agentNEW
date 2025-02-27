﻿Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports Ionic.Zip
Imports CRODIPWS

''' <summary>
''' Etat Genérique CRODIP
''' </summary>
''' <remarks></remarks>
Public Class EtatCrodipADEL
    Protected m_FileName As String
    Protected m_oReportDocument As ReportDocument
    Protected m_Path As String
    Public Overridable Function getFileName() As String
        Return m_FileName
    End Function
    Public Overridable Function getFileNameFullPath() As String
        Return m_Path & m_FileName
    End Function
    Public Overridable Function getReportdocument() As ReportDocument
        Return m_oReportDocument
    End Function
    ''' <summary>
    ''' Ouvre le fichier avec l'application par défaut
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Open() As Boolean
        Dim bReturn As Boolean

        If Not String.IsNullOrEmpty(getFileName()) Then
            CRODIPWS.CSFile.open(m_Path & getFileName())
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn
    End Function
    Public Function genereEtat(Optional pExportPDF As Boolean = True) As Boolean
        Dim bReturn As Boolean = False
        If Not String.IsNullOrEmpty(m_Path) Then
            If Not Directory.Exists(m_Path) Then
                Directory.CreateDirectory(m_Path)
            End If
        End If
        bReturn = genereEtatLocal(pExportPDF)
        If (pExportPDF) Then
            bReturn = bReturn And AddPDFs()
        End If
        Return bReturn
    End Function
    Protected Overridable Function genereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Return False
    End Function

    Private Function AddPDFs() As Boolean
        Dim FileName As String = m_Path & getFileName()
        Dim bReturn As Boolean = False
        Try
            Dim oDI As New DirectoryInfo(GlobalsCRODIP.CONST_STOCK_PDFS)
            If Not Directory.Exists(GlobalsCRODIP.CONST_STOCK_PDFS) Then
                oDI.Create()
                oDI.Attributes = FileAttributes.Hidden
            End If

            If Not Directory.Exists(GlobalsCRODIP.CONST_STOCK_PDFS & "\" & GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE) Then
                oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_MANOCONTROLE)

            End If
            If Not Directory.Exists(GlobalsCRODIP.CONST_STOCK_PDFS & "\" & GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE) Then
                oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_BANCMESURE)

            End If
            If Not Directory.Exists(GlobalsCRODIP.CONST_STOCK_PDFS & "\" & GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC) Then
                oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_DIAGNOSTIC)

            End If
            If Not Directory.Exists(GlobalsCRODIP.CONST_STOCK_PDFS & "\" & GlobalsCRODIP.CONST_PATH_EXP_FACTURE) Then
                oDI.CreateSubdirectory(GlobalsCRODIP.CONST_PATH_EXP_FACTURE)

            End If

            If File.Exists(FileName) Then
                System.IO.File.Copy(FileName, GlobalsCRODIP.CONST_STOCK_PDFS & "\" & FileName)
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispError("EtatCrodip.AddPFS ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getPDFs(pPathDest As String, pFileName As String) As String
        Dim FileName As String = pPathDest & pFileName
        Try
            'If My.Settings.TypeStockPDF = "ZIP" Then
            '    If Not File.Exists(GlobalsCRODIP.CONST_STOCK_PDFS) Then
            '        FileName = ""
            '    Else
            '        Using z As ZipFile = ZipFile.Read(GlobalsCRODIP.CONST_STOCK_PDFS)
            '            z.Password = GlobalsCRODIP.CONST_PDFS_DIAG_PWD
            '            z.ExtractSelectedEntries(pFileName, pPathDest, "", ExtractExistingFileAction.OverwriteSilently)
            '        End Using
            '    End If
            'End If
            'If My.Settings.TypeStockPDF = "DIR" Then
            If Not File.Exists(FileName) Then
                If File.Exists(GlobalsCRODIP.CONST_STOCK_PDFS & "\" & FileName) Then
                    System.IO.File.Copy(GlobalsCRODIP.CONST_STOCK_PDFS & "\" & FileName, FileName)
                End If
            End If
            If File.Exists(FileName) Then
                FileName = pPathDest & pFileName
            Else
                FileName = ""
            End If
            ' End If
        Catch ex As Exception
            CSDebug.dispError("etatCrodip.getPFS ERR", ex)
            FileName = ""
        End Try
        Return FileName
    End Function


End Class
