Imports CrystalDecisions.CrystalReports.Engine

''' <summary>
''' Etat Genérique CRODIP
''' </summary>
''' <remarks></remarks>
Public Class EtatCrodip
    Protected m_FileName As String
    Protected m_oReportDocument As ReportDocument
    Public Overridable Function getFileName() As String
        Return m_FileName
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
            CSFile.open(Globals.CONST_PATH_EXP & getFileName())
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn
    End Function
    Public Overridable Function genereEtat(Optional pExportPDF As Boolean = True) As Boolean
        Return False
    End Function

End Class
