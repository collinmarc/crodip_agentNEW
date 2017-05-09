'''
''' Classe de stockage des infos saisie de mesures pour l'item 5621
''' Hérite de DiagnosticHelp551 
<Serializable()> _
Public Class DiagnosticHelp5621
    Inherits DiagnosticHelp551

    Public Sub New()
        MyBase.New(Help551Mode.Mode5621)
    End Sub

    Public Sub New(ByVal pId As String, ByVal pIdDiag As String)
        MyBase.New(pId, pIdDiag)
        m_id = pId
        m_idDiag = pIdDiag
        m_idItem = "help5621"
    End Sub
End Class
