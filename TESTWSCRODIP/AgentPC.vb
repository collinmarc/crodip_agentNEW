Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Data.Common
Imports Microsoft.Win32

''' <summary>
''' AgentPC de TEST
''' </summary>
<Serializable()>
Public Class AgentPC

    Private _NumInterne As String
    Protected _numeroNational As String
    Protected _idCrodip As String
    Protected _idStructure As Integer
    Protected _isSupprime As Boolean
    Protected _AgentSuppression As String
    Protected _RaisonSuppression As String
    Protected _DateSuppression As String
    Protected _JamaisServi As Boolean
    Protected _DateActivation As Nullable(Of Date)
    Protected _dateDernierControle As String
    Protected _etat As Boolean
    Private _dateModificationAgent As Date
    Private _dateModificationCrodip As Date



    Sub New()
        dateModificationAgent = DateTime.MinValue
        dateModificationCrodip = DateTime.MinValue
        _numeroNational = ""
        _idCrodip = ""
        _idStructure = 0
        _isSupprime = False
        _AgentSuppression = ""
        _RaisonSuppression = ""
        _DateSuppression = ""
        _JamaisServi = False
        _DateActivation = Date.MinValue
        _dateDernierControle = ""
        _JamaisServi = False
        etat = True
        numInterne = ""
        cleUtilisation = ""
    End Sub
    Private _uid As Long
    Public Property uid() As Long
        Get
            Return _uid
        End Get
        Set(ByVal value As Long)
            _uid = value
        End Set
    End Property

    <XmlIgnore()>
    Public Property numeroNational() As String
        Get
            Return _numeroNational
        End Get
        Set(ByVal Value As String)
            _numeroNational = Value
        End Set
    End Property

    Public Property idCrodip() As String
        Get
            Return _idCrodip
        End Get
        Set(ByVal Value As String)
            _idCrodip = Value
        End Set
    End Property

    Public Property idStructure() As Integer
        Get
            Return _idStructure
        End Get
        Set(ByVal Value As Integer)
            _idStructure = Value
        End Set
    End Property
    Public Property cleUtilisation() As String
        Get
            Return _cleUtilisation
        End Get
        Set
            _cleUtilisation = Value
        End Set
    End Property

    Private _libelle As String
    Private _cleUtilisation As String

    Public Property libelle() As String
        Get
            Return _libelle
        End Get
        Set(ByVal value As String)
            _libelle = value
        End Set
    End Property
    Public Property etat() As Boolean
        Get
            Return _etat
        End Get
        Set(ByVal Value As Boolean)
            _etat = Value
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



    Public Property agentSuppression() As String
        Get
            Return _AgentSuppression
        End Get
        Set(ByVal Value As String)
            _AgentSuppression = Value
        End Set
    End Property

    Public Property raisonSuppression() As String
        Get
            Return _RaisonSuppression
        End Get
        Set(ByVal Value As String)
            _RaisonSuppression = Value
        End Set
    End Property
    Public Property dateSuppression() As String
        Get
            Return _DateSuppression
        End Get
        Set(ByVal Value As String)
            _DateSuppression = Value
        End Set
    End Property
    Public Property isSupprime() As Boolean
        Get
            Return _isSupprime
        End Get
        Set(ByVal Value As Boolean)
            _isSupprime = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property JamaisServi() As Boolean
        Get
            Return _JamaisServi
        End Get
        Set(ByVal Value As Boolean)
            _JamaisServi = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property DateActivation() As Date
        Get
            If _DateActivation.HasValue Then
                Return _DateActivation
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Date)
            _DateActivation = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property DateActivationS() As String
        Get
            Return _DateActivation
        End Get
        Set(ByVal Value As String)
            _DateActivation = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateDernierControleS() As String
        Get
            Return _dateDernierControle
        End Get
        Set(ByVal Value As String)
            _dateDernierControle = Value
        End Set
    End Property
    <XmlIgnoreAttribute()>
    Public Property dateDernierControle() As Date
        Get
            If Not String.IsNullOrEmpty(_dateDernierControle) Then
                Return DateTime.Parse(_dateDernierControle)
            Else
                Return Nothing
            End If
        End Get
        Set(ByVal Value As Date)
            _dateDernierControle = Value
        End Set
    End Property
    Public Function IsDateControle() As Boolean
        Dim bReturn As Boolean = False
        If _dateDernierControle = "" Then
            bReturn = False
        Else
            Try
                Dim dDate As Date = Date.Parse(_dateDernierControle)
                If dDate.Year > 1970 Then
                    bReturn = True
                End If
            Catch
                bReturn = False
            End Try
        End If
        Return bReturn
    End Function




    <XmlIgnoreAttribute()>
    Public Property dateModificationAgent() As Date
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As Date)
            _dateModificationAgent = Value
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
    <XmlIgnoreAttribute()>
    Public Property dateModificationCrodip() As DateTime
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal value As DateTime)
            _dateModificationCrodip = value
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

    Public Function Fill(pName As String, pValue As Object) As Boolean
        Dim bReturn As Boolean
        Try
            If Not bReturn Then
                bReturn = True
                Select Case pName.Trim().ToUpper()
                    Case "uid".Trim().ToUpper()
                        Me.uid = pValue.ToString()
                    Case "idCrodip".Trim().ToUpper()
                        Me.idCrodip = pValue.ToString()
                    Case "idstructure".Trim().ToUpper()
                        Me.idStructure = pValue.ToString()
                    Case "etat".Trim().ToUpper()
                        Me.etat = CType(pValue, Boolean)
                    Case "issupprime".Trim().ToUpper()
                        Me.isSupprime = CType(pValue, Boolean)
                    Case "issupprime".Trim().ToUpper()
                        Me.isSupprime = CType(pValue, Boolean)
                    Case "agentsuppression".Trim().ToUpper()
                        Me.AgentSuppression = pValue.ToString()
                    Case "raisonsuppression".Trim().ToUpper()
                        Me.RaisonSuppression = pValue.ToString()
                    Case "datesuppression".Trim().ToUpper()
                        Dim strDateMin As String = CSDate.ToCRODIPString("")
                        Dim strDateValue As String = CSDate.ToCRODIPString(pValue)
                        If strDateValue <> strDateMin And strDateValue <> "1899-12-30 00:00:00" Then
                            Me.DateSuppression = CSDate.ToCRODIPString(pValue).ToString()
                        Else
                            Me.DateSuppression = ""
                        End If

                    Case "jamaisServi".Trim().ToUpper()
                        Me.JamaisServi = pValue
                    Case "dateActivation".Trim().ToUpper()
                        Me.DateActivation = pValue

                    Case "idCrodip".Trim().ToUpper()
                        Me.idCrodip = CInt(pValue)
                    Case "numInterne".Trim().ToUpper()
                        Me.numInterne = pValue.ToString() 'Public modele As String
                    Case "libelle".Trim().ToUpper()
                        Me.libelle = pValue.ToString() 'Public modele As String
                    Case "dateModificationAgent".Trim().ToUpper()
                        Me.dateModificationAgent = CSDate.ToCRODIPString(pValue).ToString 'Public dateModificationAgent As String
                    Case "dateModificationCrodip".Trim().ToUpper()
                        Me.dateModificationCrodip = CSDate.ToCRODIPString(pValue).ToString 'Public dateModificationCrodip As String

                    Case Else
                        bReturn = False
                End Select
            End If

        Catch ex As Exception
            Console.Write("AgentPC.Fill  (" + pName + "," + pValue.ToString + ") ERR : " + ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function




End Class