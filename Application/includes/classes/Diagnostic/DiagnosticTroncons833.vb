Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Linq

<Serializable()>
Public Class DiagnosticTroncons833List

    Private _diagnosticTroncons833 As List(Of DiagnosticTroncons833)

    Sub New()
        _diagnosticTroncons833 = New List(Of DiagnosticTroncons833)
    End Sub
    <XmlIgnoreAttribute()>
    Public ReadOnly Property Liste As List(Of DiagnosticTroncons833)
        Get
            Return _diagnosticTroncons833
        End Get
        'Set(ByVal Value As List(Of DiagnosticMano542))
        '    _diagnosticTroncons833 = Value
        'End Set
    End Property
    ''' <summary>
    ''' Rend la liste des mesures pour une pression
    ''' </summary>
    ''' <param name="pPression"></param>
    ''' <returns></returns>
    <XmlIgnoreAttribute()>
    Public ReadOnly Property ListeparPression(pPression As String) As List(Of DiagnosticTroncons833)
        Get
            Return _diagnosticTroncons833.Where(Function(M)
                                                    Return M.idPression.Equals(pPression)
                                                End Function).ToList()
        End Get
        'Set(ByVal Value As List(Of DiagnosticMano542))
        '    _diagnosticTroncons833 = Value
        'End Set
    End Property

    Public Property diagnosticTroncons833() As DiagnosticTroncons833()
        Get
            Return _diagnosticTroncons833.ToArray()
        End Get
        Set(ByVal Value As DiagnosticTroncons833())
            _diagnosticTroncons833.Clear()
            For Each oDiagTroncons833 As DiagnosticTroncons833 In Value
                _diagnosticTroncons833.Add(oDiagTroncons833)
            Next
        End Set
    End Property
End Class
<Serializable()> _
Public Class DiagnosticTroncons833

    Private _id As Integer
    Private _idDiagnostic As String
    Private _idPression As String
    Private _idColumn As String
    Private _pressionSortie As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String

    'Attributs non sauvegardés (uniquement utilisé pour contruire le rapport de synthèse
    Private _EcartBar As Decimal
    Private _EcartPct As Decimal
    Private _MoyenneAutrePression As Decimal
    Private _HeterogeneiteBar As Decimal
    Private _Heterogeneitepct As Decimal
    Private _nNiveau As Integer
    Private _nTroncon As Integer


    '############################################################################

    Sub New()

    End Sub

    Sub New(pIdDiag As String, pidPression As String, pIdColumn As String, pPressionSortie As String)

        MyClass.New()
        idDiagnostic = pIdDiag
        idPression = pidPression
        idColumn = pIdColumn
        pressionSortie = pPressionSortie
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

    Public Property idPression() As String
        Get
            Return _idPression
        End Get
        Set(ByVal Value As String)
            _idPression = Value
        End Set
    End Property

    Public Property idColumn() As String
        Get
            Return _idColumn
        End Get
        Set(ByVal Value As String)
            _idColumn = Value
        End Set
    End Property

    Public Property pressionSortie() As String
        Get
            Return _pressionSortie
        End Get
        Set(ByVal Value As String)
            _pressionSortie = Value
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


    <XmlIgnoreAttribute()>
    Public Property EcartBar() As Decimal
        Get
            Return _EcartBar
        End Get
        Set(ByVal Value As Decimal)
            _EcartBar = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Ecartpct() As Decimal
        Get
            Return _EcartPct
        End Get
        Set(ByVal Value As Decimal)
            _EcartPct = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property HeterogeneiteBar() As Decimal
        Get
            Return _HeterogeneiteBar
        End Get
        Set(ByVal Value As Decimal)
            _HeterogeneiteBar = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property HeterogeneitePct() As Decimal
        Get
            Return _Heterogeneitepct
        End Get
        Set(ByVal Value As Decimal)
            _Heterogeneitepct = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property MoyenneAutrePression() As Decimal
        Get
            Return _MoyenneAutrePression
        End Get
        Set(ByVal Value As Decimal)
            _MoyenneAutrePression = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public Property nNiveau() As Integer
        Get
            Return _nNiveau
        End Get
        Set(ByVal Value As Integer)
            _nNiveau = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property nTroncon() As Integer
        Get
            Return _nTroncon
        End Get
        Set(ByVal Value As Integer)
            _nTroncon = Value
        End Set
    End Property
    ''' <summary>
    ''' transformation du numéro de colonne en nibeau troncon
    ''' </summary>
    ''' <param name="pNbreTroncon"></param>
    Public Sub CalcNiveauTroncons(pNbreTroncon As Integer)
        If Me.idColumn > 0 Then
            nNiveau = Fix(idColumn / pNbreTroncon) + 1
            nTroncon = idColumn Mod pNbreTroncon
            If nTroncon = 0 Then
                nNiveau = nNiveau - 1
                nTroncon = pNbreTroncon
            End If
        End If
    End Sub
    Public Function Fill(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try

            Select Case pColName.Trim().ToUpper()
                Case "id".Trim().ToUpper()
                    Me.id = pColValue
                Case "idDiagnostic".Trim().ToUpper()
                    Me.idDiagnostic = pColValue.ToString()
                Case "idPression".Trim().ToUpper()
                    Me.idPression = pColValue.ToString()
                Case "idColumn".Trim().ToUpper()
                    Me.idColumn = pColValue.ToString()
                Case "pressionSortie".Trim().ToUpper()
                    Me.pressionSortie = pColValue.ToString()
                Case "dateModificationAgent".Trim().ToUpper()
                    Me.dateModificationAgent = CSDate.ToCRODIPString(pColValue.ToString())
                Case "dateModificationCrodip".Trim().ToUpper()
                    Me.dateModificationCrodip = CSDate.ToCRODIPString(pColValue.ToString())

            End Select
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try

        Return bReturn
    End Function
End Class
