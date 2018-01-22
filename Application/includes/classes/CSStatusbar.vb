Public Class CSStatusbar

    Private statusBarObj As StatusBar
    Private loaderObj As PictureBox

    ' Constructeur
    Sub New(ByVal _statusBarObj As Statusbar, ByVal _loaderObj As PictureBox)
        init(_statusBarObj, _loaderObj)
    End Sub

    ' Initialisation de l'objet statusbar
    Public Function init(ByVal _statusBarObj As Statusbar, ByVal _loaderObj As PictureBox)
        Me.statusBarObj = _statusBarObj
        Me.loaderObj = _loaderObj
    End Function

    ' Affichage d'un message dans la statusbar
    Public Sub display(ByVal message As String)
        Try
            Me.statusBarObj.Text = " "
            If Me.loaderObj.Visible = True Then
                message = "        " & Trim(message)
            Else
                message = Trim(message)
            End If
            Me.statusBarObj.Text = message
        Catch

        End Try

    End Sub
    ' Affichage d'un message dans la statusbar + affichage du loader
    Public Function display(ByVal message As String, ByVal isLoader As Boolean)
        If isLoader = True Then
            Me.showLoader()
        Else
            Me.hideLoader()
        End If
        Me.display(message)
    End Function

    ' Affichage du loader
    Public Function toggleLoader()
        If Me.loaderObj.Visible = False Then
            Me.showLoader()
        Else
            Me.hideLoader()
        End If
    End Function
    Public Function hideLoader()
        Me.loaderObj.Visible = False
        Me.display(Me.statusBarObj.Text)
        CSTime.pause(500) ' Pause de 500ms
    End Function
    Public Function showLoader()
        Me.loaderObj.Visible = True
        Me.display(Me.statusBarObj.Text)
        CSTime.pause(500) ' Pause de 500ms
    End Function

    ' Efface la barre de status
    Public Function clear()
        Me.display("", False)
    End Function

    ' Récupère le libellé courant de la statusbar
    Public Function getLibelle()
        Return Me.statusBarObj.Text
    End Function

End Class
