'''
''' Classe de stockage des infos saisie de mesures pour l'item 831
<Serializable()> _
Public Class DiagnosticHelp831
    Private m_id As String
    Private m_idDiag As String
    Private m_Ecart_Reference As String
    Private m_Ecart_Mini As String
    Private m_Ecart_Maxi As String
    Private m_Ecart_pct As String
    Private m_Mode As ModeHelp831

    Public Const DIAGITEM_ID As String = "help831"

    Public Enum ModeHelp831
        Mode8312 = 2
        Mode8314 = 4
    End Enum

    Public Sub New(pMode As ModeHelp831)
        m_Mode = pMode
    End Sub

    Public Sub New(ByVal pId As String, ByVal pIdDiag As String)
        m_id = pId
        m_idDiag = pIdDiag
    End Sub
    Public Property id As String
        Get
            Return m_id
        End Get
        Set(ByVal Value As String)
            m_id = Value
        End Set
    End Property
    Public Property idDiag As String
        Get
            Return m_idDiag
        End Get
        Set(ByVal Value As String)
            m_idDiag = Value
        End Set
    End Property
    Public Property Ecart_reference As String
        Get
            Return m_Ecart_Reference
        End Get
        Set(ByVal Value As String)
            m_Ecart_Reference = Value
        End Set
    End Property
    Public Property Ecart_Mini As String
        Get
            Return m_Ecart_Mini
        End Get
        Set(ByVal Value As String)
            m_Ecart_Mini = Value
        End Set
    End Property
    Public Property Ecart_Maxi As String
        Get
            Return m_Ecart_Maxi
        End Get
        Set(ByVal Value As String)
            m_Ecart_Maxi = Value
        End Set
    End Property
    Public Property Ecart_pct As String
        Get
            Return m_Ecart_pct
        End Get
        Set(ByVal Value As String)
            m_Ecart_pct = Value
        End Set
    End Property
    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            If oDiagItem.idItem = "help8312" Or oDiagItem.idItem = "help8314" Then
                Dim strValue As String()
                strValue = oDiagItem.itemValue.Split("|")
                Try
                    Ecart_reference = (strValue(0))
                    Ecart_Mini = (strValue(1))
                    Ecart_Maxi = (strValue(2))
                    Ecart_pct = (strValue(3))
                Catch ex As Exception
                    CSDebug.dispError("DiagnosticHelp831.load ERR conversion (" & oDiagItem.itemValue & ") ERR " & ex.Message)
                End Try
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp831.Load ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function Save(ByVal pStructureId As String, ByVal pAgentId As String) As Boolean
        '        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pStructureId), "pStructureId must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pAgentId), "pAgentId must be set")

        Dim bReturn As Boolean
        Try
            'Cet Object est transformé en DiagItem pour le Stockage
            Dim oDiagItem As DiagnosticItem
            Dim oDiagItemLu As DiagnosticItem
            oDiagItem = ConvertToDiagnosticItem()
            If Not String.IsNullOrEmpty(id) Then
                oDiagItemLu = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
                If Not String.IsNullOrEmpty(oDiagItemLu.id) Then
                    oDiagItem.id = oDiagItemLu.id
                    oDiagItem.idDiagnostic = oDiagItemLu.idDiagnostic
                    'oDiagItem.idItem
                    'oDiagItem.itemValue
                    oDiagItem.cause = oDiagItemLu.cause
                    oDiagItem.dateModificationAgent = oDiagItemLu.dateModificationAgent
                    oDiagItem.dateModificationCrodip = oDiagItemLu.dateModificationCrodip
                End If
            End If
            If String.IsNullOrEmpty(oDiagItem.id) Then
                id = DiagnosticItemManager.getNewId(pStructureId, pAgentId)
                oDiagItem.id = id
            End If
            Dim oCSDB As New CSDb(True)
            bReturn = DiagnosticItemManager.save(oCSDB, oDiagItem)
            oCSDB.free()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp552.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        If m_Mode = ModeHelp831.Mode8312 Then
            oDiagItem.idItem = "help8312"
        Else
            oDiagItem.idItem = "help8314"
        End If

        oDiagItem.itemValue = Ecart_reference & "|" & Ecart_Mini & "|" & Ecart_Maxi & "|" & Ecart_pct
        Return oDiagItem
    End Function
    Public Function Delete() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try
            bReturn = DiagnosticItemManager.delete(id, idDiag)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp552.Delete ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function



    Public Function hasValue() As Boolean
        Dim bReturn As Boolean
        If Not String.IsNullOrEmpty(Ecart_reference) Or Not String.IsNullOrEmpty(Ecart_Mini) Or Not String.IsNullOrEmpty(Ecart_Maxi) Or Not String.IsNullOrEmpty(Ecart_pct) Then
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn

    End Function
End Class
