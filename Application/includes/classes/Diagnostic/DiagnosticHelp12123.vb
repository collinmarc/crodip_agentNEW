Imports System.Web.Services
Imports System.Xml.Serialization
Imports System.Collections.Generic
'''
''' Classe de stockage des infos saisie de mesures pour l'item 12123
''' Voir fichier Calcul12123
<Serializable()>
<XmlInclude(GetType(DiagnosticHelp12123Mesure))> _
<XmlInclude(GetType(DiagnosticHelp12123MesuresTrtSem))> _
<XmlInclude(GetType(DiagnosticHelp12123Pompe))> _
<XmlInclude(GetType(DiagnosticHelp12123PompeTrtSem))> _
Public Class DiagnosticHelp12123
    Implements ICloneable
    Private m_id As String
    Private m_idDiag As String
    Private m_lstPompes As New List(Of DiagnosticHelp12123Pompe)
    Private m_fonctionnementDesbuses As String
    Private m_EcartMoyen As Decimal

    Public Property lstPompes() As List(Of DiagnosticHelp12123Pompe)
        Get
            Return m_lstPompes
        End Get
        Set(ByVal value As List(Of DiagnosticHelp12123Pompe))
            m_lstPompes = value
        End Set
    End Property
    Private m_lstPompesTrtSem As New List(Of DiagnosticHelp12123PompeTrtSem)
    Public Property lstPompesTrtSem() As List(Of DiagnosticHelp12123PompeTrtSem)
        Get
            Return m_lstPompesTrtSem
        End Get
        Set(ByVal value As List(Of DiagnosticHelp12123PompeTrtSem))
            m_lstPompesTrtSem = value
        End Set
    End Property

    
    Private m_Resultat As String
    Private m_bCalcule As Boolean = True

    Public Const DIAGITEM_ID As String = "help12123"
    Public LIMITE_ECART_MAJEUR As Decimal = 5

    Public Sub New()
        m_Resultat = ""
        m_fonctionnementDesbuses = ""
        m_EcartMoyen = 0
    End Sub

    Public Sub New(ByVal pId As String, ByVal pIdDiag As String)

        m_id = pId
        m_idDiag = pIdDiag
        m_Resultat = ""
        m_fonctionnementDesbuses = ""
        m_EcartMoyen = 0
    End Sub
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
    Public Property bCalcule As Boolean
        Get
            Return m_bCalcule
        End Get
        Set(ByVal Value As Boolean)
            m_bCalcule = Value
        End Set
    End Property
    Public Property Resultat As String

        Get
            Return m_Resultat
        End Get
        Set(value As String)
            m_Resultat = value
        End Set
    End Property
    Public ReadOnly Property Image() As Bitmap
        Get
            If Resultat = DiagnosticItem.EtatDiagItemOK Then
                Return Resources.PuceVerteT
            Else
                If Resultat = DiagnosticItem.EtatDiagItemMAJEUR Then
                    Return Resources.PuceRougeT
                Else
                    Return Resources.PuceGriseT
                End If
            End If
        End Get
    End Property
    Public ReadOnly Property LabelResultat() As String
        Get
            If Resultat = DiagnosticItem.EtatDiagItemOK Then
                Return "OK"
            Else
                If Resultat = DiagnosticItem.EtatDiagItemMAJEUR Then
                    Return "ERREUR"
                Else
                    Return ""
                End If
            End If
        End Get
    End Property

    Public Property fonctionnementBuses() As String
        Get
            Return m_fonctionnementDesbuses
        End Get
        Set(ByVal value As String)
            m_fonctionnementDesbuses = value
        End Set
    End Property
    Public Property EcartMoyen() As Decimal
        Get
            Return m_EcartMoyen
        End Get
        Set(ByVal value As Decimal)
            m_EcartMoyen = value
        End Set
    End Property

    <XmlIgnore>
    Public ReadOnly Property isInjection() As Boolean
        Get
            Return fonctionnementBuses.ToUpper().Contains("INJECTION")
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property isCuillere() As Boolean
        Get
            Return Not isInjection()
        End Get
    End Property


    Public Function Load() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try

            Dim oDiagItem As DiagnosticItem
            oDiagItem = DiagnosticItemManager.getDiagnosticItemById(id, idDiag)
            If oDiagItem.idItem = DIAGITEM_ID Then
                Try
                    bCalcule = False 'Au rechargement on désactive le calcul
                    Dim tabValues As String()
                    tabValues = oDiagItem.itemValue.Split("|")
                    Me.Resultat = Trim(tabValues(0))
                    Dim nbPompe As Integer
                    nbPompe = Trim(tabValues(1))
                    For nPompe As Integer = 1 To nbPompe
                        Dim oPompe As DiagnosticHelp12123Pompe
                        oPompe = New DiagnosticHelp12123Pompe(Me, nPompe)
                        oPompe.Load(idDiag, nPompe)
                        lstPompes.Add(oPompe)
                    Next
                    'Pompes traitement de semences
                    nbPompe = Trim(tabValues(2))
                    For nPompe As Integer = 1 To nbPompe
                        Dim oPompeTrtSem As DiagnosticHelp12123PompeTrtSem
                        oPompeTrtSem = New DiagnosticHelp12123PompeTrtSem(Me, nPompe)
                        oPompeTrtSem.Load(idDiag, nPompe)
                        lstPompesTrtSem.Add(oPompeTrtSem)
                    Next
                    fonctionnementBuses = Trim(tabValues(3))
                    bCalcule = True
                Catch ex As Exception
                    CSDebug.dispError("DiagnosticHelp12123.load ERR conversion (" & oDiagItem.itemValue & ") ERR " & ex.Message)
                End Try
            End If
            bReturn = True

        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123.Load ERR: " & ex.Message)
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
            'Sauvegarde des pompes
            For Each oPompe As DiagnosticHelp12123Pompe In lstPompes
                oPompe.idDiag = idDiag
                oPompe.Save(pStructureId, pAgentId)
            Next
            'Sauvegarde des pompesTrtSemences
            For Each oPompe As DiagnosticHelp12123PompeTrtSem In lstPompesTrtSem
                oPompe.idDiag = idDiag
                oPompe.Save(pStructureId, pAgentId)
            Next
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123.Save ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function
    Public Function ConvertToDiagnosticItem() As DiagnosticItem

        Dim oDiagItem As DiagnosticItem
        oDiagItem = New DiagnosticItem
        oDiagItem.id = id
        oDiagItem.idDiagnostic = idDiag
        oDiagItem.idItem = DIAGITEM_ID

        oDiagItem.itemValue = Trim(Me.Resultat) & "|" '0
        oDiagItem.itemValue = oDiagItem.itemValue & lstPompes.Count & "|" '1
        oDiagItem.itemValue = oDiagItem.itemValue & lstPompesTrtSem.Count & "|" '2
        oDiagItem.itemValue = Trim(fonctionnementBuses) & "|" '3

        Return oDiagItem
    End Function

    Private Function ConvertAttToString(pValue? As Decimal) As String
        If pValue.HasValue Then
            Return Trim(pValue.ToString())
        Else
            Return ""
        End If
    End Function
    Private Function ConvertStringToAtt(pValue As String) As Decimal
        If String.IsNullOrEmpty(pValue) Then
            Return Nothing
        Else
            Try
                Return CDec(pValue)
            Catch
                Return Nothing
            End Try
        End If
    End Function
    Public Function Delete() As Boolean
        Debug.Assert(Not String.IsNullOrEmpty(id), "Id must be set")
        Debug.Assert(Not String.IsNullOrEmpty(idDiag), "IdDiag must be set")
        Dim bReturn As Boolean
        Try
            bReturn = DiagnosticItemManager.delete(id, idDiag)
        Catch ex As Exception
            CSDebug.dispError("DiagnosticHelp12123.Delete ERR :" & ex.Message)
            bReturn = False
        End Try
        Return bReturn
    End Function

    Public Function hasValue() As Boolean
        Dim bReturn As Boolean
        bReturn = True
        Return bReturn

    End Function
    ''' <summary>
    ''' Calcule le défaut 12123
    ''' Prend en compte le cas des traitement de semences 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function calcule() As Boolean
        Dim bReturn As Boolean
        Try
            If m_bCalcule Then
                m_bCalcule = False
                Dim nbIncomplet As Integer = 0
                If (lstPompes.Count > 0) Then
                    For Each oPompe As DiagnosticHelp12123Pompe In lstPompes
                        If oPompe.Resultat <> DiagnosticItem.EtatDiagItemOK And oPompe.Resultat <> DiagnosticItem.EtatDiagItemMAJEUR Then
                            nbIncomplet = nbIncomplet + 1
                        End If
                    Next
                    If nbIncomplet > 0 Then
                        Resultat = ""
                    Else
                        Resultat = DiagnosticItem.EtatDiagItemOK
                        Dim Total As Decimal = 0
                        For Each oPompe As DiagnosticHelp12123Pompe In lstPompes
                            Total = Total + oPompe.EcartReglageMoyen
                            If oPompe.Resultat = DiagnosticItem.EtatDiagItemMAJEUR Then
                                Resultat = DiagnosticItem.EtatDiagItemMAJEUR
                            End If
                        Next
                        If lstPompes.Count > 0 Then
                            EcartMoyen = Math.Round(Total / lstPompes.Count, 3)
                        End If
                    End If
                End If
                If (lstPompesTrtSem.Count > 0) Then
                    For Each oPompe As DiagnosticHelp12123PompeTrtSem In lstPompesTrtSem
                        If oPompe.Resultat <> DiagnosticItem.EtatDiagItemOK And oPompe.Resultat <> DiagnosticItem.EtatDiagItemMAJEUR Then
                            nbIncomplet = nbIncomplet + 1
                        End If
                    Next
                    If nbIncomplet > 0 Then
                        Resultat = ""
                    Else
                        Resultat = DiagnosticItem.EtatDiagItemOK
                        Dim Total As Decimal = 0
                        For Each oPompe As DiagnosticHelp12123PompeTrtSem In lstPompesTrtSem
                            Total = Total + oPompe.EcartReglageMoyen
                            If oPompe.Resultat = DiagnosticItem.EtatDiagItemMAJEUR Then
                                Resultat = DiagnosticItem.EtatDiagItemMAJEUR
                            End If
                        Next
                        If lstPompesTrtSem.Count > 0 Then
                            EcartMoyen = Math.Round(Total / lstPompesTrtSem.Count, 3)
                        End If

                    End If
                End If
                m_bCalcule = True
            End If
            bReturn = True
        Catch ex As Exception
            bReturn = False
            CSDebug.dispError("DiagnosticHelp12123 ERR : " & ex.Message)


        End Try
        Return bReturn
    End Function

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim oXS As New XmlSerializer(Me.GetType())
        Dim oStream As New System.IO.MemoryStream()
        Dim oReturn As DiagnosticHelp12123

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
            CSDebug.dispError("Diagnostic12123.Clone ERR : " & ex.Message)
            oReturn = Nothing
        End Try
        Return oReturn
    End Function

    Public Function AjoutePompe() As DiagnosticHelp12123Pompe
        Dim oReturn As DiagnosticHelp12123Pompe

        oReturn = New DiagnosticHelp12123Pompe(Me, lstPompes.Count + 1)
        lstPompes.Add(oReturn)
        Return oReturn
    End Function
    Public Function AjoutePompeTrtSem() As DiagnosticHelp12123PompeTrtSem
        Dim oReturn As DiagnosticHelp12123PompeTrtSem

        oReturn = New DiagnosticHelp12123PompeTrtSem(Me, lstPompesTrtSem.Count + 1)
        lstPompesTrtSem.Add(oReturn)
        If isCuillere Then
            oReturn.lstMesures.Clear()
            oReturn.AjouteMesure()
        End If
        Return oReturn
    End Function
End Class
