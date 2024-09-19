Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Data.Common
'''
''' Classe de stockage des infos saisie de mesures pour l'item 12123
''' Voir fichier Calcul12123
<Serializable()>
Public Class DiagnosticHelp12123MesuresTrtSem
    '    Implements ICloneable
    Public m_id As String
    Public m_idDiag As String
    Private m_oPompe As DiagnosticHelp12123PompeTrtSem
    Private m_numPompe As Integer
    Private m_numMesure As Integer

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

    Public Property numPompe() As Integer
        Get
            Return m_numPompe
        End Get
        Set(ByVal value As Integer)
            m_numPompe = value
        End Set
    End Property
    Public Property numMesure() As Integer
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
    Private m_QteGrains As Decimal
    Public Property qteGrains() As Decimal
        Get
            Return m_QteGrains
        End Get
        Set(ByVal value As Decimal)
            m_QteGrains = value
        End Set
    End Property

    Private m_DebitSouhaitee As Decimal
    Public Property DebitSouhaite() As Decimal
        Get
            Return m_DebitSouhaitee
        End Get
        Set(ByVal value As Decimal)
            m_DebitSouhaitee = value
            calcule()
        End Set
    End Property
    Private m_Pesee1 As Decimal
    Public Property Pesee1() As Decimal
        Get
            Return m_Pesee1
        End Get
        Set(ByVal value As Decimal)
            m_Pesee1 = value
            calcule()
        End Set
    End Property
    Private m_Ecart1 As Decimal
    Public Property Ecart1() As Decimal
        Get
            Return m_Ecart1
        End Get
        Set(ByVal value As Decimal)
            m_Ecart1 = value
        End Set
    End Property
    Private m_Pesee2 As Decimal
    Public Property Pesee2() As Decimal
        Get
            Return m_Pesee2
        End Get
        Set(ByVal value As Decimal)
            m_Pesee2 = value
            calcule()
        End Set
    End Property
    Private m_Ecart2 As Decimal
    Public Property Ecart2() As Decimal
        Get
            Return m_Ecart2
        End Get
        Set(ByVal value As Decimal)
            m_Ecart2 = value
        End Set
    End Property
    Private m_Pesee3 As Decimal
    Public Property Pesee3() As Decimal
        Get
            Return m_Pesee3
        End Get
        Set(ByVal value As Decimal)
            m_Pesee3 = value
            calcule()
        End Set
    End Property
    Private m_Ecart3 As Decimal
    Public Property Ecart3() As Decimal
        Get
            Return m_Ecart3
        End Get
        Set(ByVal value As Decimal)
            m_Ecart3 = value
        End Set
    End Property
    Private m_PeseeMoyenne As Decimal
    Public Property PeseeMoyenne() As Decimal
        Get
            Return m_PeseeMoyenne
        End Get
        Set(ByVal value As Decimal)
            m_PeseeMoyenne = value
        End Set
    End Property
    Private m_EcartMoyen As Decimal
    Public Property EcartMoyen() As Decimal
        Get
            Return m_EcartMoyen
        End Get
        Set(ByVal value As Decimal)
            m_EcartMoyen = value
        End Set
    End Property
    Private m_Resultat As String
    Public Property Resultat() As String
        Get
            Return m_Resultat
        End Get
        Set(ByVal value As String)
            m_Resultat = value
        End Set
    End Property
    <XmlIgnore>
    Public ReadOnly Property ResultatLabel() As String
        Get
            Select Case Resultat
                Case DiagnosticItem.EtatDiagItemOK
                    Return "OK"
                Case DiagnosticItem.EtatDiagItemMAJEUR
                    Return "ERREUR"
                Case Else
                    Return ""
            End Select

        End Get
    End Property

    Public m_bCalcule As Boolean = True

    Public Const DIAGITEM_ID As String = "HTS-M"
    Public LIMITE_ECART_MAJEUR As Decimal = 5

    Public Sub New()
    End Sub
    Public Sub New(pPompe As DiagnosticHelp12123PompeTrtSem, pNumMesure As Integer)
        m_oPompe = pPompe
        m_numPompe = pPompe.numero
        m_numMesure = pNumMesure
    End Sub
    '<XmlIgnore>
    'Public Property Image() As Bitmap
    '    Get
    '        If Resultat = DiagnosticItem.EtatDiagItemOK Then
    '            Return Resources.PuceVerteT
    '        Else
    '            If Resultat = DiagnosticItem.EtatDiagItemMAJEUR Then
    '                Return Resources.PuceRougeT
    '            Else
    '                Return Resources.PuceGriseT
    '            End If
    '        End If
    '    End Get
    '    Set(ByVal value As Bitmap)
    '        '            _image = value
    '    End Set
    'End Property

    Public Function calcule() As Boolean
        Dim bReturn As Boolean
        Try
            If DebitSouhaite <> 0 Then
                If Pesee1 <> 0 Then
                    Ecart1 = Math.Round(((Pesee1 - DebitSouhaite) / DebitSouhaite) * 100, 3)
                End If
                If Pesee2 <> 0 Then
                    Ecart2 = Math.Round(((Pesee2 - DebitSouhaite) / DebitSouhaite) * 100, 3)
                End If
                If Pesee3 <> 0 Then
                    Ecart3 = Math.Round(((Pesee3 - DebitSouhaite) / DebitSouhaite) * 100, 3)
                End If
                If Pesee1 <> 0 And Pesee2 <> 0 And Pesee3 <> 0 Then
                    PeseeMoyenne = Math.Round(((Pesee1 + Pesee2 + Pesee3) / 3), 3)
                    EcartMoyen = Math.Round(((PeseeMoyenne - DebitSouhaite) / DebitSouhaite) * 100, 3)
                    'EcartReglage > 5% => Majeur, sinon OK
                    Resultat = DiagnosticItem.EtatDiagItemOK
                    If Math.Abs(EcartMoyen) > LIMITE_ECART_MAJEUR Then
                        Resultat = DiagnosticItem.EtatDiagItemMAJEUR
                    End If
                Else
                    PeseeMoyenne = 0
                    EcartMoyen = 0
                    Resultat = ""
                End If
                If Resultat <> "" Then
                    m_oPompe.calcule()
                End If

            End If
            bReturn = True
        Catch ex As Exception
            bReturn = False
            CSDebug.dispError("DiagnosticHelp12123MesureTrtSem ERR : " & ex.Message)


        End Try
        Return bReturn
    End Function

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
                qteGrains = ConvertStringToAtt(tabValues(2))
                DebitSouhaite = ConvertStringToAtt(tabValues(3))
                Pesee1 = ConvertStringToAtt(tabValues(4))
                Ecart1 = ConvertStringToAtt(tabValues(5))
                Pesee2 = ConvertStringToAtt(tabValues(6))
                Ecart2 = ConvertStringToAtt(tabValues(7))
                Pesee3 = ConvertStringToAtt(tabValues(8))
                Ecart3 = ConvertStringToAtt(tabValues(9))
                PeseeMoyenne = ConvertStringToAtt(tabValues(10))
                EcartMoyen = ConvertStringToAtt(tabValues(11))
                Resultat = tabValues(12)
                bCalcule = True
            Catch ex As Exception
                CSDebug.dispError("DiagnosticHelp12123MesureTrtSem.load ERR conversion (" & pDiagItem.itemValue & ") ERR " & ex.Message)
            End Try
        End If

    End Sub
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = DIAGITEM_ID & m_numPompe & "-" & m_numMesure

        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(m_numPompe) & "|" '0
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(m_numMesure) & "|" '1
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(qteGrains) & "|" '2
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(DebitSouhaite) & "|" '2
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(Pesee1) & "|" '3
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(Ecart1) & "|" '4
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(Pesee2) & "|" '5
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(Ecart2) & "|" '6
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(Pesee3) & "|" '7
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(Ecart3) & "|" '8
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(PeseeMoyenne) & "|" '9
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(EcartMoyen) & "|" '10
        oDiagItem.itemValue = oDiagItem.itemValue & Resultat & "|" '11

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


End Class
