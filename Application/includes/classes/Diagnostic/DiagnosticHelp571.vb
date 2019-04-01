Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
'''
''' Classe de stockage des infos saisie de mesures pour l'item 571
''' Voir fichier Calcul571
<Serializable()> _
Public Class DiagnosticHelp571
    Implements ICloneable

    Private m_id As String
    Private m_idDiag As String
    Private m_Regulation As String
    Private m_isDPAE As Boolean
    Private m_isDPAEDebit As Boolean
    Private m_isDPAEPression As Boolean
    Private m_bCalcul As Boolean = True
    'Capteur de débit
    Private m_ErreurVitesseDEB? As Decimal
    Private m_ErreurDebitDEB? As Decimal
    Private m_ErreurGlobaleDEB? As Decimal
    Private m_ResultDEB As String
    'Capteur de Pression
    Private m_debitMesurePRS? As Decimal
    Private m_PressionMesurePRS? As Decimal
    Private m_PressionMoyennePRS? As Decimal
    Private m_DebitBuseProgrammePRS? As Decimal
    Private m_DebitReelPRS? As Decimal
    Private m_ErreurDebitPRS? As Decimal
    Private m_ErreurVitessePRS? As Decimal
    Private m_ErreurGlobalePRS? As Decimal
    Private m_ResultPRS As String

    'Paramètre de Calcul
    Public RegulationDPAE As String = "DPAE"
    Public VTSB1 As Decimal = 5 'Borne 1
    Public VTSB2 As Decimal = 10 'Borne 2
    Public Const DIAGITEM_ID As String = "help571"

    Public Sub New()
        bCalcule = True
    End Sub
    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As DiagnosticHelp571

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
            CSDebug.dispError("Diagnostic.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

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

    'Cacul automatique ou pas
    Public Property bCalcule As Boolean
        Get
            Return m_bCalcul
        End Get
        Set(ByVal Value As Boolean)
            m_bCalcul = Value
        End Set
    End Property
    Public Property Regulation As String
        Get
            Return m_Regulation
        End Get
        Set(ByVal Value As String)
            m_Regulation = Value
        End Set
    End Property
    Public Property IsDPAE As Boolean
        Get
            Return m_isDPAE
        End Get
        Set(ByVal Value As Boolean)
            m_isDPAE = Value
        End Set
    End Property
    Public Property IsDPAEDebit As Boolean
        Get
            Return m_isDPAEDebit
        End Get
        Set(ByVal Value As Boolean)
            m_isDPAEDebit = Value
        End Set
    End Property
    Public Property IsDPAEPression As Boolean
        Get
            Return m_isDPAEPression
        End Get
        Set(ByVal Value As Boolean)
            m_isDPAEPression = Value
        End Set
    End Property
    Public Property ResultPRS As String
        Get
            Return m_ResultPRS
        End Get
        Set(ByVal Value As String)
            m_ResultPRS = Value
        End Set
    End Property
    Public Property ResultDEB As String
        Get
            Return m_ResultDEB
        End Get
        Set(ByVal Value As String)
            m_ResultDEB = Value
        End Set
    End Property
    Public Function getResult() As String
        Dim sResult As String = ""
        If IsDPAEDebit And Not IsDPAEPression Then
            sResult = DiagnosticItem.EtatDiagItemOK
            If ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR Then
                sResult = DiagnosticItem.EtatDiagItemMAJEUR
            End If
            If ResultDEB = DiagnosticItem.EtatDiagItemMINEUR Then
                sResult = DiagnosticItem.EtatDiagItemMINEUR
            End If
        End If
        If Not IsDPAEDebit And IsDPAEPression Then
            sResult = DiagnosticItem.EtatDiagItemOK
            If ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR Then
                sResult = DiagnosticItem.EtatDiagItemMAJEUR
            End If
            If ResultPRS = DiagnosticItem.EtatDiagItemMINEUR Then
                sResult = DiagnosticItem.EtatDiagItemMINEUR
            End If
        End If
        If IsDPAEDebit And IsDPAEPression Then
            sResult = DiagnosticItem.EtatDiagItemOK
            If ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR Or ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR Then
                sResult = DiagnosticItem.EtatDiagItemMAJEUR
            Else
                If ResultDEB = DiagnosticItem.EtatDiagItemMINEUR Or ResultPRS = DiagnosticItem.EtatDiagItemMINEUR Then
                    sResult = DiagnosticItem.EtatDiagItemMINEUR
                End If
            End If
        End If
            Return sResult
    End Function
    Public Property erreurVitesseDEB As Decimal?
        Get
            Return m_ErreurVitesseDEB
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurVitesseDEB = Value
            calcule()
        End Set
    End Property
    Public Property erreurDebitDEB As Decimal?
        Get
            Return m_ErreurDebitDEB
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurDebitDEB = Value
            calcule()
        End Set
    End Property
    Public Property erreurGlobaleDEB As Decimal?
        Get
            Return m_ErreurGlobaleDEB
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurGlobaleDEB = Value
        End Set
    End Property
    Public Property ErreurGlobaleDEBRND As Decimal?
        Get
            If m_ErreurGlobaleDEB.HasValue Then
                Return Math.Round(m_ErreurGlobaleDEB.Value, 3)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurGlobaleDEB = Value
        End Set
    End Property
    Public Property DebitMesurePRS As Decimal?
        Get
            Return m_debitMesurePRS
        End Get
        Set(ByVal Value As Decimal?)
            m_debitMesurePRS = Value
            calcule()
        End Set
    End Property
    Public Property PressionMesurePRS As Decimal?
        Get
            Return m_PressionMesurePRS
        End Get
        Set(ByVal Value As Decimal?)
            m_PressionMesurePRS = Value
            calcule()
        End Set
    End Property
    Public Property PressionMoyennePRS As Decimal?
        Get
            Return m_PressionMoyennePRS
        End Get
        Set(ByVal Value As Decimal?)
            m_PressionMoyennePRS = Value
            calcule()
        End Set
    End Property
    Public Property DebitBuseProgrammePRS As Decimal?
        Get
            Return m_DebitBuseProgrammePRS
        End Get
        Set(ByVal Value As Decimal?)
            m_DebitBuseProgrammePRS = Value
            calcule()
        End Set
    End Property
    Public Property DebitReelPRS As Decimal?
        Get
            Return m_DebitReelPRS
        End Get
        Set(ByVal Value As Decimal?)
            m_DebitReelPRS = Value
        End Set
    End Property
    Public Property DebitReelPRSRND As Decimal?
        Get
            If m_DebitReelPRS.HasValue Then
                Return Math.Round(m_DebitReelPRS.Value, 3)
            Else
                Return Nothing
            End If

        End Get
        Set(ByVal Value As Decimal?)
            m_DebitReelPRS = Value
        End Set
    End Property
    Public Property ErreurDebitPRS As Decimal?
        Get
            Return m_ErreurDebitPRS
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurDebitPRS = Value
        End Set
    End Property
    Public Property ErreurDebitPRSRND As Decimal?
        Get
            If m_ErreurDebitPRS.HasValue Then
                Return Math.Round(m_ErreurDebitPRS.Value, 2)
            Else
                Return Nothing
            End If

        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurDebitPRS = Value
        End Set
    End Property
    Public Property ErreurVitessePRS As Decimal?
        Get
            Return m_ErreurVitessePRS
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurVitessePRS = Value
            calcule()
        End Set
    End Property
    Public Property ErreurGlobalePRS As Decimal?
        Get
            Return m_ErreurGlobalePRS
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurGlobalePRS = Value
        End Set
    End Property

    Public Property ErreurGlobalePRSRND As Decimal?
        Get
            If m_ErreurGlobalePRS.HasValue Then
                Return Math.Round(m_ErreurGlobalePRS.Value, 3)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurGlobalePRS = Value
        End Set
    End Property
    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            If oDiagItem.idItem = "help571" Then
                Try
                    bCalcule = False 'Au rechargement on désactive le calcul
                    Dim tabValues As String()
                    tabValues = oDiagItem.itemValue.Split("|")
                    erreurVitesseDEB = ConvertStringToAtt(tabValues(0))
                    erreurDebitDEB = ConvertStringToAtt(tabValues(1))
                    erreurGlobaleDEB = ConvertStringToAtt(tabValues(2))
                    DebitMesurePRS = ConvertStringToAtt(tabValues(3))
                    PressionMesurePRS = ConvertStringToAtt(tabValues(4))
                    PressionMoyennePRS = ConvertStringToAtt(tabValues(5))
                    DebitBuseProgrammePRS = ConvertStringToAtt(tabValues(6))
                    ErreurVitessePRS = ConvertStringToAtt(tabValues(7))
                    'On Stocke les Valeurs calculées en fin pour ne pas redéclencher le calculAutomatique
                    DebitReelPRS = ConvertStringToAtt(tabValues(8))
                    ErreurDebitPRS = ConvertStringToAtt(tabValues(9))
                    ErreurGlobalePRS = ConvertStringToAtt(tabValues(10))
                    Regulation = tabValues(11)
                    ResultPRS = tabValues(12)
                    ResultPRS = tabValues(12)
                    If tabValues.Length >= 14 Then
                        IsDPAE = tabValues(13)
                        IsDPAEDebit = tabValues(14)
                        IsDPAEPression = tabValues(15)
                    End If
                    bCalcule = True
                Catch ex As Exception
                    CSDebug.dispError("DiagnosticHelp571.load ERR conversion (" & oDiagItem.itemValue & ") ERR " & ex.Message)
                End Try
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp571.Load ERR: " & ex.Message)
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
            CSDebug.dispError("DiagnosticHelp571.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = "help571"

        oDiagItem.itemValue = ConvertAttToString(erreurVitesseDEB) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(erreurDebitDEB) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(erreurGlobaleDEB) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitMesurePRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(PressionMesurePRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(PressionMoyennePRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitBuseProgrammePRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(ErreurVitessePRS) & "|"
        'On Stocke les Valeurs calculées en fin pour ne pas redéclencher le calculAutomatique
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitReelPRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(ErreurDebitPRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(ErreurGlobalePRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & Trim(Regulation) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & Trim(ResultPRS) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & Trim(IsDPAE) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & Trim(IsDPAEDebit) & "|"
        oDiagItem.itemValue = oDiagItem.itemValue & Trim(IsDPAEPression) & "|"

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
            CSDebug.dispError("DiagnosticHelp571.Delete ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function hasValue() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Return bReturn

    End Function
    Public Function hasValueDebit() As Boolean
        Dim bReturn As Boolean
        bReturn = m_ResultDEB <> ""
        Return bReturn

    End Function
    Public Function hasValuePression() As Boolean
        Dim bReturn As Boolean
        bReturn = m_ResultPRS <> ""
        Return bReturn

    End Function


    Public Function calcule() As Boolean
        Dim bReturn As Boolean
        Try
            If bCalcule Then
                'Calcul Vitesse
                If m_debitMesurePRS.HasValue And m_PressionMesurePRS.HasValue And m_PressionMoyennePRS.HasValue And m_DebitBuseProgrammePRS.HasValue Then
                    m_DebitReelPRS = Math.Round(CDec(m_debitMesurePRS * Math.Sqrt(m_PressionMoyennePRS / m_PressionMesurePRS)), 3)
                    m_ErreurDebitPRS = ((m_DebitBuseProgrammePRS - m_DebitReelPRS) / m_DebitReelPRS) * 100
                Else
                    m_DebitReelPRS = Nothing
                    m_ErreurDebitPRS = Nothing

                End If
                If m_ErreurVitessePRS.HasValue And m_ErreurDebitPRS.HasValue Then
                    m_ErreurGlobalePRS = m_ErreurVitessePRS - m_ErreurDebitPRS
                Else
                    m_ErreurGlobalePRS = Nothing

                End If
                If m_ErreurGlobalePRS.HasValue And Not String.IsNullOrEmpty(Regulation) Then
                    m_ResultPRS = DiagnosticItem.EtatDiagItemOK
                    If IsDPAE Then
                        'On ne fait le calcul que pour les Pulve DPAE
                        m_ResultPRS = DiagnosticItem.EtatDiagItemOK
                        If VTSB1 <= Math.Abs(m_ErreurGlobalePRS.Value) And Math.Abs(m_ErreurGlobalePRS.Value) < VTSB2 Then
                            '5<=Erreur<10
                            m_ResultPRS = DiagnosticItem.EtatDiagItemMINEUR
                        End If
                        If VTSB2 <= Math.Abs(m_ErreurGlobalePRS.Value) Then
                            '10<=Erreur
                            m_ResultPRS = DiagnosticItem.EtatDiagItemMAJEUR
                        End If
                    End If
                Else
                    m_ResultPRS = String.Empty
                End If
                'Calcul Débit
                If m_ErreurDebitDEB.HasValue And m_ErreurVitesseDEB.HasValue Then
                    m_ErreurGlobaleDEB = m_ErreurVitesseDEB.Value - m_ErreurDebitDEB.Value
                Else
                    m_ErreurGlobaleDEB = Nothing
                End If
                If m_ErreurGlobaleDEB.HasValue Then
                    m_ResultDEB = DiagnosticItem.EtatDiagItemOK
                    'On ne fait le calcul que pour les Pulve DPAE
                    m_ResultDEB = DiagnosticItem.EtatDiagItemOK
                    If VTSB1 <= Math.Abs(m_ErreurGlobaleDEB.Value) And Math.Abs(m_ErreurGlobaleDEB.Value) < VTSB2 Then
                        '5<=Erreur<10
                        m_ResultDEB = DiagnosticItem.EtatDiagItemMINEUR
                    End If
                    If VTSB2 <= Math.Abs(m_ErreurGlobaleDEB.Value) Then
                        '10<=Erreur
                        m_ResultDEB = DiagnosticItem.EtatDiagItemMAJEUR
                    End If
                Else
                    m_ResultDEB = String.Empty
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp571.calcule ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class
