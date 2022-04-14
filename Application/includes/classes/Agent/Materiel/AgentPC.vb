Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Data.Common
Imports Crodip_agent
Imports Microsoft.Win32

<Serializable(), XmlInclude(GetType(Banc))>
Public Class AgentPC
    Inherits Materiel

    Private _cleUtilisation As String
    Private _NumInterne As String


    Sub New()
        MyBase.New()

    End Sub
    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Public Property cleUtilisation() As String
        Get
            Return _cleUtilisation
        End Get
        Set(ByVal value As String)
            _cleUtilisation = value
        End Set
    End Property
    Public Property numInterne() As String
        Get
            Return _NumInterne
        End Get
        Set(ByVal value As String)
            _NumInterne = value
        End Set
    End Property

    Private _libelle As String
    Public Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property

    Public Overrides Function Fill(pName As String, pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            bReturn = MyBase.Fill(pName, pValue)
            If Not bReturn Then
                bReturn = True
                Select Case pName.Trim().ToUpper()
                    Case "id".Trim().ToUpper()
                        Me.id = CInt(pValue)
                    Case "cleUtilisation".Trim().ToUpper()
                        Me.cleUtilisation = pValue.ToString() 'Public marque As String
                    Case "numInterne".Trim().ToUpper()
                        Me.numInterne = pValue.ToString() 'Public modele As String
                    Case "libelle".Trim().ToUpper()
                        Me.libelle = pValue.ToString() 'Public modele As String
                    Case Else
                        bReturn = False
                End Select
            End If

        Catch ex As Exception
            CSDebug.dispError("AgentPC.Fill  (" + pName + "," + pValue.ToString + ") ERR : " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Overrides Function creerFichevieActivation(pAgent As Agent) As Boolean
        Return False
    End Function

    Public Function checkRegistry() As Boolean
        Dim bReturn As Boolean
        Try
            Const userRoot As String = "HKEY_CURRENT_USER"
            Const subkey As String = "CRODIP"
            Const keyName As String = userRoot & "\" & subkey

            If String.IsNullOrEmpty(Me.cleUtilisation) Then
                Dim g As New Guid()
                g = Guid.NewGuid()
                Me.cleUtilisation = g.ToString()
                Registry.SetValue(keyName, "POOL", Me.cleUtilisation)
                AgentPCManager.save(Me)

            End If


            Dim IDLu As String =
            Registry.GetValue(keyName, "POOL", "")
            If IDLu.Equals(Me.cleUtilisation) Then
                bReturn = True
            Else
                bReturn = False
#If DEBUG Then
                CSDebug.dispError("AgentPC.checkRegistry MauvaiseClé : (" & Me.cleUtilisation & "/" & IDLu)
#End If
            End If

        Catch ex As Exception
            CSDebug.dispError("AgentPC,CheckRegistry ERR", ex)
            bReturn = False
        End Try
        Return bReturn
    End Function

End Class