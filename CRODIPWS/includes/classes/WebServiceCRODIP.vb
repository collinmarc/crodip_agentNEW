Imports System.Net
Public Class WebServiceCRODIP
    '    Private Shared m_obj As WSCrodip
    Private Shared m_WS As WSCRODIP.CrodipServer
    Private Shared m_bInit As Boolean = False
    Public Shared ReadOnly Property URL As String
        Get
            Dim strUrl As String
            If My.Settings.WSCrodipProduction And Not GlobalsCRODIP.GLOB_ENV_DEBUG Then
                strUrl = My.Settings.WSCrodipURL
            Else
                strUrl = My.Settings.WSCrodipURLTEST
            End If
            Return strUrl
        End Get
    End Property
    Public Shared Sub Init()
        Try

            m_WS = New WSCRODIP.CrodipServer
            'm_WS.Timeout = 10000
            If Not String.IsNullOrEmpty(URL) Then
                m_WS.Url = URL
            End If
            'm_WS2 = New WSCrodip2.CrodipServerClient
            'm_WS2.Endpoint.Address = New System.ServiceModel.EndpointAddress(URL)
            m_bInit = True
        Catch ex As Exception
            CSDebug.dispError("WSCrodip.Init() ERR ", ex)
            m_bInit = False
        End Try

    End Sub
    Public Shared Sub Init(pUrl As String)

        Try
            m_WS = New WSCRODIP.CrodipServer
            If Not String.IsNullOrEmpty(pUrl) Then
                m_WS.Url = pUrl
            End If
            'm_WS2 = New WSCrodip2.CrodipServerClient
            'm_WS2.Endpoint.Address = New System.ServiceModel.EndpointAddress(pUrl)
            m_bInit = True
        Catch ex As Exception
            CSDebug.dispFatal("WSCrodip.Init() Error " & ex.Message)
            m_bInit = False
        End Try
    End Sub

    Public Shared Function getWS(Optional pbForce As Boolean = False) As WSCRODIP.CrodipServer
        If (Not m_bInit) Or (pbForce) Then
            Init()
        End If
        Return m_WS
    End Function

    Public Shared Function getWS(pUrl As String) As WSCRODIP.CrodipServer
        Init(pUrl)
        Return m_WS
    End Function
End Class
