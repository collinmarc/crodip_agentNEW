Imports Crodip_agent
'Imports Microsoft.Office.Interop.Access
Imports System.Linq
Imports Microsoft.Data.Sqlite
Imports System.Data.Common
Imports System.Collections.Generic

Public Class BDDTransfert
    Private _bgw As System.ComponentModel.BackgroundWorker
    Private dbNameACCESS As String
    Public Property bgw() As System.ComponentModel.BackgroundWorker
        Get
            Return _bgw
        End Get
        Set(ByVal value As System.ComponentModel.BackgroundWorker)
            _bgw = value
        End Set
    End Property
    Public Sub New()
        If GlobalsCRODIP.GLOB_ENV_DEBUG = True Then
            dbNameACCESS = "crodip_agent_dev"
        Else
            dbNameACCESS = "crodip_agent"
        End If

    End Sub

    Public Sub TransfertStructureAgent()
        TransfertStructure()
        TransfertAgent()



    End Sub

    Public Sub TransfertStructure()
        Dim strSQL As String = "
INSERT INTO Structure (
                          id,
                          idCrodip,
                          nom,
                          type,
                          nomResponsable,
                          nomContact,
                          prenomContact,
                          adresse,
                          codePostal,
                          commune,
                          codeInsee,
                          telephoneFixe,
                          telephonePortable,
                          telephoneFax,
                          eMail,
                          commentaire,
                          dateModificationAgent,
                          dateModificationCrodip
                      )
                      VALUES (
                          @id,
                          @idCrodip,
                          @nom,
                          @type,
                          @nomResponsable,
                          @nomContact,
                          @prenomContact,
                          @adresse,
                          @codePostal,
                          @commune,
                          @codeInsee,
                          @telephoneFixe,
                          @telephonePortable,
                          @telephoneFax,
                          @eMail,
                          @commentaire,
                          @dateModificationAgent,
                          @dateModificationCrodip
                      );
"
        TransfertTable("Structure", strSQL)

    End Sub
    Public Sub TransfertAgent()
        Dim strSQL As String = "
INSERT INTO Agent (
                      Id,
                      numeroNational,
                      motDePasse,
                      nom,
                      prenom,
                      idStructure,
                      telephonePortable,
                      eMail,
                      dateCreation,
                      dateDerniereConnexion,
                      dateDerniereSynchro,
                      dateModificationAgent,
                      dateModificationCrodip,
                      versionLogiciel,
                      commentaire,
                      cleActivation,
                      isActif,
                      droitsPulves,
                      isGestionnaire,
                      SignatureElect,
                      statut
                  )
                  VALUES (
                      @Id,
                      @numeroNational,
                      @motDePasse,
                      @nom,
                      @prenom,
                      @idStructure,
                      @telephonePortable,
                      @eMail,
                      @dateCreation,
                      @dateDerniereConnexion,
                      @dateDerniereSynchro,
                      @dateModificationAgent,
                      @dateModificationCrodip,
                      @versionLogiciel,
                      @commentaire,
                      @cleActivation,
                      @isActif,
                      @droitsPulves,
                      @isGestionnaire,
                      @SignatureElect,
                      @statut
                  );
"
        TransfertTable("Agent", strSQL)

    End Sub


    Public Sub TransfertExploitationPulve()
        Dim strSQL As String =
                       "INSERT INTO Exploitation (
                             id,
                             numeroSiren,
                             codeApe,
                             raisonSociale,
                             nombreExploitant,
                             nomExploitant,
                             prenomExploitant,
                             adresse,
                             codePostal,
                             commune,
                             codeInsee,
                             telephoneFixe,
                             telephonePortable,
                             telephoneFax,
                             eMail,
                             surfaceAgricoleUtile,
                             isProdGrandeCulture,
                             isProdElevage,
                             isProdArboriculture,
                             isProdLegume,
                             isProdViticulture,
                             isProdAutre,
                             productionAutre,
                             idStructure,
                             isSupprime,
                             dateModificationCrodip,
                             dateModificationAgent,
                             dateDernierControle
                         )
                         VALUES (
                             @id,
                             @numeroSiren,
                             @codeApe,
                             @raisonSociale,
                             @nombreExploitant,
                             @nomExploitant,
                             @prenomExploitant,
                             @adresse,
                             @codePostal,
                             @commune,
                             @codeInsee,
                             @telephoneFixe,
                             @telephonePortable,
                             @telephoneFax,
                             @eMail,
                             @surfaceAgricoleUtile,
                             @isProdGrandeCulture,
                             @isProdElevage,
                             @isProdArboriculture,
                             @isProdLegume,
                             @isProdViticulture,
                             @isProdAutre,
                             @productionAutre,
                             @idStructure,
                             @isSupprime,
                             @dateModificationCrodip,
                             @dateModificationAgent,
                             @dateDernierControle
                         );
"

        TransfertTable("Exploitation", strSQL)

        strSQL = " 
INSERT INTO Pulverisateur (
                              id,
                              numeroNational,
                              type,
                              marque,
                              modele,
                              anneeAchat,
                              attelage,
                              capacite,
                              largeur,
                              nombrerangs,
                              largeurPlantation,
                              surfaceParAn,
                              nombreUtilisateurs,
                              isVentilateur,
                              isDebrayage,
                              isCuveRincage,
                              capaciteCuveRincage,
                              isRotobuse,
                              isCuveIncorporation,
                              isRinceBidon,
                              isBidonLaveMain,
                              isLanceLavage,
                              nombreBuses,
                              buseIsIso,
                              buseMarque,
                              buseType,
                              buseFonctionnement,
                              buseAge,
                              buseAngle,
                              manometreMarque,
                              manometreType,
                              manometreFondEchelle,
                              manometreDiametre,
                              manometrePressionTravail,
                              idStructure,
                              isSynchro,
                              isSupprime,
                              dateProchainControle,
                              dateModificationAgent,
                              dateModificationCrodip,
                              emplacementIdentification,
                              ancienIdentifiant,
                              isEclairageRampe,
                              isBarreGuidage,
                              isCoupureAutoTroncons,
                              isRincageAutoAssiste,
                              buseModele,
                              buseNbniveaux,
                              manometreNbniveaux,
                              manometreNbtroncons,
                              buseCouleur,
                              regulation,
                              regulationOptions,
                              modeUtilisation,
                              nombreExploitants,
                              controleEtat,
                              categorie,
                              pulverisation,
                              isAspirationExt,
                              isDispoAntiRetour,
                              isReglageAutoHauteur,
                              isFiltrationAspiration,
                              isFiltrationRefoulement,
                              isFiltrationTroncons,
                              isFiltrationBuses,
                              isPulveAdditionnel,
                              pulvePrincipalNumNat,
                              isRincagecircuit,
                              isPompesDoseuses,
                              nbPompesDoseuses,
                              numChassis
                          )
                          VALUES (
                              @id,
                              @numeroNational,
                              @type,
                              @marque,
                              @modele,
                              @anneeAchat,
                              @attelage,
                              @capacite,
                              @largeur,
                              @nombrerangs,
                              @largeurPlantation,
                              @surfaceParAn,
                              @nombreUtilisateurs,
                              @isVentilateur,
                              @isDebrayage,
                              @isCuveRincage,
                              @capaciteCuveRincage,
                              @isRotobuse,
                              @isCuveIncorporation,
                              @isRinceBidon,
                              @isBidonLaveMain,
                              @isLanceLavage,
                              @nombreBuses,
                              @buseIsIso,
                              @buseMarque,
                              @buseType,
                              @buseFonctionnement,
                              @buseAge,
                              @buseAngle,
                              @manometreMarque,
                              @manometreType,
                              @manometreFondEchelle,
                              @manometreDiametre,
                              @manometrePressionTravail,
                              @idStructure,
                              @isSynchro,
                              @isSupprime,
                              @dateProchainControle,
                              @dateModificationAgent,
                              @dateModificationCrodip,
                              @emplacementIdentification,
                              @ancienIdentifiant,
                              @isEclairageRampe,
                              @isBarreGuidage,
                              @isCoupureAutoTroncons,
                              @isRincageAutoAssiste,
                              @buseModele,
                              @buseNbniveaux,
                              @manometreNbniveaux,
                              @manometreNbtroncons,
                              @buseCouleur,
                              @regulation,
                              @regulationOptions,
                              @modeUtilisation,
                              @nombreExploitants,
                              @controleEtat,
                              @categorie,
                              @pulverisation,
                              @isAspirationExt,
                              @isDispoAntiRetour,
                              @isReglageAutoHauteur,
                              @isFiltrationAspiration,
                              @isFiltrationRefoulement,
                              @isFiltrationTroncons,
                              @isFiltrationBuses,
                              @isPulveAdditionnel,
                              @pulvePrincipalNumNat,
                              @isRincagecircuit,
                              @isPompesDoseuses,
                              @nbPompesDoseuses,
                              @numChassis
                          );
"
        TransfertTable("Pulverisateur", strSQL)
        strSQL = " 
INSERT INTO ExploitationTOPulverisateur (
                                            id,
                                            idPulverisateur,
                                            idExploitation,
                                            dateModificationAgent,
                                            dateModificationCrodip,
                                            isSupprimeCoProp
                                        )
                                        VALUES (
                                            @id,
                                            @idPulverisateur,
                                            @idExploitation,
                                            @dateModificationAgent,
                                            @dateModificationCrodip,
                                            @isSupprimeCoProp
                                        );

"

        TransfertTable("ExploitationToPulverisateur", strSQL)



    End Sub
    Public Sub TransfertAgentEquipementControle()

        Me.TransfertControleAgentBanc()
        Me.TransfertControleAgentMano()
        Me.TransfertControleBancMesure()
        Me.TransfertControleManoMesure()
        Me.TransfertControle_Regulier()
        TransfertIdentifiantPulverisateur()

    End Sub
    Public Sub TransfertAgentEquipement()

        Me.TransfertAgentBuseEtalon()
        Me.TransfertAgentManoControle()
        Me.TransfertAgentManoEtalon()
        Me.TransfertBancMesure()

    End Sub
    Public Sub transfertFicheVie()

        Me.TransfertFicheVieBancDeMesure()
        Me.TransfertFicheVieManometreControle()
        Me.TransfertFicheVieManometreEtalon()

    End Sub
    Public Sub TransfertBancMesure()

        Dim strSQL As String = "
INSERT INTO BancMesure (
                           id,
                           marque,
                           modele,
                           dateAchat,
                           idStructure,
                           dateDernierControle,
                           dateModificationAgent,
                           dateModificationCrodip,
                           etat,
                           isUtilise,
                           isSupprime,
                           nbControles,
                           nbControlesTotal,
                           agentSuppression,
                           raisonSuppression,
                           dateSuppression,
                           jamaisServi,
                           dateActivation,
                           ModuleAcquisition
                       )
                       VALUES (
                           @id,
                           @marque,
                           @modele,
                           @dateAchat,
                           @idStructure,
                           @dateDernierControle,
                           @dateModificationAgent,
                           @dateModificationCrodip,
                           @etat,
                           @isUtilise,
                           @isSupprime,
                           @nbControles,
                           @nbControlesTotal,
                           @agentSuppression,
                           @raisonSuppression,
                           @dateSuppression,
                           @jamaisServi,
                           @dateActivation,
                           @ModuleAcquisition
                       );


"
        TransfertTable("BancMesure", strSQL)
    End Sub
    Public Sub TransfertAgentManoEtalon()

        Dim strSQL As String = "
INSERT INTO AgentManoEtalon (
                                numeroNational,
                                idCrodip,
                                marque,
                                classe,
                                type,
                                fondEchelle,
                                idStructure,
                                isSynchro,
                                dateDernierControle,
                                dateModificationAgent,
                                dateModificationCrodip,
                                etat,
                                isUtilise,
                                isSupprime,
                                nbControles,
                                nbControlesTotal,
                                incertitudeEtalon,
                                agentSuppression,
                                raisonSuppression,
                                dateSuppression,
                                jamaisServi,
                                dateActivation
                            )
                            VALUES (
                                @numeroNational,
                                @idCrodip,
                                @marque,
                                @classe,
                                @type,
                                @fondEchelle,
                                @idStructure,
                                @isSynchro,
                                @dateDernierControle,
                                @dateModificationAgent,
                                @dateModificationCrodip,
                                @etat,
                                @isUtilise,
                                @isSupprime,
                                @nbControles,
                                @nbControlesTotal,
                                @incertitudeEtalon,
                                @agentSuppression,
                                @raisonSuppression,
                                @dateSuppression,
                                @jamaisServi,
                                @dateActivation
                            );

"
        TransfertTable("AgentManoEtalon", strSQL)


    End Sub
    Public Sub DeleteTable(pTable As String)

        CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        Dim oCSDBSQL As New CSDb(True)
        Dim ocmdSQL As Microsoft.Data.Sqlite.SqliteCommand
        ocmdSQL = oCSDBSQL.getConnection().CreateCommand


        ocmdSQL.CommandText = "DELETE FROM " & pTable

        ocmdSQL.ExecuteNonQuery()
        oCSDBSQL.free()


    End Sub
    Public Sub TransfertTable(pTable As String, pINSERTSQL As String, Optional pExcept As String = "")

        CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
        Dim oCSDB As New CSDb(False)
        Dim oCSDBACCESS As New OleDb.OleDbConnection(oCSDB.getConnectString(dbNameACCESS, CSDb.EnumDBTYPE.MSACCESS))
        oCSDBACCESS.Open()
        CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        Dim oCSDBSQL As New Microsoft.Data.Sqlite.SqliteConnection(oCSDB.getConnectString("crodip_agent", CSDb.EnumDBTYPE.SQLITE))
        oCSDBSQL.Open()
        Dim nMax As Integer = 100
        Dim ocmdACCESS As DbCommand
        Dim ocmdSQL As Microsoft.Data.Sqlite.SqliteCommand

        ocmdACCESS = oCSDBACCESS.CreateCommand
        ocmdSQL = oCSDBSQL.CreateCommand
        ocmdACCESS.CommandText = "SELECT Count(*) FROM " & pTable
        nMax = ocmdACCESS.ExecuteScalar()

        Try

            ocmdACCESS.CommandText = "SELECT * FROM " & pTable
            ocmdACCESS.CommandTimeout = 0

            ocmdSQL.CommandText = pINSERTSQL.ToUpper()
            ocmdSQL.CommandTimeout = 0

            ocmdSQL.Prepare()
            Dim oDR As DbDataReader
            oDR = ocmdACCESS.ExecuteReader()
            Dim n As Integer = 0
            While oDR.Read()
                n = n + 1
                If bgw.CancellationPending Then
                    Exit Sub
                End If
                bgw.ReportProgress(n * 100 / nMax, pTable & oDR.GetValue(0))
                ocmdSQL.Parameters.Clear()
                For i As Integer = 0 To oDR.FieldCount() - 1
                    If oDR.GetName(i).ToUpper() <> pExcept.ToUpper() Then
                        Dim Nom As String
                        Nom = oDR.GetName(i)
                        ocmdSQL.Parameters.AddWithValue("@" & Nom.ToUpper(), oDR.GetValue(i))
                    End If
                Next
                Try

                    ocmdSQL.ExecuteNonQuery()
                Catch ex As Exception
                    CSDebug.dispError(pTable & " [" & oDR.GetValue(0) & "] ERR :", ex)
                End Try

            End While
            oDR.Close()
        Catch ex As Exception
            CSDebug.dispError(pTable & " ERR :", ex)
        End Try

        oCSDBACCESS.Close()
        oCSDBSQL.Close()


    End Sub
    Public Sub TransfertTable2(pTable As String, pINSERTSQL As String, Optional pExcept As String = "")

        CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
        Dim oCSDB As New CSDb(False)
        Dim oCSDBACCESS As New OleDb.OleDbConnection(oCSDB.getConnectString(dbNameACCESS, CSDb.EnumDBTYPE.MSACCESS))
        oCSDBACCESS.Open()
        CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        Dim oCSDBSQL As New Microsoft.Data.Sqlite.SqliteConnection(oCSDB.getConnectString("crodip_agent", CSDb.EnumDBTYPE.SQLITE))
        oCSDBSQL.Open()
        Dim nMax As Integer = 100
        Dim ocmdACCESS As DbCommand
        Dim ocmdSQL As Microsoft.Data.Sqlite.SqliteCommand

        ocmdACCESS = oCSDBACCESS.CreateCommand
        ocmdSQL = oCSDBSQL.CreateCommand
        ocmdACCESS.CommandText = "SELECT Count(*) FROM " & pTable
        nMax = ocmdACCESS.ExecuteScalar()

        Try

            ocmdACCESS.CommandText = "SELECT * FROM " & pTable
            ocmdACCESS.CommandTimeout = 0

            ocmdSQL.CommandText = pINSERTSQL.ToUpper()
            ocmdSQL.CommandTimeout = 0

            ocmdSQL.Prepare()
            Dim oDR As DbDataReader
            oDR = ocmdACCESS.ExecuteReader()
            Dim n As Integer = 0
            While oDR.Read()
                n = n + 1
                If bgw.CancellationPending Then
                    Exit Sub
                End If
                bgw.ReportProgress(n * 100 / nMax, pTable & oDR.GetValue(0))
                ocmdSQL.Parameters.Clear()
                For i As Integer = 0 To oDR.FieldCount() - 1
                    If Not oDR.GetName(i).ToUpper().StartsWith("SIGN") Then
                        Dim Nom As String
                        Nom = oDR.GetName(i)
                        ocmdSQL.Parameters.AddWithValue("@" & Nom.ToUpper(), oDR.GetValue(i))
                    End If
                Next
                Try

                    ocmdSQL.ExecuteNonQuery()
                Catch ex As Exception
                    CSDebug.dispError(pTable & " [" & oDR.GetValue(0) & "] ERR :", ex)
                End Try

            End While
            oDR.Close()
        Catch ex As Exception
            CSDebug.dispError(pTable & " ERR :", ex)
        End Try

        oCSDBACCESS.Close()
        oCSDBSQL.Close()


    End Sub
    Public Sub TransfertAgentBuseEtalon()
        Dim strSQL As String = "
INSERT INTO AgentBuseEtalon (
                                numeroNational,
                                idCrodip,
                                couleur,
                                pressionEtalonnage,
                                debitEtalonnage,
                                idStructure,
                                isSynchro,
                                dateAchat,
                                dateModificationAgent,
                                dateModificationCrodip,
                                etat,
                                isSupprime,
                                isUtilise,
                                agentSuppression,
                                raisonSuppression,
                                dateSuppression,
                                jamaisServi,
                                dateActivation
                            )
                            VALUES (
                                @numeroNational,
                                @idCrodip,
                                @couleur,
                                @pressionEtalonnage,
                                @debitEtalonnage,
                                @idStructure,
                                @isSynchro,
                                @dateAchat,
                                @dateModificationAgent,
                                @dateModificationCrodip,
                                @etat,
                                @isSupprime,
                                @isUtilise,
                                @agentSuppression,
                                @raisonSuppression,
                                @dateSuppression,
                                @jamaisServi,
                                @dateActivation
                            );

"
        TransfertTable("AgentBuseEtalon", strSQL)

    End Sub

    Public Sub TransfertControleAgentBanc()

        Dim strSQL As String = "
INSERT INTO ControleAgentBanc (
                                  id,
                                  date,
                                  marqueDebitmetre,
                                  modeleDebitmetre,
                                  typeDebitmetre,
                                  idManometreEtalon,
                                  intervalleLectures,
                                  temperatureExterieure,
                                  temperatureEau,
                                  pressionManometre,
                                  debitLue,
                                  resultat,
                                  etat,
                                  isSynchro
                              )
                              VALUES (
                                  @id,
                                  @date,
                                  @marqueDebitmetre,
                                  @modeleDebitmetre,
                                  @typeDebitmetre,
                                  @idManometreEtalon,
                                  @intervalleLectures,
                                  @temperatureExterieure,
                                  @temperatureEau,
                                  @pressionManometre,
                                  @debitLue,
                                  @resultat,
                                  @etat,
                                  @isSynchro
                              );

"
        TransfertTable("ControleAgentBanc", strSQL)



    End Sub
    Public Sub TransfertControleAgentMano()

        Dim strSQL As String = "
INSERT INTO ControleAgentMano (
                                  id,
                                  date,
                                  idManoEtalon,
                                  idManoControle,
                                  temperature,
                                  pressionAppliquee,
                                  pressionMontante,
                                  pressionDescendante,
                                  erreurAbsolue,
                                  erreurFondEchelle,
                                  erreurMoyenne,
                                  resultat,
                                  etat
                              )
                              VALUES (
                                  @id,
                                  @date,
                                  @idManoEtalon,
                                  @idManoControle,
                                  @temperature,
                                  @pressionAppliquee,
                                  @pressionMontante,
                                  @pressionDescendante,
                                  @erreurAbsolue,
                                  @erreurFondEchelle,
                                  @erreurMoyenne,
                                  @resultat,
                                  @etat
                              );


"
        TransfertTable("ControleAgentMano", strSQL)



    End Sub
    Public Sub TransfertAgentManoControle()
        Dim strSQL As String = "
INSERT INTO AgentManoControle (
                                  numeroNational,
                                  idCrodip,
                                  marque,
                                  classe,
                                  type,
                                  fondEchelle,
                                  etat,
                                  idStructure,
                                  isSynchro,
                                  dateDernierControle,
                                  dateModificationAgent,
                                  dateModificationCrodip,
                                  isUtilise,
                                  isSupprime,
                                  nbControles,
                                  nbControlesTotal,
                                  resolution,
                                  agentSuppression,
                                  raisonSuppression,
                                  dateSuppression,
                                  jamaisServi,
                                  dateActivation
                              )
                              VALUES (
                                  @numeroNational,
                                  @idCrodip,
                                  @marque,
                                  @classe,
                                  @type,
                                  @fondEchelle,
                                  @etat,
                                  @idStructure,
                                  @isSynchro,
                                  @dateDernierControle,
                                  @dateModificationAgent,
                                  @dateModificationCrodip,
                                  @isUtilise,
                                  @isSupprime,
                                  @nbControles,
                                  @nbControlesTotal,
                                  @resolution,
                                  @agentSuppression,
                                  @raisonSuppression,
                                  @dateSuppression,
                                  @jamaisServi,
                                  @dateActivation
                              );

"
        TransfertTable("AgentManoControle", strSQL)


    End Sub
    Public Sub TransfertControleBancMesure()
        Dim strSQL As String = "
INSERT INTO ControleBancMesure (
                                   id,
                                   idStructure,
                                   idBanc,
                                   buse1,
                                   buse2,
                                   buse3,
                                   buse4,
                                   buse5,
                                   buse6,
                                   tempExt,
                                   tempEau,
                                   resultat,
                                   b1_pressionEtal,
                                   b1_debitEtal,
                                   b1_2bar_m1,
                                   b1_2bar_m2,
                                   b1_2bar_m3,
                                   b1_2bar_moy,
                                   b1_2bar_ecart,
                                   b1_3bar_m1,
                                   b1_3bar_m2,
                                   b1_3bar_m3,
                                   b1_3bar_moy,
                                   b1_3bar_ecart,
                                   b2_pressionEtal,
                                   b2_debitEtal,
                                   b2_2bar_m1,
                                   b2_2bar_m2,
                                   b2_2bar_m3,
                                   b2_2bar_moy,
                                   b2_2bar_ecart,
                                   b2_3bar_m1,
                                   b2_3bar_m2,
                                   b2_3bar_m3,
                                   b2_3bar_moy,
                                   b2_3bar_ecart,
                                   b3_pressionEtal,
                                   b3_debitEtal,
                                   b3_2bar_m1,
                                   b3_2bar_m2,
                                   b3_2bar_m3,
                                   b3_2bar_moy,
                                   b3_2bar_ecart,
                                   b3_3bar_m1,
                                   b3_3bar_m2,
                                   b3_3bar_m3,
                                   b3_3bar_moy,
                                   b3_3bar_ecart,
                                   b4_pressionEtal,
                                   b4_debitEtal,
                                   b4_2bar_m1,
                                   b4_2bar_m2,
                                   b4_2bar_m3,
                                   b4_2bar_moy,
                                   b4_2bar_ecart,
                                   b4_3bar_m1,
                                   b4_3bar_m2,
                                   b4_3bar_m3,
                                   b4_3bar_moy,
                                   b4_3bar_ecart,
                                   b5_pressionEtal,
                                   b5_debitEtal,
                                   b5_2bar_m1,
                                   b5_2bar_m2,
                                   b5_2bar_m3,
                                   b5_2bar_moy,
                                   b5_2bar_ecart,
                                   b5_3bar_m1,
                                   b5_3bar_m2,
                                   b5_3bar_m3,
                                   b5_3bar_moy,
                                   b5_3bar_ecart,
                                   b6_pressionEtal,
                                   b6_debitEtal,
                                   b6_2bar_m1,
                                   b6_2bar_m2,
                                   b6_2bar_m3,
                                   b6_2bar_moy,
                                   b6_2bar_ecart,
                                   b6_3bar_m1,
                                   b6_3bar_m2,
                                   b6_3bar_m3,
                                   b6_3bar_moy,
                                   b6_3bar_ecart,
                                   dateModificationAgent,
                                   dateModificationCrodip,
                                   idFichevie,
                                   b1_2bar_conformite,
                                   b2_2bar_conformite,
                                   b3_2bar_conformite,
                                   b4_2bar_conformite,
                                   b5_2bar_conformite,
                                   b6_2bar_conformite,
                                   b1_3bar_conformite,
                                   b2_3bar_conformite,
                                   b3_3bar_conformite,
                                   b4_3bar_conformite,
                                   b5_3bar_conformite,
                                   b6_3bar_conformite
                               )
                               VALUES (
                                   @id,
                                   @idStructure,
                                   @idBanc,
                                   @buse1,
                                   @buse2,
                                   @buse3,
                                   @buse4,
                                   @buse5,
                                   @buse6,
                                   @tempExt,
                                   @tempEau,
                                   @resultat,
                                   @b1_pressionEtal,
                                   @b1_debitEtal,
                                   @b1_2bar_m1,
                                   @b1_2bar_m2,
                                   @b1_2bar_m3,
                                   @b1_2bar_moy,
                                   @b1_2bar_ecart,
                                   @b1_3bar_m1,
                                   @b1_3bar_m2,
                                   @b1_3bar_m3,
                                   @b1_3bar_moy,
                                   @b1_3bar_ecart,
                                   @b2_pressionEtal,
                                   @b2_debitEtal,
                                   @b2_2bar_m1,
                                   @b2_2bar_m2,
                                   @b2_2bar_m3,
                                   @b2_2bar_moy,
                                   @b2_2bar_ecart,
                                   @b2_3bar_m1,
                                   @b2_3bar_m2,
                                   @b2_3bar_m3,
                                   @b2_3bar_moy,
                                   @b2_3bar_ecart,
                                   @b3_pressionEtal,
                                   @b3_debitEtal,
                                   @b3_2bar_m1,
                                   @b3_2bar_m2,
                                   @b3_2bar_m3,
                                   @b3_2bar_moy,
                                   @b3_2bar_ecart,
                                   @b3_3bar_m1,
                                   @b3_3bar_m2,
                                   @b3_3bar_m3,
                                   @b3_3bar_moy,
                                   @b3_3bar_ecart,
                                   @b4_pressionEtal,
                                   @b4_debitEtal,
                                   @b4_2bar_m1,
                                   @b4_2bar_m2,
                                   @b4_2bar_m3,
                                   @b4_2bar_moy,
                                   @b4_2bar_ecart,
                                   @b4_3bar_m1,
                                   @b4_3bar_m2,
                                   @b4_3bar_m3,
                                   @b4_3bar_moy,
                                   @b4_3bar_ecart,
                                   @b5_pressionEtal,
                                   @b5_debitEtal,
                                   @b5_2bar_m1,
                                   @b5_2bar_m2,
                                   @b5_2bar_m3,
                                   @b5_2bar_moy,
                                   @b5_2bar_ecart,
                                   @b5_3bar_m1,
                                   @b5_3bar_m2,
                                   @b5_3bar_m3,
                                   @b5_3bar_moy,
                                   @b5_3bar_ecart,
                                   @b6_pressionEtal,
                                   @b6_debitEtal,
                                   @b6_2bar_m1,
                                   @b6_2bar_m2,
                                   @b6_2bar_m3,
                                   @b6_2bar_moy,
                                   @b6_2bar_ecart,
                                   @b6_3bar_m1,
                                   @b6_3bar_m2,
                                   @b6_3bar_m3,
                                   @b6_3bar_moy,
                                   @b6_3bar_ecart,
                                   @dateModificationAgent,
                                   @dateModificationCrodip,
                                   @idFichevie,
                                   @b1_2bar_conformite,
                                   @b2_2bar_conformite,
                                   @b3_2bar_conformite,
                                   @b4_2bar_conformite,
                                   @b5_2bar_conformite,
                                   @b6_2bar_conformite,
                                   @b1_3bar_conformite,
                                   @b2_3bar_conformite,
                                   @b3_3bar_conformite,
                                   @b4_3bar_conformite,
                                   @b5_3bar_conformite,
                                   @b6_3bar_conformite
                               );

"
        TransfertTable("ControleBancMesure", strSQL)


    End Sub

    Public Sub TransfertControleManoMesure()

        Dim strSQL As String = "
INSERT INTO ControleManoMesure (
                                   id,
                                   idStructure,
                                   idMano,
                                   manoEtalon,
                                   tempAir,
                                   resultat,
                                   up_pt1_pres_manoCtrl,
                                   up_pt1_pres_manoEtalon,
                                   up_pt1_incertitude,
                                   up_pt1_EMT,
                                   up_pt1_err_abs,
                                   up_pt1_err_fondEchelle,
                                   up_pt2_pres_manoCtrl,
                                   up_pt2_pres_manoEtalon,
                                   up_pt2_incertitude,
                                   up_pt2_EMT,
                                   up_pt2_err_abs,
                                   up_pt2_err_fondEchelle,
                                   up_pt3_pres_manoCtrl,
                                   up_pt3_pres_manoEtalon,
                                   up_pt3_incertitude,
                                   up_pt3_EMT,
                                   up_pt3_err_abs,
                                   up_pt3_err_fondEchelle,
                                   up_pt4_pres_manoCtrl,
                                   up_pt4_pres_manoEtalon,
                                   up_pt4_incertitude,
                                   up_pt4_EMT,
                                   up_pt4_err_abs,
                                   up_pt4_err_fondEchelle,
                                   up_pt5_pres_manoCtrl,
                                   up_pt5_pres_manoEtalon,
                                   up_pt5_incertitude,
                                   up_pt5_EMT,
                                   up_pt5_err_abs,
                                   up_pt5_err_fondEchelle,
                                   up_pt6_pres_manoCtrl,
                                   up_pt6_pres_manoEtalon,
                                   up_pt6_incertitude,
                                   up_pt6_EMT,
                                   up_pt6_err_abs,
                                   up_pt6_err_fondEchelle,
                                   down_pt1_pres_manoCtrl,
                                   down_pt1_pres_manoEtalon,
                                   down_pt1_incertitude,
                                   down_pt1_EMT,
                                   down_pt1_err_abs,
                                   down_pt1_err_fondEchelle,
                                   down_pt2_pres_manoCtrl,
                                   down_pt2_pres_manoEtalon,
                                   down_pt2_incertitude,
                                   down_pt2_EMT,
                                   down_pt2_err_abs,
                                   down_pt2_err_fondEchelle,
                                   down_pt3_pres_manoCtrl,
                                   down_pt3_pres_manoEtalon,
                                   down_pt3_incertitude,
                                   down_pt3_EMT,
                                   down_pt3_err_abs,
                                   down_pt3_err_fondEchelle,
                                   down_pt4_pres_manoCtrl,
                                   down_pt4_pres_manoEtalon,
                                   down_pt4_incertitude,
                                   down_pt4_EMT,
                                   down_pt4_err_abs,
                                   down_pt4_err_fondEchelle,
                                   down_pt5_pres_manoCtrl,
                                   down_pt5_pres_manoEtalon,
                                   down_pt5_incertitude,
                                   down_pt5_EMT,
                                   down_pt5_err_abs,
                                   down_pt5_err_fondEchelle,
                                   down_pt6_pres_manoCtrl,
                                   down_pt6_pres_manoEtalon,
                                   down_pt6_incertitude,
                                   down_pt6_EMT,
                                   down_pt6_err_abs,
                                   down_pt6_err_fondEchelle,
                                   dateModificationAgent,
                                   dateModificationCrodip,
                                   up_pt1_conformite,
                                   up_pt2_conformite,
                                   up_pt3_conformite,
                                   up_pt4_conformite,
                                   up_pt5_conformite,
                                   up_pt6_conformite,
                                   down_pt1_conformite,
                                   down_pt2_conformite,
                                   down_pt3_conformite,
                                   down_pt4_conformite,
                                   down_pt5_conformite,
                                   down_pt6_conformite,
                                   idFichevie
                               )
                               VALUES (
                                   @id,
                                   @idStructure,
                                   @idMano,
                                   @manoEtalon,
                                   @tempAir,
                                   @resultat,
                                   @up_pt1_pres_manoCtrl,
                                   @up_pt1_pres_manoEtalon,
                                   @up_pt1_incertitude,
                                   @up_pt1_EMT,
                                   @up_pt1_err_abs,
                                   @up_pt1_err_fondEchelle,
                                   @up_pt2_pres_manoCtrl,
                                   @up_pt2_pres_manoEtalon,
                                   @up_pt2_incertitude,
                                   @up_pt2_EMT,
                                   @up_pt2_err_abs,
                                   @up_pt2_err_fondEchelle,
                                   @up_pt3_pres_manoCtrl,
                                   @up_pt3_pres_manoEtalon,
                                   @up_pt3_incertitude,
                                   @up_pt3_EMT,
                                   @up_pt3_err_abs,
                                   @up_pt3_err_fondEchelle,
                                   @up_pt4_pres_manoCtrl,
                                   @up_pt4_pres_manoEtalon,
                                   @up_pt4_incertitude,
                                   @up_pt4_EMT,
                                   @up_pt4_err_abs,
                                   @up_pt4_err_fondEchelle,
                                   @up_pt5_pres_manoCtrl,
                                   @up_pt5_pres_manoEtalon,
                                   @up_pt5_incertitude,
                                   @up_pt5_EMT,
                                   @up_pt5_err_abs,
                                   @up_pt5_err_fondEchelle,
                                   @up_pt6_pres_manoCtrl,
                                   @up_pt6_pres_manoEtalon,
                                   @up_pt6_incertitude,
                                   @up_pt6_EMT,
                                   @up_pt6_err_abs,
                                   @up_pt6_err_fondEchelle,
                                   @down_pt1_pres_manoCtrl,
                                   @down_pt1_pres_manoEtalon,
                                   @down_pt1_incertitude,
                                   @down_pt1_EMT,
                                   @down_pt1_err_abs,
                                   @down_pt1_err_fondEchelle,
                                   @down_pt2_pres_manoCtrl,
                                   @down_pt2_pres_manoEtalon,
                                   @down_pt2_incertitude,
                                   @down_pt2_EMT,
                                   @down_pt2_err_abs,
                                   @down_pt2_err_fondEchelle,
                                   @down_pt3_pres_manoCtrl,
                                   @down_pt3_pres_manoEtalon,
                                   @down_pt3_incertitude,
                                   @down_pt3_EMT,
                                   @down_pt3_err_abs,
                                   @down_pt3_err_fondEchelle,
                                   @down_pt4_pres_manoCtrl,
                                   @down_pt4_pres_manoEtalon,
                                   @down_pt4_incertitude,
                                   @down_pt4_EMT,
                                   @down_pt4_err_abs,
                                   @down_pt4_err_fondEchelle,
                                   @down_pt5_pres_manoCtrl,
                                   @down_pt5_pres_manoEtalon,
                                   @down_pt5_incertitude,
                                   @down_pt5_EMT,
                                   @down_pt5_err_abs,
                                   @down_pt5_err_fondEchelle,
                                   @down_pt6_pres_manoCtrl,
                                   @down_pt6_pres_manoEtalon,
                                   @down_pt6_incertitude,
                                   @down_pt6_EMT,
                                   @down_pt6_err_abs,
                                   @down_pt6_err_fondEchelle,
                                   @dateModificationAgent,
                                   @dateModificationCrodip,
                                   @up_pt1_conformite,
                                   @up_pt2_conformite,
                                   @up_pt3_conformite,
                                   @up_pt4_conformite,
                                   @up_pt5_conformite,
                                   @up_pt6_conformite,
                                   @down_pt1_conformite,
                                   @down_pt2_conformite,
                                   @down_pt3_conformite,
                                   @down_pt4_conformite,
                                   @down_pt5_conformite,
                                   @down_pt6_conformite,
                                   @idFichevie
                               );
"
        TransfertTable("ControleManoMesure", strSQL)


    End Sub
    Public Sub TransfertControle_Regulier()
        Dim strSQL As String = "
INSERT INTO CONTROLE_REGULIER (
                                  CTRG_DATE,
                                  CTRG_STRUCTUREID,
                                  CTRG_TYPE,
                                  CTRG_MATID,
                                  CTRG_NUMAGENT,
                                  dateModificationAgent,
                                  dateModificationCrodip,
                                  CTRG_ETAT
                              )
                              VALUES (
                                  @CTRG_DATE,
                                  @CTRG_STRUCTUREID,
                                  @CTRG_TYPE,
                                  @CTRG_MATID,
                                  @CTRG_NUMAGENT,
                                  @dateModificationAgent,
                                  @dateModificationCrodip,
                                  @CTRG_ETAT
                              );

"
        TransfertTable("CONTROLE_REGULIER", strSQL, "CTRG_ID")

    End Sub
    Public Sub TransfertIdentifiantPulverisateur()

        Dim strSQL As String = "
INSERT INTO IdentifiantPulverisateur (
                                         id,
                                         idStructure,
                                         numeroNational,
                                         etat,
                                         dateUtilisation,
                                         libelle,
                                         dateModificationAgent,
                                         dateModificationCrodip
                                     )
                                     VALUES (
                                         @id,
                                         @idStructure,
                                         @numeroNational,
                                         @etat,
                                         @dateUtilisation,
                                         @libelle,
                                         @dateModificationAgent,
                                         @dateModificationCrodip
                                     );
"
        TransfertTable("IdentifiantPulverisateur", strSQL)
    End Sub
    Public Sub TransfertFicheVieBancDeMesure()

        Dim strSQL As String = "
INSERT INTO FichevieBancMesure (
                                   id,
                                   idBancMesure,
                                   type,
                                   auteur,
                                   idAgentControleur,
                                   caracteristiques,
                                   dateModif,
                                   blocage,
                                   pressionControle,
                                   valeursMesurees,
                                   idManometreControle,
                                   idBuseEtalon,
                                   dateModificationAgent,
                                   dateModificationCrodip,
                                   FVFileName
                               )
                               VALUES (
                                   @id,
                                   @idBancMesure,
                                   @type,
                                   @auteur,
                                   @idAgentControleur,
                                   @caracteristiques,
                                   @dateModif,
                                   @blocage,
                                   @pressionControle,
                                   @valeursMesurees,
                                   @idManometreControle,
                                   @idBuseEtalon,
                                   @dateModificationAgent,
                                   @dateModificationCrodip,
                                   @FVFileName
                               );
"
        TransfertTable("FichevieBancMesure", strSQL)
    End Sub
    Public Sub TransfertFicheVieManometreControle()
        Dim strSQL As String = "
INSERT INTO FichevieManometreControle (
                                          id,
                                          idManometre,
                                          type,
                                          auteur,
                                          idAgentControleur,
                                          caracteristiques,
                                          dateModif,
                                          blocage,
                                          idReetalonnage,
                                          nomLaboratoire,
                                          dateReetalonnage,
                                          pressionControle,
                                          valeursMesurees,
                                          idManometreControleur,
                                          dateModificationCrodip,
                                          dateModificationAgent,
                                          FVFileName
                                      )
                                      VALUES (
                                          @id,
                                          @idManometre,
                                          @type,
                                          @auteur,
                                          @idAgentControleur,
                                          @caracteristiques,
                                          @dateModif,
                                          @blocage,
                                          @idReetalonnage,
                                          @nomLaboratoire,
                                          @dateReetalonnage,
                                          @pressionControle,
                                          @valeursMesurees,
                                          @idManometreControleur,
                                          @dateModificationCrodip,
                                          @dateModificationAgent,
                                          @FVFileName
                                      );
"
        TransfertTable("FichevieManometreControle", strSQL)

    End Sub
    Public Sub TransfertFicheVieManometreEtalon()

        Dim strSQL As String = "
INSERT INTO FichevieManometreEtalon (
                                        id,
                                        idManometre,
                                        type,
                                        auteur,
                                        idAgentControleur,
                                        caracteristiques,
                                        dateModif,
                                        blocage,
                                        idReetalonnage,
                                        nomLaboratoire,
                                        dateReetalonnage,
                                        pressionControle,
                                        valeursMesurees,
                                        idManometreControleur,
                                        dateModificationCrodip,
                                        dateModificationAgent,
                                        FVFileName
                                    )
                                    VALUES (
                                        @id,
                                        @idManometre,
                                        @type,
                                        @auteur,
                                        @idAgentControleur,
                                        @caracteristiques,
                                        @dateModif,
                                        @blocage,
                                        @idReetalonnage,
                                        @nomLaboratoire,
                                        @dateReetalonnage,
                                        @pressionControle,
                                        @valeursMesurees,
                                        @idManometreControleur,
                                        @dateModificationCrodip,
                                        @dateModificationAgent,
                                        @FVFileName
                                    );

"
        TransfertTable("FichevieManometreEtalon", strSQL)
    End Sub

    Public Sub TransfertPrestationCategorie()

        Dim strSQL As String = "
INSERT INTO PrestationCategorie (
                                    id,
                                    idStructure,
                                    libelle,
                                    dateModificationAgent,
                                    dateModificationCrodip
                                )
                                VALUES (
                                    @id,
                                    @idStructure,
                                    @libelle,
                                    @dateModificationAgent,
                                    @dateModificationCrodip
                                );


"
        TransfertTable("PrestationCategorie", strSQL)


    End Sub
    Public Sub TransfertPrestationTarif()

        Dim strSQL As String = "
INSERT INTO PrestationTarif (
                                id,
                                idCategorie,
                                idStructure,
                                description,
                                tarifHT,
                                tarifTTC,
                                tva,
                                dateModificationAgent,
                                dateModificationCrodip
                            )
                            VALUES (
                                @id,
                                @idCategorie,
                                @idStructure,
                                @description,
                                @tarifHT,
                                @tarifTTC,
                                @tva,
                                @dateModificationAgent,
                                @dateModificationCrodip
                            );


"
        TransfertTable("PrestationTarif", strSQL)


    End Sub
    Public Sub TransfertVersion()
        Dim strSQL As String = "
INSERT INTO VERSION (
                        VERSION_NUM,
                        VERSION_DATE,
                        VERSION_COMM
                    )
                    VALUES (
                        @VERSION_NUM,
                        @VERSION_DATE,
                        @VERSION_COMM
                    );


"
        TransfertTable("Version", strSQL)

    End Sub
    Public Sub TransfertPrestation()
        TransfertPrestationCategorie()
        TransfertPrestationTarif()
        TransfertVersion()
    End Sub
    Public Sub TransfertDiagnostic()
        Dim strSQL As String = "
INSERT INTO Diagnostic (
                           id,
                           organismePresId,
                           organismePresNumero,
                           organismePresNom,
                           organismeInspNom,
                           organismeInspAgrement,
                           inspecteurId,
                           inspecteurNom,
                           inspecteurPrenom,
                           controleDateDebut,
                           controleDateFin,
                           controleCommune,
                           controleCodePostal,
                           controleLieu,
                           controleTerritoire,
                           controleSite,
                           controleNomSite,
                           controleIsComplet,
                           controleIsPremierControle,
                           controleDateDernierControle,
                           controleIsSiteSecurise,
                           controleIsRecupResidus,
                           controleEtat,
                           controleInfosConseils,
                           controleTarif,
                           controleIsPulveRepare,
                           proprietaireId,
                           proprietaireRaisonSociale,
                           proprietairePrenom,
                           proprietaireNom,
                           proprietaireCodeApe,
                           proprietaireNumeroSiren,
                           proprietaireCommune,
                           proprietaireCodePostal,
                           proprietaireAdresse,
                           proprietaireEmail,
                           proprietaireTelephonePortable,
                           proprietaireTelephoneFixe,
                           pulverisateurId,
                           pulverisateurMarque,
                           pulverisateurModele,
                           pulverisateurType,
                           pulverisateurCapacite,
                           pulverisateurLargeur,
                           pulverisateurNbRangs,
                           pulverisateurLargeurPlantation,
                           pulverisateurIsVentilateur,
                           pulverisateurIsDebrayage,
                           pulverisateurAnneeAchat,
                           pulverisateurSurface,
                           pulverisateurNbUtilisateurs,
                           pulverisateurIsCuveRincage,
                           pulverisateurCapaciteCuveRincage,
                           pulverisateurIsRotobuse,
                           pulverisateurIsRinceBidon,
                           pulverisateurIsBidonLaveMain,
                           pulverisateurIsLanceLavageExterieur,
                           pulverisateurIsCuveIncorporation,
                           pulverisateurAttelage,
                           pulverisateurAutresAccessoires,
                           buseMarque,
                           buseCouleur,
                           buseGenre,
                           buseCalibre,
                           buseDebit,
                           buseDebit2bars,
                           buseDebit3bars,
                           buseAge,
                           buseNbBuses,
                           buseType,
                           buseAngle,
                           buseIsISO,
                           manometreMarque,
                           manometreDiametre,
                           manometreType,
                           manometreFondEchelle,
                           manometrePressionTravail,
                           exploitationTypeCultureIsGrandeCulture,
                           exploitationTypeCultureIsLegume,
                           exploitationTypeCultureIsElevage,
                           exploitationTypeCultureIsArboriculture,
                           exploitationTypeCultureIsViticulture,
                           exploitationTypeCultureIsAutres,
                           exploitationSau,
                           dateModificationAgent,
                           dateModificationCrodip,
                           dateSynchro,
                           isSynchro,
                           isATGIP,
                           isTGIP,
                           isFacture,
                           syntheseErreurMoyenneMano,
                           syntheseErreurMaxiMano,
                           syntheseErreurDebitmetre,
                           syntheseErreurMoyenneCinemometre,
                           syntheseUsureMoyenneBuses,
                           syntheseNbBusesUsees,
                           synthesePerteChargeMoyenne,
                           synthesePerteChargeMaxi,
                           controleIsPreControleProfessionel,
                           controleIsAutoControle,
                           ProprietaireRepresentant,
                           organismeOriginePresId,
                           organismeOriginePresNumero,
                           organismeOriginePresNom,
                           organismeOrigineInspNom,
                           organismeOrigineInspAgrement,
                           inspecteurOrigineId,
                           inspecteurOrigineNom,
                           inspecteurOriginePrenom,
                           pulverisateurEmplacementIdentification,
                           controleBancMesureId,
                           controleUseCalibrateur,
                           controleNbreNiveaux,
                           controleNbreTroncons,
                           controleManoControleNumNational,
                           controleInitialId,
                           pulverisateurAncienId,
                           buseModele,
                           RIFileName,
                           SMFileName,
                           pulverisateurRegulation,
                           pulverisateurRegulationOptions,
                           pulverisateurModeUtilisation,
                           pulverisateurNbreExploitants,
                           buseFonctionnement,
                           pulverisateurCategorie,
                           pulverisateurPulverisation,
                           CCFileName,
                           pulverisateurCoupureAutoTroncons,
                           pulverisateurReglageAutoHauteur,
                           pulverisateurRincagecircuit,
                           typeDiagnostic,
                           codeInsee,
                           commentaire,
                           pulverisateurNumNational,
                           pulverisateurNumchassis,
                           origineDiag,
                           isSignRIAgent,
                           isSignRIClient,
                           isSignCCAgent,
                           isSignCCClient,
                           dateSignRIAgent,
                           dateSignRIClient,
                           dateSignCCAgent,
                           dateSignCCClient,
                           isSupprime,
                           diagRemplacementId,
                           totalHT,
                           totalTTC,
                           dateRemplacement,
                           isCVImmediate,
                           isGratuit
                       )
                       VALUES (
                           @id,
                           @organismePresId,
                           @organismePresNumero,
                           @organismePresNom,
                           @organismeInspNom,
                           @organismeInspAgrement,
                           @inspecteurId,
                           @inspecteurNom,
                           @inspecteurPrenom,
                           @controleDateDebut,
                           @controleDateFin,
                           @controleCommune,
                           @controleCodePostal,
                           @controleLieu,
                           @controleTerritoire,
                           @controleSite,
                           @controleNomSite,
                           @controleIsComplet,
                           @controleIsPremierControle,
                           @controleDateDernierControle,
                           @controleIsSiteSecurise,
                           @controleIsRecupResidus,
                           @controleEtat,
                           @controleInfosConseils,
                           @controleTarif,
                           @controleIsPulveRepare,
                           @proprietaireId,
                           @proprietaireRaisonSociale,
                           @proprietairePrenom,
                           @proprietaireNom,
                           @proprietaireCodeApe,
                           @proprietaireNumeroSiren,
                           @proprietaireCommune,
                           @proprietaireCodePostal,
                           @proprietaireAdresse,
                           @proprietaireEmail,
                           @proprietaireTelephonePortable,
                           @proprietaireTelephoneFixe,
                           @pulverisateurId,
                           @pulverisateurMarque,
                           @pulverisateurModele,
                           @pulverisateurType,
                           @pulverisateurCapacite,
                           @pulverisateurLargeur,
                           @pulverisateurNbRangs,
                           @pulverisateurLargeurPlantation,
                           @pulverisateurIsVentilateur,
                           @pulverisateurIsDebrayage,
                           @pulverisateurAnneeAchat,
                           @pulverisateurSurface,
                           @pulverisateurNbUtilisateurs,
                           @pulverisateurIsCuveRincage,
                           @pulverisateurCapaciteCuveRincage,
                           @pulverisateurIsRotobuse,
                           @pulverisateurIsRinceBidon,
                           @pulverisateurIsBidonLaveMain,
                           @pulverisateurIsLanceLavageExterieur,
                           @pulverisateurIsCuveIncorporation,
                           @pulverisateurAttelage,
                           @pulverisateurAutresAccessoires,
                           @buseMarque,
                           @buseCouleur,
                           @buseGenre,
                           @buseCalibre,
                           @buseDebit,
                           @buseDebit2bars,
                           @buseDebit3bars,
                           @buseAge,
                           @buseNbBuses,
                           @buseType,
                           @buseAngle,
                           @buseIsISO,
                           @manometreMarque,
                           @manometreDiametre,
                           @manometreType,
                           @manometreFondEchelle,
                           @manometrePressionTravail,
                           @exploitationTypeCultureIsGrandeCulture,
                           @exploitationTypeCultureIsLegume,
                           @exploitationTypeCultureIsElevage,
                           @exploitationTypeCultureIsArboriculture,
                           @exploitationTypeCultureIsViticulture,
                           @exploitationTypeCultureIsAutres,
                           @exploitationSau,
                           @dateModificationAgent,
                           @dateModificationCrodip,
                           @dateSynchro,
                           @isSynchro,
                           @isATGIP,
                           @isTGIP,
                           @isFacture,
                           @syntheseErreurMoyenneMano,
                           @syntheseErreurMaxiMano,
                           @syntheseErreurDebitmetre,
                           @syntheseErreurMoyenneCinemometre,
                           @syntheseUsureMoyenneBuses,
                           @syntheseNbBusesUsees,
                           @synthesePerteChargeMoyenne,
                           @synthesePerteChargeMaxi,
                           @controleIsPreControleProfessionel,
                           @controleIsAutoControle,
                           @ProprietaireRepresentant,
                           @organismeOriginePresId,
                           @organismeOriginePresNumero,
                           @organismeOriginePresNom,
                           @organismeOrigineInspNom,
                           @organismeOrigineInspAgrement,
                           @inspecteurOrigineId,
                           @inspecteurOrigineNom,
                           @inspecteurOriginePrenom,
                           @pulverisateurEmplacementIdentification,
                           @controleBancMesureId,
                           @controleUseCalibrateur,
                           @controleNbreNiveaux,
                           @controleNbreTroncons,
                           @controleManoControleNumNational,
                           @controleInitialId,
                           @pulverisateurAncienId,
                           @buseModele,
                           @RIFileName,
                           @SMFileName,
                           @pulverisateurRegulation,
                           @pulverisateurRegulationOptions,
                           @pulverisateurModeUtilisation,
                           @pulverisateurNbreExploitants,
                           @buseFonctionnement,
                           @pulverisateurCategorie,
                           @pulverisateurPulverisation,
                           @CCFileName,
                           @pulverisateurCoupureAutoTroncons,
                           @pulverisateurReglageAutoHauteur,
                           @pulverisateurRincagecircuit,
                           @typeDiagnostic,
                           @codeInsee,
                           @commentaire,
                           @pulverisateurNumNational,
                           @pulverisateurNumchassis,
                           @origineDiag,
                           @isSignRIAgent,
                           @isSignRIClient,
                           @isSignCCAgent,
                           @isSignCCClient,
                           @dateSignRIAgent,
                           @dateSignRIClient,
                           @dateSignCCAgent,
                           @dateSignCCClient,
                           @isSupprime,
                           @diagRemplacementId,
                           @totalHT,
                           @totalTTC,
                           @dateRemplacement,
                           @isCVImmediate,
                           @isGratuit
                       )"

        TransfertTable2("Diagnostic", strSQL)
    End Sub
    Public Sub TransfertDiagnosticItem()

        Dim strSQL As String = " INSERT INTO DiagnosticItem (
                               idDiagnostic,
                               idItem,
                               itemValue,
                               itemCodeEtat,
                               isItemCode1,
                               isItemCode2,
                               dateModificationAgent,
                               dateModificationCrodip,
                               cause
                           )
                           VALUES(
                               @idDiagnostic,
                               @idItem,
                               @itemValue,
                               @itemCodeEtat,
                               @isItemCode1,
                               @isItemCode2,
                               @dateModificationAgent,
                               @dateModificationCrodip,
                               @cause
                           );"
        CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
        Dim oCSDB As New CSDb(False)
        Dim oCSDBACCESS As New OleDb.OleDbConnection(oCSDB.getConnectString(dbNameACCESS, CSDb.EnumDBTYPE.MSACCESS))
        oCSDBACCESS.Open()
        CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        Dim oCSDBSQL As New Microsoft.Data.Sqlite.SqliteConnection(oCSDB.getConnectString("crodip_agent", CSDb.EnumDBTYPE.SQLITE))
        oCSDBSQL.Open()
        Dim nMax As Integer = 100
        Dim ocmdACCESS As DbCommand
        Dim ocmdSQL As Microsoft.Data.Sqlite.SqliteCommand

        ocmdACCESS = oCSDBACCESS.CreateCommand
        ocmdSQL = oCSDBSQL.CreateCommand

        ocmdACCESS = oCSDBACCESS.CreateCommand
        ocmdSQL = oCSDBSQL.CreateCommand
        ocmdACCESS.CommandText = "SELECT Count(*) FROM DiagnosticItem Where ItemCodeEtat <> 'B'"
        nMax = ocmdACCESS.ExecuteScalar()

        ocmdACCESS.CommandText = "SELECT * FROM DiagnosticItem  Where ItemCodeEtat <> 'B'"


        ocmdSQL.CommandText = strSQL

        ocmdSQL.Prepare()
        Dim oDR As DbDataReader
        oDR = ocmdACCESS.ExecuteReader()
        Dim n As Integer = 0
        While oDR.Read()
            n = n + 1
            bgw.ReportProgress(n * 100 / nMax, "DiagnosticItem " & oDR.GetValue(0))
            ocmdSQL.Parameters.Clear()
            For i As Integer = 0 To oDR.FieldCount() - 1
                If oDR.GetName(i) <> "Id" Then
                    ocmdSQL.Parameters.AddWithValue("@" & oDR.GetName(i), oDR.GetValue(i))
                End If
            Next
            Try

                ocmdSQL.ExecuteNonQuery()
            Catch ex As Exception
                CSDebug.dispError("DiagnosticItem " & oDR.GetValue(0) & "] ERR :", ex)
            End Try

        End While
        oDR.Close()

        oCSDBACCESS.Close()
        oCSDBSQL.Close()


    End Sub
    Public Sub TransfertDiagnosticBuses()
        Dim strSQL As String = "INSERT INTO DiagnosticBuses (
                                idDiagnostic,
                                marque,
                                nombre,
                                genre,
                                calibre,
                                couleur,
                                debitMoyen,
                                debitNominal,
                                dateModificationAgent,
                                dateModificationCrodip,
                                idLot,
                                ecartTolere
                            )
                            VALUES (
                                @idDiagnostic,
                                @marque,
                                @nombre,
                                @genre,
                                @calibre,
                                @couleur,
                                @debitMoyen,
                                @debitNominal,
                                @dateModificationAgent,
                                @dateModificationCrodip,
                                @idLot,
                                @ecartTolere
                            );
"
        TransfertTable("DiagnosticBuses", strSQL, "Id")
    End Sub
    Public Sub TransfertDiagnosticBusesDetail()

        Dim strSQL As String = "INSERT INTO DiagnosticBusesDetail (
                                      idDiagnostic,
                                      idBuse,
                                      idLot,
                                      debit,
                                      ecart,
                                      dateModificationAgent,
                                      dateModificationCrodip
                                  )
                                  VALUES (
                                      @idDiagnostic,
                                      @idBuse,
                                      @idLot,
                                      @debit,
                                      @ecart,
                                      @dateModificationAgent,
                                      @dateModificationCrodip
                                  );

"
        TransfertTable("DiagnosticBusesDetail", strSQL, "Id")
    End Sub
    Public Sub TransfertDiagnosticMano542()
        Dim strSQL As String = "INSERT INTO DiagnosticMano542 (
                                  idDiagnostic,
                                  pressionPulve,
                                  pressionControle,
                                  dateModificationAgent,
                                  dateModificationCrodip
                              )
                              VALUES (
                                  @idDiagnostic,
                                  @pressionPulve,
                                  @pressionControle,
                                  @dateModificationAgent,
                                  @dateModificationCrodip
                              );


"
        TransfertTable("DiagnosticMano542", strSQL, "Id")
    End Sub
    Public Sub TransfertDiagnosticTronçons833()
        Dim strSQL As String =
        "INSERT INTO DiagnosticTroncons833 (
                                      idDiagnostic,
                                      idPression,
                                      idColumn,
                                      pressionSortie,
                                      dateModificationAgent,
                                      dateModificationCrodip
                                  )
                                  VALUES (
                                      @idDiagnostic,
                                      @idPression,
                                      @idColumn,
                                      @pressionSortie,
                                      @dateModificationAgent,
                                      @dateModificationCrodip
                                  );


"
        TransfertTable("DiagnosticTroncons833", strSQL)

    End Sub





    Public Sub TransfertDiagnosticALL()
        Try

            TransfertDiagnostic()
            TransfertDiagnosticItem()
            TransfertDiagnosticBuses()
            TransfertDiagnosticBusesDetail()
            TransfertDiagnosticMano542()
            TransfertDiagnosticTronçons833()
        Catch ex As Exception
            CSDebug.dispError("TransfertDiagnostic ERR", ex)
        End Try
    End Sub
    Public Sub TransfertFactures()
        TransfertFacture()
        TransfertFactureItem()
    End Sub

    Private Sub TransfertFactureItem()
        Dim strSQL As String = "
INSERT INTO factureitem (
                            idfacture,
                            nfactureitem,
                            categorie,
                            prestation,
                            quantite,
                            pu,
                            totalhtitem,
                            totaltvaitem,
                            totalttcitem,
                            txtvaitem,
                            dateModificationAgent,
                            dateModificationCRODIP
                        )
                        VALUES (
                            @idfacture,
                            @nfactureitem,
                            @categorie,
                            @prestation,
                            @quantite,
                            @pu,
                            @totalhtitem,
                            @totaltvaitem,
                            @totalttcitem,
                            @txtvaitem,
                            @dateModificationAgent,
                            @dateModificationCRODIP
                        );

"
        TransfertTable("factureitem", strSQL)
    End Sub

    Private Sub TransfertFacture()
        Dim strSQL As String = "
INSERT INTO facture (
                        idfacture,
                        idstructure,
                        datefacture,
                        dateecheance,
                        commentaire,
                        modereglement,
                        isreglee,
                        refreglement,
                        totalht,
                        txtva,
                        totalttc,
                        totaltva,
                        iddiag,
                        idexploit,
                        rsclient,
                        nomclient,
                        prenomclient,
                        adresseclient,
                        cpclient,
                        communeclient,
                        telfixeclient,
                        telportclient,
                        emailclient,
                        dateModificationAgent,
                        dateModificationCRODIP,
                        pathPDF
                    )
                    VALUES (
                        @idfacture,
                        @idstructure,
                        @datefacture,
                        @dateecheance,
                        @commentaire,
                        @modereglement,
                        @isreglee,
                        @refreglement,
                        @totalht,
                        @txtva,
                        @totalttc,
                        @totaltva,
                        @iddiag,
                        @idexploit,
                        @rsclient,
                        @nomclient,
                        @prenomclient,
                        @adresseclient,
                        @cpclient,
                        @communeclient,
                        @telfixeclient,
                        @telportclient,
                        @emailclient,
                        @dateModificationAgent,
                        @dateModificationCRODIP,
                        @pathPDF
                    );

"
        TransfertTable("facture", strSQL)
    End Sub
    ''' <summary>
    ''' compare la numérotation des Diag avant et après migration
    ''' et revoie une liste de Messages d'alertes
    ''' </summary>
    ''' <returns></returns>
    Public Shared Function ComparerNumDiag() As List(Of String)
        CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
        Dim lstAlertes As New List(Of String)
        Dim strNumAvant As String
        Dim strNumApres As String
        Dim olstStructure As List(Of Structuree)
        olstStructure = StructureManager.getList()
        For Each oStruct As Structuree In olstStructure
            Dim olst As List(Of Agent) = AgentManager.getAgentList(oStruct.id).items
            For Each oAgent As Agent In olst
                CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
                CSDb.resetConnection()
                strNumAvant = DiagnosticManager.getNewId(oAgent)

                CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
                CSDb.resetConnection()
                strNumApres = DiagnosticManager.getNewId(oAgent)

                If strNumAvant <> strNumApres Then
                    lstAlertes.Add("Erreur de numérotation pour l'agent [" & oAgent.numeroNational & "] : Avant = " & strNumAvant & " , Après = " & strNumApres & " , URGENT PREVENEZ LE CRODIP")
                End If
            Next
        Next

        If My.Settings.BDDType = "ACCESS" Then
            CSDb._DBTYPE = CSDb.EnumDBTYPE.MSACCESS
        End If
        If My.Settings.BDDType = "SQLITE" Then
            CSDb._DBTYPE = CSDb.EnumDBTYPE.SQLITE
        End If
        CSDb.resetConnection()

        Return lstAlertes

    End Function
End Class
