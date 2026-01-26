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
   public class aprodutoscategoria : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "CategoriaId");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8CategoriaId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
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

      public aprodutoscategoria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public aprodutoscategoria( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CategoriaId )
      {
         this.AV8CategoriaId = aP0_CategoriaId;
         initialize();
         executePrivate();
         aP0_CategoriaId=this.AV8CategoriaId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_CategoriaId);
         return AV8CategoriaId ;
      }

      public void executeSubmit( ref short aP0_CategoriaId )
      {
         aprodutoscategoria objaprodutoscategoria;
         objaprodutoscategoria = new aprodutoscategoria();
         objaprodutoscategoria.AV8CategoriaId = aP0_CategoriaId;
         objaprodutoscategoria.context.SetSubmitInitialConfig(context);
         objaprodutoscategoria.initialize();
         Submit( executePrivateCatch,objaprodutoscategoria);
         aP0_CategoriaId=this.AV8CategoriaId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aprodutoscategoria)stateInfo).executePrivate();
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
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV8CategoriaId ,
                                                 A30CategoriaProdutoId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            /* Using cursor P000G2 */
            pr_default.execute(0, new Object[] {AV8CategoriaId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               BRK0G3 = false;
               A24VendedorProdutoId = P000G2_A24VendedorProdutoId[0];
               A30CategoriaProdutoId = P000G2_A30CategoriaProdutoId[0];
               A40001VendedorProdutoImagem_GXI = P000G2_A40001VendedorProdutoImagem_GXI[0];
               n40001VendedorProdutoImagem_GXI = P000G2_n40001VendedorProdutoImagem_GXI[0];
               A40000ProdutoImagem_GXI = P000G2_A40000ProdutoImagem_GXI[0];
               A25VendedorProdutoNome = P000G2_A25VendedorProdutoNome[0];
               A22ProdutoPreco = P000G2_A22ProdutoPreco[0];
               A20ProdutoNome = P000G2_A20ProdutoNome[0];
               A31CategoriaProdutoNome = P000G2_A31CategoriaProdutoNome[0];
               A19ProdutoId = P000G2_A19ProdutoId[0];
               A68VendedorProdutoImagem = P000G2_A68VendedorProdutoImagem[0];
               A23ProdutoImagem = P000G2_A23ProdutoImagem[0];
               A40001VendedorProdutoImagem_GXI = P000G2_A40001VendedorProdutoImagem_GXI[0];
               n40001VendedorProdutoImagem_GXI = P000G2_n40001VendedorProdutoImagem_GXI[0];
               A25VendedorProdutoNome = P000G2_A25VendedorProdutoNome[0];
               A68VendedorProdutoImagem = P000G2_A68VendedorProdutoImagem[0];
               A31CategoriaProdutoNome = P000G2_A31CategoriaProdutoNome[0];
               H0G0( false, 25) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 12, false, false, false, false, 0, 85, 107, 47, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A31CategoriaProdutoNome, "")), 40, Gx_line+3, 333, Gx_line+25, 0+256, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+25);
               while ( (pr_default.getStatus(0) != 101) && ( P000G2_A30CategoriaProdutoId[0] == A30CategoriaProdutoId ) )
               {
                  BRK0G3 = false;
                  A24VendedorProdutoId = P000G2_A24VendedorProdutoId[0];
                  A40001VendedorProdutoImagem_GXI = P000G2_A40001VendedorProdutoImagem_GXI[0];
                  n40001VendedorProdutoImagem_GXI = P000G2_n40001VendedorProdutoImagem_GXI[0];
                  A40000ProdutoImagem_GXI = P000G2_A40000ProdutoImagem_GXI[0];
                  A25VendedorProdutoNome = P000G2_A25VendedorProdutoNome[0];
                  A22ProdutoPreco = P000G2_A22ProdutoPreco[0];
                  A20ProdutoNome = P000G2_A20ProdutoNome[0];
                  A19ProdutoId = P000G2_A19ProdutoId[0];
                  A68VendedorProdutoImagem = P000G2_A68VendedorProdutoImagem[0];
                  A23ProdutoImagem = P000G2_A23ProdutoImagem[0];
                  A40001VendedorProdutoImagem_GXI = P000G2_A40001VendedorProdutoImagem_GXI[0];
                  n40001VendedorProdutoImagem_GXI = P000G2_n40001VendedorProdutoImagem_GXI[0];
                  A25VendedorProdutoNome = P000G2_A25VendedorProdutoNome[0];
                  A68VendedorProdutoImagem = P000G2_A68VendedorProdutoImagem[0];
                  H0G0( false, 81) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : A23ProdutoImagem);
                  getPrinter().GxDrawBitMap(sImgUrl, 63, Gx_line+7, 126, Gx_line+54) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A20ProdutoNome, "")), 143, Gx_line+20, 273, Gx_line+35, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99")), 393, Gx_line+23, 457, Gx_line+38, 2+256, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A25VendedorProdutoNome, "")), 467, Gx_line+23, 627, Gx_line+38, 0, 0, 0, 0) ;
                  sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : A68VendedorProdutoImagem);
                  getPrinter().GxDrawBitMap(sImgUrl, 663, Gx_line+10, 713, Gx_line+70) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+81);
                  BRK0G3 = true;
                  pr_default.readNext(0);
               }
               if ( ! BRK0G3 )
               {
                  BRK0G3 = true;
                  pr_default.readNext(0);
               }
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0G0( true, 0) ;
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

      protected void H0G0( bool bFoot ,
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
               getPrinter().GxDrawBitMap(context.GetImagePath( "d1264722-d6df-48f4-a529-c03a063b1abc", "", context.GetTheme( )), 120, Gx_line+13, 247, Gx_line+96) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 16, false, false, false, false, 0, 0, 0, 139, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Joias e produtos", 333, Gx_line+37, 573, Gx_line+70, 0, 0, 0, 0) ;
               getPrinter().GxDrawLine(7, Gx_line+103, 824, Gx_line+103, 1, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+112);
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
      }

      protected void add_metrics0( )
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
         P000G2_A24VendedorProdutoId = new short[1] ;
         P000G2_A30CategoriaProdutoId = new short[1] ;
         P000G2_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         P000G2_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         P000G2_A40000ProdutoImagem_GXI = new string[] {""} ;
         P000G2_A25VendedorProdutoNome = new string[] {""} ;
         P000G2_A22ProdutoPreco = new decimal[1] ;
         P000G2_A20ProdutoNome = new string[] {""} ;
         P000G2_A31CategoriaProdutoNome = new string[] {""} ;
         P000G2_A19ProdutoId = new short[1] ;
         P000G2_A68VendedorProdutoImagem = new string[] {""} ;
         P000G2_A23ProdutoImagem = new string[] {""} ;
         A40001VendedorProdutoImagem_GXI = "";
         A40000ProdutoImagem_GXI = "";
         A25VendedorProdutoNome = "";
         A20ProdutoNome = "";
         A31CategoriaProdutoNome = "";
         A68VendedorProdutoImagem = "";
         A23ProdutoImagem = "";
         sImgUrl = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aprodutoscategoria__default(),
            new Object[][] {
                new Object[] {
               P000G2_A24VendedorProdutoId, P000G2_A30CategoriaProdutoId, P000G2_A40001VendedorProdutoImagem_GXI, P000G2_n40001VendedorProdutoImagem_GXI, P000G2_A40000ProdutoImagem_GXI, P000G2_A25VendedorProdutoNome, P000G2_A22ProdutoPreco, P000G2_A20ProdutoNome, P000G2_A31CategoriaProdutoNome, P000G2_A19ProdutoId,
               P000G2_A68VendedorProdutoImagem, P000G2_A23ProdutoImagem
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short AV8CategoriaId ;
      private short GxWebError ;
      private short A30CategoriaProdutoId ;
      private short A24VendedorProdutoId ;
      private short A19ProdutoId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private decimal A22ProdutoPreco ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string sImgUrl ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool BRK0G3 ;
      private bool n40001VendedorProdutoImagem_GXI ;
      private string A40001VendedorProdutoImagem_GXI ;
      private string A40000ProdutoImagem_GXI ;
      private string A25VendedorProdutoNome ;
      private string A20ProdutoNome ;
      private string A31CategoriaProdutoNome ;
      private string A68VendedorProdutoImagem ;
      private string A23ProdutoImagem ;
      private IGxDataStore dsDefault ;
      private short aP0_CategoriaId ;
      private IDataStoreProvider pr_default ;
      private short[] P000G2_A24VendedorProdutoId ;
      private short[] P000G2_A30CategoriaProdutoId ;
      private string[] P000G2_A40001VendedorProdutoImagem_GXI ;
      private bool[] P000G2_n40001VendedorProdutoImagem_GXI ;
      private string[] P000G2_A40000ProdutoImagem_GXI ;
      private string[] P000G2_A25VendedorProdutoNome ;
      private decimal[] P000G2_A22ProdutoPreco ;
      private string[] P000G2_A20ProdutoNome ;
      private string[] P000G2_A31CategoriaProdutoNome ;
      private short[] P000G2_A19ProdutoId ;
      private string[] P000G2_A68VendedorProdutoImagem ;
      private string[] P000G2_A23ProdutoImagem ;
   }

   public class aprodutoscategoria__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000G2( IGxContext context ,
                                             short AV8CategoriaId ,
                                             short A30CategoriaProdutoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[1];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT T1.[VendedorProdutoId] AS VendedorProdutoId, T1.[CategoriaProdutoId] AS CategoriaProdutoId, T2.[VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, T1.[ProdutoImagem_GXI], T2.[VendedorNome] AS VendedorProdutoNome, T1.[ProdutoPreco], T1.[ProdutoNome], T3.[CategoriaNome] AS CategoriaProdutoNome, T1.[ProdutoId], T2.[VendedorFoto] AS VendedorProdutoImagem, T1.[ProdutoImagem] FROM (([Produto] T1 INNER JOIN [Vendedor] T2 ON T2.[VendedorId] = T1.[VendedorProdutoId]) INNER JOIN [Categoria] T3 ON T3.[CategoriaId] = T1.[CategoriaProdutoId])";
         if ( ! (0==AV8CategoriaId) )
         {
            AddWhere(sWhereString, "(T1.[CategoriaProdutoId] = @AV8CategoriaId)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY T1.[CategoriaProdutoId]";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P000G2(context, (short)dynConstraints[0] , (short)dynConstraints[1] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000G2;
          prmP000G2 = new Object[] {
          new ParDef("@AV8CategoriaId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000G2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000G2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((decimal[]) buf[6])[0] = rslt.getDecimal(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(3));
                ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
                return;
       }
    }

 }

}
