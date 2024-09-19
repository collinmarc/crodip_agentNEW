'''
''' Classe de stockage des infos saisie de mesures pour l'item 5622
<Serializable()> _
Public Class DiagnosticHelp5622
    Inherits DiagnosticHelp552
    Public Sub New()

        m_idItem = "help5622"
    End Sub

    Public Sub New(ByVal pId As String, ByVal pIdDiag As String)
        m_id = pId
        m_idDiag = pIdDiag
        m_idItem = "help5622"
    End Sub
End Class
