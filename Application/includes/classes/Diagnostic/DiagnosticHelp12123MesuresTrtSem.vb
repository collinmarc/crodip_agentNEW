Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
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

    Public Property numPompe() As Decimal
        Get
            Return m_numPompe
        End Get
        Set(ByVal value As Decimal)
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
        End Set
    End Property
    Private m_Pesee1 As Decimal
    Public Property Pesee1() As Decimal
        Get
            Return m_Pesee1
        End Get
        Set(ByVal value As Decimal)
            m_Pesee1 = value
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
    Public m_bCalcule As Boolean = True

    Public const DIAGITEM_ID As String = "help12123TrtSem"
    Public LIMITE_ECART_MAJEUR As Decimal = 5

    Public Sub New()
    End Sub
    Public Sub New(pPompe As DiagnosticHelp12123PompeTrtSem, pNumMesure As Integer)
        m_oPompe = pPompe
        m_numPompe = pPompe.numero
        m_numMesure = pNumMesure
    End Sub
    Private _image As Bitmap
    Public Property Image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal value As Bitmap)
            _image = value
        End Set
    End Property

    Public Function calcule() As Boolean
        Dim bReturn As Boolean
        Try
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
            Dim oCmd As OleDb.OleDbCommand

            oCmd = oCsDB.getConnection().CreateCommand()
            Dim strQuery As String
            strQuery = "Select * from DiagnosticItem where idDiagnostic = '" & idDiag & "' and idItem = '" & DIAGITEM_ID & pNumPompe & "-" & pNumMesure & "'"
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
                'DebitReel = ConvertStringToAtt(tabValues(2))  '4
                'DebitTotal = ConvertStringToAtt(tabValues(3))  '5
                bCalcule = True
            Catch ex As Exception
                CSDebug.dispError("DiagnosticHelp12123Mesure.load ERR conversion (" & pDiagItem.itemValue & ") ERR " & ex.Message)
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
        oDiagItem.itemValue = oDiagItem.itemValue & ConvertAttToString(m_numMesure) & "|" '0
        oDiagItem.itemValue = oDiagItem.itemValue & "|" '0
        oDiagItem.itemValue = oDiagItem.itemValue & "|" '1

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
