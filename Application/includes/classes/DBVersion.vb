Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(DBVersion))> _
Public Class DBVersion

    Private _Num As String
    Private _Date As Date
    Private _Commentaire As String



    Sub New()

    End Sub

    Public Property NUM() As String
        Get
            Return _Num
        End Get
        Set(ByVal Value As String)
            _Num = Value
        End Set
    End Property

    Public Property DateVersion() As Date
        Get
            Return _Date
        End Get
        Set(ByVal Value As Date)
            _Date = Value
        End Set
    End Property

    Public Property Commentaire() As String
        Get
            Return _Commentaire
        End Get
        Set(ByVal Value As String)
            _Commentaire = Value
        End Set
    End Property

    ''' <summary>
    ''' initialisation de l'objet avec le resultat d'un requete
    ''' </summary>
    ''' <param name="pColName"></param>
    ''' <param name="pValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Fill(ByVal pColName As String, ByVal pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case pColName.ToUpper.Trim().ToUpper()
                Case "VERSION_NUM".Trim().ToUpper()
                    Me.NUM = pValue.ToString()
                Case "VERSION_DATE".Trim().ToUpper()
                    Me.DateVersion = CSDate.ToCRODIPString(pValue.ToString())
                Case "VERSION_COMM".Trim().ToUpper()
                    Me.Commentaire = pValue.ToString()
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DBVersion.Fill Error : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class