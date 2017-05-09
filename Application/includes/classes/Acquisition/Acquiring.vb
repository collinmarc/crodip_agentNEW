''' <summary>
''' classe d'acquisition
''' 
''' </summary>
''' <remarks></remarks>
Public Class Acquiring
    Public m_idBuse As Integer
    Public m_idNiveau As Integer
    Public m_debit As Double
    Public m_pression As Double


    Public Property idBuse As Integer
        Get
            Return m_idBuse
        End Get
        Set(ByVal value As Integer)
            m_idBuse = value
        End Set
    End Property

    Public Property idNiveau As Integer
        Get
            Return m_idNiveau
        End Get
        Set(ByVal value As Integer)
            m_idNiveau = value
        End Set

    End Property

    Public Property debit As Double
        Get
            Return m_debit
        End Get
        Set(ByVal value As Double)
            m_debit = value
        End Set
    End Property

    Public Property pression As Double
        Get
            Return m_pression
        End Get
        Set(ByVal value As Double)
            m_pression = value
        End Set
    End Property
    ''' <summary>
    ''' Initialisation de l'objet
    ''' </summary>
    ''' <param name="pName"></param>
    ''' <param name="pValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Fill(ByVal pName As String, ByVal pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            Select Case pName.ToUpper().Trim()
                Case "idBuse".ToUpper().Trim()
                    idBuse = pValue
                Case "idNiveau".ToUpper().Trim()
                    idNiveau = pValue
                Case "debit".ToUpper().Trim()
                    debit = pValue
                Case "pression".ToUpper().Trim()
                    pression = pValue
            End Select
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("Acquiring.Fill ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
End Class
