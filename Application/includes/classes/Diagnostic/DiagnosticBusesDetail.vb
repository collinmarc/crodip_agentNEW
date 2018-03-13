Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic

<Serializable()> _
Public Class DiagnosticBusesDetailList

    Private _diagnosticBusesDetail As List(Of DiagnosticBusesDetail)

    Sub New()
        _diagnosticBusesDetail = New List(Of DiagnosticBusesDetail)
    End Sub
    '    <XmlIgnore()>
    Public Property Liste() As List(Of DiagnosticBusesDetail)
        Get
            Return _diagnosticBusesDetail
        End Get
        Set(ByVal Value As List(Of DiagnosticBusesDetail))
            _diagnosticBusesDetail = Value
        End Set
    End Property
    Public Property DiagnosticBusesDetail() As DiagnosticBusesDetail()
        Get
            Return _diagnosticBusesDetail.ToArray()
        End Get
        Set(ByVal Value As DiagnosticBusesDetail())

        End Set
    End Property

End Class

<Serializable()>
Public Class DiagnosticBusesDetail

    Private _id As Integer
    Private _idDiagnostic As String
    Private _idBuse As Integer
    Private _idLot As String
    Private _debit As String
    Private _ecart As String
    Private _Usee As Boolean
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String

    Sub New()

    End Sub

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal Value As Integer)
            _id = Value
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

    Public Property idBuse() As Integer
        Get
            Return _idBuse
        End Get
        Set(ByVal Value As Integer)
            _idBuse = Value
        End Set
    End Property

    Public Property idLot() As String
        Get
            Return _idLot
        End Get
        Set(ByVal Value As String)
            _idLot = Value
        End Set
    End Property

    Public Property debit() As String
        Get
            Return _debit
        End Get
        Set(ByVal Value As String)
            _debit = Value
        End Set
    End Property

    Public Property ecart() As String
        Get
            Return _ecart
        End Get
        Set(ByVal Value As String)
            _ecart = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property usee() As Boolean
        Get
            Return _Usee
        End Get
        Set(ByVal Value As Boolean)
            _Usee = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property

    <XmlElement("dateModificationAgent")>
    Public Property dateModificationAgentS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationAgent)
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property
    <XmlElement("dateModificationCrodip")>
    Public Property dateModificationCrodipS() As String
        Get
            Return CSDate.GetDateForWS(_dateModificationCrodip)
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
        End Set
    End Property
    Public Function Fill(ByVal pColname As String, ByVal pcolValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case pColname.Trim().ToUpper()
                Case "id".Trim().ToUpper()
                    Me.id = CInt(pcolValue)
                Case "idDiagnostic".Trim().ToUpper()
                    Me.idDiagnostic = pcolValue.ToString()
                Case "idBuse".Trim().ToUpper()
                    Me.idBuse = CInt(pcolValue)
                Case "idLot".Trim().ToUpper()
                    Me.idLot = pcolValue.ToString()
                Case "debit".Trim().ToUpper()
                    Me.debit = pcolValue.ToString()
                Case "ecart".Trim().ToUpper()
                    Me.ecart = pcolValue.ToString()
                Case "dateModificationAgent".Trim().ToUpper()
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pcolValue.ToString())
                Case "dateModificationCrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pcolValue.ToString())
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesDetail.Fill ERR " & ex.Message.ToString())
            bReturn = False
        End Try
        Return bReturn


    End Function
    ''' <summary>
    ''' Calcul l'écart de débit pour une buse
    ''' </summary>
    ''' <param name="pDebitNominal"></param>
    ''' <param name="pTolerance"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function CalcEcart(pDebitNominal As Decimal, pTolerance As Decimal) As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Try
            Dim ecartD As Decimal
            ecartD = Math.Round(((debit - pDebitNominal) * 100) / pDebitNominal, 2)
            usee = (Math.Abs(ecartD) > pTolerance)
            ecart = ecartD
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesDetail.CalcEcart ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class
