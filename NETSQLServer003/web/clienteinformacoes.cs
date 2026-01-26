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
   public class clienteinformacoes : GXProcedure
   {
      public clienteinformacoes( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public clienteinformacoes( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref DateTime aP0_DataInicio ,
                           ref DateTime aP1_DataFim )
      {
         this.AV2DataInicio = aP0_DataInicio;
         this.AV3DataFim = aP1_DataFim;
         initialize();
         executePrivate();
         aP0_DataInicio=this.AV2DataInicio;
         aP1_DataFim=this.AV3DataFim;
      }

      public DateTime executeUdp( ref DateTime aP0_DataInicio )
      {
         execute(ref aP0_DataInicio, ref aP1_DataFim);
         return AV3DataFim ;
      }

      public void executeSubmit( ref DateTime aP0_DataInicio ,
                                 ref DateTime aP1_DataFim )
      {
         clienteinformacoes objclienteinformacoes;
         objclienteinformacoes = new clienteinformacoes();
         objclienteinformacoes.AV2DataInicio = aP0_DataInicio;
         objclienteinformacoes.AV3DataFim = aP1_DataFim;
         objclienteinformacoes.context.SetSubmitInitialConfig(context);
         objclienteinformacoes.initialize();
         Submit( executePrivateCatch,objclienteinformacoes);
         aP0_DataInicio=this.AV2DataInicio;
         aP1_DataFim=this.AV3DataFim;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clienteinformacoes)stateInfo).executePrivate();
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
         args = new Object[] {(DateTime)AV2DataInicio,(DateTime)AV3DataFim} ;
         ClassLoader.Execute("aclienteinformacoes","GeneXus.Programs","aclienteinformacoes", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 2 ) )
         {
            AV2DataInicio = (DateTime)(args[0]) ;
            AV3DataFim = (DateTime)(args[1]) ;
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
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private DateTime AV2DataInicio ;
      private DateTime AV3DataFim ;
      private IGxDataStore dsDefault ;
      private DateTime aP0_DataInicio ;
      private DateTime aP1_DataFim ;
      private Object[] args ;
   }

}
