﻿Imports System.IO
Imports System.Reflection
Imports System.Xml.Serialization

Public Class ModuleAcq

    Public Shared ReadOnly Property XMLFILE() As String
        Get
            Return "./moduleDocumentaire/_parametres/ModulesAcquisision.xml"
        End Get
    End Property

    Private _Name As String
    Public Property Nom() As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
        End Set
    End Property

    Private _Assembly As String
    Public Property Assembly() As String
        Get
            Return _Assembly
        End Get
        Set(ByVal value As String)
            _Assembly = value
        End Set
    End Property

    Private _Main As String
    Public Property Main() As String
        Get
            Return _Main
        End Get
        Set(ByVal value As String)
            _Main = value
        End Set
    End Property
    Private _instance As ICRODIPAcquisition
    <XmlIgnore()>
    Public Property Instance() As ICRODIPAcquisition
        Get
            If _instance Is Nothing Then
                _instance = createModuleAcquisition()
            End If
            Return _instance
        End Get
        Set(ByVal value As ICRODIPAcquisition)
            _instance = value
        End Set
    End Property
    Public Shared Function ReadXML() As List(Of ModuleAcq)
        Dim oReturn As New List(Of ModuleAcq)
        Try
            Dim oParam As New List(Of ModuleAcq)
            Dim objStreamReader As New StreamReader(XMLFILE)
            Dim x As New XmlSerializer(oParam.GetType)
            oReturn = x.Deserialize(objStreamReader)
            objStreamReader.Close()
        Catch ex As Exception
            Debug.Print("ModuleAcq.readXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("ModuleAcq.readXML: " & ex.InnerException.Message)
            End If
        End Try
        Return oReturn
    End Function

    Public Shared Function WriteXML(pList As List(Of ModuleAcq)) As Boolean
        Dim bReturn As Boolean
        Dim objStreamWriter As StreamWriter = Nothing

        Try
            Dim oParam As New List(Of ModuleAcq)
            Dim ns As New XmlSerializerNamespaces()
            ns.Add("", "")

            objStreamWriter = New StreamWriter(XMLFILE)
            Dim x As New XmlSerializer(oParam.GetType)
            x.Serialize(objStreamWriter, pList, ns)
            objStreamWriter.Close()
            bReturn = True
        Catch ex As Exception
            Debug.Print("ModuleAcq.WriteXML: " & ex.Message)
            If ex.InnerException IsNot Nothing Then
                Debug.Print("ModuleAcq.WriteXML: " & ex.InnerException.Message)
            End If
            bReturn = False
            If objStreamWriter IsNot Nothing Then
                objStreamWriter.Close()
            End If


        End Try
        Return bReturn
    End Function

    Public Shared Function GetModule(pModuleName As String) As ModuleAcq

        Dim oLst As List(Of ModuleAcq)
        oLst = ModuleAcq.ReadXML()
        Dim oModule As ModuleAcq
        oModule = (From oMod As ModuleAcq In oLst
                   Where oMod.Nom = pModuleName
                   Select oMod).FirstOrDefault()

        Return oModule
    End Function
    Public Shared Function GetlstModules() As List(Of ModuleAcq)

        Dim oLst As List(Of ModuleAcq)
        oLst = ModuleAcq.ReadXML()

        Return oLst
    End Function

    Private Function createModuleAcquisition() As ICRODIPAcquisition

        Dim oAss As Assembly = System.Reflection.Assembly.LoadFrom(Assembly)
        Dim oT As Type = oAss.GetType(Main)

        Dim oMainAcq As Object = Activator.CreateInstance(oT)
        Dim mainMethod As MethodInfo = oT.GetMethod("CreateInstance")

        Dim oAcq As ICRODIPAcquisition = CType(mainMethod.Invoke(oMainAcq, Nothing), ICRODIPAcquisition)

        Me.Instance = oAcq
        Return oAcq
    End Function

    Public Function getValues() As List(Of AcquisitionValue)
        Dim oReturn As New List(Of AcquisitionValue)
        If Instance IsNot Nothing Then
            oReturn = Instance.GetValues()
        End If
        Return oReturn
    End Function
    Public Function getNbNiveaux() As Integer
        Dim oReturn As Integer = 0
        If Instance IsNot Nothing Then
            oReturn = Instance.GetNbNiveaux()
        End If
        Return oReturn
    End Function
    Public Function getNbBuses(pNiveau As Integer) As Integer
        Dim oReturn As Integer = 0
        If Instance IsNot Nothing Then
            oReturn = Instance.GetNbBuses(pNiveau)
        End If
        Return oReturn
    End Function

    Public Function clearResults() As Boolean
        Dim bReturn As Boolean = False
        If Instance IsNot Nothing Then
            bReturn = Instance.clearResults()
        End If
        Return bReturn
    End Function
End Class
