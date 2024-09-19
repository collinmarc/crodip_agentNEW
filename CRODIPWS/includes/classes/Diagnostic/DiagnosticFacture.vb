'Imports System.Web.Services
'Imports System.Xml.Serialization
'Imports System.Collections.Generic

'<Serializable(), XmlInclude(GetType(Diagnostic))> _
'Public Class DiagnosticFacture

'    Private _id As String
'    Private _factureReference As String
'    Private _factureDate As String
'    Private _factureTotal As String
'    Private _emetteurOrganisme As String
'    Private _emetteurOrganismeAdresse As String
'    Private _emetteurOrganismeCpVille As String
'    Private _emetteurOrganismeTelFax As String
'    Private _emetteurOrganismeSiren As String
'    Private _emetteurOrganismeTva As String
'    Private _emetteurOrganismeRcs As String
'    Private _recepteurRaisonSociale As String
'    Private _recepteurProprio As String
'    Private _recepteurCpVille As String
'    Private _dateModificationAgent As String
'    Private _dateModificationCrodip As String
'    Private _diagnosticFactureItems As List(Of DiagnosticFactureItem)


'    Sub New()

'    End Sub

'    Public Property id() As String
'        Get
'            Return _id
'        End Get
'        Set(ByVal Value As String)
'            _id = Value
'        End Set
'    End Property

'    Public Property factureReference() As String
'        Get
'            Return _factureReference
'        End Get
'        Set(ByVal Value As String)
'            _factureReference = Value
'        End Set
'    End Property

'    Public Property factureDate() As String
'        Get
'            Return _factureDate
'        End Get
'        Set(ByVal Value As String)
'            _factureDate = Value
'        End Set
'    End Property

'    Public Property factureTotal() As String
'        Get
'            Return _factureTotal
'        End Get
'        Set(ByVal Value As String)
'            _factureTotal = Value
'        End Set
'    End Property

'    Public Property emetteurOrganisme() As String
'        Get
'            Return _emetteurOrganisme
'        End Get
'        Set(ByVal Value As String)
'            _emetteurOrganisme = Value
'        End Set
'    End Property

'    Public Property emetteurOrganismeAdresse() As String
'        Get
'            Return _emetteurOrganismeAdresse
'        End Get
'        Set(ByVal Value As String)
'            _emetteurOrganismeAdresse = Value
'        End Set
'    End Property

'    Public Property emetteurOrganismeCpVille() As String
'        Get
'            Return _emetteurOrganismeCpVille
'        End Get
'        Set(ByVal Value As String)
'            _emetteurOrganismeCpVille = Value
'        End Set
'    End Property

'    Public Property emetteurOrganismeTelFax() As String
'        Get
'            Return _emetteurOrganismeTelFax
'        End Get
'        Set(ByVal Value As String)
'            _emetteurOrganismeTelFax = Value
'        End Set
'    End Property

'    Public Property emetteurOrganismeSiren() As String
'        Get
'            Return _emetteurOrganismeSiren
'        End Get
'        Set(ByVal Value As String)
'            _emetteurOrganismeSiren = Value
'        End Set
'    End Property

'    Public Property emetteurOrganismeTva() As String
'        Get
'            Return _emetteurOrganismeTva
'        End Get
'        Set(ByVal Value As String)
'            _emetteurOrganismeTva = Value
'        End Set
'    End Property

'    Public Property emetteurOrganismeRcs() As String
'        Get
'            Return _emetteurOrganismeRcs
'        End Get
'        Set(ByVal Value As String)
'            _emetteurOrganismeRcs = Value
'        End Set
'    End Property

'    Public Property recepteurRaisonSociale() As String
'        Get
'            Return _recepteurRaisonSociale
'        End Get
'        Set(ByVal Value As String)
'            _recepteurRaisonSociale = Value
'        End Set
'    End Property

'    Public Property recepteurProprio() As String
'        Get
'            Return _recepteurProprio
'        End Get
'        Set(ByVal Value As String)
'            _recepteurProprio = Value
'        End Set
'    End Property

'    Public Property recepteurCpVille() As String
'        Get
'            Return _recepteurCpVille
'        End Get
'        Set(ByVal Value As String)
'            _recepteurCpVille = Value
'        End Set
'    End Property

'    Public Property dateModificationAgent() As String
'        Get
'            Return _dateModificationAgent
'        End Get
'        Set(ByVal Value As String)
'            _dateModificationAgent = Value
'        End Set
'    End Property

'    Public Property dateModificationCrodip() As String
'        Get
'            Return _dateModificationCrodip
'        End Get
'        Set(ByVal Value As String)
'            _dateModificationCrodip = Value
'        End Set
'    End Property

'    Public Property diagnosticFactureItems() As List(Of DiagnosticFactureItem)
'        Get
'            Return _diagnosticFactureItems
'        End Get
'        Set(ByVal Value As List(Of DiagnosticFactureItem))
'            _diagnosticFactureItems = Value
'        End Set
'    End Property


'End Class
