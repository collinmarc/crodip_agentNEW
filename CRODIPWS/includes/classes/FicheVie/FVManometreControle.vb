Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(FVManometreControle))> _
Public Class FVManometreControle
    Inherits FVMateriel

    Private _idManometre As String
    Private _idReetalonnage As String
    Private _nomLaboratoire As String
    Private _dateReetalonnage As String
    Private _pressionControle As String
    Private _valeursMesurees As String
    Private _idManometreControleur As String
    Private _resolution As String

    Sub New()

    End Sub
    Sub New(ByVal pAgent As Agent)
        id = FVManometreControleManager.getNewId(pAgent)
        idAgentControleur = pAgent.id
        uidstructure = pAgent.uidstructure
        uidagentcontroleur = pAgent.uid
    End Sub


    Public Property idManometre() As String
        Get
            Return _idManometre
        End Get
        Set(ByVal Value As String)
            _idManometre = Value
        End Set
    End Property
    Private _uidmanometre As Integer
    <XmlIgnore>
    Public Property uidmanometre() As Integer
        Get
            Return _uidmanometre
        End Get
        Set(ByVal value As Integer)
            _uidmanometre = value
        End Set
    End Property
    <XmlElement("uidmanometre")>
    Public Property uidmanometreS() As String
        Get
            Return uidmanometre
        End Get
        Set(ByVal value As String)
            If Not String.IsNullOrEmpty(value) Then
                _uidmanometre = value
            End If
        End Set
    End Property




    Public Property idReetalonnage() As String
        Get
            Return _idReetalonnage
        End Get
        Set(ByVal Value As String)
            _idReetalonnage = Value
        End Set
    End Property

    Public Property nomLaboratoire() As String
        Get
            Return _nomLaboratoire
        End Get
        Set(ByVal Value As String)
            _nomLaboratoire = Value
        End Set
    End Property

    Public Property dateReetalonnage() As String
        Get
            Return _dateReetalonnage
        End Get
        Set(ByVal Value As String)
            _dateReetalonnage = Value
        End Set
    End Property

    Public Property pressionControle() As String
        Get
            Return _pressionControle
        End Get
        Set(ByVal Value As String)
            _pressionControle = Value
        End Set
    End Property

    Public Property valeursMesurees() As String
        Get
            Return _valeursMesurees
        End Get
        Set(ByVal Value As String)
            _valeursMesurees = Value
        End Set
    End Property

    Public Property idManometreControleur() As String
        Get
            Return _idManometreControleur
        End Get
        Set(ByVal Value As String)
            _idManometreControleur = Value
        End Set
    End Property


    Public Property resolution() As String
        Get
            Return _resolution
        End Get
        Set(ByVal Value As String)
            _resolution = Value
        End Set
    End Property

    Public Overrides Function Fill(pColName As String, pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            FillCommun(pColName, pColValue)

            Select Case pColName.ToUpper().Trim()
                Case "idManometre".ToUpper().Trim()
                    Me.idManometre = pColValue.ToString()
                Case "uidmanometre".ToUpper().Trim()
                    Me.uidmanometre = pColValue.ToString
                Case "idReetalonnage".ToUpper().Trim()
                    Me.idReetalonnage = pColValue.ToString()
                Case "nomLaboratoire".ToUpper().Trim()
                    Me.nomLaboratoire = pColValue.ToString()
                Case "dateReetalonnage".ToUpper().Trim()
                    Me.dateReetalonnage = CSDate.ToCRODIPString(pColValue.ToString())
                Case "pressionControle".ToUpper().Trim()
                    Me.pressionControle = pColValue.ToString()
                Case "valeursMesurees".ToUpper().Trim()
                    Me.valeursMesurees = pColValue.ToString()
                Case "idManometreControleur".ToUpper().Trim()
                    Me.idManometreControleur = pColValue.ToString()
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVManometreControle.Fill(" & pColName & ",...) Err " & ex.Message())
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class