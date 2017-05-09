''' <summary>
''' Etat Genérique CRODIP
''' </summary>
''' <remarks></remarks>
Public Class EtatCrodip
    Protected m_FileName As String
    Public Overridable Function getFileName() As String
        Return m_FileName
    End Function
    ''' <summary>
    ''' Ouvre le fichier avec l'application par défaut
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overridable Function Open() As Boolean
        Dim bReturn As Boolean

        If Not String.IsNullOrEmpty(getFileName()) Then
            CSFile.open(CONST_PATH_EXP & getFileName())
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn
    End Function

End Class
