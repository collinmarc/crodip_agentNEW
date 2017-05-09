Imports System.Xml.Serialization
<Serializable()>
Public Class ParamDiagCalc922
    ' <ParamDiagCalc922>
    '  <limitePctBuseUsees>33</limitePctBuseUsees>
    '  <pctToleranceDebitNominal>15</pctToleranceDebitNominal>
    '</ParamDiagCalc922>

    Private m_limitePctBuseUsees As String
    Private m_pctToleranceDebitNominal As String

    Public Property limitePctBuseUsees As String
        Get
            Return m_limitePctBuseUsees
        End Get
        Set(value As String)
            m_limitePctBuseUsees = value.Replace(".", ",")
        End Set
    End Property

    Public Property pctToleranceDebitNominal As String
        Get
            Return m_pctToleranceDebitNominal
        End Get
        Set(value As String)
            m_pctToleranceDebitNominal = value.Replace(".", ",")
        End Set
    End Property

End Class
