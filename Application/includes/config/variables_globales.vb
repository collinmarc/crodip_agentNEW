Public Module variables_globales
    Public Enum ALERTE As Integer
        NOIRE = -1
        ROUGE = 0
        ORANGE = 1
        JAUNE = 2
        NONE = 3
    End Enum
    Public Enum DiagMode As Integer
        CTRL_COMPLET = 0
        CTRL_CV = 1
        CTRL_VISU = 2
    End Enum
    Public Enum enumConclusionDiag
        OK
        OK_AVECMINEEUR
        NOK
        NOK_PRELIM
    End Enum

#Region "Variables de SESSION"
    ' StatusBar
    Public Statusbar As CSStatusbar
    ' Agent courant logguer
    Public agentCourant As New Agent
    ' Client actuellement sélectionné
    Public clientCourant As New Exploitation
    ' Pulvé actuellement sélectionné
    Public pulverisateurCourant As New Pulverisateur
    ' Diagnostic courant
    Public diagnosticCourant As Diagnostic
    Public arrBusesUsed() As String
    '    Public arrManoUsed(2) As Object
    'DiagnosticInitial = ControleComplet

#End Region

#Region "Formulaires en SESSION"
    ' Form parent
    Public globFormParent As parentContener
    ' Form principal "Accueil"
    Public globFormAccueil As accueil
    ' Diagnostic - Contrôle préliminaire
    Public globFormControlePreliminaire As controle_preliminaire
    ' Diagnostic - Contrôle préliminaire
    Public globFormDiagnostic As frmDiagnostique
    Public globFormToolBuses As tool_diagBuses
    ' Flag de connexion
    Public globConnectFlagOk As Object
    Public globConnectFlagNok As Object
    ' Gestion des manomètres
    'Public globFormGestionMano As gestion_manometres
    ' Gestion des buses
    'Public globFormGestionBusesEtalons As gestion_busesEtalons
#End Region

#Region "Base De Données"
    ' Objet de manipulation de la connexion à la base
    'Public bddConnection As New OleDb.OleDbConnection
    'Public bddConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & conf_bddPath & ";Jet OLEDB:System Database=" & conf_bddKeyPath & ";User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:Database Password=" & conf_bddPass & ""
    '   Public bddDLConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & conf_bddDLPath & ";Jet OLEDB:System Database=" & conf_bddKeyPath & ";User ID=" & conf_bddUser & ";Password=" & conf_bddPass & ";Jet OLEDB:Database Password=" & conf_bddDLPass & ""
    '    Public bddEtatConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & conf_bddEtatPath
#End Region


#Region "Objets Locaux"

    Structure objTarifCategorie
        Public id As Integer
        Public idStructure As String
        Public libelle As String
        Public dateModificationAgent As String
        Public dateModificationCrodip As String
    End Structure
    Structure objTarifPrestation
        Public id As Integer
        Public idCategorie As Integer
        Public idStructure As String
        Public description As String
        Public tarifHT As Double
        Public tarifTTC As Double
        Public tva As Double
        Public dateModificationAgent As String
        Public dateModificationCrodip As String
    End Structure
    Structure Acquiring2
        Public idBuse As Integer
        Public idNiveau As Integer
        Public debit As Double
        Public pression As Double
    End Structure

#End Region

End Module
