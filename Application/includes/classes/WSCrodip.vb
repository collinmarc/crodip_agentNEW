Imports System.Net
Public Class WSCrodip
    '    Private Shared m_obj As WSCrodip
    Private Shared m_WS As WSCrodip_prod.CrodipServer
    Private Shared m_WS2 As WSCrodip2.CrodipServerClient
    Private Shared m_bInit As Boolean = False
    Public Shared ReadOnly Property URL As String
        Get
            Dim strUrl As String
            If My.Settings.WSCrodipProduction And Not Globals.GLOB_ENV_DEBUG Then
                strUrl = My.Settings.WSCrodipURL
            Else
                strUrl = My.Settings.WSCrodipURLTEST
            End If
            Return strUrl
        End Get
    End Property
    Public Shared Sub Init()
        Try

            m_WS = New WSCrodip_prod.CrodipServer
            'm_WS.Timeout = 10000
            If Not String.IsNullOrEmpty(URL) Then
                m_WS.Url = URL
            End If
            m_WS2 = New WSCrodip2.CrodipServerClient
            m_WS2.Endpoint.Address = New System.ServiceModel.EndpointAddress(URL)
            m_bInit = True
        Catch ex As Exception
            CSDebug.dispError("WSCrodip.Init() Error " & ex.Message)
            m_bInit = False
        End Try

    End Sub
    Public Shared Sub Init(pUrl As String)

        Try
            m_WS = New WSCrodip_prod.CrodipServer
            If Not String.IsNullOrEmpty(pUrl) Then
                m_WS.Url = pUrl
            End If
            m_WS2 = New WSCrodip2.CrodipServerClient
            m_WS2.Endpoint.Address = New System.ServiceModel.EndpointAddress(pUrl)
            m_bInit = True
        Catch ex As Exception
            CSDebug.dispFatal("WSCrodip.Init() Error " & ex.Message)
            m_bInit = False
        End Try
    End Sub

    Public Shared Function getWS(Optional pbForce As Boolean = False) As WSCrodip_prod.CrodipServer
        If (Not m_bInit) Or (pbForce) Then
            Init()
        End If
        System.Net.ServicePointManager.Expect100Continue = My.Settings.Expect100Continue
        Return m_WS
    End Function

    Public Shared Function getWS(pUrl As String, Optional pbForce As Boolean = False) As WSCrodip_prod.CrodipServer
        If (Not m_bInit) Or (pbForce) Then
            Init(pUrl)
        End If
        Return m_WS
    End Function
    Public Shared Function getWS2(Optional pbForce As Boolean = False) As WSCrodip2.CrodipServerClient
        If (Not m_bInit) Or (pbForce) Then
            Init()
        End If
        Return m_WS2
    End Function

    Public Shared Function getWS2(pUrl As String, Optional pbForce As Boolean = False) As WSCrodip2.CrodipServerClient
        If (Not m_bInit) Or (pbForce) Then
            Init(pUrl)
        End If
        Return m_WS2
    End Function
End Class
