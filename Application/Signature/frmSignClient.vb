Public Class frmSignClient
    Inherits System.Windows.Forms.Form
    Shared Function getfrmSignature(pDiag As Diagnostic, psignMode As SignMode, pAgent As Agent) As frmSignClient

        Dim ofrm As frmSignClient
        If My.Settings.ModeSignature = "Téléphone" Then
            ofrm = New frmSignClientTelephone(pDiag, psignMode, pAgent)
        Else
            ofrm = New frmSignClientTablette(pDiag, psignMode, pAgent)
        End If
        Return ofrm
    End Function
End Class
