Imports System.Collections.Generic
<Serializable()> _
Public Class RelevePression833
    '    Implements ICloneable
    Public Enum TYPEPulve As Integer
        RAMPE = 0
        ARBOVITI = 1
    End Enum
    Private m_colNiveaux As List(Of RelevePression833Niveau)
    Private m_Type As CRODIP_ControlLibrary.ParamDiagCalc833
    Private m_PressionMano As Decimal
    Private m_PressionParDefaut As Boolean = False


    'Public Property ParamCalc833() As CRODIP_ControlLibrary.ParamDiagCalc833
    '    Get
    '        Return m_Type
    '    End Get
    '    Set(ByVal Value As CRODIP_ControlLibrary.ParamDiagCalc833)
    '        m_Type = Value
    '    End Set
    'End Property

    Public ReadOnly Property PressionMano() As Decimal
        Get
            Return m_PressionMano
        End Get
    End Property
    Public Sub SetPressionMano(ByVal Value As Decimal)
        m_PressionMano = Value
        For Each oNiveau As RelevePression833Niveau In m_colNiveaux
            oNiveau.SetPressionMano(m_PressionMano)
        Next
    End Sub
    Public Sub creerNiveaux(ByVal pnNiveau As Integer, ByVal pnTroncons As Integer, ByVal pPressionMano As Decimal)
        Dim oNiveau As RelevePression833Niveau
        If Not m_colNiveaux Is Nothing Then
            m_colNiveaux.Clear()
        End If
        m_colNiveaux = New List(Of RelevePression833Niveau)
        For i As Integer = 1 To pnNiveau

            oNiveau = New RelevePression833Niveau(i, pnTroncons, pPressionMano)
            m_colNiveaux.Add(oNiveau)
        Next
        SetPressionMano(pPressionMano)
    End Sub

    Public Sub New()
        creerNiveaux(1, 1, 0)
        SetPressionMano(0)
    End Sub
    'Public Sub New(ByVal pnbreNiveaux As Integer, ByVal pnbreTroncons As Integer, ByVal pPressionMano As Decimal)
    '    creerNiveaux(pnbreNiveaux, pnbreTroncons, pPressionMano)
    'End Sub
    Public Sub New(ByVal pnbreNiveaux As Integer, ByVal pnbreTroncons As Integer, ByVal pPressionMano As Decimal, pParam As CRODIP_ControlLibrary.ParamDiagCalc833)
        creerNiveaux(pnbreNiveaux, pnbreTroncons, pPressionMano)
        m_Type = pParam
    End Sub

    Public Function SetPressionLue(ByVal pNiveau As Integer, ByVal pTroncon As Integer, ByVal pPressionLue As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            m_colNiveaux(pNiveau - 1).SetPressionLue(pTroncon, pPressionLue)
            bReturn = True
        Catch ex As Exception
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function GetTroncon(ByVal pNiveau As Integer, ByVal pTroncon As Integer) As RelevePression833Troncon
        Dim oReturn As RelevePression833Troncon
        Try
            oReturn = m_colNiveaux(pNiveau - 1).GetTroncon(pTroncon - 1)
        Catch ex As Exception
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Function GetNiveau(ByVal pNiveau As Integer) As RelevePression833Niveau
        Dim oReturn As RelevePression833Niveau
        Try
            oReturn = m_colNiveaux(pNiveau - 1)
        Catch ex As Exception
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Function calcDefauts() As Boolean
        Dim bReturn As Boolean
        Dim oNiveau As RelevePression833Niveau
        'Parcours de différents niveau pour déclenter le calcul
        bReturn = False
        For Each oNiveau In m_colNiveaux
            oNiveau.calcDefauts()
        Next
        Return bReturn
    End Function

    Public Property PressionManoPourCalculDefaut() As Boolean

        Get
            Return m_PressionParDefaut
        End Get
        Set(ByVal Value As Boolean)
            m_PressionParDefaut = Value
        End Set
    End Property

    Public ReadOnly Property colNiveaux As List(Of RelevePression833Niveau)
        Get
            Return m_colNiveaux
        End Get
    End Property

    Public Function Result_Moyenne() As Decimal
        If colNiveaux.Count >= 1 Then
            Dim dPression As Decimal = 0
            For Each oNiveaux As RelevePression833Niveau In colNiveaux
                dPression = dPression + oNiveaux.MoyenneTousTroncons
            Next
            Return dPression / colNiveaux.Count
        Else
            Return 0
        End If
    End Function
    '''
    ''' Retourne l'écart Moyen par rapport à la Pression Mano
    '''
    Public Function Result_EcartBars() As Decimal
        Dim dReturn As Decimal
        If colNiveaux.Count >= 1 Then
            'Pour éviter le pbkl des arrondis on refait le calcul de la moyenne
            Dim dPression As Decimal = 0
            Dim n As Integer = 0
            For Each oNiveaux As RelevePression833Niveau In colNiveaux
                For Each oTroncons As RelevePression833Troncon In oNiveaux.colTroncons
                    dPression = dPression + oTroncons.PressionLue
                    n = n + 1
                Next
            Next
            'Moyenne des pression Lues
            If n <> 0 Then
                dPression = dPression / n
            End If
            dReturn = Math.Round((PressionMano - dPression), 3)
        Else
            dReturn = 0D
        End If
        Return dReturn
    End Function
    '''
    ''' Retourne le % d'écart  = (PressionMano-Moyenne des pression / Moyennes des pression)
    '''
    Public Function Result_EcartPct() As Decimal
        Dim dReturn As Decimal
        dReturn = 0
        If colNiveaux.Count >= 1 Then
            Try

                'Pour éviter le pbkl des arrondis on refait le calcul de la moyenne
                Dim dPression As Decimal = 0
                Dim n As Integer = 0
                For Each oNiveaux As RelevePression833Niveau In colNiveaux
                    For Each oTroncons As RelevePression833Troncon In oNiveaux.colTroncons
                        dPression = dPression + oTroncons.PressionLue
                        n = n + 1
                    Next
                Next
                dPression = dPression / n

                If dPression = 0 Then
                    dReturn = 100
                Else
                    dReturn = Math.Round(((PressionMano - dPression) / dPression) * 100, 2)
                End If
            Catch ex As Exception
                CSDebug.dispError("RelevePression833.Resut_Ecartpct ERR:" & ex.Message)
                dReturn = 0
            End Try

        Else
            dReturn = 0
        End If
        Return dReturn

    End Function
    '''
    ''' Renvoie Vrai si le tableau a un défaut d'écart (Ecart% > 15 ou Ecart% >10)
    '''
    Public Function Result_isDefautEcart() As Boolean
        If colNiveaux.Count >= 1 Then
            '            Return colNiveaux(0).isDefaultEcart(Me.TypePulverisateur)
            Dim bReturn As Boolean
            Dim dLimite As Decimal
            dLimite = CDec(m_Type.limite8333)

            bReturn = False
            If Math.Abs(Result_EcartPct()) > dLimite Then
                bReturn = True
            End If
            Return bReturn

        Else
            Return False
        End If
    End Function

    '''
    ''' Renvoie Vrai si le tableau a un défaut d'hétérogénéité => si un des tronçons a un défaut d'hétérogénéité
    '''
    Public Function Result_isDefautHeterogeneite() As Boolean
        If colNiveaux.Count >= 1 Then
            'Il y a un defaut si au moins un niveau a un defaut
            Dim bReturn As Boolean = False
            For Each oNiveau As RelevePression833Niveau In m_colNiveaux
                If oNiveau.isDefaultHeterogeneite(m_Type) Then
                    bReturn = True
                End If
            Next
            Return bReturn
        Else
            Return False
        End If
    End Function
    Public Function Result_PerteChargeMoyenne() As Decimal
        Return Result_EcartPct()
    End Function
    Public Function Result_PerteChargeMaxi() As Decimal
        If colNiveaux.Count >= 1 Then
            Dim dPerteDechargeMaxi As Decimal = 0
            For Each oNiveau As RelevePression833Niveau In m_colNiveaux
                If Math.Abs(oNiveau.EcartMax_pct) > Math.Abs(dPerteDechargeMaxi) Then
                    dPerteDechargeMaxi = oNiveau.EcartMax_pct
                End If
            Next
            Return dPerteDechargeMaxi
        Else
            Return 0
        End If
    End Function
    ' ''' <summary>
    ' ''' Dupplique 'object courant
    ' ''' </summary>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Function Clone2() As Object Implements ICloneable.Clone
    '    Dim oRV As New RelevePression833()
    '    oRV.ParamCalc833 = m_Type
    '    oRV.SetPressionMano(Me.PressionMano)
    '    oRV.PressionManoPourCalculDefaut = Me.PressionManoPourCalculDefaut
    '    For Each oNiveaux As RelevePression833Niveau In Me.colNiveaux
    '        oRV.colNiveaux.Add(oNiveaux.Clone())
    '    Next
    '    Return oRV
    'End Function
End Class
