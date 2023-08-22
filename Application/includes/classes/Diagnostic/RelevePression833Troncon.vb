<Serializable()>
Public Class RelevePression833Troncon
    Implements ICloneable

    Private m_Num As Integer
    Private m_NumCol As Integer
    Private m_PressionMano As Decimal
    Private m_PressionLue As Decimal
    Private m_EcartPression As Decimal
    Private m_EcartPressionPct As Decimal
    Private m_Heterogeneite As Decimal
    Private m_MoyenneAutresTroncons As Decimal
    Private m_EcartMoyenneAutresTroncons As Decimal

    'Private m_MoyenneTousTroncons As Decimal
    'Private m_EcartMoyenneTousTroncons As Decimal
    'Private m_EcartMoyenneTousTroncons_pct As Decimal

    Public Property Num() As Integer
        Get
            Return m_Num
        End Get
        Set(ByVal Value As Integer)
            m_Num = Value
        End Set
    End Property

    Public Property NumCol() As Integer
        Get
            Return m_NumCol
        End Get
        Set(ByVal Value As Integer)
            m_NumCol = Value
        End Set
    End Property
    Public ReadOnly Property PressionMano() As Decimal
        Get
            Return m_PressionMano
        End Get
    End Property

    Public Property PressionLue() As Decimal
        Get
            Return m_PressionLue
        End Get
        Set(ByVal Value As Decimal)
            m_PressionLue = Value
        End Set
    End Property
    Public Property EcartPression() As Decimal
        Get
            Return m_EcartPression
        End Get
        Set(ByVal Value As Decimal)
            m_EcartPression = Value
        End Set
    End Property
    Public Property EcartPressionpct() As Decimal
        Get
            Return m_EcartPressionPct
        End Get
        Set(ByVal Value As Decimal)
            m_EcartPressionPct = Value
        End Set
    End Property
    Public Property Heterogeneite() As Decimal
        Get
            Return m_Heterogeneite
        End Get
        Set(ByVal Value As Decimal)
            m_Heterogeneite = Value
        End Set
    End Property
    Public Property MoyenneAutresTroncons() As Decimal
        Get
            Return m_MoyenneAutresTroncons
        End Get
        Set(ByVal Value As Decimal)
            m_MoyenneAutresTroncons = Value
        End Set
    End Property
    Public Property EcartMoyenneAutresTroncons() As Decimal
        Get
            Return m_EcartMoyenneAutresTroncons
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMoyenneAutresTroncons = Value
        End Set
    End Property
    Private Sub New()
    End Sub
    Public Sub New(ByVal pNum As Integer, ByVal pPressionMano As Decimal)
        Num = pNum
        SetPressionMano(pPressionMano)
    End Sub

    Public Function SetPressionLue(ByVal pPressionLue As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            PressionLue = pPressionLue
            EcartPression = PressionMano - PressionLue
            '            EcartPressionpct = Math.Round((EcartPression * 100) / PressionMano, 2)
            If PressionLue <> 0 Then
                EcartPressionpct = Math.Round((EcartPression * 100) / PressionLue, 2)
            Else
                EcartPressionpct = 100
            End If
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function SetPressionMano(ByVal pPressionMano As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            m_PressionMano = pPressionMano
            'on recalcule les écarts de pression
            SetPressionLue(PressionLue)
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function SetNumTraca(ByVal pTraca As String) As Boolean
        Dim bReturn As Boolean
        Try
            NumTraca = pTraca
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    ''' <summary>
    ''' Calcul pour savoir s'il y a un defaut dans le niveau
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isDefaultHeterogeneite(pParamCalc As CRODIP_ControlLibrary.ParamDiagCalc833) As Boolean
        Dim bReturn As Boolean

        bReturn = False
        Dim dLimite As Decimal
        dLimite = CDec(pParamCalc.limite8332)

        If Math.Abs(Heterogeneite) > dLimite Then
            bReturn = True
        End If
        Return bReturn
    End Function

    Public Function Clone() As Object Implements ICloneable.Clone
        Dim oRV As New RelevePression833Troncon
        'Private m_Num As Integer
        'Private m_NumCol As Integer
        'Private m_PressionMano As Decimal
        'Private m_PressionLue As Decimal
        'Private m_EcartPression As Decimal
        'Private m_EcartPressionPct As Decimal
        'Private m_Heterogeneite As Decimal
        'Private m_MoyenneAutresTroncons As Decimal
        'Private m_EcartMoyenneAutresTroncons As Decimal

        oRV.Num = Me.Num
        oRV.NumCol = Me.NumCol
        oRV.SetPressionMano(Me.PressionMano)
        oRV.SetPressionLue(Me.PressionLue)
        oRV.EcartPression = Me.EcartPression
        oRV.EcartPressionpct = Me.EcartPressionpct
        oRV.Heterogeneite = Me.Heterogeneite
        oRV.MoyenneAutresTroncons = Me.MoyenneAutresTroncons
        oRV.EcartMoyenneAutresTroncons = Me.EcartMoyenneAutresTroncons
        oRV.NumTraca = Me.NumTraca


        Return oRV
    End Function
    Private _NumTraca As String
    Public Property NumTraca() As String
        Get
            Return _NumTraca
        End Get
        Set(ByVal value As String)
            _NumTraca = value
        End Set
    End Property
End Class
