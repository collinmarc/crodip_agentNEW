'''
''' Classe de stockage des infos Pression par Defaut
<Serializable()> _
Public Class DiagnosticInfosComplementaires
    Private m_id As String
    Private m_idDiag As String
    Private m_PressionParDefaut As String
    Public Const DIAGITEM_ID As String = "InfosComp"
    Public Sub New()

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
    Public Property PressionParDefaut As String
        Get
            Return m_PressionParDefaut
        End Get
        Set(ByVal Value As String)
            m_PressionParDefaut = Value
        End Set
    End Property
    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            If oDiagItem.idItem = DIAGITEM_ID Then
                Dim strValue As String()
                strValue = oDiagItem.itemValue.Split("|")
                Try
                    PressionParDefaut = (strValue(0))
                Catch ex As Exception
                    CSDebug.dispError("DiagnosticInfosComplementaires.load ERR conversion (" & oDiagItem.itemValue & ") ERR " & ex.Message)
                End Try
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticInfosComplementaires.Load ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function Save(ByVal pStructureId As String, ByVal pAgentId As String, pCSDB As CSDb) As Boolean
        '        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pStructureId), "pStructureId must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pAgentId), "pAgentId must be set")
        Debug.Assert(pCSDB.isOpen(), "La Connection Doit être ouverte")

        Dim bReturn As Boolean
        Try
            'Cet Object est transformé en DiagItem pour le Stockage
            Dim oDiagItem As DiagnosticItem
            Dim oDiagItemLu As DiagnosticItem
            oDiagItem = ConvertToDiagnosticItem()
            If Not String.IsNullOrEmpty(id) Or id = "0" Then
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
            If CSDb._DBTYPE <> CSDb.EnumDBTYPE.SQLITE Then
                If Not String.IsNullOrEmpty(id) Or id = "0" Then
                    id = DiagnosticItemManager.getNewId(pStructureId, pAgentId)
                    oDiagItem.id = id
                End If
            End If
            bReturn = DiagnosticItemManager.save(pCSDB, oDiagItem)
            id = oDiagItem.id
        Catch ex As Exception
            CSDebug.dispError("DiagnosticInfosComplementaires.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = DIAGITEM_ID
        oDiagItem.itemValue = PressionParDefaut & "|"
        Return oDiagItem
    End Function
    Public Function Delete() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try
            bReturn = DiagnosticItemManager.delete(id, idDiag)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticInfosComplementaires.Delete ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function



    Public Function hasValue() As Boolean
        Dim bReturn As Boolean
        If Not String.IsNullOrEmpty(PressionParDefaut) Then
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn

    End Function
End Class
