using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class acategoria_dataprovider : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("LojaAnnaLaisa");
         initialize();
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Gxm2rootcol");
            toggleJsOutput = isJsOutputEnabled( );
            if ( ! entryPointCalled )
            {
               ajax_req_read_hidden_sdt(gxfirstwebparm, Gxm2rootcol);
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

      public acategoria_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public acategoria_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtCategoria> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtCategoria>( context, "Categoria", "LojaAnnaLaisa1") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtCategoria> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtCategoria> aP0_Gxm2rootcol )
      {
         acategoria_dataprovider objacategoria_dataprovider;
         objacategoria_dataprovider = new acategoria_dataprovider();
         objacategoria_dataprovider.Gxm2rootcol = new GXBCCollection<SdtCategoria>( context, "Categoria", "LojaAnnaLaisa1") ;
         objacategoria_dataprovider.context.SetSubmitInitialConfig(context);
         objacategoria_dataprovider.initialize();
         Submit( executePrivateCatch,objacategoria_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((acategoria_dataprovider)stateInfo).executePrivate();
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
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categoriaid = 1;
         Gxm1categoria.gxTpr_Categorianome = "Vestuário";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categoriaid = 2;
         Gxm1categoria.gxTpr_Categorianome = "Joalheria";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categoriaid = 3;
         Gxm1categoria.gxTpr_Categorianome = "Entreterimento";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categoriaid = 4;
         Gxm1categoria.gxTpr_Categorianome = "Casa";
         Gxm1categoria = new SdtCategoria(context);
         Gxm2rootcol.Add(Gxm1categoria, 0);
         Gxm1categoria.gxTpr_Categoriaid = 5;
         Gxm1categoria.gxTpr_Categorianome = "Saúde";
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         gxfirstwebparm = "";
         Gxm1categoria = new SdtCategoria(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nGotPars ;
      private short GxWebError ;
      private string gxfirstwebparm ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private GXBCCollection<SdtCategoria> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtCategoria> Gxm2rootcol ;
      private SdtCategoria Gxm1categoria ;
   }

}
