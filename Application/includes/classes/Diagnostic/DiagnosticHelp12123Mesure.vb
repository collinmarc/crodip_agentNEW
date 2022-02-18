Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Data.Common
'''
<Serializable()> _
Public Class DiagnosticHelp12123Mesure
    Implements ICloneable
    Private m_id As String
    Private m_idDiag As String
    Private m_oPompe As DiagnosticHelp12123Pompe
    Private m_numPompe As Integer
    Private m_numMesure As Integer
    '    Private m_DebitReel? As Decimal = Nothing
    '    Private m_DebitTotal? As Decimal = Nothing
    Private m_ReglageDispositif? As Decimal = Nothing
    Private m_DebitTheorique? As Decimal = Nothing
    Private m_TempsMesure? As Decimal = Nothing
    Private m_QteEauPulverisee? As Decimal = Nothing
    Private m_MasseInitiale? As Decimal = Nothing
    Private m_MasseAspire? As Decimal = Nothing
    Private m_QteProduitConso? As Decimal = Nothing
    Private m_DosageReel? As Decimal = Nothing
    Private m_EcartReglage? As Decimal = Nothing
    Private m_Resultat As String
    Private m_bCalcule As Boolean = True

    Public Const DIAGITEM_ID As String = "H12123M"
    Public LIMITE_ECART_MAJEUR As Decimal = 5

    Public Sub New()
    End Sub
    Public Sub New(pPompe As DiagnosticHelp12123Pompe, pNumMesure As Integer)
        m_oPompe = pPompe
        m_numPompe = pPompe.numero
        m_numMesure = pNumMesure
    End Sub
    <XmlIgnore>
    Public Property Image() As Bitmap
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
        Set(ByVal value As Bitmap)
            '            _image = value
        End Set
    End Property


    Public Property numeroPompe() As Integer
        Get
            Return m_numPompe
        End Get
        Set(ByVal value As Integer)
            m_numPompe = value
        End Set
    End Property
    Public Property numeroMesure() As Integer
        Get
            Return m_numMesure
        End Get
        Set(ByVal value As Integer)
            m_numMesure = value
        End Set
    End Property

    Public ReadOnly Property numeroMesurestr() As String
        Get
            Return "Mesure " & m_numMesure
        End Get
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
    'Public Property debitMesure As Decimal?
    '    Get
    '        Return m_debitMesure
    '    End Get
    '    Set(value As Decimal?)
    '        m_debitMesure = value
    '        calcule()
    '    End Set
    'End Property
    'Public Property PressionMesure As Decimal?
    '    Get
    '        Return m_PressionMesure
    '    End Get
    '    Set(value As Decimal?)
    '        m_PressionMesure = value
    '        calcule()
    '    End Set
    'End Property
    'Public Property PressionMoyenne As Decimal?
    '    Get
    '        Return m_PressionMoyenne
    '    End Get
    '    Set(value As Decimal?)
    '        m_PressionMoyenne = value
    '        calcule()
    '    End Set
    'End Property
    'Public Property NbBuses As Decimal?
    '    Get
    '        Return m_NbBuses
    '    End Get
    '    Set(value As Decimal?)
    '        m_NbBuses = value
    '        calcule()

    '    End Set
    'End Property
    Public ReadOnly Property DebitReel As Decimal?
        Get
            Return m_oPompe.DebitReel
        End Get
    End Property
    Public ReadOnly Property DebitReelRND As Decimal?
        Get
            Return m_oPompe.DebitReelRND
        End Get
    End Property
    Public ReadOnly Property DebitTotal As Decimal?
        Get
            Return m_oPompe.DebitTotal
        End Get
    End Property
    Public ReadOnly Property DebitTotalRND As Decimal?
        Get
            Return m_oPompe.DebitTotalRND
        End Get
    End Property
    Public Property ReglageDispositif As Decimal?
        Get
            Return m_ReglageDispositif
        End Get
        Set(value As Decimal?)
            m_ReglageDispositif = value
            calcule()
        End Set
    End Property
    Public Property DebitTheorique As Decimal?
        Get
            Return m_DebitTheorique
        End Get
        Set(value As Decimal?)
            m_DebitTheorique = value
        End Set
    End Property
    Public Property DebitTheoriqueRND As Decimal?
        Get
            If m_DebitTheorique.HasValue Then
                Return Math.Round(m_DebitTheorique.Value, 3)
            Else
                Return Nothing
            End If
        End Get
        Set(value As Decimal?)
            m_DebitTheorique = value
        End Set
    End Property
    Public Property TempsMesure As Decimal?
        Get
            Return m_TempsMesure
        End Get
        Set(value As Decimal?)
            m_TempsMesure = value
            calcule()
        End Set
    End Property
    Public Property QteEauPulverisee As Decimal?
        Get
            Return m_QteEauPulverisee
        End Get
        Set(value As Decimal?)
            m_QteEauPulverisee = value
        End Set
    End Property
    Public Property QteEauPulveriseeRND As Decimal?
        Get
            If m_QteEauPulverisee.HasValue Then
                Return Math.Round(m_QteEauPulverisee.Value, 2)
            Else
                Return Nothing
            End If
        End Get
        Set(value As Decimal?)
            m_QteEauPulverisee = value
        End Set
    End Property
    Public Property MasseInitiale As Decimal?
        Get
            Return m_MasseInitiale
        End Get
        Set(value As Decimal?)
            m_MasseInitiale = value
            calcule()
        End Set
    End Property
    Public Property MasseAspire As Decimal?
        Get
            Return m_MasseAspire
        End Get
        Set(value As Decimal?)
            m_MasseAspire = value
            calcule()
        End Set
    End Property
    Public Property QteProduitConso As Decimal?
        Get
            Return m_QteProduitConso
        End Get
        Set(value As Decimal?)
            m_QteProduitConso = value
        End Set
    End Property
    Public Property DosageReel As Decimal?
        Get
            Return m_DosageReel
        End Get
        Set(value As Decimal?)
            m_DosageReel = value
        End Set
    End Property
    Public Property DosageReelRND As Decimal?
        Get
            If m_DosageReel.HasValue Then
                Return Math.Round(m_DosageReel.Value, 3)
            Else
                Return Nothing
            End If
        End Get
        Set(value As Decimal?)
            m_DosageReel = value
        End Set
    End Property
    Public Property EcartReglage As Decimal?
        Get
            Return m_EcartReglage
        End Get
        Set(value As Decimal?)
            m_EcartReglage = value
        End Set
    End Property
    Public Property EcartReglageRND As Decimal?
        Get
            If m_EcartReglage.HasValue Then
                Return Math.Round(m_EcartReglage.Value, 2)
            Else
                Return Nothing
            End If
        End Get
        Set(value As Decimal?)
            m_EcartReglage = value
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
    Public Function Load(pid As String, pidDiag As String) As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(pid), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pidDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(pid, pidDiag)
            getDatasFromItemValue(oDiagItem)
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123Mesure.Load ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Sub getDatasFromItemValue(pDiagItem As DiagnosticItem)

        If pDiagItem.idItem.StartsWith(DIAGITEM_ID) Then
            Try
                bCalcule = False 'Au rechargement on désactive le calcul
                id = pDiagItem.id
                idDiag = pDiagItem.idDiagnostic
                Dim tabValues As String()
                tabValues = pDiagItem.itemValue.Split("|")
                m_numPompe = ConvertStringToAtt(tabValues(0))
                m_numMesure = ConvertStringToAtt(tabValues(1))
                'DebitReel = ConvertStringToAtt(tabValues(2))  '4
                'DebitTotal = ConvertStringToAtt(tabValues(3))  '5
                ReglageDispositif = ConvertStringToAtt(tabValues(4))  '6
                DebitTheorique = ConvertStringToAtt(tabValues(5))  '7
                TempsMesure = ConvertStringToAtt(tabValues(6))  '8
                QteEauPulverisee = ConvertStringToAtt(tabValues(7))  '9
                MasseInitiale = ConvertStringToAtt(tabValues(8))  '10
                MasseAspire = ConvertStringToAtt(tabValues(9))  '11
                QteProduitConso = ConvertStringToAtt(tabValues(10))  '12
                DosageReel = ConvertStringToAtt(tabValues(11))  '13
                EcartReglage = ConvertStringToAtt(tabValues(12))  '14
                Me.Resultat = Trim(tabValues(13))  '15
                bCalcule = True
            Catch ex As Exception
                CSDebug.dispError("DiagnosticHelp12123Mesure.load ERR conversion (" & pDiagItem.itemValue & ") ERR " & ex.Message)
            End Try
        End If

    End Sub
    Public Function Load(pidDiag As String, pNumPompe As Integer, pNumMesure As Integer) As Boolean
        Dim bReturn As Boolean
        Try
            Dim oCsDB As New CSDb(True)
            Dim oCmd As DbCommand

            oCmd = oCsDB.getConnection().CreateCommand()
            Dim strQuery As String
            strQuery = "Select * from DiagnosticItem where idDiagnostic = '" & idDiag & "' and idItem = '" & DIAGITEM_ID & pNumPompe & "-" & pNumMesure & "'"
            oCmd.CommandText = strQuery
            Dim oDr As DbDataReader
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
            CSDebug.dispError("DiagnocticHelp12123:load(" & pidDiag & "," & pNumPompe & "," & pNumMesure & " ) ERROR" & ex.Message)
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
            CSDebug.dispError("DiagnosticHelp12123Mesure.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = DIAGITEM_ID & m_numPompe & "-" & m_numMesure

        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(m_numPompe) & "|" '0
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(m_numMesure) & "|" '0
        oDiagItem.itemValue = oDiagItem.itemValue & "|" '0
        oDiagItem.itemValue = oDiagItem.itemValue & "|" '1
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(ReglageDispositif) & "|" '2
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitTheorique) & "|" '3
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(TempsMesure) & "|" '4
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(QteEauPulverisee) & "|" '5
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(MasseInitiale) & "|" '6
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(MasseAspire) & "|" '7
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(QteProduitConso) & "|" '8
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DosageReel) & "|" '9
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(EcartReglage) & "|" '10
        oDiagItem.itemValue = oDiagItem.itemValue & Trim(Me.Resultat) & "|" '11

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
            If bCalcule Then
                m_bCalcule = False
                DebitTheorique = Nothing
                If ReglageDispositif.HasValue And m_oPompe.NbBuses.HasValue And m_oPompe.debitMesure.HasValue Then
                    DebitTheorique = (ReglageDispositif / 100) * (m_oPompe.debitMesure * m_oPompe.NbBuses)
                End If
                QteEauPulverisee = Nothing
                If m_TempsMesure.HasValue And DebitTotal.HasValue Then
                    QteEauPulverisee = TempsMesure * (DebitTotal / 60)
                End If
                QteProduitConso = Nothing
                If m_MasseInitiale.HasValue And m_MasseAspire.HasValue Then
                    'QteProduitConso = MasseInitiale-MasseFinal
                    '                    QteProduitConso = MasseInitiale - MasseFinale
                    QteProduitConso = MasseInitiale - MasseAspire

                End If
                DosageReel = Nothing
                If m_QteProduitConso.HasValue And m_QteEauPulverisee.HasValue Then
                    'DosageReel = QteProduitConso en kg / qteEauPulverisee
                    DosageReel = (QteProduitConso / QteEauPulverisee) * 100
                End If

                If m_ReglageDispositif.HasValue And m_DosageReel.HasValue Then
                    'EcartDeReglage = (ReglageDispositif-DosageReel)/DosageReel)*100
                    EcartReglage = ((DosageReel - ReglageDispositif) / ReglageDispositif) * 100
                Else
                    EcartReglage = Nothing

                End If
                If m_EcartReglage.HasValue Then
                    'EcartReglage > 5% => Majeur, sinon OK
                    Resultat = DiagnosticItem.EtatDiagItemOK
                    If Math.Abs(EcartReglage.Value) > LIMITE_ECART_MAJEUR Then
                        Resultat = DiagnosticItem.EtatDiagItemMAJEUR
                    End If
                Else
                    Resultat = String.Empty

                End If
                'Recalcule du Resultat de la pompe si on a un résultat
                If Resultat IsNot String.Empty Then
                    m_oPompe.calcule()
                End If
                m_bCalcule = True
            End If
            bReturn = True
        Catch ex As Exception
            bReturn = False
            CSDebug.dispError("DiagnosticHelp12123 ERR : " & ex.Message)


        End Try
        Return bReturn
    End Function

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As DiagnosticHelp12123Mesure

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
            CSDebug.dispError("Diagnostic12123Mesure.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function


End Class
