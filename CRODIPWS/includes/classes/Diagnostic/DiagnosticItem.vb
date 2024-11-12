Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Linq


<Serializable(), XmlInclude(GetType(DiagnosticItem))>
Public Class DiagnosticItemList

    Private _Dic_diagnosticItem As Dictionary(Of String, DiagnosticItem)

    Sub New()
        _Dic_diagnosticItem = New Dictionary(Of String, DiagnosticItem)
    End Sub
    <XmlElement("DiagnosticItems")>
    Public Property items() As Object()
        Get
            Dim olst As New List(Of DiagnosticItem)
            olst.AddRange(_Dic_diagnosticItem.Values)
            Return olst.ToArray()
        End Get
        Set(ByVal Value As Object())
            For Each oItem As DiagnosticItem In Value
                AddOrReplace(oItem)
            Next
        End Set
    End Property
    <XmlIgnore()>
    Public Property Liste() As List(Of DiagnosticItem)
        Get
            Dim olst As New List(Of DiagnosticItem)
            olst.AddRange(_Dic_diagnosticItem.Values)
            Return olst
        End Get
        Set(ByVal Value As List(Of DiagnosticItem))
            For Each oItem As DiagnosticItem In Value
                AddOrReplace(oItem)
            Next
        End Set
    End Property
    Public Sub AddOrReplace(ByVal pDiagItem As DiagnosticItem)
        Dim key As String = pDiagItem.getItemCode()
        If _Dic_diagnosticItem.ContainsKey(key) Then
            _Dic_diagnosticItem(key) = pDiagItem
        Else
            _Dic_diagnosticItem.Add(key, pDiagItem)
        End If
    End Sub
    Public Function getItem(sKey As String) As DiagnosticItem
        Dim oReturn As DiagnosticItem
        Try
            oReturn = _Dic_diagnosticItem(sKey)
        Catch ex As Exception
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
    ''' <summary>
    ''' Renvoie Vrai si la clé est incluse dans le dictionnaire
    ''' </summary>
    ''' <param name="pKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function ContainsKey(pKey As String) As Boolean
        Return _Dic_diagnosticItem.ContainsKey(pKey)
    End Function
    ''' <summary>
    ''' Supprime l'élement si la clé existe, renbd Vrai si la suppression a fonctionné , False sinon
    ''' </summary>
    ''' <param name="pKey"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Remove(pDiagItem As DiagnosticItem) As Boolean
        Dim bReturn As Boolean = False
        If _Dic_diagnosticItem.ContainsKey(pDiagItem.getItemCode()) Then
            _Dic_diagnosticItem.Remove(pDiagItem.getItemCode())
            bReturn = True
        End If
        Return bReturn
    End Function
    Public Function Count() As Integer
        Return _Dic_diagnosticItem.Count
    End Function
    Public Sub Clear()
        _Dic_diagnosticItem.Clear()
    End Sub
End Class
<Serializable(), XmlType(TypeName:="DiagnosticItems")>
Public Class DiagnosticItem
    Inherits root

    Private _id As String
    Private _idDiagnostic As String
    Private _idItem As String
    Private _itemValue As String
    Private _itemCodeEtat As String
    Private _isItemCode1 As Boolean
    Private _isItemCode2 As Boolean
    Private _cause As String
    Private _dateModificationCrodip As String
    Private _dateModificationAgent As String
    Private _libelleCourt As String
    Private _libelleLong As String

    Public Const EtatDiagItemOK As String = "B"
    Public Const EtatDiagItemMINEUR As String = "O"
    Public Const EtatDiagItemMAJEUR As String = "P"
    Public Const EtatDiagItemMAJPRELIM As String = "X"
    Public Const EtatDiagItemABSENCE As String = "A"




    Sub New()
        Me.id = ""
        dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString
        dateModificationCrodip = CSDate.ToCRODIPString(DateTime.MinValue).ToString
        Me.cause = ""
    End Sub
    Public Sub New(ByVal idDiagnostic As String, ByVal pItem As String, ByVal pValue As String, Optional ByVal pCause As String = "", Optional ByVal pCodeEtat As String = "")
        Me.New()
        Me.idDiagnostic = idDiagnostic
        Me.idItem = pItem
        Me.itemValue = pValue
        Me.cause = pCause
        Me.itemCodeEtat = pCodeEtat

    End Sub
    ''' <summary>
    ''' création d"un diagItem à partir du controle de saisie
    ''' </summary>
    ''' <param name="pCtrl"></param>
    Public Sub New(pCtrl As CRODIP_ControlLibrary.CtrlDiag2)
        Me.New()
        Dim answ_GroupeId As String
        Dim answ_titleId As String
        Dim answ_groupBoxId As String
        Dim answ_itemId As String
        Dim strItemCode As String = pCtrl.Code.Replace(".", "")
        If (strItemCode.StartsWith("10") Or strItemCode.StartsWith("11") Or strItemCode.StartsWith("12")) And strItemCode.Length() > 4 Then
            answ_GroupeId = strItemCode.Substring(0, 2)
            answ_titleId = strItemCode.Substring(2, 1)
            answ_groupBoxId = strItemCode.Substring(3, 1)
            answ_itemId = strItemCode.Substring(4)
        Else
            answ_GroupeId = strItemCode.Substring(0, 1)
            answ_titleId = strItemCode.Substring(1, 1)
            answ_groupBoxId = strItemCode.Substring(2, 1)
            answ_itemId = strItemCode.Substring(3)
        End If

        idItem = answ_GroupeId & answ_titleId & answ_groupBoxId
        itemValue = answ_itemId

        LibelleCourt = pCtrl.Libelle
        LibelleLong = pCtrl.LibelleLong
        If pCtrl.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.UN Or pCtrl.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.DEUX Or pCtrl.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.TROIS Then
            cause = pCtrl.Cause
        Else
            cause = ""
        End If
        If pCtrl.Checked Then
            SetItemCodeEtat(pCtrl.Categorie)
        End If

    End Sub
    <XmlIgnore>
    Public Property id() As String
        Get
            Return aid
        End Get
        Set(ByVal Value As String)
            aid = Value
        End Set
    End Property
    Private _uidDiagnostic As Integer
    Public Property uiddiagnostic() As Integer
        Get
            Return _uidDiagnostic
        End Get
        Set(ByVal value As Integer)
            _uidDiagnostic = value
        End Set
    End Property
    Public Property idDiagnostic() As String
        Get
            Return _idDiagnostic
        End Get
        Set(ByVal Value As String)
            _idDiagnostic = Value
        End Set
    End Property
    Public Property aiddiagnostic() As String
        Get
            Return idDiagnostic
        End Get
        Set(ByVal Value As String)
            idDiagnostic = Value
        End Set
    End Property

    Public Property idItem() As String
        Get
            Return _idItem
        End Get
        Set(ByVal Value As String)
            _idItem = Value
        End Set
    End Property

    Public Property itemValue() As String
        Get
            Return _itemValue
        End Get
        Set(ByVal Value As String)
            _itemValue = Value
        End Set
    End Property
    Public Property LibelleCourt() As String
        Get
            Return _libelleCourt
        End Get
        Set(ByVal Value As String)
            _libelleCourt = Value
        End Set
    End Property
    Public Property LibelleLong() As String
        Get
            Return _libelleLong
        End Get
        Set(ByVal Value As String)
            _libelleLong = Value
        End Set
    End Property
    ''' <summary>
    ''' Renvoie le code complet de l'item avec un blanc devant si besoin
    ''' Traite le cas des champs de mesures (help*)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getItemCode() As String
        If (IsNumeric(idItem)) Then
            Return Right(" " & idItem & itemValue, 5)
        Else
            Return idItem
        End If
    End Function
    ''' <summary>
    ''' Maj du CodeEtat (Utiliser plutot SetItemCodeEtat)
    ''' on est obligé de garder cette prop public pour les echanges XMLs
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks>B = OK, O = Mineur, P = Majeur, X = Défauts au Préliminaires</remarks>
    Public Property itemCodeEtat() As String
        Get
            Return _itemCodeEtat
        End Get
        Set(ByVal Value As String)
            _itemCodeEtat = Value
        End Set
    End Property
    Public Overridable Sub SetItemCodeEtat(pTypectrl As CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT)
        Select Case pTypectrl
            Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_OK
                itemCodeEtat = EtatDiagItemOK
            Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MINEUR
                itemCodeEtat = EtatDiagItemMINEUR
            Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEUR
                itemCodeEtat = EtatDiagItemMAJEUR
            Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_MAJEURPRELIM
                itemCodeEtat = EtatDiagItemMAJPRELIM
            Case CRODIP_ControlLibrary.CRODIP_CATEGORIEDEFAUT.DEFAUT_ABSENCE
                itemCodeEtat = EtatDiagItemABSENCE
        End Select

    End Sub

    Public Property isItemCode1() As String
        Get
            Return (cause = "1")
        End Get
        Set(ByVal Value As String)
            If Value.ToUpper() = "TRUE" Or Value.ToUpper() = "VRAI" Or Value.ToUpper() = "1" Then
                cause = "1"
            End If
        End Set
    End Property

    Public Property isItemCode2() As String
        Get
            Return (cause = "2")
        End Get
        Set(ByVal Value As String)
            If Value.ToUpper() = "TRUE" Or Value.ToUpper() = "VRAI" Or Value.ToUpper() = "1" Then
                cause = "2"
            End If
        End Set
    End Property

    Public Property cause() As String
        Get
            Return _cause
        End Get
        Set(ByVal Value As String)
            _cause = Value
        End Set
    End Property
    Public Overrides Function Fill(ByVal pColName As String, ByVal pcolValue As Object) As Boolean
        Dim bReturn As Boolean = True
        If Not MyBase.Fill(pColName, pcolValue) Then
            Select Case pColName.ToUpper().Trim()
                Case "id".ToUpper()
                    id = pcolValue.ToString
                Case "idDiagnostic".ToUpper()
                    idDiagnostic = pcolValue.ToString()
                Case "uiddiagnostic".ToUpper()
                    uiddiagnostic = pcolValue.ToString()
                Case "aiddiagnostic".ToUpper()
                    aiddiagnostic = pcolValue.ToString()
                Case "idItem".ToUpper
                    idItem = pcolValue.ToString()
                Case "itemValue".ToUpper()
                    itemValue = pcolValue.ToString()
                Case "itemCodeEtat".ToUpper()
                    itemCodeEtat = pcolValue.ToString()
                '           Case "isItemCode1".ToUpper()
                '                isItemCode1 = pcolValue
                '            Case "isItemCode2".ToUpper()
                '               isItemCode2 = pcolValue
                Case "cause".ToUpper()
                    cause = pcolValue.ToString
                Case Else
                    bReturn = False
            End Select
        End If
        Return bReturn
    End Function





End Class