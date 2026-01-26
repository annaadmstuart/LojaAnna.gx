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
   public class deletacarrinhocompras : GXProcedure
   {
      public deletacarrinhocompras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public deletacarrinhocompras( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( DateTime aP0_DataInicio ,
                           DateTime aP1_DataFim )
      {
         this.AV8DataInicio = aP0_DataInicio;
         this.AV9DataFim = aP1_DataFim;
         initialize();
         executePrivate();
      }

      public void executeSubmit( DateTime aP0_DataInicio ,
                                 DateTime aP1_DataFim )
      {
         deletacarrinhocompras objdeletacarrinhocompras;
         objdeletacarrinhocompras = new deletacarrinhocompras();
         objdeletacarrinhocompras.AV8DataInicio = aP0_DataInicio;
         objdeletacarrinhocompras.AV9DataFim = aP1_DataFim;
         objdeletacarrinhocompras.context.SetSubmitInitialConfig(context);
         objdeletacarrinhocompras.initialize();
         Submit( executePrivateCatch,objdeletacarrinhocompras);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((deletacarrinhocompras)stateInfo).executePrivate();
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
         /* Using cursor P000I2 */
         pr_default.execute(0);
         while ( (pr_default.getStatus(0) != 101) )
         {
            A43ClienteId = P000I2_A43ClienteId[0];
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
            /* Using cursor P000I3 */
            pr_default.execute(1, new Object[] {AV10ClienteId, AV8DataInicio, AV8DataInicio});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A52CarrinhoComprasId = P000I3_A52CarrinhoComprasId[0];
               A53CarrinhoComprasData = P000I3_A53CarrinhoComprasData[0];
               A54ClienteCarrinhoComprasId = P000I3_A54ClienteCarrinhoComprasId[0];
               if ( DateTimeUtil.ResetTime ( A53CarrinhoComprasData ) == DateTimeUtil.ResetTime ( Gx_date ) )
               {
                  GX_msglist.addItem("O carrinho da data de hoje não pode ser deletado.");
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
               /* Optimized DELETE. */
               /* Using cursor P000I4 */
               pr_default.execute(2, new Object[] {A52CarrinhoComprasId});
               pr_default.close(2);
               pr_default.SmartCacheProvider.SetUpdated("CarrinhoComprasProdutos");
               /* End optimized DELETE. */
               /* Using cursor P000I5 */
               pr_default.execute(3, new Object[] {A52CarrinhoComprasId});
               pr_default.close(3);
               pr_default.SmartCacheProvider.SetUpdated("CarrinhoCompras");
               GX_msglist.addItem("Deletado com sucesso");
               pr_default.readNext(1);
            }
            pr_default.close(1);
            pr_default.readNext(0);
         }
         pr_default.close(0);
         this.cleanup();
      }

      public override void cleanup( )
      {
         context.CommitDataStores("deletacarrinhocompras",pr_default);
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
         P000I2_A43ClienteId = new short[1] ;
         A53CarrinhoComprasData = DateTime.MinValue;
         P000I3_A52CarrinhoComprasId = new short[1] ;
         P000I3_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         P000I3_A54ClienteCarrinhoComprasId = new short[1] ;
         Gx_date = DateTime.MinValue;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.deletacarrinhocompras__default(),
            new Object[][] {
                new Object[] {
               P000I2_A43ClienteId
               }
               , new Object[] {
               P000I3_A52CarrinhoComprasId, P000I3_A53CarrinhoComprasData, P000I3_A54ClienteCarrinhoComprasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_date = DateTimeUtil.Today( context);
         context.Gx_err = 0;
      }

      private short A43ClienteId ;
      private short AV10ClienteId ;
      private short A54ClienteCarrinhoComprasId ;
      private short A52CarrinhoComprasId ;
      private string scmdbuf ;
      private DateTime AV8DataInicio ;
      private DateTime AV9DataFim ;
      private DateTime A53CarrinhoComprasData ;
      private DateTime Gx_date ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] P000I2_A43ClienteId ;
      private short[] P000I3_A52CarrinhoComprasId ;
      private DateTime[] P000I3_A53CarrinhoComprasData ;
      private short[] P000I3_A54ClienteCarrinhoComprasId ;
   }

   public class deletacarrinhocompras__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P000I3( IGxContext context ,
                                             DateTime AV8DataInicio ,
                                             DateTime A53CarrinhoComprasData ,
                                             short AV10ClienteId ,
                                             short A54ClienteCarrinhoComprasId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[3];
         Object[] GXv_Object2 = new Object[2];
         scmdbuf = "SELECT [CarrinhoComprasId], [CarrinhoComprasData], [ClienteCarrinhoComprasId] FROM [CarrinhoCompras] WITH (UPDLOCK)";
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
                     return conditional_P000I3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new UpdateCursor(def[2])
         ,new UpdateCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP000I2;
          prmP000I2 = new Object[] {
          };
          Object[] prmP000I4;
          prmP000I4 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmP000I5;
          prmP000I5 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmP000I3;
          prmP000I3 = new Object[] {
          new ParDef("@AV10ClienteId",GXType.Int16,4,0) ,
          new ParDef("@AV8DataInicio",GXType.Date,8,0) ,
          new ParDef("@AV8DataInicio",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P000I2", "SELECT [ClienteId] FROM [Cliente] ORDER BY [ClienteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000I3", "scmdbuf",true, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP000I3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P000I4", "DELETE FROM [CarrinhoComprasProdutos]  WHERE [CarrinhoComprasId] = @CarrinhoComprasId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000I4)
             ,new CursorDef("P000I5", "DELETE FROM [CarrinhoCompras]  WHERE [CarrinhoComprasId] = @CarrinhoComprasId", GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK,prmP000I5)
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
       }
    }

 }

}
