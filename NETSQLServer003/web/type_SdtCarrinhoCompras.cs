using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   [XmlRoot(ElementName = "CarrinhoCompras" )]
   [XmlType(TypeName =  "CarrinhoCompras" , Namespace = "LojaAnnaLaisa1" )]
   [Serializable]
   public class SdtCarrinhoCompras : GxSilentTrnSdt
   {
      public SdtCarrinhoCompras( )
      {
      }

      public SdtCarrinhoCompras( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetEntryAssembly();
         initialize();
      }

      private static Hashtable mapper;
      public override string JsonMap( string value )
      {
         if ( mapper == null )
         {
            mapper = new Hashtable();
         }
         return (string)mapper[value]; ;
      }

      public void Load( short AV52CarrinhoComprasId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV52CarrinhoComprasId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CarrinhoComprasId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "CarrinhoCompras");
         metadata.Set("BT", "CarrinhoCompras");
         metadata.Set("PK", "[ \"CarrinhoComprasId\" ]");
         metadata.Set("Levels", "[ \"Produtos\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"ClienteId\" ],\"FKMap\":[ \"ClienteCarrinhoComprasId-ClienteId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Carrinhocomprasid_Z");
         state.Add("gxTpr_Carrinhocomprasdata_Z_Nullable");
         state.Add("gxTpr_Clientecarrinhocomprasid_Z");
         state.Add("gxTpr_Clientecarrinhocomprasnome_Z");
         state.Add("gxTpr_Clientecarrinhocomprasendereco_Z");
         state.Add("gxTpr_Clientecarrinhocompraspaisid_Z");
         state.Add("gxTpr_Clientecarrinhocompraspaisnome_Z");
         state.Add("gxTpr_Carrinhocomprasprecototal_Z");
         state.Add("gxTpr_Carrinhocomprasdataentrega_Z_Nullable");
         state.Add("gxTpr_Carrinhocompraspontos_Z");
         state.Add("gxTpr_Carrinhocomprasprecototal_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCarrinhoCompras sdt;
         sdt = (SdtCarrinhoCompras)(source);
         gxTv_SdtCarrinhoCompras_Carrinhocomprasid = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasid ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdata = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasdata ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega ;
         gxTv_SdtCarrinhoCompras_Carrinhocompraspontos = sdt.gxTv_SdtCarrinhoCompras_Carrinhocompraspontos ;
         gxTv_SdtCarrinhoCompras_Produtos = sdt.gxTv_SdtCarrinhoCompras_Produtos ;
         gxTv_SdtCarrinhoCompras_Mode = sdt.gxTv_SdtCarrinhoCompras_Mode ;
         gxTv_SdtCarrinhoCompras_Initialized = sdt.gxTv_SdtCarrinhoCompras_Initialized ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z ;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z ;
         gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z = sdt.gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z ;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N ;
         return  ;
      }

      public override void ToJSON( )
      {
         ToJSON( true) ;
         return  ;
      }

      public override void ToJSON( bool includeState )
      {
         ToJSON( includeState, true) ;
         return  ;
      }

      public override void ToJSON( bool includeState ,
                                   bool includeNonInitialized )
      {
         AddObjectProperty("CarrinhoComprasId", gxTv_SdtCarrinhoCompras_Carrinhocomprasid, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("CarrinhoComprasData", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("ClienteCarrinhoComprasId", gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid, false, includeNonInitialized);
         AddObjectProperty("ClienteCarrinhoComprasNome", gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome, false, includeNonInitialized);
         AddObjectProperty("ClienteCarrinhoComprasEndereco", gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco, false, includeNonInitialized);
         AddObjectProperty("ClienteCarrinhoComprasPaisId", gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid, false, includeNonInitialized);
         AddObjectProperty("ClienteCarrinhoComprasPaisNome", gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome, false, includeNonInitialized);
         AddObjectProperty("CarrinhoComprasPrecoTotal", gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal, false, includeNonInitialized);
         AddObjectProperty("CarrinhoComprasPrecoTotal_N", gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N, false, includeNonInitialized);
         sDateCnv = "";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega)), 10, 0));
         sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         sDateCnv += "-";
         sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega)), 10, 0));
         sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
         AddObjectProperty("CarrinhoComprasDataEntrega", sDateCnv, false, includeNonInitialized);
         AddObjectProperty("CarrinhoComprasPontos", gxTv_SdtCarrinhoCompras_Carrinhocompraspontos, false, includeNonInitialized);
         if ( gxTv_SdtCarrinhoCompras_Produtos != null )
         {
            AddObjectProperty("Produtos", gxTv_SdtCarrinhoCompras_Produtos, includeState, includeNonInitialized);
         }
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCarrinhoCompras_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCarrinhoCompras_Initialized, false, includeNonInitialized);
            AddObjectProperty("CarrinhoComprasId_Z", gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("CarrinhoComprasData_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("ClienteCarrinhoComprasId_Z", gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteCarrinhoComprasNome_Z", gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteCarrinhoComprasEndereco_Z", gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteCarrinhoComprasPaisId_Z", gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z, false, includeNonInitialized);
            AddObjectProperty("ClienteCarrinhoComprasPaisNome_Z", gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z, false, includeNonInitialized);
            AddObjectProperty("CarrinhoComprasPrecoTotal_Z", gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z, false, includeNonInitialized);
            sDateCnv = "";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Year( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "0000", 1, 4-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Month( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            sDateCnv += "-";
            sNumToPad = StringUtil.Trim( StringUtil.Str( (decimal)(DateTimeUtil.Day( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z)), 10, 0));
            sDateCnv += StringUtil.Substring( "00", 1, 2-StringUtil.Len( sNumToPad)) + sNumToPad;
            AddObjectProperty("CarrinhoComprasDataEntrega_Z", sDateCnv, false, includeNonInitialized);
            AddObjectProperty("CarrinhoComprasPontos_Z", gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z, false, includeNonInitialized);
            AddObjectProperty("CarrinhoComprasPrecoTotal_N", gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCarrinhoCompras sdt )
      {
         if ( sdt.IsDirty("CarrinhoComprasId") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasid = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasid ;
         }
         if ( sdt.IsDirty("CarrinhoComprasData") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasdata = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasdata ;
         }
         if ( sdt.IsDirty("ClienteCarrinhoComprasId") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid ;
         }
         if ( sdt.IsDirty("ClienteCarrinhoComprasNome") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome ;
         }
         if ( sdt.IsDirty("ClienteCarrinhoComprasEndereco") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco ;
         }
         if ( sdt.IsDirty("ClienteCarrinhoComprasPaisId") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid ;
         }
         if ( sdt.IsDirty("ClienteCarrinhoComprasPaisNome") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome = sdt.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome ;
         }
         if ( sdt.IsDirty("CarrinhoComprasPrecoTotal") )
         {
            gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N = (short)(sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N);
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal ;
         }
         if ( sdt.IsDirty("CarrinhoComprasDataEntrega") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega = sdt.gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega ;
         }
         if ( sdt.IsDirty("CarrinhoComprasPontos") )
         {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocompraspontos = sdt.gxTv_SdtCarrinhoCompras_Carrinhocompraspontos ;
         }
         if ( gxTv_SdtCarrinhoCompras_Produtos != null )
         {
            GXBCLevelCollection<SdtCarrinhoCompras_Produtos> newCollectionProdutos = sdt.gxTpr_Produtos;
            SdtCarrinhoCompras_Produtos currItemProdutos;
            SdtCarrinhoCompras_Produtos newItemProdutos;
            short idx = 1;
            while ( idx <= newCollectionProdutos.Count )
            {
               newItemProdutos = ((SdtCarrinhoCompras_Produtos)newCollectionProdutos.Item(idx));
               currItemProdutos = gxTv_SdtCarrinhoCompras_Produtos.GetByKey(newItemProdutos.gxTpr_Produtoid);
               if ( StringUtil.StrCmp(currItemProdutos.gxTpr_Mode, "UPD") == 0 )
               {
                  currItemProdutos.UpdateDirties(newItemProdutos);
                  if ( StringUtil.StrCmp(newItemProdutos.gxTpr_Mode, "DLT") == 0 )
                  {
                     currItemProdutos.gxTpr_Mode = "DLT";
                  }
                  currItemProdutos.gxTpr_Modified = 1;
               }
               else
               {
                  gxTv_SdtCarrinhoCompras_Produtos.Add(newItemProdutos, 0);
               }
               idx = (short)(idx+1);
            }
         }
         return  ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasId" )]
      [  XmlElement( ElementName = "CarrinhoComprasId"   )]
      public short gxTpr_Carrinhocomprasid
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasid ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            if ( gxTv_SdtCarrinhoCompras_Carrinhocomprasid != value )
            {
               gxTv_SdtCarrinhoCompras_Mode = "INS";
               this.gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z_SetNull( );
               this.gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z_SetNull( );
               if ( gxTv_SdtCarrinhoCompras_Produtos != null )
               {
                  GXBCLevelCollection<SdtCarrinhoCompras_Produtos> collectionProdutos = gxTv_SdtCarrinhoCompras_Produtos;
                  SdtCarrinhoCompras_Produtos currItemProdutos;
                  short idx = 1;
                  while ( idx <= collectionProdutos.Count )
                  {
                     currItemProdutos = ((SdtCarrinhoCompras_Produtos)collectionProdutos.Item(idx));
                     currItemProdutos.gxTpr_Mode = "INS";
                     currItemProdutos.gxTpr_Modified = 1;
                     idx = (short)(idx+1);
                  }
               }
            }
            gxTv_SdtCarrinhoCompras_Carrinhocomprasid = value;
            SetDirty("Carrinhocomprasid");
         }

      }

      [  SoapElement( ElementName = "CarrinhoComprasData" )]
      [  XmlElement( ElementName = "CarrinhoComprasData"  , IsNullable=true )]
      public string gxTpr_Carrinhocomprasdata_Nullable
      {
         get {
            if ( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCarrinhoCompras_Carrinhocomprasdata).value ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdata = DateTime.MinValue;
            else
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdata = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carrinhocomprasdata
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasdata ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasdata = value;
            SetDirty("Carrinhocomprasdata");
         }

      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasId" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasId"   )]
      public short gxTpr_Clientecarrinhocomprasid
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid = value;
            SetDirty("Clientecarrinhocomprasid");
         }

      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasNome" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasNome"   )]
      public string gxTpr_Clientecarrinhocomprasnome
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome = value;
            SetDirty("Clientecarrinhocomprasnome");
         }

      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasEndereco" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasEndereco"   )]
      public string gxTpr_Clientecarrinhocomprasendereco
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco = value;
            SetDirty("Clientecarrinhocomprasendereco");
         }

      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasPaisId" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasPaisId"   )]
      public short gxTpr_Clientecarrinhocompraspaisid
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid = value;
            SetDirty("Clientecarrinhocompraspaisid");
         }

      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasPaisNome" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasPaisNome"   )]
      public string gxTpr_Clientecarrinhocompraspaisnome
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome = value;
            SetDirty("Clientecarrinhocompraspaisnome");
         }

      }

      [  SoapElement( ElementName = "CarrinhoComprasPrecoTotal" )]
      [  XmlElement( ElementName = "CarrinhoComprasPrecoTotal"   )]
      public decimal gxTpr_Carrinhocomprasprecototal
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N = 0;
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal = value;
            SetDirty("Carrinhocomprasprecototal");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N = 1;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal = 0;
         SetDirty("Carrinhocomprasprecototal");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_IsNull( )
      {
         return (gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N==1) ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasDataEntrega" )]
      [  XmlElement( ElementName = "CarrinhoComprasDataEntrega"  , IsNullable=true )]
      public string gxTpr_Carrinhocomprasdataentrega_Nullable
      {
         get {
            if ( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega).value ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega = DateTime.MinValue;
            else
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carrinhocomprasdataentrega
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega = value;
            SetDirty("Carrinhocomprasdataentrega");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega = (DateTime)(DateTime.MinValue);
         SetDirty("Carrinhocomprasdataentrega");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasPontos" )]
      [  XmlElement( ElementName = "CarrinhoComprasPontos"   )]
      public decimal gxTpr_Carrinhocompraspontos
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocompraspontos ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocompraspontos = value;
            SetDirty("Carrinhocompraspontos");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocompraspontos = 0;
         SetDirty("Carrinhocompraspontos");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Produtos" )]
      [  XmlArray( ElementName = "Produtos"  )]
      [  XmlArrayItemAttribute( ElementName= "CarrinhoCompras.Produtos"  , IsNullable=false)]
      public GXBCLevelCollection<SdtCarrinhoCompras_Produtos> gxTpr_Produtos_GXBCLevelCollection
      {
         get {
            if ( gxTv_SdtCarrinhoCompras_Produtos == null )
            {
               gxTv_SdtCarrinhoCompras_Produtos = new GXBCLevelCollection<SdtCarrinhoCompras_Produtos>( context, "CarrinhoCompras.Produtos", "LojaAnnaLaisa1");
            }
            return gxTv_SdtCarrinhoCompras_Produtos ;
         }

         set {
            if ( gxTv_SdtCarrinhoCompras_Produtos == null )
            {
               gxTv_SdtCarrinhoCompras_Produtos = new GXBCLevelCollection<SdtCarrinhoCompras_Produtos>( context, "CarrinhoCompras.Produtos", "LojaAnnaLaisa1");
            }
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos = value;
         }

      }

      [XmlIgnore]
      public GXBCLevelCollection<SdtCarrinhoCompras_Produtos> gxTpr_Produtos
      {
         get {
            if ( gxTv_SdtCarrinhoCompras_Produtos == null )
            {
               gxTv_SdtCarrinhoCompras_Produtos = new GXBCLevelCollection<SdtCarrinhoCompras_Produtos>( context, "CarrinhoCompras.Produtos", "LojaAnnaLaisa1");
            }
            gxTv_SdtCarrinhoCompras_N = 0;
            return gxTv_SdtCarrinhoCompras_Produtos ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos = value;
            SetDirty("Produtos");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos = null;
         SetDirty("Produtos");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_IsNull( )
      {
         if ( gxTv_SdtCarrinhoCompras_Produtos == null )
         {
            return true ;
         }
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCarrinhoCompras_Mode ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Mode_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCarrinhoCompras_Initialized ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Initialized_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasId_Z" )]
      [  XmlElement( ElementName = "CarrinhoComprasId_Z"   )]
      public short gxTpr_Carrinhocomprasid_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z = value;
            SetDirty("Carrinhocomprasid_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z = 0;
         SetDirty("Carrinhocomprasid_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasData_Z" )]
      [  XmlElement( ElementName = "CarrinhoComprasData_Z"  , IsNullable=true )]
      public string gxTpr_Carrinhocomprasdata_Z_Nullable
      {
         get {
            if ( gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z).value ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z = DateTime.MinValue;
            else
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carrinhocomprasdata_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z = value;
            SetDirty("Carrinhocomprasdata_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Carrinhocomprasdata_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasId_Z" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasId_Z"   )]
      public short gxTpr_Clientecarrinhocomprasid_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z = value;
            SetDirty("Clientecarrinhocomprasid_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z = 0;
         SetDirty("Clientecarrinhocomprasid_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasNome_Z" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasNome_Z"   )]
      public string gxTpr_Clientecarrinhocomprasnome_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z = value;
            SetDirty("Clientecarrinhocomprasnome_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z = "";
         SetDirty("Clientecarrinhocomprasnome_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasEndereco_Z" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasEndereco_Z"   )]
      public string gxTpr_Clientecarrinhocomprasendereco_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z = value;
            SetDirty("Clientecarrinhocomprasendereco_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z = "";
         SetDirty("Clientecarrinhocomprasendereco_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasPaisId_Z" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasPaisId_Z"   )]
      public short gxTpr_Clientecarrinhocompraspaisid_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z = value;
            SetDirty("Clientecarrinhocompraspaisid_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z = 0;
         SetDirty("Clientecarrinhocompraspaisid_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ClienteCarrinhoComprasPaisNome_Z" )]
      [  XmlElement( ElementName = "ClienteCarrinhoComprasPaisNome_Z"   )]
      public string gxTpr_Clientecarrinhocompraspaisnome_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z = value;
            SetDirty("Clientecarrinhocompraspaisnome_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z = "";
         SetDirty("Clientecarrinhocompraspaisnome_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasPrecoTotal_Z" )]
      [  XmlElement( ElementName = "CarrinhoComprasPrecoTotal_Z"   )]
      public decimal gxTpr_Carrinhocomprasprecototal_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z = value;
            SetDirty("Carrinhocomprasprecototal_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z = 0;
         SetDirty("Carrinhocomprasprecototal_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasDataEntrega_Z" )]
      [  XmlElement( ElementName = "CarrinhoComprasDataEntrega_Z"  , IsNullable=true )]
      public string gxTpr_Carrinhocomprasdataentrega_Z_Nullable
      {
         get {
            if ( gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z == DateTime.MinValue)
               return null;
            return new GxDateString(gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z).value ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            if (String.IsNullOrEmpty(value) || value == GxDateString.NullValue )
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z = DateTime.MinValue;
            else
               gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z = DateTime.Parse( value);
         }

      }

      [XmlIgnore]
      public DateTime gxTpr_Carrinhocomprasdataentrega_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z = value;
            SetDirty("Carrinhocomprasdataentrega_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z = (DateTime)(DateTime.MinValue);
         SetDirty("Carrinhocomprasdataentrega_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasPontos_Z" )]
      [  XmlElement( ElementName = "CarrinhoComprasPontos_Z"   )]
      public decimal gxTpr_Carrinhocompraspontos_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z = value;
            SetDirty("Carrinhocompraspontos_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z = 0;
         SetDirty("Carrinhocompraspontos_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasPrecoTotal_N" )]
      [  XmlElement( ElementName = "CarrinhoComprasPrecoTotal_N"   )]
      public short gxTpr_Carrinhocomprasprecototal_N
      {
         get {
            return gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N ;
         }

         set {
            gxTv_SdtCarrinhoCompras_N = 0;
            gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N = value;
            SetDirty("Carrinhocomprasprecototal_N");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N = 0;
         SetDirty("Carrinhocomprasprecototal_N");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCarrinhoCompras_N = 1;
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdata = DateTime.MinValue;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome = "";
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco = "";
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome = "";
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega = DateTime.MinValue;
         gxTv_SdtCarrinhoCompras_Mode = "";
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z = DateTime.MinValue;
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z = "";
         gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z = "";
         gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z = "";
         gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z = DateTime.MinValue;
         sDateCnv = "";
         sNumToPad = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "carrinhocompras", "GeneXus.Programs.carrinhocompras_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCarrinhoCompras_N ;
      }

      private short gxTv_SdtCarrinhoCompras_Carrinhocomprasid ;
      private short gxTv_SdtCarrinhoCompras_N ;
      private short gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid ;
      private short gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid ;
      private short gxTv_SdtCarrinhoCompras_Initialized ;
      private short gxTv_SdtCarrinhoCompras_Carrinhocomprasid_Z ;
      private short gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasid_Z ;
      private short gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisid_Z ;
      private short gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_N ;
      private decimal gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal ;
      private decimal gxTv_SdtCarrinhoCompras_Carrinhocompraspontos ;
      private decimal gxTv_SdtCarrinhoCompras_Carrinhocomprasprecototal_Z ;
      private decimal gxTv_SdtCarrinhoCompras_Carrinhocompraspontos_Z ;
      private string gxTv_SdtCarrinhoCompras_Mode ;
      private string sDateCnv ;
      private string sNumToPad ;
      private DateTime gxTv_SdtCarrinhoCompras_Carrinhocomprasdata ;
      private DateTime gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega ;
      private DateTime gxTv_SdtCarrinhoCompras_Carrinhocomprasdata_Z ;
      private DateTime gxTv_SdtCarrinhoCompras_Carrinhocomprasdataentrega_Z ;
      private string gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome ;
      private string gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco ;
      private string gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome ;
      private string gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasnome_Z ;
      private string gxTv_SdtCarrinhoCompras_Clientecarrinhocomprasendereco_Z ;
      private string gxTv_SdtCarrinhoCompras_Clientecarrinhocompraspaisnome_Z ;
      private GXBCLevelCollection<SdtCarrinhoCompras_Produtos> gxTv_SdtCarrinhoCompras_Produtos=null ;
   }

   [DataContract(Name = @"CarrinhoCompras", Namespace = "LojaAnnaLaisa1")]
   public class SdtCarrinhoCompras_RESTInterface : GxGenericCollectionItem<SdtCarrinhoCompras>
   {
      public SdtCarrinhoCompras_RESTInterface( ) : base()
      {
      }

      public SdtCarrinhoCompras_RESTInterface( SdtCarrinhoCompras psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CarrinhoComprasId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Carrinhocomprasid
      {
         get {
            return sdt.gxTpr_Carrinhocomprasid ;
         }

         set {
            sdt.gxTpr_Carrinhocomprasid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CarrinhoComprasData" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Carrinhocomprasdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Carrinhocomprasdata) ;
         }

         set {
            sdt.gxTpr_Carrinhocomprasdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "ClienteCarrinhoComprasId" , Order = 2 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Clientecarrinhocomprasid
      {
         get {
            return sdt.gxTpr_Clientecarrinhocomprasid ;
         }

         set {
            sdt.gxTpr_Clientecarrinhocomprasid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ClienteCarrinhoComprasNome" , Order = 3 )]
      [GxSeudo()]
      public string gxTpr_Clientecarrinhocomprasnome
      {
         get {
            return sdt.gxTpr_Clientecarrinhocomprasnome ;
         }

         set {
            sdt.gxTpr_Clientecarrinhocomprasnome = value;
         }

      }

      [DataMember( Name = "ClienteCarrinhoComprasEndereco" , Order = 4 )]
      [GxSeudo()]
      public string gxTpr_Clientecarrinhocomprasendereco
      {
         get {
            return sdt.gxTpr_Clientecarrinhocomprasendereco ;
         }

         set {
            sdt.gxTpr_Clientecarrinhocomprasendereco = value;
         }

      }

      [DataMember( Name = "ClienteCarrinhoComprasPaisId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Clientecarrinhocompraspaisid
      {
         get {
            return sdt.gxTpr_Clientecarrinhocompraspaisid ;
         }

         set {
            sdt.gxTpr_Clientecarrinhocompraspaisid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ClienteCarrinhoComprasPaisNome" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Clientecarrinhocompraspaisnome
      {
         get {
            return sdt.gxTpr_Clientecarrinhocompraspaisnome ;
         }

         set {
            sdt.gxTpr_Clientecarrinhocompraspaisnome = value;
         }

      }

      [DataMember( Name = "CarrinhoComprasPrecoTotal" , Order = 7 )]
      [GxSeudo()]
      public string gxTpr_Carrinhocomprasprecototal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Carrinhocomprasprecototal, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Carrinhocomprasprecototal = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "CarrinhoComprasDataEntrega" , Order = 8 )]
      [GxSeudo()]
      public string gxTpr_Carrinhocomprasdataentrega
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Carrinhocomprasdataentrega) ;
         }

         set {
            sdt.gxTpr_Carrinhocomprasdataentrega = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "CarrinhoComprasPontos" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Carrinhocompraspontos
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Carrinhocompraspontos, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Carrinhocompraspontos = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "Produtos" , Order = 10 )]
      public GxGenericCollection<SdtCarrinhoCompras_Produtos_RESTInterface> gxTpr_Produtos
      {
         get {
            return new GxGenericCollection<SdtCarrinhoCompras_Produtos_RESTInterface>(sdt.gxTpr_Produtos) ;
         }

         set {
            value.LoadCollection(sdt.gxTpr_Produtos);
         }

      }

      public SdtCarrinhoCompras sdt
      {
         get {
            return (SdtCarrinhoCompras)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCarrinhoCompras() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 11 )]
      public string Hash
      {
         get {
            if ( StringUtil.StrCmp(md5Hash, null) == 0 )
            {
               md5Hash = (string)(getHash());
            }
            return md5Hash ;
         }

         set {
            md5Hash = value ;
         }

      }

      private string md5Hash ;
   }

   [DataContract(Name = @"CarrinhoCompras", Namespace = "LojaAnnaLaisa1")]
   public class SdtCarrinhoCompras_RESTLInterface : GxGenericCollectionItem<SdtCarrinhoCompras>
   {
      public SdtCarrinhoCompras_RESTLInterface( ) : base()
      {
      }

      public SdtCarrinhoCompras_RESTLInterface( SdtCarrinhoCompras psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CarrinhoComprasData" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Carrinhocomprasdata
      {
         get {
            return DateTimeUtil.DToC2( sdt.gxTpr_Carrinhocomprasdata) ;
         }

         set {
            sdt.gxTpr_Carrinhocomprasdata = DateTimeUtil.CToD2( value);
         }

      }

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtCarrinhoCompras sdt
      {
         get {
            return (SdtCarrinhoCompras)Sdt ;
         }

         set {
            Sdt = value ;
         }

      }

      [OnDeserializing]
      void checkSdt( StreamingContext ctx )
      {
         if ( sdt == null )
         {
            sdt = new SdtCarrinhoCompras() ;
         }
      }

   }

}
