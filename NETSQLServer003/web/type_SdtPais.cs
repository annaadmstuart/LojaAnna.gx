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
   [XmlRoot(ElementName = "Pais" )]
   [XmlType(TypeName =  "Pais" , Namespace = "LojaAnnaLaisa1" )]
   [Serializable]
   public class SdtPais : GxSilentTrnSdt
   {
      public SdtPais( )
      {
      }

      public SdtPais( IGxContext context )
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

      public void Load( short AV1PaisId )
      {
         IGxSilentTrn obj;
         obj = getTransaction();
         obj.LoadKey(new Object[] {(short)AV1PaisId});
         return  ;
      }

      public override Object[][] GetBCKey( )
      {
         return (Object[][])(new Object[][]{new Object[]{"PaisId", typeof(short)}}) ;
      }

      public override GXProperties GetMetadata( )
      {
         GXProperties metadata = new GXProperties();
         metadata.Set("Name", "Pais");
         metadata.Set("BT", "Pais");
         metadata.Set("PK", "[ \"PaisId\" ]");
         metadata.Set("AllowInsert", "True");
         metadata.Set("AllowUpdate", "True");
         metadata.Set("AllowDelete", "True");
         return metadata ;
      }

      public override GeneXus.Utils.GxStringCollection StateAttributes( )
      {
         GeneXus.Utils.GxStringCollection state = new GeneXus.Utils.GxStringCollection();
         state.Add("gxTpr_Paisbandeira_gxi");
         state.Add("gxTpr_Mode");
         state.Add("gxTpr_Initialized");
         state.Add("gxTpr_Paisid_Z");
         state.Add("gxTpr_Paisnome_Z");
         state.Add("gxTpr_Paisbandeira_gxi_Z");
         return state ;
      }

      public override void Copy( GxUserType source )
      {
         SdtPais sdt;
         sdt = (SdtPais)(source);
         gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         gxTv_SdtPais_Paisnome = sdt.gxTv_SdtPais_Paisnome ;
         gxTv_SdtPais_Paisbandeira = sdt.gxTv_SdtPais_Paisbandeira ;
         gxTv_SdtPais_Paisbandeira_gxi = sdt.gxTv_SdtPais_Paisbandeira_gxi ;
         gxTv_SdtPais_Mode = sdt.gxTv_SdtPais_Mode ;
         gxTv_SdtPais_Initialized = sdt.gxTv_SdtPais_Initialized ;
         gxTv_SdtPais_Paisid_Z = sdt.gxTv_SdtPais_Paisid_Z ;
         gxTv_SdtPais_Paisnome_Z = sdt.gxTv_SdtPais_Paisnome_Z ;
         gxTv_SdtPais_Paisbandeira_gxi_Z = sdt.gxTv_SdtPais_Paisbandeira_gxi_Z ;
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
         AddObjectProperty("PaisId", gxTv_SdtPais_Paisid, false, includeNonInitialized);
         AddObjectProperty("PaisNome", gxTv_SdtPais_Paisnome, false, includeNonInitialized);
         AddObjectProperty("PaisBandeira", gxTv_SdtPais_Paisbandeira, false, includeNonInitialized);
         if ( includeState )
         {
            AddObjectProperty("PaisBandeira_GXI", gxTv_SdtPais_Paisbandeira_gxi, false, includeNonInitialized);
            AddObjectProperty("Mode", gxTv_SdtPais_Mode, false, includeNonInitialized);
            AddObjectProperty("Initialized", gxTv_SdtPais_Initialized, false, includeNonInitialized);
            AddObjectProperty("PaisId_Z", gxTv_SdtPais_Paisid_Z, false, includeNonInitialized);
            AddObjectProperty("PaisNome_Z", gxTv_SdtPais_Paisnome_Z, false, includeNonInitialized);
            AddObjectProperty("PaisBandeira_GXI_Z", gxTv_SdtPais_Paisbandeira_gxi_Z, false, includeNonInitialized);
         }
         return  ;
      }

      public void UpdateDirties( SdtPais sdt )
      {
         if ( sdt.IsDirty("PaisId") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisid = sdt.gxTv_SdtPais_Paisid ;
         }
         if ( sdt.IsDirty("PaisNome") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisnome = sdt.gxTv_SdtPais_Paisnome ;
         }
         if ( sdt.IsDirty("PaisBandeira") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisbandeira = sdt.gxTv_SdtPais_Paisbandeira ;
         }
         if ( sdt.IsDirty("PaisBandeira") )
         {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisbandeira_gxi = sdt.gxTv_SdtPais_Paisbandeira_gxi ;
         }
         return  ;
      }

      [  SoapElement( ElementName = "PaisId" )]
      [  XmlElement( ElementName = "PaisId"   )]
      public short gxTpr_Paisid
      {
         get {
            return gxTv_SdtPais_Paisid ;
         }

         set {
            gxTv_SdtPais_N = 0;
            if ( gxTv_SdtPais_Paisid != value )
            {
               gxTv_SdtPais_Mode = "INS";
               this.gxTv_SdtPais_Paisid_Z_SetNull( );
               this.gxTv_SdtPais_Paisnome_Z_SetNull( );
               this.gxTv_SdtPais_Paisbandeira_gxi_Z_SetNull( );
            }
            gxTv_SdtPais_Paisid = value;
            SetDirty("Paisid");
         }

      }

      [  SoapElement( ElementName = "PaisNome" )]
      [  XmlElement( ElementName = "PaisNome"   )]
      public string gxTpr_Paisnome
      {
         get {
            return gxTv_SdtPais_Paisnome ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisnome = value;
            SetDirty("Paisnome");
         }

      }

      [  SoapElement( ElementName = "PaisBandeira" )]
      [  XmlElement( ElementName = "PaisBandeira"   )]
      [GxUpload()]
      public string gxTpr_Paisbandeira
      {
         get {
            return gxTv_SdtPais_Paisbandeira ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisbandeira = value;
            SetDirty("Paisbandeira");
         }

      }

      [  SoapElement( ElementName = "PaisBandeira_GXI" )]
      [  XmlElement( ElementName = "PaisBandeira_GXI"   )]
      public string gxTpr_Paisbandeira_gxi
      {
         get {
            return gxTv_SdtPais_Paisbandeira_gxi ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisbandeira_gxi = value;
            SetDirty("Paisbandeira_gxi");
         }

      }

      [  SoapElement( ElementName = "Mode" )]
      [  XmlElement( ElementName = "Mode"   )]
      public string gxTpr_Mode
      {
         get {
            return gxTv_SdtPais_Mode ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Mode = value;
            SetDirty("Mode");
         }

      }

      public void gxTv_SdtPais_Mode_SetNull( )
      {
         gxTv_SdtPais_Mode = "";
         SetDirty("Mode");
         return  ;
      }

      public bool gxTv_SdtPais_Mode_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "Initialized" )]
      [  XmlElement( ElementName = "Initialized"   )]
      public short gxTpr_Initialized
      {
         get {
            return gxTv_SdtPais_Initialized ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Initialized = value;
            SetDirty("Initialized");
         }

      }

      public void gxTv_SdtPais_Initialized_SetNull( )
      {
         gxTv_SdtPais_Initialized = 0;
         SetDirty("Initialized");
         return  ;
      }

      public bool gxTv_SdtPais_Initialized_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisId_Z" )]
      [  XmlElement( ElementName = "PaisId_Z"   )]
      public short gxTpr_Paisid_Z
      {
         get {
            return gxTv_SdtPais_Paisid_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisid_Z = value;
            SetDirty("Paisid_Z");
         }

      }

      public void gxTv_SdtPais_Paisid_Z_SetNull( )
      {
         gxTv_SdtPais_Paisid_Z = 0;
         SetDirty("Paisid_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisid_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisNome_Z" )]
      [  XmlElement( ElementName = "PaisNome_Z"   )]
      public string gxTpr_Paisnome_Z
      {
         get {
            return gxTv_SdtPais_Paisnome_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisnome_Z = value;
            SetDirty("Paisnome_Z");
         }

      }

      public void gxTv_SdtPais_Paisnome_Z_SetNull( )
      {
         gxTv_SdtPais_Paisnome_Z = "";
         SetDirty("Paisnome_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisnome_Z_IsNull( )
      {
         return false ;
      }

      [  SoapElement( ElementName = "PaisBandeira_GXI_Z" )]
      [  XmlElement( ElementName = "PaisBandeira_GXI_Z"   )]
      public string gxTpr_Paisbandeira_gxi_Z
      {
         get {
            return gxTv_SdtPais_Paisbandeira_gxi_Z ;
         }

         set {
            gxTv_SdtPais_N = 0;
            gxTv_SdtPais_Paisbandeira_gxi_Z = value;
            SetDirty("Paisbandeira_gxi_Z");
         }

      }

      public void gxTv_SdtPais_Paisbandeira_gxi_Z_SetNull( )
      {
         gxTv_SdtPais_Paisbandeira_gxi_Z = "";
         SetDirty("Paisbandeira_gxi_Z");
         return  ;
      }

      public bool gxTv_SdtPais_Paisbandeira_gxi_Z_IsNull( )
      {
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtPais_N = 1;
         gxTv_SdtPais_Paisnome = "";
         gxTv_SdtPais_Paisbandeira = "";
         gxTv_SdtPais_Paisbandeira_gxi = "";
         gxTv_SdtPais_Mode = "";
         gxTv_SdtPais_Paisnome_Z = "";
         gxTv_SdtPais_Paisbandeira_gxi_Z = "";
         IGxSilentTrn obj;
         obj = (IGxSilentTrn)ClassLoader.FindInstance( "pais", "GeneXus.Programs.pais_bc", new Object[] {context}, constructorCallingAssembly);;
         obj.initialize();
         obj.SetSDT(this, 1);
         setTransaction( obj) ;
         obj.SetMode("INS");
         return  ;
      }

      public short isNull( )
      {
         return gxTv_SdtPais_N ;
      }

      private short gxTv_SdtPais_Paisid ;
      private short gxTv_SdtPais_N ;
      private short gxTv_SdtPais_Initialized ;
      private short gxTv_SdtPais_Paisid_Z ;
      private string gxTv_SdtPais_Mode ;
      private string gxTv_SdtPais_Paisnome ;
      private string gxTv_SdtPais_Paisbandeira_gxi ;
      private string gxTv_SdtPais_Paisnome_Z ;
      private string gxTv_SdtPais_Paisbandeira_gxi_Z ;
      private string gxTv_SdtPais_Paisbandeira ;
   }

   [DataContract(Name = @"Pais", Namespace = "LojaAnnaLaisa1")]
   public class SdtPais_RESTInterface : GxGenericCollectionItem<SdtPais>
   {
      public SdtPais_RESTInterface( ) : base()
      {
      }

      public SdtPais_RESTInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisId" , Order = 0 )]
      [GxSeudo()]
      public Nullable<short> gxTpr_Paisid
      {
         get {
            return sdt.gxTpr_Paisid ;
         }

         set {
            sdt.gxTpr_Paisid = (short)(value.HasValue ? value.Value : 0);
         }

      }

      [DataMember( Name = "PaisNome" , Order = 1 )]
      [GxSeudo()]
      public string gxTpr_Paisnome
      {
         get {
            return sdt.gxTpr_Paisnome ;
         }

         set {
            sdt.gxTpr_Paisnome = value;
         }

      }

      [DataMember( Name = "PaisBandeira" , Order = 2 )]
      [GxUpload()]
      public string gxTpr_Paisbandeira
      {
         get {
            return (!String.IsNullOrEmpty(StringUtil.RTrim( sdt.gxTpr_Paisbandeira)) ? PathUtil.RelativeURL( sdt.gxTpr_Paisbandeira) : StringUtil.RTrim( sdt.gxTpr_Paisbandeira_gxi)) ;
         }

         set {
            sdt.gxTpr_Paisbandeira = value;
         }

      }

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
         }
      }

      [DataMember( Name = "gx_md5_hash", Order = 3 )]
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

   [DataContract(Name = @"Pais", Namespace = "LojaAnnaLaisa1")]
   public class SdtPais_RESTLInterface : GxGenericCollectionItem<SdtPais>
   {
      public SdtPais_RESTLInterface( ) : base()
      {
      }

      public SdtPais_RESTLInterface( SdtPais psdt ) : base(psdt)
      {
      }

      [DataMember( Name = "PaisNome" , Order = 0 )]
      [GxSeudo()]
      public string gxTpr_Paisnome
      {
         get {
            return sdt.gxTpr_Paisnome ;
         }

         set {
            sdt.gxTpr_Paisnome = value;
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

      public SdtPais sdt
      {
         get {
            return (SdtPais)Sdt ;
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
            sdt = new SdtPais() ;
         }
      }

   }

}
