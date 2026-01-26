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
   public class apais_dataprovider : GXProcedure
   {
      public static int Main( string[] args )
      {
         try
         {
            GeneXus.Configuration.Config.ParseArgs(ref args);
            return new apais_dataprovider().executeCmdLine(args); ;
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
            return 1 ;
         }
      }

      public int executeCmdLine( string[] args )
      {
         GXBCCollection<SdtPais> aP0_Gxm2rootcol = new GXBCCollection<SdtPais>()  ;
         execute(out aP0_Gxm2rootcol);
         return GX.GXRuntime.ExitCode ;
      }

      public apais_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public apais_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void execute( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         this.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "LojaAnnaLaisa1") ;
         initialize();
         executePrivate();
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      public GXBCCollection<SdtPais> executeUdp( )
      {
         execute(out aP0_Gxm2rootcol);
         return Gxm2rootcol ;
      }

      public void executeSubmit( out GXBCCollection<SdtPais> aP0_Gxm2rootcol )
      {
         apais_dataprovider objapais_dataprovider;
         objapais_dataprovider = new apais_dataprovider();
         objapais_dataprovider.Gxm2rootcol = new GXBCCollection<SdtPais>( context, "Pais", "LojaAnnaLaisa1") ;
         objapais_dataprovider.context.SetSubmitInitialConfig(context);
         objapais_dataprovider.initialize();
         Submit( executePrivateCatch,objapais_dataprovider);
         aP0_Gxm2rootcol=this.Gxm2rootcol;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((apais_dataprovider)stateInfo).executePrivate();
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
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisid = 2;
         Gxm1pais.gxTpr_Paisnome = "Uruguai";
         Gxm1pais.gxTpr_Paisbandeira = context.convertURL( (string)(context.GetImagePath( "c3cca1e3-41f8-4822-95e2-4ccf76bd01c4", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisid = 3;
         Gxm1pais.gxTpr_Paisnome = "Brazil";
         Gxm1pais.gxTpr_Paisbandeira = context.convertURL( (string)(context.GetImagePath( "fd391f49-1493-4d0c-bc28-4902513956e8", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisid = 4;
         Gxm1pais.gxTpr_Paisnome = "Argentina";
         Gxm1pais.gxTpr_Paisbandeira = context.convertURL( (string)(context.GetImagePath( "3e8aef9c-d48b-40ac-8987-af5c818104b4", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisid = 5;
         Gxm1pais.gxTpr_Paisnome = "México";
         Gxm1pais.gxTpr_Paisbandeira = context.convertURL( (string)(context.GetImagePath( "16d9d7ad-b2ec-4cc6-8aad-880db160398a", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisid = 6;
         Gxm1pais.gxTpr_Paisnome = "China";
         Gxm1pais.gxTpr_Paisbandeira = context.convertURL( (string)(context.GetImagePath( "0013d92c-4883-4444-8292-cc5039455f66", "", context.GetTheme( ))));
         Gxm1pais = new SdtPais(context);
         Gxm2rootcol.Add(Gxm1pais, 0);
         Gxm1pais.gxTpr_Paisid = 7;
         Gxm1pais.gxTpr_Paisnome = "Estados unidos";
         Gxm1pais.gxTpr_Paisbandeira = context.convertURL( (string)(context.GetImagePath( "98f36b53-751d-44f9-8e80-f62dd333cab3", "", context.GetTheme( ))));
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
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
         Gxm1pais = new SdtPais(context);
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private GXBCCollection<SdtPais> aP0_Gxm2rootcol ;
      private GXBCCollection<SdtPais> Gxm2rootcol ;
      private SdtPais Gxm1pais ;
   }

}
