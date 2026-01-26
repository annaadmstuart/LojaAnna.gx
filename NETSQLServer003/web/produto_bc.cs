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
   public class produto_bc : GxSilentTrn, IGxSilentTrn
   {
      public produto_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public produto_bc( IGxContext context )
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
         ReadRow066( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey066( ) ;
         standaloneModal( ) ;
         AddRow066( ) ;
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
            E11062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z19ProdutoId = A19ProdutoId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               if ( AnyError == 0 )
               {
                  ZM066( 5) ;
                  ZM066( 6) ;
                  ZM066( 7) ;
                  ZM066( 8) ;
               }
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12062( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E11062( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z20ProdutoNome = A20ProdutoNome;
            Z21ProdutoDescricao = A21ProdutoDescricao;
            Z22ProdutoPreco = A22ProdutoPreco;
            Z24VendedorProdutoId = A24VendedorProdutoId;
            Z26PaisProdutoId = A26PaisProdutoId;
            Z28FornecedorProdutoId = A28FornecedorProdutoId;
            Z30CategoriaProdutoId = A30CategoriaProdutoId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z25VendedorProdutoNome = A25VendedorProdutoNome;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z27PaisProdutoNome = A27PaisProdutoNome;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z29FornecedorProdutoNome = A29FornecedorProdutoNome;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z31CategoriaProdutoNome = A31CategoriaProdutoNome;
         }
         if ( GX_JID == -3 )
         {
            Z19ProdutoId = A19ProdutoId;
            Z20ProdutoNome = A20ProdutoNome;
            Z21ProdutoDescricao = A21ProdutoDescricao;
            Z22ProdutoPreco = A22ProdutoPreco;
            Z23ProdutoImagem = A23ProdutoImagem;
            Z40000ProdutoImagem_GXI = A40000ProdutoImagem_GXI;
            Z24VendedorProdutoId = A24VendedorProdutoId;
            Z26PaisProdutoId = A26PaisProdutoId;
            Z28FornecedorProdutoId = A28FornecedorProdutoId;
            Z30CategoriaProdutoId = A30CategoriaProdutoId;
            Z25VendedorProdutoNome = A25VendedorProdutoNome;
            Z68VendedorProdutoImagem = A68VendedorProdutoImagem;
            Z40001VendedorProdutoImagem_GXI = A40001VendedorProdutoImagem_GXI;
            Z27PaisProdutoNome = A27PaisProdutoNome;
            Z29FornecedorProdutoNome = A29FornecedorProdutoNome;
            Z31CategoriaProdutoNome = A31CategoriaProdutoNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load066( )
      {
         /* Using cursor BC00068 */
         pr_default.execute(6, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
            A20ProdutoNome = BC00068_A20ProdutoNome[0];
            A21ProdutoDescricao = BC00068_A21ProdutoDescricao[0];
            A22ProdutoPreco = BC00068_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC00068_A40000ProdutoImagem_GXI[0];
            A25VendedorProdutoNome = BC00068_A25VendedorProdutoNome[0];
            A40001VendedorProdutoImagem_GXI = BC00068_A40001VendedorProdutoImagem_GXI[0];
            n40001VendedorProdutoImagem_GXI = BC00068_n40001VendedorProdutoImagem_GXI[0];
            A27PaisProdutoNome = BC00068_A27PaisProdutoNome[0];
            A29FornecedorProdutoNome = BC00068_A29FornecedorProdutoNome[0];
            A31CategoriaProdutoNome = BC00068_A31CategoriaProdutoNome[0];
            A24VendedorProdutoId = BC00068_A24VendedorProdutoId[0];
            A26PaisProdutoId = BC00068_A26PaisProdutoId[0];
            A28FornecedorProdutoId = BC00068_A28FornecedorProdutoId[0];
            A30CategoriaProdutoId = BC00068_A30CategoriaProdutoId[0];
            A23ProdutoImagem = BC00068_A23ProdutoImagem[0];
            A68VendedorProdutoImagem = BC00068_A68VendedorProdutoImagem[0];
            ZM066( -3) ;
         }
         pr_default.close(6);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00069 */
         pr_default.execute(7, new Object[] {A20ProdutoNome, A19ProdutoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Produto"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A20ProdutoNome)) )
         {
            GX_msglist.addItem("O nome do produto deve ser preenchido.", 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A22ProdutoPreco) )
         {
            GX_msglist.addItem("O preço deve ser preenchido.", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {A24VendedorProdutoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Vendedor Produto'.", "ForeignKeyNotFound", 1, "VENDEDORPRODUTOID");
            AnyError = 1;
         }
         A25VendedorProdutoNome = BC00064_A25VendedorProdutoNome[0];
         A40001VendedorProdutoImagem_GXI = BC00064_A40001VendedorProdutoImagem_GXI[0];
         n40001VendedorProdutoImagem_GXI = BC00064_n40001VendedorProdutoImagem_GXI[0];
         A68VendedorProdutoImagem = BC00064_A68VendedorProdutoImagem[0];
         pr_default.close(2);
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {A26PaisProdutoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISPRODUTOID");
            AnyError = 1;
         }
         A27PaisProdutoNome = BC00065_A27PaisProdutoNome[0];
         pr_default.close(3);
         /* Using cursor BC00066 */
         pr_default.execute(4, new Object[] {A28FornecedorProdutoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Fornecedor'.", "ForeignKeyNotFound", 1, "FORNECEDORPRODUTOID");
            AnyError = 1;
         }
         A29FornecedorProdutoNome = BC00066_A29FornecedorProdutoNome[0];
         pr_default.close(4);
         /* Using cursor BC00067 */
         pr_default.execute(5, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
         }
         A31CategoriaProdutoNome = BC00067_A31CategoriaProdutoNome[0];
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor BC000610 */
         pr_default.execute(8, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 3) ;
            RcdFound6 = 1;
            A19ProdutoId = BC00063_A19ProdutoId[0];
            A20ProdutoNome = BC00063_A20ProdutoNome[0];
            A21ProdutoDescricao = BC00063_A21ProdutoDescricao[0];
            A22ProdutoPreco = BC00063_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC00063_A40000ProdutoImagem_GXI[0];
            A24VendedorProdutoId = BC00063_A24VendedorProdutoId[0];
            A26PaisProdutoId = BC00063_A26PaisProdutoId[0];
            A28FornecedorProdutoId = BC00063_A28FornecedorProdutoId[0];
            A30CategoriaProdutoId = BC00063_A30CategoriaProdutoId[0];
            A23ProdutoImagem = BC00063_A23ProdutoImagem[0];
            Z19ProdutoId = A19ProdutoId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {A19ProdutoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Produto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z20ProdutoNome, BC00062_A20ProdutoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z21ProdutoDescricao, BC00062_A21ProdutoDescricao[0]) != 0 ) || ( Z22ProdutoPreco != BC00062_A22ProdutoPreco[0] ) || ( Z24VendedorProdutoId != BC00062_A24VendedorProdutoId[0] ) || ( Z26PaisProdutoId != BC00062_A26PaisProdutoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z28FornecedorProdutoId != BC00062_A28FornecedorProdutoId[0] ) || ( Z30CategoriaProdutoId != BC00062_A30CategoriaProdutoId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Produto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000611 */
                     pr_default.execute(9, new Object[] {A19ProdutoId, A20ProdutoNome, A21ProdutoDescricao, A22ProdutoPreco, A23ProdutoImagem, A40000ProdutoImagem_GXI, A24VendedorProdutoId, A26PaisProdutoId, A28FornecedorProdutoId, A30CategoriaProdutoId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Produto");
                     if ( (pr_default.getStatus(9) == 1) )
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000612 */
                     pr_default.execute(10, new Object[] {A20ProdutoNome, A21ProdutoDescricao, A22ProdutoPreco, A24VendedorProdutoId, A26PaisProdutoId, A28FornecedorProdutoId, A30CategoriaProdutoId, A19ProdutoId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Produto");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Produto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC000613 */
            pr_default.execute(11, new Object[] {A23ProdutoImagem, A40000ProdutoImagem_GXI, A19ProdutoId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Produto");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000614 */
                  pr_default.execute(12, new Object[] {A19ProdutoId});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("Produto");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel066( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000615 */
            pr_default.execute(13, new Object[] {A24VendedorProdutoId});
            A25VendedorProdutoNome = BC000615_A25VendedorProdutoNome[0];
            A40001VendedorProdutoImagem_GXI = BC000615_A40001VendedorProdutoImagem_GXI[0];
            n40001VendedorProdutoImagem_GXI = BC000615_n40001VendedorProdutoImagem_GXI[0];
            A68VendedorProdutoImagem = BC000615_A68VendedorProdutoImagem[0];
            pr_default.close(13);
            /* Using cursor BC000616 */
            pr_default.execute(14, new Object[] {A26PaisProdutoId});
            A27PaisProdutoNome = BC000616_A27PaisProdutoNome[0];
            pr_default.close(14);
            /* Using cursor BC000617 */
            pr_default.execute(15, new Object[] {A28FornecedorProdutoId});
            A29FornecedorProdutoNome = BC000617_A29FornecedorProdutoNome[0];
            pr_default.close(15);
            /* Using cursor BC000618 */
            pr_default.execute(16, new Object[] {A30CategoriaProdutoId});
            A31CategoriaProdutoNome = BC000618_A31CategoriaProdutoNome[0];
            pr_default.close(16);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000619 */
            pr_default.execute(17, new Object[] {A19ProdutoId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CarrinhoComprasProdutos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor BC000620 */
            pr_default.execute(18, new Object[] {A19ProdutoId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Produto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
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

      public void ScanKeyStart066( )
      {
         /* Scan By routine */
         /* Using cursor BC000621 */
         pr_default.execute(19, new Object[] {A19ProdutoId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound6 = 1;
            A19ProdutoId = BC000621_A19ProdutoId[0];
            A20ProdutoNome = BC000621_A20ProdutoNome[0];
            A21ProdutoDescricao = BC000621_A21ProdutoDescricao[0];
            A22ProdutoPreco = BC000621_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC000621_A40000ProdutoImagem_GXI[0];
            A25VendedorProdutoNome = BC000621_A25VendedorProdutoNome[0];
            A40001VendedorProdutoImagem_GXI = BC000621_A40001VendedorProdutoImagem_GXI[0];
            n40001VendedorProdutoImagem_GXI = BC000621_n40001VendedorProdutoImagem_GXI[0];
            A27PaisProdutoNome = BC000621_A27PaisProdutoNome[0];
            A29FornecedorProdutoNome = BC000621_A29FornecedorProdutoNome[0];
            A31CategoriaProdutoNome = BC000621_A31CategoriaProdutoNome[0];
            A24VendedorProdutoId = BC000621_A24VendedorProdutoId[0];
            A26PaisProdutoId = BC000621_A26PaisProdutoId[0];
            A28FornecedorProdutoId = BC000621_A28FornecedorProdutoId[0];
            A30CategoriaProdutoId = BC000621_A30CategoriaProdutoId[0];
            A23ProdutoImagem = BC000621_A23ProdutoImagem[0];
            A68VendedorProdutoImagem = BC000621_A68VendedorProdutoImagem[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound6 = 0;
         ScanKeyLoad066( ) ;
      }

      protected void ScanKeyLoad066( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound6 = 1;
            A19ProdutoId = BC000621_A19ProdutoId[0];
            A20ProdutoNome = BC000621_A20ProdutoNome[0];
            A21ProdutoDescricao = BC000621_A21ProdutoDescricao[0];
            A22ProdutoPreco = BC000621_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = BC000621_A40000ProdutoImagem_GXI[0];
            A25VendedorProdutoNome = BC000621_A25VendedorProdutoNome[0];
            A40001VendedorProdutoImagem_GXI = BC000621_A40001VendedorProdutoImagem_GXI[0];
            n40001VendedorProdutoImagem_GXI = BC000621_n40001VendedorProdutoImagem_GXI[0];
            A27PaisProdutoNome = BC000621_A27PaisProdutoNome[0];
            A29FornecedorProdutoNome = BC000621_A29FornecedorProdutoNome[0];
            A31CategoriaProdutoNome = BC000621_A31CategoriaProdutoNome[0];
            A24VendedorProdutoId = BC000621_A24VendedorProdutoId[0];
            A26PaisProdutoId = BC000621_A26PaisProdutoId[0];
            A28FornecedorProdutoId = BC000621_A28FornecedorProdutoId[0];
            A30CategoriaProdutoId = BC000621_A30CategoriaProdutoId[0];
            A23ProdutoImagem = BC000621_A23ProdutoImagem[0];
            A68VendedorProdutoImagem = BC000621_A68VendedorProdutoImagem[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd066( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void AddRow066( )
      {
         VarsToRow6( bcProduto) ;
      }

      protected void ReadRow066( )
      {
         RowToVars6( bcProduto, 1) ;
      }

      protected void InitializeNonKey066( )
      {
         A20ProdutoNome = "";
         A21ProdutoDescricao = "";
         A22ProdutoPreco = 0;
         A23ProdutoImagem = "";
         A40000ProdutoImagem_GXI = "";
         A24VendedorProdutoId = 0;
         A25VendedorProdutoNome = "";
         A68VendedorProdutoImagem = "";
         A40001VendedorProdutoImagem_GXI = "";
         n40001VendedorProdutoImagem_GXI = false;
         A26PaisProdutoId = 0;
         A27PaisProdutoNome = "";
         A28FornecedorProdutoId = 0;
         A29FornecedorProdutoNome = "";
         A30CategoriaProdutoId = 0;
         A31CategoriaProdutoNome = "";
         Z20ProdutoNome = "";
         Z21ProdutoDescricao = "";
         Z22ProdutoPreco = 0;
         Z24VendedorProdutoId = 0;
         Z26PaisProdutoId = 0;
         Z28FornecedorProdutoId = 0;
         Z30CategoriaProdutoId = 0;
      }

      protected void InitAll066( )
      {
         A19ProdutoId = 0;
         InitializeNonKey066( ) ;
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

      public void VarsToRow6( SdtProduto obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Produtonome = A20ProdutoNome;
         obj6.gxTpr_Produtodescricao = A21ProdutoDescricao;
         obj6.gxTpr_Produtopreco = A22ProdutoPreco;
         obj6.gxTpr_Produtoimagem = A23ProdutoImagem;
         obj6.gxTpr_Produtoimagem_gxi = A40000ProdutoImagem_GXI;
         obj6.gxTpr_Vendedorprodutoid = A24VendedorProdutoId;
         obj6.gxTpr_Vendedorprodutonome = A25VendedorProdutoNome;
         obj6.gxTpr_Vendedorprodutoimagem = A68VendedorProdutoImagem;
         obj6.gxTpr_Vendedorprodutoimagem_gxi = A40001VendedorProdutoImagem_GXI;
         obj6.gxTpr_Paisprodutoid = A26PaisProdutoId;
         obj6.gxTpr_Paisprodutonome = A27PaisProdutoNome;
         obj6.gxTpr_Fornecedorprodutoid = A28FornecedorProdutoId;
         obj6.gxTpr_Fornecedorprodutonome = A29FornecedorProdutoNome;
         obj6.gxTpr_Categoriaprodutoid = A30CategoriaProdutoId;
         obj6.gxTpr_Categoriaprodutonome = A31CategoriaProdutoNome;
         obj6.gxTpr_Produtoid = A19ProdutoId;
         obj6.gxTpr_Produtoid_Z = Z19ProdutoId;
         obj6.gxTpr_Produtonome_Z = Z20ProdutoNome;
         obj6.gxTpr_Produtodescricao_Z = Z21ProdutoDescricao;
         obj6.gxTpr_Produtopreco_Z = Z22ProdutoPreco;
         obj6.gxTpr_Vendedorprodutoid_Z = Z24VendedorProdutoId;
         obj6.gxTpr_Vendedorprodutonome_Z = Z25VendedorProdutoNome;
         obj6.gxTpr_Paisprodutoid_Z = Z26PaisProdutoId;
         obj6.gxTpr_Paisprodutonome_Z = Z27PaisProdutoNome;
         obj6.gxTpr_Fornecedorprodutoid_Z = Z28FornecedorProdutoId;
         obj6.gxTpr_Fornecedorprodutonome_Z = Z29FornecedorProdutoNome;
         obj6.gxTpr_Categoriaprodutoid_Z = Z30CategoriaProdutoId;
         obj6.gxTpr_Categoriaprodutonome_Z = Z31CategoriaProdutoNome;
         obj6.gxTpr_Produtoimagem_gxi_Z = Z40000ProdutoImagem_GXI;
         obj6.gxTpr_Vendedorprodutoimagem_gxi_Z = Z40001VendedorProdutoImagem_GXI;
         obj6.gxTpr_Vendedorprodutoimagem_gxi_N = (short)(Convert.ToInt16(n40001VendedorProdutoImagem_GXI));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( SdtProduto obj6 )
      {
         obj6.gxTpr_Produtoid = A19ProdutoId;
         return  ;
      }

      public void RowToVars6( SdtProduto obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A20ProdutoNome = obj6.gxTpr_Produtonome;
         A21ProdutoDescricao = obj6.gxTpr_Produtodescricao;
         A22ProdutoPreco = obj6.gxTpr_Produtopreco;
         A23ProdutoImagem = obj6.gxTpr_Produtoimagem;
         A40000ProdutoImagem_GXI = obj6.gxTpr_Produtoimagem_gxi;
         A24VendedorProdutoId = obj6.gxTpr_Vendedorprodutoid;
         A25VendedorProdutoNome = obj6.gxTpr_Vendedorprodutonome;
         A68VendedorProdutoImagem = obj6.gxTpr_Vendedorprodutoimagem;
         A40001VendedorProdutoImagem_GXI = obj6.gxTpr_Vendedorprodutoimagem_gxi;
         n40001VendedorProdutoImagem_GXI = false;
         A26PaisProdutoId = obj6.gxTpr_Paisprodutoid;
         A27PaisProdutoNome = obj6.gxTpr_Paisprodutonome;
         A28FornecedorProdutoId = obj6.gxTpr_Fornecedorprodutoid;
         A29FornecedorProdutoNome = obj6.gxTpr_Fornecedorprodutonome;
         A30CategoriaProdutoId = obj6.gxTpr_Categoriaprodutoid;
         A31CategoriaProdutoNome = obj6.gxTpr_Categoriaprodutonome;
         A19ProdutoId = obj6.gxTpr_Produtoid;
         Z19ProdutoId = obj6.gxTpr_Produtoid_Z;
         Z20ProdutoNome = obj6.gxTpr_Produtonome_Z;
         Z21ProdutoDescricao = obj6.gxTpr_Produtodescricao_Z;
         Z22ProdutoPreco = obj6.gxTpr_Produtopreco_Z;
         Z24VendedorProdutoId = obj6.gxTpr_Vendedorprodutoid_Z;
         Z25VendedorProdutoNome = obj6.gxTpr_Vendedorprodutonome_Z;
         Z26PaisProdutoId = obj6.gxTpr_Paisprodutoid_Z;
         Z27PaisProdutoNome = obj6.gxTpr_Paisprodutonome_Z;
         Z28FornecedorProdutoId = obj6.gxTpr_Fornecedorprodutoid_Z;
         Z29FornecedorProdutoNome = obj6.gxTpr_Fornecedorprodutonome_Z;
         Z30CategoriaProdutoId = obj6.gxTpr_Categoriaprodutoid_Z;
         Z31CategoriaProdutoNome = obj6.gxTpr_Categoriaprodutonome_Z;
         Z40000ProdutoImagem_GXI = obj6.gxTpr_Produtoimagem_gxi_Z;
         Z40001VendedorProdutoImagem_GXI = obj6.gxTpr_Vendedorprodutoimagem_gxi_Z;
         n40001VendedorProdutoImagem_GXI = (bool)(Convert.ToBoolean(obj6.gxTpr_Vendedorprodutoimagem_gxi_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A19ProdutoId = (short)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey066( ) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19ProdutoId = A19ProdutoId;
         }
         ZM066( -3) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcProduto, 0) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z19ProdutoId = A19ProdutoId;
         }
         ZM066( -3) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert066( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A19ProdutoId != Z19ProdutoId )
               {
                  A19ProdutoId = Z19ProdutoId;
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
                  Update066( ) ;
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
                  if ( A19ProdutoId != Z19ProdutoId )
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
                        Insert066( ) ;
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
                        Insert066( ) ;
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
         RowToVars6( bcProduto, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcProduto) ;
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
         RowToVars6( bcProduto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcProduto) ;
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
            SdtProduto auxBC = new SdtProduto(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A19ProdutoId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcProduto);
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
         RowToVars6( bcProduto, 1) ;
         UpdateImpl( ) ;
         VarsToRow6( bcProduto) ;
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
         RowToVars6( bcProduto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
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
         VarsToRow6( bcProduto) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars6( bcProduto, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey066( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A19ProdutoId != Z19ProdutoId )
            {
               A19ProdutoId = Z19ProdutoId;
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
            if ( A19ProdutoId != Z19ProdutoId )
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
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
         context.RollbackDataStores("produto_bc",pr_default);
         VarsToRow6( bcProduto) ;
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
         Gx_mode = bcProduto.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcProduto.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcProduto )
         {
            bcProduto = (SdtProduto)(sdt);
            if ( StringUtil.StrCmp(bcProduto.gxTpr_Mode, "") == 0 )
            {
               bcProduto.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcProduto) ;
            }
            else
            {
               RowToVars6( bcProduto, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcProduto.gxTpr_Mode, "") == 0 )
            {
               bcProduto.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcProduto, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProduto Produto_BC
      {
         get {
            return bcProduto ;
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
         pr_default.close(13);
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(16);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z20ProdutoNome = "";
         A20ProdutoNome = "";
         Z21ProdutoDescricao = "";
         A21ProdutoDescricao = "";
         Z25VendedorProdutoNome = "";
         A25VendedorProdutoNome = "";
         Z27PaisProdutoNome = "";
         A27PaisProdutoNome = "";
         Z29FornecedorProdutoNome = "";
         A29FornecedorProdutoNome = "";
         Z31CategoriaProdutoNome = "";
         A31CategoriaProdutoNome = "";
         Z23ProdutoImagem = "";
         A23ProdutoImagem = "";
         Z40000ProdutoImagem_GXI = "";
         A40000ProdutoImagem_GXI = "";
         Z68VendedorProdutoImagem = "";
         A68VendedorProdutoImagem = "";
         Z40001VendedorProdutoImagem_GXI = "";
         A40001VendedorProdutoImagem_GXI = "";
         BC00068_A19ProdutoId = new short[1] ;
         BC00068_A20ProdutoNome = new string[] {""} ;
         BC00068_A21ProdutoDescricao = new string[] {""} ;
         BC00068_A22ProdutoPreco = new decimal[1] ;
         BC00068_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC00068_A25VendedorProdutoNome = new string[] {""} ;
         BC00068_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         BC00068_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         BC00068_A27PaisProdutoNome = new string[] {""} ;
         BC00068_A29FornecedorProdutoNome = new string[] {""} ;
         BC00068_A31CategoriaProdutoNome = new string[] {""} ;
         BC00068_A24VendedorProdutoId = new short[1] ;
         BC00068_A26PaisProdutoId = new short[1] ;
         BC00068_A28FornecedorProdutoId = new short[1] ;
         BC00068_A30CategoriaProdutoId = new short[1] ;
         BC00068_A23ProdutoImagem = new string[] {""} ;
         BC00068_A68VendedorProdutoImagem = new string[] {""} ;
         BC00069_A20ProdutoNome = new string[] {""} ;
         BC00064_A25VendedorProdutoNome = new string[] {""} ;
         BC00064_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         BC00064_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         BC00064_A68VendedorProdutoImagem = new string[] {""} ;
         BC00065_A27PaisProdutoNome = new string[] {""} ;
         BC00066_A29FornecedorProdutoNome = new string[] {""} ;
         BC00067_A31CategoriaProdutoNome = new string[] {""} ;
         BC000610_A19ProdutoId = new short[1] ;
         BC00063_A19ProdutoId = new short[1] ;
         BC00063_A20ProdutoNome = new string[] {""} ;
         BC00063_A21ProdutoDescricao = new string[] {""} ;
         BC00063_A22ProdutoPreco = new decimal[1] ;
         BC00063_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC00063_A24VendedorProdutoId = new short[1] ;
         BC00063_A26PaisProdutoId = new short[1] ;
         BC00063_A28FornecedorProdutoId = new short[1] ;
         BC00063_A30CategoriaProdutoId = new short[1] ;
         BC00063_A23ProdutoImagem = new string[] {""} ;
         sMode6 = "";
         BC00062_A19ProdutoId = new short[1] ;
         BC00062_A20ProdutoNome = new string[] {""} ;
         BC00062_A21ProdutoDescricao = new string[] {""} ;
         BC00062_A22ProdutoPreco = new decimal[1] ;
         BC00062_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC00062_A24VendedorProdutoId = new short[1] ;
         BC00062_A26PaisProdutoId = new short[1] ;
         BC00062_A28FornecedorProdutoId = new short[1] ;
         BC00062_A30CategoriaProdutoId = new short[1] ;
         BC00062_A23ProdutoImagem = new string[] {""} ;
         BC000615_A25VendedorProdutoNome = new string[] {""} ;
         BC000615_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         BC000615_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         BC000615_A68VendedorProdutoImagem = new string[] {""} ;
         BC000616_A27PaisProdutoNome = new string[] {""} ;
         BC000617_A29FornecedorProdutoNome = new string[] {""} ;
         BC000618_A31CategoriaProdutoNome = new string[] {""} ;
         BC000619_A52CarrinhoComprasId = new short[1] ;
         BC000619_A19ProdutoId = new short[1] ;
         BC000620_A32PromocaoId = new short[1] ;
         BC000620_A19ProdutoId = new short[1] ;
         BC000621_A19ProdutoId = new short[1] ;
         BC000621_A20ProdutoNome = new string[] {""} ;
         BC000621_A21ProdutoDescricao = new string[] {""} ;
         BC000621_A22ProdutoPreco = new decimal[1] ;
         BC000621_A40000ProdutoImagem_GXI = new string[] {""} ;
         BC000621_A25VendedorProdutoNome = new string[] {""} ;
         BC000621_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         BC000621_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         BC000621_A27PaisProdutoNome = new string[] {""} ;
         BC000621_A29FornecedorProdutoNome = new string[] {""} ;
         BC000621_A31CategoriaProdutoNome = new string[] {""} ;
         BC000621_A24VendedorProdutoId = new short[1] ;
         BC000621_A26PaisProdutoId = new short[1] ;
         BC000621_A28FornecedorProdutoId = new short[1] ;
         BC000621_A30CategoriaProdutoId = new short[1] ;
         BC000621_A23ProdutoImagem = new string[] {""} ;
         BC000621_A68VendedorProdutoImagem = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produto_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A19ProdutoId, BC00062_A20ProdutoNome, BC00062_A21ProdutoDescricao, BC00062_A22ProdutoPreco, BC00062_A40000ProdutoImagem_GXI, BC00062_A24VendedorProdutoId, BC00062_A26PaisProdutoId, BC00062_A28FornecedorProdutoId, BC00062_A30CategoriaProdutoId, BC00062_A23ProdutoImagem
               }
               , new Object[] {
               BC00063_A19ProdutoId, BC00063_A20ProdutoNome, BC00063_A21ProdutoDescricao, BC00063_A22ProdutoPreco, BC00063_A40000ProdutoImagem_GXI, BC00063_A24VendedorProdutoId, BC00063_A26PaisProdutoId, BC00063_A28FornecedorProdutoId, BC00063_A30CategoriaProdutoId, BC00063_A23ProdutoImagem
               }
               , new Object[] {
               BC00064_A25VendedorProdutoNome, BC00064_A40001VendedorProdutoImagem_GXI, BC00064_n40001VendedorProdutoImagem_GXI, BC00064_A68VendedorProdutoImagem
               }
               , new Object[] {
               BC00065_A27PaisProdutoNome
               }
               , new Object[] {
               BC00066_A29FornecedorProdutoNome
               }
               , new Object[] {
               BC00067_A31CategoriaProdutoNome
               }
               , new Object[] {
               BC00068_A19ProdutoId, BC00068_A20ProdutoNome, BC00068_A21ProdutoDescricao, BC00068_A22ProdutoPreco, BC00068_A40000ProdutoImagem_GXI, BC00068_A25VendedorProdutoNome, BC00068_A40001VendedorProdutoImagem_GXI, BC00068_n40001VendedorProdutoImagem_GXI, BC00068_A27PaisProdutoNome, BC00068_A29FornecedorProdutoNome,
               BC00068_A31CategoriaProdutoNome, BC00068_A24VendedorProdutoId, BC00068_A26PaisProdutoId, BC00068_A28FornecedorProdutoId, BC00068_A30CategoriaProdutoId, BC00068_A23ProdutoImagem, BC00068_A68VendedorProdutoImagem
               }
               , new Object[] {
               BC00069_A20ProdutoNome
               }
               , new Object[] {
               BC000610_A19ProdutoId
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
               BC000615_A25VendedorProdutoNome, BC000615_A40001VendedorProdutoImagem_GXI, BC000615_n40001VendedorProdutoImagem_GXI, BC000615_A68VendedorProdutoImagem
               }
               , new Object[] {
               BC000616_A27PaisProdutoNome
               }
               , new Object[] {
               BC000617_A29FornecedorProdutoNome
               }
               , new Object[] {
               BC000618_A31CategoriaProdutoNome
               }
               , new Object[] {
               BC000619_A52CarrinhoComprasId, BC000619_A19ProdutoId
               }
               , new Object[] {
               BC000620_A32PromocaoId, BC000620_A19ProdutoId
               }
               , new Object[] {
               BC000621_A19ProdutoId, BC000621_A20ProdutoNome, BC000621_A21ProdutoDescricao, BC000621_A22ProdutoPreco, BC000621_A40000ProdutoImagem_GXI, BC000621_A25VendedorProdutoNome, BC000621_A40001VendedorProdutoImagem_GXI, BC000621_n40001VendedorProdutoImagem_GXI, BC000621_A27PaisProdutoNome, BC000621_A29FornecedorProdutoNome,
               BC000621_A31CategoriaProdutoNome, BC000621_A24VendedorProdutoId, BC000621_A26PaisProdutoId, BC000621_A28FornecedorProdutoId, BC000621_A30CategoriaProdutoId, BC000621_A23ProdutoImagem, BC000621_A68VendedorProdutoImagem
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12062 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z19ProdutoId ;
      private short A19ProdutoId ;
      private short GX_JID ;
      private short Z24VendedorProdutoId ;
      private short A24VendedorProdutoId ;
      private short Z26PaisProdutoId ;
      private short A26PaisProdutoId ;
      private short Z28FornecedorProdutoId ;
      private short A28FornecedorProdutoId ;
      private short Z30CategoriaProdutoId ;
      private short A30CategoriaProdutoId ;
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private int trnEnded ;
      private decimal Z22ProdutoPreco ;
      private decimal A22ProdutoPreco ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode6 ;
      private bool returnInSub ;
      private bool n40001VendedorProdutoImagem_GXI ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z20ProdutoNome ;
      private string A20ProdutoNome ;
      private string Z21ProdutoDescricao ;
      private string A21ProdutoDescricao ;
      private string Z25VendedorProdutoNome ;
      private string A25VendedorProdutoNome ;
      private string Z27PaisProdutoNome ;
      private string A27PaisProdutoNome ;
      private string Z29FornecedorProdutoNome ;
      private string A29FornecedorProdutoNome ;
      private string Z31CategoriaProdutoNome ;
      private string A31CategoriaProdutoNome ;
      private string Z40000ProdutoImagem_GXI ;
      private string A40000ProdutoImagem_GXI ;
      private string Z40001VendedorProdutoImagem_GXI ;
      private string A40001VendedorProdutoImagem_GXI ;
      private string Z23ProdutoImagem ;
      private string A23ProdutoImagem ;
      private string Z68VendedorProdutoImagem ;
      private string A68VendedorProdutoImagem ;
      private SdtProduto bcProduto ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00068_A19ProdutoId ;
      private string[] BC00068_A20ProdutoNome ;
      private string[] BC00068_A21ProdutoDescricao ;
      private decimal[] BC00068_A22ProdutoPreco ;
      private string[] BC00068_A40000ProdutoImagem_GXI ;
      private string[] BC00068_A25VendedorProdutoNome ;
      private string[] BC00068_A40001VendedorProdutoImagem_GXI ;
      private bool[] BC00068_n40001VendedorProdutoImagem_GXI ;
      private string[] BC00068_A27PaisProdutoNome ;
      private string[] BC00068_A29FornecedorProdutoNome ;
      private string[] BC00068_A31CategoriaProdutoNome ;
      private short[] BC00068_A24VendedorProdutoId ;
      private short[] BC00068_A26PaisProdutoId ;
      private short[] BC00068_A28FornecedorProdutoId ;
      private short[] BC00068_A30CategoriaProdutoId ;
      private string[] BC00068_A23ProdutoImagem ;
      private string[] BC00068_A68VendedorProdutoImagem ;
      private string[] BC00069_A20ProdutoNome ;
      private string[] BC00064_A25VendedorProdutoNome ;
      private string[] BC00064_A40001VendedorProdutoImagem_GXI ;
      private bool[] BC00064_n40001VendedorProdutoImagem_GXI ;
      private string[] BC00064_A68VendedorProdutoImagem ;
      private string[] BC00065_A27PaisProdutoNome ;
      private string[] BC00066_A29FornecedorProdutoNome ;
      private string[] BC00067_A31CategoriaProdutoNome ;
      private short[] BC000610_A19ProdutoId ;
      private short[] BC00063_A19ProdutoId ;
      private string[] BC00063_A20ProdutoNome ;
      private string[] BC00063_A21ProdutoDescricao ;
      private decimal[] BC00063_A22ProdutoPreco ;
      private string[] BC00063_A40000ProdutoImagem_GXI ;
      private short[] BC00063_A24VendedorProdutoId ;
      private short[] BC00063_A26PaisProdutoId ;
      private short[] BC00063_A28FornecedorProdutoId ;
      private short[] BC00063_A30CategoriaProdutoId ;
      private string[] BC00063_A23ProdutoImagem ;
      private short[] BC00062_A19ProdutoId ;
      private string[] BC00062_A20ProdutoNome ;
      private string[] BC00062_A21ProdutoDescricao ;
      private decimal[] BC00062_A22ProdutoPreco ;
      private string[] BC00062_A40000ProdutoImagem_GXI ;
      private short[] BC00062_A24VendedorProdutoId ;
      private short[] BC00062_A26PaisProdutoId ;
      private short[] BC00062_A28FornecedorProdutoId ;
      private short[] BC00062_A30CategoriaProdutoId ;
      private string[] BC00062_A23ProdutoImagem ;
      private string[] BC000615_A25VendedorProdutoNome ;
      private string[] BC000615_A40001VendedorProdutoImagem_GXI ;
      private bool[] BC000615_n40001VendedorProdutoImagem_GXI ;
      private string[] BC000615_A68VendedorProdutoImagem ;
      private string[] BC000616_A27PaisProdutoNome ;
      private string[] BC000617_A29FornecedorProdutoNome ;
      private string[] BC000618_A31CategoriaProdutoNome ;
      private short[] BC000619_A52CarrinhoComprasId ;
      private short[] BC000619_A19ProdutoId ;
      private short[] BC000620_A32PromocaoId ;
      private short[] BC000620_A19ProdutoId ;
      private short[] BC000621_A19ProdutoId ;
      private string[] BC000621_A20ProdutoNome ;
      private string[] BC000621_A21ProdutoDescricao ;
      private decimal[] BC000621_A22ProdutoPreco ;
      private string[] BC000621_A40000ProdutoImagem_GXI ;
      private string[] BC000621_A25VendedorProdutoNome ;
      private string[] BC000621_A40001VendedorProdutoImagem_GXI ;
      private bool[] BC000621_n40001VendedorProdutoImagem_GXI ;
      private string[] BC000621_A27PaisProdutoNome ;
      private string[] BC000621_A29FornecedorProdutoNome ;
      private string[] BC000621_A31CategoriaProdutoNome ;
      private short[] BC000621_A24VendedorProdutoId ;
      private short[] BC000621_A26PaisProdutoId ;
      private short[] BC000621_A28FornecedorProdutoId ;
      private short[] BC000621_A30CategoriaProdutoId ;
      private string[] BC000621_A23ProdutoImagem ;
      private string[] BC000621_A68VendedorProdutoImagem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
   }

   public class produto_bc__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
         ,new ForEachCursor(def[19])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmBC00068;
          prmBC00068 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC00069;
          prmBC00069 = new Object[] {
          new ParDef("@ProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC00064;
          prmBC00064 = new Object[] {
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC00065;
          prmBC00065 = new Object[] {
          new ParDef("@PaisProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC00066;
          prmBC00066 = new Object[] {
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC00067;
          prmBC00067 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000610;
          prmBC000610 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC00063;
          prmBC00063 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC00062;
          prmBC00062 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000611;
          prmBC000611 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@ProdutoDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@ProdutoPreco",GXType.Decimal,10,2) ,
          new ParDef("@ProdutoImagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProdutoImagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Produto", Fld="ProdutoImagem"} ,
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@PaisProdutoId",GXType.Int16,4,0) ,
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000612;
          prmBC000612 = new Object[] {
          new ParDef("@ProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@ProdutoDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@ProdutoPreco",GXType.Decimal,10,2) ,
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@PaisProdutoId",GXType.Int16,4,0) ,
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000613;
          prmBC000613 = new Object[] {
          new ParDef("@ProdutoImagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProdutoImagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Produto", Fld="ProdutoImagem"} ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000614;
          prmBC000614 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000615;
          prmBC000615 = new Object[] {
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000616;
          prmBC000616 = new Object[] {
          new ParDef("@PaisProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000617;
          prmBC000617 = new Object[] {
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000618;
          prmBC000618 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000619;
          prmBC000619 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000620;
          prmBC000620 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmBC000621;
          prmBC000621 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("BC00062", "SELECT [ProdutoId], [ProdutoNome], [ProdutoDescricao], [ProdutoPreco], [ProdutoImagem_GXI], [VendedorProdutoId] AS VendedorProdutoId, [PaisProdutoId] AS PaisProdutoId, [FornecedorProdutoId] AS FornecedorProdutoId, [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoImagem] FROM [Produto] WITH (UPDLOCK) WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00063", "SELECT [ProdutoId], [ProdutoNome], [ProdutoDescricao], [ProdutoPreco], [ProdutoImagem_GXI], [VendedorProdutoId] AS VendedorProdutoId, [PaisProdutoId] AS PaisProdutoId, [FornecedorProdutoId] AS FornecedorProdutoId, [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoImagem] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00064", "SELECT [VendedorNome] AS VendedorProdutoNome, [VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, [VendedorFoto] AS VendedorProdutoImagem FROM [Vendedor] WHERE [VendedorId] = @VendedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00065", "SELECT [PaisNome] AS PaisProdutoNome FROM [Pais] WHERE [PaisId] = @PaisProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00066", "SELECT [FornecedorNome] AS FornecedorProdutoNome FROM [Fornecedor] WHERE [FornecedorId] = @FornecedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00067", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00068", "SELECT TM1.[ProdutoId], TM1.[ProdutoNome], TM1.[ProdutoDescricao], TM1.[ProdutoPreco], TM1.[ProdutoImagem_GXI], T2.[VendedorNome] AS VendedorProdutoNome, T2.[VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, T3.[PaisNome] AS PaisProdutoNome, T4.[FornecedorNome] AS FornecedorProdutoNome, T5.[CategoriaNome] AS CategoriaProdutoNome, TM1.[VendedorProdutoId] AS VendedorProdutoId, TM1.[PaisProdutoId] AS PaisProdutoId, TM1.[FornecedorProdutoId] AS FornecedorProdutoId, TM1.[CategoriaProdutoId] AS CategoriaProdutoId, TM1.[ProdutoImagem], T2.[VendedorFoto] AS VendedorProdutoImagem FROM (((([Produto] TM1 INNER JOIN [Vendedor] T2 ON T2.[VendedorId] = TM1.[VendedorProdutoId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = TM1.[PaisProdutoId]) INNER JOIN [Fornecedor] T4 ON T4.[FornecedorId] = TM1.[FornecedorProdutoId]) INNER JOIN [Categoria] T5 ON T5.[CategoriaId] = TM1.[CategoriaProdutoId]) WHERE TM1.[ProdutoId] = @ProdutoId ORDER BY TM1.[ProdutoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC00068,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC00069", "SELECT [ProdutoNome] FROM [Produto] WHERE ([ProdutoNome] = @ProdutoNome) AND (Not ( [ProdutoId] = @ProdutoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000610", "SELECT [ProdutoId] FROM [Produto] WHERE [ProdutoId] = @ProdutoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000611", "INSERT INTO [Produto]([ProdutoId], [ProdutoNome], [ProdutoDescricao], [ProdutoPreco], [ProdutoImagem], [ProdutoImagem_GXI], [VendedorProdutoId], [PaisProdutoId], [FornecedorProdutoId], [CategoriaProdutoId]) VALUES(@ProdutoId, @ProdutoNome, @ProdutoDescricao, @ProdutoPreco, @ProdutoImagem, @ProdutoImagem_GXI, @VendedorProdutoId, @PaisProdutoId, @FornecedorProdutoId, @CategoriaProdutoId)", GxErrorMask.GX_NOMASK,prmBC000611)
             ,new CursorDef("BC000612", "UPDATE [Produto] SET [ProdutoNome]=@ProdutoNome, [ProdutoDescricao]=@ProdutoDescricao, [ProdutoPreco]=@ProdutoPreco, [VendedorProdutoId]=@VendedorProdutoId, [PaisProdutoId]=@PaisProdutoId, [FornecedorProdutoId]=@FornecedorProdutoId, [CategoriaProdutoId]=@CategoriaProdutoId  WHERE [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmBC000612)
             ,new CursorDef("BC000613", "UPDATE [Produto] SET [ProdutoImagem]=@ProdutoImagem, [ProdutoImagem_GXI]=@ProdutoImagem_GXI  WHERE [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmBC000613)
             ,new CursorDef("BC000614", "DELETE FROM [Produto]  WHERE [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmBC000614)
             ,new CursorDef("BC000615", "SELECT [VendedorNome] AS VendedorProdutoNome, [VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, [VendedorFoto] AS VendedorProdutoImagem FROM [Vendedor] WHERE [VendedorId] = @VendedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000615,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000616", "SELECT [PaisNome] AS PaisProdutoNome FROM [Pais] WHERE [PaisId] = @PaisProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000616,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000617", "SELECT [FornecedorNome] AS FornecedorProdutoNome FROM [Fornecedor] WHERE [FornecedorId] = @FornecedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000617,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000618", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000618,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("BC000619", "SELECT TOP 1 [CarrinhoComprasId], [ProdutoId] FROM [CarrinhoComprasProdutos] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000619,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000620", "SELECT TOP 1 [PromocaoId], [ProdutoId] FROM [PromocaoProduto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000620,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("BC000621", "SELECT TM1.[ProdutoId], TM1.[ProdutoNome], TM1.[ProdutoDescricao], TM1.[ProdutoPreco], TM1.[ProdutoImagem_GXI], T2.[VendedorNome] AS VendedorProdutoNome, T2.[VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, T3.[PaisNome] AS PaisProdutoNome, T4.[FornecedorNome] AS FornecedorProdutoNome, T5.[CategoriaNome] AS CategoriaProdutoNome, TM1.[VendedorProdutoId] AS VendedorProdutoId, TM1.[PaisProdutoId] AS PaisProdutoId, TM1.[FornecedorProdutoId] AS FornecedorProdutoId, TM1.[CategoriaProdutoId] AS CategoriaProdutoId, TM1.[ProdutoImagem], T2.[VendedorFoto] AS VendedorProdutoImagem FROM (((([Produto] TM1 INNER JOIN [Vendedor] T2 ON T2.[VendedorId] = TM1.[VendedorProdutoId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = TM1.[PaisProdutoId]) INNER JOIN [Fornecedor] T4 ON T4.[FornecedorId] = TM1.[FornecedorProdutoId]) INNER JOIN [Categoria] T5 ON T5.[CategoriaId] = TM1.[CategoriaProdutoId]) WHERE TM1.[ProdutoId] = @ProdutoId ORDER BY TM1.[ProdutoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmBC000621,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(7));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(7));
                return;
       }
    }

 }

}
