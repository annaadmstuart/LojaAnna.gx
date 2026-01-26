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
   public class produtoscategoria : GXProcedure
   {
      public produtoscategoria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public produtoscategoria( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CategoriaId )
      {
         this.AV2CategoriaId = aP0_CategoriaId;
         initialize();
         executePrivate();
         aP0_CategoriaId=this.AV2CategoriaId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_CategoriaId);
         return AV2CategoriaId ;
      }

      public void executeSubmit( ref short aP0_CategoriaId )
      {
         produtoscategoria objprodutoscategoria;
         objprodutoscategoria = new produtoscategoria();
         objprodutoscategoria.AV2CategoriaId = aP0_CategoriaId;
         objprodutoscategoria.context.SetSubmitInitialConfig(context);
         objprodutoscategoria.initialize();
         Submit( executePrivateCatch,objprodutoscategoria);
         aP0_CategoriaId=this.AV2CategoriaId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((produtoscategoria)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2CategoriaId} ;
         ClassLoader.Execute("aprodutoscategoria","GeneXus.Programs","aprodutoscategoria", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2CategoriaId = (short)(args[0]) ;
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

      private short AV2CategoriaId ;
      private IGxDataStore dsDefault ;
      private short aP0_CategoriaId ;
      private Object[] args ;
   }

}
