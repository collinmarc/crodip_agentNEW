Imports System.Xml.Serialization
<Serializable()>
Public Class ParamDiagCalc542
    'Private m_EcartVariable As ParamDiagCalc542TypeEcart
    'Private m_EcartConstant As ParamDiagCalc542TypeEcart
    Private m_lstEcart As New List(Of ParamDiagCalc542TypeEcart)

    <XmlIgnore()>
    Public ReadOnly Property EcartVariable As ParamDiagCalc542TypeEcart
        Get
            Dim oReturn As ParamDiagCalc542TypeEcart
            oReturn = Nothing
            For Each oParam As ParamDiagCalc542TypeEcart In LstEcarts
                If oParam.Type <> "CONSTANT" Then
                    oReturn = oParam
                    Exit For
                End If
            Next
            Return oReturn
        End Get
    End Property
    <XmlIgnore()>
    Public ReadOnly Property EcartConstant As ParamDiagCalc542TypeEcart
        Get
            Dim oReturn As ParamDiagCalc542TypeEcart
            oReturn = Nothing
            For Each oParam As ParamDiagCalc542TypeEcart In LstEcarts
                If oParam.Type = "CONSTANT" Then
                    oReturn = oParam
                    Exit For
                End If
            Next
            Return oReturn
        End Get
    End Property
    '<XmlArrayItem("TYPEECART")>
    'Ce tag XML Permet d'éliminer le niveau collection dans le fichier XML
    <XmlElement("TYPEECART")>
    Public Property LstEcarts As List(Of ParamDiagCalc542TypeEcart)
        Get
            Return m_lstEcart
        End Get
        Set(value As List(Of ParamDiagCalc542TypeEcart))
            m_lstEcart = value
        End Set
    End Property
    Public Sub FTO_init()
        LstEcarts.Clear()
        Dim oType As New ParamDiagCalc542TypeEcart()
        LstEcarts.Add(New ParamDiagCalc542TypeEcart("CONSTANT"))
        LstEcarts.Add(New ParamDiagCalc542TypeEcart("VARIABLE"))
    End Sub
End Class
