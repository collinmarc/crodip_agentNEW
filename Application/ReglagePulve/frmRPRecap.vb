Imports System.Collections.Generic
Imports CRODIP_ControlLibrary

Public Class frmRPRecap
    Implements IfrmCRODIP
    Private m_paramDiag As CRODIP_ControlLibrary.ParamDiag
    Private m_lstParamStrlDiag As CRODIP_ControlLibrary.LstParamCtrlDiag
    Private WithEvents m_oDiag As RPDiagnostic
    Private m_PulverisateurCourant As Pulverisateur


    Public Sub setContexte(pDiag As RPDiagnostic, pPulve As Pulverisateur)
        m_oDiag = pDiag
        m_bsDiagnostic.Clear()
        m_bsDiagnostic.Add(pDiag)
        m_PulverisateurCourant = pPulve
    End Sub

    Private Sub frmRPRecap_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Valider()
    End Sub

    Private Sub frmRPRecap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        formload()
    End Sub
    Protected Overridable Sub formload() Implements IfrmCRODIP.formLoad
        Me.SuspendLayout()
        m_paramDiag = m_oDiag.ParamDiag
        If m_paramDiag IsNot Nothing Then
            'charegement de la liste des Controle du Paramdiag
            m_lstParamStrlDiag = New CRODIP_ControlLibrary.LstParamCtrlDiag()
            If m_lstParamStrlDiag.readXML(My.Settings.RepertoireParametres & "/" & m_paramDiag.fichierConfig) Then
                ' Maj du TreeView
                TreeView3state1.Nodes.Clear()
                Dim oTvNode1 As TreeNode = TreeView3state1.Nodes.Add("Liste des Défauts")
                FillTreeView(oTvNode1)
            End If

        End If
        MinimizeBox = False
        MaximizeBox = False
        Me.ResumeLayout()

    End Sub

    Protected Function FillTreeView(pNode As TreeNode) As Boolean

        Dim bReturn As Boolean
        Dim racine As String = ""
        Dim oNodeGrp As TreeNode
        Dim oNodeGrp1 As TreeNode
        Dim oNodeGrp2 As TreeNode
        Dim oNode As TreeNode
        Dim oLst As List(Of CRODIP_ControlLibrary.ParamCtrlDiag)
        Try
            oLst = m_lstParamStrlDiag.getListeHierachique
            'parcours de Param de niveau 1
            For Each oParam As CRODIP_ControlLibrary.ParamCtrlDiag In oLst
                oNodeGrp = pNode.Nodes.Add("(" & oParam.Code & ") " & oParam.Libelle)
                oNodeGrp.Tag = oParam
                'parcours de Param de niveau 2
                For Each oParam1 As ParamCtrlDiag In oParam.lstSubNodes
                    oNodeGrp1 = oNodeGrp.Nodes.Add("(" & oParam1.Code & ") " & oParam1.Libelle)
                    oNodeGrp1.Tag = oParam1
                    'parcours de Param de niveau 3
                    For Each oParam2 As ParamCtrlDiag In oParam1.lstSubNodes
                        oNodeGrp2 = oNodeGrp1.Nodes.Add("(" & oParam2.Code & ") " & oParam2.Libelle)
                        oNodeGrp2.Tag = oParam2
                        'parcours de Param de niveau 4
                        For Each oParam3 As ParamCtrlDiag In oParam2.lstSubNodes
                            'On n'affiche pas les OK
                            If oParam3.DefaultCategorie <> 0 Then
                                oNode = oNodeGrp2.Nodes.Add("(" & oParam3.Code & ") " & oParam3.LibelleLong)
                                oNode.Tag = oParam3
                                'Si le diag contient un diagitem avec ce code 
                                '   => check 
                                If isDiagItem(oParam3) Then
                                    oNode.Checked = True
                                End If
                            End If
                        Next
                    Next
                Next

            Next

            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("frmRPrecap.Filltreeview ERR " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    ''' <summary>
    ''' Rend vrai si le diagnosticCourent contient le DiagItem 
    ''' </summary>
    ''' <param name="pCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isDiagItem(pParam As CRODIP_ControlLibrary.ParamCtrlDiag) As Boolean
        Dim bReturn As Boolean
        Dim sKey As String = pParam.Code.Replace(".", "")
        sKey = Strings.Right(" " & sKey, 5)
        bReturn = False
        Dim oDiagItem As DiagnosticItem
        oDiagItem = m_oDiag.diagnosticItemsLst.getItem(sKey)
        If oDiagItem IsNot Nothing Then
            If (oDiagItem.LibelleLong = pParam.LibelleLong) Then
                bReturn = True
            End If
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Renvoie le code du groupe d'un paramètre
    ''' </summary>
    ''' <param name="pCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getGrpCode(pCode As String) As String
        Dim str As String
        str = Mid(pCode, 1, 6)
        If str.EndsWith(".") Then
            str = Mid(str, 1, str.Length - 1)
        End If
        Return str
    End Function
    ''' <summary>
    ''' Sélection d'un noeud de l'arbre
    ''' Récupération du ParamCtrlDiag
    '''     Affectation au controle de saisie
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SelectNode()

    End Sub
    Private m_bDuringSelectNode As Boolean
    Private Sub tvDiagItems_AfterSelect(sender As Object, e As TreeViewEventArgs)
        SelectNode()
    End Sub

    Private Sub tvDiagItems_AfterCheck(sender As Object, e As TreeViewEventArgs)
    End Sub


    Private Sub btn_Valider_Click(sender As Object, e As EventArgs)

        Valider()
    End Sub
    Private Function ExploreTreeViewToCreateDiagItems(pNode As TreeNode) As Boolean
        Dim bReturn As Boolean
        Try
            If pNode.Level = 4 And pNode.Checked Then
                Dim oParam As ParamCtrlDiag
                oParam = TryCast(pNode.Tag, ParamCtrlDiag)
                If oParam IsNot Nothing Then
                    Dim oDiagItem As New DiagnosticItem(m_oDiag.id, oParam.Code.Replace(".", ""), "")

                    oDiagItem.itemCodeEtat = DiagnosticItem.EtatDiagItemMAJEUR
                    oDiagItem.LibelleCourt = oParam.Libelle
                    oDiagItem.LibelleLong = oParam.LibelleLong
                    m_oDiag.AddDiagItem(oDiagItem)
                End If
            End If
            For Each oNodeChild As TreeNode In pNode.Nodes
                ExploreTreeViewToCreateDiagItems(oNodeChild)
            Next
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    Protected Overridable Function Valider() As Boolean Implements IfrmCRODIP.Valider
        Dim bReturn As Boolean
        Try
            m_oDiag.diagnosticItemsLst.Clear()
            Dim oNode As TreeNode
            If TreeView3state1.Nodes.Count > 0 Then
                oNode = TreeView3state1.Nodes(0)
                ExploreTreeViewToCreateDiagItems(oNode)

                m_oDiag.bSectionDefauts = True
            End If

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("frmRPRecap.Valider Err" & ex.Message)
            bReturn = True
        End Try
        Return bReturn
    End Function

    Private Sub btn_annuler_Click(sender As Object, e As EventArgs)
        Annuler()
    End Sub

    Protected Overridable Sub Annuler() Implements IfrmCRODIP.Annuler

    End Sub

    Public Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

    End Sub

    Private Sub m_oDiag_ParamDiagUpated() Handles m_oDiag.ParamDiagUpated
        formload()
    End Sub
End Class