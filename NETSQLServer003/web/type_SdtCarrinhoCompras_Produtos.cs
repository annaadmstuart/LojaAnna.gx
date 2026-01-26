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
   [XmlRoot(ElementName = "CarrinhoCompras.Produtos" )]
   [XmlType(TypeName =  "CarrinhoCompras.Produtos" , Namespace = "LojaAnnaLaisa1" )]
   [Serializable]
   public class SdtCarrinhoCompras_Produtos : GxSilentTrnSdt, IGxSilentTrnGridItem
   {
      public SdtCarrinhoCompras_Produtos( )
      {
      }

      public SdtCarrinhoCompras_Produtos( IGxContext context )
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

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProdutoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Produtos");
         metadata.Set("BT", "CarrinhoComprasProdutos");
         metadata.Set("PK", "[ \"ProdutoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CarrinhoComprasId\" ],\"FKMap\":[  ] },{ \"FK\":[ \"ProdutoId\" ],\"FKMap\":[  ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Produtoimagem_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Modified");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Produtoid_Z");
         state.Add("gxTpr_Produtonome_Z");
         state.Add("gxTpr_Produtopreco_Z");
         state.Add("gxTpr_Carrinhocomprasprodutosquantidade_Z");
         state.Add("gxTpr_Produtosprecototal_Z");
         state.Add("gxTpr_Produtoimagem_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCarrinhoCompras_Produtos sdt;
         sdt = (SdtCarrinhoCompras_Produtos)(source);
         gxTv_SdtCarrinhoCompras_Produtos_Produtoid = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoid ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtonome = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtonome ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtopreco = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtopreco ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi ;
         gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade = sdt.gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal ;
         gxTv_SdtCarrinhoCompras_Produtos_Mode = sdt.gxTv_SdtCarrinhoCompras_Produtos_Mode ;
         gxTv_SdtCarrinhoCompras_Produtos_Modified = sdt.gxTv_SdtCarrinhoCompras_Produtos_Modified ;
         gxTv_SdtCarrinhoCompras_Produtos_Initialized = sdt.gxTv_SdtCarrinhoCompras_Produtos_Initialized ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z ;
         gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z = sdt.gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z ;
         gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z ;
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
         AddObjectProperty("ProdutoId", gxTv_SdtCarrinhoCompras_Produtos_Produtoid, false, includeNonInitialized);
         AddObjectProperty("ProdutoNome", gxTv_SdtCarrinhoCompras_Produtos_Produtonome, false, includeNonInitialized);
         AddObjectProperty("ProdutoPreco", gxTv_SdtCarrinhoCompras_Produtos_Produtopreco, false, includeNonInitialized);
         AddObjectProperty("ProdutoImagem", gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem, false, includeNonInitialized);
         AddObjectProperty("CarrinhoComprasProdutosQuantidade", gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade, false, includeNonInitialized);
         AddObjectProperty("ProdutosPrecoTotal", gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProdutoImagem_GXI", gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtCarrinhoCompras_Produtos_Mode, false, includeNonInitialized);
            AddObjectProperty("Modified", gxTv_SdtCarrinhoCompras_Produtos_Modified, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCarrinhoCompras_Produtos_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProdutoId_Z", gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutoNome_Z", gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutoPreco_Z", gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z, false, includeNonInitialized);
            AddObjectProperty("CarrinhoComprasProdutosQuantidade_Z", gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutosPrecoTotal_Z", gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutoImagem_GXI_Z", gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCarrinhoCompras_Produtos sdt )
      {
         if ( sdt.IsDirty("ProdutoId") )
         {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoid = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoid ;
         }
         if ( sdt.IsDirty("ProdutoNome") )
         {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtonome = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtonome ;
         }
         if ( sdt.IsDirty("ProdutoPreco") )
         {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtopreco = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtopreco ;
         }
         if ( sdt.IsDirty("ProdutoImagem") )
         {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem ;
         }
         if ( sdt.IsDirty("ProdutoImagem") )
         {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi ;
         }
         if ( sdt.IsDirty("CarrinhoComprasProdutosQuantidade") )
         {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade = sdt.gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade ;
         }
         if ( sdt.IsDirty("ProdutosPrecoTotal") )
         {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal = sdt.gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProdutoId" )]
      [  XmlElement( ElementName = "ProdutoId"   )]
      public short gxTpr_Produtoid
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtoid ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoid = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtoid");
         }

      }

      [  SoapElement( ElementName = "ProdutoNome" )]
      [  XmlElement( ElementName = "ProdutoNome"   )]
      public string gxTpr_Produtonome
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtonome ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtonome = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtonome");
         }

      }

      [  SoapElement( ElementName = "ProdutoPreco" )]
      [  XmlElement( ElementName = "ProdutoPreco"   )]
      public decimal gxTpr_Produtopreco
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtopreco ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtopreco = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtopreco");
         }

      }

      [  SoapElement( ElementName = "ProdutoImagem" )]
      [  XmlElement( ElementName = "ProdutoImagem"   )]
      [GxUpload()]
      public string gxTpr_Produtoimagem
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtoimagem");
         }

      }

      [  SoapElement( ElementName = "ProdutoImagem_GXI" )]
      [  XmlElement( ElementName = "ProdutoImagem_GXI"   )]
      public string gxTpr_Produtoimagem_gxi
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtoimagem_gxi");
         }

      }

      [  SoapElement( ElementName = "CarrinhoComprasProdutosQuantidade" )]
      [  XmlElement( ElementName = "CarrinhoComprasProdutosQuantidade"   )]
      public short gxTpr_Carrinhocomprasprodutosquantidade
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Carrinhocomprasprodutosquantidade");
         }

      }

      [  SoapElement( ElementName = "ProdutosPrecoTotal" )]
      [  XmlElement( ElementName = "ProdutosPrecoTotal"   )]
      public decimal gxTpr_Produtosprecototal
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtosprecototal");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal = 0;
         SetDirty("Produtosprecototal");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Mode ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Mode_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Modified" )]
      [  XmlElement( ElementName = "Modified"   )]
      public short gxTpr_Modified
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Modified ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = value;
            SetDirty("Modified");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Modified_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Modified = 0;
         SetDirty("Modified");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Modified_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Initialized ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Initialized = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Initialized_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoId_Z" )]
      [  XmlElement( ElementName = "ProdutoId_Z"   )]
      public short gxTpr_Produtoid_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtoid_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z = 0;
         SetDirty("Produtoid_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoNome_Z" )]
      [  XmlElement( ElementName = "ProdutoNome_Z"   )]
      public string gxTpr_Produtonome_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtonome_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z = "";
         SetDirty("Produtonome_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoPreco_Z" )]
      [  XmlElement( ElementName = "ProdutoPreco_Z"   )]
      public decimal gxTpr_Produtopreco_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtopreco_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z = 0;
         SetDirty("Produtopreco_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CarrinhoComprasProdutosQuantidade_Z" )]
      [  XmlElement( ElementName = "CarrinhoComprasProdutosQuantidade_Z"   )]
      public short gxTpr_Carrinhocomprasprodutosquantidade_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Carrinhocomprasprodutosquantidade_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z = 0;
         SetDirty("Carrinhocomprasprodutosquantidade_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutosPrecoTotal_Z" )]
      [  XmlElement( ElementName = "ProdutosPrecoTotal_Z"   )]
      public decimal gxTpr_Produtosprecototal_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtosprecototal_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z = 0;
         SetDirty("Produtosprecototal_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoImagem_GXI_Z" )]
      [  XmlElement( ElementName = "ProdutoImagem_GXI_Z"   )]
      public string gxTpr_Produtoimagem_gxi_Z
      {
         get {
            return gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z ;
         }

         set {
            gxTv_SdtCarrinhoCompras_Produtos_N = 0;
            gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z = value;
            gxTv_SdtCarrinhoCompras_Produtos_Modified = 1;
            SetDirty("Produtoimagem_gxi_Z");
         }

      }

      public void gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z_SetNull( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z = "";
         SetDirty("Produtoimagem_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCarrinhoCompras_Produtos_N = 1;
         gxTv_SdtCarrinhoCompras_Produtos_Produtonome = "";
         gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem = "";
         gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi = "";
         gxTv_SdtCarrinhoCompras_Produtos_Mode = "";
         gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z = "";
         gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z = "";
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCarrinhoCompras_Produtos_N ;
      }

      private short gxTv_SdtCarrinhoCompras_Produtos_Produtoid ;
      private short gxTv_SdtCarrinhoCompras_Produtos_N ;
      private short gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade ;
      private short gxTv_SdtCarrinhoCompras_Produtos_Modified ;
      private short gxTv_SdtCarrinhoCompras_Produtos_Initialized ;
      private short gxTv_SdtCarrinhoCompras_Produtos_Produtoid_Z ;
      private short gxTv_SdtCarrinhoCompras_Produtos_Carrinhocomprasprodutosquantidade_Z ;
      private decimal gxTv_SdtCarrinhoCompras_Produtos_Produtopreco ;
      private decimal gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal ;
      private decimal gxTv_SdtCarrinhoCompras_Produtos_Produtopreco_Z ;
      private decimal gxTv_SdtCarrinhoCompras_Produtos_Produtosprecototal_Z ;
      private string gxTv_SdtCarrinhoCompras_Produtos_Mode ;
      private string gxTv_SdtCarrinhoCompras_Produtos_Produtonome ;
      private string gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi ;
      private string gxTv_SdtCarrinhoCompras_Produtos_Produtonome_Z ;
      private string gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem_gxi_Z ;
      private string gxTv_SdtCarrinhoCompras_Produtos_Produtoimagem ;
   }

   [DataContract(Name = @"CarrinhoCompras.Produtos", Namespace = "LojaAnnaLaisa1")]
   public class SdtCarrinhoCompras_Produtos_RESTInterface : GxGenericCollectionItem<SdtCarrinhoCompras_Produtos>
   {
      public SdtCarrinhoCompras_Produtos_RESTInterface( ) : base()
      {
      }

      public SdtCarrinhoCompras_Produtos_RESTInterface( SdtCarrinhoCompras_Produtos psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProdutoId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Produtoid
      {
         get {
            return sdt.gxTpr_Produtoid ;
         }

         set {
            sdt.gxTpr_Produtoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProdutoNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Produtonome
      {
         get {
            return sdt.gxTpr_Produtonome ;
         }

         set {
            sdt.gxTpr_Produtonome = value;
         }

      }

      [DataMember( Name = "ProdutoPreco" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Produtopreco
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Produtopreco, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Produtopreco = NumberUtil.Val( value, ".");
         }

      }

      [DataMember( Name = "ProdutoImagem" , Order = 3 )]
      [GxUpload()]
      public string gxTpr_Produtoimagem
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Produtoimagem)) ? PathUtil.RelativeURL( sdt.gxTpr_Produtoimagem) : StringUtil.RTrim( sdt.gxTpr_Produtoimagem_gxi)) ;
         }

         set {
            sdt.gxTpr_Produtoimagem = value;
         }

      }

      [DataMember( Name = "CarrinhoComprasProdutosQuantidade" , Order = 4 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Carrinhocomprasprodutosquantidade
      {
         get {
            return sdt.gxTpr_Carrinhocomprasprodutosquantidade ;
         }

         set {
            sdt.gxTpr_Carrinhocomprasprodutosquantidade = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "ProdutosPrecoTotal" , Order = 5 )]
      [GxSeudo()]
      public string gxTpr_Produtosprecototal
      {
         get {
            return StringUtil.LTrim( StringUtil.Str( sdt.gxTpr_Produtosprecototal, 10, 2)) ;
         }

         set {
            sdt.gxTpr_Produtosprecototal = NumberUtil.Val( value, ".");
         }

      }

      public SdtCarrinhoCompras_Produtos sdt
      {
         get {
            return (SdtCarrinhoCompras_Produtos)Sdt ;
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
            sdt = new SdtCarrinhoCompras_Produtos() ;
         }
      }

   }

   [DataContract(Name = @"CarrinhoCompras.Produtos", Namespace = "LojaAnnaLaisa1")]
   public class SdtCarrinhoCompras_Produtos_RESTLInterface : GxGenericCollectionItem<SdtCarrinhoCompras_Produtos>
   {
      public SdtCarrinhoCompras_Produtos_RESTLInterface( ) : base()
      {
      }

      public SdtCarrinhoCompras_Produtos_RESTLInterface( SdtCarrinhoCompras_Produtos psdt ) : base(psdt)
      {
      }

      public SdtCarrinhoCompras_Produtos sdt
      {
         get {
            return (SdtCarrinhoCompras_Produtos)Sdt ;
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
            sdt = new SdtCarrinhoCompras_Produtos() ;
         }
      }

   }

}
