Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic

''' <summary>
''' Object dépendant d'un diagnostic
''' </summary>
<Serializable()>
Public Class DiagnosticObjDependant
    Inherits root

    Private _aidDiagnostic As String
    Private _uidDiagnostic As Integer

    '############################################################################

    Sub New()
    End Sub
    Sub New(pdiag As Diagnostic)
        uiddiagnostic = pdiag.uid
        aiddiagnostic = pdiag.aid
    End Sub

    Public Property id() As Integer
        Get
            If String.IsNullOrEmpty(Trim(aid)) Then
                Return 0
            Else
                Try

                    Return CInt(aid)
                Catch ex As Exception
                    Return 0
                End Try

            End If
        End Get
        Set(ByVal Value As Integer)
            aid = Value
        End Set
    End Property

    Public Property idDiagnostic() As String
        Get
            Return _aidDiagnostic
        End Get
        Set(ByVal Value As String)
            _aidDiagnostic = Value
        End Set
    End Property
    Public Property aiddiagnostic() As String
        Get
            Return _aidDiagnostic
        End Get
        Set(ByVal value As String)
            _aidDiagnostic = value
        End Set
    End Property
    <XmlElement("uiddiagnostic")>
    Public Property uiddiagnosticS() As String
        Get
            Return uiddiagnostic
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                uiddiagnostic = value
            End If
        End Set
    End Property
    <XmlIgnore()>
    Public Property uiddiagnostic() As Integer
        Get
            Return _uidDiagnostic
        End Get
        Set(ByVal value As Integer)
            _uidDiagnostic = value
        End Set
    End Property

End Class
