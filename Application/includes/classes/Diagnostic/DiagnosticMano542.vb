Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports CRODIP_ControlLibrary
<Serializable()> _
Public Class DiagnosticMano542List

    Private _diagnosticMano542 As List(Of DiagnosticMano542)
    Private m_EcartMin As Decimal
    Private m_EcartMax As Decimal
    Private m_EcartMoy As Decimal
    Private m_Result As DiagnosticMano542.ERR542

    Sub New()
        _diagnosticMano542 = New List(Of DiagnosticMano542)
        m_EcartMax = Integer.MinValue
        m_EcartMin = Integer.MaxValue
        m_EcartMoy = 0
    End Sub
    <XmlIgnoreAttribute()>
    Public Property Liste() As List(Of DiagnosticMano542)
        Get
            Return _diagnosticMano542
        End Get
        Set(ByVal Value As List(Of DiagnosticMano542))
            _diagnosticMano542 = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property EcartMin() As Decimal
        Get
            Return m_EcartMin
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMin = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property EcartMax() As Decimal
        Get
            Return m_EcartMax
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMax = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property EcartMoy() As Decimal
        Get
            Return m_EcartMoy
        End Get
        Set(ByVal Value As Decimal)
            m_EcartMoy = Value
        End Set
    End Property
    <XmlIgnore()>
    Public Property Result() As DiagnosticMano542.ERR542
        Get
            Return m_Result
        End Get
        Set(ByVal Value As DiagnosticMano542.ERR542)
            m_Result = Value
        End Set
    End Property
    Public Property diagnosticMano542() As DiagnosticMano542()
        Get
            Return _diagnosticMano542.ToArray()
        End Get
        Set(ByVal Value As DiagnosticMano542())
            Throw New NotSupportedException("Setting the diagnosticMano542 property is not supported, needed for XML Serialize")
        End Set
    End Property
    ''' <summary>
    ''' Calcul de l'imprecision en utilisant le fichier de paramètre
    ''' </summary>
    ''' <param name="pParamCalc542"></param>
    ''' <remarks></remarks>
    Public Sub CalcImprecisionNew(pParamCalc542 As ParamDiagCalc542)
        'Calcul des Ecarts Min et Max et Moyen pour touts les Manos
        m_EcartMax = 0
        m_EcartMin = Integer.MaxValue
        m_EcartMoy = 0
        Dim bEcartConstant As Boolean = True
        Dim ecartConstant As Decimal = Decimal.MinValue

        'Dim oCalc542 As New CRODIP_ControlLibrary.ParanDiagCalc542()

        'Calcul du caractère constant de l'écart et de l'écart Min et Max, et Moyen
        For Each oMano542 As DiagnosticMano542 In _diagnosticMano542
            oMano542.calcEcarts()
            'Vérification de la constance de l'écart
            If ecartConstant = Decimal.MinValue Then
                ecartConstant = oMano542.Ecart
            End If
            If Math.Abs(oMano542.Ecart) <> Math.Abs(ecartConstant) Then
                bEcartConstant = False
            End If
            If Math.Abs(oMano542.Ecart) < Math.Abs(EcartMin) Then
                EcartMin = oMano542.Ecart
            End If
            If Math.Abs(oMano542.Ecart) > Math.Abs(EcartMax) Then
                EcartMax = oMano542.Ecart
            End If
            EcartMoy = EcartMoy + Math.Abs(oMano542.Ecart)
        Next
        EcartMoy = Math.Round(EcartMoy / _diagnosticMano542.Count, 2)

        'Détermination du type d'écart
        Dim TypeEcart As CRODIP_ControlLibrary.ParamDiagCalc542TypeEcart
        If bEcartConstant Then
            'Ecart constant
            TypeEcart = pParamCalc542.EcartConstant
        Else
            TypeEcart = pParamCalc542.EcartVariable
        End If

        'Pour Chaque Mano
        For Each oMano542 As DiagnosticMano542 In _diagnosticMano542
            'Par Défaut l'imprecission est OK
            oMano542.Erreur = Crodip_agent.DiagnosticMano542.ERR542.OK
            'Parcours des plages de pression du type d'écart (Variable ou constant)
            For Each oPlagePression As CRODIP_ControlLibrary.ParamDiagCalc542PlagePression In TypeEcart.colPression
                If oMano542.pressionPulved >= oPlagePression.Mini And oMano542.pressionPulved <= oPlagePression.Maxi Then
                    For Each oEcart As CRODIP_ControlLibrary.ParamDiagCalc542Ecart In oPlagePression.colEcart
                        Select Case oEcart.typeValeur
                            Case CRODIP_ControlLibrary.ParamDiagCalc542Ecart.ECARTVALEUR
                                If Math.Abs(oMano542.Ecart) >= oEcart.Mini And oMano542.Ecart <= oEcart.Maxi Then
                                    oMano542.Erreur = oEcart.Imprecision
                                End If
                            Case CRODIP_ControlLibrary.ParamDiagCalc542Ecart.ECARTPCT
                                If Math.Abs(oMano542.EcartPct) >= oEcart.Mini And oMano542.EcartPct <= oEcart.Maxi Then
                                    oMano542.Erreur = oEcart.Imprecision
                                End If
                        End Select
                    Next
                End If
            Next

        Next


        Dim nNbOk As Integer
        Dim nNbFaible As Integer
        Dim nNbForte As Integer

        nNbOk = 0
        nNbFaible = 0
        nNbForte = 0
        For Each oMano542 As DiagnosticMano542 In _diagnosticMano542
            If (oMano542.Erreur = Crodip_agent.DiagnosticMano542.ERR542.OK) Then
                nNbOk = nNbOk + 1
            End If
            If (oMano542.Erreur = Crodip_agent.DiagnosticMano542.ERR542.FAIBLE) Then
                nNbFaible = nNbFaible + 1
            End If
            If (oMano542.Erreur = Crodip_agent.DiagnosticMano542.ERR542.FORTE) Then
                nNbForte = nNbForte + 1
            End If
        Next
        If nNbOk = _diagnosticMano542.Count Then
            'Tout est OK
            Result = Crodip_agent.DiagnosticMano542.ERR542.OK
            Exit Sub
        End If

        '#16867 : Annullation de la régle 1.2.3 du document (FormulesCalcul542(COGNYX))
        'If nNbForte > 1 Then
        '    'Plus de une Forte => forte
        '    Result = Crodip_agent.DiagnosticMano542.ERR542.FORTE
        '    Exit Sub
        'End If
        If nNbForte > 0 Then
            'Aumoins une Forte => forte
            Result = Crodip_agent.DiagnosticMano542.ERR542.FORTE
            Exit Sub
        End If

        'IL nous reste des OK,  des faibles et 0 ou 1 forte

        If nNbForte = 0 Then
            Result = Crodip_agent.DiagnosticMano542.ERR542.FAIBLE
            Exit Sub
        End If

        '#16867 : Annullation de la régle 1.2.3 du document (FormulesCalcul542(COGNYX))
        'If nNbForte = 1 Then
        '    'On n'a une seule forte au milieu de OK ou FAIBLE
        '    If (Math.Abs(EcartMax - EcartMin) <= 0.0201) Or EcartMax <= 0.0501 Then
        '        Result = Crodip_agent.DiagnosticMano542.ERR542.FAIBLE
        '        Exit Sub
        '    Else
        '        Result = Crodip_agent.DiagnosticMano542.ERR542.FORTE
        '        Exit Sub
        '    End If
        'End If

    End Sub


End Class
<Serializable()> _
Public Class DiagnosticMano542
    Public Enum ERR542 As Integer
        OK = 0
        FAIBLE = 1
        FORTE = 2
    End Enum
    Private _id As Integer
    Private _idDiagnostic As String
    Private _pressionPulve As String
    Private _pressionControle As String
    Private _dateModificationAgent As String
    Private _dateModificationCrodip As String
    Private _ecart As Decimal
    Private _ecartPct As Decimal
    Private _ERR As ERR542


    '############################################################################

    Sub New()

    End Sub

    Sub New(ByVal pPressionManoPulve As String, ByVal pPressionManoControle As String)
        _pressionControle = pPressionManoControle
        _pressionPulve = pPressionManoPulve
        calcEcarts()
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

    Public Property pressionPulve() As String
        Get
            Return _pressionPulve
        End Get
        Set(ByVal Value As String)
            _pressionPulve = Value
        End Set
    End Property

    Public Property pressionControle() As String
        Get
            Return _pressionControle
        End Get
        Set(ByVal Value As String)
            _pressionControle = Value
        End Set
    End Property

    <XmlIgnoreAttribute()>
    Public ReadOnly Property pressionPulved() As Decimal
        Get
            Try
                Return CDec(StringToDouble(_pressionPulve))

            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property
    <XmlIgnoreAttribute()>
    Public ReadOnly Property pressionControled() As Decimal
        Get
            Try
                Return CDec(StringToDouble(_pressionControle))
            Catch ex As Exception
                Return 0
            End Try
        End Get
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
    Public Property Ecart() As Decimal
        Get
            Return _ecart
        End Get
        Set(ByVal Value As Decimal)
            _ecart = Value
        End Set
    End Property
    ''' <summary>
    ''' Ecart en % de la Pression Pulve
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <XmlIgnoreAttribute()>
    Public Property EcartPct() As Decimal
        Get
            Return _ecartPct
        End Get
        Set(ByVal Value As Decimal)
            _ecartPct = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property Erreur() As ERR542
        Get
            Return _ERR
        End Get
        Set(ByVal Value As ERR542)
            _ERR = Value
        End Set
    End Property
    Public Function Fill(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try

            Select Case pColName.Trim().ToUpper()
                Case "id".Trim().ToUpper()
                    Me.id = pColValue
                Case "idDiagnostic".Trim().ToUpper()
                    Me.idDiagnostic = pColValue.ToString()
                Case "pressionPulve".Trim().ToUpper()
                    Me.pressionPulve = pColValue
                Case "pressionControle".Trim().ToUpper()
                    Me.pressionControle = pColValue.ToString()
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
    ''' <summary>
    ''' Calcul des écarts (Valeurs et Pourcentage)
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub calcEcarts()
        Ecart = pressionPulved - pressionControled
        EcartPct = Math.Round((Math.Abs(Ecart) / pressionControled) * 100, 2) 'Pourcentage

    End Sub

    Public Sub calcimprecision2()
        'Calcul de l'écart
        calcEcarts()
        Dim Ecart_VAbsolue As Decimal

        Ecart_VAbsolue = Math.Abs(Ecart)

        '===================
        'Pression <=2 bars 
        '   0.1>err>0.2 => FAIBLE
        '   err>0.2 => FORTE
        'Pression > 2 bars
        '   %<10 =FAIBLE
        '   %>10 = FORTE
        '==================
        If pressionPulved <= 2 And Ecart_VAbsolue <= 0.1 Then
            Erreur = ERR542.OK
        End If
        If pressionPulved > 2 And Ecart_VAbsolue <= (pressionControled * 0.05) Then
            Erreur = ERR542.OK
        End If

        If pressionPulved <= 2 And (Ecart_VAbsolue > 0.1 And Ecart_VAbsolue <= 0.2) Then
            Erreur = ERR542.FAIBLE
        End If
        If pressionPulved > 2 And (Ecart_VAbsolue > (pressionControled * 0.05) And Ecart_VAbsolue <= (pressionControled * 0.1)) Then
            Erreur = ERR542.FAIBLE
        End If

        If pressionPulved <= 2 And (Ecart_VAbsolue > 0.2) Then
            Erreur = ERR542.FORTE
        End If
        If pressionPulved > 2 And (Ecart_VAbsolue > (pressionControled * 0.1)) Then
            Erreur = ERR542.FORTE
        End If

    End Sub

    Public Shared Function GetErreurLabel(ByVal pErr As ERR542) As String
        Dim strReturn As String
        strReturn = pErr.ToString()
        Select Case pErr
            Case ERR542.FAIBLE
                strReturn = "FAIBLE"
            Case ERR542.FORTE
                strReturn = "FORTE"
            Case ERR542.OK
                strReturn = "OK"
        End Select
        Return strReturn
    End Function


End Class
