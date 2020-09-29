Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports Ionic.Zip

''' <summary>
''' Etat Genérique CRODIP
''' </summary>
''' <remarks></remarks>
Public Class EtatCrodip
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
            CSFile.open(m_Path & getFileName())
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn
    End Function
    Public Function genereEtat(Optional pExportPDF As Boolean = True) As Boolean
        genereEtatLocal(pExportPDF)
        If (pExportPDF) Then
            AddPDFs()
        End If
    End Function
    Protected Overridable Function genereEtatLocal(Optional pExportPDF As Boolean = True) As Boolean
        Return False
    End Function

    Private Function AddPDFs() As Boolean
        Dim FileName As String = m_Path & getFileName()
        Dim bReturn As Boolean = False
        Try
            If Not File.Exists(Globals.CONST_PDFS_DIAG) Then
                Using z As New ZipFile()
                    z.Password = Globals.CONST_PDFS_DIAG_PWD
                    z.Save(Globals.CONST_PDFS_DIAG)
                End Using

            End If
            If File.Exists(FileName) Then
                Using z As ZipFile = ZipFile.Read(Globals.CONST_PDFS_DIAG)
                    z.Password = Globals.CONST_PDFS_DIAG_PWD
                    z.AddFile(FileName, m_Path)
                    z.Save()
                End Using
                bReturn = True
            End If
        Catch ex As Exception
            CSDebug.dispError("EtatCrodip.AddPFS ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Shared Function getPDFs(pPath As String, pFileName As String) As String
        Dim FileName As String = pPath & pFileName
        Try
            If Not File.Exists(Globals.CONST_PDFS_DIAG) Then
                FileName = ""
            Else
                Using z As ZipFile = ZipFile.Read(Globals.CONST_PDFS_DIAG)
                    z.Password = Globals.CONST_PDFS_DIAG_PWD
                    z.ExtractSelectedEntries(pFileName, Globals.CONST_PATH_EXP, "", ExtractExistingFileAction.OverwriteSilently)
                End Using
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostic.getPFS ERR", ex)
            FileName = ""
        End Try
        Return FileName
    End Function


End Class
