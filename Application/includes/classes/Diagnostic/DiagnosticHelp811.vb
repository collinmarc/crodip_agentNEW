'''
''' Classe de stockage des infos saisie de mesures pour l'item 811
<Serializable()> _
Public Class DiagnosticHelp811
    Private m_id As String
    Private m_idDiag As String
    Private m_LargeurRampe As String
    Private m_fleche As String

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
    Public Property LargeurRampe As String
        Get
            Return m_LargeurRampe
        End Get
        Set(ByVal Value As String)
            m_LargeurRampe = Value
        End Set
    End Property
    Public Property Fleche As String
        Get
            Return m_fleche
        End Get
        Set(ByVal Value As String)
            m_fleche = Value
        End Set
    End Property
    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            If oDiagItem.idItem = "help811" Then
                Dim strValue As String()
                strValue = oDiagItem.itemValue.Split("|")
                Try
                    LargeurRampe = strValue(0)
                    Fleche = strValue(1)
                Catch ex As Exception
                    CSDebug.dispError("DiagnosticHelp511.load ERR conversion (" & oDiagItem.itemValue & ") ERR " & ex.Message)
                End Try
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp811.Load ERR: " & ex.Message)
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
            Dim oCSDB As New CSDb(True)
            bReturn = DiagnosticItemManager.save(oCSDB, oDiagItem)
            oCSDB.free()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp811.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = "help811"
        oDiagItem.itemValue = LargeurRampe & "|" & Fleche
        Return oDiagItem
    End Function
    Public Function Delete() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try
            bReturn = DiagnosticItemManager.delete(id, idDiag)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp811.Delete ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function



    Public Function hasValue() As Boolean
        Dim bReturn As Boolean
        If Not String.IsNullOrEmpty(LargeurRampe) Or Not String.IsNullOrEmpty(Fleche) Then
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn

    End Function
End Class
