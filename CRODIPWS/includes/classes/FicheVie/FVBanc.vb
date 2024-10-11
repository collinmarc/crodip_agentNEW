Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(FVBanc))> _
Public Class FVBanc
    Inherits FVMateriel

    Private _idBancMesure As String
    Private _pressionControle As String
    Private _valeursMesurees As String
    Private _idManometreControle As String
    Private _idBuseEtalon As String

    Sub New()
    End Sub
    Sub New(ByVal pAgent As Agent)

        idAgentControleur = pAgent.id
    End Sub


    Public Property idBancMesure() As String
        Get
            Return _idBancMesure
        End Get
        Set(ByVal Value As String)
            _idBancMesure = Value
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

    Public Property idManometreControle() As String
        Get
            Return _idManometreControle
        End Get
        Set(ByVal Value As String)
            _idManometreControle = Value
        End Set
    End Property

    Public Property idBuseEtalon() As String
        Get
            Return _idBuseEtalon
        End Get
        Set(ByVal Value As String)
            _idBuseEtalon = Value
        End Set
    End Property


    Public Overrides Function Fill(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            FillCommun(pColName, pColValue)
            Select Case pColName.ToUpper().Trim()
                Case "idBancMesure".ToUpper().Trim()
                    Me.idBancMesure = pColValue.ToString
                Case "pressionControle".ToUpper().Trim()
                    Me.pressionControle = pColValue.ToString
                Case "valeursMesurees".ToUpper().Trim()
                    Me.valeursMesurees = pColValue.ToString
                Case "idManometreControle".ToUpper().Trim()
                    Me.idManometreControle = pColValue.ToString
                Case "idBuseEtalon".ToUpper().Trim()
                    Me.idBuseEtalon = pColValue.ToString
                Case "FVFileName".ToUpper().Trim()
                    Me.FVFileName = pColValue.ToString
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVBanc.Fill Err " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function 'Fill

End Class