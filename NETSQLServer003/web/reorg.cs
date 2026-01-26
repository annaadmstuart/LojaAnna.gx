using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Reorg;
using System.Threading;
using GeneXus.Programs;
using System.Data;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
namespace GeneXus.Programs {
   public class reorg : GXReorganization
   {
      public reorg( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public reorg( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      void executePrivate( )
      {
         SetCreateDataBase( ) ;
         CreateDataBase( ) ;
         if ( PreviousCheck() )
         {
            ExecuteReorganization( ) ;
         }
      }

      private void CreateDataBase( )
      {
         DS = (GxDataStore)(context.GetDataStore( "Default"));
         ErrCode = DS.Connection.FullConnect();
         DataBaseName = DS.Connection.Database;
         if ( ErrCode != 0 )
         {
            DS.Connection.Database = "";
            ErrCode = DS.Connection.FullConnect();
            if ( ErrCode == 0 )
            {
               try
               {
                  GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbcrea")+ " " +DataBaseName , null);
                  cmdBuffer = "CREATE DATABASE " + "[" + DataBaseName + "]";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  cmdBuffer = "ALTER DATABASE " + "[" + DataBaseName + "]" + " SET READ_COMMITTED_SNAPSHOT ON";
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
                  Count = 1;
               }
               catch ( Exception ex )
               {
                  ErrCode = 1;
                  GeneXus.Reorg.GXReorganization.AddMsg( ex.Message , null);
                  throw;
               }
               ErrCode = DS.Connection.Disconnect();
               DS.Connection.Database = DataBaseName;
               ErrCode = DS.Connection.FullConnect();
               while ( ( ErrCode != 0 ) && ( Count > 0 ) && ( Count < 30 ) )
               {
                  Res = GXUtil.Sleep( 1);
                  ErrCode = DS.Connection.FullConnect();
                  Count = (short)(Count+1);
               }
               setupDB = 1;
               if ( ( setupDB == 1 ) || GeneXus.Configuration.Preferences.MustSetupDB( ) )
               {
                  defaultUsers = GXUtil.DefaultWebUser( context);
                  short gxidx;
                  gxidx = 1;
                  while ( gxidx <= defaultUsers.Count )
                  {
                     defaultUser = ((string)defaultUsers.Item(gxidx));
                     try
                     {
                        GeneXus.Reorg.GXReorganization.AddMsg( GXResourceManager.GetMessage("GXM_dbadduser", new   object[]  {defaultUser, DataBaseName}) , null);
                        cmdBuffer = "CREATE LOGIN " + "[" + defaultUser + "]" + " FROM WINDOWS";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "CREATE USER " + "[" + defaultUser + "]" + " FOR LOGIN " + "[" + defaultUser + "]";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datareader', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     try
                     {
                        cmdBuffer = "EXEC sp_addrolemember N'db_datawriter', N'" + defaultUser + "'";
                        RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                        RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                        RGZ.ExecuteStmt() ;
                        RGZ.Drop();
                     }
                     catch
                     {
                     }
                     gxidx = (short)(gxidx+1);
                  }
               }
            }
            if ( ErrCode != 0 )
            {
               ErrMsg = DS.ErrDescription;
               GeneXus.Reorg.GXReorganization.AddMsg( ErrMsg , null);
               ErrCode = 1;
               throw new Exception( ErrMsg) ;
            }
         }
      }

      private void FirstActions( )
      {
         /* Load data into tables. */
      }

      public void CreateCarrinhoComprasProdutos( )
      {
         string cmdBuffer = "";
         /* Indices for table CarrinhoComprasProdutos */
         try
         {
            cmdBuffer=" CREATE TABLE [CarrinhoComprasProdutos] ([CarrinhoComprasId] smallint NOT NULL , [ProdutoId] smallint NOT NULL , [CarrinhoComprasProdutosQuantid] smallint NOT NULL , PRIMARY KEY([CarrinhoComprasId], [ProdutoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[CarrinhoComprasProdutos]") ;
               cmdBuffer=" DROP TABLE [CarrinhoComprasProdutos] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[CarrinhoComprasProdutos]") ;
                  cmdBuffer=" DROP VIEW [CarrinhoComprasProdutos] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[CarrinhoComprasProdutos]") ;
                     cmdBuffer=" DROP FUNCTION [CarrinhoComprasProdutos] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [CarrinhoComprasProdutos] ([CarrinhoComprasId] smallint NOT NULL , [ProdutoId] smallint NOT NULL , [CarrinhoComprasProdutosQuantid] smallint NOT NULL , PRIMARY KEY([CarrinhoComprasId], [ProdutoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICARRINHOCOMPRASPRODUTOS1] ON [CarrinhoComprasProdutos] ([ProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICARRINHOCOMPRASPRODUTOS1] ON [CarrinhoComprasProdutos] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICARRINHOCOMPRASPRODUTOS1] ON [CarrinhoComprasProdutos] ([ProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCarrinhoCompras( )
      {
         string cmdBuffer = "";
         /* Indices for table CarrinhoCompras */
         try
         {
            cmdBuffer=" CREATE TABLE [CarrinhoCompras] ([CarrinhoComprasId] smallint NOT NULL , [CarrinhoComprasData] datetime NOT NULL , [ClienteCarrinhoComprasId] smallint NOT NULL , PRIMARY KEY([CarrinhoComprasId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[CarrinhoCompras]") ;
               cmdBuffer=" DROP TABLE [CarrinhoCompras] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[CarrinhoCompras]") ;
                  cmdBuffer=" DROP VIEW [CarrinhoCompras] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[CarrinhoCompras]") ;
                     cmdBuffer=" DROP FUNCTION [CarrinhoCompras] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [CarrinhoCompras] ([CarrinhoComprasId] smallint NOT NULL , [CarrinhoComprasData] datetime NOT NULL , [ClienteCarrinhoComprasId] smallint NOT NULL , PRIMARY KEY([CarrinhoComprasId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICARRINHOCOMPRAS1] ON [CarrinhoCompras] ([ClienteCarrinhoComprasId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICARRINHOCOMPRAS1] ON [CarrinhoCompras] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICARRINHOCOMPRAS1] ON [CarrinhoCompras] ([ClienteCarrinhoComprasId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCliente( )
      {
         string cmdBuffer = "";
         /* Indices for table Cliente */
         try
         {
            cmdBuffer=" CREATE TABLE [Cliente] ([ClienteId] smallint NOT NULL , [ClienteNome] nvarchar(40) NOT NULL , [ClienteEndereco] nvarchar(1024) NOT NULL , [ClienteTelefone] nchar(20) NOT NULL , [ClienteEmail] nvarchar(100) NOT NULL , [PaisClienteId] smallint NOT NULL , [CartaoPontosClienteId] smallint NULL , PRIMARY KEY([ClienteId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Cliente]") ;
               cmdBuffer=" DROP TABLE [Cliente] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Cliente]") ;
                  cmdBuffer=" DROP VIEW [Cliente] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Cliente]") ;
                     cmdBuffer=" DROP FUNCTION [Cliente] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Cliente] ([ClienteId] smallint NOT NULL , [ClienteNome] nvarchar(40) NOT NULL , [ClienteEndereco] nvarchar(1024) NOT NULL , [ClienteTelefone] nchar(20) NOT NULL , [ClienteEmail] nvarchar(100) NOT NULL , [PaisClienteId] smallint NOT NULL , [CartaoPontosClienteId] smallint NULL , PRIMARY KEY([ClienteId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICLIENTE1] ON [Cliente] ([PaisClienteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICLIENTE1] ON [Cliente] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICLIENTE1] ON [Cliente] ([PaisClienteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICLIENTE2] ON [Cliente] ([CartaoPontosClienteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [ICLIENTE2] ON [Cliente] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [ICLIENTE2] ON [Cliente] ([CartaoPontosClienteId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCartaoPontos( )
      {
         string cmdBuffer = "";
         /* Indices for table CartaoPontos */
         try
         {
            cmdBuffer=" CREATE TABLE [CartaoPontos] ([CartaoPontosId] smallint NOT NULL , [CartaoPontosDescricao] nvarchar(20) NOT NULL , [ClienteCartaoPontosId] smallint NOT NULL , PRIMARY KEY([CartaoPontosId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[CartaoPontos]") ;
               cmdBuffer=" DROP TABLE [CartaoPontos] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[CartaoPontos]") ;
                  cmdBuffer=" DROP VIEW [CartaoPontos] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[CartaoPontos]") ;
                     cmdBuffer=" DROP FUNCTION [CartaoPontos] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [CartaoPontos] ([CartaoPontosId] smallint NOT NULL , [CartaoPontosDescricao] nvarchar(20) NOT NULL , [ClienteCartaoPontosId] smallint NOT NULL , PRIMARY KEY([CartaoPontosId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UCARTAOPONTOS] ON [CartaoPontos] ([ClienteCartaoPontosId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UCARTAOPONTOS] ON [CartaoPontos] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UCARTAOPONTOS] ON [CartaoPontos] ([ClienteCartaoPontosId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePromocaoProduto( )
      {
         string cmdBuffer = "";
         /* Indices for table PromocaoProduto */
         try
         {
            cmdBuffer=" CREATE TABLE [PromocaoProduto] ([PromocaoId] smallint NOT NULL , [ProdutoId] smallint NOT NULL , PRIMARY KEY([PromocaoId], [ProdutoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[PromocaoProduto]") ;
               cmdBuffer=" DROP TABLE [PromocaoProduto] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[PromocaoProduto]") ;
                  cmdBuffer=" DROP VIEW [PromocaoProduto] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[PromocaoProduto]") ;
                     cmdBuffer=" DROP FUNCTION [PromocaoProduto] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [PromocaoProduto] ([PromocaoId] smallint NOT NULL , [ProdutoId] smallint NOT NULL , PRIMARY KEY([PromocaoId], [ProdutoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPROMOCAOPRODUTO1] ON [PromocaoProduto] ([ProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPROMOCAOPRODUTO1] ON [PromocaoProduto] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPROMOCAOPRODUTO1] ON [PromocaoProduto] ([ProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePromocao( )
      {
         string cmdBuffer = "";
         /* Indices for table Promocao */
         try
         {
            cmdBuffer=" CREATE TABLE [Promocao] ([PromocaoId] smallint NOT NULL , [PromocaoDescricao] nvarchar(40) NOT NULL , [PromocaoImagem] VARBINARY(MAX) NOT NULL , [PromocaoImagem_GXI] varchar(2048) NULL , [PromocaoDataInicio] datetime NOT NULL , [PromocaoDataTermino] datetime NOT NULL , PRIMARY KEY([PromocaoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Promocao]") ;
               cmdBuffer=" DROP TABLE [Promocao] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Promocao]") ;
                  cmdBuffer=" DROP VIEW [Promocao] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Promocao]") ;
                     cmdBuffer=" DROP FUNCTION [Promocao] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Promocao] ([PromocaoId] smallint NOT NULL , [PromocaoDescricao] nvarchar(40) NOT NULL , [PromocaoImagem] VARBINARY(MAX) NOT NULL , [PromocaoImagem_GXI] varchar(2048) NULL , [PromocaoDataInicio] datetime NOT NULL , [PromocaoDataTermino] datetime NOT NULL , PRIMARY KEY([PromocaoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateProduto( )
      {
         string cmdBuffer = "";
         /* Indices for table Produto */
         try
         {
            cmdBuffer=" CREATE TABLE [Produto] ([ProdutoId] smallint NOT NULL , [ProdutoNome] nvarchar(40) NOT NULL , [ProdutoDescricao] nvarchar(20) NOT NULL , [ProdutoPreco] money NOT NULL , [ProdutoImagem] VARBINARY(MAX) NOT NULL , [ProdutoImagem_GXI] varchar(2048) NULL , [VendedorProdutoId] smallint NOT NULL , [PaisProdutoId] smallint NOT NULL , [FornecedorProdutoId] smallint NOT NULL , [CategoriaProdutoId] smallint NOT NULL , PRIMARY KEY([ProdutoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Produto]") ;
               cmdBuffer=" DROP TABLE [Produto] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Produto]") ;
                  cmdBuffer=" DROP VIEW [Produto] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Produto]") ;
                     cmdBuffer=" DROP FUNCTION [Produto] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Produto] ([ProdutoId] smallint NOT NULL , [ProdutoNome] nvarchar(40) NOT NULL , [ProdutoDescricao] nvarchar(20) NOT NULL , [ProdutoPreco] money NOT NULL , [ProdutoImagem] VARBINARY(MAX) NOT NULL , [ProdutoImagem_GXI] varchar(2048) NULL , [VendedorProdutoId] smallint NOT NULL , [PaisProdutoId] smallint NOT NULL , [FornecedorProdutoId] smallint NOT NULL , [CategoriaProdutoId] smallint NOT NULL , PRIMARY KEY([ProdutoId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UPRODUTO] ON [Produto] ([ProdutoNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UPRODUTO] ON [Produto] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UPRODUTO] ON [Produto] ([ProdutoNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO1] ON [Produto] ([CategoriaProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRODUTO1] ON [Produto] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO1] ON [Produto] ([CategoriaProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO2] ON [Produto] ([FornecedorProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRODUTO2] ON [Produto] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO2] ON [Produto] ([FornecedorProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO3] ON [Produto] ([PaisProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRODUTO3] ON [Produto] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO3] ON [Produto] ([PaisProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO4] ON [Produto] ([VendedorProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IPRODUTO4] ON [Produto] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IPRODUTO4] ON [Produto] ([VendedorProdutoId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateFornecedor( )
      {
         string cmdBuffer = "";
         /* Indices for table Fornecedor */
         try
         {
            cmdBuffer=" CREATE TABLE [Fornecedor] ([FornecedorId] smallint NOT NULL , [FornecedorNome] nvarchar(40) NOT NULL , PRIMARY KEY([FornecedorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Fornecedor]") ;
               cmdBuffer=" DROP TABLE [Fornecedor] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Fornecedor]") ;
                  cmdBuffer=" DROP VIEW [Fornecedor] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Fornecedor]") ;
                     cmdBuffer=" DROP FUNCTION [Fornecedor] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Fornecedor] ([FornecedorId] smallint NOT NULL , [FornecedorNome] nvarchar(40) NOT NULL , PRIMARY KEY([FornecedorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UFORNECEDOR] ON [Fornecedor] ([FornecedorNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UFORNECEDOR] ON [Fornecedor] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UFORNECEDOR] ON [Fornecedor] ([FornecedorNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateVendedor( )
      {
         string cmdBuffer = "";
         /* Indices for table Vendedor */
         try
         {
            cmdBuffer=" CREATE TABLE [Vendedor] ([VendedorId] smallint NOT NULL , [VendedorNome] nvarchar(40) NOT NULL , [VendedorFoto] VARBINARY(MAX) NOT NULL , [VendedorFoto_GXI] varchar(2048) NULL , [PaisVendedorId] smallint NOT NULL , PRIMARY KEY([VendedorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Vendedor]") ;
               cmdBuffer=" DROP TABLE [Vendedor] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Vendedor]") ;
                  cmdBuffer=" DROP VIEW [Vendedor] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Vendedor]") ;
                     cmdBuffer=" DROP FUNCTION [Vendedor] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Vendedor] ([VendedorId] smallint NOT NULL , [VendedorNome] nvarchar(40) NOT NULL , [VendedorFoto] VARBINARY(MAX) NOT NULL , [VendedorFoto_GXI] varchar(2048) NULL , [PaisVendedorId] smallint NOT NULL , PRIMARY KEY([VendedorId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENDEDOR1] ON [Vendedor] ([PaisVendedorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [IVENDEDOR1] ON [Vendedor] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE NONCLUSTERED INDEX [IVENDEDOR1] ON [Vendedor] ([PaisVendedorId] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreateCategoria( )
      {
         string cmdBuffer = "";
         /* Indices for table Categoria */
         try
         {
            cmdBuffer=" CREATE TABLE [Categoria] ([CategoriaId] smallint NOT NULL , [CategoriaNome] nvarchar(40) NOT NULL , PRIMARY KEY([CategoriaId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Categoria]") ;
               cmdBuffer=" DROP TABLE [Categoria] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Categoria]") ;
                  cmdBuffer=" DROP VIEW [Categoria] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Categoria]") ;
                     cmdBuffer=" DROP FUNCTION [Categoria] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Categoria] ([CategoriaId] smallint NOT NULL , [CategoriaNome] nvarchar(40) NOT NULL , PRIMARY KEY([CategoriaId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UCATEGORIA] ON [Categoria] ([CategoriaNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UCATEGORIA] ON [Categoria] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UCATEGORIA] ON [Categoria] ([CategoriaNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void CreatePais( )
      {
         string cmdBuffer = "";
         /* Indices for table Pais */
         try
         {
            cmdBuffer=" CREATE TABLE [Pais] ([PaisId] smallint NOT NULL , [PaisNome] nvarchar(40) NOT NULL , [PaisBandeira] VARBINARY(MAX) NOT NULL , [PaisBandeira_GXI] varchar(2048) NULL , PRIMARY KEY([PaisId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               DropTableConstraints( "[Pais]") ;
               cmdBuffer=" DROP TABLE [Pais] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
               try
               {
                  DropTableConstraints( "[Pais]") ;
                  cmdBuffer=" DROP VIEW [Pais] "
                  ;
                  RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                  RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
                  RGZ.ExecuteStmt() ;
                  RGZ.Drop();
               }
               catch
               {
                  try
                  {
                     DropTableConstraints( "[Pais]") ;
                     cmdBuffer=" DROP FUNCTION [Pais] "
                     ;
                     RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
                     RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
                     RGZ.ExecuteStmt() ;
                     RGZ.Drop();
                  }
                  catch
                  {
                  }
               }
            }
            cmdBuffer=" CREATE TABLE [Pais] ([PaisId] smallint NOT NULL , [PaisNome] nvarchar(40) NOT NULL , [PaisBandeira] VARBINARY(MAX) NOT NULL , [PaisBandeira_GXI] varchar(2048) NULL , PRIMARY KEY([PaisId]))  "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         try
         {
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UPAIS] ON [Pais] ([PaisNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            cmdBuffer=" DROP INDEX [UPAIS] ON [Pais] "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            cmdBuffer=" CREATE UNIQUE NONCLUSTERED INDEX [UPAIS] ON [Pais] ([PaisNome] ) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIVendedorPais( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Vendedor] ADD CONSTRAINT [IVENDEDOR1] FOREIGN KEY ([PaisVendedorId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Vendedor] DROP CONSTRAINT [IVENDEDOR1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Vendedor] ADD CONSTRAINT [IVENDEDOR1] FOREIGN KEY ([PaisVendedorId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProdutoVendedor( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO4] FOREIGN KEY ([VendedorProdutoId]) REFERENCES [Vendedor] ([VendedorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Produto] DROP CONSTRAINT [IPRODUTO4] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO4] FOREIGN KEY ([VendedorProdutoId]) REFERENCES [Vendedor] ([VendedorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProdutoPais( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO3] FOREIGN KEY ([PaisProdutoId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Produto] DROP CONSTRAINT [IPRODUTO3] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO3] FOREIGN KEY ([PaisProdutoId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProdutoFornecedor( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO2] FOREIGN KEY ([FornecedorProdutoId]) REFERENCES [Fornecedor] ([FornecedorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Produto] DROP CONSTRAINT [IPRODUTO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO2] FOREIGN KEY ([FornecedorProdutoId]) REFERENCES [Fornecedor] ([FornecedorId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIProdutoCategoria( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO1] FOREIGN KEY ([CategoriaProdutoId]) REFERENCES [Categoria] ([CategoriaId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Produto] DROP CONSTRAINT [IPRODUTO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Produto] ADD CONSTRAINT [IPRODUTO1] FOREIGN KEY ([CategoriaProdutoId]) REFERENCES [Categoria] ([CategoriaId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPromocaoProdutoPromocao( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PromocaoProduto] ADD CONSTRAINT [IPROMOCAOPRODUTO2] FOREIGN KEY ([PromocaoId]) REFERENCES [Promocao] ([PromocaoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PromocaoProduto] DROP CONSTRAINT [IPROMOCAOPRODUTO2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PromocaoProduto] ADD CONSTRAINT [IPROMOCAOPRODUTO2] FOREIGN KEY ([PromocaoId]) REFERENCES [Promocao] ([PromocaoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIPromocaoProdutoProduto( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [PromocaoProduto] ADD CONSTRAINT [IPROMOCAOPRODUTO1] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([ProdutoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [PromocaoProduto] DROP CONSTRAINT [IPROMOCAOPRODUTO1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [PromocaoProduto] ADD CONSTRAINT [IPROMOCAOPRODUTO1] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([ProdutoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICartaoPontosCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [CartaoPontos] ADD CONSTRAINT [ICARTAOPONTOS] FOREIGN KEY ([ClienteCartaoPontosId]) REFERENCES [Cliente] ([ClienteId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [CartaoPontos] DROP CONSTRAINT [ICARTAOPONTOS] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [CartaoPontos] ADD CONSTRAINT [ICARTAOPONTOS] FOREIGN KEY ([ClienteCartaoPontosId]) REFERENCES [Cliente] ([ClienteId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClientePais( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Cliente] ADD CONSTRAINT [ICLIENTE1] FOREIGN KEY ([PaisClienteId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Cliente] DROP CONSTRAINT [ICLIENTE1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Cliente] ADD CONSTRAINT [ICLIENTE1] FOREIGN KEY ([PaisClienteId]) REFERENCES [Pais] ([PaisId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RIClienteCartaoPontos( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [Cliente] ADD CONSTRAINT [ICLIENTE2] FOREIGN KEY ([CartaoPontosClienteId]) REFERENCES [CartaoPontos] ([CartaoPontosId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [Cliente] DROP CONSTRAINT [ICLIENTE2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [Cliente] ADD CONSTRAINT [ICLIENTE2] FOREIGN KEY ([CartaoPontosClienteId]) REFERENCES [CartaoPontos] ([CartaoPontosId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICarrinhoComprasCliente( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [CarrinhoCompras] ADD CONSTRAINT [ICARRINHOCOMPRAS1] FOREIGN KEY ([ClienteCarrinhoComprasId]) REFERENCES [Cliente] ([ClienteId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [CarrinhoCompras] DROP CONSTRAINT [ICARRINHOCOMPRAS1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [CarrinhoCompras] ADD CONSTRAINT [ICARRINHOCOMPRAS1] FOREIGN KEY ([ClienteCarrinhoComprasId]) REFERENCES [Cliente] ([ClienteId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICarrinhoComprasProdutosCarrinhoCompras( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [CarrinhoComprasProdutos] ADD CONSTRAINT [ICARRINHOCOMPRASPRODUTOS2] FOREIGN KEY ([CarrinhoComprasId]) REFERENCES [CarrinhoCompras] ([CarrinhoComprasId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [CarrinhoComprasProdutos] DROP CONSTRAINT [ICARRINHOCOMPRASPRODUTOS2] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [CarrinhoComprasProdutos] ADD CONSTRAINT [ICARRINHOCOMPRASPRODUTOS2] FOREIGN KEY ([CarrinhoComprasId]) REFERENCES [CarrinhoCompras] ([CarrinhoComprasId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      public void RICarrinhoComprasProdutosProduto( )
      {
         string cmdBuffer;
         try
         {
            cmdBuffer=" ALTER TABLE [CarrinhoComprasProdutos] ADD CONSTRAINT [ICARRINHOCOMPRASPRODUTOS1] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([ProdutoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
         catch
         {
            try
            {
               cmdBuffer=" ALTER TABLE [CarrinhoComprasProdutos] DROP CONSTRAINT [ICARRINHOCOMPRASPRODUTOS1] "
               ;
               RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
               RGZ.ErrorMask = GxErrorMask.GX_MASKNOTFOUND | GxErrorMask.GX_MASKLOOPLOCK;
               RGZ.ExecuteStmt() ;
               RGZ.Drop();
            }
            catch
            {
            }
            cmdBuffer=" ALTER TABLE [CarrinhoComprasProdutos] ADD CONSTRAINT [ICARRINHOCOMPRASPRODUTOS1] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto] ([ProdutoId]) "
            ;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
         }
      }

      private void TablesCount( )
      {
      }

      private bool PreviousCheck( )
      {
         if ( ! IsResumeMode( ) )
         {
            if ( GXUtil.DbmsVersion( context, "DEFAULT") < 10 )
            {
               SetCheckError ( GXResourceManager.GetMessage("GXM_bad_DBMS_version", new   object[]  {"2012"}) ) ;
               return false ;
            }
         }
         if ( ! MustRunCheck( ) )
         {
            return true ;
         }
         if ( GXUtil.IsSQLSERVER2005( context, "DEFAULT") )
         {
            /* Using cursor P00012 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               sSchemaVar = P00012_AsSchemaVar[0];
               nsSchemaVar = P00012_nsSchemaVar[0];
               pr_default.readNext(0);
            }
            pr_default.close(0);
         }
         else
         {
            /* Using cursor P00023 */
            pr_default.execute(1);
            while ( (pr_default.getStatus(1) != 101) )
            {
               sSchemaVar = P00023_AsSchemaVar[0];
               nsSchemaVar = P00023_nsSchemaVar[0];
               pr_default.readNext(1);
            }
            pr_default.close(1);
         }
         if ( tableexist("CarrinhoComprasProdutos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CarrinhoComprasProdutos"}) ) ;
            return false ;
         }
         if ( tableexist("CarrinhoCompras",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CarrinhoCompras"}) ) ;
            return false ;
         }
         if ( tableexist("Cliente",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Cliente"}) ) ;
            return false ;
         }
         if ( tableexist("CartaoPontos",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"CartaoPontos"}) ) ;
            return false ;
         }
         if ( tableexist("PromocaoProduto",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"PromocaoProduto"}) ) ;
            return false ;
         }
         if ( tableexist("Promocao",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Promocao"}) ) ;
            return false ;
         }
         if ( tableexist("Produto",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Produto"}) ) ;
            return false ;
         }
         if ( tableexist("Fornecedor",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Fornecedor"}) ) ;
            return false ;
         }
         if ( tableexist("Vendedor",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Vendedor"}) ) ;
            return false ;
         }
         if ( tableexist("Categoria",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Categoria"}) ) ;
            return false ;
         }
         if ( tableexist("Pais",sSchemaVar) )
         {
            SetCheckError ( GXResourceManager.GetMessage("GXM_table_exist", new   object[]  {"Pais"}) ) ;
            return false ;
         }
         return true ;
      }

      private bool tableexist( string sTableName ,
                               string sMySchemaName )
      {
         bool result;
         result = false;
         /* Using cursor P00034 */
         pr_default.execute(2, new Object[] {sTableName, sMySchemaName});
         while ( (pr_default.getStatus(2) != 101) )
         {
            tablename = P00034_Atablename[0];
            ntablename = P00034_ntablename[0];
            schemaname = P00034_Aschemaname[0];
            nschemaname = P00034_nschemaname[0];
            result = true;
            pr_default.readNext(2);
         }
         pr_default.close(2);
         return result ;
      }

      private void ExecuteOnlyTablesReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 1 ,  "CreateCarrinhoComprasProdutos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 2 ,  "CreateCarrinhoCompras" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 3 ,  "CreateCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 4 ,  "CreateCartaoPontos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 5 ,  "CreatePromocaoProduto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 6 ,  "CreatePromocao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 7 ,  "CreateProduto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 8 ,  "CreateFornecedor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 9 ,  "CreateVendedor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 10 ,  "CreateCategoria" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 11 ,  "CreatePais" , new Object[]{ });
      }

      private void ExecuteOnlyRisReorganization( )
      {
         ReorgExecute.RegisterBlockForSubmit( 12 ,  "RIVendedorPais" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 13 ,  "RIProdutoVendedor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 14 ,  "RIProdutoPais" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 15 ,  "RIProdutoFornecedor" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 16 ,  "RIProdutoCategoria" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 17 ,  "RIPromocaoProdutoPromocao" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 18 ,  "RIPromocaoProdutoProduto" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 19 ,  "RICartaoPontosCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 20 ,  "RIClientePais" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 21 ,  "RIClienteCartaoPontos" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 22 ,  "RICarrinhoComprasCliente" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 23 ,  "RICarrinhoComprasProdutosCarrinhoCompras" , new Object[]{ });
         ReorgExecute.RegisterBlockForSubmit( 24 ,  "RICarrinhoComprasProdutosProduto" , new Object[]{ });
      }

      private void ExecuteTablesReorganization( )
      {
         ExecuteOnlyTablesReorganization( ) ;
         ExecuteOnlyRisReorganization( ) ;
         ReorgExecute.SubmitAll() ;
      }

      private void SetPrecedence( )
      {
         SetPrecedencetables( ) ;
         SetPrecedenceris( ) ;
      }

      private void SetPrecedencetables( )
      {
         GXReorganization.SetMsg( 1 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CarrinhoComprasProdutos", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCarrinhoComprasProdutos" ,  "CreateCarrinhoCompras" );
         ReorgExecute.RegisterPrecedence( "CreateCarrinhoComprasProdutos" ,  "CreateProduto" );
         GXReorganization.SetMsg( 2 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CarrinhoCompras", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCarrinhoCompras" ,  "CreateCliente" );
         GXReorganization.SetMsg( 3 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Cliente", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreatePais" );
         ReorgExecute.RegisterPrecedence( "CreateCliente" ,  "CreateCartaoPontos" );
         GXReorganization.SetMsg( 4 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"CartaoPontos", ""}) );
         GXReorganization.SetMsg( 5 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"PromocaoProduto", ""}) );
         ReorgExecute.RegisterPrecedence( "CreatePromocaoProduto" ,  "CreatePromocao" );
         ReorgExecute.RegisterPrecedence( "CreatePromocaoProduto" ,  "CreateProduto" );
         GXReorganization.SetMsg( 6 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Promocao", ""}) );
         GXReorganization.SetMsg( 7 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Produto", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateProduto" ,  "CreateVendedor" );
         ReorgExecute.RegisterPrecedence( "CreateProduto" ,  "CreatePais" );
         ReorgExecute.RegisterPrecedence( "CreateProduto" ,  "CreateFornecedor" );
         ReorgExecute.RegisterPrecedence( "CreateProduto" ,  "CreateCategoria" );
         GXReorganization.SetMsg( 8 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Fornecedor", ""}) );
         GXReorganization.SetMsg( 9 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Vendedor", ""}) );
         ReorgExecute.RegisterPrecedence( "CreateVendedor" ,  "CreatePais" );
         GXReorganization.SetMsg( 10 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Categoria", ""}) );
         GXReorganization.SetMsg( 11 ,  GXResourceManager.GetMessage("GXM_filecrea", new   object[]  {"Pais", ""}) );
      }

      private void SetPrecedenceris( )
      {
         GXReorganization.SetMsg( 12 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IVENDEDOR1]"}) );
         ReorgExecute.RegisterPrecedence( "RIVendedorPais" ,  "CreateVendedor" );
         ReorgExecute.RegisterPrecedence( "RIVendedorPais" ,  "CreatePais" );
         GXReorganization.SetMsg( 13 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRODUTO4]"}) );
         ReorgExecute.RegisterPrecedence( "RIProdutoVendedor" ,  "CreateProduto" );
         ReorgExecute.RegisterPrecedence( "RIProdutoVendedor" ,  "CreateVendedor" );
         GXReorganization.SetMsg( 14 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRODUTO3]"}) );
         ReorgExecute.RegisterPrecedence( "RIProdutoPais" ,  "CreateProduto" );
         ReorgExecute.RegisterPrecedence( "RIProdutoPais" ,  "CreatePais" );
         GXReorganization.SetMsg( 15 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRODUTO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIProdutoFornecedor" ,  "CreateProduto" );
         ReorgExecute.RegisterPrecedence( "RIProdutoFornecedor" ,  "CreateFornecedor" );
         GXReorganization.SetMsg( 16 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPRODUTO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIProdutoCategoria" ,  "CreateProduto" );
         ReorgExecute.RegisterPrecedence( "RIProdutoCategoria" ,  "CreateCategoria" );
         GXReorganization.SetMsg( 17 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPROMOCAOPRODUTO2]"}) );
         ReorgExecute.RegisterPrecedence( "RIPromocaoProdutoPromocao" ,  "CreatePromocaoProduto" );
         ReorgExecute.RegisterPrecedence( "RIPromocaoProdutoPromocao" ,  "CreatePromocao" );
         GXReorganization.SetMsg( 18 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[IPROMOCAOPRODUTO1]"}) );
         ReorgExecute.RegisterPrecedence( "RIPromocaoProdutoProduto" ,  "CreatePromocaoProduto" );
         ReorgExecute.RegisterPrecedence( "RIPromocaoProdutoProduto" ,  "CreateProduto" );
         GXReorganization.SetMsg( 19 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICARTAOPONTOS]"}) );
         ReorgExecute.RegisterPrecedence( "RICartaoPontosCliente" ,  "CreateCartaoPontos" );
         ReorgExecute.RegisterPrecedence( "RICartaoPontosCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 20 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICLIENTE1]"}) );
         ReorgExecute.RegisterPrecedence( "RIClientePais" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClientePais" ,  "CreatePais" );
         GXReorganization.SetMsg( 21 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICLIENTE2]"}) );
         ReorgExecute.RegisterPrecedence( "RIClienteCartaoPontos" ,  "CreateCliente" );
         ReorgExecute.RegisterPrecedence( "RIClienteCartaoPontos" ,  "CreateCartaoPontos" );
         GXReorganization.SetMsg( 22 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICARRINHOCOMPRAS1]"}) );
         ReorgExecute.RegisterPrecedence( "RICarrinhoComprasCliente" ,  "CreateCarrinhoCompras" );
         ReorgExecute.RegisterPrecedence( "RICarrinhoComprasCliente" ,  "CreateCliente" );
         GXReorganization.SetMsg( 23 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICARRINHOCOMPRASPRODUTOS2]"}) );
         ReorgExecute.RegisterPrecedence( "RICarrinhoComprasProdutosCarrinhoCompras" ,  "CreateCarrinhoComprasProdutos" );
         ReorgExecute.RegisterPrecedence( "RICarrinhoComprasProdutosCarrinhoCompras" ,  "CreateCarrinhoCompras" );
         GXReorganization.SetMsg( 24 ,  GXResourceManager.GetMessage("GXM_refintcrea", new   object[]  {"[ICARRINHOCOMPRASPRODUTOS1]"}) );
         ReorgExecute.RegisterPrecedence( "RICarrinhoComprasProdutosProduto" ,  "CreateCarrinhoComprasProdutos" );
         ReorgExecute.RegisterPrecedence( "RICarrinhoComprasProdutosProduto" ,  "CreateProduto" );
      }

      private void ExecuteReorganization( )
      {
         if ( ErrCode == 0 )
         {
            TablesCount( ) ;
            if ( ! PrintOnlyRecordCount( ) )
            {
               FirstActions( ) ;
               SetPrecedence( ) ;
               ExecuteTablesReorganization( ) ;
            }
         }
      }

      public void DropTableConstraints( string sTableName )
      {
         string cmdBuffer;
         /* Using cursor P00045 */
         pr_default.execute(3, new Object[] {sTableName});
         while ( (pr_default.getStatus(3) != 101) )
         {
            constid = P00045_Aconstid[0];
            nconstid = P00045_nconstid[0];
            fkeyid = P00045_Afkeyid[0];
            nfkeyid = P00045_nfkeyid[0];
            rkeyid = P00045_Arkeyid[0];
            nrkeyid = P00045_nrkeyid[0];
            cmdBuffer = "ALTER TABLE " + "[" + fkeyid + "] DROP CONSTRAINT " + constid;
            RGZ = new GxCommand(dsDefault.Db, cmdBuffer, dsDefault,0,true,false,null);
            RGZ.ErrorMask = GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK;
            RGZ.ExecuteStmt() ;
            RGZ.Drop();
            pr_default.readNext(3);
         }
         pr_default.close(3);
      }

      public void UtilsCleanup( )
      {
         this.cleanup();
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         DS = new GxDataStore();
         ErrMsg = "";
         DataBaseName = "";
         defaultUsers = new GeneXus.Utils.GxStringCollection();
         defaultUser = "";
         sSchemaVar = "";
         nsSchemaVar = false;
         scmdbuf = "";
         P00012_AsSchemaVar = new string[] {""} ;
         P00012_nsSchemaVar = new bool[] {false} ;
         P00023_AsSchemaVar = new string[] {""} ;
         P00023_nsSchemaVar = new bool[] {false} ;
         sTableName = "";
         sMySchemaName = "";
         tablename = "";
         ntablename = false;
         schemaname = "";
         nschemaname = false;
         P00034_Atablename = new string[] {""} ;
         P00034_ntablename = new bool[] {false} ;
         P00034_Aschemaname = new string[] {""} ;
         P00034_nschemaname = new bool[] {false} ;
         constid = "";
         nconstid = false;
         fkeyid = "";
         nfkeyid = false;
         P00045_Aconstid = new string[] {""} ;
         P00045_nconstid = new bool[] {false} ;
         P00045_Afkeyid = new string[] {""} ;
         P00045_nfkeyid = new bool[] {false} ;
         P00045_Arkeyid = new int[1] ;
         P00045_nrkeyid = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.reorg__default(),
            new Object[][] {
                new Object[] {
               P00012_AsSchemaVar
               }
               , new Object[] {
               P00023_AsSchemaVar
               }
               , new Object[] {
               P00034_Atablename, P00034_Aschemaname
               }
               , new Object[] {
               P00045_Aconstid, P00045_Afkeyid, P00045_Arkeyid
               }
            }
         );
         /* GeneXus formulas. */
      }

      protected short ErrCode ;
      protected short Count ;
      protected short Res ;
      protected short setupDB ;
      protected int rkeyid ;
      protected string ErrMsg ;
      protected string DataBaseName ;
      protected string cmdBuffer ;
      protected string defaultUser ;
      protected string sSchemaVar ;
      protected string scmdbuf ;
      protected string sTableName ;
      protected string sMySchemaName ;
      protected bool nsSchemaVar ;
      protected bool ntablename ;
      protected bool nschemaname ;
      protected bool nconstid ;
      protected bool nfkeyid ;
      protected bool nrkeyid ;
      protected string tablename ;
      protected string schemaname ;
      protected string constid ;
      protected string fkeyid ;
      protected GeneXus.Utils.GxStringCollection defaultUsers ;
      protected GxDataStore DS ;
      protected IGxDataStore dsDefault ;
      protected GxCommand RGZ ;
      protected IDataStoreProvider pr_default ;
      protected string[] P00012_AsSchemaVar ;
      protected bool[] P00012_nsSchemaVar ;
      protected string[] P00023_AsSchemaVar ;
      protected bool[] P00023_nsSchemaVar ;
      protected string[] P00034_Atablename ;
      protected bool[] P00034_ntablename ;
      protected string[] P00034_Aschemaname ;
      protected bool[] P00034_nschemaname ;
      protected string[] P00045_Aconstid ;
      protected bool[] P00045_nconstid ;
      protected string[] P00045_Afkeyid ;
      protected bool[] P00045_nfkeyid ;
      protected int[] P00045_Arkeyid ;
      protected bool[] P00045_nrkeyid ;
   }

   public class reorg__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00012;
          prmP00012 = new Object[] {
          };
          Object[] prmP00023;
          prmP00023 = new Object[] {
          };
          Object[] prmP00034;
          prmP00034 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0) ,
          new ParDef("@sMySchemaName",GXType.Char,255,0)
          };
          Object[] prmP00045;
          prmP00045 = new Object[] {
          new ParDef("@sTableName",GXType.Char,255,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00012", "SELECT SCHEMA_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00012,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00023", "SELECT USER_NAME() ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00023,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00034", "SELECT TABLE_NAME, TABLE_SCHEMA FROM INFORMATION_SCHEMA.TABLES WHERE (TABLE_NAME = @sTableName) AND (TABLE_SCHEMA = @sMySchemaName) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00034,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00045", "SELECT OBJECT_NAME(object_id), OBJECT_NAME(parent_object_id), referenced_object_id FROM sys.foreign_keys WHERE referenced_object_id = OBJECT_ID(RTRIM(LTRIM(@sTableName))) ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00045,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getString(1, 255);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                return;
       }
    }

 }

}
