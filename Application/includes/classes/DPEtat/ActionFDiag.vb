Public Enum Action
    ACTION_NEXT = 10
    ACTION_BACK = 20
    ACTION_BACKTOPRELIM = 21
    ACTION_BACKTODEFAUTS = 22
    ACTION_END = 30
    ACTION_CVI = 40
    ACTION_RECAP = 50 'Recap à partir des préliminaires
End Enum
Public Class ActionFDiag
    Public CodeAction As Action
    Public context As Object
End Class

Public Class ActionFDiagNext
    Inherits ActionFDiag
    Public Sub New()
        CodeAction = Action.ACTION_NEXT
    End Sub
End Class
Public Class ActionFDiagback
    Inherits ActionFDiag
    Public Sub New()
        CodeAction = Action.ACTION_BACK
    End Sub
End Class
Public Class ActionFDiagbackToPreliminaires
    Inherits ActionFDiag
    Public Sub New()
        CodeAction = Action.ACTION_BACKTOPRELIM
    End Sub
End Class
Public Class ActionFDiagbackToDefauts
    Inherits ActionFDiag
    Public Sub New()
        CodeAction = Action.ACTION_BACKTODEFAUTS
    End Sub
End Class
Public Class ActionFDiagEND
    Inherits ActionFDiag
    Public Sub New()
        CodeAction = Action.ACTION_END
    End Sub
End Class
Public Class ActionFDiagCVImmediate
    Inherits ActionFDiag
    Public Sub New()
        CodeAction = Action.ACTION_CVI
    End Sub
End Class
Public Class ActionFDiagRecapApresPreliminaire
    Inherits ActionFDiag
    Public Sub New()
        CodeAction = Action.ACTION_RECAP
    End Sub
End Class
