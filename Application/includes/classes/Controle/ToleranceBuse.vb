Imports System.Collections.Generic
Imports System.Xml.Serialization
<Serializable()>
Public Class lstToleranceBuse
    Inherits List(Of ToleranceBuse)

    Public Sub Serialize()
        Dim oSer As New System.Xml.Serialization.XmlSerializer(Me.GetType())
        If System.IO.File.Exists("./toleranceBuses.xml") Then
            System.IO.File.Delete("./toleranceBuses.xml")
        End If
        Dim oWr As New System.IO.StreamWriter("./toleranceBuses.xml")
        Try


            oSer.Serialize(oWr, Me)
            oWr.Close()
        Catch ex As Exception

        Finally
            oWr.Close()
        End Try

    End Sub
    Public Sub DeSerialize()
        Dim oRd As System.IO.StreamReader = Nothing
        Try
            oRd = New System.IO.StreamReader("./toleranceBuses.xml")
            Dim oSer As New System.Xml.Serialization.XmlSerializer(Me.GetType())
            Dim olst As New lstToleranceBuse
            olst = oSer.Deserialize(oRd)

            Me.Clear()
            Me.AddRange(olst)
            oRd.Close()
        Catch ex As Exception
            Add(New ToleranceBuse())
            Add(New ToleranceBuse())
            Add(New ToleranceBuse())
            Add(New ToleranceBuse())
            Add(New ToleranceBuse())
        Finally
            oRd.Close()

        End Try

    End Sub
End Class

''' <summary>
''' Class de calcul des % de tolérance
''' </summary>
''' <remarks></remarks>
''' 
<Serializable()>
Public Class ToleranceBuse
    Private m_Couleur As String
    Private m_toleranceMini As Decimal
    Private m_DebitMesure As Decimal
    Private m_toleranceMaxi As Decimal
    Private m_pctTolerance As Decimal

    Public Sub New()
        m_pctTolerance = 1.875 / 100
    End Sub
    ''' <summary>
    ''' Couleur
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Couleur As String
        Get
            Return m_Couleur
        End Get
        Set(ByVal value As String)
            m_Couleur = value
        End Set
    End Property
    ''' <summary>
    ''' Tolérance Mini (Calculée)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToleranceMini As Decimal
        Get
            Return m_toleranceMini
        End Get
        Set(ByVal value As Decimal)
            m_toleranceMini = value
        End Set
    End Property
    ''' <summary>
    ''' Tolérance Maxi (calculée)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ToleranceMaxi As Decimal
        Get
            Return m_toleranceMaxi
        End Get
        Set(ByVal value As Decimal)
            m_toleranceMaxi = value
        End Set
    End Property
    ''' <summary>
    ''' Debit Mesuré
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property debitMesure As Decimal
        Get
            Return m_DebitMesure
        End Get
        Set(ByVal value As Decimal)
            If value <> m_DebitMesure Then
                m_DebitMesure = value
                calcTolerance()
            End If
        End Set
    End Property
    ''' <summary>
    ''' Debit Mesuré
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property debitMesureAsString As String
        Get
            If m_DebitMesure = Decimal.MinValue Then
                Return ""
            Else
                Return m_DebitMesure.ToString()
            End If

        End Get
        Set(ByVal value As String)
            Dim dec As Decimal = convertValue(value)
            If dec <> m_DebitMesure Then
                m_DebitMesure = dec
                calcTolerance()
            End If
        End Set
    End Property
    ''' <summary>
    ''' Pourcentage de tolérance (par defaut 1.875%)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property pctTolerance As Decimal
        Get
            Return m_pctTolerance
        End Get
        Set(ByVal value As Decimal)
            If value <> m_pctTolerance Then
                If value > 1 Then
                    m_pctTolerance = value / 100
                Else
                    m_pctTolerance = value
                End If
                calcTolerance()
            End If
        End Set
    End Property
    ''' <summary>
    ''' Calcul des valeurs de tolérance Mini et Maxi
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub calcTolerance()
        ToleranceMini = Math.Round(debitMesure * (1 - pctTolerance), 3)
        ToleranceMaxi = Math.Round(debitMesure * (1 + pctTolerance), 3)
    End Sub

    Private Function convertValue(ByVal pValue As String) As Decimal
        Dim dec As Decimal
        pValue = pValue.Replace(".", ",")
        pValue = pValue.Replace(";", ",")
        pValue = pValue.Replace("?", ",")
        If IsNumeric(pValue) And Not String.IsNullOrEmpty(pValue) Then
            dec = Math.Round(CDec(pValue), 3)
        Else
            dec = Decimal.MinValue
        End If
        Return dec
    End Function
End Class
