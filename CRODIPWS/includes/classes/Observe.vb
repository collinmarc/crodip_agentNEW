Imports System.Collections.Generic
''' <summary>
''' Objet observé par des obbservateurs
''' </summary>
''' <remarks></remarks>
Public MustInherit Class Observe
    Private mList As New List(Of IObservateur)
    Protected m_listSynchro As String

    Public Sub ajouteObservateur(pObj As IObservateur)
        mList.Add(pObj)
    End Sub
    Public Sub Notice(pMsg As String)
        For Each obj As IObservateur In mList
            obj.Notice(pMsg)
        Next
        m_listSynchro = m_listSynchro & pMsg & ";"
    End Sub
End Class
