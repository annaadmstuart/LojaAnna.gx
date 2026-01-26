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
   public class incrementaprecocategoria : GXProcedure
   {
      public incrementaprecocategoria( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public incrementaprecocategoria( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CategoriaId ,
                           short aP1_Porcentagem )
      {
         this.AV8CategoriaId = aP0_CategoriaId;
         this.AV10Porcentagem = aP1_Porcentagem;
         initialize();
         executePrivate();
      }

      public void executeSubmit( short aP0_CategoriaId ,
                                 short aP1_Porcentagem )
      {
         incrementaprecocategoria objincrementaprecocategoria;
         objincrementaprecocategoria = new incrementaprecocategoria();
         objincrementaprecocategoria.AV8CategoriaId = aP0_CategoriaId;
         objincrementaprecocategoria.AV10Porcentagem = aP1_Porcentagem;
         objincrementaprecocategoria.context.SetSubmitInitialConfig(context);
         objincrementaprecocategoria.initialize();
         Submit( executePrivateCatch,objincrementaprecocategoria);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((incrementaprecocategoria)stateInfo).executePrivate();
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
         /* Using cursor P000J2 */
         pr_default.execute(0, new Object[] {AV8CategoriaId});
         while ( (pr_default.getStatus(0) != 101) )
         {
            GXT0J2 = 0;
            A30CategoriaProdutoId = P000J2_A30CategoriaProdutoId[0];
            A22ProdutoPreco = P000J2_A22ProdutoPreco[0];
            A19ProdutoId = P000J2_A19ProdutoId[0];
            A22ProdutoPreco = (decimal)((A22ProdutoPreco+AV10Porcentagem)/ (decimal)(100)*A22ProdutoPreco);
            GXT0J2 = 1;
            GX_msglist.addItem("Preços aumentados.");
            /* Using cursor P000J3 */
            pr_default.execute(1, new Object[] {A22ProdutoPreco, A19ProdutoId});
            pr_default.close(1);
            pr_default.SmartCacheProvider.SetUpdated("Produto");
            if ( GXT0J2 == 1 )
            {
               context.CommitDataStores("incrementaprecocategoria",pr_default);
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("incrementaprecocategoria",pr_default);
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
         scmdbuf = "";
         P000J2_A30CategoriaProdutoId = new short[1] ;
         P000J2_A22ProdutoPreco = new decimal[1] ;
         P000J2_A19ProdutoId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.incrementaprecocategoria__default(),
            new Object[][] {
                new Object[] {
               P000J2_A30CategoriaProdutoId, P000J2_A22ProdutoPreco, P000J2_A19ProdutoId
               }
               , new Object[] {
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV8CategoriaId ;
      private short AV10Porcentagem ;
      private short GXT0J2 ;
      private short A30CategoriaProdutoId ;
      private short A19ProdutoId ;
      private decimal A22ProdutoPreco ;
      private string scmdbuf ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000J2_A30CategoriaProdutoId ;
      private decimal[] P000J2_A22ProdutoPreco ;
      private short[] P000J2_A19ProdutoId ;
   }

   public class incrementaprecocategoria__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new UpdateCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000J2;
          prmP000J2 = new Object[] {
          new ParDef("@AV8CategoriaId",GXType.Int16,4,0)
          };
          Object[] prmP000J3;
          prmP000J3 = new Object[] {
          new ParDef("@ProdutoPreco",GXType.Decimal,10,2) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000J2", "SELECT [CategoriaProdutoId], [ProdutoPreco], [ProdutoId] FROM [Produto] WITH (UPDLOCK) WHERE [CategoriaProdutoId] = @AV8CategoriaId ORDER BY [CategoriaProdutoId] ",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000J2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000J3", "UPDATE [Produto] SET [ProdutoPreco]=@ProdutoPreco  WHERE [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000J3)
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
                ((decimal[]) buf[1])[0] = rslt.getDecimal(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
