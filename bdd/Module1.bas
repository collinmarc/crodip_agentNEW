Attribute VB_Name = "Module1"
Option Compare Database
Option Explicit

Public Sub updateDiagnostic()

Dim Db As DAO.Database
Set Db = CurrentDb

Db.Execute ("ALTER TABLE [Diagnostic] ADD organismeOriginePresId int")
Db.Execute ("ALTER TABLE [Diagnostic] Add organismeOriginePresNumero Text;")
Db.Execute ("ALTER TABLE [Diagnostic] ADD organismeOriginePresNom Text;")
Db.Execute ("ALTER TABLE [Diagnostic] ADD organismeOrigineInspNom Text;")
Db.Execute ("ALTER TABLE [Diagnostic] ADD organismeOrigineInspAgrement Text;")
Db.Execute ("ALTER TABLE [Diagnostic] ADD inspecteurOrigineId int;")
Db.Execute ("ALTER TABLE [Diagnostic] ADD inspecteurOrigineNom Text;")
Db.Execute ("ALTER TABLE [Diagnostic] ADD inspecteurOriginePrenom Text;")

End Sub


