'Imports System.Web.Services
'Imports System.Xml.Serialization

'Public Class DiagnosticFactureItem

'    Private _id As Integer
'    Private _idFacture As String
'    Private _libelle As String
'    Private _prixUnitaire As String
'    Private _qte As String
'    Private _tva As String
'    Private _prixTotal As String
'    Private _dateModificationAgent As String
'    Private _dateModificationCrodip As String

'    '############################################################################

'    Sub New()

'    End Sub

'    Public Property id() As Integer
'        Get
'            Return _id
'        End Get
'        Set(ByVal Value As Integer)
'            _id = Value
'        End Set
'    End Property

'    Public Property idFacture() As String
'        Get
'            Return _idFacture
'        End Get
'        Set(ByVal Value As String)
'            _idFacture = Value
'        End Set
'    End Property

'    Public Property libelle() As String
'        Get
'            Return _libelle
'        End Get
'        Set(ByVal Value As String)
'            _libelle = Value
'        End Set
'    End Property

'    Public Property prixUnitaire() As String
'        Get
'            Return _prixUnitaire
'        End Get
'        Set(ByVal Value As String)
'            Try
'                Dim strValue As String = Value
'                strValue = strValue.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                strValue = strValue.Replace(",", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                Dim nValue As Decimal
'                nValue = Convert.ToDecimal(strValue)
'                _prixUnitaire = String.Format("{0:0.00}", nValue)
'                calcultTotal()
'            Catch ex As Exception

'            End Try
'        End Set
'    End Property

'    Public Property qte() As String
'        Get
'            Return _qte
'        End Get
'        Set(ByVal Value As String)
'            Try
'                Dim strValue As String = Value
'                strValue = strValue.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                strValue = strValue.Replace(",", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                Dim nValue As Decimal
'                nValue = Convert.ToDecimal(strValue)
'                _qte = strValue
'                calcultTotal()

'            Catch ex As Exception

'            End Try
'        End Set
'    End Property

'    Public Property tva() As String
'        Get
'            Return _tva
'        End Get
'        Set(ByVal Value As String)
'            Try
'                Dim strValue As String = Value
'                strValue = strValue.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                strValue = Value.Replace(",", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                Dim nValue As Decimal
'                nValue = Convert.ToDecimal(strValue)
'                _tva = strValue
'                calcultTotal()

'            Catch ex As Exception

'            End Try
'        End Set
'    End Property

'    Public Property prixTotal() As String
'        Get
'            Return _prixTotal
'        End Get
'        Set(ByVal Value As String)
'            Try

'                Dim strValue As String = Value
'                strValue = strValue.Replace(".", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                strValue = Value.Replace(",", Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator)
'                Dim nValue As Decimal
'                nValue = Convert.ToDecimal(strValue)
'                _prixTotal = String.Format("{0:0.00}", nValue)
'            Catch ex As Exception

'            End Try
'        End Set
'    End Property

'    Public Property dateModificationAgent() As String
'        Get
'            Return _dateModificationAgent
'        End Get
'        Set(ByVal Value As String)
'            _dateModificationAgent = Value
'        End Set
'    End Property

'    Public Property dateModificationCrodip() As String
'        Get
'            Return _dateModificationCrodip
'        End Get
'        Set(ByVal Value As String)
'            _dateModificationCrodip = Value
'        End Set
'    End Property


'    Private Sub calcultTotal()
'        Try
'            Dim nqte As Decimal = Convert.ToDecimal(qte)
'            Dim nPU As Decimal = Convert.ToDecimal(prixUnitaire)
'            Dim ntva As Decimal = Convert.ToDecimal(tva)
'            Dim nPrixtotal As Decimal

'            nPrixtotal = nqte * nPU * (1 + (ntva / 100))
'            prixTotal = String.Format("{0:0.00}", nPrixtotal)

'        Catch ex As Exception

'        End Try
'    End Sub
'End Class
