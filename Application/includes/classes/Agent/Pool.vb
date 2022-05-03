Imports System.Xml.Serialization
Imports Crodip_agent

Public Class Pool
    Inherits Materiel
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _libelle As String
    Public Overrides Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property
    Private _nbPastillesVertes As Integer
    Public Property nbPastillesVertes() As Integer
        Get
            Return _nbPastillesVertes
        End Get
        Set(ByVal value As Integer)
            _nbPastillesVertes = value
        End Set
    End Property
    Private _idPC As Integer
    Public Property idPC() As Integer
        Get
            Return _idPC
        End Get
        Set(ByVal value As Integer)
            _idPC = value
        End Set
    End Property
    Private _idBanc As String
    Public Property idBanc() As String
        Get
            Return _idBanc
        End Get
        Set(ByVal value As String)
            _idBanc = value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property IDCRODIPPC() As String
        Get
            If idPC <> 0 Then
                Return AgentPCManager.getAgentPCById(idPC).idCrodip
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As String)

        End Set
    End Property
    Public Sub New()
        libelle = ""
        nbPastillesVertes = 0
    End Sub

    Public Overrides Function Fill(pcolName As String, pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = MyBase.Fill(pcolName, pValue)
            If Not bReturn Then
                bReturn = True
                Select Case pcolName.Trim().ToUpper()
                    Case "id".Trim().ToUpper()
                        Me.id = CInt(pValue)
                    Case "libelle".Trim().ToUpper()
                        Me.libelle = pValue.ToString()
                    Case "idPC".Trim().ToUpper()
                        Me.idPC = pValue
                    Case "idStructure".Trim().ToUpper()
                        Me.idStructure = pValue
                    Case "nbPastillesVertes".Trim().ToUpper()
                        Me.nbPastillesVertes = pValue
                    Case "idBanc".Trim().ToUpper()
                        Me.idBanc = pValue
                    Case Else
                        bReturn = False
                End Select
            End If
        Catch ex As Exception
            CSDebug.dispError("Pool.Fill ERR : " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function getAgentPC() As AgentPC
        Dim oReturn As AgentPC = Nothing
        Try
            If idPC <> 0 Then
                oReturn = AgentPCManager.getAgentPCById(idPC)
            End If
        Catch ex As Exception
            CSDebug.dispError("Pool.getPC ERR", ex)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Overrides Function creerFichevieActivation(pAgent As Agent) As Boolean
        Return False
    End Function
End Class
