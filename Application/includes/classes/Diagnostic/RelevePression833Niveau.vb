Imports System.Collections.Generic
<Serializable()> _
Public Class RelevePression833Niveau
    Implements ICloneable

    Private m_Num As Integer
    Private m_colTroncons As List(Of RelevePression833Troncon)
    Private m_EcartMax_pct As Decimal
    Private m_EcartMax As Decimal
    Private m_PressionMano As Decimal

    Private m_MoyenneTousTroncons As Decimal
    Private m_EcartMoyenneTousTroncons As Decimal
    Private m_EcartMoyenneTousTroncons_pct As Decimal


    Public Property Num() As Integer
        Get
            Return m_Num
        End Get
        Set(ByVal Value As Integer)
            m_Num = Value
        End Set
    End Property
    Public ReadOnly Property colTroncons As List(Of RelevePression833Troncon)
        Get
            Return m_colTroncons
        End Get
    End Property
    Public Property EcartMax_pct As Decimal
        Get
            Return m_EcartMax_pct
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMax_pct = Value
        End Set
    End Property

    Public Property EcartMax As Decimal
        Get
            Return m_EcartMax
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMax = Value
        End Set
    End Property
    Public ReadOnly Property PressionMano() As Decimal
        Get
            Return m_PressionMano
        End Get
    End Property
    Public Property MoyenneTousTroncons() As Decimal
        Get
            Return m_MoyenneTousTroncons
        End Get
        Set(ByVal Value As Decimal)
            m_MoyenneTousTroncons = Value
        End Set
    End Property
    Public Property EcartMoyenneTousTroncons() As Decimal
        Get
            Return m_EcartMoyenneTousTroncons
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMoyenneTousTroncons = Value
        End Set
    End Property
    Public Property EcartMoyenneTousTroncons_pct() As Decimal
        Get
            Return m_EcartMoyenneTousTroncons_pct
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMoyenneTousTroncons_pct = Value
        End Set
    End Property

    Public Sub New()
        Num = 0
        creerNTroncons(1, 0)
    End Sub
    Public Sub New(ByVal pNum As Integer, ByVal pNbTroncons As Integer, ByVal pPressionMano As Decimal)
        Num = pNum
        creerNTroncons(pNbTroncons, pPressionMano)
    End Sub

    Public Function creerNTroncons(ByVal pNbreTroncons As Integer, ByVal pPressionMano As Decimal) As Boolean
        Dim bReturn As Boolean
        Dim oTroncon As RelevePression833Troncon
        Dim nCol As Integer
        Try
            If Not m_colTroncons Is Nothing Then
                m_colTroncons.Clear()
            End If
            m_colTroncons = New List(Of RelevePression833Troncon)

            nCol = (Num - 1) * pNbreTroncons
            For i As Integer = 1 To pNbreTroncons
                nCol = nCol + 1
                oTroncon = New RelevePression833Troncon(i, pPressionMano)
                oTroncon.NumCol = nCol
                m_colTroncons.Add(oTroncon)
            Next
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function SetPressionLue(ByVal pTroncon As Integer, ByVal pPressionLue As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            m_colTroncons(pTroncon - 1).SetPressionLue(pPressionLue)

            bReturn = calcDefauts()
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function SetPressionMano(ByVal pPressionMano As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            m_PressionMano = pPressionMano
            For Each oTroncon As RelevePression833Troncon In m_colTroncons
                oTroncon.SetPressionMano(pPressionMano)
            Next
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function SetNumTraca(ByVal pTroncon As Integer, ByVal ptraca As String) As Boolean
        Dim bReturn As Boolean
        Try
            m_colTroncons(pTroncon - 1).SetNumTraca(ptraca)
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn

    End Function

    Public Function calcDefauts() As Boolean
        Dim bReturn As Boolean
        Dim oTroncon As RelevePression833Troncon
        Try

            'Calcul de l'hétérogénéité des pressions Lues (Hors la courante)
            If m_colTroncons.Count > 2 Then

                For Each oTroncon In m_colTroncons
                    CalcHeterogeneite(oTroncon)
                Next
            Else
                CalcHeterogeneite2Troncons()
            End If

            CalcEcartMoyenne()

            CalcEcartMax()

            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    '''
    ''' Calcul des écarts de pression moyen
    '''
    Private Function CalcEcartMoyenne() As Boolean
        Dim bReturn As Boolean
        Dim EcartMoyenne As Decimal
        Dim nTroncons As Integer
        Dim TotalPressionLue As Decimal
        Dim MoyennePressionLue As Decimal
        Dim oTroncon As RelevePression833Troncon
        Try

            'Calcul de la Moyenne des pressions Lues
            '=======================================
            nTroncons = 0
            TotalPressionLue = 0
            'Calcul de la pression totale Lue pour un niveau
            For Each oTroncon In m_colTroncons
                nTroncons = nTroncons + 1
                TotalPressionLue = TotalPressionLue + oTroncon.PressionLue
            Next
            'Moyenne des pressions = Pression Total / Nbre de troncons
            If nTroncons <> 0 Then
                MoyennePressionLue = TotalPressionLue / nTroncons
            End If

            'Ecart entre la moyenne des pressions lue et la pression Mano
            EcartMoyenne = Math.Abs(MoyennePressionLue - PressionMano)

            MoyenneTousTroncons = Math.Round(MoyennePressionLue, 2)
            EcartMoyenneTousTroncons = Math.Round(EcartMoyenne, 2)
            '            EcartMoyenneTousTroncons_pct = Math.Round((EcartMoyenne / PressionMano) * 100, 2)
            If MoyennePressionLue <> 0 Then
                EcartMoyenneTousTroncons_pct = Math.Round((EcartMoyenne / MoyennePressionLue) * 100, 2)
            End If

            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function

    '''
    ''' Calcul de l'écarts de pression maxi
    '''
    Private Function CalcEcartMax() As Boolean
        Dim bReturn As Boolean
        Dim oTroncon As RelevePression833Troncon
        Try

            'Recherche dans tous les tronçons du max de l'écart en pct
            '=======================================
            EcartMax_pct = 0
            EcartMax = 0
            '#16354 Lors de la comparaison entre l'écart et l'écart Max, on compare les valeurs absolues, mais on stocke le valeurs réelles.
            For Each oTroncon In m_colTroncons
                If Math.Abs(oTroncon.EcartPressionpct) > Math.Abs(EcartMax_pct) Then
                    EcartMax_pct = oTroncon.EcartPressionpct
                End If
                If Math.Abs(oTroncon.EcartPression) > Math.Abs(EcartMax) Then
                    EcartMax = oTroncon.EcartPression
                End If
            Next

            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Function CalcHeterogeneite(ByVal pTroncon As RelevePression833Troncon) As Boolean
        Dim bReturn As Boolean
        Dim oTroncon As RelevePression833Troncon
        Dim TotalPression As Decimal
        Dim nTroncons As Integer
        Dim MoyennePressionAutreTronçons As Decimal
        Dim EcartMoyenne As Decimal
        Try
            'Niveau à plus de 2 tronçons
            nTroncons = 0
            TotalPression = 0
            For Each oTroncon In m_colTroncons
                If oTroncon.Num <> pTroncon.Num Then
                    nTroncons = nTroncons + 1
                    TotalPression = TotalPression + oTroncon.PressionLue
                End If
            Next
            MoyennePressionAutreTronçons = TotalPression / nTroncons
            If MoyennePressionAutreTronçons <> 0 Then
                pTroncon.MoyenneAutresTroncons = Math.Round(MoyennePressionAutreTronçons, 2)
                EcartMoyenne = pTroncon.PressionLue - MoyennePressionAutreTronçons
                pTroncon.EcartMoyenneAutresTroncons = Math.Round(EcartMoyenne, 2)
                If MoyennePressionAutreTronçons <> 0 Then
                    pTroncon.Heterogeneite = Math.Round(EcartMoyenne / MoyennePressionAutreTronçons * 100, 2)
                End If
            End If

            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Private Function CalcHeterogeneite2Troncons() As Boolean
        Dim bReturn As Boolean
        Try
            'Niveau avec 2 Tronçons 
            Dim oTroncon1 As RelevePression833Troncon
            Dim oTroncon2 As RelevePression833Troncon
            Dim PressionMin As Decimal
            oTroncon1 = m_colTroncons(0)
            oTroncon2 = m_colTroncons(1)
            PressionMin = Math.Min(oTroncon1.PressionLue, oTroncon2.PressionLue)
            oTroncon1.MoyenneAutresTroncons = PressionMin
            oTroncon2.MoyenneAutresTroncons = PressionMin
            oTroncon1.EcartMoyenneAutresTroncons = Math.Abs(PressionMin - oTroncon1.PressionLue)
            oTroncon2.EcartMoyenneAutresTroncons = Math.Abs(PressionMin - oTroncon2.PressionLue)
            If oTroncon1.EcartMoyenneAutresTroncons <> 0 Then
                oTroncon1.Heterogeneite = Math.Round(oTroncon1.EcartMoyenneAutresTroncons / oTroncon1.MoyenneAutresTroncons * 100, 2)
            Else
                oTroncon1.Heterogeneite = 0

            End If
            If oTroncon2.EcartMoyenneAutresTroncons <> 0 Then
                oTroncon2.Heterogeneite = Math.Round(oTroncon2.EcartMoyenneAutresTroncons / oTroncon2.MoyenneAutresTroncons * 100, 2)
            Else
                oTroncon2.Heterogeneite = 0
            End If


            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    'Private Function CalcEcartPression(pTroncon As RelevePression833Troncon, pMoyennePression As Decimal) As Boolean
    '    Dim bReturn As Boolean
    '    Dim EcartMoyenne As Decimal
    '    Try

    '        If pMoyennePression <> 0 Then
    '            pTroncon.MoyenneTousTroncons = pMoyennePression
    '            EcartMoyenne = Math.Abs(pMoyennePression - pTroncon.PressionMano)
    '            pTroncon.EcartMoyenneTousTroncons = EcartMoyenne
    '            pTroncon.EcartMoyen_pct = Math.Round((EcartMoyenne / pTroncon.PressionMano) * 100, 2)
    '        End If

    '        bReturn = True
    '    Catch ex As Exception
    '        bReturn = False
    '    End Try
    '    Return bReturn
    'End Function
    Public Function GetTroncon(ByVal pTroncon As Integer) As RelevePression833Troncon
        Dim oReturn As RelevePression833Troncon
        Try
            oReturn = m_colTroncons(pTroncon)
        Catch ex As Exception
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
    ''' <summary>
    ''' Calcul pour savoir s'il y a un defaut dans le niveau
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function isDefaultHeterogeneite(ByVal pParamCalc As CRODIP_ControlLibrary.ParamDiagCalc833) As Boolean
        Dim bReturn As Boolean
        Dim oTroncon As RelevePression833Troncon

        bReturn = False
        'Defaut si au moins un troncon à un defaut d'hétérogénéité
        For Each oTroncon In m_colTroncons
            If oTroncon.isDefaultHeterogeneite(pParamCalc) Then
                bReturn = True
            End If
        Next
        Return bReturn
    End Function
    Public Function isDefaultEcart(ByVal pParamCalc As CRODIP_ControlLibrary.ParamDiagCalc833) As Boolean
        Dim bReturn As Boolean

        bReturn = False
        Dim dLimite As Decimal
        dLimite = CDec(pParamCalc.limite8333)
        If EcartMoyenneTousTroncons_pct > dLimite Then
            bReturn = True
        End If
        Return bReturn
    End Function
    ''' <summary>
    ''' Dupplique 'object courant
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Clone() As Object Implements ICloneable.Clone
        Dim oRV As New RelevePression833Niveau

        oRV.Num = Me.Num
        oRV.EcartMax_pct = Me.EcartMax_pct
        oRV.EcartMax = Me.EcartMax
        oRV.SetPressionMano(Me.PressionMano)
        oRV.MoyenneTousTroncons = Me.MoyenneTousTroncons
        oRV.EcartMoyenneTousTroncons = Me.EcartMoyenneTousTroncons
        oRV.EcartMoyenneTousTroncons_pct = Me.EcartMoyenneTousTroncons_pct


        For Each oTroncon As RelevePression833Troncon In Me.colTroncons
            oRV.colTroncons.Add(oTroncon.Clone())
        Next
        Return oRV
    End Function
End Class

