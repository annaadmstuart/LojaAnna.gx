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
   public class notafiscalcarrinho : GXProcedure
   {
      public notafiscalcarrinho( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
      }

      public notafiscalcarrinho( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref short aP0_CarrinhoComprasId )
      {
         this.AV2CarrinhoComprasId = aP0_CarrinhoComprasId;
         initialize();
         executePrivate();
         aP0_CarrinhoComprasId=this.AV2CarrinhoComprasId;
      }

      public short executeUdp( )
      {
         execute(ref aP0_CarrinhoComprasId);
         return AV2CarrinhoComprasId ;
      }

      public void executeSubmit( ref short aP0_CarrinhoComprasId )
      {
         notafiscalcarrinho objnotafiscalcarrinho;
         objnotafiscalcarrinho = new notafiscalcarrinho();
         objnotafiscalcarrinho.AV2CarrinhoComprasId = aP0_CarrinhoComprasId;
         objnotafiscalcarrinho.context.SetSubmitInitialConfig(context);
         objnotafiscalcarrinho.initialize();
         Submit( executePrivateCatch,objnotafiscalcarrinho);
         aP0_CarrinhoComprasId=this.AV2CarrinhoComprasId;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((notafiscalcarrinho)stateInfo).executePrivate();
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
         args = new Object[] {(short)AV2CarrinhoComprasId} ;
         ClassLoader.Execute("anotafiscalcarrinho","GeneXus.Programs","anotafiscalcarrinho", new Object[] {context }, "execute", args);
         if ( ( args != null ) && ( args.Length == 1 ) )
         {
            AV2CarrinhoComprasId = (short)(args[0]) ;
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

      private short AV2CarrinhoComprasId ;
      private IGxDataStore dsDefault ;
      private short aP0_CarrinhoComprasId ;
      private Object[] args ;
   }

}
