Imports System.Xml.Serialization
Imports System.Collections.Generic
'''
''' Classe de stockage des infos saisie de mesures pour l'item 551
<Serializable()> _
Public Class DiagnosticHelp551
    Implements ICloneable
    Protected m_id As String
    Protected m_idDiag As String
    Protected m_distance1 As Decimal
    Protected m_temps1 As Decimal
    Protected m_vitesseLue1 As Decimal
    Protected m_Ecart1 As Decimal
    Protected m_vitesseReelle1 As Decimal
    Protected m_REsultat1 As String

    Protected m_distance2 As Decimal
    Protected m_temps2 As Decimal
    Protected m_vitesseLue2 As Decimal
    Protected m_Ecart2 As Decimal
    Protected m_vitesseReelle2 As Decimal
    Protected m_REsultat2 As String

    Protected m_ErreurMoyenne As Decimal
    Protected m_ErreurMoyenneSigned As Decimal?
    Protected m_REsultat As String
    Protected m_idItem As String

    Public Enum Help551Mode As Integer
        Mode551 = 1
        Mode5621 = 2
        Mode12323 = 3
    End Enum

    Public Sub New()
        m_idItem = "help551"
    End Sub
    Public Sub New(pMode As DiagnosticHelp551.Help551Mode)
        Select Case pMode
            Case Help551Mode.Mode551
                m_idItem = "help551"
            Case Help551Mode.Mode12323
                m_idItem = "help12323"
            Case Help551Mode.Mode5621
                m_idItem = "help5621"

        End Select
    End Sub

    Public Sub New(ByVal pId As String, ByVal pIdDiag As String)
        m_id = pId
        m_idDiag = pIdDiag
        m_idItem = "help551"
    End Sub
    Public Property iditem As String
        Get
            Return m_idItem
        End Get
        Set(ByVal Value As String)
            'm_idItem = Value
        End Set
    End Property
    Public Property id As String
        Get
            Return m_id
        End Get
        Set(ByVal Value As String)
            m_id = Value
        End Set
    End Property
    Public Property idDiag As String
        Get
            Return m_idDiag
        End Get
        Set(ByVal Value As String)
            m_idDiag = Value
        End Set
    End Property
    Public Property Distance1 As Decimal
        Get
            Return m_distance1
        End Get
        Set(ByVal Value As Decimal)
            m_distance1 = Value
        End Set
    End Property
    Public Property Temps1 As Decimal
        Get
            Return m_temps1
        End Get
        Set(ByVal Value As Decimal)
            m_temps1 = Value
        End Set
    End Property
    Public Property VitesseLue1 As Decimal
        Get
            Return m_vitesseLue1
        End Get
        Set(ByVal Value As Decimal)
            m_vitesseLue1 = Value
        End Set
    End Property

    Public Property Ecart1 As Decimal
        Get
            Return m_Ecart1
        End Get
        Set(ByVal Value As Decimal)
            m_Ecart1 = Value
        End Set
    End Property
    Public Property VitesseReelle1 As Decimal
        Get
            Return m_vitesseReelle1
        End Get
        Set(ByVal Value As Decimal)
            m_vitesseReelle1 = Value
        End Set
    End Property
    Public Property Resultat1 As String
        Get
            Return m_REsultat1
        End Get
        Set(ByVal Value As String)
            m_REsultat1 = Value
        End Set
    End Property
    Public Property Distance2 As Decimal
        Get
            Return m_distance2
        End Get
        Set(ByVal Value As Decimal)
            m_distance2 = Value
        End Set
    End Property
    Public Property Temps2 As Decimal
        Get
            Return m_temps2
        End Get
        Set(ByVal Value As Decimal)
            m_temps2 = Value
        End Set
    End Property
    Public Property VitesseLue2 As Decimal
        Get
            Return m_vitesseLue2
        End Get
        Set(ByVal Value As Decimal)
            m_vitesseLue2 = Value
        End Set
    End Property

    Public Property Ecart2 As Decimal
        Get
            Return m_Ecart2
        End Get
        Set(ByVal Value As Decimal)
            m_Ecart2 = Value
        End Set
    End Property
    Public Property VitesseReelle2 As Decimal
        Get
            Return m_vitesseReelle2
        End Get
        Set(ByVal Value As Decimal)
            m_vitesseReelle2 = Value
        End Set
    End Property
    Public Property Resultat2 As String
        Get
            Return m_REsultat2
        End Get
        Set(ByVal Value As String)
            m_REsultat2 = Value
        End Set
    End Property
    Public ReadOnly Property ErreurMoyenne As Decimal
        Get
            If ErreurMoyenneSigned.HasValue Then
                Return Math.Abs(ErreurMoyenneSigned.Value)
            Else
                Return 0
            End If
        End Get
        '        Set(ByVal Value As Decimal)
        'm_ErreurMoyenne = Value
        '    End Set
    End Property
    Public Property ErreurMoyenneSigned As Decimal?
        Get
            Return m_ErreurMoyenneSigned
        End Get
        Set(ByVal Value As Decimal?)
            m_ErreurMoyenneSigned = Value
        End Set
    End Property
    Public Property Resultat As String
        Get
            Return m_REsultat
        End Get
        Set(ByVal Value As String)
            m_REsultat = Value
        End Set
    End Property
    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            If oDiagItem.idItem = m_idItem Then
                Dim strValue As String()
                strValue = oDiagItem.itemValue.Split("|")
                Try
                    Distance1 = CDec(strValue(0))
                    Temps1 = CDec(strValue(1))
                    VitesseLue1 = CDec(strValue(2))
                    Distance2 = CDec(strValue(3))
                    Temps2 = CDec(strValue(4))
                    VitesseLue2 = CDec(strValue(5))
                    'Pour compatibilité avec les versions précédents ou la vitesse réelle n'était pas sauvegardée
                    If strValue.Length > 7 Then 'NB : le dernier element était vide
                        VitesseReelle1 = CDec(strValue(6))
                        VitesseReelle2 = CDec(strValue(7))
                        Ecart1 = CDec(strValue(8))
                        Ecart2 = CDec(strValue(9))
                        Resultat1 = strValue(10)
                        Resultat2 = strValue(11)
                        Resultat = strValue(12)
                        ErreurMoyenneSigned = CDec(strValue(13))
                    End If

                Catch ex As Exception
                    CSDebug.dispError("DiagnosticHelp551.load ERR conversion (" & oDiagItem.itemValue & ") ERR " & ex.Message)
                End Try
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp551.Load ERR: " & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function Save(ByVal pStructureId As String, ByVal pAgentId As String) As Boolean
        '        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pStructureId), "pStructureId must be set")
        Debug.Assert(Not String.IsNullOrEmpty(pAgentId), "pAgentId must be set")

        Dim bReturn As Boolean
        Try
            'Cet Object est transformé en DiagItem pour le Stockage
            Dim oDiagItem As DiagnosticItem
            Dim oDiagItemLu As DiagnosticItem
            oDiagItem = ConvertToDiagnosticItem()
            If Not String.IsNullOrEmpty(id) Then
                oDiagItemLu = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
                If Not String.IsNullOrEmpty(oDiagItemLu.id) Then
                    oDiagItem.id = oDiagItemLu.id
                    oDiagItem.idDiagnostic = oDiagItemLu.idDiagnostic
                    'oDiagItem.idItem
                    'oDiagItem.itemValue
                    oDiagItem.cause = oDiagItemLu.cause
                    oDiagItem.dateModificationAgent = oDiagItemLu.dateModificationAgent
                    oDiagItem.dateModificationCrodip = oDiagItemLu.dateModificationCrodip
                End If
            End If
            If String.IsNullOrEmpty(oDiagItem.id) Then
                id = DiagnosticItemManager.getNewId(pStructureId, pAgentId)
                oDiagItem.id = id
            End If
            Dim oCSDB As New CSDb(True)
            bReturn = DiagnosticItemManager.save(oCSDB, oDiagItem)
            oCSDB.free()
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp551.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = m_idItem
        oDiagItem.itemValue = Distance1 & "|" & Temps1 & "|" & VitesseLue1 & "|" & Distance2 & "|" & Temps2 & "|" & VitesseLue2 & "|" & VitesseReelle1 & "|" & m_vitesseReelle2 & "|" & Ecart1 & "|" & Ecart2 & "|" & Resultat1 & "|" & Resultat2 & "|" & Resultat & "|" & ErreurMoyenneSigned
        Return oDiagItem
    End Function
    Public Function Delete() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try
            bReturn = DiagnosticItemManager.delete(id, idDiag)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp551.Delete ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function HasValue() As Boolean
        Dim bReturn As Boolean
        If Distance1 + Temps1 + VitesseLue1 + Distance2 + Temps2 + VitesseLue2 <> 0 Then
            bReturn = True
        Else
            bReturn = False
        End If
        Return bReturn


    End Function
    Public Function calc(pTolerance As Decimal) As Boolean
        Dim bReturn As Boolean
        Try
            Resultat1 = ""
            If Temps1 <> 0 And Distance1 <> 0 Then
                VitesseReelle1 = Math.Round((Distance1 / Temps1) * 3.6, 2)
                If VitesseReelle1 <> 0 Then
                    If VitesseLue1 = VitesseReelle1 Then
                        Ecart1 = 0
                    Else
                        Ecart1 = Math.Round(Math.Abs(100 - (Math.Abs(VitesseLue1) / Math.Abs(VitesseReelle1) * 100)), 2)
                    End If
                    If Ecart1 > pTolerance Then
                        Resultat1 = "IMPRECISION"
                    Else
                        Resultat1 = "OK"
                    End If
                End If
            End If


            Resultat2 = ""
            If Temps2 <> 0 And Distance2 <> 0 Then
                VitesseReelle2 = Math.Round((Distance2 / Temps2) * 3.6, 2)
                If VitesseReelle2 <> 0 Then
                    If VitesseLue2 = VitesseReelle2 Then
                        Ecart2 = 0
                    Else
                        Ecart2 = Math.Round(Math.Abs(100 - (Math.Abs(VitesseLue2) / Math.Abs(VitesseReelle2) * 100)), 2)
                    End If
                    If Ecart2 > pTolerance Then
                        Resultat2 = "IMPRECISION"
                    Else
                        Resultat2 = "OK"
                    End If
                End If
            End If

            Dim VLueMoyenne As Decimal
            Dim VReelleMoyenne As Decimal
            If Not String.IsNullOrEmpty(Resultat1) And Not String.IsNullOrEmpty(Resultat2) Then
                VLueMoyenne = Math.Round((VitesseLue1 + VitesseLue2) / 2, 2)
                VReelleMoyenne = Math.Round((VitesseReelle1 + VitesseReelle2) / 2, 2)
                ErreurMoyenneSigned = Math.Round(((VLueMoyenne - VReelleMoyenne) / VReelleMoyenne) * 100, 2)
                'ErreurMoyenne = Math.Abs(ErreurMoyenneSigned.Value)
                If ErreurMoyenne > pTolerance Then
                    Resultat = "IMPRECISION"
                Else
                    Resultat = "OK"
                End If
            End If
            bReturn = True
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp551.Calc ERR" & ex.Message)
            bReturn = False
        End Try
        Return bReturn

    End Function
    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As DiagnosticHelp551

        Try


            ' Create a memory stream and a formatter.
            Dim ms As New System.IO.MemoryStream(1000)
            Dim bf As New System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(Nothing, _
                New System.Runtime.Serialization.StreamingContext(System.Runtime.Serialization.StreamingContextStates.Clone))
            ' Serialize the object into the stream.
            bf.Serialize(ms, Me)
            ' Position streem pointer back to first byte.
            ms.Seek(0, System.IO.SeekOrigin.Begin)
            ' Deserialize into another object.
            oReturn = bf.Deserialize(ms)
            ' release memory.
            ms.Close()
        Catch ex As Exception
            CSDebug.dispError("Diagnostichelp551.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function
End Class
