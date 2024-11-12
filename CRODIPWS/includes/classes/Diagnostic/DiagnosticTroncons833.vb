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
    Public Property Liste As List(Of DiagnosticTroncons833)
        Get
            Return _diagnosticTroncons833
        End Get
        Set(ByVal Value As List(Of DiagnosticTroncons833))
            _diagnosticTroncons833 = Value
        End Set
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
<Serializable()>
Public Class DiagnosticTroncons833
    Inherits DiagnosticObjDependant

    Private _id As Integer
    Private _idDiagnostic As String
    Private _idPression As String
    Private _idColumn As String
    Private _pressionSortie As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String
    Private _ManoCId As String

    'Attributs non sauvegard�s (uniquement utilis� pour contruire le rapport de synth�se
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
    Sub New(pDiag As Diagnostic)

        MyClass.New()
        idDiagnostic = pDiag.id
        uiddiagnostic = pDiag.uid
        aiddiagnostic = pDiag.aid
    End Sub


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
    <XmlElement("manocId")>
    Public Property ManocId() As String
        Get
            Return _ManoCId
        End Get
        Set(ByVal Value As String)
            _ManoCId = Value
        End Set
    End Property
    ''' <summary>
    ''' transformation du num�ro de colonne en nibeau troncon
    ''' </summary>
    ''' <param name="pNbreTroncon"></param>
    Public Sub CalcNiveauTroncons(pNbreTroncon As Integer)
        If Me.idColumn > 0 And pNbreTroncon > 0 Then
            nNiveau = Fix(idColumn / pNbreTroncon) + 1
            nTroncon = idColumn Mod pNbreTroncon
            If nTroncon = 0 Then
                nNiveau = nNiveau - 1
                nTroncon = pNbreTroncon
            End If
        End If
    End Sub

    Public Overrides Function Fill(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean = True
        Try
            If Not MyBase.Fill(pColName, pColValue) Then
                bReturn = True
                Select Case pColName.Trim().ToUpper()
                    Case "uiddiagnostic".Trim().ToUpper()
                        Me.uiddiagnostic = pColValue
                    Case "aiddiagnostic".Trim().ToUpper()
                        Me.aiddiagnostic = pColValue
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
                    Case "manocId".Trim().ToUpper()
                        Me.ManocId = pColValue.ToString()
                    Case Else
                        bReturn = False
                End Select
            End If
        Catch ex As Exception
            CSDebug.dispError("Diagnostictroncons833.Fill Err", ex)
            bReturn = False
        End Try

        Return bReturn
    End Function
End Class
