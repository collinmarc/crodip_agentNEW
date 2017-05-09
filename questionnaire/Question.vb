Imports System.Xml.Serialization
Imports System.IO

<XmlInclude(GetType(Question))>
Public Class Question
    Inherits Element
    Private m_LibelleChapitre As String
    Private m_LstChoix As List(Of Choix)
    Private m_Reponse As String
    Private m_Precision As String
    Private m_Commentaire As String
    Private m_OuiNonQ As Boolean
    Private m_OuiNonR As Boolean

    Public Sub New()
        m_LstChoix = New List(Of Choix)
        m_Reponse = ""
        m_OuiNonQ = False
        m_OuiNonR = True
    End Sub

    Public Sub New(ByVal pCode As String, ByVal pLib As String)
        Me.New()
        Code = pCode
        Libelle = pLib
    End Sub


    Public Property ListOfChoix As List(Of Choix)
        Get
            Return m_LstChoix
        End Get
        Set(ByVal value As List(Of Choix))
            m_LstChoix = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property LibelleChapitre As String
        Get
            Return m_LibelleChapitre
        End Get
        Set(ByVal value As String)
            m_LibelleChapitre = value
        End Set
    End Property
    Public Overridable Property Reponse As String
        Get
            Return m_Reponse
        End Get
        Set(ByVal value As String)
            m_Reponse = value
        End Set
    End Property
    Public Function GetReponsecomplete() As String
        Dim strReponse As String = ""
        'Constrcution de la Réponse"
        If Me.OuiNonQ Then
            If OuiNonR = False Then
                strReponse = "NON"
            End If
        End If
        If strReponse <> "NON" Then
            If ListOfChoix.Count = 0 Then
                strReponse = m_Reponse
            Else
                For Each oChoix As Choix In ListOfChoix
                    If oChoix.EstSelectionne Then
                        strReponse = strReponse + oChoix.Libelle + " , "
                        If oChoix.isAutre Then
                            strReponse = Left(strReponse, strReponse.Length - 3)
                            strReponse = strReponse + "(" & Precision & ")"
                        End If
                    End If
                Next
                If strReponse.Length > 3 Then
                    strReponse = Left(strReponse, strReponse.Length - 3)
                End If
            End If


        End If
        Return strReponse
    End Function
    Public Property Precision As String
        Get
            Return m_Precision
        End Get
        Set(ByVal value As String)
            m_Precision = value
        End Set
    End Property
    Public Property Commentaire As String
        Get
            Return m_Commentaire
        End Get
        Set(ByVal value As String)
            m_Commentaire = value
        End Set
    End Property
    Public Property OuiNonQ As Boolean
        Get
            Return m_OuiNonQ
        End Get
        Set(ByVal value As Boolean)
            m_OuiNonQ = value
        End Set
    End Property
    Public Property OuiNonR As Boolean
        Get
            Return m_OuiNonR
        End Get
        Set(ByVal value As Boolean)
            m_OuiNonR = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property isOui As Boolean
        Get
            Return OuiNonR
        End Get
        Set(ByVal value As Boolean)
            OuiNonR = value
        End Set
    End Property
    <XmlIgnore()>
    Public Property isNon As Boolean
        Get
            Return Not m_OuiNonR
        End Get
        Set(ByVal value As Boolean)
            OuiNonR = Not value
        End Set
    End Property
    Public Function GetNbreReponse() As Integer
        Return m_Reponse.Count
    End Function
    Public Function GetNbreChoix() As Integer
        Return m_LstChoix.Count
    End Function

    Public Overrides Function ToCSV() As String
        Dim sReturn As String
        Try
            sReturn = ""
            sReturn = Code & ";" & Libelle & ";" & OuiNonR & ";" & Reponse
            For Each ochoix In ListOfChoix
                sReturn = sReturn & ";" & ochoix.Libelle & ";" & ochoix.EstSelectionne & ";" & ochoix.isAutre
                If ochoix.isAutre And ochoix.EstSelectionne Then
                    sReturn = sReturn & ";" & Precision
                Else
                    sReturn = sReturn & ";" & ""
                End If
            Next
            sReturn = sReturn & Me.Commentaire
        Catch ex As Exception
            CSDebug.dispInfo("Question.tocsv ERR" & ex.Message)
            sReturn = ""
        End Try
        Return sReturn
    End Function
End Class
