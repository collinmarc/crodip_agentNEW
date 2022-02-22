Imports System.Xml.Serialization
Imports System.Collections.Generic
'''
''' Classe de stockage des infos saisie de mesures pour l'item 551
<Serializable()> _
Public Class DiagnosticHelp552
    Implements ICloneable
    Protected m_id As String
    Protected m_idDiag As String
    Protected m_NbBuses_m1 As Decimal
    Protected m_NbBuses_m2 As Decimal
    Protected m_NbBuses_m3 As Decimal
    Protected m_Pression_m1 As Decimal
    Protected m_Pression_m2 As Decimal
    Protected m_Pression_m3 As Decimal
    Protected m_DebitEtalon_m1 As Decimal
    Protected m_DebitEtalon_m2 As Decimal
    Protected m_DebitEtalon_m3 As Decimal
    Protected m_DebitAfficheur_m1 As Decimal
    Protected m_DebitAfficheur_m2 As Decimal
    Protected m_DebitAfficheur_m3 As Decimal
    Protected m_EcartPct_m1 As Decimal
    Protected m_EcartPct_m2 As Decimal
    Protected m_EcartPct_m3 As Decimal
    Protected m_ErreurDebitMetre As Decimal
    Protected m_ErreurDebitMetreSigned As Decimal?
    Protected m_idItem As String
    Protected m_PressionMesure As Decimal
    Protected m_debitMoyen0bar As Decimal
    Protected m_resultat As String

    Public Sub New()

        m_idItem = "help552"
    End Sub

    Public Sub New(ByVal pId As String, ByVal pIdDiag As String)
        m_id = pId
        m_idDiag = pIdDiag
        m_idItem = "help552"
    End Sub
    Public Property iditem As String
        Get
            Return m_idItem
        End Get
        Set(ByVal Value As String)
            'm_idItem = Value
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
    Public Property NbBuses_m1 As Decimal
        Get
            Return m_NbBuses_m1
        End Get
        Set(ByVal Value As Decimal)
            m_NbBuses_m1 = Value
        End Set
    End Property
    Public Property Pression_m1 As Decimal
        Get
            Return m_Pression_m1
        End Get
        Set(ByVal Value As Decimal)
            m_Pression_m1 = Value
        End Set
    End Property
    Public Property DebitEtalon_m1 As Decimal
        Get
            Return m_DebitEtalon_m1
        End Get
        Set(ByVal Value As Decimal)
            m_DebitEtalon_m1 = Value
        End Set
    End Property

    Public Property DebitAfficheur_m1 As Decimal
        Get
            Return m_DebitAfficheur_m1
        End Get
        Set(ByVal Value As Decimal)
            m_DebitAfficheur_m1 = Value
        End Set
    End Property

    Public Property EcartPct_m1 As Decimal
        Get
            Return m_EcartPct_m1
        End Get
        Set(ByVal Value As Decimal)
            m_EcartPct_m1 = Value
        End Set
    End Property

    Public Property NbBuses_m2 As Decimal
        Get
            Return m_NbBuses_m2
        End Get
        Set(ByVal Value As Decimal)
            m_NbBuses_m2 = Value
        End Set
    End Property
    Public Property Pression_m2 As Decimal
        Get
            Return m_Pression_m2
        End Get
        Set(ByVal Value As Decimal)
            m_Pression_m2 = Value
        End Set
    End Property
    Public Property DebitEtalon_m2 As Decimal
        Get
            Return m_DebitEtalon_m2
        End Get
        Set(ByVal Value As Decimal)
            m_DebitEtalon_m2 = Value
        End Set
    End Property

    Public Property DebitAfficheur_m2 As Decimal
        Get
            Return m_DebitAfficheur_m2
        End Get
        Set(ByVal Value As Decimal)
            m_DebitAfficheur_m2 = Value
        End Set
    End Property
    Public Property EcartPct_m2 As Decimal
        Get
            Return m_EcartPct_m2
        End Get
        Set(ByVal Value As Decimal)
            m_EcartPct_m2 = Value
        End Set
    End Property
    Public Property NbBuses_m3 As Decimal
        Get
            Return m_NbBuses_m3
        End Get
        Set(ByVal Value As Decimal)
            m_NbBuses_m3 = Value
        End Set
    End Property
    Public Property Pression_m3 As Decimal
        Get
            Return m_Pression_m3
        End Get
        Set(ByVal Value As Decimal)
            m_Pression_m3 = Value
        End Set
    End Property
    Public Property DebitEtalon_m3 As Decimal
        Get
            Return m_DebitEtalon_m3
        End Get
        Set(ByVal Value As Decimal)
            m_DebitEtalon_m3 = Value
        End Set
    End Property

    Public Property DebitAfficheur_m3 As Decimal
        Get
            Return m_DebitAfficheur_m3
        End Get
        Set(ByVal Value As Decimal)
            m_DebitAfficheur_m3 = Value
        End Set
    End Property
    Public Property EcartPct_m3 As Decimal
        Get
            Return m_EcartPct_m3
        End Get
        Set(ByVal Value As Decimal)
            m_EcartPct_m3 = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property ErreurDebitMetre As Decimal
        Get
            Return m_ErreurDebitMetre
        End Get
        Set(ByVal Value As Decimal)
            m_ErreurDebitMetre = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property ErreurDebitMetreSigned As Decimal?
        Get
            Return m_ErreurDebitMetreSigned
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurDebitMetreSigned = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property PressionMesure As Decimal
        Get
            Return m_PressionMesure
        End Get
        Set(ByVal Value As Decimal)
            m_PressionMesure = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property DebitMoyen0Bar As Decimal
        Get
            Return m_debitMoyen0bar
        End Get
        Set(ByVal Value As Decimal)
            m_debitMoyen0bar = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Resultat As String
        Get
            Return m_resultat
        End Get
        Set(ByVal Value As String)
            m_resultat = Value
        End Set
    End Property
    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            If oDiagItem.idItem = m_idItem Then
                Dim strValue As String()
                strValue = oDiagItem.itemValue.Split("|")
                Try
                    NbBuses_m1 = CDec(strValue(0))
                    Pression_m1 = CDec(strValue(1))
                    DebitEtalon_m1 = CDec(strValue(2))
                    DebitAfficheur_m1 = CDec(strValue(3))
                    NbBuses_m2 = CDec(strValue(4))
                    Pression_m2 = CDec(strValue(5))
                    DebitEtalon_m2 = CDec(strValue(6))
                    DebitAfficheur_m2 = CDec(strValue(7))
                    NbBuses_m3 = CDec(strValue(8))
                    Pression_m3 = CDec(strValue(9))
                    DebitEtalon_m3 = CDec(strValue(10))
                    DebitAfficheur_m3 = CDec(strValue(11))
                Catch ex As Exception
                    CSDebug.dispError("DiagnosticHelp552.load ERR conversion (" & oDiagItem.itemValue & ") ERR " & ex.Message)
                End Try
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp552.Load ERR: " & ex.Message)
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
            id = oDiagItem.id
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
        oDiagItem.idItem = m_idItem
        oDiagItem.itemValue = NbBuses_m1 & "|" & Pression_m1 & "|" & DebitEtalon_m1 & "|" & DebitAfficheur_m1 & "|" & NbBuses_m2 & "|" & Pression_m2 & "|" & DebitEtalon_m2 & "|" & DebitAfficheur_m2 & "|" & NbBuses_m3 & "|" & Pression_m3 & "|" & DebitEtalon_m3 & "|" & DebitAfficheur_m3
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
        If NbBuses_m1 + NbBuses_m2 + NbBuses_m3 > 0 Then
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn

    End Function

    Public Function calc() As Boolean
        Dim bReturn As Boolean
        Dim tmpnbBuses As Double = 0
        Dim tmppression As Double = 0
        Dim tmpdebitEtalon As Double = 0
        Dim tmpdebitAfficheur As Double = 0
        Dim tmp_ecart As Double = 0
        Dim tmpErreurDebimetre As Double = 0
        Try
            bReturn = True
            ' Ecart M1
            EcartPct_m1 = 0D
            If DebitAfficheur_m1 <> 0 Then
                ' Récupération des données
                tmpnbBuses = NbBuses_m1
                tmppression = Pression_m1
                tmpdebitAfficheur = DebitAfficheur_m1
                ' Calcul Ecart
                tmpdebitEtalon = DebitEtalon_m1
                EcartPct_m1 = calcEcart(tmpdebitEtalon, tmpdebitAfficheur, tmpnbBuses, tmppression)
            End If
            ' Ecart M2
            EcartPct_m2 = 0D
            If DebitAfficheur_m2 <> 0 Then
                ' Récupération des données
                tmpnbBuses = NbBuses_m2
                tmppression = Pression_m2
                tmpdebitAfficheur = DebitAfficheur_m2
                ' Calcul Ecart
                tmpdebitEtalon = DebitEtalon_m2
                EcartPct_m2 = calcEcart(tmpdebitEtalon, tmpdebitAfficheur, tmpnbBuses, tmppression)
            End If
            ' Ecart m3
            EcartPct_m3 = 0D
            If DebitAfficheur_m3 <> 0 Then
                ' Récupération des données
                tmpnbBuses = NbBuses_m3
                tmppression = Pression_m3
                tmpdebitAfficheur = DebitAfficheur_m3
                ' Calcul Ecart
                tmpdebitEtalon = DebitEtalon_m3
                EcartPct_m3 = calcEcart(tmpdebitEtalon, tmpdebitAfficheur, tmpnbBuses, tmppression)
            End If

            CalcErreurDebitMetre()
            ' Résultat
            If ErreurDebitMetre > 5 And Math.Abs(EcartPct_m3) > 5 Then
                Resultat = "IMPRECISION"
            Else
                Resultat = "OK"
            End If


        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp552.Calc err" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
        Friend Sub CalcErreurDebitMetre()

        ' Erreur Débitmètre (%)
        ErreurDebitMetre = Nothing
        'Débit mètre = 3 chiffre après la virgule
        ErreurDebitMetre = Math.Abs(Math.Round((Math.Abs(EcartPct_m1) + Math.Abs(EcartPct_m2) + Math.Abs(EcartPct_m3)) / 3, 3))
        ErreurDebitMetreSigned = Math.Round((EcartPct_m1 + EcartPct_m2 + EcartPct_m3) / 3, 3)
        CSDebug.dispInfo("DiagHelp552.CalcErreurDebitMetre: ErreurDebitMetre=" & ErreurDebitMetre & " ,ErreurDebitMetreSigned =" & ErreurDebitMetreSigned)
    End Sub

    Private Function calcEcart(ByVal pDebitEtalon As Decimal, ByVal pDebitAfficheur As Decimal, ByVal pNbBuses As Decimal, ByVal pPression As Decimal) As Decimal
        Dim tmp_ecart As Decimal
        Dim tmp_DebReel As Decimal
        ' Calcul Ecart
        'If pDebitEtalon <> 0 Then
        'tmp_ecart = Math.Round(100 * (pDebitAfficheur - pDebitEtalon) / pDebitEtalon, 2)
        'Else
        If (pNbBuses * DebitMoyen0Bar * pPression) <> 0 Then
            tmp_DebReel = DebitMoyen0Bar * Math.Sqrt(pPression / 3) * pNbBuses
            'tmp_DebReel = Math.Round(tmp_DebReel, 2)

            'tmp_ecart = Math.Round(100 * (pDebitAfficheur - (pNbBuses * DebitMoyen0Bar * (pPression ^ 0.5 / PressionMesure ^ 0.5))) / (pNbBuses * DebitMoyen0Bar * (pPression ^ 0.5 / PressionMesure ^ 0.5)), 2)
            tmp_ecart = 100 * (pDebitAfficheur - tmp_DebReel) / tmp_DebReel
            tmp_ecart = Math.Round(tmp_ecart, 3)
            'End If
        End If

        Return tmp_ecart
    End Function

    'Private Function calcEcartOLD(ByVal tmpdebitEtalon As Decimal, ByVal tmpdebitAfficheur As Decimal, ByVal tmpnbBuses As Decimal, ByVal tmppression As Decimal) As Decimal
    '    Dim tmp_ecart As Decimal
    '    ' Calcul Ecart
    '    If tmpdebitEtalon <> 0 Then
    '        tmp_ecart = Math.Round(100 * (tmpdebitAfficheur - tmpdebitEtalon) / tmpdebitEtalon, 2)
    '    Else
    '        If PressionMesure <> 0 And (tmpnbBuses * DebitMoyen0Bar * tmppression) <> 0 Then
    '            tmp_ecart = Math.Round(100 * (tmpdebitAfficheur - (tmpnbBuses * DebitMoyen0Bar * (tmppression ^ 0.5 / PressionMesure ^ 0.5))) / (tmpnbBuses * DebitMoyen0Bar * (tmppression ^ 0.5 / PressionMesure ^ 0.5)), 2)

    '            Return Math.Abs(tmp_ecart)
    'End Function

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As DiagnosticHelp552

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
            CSDebug.dispError("Diagnostichelp552.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
End Class
