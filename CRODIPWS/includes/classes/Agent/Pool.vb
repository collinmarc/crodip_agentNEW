Imports System.Xml.Serialization

Public Class Pool
    Inherits Materiel
    Private _libelle As String
    Public Overrides Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property

    Public Property idPool() As String
        Get
            Return idCrodip
        End Get
        Set(ByVal value As String)
            idCrodip = value
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
    Private _aidBanc As String
    Public Property aidbanc() As String
        Get
            Return _aidBanc
        End Get
        Set(ByVal value As String)
            _aidBanc = value
        End Set
    End Property
    Private _uidbanc As Integer
    Public Property uidbanc() As Integer
        Get
            Return _uidbanc
        End Get
        Set(ByVal value As Integer)
            _uidbanc = value
        End Set
    End Property
    '' Pour cohérence avec le serveur
    Public Property dateMiseEnService() As String
        Get
            Return dateActivationS
        End Get
        Set(ByVal Value As String)
            dateActivationS = Value
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
                    Case "libelle".Trim().ToUpper()
                        Me.libelle = pValue.ToString()
                    Case "idPool".Trim().ToUpper()
                        Me.idCrodip = pValue
                    Case "uidStructure".Trim().ToUpper()
                        Me.uidstructure = pValue
                    Case "nbPastillesVertes".Trim().ToUpper()
                        Me.nbPastillesVertes = pValue
                    Case "idbanc".Trim().ToUpper()
                        Me.aidbanc = pValue
                    Case "uidbanc".Trim().ToUpper()
                        Me.uidbanc = pValue
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


    Public Overrides Function creerFichevieActivation(pAgent As Agent) As Boolean
        Return False
    End Function
End Class
