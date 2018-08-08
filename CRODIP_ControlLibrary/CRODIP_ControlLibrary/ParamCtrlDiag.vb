Imports System.Xml.Serialization
Imports System.IO
<Serializable()>
Public Class LstParamCtrlDiag
    Private m_lst As List(Of ParamCtrlDiag)

    Public Property ListeParam As List(Of ParamCtrlDiag)
        Get
            Return m_lst
        End Get
        Set(ByVal value As List(Of ParamCtrlDiag))
            m_lst = value

        End Set
    End Property
    Public Sub New()
        m_lst = New List(Of ParamCtrlDiag)
    End Sub
    Public Function Find(ByVal pCode As String) As ParamCtrlDiag
        Dim bReturn As ParamCtrlDiag = Nothing
        For Each octrl As ParamCtrlDiag In ListeParam
            If Trim(octrl.Code) = Trim(pCode) Then
                bReturn = octrl
            End If
        Next
        Return bReturn
    End Function
    Public Function FindDiagItem(ByVal pCode As String) As ParamCtrlDiag
        Dim bReturn As ParamCtrlDiag = Nothing
        For Each octrl As ParamCtrlDiag In ListeParam
            Dim str As String = octrl.Code.Replace(".", "")
            str = Right(" " & str, 5)
            If str = pCode Then
                bReturn = octrl
            End If
        Next
        Return bReturn
    End Function
    ''' <summary>
    ''' Retourn la liste des paramètre de niveau inférieur au code Spécfié
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getNiveauInf(pCode As String) As List(Of ParamCtrlDiag)
        Dim oReturn As New List(Of ParamCtrlDiag)
        Try
            Dim nNiveau As Integer
            If String.IsNullOrEmpty(pCode) Then
                nNiveau = 0
            Else
                nNiveau = pCode.Split(".").Count
            End If
            For Each oParam As ParamCtrlDiag In m_lst
                If nNiveau = 0 Then
                    If oParam.Niveau = 1 Then
                        oReturn.Add(oParam)
                    End If
                Else
                    If oParam.Code.StartsWith(pCode & ".") And oParam.Niveau = nNiveau + 1 Then
                        oReturn.Add(oParam)
                    End If
                End If
            Next
        Catch ex As Exception

        End Try
        Return oReturn
    End Function
    ''' <summary>
    ''' Retourn la liste des paramètre de niveau inférieur au code Spécfié
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function getListeHierachique() As List(Of ParamCtrlDiag)
        Dim oReturn As New List(Of ParamCtrlDiag)
        Try
            oReturn = getNiveauInf("")
            'Niveau 1
            For Each oParam As ParamCtrlDiag In oReturn
                oParam.lstSubNodes = getNiveauInf(oParam.Code)
                'Niveau 2
                For Each oParam2 As ParamCtrlDiag In oParam.lstSubNodes
                    oParam2.lstSubNodes = getNiveauInf(oParam2.Code)
                    'Niveau 3
                    For Each oParam3 As ParamCtrlDiag In oParam2.lstSubNodes
                        oParam3.lstSubNodes = getNiveauInf(oParam3.Code)
                        'Niveau 4
                        For Each oParam4 As ParamCtrlDiag In oParam3.lstSubNodes
                            'Niveau 1.1.1.1
                            'On ne va pas chercher les niveau inférieur, pour gagner du temps
                            oParam4.lstSubNodes = New List(Of ParamCtrlDiag)
                        Next
                    Next
                Next
            Next
        Catch ex As Exception

        End Try
        Return oReturn
    End Function

    Public Function writeXml(ByVal strFileName As String) As Boolean
        Dim bReturn As Boolean
        Try

            Dim objStreamWriter As New StreamWriter(strFileName)
            Dim x As New XmlSerializer(Me.GetType)
            x.Serialize(objStreamWriter, Me)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function readXML(ByVal strFileName As String) As Boolean
        Dim bReturn As Boolean
        Try
            Dim olst As New LstParamCtrlDiag()
            Dim objStreamReader As New StreamReader(strFileName)
            Dim x As New XmlSerializer(Me.GetType)
            olst = x.Deserialize(objStreamReader)
            objStreamReader.Close()
            ListeParam.Clear()
            For Each oParam As ParamCtrlDiag In olst.ListeParam
                If String.IsNullOrEmpty(oParam.LibelleLong) Then
                    oParam.LibelleLong = oParam.Libelle
                End If
                ListeParam.Add(oParam)
            Next
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class

Public Class ParamCtrlDiag
    Private m_code As String
    Private m_libelle As String
    Private m_libelleLong As String
    Private m_defaultcategorie As String
    Private m_NiveauCauseMax As String
    Private m_bCause1 As Boolean
    Private m_bCause2 As Boolean
    Private m_bCause3 As Boolean
    Private m_Actif As Boolean
    Private m_Niveau As Integer
    Private m_lstSubNode As List(Of ParamCtrlDiag)

    Public Property Code As String
        Get
            Return m_code
        End Get
        Set(ByVal value As String)
            m_code = value
            m_Niveau = value.Split(".").Count
        End Set
    End Property
    Public Property Libelle As String
        Get
            Return m_libelle
        End Get
        Set(ByVal value As String)
            m_libelle = value

        End Set
    End Property
    Public Property LibelleLong As String
        Get
            Return m_libelleLong
        End Get
        Set(ByVal value As String)
            m_libelleLong = value

        End Set
    End Property
    Public Property Actif As Boolean
        Get
            Return m_Actif
        End Get
        Set(ByVal value As Boolean)
            m_Actif = value
        End Set
    End Property
    Public Property DefaultCategorie As String
        Get
            Return m_defaultcategorie
        End Get
        Set(ByVal value As String)
            m_defaultcategorie = value

        End Set
    End Property
    Public Property NiveauCauseMax As String
        Get
            Return m_NiveauCauseMax
        End Get
        Set(ByVal value As String)
            m_NiveauCauseMax = value

        End Set
    End Property
    Public Property Cause1 As Boolean
        Get
            Return m_bCause1
        End Get
        Set(ByVal value As Boolean)
            m_bCause1 = value

        End Set
    End Property
    Public Property Cause2 As Boolean
        Get
            Return m_bCause2
        End Get
        Set(ByVal value As Boolean)
            m_bCause2 = value

        End Set
    End Property
    Public Property Cause3 As Boolean
        Get
            Return m_bCause3
        End Get
        Set(ByVal value As Boolean)
            m_bCause3 = value

        End Set
    End Property
    Public Property Niveau As Integer
        Get
            Return m_Niveau
        End Get
        Set(ByVal value As Integer)
            m_Niveau = value

        End Set
    End Property
    <XmlIgnore()>
    Public Property lstSubNodes As List(Of ParamCtrlDiag)
        Get
            Return m_lstSubNode
        End Get
        Set(ByVal value As List(Of ParamCtrlDiag))
            m_lstSubNode = value

        End Set
    End Property
    ''' <summary>
    ''' Affecte les paramétre à un controle de diagnostique
    ''' </summary>
    ''' <param name="pCtrlDiag">Controle à mettre à jour</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Affecte(ByVal pCtrlDiag As CRODIP_ControlLibrary.CtrlDiag2) As Boolean
        Dim bReturn As Boolean
        Try
            '            pCtrlDiag.Checked = False
            pCtrlDiag.Categorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_NONE
            pCtrlDiag.Cause = CRODIP_ControlLibrary.CRODIP_NIVEAUCAUSE.NONE

            pCtrlDiag.DefaultCategorie = DefaultCategorie
            pCtrlDiag.Code = Code
            pCtrlDiag.Libelle = Libelle
            pCtrlDiag.LibelleLong = LibelleLong
            pCtrlDiag.cause1 = Cause1
            pCtrlDiag.Cause2 = Cause2
            pCtrlDiag.cause3 = Cause3
            pCtrlDiag.Enabled = Actif
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn

    End Function


    Public Sub New()
        m_code = ""
        m_libelle = ""
        m_libelleLong = ""
        m_defaultcategorie = CRODIP_CATEGORIEDEFAUT.DEFAUT_GROUPE
        m_NiveauCauseMax = ""
        m_bCause1 = False
        m_bCause2 = False
        m_bCause3 = False
        m_Actif = True
        m_Niveau = 4 'Niveau défaut par défaut
    End Sub

    Public Shared Function ConvertCode(ByVal pOldCode As String) As String
        Dim NewCode As String = ""
        Dim bPremierCar As Boolean = True
        If pOldCode.IndexOf(".") = -1 Then
            For i As Integer = 0 To pOldCode.Length - 1
                If Not bPremierCar Then
                    NewCode = NewCode & "."
                End If
                NewCode = NewCode & pOldCode(i)
                If bPremierCar And pOldCode.Length > 4 Then
                    If (pOldCode.StartsWith("10") Or pOldCode.StartsWith("11") Or pOldCode.StartsWith("12")) Then
                        i = i + 1
                        NewCode = NewCode & pOldCode(i)
                    End If
                End If
                bPremierCar = False
            Next

        Else
            'Si le code passé en Param contient un . on le retourne 
            NewCode = pOldCode
        End If

        Return NewCode
    End Function

    Public Shared Function getLibelleLong(ByVal code As String, ByVal pParamfile As String) As String

        Dim sReturn As String
        Dim olst As CRODIP_ControlLibrary.LstParamCtrlDiag
        Dim oParam As CRODIP_ControlLibrary.ParamCtrlDiag

        olst = New CRODIP_ControlLibrary.LstParamCtrlDiag()
        olst.readXML(pParamfile)
        'Le Code que l'on recoit n'a pas de point, il faut donc le reconstruire pour être en accord avec le ?xml
        If code.IndexOf(".") = -1 Then
            oParam = New CRODIP_ControlLibrary.ParamCtrlDiag()
            code = ConvertCode(code)
        End If

        oParam = olst.Find(code)
        If oParam IsNot Nothing Then
            sReturn = oParam.LibelleLong
        Else
            sReturn = ""
        End If
        Return sReturn
    End Function

End Class
