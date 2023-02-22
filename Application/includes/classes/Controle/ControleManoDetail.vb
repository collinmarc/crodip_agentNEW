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
    Private _FondEchelle As String

    Public Sub New(ptype As String, pPoint As String)
        type = ptype
        point = pPoint
        _conformite = ""
    End Sub
    Public Sub New(ptype As String, pPoint As String, pPression As Decimal, pMano As ManometreControle)
        type = ptype
        point = pPoint
        pres_manoCtrl = pPression
        pres_manoEtalon = ""
        _FondEchelle = pMano.fondEchelle
        calcEMT(pMano)
        _conformite = ""
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
            Return ConvertToDecimal(_pres_manoCtrl, 1)
        End Get
        Set(ByVal Value As String)
            If Value <> _pres_manoCtrl Then
                _pres_manoCtrl = Value
                calcErrAbs()
                calcErrFond()
            End If
        End Set
    End Property

    Public Property pres_manoEtalon() As String
        Get
            Return ConvertToDecimal(_pres_manoEtalon, 3)
        End Get
        Set(ByVal Value As String)
            If Value <> _pres_manoEtalon Then
                _pres_manoEtalon = Value
                calcErrAbs()
                calcErrFond()
            End If
        End Set
    End Property

    Public Property incertitude() As String
        Get
            Return ConvertToDecimal(_incertitude, 2)
        End Get
        Set(ByVal Value As String)
            _incertitude = Value
        End Set
    End Property

    Public Property EMT() As String
        Get
            Return ConvertToDecimal(_EMT, 1)
        End Get
        Set(ByVal Value As String)
            If Value <> EMT Then
                _EMT = Value
                calcConformite()
            End If
        End Set
    End Property

    Public Property err_abs() As String
        Get
            Return ConvertToDecimal(_err_abs, 2)
        End Get
        Set(ByVal Value As String)
            If Value <> err_abs Then
                _err_abs = Value
                calcConformite()
            End If
        End Set
    End Property

    Public Property err_fondEchelle() As String
        Get
            Return ConvertToDecimal(_err_fondEchelle, 1)
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

    Private Sub calcErrAbs()
        Dim dErr As Double
        If Not String.IsNullOrEmpty(Me.pres_manoCtrl) And Not String.IsNullOrEmpty(Me.pres_manoEtalon) Then
            dErr = Math.Round(Math.Abs(GlobalsCRODIP.StringToDouble(Me.pres_manoCtrl) - GlobalsCRODIP.StringToDouble(Me.pres_manoEtalon)), 3)
            err_abs = dErr.ToString("####0.000")
        Else
            err_abs = ""
        End If
    End Sub
    Private Sub calcErrFond()
        Dim dErr As Double
        If Not String.IsNullOrEmpty(pres_manoCtrl) And Not String.IsNullOrEmpty(pres_manoEtalon) And Not String.IsNullOrEmpty(_FondEchelle) Then
            dErr = Math.Round(Math.Abs(GlobalsCRODIP.StringToDouble(pres_manoCtrl) - GlobalsCRODIP.StringToDouble(pres_manoEtalon)) * 100 / GlobalsCRODIP.StringToDouble(_FondEchelle), 3)
            err_fondEchelle = dErr.ToString("####0.000")
        Else
            err_fondEchelle = ""
        End If
    End Sub
    Private Sub calcConformite()
        If Not String.IsNullOrEmpty(err_abs) And Not String.IsNullOrEmpty(EMT) Then
            If GlobalsCRODIP.StringToDouble(err_abs) > GlobalsCRODIP.StringToDouble(EMT) Then
                conformite = "0" ' NOK
            Else
                conformite = "1" 'OK
            End If
        Else
            conformite = ""
        End If
    End Sub
    Private Sub calcEMT(pMano As ManometreControle)
        Select Case pMano.fondEchelle
            Case "6"
                EMT = 0.1
            Case "10"
                EMT = 0.1
            Case "20"
                EMT = 0.2
            Case "25"
                EMT = 0.25
            Case Else
                EMT = CDbl(Math.Round((GlobalsCRODIP.StringToDouble(pMano.classe) * GlobalsCRODIP.StringToDouble(pMano.fondEchelle) / 100), 2))
        End Select


    End Sub



    Private Function ConvertToDecimal(pValue As String, nDec As Integer) As String
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
