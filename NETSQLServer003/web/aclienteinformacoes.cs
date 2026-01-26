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
   public class aclienteinformacoes : GXWebProcedure
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
            gxfirstwebparm = GetFirstPar( "DataInicio");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               AV8DataInicio = context.localUtil.ParseDateParm( gxfirstwebparm);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV9DataFim = context.localUtil.ParseDateParm( GetPar( "DataFim"));
               }
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

      public aclienteinformacoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public aclienteinformacoes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_DataInicio ,
                           ref DateTime aP1_DataFim )
      {
         this.AV8DataInicio = aP0_DataInicio;
         this.AV9DataFim = aP1_DataFim;
         initialize();
         executePrivate();
         aP0_DataInicio=this.AV8DataInicio;
         aP1_DataFim=this.AV9DataFim;
      }

      public DateTime executeUdp( ref DateTime aP0_DataInicio )
      {
         execute(ref aP0_DataInicio, ref aP1_DataFim);
         return AV9DataFim ;
      }

      public void executeSubmit( ref DateTime aP0_DataInicio ,
                                 ref DateTime aP1_DataFim )
      {
         aclienteinformacoes objaclienteinformacoes;
         objaclienteinformacoes = new aclienteinformacoes();
         objaclienteinformacoes.AV8DataInicio = aP0_DataInicio;
         objaclienteinformacoes.AV9DataFim = aP1_DataFim;
         objaclienteinformacoes.context.SetSubmitInitialConfig(context);
         objaclienteinformacoes.initialize();
         Submit( executePrivateCatch,objaclienteinformacoes);
         aP0_DataInicio=this.AV8DataInicio;
         aP1_DataFim=this.AV9DataFim;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((aclienteinformacoes)stateInfo).executePrivate();
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
            H0H0( false, 142) ;
            getPrinter().GxDrawBitMap(context.GetImagePath( "d1264722-d6df-48f4-a529-c03a063b1abc", "", context.GetTheme( )), 127, Gx_line+27, 267, Gx_line+107) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 12, true, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Clientes e Carrinho Compras", 333, Gx_line+53, 633, Gx_line+74, 0, 0, 0, 0) ;
            getPrinter().GxDrawLine(0, Gx_line+133, 827, Gx_line+133, 1, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV8DataInicio, "99/99/99"), 347, Gx_line+93, 414, Gx_line+108, 2, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV9DataFim, "99/99/99"), 500, Gx_line+93, 567, Gx_line+106, 2, 0, 0, 0) ;
            getPrinter().GxDrawText("to", 453, Gx_line+93, 463, Gx_line+107, 0+256, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+142);
            /* Using cursor P000H2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A46ClienteTelefone = P000H2_A46ClienteTelefone[0];
               A47ClienteEmail = P000H2_A47ClienteEmail[0];
               A45ClienteEndereco = P000H2_A45ClienteEndereco[0];
               A44ClienteNome = P000H2_A44ClienteNome[0];
               A43ClienteId = P000H2_A43ClienteId[0];
               AV10ClienteId = A43ClienteId;
               pr_default.dynParam(1, new Object[]{ new Object[]{
                                                    AV8DataInicio ,
                                                    A53CarrinhoComprasData ,
                                                    AV10ClienteId ,
                                                    A54ClienteCarrinhoComprasId } ,
                                                    new int[]{
                                                    TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT
                                                    }
               });
               /* Using cursor P000H3 */
               pr_default.execute(1, new Object[] {AV10ClienteId, AV8DataInicio, AV8DataInicio});
               while ( (pr_default.getStatus(1) != 101) )
               {
                  A53CarrinhoComprasData = P000H3_A53CarrinhoComprasData[0];
                  A54ClienteCarrinhoComprasId = P000H3_A54ClienteCarrinhoComprasId[0];
                  A52CarrinhoComprasId = P000H3_A52CarrinhoComprasId[0];
                  H0H0( false, 100) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 0, 0, 128, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A44ClienteNome, "")), 67, Gx_line+13, 187, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A45ClienteEndereco, "")), 67, Gx_line+40, 194, Gx_line+55, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A47ClienteEmail, "")), 67, Gx_line+53, 187, Gx_line+68, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A46ClienteTelefone, "")), 227, Gx_line+40, 332, Gx_line+55, 0+256, 0, 0, 0) ;
                  getPrinter().GxDrawLine(0, Gx_line+93, 823, Gx_line+93, 1, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+100);
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
                  pr_default.readNext(1);
               }
               pr_default.close(1);
               pr_default.readNext(0);
            }
            pr_default.close(0);
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H0H0( true, 0) ;
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

      protected void H0H0( bool bFoot ,
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
         P000H2_A46ClienteTelefone = new string[] {""} ;
         P000H2_A47ClienteEmail = new string[] {""} ;
         P000H2_A45ClienteEndereco = new string[] {""} ;
         P000H2_A44ClienteNome = new string[] {""} ;
         P000H2_A43ClienteId = new short[1] ;
         A46ClienteTelefone = "";
         A47ClienteEmail = "";
         A45ClienteEndereco = "";
         A44ClienteNome = "";
         A53CarrinhoComprasData = DateTime.MinValue;
         P000H3_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         P000H3_A54ClienteCarrinhoComprasId = new short[1] ;
         P000H3_A52CarrinhoComprasId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.aclienteinformacoes__default(),
            new Object[][] {
                new Object[] {
               P000H2_A46ClienteTelefone, P000H2_A47ClienteEmail, P000H2_A45ClienteEndereco, P000H2_A44ClienteNome, P000H2_A43ClienteId
               }
               , new Object[] {
               P000H3_A53CarrinhoComprasData, P000H3_A54ClienteCarrinhoComprasId, P000H3_A52CarrinhoComprasId
               }
            }
         );
         /* GeneXus formulas. */
         Gx_line = 0;
         context.Gx_err = 0;
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short A43ClienteId ;
      private short AV10ClienteId ;
      private short A54ClienteCarrinhoComprasId ;
      private short A52CarrinhoComprasId ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private string A46ClienteTelefone ;
      private DateTime AV8DataInicio ;
      private DateTime AV9DataFim ;
      private DateTime A53CarrinhoComprasData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private string A47ClienteEmail ;
      private string A45ClienteEndereco ;
      private string A44ClienteNome ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_DataInicio ;
      private DateTime aP1_DataFim ;
      private IDataStoreProvider pr_default ;
      private string[] P000H2_A46ClienteTelefone ;
      private string[] P000H2_A47ClienteEmail ;
      private string[] P000H2_A45ClienteEndereco ;
      private string[] P000H2_A44ClienteNome ;
      private short[] P000H2_A43ClienteId ;
      private DateTime[] P000H3_A53CarrinhoComprasData ;
      private short[] P000H3_A54ClienteCarrinhoComprasId ;
      private short[] P000H3_A52CarrinhoComprasId ;
   }

   public class aclienteinformacoes__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000H3( IGxContext context ,
                                             DateTime AV8DataInicio ,
                                             DateTime A53CarrinhoComprasData ,
                                             short AV10ClienteId ,
                                             short A54ClienteCarrinhoComprasId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT TOP 1 [CarrinhoComprasData], [ClienteCarrinhoComprasId], [CarrinhoComprasId] FROM [CarrinhoCompras]";
         AddWhere(sWhereString, "([ClienteCarrinhoComprasId] = @AV10ClienteId)");
         if ( ! (DateTime.MinValue==AV8DataInicio) )
         {
            AddWhere(sWhereString, "([CarrinhoComprasData] >= @AV8DataInicio)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! (DateTime.MinValue==AV8DataInicio) )
         {
            AddWhere(sWhereString, "([CarrinhoComprasData] <= @AV8DataInicio)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         scmdbuf += sWhereString;
         scmdbuf += " ORDER BY [ClienteCarrinhoComprasId]";
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
               case 1 :
                     return conditional_P000H3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

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
          Object[] prmP000H2;
          prmP000H2 = new Object[] {
          };
          Object[] prmP000H3;
          prmP000H3 = new Object[] {
          new ParDef("@AV10ClienteId",GXType.Int16,4,0) ,
          new ParDef("@AV8DataInicio",GXType.Date,8,0) ,
          new ParDef("@AV8DataInicio",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000H2", "SELECT [ClienteTelefone], [ClienteEmail], [ClienteEndereco], [ClienteNome], [ClienteId] FROM [Cliente] ORDER BY [ClienteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000H3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000H3,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 20);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                return;
             case 1 :
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
