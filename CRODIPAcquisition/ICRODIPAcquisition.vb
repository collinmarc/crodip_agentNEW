Public Interface ICRODIPAcquisition
    Function GetValues() As List(Of AcquisitionValue)
    Function GetNbNiveaux() As Integer
    Function GetNbBuses(pNiveau As Integer) As Integer
    Sub FTO_SaveData(plst As List(Of AcquisitionValue))
    Function clearResults() As Boolean
    Function getFichier() As String
    Sub setFichier(pFichier As String)
    Function getGestionDesNiveaux() As Boolean
    Sub setNbBusesParNiveau(pNbreBuses As Integer)

End Interface
