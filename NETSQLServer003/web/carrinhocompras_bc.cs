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
   public class carrinhocompras_bc : GxSilentTrn, IGxSilentTrn
   {
      public carrinhocompras_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public carrinhocompras_bc( IGxContext context )
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
         ReadRow0D12( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D12( ) ;
         standaloneModal( ) ;
         AddRow0D12( ) ;
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
            E110D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z52CarrinhoComprasId = A52CarrinhoComprasId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D12( ) ;
            }
            else
            {
               CheckExtendedTable0D12( ) ;
               if ( AnyError == 0 )
               {
                  ZM0D12( 10) ;
                  ZM0D12( 11) ;
                  ZM0D12( 12) ;
               }
               CloseExtendedTableCursors0D12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode12 = Gx_mode;
            CONFIRM_0D13( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode12;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode12;
         }
      }

      protected void CONFIRM_0D13( )
      {
         s62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         s65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
         nGXsfl_13_idx = 0;
         while ( nGXsfl_13_idx < bcCarrinhoCompras.gxTpr_Produtos.Count )
         {
            ReadRow0D13( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound13 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_13 != 0 ) )
            {
               GetKey0D13( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound13 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0D13( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0D13( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0D13( 14) ;
                           ZM0D13( 15) ;
                        }
                        CloseExtendedTableCursors0D13( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                        n62CarrinhoComprasPrecoTotal = false;
                        O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0D13( ) ;
                        Load0D13( ) ;
                        BeforeValidate0D13( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0D13( ) ;
                           O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                           n62CarrinhoComprasPrecoTotal = false;
                           O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                        }
                     }
                     else
                     {
                        if ( nIsMod_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0D13( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0D13( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0D13( 14) ;
                                 ZM0D13( 15) ;
                              }
                              CloseExtendedTableCursors0D13( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                              n62CarrinhoComprasPrecoTotal = false;
                              O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow13( ((SdtCarrinhoCompras_Produtos)bcCarrinhoCompras.gxTpr_Produtos.Item(nGXsfl_13_idx))) ;
            }
         }
         O62CarrinhoComprasPrecoTotal = s62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         O65CarrinhoComprasPontos = s65CarrinhoComprasPontos;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120D2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("anotafiscalcarrinho.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0))}, new string[] {"CarrinhoComprasId"}) , new Object[] {"A52CarrinhoComprasId"});
         /*  Sending Event outputs  */
      }

      protected void ZM0D12( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            Z53CarrinhoComprasData = A53CarrinhoComprasData;
            Z54ClienteCarrinhoComprasId = A54ClienteCarrinhoComprasId;
            Z62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            Z63CarrinhoComprasDataEntrega = A63CarrinhoComprasDataEntrega;
            Z65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
         }
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z55ClienteCarrinhoComprasNome = A55ClienteCarrinhoComprasNome;
            Z56ClienteCarrinhoComprasEndereco = A56ClienteCarrinhoComprasEndereco;
            Z57ClienteCarrinhoComprasPaisId = A57ClienteCarrinhoComprasPaisId;
            Z62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            Z63CarrinhoComprasDataEntrega = A63CarrinhoComprasDataEntrega;
            Z65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
         }
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z58ClienteCarrinhoComprasPaisNome = A58ClienteCarrinhoComprasPaisNome;
            Z62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            Z63CarrinhoComprasDataEntrega = A63CarrinhoComprasDataEntrega;
            Z65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
         }
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            Z62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            Z63CarrinhoComprasDataEntrega = A63CarrinhoComprasDataEntrega;
            Z65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
         }
         if ( GX_JID == -9 )
         {
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            Z53CarrinhoComprasData = A53CarrinhoComprasData;
            Z54ClienteCarrinhoComprasId = A54ClienteCarrinhoComprasId;
            Z62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            Z55ClienteCarrinhoComprasNome = A55ClienteCarrinhoComprasNome;
            Z56ClienteCarrinhoComprasEndereco = A56ClienteCarrinhoComprasEndereco;
            Z57ClienteCarrinhoComprasPaisId = A57ClienteCarrinhoComprasPaisId;
            Z58ClienteCarrinhoComprasPaisNome = A58ClienteCarrinhoComprasPaisNome;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A53CarrinhoComprasData) && ( Gx_BScreen == 0 ) )
         {
            A53CarrinhoComprasData = Gx_date;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
         }
      }

      protected void Load0D12( )
      {
         /* Using cursor BC000D13 */
         pr_default.execute(9, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound12 = 1;
            A53CarrinhoComprasData = BC000D13_A53CarrinhoComprasData[0];
            A55ClienteCarrinhoComprasNome = BC000D13_A55ClienteCarrinhoComprasNome[0];
            A56ClienteCarrinhoComprasEndereco = BC000D13_A56ClienteCarrinhoComprasEndereco[0];
            A58ClienteCarrinhoComprasPaisNome = BC000D13_A58ClienteCarrinhoComprasPaisNome[0];
            A54ClienteCarrinhoComprasId = BC000D13_A54ClienteCarrinhoComprasId[0];
            A57ClienteCarrinhoComprasPaisId = BC000D13_A57ClienteCarrinhoComprasPaisId[0];
            A62CarrinhoComprasPrecoTotal = BC000D13_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = BC000D13_n62CarrinhoComprasPrecoTotal[0];
            ZM0D12( -9) ;
         }
         pr_default.close(9);
         OnLoadActions0D12( ) ;
      }

      protected void OnLoadActions0D12( )
      {
         O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
         }
         else
         {
            A65CarrinhoComprasPontos = 0;
         }
         A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
      }

      protected void CheckExtendedTable0D12( )
      {
         nIsDirty_12 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000D11 */
         pr_default.execute(8, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A62CarrinhoComprasPrecoTotal = BC000D11_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = BC000D11_n62CarrinhoComprasPrecoTotal[0];
         }
         else
         {
            nIsDirty_12 = 1;
            A62CarrinhoComprasPrecoTotal = 0;
            n62CarrinhoComprasPrecoTotal = false;
         }
         pr_default.close(8);
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            nIsDirty_12 = 1;
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
         }
         else
         {
            nIsDirty_12 = 1;
            A65CarrinhoComprasPontos = 0;
         }
         if ( ! ( (DateTime.MinValue==A53CarrinhoComprasData) || ( DateTimeUtil.ResetTime ( A53CarrinhoComprasData ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Data is out of range", "OutOfRange", 1, "");
            AnyError = 1;
         }
         nIsDirty_12 = 1;
         A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
         /* Using cursor BC000D8 */
         pr_default.execute(6, new Object[] {A54ClienteCarrinhoComprasId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASID");
            AnyError = 1;
         }
         A55ClienteCarrinhoComprasNome = BC000D8_A55ClienteCarrinhoComprasNome[0];
         A56ClienteCarrinhoComprasEndereco = BC000D8_A56ClienteCarrinhoComprasEndereco[0];
         A57ClienteCarrinhoComprasPaisId = BC000D8_A57ClienteCarrinhoComprasPaisId[0];
         pr_default.close(6);
         /* Using cursor BC000D9 */
         pr_default.execute(7, new Object[] {A57ClienteCarrinhoComprasPaisId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASPAISID");
            AnyError = 1;
         }
         A58ClienteCarrinhoComprasPaisNome = BC000D9_A58ClienteCarrinhoComprasPaisNome[0];
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0D12( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D12( )
      {
         /* Using cursor BC000D14 */
         pr_default.execute(10, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(10);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D7 */
         pr_default.execute(5, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0D12( 9) ;
            RcdFound12 = 1;
            A52CarrinhoComprasId = BC000D7_A52CarrinhoComprasId[0];
            A53CarrinhoComprasData = BC000D7_A53CarrinhoComprasData[0];
            A54ClienteCarrinhoComprasId = BC000D7_A54ClienteCarrinhoComprasId[0];
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0D12( ) ;
            }
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0D12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode12;
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D12( ) ;
         if ( RcdFound12 == 0 )
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
         CONFIRM_0D0( ) ;
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

      protected void CheckOptimisticConcurrency0D12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D6 */
            pr_default.execute(4, new Object[] {A52CarrinhoComprasId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoCompras"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z53CarrinhoComprasData ) != DateTimeUtil.ResetTime ( BC000D6_A53CarrinhoComprasData[0] ) ) || ( Z54ClienteCarrinhoComprasId != BC000D6_A54ClienteCarrinhoComprasId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CarrinhoCompras"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D12( )
      {
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D12( 0) ;
            CheckOptimisticConcurrency0D12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D15 */
                     pr_default.execute(11, new Object[] {A52CarrinhoComprasId, A53CarrinhoComprasData, A54ClienteCarrinhoComprasId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoCompras");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ProcessLevel0D12( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load0D12( ) ;
            }
            EndLevel0D12( ) ;
         }
         CloseExtendedTableCursors0D12( ) ;
      }

      protected void Update0D12( )
      {
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D16 */
                     pr_default.execute(12, new Object[] {A53CarrinhoComprasData, A54ClienteCarrinhoComprasId, A52CarrinhoComprasId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoCompras");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoCompras"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0D12( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel0D12( ) ;
         }
         CloseExtendedTableCursors0D12( ) ;
      }

      protected void DeferredUpdate0D12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D12( ) ;
            AfterConfirm0D12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D12( ) ;
               if ( AnyError == 0 )
               {
                  A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                  n62CarrinhoComprasPrecoTotal = false;
                  A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                  ScanKeyStart0D13( ) ;
                  while ( RcdFound13 != 0 )
                  {
                     getByPrimaryKey0D13( ) ;
                     Delete0D13( ) ;
                     ScanKeyNext0D13( ) ;
                     O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                     n62CarrinhoComprasPrecoTotal = false;
                     O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                  }
                  ScanKeyEnd0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D17 */
                     pr_default.execute(13, new Object[] {A52CarrinhoComprasId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoCompras");
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
         }
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0D12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D19 */
            pr_default.execute(14, new Object[] {A52CarrinhoComprasId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A62CarrinhoComprasPrecoTotal = BC000D19_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = BC000D19_n62CarrinhoComprasPrecoTotal[0];
            }
            else
            {
               A62CarrinhoComprasPrecoTotal = 0;
               n62CarrinhoComprasPrecoTotal = false;
            }
            pr_default.close(14);
            if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
            {
               A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
            }
            else
            {
               A65CarrinhoComprasPontos = 0;
            }
            A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
            /* Using cursor BC000D20 */
            pr_default.execute(15, new Object[] {A54ClienteCarrinhoComprasId});
            A55ClienteCarrinhoComprasNome = BC000D20_A55ClienteCarrinhoComprasNome[0];
            A56ClienteCarrinhoComprasEndereco = BC000D20_A56ClienteCarrinhoComprasEndereco[0];
            A57ClienteCarrinhoComprasPaisId = BC000D20_A57ClienteCarrinhoComprasPaisId[0];
            pr_default.close(15);
            /* Using cursor BC000D21 */
            pr_default.execute(16, new Object[] {A57ClienteCarrinhoComprasPaisId});
            A58ClienteCarrinhoComprasPaisNome = BC000D21_A58ClienteCarrinhoComprasPaisNome[0];
            pr_default.close(16);
            if ( ( DateTimeUtil.ResetTime ( A53CarrinhoComprasData ) == DateTimeUtil.ResetTime ( Gx_date ) ) && IsDlt( )  )
            {
               GX_msglist.addItem("Não é permitido excluir registros do carrinho de hoje", 1, "");
               AnyError = 1;
            }
         }
      }

      protected void ProcessNestedLevel0D13( )
      {
         s62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         s65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
         nGXsfl_13_idx = 0;
         while ( nGXsfl_13_idx < bcCarrinhoCompras.gxTpr_Produtos.Count )
         {
            ReadRow0D13( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound13 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_13 != 0 ) )
            {
               standaloneNotModal0D13( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0D13( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0D13( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0D13( ) ;
                  }
               }
               O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
               n62CarrinhoComprasPrecoTotal = false;
               O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
            }
            KeyVarsToRow13( ((SdtCarrinhoCompras_Produtos)bcCarrinhoCompras.gxTpr_Produtos.Item(nGXsfl_13_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_13_idx = 0;
            while ( nGXsfl_13_idx < bcCarrinhoCompras.gxTpr_Produtos.Count )
            {
               ReadRow0D13( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound13 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bcCarrinhoCompras.gxTpr_Produtos.RemoveElement(nGXsfl_13_idx);
                  nGXsfl_13_idx = (int)(nGXsfl_13_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0D13( ) ;
                  VarsToRow13( ((SdtCarrinhoCompras_Produtos)bcCarrinhoCompras.gxTpr_Produtos.Item(nGXsfl_13_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0D13( ) ;
         if ( AnyError != 0 )
         {
            O62CarrinhoComprasPrecoTotal = s62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            O65CarrinhoComprasPontos = s65CarrinhoComprasPontos;
         }
         nRcdExists_13 = 0;
         nIsMod_13 = 0;
         Gxremove13 = 0;
      }

      protected void ProcessLevel0D12( )
      {
         /* Save parent mode. */
         sMode12 = Gx_mode;
         ProcessNestedLevel0D13( ) ;
         if ( AnyError != 0 )
         {
            O62CarrinhoComprasPrecoTotal = s62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            O65CarrinhoComprasPontos = s65CarrinhoComprasPontos;
         }
         /* Restore parent mode. */
         Gx_mode = sMode12;
         /* ' Update level parameters */
      }

      protected void EndLevel0D12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D12( ) ;
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

      public void ScanKeyStart0D12( )
      {
         /* Scan By routine */
         /* Using cursor BC000D23 */
         pr_default.execute(17, new Object[] {A52CarrinhoComprasId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound12 = 1;
            A52CarrinhoComprasId = BC000D23_A52CarrinhoComprasId[0];
            A53CarrinhoComprasData = BC000D23_A53CarrinhoComprasData[0];
            A55ClienteCarrinhoComprasNome = BC000D23_A55ClienteCarrinhoComprasNome[0];
            A56ClienteCarrinhoComprasEndereco = BC000D23_A56ClienteCarrinhoComprasEndereco[0];
            A58ClienteCarrinhoComprasPaisNome = BC000D23_A58ClienteCarrinhoComprasPaisNome[0];
            A54ClienteCarrinhoComprasId = BC000D23_A54ClienteCarrinhoComprasId[0];
            A57ClienteCarrinhoComprasPaisId = BC000D23_A57ClienteCarrinhoComprasPaisId[0];
            A62CarrinhoComprasPrecoTotal = BC000D23_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = BC000D23_n62CarrinhoComprasPrecoTotal[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D12( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound12 = 0;
         ScanKeyLoad0D12( ) ;
      }

      protected void ScanKeyLoad0D12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound12 = 1;
            A52CarrinhoComprasId = BC000D23_A52CarrinhoComprasId[0];
            A53CarrinhoComprasData = BC000D23_A53CarrinhoComprasData[0];
            A55ClienteCarrinhoComprasNome = BC000D23_A55ClienteCarrinhoComprasNome[0];
            A56ClienteCarrinhoComprasEndereco = BC000D23_A56ClienteCarrinhoComprasEndereco[0];
            A58ClienteCarrinhoComprasPaisNome = BC000D23_A58ClienteCarrinhoComprasPaisNome[0];
            A54ClienteCarrinhoComprasId = BC000D23_A54ClienteCarrinhoComprasId[0];
            A57ClienteCarrinhoComprasPaisId = BC000D23_A57ClienteCarrinhoComprasPaisId[0];
            A62CarrinhoComprasPrecoTotal = BC000D23_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = BC000D23_n62CarrinhoComprasPrecoTotal[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0D12( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0D12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D12( )
      {
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z60CarrinhoComprasProdutosQuantid = A60CarrinhoComprasProdutosQuantid;
            Z64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
         }
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z30CategoriaProdutoId = A30CategoriaProdutoId;
            Z20ProdutoNome = A20ProdutoNome;
            Z22ProdutoPreco = A22ProdutoPreco;
            Z64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z31CategoriaProdutoNome = A31CategoriaProdutoNome;
            Z64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
         }
         if ( GX_JID == -13 )
         {
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            Z60CarrinhoComprasProdutosQuantid = A60CarrinhoComprasProdutosQuantid;
            Z19ProdutoId = A19ProdutoId;
            Z30CategoriaProdutoId = A30CategoriaProdutoId;
            Z20ProdutoNome = A20ProdutoNome;
            Z22ProdutoPreco = A22ProdutoPreco;
            Z23ProdutoImagem = A23ProdutoImagem;
            Z40000ProdutoImagem_GXI = A40000ProdutoImagem_GXI;
            Z31CategoriaProdutoNome = A31CategoriaProdutoNome;
         }
      }

      protected void standaloneNotModal0D13( )
      {
      }

      protected void standaloneModal0D13( )
      {
      }

      protected void Load0D13( )
      {
         /* Using cursor BC000D24 */
         pr_default.execute(18, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound13 = 1;
            A30CategoriaProdutoId = BC000D24_A30CategoriaProdutoId[0];
            A20ProdutoNome = BC000D24_A20ProdutoNome[0];
            A22ProdutoPreco = BC000D24_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC000D24_A40000ProdutoImagem_GXI[0];
            A60CarrinhoComprasProdutosQuantid = BC000D24_A60CarrinhoComprasProdutosQuantid[0];
            A31CategoriaProdutoNome = BC000D24_A31CategoriaProdutoNome[0];
            A23ProdutoImagem = BC000D24_A23ProdutoImagem[0];
            ZM0D13( -13) ;
         }
         pr_default.close(18);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
         if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Joalheria") == 0 )
         {
            A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*1.05m));
         }
         else
         {
            if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Entreterimento") == 0 )
            {
               A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*0.9m));
            }
            else
            {
               A64ProdutosPrecoTotal = (decimal)(A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco);
            }
         }
         O64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
         if ( IsIns( )  )
         {
            A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal);
            n62CarrinhoComprasPrecoTotal = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal-O64ProdutosPrecoTotal);
               n62CarrinhoComprasPrecoTotal = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal-O64ProdutosPrecoTotal);
                  n62CarrinhoComprasPrecoTotal = false;
               }
            }
         }
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
         }
         else
         {
            A65CarrinhoComprasPontos = 0;
         }
      }

      protected void CheckExtendedTable0D13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         standaloneModal0D13( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Produto'.", "ForeignKeyNotFound", 1, "PRODUTOID");
            AnyError = 1;
         }
         A30CategoriaProdutoId = BC000D4_A30CategoriaProdutoId[0];
         A20ProdutoNome = BC000D4_A20ProdutoNome[0];
         A22ProdutoPreco = BC000D4_A22ProdutoPreco[0];
         A40000ProdutoImagem_GXI = BC000D4_A40000ProdutoImagem_GXI[0];
         A23ProdutoImagem = BC000D4_A23ProdutoImagem[0];
         pr_default.close(2);
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
         }
         A31CategoriaProdutoNome = BC000D5_A31CategoriaProdutoNome[0];
         pr_default.close(3);
         if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Joalheria") == 0 )
         {
            nIsDirty_13 = 1;
            A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*1.05m));
         }
         else
         {
            if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Entreterimento") == 0 )
            {
               nIsDirty_13 = 1;
               A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*0.9m));
            }
            else
            {
               nIsDirty_13 = 1;
               A64ProdutosPrecoTotal = (decimal)(A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco);
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_13 = 1;
            A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal);
            n62CarrinhoComprasPrecoTotal = false;
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_13 = 1;
               A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal-O64ProdutosPrecoTotal);
               n62CarrinhoComprasPrecoTotal = false;
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_13 = 1;
                  A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal-O64ProdutosPrecoTotal);
                  n62CarrinhoComprasPrecoTotal = false;
               }
            }
         }
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            nIsDirty_13 = 1;
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
         }
         else
         {
            nIsDirty_13 = 1;
            A65CarrinhoComprasPontos = 0;
         }
      }

      protected void CloseExtendedTableCursors0D13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0D13( )
      {
      }

      protected void GetKey0D13( )
      {
         /* Using cursor BC000D25 */
         pr_default.execute(19, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(19);
      }

      protected void getByPrimaryKey0D13( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 13) ;
            RcdFound13 = 1;
            InitializeNonKey0D13( ) ;
            A60CarrinhoComprasProdutosQuantid = BC000D3_A60CarrinhoComprasProdutosQuantid[0];
            A19ProdutoId = BC000D3_A19ProdutoId[0];
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            Z19ProdutoId = A19ProdutoId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0D13( ) ;
            Load0D13( ) ;
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0D13( ) ;
            Gx_mode = sMode13;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0D13( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoComprasProdutos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z60CarrinhoComprasProdutosQuantid != BC000D2_A60CarrinhoComprasProdutosQuantid[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CarrinhoComprasProdutos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D26 */
                     pr_default.execute(20, new Object[] {A52CarrinhoComprasId, A60CarrinhoComprasProdutosQuantid, A19ProdutoId});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoComprasProdutos");
                     if ( (pr_default.getStatus(20) == 1) )
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D27 */
                     pr_default.execute(21, new Object[] {A60CarrinhoComprasProdutosQuantid, A52CarrinhoComprasId, A19ProdutoId});
                     pr_default.close(21);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoComprasProdutos");
                     if ( (pr_default.getStatus(21) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoComprasProdutos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0D13( ) ;
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
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void Delete0D13( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D28 */
                  pr_default.execute(22, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("CarrinhoComprasProdutos");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal0D13( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D29 */
            pr_default.execute(23, new Object[] {A19ProdutoId});
            A30CategoriaProdutoId = BC000D29_A30CategoriaProdutoId[0];
            A20ProdutoNome = BC000D29_A20ProdutoNome[0];
            A22ProdutoPreco = BC000D29_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC000D29_A40000ProdutoImagem_GXI[0];
            A23ProdutoImagem = BC000D29_A23ProdutoImagem[0];
            pr_default.close(23);
            /* Using cursor BC000D30 */
            pr_default.execute(24, new Object[] {A30CategoriaProdutoId});
            A31CategoriaProdutoNome = BC000D30_A31CategoriaProdutoNome[0];
            pr_default.close(24);
            if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Joalheria") == 0 )
            {
               A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*1.05m));
            }
            else
            {
               if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Entreterimento") == 0 )
               {
                  A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*0.9m));
               }
               else
               {
                  A64ProdutosPrecoTotal = (decimal)(A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco);
               }
            }
            if ( IsIns( )  )
            {
               A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal);
               n62CarrinhoComprasPrecoTotal = false;
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal-O64ProdutosPrecoTotal);
                  n62CarrinhoComprasPrecoTotal = false;
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal-O64ProdutosPrecoTotal);
                     n62CarrinhoComprasPrecoTotal = false;
                  }
               }
            }
            if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
            {
               A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
            }
            else
            {
               A65CarrinhoComprasPontos = 0;
            }
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0D13( )
      {
         /* Scan By routine */
         /* Using cursor BC000D31 */
         pr_default.execute(25, new Object[] {A52CarrinhoComprasId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound13 = 1;
            A30CategoriaProdutoId = BC000D31_A30CategoriaProdutoId[0];
            A20ProdutoNome = BC000D31_A20ProdutoNome[0];
            A22ProdutoPreco = BC000D31_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC000D31_A40000ProdutoImagem_GXI[0];
            A60CarrinhoComprasProdutosQuantid = BC000D31_A60CarrinhoComprasProdutosQuantid[0];
            A31CategoriaProdutoNome = BC000D31_A31CategoriaProdutoNome[0];
            A19ProdutoId = BC000D31_A19ProdutoId[0];
            A23ProdutoImagem = BC000D31_A23ProdutoImagem[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound13 = 0;
         ScanKeyLoad0D13( ) ;
      }

      protected void ScanKeyLoad0D13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound13 = 1;
            A30CategoriaProdutoId = BC000D31_A30CategoriaProdutoId[0];
            A20ProdutoNome = BC000D31_A20ProdutoNome[0];
            A22ProdutoPreco = BC000D31_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC000D31_A40000ProdutoImagem_GXI[0];
            A60CarrinhoComprasProdutosQuantid = BC000D31_A60CarrinhoComprasProdutosQuantid[0];
            A31CategoriaProdutoNome = BC000D31_A31CategoriaProdutoNome[0];
            A19ProdutoId = BC000D31_A19ProdutoId[0];
            A23ProdutoImagem = BC000D31_A23ProdutoImagem[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0D13( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm0D13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void send_integrity_lvl_hashes0D12( )
      {
      }

      protected void AddRow0D12( )
      {
         VarsToRow12( bcCarrinhoCompras) ;
      }

      protected void ReadRow0D12( )
      {
         RowToVars12( bcCarrinhoCompras, 1) ;
      }

      protected void AddRow0D13( )
      {
         SdtCarrinhoCompras_Produtos obj13;
         obj13 = new SdtCarrinhoCompras_Produtos(context);
         VarsToRow13( obj13) ;
         bcCarrinhoCompras.gxTpr_Produtos.Add(obj13, 0);
         obj13.gxTpr_Mode = "UPD";
         obj13.gxTpr_Modified = 0;
      }

      protected void ReadRow0D13( )
      {
         nGXsfl_13_idx = (int)(nGXsfl_13_idx+1);
         RowToVars13( ((SdtCarrinhoCompras_Produtos)bcCarrinhoCompras.gxTpr_Produtos.Item(nGXsfl_13_idx)), 1) ;
      }

      protected void InitializeNonKey0D12( )
      {
         A65CarrinhoComprasPontos = 0;
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         A54ClienteCarrinhoComprasId = 0;
         A55ClienteCarrinhoComprasNome = "";
         A56ClienteCarrinhoComprasEndereco = "";
         A57ClienteCarrinhoComprasPaisId = 0;
         A58ClienteCarrinhoComprasPaisNome = "";
         A62CarrinhoComprasPrecoTotal = 0;
         n62CarrinhoComprasPrecoTotal = false;
         A53CarrinhoComprasData = Gx_date;
         O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         Z53CarrinhoComprasData = DateTime.MinValue;
         Z54ClienteCarrinhoComprasId = 0;
      }

      protected void InitAll0D12( )
      {
         A52CarrinhoComprasId = 0;
         InitializeNonKey0D12( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A53CarrinhoComprasData = i53CarrinhoComprasData;
      }

      protected void InitializeNonKey0D13( )
      {
         A30CategoriaProdutoId = 0;
         A64ProdutosPrecoTotal = 0;
         A20ProdutoNome = "";
         A22ProdutoPreco = 0;
         A23ProdutoImagem = "";
         A40000ProdutoImagem_GXI = "";
         A60CarrinhoComprasProdutosQuantid = 0;
         A31CategoriaProdutoNome = "";
         O64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
         Z60CarrinhoComprasProdutosQuantid = 0;
      }

      protected void InitAll0D13( )
      {
         A19ProdutoId = 0;
         InitializeNonKey0D13( ) ;
      }

      protected void StandaloneModalInsert0D13( )
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

      public void VarsToRow12( SdtCarrinhoCompras obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Carrinhocompraspontos = A65CarrinhoComprasPontos;
         obj12.gxTpr_Carrinhocomprasdataentrega = A63CarrinhoComprasDataEntrega;
         obj12.gxTpr_Clientecarrinhocomprasid = A54ClienteCarrinhoComprasId;
         obj12.gxTpr_Clientecarrinhocomprasnome = A55ClienteCarrinhoComprasNome;
         obj12.gxTpr_Clientecarrinhocomprasendereco = A56ClienteCarrinhoComprasEndereco;
         obj12.gxTpr_Clientecarrinhocompraspaisid = A57ClienteCarrinhoComprasPaisId;
         obj12.gxTpr_Clientecarrinhocompraspaisnome = A58ClienteCarrinhoComprasPaisNome;
         obj12.gxTpr_Carrinhocomprasprecototal = A62CarrinhoComprasPrecoTotal;
         obj12.gxTpr_Carrinhocomprasdata = A53CarrinhoComprasData;
         obj12.gxTpr_Carrinhocomprasid = A52CarrinhoComprasId;
         obj12.gxTpr_Carrinhocomprasid_Z = Z52CarrinhoComprasId;
         obj12.gxTpr_Carrinhocomprasdata_Z = Z53CarrinhoComprasData;
         obj12.gxTpr_Clientecarrinhocomprasid_Z = Z54ClienteCarrinhoComprasId;
         obj12.gxTpr_Clientecarrinhocomprasnome_Z = Z55ClienteCarrinhoComprasNome;
         obj12.gxTpr_Clientecarrinhocomprasendereco_Z = Z56ClienteCarrinhoComprasEndereco;
         obj12.gxTpr_Clientecarrinhocompraspaisid_Z = Z57ClienteCarrinhoComprasPaisId;
         obj12.gxTpr_Clientecarrinhocompraspaisnome_Z = Z58ClienteCarrinhoComprasPaisNome;
         obj12.gxTpr_Carrinhocomprasprecototal_Z = Z62CarrinhoComprasPrecoTotal;
         obj12.gxTpr_Carrinhocomprasdataentrega_Z = Z63CarrinhoComprasDataEntrega;
         obj12.gxTpr_Carrinhocompraspontos_Z = Z65CarrinhoComprasPontos;
         obj12.gxTpr_Carrinhocomprasprecototal_N = (short)(Convert.ToInt16(n62CarrinhoComprasPrecoTotal));
         obj12.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow12( SdtCarrinhoCompras obj12 )
      {
         obj12.gxTpr_Carrinhocomprasid = A52CarrinhoComprasId;
         return  ;
      }

      public void RowToVars12( SdtCarrinhoCompras obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A65CarrinhoComprasPontos = obj12.gxTpr_Carrinhocompraspontos;
         A63CarrinhoComprasDataEntrega = obj12.gxTpr_Carrinhocomprasdataentrega;
         A54ClienteCarrinhoComprasId = obj12.gxTpr_Clientecarrinhocomprasid;
         A55ClienteCarrinhoComprasNome = obj12.gxTpr_Clientecarrinhocomprasnome;
         A56ClienteCarrinhoComprasEndereco = obj12.gxTpr_Clientecarrinhocomprasendereco;
         A57ClienteCarrinhoComprasPaisId = obj12.gxTpr_Clientecarrinhocompraspaisid;
         A58ClienteCarrinhoComprasPaisNome = obj12.gxTpr_Clientecarrinhocompraspaisnome;
         A62CarrinhoComprasPrecoTotal = obj12.gxTpr_Carrinhocomprasprecototal;
         n62CarrinhoComprasPrecoTotal = false;
         A53CarrinhoComprasData = obj12.gxTpr_Carrinhocomprasdata;
         A52CarrinhoComprasId = obj12.gxTpr_Carrinhocomprasid;
         Z52CarrinhoComprasId = obj12.gxTpr_Carrinhocomprasid_Z;
         Z53CarrinhoComprasData = obj12.gxTpr_Carrinhocomprasdata_Z;
         Z54ClienteCarrinhoComprasId = obj12.gxTpr_Clientecarrinhocomprasid_Z;
         Z55ClienteCarrinhoComprasNome = obj12.gxTpr_Clientecarrinhocomprasnome_Z;
         Z56ClienteCarrinhoComprasEndereco = obj12.gxTpr_Clientecarrinhocomprasendereco_Z;
         Z57ClienteCarrinhoComprasPaisId = obj12.gxTpr_Clientecarrinhocompraspaisid_Z;
         Z58ClienteCarrinhoComprasPaisNome = obj12.gxTpr_Clientecarrinhocompraspaisnome_Z;
         Z62CarrinhoComprasPrecoTotal = obj12.gxTpr_Carrinhocomprasprecototal_Z;
         O62CarrinhoComprasPrecoTotal = obj12.gxTpr_Carrinhocomprasprecototal_Z;
         Z63CarrinhoComprasDataEntrega = obj12.gxTpr_Carrinhocomprasdataentrega_Z;
         Z65CarrinhoComprasPontos = obj12.gxTpr_Carrinhocompraspontos_Z;
         n62CarrinhoComprasPrecoTotal = (bool)(Convert.ToBoolean(obj12.gxTpr_Carrinhocomprasprecototal_N));
         Gx_mode = obj12.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow13( SdtCarrinhoCompras_Produtos obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Produtosprecototal = A64ProdutosPrecoTotal;
         obj13.gxTpr_Produtonome = A20ProdutoNome;
         obj13.gxTpr_Produtopreco = A22ProdutoPreco;
         obj13.gxTpr_Produtoimagem = A23ProdutoImagem;
         obj13.gxTpr_Produtoimagem_gxi = A40000ProdutoImagem_GXI;
         obj13.gxTpr_Carrinhocomprasprodutosquantidade = A60CarrinhoComprasProdutosQuantid;
         obj13.gxTpr_Produtoid = A19ProdutoId;
         obj13.gxTpr_Produtoid_Z = Z19ProdutoId;
         obj13.gxTpr_Produtonome_Z = Z20ProdutoNome;
         obj13.gxTpr_Produtopreco_Z = Z22ProdutoPreco;
         obj13.gxTpr_Carrinhocomprasprodutosquantidade_Z = Z60CarrinhoComprasProdutosQuantid;
         obj13.gxTpr_Produtosprecototal_Z = Z64ProdutosPrecoTotal;
         obj13.gxTpr_Produtoimagem_gxi_Z = Z40000ProdutoImagem_GXI;
         obj13.gxTpr_Modified = nIsMod_13;
         return  ;
      }

      public void KeyVarsToRow13( SdtCarrinhoCompras_Produtos obj13 )
      {
         obj13.gxTpr_Produtoid = A19ProdutoId;
         return  ;
      }

      public void RowToVars13( SdtCarrinhoCompras_Produtos obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A64ProdutosPrecoTotal = obj13.gxTpr_Produtosprecototal;
         A20ProdutoNome = obj13.gxTpr_Produtonome;
         A22ProdutoPreco = obj13.gxTpr_Produtopreco;
         A23ProdutoImagem = obj13.gxTpr_Produtoimagem;
         A40000ProdutoImagem_GXI = obj13.gxTpr_Produtoimagem_gxi;
         A60CarrinhoComprasProdutosQuantid = obj13.gxTpr_Carrinhocomprasprodutosquantidade;
         A19ProdutoId = obj13.gxTpr_Produtoid;
         Z19ProdutoId = obj13.gxTpr_Produtoid_Z;
         Z20ProdutoNome = obj13.gxTpr_Produtonome_Z;
         Z22ProdutoPreco = obj13.gxTpr_Produtopreco_Z;
         Z60CarrinhoComprasProdutosQuantid = obj13.gxTpr_Carrinhocomprasprodutosquantidade_Z;
         Z64ProdutosPrecoTotal = obj13.gxTpr_Produtosprecototal_Z;
         O64ProdutosPrecoTotal = obj13.gxTpr_Produtosprecototal_Z;
         Z40000ProdutoImagem_GXI = obj13.gxTpr_Produtoimagem_gxi_Z;
         nIsMod_13 = obj13.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A52CarrinhoComprasId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D12( ) ;
         ScanKeyStart0D12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
         }
         ZM0D12( -9) ;
         OnLoadActions0D12( ) ;
         AddRow0D12( ) ;
         bcCarrinhoCompras.gxTpr_Produtos.ClearCollection();
         if ( RcdFound12 == 1 )
         {
            ScanKeyStart0D13( ) ;
            nGXsfl_13_idx = 1;
            while ( RcdFound13 != 0 )
            {
               O64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
               Z52CarrinhoComprasId = A52CarrinhoComprasId;
               Z19ProdutoId = A19ProdutoId;
               ZM0D13( -13) ;
               OnLoadActions0D13( ) ;
               nRcdExists_13 = 1;
               nIsMod_13 = 0;
               Z64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
               AddRow0D13( ) ;
               nGXsfl_13_idx = (int)(nGXsfl_13_idx+1);
               ScanKeyNext0D13( ) ;
            }
            ScanKeyEnd0D13( ) ;
         }
         ScanKeyEnd0D12( ) ;
         if ( RcdFound12 == 0 )
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
         RowToVars12( bcCarrinhoCompras, 0) ;
         ScanKeyStart0D12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
         }
         ZM0D12( -9) ;
         OnLoadActions0D12( ) ;
         AddRow0D12( ) ;
         bcCarrinhoCompras.gxTpr_Produtos.ClearCollection();
         if ( RcdFound12 == 1 )
         {
            ScanKeyStart0D13( ) ;
            nGXsfl_13_idx = 1;
            while ( RcdFound13 != 0 )
            {
               O64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
               Z52CarrinhoComprasId = A52CarrinhoComprasId;
               Z19ProdutoId = A19ProdutoId;
               ZM0D13( -13) ;
               OnLoadActions0D13( ) ;
               nRcdExists_13 = 1;
               nIsMod_13 = 0;
               Z64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
               AddRow0D13( ) ;
               nGXsfl_13_idx = (int)(nGXsfl_13_idx+1);
               ScanKeyNext0D13( ) ;
            }
            ScanKeyEnd0D13( ) ;
         }
         ScanKeyEnd0D12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0D12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
            Insert0D12( ) ;
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A52CarrinhoComprasId != Z52CarrinhoComprasId )
               {
                  A52CarrinhoComprasId = Z52CarrinhoComprasId;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                  n62CarrinhoComprasPrecoTotal = false;
                  A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                  n62CarrinhoComprasPrecoTotal = false;
                  A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                  Update0D12( ) ;
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
                  if ( A52CarrinhoComprasId != Z52CarrinhoComprasId )
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
                        A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                        n62CarrinhoComprasPrecoTotal = false;
                        A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                        Insert0D12( ) ;
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
                        A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                        n62CarrinhoComprasPrecoTotal = false;
                        A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                        Insert0D12( ) ;
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
         RowToVars12( bcCarrinhoCompras, 1) ;
         SaveImpl( ) ;
         VarsToRow12( bcCarrinhoCompras) ;
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
         RowToVars12( bcCarrinhoCompras, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
         Insert0D12( ) ;
         AfterTrn( ) ;
         VarsToRow12( bcCarrinhoCompras) ;
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
            SdtCarrinhoCompras auxBC = new SdtCarrinhoCompras(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A52CarrinhoComprasId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcCarrinhoCompras);
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
         RowToVars12( bcCarrinhoCompras, 1) ;
         UpdateImpl( ) ;
         VarsToRow12( bcCarrinhoCompras) ;
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
         RowToVars12( bcCarrinhoCompras, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D12( ) ;
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
         VarsToRow12( bcCarrinhoCompras) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars12( bcCarrinhoCompras, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0D12( ) ;
         if ( RcdFound12 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A52CarrinhoComprasId != Z52CarrinhoComprasId )
            {
               A52CarrinhoComprasId = Z52CarrinhoComprasId;
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
            if ( A52CarrinhoComprasId != Z52CarrinhoComprasId )
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
         pr_default.close(5);
         pr_default.close(1);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
         pr_default.close(23);
         pr_default.close(24);
         context.RollbackDataStores("carrinhocompras_bc",pr_default);
         VarsToRow12( bcCarrinhoCompras) ;
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
         Gx_mode = bcCarrinhoCompras.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcCarrinhoCompras.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcCarrinhoCompras )
         {
            bcCarrinhoCompras = (SdtCarrinhoCompras)(sdt);
            if ( StringUtil.StrCmp(bcCarrinhoCompras.gxTpr_Mode, "") == 0 )
            {
               bcCarrinhoCompras.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow12( bcCarrinhoCompras) ;
            }
            else
            {
               RowToVars12( bcCarrinhoCompras, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcCarrinhoCompras.gxTpr_Mode, "") == 0 )
            {
               bcCarrinhoCompras.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars12( bcCarrinhoCompras, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCarrinhoCompras CarrinhoCompras_BC
      {
         get {
            return bcCarrinhoCompras ;
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
         pr_default.close(23);
         pr_default.close(24);
         pr_default.close(5);
         pr_default.close(15);
         pr_default.close(16);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         sMode12 = "";
         Z53CarrinhoComprasData = DateTime.MinValue;
         A53CarrinhoComprasData = DateTime.MinValue;
         Z63CarrinhoComprasDataEntrega = DateTime.MinValue;
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         Z55ClienteCarrinhoComprasNome = "";
         A55ClienteCarrinhoComprasNome = "";
         Z56ClienteCarrinhoComprasEndereco = "";
         A56ClienteCarrinhoComprasEndereco = "";
         Z58ClienteCarrinhoComprasPaisNome = "";
         A58ClienteCarrinhoComprasPaisNome = "";
         Gx_date = DateTime.MinValue;
         BC000D13_A52CarrinhoComprasId = new short[1] ;
         BC000D13_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         BC000D13_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         BC000D13_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         BC000D13_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         BC000D13_A54ClienteCarrinhoComprasId = new short[1] ;
         BC000D13_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         BC000D13_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         BC000D13_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         BC000D11_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         BC000D11_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         BC000D8_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         BC000D8_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         BC000D8_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         BC000D9_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         BC000D14_A52CarrinhoComprasId = new short[1] ;
         BC000D7_A52CarrinhoComprasId = new short[1] ;
         BC000D7_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         BC000D7_A54ClienteCarrinhoComprasId = new short[1] ;
         BC000D6_A52CarrinhoComprasId = new short[1] ;
         BC000D6_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         BC000D6_A54ClienteCarrinhoComprasId = new short[1] ;
         BC000D19_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         BC000D19_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         BC000D20_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         BC000D20_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         BC000D20_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         BC000D21_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         BC000D23_A52CarrinhoComprasId = new short[1] ;
         BC000D23_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         BC000D23_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         BC000D23_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         BC000D23_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         BC000D23_A54ClienteCarrinhoComprasId = new short[1] ;
         BC000D23_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         BC000D23_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         BC000D23_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         Z20ProdutoNome = "";
         A20ProdutoNome = "";
         Z31CategoriaProdutoNome = "";
         A31CategoriaProdutoNome = "";
         Z23ProdutoImagem = "";
         A23ProdutoImagem = "";
         Z40000ProdutoImagem_GXI = "";
         A40000ProdutoImagem_GXI = "";
         BC000D24_A30CategoriaProdutoId = new short[1] ;
         BC000D24_A52CarrinhoComprasId = new short[1] ;
         BC000D24_A20ProdutoNome = new string[] {""} ;
         BC000D24_A22ProdutoPreco = new decimal[1] ;
         BC000D24_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC000D24_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         BC000D24_A31CategoriaProdutoNome = new string[] {""} ;
         BC000D24_A19ProdutoId = new short[1] ;
         BC000D24_A23ProdutoImagem = new string[] {""} ;
         BC000D4_A30CategoriaProdutoId = new short[1] ;
         BC000D4_A20ProdutoNome = new string[] {""} ;
         BC000D4_A22ProdutoPreco = new decimal[1] ;
         BC000D4_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC000D4_A23ProdutoImagem = new string[] {""} ;
         BC000D5_A31CategoriaProdutoNome = new string[] {""} ;
         BC000D25_A52CarrinhoComprasId = new short[1] ;
         BC000D25_A19ProdutoId = new short[1] ;
         BC000D3_A52CarrinhoComprasId = new short[1] ;
         BC000D3_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         BC000D3_A19ProdutoId = new short[1] ;
         sMode13 = "";
         BC000D2_A52CarrinhoComprasId = new short[1] ;
         BC000D2_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         BC000D2_A19ProdutoId = new short[1] ;
         BC000D29_A30CategoriaProdutoId = new short[1] ;
         BC000D29_A20ProdutoNome = new string[] {""} ;
         BC000D29_A22ProdutoPreco = new decimal[1] ;
         BC000D29_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC000D29_A23ProdutoImagem = new string[] {""} ;
         BC000D30_A31CategoriaProdutoNome = new string[] {""} ;
         BC000D31_A30CategoriaProdutoId = new short[1] ;
         BC000D31_A52CarrinhoComprasId = new short[1] ;
         BC000D31_A20ProdutoNome = new string[] {""} ;
         BC000D31_A22ProdutoPreco = new decimal[1] ;
         BC000D31_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC000D31_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         BC000D31_A31CategoriaProdutoNome = new string[] {""} ;
         BC000D31_A19ProdutoId = new short[1] ;
         BC000D31_A23ProdutoImagem = new string[] {""} ;
         i53CarrinhoComprasData = DateTime.MinValue;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carrinhocompras_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A52CarrinhoComprasId, BC000D2_A60CarrinhoComprasProdutosQuantid, BC000D2_A19ProdutoId
               }
               , new Object[] {
               BC000D3_A52CarrinhoComprasId, BC000D3_A60CarrinhoComprasProdutosQuantid, BC000D3_A19ProdutoId
               }
               , new Object[] {
               BC000D4_A30CategoriaProdutoId, BC000D4_A20ProdutoNome, BC000D4_A22ProdutoPreco, BC000D4_A40000ProdutoImagem_GXI, BC000D4_A23ProdutoImagem
               }
               , new Object[] {
               BC000D5_A31CategoriaProdutoNome
               }
               , new Object[] {
               BC000D6_A52CarrinhoComprasId, BC000D6_A53CarrinhoComprasData, BC000D6_A54ClienteCarrinhoComprasId
               }
               , new Object[] {
               BC000D7_A52CarrinhoComprasId, BC000D7_A53CarrinhoComprasData, BC000D7_A54ClienteCarrinhoComprasId
               }
               , new Object[] {
               BC000D8_A55ClienteCarrinhoComprasNome, BC000D8_A56ClienteCarrinhoComprasEndereco, BC000D8_A57ClienteCarrinhoComprasPaisId
               }
               , new Object[] {
               BC000D9_A58ClienteCarrinhoComprasPaisNome
               }
               , new Object[] {
               BC000D11_A62CarrinhoComprasPrecoTotal, BC000D11_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               BC000D13_A52CarrinhoComprasId, BC000D13_A53CarrinhoComprasData, BC000D13_A55ClienteCarrinhoComprasNome, BC000D13_A56ClienteCarrinhoComprasEndereco, BC000D13_A58ClienteCarrinhoComprasPaisNome, BC000D13_A54ClienteCarrinhoComprasId, BC000D13_A57ClienteCarrinhoComprasPaisId, BC000D13_A62CarrinhoComprasPrecoTotal, BC000D13_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               BC000D14_A52CarrinhoComprasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D19_A62CarrinhoComprasPrecoTotal, BC000D19_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               BC000D20_A55ClienteCarrinhoComprasNome, BC000D20_A56ClienteCarrinhoComprasEndereco, BC000D20_A57ClienteCarrinhoComprasPaisId
               }
               , new Object[] {
               BC000D21_A58ClienteCarrinhoComprasPaisNome
               }
               , new Object[] {
               BC000D23_A52CarrinhoComprasId, BC000D23_A53CarrinhoComprasData, BC000D23_A55ClienteCarrinhoComprasNome, BC000D23_A56ClienteCarrinhoComprasEndereco, BC000D23_A58ClienteCarrinhoComprasPaisNome, BC000D23_A54ClienteCarrinhoComprasId, BC000D23_A57ClienteCarrinhoComprasPaisId, BC000D23_A62CarrinhoComprasPrecoTotal, BC000D23_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               BC000D24_A30CategoriaProdutoId, BC000D24_A52CarrinhoComprasId, BC000D24_A20ProdutoNome, BC000D24_A22ProdutoPreco, BC000D24_A40000ProdutoImagem_GXI, BC000D24_A60CarrinhoComprasProdutosQuantid, BC000D24_A31CategoriaProdutoNome, BC000D24_A19ProdutoId, BC000D24_A23ProdutoImagem
               }
               , new Object[] {
               BC000D25_A52CarrinhoComprasId, BC000D25_A19ProdutoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D29_A30CategoriaProdutoId, BC000D29_A20ProdutoNome, BC000D29_A22ProdutoPreco, BC000D29_A40000ProdutoImagem_GXI, BC000D29_A23ProdutoImagem
               }
               , new Object[] {
               BC000D30_A31CategoriaProdutoNome
               }
               , new Object[] {
               BC000D31_A30CategoriaProdutoId, BC000D31_A52CarrinhoComprasId, BC000D31_A20ProdutoNome, BC000D31_A22ProdutoPreco, BC000D31_A40000ProdutoImagem_GXI, BC000D31_A60CarrinhoComprasProdutosQuantid, BC000D31_A31CategoriaProdutoNome, BC000D31_A19ProdutoId, BC000D31_A23ProdutoImagem
               }
            }
         );
         Z53CarrinhoComprasData = DateTime.MinValue;
         A53CarrinhoComprasData = DateTime.MinValue;
         i53CarrinhoComprasData = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120D2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z52CarrinhoComprasId ;
      private short A52CarrinhoComprasId ;
      private short nIsMod_13 ;
      private short RcdFound13 ;
      private short GX_JID ;
      private short Z54ClienteCarrinhoComprasId ;
      private short A54ClienteCarrinhoComprasId ;
      private short Z57ClienteCarrinhoComprasPaisId ;
      private short A57ClienteCarrinhoComprasPaisId ;
      private short Gx_BScreen ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private short nRcdExists_13 ;
      private short Gxremove13 ;
      private short Z60CarrinhoComprasProdutosQuantid ;
      private short A60CarrinhoComprasProdutosQuantid ;
      private short Z30CategoriaProdutoId ;
      private short A30CategoriaProdutoId ;
      private short Z19ProdutoId ;
      private short A19ProdutoId ;
      private short nIsDirty_13 ;
      private int trnEnded ;
      private int nGXsfl_13_idx=1 ;
      private decimal s62CarrinhoComprasPrecoTotal ;
      private decimal O62CarrinhoComprasPrecoTotal ;
      private decimal A62CarrinhoComprasPrecoTotal ;
      private decimal s65CarrinhoComprasPontos ;
      private decimal O65CarrinhoComprasPontos ;
      private decimal A65CarrinhoComprasPontos ;
      private decimal Z62CarrinhoComprasPrecoTotal ;
      private decimal Z65CarrinhoComprasPontos ;
      private decimal Z64ProdutosPrecoTotal ;
      private decimal A64ProdutosPrecoTotal ;
      private decimal Z22ProdutoPreco ;
      private decimal A22ProdutoPreco ;
      private decimal O64ProdutosPrecoTotal ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode12 ;
      private string sMode13 ;
      private DateTime Z53CarrinhoComprasData ;
      private DateTime A53CarrinhoComprasData ;
      private DateTime Z63CarrinhoComprasDataEntrega ;
      private DateTime A63CarrinhoComprasDataEntrega ;
      private DateTime Gx_date ;
      private DateTime i53CarrinhoComprasData ;
      private bool n62CarrinhoComprasPrecoTotal ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z55ClienteCarrinhoComprasNome ;
      private string A55ClienteCarrinhoComprasNome ;
      private string Z56ClienteCarrinhoComprasEndereco ;
      private string A56ClienteCarrinhoComprasEndereco ;
      private string Z58ClienteCarrinhoComprasPaisNome ;
      private string A58ClienteCarrinhoComprasPaisNome ;
      private string Z20ProdutoNome ;
      private string A20ProdutoNome ;
      private string Z31CategoriaProdutoNome ;
      private string A31CategoriaProdutoNome ;
      private string Z40000ProdutoImagem_GXI ;
      private string A40000ProdutoImagem_GXI ;
      private string Z23ProdutoImagem ;
      private string A23ProdutoImagem ;
      private SdtCarrinhoCompras bcCarrinhoCompras ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC000D13_A52CarrinhoComprasId ;
      private DateTime[] BC000D13_A53CarrinhoComprasData ;
      private string[] BC000D13_A55ClienteCarrinhoComprasNome ;
      private string[] BC000D13_A56ClienteCarrinhoComprasEndereco ;
      private string[] BC000D13_A58ClienteCarrinhoComprasPaisNome ;
      private short[] BC000D13_A54ClienteCarrinhoComprasId ;
      private short[] BC000D13_A57ClienteCarrinhoComprasPaisId ;
      private decimal[] BC000D13_A62CarrinhoComprasPrecoTotal ;
      private bool[] BC000D13_n62CarrinhoComprasPrecoTotal ;
      private decimal[] BC000D11_A62CarrinhoComprasPrecoTotal ;
      private bool[] BC000D11_n62CarrinhoComprasPrecoTotal ;
      private string[] BC000D8_A55ClienteCarrinhoComprasNome ;
      private string[] BC000D8_A56ClienteCarrinhoComprasEndereco ;
      private short[] BC000D8_A57ClienteCarrinhoComprasPaisId ;
      private string[] BC000D9_A58ClienteCarrinhoComprasPaisNome ;
      private short[] BC000D14_A52CarrinhoComprasId ;
      private short[] BC000D7_A52CarrinhoComprasId ;
      private DateTime[] BC000D7_A53CarrinhoComprasData ;
      private short[] BC000D7_A54ClienteCarrinhoComprasId ;
      private short[] BC000D6_A52CarrinhoComprasId ;
      private DateTime[] BC000D6_A53CarrinhoComprasData ;
      private short[] BC000D6_A54ClienteCarrinhoComprasId ;
      private decimal[] BC000D19_A62CarrinhoComprasPrecoTotal ;
      private bool[] BC000D19_n62CarrinhoComprasPrecoTotal ;
      private string[] BC000D20_A55ClienteCarrinhoComprasNome ;
      private string[] BC000D20_A56ClienteCarrinhoComprasEndereco ;
      private short[] BC000D20_A57ClienteCarrinhoComprasPaisId ;
      private string[] BC000D21_A58ClienteCarrinhoComprasPaisNome ;
      private short[] BC000D23_A52CarrinhoComprasId ;
      private DateTime[] BC000D23_A53CarrinhoComprasData ;
      private string[] BC000D23_A55ClienteCarrinhoComprasNome ;
      private string[] BC000D23_A56ClienteCarrinhoComprasEndereco ;
      private string[] BC000D23_A58ClienteCarrinhoComprasPaisNome ;
      private short[] BC000D23_A54ClienteCarrinhoComprasId ;
      private short[] BC000D23_A57ClienteCarrinhoComprasPaisId ;
      private decimal[] BC000D23_A62CarrinhoComprasPrecoTotal ;
      private bool[] BC000D23_n62CarrinhoComprasPrecoTotal ;
      private short[] BC000D24_A30CategoriaProdutoId ;
      private short[] BC000D24_A52CarrinhoComprasId ;
      private string[] BC000D24_A20ProdutoNome ;
      private decimal[] BC000D24_A22ProdutoPreco ;
      private string[] BC000D24_A40000ProdutoImagem_GXI ;
      private short[] BC000D24_A60CarrinhoComprasProdutosQuantid ;
      private string[] BC000D24_A31CategoriaProdutoNome ;
      private short[] BC000D24_A19ProdutoId ;
      private string[] BC000D24_A23ProdutoImagem ;
      private short[] BC000D4_A30CategoriaProdutoId ;
      private string[] BC000D4_A20ProdutoNome ;
      private decimal[] BC000D4_A22ProdutoPreco ;
      private string[] BC000D4_A40000ProdutoImagem_GXI ;
      private string[] BC000D4_A23ProdutoImagem ;
      private string[] BC000D5_A31CategoriaProdutoNome ;
      private short[] BC000D25_A52CarrinhoComprasId ;
      private short[] BC000D25_A19ProdutoId ;
      private short[] BC000D3_A52CarrinhoComprasId ;
      private short[] BC000D3_A60CarrinhoComprasProdutosQuantid ;
      private short[] BC000D3_A19ProdutoId ;
      private short[] BC000D2_A52CarrinhoComprasId ;
      private short[] BC000D2_A60CarrinhoComprasProdutosQuantid ;
      private short[] BC000D2_A19ProdutoId ;
      private short[] BC000D29_A30CategoriaProdutoId ;
      private string[] BC000D29_A20ProdutoNome ;
      private decimal[] BC000D29_A22ProdutoPreco ;
      private string[] BC000D29_A40000ProdutoImagem_GXI ;
      private string[] BC000D29_A23ProdutoImagem ;
      private string[] BC000D30_A31CategoriaProdutoNome ;
      private short[] BC000D31_A30CategoriaProdutoId ;
      private short[] BC000D31_A52CarrinhoComprasId ;
      private string[] BC000D31_A20ProdutoNome ;
      private decimal[] BC000D31_A22ProdutoPreco ;
      private string[] BC000D31_A40000ProdutoImagem_GXI ;
      private short[] BC000D31_A60CarrinhoComprasProdutosQuantid ;
      private string[] BC000D31_A31CategoriaProdutoNome ;
      private short[] BC000D31_A19ProdutoId ;
      private string[] BC000D31_A23ProdutoImagem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class carrinhocompras_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new UpdateCursor(def[20])
         ,new UpdateCursor(def[21])
         ,new UpdateCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC000D13;
          prmBC000D13 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D11;
          prmBC000D11 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D8;
          prmBC000D8 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D9;
          prmBC000D9 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasPaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000D14;
          prmBC000D14 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D7;
          prmBC000D7 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D6;
          prmBC000D6 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D15;
          prmBC000D15 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasData",GXType.Date,8,0) ,
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D16;
          prmBC000D16 = new Object[] {
          new ParDef("@CarrinhoComprasData",GXType.Date,8,0) ,
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D17;
          prmBC000D17 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D19;
          prmBC000D19 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D20;
          prmBC000D20 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D21;
          prmBC000D21 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasPaisId",GXType.Int16,4,0)
          };
          Object[] prmBC000D23;
          prmBC000D23 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmBC000D24;
          prmBC000D24 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D4;
          prmBC000D4 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D5;
          prmBC000D5 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D25;
          prmBC000D25 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D3;
          prmBC000D3 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D2;
          prmBC000D2 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D26;
          prmBC000D26 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasProdutosQuantid",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D27;
          prmBC000D27 = new Object[] {
          new ParDef("@CarrinhoComprasProdutosQuantid",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D28;
          prmBC000D28 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D29;
          prmBC000D29 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D30;
          prmBC000D30 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000D31;
          prmBC000D31 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC000D2", "SELECT [CarrinhoComprasId], [CarrinhoComprasProdutosQuantid], [ProdutoId] FROM [CarrinhoComprasProdutos] WITH (UPDLOCK) WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D3", "SELECT [CarrinhoComprasId], [CarrinhoComprasProdutosQuantid], [ProdutoId] FROM [CarrinhoComprasProdutos] WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D4", "SELECT [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoNome], [ProdutoPreco], [ProdutoImagem_GXI], [ProdutoImagem] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D5", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D6", "SELECT [CarrinhoComprasId], [CarrinhoComprasData], [ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId FROM [CarrinhoCompras] WITH (UPDLOCK) WHERE [CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D7", "SELECT [CarrinhoComprasId], [CarrinhoComprasData], [ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId FROM [CarrinhoCompras] WHERE [CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D8", "SELECT [ClienteNome] AS ClienteCarrinhoComprasNome, [ClienteEndereco] AS ClienteCarrinhoComprasEndereco, [PaisClienteId] AS ClienteCarrinhoComprasPaisId FROM [Cliente] WHERE [ClienteId] = @ClienteCarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D9", "SELECT [PaisNome] AS ClienteCarrinhoComprasPaisNome FROM [Pais] WHERE [PaisId] = @ClienteCarrinhoComprasPaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D11", "SELECT COALESCE( T1.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (SELECT SUM(CASE  WHEN T4.[CategoriaNome] = 'Joalheria' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T4.[CategoriaNome] = 'Entreterimento' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T2.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T2 WITH (UPDLOCK) INNER JOIN [Produto] T3 ON T3.[ProdutoId] = T2.[ProdutoId]) INNER JOIN [Categoria] T4 ON T4.[CategoriaId] = T3.[CategoriaProdutoId]) GROUP BY T2.[CarrinhoComprasId] ) T1 WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D13", "SELECT TM1.[CarrinhoComprasId], TM1.[CarrinhoComprasData], T3.[ClienteNome] AS ClienteCarrinhoComprasNome, T3.[ClienteEndereco] AS ClienteCarrinhoComprasEndereco, T4.[PaisNome] AS ClienteCarrinhoComprasPaisNome, TM1.[ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId, T3.[PaisClienteId] AS ClienteCarrinhoComprasPaisId, COALESCE( T2.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM ((([CarrinhoCompras] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T2 ON T2.[CarrinhoComprasId] = TM1.[CarrinhoComprasId]) INNER JOIN [Cliente] T3 ON T3.[ClienteId] = TM1.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisClienteId]) WHERE TM1.[CarrinhoComprasId] = @CarrinhoComprasId ORDER BY TM1.[CarrinhoComprasId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D14", "SELECT [CarrinhoComprasId] FROM [CarrinhoCompras] WHERE [CarrinhoComprasId] = @CarrinhoComprasId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D15", "INSERT INTO [CarrinhoCompras]([CarrinhoComprasId], [CarrinhoComprasData], [ClienteCarrinhoComprasId]) VALUES(@CarrinhoComprasId, @CarrinhoComprasData, @ClienteCarrinhoComprasId)", GxErrorMask.GX_NOMASK,prmBC000D15)
             ,new CursorDef("BC000D16", "UPDATE [CarrinhoCompras] SET [CarrinhoComprasData]=@CarrinhoComprasData, [ClienteCarrinhoComprasId]=@ClienteCarrinhoComprasId  WHERE [CarrinhoComprasId] = @CarrinhoComprasId", GxErrorMask.GX_NOMASK,prmBC000D16)
             ,new CursorDef("BC000D17", "DELETE FROM [CarrinhoCompras]  WHERE [CarrinhoComprasId] = @CarrinhoComprasId", GxErrorMask.GX_NOMASK,prmBC000D17)
             ,new CursorDef("BC000D19", "SELECT COALESCE( T1.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (SELECT SUM(CASE  WHEN T4.[CategoriaNome] = 'Joalheria' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T4.[CategoriaNome] = 'Entreterimento' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T2.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T2 WITH (UPDLOCK) INNER JOIN [Produto] T3 ON T3.[ProdutoId] = T2.[ProdutoId]) INNER JOIN [Categoria] T4 ON T4.[CategoriaId] = T3.[CategoriaProdutoId]) GROUP BY T2.[CarrinhoComprasId] ) T1 WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D20", "SELECT [ClienteNome] AS ClienteCarrinhoComprasNome, [ClienteEndereco] AS ClienteCarrinhoComprasEndereco, [PaisClienteId] AS ClienteCarrinhoComprasPaisId FROM [Cliente] WHERE [ClienteId] = @ClienteCarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D20,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D21", "SELECT [PaisNome] AS ClienteCarrinhoComprasPaisNome FROM [Pais] WHERE [PaisId] = @ClienteCarrinhoComprasPaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D21,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D23", "SELECT TM1.[CarrinhoComprasId], TM1.[CarrinhoComprasData], T3.[ClienteNome] AS ClienteCarrinhoComprasNome, T3.[ClienteEndereco] AS ClienteCarrinhoComprasEndereco, T4.[PaisNome] AS ClienteCarrinhoComprasPaisNome, TM1.[ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId, T3.[PaisClienteId] AS ClienteCarrinhoComprasPaisId, COALESCE( T2.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM ((([CarrinhoCompras] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T2 ON T2.[CarrinhoComprasId] = TM1.[CarrinhoComprasId]) INNER JOIN [Cliente] T3 ON T3.[ClienteId] = TM1.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisClienteId]) WHERE TM1.[CarrinhoComprasId] = @CarrinhoComprasId ORDER BY TM1.[CarrinhoComprasId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D23,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D24", "SELECT T2.[CategoriaProdutoId] AS CategoriaProdutoId, T1.[CarrinhoComprasId], T2.[ProdutoNome], T2.[ProdutoPreco], T2.[ProdutoImagem_GXI], T1.[CarrinhoComprasProdutosQuantid], T3.[CategoriaNome] AS CategoriaProdutoNome, T1.[ProdutoId], T2.[ProdutoImagem] FROM (([CarrinhoComprasProdutos] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[ProdutoId]) INNER JOIN [Categoria] T3 ON T3.[CategoriaId] = T2.[CategoriaProdutoId]) WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId and T1.[ProdutoId] = @ProdutoId ORDER BY T1.[CarrinhoComprasId], T1.[ProdutoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D24,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D25", "SELECT [CarrinhoComprasId], [ProdutoId] FROM [CarrinhoComprasProdutos] WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D26", "INSERT INTO [CarrinhoComprasProdutos]([CarrinhoComprasId], [CarrinhoComprasProdutosQuantid], [ProdutoId]) VALUES(@CarrinhoComprasId, @CarrinhoComprasProdutosQuantid, @ProdutoId)", GxErrorMask.GX_NOMASK,prmBC000D26)
             ,new CursorDef("BC000D27", "UPDATE [CarrinhoComprasProdutos] SET [CarrinhoComprasProdutosQuantid]=@CarrinhoComprasProdutosQuantid  WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmBC000D27)
             ,new CursorDef("BC000D28", "DELETE FROM [CarrinhoComprasProdutos]  WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmBC000D28)
             ,new CursorDef("BC000D29", "SELECT [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoNome], [ProdutoPreco], [ProdutoImagem_GXI], [ProdutoImagem] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D29,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D30", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000D31", "SELECT T2.[CategoriaProdutoId] AS CategoriaProdutoId, T1.[CarrinhoComprasId], T2.[ProdutoNome], T2.[ProdutoPreco], T2.[ProdutoImagem_GXI], T1.[CarrinhoComprasProdutosQuantid], T3.[CategoriaNome] AS CategoriaProdutoNome, T1.[ProdutoId], T2.[ProdutoImagem] FROM (([CarrinhoComprasProdutos] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[ProdutoId]) INNER JOIN [Categoria] T3 ON T3.[CategoriaId] = T2.[CategoriaProdutoId]) WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ORDER BY T1.[CarrinhoComprasId], T1.[ProdutoId]  OPTION (FAST 11)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D31,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                return;
             case 24 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
       }
    }

 }

}
