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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class vendedor : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
         gxfirstwebparm_bkp = gxfirstwebparm;
         gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
         {
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            dyncall( GetNextPar( )) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A9PaisVendedorId = (short)(NumberUtil.Val( GetPar( "PaisVendedorId"), "."));
            AssignAttri("", false, "A9PaisVendedorId", StringUtil.LTrimStr( (decimal)(A9PaisVendedorId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A9PaisVendedorId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
         {
            setAjaxEventMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else
         {
            if ( ! IsValidAjaxCall( false) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = gxfirstwebparm_bkp;
         }
         if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
         {
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7VendedorId = (short)(NumberUtil.Val( GetPar( "VendedorId"), "."));
               AssignAttri("", false, "AV7VendedorId", StringUtil.LTrimStr( (decimal)(AV7VendedorId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vVENDEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VendedorId), "ZZZ9"), context));
            }
         }
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_web_controls( ) ;
         if ( toggleJsOutput )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_0-166471", 0) ;
            }
            Form.Meta.addItem("description", "Vendedor", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVendedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public vendedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public vendedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_VendedorId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VendedorId = aP1_VendedorId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterunanimosidebar", "GeneXus.Programs.general.ui.masterunanimosidebar", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Vendedor", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVendedorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVendedorId_Internalname, "Vendedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVendedorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A6VendedorId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A6VendedorId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVendedorNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVendedorNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVendedorNome_Internalname, A7VendedorNome, StringUtil.RTrim( context.localUtil.Format( A7VendedorNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgVendedorFoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Foto", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A8VendedorFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000VendedorFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.PathToRelativeUrl( A8VendedorFoto));
         GxWebStd.gx_bitmap( context, imgVendedorFoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgVendedorFoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A8VendedorFoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Vendedor.htm");
         AssignProp("", false, imgVendedorFoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.PathToRelativeUrl( A8VendedorFoto)), true);
         AssignProp("", false, imgVendedorFoto_Internalname, "IsBlob", StringUtil.BoolToStr( A8VendedorFoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisVendedorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisVendedorId_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisVendedorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A9PaisVendedorId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A9PaisVendedorId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisVendedorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisVendedorId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Vendedor.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_9_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_9_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_9_Internalname, sImgUrl, imgprompt_9_Link, "", "", context.GetTheme( ), imgprompt_9_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisVendedorNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisVendedorNome_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisVendedorNome_Internalname, A10PaisVendedorNome, StringUtil.RTrim( context.localUtil.Format( A10PaisVendedorNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisVendedorNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisVendedorNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "Right", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Vendedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E11032 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z6VendedorId = (short)(context.localUtil.CToN( cgiGet( "Z6VendedorId"), ".", ","));
               Z7VendedorNome = cgiGet( "Z7VendedorNome");
               Z9PaisVendedorId = (short)(context.localUtil.CToN( cgiGet( "Z9PaisVendedorId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N9PaisVendedorId = (short)(context.localUtil.CToN( cgiGet( "N9PaisVendedorId"), ".", ","));
               AV7VendedorId = (short)(context.localUtil.CToN( cgiGet( "vVENDEDORID"), ".", ","));
               AV11Insert_PaisVendedorId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_PAISVENDEDORID"), ".", ","));
               A40000VendedorFoto_GXI = cgiGet( "VENDEDORFOTO_GXI");
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtVendedorId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVendedorId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENDEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtVendedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A6VendedorId = 0;
                  AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
               }
               else
               {
                  A6VendedorId = (short)(context.localUtil.CToN( cgiGet( edtVendedorId_Internalname), ".", ","));
                  AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
               }
               A7VendedorNome = cgiGet( edtVendedorNome_Internalname);
               AssignAttri("", false, "A7VendedorNome", A7VendedorNome);
               A8VendedorFoto = cgiGet( imgVendedorFoto_Internalname);
               AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisVendedorId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisVendedorId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISVENDEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisVendedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A9PaisVendedorId = 0;
                  AssignAttri("", false, "A9PaisVendedorId", StringUtil.LTrimStr( (decimal)(A9PaisVendedorId), 4, 0));
               }
               else
               {
                  A9PaisVendedorId = (short)(context.localUtil.CToN( cgiGet( edtPaisVendedorId_Internalname), ".", ","));
                  AssignAttri("", false, "A9PaisVendedorId", StringUtil.LTrimStr( (decimal)(A9PaisVendedorId), 4, 0));
               }
               A10PaisVendedorNome = cgiGet( edtPaisVendedorNome_Internalname);
               AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgVendedorFoto_Internalname, ref  A8VendedorFoto, ref  A40000VendedorFoto_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Vendedor");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A6VendedorId != Z6VendedorId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("vendedor:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A6VendedorId = (short)(NumberUtil.Val( GetPar( "VendedorId"), "."));
                  AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode3 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode3;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound3 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_030( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VENDEDORID");
                        AnyError = 1;
                        GX_FocusControl = edtVendedorId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
            sEvt = cgiGet( "_EventName");
            EvtGridId = cgiGet( "_EventGridId");
            EvtRowId = cgiGet( "_EventRowId");
            if ( StringUtil.Len( sEvt) > 0 )
            {
               sEvtType = StringUtil.Left( sEvt, 1);
               sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
               if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
               {
                  if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                  {
                     sEvtType = StringUtil.Right( sEvt, 1);
                     if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                     {
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12032 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                     }
                     else
                     {
                     }
                  }
                  context.wbHandled = 1;
               }
            }
         }
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E12032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll033( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         if ( IsDsp( ) || IsDlt( ) )
         {
            bttBtn_delete_Visible = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
            if ( IsDsp( ) )
            {
               bttBtn_enter_Visible = 0;
               AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
            }
            DisableAttributes033( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption030( )
      {
      }

      protected void E11032( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_PaisVendedorId = 0;
         AssignAttri("", false, "AV11Insert_PaisVendedorId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisVendedorId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "PaisVendedorId") == 0 )
               {
                  AV11Insert_PaisVendedorId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_PaisVendedorId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisVendedorId), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12032( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwvendedor.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z7VendedorNome = T00033_A7VendedorNome[0];
               Z9PaisVendedorId = T00033_A9PaisVendedorId[0];
            }
            else
            {
               Z7VendedorNome = A7VendedorNome;
               Z9PaisVendedorId = A9PaisVendedorId;
            }
         }
         if ( GX_JID == -10 )
         {
            Z6VendedorId = A6VendedorId;
            Z7VendedorNome = A7VendedorNome;
            Z8VendedorFoto = A8VendedorFoto;
            Z40000VendedorFoto_GXI = A40000VendedorFoto_GXI;
            Z9PaisVendedorId = A9PaisVendedorId;
            Z10PaisVendedorNome = A10PaisVendedorNome;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_9_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISVENDEDORID"+"'), id:'"+"PAISVENDEDORID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7VendedorId) )
         {
            A6VendedorId = AV7VendedorId;
            AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
         }
         if ( ! (0==AV7VendedorId) )
         {
            edtVendedorId_Enabled = 0;
            AssignProp("", false, edtVendedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorId_Enabled), 5, 0), true);
         }
         else
         {
            edtVendedorId_Enabled = 1;
            AssignProp("", false, edtVendedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7VendedorId) )
         {
            edtVendedorId_Enabled = 0;
            AssignProp("", false, edtVendedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisVendedorId) )
         {
            edtPaisVendedorId_Enabled = 0;
            AssignProp("", false, edtPaisVendedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisVendedorId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisVendedorId_Enabled = 1;
            AssignProp("", false, edtPaisVendedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisVendedorId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisVendedorId) )
         {
            A9PaisVendedorId = AV11Insert_PaisVendedorId;
            AssignAttri("", false, "A9PaisVendedorId", StringUtil.LTrimStr( (decimal)(A9PaisVendedorId), 4, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            AV13Pgmname = "Vendedor";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T00034 */
            pr_default.execute(2, new Object[] {A9PaisVendedorId});
            A10PaisVendedorNome = T00034_A10PaisVendedorNome[0];
            AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
            pr_default.close(2);
         }
      }

      protected void Load033( )
      {
         /* Using cursor T00035 */
         pr_default.execute(3, new Object[] {A6VendedorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound3 = 1;
            A7VendedorNome = T00035_A7VendedorNome[0];
            AssignAttri("", false, "A7VendedorNome", A7VendedorNome);
            A40000VendedorFoto_GXI = T00035_A40000VendedorFoto_GXI[0];
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            A10PaisVendedorNome = T00035_A10PaisVendedorNome[0];
            AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
            A9PaisVendedorId = T00035_A9PaisVendedorId[0];
            AssignAttri("", false, "A9PaisVendedorId", StringUtil.LTrimStr( (decimal)(A9PaisVendedorId), 4, 0));
            A8VendedorFoto = T00035_A8VendedorFoto[0];
            AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            ZM033( -10) ;
         }
         pr_default.close(3);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         AV13Pgmname = "Vendedor";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "Vendedor";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A7VendedorNome)) )
         {
            GX_msglist.addItem("O nome do vendedor deve ser preenchido.", 1, "VENDEDORNOME");
            AnyError = 1;
            GX_FocusControl = edtVendedorNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00034 */
         pr_default.execute(2, new Object[] {A9PaisVendedorId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISVENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtPaisVendedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10PaisVendedorNome = T00034_A10PaisVendedorNome[0];
         AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_11( short A9PaisVendedorId )
      {
         /* Using cursor T00036 */
         pr_default.execute(4, new Object[] {A9PaisVendedorId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISVENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtPaisVendedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A10PaisVendedorNome = T00036_A10PaisVendedorNome[0];
         AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A10PaisVendedorNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey033( )
      {
         /* Using cursor T00037 */
         pr_default.execute(5, new Object[] {A6VendedorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00033 */
         pr_default.execute(1, new Object[] {A6VendedorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 10) ;
            RcdFound3 = 1;
            A6VendedorId = T00033_A6VendedorId[0];
            AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
            A7VendedorNome = T00033_A7VendedorNome[0];
            AssignAttri("", false, "A7VendedorNome", A7VendedorNome);
            A40000VendedorFoto_GXI = T00033_A40000VendedorFoto_GXI[0];
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            A9PaisVendedorId = T00033_A9PaisVendedorId[0];
            AssignAttri("", false, "A9PaisVendedorId", StringUtil.LTrimStr( (decimal)(A9PaisVendedorId), 4, 0));
            A8VendedorFoto = T00033_A8VendedorFoto[0];
            AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
            AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
            AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
            Z6VendedorId = A6VendedorId;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode3;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound3 = 0;
         /* Using cursor T00038 */
         pr_default.execute(6, new Object[] {A6VendedorId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00038_A6VendedorId[0] < A6VendedorId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00038_A6VendedorId[0] > A6VendedorId ) ) )
            {
               A6VendedorId = T00038_A6VendedorId[0];
               AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound3 = 0;
         /* Using cursor T00039 */
         pr_default.execute(7, new Object[] {A6VendedorId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00039_A6VendedorId[0] > A6VendedorId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00039_A6VendedorId[0] < A6VendedorId ) ) )
            {
               A6VendedorId = T00039_A6VendedorId[0];
               AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
               RcdFound3 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVendedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert033( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A6VendedorId != Z6VendedorId )
               {
                  A6VendedorId = Z6VendedorId;
                  AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VENDEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtVendedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVendedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update033( ) ;
                  GX_FocusControl = edtVendedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A6VendedorId != Z6VendedorId )
               {
                  /* Insert record */
                  GX_FocusControl = edtVendedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert033( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VENDEDORID");
                     AnyError = 1;
                     GX_FocusControl = edtVendedorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtVendedorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert033( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A6VendedorId != Z6VendedorId )
         {
            A6VendedorId = Z6VendedorId;
            AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtVendedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVendedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00032 */
            pr_default.execute(0, new Object[] {A6VendedorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Vendedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z7VendedorNome, T00032_A7VendedorNome[0]) != 0 ) || ( Z9PaisVendedorId != T00032_A9PaisVendedorId[0] ) )
            {
               if ( StringUtil.StrCmp(Z7VendedorNome, T00032_A7VendedorNome[0]) != 0 )
               {
                  GXUtil.WriteLog("vendedor:[seudo value changed for attri]"+"VendedorNome");
                  GXUtil.WriteLogRaw("Old: ",Z7VendedorNome);
                  GXUtil.WriteLogRaw("Current: ",T00032_A7VendedorNome[0]);
               }
               if ( Z9PaisVendedorId != T00032_A9PaisVendedorId[0] )
               {
                  GXUtil.WriteLog("vendedor:[seudo value changed for attri]"+"PaisVendedorId");
                  GXUtil.WriteLogRaw("Old: ",Z9PaisVendedorId);
                  GXUtil.WriteLogRaw("Current: ",T00032_A9PaisVendedorId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Vendedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000310 */
                     pr_default.execute(8, new Object[] {A6VendedorId, A7VendedorNome, A8VendedorFoto, A40000VendedorFoto_GXI, A9PaisVendedorId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Vendedor");
                     if ( (pr_default.getStatus(8) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption030( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000311 */
                     pr_default.execute(9, new Object[] {A7VendedorNome, A9PaisVendedorId, A6VendedorId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Vendedor");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Vendedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000312 */
            pr_default.execute(10, new Object[] {A8VendedorFoto, A40000VendedorFoto_GXI, A6VendedorId});
            pr_default.close(10);
            pr_default.SmartCacheProvider.SetUpdated("Vendedor");
         }
      }

      protected void delete( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000313 */
                  pr_default.execute(11, new Object[] {A6VendedorId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("Vendedor");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel033( ) ;
         Gx_mode = sMode3;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "Vendedor";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000314 */
            pr_default.execute(12, new Object[] {A9PaisVendedorId});
            A10PaisVendedorNome = T000314_A10PaisVendedorNome[0];
            AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000315 */
            pr_default.execute(13, new Object[] {A6VendedorId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Produto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(12);
            context.CommitDataStores("vendedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues030( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(12);
            context.RollbackDataStores("vendedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart033( )
      {
         /* Scan By routine */
         /* Using cursor T000316 */
         pr_default.execute(14);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound3 = 1;
            A6VendedorId = T000316_A6VendedorId[0];
            AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound3 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound3 = 1;
            A6VendedorId = T000316_A6VendedorId[0];
            AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
         }
      }

      protected void ScanEnd033( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
         edtVendedorId_Enabled = 0;
         AssignProp("", false, edtVendedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorId_Enabled), 5, 0), true);
         edtVendedorNome_Enabled = 0;
         AssignProp("", false, edtVendedorNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorNome_Enabled), 5, 0), true);
         imgVendedorFoto_Enabled = 0;
         AssignProp("", false, imgVendedorFoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgVendedorFoto_Enabled), 5, 0), true);
         edtPaisVendedorId_Enabled = 0;
         AssignProp("", false, edtPaisVendedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisVendedorId_Enabled), 5, 0), true);
         edtPaisVendedorNome_Enabled = 0;
         AssignProp("", false, edtPaisVendedorNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisVendedorNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues030( )
      {
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         MasterPageObj.master_styles();
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 849480), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 849480), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 849480), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vendedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VendedorId,4,0))}, new string[] {"Gx_mode","VendedorId"}) +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Vendedor");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("vendedor:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z6VendedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z6VendedorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z7VendedorNome", Z7VendedorNome);
         GxWebStd.gx_hidden_field( context, "Z9PaisVendedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z9PaisVendedorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N9PaisVendedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A9PaisVendedorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV9TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV9TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vVENDEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VendedorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVENDEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VendedorId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISVENDEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PaisVendedorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "VENDEDORFOTO_GXI", A40000VendedorFoto_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
         GXCCtlgxBlob = "VENDEDORFOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A8VendedorFoto);
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
      }

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("vendedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7VendedorId,4,0))}, new string[] {"Gx_mode","VendedorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Vendedor" ;
      }

      public override string GetPgmdesc( )
      {
         return "Vendedor" ;
      }

      protected void InitializeNonKey033( )
      {
         A9PaisVendedorId = 0;
         AssignAttri("", false, "A9PaisVendedorId", StringUtil.LTrimStr( (decimal)(A9PaisVendedorId), 4, 0));
         A7VendedorNome = "";
         AssignAttri("", false, "A7VendedorNome", A7VendedorNome);
         A8VendedorFoto = "";
         AssignAttri("", false, "A8VendedorFoto", A8VendedorFoto);
         AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
         AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
         A40000VendedorFoto_GXI = "";
         AssignProp("", false, imgVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), true);
         AssignProp("", false, imgVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
         A10PaisVendedorNome = "";
         AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
         Z7VendedorNome = "";
         Z9PaisVendedorId = 0;
      }

      protected void InitAll033( )
      {
         A6VendedorId = 0;
         AssignAttri("", false, "A6VendedorId", StringUtil.LTrimStr( (decimal)(A6VendedorId), 4, 0));
         InitializeNonKey033( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513878", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("vendedor.js", "?202582916513879", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtVendedorId_Internalname = "VENDEDORID";
         edtVendedorNome_Internalname = "VENDEDORNOME";
         imgVendedorFoto_Internalname = "VENDEDORFOTO";
         edtPaisVendedorId_Internalname = "PAISVENDEDORID";
         edtPaisVendedorNome_Internalname = "PAISVENDEDORNOME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_9_Internalname = "PROMPT_9";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Vendedor";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPaisVendedorNome_Jsonclick = "";
         edtPaisVendedorNome_Enabled = 0;
         imgprompt_9_Visible = 1;
         imgprompt_9_Link = "";
         edtPaisVendedorId_Jsonclick = "";
         edtPaisVendedorId_Enabled = 1;
         imgVendedorFoto_Enabled = 1;
         edtVendedorNome_Jsonclick = "";
         edtVendedorNome_Enabled = 1;
         edtVendedorId_Jsonclick = "";
         edtVendedorId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void Valid_Paisvendedorid( )
      {
         /* Using cursor T000314 */
         pr_default.execute(12, new Object[] {A9PaisVendedorId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISVENDEDORID");
            AnyError = 1;
            GX_FocusControl = edtPaisVendedorId_Internalname;
         }
         A10PaisVendedorNome = T000314_A10PaisVendedorNome[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A10PaisVendedorNome", A10PaisVendedorNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VendedorId',fld:'vVENDEDORID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7VendedorId',fld:'vVENDEDORID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12032',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_VENDEDORID","{handler:'Valid_Vendedorid',iparms:[]");
         setEventMetadata("VALID_VENDEDORID",",oparms:[]}");
         setEventMetadata("VALID_VENDEDORNOME","{handler:'Valid_Vendedornome',iparms:[]");
         setEventMetadata("VALID_VENDEDORNOME",",oparms:[]}");
         setEventMetadata("VALID_PAISVENDEDORID","{handler:'Valid_Paisvendedorid',iparms:[{av:'A9PaisVendedorId',fld:'PAISVENDEDORID',pic:'ZZZ9'},{av:'A10PaisVendedorNome',fld:'PAISVENDEDORNOME',pic:''}]");
         setEventMetadata("VALID_PAISVENDEDORID",",oparms:[{av:'A10PaisVendedorNome',fld:'PAISVENDEDORNOME',pic:''}]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z7VendedorNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A7VendedorNome = "";
         A8VendedorFoto = "";
         A40000VendedorFoto_GXI = "";
         sImgUrl = "";
         imgprompt_9_gximage = "";
         A10PaisVendedorNome = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode3 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z8VendedorFoto = "";
         Z40000VendedorFoto_GXI = "";
         Z10PaisVendedorNome = "";
         T00034_A10PaisVendedorNome = new string[] {""} ;
         T00035_A6VendedorId = new short[1] ;
         T00035_A7VendedorNome = new string[] {""} ;
         T00035_A40000VendedorFoto_GXI = new string[] {""} ;
         T00035_A10PaisVendedorNome = new string[] {""} ;
         T00035_A9PaisVendedorId = new short[1] ;
         T00035_A8VendedorFoto = new string[] {""} ;
         T00036_A10PaisVendedorNome = new string[] {""} ;
         T00037_A6VendedorId = new short[1] ;
         T00033_A6VendedorId = new short[1] ;
         T00033_A7VendedorNome = new string[] {""} ;
         T00033_A40000VendedorFoto_GXI = new string[] {""} ;
         T00033_A9PaisVendedorId = new short[1] ;
         T00033_A8VendedorFoto = new string[] {""} ;
         T00038_A6VendedorId = new short[1] ;
         T00039_A6VendedorId = new short[1] ;
         T00032_A6VendedorId = new short[1] ;
         T00032_A7VendedorNome = new string[] {""} ;
         T00032_A40000VendedorFoto_GXI = new string[] {""} ;
         T00032_A9PaisVendedorId = new short[1] ;
         T00032_A8VendedorFoto = new string[] {""} ;
         T000314_A10PaisVendedorNome = new string[] {""} ;
         T000315_A19ProdutoId = new short[1] ;
         T000316_A6VendedorId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vendedor__default(),
            new Object[][] {
                new Object[] {
               T00032_A6VendedorId, T00032_A7VendedorNome, T00032_A40000VendedorFoto_GXI, T00032_A9PaisVendedorId, T00032_A8VendedorFoto
               }
               , new Object[] {
               T00033_A6VendedorId, T00033_A7VendedorNome, T00033_A40000VendedorFoto_GXI, T00033_A9PaisVendedorId, T00033_A8VendedorFoto
               }
               , new Object[] {
               T00034_A10PaisVendedorNome
               }
               , new Object[] {
               T00035_A6VendedorId, T00035_A7VendedorNome, T00035_A40000VendedorFoto_GXI, T00035_A10PaisVendedorNome, T00035_A9PaisVendedorId, T00035_A8VendedorFoto
               }
               , new Object[] {
               T00036_A10PaisVendedorNome
               }
               , new Object[] {
               T00037_A6VendedorId
               }
               , new Object[] {
               T00038_A6VendedorId
               }
               , new Object[] {
               T00039_A6VendedorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000314_A10PaisVendedorNome
               }
               , new Object[] {
               T000315_A19ProdutoId
               }
               , new Object[] {
               T000316_A6VendedorId
               }
            }
         );
         AV13Pgmname = "Vendedor";
      }

      private short wcpOAV7VendedorId ;
      private short Z6VendedorId ;
      private short Z9PaisVendedorId ;
      private short N9PaisVendedorId ;
      private short GxWebError ;
      private short A9PaisVendedorId ;
      private short AV7VendedorId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A6VendedorId ;
      private short AV11Insert_PaisVendedorId ;
      private short RcdFound3 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_3 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtVendedorId_Enabled ;
      private int edtVendedorNome_Enabled ;
      private int imgVendedorFoto_Enabled ;
      private int edtPaisVendedorId_Enabled ;
      private int imgprompt_9_Visible ;
      private int edtPaisVendedorNome_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV14GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVendedorId_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtVendedorId_Jsonclick ;
      private string edtVendedorNome_Internalname ;
      private string edtVendedorNome_Jsonclick ;
      private string imgVendedorFoto_Internalname ;
      private string sImgUrl ;
      private string edtPaisVendedorId_Internalname ;
      private string edtPaisVendedorId_Jsonclick ;
      private string imgprompt_9_gximage ;
      private string imgprompt_9_Internalname ;
      private string imgprompt_9_Link ;
      private string edtPaisVendedorNome_Internalname ;
      private string edtPaisVendedorNome_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode3 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A8VendedorFoto_IsBlob ;
      private bool returnInSub ;
      private string Z7VendedorNome ;
      private string A7VendedorNome ;
      private string A40000VendedorFoto_GXI ;
      private string A10PaisVendedorNome ;
      private string Z40000VendedorFoto_GXI ;
      private string Z10PaisVendedorNome ;
      private string A8VendedorFoto ;
      private string Z8VendedorFoto ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00034_A10PaisVendedorNome ;
      private short[] T00035_A6VendedorId ;
      private string[] T00035_A7VendedorNome ;
      private string[] T00035_A40000VendedorFoto_GXI ;
      private string[] T00035_A10PaisVendedorNome ;
      private short[] T00035_A9PaisVendedorId ;
      private string[] T00035_A8VendedorFoto ;
      private string[] T00036_A10PaisVendedorNome ;
      private short[] T00037_A6VendedorId ;
      private short[] T00033_A6VendedorId ;
      private string[] T00033_A7VendedorNome ;
      private string[] T00033_A40000VendedorFoto_GXI ;
      private short[] T00033_A9PaisVendedorId ;
      private string[] T00033_A8VendedorFoto ;
      private short[] T00038_A6VendedorId ;
      private short[] T00039_A6VendedorId ;
      private short[] T00032_A6VendedorId ;
      private string[] T00032_A7VendedorNome ;
      private string[] T00032_A40000VendedorFoto_GXI ;
      private short[] T00032_A9PaisVendedorId ;
      private string[] T00032_A8VendedorFoto ;
      private string[] T000314_A10PaisVendedorNome ;
      private short[] T000315_A19ProdutoId ;
      private short[] T000316_A6VendedorId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class vendedor__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
         ,new ForEachCursor(def[6])
         ,new ForEachCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00035;
          prmT00035 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT00034;
          prmT00034 = new Object[] {
          new ParDef("@PaisVendedorId",GXType.Int16,4,0)
          };
          Object[] prmT00036;
          prmT00036 = new Object[] {
          new ParDef("@PaisVendedorId",GXType.Int16,4,0)
          };
          Object[] prmT00037;
          prmT00037 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT00033;
          prmT00033 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT00038;
          prmT00038 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT00039;
          prmT00039 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT00032;
          prmT00032 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT000310;
          prmT000310 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0) ,
          new ParDef("@VendedorNome",GXType.NVarChar,40,0) ,
          new ParDef("@VendedorFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@VendedorFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Vendedor", Fld="VendedorFoto"} ,
          new ParDef("@PaisVendedorId",GXType.Int16,4,0)
          };
          Object[] prmT000311;
          prmT000311 = new Object[] {
          new ParDef("@VendedorNome",GXType.NVarChar,40,0) ,
          new ParDef("@PaisVendedorId",GXType.Int16,4,0) ,
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT000312;
          prmT000312 = new Object[] {
          new ParDef("@VendedorFoto",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@VendedorFoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Vendedor", Fld="VendedorFoto"} ,
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT000313;
          prmT000313 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT000315;
          prmT000315 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          Object[] prmT000316;
          prmT000316 = new Object[] {
          };
          Object[] prmT000314;
          prmT000314 = new Object[] {
          new ParDef("@PaisVendedorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00032", "SELECT [VendedorId], [VendedorNome], [VendedorFoto_GXI], [PaisVendedorId] AS PaisVendedorId, [VendedorFoto] FROM [Vendedor] WITH (UPDLOCK) WHERE [VendedorId] = @VendedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00032,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00033", "SELECT [VendedorId], [VendedorNome], [VendedorFoto_GXI], [PaisVendedorId] AS PaisVendedorId, [VendedorFoto] FROM [Vendedor] WHERE [VendedorId] = @VendedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00033,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00034", "SELECT [PaisNome] AS PaisVendedorNome FROM [Pais] WHERE [PaisId] = @PaisVendedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00034,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00035", "SELECT TM1.[VendedorId], TM1.[VendedorNome], TM1.[VendedorFoto_GXI], T2.[PaisNome] AS PaisVendedorNome, TM1.[PaisVendedorId] AS PaisVendedorId, TM1.[VendedorFoto] FROM ([Vendedor] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisVendedorId]) WHERE TM1.[VendedorId] = @VendedorId ORDER BY TM1.[VendedorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00035,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00036", "SELECT [PaisNome] AS PaisVendedorNome FROM [Pais] WHERE [PaisId] = @PaisVendedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00036,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00037", "SELECT [VendedorId] FROM [Vendedor] WHERE [VendedorId] = @VendedorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00037,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00038", "SELECT TOP 1 [VendedorId] FROM [Vendedor] WHERE ( [VendedorId] > @VendedorId) ORDER BY [VendedorId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00038,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00039", "SELECT TOP 1 [VendedorId] FROM [Vendedor] WHERE ( [VendedorId] < @VendedorId) ORDER BY [VendedorId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00039,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000310", "INSERT INTO [Vendedor]([VendedorId], [VendedorNome], [VendedorFoto], [VendedorFoto_GXI], [PaisVendedorId]) VALUES(@VendedorId, @VendedorNome, @VendedorFoto, @VendedorFoto_GXI, @PaisVendedorId)", GxErrorMask.GX_NOMASK,prmT000310)
             ,new CursorDef("T000311", "UPDATE [Vendedor] SET [VendedorNome]=@VendedorNome, [PaisVendedorId]=@PaisVendedorId  WHERE [VendedorId] = @VendedorId", GxErrorMask.GX_NOMASK,prmT000311)
             ,new CursorDef("T000312", "UPDATE [Vendedor] SET [VendedorFoto]=@VendedorFoto, [VendedorFoto_GXI]=@VendedorFoto_GXI  WHERE [VendedorId] = @VendedorId", GxErrorMask.GX_NOMASK,prmT000312)
             ,new CursorDef("T000313", "DELETE FROM [Vendedor]  WHERE [VendedorId] = @VendedorId", GxErrorMask.GX_NOMASK,prmT000313)
             ,new CursorDef("T000314", "SELECT [PaisNome] AS PaisVendedorNome FROM [Pais] WHERE [PaisId] = @PaisVendedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000314,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000315", "SELECT TOP 1 [ProdutoId] FROM [Produto] WHERE [VendedorProdutoId] = @VendedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000315,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000316", "SELECT [VendedorId] FROM [Vendedor] ORDER BY [VendedorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000316,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(3));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
