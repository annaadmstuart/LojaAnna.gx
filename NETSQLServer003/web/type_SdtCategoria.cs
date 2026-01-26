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
   [XmlRoot(ElementName = "Categoria" )]
   [XmlType(TypeName =  "Categoria" , Namespace = "LojaAnnaLaisa1" )]
   [Serializable]
   public class SdtCategoria : GxSilentTrnSdt
   {
      public SdtCategoria( )
      {
      }

      public SdtCategoria( IGxContext context )
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

      public void Load( short AV4CategoriaId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV4CategoriaId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"CategoriaId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Categoria");
         metadata.Set("BT", "Categoria");
         metadata.Set("PK", "[ \"CategoriaId\" ]");
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
         state.Add("gxTpr_Categoriaid_Z");
         state.Add("gxTpr_Categorianome_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtCategoria sdt;
         sdt = (SdtCategoria)(source);
         gxTv_SdtCategoria_Categoriaid = sdt.gxTv_SdtCategoria_Categoriaid ;
         gxTv_SdtCategoria_Categorianome = sdt.gxTv_SdtCategoria_Categorianome ;
         gxTv_SdtCategoria_Mode = sdt.gxTv_SdtCategoria_Mode ;
         gxTv_SdtCategoria_Initialized = sdt.gxTv_SdtCategoria_Initialized ;
         gxTv_SdtCategoria_Categoriaid_Z = sdt.gxTv_SdtCategoria_Categoriaid_Z ;
         gxTv_SdtCategoria_Categorianome_Z = sdt.gxTv_SdtCategoria_Categorianome_Z ;
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
         AddObjectProperty("CategoriaId", gxTv_SdtCategoria_Categoriaid, false, includeNonInitialized);
         AddObjectProperty("CategoriaNome", gxTv_SdtCategoria_Categorianome, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("Mode", gxTv_SdtCategoria_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtCategoria_Initialized, false, includeNonInitialized);
            AddObjectProperty("CategoriaId_Z", gxTv_SdtCategoria_Categoriaid_Z, false, includeNonInitialized);
            AddObjectProperty("CategoriaNome_Z", gxTv_SdtCategoria_Categorianome_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtCategoria sdt )
      {
         if ( sdt.IsDirty("CategoriaId") )
         {
            gxTv_SdtCategoria_N = 0;
            gxTv_SdtCategoria_Categoriaid = sdt.gxTv_SdtCategoria_Categoriaid ;
         }
         if ( sdt.IsDirty("CategoriaNome") )
         {
            gxTv_SdtCategoria_N = 0;
            gxTv_SdtCategoria_Categorianome = sdt.gxTv_SdtCategoria_Categorianome ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "CategoriaId" )]
      [  XmlElement( ElementName = "CategoriaId"   )]
      public short gxTpr_Categoriaid
      {
         get {
            return gxTv_SdtCategoria_Categoriaid ;
         }

         set {
            gxTv_SdtCategoria_N = 0;
            if ( gxTv_SdtCategoria_Categoriaid != value )
            {
               gxTv_SdtCategoria_Mode = "INS";
               this.gxTv_SdtCategoria_Categoriaid_Z_SetNull( );
               this.gxTv_SdtCategoria_Categorianome_Z_SetNull( );
            }
            gxTv_SdtCategoria_Categoriaid = value;
            SetDirty("Categoriaid");
         }

      }

      [  SoapElement( ElementName = "CategoriaNome" )]
      [  XmlElement( ElementName = "CategoriaNome"   )]
      public string gxTpr_Categorianome
      {
         get {
            return gxTv_SdtCategoria_Categorianome ;
         }

         set {
            gxTv_SdtCategoria_N = 0;
            gxTv_SdtCategoria_Categorianome = value;
            SetDirty("Categorianome");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtCategoria_Mode ;
         }

         set {
            gxTv_SdtCategoria_N = 0;
            gxTv_SdtCategoria_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtCategoria_Mode_SetNull( )
      {
         gxTv_SdtCategoria_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtCategoria_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtCategoria_Initialized ;
         }

         set {
            gxTv_SdtCategoria_N = 0;
            gxTv_SdtCategoria_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtCategoria_Initialized_SetNull( )
      {
         gxTv_SdtCategoria_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtCategoria_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaId_Z" )]
      [  XmlElement( ElementName = "CategoriaId_Z"   )]
      public short gxTpr_Categoriaid_Z
      {
         get {
            return gxTv_SdtCategoria_Categoriaid_Z ;
         }

         set {
            gxTv_SdtCategoria_N = 0;
            gxTv_SdtCategoria_Categoriaid_Z = value;
            SetDirty("Categoriaid_Z");
         }

      }

      public void gxTv_SdtCategoria_Categoriaid_Z_SetNull( )
      {
         gxTv_SdtCategoria_Categoriaid_Z = 0;
         SetDirty("Categoriaid_Z");
         return  ;
      }

      public bool gxTv_SdtCategoria_Categoriaid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "CategoriaNome_Z" )]
      [  XmlElement( ElementName = "CategoriaNome_Z"   )]
      public string gxTpr_Categorianome_Z
      {
         get {
            return gxTv_SdtCategoria_Categorianome_Z ;
         }

         set {
            gxTv_SdtCategoria_N = 0;
            gxTv_SdtCategoria_Categorianome_Z = value;
            SetDirty("Categorianome_Z");
         }

      }

      public void gxTv_SdtCategoria_Categorianome_Z_SetNull( )
      {
         gxTv_SdtCategoria_Categorianome_Z = "";
         SetDirty("Categorianome_Z");
         return  ;
      }

      public bool gxTv_SdtCategoria_Categorianome_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtCategoria_N = 1;
         gxTv_SdtCategoria_Categorianome = "";
         gxTv_SdtCategoria_Mode = "";
         gxTv_SdtCategoria_Categorianome_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "categoria", "GeneXus.Programs.categoria_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtCategoria_N ;
      }

      private short gxTv_SdtCategoria_Categoriaid ;
      private short gxTv_SdtCategoria_N ;
      private short gxTv_SdtCategoria_Initialized ;
      private short gxTv_SdtCategoria_Categoriaid_Z ;
      private string gxTv_SdtCategoria_Mode ;
      private string gxTv_SdtCategoria_Categorianome ;
      private string gxTv_SdtCategoria_Categorianome_Z ;
   }

   [DataContract(Name = @"Categoria", Namespace = "LojaAnnaLaisa1")]
   public class SdtCategoria_RESTInterface : GxGenericCollectionItem<SdtCategoria>
   {
      public SdtCategoria_RESTInterface( ) : base()
      {
      }

      public SdtCategoria_RESTInterface( SdtCategoria psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CategoriaId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Categoriaid
      {
         get {
            return sdt.gxTpr_Categoriaid ;
         }

         set {
            sdt.gxTpr_Categoriaid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "CategoriaNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Categorianome
      {
         get {
            return sdt.gxTpr_Categorianome ;
         }

         set {
            sdt.gxTpr_Categorianome = value;
         }

      }

      public SdtCategoria sdt
      {
         get {
            return (SdtCategoria)Sdt ;
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
            sdt = new SdtCategoria() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 2 )]
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

   [DataContract(Name = @"Categoria", Namespace = "LojaAnnaLaisa1")]
   public class SdtCategoria_RESTLInterface : GxGenericCollectionItem<SdtCategoria>
   {
      public SdtCategoria_RESTLInterface( ) : base()
      {
      }

      public SdtCategoria_RESTLInterface( SdtCategoria psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "CategoriaNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Categorianome
      {
         get {
            return sdt.gxTpr_Categorianome ;
         }

         set {
            sdt.gxTpr_Categorianome = value;
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

      public SdtCategoria sdt
      {
         get {
            return (SdtCategoria)Sdt ;
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
            sdt = new SdtCategoria() ;
         }
      }

   }

}
