Public Class ControleBancBuse
    Private _NumNatBuse As String
    Private _couleur As String
    Private _numero As Integer
    Private _pressionEtal As String
    Private _debitEtal As String
    Private _3bar_m1 As String
    Private _3bar_m2 As String
    Private _3bar_m3 As String
    Private _3bar_moy As String
    Private _3bar_ecart As String
    Private _3bar_Resultat As Boolean
    Private _3bar_pctEcart As String
    Private _3bar_pctTolerance As String
    Public Sub New()

    End Sub
    Public Sub New(pNum As String)
        numero = pNum
    End Sub

    Public Property NumNatBuse() As String
        Get
            Return _NumNatBuse
        End Get
        Set(ByVal Value As String)
            _NumNatBuse = Value
        End Set
    End Property
    Public Property Couleur() As String
        Get
            Return _couleur
        End Get
        Set(ByVal Value As String)
            _couleur = Value
            CalcTolérance()
        End Set
    End Property
    Public Property numero() As String
        Get
            Return _numero
        End Get
        Set(ByVal Value As String)
            _numero = Value
        End Set
    End Property
    Public Property pressionEtal() As String
        Get
            Return _pressionEtal
        End Get
        Set(ByVal Value As String)
            _pressionEtal = Value
        End Set
    End Property

    Public Property debitEtal() As String
        Get
            Return _debitEtal
        End Get
        Set(ByVal Value As String)
            _debitEtal = Value
        End Set
    End Property


    Public Property m1_3bar() As String
        Get
            Return _3bar_m1
        End Get
        Set(ByVal Value As String)
            _3bar_m1 = Value
        End Set
    End Property

    Public Property m2_3bar() As String
        Get
            Return _3bar_m2
        End Get
        Set(ByVal Value As String)
            _3bar_m2 = Value
        End Set
    End Property

    Public Property m3_3bar() As String
        Get
            Return _3bar_m3
        End Get
        Set(ByVal Value As String)
            _3bar_m3 = Value
        End Set
    End Property

    Public Property moy_3bar() As String
        Get
            Return _3bar_moy
        End Get
        Set(ByVal Value As String)
            _3bar_moy = Value
        End Set
    End Property

    Public Property ecart_3bar() As String
        Get
            Return _3bar_ecart
        End Get
        Set(ByVal Value As String)
            _3bar_ecart = Value
        End Set
    End Property

    Public Property resultat_3bar() As Boolean
        Get
            Return _3bar_Resultat
        End Get
        Set(ByVal Value As Boolean)
            _3bar_Resultat = Value
        End Set
    End Property
    Public Property pctEcart_3bar() As String
        Get
            Return _3bar_pctEcart
        End Get
        Set(ByVal Value As String)
            _3bar_pctEcart = Value
        End Set
    End Property
    Public Property pctTolerance_3bar() As String
        Get
            Return _3bar_pctTolerance
        End Get
        Set(ByVal Value As String)
            _3bar_pctTolerance = Value
        End Set
    End Property
    Public Sub calc_ecart_buse()
        ' Init
        Dim debitEtalonne As Double = 0
        Dim pressionEtalonnage As Double = 0
        Dim ecartAutorise_2bar As Double = 0
        Dim ecartAutorise_3bar As Double = 0
        Try
            ' On récupère les valeurs
            debitEtalonne = CType(Me.debitEtal, Double)
            pressionEtalonnage = CType(Me.pressionEtal, Double)
            ' On calcul l'écart à 3bar
            If (debitEtalonne * 3 ^ 0.5 / pressionEtalonnage ^ 0.5) < 1 Then
                ecartAutorise_3bar = 0.025
            Else
                ecartAutorise_3bar = debitEtalonne * 0.025 * 3 ^ 0.5 / pressionEtalonnage ^ 0.5
            End If
        Catch ex As Exception
            Console.Write("[Erreur] - Calcul Ecart : " & ex.Message.ToString & vbNewLine)
        End Try
        ' Affichage résultats
        'controleBanc_buse1_3bar_ecartAutorise.Text = Math.Round(ecartAutorise_2bar, 3)
        Me.ecart_3bar = Math.Round(ecartAutorise_3bar, 3)
    End Sub

    Public Sub SetBuse(pbuse As Buse)
        Me.NumNatBuse = pbuse.idCrodip
        Me.Couleur = pbuse.couleur
        Me.pressionEtal = "3"
        Me.debitEtal = pbuse.debitEtalonnage.ToString()
        calc_ecart_buse()

    End Sub
    Public Sub Calc()
        Dim dM1 As Decimal = 0
        Dim dM2 As Decimal = 0
        Dim dM3 As Decimal = 0
        Dim debitEtalonne As Decimal = 0
        Dim pressionEtalonnage As Decimal = 0
        Dim moyenne3bar As Decimal = 0
        Dim EcartAutorise As Decimal = 0

        If IsNumeric(m1_3bar) Then
            dM1 = CType(Replace(m1_3bar, ".", ","), Double)
        End If
        If IsNumeric(m2_3bar) Then
            dM2 = CType(Replace(m2_3bar, ".", ","), Double)
        End If
        If IsNumeric(m3_3bar) Then
            dM3 = CType(Replace(m3_3bar, ".", ","), Double)
        End If
        moy_3bar = Math.Round((dM1 + dM2 + dM3) / 3, 3).ToString("##0.000")

        If IsNumeric(Me.debitEtal) Then
            debitEtalonne = CType(Replace(debitEtal, ".", ","), Double)
        End If
        If IsNumeric(Me.pressionEtal) Then
            pressionEtalonnage = CType(Replace(pressionEtal, ".", ","), Double)
        End If
        If IsNumeric(Me.moy_3bar) Then
            moyenne3bar = CType(Replace(moy_3bar, ".", ","), Double)
        End If
        If IsNumeric(Me.ecart_3bar) Then
            EcartAutorise = CType(Replace(ecart_3bar, ".", ","), Double)
        End If

        'Calcul du Résulat
        Dim calc As Decimal = (debitEtalonne * (Math.Sqrt(3) / Math.Sqrt(pressionEtalonnage)))

        If Math.Abs(calc - moyenne3bar) > EcartAutorise Then
            Me.resultat_3bar = False
        Else
            Me.resultat_3bar = True

        End If
        '=-1+H18/(D18*(3^0.5/C18^0.5))
        Dim pct As Decimal = (-1 + (moyenne3bar / calc)) * 100
        pctEcart_3bar = "" + CStr(Math.Round(pct, 2)) + "%"
        'buse1_tab2_3bars = -1 + tmp_3bar_moyenne1 / (tmp_debit_etalon1 * (Sqrt(3) / Sqrt(tmp_pression_etalon1)))


    End Sub

    Private Sub CalcTolérance()

        If Couleur.ToUpper() = "Orange".ToUpper() Then
            pctTolerance_3bar = "6,28%"
        ElseIf Couleur.ToUpper() = "Jaune".ToUpper() Then
            pctTolerance_3bar = "3,09%"
        Else
            pctTolerance_3bar = "2,50%"
        End If

    End Sub
End Class
