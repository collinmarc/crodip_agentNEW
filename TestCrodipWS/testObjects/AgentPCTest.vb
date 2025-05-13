Imports System.Text
Imports CRODIPWS
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Microsoft.Win32

<TestClass()> Public Class AgentPCTest
    Inherits CRODIPTest

    <TestMethod()> Public Sub CRUD()

        Dim oAgentPC As New AgentPc()
        oAgentPC.cleUtilisation = "AQWZSX"
        oAgentPC.idPc = "123465"
        oAgentPC.dateDerniereSynchro = New Date(2025, 6, 7)

        Assert.IsTrue(AgentPcManager.Save(oAgentPC))
        Dim sIdPc As String = oAgentPC.idPc

        oAgentPC = AgentPcManager.GetByidPc("123465")
        Assert.AreEqual(sIdPc, oAgentPC.idPc)
        Assert.AreEqual("AQWZSX", oAgentPC.cleUtilisation)
        Assert.AreEqual(New Date(2025, 6, 7), oAgentPC.dateDerniereSynchro)

        oAgentPC.cleUtilisation = "AZERTYUIOP"
        oAgentPC.dateDerniereSynchro = New Date(2025, 6, 8)

        Assert.IsTrue(AgentPcManager.Save(oAgentPC))

        oAgentPC = AgentPcManager.GetByidPc("123465")
        Assert.AreEqual(sIdPc, oAgentPC.idPc)
        Assert.AreEqual("AZERTYUIOP", oAgentPC.cleUtilisation)
        Assert.AreEqual(New Date(2025, 6, 8), oAgentPC.dateDerniereSynchro)


    End Sub
    <TestMethod()> Public Sub GetPCListTest()
        'l'agent contient le pool
        Assert.IsNotNull(m_oAgent.oPool)
        Dim lstPc As List(Of AgentPc)
        lstPc = AgentPcManager.WSGetListByPool(m_oAgent.oPool)
        Assert.AreNotEqual(0, lstPc)
        For Each oAgentPc As AgentPc In lstPc
            Assert.AreEqual(m_oAgent.uidstructure, oAgentPc.uidstructure)
        Next


    End Sub
    <TestMethod()> Public Sub RegistryTest()
        'Sauvegarde du contenu de la base de registre
        Const RegistryPath As String = "HKEY_CURRENT_USER\CRODIP"
        Const subkey1 As String = "CRODIP"
        Const subkey2 As String = "PC"
        Dim PC_Origine As String = Registry.GetValue(RegistryPath, subkey2, "VIDE")
        Dim CLE_Origine As String = Registry.GetValue(RegistryPath, subkey1, "VIDE")
        Registry.SetValue(RegistryPath, subkey1, "")
        Registry.SetValue(RegistryPath, subkey2, "")

        Dim oAgentPc As New AgentPc()
        oAgentPc.idPc = "12345"
        oAgentPc.uidstructure = m_oStructure.uid
        AgentPcManager.Save(oAgentPc)

        Assert.IsTrue(AgentPcManager.IsRegistryVide())
        oAgentPc.SaveRegistry()
        Dim PC As String = Registry.GetValue(RegistryPath, subkey2, "VIDE")
        Dim CLE As String = Registry.GetValue(RegistryPath, subkey1, "VIDE")
        Assert.AreEqual(oAgentPc.idPc, PC)
        Assert.AreEqual(oAgentPc.cleUtilisation, CLE)

        Assert.IsFalse(AgentPcManager.IsRegistryVide())
        Dim oAgentPC2 As AgentPc
        oAgentPC2 = AgentPcManager.GetAgentPCFromRegistry()
        Assert.AreEqual(oAgentPc.idCrodip, oAgentPc.idCrodip)
        Assert.AreEqual(oAgentPc.cleUtilisation, oAgentPc.cleUtilisation)




        'Remise à l'état initial
        Registry.SetValue(RegistryPath, subkey2, PC_Origine)
        Registry.SetValue(RegistryPath, subkey1, CLE_Origine)

    End Sub



End Class