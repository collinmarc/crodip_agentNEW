Imports System.Xml.Serialization

Public Class PoolManoControle
    Inherits root
    Private _uidpool As Integer
    Public Property uidpool() As Integer
        Get
            Return _uidpool
        End Get
        Set(ByVal value As Integer)
            _uidpool = value
        End Set
    End Property
    Private _namepool As String
    Public Property namepool() As String
        Get
            Return _namepool
        End Get
        Set(ByVal value As String)
            _namepool = value
        End Set
    End Property
    Private _uidManoControle As Integer
    Public Property uidmanoc() As Integer
        Get
            Return _uidManoControle
        End Get
        Set(ByVal value As Integer)
            _uidManoControle = value
        End Set
    End Property
    Private _idManoControle As String
    Public Property idManometre() As String
        Get
            Return _idManoControle
        End Get
        Set(ByVal value As String)
            _idManoControle = value
        End Set
    End Property
    Private _uidstructure As Integer
    Public Property uidstructure() As Integer
        Get
            Return _uidstructure
        End Get
        Set(ByVal value As Integer)
            _uidstructure = value
        End Set
    End Property
    Private _dateAssociation As Date
    <XmlIgnoreAttribute()>
    Public Property dateAssociation() As Date
        Get
            Return _dateAssociation
        End Get
        Set(ByVal value As Date)
            _dateAssociation = value
        End Set
    End Property
    <XmlElement("dateAssociation")>
    Public Property dateAssociationS() As String
        Get
            If dateAssociation <> Date.MinValue Then
                Return CSDate.GetDateForWS(dateAssociation)
            Else
                Return ""
            End If
        End Get
        Set(ByVal Value As String)
            If Value <> "" Then
                Try
                    dateAssociation = CSDate.FromCrodipString(Value)
                Catch
                End Try
            End If
        End Set
    End Property
    Public Sub New()
    End Sub

    Public Overrides Function Fill(pcolName As String, pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = MyBase.Fill(pcolName, pValue)
            If Not bReturn Then
                CSDebug.dispError("PoolManoControle.Fill ERR : Erreur Affectation [" & pcolName & "}, value=[" & pValue & "]")
            End If

        Catch ex As Exception
            CSDebug.dispError("PoolManoControle.Fill ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function


End Class
