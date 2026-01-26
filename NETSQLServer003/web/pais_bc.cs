using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pais_bc : GxSilentTrn, IGxSilentTrn
   {
      public pais_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public pais_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1PaisId = A1PaisId;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z2PaisNome = A2PaisNome;
         }
         if ( GX_JID == -2 )
         {
            Z1PaisId = A1PaisId;
            Z2PaisNome = A2PaisNome;
            Z3PaisBandeira = A3PaisBandeira;
            Z40000PaisBandeira_GXI = A40000PaisBandeira_GXI;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1PaisId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A2PaisNome = BC00014_A2PaisNome[0];
            A40000PaisBandeira_GXI = BC00014_A40000PaisBandeira_GXI[0];
            A3PaisBandeira = BC00014_A3PaisBandeira[0];
            ZM011( -2) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A2PaisNome, A1PaisId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"País"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A2PaisNome)) )
         {
            GX_msglist.addItem("O nome do país deve ser preenchido.", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1PaisId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1PaisId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 2) ;
            RcdFound1 = 1;
            A1PaisId = BC00013_A1PaisId[0];
            A2PaisNome = BC00013_A2PaisNome[0];
            A40000PaisBandeira_GXI = BC00013_A40000PaisBandeira_GXI[0];
            A3PaisBandeira = BC00013_A3PaisBandeira[0];
            Z1PaisId = A1PaisId;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_010( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1PaisId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z2PaisNome, BC00012_A2PaisNome[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Pais"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A1PaisId, A2PaisNome, A3PaisBandeira, A40000PaisBandeira_GXI});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(5) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A2PaisNome, A1PaisId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("Pais");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Pais"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00019 */
            pr_default.execute(7, new Object[] {A3PaisBandeira, A40000PaisBandeira_GXI, A1PaisId});
            pr_default.close(7);
            pr_default.SmartCacheProvider.SetUpdated("Pais");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000110 */
                  pr_default.execute(8, new Object[] {A1PaisId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("Pais");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000111 */
            pr_default.execute(9, new Object[] {A1PaisId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Produto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000112 */
            pr_default.execute(10, new Object[] {A1PaisId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000113 */
            pr_default.execute(11, new Object[] {A1PaisId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Vendedor"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000114 */
         pr_default.execute(12, new Object[] {A1PaisId});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1PaisId = BC000114_A1PaisId[0];
            A2PaisNome = BC000114_A2PaisNome[0];
            A40000PaisBandeira_GXI = BC000114_A40000PaisBandeira_GXI[0];
            A3PaisBandeira = BC000114_A3PaisBandeira[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound1 = 1;
            A1PaisId = BC000114_A1PaisId[0];
            A2PaisNome = BC000114_A2PaisNome[0];
            A40000PaisBandeira_GXI = BC000114_A40000PaisBandeira_GXI[0];
            A3PaisBandeira = BC000114_A3PaisBandeira[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bcPais) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bcPais, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A2PaisNome = "";
         A3PaisBandeira = "";
         A40000PaisBandeira_GXI = "";
         Z2PaisNome = "";
      }

      protected void InitAll011( )
      {
         A1PaisId = 0;
         InitializeNonKey011( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow1( SdtPais obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Paisnome = A2PaisNome;
         obj1.gxTpr_Paisbandeira = A3PaisBandeira;
         obj1.gxTpr_Paisbandeira_gxi = A40000PaisBandeira_GXI;
         obj1.gxTpr_Paisid = A1PaisId;
         obj1.gxTpr_Paisid_Z = Z1PaisId;
         obj1.gxTpr_Paisnome_Z = Z2PaisNome;
         obj1.gxTpr_Paisbandeira_gxi_Z = Z40000PaisBandeira_GXI;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( SdtPais obj1 )
      {
         obj1.gxTpr_Paisid = A1PaisId;
         return  ;
      }

      public void RowToVars1( SdtPais obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A2PaisNome = obj1.gxTpr_Paisnome;
         A3PaisBandeira = obj1.gxTpr_Paisbandeira;
         A40000PaisBandeira_GXI = obj1.gxTpr_Paisbandeira_gxi;
         A1PaisId = obj1.gxTpr_Paisid;
         Z1PaisId = obj1.gxTpr_Paisid_Z;
         Z2PaisNome = obj1.gxTpr_Paisnome_Z;
         Z40000PaisBandeira_GXI = obj1.gxTpr_Paisbandeira_gxi_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1PaisId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1PaisId = A1PaisId;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars1( bcPais, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1PaisId = A1PaisId;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1PaisId != Z1PaisId )
               {
                  A1PaisId = Z1PaisId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update011( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A1PaisId != Z1PaisId )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert011( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcPais, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
         }
         else
         {
            SdtPais auxBC = new SdtPais(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1PaisId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcPais);
               auxBC.Save();
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcPais, 1) ;
         UpdateImpl( ) ;
         VarsToRow1( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars1( bcPais, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
         }
         else
         {
            AfterTrn( ) ;
         }
         VarsToRow1( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars1( bcPais, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1PaisId != Z1PaisId )
            {
               A1PaisId = Z1PaisId;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A1PaisId != Z1PaisId )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         pr_default.close(1);
         context.RollbackDataStores("pais_bc",pr_default);
         VarsToRow1( bcPais) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bcPais.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcPais.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcPais )
         {
            bcPais = (SdtPais)(sdt);
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bcPais) ;
            }
            else
            {
               RowToVars1( bcPais, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcPais.gxTpr_Mode, "") == 0 )
            {
               bcPais.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bcPais, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtPais Pais_BC
      {
         get {
            return bcPais ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z2PaisNome = "";
         A2PaisNome = "";
         Z3PaisBandeira = "";
         A3PaisBandeira = "";
         Z40000PaisBandeira_GXI = "";
         A40000PaisBandeira_GXI = "";
         BC00014_A1PaisId = new short[1] ;
         BC00014_A2PaisNome = new string[] {""} ;
         BC00014_A40000PaisBandeira_GXI = new string[] {""} ;
         BC00014_A3PaisBandeira = new string[] {""} ;
         BC00015_A2PaisNome = new string[] {""} ;
         BC00016_A1PaisId = new short[1] ;
         BC00013_A1PaisId = new short[1] ;
         BC00013_A2PaisNome = new string[] {""} ;
         BC00013_A40000PaisBandeira_GXI = new string[] {""} ;
         BC00013_A3PaisBandeira = new string[] {""} ;
         sMode1 = "";
         BC00012_A1PaisId = new short[1] ;
         BC00012_A2PaisNome = new string[] {""} ;
         BC00012_A40000PaisBandeira_GXI = new string[] {""} ;
         BC00012_A3PaisBandeira = new string[] {""} ;
         BC000111_A19ProdutoId = new short[1] ;
         BC000112_A43ClienteId = new short[1] ;
         BC000113_A6VendedorId = new short[1] ;
         BC000114_A1PaisId = new short[1] ;
         BC000114_A2PaisNome = new string[] {""} ;
         BC000114_A40000PaisBandeira_GXI = new string[] {""} ;
         BC000114_A3PaisBandeira = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.pais_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A1PaisId, BC00012_A2PaisNome, BC00012_A40000PaisBandeira_GXI, BC00012_A3PaisBandeira
               }
               , new Object[] {
               BC00013_A1PaisId, BC00013_A2PaisNome, BC00013_A40000PaisBandeira_GXI, BC00013_A3PaisBandeira
               }
               , new Object[] {
               BC00014_A1PaisId, BC00014_A2PaisNome, BC00014_A40000PaisBandeira_GXI, BC00014_A3PaisBandeira
               }
               , new Object[] {
               BC00015_A2PaisNome
               }
               , new Object[] {
               BC00016_A1PaisId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000111_A19ProdutoId
               }
               , new Object[] {
               BC000112_A43ClienteId
               }
               , new Object[] {
               BC000113_A6VendedorId
               }
               , new Object[] {
               BC000114_A1PaisId, BC000114_A2PaisNome, BC000114_A40000PaisBandeira_GXI, BC000114_A3PaisBandeira
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z1PaisId ;
      private short A1PaisId ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z2PaisNome ;
      private string A2PaisNome ;
      private string Z40000PaisBandeira_GXI ;
      private string A40000PaisBandeira_GXI ;
      private string Z3PaisBandeira ;
      private string A3PaisBandeira ;
      private SdtPais bcPais ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00014_A1PaisId ;
      private string[] BC00014_A2PaisNome ;
      private string[] BC00014_A40000PaisBandeira_GXI ;
      private string[] BC00014_A3PaisBandeira ;
      private string[] BC00015_A2PaisNome ;
      private short[] BC00016_A1PaisId ;
      private short[] BC00013_A1PaisId ;
      private string[] BC00013_A2PaisNome ;
      private string[] BC00013_A40000PaisBandeira_GXI ;
      private string[] BC00013_A3PaisBandeira ;
      private short[] BC00012_A1PaisId ;
      private string[] BC00012_A2PaisNome ;
      private string[] BC00012_A40000PaisBandeira_GXI ;
      private string[] BC00012_A3PaisBandeira ;
      private short[] BC000111_A19ProdutoId ;
      private short[] BC000112_A43ClienteId ;
      private short[] BC000113_A6VendedorId ;
      private short[] BC000114_A1PaisId ;
      private string[] BC000114_A2PaisNome ;
      private string[] BC000114_A40000PaisBandeira_GXI ;
      private string[] BC000114_A3PaisBandeira ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class pais_bc__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new UpdateCursor(def[5])
         ,new UpdateCursor(def[6])
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00014;
          prmBC00014 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00015;
          prmBC00015 = new Object[] {
          new ParDef("@PaisNome",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00016;
          prmBC00016 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00013;
          prmBC00013 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00012;
          prmBC00012 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00017;
          prmBC00017 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0) ,
          new ParDef("@PaisNome",GXType.NVarChar,40,0) ,
          new ParDef("@PaisBandeira",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PaisBandeira_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Pais", Fld="PaisBandeira"}
          };
          Object[] prmBC00018;
          prmBC00018 = new Object[] {
          new ParDef("@PaisNome",GXType.NVarChar,40,0) ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC00019;
          prmBC00019 = new Object[] {
          new ParDef("@PaisBandeira",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PaisBandeira_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Pais", Fld="PaisBandeira"} ,
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000110;
          prmBC000110 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000111;
          prmBC000111 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000112;
          prmBC000112 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000113;
          prmBC000113 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000114;
          prmBC000114 = new Object[] {
          new ParDef("@PaisId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00012", "SELECT [PaisId], [PaisNome], [PaisBandeira_GXI], [PaisBandeira] FROM [Pais] WITH (UPDLOCK) WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00013", "SELECT [PaisId], [PaisNome], [PaisBandeira_GXI], [PaisBandeira] FROM [Pais] WHERE [PaisId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00014", "SELECT TM1.[PaisId], TM1.[PaisNome], TM1.[PaisBandeira_GXI], TM1.[PaisBandeira] FROM [Pais] TM1 WHERE TM1.[PaisId] = @PaisId ORDER BY TM1.[PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00015", "SELECT [PaisNome] FROM [Pais] WHERE ([PaisNome] = @PaisNome) AND (Not ( [PaisId] = @PaisId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00016", "SELECT [PaisId] FROM [Pais] WHERE [PaisId] = @PaisId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00017", "INSERT INTO [Pais]([PaisId], [PaisNome], [PaisBandeira], [PaisBandeira_GXI]) VALUES(@PaisId, @PaisNome, @PaisBandeira, @PaisBandeira_GXI)", GxErrorMask.GX_NOMASK,prmBC00017)
             ,new CursorDef("BC00018", "UPDATE [Pais] SET [PaisNome]=@PaisNome  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC00018)
             ,new CursorDef("BC00019", "UPDATE [Pais] SET [PaisBandeira]=@PaisBandeira, [PaisBandeira_GXI]=@PaisBandeira_GXI  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC00019)
             ,new CursorDef("BC000110", "DELETE FROM [Pais]  WHERE [PaisId] = @PaisId", GxErrorMask.GX_NOMASK,prmBC000110)
             ,new CursorDef("BC000111", "SELECT TOP 1 [ProdutoId] FROM [Produto] WHERE [PaisProdutoId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000112", "SELECT TOP 1 [ClienteId] FROM [Cliente] WHERE [PaisClienteId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000112,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000113", "SELECT TOP 1 [VendedorId] FROM [Vendedor] WHERE [PaisVendedorId] = @PaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000113,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000114", "SELECT TM1.[PaisId], TM1.[PaisNome], TM1.[PaisBandeira_GXI], TM1.[PaisBandeira] FROM [Pais] TM1 WHERE TM1.[PaisId] = @PaisId ORDER BY TM1.[PaisId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000114,100, GxCacheFrequency.OFF ,true,false )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
       }
    }

 }

}
