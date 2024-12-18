Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic

<Serializable()>
Public Class DiagnosticBusesDetailList

    Private _diagnosticBusesDetail As List(Of DiagnosticBusesDetail)

    Sub New()
        _diagnosticBusesDetail = New List(Of DiagnosticBusesDetail)
    End Sub
    <XmlIgnore>
    Public Property Liste() As List(Of DiagnosticBusesDetail)
        Get
            Return _diagnosticBusesDetail
        End Get
        Set(ByVal Value As List(Of DiagnosticBusesDetail))
            _diagnosticBusesDetail = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property arrDiagnosticBusesDetail() As DiagnosticBusesDetail()
        Get
            Return _diagnosticBusesDetail.ToArray()
        End Get
        Set(ByVal Value As DiagnosticBusesDetail())

        End Set
    End Property

End Class

<Serializable()>
Public Class DiagnosticBusesDetail
    Inherits DiagnosticObjDependant

    Private _idBuse As Integer
    Private _idLot As String
    Private _debit As String
    Private _ecart As String
    Private _Usee As Boolean
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String

    Sub New()
        idDiagnostic = ""
        _idBuse = 0
        _idLot = 0
        _debit = ""
        _ecart = ""
        _Usee = False
        dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString

        dateModificationCrodip = CSDate.ToCRODIPString(DateTime.MinValue).ToString

    End Sub
    Sub New(pBuse As DiagnosticBuses)
        idDiagnostic = pBuse.idDiagnostic
        uiddiagnostic = pBuse.uiddiagnostic
        aiddiagnostic = pBuse.aiddiagnostic
        idLot = pBuse.idLot
        dateModificationAgent = CSDate.ToCRODIPString(Date.Now).ToString

        dateModificationCrodip = CSDate.ToCRODIPString(DateTime.MinValue).ToString

    End Sub
    ''' <summary>
    ''' idBuse = numero de buse
    ''' </summary>
    ''' <returns></returns>
    <Obsolete("ne pas utiliser cettte propri�t� car ce n'est pas un veritable id, utilisez numbuse plutot")>
    Public Property idBuse() As Integer
        Get
            Return _idBuse
        End Get
        Set(ByVal Value As Integer)
            _idBuse = Value
        End Set
    End Property
    ''' <summary>
    ''' Numero de buse (Anciennement nomm�e idbuse)
    ''' </summary>
    ''' <returns></returns>

    <XmlElement("idBuse")>
    Public Property numBuse() As Integer
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

    Public Overrides Function Fill(ByVal pColname As String, ByVal pcolValue As Object) As Boolean
        Dim bReturn As Boolean = True
        Try
            If Not MyBase.Fill(pColname, pcolValue) Then
                bReturn = True
                Select Case pColname.Trim().ToUpper()
                    Case "id".Trim().ToUpper()
                        Me.id = CInt(pcolValue)
                    Case "uiddiagnostic".Trim().ToUpper()
                        Me.uiddiagnostic = pcolValue.ToString()
                    Case "aiddiagnostic".Trim().ToUpper()
                        Me.aiddiagnostic = pcolValue.ToString()
                    Case "idDiagnostic".Trim().ToUpper()
                        Me.idDiagnostic = pcolValue.ToString()
                    Case "idBuse".Trim().ToUpper()
                        Me.numBuse = CInt(pcolValue)
                    Case "idLot".Trim().ToUpper()
                        Me.idLot = pcolValue.ToString()
                    Case "debit".Trim().ToUpper()
                        Me.debit = pcolValue.ToString()
                    Case "ecart".Trim().ToUpper()
                        Me.ecart = pcolValue.ToString()
                    Case Else
                        bReturn = False
                End Select
            End If
        Catch ex As Exception
            CSDebug.dispError("DiagnosticBusesDetail.Fill ERR " & ex.Message.ToString())
            bReturn = False
        End Try
        Return bReturn


    End Function
    ''' <summary>
    ''' Calcul l'�cart de d�bit pour une buse
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
