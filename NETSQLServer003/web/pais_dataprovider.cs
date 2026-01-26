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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class pais_dataprovider : GXProcedure
   {
      public pais_dataprovider( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public pais_dataprovider( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out GXBCCollection<SdtPais> aP0_ReturnValue )
      {
         this.AV2ReturnValue = new GXBCCollection<SdtPais>( context, "Pais", "LojaAnnaLaisa1") ;
         initialize();
         executePrivate();
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      public GXBCCollection<SdtPais> executeUdp( )
      {
         execute(out aP0_ReturnValue);
         return AV2ReturnValue ;
      }

      public void executeSubmit( out GXBCCollection<SdtPais> aP0_ReturnValue )
      {
         pais_dataprovider objpais_dataprovider;
         objpais_dataprovider = new pais_dataprovider();
         objpais_dataprovider.AV2ReturnValue = new GXBCCollection<SdtPais>( context, "Pais", "LojaAnnaLaisa1") ;
         objpais_dataprovider.context.SetSubmitInitialConfig(context);
         objpais_dataprovider.initialize();
         Submit( executePrivateCatch,objpais_dataprovider);
         aP0_ReturnValue=this.AV2ReturnValue;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((pais_dataprovider)stateInfo).executePrivate();
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
         args = new Object[] {(GXBCCollection<SdtPais>)AV2ReturnValue} ;
         ClassLoader.Execute("apais_dataprovider","GeneXus.Programs","apais_dataprovider", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2ReturnValue = (GXBCCollection<SdtPais>)(args[0]) ;
         }
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV2ReturnValue = new GXBCCollection<SdtPais>( context, "Pais", "LojaAnnaLaisa1");
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private IGxDataStore dsDefault ;
      private Object[] args ;
      private GXBCCollection<SdtPais> aP0_ReturnValue ;
      private GXBCCollection<SdtPais> AV2ReturnValue ;
   }

}
