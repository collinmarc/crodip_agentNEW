Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic

<Serializable()> _
Public Class DiagnosticBusesList

    Private _diagnosticBuses As List(Of DiagnosticBuses)

    Sub New()
        _diagnosticBuses = New List(Of DiagnosticBuses)

    End Sub
    <XmlIgnoreAttribute()>
    Public Property Liste As List(Of DiagnosticBuses)
        Get
            Return _diagnosticBuses
        End Get
        Set(ByVal Value As List(Of DiagnosticBuses))
            _diagnosticBuses = Value
        End Set
    End Property
    'Public Property diagnosticBuses As DiagnosticBuses()
    '    Get
    '        Return _diagnosticBuses.ToArray()
    '    End Get
    '    Set(ByVal Value As DiagnosticBuses())
    '    End Set
    'End Property

End Class
<Serializable()>
Public Class DiagnosticBuses
    Inherits DiagnosticObjDependant

    Private _id As Integer
    Private _idDiagnostic As String
    Private _idLot As String
    Private _marque As String
    Private _nombre As String
    Private _nombrebusesusees As String
    Private _genre As String
    Private _calibre As String
    Private _couleur As String
    Private _ecartTolere As String
    Private _debitMoyen As String
    Private _debitNominal As String
    Private _debitMax As String
    Private _debitMin As String
    Private _Resultat As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String
    Private _diagnosticBusesDetail As DiagnosticBusesDetailList

    '############################################################################

    Sub New()
        _diagnosticBusesDetail = New DiagnosticBusesDetailList()
    End Sub
    Sub New(pdiag As Diagnostic)
        _diagnosticBusesDetail = New DiagnosticBusesDetailList()
        uiddiagnostic = pdiag.uid
        aiddiagnostic = pdiag.aid
    End Sub
    Public Property idLot() As String
        Get
            Return _idLot
        End Get
        Set(ByVal Value As String)
            _idLot = Value
        End Set
    End Property

    Public Property marque() As String
        Get
            Return _marque
        End Get
        Set(ByVal Value As String)
            _marque = Value
        End Set
    End Property

    Public Property nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal Value As String)
            _nombre = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property nombrebusesusees() As String
        Get
            Return _nombrebusesusees
        End Get
        Set(ByVal Value As String)
            _nombrebusesusees = Value
        End Set
    End Property

    Public Property genre() As String
        Get
            Return _genre
        End Get
        Set(ByVal Value As String)
            _genre = Value
        End Set
    End Property

    Public Property calibre() As String
        Get
            Return _calibre
        End Get
        Set(ByVal Value As String)
            _calibre = Value
        End Set
    End Property

    Public Property couleur() As String
        Get
            Return _couleur
        End Get
        Set(ByVal Value As String)
            _couleur = Value
        End Set
    End Property

    Public Property ecartTolere() As String
        Get
            Return _ecartTolere
        End Get
        Set(ByVal Value As String)
            _ecartTolere = Value
        End Set
    End Property

    Public Property debitMoyen() As String
        Get
            Return _debitMoyen
        End Get
        Set(ByVal Value As String)
            _debitMoyen = convertValue(Value)
        End Set
    End Property

    Public Property debitNominal() As String
        Get
            Return _debitNominal
        End Get
        Set(ByVal Value As String)
            _debitNominal = convertValue(Value)
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property debitMax() As String
        Get
            Return _debitMax
        End Get
        Set(ByVal Value As String)
            _debitMax = convertValue(Value)

        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property debitMin() As String
        Get
            Return _debitMin
        End Get
        Set(ByVal Value As String)
            _debitMin = convertValue(Value)
        End Set
    End Property

    Private Function convertValue(ByVal pValue As String) As String
        Dim dec As Decimal
        Dim sReturn As String
        pValue = pValue.Replace(".", ",")
        pValue = pValue.Replace(";", ",")
        pValue = pValue.Replace("?", ",")
        If IsNumeric(pValue) And Not String.IsNullOrEmpty(pValue) Then
            dec = Math.Round(CDec(pValue), 3)
            sReturn = dec.ToString()
        Else
            sReturn = ""
        End If
        Return sReturn
    End Function
    <XmlIgnoreAttribute()>
    Public Property Resultat() As String
        Get
            Return _Resultat
        End Get
        Set(ByVal Value As String)
            _Resultat = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property diagnosticBusesDetailList() As DiagnosticBusesDetailList
        Get
            Return _diagnosticBusesDetail
        End Get
        Set(ByVal Value As DiagnosticBusesDetailList)
            _diagnosticBusesDetail = Value
        End Set
    End Property


    Public Overrides Function Fill(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            If Not MyBase.Fill(pColName, pColValue) Then

                Select Case pColName.Trim().ToUpper()
                    Case "id".Trim().ToUpper()
                        Me.id = pColValue
                    Case "idDiagnostic".Trim().ToUpper()
                        Me.idDiagnostic = pColValue.ToString()
                    Case "idLot".Trim().ToUpper()
                        Me.idLot = pColValue.ToString()
                    Case "marque".Trim().ToUpper()
                        Me.marque = pColValue.ToString()
                    Case "nombre".Trim().ToUpper()
                        Me.nombre = pColValue.ToString()
                    Case "genre".Trim().ToUpper()
                        Me.genre = pColValue.ToString()
                    Case "calibre".Trim().ToUpper()
                        Me.calibre = pColValue.ToString()
                    Case "ecartTolere".Trim().ToUpper()
                        Me.ecartTolere = pColValue.ToString()
                    Case "couleur".Trim().ToUpper()
                        Me.couleur = pColValue.ToString()
                    Case "debitMoyen".Trim().ToUpper()
                        Me.debitMoyen = pColValue.ToString()
                    Case "debitNominal".Trim().ToUpper()
                        Me.debitNominal = pColValue.ToString()
                    Case "uiddiagnostic".Trim().ToUpper()
                        Me.uiddiagnostic = pColValue.ToString()
                    Case "aiddiagnostic".Trim().ToUpper()
                        Me.aiddiagnostic = pColValue.ToString()
                End Select

                bReturn = True
            End If
        Catch ex As Exception
            bReturn = False
        End Try

        Return bReturn
    End Function
End Class
