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
   [XmlRoot(ElementName = "Produto" )]
   [XmlType(TypeName =  "Produto" , Namespace = "LojaAnnaLaisa1" )]
   [Serializable]
   public class SdtProduto : GxSilentTrnSdt
   {
      public SdtProduto( )
      {
      }

      public SdtProduto( IGxContext context )
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

      public void Load( short AV19ProdutoId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV19ProdutoId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"ProdutoId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Produto");
         metadata.Set("BT", "Produto");
         metadata.Set("PK", "[ \"ProdutoId\" ]");
         metadata.Set("FKList", "[ { \"FK\":[ \"CategoriaId\" ],\"FKMap\":[ \"CategoriaProdutoId-CategoriaId\" ] },{ \"FK\":[ \"FornecedorId\" ],\"FKMap\":[ \"FornecedorProdutoId-FornecedorId\" ] },{ \"FK\":[ \"PaisId\" ],\"FKMap\":[ \"PaisProdutoId-PaisId\" ] },{ \"FK\":[ \"VendedorId\" ],\"FKMap\":[ \"VendedorProdutoId-VendedorId\" ] } ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Produtoimagem_gxi");
         state.Add("gxTpr_Vendedorprodutoimagem_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Produtoid_Z");
         state.Add("gxTpr_Produtonome_Z");
         state.Add("gxTpr_Produtodescricao_Z");
         state.Add("gxTpr_Produtopreco_Z");
         state.Add("gxTpr_Vendedorprodutoid_Z");
         state.Add("gxTpr_Vendedorprodutonome_Z");
         state.Add("gxTpr_Paisprodutoid_Z");
         state.Add("gxTpr_Paisprodutonome_Z");
         state.Add("gxTpr_Fornecedorprodutoid_Z");
         state.Add("gxTpr_Fornecedorprodutonome_Z");
         state.Add("gxTpr_Categoriaprodutoid_Z");
         state.Add("gxTpr_Categoriaprodutonome_Z");
         state.Add("gxTpr_Produtoimagem_gxi_Z");
         state.Add("gxTpr_Vendedorprodutoimagem_gxi_Z");
         state.Add("gxTpr_Vendedorprodutoimagem_gxi_N");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtProduto sdt;
         sdt = (SdtProduto)(source);
         gxTv_SdtProduto_Produtoid = sdt.gxTv_SdtProduto_Produtoid ;
         gxTv_SdtProduto_Produtonome = sdt.gxTv_SdtProduto_Produtonome ;
         gxTv_SdtProduto_Produtodescricao = sdt.gxTv_SdtProduto_Produtodescricao ;
         gxTv_SdtProduto_Produtopreco = sdt.gxTv_SdtProduto_Produtopreco ;
         gxTv_SdtProduto_Produtoimagem = sdt.gxTv_SdtProduto_Produtoimagem ;
         gxTv_SdtProduto_Produtoimagem_gxi = sdt.gxTv_SdtProduto_Produtoimagem_gxi ;
         gxTv_SdtProduto_Vendedorprodutoid = sdt.gxTv_SdtProduto_Vendedorprodutoid ;
         gxTv_SdtProduto_Vendedorprodutonome = sdt.gxTv_SdtProduto_Vendedorprodutonome ;
         gxTv_SdtProduto_Vendedorprodutoimagem = sdt.gxTv_SdtProduto_Vendedorprodutoimagem ;
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi = sdt.gxTv_SdtProduto_Vendedorprodutoimagem_gxi ;
         gxTv_SdtProduto_Paisprodutoid = sdt.gxTv_SdtProduto_Paisprodutoid ;
         gxTv_SdtProduto_Paisprodutonome = sdt.gxTv_SdtProduto_Paisprodutonome ;
         gxTv_SdtProduto_Fornecedorprodutoid = sdt.gxTv_SdtProduto_Fornecedorprodutoid ;
         gxTv_SdtProduto_Fornecedorprodutonome = sdt.gxTv_SdtProduto_Fornecedorprodutonome ;
         gxTv_SdtProduto_Categoriaprodutoid = sdt.gxTv_SdtProduto_Categoriaprodutoid ;
         gxTv_SdtProduto_Categoriaprodutonome = sdt.gxTv_SdtProduto_Categoriaprodutonome ;
         gxTv_SdtProduto_Mode = sdt.gxTv_SdtProduto_Mode ;
         gxTv_SdtProduto_Initialized = sdt.gxTv_SdtProduto_Initialized ;
         gxTv_SdtProduto_Produtoid_Z = sdt.gxTv_SdtProduto_Produtoid_Z ;
         gxTv_SdtProduto_Produtonome_Z = sdt.gxTv_SdtProduto_Produtonome_Z ;
         gxTv_SdtProduto_Produtodescricao_Z = sdt.gxTv_SdtProduto_Produtodescricao_Z ;
         gxTv_SdtProduto_Produtopreco_Z = sdt.gxTv_SdtProduto_Produtopreco_Z ;
         gxTv_SdtProduto_Vendedorprodutoid_Z = sdt.gxTv_SdtProduto_Vendedorprodutoid_Z ;
         gxTv_SdtProduto_Vendedorprodutonome_Z = sdt.gxTv_SdtProduto_Vendedorprodutonome_Z ;
         gxTv_SdtProduto_Paisprodutoid_Z = sdt.gxTv_SdtProduto_Paisprodutoid_Z ;
         gxTv_SdtProduto_Paisprodutonome_Z = sdt.gxTv_SdtProduto_Paisprodutonome_Z ;
         gxTv_SdtProduto_Fornecedorprodutoid_Z = sdt.gxTv_SdtProduto_Fornecedorprodutoid_Z ;
         gxTv_SdtProduto_Fornecedorprodutonome_Z = sdt.gxTv_SdtProduto_Fornecedorprodutonome_Z ;
         gxTv_SdtProduto_Categoriaprodutoid_Z = sdt.gxTv_SdtProduto_Categoriaprodutoid_Z ;
         gxTv_SdtProduto_Categoriaprodutonome_Z = sdt.gxTv_SdtProduto_Categoriaprodutonome_Z ;
         gxTv_SdtProduto_Produtoimagem_gxi_Z = sdt.gxTv_SdtProduto_Produtoimagem_gxi_Z ;
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z = sdt.gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z ;
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N = sdt.gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N ;
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
         AddObjectProperty("ProdutoId", gxTv_SdtProduto_Produtoid, false, includeNonInitialized);
         AddObjectProperty("ProdutoNome", gxTv_SdtProduto_Produtonome, false, includeNonInitialized);
         AddObjectProperty("ProdutoDescricao", gxTv_SdtProduto_Produtodescricao, false, includeNonInitialized);
         AddObjectProperty("ProdutoPreco", gxTv_SdtProduto_Produtopreco, false, includeNonInitialized);
         AddObjectProperty("ProdutoImagem", gxTv_SdtProduto_Produtoimagem, false, includeNonInitialized);
         AddObjectProperty("VendedorProdutoId", gxTv_SdtProduto_Vendedorprodutoid, false, includeNonInitialized);
         AddObjectProperty("VendedorProdutoNome", gxTv_SdtProduto_Vendedorprodutonome, false, includeNonInitialized);
         AddObjectProperty("VendedorProdutoImagem", gxTv_SdtProduto_Vendedorprodutoimagem, false, includeNonInitialized);
         AddObjectProperty("PaisProdutoId", gxTv_SdtProduto_Paisprodutoid, false, includeNonInitialized);
         AddObjectProperty("PaisProdutoNome", gxTv_SdtProduto_Paisprodutonome, false, includeNonInitialized);
         AddObjectProperty("FornecedorProdutoId", gxTv_SdtProduto_Fornecedorprodutoid, false, includeNonInitialized);
         AddObjectProperty("FornecedorProdutoNome", gxTv_SdtProduto_Fornecedorprodutonome, false, includeNonInitialized);
         AddObjectProperty("CategoriaProdutoId", gxTv_SdtProduto_Categoriaprodutoid, false, includeNonInitialized);
         AddObjectProperty("CategoriaProdutoNome", gxTv_SdtProduto_Categoriaprodutonome, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("ProdutoImagem_GXI", gxTv_SdtProduto_Produtoimagem_gxi, false, includeNonInitialized);
            AddObjectProperty("VendedorProdutoImagem_GXI", gxTv_SdtProduto_Vendedorprodutoimagem_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtProduto_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtProduto_Initialized, false, includeNonInitialized);
            AddObjectProperty("ProdutoId_Z", gxTv_SdtProduto_Produtoid_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutoNome_Z", gxTv_SdtProduto_Produtonome_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutoDescricao_Z", gxTv_SdtProduto_Produtodescricao_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutoPreco_Z", gxTv_SdtProduto_Produtopreco_Z, false, includeNonInitialized);
            AddObjectProperty("VendedorProdutoId_Z", gxTv_SdtProduto_Vendedorprodutoid_Z, false, includeNonInitialized);
            AddObjectProperty("VendedorProdutoNome_Z", gxTv_SdtProduto_Vendedorprodutonome_Z, false, includeNonInitialized);
            AddObjectProperty("PaisProdutoId_Z", gxTv_SdtProduto_Paisprodutoid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisProdutoNome_Z", gxTv_SdtProduto_Paisprodutonome_Z, false, includeNonInitialized);
            AddObjectProperty("FornecedorProdutoId_Z", gxTv_SdtProduto_Fornecedorprodutoid_Z, false, includeNonInitialized);
            AddObjectProperty("FornecedorProdutoNome_Z", gxTv_SdtProduto_Fornecedorprodutonome_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaProdutoId_Z", gxTv_SdtProduto_Categoriaprodutoid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaProdutoNome_Z", gxTv_SdtProduto_Categoriaprodutonome_Z, false, includeNonInitialized);
            AddObjectProperty("ProdutoImagem_GXI_Z", gxTv_SdtProduto_Produtoimagem_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("VendedorProdutoImagem_GXI_Z", gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z, false, includeNonInitialized);
            AddObjectProperty("VendedorProdutoImagem_GXI_N", gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtProduto sdt )
      {
         if ( sdt.IsDirty("ProdutoId") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtoid = sdt.gxTv_SdtProduto_Produtoid ;
         }
         if ( sdt.IsDirty("ProdutoNome") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtonome = sdt.gxTv_SdtProduto_Produtonome ;
         }
         if ( sdt.IsDirty("ProdutoDescricao") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtodescricao = sdt.gxTv_SdtProduto_Produtodescricao ;
         }
         if ( sdt.IsDirty("ProdutoPreco") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtopreco = sdt.gxTv_SdtProduto_Produtopreco ;
         }
         if ( sdt.IsDirty("ProdutoImagem") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtoimagem = sdt.gxTv_SdtProduto_Produtoimagem ;
         }
         if ( sdt.IsDirty("ProdutoImagem") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtoimagem_gxi = sdt.gxTv_SdtProduto_Produtoimagem_gxi ;
         }
         if ( sdt.IsDirty("VendedorProdutoId") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoid = sdt.gxTv_SdtProduto_Vendedorprodutoid ;
         }
         if ( sdt.IsDirty("VendedorProdutoNome") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutonome = sdt.gxTv_SdtProduto_Vendedorprodutonome ;
         }
         if ( sdt.IsDirty("VendedorProdutoImagem") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoimagem = sdt.gxTv_SdtProduto_Vendedorprodutoimagem ;
         }
         if ( sdt.IsDirty("VendedorProdutoImagem") )
         {
            gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N = (short)(sdt.gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N);
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoimagem_gxi = sdt.gxTv_SdtProduto_Vendedorprodutoimagem_gxi ;
         }
         if ( sdt.IsDirty("PaisProdutoId") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Paisprodutoid = sdt.gxTv_SdtProduto_Paisprodutoid ;
         }
         if ( sdt.IsDirty("PaisProdutoNome") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Paisprodutonome = sdt.gxTv_SdtProduto_Paisprodutonome ;
         }
         if ( sdt.IsDirty("FornecedorProdutoId") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Fornecedorprodutoid = sdt.gxTv_SdtProduto_Fornecedorprodutoid ;
         }
         if ( sdt.IsDirty("FornecedorProdutoNome") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Fornecedorprodutonome = sdt.gxTv_SdtProduto_Fornecedorprodutonome ;
         }
         if ( sdt.IsDirty("CategoriaProdutoId") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Categoriaprodutoid = sdt.gxTv_SdtProduto_Categoriaprodutoid ;
         }
         if ( sdt.IsDirty("CategoriaProdutoNome") )
         {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Categoriaprodutonome = sdt.gxTv_SdtProduto_Categoriaprodutonome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "ProdutoId" )]
      [  XmlElement( ElementName = "ProdutoId"   )]
      public short gxTpr_Produtoid
      {
         get {
            return gxTv_SdtProduto_Produtoid ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            if ( gxTv_SdtProduto_Produtoid != value )
            {
               gxTv_SdtProduto_Mode = "INS";
               this.gxTv_SdtProduto_Produtoid_Z_SetNull( );
               this.gxTv_SdtProduto_Produtonome_Z_SetNull( );
               this.gxTv_SdtProduto_Produtodescricao_Z_SetNull( );
               this.gxTv_SdtProduto_Produtopreco_Z_SetNull( );
               this.gxTv_SdtProduto_Vendedorprodutoid_Z_SetNull( );
               this.gxTv_SdtProduto_Vendedorprodutonome_Z_SetNull( );
               this.gxTv_SdtProduto_Paisprodutoid_Z_SetNull( );
               this.gxTv_SdtProduto_Paisprodutonome_Z_SetNull( );
               this.gxTv_SdtProduto_Fornecedorprodutoid_Z_SetNull( );
               this.gxTv_SdtProduto_Fornecedorprodutonome_Z_SetNull( );
               this.gxTv_SdtProduto_Categoriaprodutoid_Z_SetNull( );
               this.gxTv_SdtProduto_Categoriaprodutonome_Z_SetNull( );
               this.gxTv_SdtProduto_Produtoimagem_gxi_Z_SetNull( );
               this.gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z_SetNull( );
            }
            gxTv_SdtProduto_Produtoid = value;
            SetDirty("Produtoid");
         }

      }

      [  SoapElement( ElementName = "ProdutoNome" )]
      [  XmlElement( ElementName = "ProdutoNome"   )]
      public string gxTpr_Produtonome
      {
         get {
            return gxTv_SdtProduto_Produtonome ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtonome = value;
            SetDirty("Produtonome");
         }

      }

      [  SoapElement( ElementName = "ProdutoDescricao" )]
      [  XmlElement( ElementName = "ProdutoDescricao"   )]
      public string gxTpr_Produtodescricao
      {
         get {
            return gxTv_SdtProduto_Produtodescricao ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtodescricao = value;
            SetDirty("Produtodescricao");
         }

      }

      [  SoapElement( ElementName = "ProdutoPreco" )]
      [  XmlElement( ElementName = "ProdutoPreco"   )]
      public decimal gxTpr_Produtopreco
      {
         get {
            return gxTv_SdtProduto_Produtopreco ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtopreco = value;
            SetDirty("Produtopreco");
         }

      }

      [  SoapElement( ElementName = "ProdutoImagem" )]
      [  XmlElement( ElementName = "ProdutoImagem"   )]
      [GxUpload()]
      public string gxTpr_Produtoimagem
      {
         get {
            return gxTv_SdtProduto_Produtoimagem ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtoimagem = value;
            SetDirty("Produtoimagem");
         }

      }

      [  SoapElement( ElementName = "ProdutoImagem_GXI" )]
      [  XmlElement( ElementName = "ProdutoImagem_GXI"   )]
      public string gxTpr_Produtoimagem_gxi
      {
         get {
            return gxTv_SdtProduto_Produtoimagem_gxi ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtoimagem_gxi = value;
            SetDirty("Produtoimagem_gxi");
         }

      }

      [  SoapElement( ElementName = "VendedorProdutoId" )]
      [  XmlElement( ElementName = "VendedorProdutoId"   )]
      public short gxTpr_Vendedorprodutoid
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutoid ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoid = value;
            SetDirty("Vendedorprodutoid");
         }

      }

      [  SoapElement( ElementName = "VendedorProdutoNome" )]
      [  XmlElement( ElementName = "VendedorProdutoNome"   )]
      public string gxTpr_Vendedorprodutonome
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutonome ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutonome = value;
            SetDirty("Vendedorprodutonome");
         }

      }

      [  SoapElement( ElementName = "VendedorProdutoImagem" )]
      [  XmlElement( ElementName = "VendedorProdutoImagem"   )]
      [GxUpload()]
      public string gxTpr_Vendedorprodutoimagem
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutoimagem ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoimagem = value;
            SetDirty("Vendedorprodutoimagem");
         }

      }

      [  SoapElement( ElementName = "VendedorProdutoImagem_GXI" )]
      [  XmlElement( ElementName = "VendedorProdutoImagem_GXI"   )]
      public string gxTpr_Vendedorprodutoimagem_gxi
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutoimagem_gxi ;
         }

         set {
            gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N = 0;
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoimagem_gxi = value;
            SetDirty("Vendedorprodutoimagem_gxi");
         }

      }

      public void gxTv_SdtProduto_Vendedorprodutoimagem_gxi_SetNull( )
      {
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N = 1;
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi = "";
         SetDirty("Vendedorprodutoimagem_gxi");
         return  ;
      }

      public bool gxTv_SdtProduto_Vendedorprodutoimagem_gxi_IsNull( )
      {
         return (gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N==1) ;
      }

      [  SoapElement( ElementName = "PaisProdutoId" )]
      [  XmlElement( ElementName = "PaisProdutoId"   )]
      public short gxTpr_Paisprodutoid
      {
         get {
            return gxTv_SdtProduto_Paisprodutoid ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Paisprodutoid = value;
            SetDirty("Paisprodutoid");
         }

      }

      [  SoapElement( ElementName = "PaisProdutoNome" )]
      [  XmlElement( ElementName = "PaisProdutoNome"   )]
      public string gxTpr_Paisprodutonome
      {
         get {
            return gxTv_SdtProduto_Paisprodutonome ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Paisprodutonome = value;
            SetDirty("Paisprodutonome");
         }

      }

      [  SoapElement( ElementName = "FornecedorProdutoId" )]
      [  XmlElement( ElementName = "FornecedorProdutoId"   )]
      public short gxTpr_Fornecedorprodutoid
      {
         get {
            return gxTv_SdtProduto_Fornecedorprodutoid ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Fornecedorprodutoid = value;
            SetDirty("Fornecedorprodutoid");
         }

      }

      [  SoapElement( ElementName = "FornecedorProdutoNome" )]
      [  XmlElement( ElementName = "FornecedorProdutoNome"   )]
      public string gxTpr_Fornecedorprodutonome
      {
         get {
            return gxTv_SdtProduto_Fornecedorprodutonome ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Fornecedorprodutonome = value;
            SetDirty("Fornecedorprodutonome");
         }

      }

      [  SoapElement( ElementName = "CategoriaProdutoId" )]
      [  XmlElement( ElementName = "CategoriaProdutoId"   )]
      public short gxTpr_Categoriaprodutoid
      {
         get {
            return gxTv_SdtProduto_Categoriaprodutoid ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Categoriaprodutoid = value;
            SetDirty("Categoriaprodutoid");
         }

      }

      [  SoapElement( ElementName = "CategoriaProdutoNome" )]
      [  XmlElement( ElementName = "CategoriaProdutoNome"   )]
      public string gxTpr_Categoriaprodutonome
      {
         get {
            return gxTv_SdtProduto_Categoriaprodutonome ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Categoriaprodutonome = value;
            SetDirty("Categoriaprodutonome");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtProduto_Mode ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtProduto_Mode_SetNull( )
      {
         gxTv_SdtProduto_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtProduto_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtProduto_Initialized ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtProduto_Initialized_SetNull( )
      {
         gxTv_SdtProduto_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtProduto_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoId_Z" )]
      [  XmlElement( ElementName = "ProdutoId_Z"   )]
      public short gxTpr_Produtoid_Z
      {
         get {
            return gxTv_SdtProduto_Produtoid_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtoid_Z = value;
            SetDirty("Produtoid_Z");
         }

      }

      public void gxTv_SdtProduto_Produtoid_Z_SetNull( )
      {
         gxTv_SdtProduto_Produtoid_Z = 0;
         SetDirty("Produtoid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Produtoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoNome_Z" )]
      [  XmlElement( ElementName = "ProdutoNome_Z"   )]
      public string gxTpr_Produtonome_Z
      {
         get {
            return gxTv_SdtProduto_Produtonome_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtonome_Z = value;
            SetDirty("Produtonome_Z");
         }

      }

      public void gxTv_SdtProduto_Produtonome_Z_SetNull( )
      {
         gxTv_SdtProduto_Produtonome_Z = "";
         SetDirty("Produtonome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Produtonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoDescricao_Z" )]
      [  XmlElement( ElementName = "ProdutoDescricao_Z"   )]
      public string gxTpr_Produtodescricao_Z
      {
         get {
            return gxTv_SdtProduto_Produtodescricao_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtodescricao_Z = value;
            SetDirty("Produtodescricao_Z");
         }

      }

      public void gxTv_SdtProduto_Produtodescricao_Z_SetNull( )
      {
         gxTv_SdtProduto_Produtodescricao_Z = "";
         SetDirty("Produtodescricao_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Produtodescricao_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoPreco_Z" )]
      [  XmlElement( ElementName = "ProdutoPreco_Z"   )]
      public decimal gxTpr_Produtopreco_Z
      {
         get {
            return gxTv_SdtProduto_Produtopreco_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtopreco_Z = value;
            SetDirty("Produtopreco_Z");
         }

      }

      public void gxTv_SdtProduto_Produtopreco_Z_SetNull( )
      {
         gxTv_SdtProduto_Produtopreco_Z = 0;
         SetDirty("Produtopreco_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Produtopreco_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VendedorProdutoId_Z" )]
      [  XmlElement( ElementName = "VendedorProdutoId_Z"   )]
      public short gxTpr_Vendedorprodutoid_Z
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutoid_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoid_Z = value;
            SetDirty("Vendedorprodutoid_Z");
         }

      }

      public void gxTv_SdtProduto_Vendedorprodutoid_Z_SetNull( )
      {
         gxTv_SdtProduto_Vendedorprodutoid_Z = 0;
         SetDirty("Vendedorprodutoid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Vendedorprodutoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VendedorProdutoNome_Z" )]
      [  XmlElement( ElementName = "VendedorProdutoNome_Z"   )]
      public string gxTpr_Vendedorprodutonome_Z
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutonome_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutonome_Z = value;
            SetDirty("Vendedorprodutonome_Z");
         }

      }

      public void gxTv_SdtProduto_Vendedorprodutonome_Z_SetNull( )
      {
         gxTv_SdtProduto_Vendedorprodutonome_Z = "";
         SetDirty("Vendedorprodutonome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Vendedorprodutonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisProdutoId_Z" )]
      [  XmlElement( ElementName = "PaisProdutoId_Z"   )]
      public short gxTpr_Paisprodutoid_Z
      {
         get {
            return gxTv_SdtProduto_Paisprodutoid_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Paisprodutoid_Z = value;
            SetDirty("Paisprodutoid_Z");
         }

      }

      public void gxTv_SdtProduto_Paisprodutoid_Z_SetNull( )
      {
         gxTv_SdtProduto_Paisprodutoid_Z = 0;
         SetDirty("Paisprodutoid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Paisprodutoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisProdutoNome_Z" )]
      [  XmlElement( ElementName = "PaisProdutoNome_Z"   )]
      public string gxTpr_Paisprodutonome_Z
      {
         get {
            return gxTv_SdtProduto_Paisprodutonome_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Paisprodutonome_Z = value;
            SetDirty("Paisprodutonome_Z");
         }

      }

      public void gxTv_SdtProduto_Paisprodutonome_Z_SetNull( )
      {
         gxTv_SdtProduto_Paisprodutonome_Z = "";
         SetDirty("Paisprodutonome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Paisprodutonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FornecedorProdutoId_Z" )]
      [  XmlElement( ElementName = "FornecedorProdutoId_Z"   )]
      public short gxTpr_Fornecedorprodutoid_Z
      {
         get {
            return gxTv_SdtProduto_Fornecedorprodutoid_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Fornecedorprodutoid_Z = value;
            SetDirty("Fornecedorprodutoid_Z");
         }

      }

      public void gxTv_SdtProduto_Fornecedorprodutoid_Z_SetNull( )
      {
         gxTv_SdtProduto_Fornecedorprodutoid_Z = 0;
         SetDirty("Fornecedorprodutoid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Fornecedorprodutoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "FornecedorProdutoNome_Z" )]
      [  XmlElement( ElementName = "FornecedorProdutoNome_Z"   )]
      public string gxTpr_Fornecedorprodutonome_Z
      {
         get {
            return gxTv_SdtProduto_Fornecedorprodutonome_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Fornecedorprodutonome_Z = value;
            SetDirty("Fornecedorprodutonome_Z");
         }

      }

      public void gxTv_SdtProduto_Fornecedorprodutonome_Z_SetNull( )
      {
         gxTv_SdtProduto_Fornecedorprodutonome_Z = "";
         SetDirty("Fornecedorprodutonome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Fornecedorprodutonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaProdutoId_Z" )]
      [  XmlElement( ElementName = "CategoriaProdutoId_Z"   )]
      public short gxTpr_Categoriaprodutoid_Z
      {
         get {
            return gxTv_SdtProduto_Categoriaprodutoid_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Categoriaprodutoid_Z = value;
            SetDirty("Categoriaprodutoid_Z");
         }

      }

      public void gxTv_SdtProduto_Categoriaprodutoid_Z_SetNull( )
      {
         gxTv_SdtProduto_Categoriaprodutoid_Z = 0;
         SetDirty("Categoriaprodutoid_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Categoriaprodutoid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaProdutoNome_Z" )]
      [  XmlElement( ElementName = "CategoriaProdutoNome_Z"   )]
      public string gxTpr_Categoriaprodutonome_Z
      {
         get {
            return gxTv_SdtProduto_Categoriaprodutonome_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Categoriaprodutonome_Z = value;
            SetDirty("Categoriaprodutonome_Z");
         }

      }

      public void gxTv_SdtProduto_Categoriaprodutonome_Z_SetNull( )
      {
         gxTv_SdtProduto_Categoriaprodutonome_Z = "";
         SetDirty("Categoriaprodutonome_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Categoriaprodutonome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "ProdutoImagem_GXI_Z" )]
      [  XmlElement( ElementName = "ProdutoImagem_GXI_Z"   )]
      public string gxTpr_Produtoimagem_gxi_Z
      {
         get {
            return gxTv_SdtProduto_Produtoimagem_gxi_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Produtoimagem_gxi_Z = value;
            SetDirty("Produtoimagem_gxi_Z");
         }

      }

      public void gxTv_SdtProduto_Produtoimagem_gxi_Z_SetNull( )
      {
         gxTv_SdtProduto_Produtoimagem_gxi_Z = "";
         SetDirty("Produtoimagem_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Produtoimagem_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VendedorProdutoImagem_GXI_Z" )]
      [  XmlElement( ElementName = "VendedorProdutoImagem_GXI_Z"   )]
      public string gxTpr_Vendedorprodutoimagem_gxi_Z
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z = value;
            SetDirty("Vendedorprodutoimagem_gxi_Z");
         }

      }

      public void gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z_SetNull( )
      {
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z = "";
         SetDirty("Vendedorprodutoimagem_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "VendedorProdutoImagem_GXI_N" )]
      [  XmlElement( ElementName = "VendedorProdutoImagem_GXI_N"   )]
      public short gxTpr_Vendedorprodutoimagem_gxi_N
      {
         get {
            return gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N ;
         }

         set {
            gxTv_SdtProduto_N = 0;
            gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N = value;
            SetDirty("Vendedorprodutoimagem_gxi_N");
         }

      }

      public void gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N_SetNull( )
      {
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N = 0;
         SetDirty("Vendedorprodutoimagem_gxi_N");
         return  ;
      }

      public bool gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtProduto_N = 1;
         gxTv_SdtProduto_Produtonome = "";
         gxTv_SdtProduto_Produtodescricao = "";
         gxTv_SdtProduto_Produtoimagem = "";
         gxTv_SdtProduto_Produtoimagem_gxi = "";
         gxTv_SdtProduto_Vendedorprodutonome = "";
         gxTv_SdtProduto_Vendedorprodutoimagem = "";
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi = "";
         gxTv_SdtProduto_Paisprodutonome = "";
         gxTv_SdtProduto_Fornecedorprodutonome = "";
         gxTv_SdtProduto_Categoriaprodutonome = "";
         gxTv_SdtProduto_Mode = "";
         gxTv_SdtProduto_Produtonome_Z = "";
         gxTv_SdtProduto_Produtodescricao_Z = "";
         gxTv_SdtProduto_Vendedorprodutonome_Z = "";
         gxTv_SdtProduto_Paisprodutonome_Z = "";
         gxTv_SdtProduto_Fornecedorprodutonome_Z = "";
         gxTv_SdtProduto_Categoriaprodutonome_Z = "";
         gxTv_SdtProduto_Produtoimagem_gxi_Z = "";
         gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "produto", "GeneXus.Programs.produto_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtProduto_N ;
      }

      private short gxTv_SdtProduto_Produtoid ;
      private short gxTv_SdtProduto_N ;
      private short gxTv_SdtProduto_Vendedorprodutoid ;
      private short gxTv_SdtProduto_Paisprodutoid ;
      private short gxTv_SdtProduto_Fornecedorprodutoid ;
      private short gxTv_SdtProduto_Categoriaprodutoid ;
      private short gxTv_SdtProduto_Initialized ;
      private short gxTv_SdtProduto_Produtoid_Z ;
      private short gxTv_SdtProduto_Vendedorprodutoid_Z ;
      private short gxTv_SdtProduto_Paisprodutoid_Z ;
      private short gxTv_SdtProduto_Fornecedorprodutoid_Z ;
      private short gxTv_SdtProduto_Categoriaprodutoid_Z ;
      private short gxTv_SdtProduto_Vendedorprodutoimagem_gxi_N ;
      private decimal gxTv_SdtProduto_Produtopreco ;
      private decimal gxTv_SdtProduto_Produtopreco_Z ;
      private string gxTv_SdtProduto_Mode ;
      private string gxTv_SdtProduto_Produtonome ;
      private string gxTv_SdtProduto_Produtodescricao ;
      private string gxTv_SdtProduto_Produtoimagem_gxi ;
      private string gxTv_SdtProduto_Vendedorprodutonome ;
      private string gxTv_SdtProduto_Vendedorprodutoimagem_gxi ;
      private string gxTv_SdtProduto_Paisprodutonome ;
      private string gxTv_SdtProduto_Fornecedorprodutonome ;
      private string gxTv_SdtProduto_Categoriaprodutonome ;
      private string gxTv_SdtProduto_Produtonome_Z ;
      private string gxTv_SdtProduto_Produtodescricao_Z ;
      private string gxTv_SdtProduto_Vendedorprodutonome_Z ;
      private string gxTv_SdtProduto_Paisprodutonome_Z ;
      private string gxTv_SdtProduto_Fornecedorprodutonome_Z ;
      private string gxTv_SdtProduto_Categoriaprodutonome_Z ;
      private string gxTv_SdtProduto_Produtoimagem_gxi_Z ;
      private string gxTv_SdtProduto_Vendedorprodutoimagem_gxi_Z ;
      private string gxTv_SdtProduto_Produtoimagem ;
      private string gxTv_SdtProduto_Vendedorprodutoimagem ;
   }

   [DataContract(Name = @"Produto", Namespace = "LojaAnnaLaisa1")]
   public class SdtProduto_RESTInterface : GxGenericCollectionItem<SdtProduto>
   {
      public SdtProduto_RESTInterface( ) : base()
      {
      }

      public SdtProduto_RESTInterface( SdtProduto psdt ) : base(psdt)
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

      [DataMember( Name = "ProdutoDescricao" , Order = 2 )]
      [GxSeudo()]
      public string gxTpr_Produtodescricao
      {
         get {
            return sdt.gxTpr_Produtodescricao ;
         }

         set {
            sdt.gxTpr_Produtodescricao = value;
         }

      }

      [DataMember( Name = "ProdutoPreco" , Order = 3 )]
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

      [DataMember( Name = "ProdutoImagem" , Order = 4 )]
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

      [DataMember( Name = "VendedorProdutoId" , Order = 5 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Vendedorprodutoid
      {
         get {
            return sdt.gxTpr_Vendedorprodutoid ;
         }

         set {
            sdt.gxTpr_Vendedorprodutoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "VendedorProdutoNome" , Order = 6 )]
      [GxSeudo()]
      public string gxTpr_Vendedorprodutonome
      {
         get {
            return sdt.gxTpr_Vendedorprodutonome ;
         }

         set {
            sdt.gxTpr_Vendedorprodutonome = value;
         }

      }

      [DataMember( Name = "VendedorProdutoImagem" , Order = 7 )]
      [GxUpload()]
      public string gxTpr_Vendedorprodutoimagem
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Vendedorprodutoimagem)) ? PathUtil.RelativeURL( sdt.gxTpr_Vendedorprodutoimagem) : StringUtil.RTrim( sdt.gxTpr_Vendedorprodutoimagem_gxi)) ;
         }

         set {
            sdt.gxTpr_Vendedorprodutoimagem = value;
         }

      }

      [DataMember( Name = "PaisProdutoId" , Order = 8 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Paisprodutoid
      {
         get {
            return sdt.gxTpr_Paisprodutoid ;
         }

         set {
            sdt.gxTpr_Paisprodutoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisProdutoNome" , Order = 9 )]
      [GxSeudo()]
      public string gxTpr_Paisprodutonome
      {
         get {
            return sdt.gxTpr_Paisprodutonome ;
         }

         set {
            sdt.gxTpr_Paisprodutonome = value;
         }

      }

      [DataMember( Name = "FornecedorProdutoId" , Order = 10 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Fornecedorprodutoid
      {
         get {
            return sdt.gxTpr_Fornecedorprodutoid ;
         }

         set {
            sdt.gxTpr_Fornecedorprodutoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "FornecedorProdutoNome" , Order = 11 )]
      [GxSeudo()]
      public string gxTpr_Fornecedorprodutonome
      {
         get {
            return sdt.gxTpr_Fornecedorprodutonome ;
         }

         set {
            sdt.gxTpr_Fornecedorprodutonome = value;
         }

      }

      [DataMember( Name = "CategoriaProdutoId" , Order = 12 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Categoriaprodutoid
      {
         get {
            return sdt.gxTpr_Categoriaprodutoid ;
         }

         set {
            sdt.gxTpr_Categoriaprodutoid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CategoriaProdutoNome" , Order = 13 )]
      [GxSeudo()]
      public string gxTpr_Categoriaprodutonome
      {
         get {
            return sdt.gxTpr_Categoriaprodutonome ;
         }

         set {
            sdt.gxTpr_Categoriaprodutonome = value;
         }

      }

      public SdtProduto sdt
      {
         get {
            return (SdtProduto)Sdt ;
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
            sdt = new SdtProduto() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 14 )]
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

   [DataContract(Name = @"Produto", Namespace = "LojaAnnaLaisa1")]
   public class SdtProduto_RESTLInterface : GxGenericCollectionItem<SdtProduto>
   {
      public SdtProduto_RESTLInterface( ) : base()
      {
      }

      public SdtProduto_RESTLInterface( SdtProduto psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "ProdutoNome" , Order = 0 )]
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

      [DataMember( Name = "uri", Order = 1 )]
      public string Uri
      {
         get {
            return "" ;
         }

         set {
         }

      }

      public SdtProduto sdt
      {
         get {
            return (SdtProduto)Sdt ;
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
            sdt = new SdtProduto() ;
         }
      }

   }

}
