Public Class ControleManoDetail
    Private _type As String
    Private _point As String
    Private _pres_manoCtrl As String
    Private _pres_manoEtalon As String
    Private _incertitude As String
    Private _EMT As String
    Private _err_abs As String
    Private _err_fondEchelle As String
    Private _conformite As String

    Public Sub New(ptype As String, pPoint As String)
        _type = ptype
        _point = pPoint
    End Sub

    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal Value As String)
            _type = Value
        End Set
    End Property
    Public Property point() As String
        Get
            Return _point
        End Get
        Set(ByVal Value As String)
            _point = Value
        End Set
    End Property
    Public Property pres_manoCtrl() As String
        Get
            Return ConcertToDecimal(_pres_manoCtrl, 1)
        End Get
        Set(ByVal Value As String)
            _pres_manoCtrl = Value
        End Set
    End Property

    Public Property pres_manoEtalon() As String
        Get
            Return ConcertToDecimal(_pres_manoEtalon, 3)
        End Get
        Set(ByVal Value As String)
            _pres_manoEtalon = Value
        End Set
    End Property

    Public Property incertitude() As String
        Get
            Return ConcertToDecimal(_incertitude, 2)
        End Get
        Set(ByVal Value As String)
            _incertitude = Value
        End Set
    End Property

    Public Property EMT() As String
        Get
            Return ConcertToDecimal(_EMT, 1)
        End Get
        Set(ByVal Value As String)
            _EMT = Value
        End Set
    End Property

    Public Property err_abs() As String
        Get
            Return ConcertToDecimal(_err_abs, 2)
        End Get
        Set(ByVal Value As String)
            _err_abs = Value
        End Set
    End Property

    Public Property err_fondEchelle() As String
        Get
            Return ConcertToDecimal(_err_fondEchelle, 1)
        End Get
        Set(ByVal Value As String)
            _err_fondEchelle = Value
        End Set
    End Property

    Public Property conformite() As String
        Get
            Return _conformite
        End Get
        Set(ByVal Value As String)
            _conformite = Value
        End Set
    End Property

    Private Function calcEMT(pMano As ManometreControle) As Double
        Dim dReturn As Double
        Select Case pMano.fondEchelle
            Case "6"
                dReturn = 0.1
            Case "10"
                dReturn = 0.1
            Case "20"
                dReturn = 0.2
            Case "25"
                dReturn = 0.25
            Case Else
                dReturn = CDbl(Math.Round((Globals.StringToDouble(pMano.classe) * Globals.StringToDouble(pMano.fondEchelle) / 100), 2))
        End Select

        Return dReturn

    End Function


    Private Function ConcertToDecimal(pValue As String, nDec As Integer) As String
        If String.IsNullOrEmpty(pValue) Then
            Return ""
        Else
            Try
                Dim d As Single = Single.Parse(pValue.Replace(".", ","))
                Select Case nDec
                    Case 0
                        Return d.ToString("##0")
                    Case 1
                        Return d.ToString("##0.0")
                    Case 2
                        Return d.ToString("##0.00")
                    Case 3
                        Return d.ToString("##0.000")
                    Case 4
                        Return d.ToString("##0.0000")
                    Case Else
                        Return d.ToString()

                End Select

            Catch ex As Exception
                Return ""
            End Try

        End If
    End Function

End Class
