Public Interface ICRODIPAcquisition
    Function GetValues() As List(Of AcquisitionValue)
    Function GetNbNiveaux() As Integer
    Function GetNbBuses(pNiveau As Integer) As Integer


End Interface
