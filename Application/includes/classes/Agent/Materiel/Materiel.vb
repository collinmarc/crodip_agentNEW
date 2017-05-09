Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable(), XmlInclude(GetType(Materiel))> _
Public MustInherit Class Materiel

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
    Protected _dateModificationAgent As String
    Protected _dateModificationCrodip As String
    Protected _etat As Boolean



    Sub New()
        _JamaisServi = False

    End Sub

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


    Public Property isSupprime() As Boolean
        Get
            Return _isSupprime
        End Get
        Set(ByVal Value As Boolean)
            _isSupprime = Value
        End Set
    End Property


    Public Property AgentSuppression() As String
        Get
            Return _AgentSuppression
        End Get
        Set(ByVal Value As String)
            _AgentSuppression = Value
        End Set
    End Property

    Public Property RaisonSuppression() As String
        Get
            Return _RaisonSuppression
        End Get
        Set(ByVal Value As String)
            _RaisonSuppression = Value
        End Set
    End Property
    Public Property DateSuppression() As String
        Get
            Return _DateSuppression
        End Get
        Set(ByVal Value As String)
            _DateSuppression = Value
        End Set
    End Property

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
    <XmlElement("DateActivation")>
    Public Property DateActivationS() As String
        Get
            Return CSDate.GetDateForWS(_DateActivation.GetValueOrDefault())
        End Get
        Set(ByVal Value As String)
            _DateActivation = Value
        End Set
    End Property
    Public Property dateDernierControle() As String
        Get
            Return _dateDernierControle
        End Get
        Set(ByVal Value As String)
            _dateDernierControle = Value
        End Set
    End Property
    Public Property dateModificationAgent() As String
        Get
            Return _dateModificationAgent
        End Get
        Set(ByVal Value As String)
            _dateModificationAgent = Value
        End Set
    End Property

    Public Property dateModificationCrodip() As String
        Get
            Return _dateModificationCrodip
        End Get
        Set(ByVal Value As String)
            _dateModificationCrodip = Value
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

    Public Overridable ReadOnly Property Libelle() As String
        Get
            Return "Matériel : " + numeroNational
        End Get
    End Property
    Public Overridable Function DeleteMateriel(ByVal pAgentSuppression As Agent, ByVal pRaison As String) As Boolean
        Return False
    End Function

    Public Overridable Function ActiverMateriel(ByVal pDateActivation As Date, ByVal pAgent As Agent) As Boolean
        Debug.Assert(Not CSDate.isDateNull(pDateActivation), "Date non nulle")
        Debug.Assert(pAgent IsNot Nothing, "Agent initialisé")
        Dim bReturn As Boolean
        Try
            JamaisServi = False
            etat = True
            DateActivation = pDateActivation
            dateDernierControle = pDateActivation

            bReturn = creerFichevieActivation(pAgent)
        Catch ex As Exception
            CSDebug.dispError("Materiel.ActiverMateriel ERR: " & ex.Message)
            bReturn = False

        End Try
        Return bReturn
    End Function 'ActiverMateriel

    Public MustOverride Function creerFichevieActivation(ByVal pAgent As Agent) As Boolean


End Class