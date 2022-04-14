Imports System.Web.Services
Imports System.Xml.Serialization

<Serializable()>
Public Class FVAgentPC
    Inherits FVMateriel

    Sub New()
    End Sub
    Sub New(ByVal pAgent As Agent)

        idAgentControleur = pAgent.id
    End Sub




    Public Overrides Function Fill(ByVal pColName As String, ByVal pColValue As Object) As Boolean
        Dim bReturn As Boolean
        Try

            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("FVAgentPC.Fill Err " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function 'Fill

End Class