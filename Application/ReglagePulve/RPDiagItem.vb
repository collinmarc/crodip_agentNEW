Imports System.Collections.Generic
Public Class RPDiagItem
    Inherits DiagnosticItem


    Public Sub New(pControl As CRODIP_ControlLibrary.CtrlDiag2)
        MyBase.New(pControl)
    End Sub
    Public Sub New(ByVal idDiagnostic As String, ByVal pItem As String, ByVal pValue As String, Optional ByVal pCause As String = "", Optional ByVal pCodeEtat As String = "")
        MyBase.New(idDiagnostic, pItem, pValue, pCause, pCodeEtat)

    End Sub

End Class
