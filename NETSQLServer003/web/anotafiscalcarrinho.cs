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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class anotafiscalcarrinho : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("LojaAnnaLaisa");
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "CarrinhoComprasId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8CarrinhoComprasId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
            }
            if ( toggleJsOutput )
            {
            }
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public anotafiscalcarrinho( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public anotafiscalcarrinho( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CarrinhoComprasId )
      {
         this.AV8CarrinhoComprasId = aP0_CarrinhoComprasId;
         initialize();
         executePrivate();
         aP0_CarrinhoComprasId=this.AV8CarrinhoComprasId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_CarrinhoComprasId);
         return AV8CarrinhoComprasId ;
      }

      public void executeSubmit( ref short aP0_CarrinhoComprasId )
      {
         anotafiscalcarrinho objanotafiscalcarrinho;
         objanotafiscalcarrinho = new anotafiscalcarrinho();
         objanotafiscalcarrinho.AV8CarrinhoComprasId = aP0_CarrinhoComprasId;
         objanotafiscalcarrinho.context.SetSubmitInitialConfig(context);
         objanotafiscalcarrinho.initialize();
         Submit( executePrivateCatch,objanotafiscalcarrinho);
         aP0_CarrinhoComprasId=this.AV8CarrinhoComprasId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((anotafiscalcarrinho)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         getPrinter().GxSetDocName("") ;
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 256, 16834, 11909, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            H0F0( false, 118) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "489f172f-37fb-4601-b272-97fc473e57db", "", context.GetTheme( )), 167, Gx_line+13, 264, Gx_line+110) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 14, true, false, false, false, 0, 139, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Meu carrinho de compras", 300, Gx_line+47, 607, Gx_line+80, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+118);
            /* Using cursor P000F3 */
            pr_default.execute(0, new Object[] {AV8CarrinhoComprasId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A54ClienteCarrinhoComprasId = P000F3_A54ClienteCarrinhoComprasId[0];
               A57ClienteCarrinhoComprasPaisId = P000F3_A57ClienteCarrinhoComprasPaisId[0];
               A52CarrinhoComprasId = P000F3_A52CarrinhoComprasId[0];
               A58ClienteCarrinhoComprasPaisNome = P000F3_A58ClienteCarrinhoComprasPaisNome[0];
               A56ClienteCarrinhoComprasEndereco = P000F3_A56ClienteCarrinhoComprasEndereco[0];
               A55ClienteCarrinhoComprasNome = P000F3_A55ClienteCarrinhoComprasNome[0];
               A62CarrinhoComprasPrecoTotal = P000F3_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = P000F3_n62CarrinhoComprasPrecoTotal[0];
               A53CarrinhoComprasData = P000F3_A53CarrinhoComprasData[0];
               A57ClienteCarrinhoComprasPaisId = P000F3_A57ClienteCarrinhoComprasPaisId[0];
               A56ClienteCarrinhoComprasEndereco = P000F3_A56ClienteCarrinhoComprasEndereco[0];
               A55ClienteCarrinhoComprasNome = P000F3_A55ClienteCarrinhoComprasNome[0];
               A58ClienteCarrinhoComprasPaisNome = P000F3_A58ClienteCarrinhoComprasPaisNome[0];
               A62CarrinhoComprasPrecoTotal = P000F3_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = P000F3_n62CarrinhoComprasPrecoTotal[0];
               A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
               H0F0( false, 138) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9")), 137, Gx_line+20, 163, Gx_line+35, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A53CarrinhoComprasData, "99/99/99"), 330, Gx_line+20, 397, Gx_line+35, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(context.localUtil.Format( A63CarrinhoComprasDataEntrega, "99/99/99"), 610, Gx_line+20, 659, Gx_line+35, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A55ClienteCarrinhoComprasNome, "")), 137, Gx_line+47, 346, Gx_line+62, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A56ClienteCarrinhoComprasEndereco, "")), 57, Gx_line+73, 546, Gx_line+88, 0, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A58ClienteCarrinhoComprasPaisNome, "")), 57, Gx_line+93, 266, Gx_line+108, 0+256, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A62CarrinhoComprasPrecoTotal, "ZZZZZZ9.99")), 607, Gx_line+107, 671, Gx_line+122, 2+256, 0, 0, 0) ;
               getPrinter().GxDrawText("Carrinho:", 57, Gx_line+20, 120, Gx_line+34, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Data:", 287, Gx_line+20, 324, Gx_line+34, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Data de entrega:", 480, Gx_line+20, 587, Gx_line+34, 0, 0, 0, 0) ;
               getPrinter().GxDrawText("Cliente:", 57, Gx_line+47, 120, Gx_line+61, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 139, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Total:", 560, Gx_line+107, 600, Gx_line+121, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(0, Gx_line+127, 827, Gx_line+127, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+138);
               /* Using cursor P000F4 */
               pr_default.execute(1, new Object[] {A52CarrinhoComprasId});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A19ProdutoId = P000F4_A19ProdutoId[0];
                  A30CategoriaProdutoId = P000F4_A30CategoriaProdutoId[0];
                  A40000ProdutoImagem_GXI = P000F4_A40000ProdutoImagem_GXI[0];
                  A20ProdutoNome = P000F4_A20ProdutoNome[0];
                  A31CategoriaProdutoNome = P000F4_A31CategoriaProdutoNome[0];
                  A22ProdutoPreco = P000F4_A22ProdutoPreco[0];
                  A60CarrinhoComprasProdutosQuantid = P000F4_A60CarrinhoComprasProdutosQuantid[0];
                  A23ProdutoImagem = P000F4_A23ProdutoImagem[0];
                  A30CategoriaProdutoId = P000F4_A30CategoriaProdutoId[0];
                  A40000ProdutoImagem_GXI = P000F4_A40000ProdutoImagem_GXI[0];
                  A20ProdutoNome = P000F4_A20ProdutoNome[0];
                  A22ProdutoPreco = P000F4_A22ProdutoPreco[0];
                  A23ProdutoImagem = P000F4_A23ProdutoImagem[0];
                  A31CategoriaProdutoNome = P000F4_A31CategoriaProdutoNome[0];
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
                  H0F0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText("Produto", 47, Gx_line+0, 110, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Preço", 330, Gx_line+0, 393, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Quantidade", 480, Gx_line+0, 567, Gx_line+14, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText("Total", 607, Gx_line+0, 694, Gx_line+14, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : A23ProdutoImagem);
                  getPrinter().GxDrawBitMap(sImgUrl, 47, Gx_line+23, 100, Gx_line+73) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A20ProdutoNome, "")), 110, Gx_line+40, 319, Gx_line+55, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99")), 330, Gx_line+40, 394, Gx_line+55, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A60CarrinhoComprasProdutosQuantid), "ZZZ9")), 500, Gx_line+40, 526, Gx_line+55, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A64ProdutosPrecoTotal, "ZZZZZZ9.99")), 610, Gx_line+37, 674, Gx_line+52, 2+256, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0F0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void H0F0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
         add_metrics1( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", true, false, 57, 15, 72, 163,  new int[] {47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 19, 29, 34, 34, 55, 45, 15, 21, 21, 24, 36, 17, 21, 17, 17, 34, 34, 34, 34, 34, 34, 34, 34, 34, 34, 21, 21, 36, 36, 36, 38, 60, 43, 45, 45, 45, 41, 38, 48, 45, 17, 34, 45, 38, 53, 45, 48, 41, 48, 45, 41, 38, 45, 41, 57, 41, 41, 38, 21, 17, 21, 36, 34, 21, 34, 38, 34, 38, 34, 21, 38, 38, 17, 17, 34, 17, 55, 38, 38, 38, 38, 24, 34, 21, 38, 33, 49, 34, 34, 31, 24, 17, 24, 36, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 47, 17, 21, 34, 34, 34, 34, 17, 34, 21, 46, 23, 34, 36, 21, 46, 34, 25, 34, 21, 21, 21, 36, 34, 21, 20, 21, 23, 34, 52, 52, 52, 38, 45, 45, 45, 45, 45, 45, 62, 45, 41, 41, 41, 41, 17, 17, 17, 17, 45, 45, 48, 48, 48, 48, 48, 36, 48, 45, 45, 45, 45, 41, 41, 38, 34, 34, 34, 34, 34, 34, 55, 34, 34, 34, 34, 34, 17, 17, 17, 17, 38, 38, 38, 38, 38, 38, 38, 34, 38, 38, 38, 38, 38, 34, 38, 34}) ;
      }

      protected void add_metrics1( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if (IsMain)	waitPrinterEnd();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         scmdbuf = "";
         P000F3_A54ClienteCarrinhoComprasId = new short[1] ;
         P000F3_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         P000F3_A52CarrinhoComprasId = new short[1] ;
         P000F3_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         P000F3_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         P000F3_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         P000F3_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         P000F3_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         P000F3_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         A58ClienteCarrinhoComprasPaisNome = "";
         A56ClienteCarrinhoComprasEndereco = "";
         A55ClienteCarrinhoComprasNome = "";
         A53CarrinhoComprasData = DateTime.MinValue;
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         P000F4_A19ProdutoId = new short[1] ;
         P000F4_A30CategoriaProdutoId = new short[1] ;
         P000F4_A52CarrinhoComprasId = new short[1] ;
         P000F4_A40000ProdutoImagem_GXI = new string[] {""} ;
         P000F4_A20ProdutoNome = new string[] {""} ;
         P000F4_A31CategoriaProdutoNome = new string[] {""} ;
         P000F4_A22ProdutoPreco = new decimal[1] ;
         P000F4_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         P000F4_A23ProdutoImagem = new string[] {""} ;
         A40000ProdutoImagem_GXI = "";
         A20ProdutoNome = "";
         A31CategoriaProdutoNome = "";
         A23ProdutoImagem = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.anotafiscalcarrinho__default(),
            new Object[][] {
                new Object[] {
               P000F3_A54ClienteCarrinhoComprasId, P000F3_A57ClienteCarrinhoComprasPaisId, P000F3_A52CarrinhoComprasId, P000F3_A58ClienteCarrinhoComprasPaisNome, P000F3_A56ClienteCarrinhoComprasEndereco, P000F3_A55ClienteCarrinhoComprasNome, P000F3_A62CarrinhoComprasPrecoTotal, P000F3_n62CarrinhoComprasPrecoTotal, P000F3_A53CarrinhoComprasData
               }
               , new Object[] {
               P000F4_A19ProdutoId, P000F4_A30CategoriaProdutoId, P000F4_A52CarrinhoComprasId, P000F4_A40000ProdutoImagem_GXI, P000F4_A20ProdutoNome, P000F4_A31CategoriaProdutoNome, P000F4_A22ProdutoPreco, P000F4_A60CarrinhoComprasProdutosQuantid, P000F4_A23ProdutoImagem
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8CarrinhoComprasId ;
      private short GxWebError ;
      private short A54ClienteCarrinhoComprasId ;
      private short A57ClienteCarrinhoComprasPaisId ;
      private short A52CarrinhoComprasId ;
      private short A19ProdutoId ;
      private short A30CategoriaProdutoId ;
      private short A60CarrinhoComprasProdutosQuantid ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A62CarrinhoComprasPrecoTotal ;
      private decimal A22ProdutoPreco ;
      private decimal A64ProdutosPrecoTotal ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string sImgUrl ;
      private DateTime A53CarrinhoComprasData ;
      private DateTime A63CarrinhoComprasDataEntrega ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n62CarrinhoComprasPrecoTotal ;
      private string A58ClienteCarrinhoComprasPaisNome ;
      private string A56ClienteCarrinhoComprasEndereco ;
      private string A55ClienteCarrinhoComprasNome ;
      private string A40000ProdutoImagem_GXI ;
      private string A20ProdutoNome ;
      private string A31CategoriaProdutoNome ;
      private string A23ProdutoImagem ;
      private IGxDataStore dsDefault ;
      private short aP0_CarrinhoComprasId ;
      private IDataStoreProvider pr_default ;
      private short[] P000F3_A54ClienteCarrinhoComprasId ;
      private short[] P000F3_A57ClienteCarrinhoComprasPaisId ;
      private short[] P000F3_A52CarrinhoComprasId ;
      private string[] P000F3_A58ClienteCarrinhoComprasPaisNome ;
      private string[] P000F3_A56ClienteCarrinhoComprasEndereco ;
      private string[] P000F3_A55ClienteCarrinhoComprasNome ;
      private decimal[] P000F3_A62CarrinhoComprasPrecoTotal ;
      private bool[] P000F3_n62CarrinhoComprasPrecoTotal ;
      private DateTime[] P000F3_A53CarrinhoComprasData ;
      private short[] P000F4_A19ProdutoId ;
      private short[] P000F4_A30CategoriaProdutoId ;
      private short[] P000F4_A52CarrinhoComprasId ;
      private string[] P000F4_A40000ProdutoImagem_GXI ;
      private string[] P000F4_A20ProdutoNome ;
      private string[] P000F4_A31CategoriaProdutoNome ;
      private decimal[] P000F4_A22ProdutoPreco ;
      private short[] P000F4_A60CarrinhoComprasProdutosQuantid ;
      private string[] P000F4_A23ProdutoImagem ;
   }

   public class anotafiscalcarrinho__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000F3;
          prmP000F3 = new Object[] {
          new ParDef("@AV8CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmP000F4;
          prmP000F4 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000F3", "SELECT T1.[ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId, T2.[PaisClienteId] AS ClienteCarrinhoComprasPaisId, T1.[CarrinhoComprasId], T3.[PaisNome] AS ClienteCarrinhoComprasPaisNome, T2.[ClienteEndereco] AS ClienteCarrinhoComprasEndereco, T2.[ClienteNome] AS ClienteCarrinhoComprasNome, COALESCE( T4.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal, T1.[CarrinhoComprasData] FROM ((([CarrinhoCompras] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisClienteId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T1.[CarrinhoComprasId]) WHERE T1.[CarrinhoComprasId] = @AV8CarrinhoComprasId ORDER BY T1.[CarrinhoComprasId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P000F4", "SELECT T1.[ProdutoId], T2.[CategoriaProdutoId] AS CategoriaProdutoId, T1.[CarrinhoComprasId], T2.[ProdutoImagem_GXI], T2.[ProdutoNome], T3.[CategoriaNome] AS CategoriaProdutoNome, T2.[ProdutoPreco], T1.[CarrinhoComprasProdutosQuantid], T2.[ProdutoImagem] FROM (([CarrinhoComprasProdutos] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[ProdutoId]) INNER JOIN [Categoria] T3 ON T3.[CategoriaId] = T2.[CategoriaProdutoId]) WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ORDER BY T1.[CarrinhoComprasId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000F4,100, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDate(8);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(4));
                return;
       }
    }

 }

}
