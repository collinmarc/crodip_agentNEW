Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
'''
<Serializable()> _
Public Class DiagnosticHelp12123Pompe
    Implements ICloneable
    Private m_id As String
    Private m_idDiag As String
    Private m__Numero As Integer
    Private m_debitMesure? As Decimal = Nothing
    Private m_PressionMesure? As Decimal = Nothing
    Private m_PressionMoyenne? As Decimal = Nothing
    Private m_NbBuses? As Decimal = Nothing

    Private m_DebitReel? As Decimal = Nothing
    Private m_DebitTotal? As Decimal = Nothing
    Private m_EcartReglageMoyen? As Decimal
    Private m_Resultat As String
    Private m_bCalcule As Boolean = False

    Private m_help12123 As DiagnosticHelp12123
    Public Property help12123() As DiagnosticHelp12123
        Get
            Return m_help12123
        End Get
        Set(ByVal value As DiagnosticHelp12123)
            m_help12123 = value
        End Set
    End Property

    Private m_lstHelp12123Mesures As List(Of DiagnosticHelp12123Mesure)
    Public Property lstMesures() As List(Of DiagnosticHelp12123Mesure)
        Get
            Return m_lstHelp12123Mesures
        End Get
        Set(ByVal value As List(Of DiagnosticHelp12123Mesure))
            m_lstHelp12123Mesures = value
        End Set
    End Property

    Public Const DIAGITEM_ID As String = "H12123P"
    Public LIMITE_ECART_MAJEUR As Decimal = 5
    Private Sub New()
        m_Resultat = ""
        m_bCalcule = True
        m_lstHelp12123Mesures = New List(Of DiagnosticHelp12123Mesure)
    End Sub

    Public Sub New(pHelp12123 As DiagnosticHelp12123, pNum As Integer)
        Me.New()
        m_help12123 = pHelp12123
        m__Numero = pNum
    End Sub
    Public Sub New(ByVal pId As String, pIdDiag As String)
        Me.New()
        m_id = pId
        m_idDiag = pIdDiag
    End Sub
    Public ReadOnly Property Image() As Bitmap
        Get
            If Resultat = DiagnosticItem.EtatDiagItemOK Then
                Return Resources.PuceVerteT
            Else
                If Resultat = DiagnosticItem.EtatDiagItemMAJEUR Then
                    Return Resources.PuceRougeT
                Else
                    Return Resources.PuceGriseT
                End If
            End If
        End Get
    End Property
    Public ReadOnly Property LabelResultat() As String
        Get
            If Resultat = DiagnosticItem.EtatDiagItemOK Then
                Return "OK"
            Else
                If Resultat = DiagnosticItem.EtatDiagItemMAJEUR Then
                    Return "ERREUR"
                Else
                    Return ""
                End If
            End If
        End Get
    End Property


    Public Property numero() As Integer
        Get
            Return m__Numero
        End Get
        Set(ByVal value As Integer)
            m__Numero = value
        End Set
    End Property

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
    Public Property bCalcule As Boolean
        Get
            Return m_bCalcule
        End Get
        Set(ByVal Value As Boolean)
            m_bCalcule = Value
        End Set
    End Property
    Public ReadOnly Property Nom() As String
        Get
            Return "Pompe " & numero
        End Get
    End Property

    Public Property debitMesure As Decimal?
        Get
            Return m_debitMesure
        End Get
        Set(value As Decimal?)
            m_debitMesure = value
            calcule()
        End Set
    End Property
    Public Property PressionMesure As Decimal?
        Get
            Return m_PressionMesure
        End Get
        Set(value As Decimal?)
            m_PressionMesure = value
            calcule()
        End Set
    End Property
    Public Property PressionMoyenne As Decimal?
        Get
            Return m_PressionMoyenne
        End Get
        Set(value As Decimal?)
            m_PressionMoyenne = value
            calcule()
        End Set
    End Property
    Public Property NbBuses As Decimal?
        Get
            Return m_NbBuses
        End Get
        Set(value As Decimal?)
            m_NbBuses = value
            calcule()

        End Set
    End Property
    Public Property DebitReel As Decimal?
        Get
            Return m_DebitReel
        End Get
        Set(value As Decimal?)
            setDebitReel(value)
        End Set
    End Property
    Private Sub setDebitReel(pValue As Decimal?)
        m_DebitReel = pValue
        For Each oMesure As DiagnosticHelp12123Mesure In lstMesures
            oMesure.calcule()
        Next
    End Sub

    Public Property DebitReelRND As Decimal?
        Get
            If DebitReel.HasValue Then
                Return Math.Round(DebitReel.Value, 2)
            Else
                Return Nothing
            End If
        End Get
        Set(value As Decimal?)
            m_DebitReel = value
        End Set
    End Property
    Public Property DebitTotal As Decimal?
        Get
            Return m_DebitTotal
        End Get
        Set(value As Decimal?)
            setDebitTotal(value)
        End Set
    End Property
    Private Sub setDebitTotal(pValue As Decimal?)
        m_DebitTotal = pValue
        For Each oMesure As DiagnosticHelp12123Mesure In lstMesures
            oMesure.calcule()
        Next
    End Sub
    Public Property DebitTotalRND As Decimal?
        Get
            If DebitTotal.HasValue Then
                Return Math.Round(DebitTotal.Value, 2)
            Else
                Return Nothing
            End If
        End Get
        Set(value As Decimal?)
            m_DebitTotal = value
        End Set
    End Property
    Public Property Resultat As String

        Get
            Return m_Resultat
        End Get
        Set(value As String)
            m_Resultat = value
        End Set
    End Property
    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            getDatasFromItemValue(oDiagItem)
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123Mesure.Load ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function Load(pidDiag As String, pNumPompe As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCsDB As New CSDb(True)
            Dim oCmd As OleDb.OleDbCommand

            oCmd = oCsDB.getConnection().CreateCommand()
            Dim strQuery As String
            strQuery = "Select * from DiagnosticItem where idDiagnostic = '" & pidDiag & "' and idItem = '" & DIAGITEM_ID & pNumPompe & "'"
            oCmd.CommandText = strQuery
            Dim oDr As OleDb.OleDbDataReader
            oDr = oCmd.ExecuteReader()
            If oDr.HasRows() Then
                oDr.Read()
                Dim oDiagItem As DiagnosticItem = New DiagnosticItem()
                Dim tmpColId As Integer = 0
                While tmpColId < oDr.FieldCount()
                    oDiagItem.Fill(oDr.GetName(tmpColId), oDr.Item(tmpColId))
                    tmpColId = tmpColId + 1
                End While
                getDatasFromItemValue(oDiagItem)
            End If
            oDr.Close()
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnocticHelp12123Pompe:load(" & pidDiag & "," & pNumPompe & " ) ERROR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Sub getDatasFromItemValue(pDiagItem As DiagnosticItem)

        If pDiagItem.idItem.StartsWith(DIAGITEM_ID) Then
            Try
                bCalcule = False 'Au rechargement on désactive le calcul
                Me.id = pDiagItem.id
                Me.idDiag = pDiagItem.idDiagnostic
                Dim tabValues As String()
                tabValues = pDiagItem.itemValue.Split("|")

                'oDiagItem.itemValue = ConvertAttToString(numero) & "|"
                'oDiagItem.itemValue = oDiagItem.itemValue & Resultat & "|" '4
                'oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(debitMesure) & "|" '4
                'oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(PressionMesure) & "|" '4
                'oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(PressionMoyenne) & "|" '4
                'oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(NbBuses) & "|" '4
                'oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitReel) & "|" '5
                'oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitTotal) & "|" '5
                numero = ConvertStringToAtt(tabValues(0))
                Resultat = tabValues(1)
                debitMesure = ConvertStringToAtt(tabValues(2))
                PressionMesure = ConvertStringToAtt(tabValues(3))
                PressionMoyenne = ConvertStringToAtt(tabValues(4))
                NbBuses = ConvertStringToAtt(tabValues(5))
                DebitReel = ConvertStringToAtt(tabValues(6))
                DebitTotal = ConvertStringToAtt(tabValues(7))
                Dim nbMesure As Integer
                nbMesure = ConvertStringToAtt(tabValues(8))
                EcartReglageMoyen = ConvertStringToAtt(tabValues(9))
                For nMesure As Integer = 1 To nbMesure
                    Dim oMesure As DiagnosticHelp12123Mesure = New DiagnosticHelp12123Mesure(Me, nMesure)
                    oMesure.idDiag = idDiag
                    oMesure.Load(idDiag, numero, nMesure)
                    m_lstHelp12123Mesures.Add(oMesure)
                Next
                bCalcule = True
            Catch ex As Exception
                CSDebug.dispError("DiagnosticHelp12123Mesure.load ERR conversion (" & pDiagItem.itemValue & ") ERR " & ex.Message)
            End Try
        End If

    End Sub

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
                    'Récupération des infos Lues
                    oDiagItem.id = oDiagItemLu.id
                    oDiagItem.idDiagnostic = oDiagItemLu.idDiagnostic
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
            For Each oMEsure As DiagnosticHelp12123Mesure In m_lstHelp12123Mesures
                oMEsure.idDiag = idDiag
                oMEsure.Save(pStructureId, pAgentId)
            Next
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123Pompe.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = DIAGITEM_ID & numero

        oDiagItem.itemValue = ConvertAttToString(numero) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & Resultat & "|" '1
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(debitMesure) & "|" '2
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(PressionMesure) & "|" '3
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(PressionMoyenne) & "|" '4
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(NbBuses) & "|" '5
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitReel) & "|" '6
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitTotal) & "|" '7
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(m_lstHelp12123Mesures.Count) & "|" '8
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(EcartReglageMoyen) & "|" '9

        Return oDiagItem
    End Function

    Private Function ConvertAttToString(pValue? As Decimal) As String
        If pValue.HasValue Then
            Return Trim(pValue.ToString())
        Else
            Return ""
        End If
    End Function
    Private Function ConvertStringToAtt(pValue As String) As Decimal
        If String.IsNullOrEmpty(pValue) Then
            Return Nothing
        Else
            Try
                Return CDec(pValue)
            Catch
                Return Nothing
            End Try
        End If
    End Function
    Public Function Delete() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try
            bReturn = DiagnosticItemManager.delete(id, idDiag)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123.Delete ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function hasValue() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Return bReturn

    End Function

    Public Function calcule() As Boolean
        Dim bReturn As Boolean
        Try
            Dim nEcartReglage As Decimal
            If bCalcule Then
                If Me.debitMesure.HasValue And Me.PressionMoyenne.HasValue And Me.PressionMesure.HasValue Then
                    'Debit Reel
                    DebitReel = Me.debitMesure * Math.Sqrt(Me.PressionMoyenne / Me.PressionMesure)
                Else
                    DebitReel = Nothing
                End If
                'Debit Total
                If DebitReel.HasValue And Me.NbBuses.HasValue Then
                    DebitTotal = DebitReel * Me.NbBuses
                Else
                    DebitTotal = Nothing
                End If
                If lstMesures.Count > 0 Then
                    For Each oMesure As DiagnosticHelp12123Mesure In lstMesures
                        'Le Calcul de la pompe est déclenché par le calcul des Mesures
                        'Donc ne pas redemander le calcul des mesures ...
                        If oMesure.EcartReglageRND.HasValue Then
                            nEcartReglage = nEcartReglage + oMesure.EcartReglageRND
                        End If
                    Next
                    EcartReglageMoyen = Math.Round(nEcartReglage / lstMesures.Count, 2)
                    Resultat = DiagnosticItem.EtatDiagItemOK
                    If Math.Abs(EcartReglageMoyen.Value) > LIMITE_ECART_MAJEUR Then
                        Resultat = DiagnosticItem.EtatDiagItemMAJEUR
                    End If
                    m_help12123.calcule()
                End If

            End If
            bReturn = True
        Catch ex As Exception
            bReturn = False
            CSDebug.dispError("DiagnosticHelp12123Pompe.Calcule ERR : " & ex.Message)

        End Try
        Return bReturn
    End Function

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As DiagnosticHelp12123Pompe

        Try


            ' Create a memory stream and a formatter.
            Dim ms As New System.IO.MemoryStream(1000)
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing, _
                New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Clone))
            ' Serialize the object into the stream.
            bf.Serialize(ms, Me)
            ' Position streem pointer back to first byte.
            ms.Seek(0, System.IO.SeekOrigin.Begin)
            ' Deserialize into another object.
            oReturn = bf.Deserialize(ms)
            ' release memory.
            ms.Close()
        Catch ex As Exception
            CSDebug.dispError("Diagnostic12123MesurePompe.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Function AjouteMesure() As DiagnosticHelp12123Mesure
        Dim oMesure As DiagnosticHelp12123Mesure

        oMesure = New DiagnosticHelp12123Mesure(Me, lstMesures.Count + 1)
        lstMesures.Add(oMesure)
        Return oMesure
    End Function
    ''' <summary>
    ''' Rend le nombre de mesures
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNbMesures() As Integer
        Return lstMesures.Count
    End Function

    ''' <summary>
    ''' Rend le nombre de mesures
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getMesure(pNumMesure As Integer) As DiagnosticHelp12123Mesure
        Dim oReturn As DiagnosticHelp12123Mesure
        If pNumMesure < 0 Or pNumMesure > lstMesures.Count - 1 Then
            oReturn = Nothing
        Else
            oReturn = lstMesures(pNumMesure)
        End If
        Return oReturn
    End Function

    Public Property EcartReglageMoyen() As Decimal?
        Get
            Return m_EcartReglageMoyen
        End Get
        Set(ByVal value As Decimal?)
            m_EcartReglageMoyen = value
        End Set
    End Property


End Class
