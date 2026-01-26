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
   public class cliente : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A11PaisClienteId = (short)(NumberUtil.Val( GetPar( "PaisClienteId"), "."));
            AssignAttri("", false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A11PaisClienteId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A48CartaoPontosClienteId = (short)(NumberUtil.Val( GetPar( "CartaoPontosClienteId"), "."));
            n48CartaoPontosClienteId = false;
            AssignAttri("", false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A48CartaoPontosClienteId) ;
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
               AV7ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
               AssignAttri("", false, "AV7ClienteId", StringUtil.LTrimStr( (decimal)(AV7ClienteId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Cliente", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public cliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ClienteId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ClienteId = aP1_ClienteId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkClienteVIP = new GXCheckbox();
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
         A67ClienteVIP = StringUtil.StrToBool( StringUtil.BoolToStr( A67ClienteVIP));
         AssignAttri("", false, "A67ClienteVIP", A67ClienteVIP);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Cliente", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Cliente.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Cliente.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A43ClienteId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteNome_Internalname, A44ClienteNome, StringUtil.RTrim( context.localUtil.Format( A44ClienteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteEndereco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteEndereco_Internalname, "Endereço", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtClienteEndereco_Internalname, A45ClienteEndereco, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A45ClienteEndereco), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtClienteEndereco_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteTelefone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteTelefone_Internalname, "Telefone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A46ClienteTelefone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteTelefone_Internalname, StringUtil.RTrim( A46ClienteTelefone), StringUtil.RTrim( context.localUtil.Format( A46ClienteTelefone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtClienteTelefone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteTelefone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteEmail_Internalname, A47ClienteEmail, StringUtil.RTrim( context.localUtil.Format( A47ClienteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A47ClienteEmail, "", "", "", edtClienteEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisClienteId_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11PaisClienteId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A11PaisClienteId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisClienteId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Cliente.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_11_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_11_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_11_Internalname, sImgUrl, imgprompt_11_Link, "", "", context.GetTheme( ), imgprompt_11_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisClienteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisClienteNome_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisClienteNome_Internalname, A12PaisClienteNome, StringUtil.RTrim( context.localUtil.Format( A12PaisClienteNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisClienteNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisClienteNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgPaisClienteBandeira_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Bandeira", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A69PaisClienteBandeira_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PaisClienteBandeira_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.PathToRelativeUrl( A69PaisClienteBandeira));
         GxWebStd.gx_bitmap( context, imgPaisClienteBandeira_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPaisClienteBandeira_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 0, A69PaisClienteBandeira_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Cliente.htm");
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.PathToRelativeUrl( A69PaisClienteBandeira)), true);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "IsBlob", StringUtil.BoolToStr( A69PaisClienteBandeira_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCartaoPontosClienteId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCartaoPontosClienteId_Internalname, "Cartão", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCartaoPontosClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A48CartaoPontosClienteId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A48CartaoPontosClienteId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosClienteId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCartaoPontosClienteId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Cliente.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_48_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_48_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_48_Internalname, sImgUrl, imgprompt_48_Link, "", "", context.GetTheme( ), imgprompt_48_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCartaoPontosClienteDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCartaoPontosClienteDescricao_Internalname, "Cartão", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCartaoPontosClienteDescricao_Internalname, A49CartaoPontosClienteDescricao, StringUtil.RTrim( context.localUtil.Format( A49CartaoPontosClienteDescricao, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosClienteDescricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCartaoPontosClienteDescricao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+chkClienteVIP_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkClienteVIP_Internalname, "VIP", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkClienteVIP_Internalname, StringUtil.BoolToStr( A67ClienteVIP), "", "VIP", 1, chkClienteVIP.Enabled, "true", "", StyleString, ClassString, "", "", "");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Cliente.htm");
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
         E110C2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z43ClienteId = (short)(context.localUtil.CToN( cgiGet( "Z43ClienteId"), ".", ","));
               Z44ClienteNome = cgiGet( "Z44ClienteNome");
               Z45ClienteEndereco = cgiGet( "Z45ClienteEndereco");
               Z46ClienteTelefone = cgiGet( "Z46ClienteTelefone");
               Z47ClienteEmail = cgiGet( "Z47ClienteEmail");
               Z11PaisClienteId = (short)(context.localUtil.CToN( cgiGet( "Z11PaisClienteId"), ".", ","));
               Z48CartaoPontosClienteId = (short)(context.localUtil.CToN( cgiGet( "Z48CartaoPontosClienteId"), ".", ","));
               n48CartaoPontosClienteId = ((0==A48CartaoPontosClienteId) ? true : false);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N11PaisClienteId = (short)(context.localUtil.CToN( cgiGet( "N11PaisClienteId"), ".", ","));
               N48CartaoPontosClienteId = (short)(context.localUtil.CToN( cgiGet( "N48CartaoPontosClienteId"), ".", ","));
               n48CartaoPontosClienteId = ((0==A48CartaoPontosClienteId) ? true : false);
               A66CartaoPontosAcumulados = context.localUtil.CToN( cgiGet( "CARTAOPONTOSACUMULADOS"), ".", ",");
               n66CartaoPontosAcumulados = false;
               AV7ClienteId = (short)(context.localUtil.CToN( cgiGet( "vCLIENTEID"), ".", ","));
               AV11Insert_PaisClienteId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_PAISCLIENTEID"), ".", ","));
               AV12Insert_CartaoPontosClienteId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CARTAOPONTOSCLIENTEID"), ".", ","));
               A41CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( "CARTAOPONTOSID"), ".", ","));
               A40000PaisClienteBandeira_GXI = cgiGet( "PAISCLIENTEBANDEIRA_GXI");
               AV14Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A43ClienteId = 0;
                  AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
               }
               else
               {
                  A43ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ","));
                  AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
               }
               A44ClienteNome = cgiGet( edtClienteNome_Internalname);
               AssignAttri("", false, "A44ClienteNome", A44ClienteNome);
               A45ClienteEndereco = cgiGet( edtClienteEndereco_Internalname);
               AssignAttri("", false, "A45ClienteEndereco", A45ClienteEndereco);
               A46ClienteTelefone = cgiGet( edtClienteTelefone_Internalname);
               AssignAttri("", false, "A46ClienteTelefone", A46ClienteTelefone);
               A47ClienteEmail = cgiGet( edtClienteEmail_Internalname);
               AssignAttri("", false, "A47ClienteEmail", A47ClienteEmail);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisClienteId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisClienteId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISCLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A11PaisClienteId = 0;
                  AssignAttri("", false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
               }
               else
               {
                  A11PaisClienteId = (short)(context.localUtil.CToN( cgiGet( edtPaisClienteId_Internalname), ".", ","));
                  AssignAttri("", false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
               }
               A12PaisClienteNome = cgiGet( edtPaisClienteNome_Internalname);
               AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
               A69PaisClienteBandeira = cgiGet( imgPaisClienteBandeira_Internalname);
               AssignAttri("", false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCartaoPontosClienteId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCartaoPontosClienteId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CARTAOPONTOSCLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtCartaoPontosClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A48CartaoPontosClienteId = 0;
                  n48CartaoPontosClienteId = false;
                  AssignAttri("", false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
               }
               else
               {
                  A48CartaoPontosClienteId = (short)(context.localUtil.CToN( cgiGet( edtCartaoPontosClienteId_Internalname), ".", ","));
                  n48CartaoPontosClienteId = false;
                  AssignAttri("", false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
               }
               n48CartaoPontosClienteId = ((0==A48CartaoPontosClienteId) ? true : false);
               A49CartaoPontosClienteDescricao = cgiGet( edtCartaoPontosClienteDescricao_Internalname);
               AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
               A67ClienteVIP = StringUtil.StrToBool( cgiGet( chkClienteVIP_Internalname));
               AssignAttri("", false, "A67ClienteVIP", A67ClienteVIP);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPaisClienteBandeira_Internalname, ref  A69PaisClienteBandeira, ref  A40000PaisClienteBandeira_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Cliente");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A43ClienteId != Z43ClienteId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("cliente:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A43ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
                  AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
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
                     sMode11 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode11;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound11 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0C0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIENTEID");
                        AnyError = 1;
                        GX_FocusControl = edtClienteId_Internalname;
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
                           E110C2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120C2 ();
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
            E120C2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0C11( ) ;
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
            DisableAttributes0C11( ) ;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C11( ) ;
            }
            else
            {
               CheckExtendedTable0C11( ) ;
               CloseExtendedTableCursors0C11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0C0( )
      {
      }

      protected void E110C2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV14Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV14Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_PaisClienteId = 0;
         AssignAttri("", false, "AV11Insert_PaisClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisClienteId), 4, 0));
         AV12Insert_CartaoPontosClienteId = 0;
         AssignAttri("", false, "AV12Insert_CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(AV12Insert_CartaoPontosClienteId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV14Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV15GXV1 = 1;
            AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
            while ( AV15GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV13TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV15GXV1));
               if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "PaisClienteId") == 0 )
               {
                  AV11Insert_PaisClienteId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_PaisClienteId", StringUtil.LTrimStr( (decimal)(AV11Insert_PaisClienteId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV13TrnContextAtt.gxTpr_Attributename, "CartaoPontosClienteId") == 0 )
               {
                  AV12Insert_CartaoPontosClienteId = (short)(NumberUtil.Val( AV13TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(AV12Insert_CartaoPontosClienteId), 4, 0));
               }
               AV15GXV1 = (int)(AV15GXV1+1);
               AssignAttri("", false, "AV15GXV1", StringUtil.LTrimStr( (decimal)(AV15GXV1), 8, 0));
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

      protected void E120C2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwcliente.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0C11( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z44ClienteNome = T000C3_A44ClienteNome[0];
               Z45ClienteEndereco = T000C3_A45ClienteEndereco[0];
               Z46ClienteTelefone = T000C3_A46ClienteTelefone[0];
               Z47ClienteEmail = T000C3_A47ClienteEmail[0];
               Z11PaisClienteId = T000C3_A11PaisClienteId[0];
               Z48CartaoPontosClienteId = T000C3_A48CartaoPontosClienteId[0];
            }
            else
            {
               Z44ClienteNome = A44ClienteNome;
               Z45ClienteEndereco = A45ClienteEndereco;
               Z46ClienteTelefone = A46ClienteTelefone;
               Z47ClienteEmail = A47ClienteEmail;
               Z11PaisClienteId = A11PaisClienteId;
               Z48CartaoPontosClienteId = A48CartaoPontosClienteId;
            }
         }
         if ( GX_JID == -17 )
         {
            Z43ClienteId = A43ClienteId;
            Z44ClienteNome = A44ClienteNome;
            Z45ClienteEndereco = A45ClienteEndereco;
            Z46ClienteTelefone = A46ClienteTelefone;
            Z47ClienteEmail = A47ClienteEmail;
            Z11PaisClienteId = A11PaisClienteId;
            Z48CartaoPontosClienteId = A48CartaoPontosClienteId;
            Z12PaisClienteNome = A12PaisClienteNome;
            Z69PaisClienteBandeira = A69PaisClienteBandeira;
            Z40000PaisClienteBandeira_GXI = A40000PaisClienteBandeira_GXI;
            Z49CartaoPontosClienteDescricao = A49CartaoPontosClienteDescricao;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_11_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISCLIENTEID"+"'), id:'"+"PAISCLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_48_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00a0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CARTAOPONTOSCLIENTEID"+"'), id:'"+"CARTAOPONTOSCLIENTEID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ClienteId) )
         {
            A43ClienteId = AV7ClienteId;
            AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
         }
         if ( ! (0==AV7ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteId_Enabled = 1;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7ClienteId) )
         {
            edtClienteId_Enabled = 0;
            AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisClienteId) )
         {
            edtPaisClienteId_Enabled = 0;
            AssignProp("", false, edtPaisClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisClienteId_Enabled = 1;
            AssignProp("", false, edtPaisClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisClienteId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CartaoPontosClienteId) )
         {
            edtCartaoPontosClienteId_Enabled = 0;
            AssignProp("", false, edtCartaoPontosClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosClienteId_Enabled), 5, 0), true);
         }
         else
         {
            edtCartaoPontosClienteId_Enabled = 1;
            AssignProp("", false, edtCartaoPontosClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosClienteId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_CartaoPontosClienteId) )
         {
            A48CartaoPontosClienteId = AV12Insert_CartaoPontosClienteId;
            n48CartaoPontosClienteId = false;
            AssignAttri("", false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_PaisClienteId) )
         {
            A11PaisClienteId = AV11Insert_PaisClienteId;
            AssignAttri("", false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
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
            AV14Pgmname = "Cliente";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000C8 */
            pr_default.execute(4, new Object[] {n48CartaoPontosClienteId, A48CartaoPontosClienteId});
            A49CartaoPontosClienteDescricao = T000C8_A49CartaoPontosClienteDescricao[0];
            AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
            pr_default.close(4);
            /* Using cursor T000C7 */
            pr_default.execute(3, new Object[] {A11PaisClienteId});
            A12PaisClienteNome = T000C7_A12PaisClienteNome[0];
            AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
            A40000PaisClienteBandeira_GXI = T000C7_A40000PaisClienteBandeira_GXI[0];
            n40000PaisClienteBandeira_GXI = T000C7_n40000PaisClienteBandeira_GXI[0];
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
            A69PaisClienteBandeira = T000C7_A69PaisClienteBandeira[0];
            AssignAttri("", false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
            pr_default.close(3);
         }
      }

      protected void Load0C11( )
      {
         /* Using cursor T000C9 */
         pr_default.execute(5, new Object[] {A43ClienteId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound11 = 1;
            A44ClienteNome = T000C9_A44ClienteNome[0];
            AssignAttri("", false, "A44ClienteNome", A44ClienteNome);
            A45ClienteEndereco = T000C9_A45ClienteEndereco[0];
            AssignAttri("", false, "A45ClienteEndereco", A45ClienteEndereco);
            A46ClienteTelefone = T000C9_A46ClienteTelefone[0];
            AssignAttri("", false, "A46ClienteTelefone", A46ClienteTelefone);
            A47ClienteEmail = T000C9_A47ClienteEmail[0];
            AssignAttri("", false, "A47ClienteEmail", A47ClienteEmail);
            A12PaisClienteNome = T000C9_A12PaisClienteNome[0];
            AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
            A40000PaisClienteBandeira_GXI = T000C9_A40000PaisClienteBandeira_GXI[0];
            n40000PaisClienteBandeira_GXI = T000C9_n40000PaisClienteBandeira_GXI[0];
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
            A49CartaoPontosClienteDescricao = T000C9_A49CartaoPontosClienteDescricao[0];
            AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
            A11PaisClienteId = T000C9_A11PaisClienteId[0];
            AssignAttri("", false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
            A48CartaoPontosClienteId = T000C9_A48CartaoPontosClienteId[0];
            n48CartaoPontosClienteId = T000C9_n48CartaoPontosClienteId[0];
            AssignAttri("", false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
            A69PaisClienteBandeira = T000C9_A69PaisClienteBandeira[0];
            AssignAttri("", false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
            ZM0C11( -17) ;
         }
         pr_default.close(5);
         OnLoadActions0C11( ) ;
      }

      protected void OnLoadActions0C11( )
      {
         AV14Pgmname = "Cliente";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
      }

      protected void CheckExtendedTable0C11( )
      {
         nIsDirty_11 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV14Pgmname = "Cliente";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A44ClienteNome)) )
         {
            GX_msglist.addItem("O nome do Cliente deve ser informado", 1, "CLIENTENOME");
            AnyError = 1;
            GX_FocusControl = edtClienteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A45ClienteEndereco)) )
         {
            GX_msglist.addItem("O Endereço deve ser informado", 1, "CLIENTEENDERECO");
            AnyError = 1;
            GX_FocusControl = edtClienteEndereco_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A46ClienteTelefone)) )
         {
            GX_msglist.addItem("Telefone não preenchido", 0, "CLIENTETELEFONE");
         }
         if ( ! ( GxRegex.IsMatch(A47ClienteEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("Field Email does not match the specified pattern", "OutOfRange", 1, "CLIENTEEMAIL");
            AnyError = 1;
            GX_FocusControl = edtClienteEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000C7 */
         pr_default.execute(3, new Object[] {A11PaisClienteId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISCLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtPaisClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A12PaisClienteNome = T000C7_A12PaisClienteNome[0];
         AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
         A40000PaisClienteBandeira_GXI = T000C7_A40000PaisClienteBandeira_GXI[0];
         n40000PaisClienteBandeira_GXI = T000C7_n40000PaisClienteBandeira_GXI[0];
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
         A69PaisClienteBandeira = T000C7_A69PaisClienteBandeira[0];
         AssignAttri("", false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
         pr_default.close(3);
         /* Using cursor T000C8 */
         pr_default.execute(4, new Object[] {n48CartaoPontosClienteId, A48CartaoPontosClienteId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A48CartaoPontosClienteId) ) )
            {
               GX_msglist.addItem("No matching 'Cartão'.", "ForeignKeyNotFound", 1, "CARTAOPONTOSCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtCartaoPontosClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A49CartaoPontosClienteDescricao = T000C8_A49CartaoPontosClienteDescricao[0];
         AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0C11( )
      {
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_19( short A11PaisClienteId )
      {
         /* Using cursor T000C10 */
         pr_default.execute(6, new Object[] {A11PaisClienteId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISCLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtPaisClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A12PaisClienteNome = T000C10_A12PaisClienteNome[0];
         AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
         A40000PaisClienteBandeira_GXI = T000C10_A40000PaisClienteBandeira_GXI[0];
         n40000PaisClienteBandeira_GXI = T000C10_n40000PaisClienteBandeira_GXI[0];
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
         A69PaisClienteBandeira = T000C10_A69PaisClienteBandeira[0];
         AssignAttri("", false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A12PaisClienteNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A69PaisClienteBandeira)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000PaisClienteBandeira_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_20( short A48CartaoPontosClienteId )
      {
         /* Using cursor T000C11 */
         pr_default.execute(7, new Object[] {n48CartaoPontosClienteId, A48CartaoPontosClienteId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (0==A48CartaoPontosClienteId) ) )
            {
               GX_msglist.addItem("No matching 'Cartão'.", "ForeignKeyNotFound", 1, "CARTAOPONTOSCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtCartaoPontosClienteId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A49CartaoPontosClienteDescricao = T000C11_A49CartaoPontosClienteDescricao[0];
         AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A49CartaoPontosClienteDescricao)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey0C11( )
      {
         /* Using cursor T000C12 */
         pr_default.execute(8, new Object[] {A43ClienteId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000C3 */
         pr_default.execute(1, new Object[] {A43ClienteId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C11( 17) ;
            RcdFound11 = 1;
            A43ClienteId = T000C3_A43ClienteId[0];
            AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
            A44ClienteNome = T000C3_A44ClienteNome[0];
            AssignAttri("", false, "A44ClienteNome", A44ClienteNome);
            A45ClienteEndereco = T000C3_A45ClienteEndereco[0];
            AssignAttri("", false, "A45ClienteEndereco", A45ClienteEndereco);
            A46ClienteTelefone = T000C3_A46ClienteTelefone[0];
            AssignAttri("", false, "A46ClienteTelefone", A46ClienteTelefone);
            A47ClienteEmail = T000C3_A47ClienteEmail[0];
            AssignAttri("", false, "A47ClienteEmail", A47ClienteEmail);
            A11PaisClienteId = T000C3_A11PaisClienteId[0];
            AssignAttri("", false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
            A48CartaoPontosClienteId = T000C3_A48CartaoPontosClienteId[0];
            n48CartaoPontosClienteId = T000C3_n48CartaoPontosClienteId[0];
            AssignAttri("", false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
            Z43ClienteId = A43ClienteId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0C11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0C11( ) ;
            }
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0C11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode11;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C11( ) ;
         if ( RcdFound11 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound11 = 0;
         /* Using cursor T000C13 */
         pr_default.execute(9, new Object[] {A43ClienteId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000C13_A43ClienteId[0] < A43ClienteId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000C13_A43ClienteId[0] > A43ClienteId ) ) )
            {
               A43ClienteId = T000C13_A43ClienteId[0];
               AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound11 = 0;
         /* Using cursor T000C14 */
         pr_default.execute(10, new Object[] {A43ClienteId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000C14_A43ClienteId[0] > A43ClienteId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000C14_A43ClienteId[0] < A43ClienteId ) ) )
            {
               A43ClienteId = T000C14_A43ClienteId[0];
               AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
               RcdFound11 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0C11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0C11( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( A43ClienteId != Z43ClienteId )
               {
                  A43ClienteId = Z43ClienteId;
                  AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIENTEID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0C11( ) ;
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A43ClienteId != Z43ClienteId )
               {
                  /* Insert record */
                  GX_FocusControl = edtClienteId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0C11( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIENTEID");
                     AnyError = 1;
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtClienteId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0C11( ) ;
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
         if ( A43ClienteId != Z43ClienteId )
         {
            A43ClienteId = Z43ClienteId;
            AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtClienteId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0C11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000C2 */
            pr_default.execute(0, new Object[] {A43ClienteId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z44ClienteNome, T000C2_A44ClienteNome[0]) != 0 ) || ( StringUtil.StrCmp(Z45ClienteEndereco, T000C2_A45ClienteEndereco[0]) != 0 ) || ( StringUtil.StrCmp(Z46ClienteTelefone, T000C2_A46ClienteTelefone[0]) != 0 ) || ( StringUtil.StrCmp(Z47ClienteEmail, T000C2_A47ClienteEmail[0]) != 0 ) || ( Z11PaisClienteId != T000C2_A11PaisClienteId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z48CartaoPontosClienteId != T000C2_A48CartaoPontosClienteId[0] ) )
            {
               if ( StringUtil.StrCmp(Z44ClienteNome, T000C2_A44ClienteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteNome");
                  GXUtil.WriteLogRaw("Old: ",Z44ClienteNome);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A44ClienteNome[0]);
               }
               if ( StringUtil.StrCmp(Z45ClienteEndereco, T000C2_A45ClienteEndereco[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteEndereco");
                  GXUtil.WriteLogRaw("Old: ",Z45ClienteEndereco);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A45ClienteEndereco[0]);
               }
               if ( StringUtil.StrCmp(Z46ClienteTelefone, T000C2_A46ClienteTelefone[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteTelefone");
                  GXUtil.WriteLogRaw("Old: ",Z46ClienteTelefone);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A46ClienteTelefone[0]);
               }
               if ( StringUtil.StrCmp(Z47ClienteEmail, T000C2_A47ClienteEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"ClienteEmail");
                  GXUtil.WriteLogRaw("Old: ",Z47ClienteEmail);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A47ClienteEmail[0]);
               }
               if ( Z11PaisClienteId != T000C2_A11PaisClienteId[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"PaisClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z11PaisClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A11PaisClienteId[0]);
               }
               if ( Z48CartaoPontosClienteId != T000C2_A48CartaoPontosClienteId[0] )
               {
                  GXUtil.WriteLog("cliente:[seudo value changed for attri]"+"CartaoPontosClienteId");
                  GXUtil.WriteLogRaw("Old: ",Z48CartaoPontosClienteId);
                  GXUtil.WriteLogRaw("Current: ",T000C2_A48CartaoPontosClienteId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C11( )
      {
         BeforeValidate0C11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C11( 0) ;
            CheckOptimisticConcurrency0C11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C15 */
                     pr_default.execute(11, new Object[] {A43ClienteId, A44ClienteNome, A45ClienteEndereco, A46ClienteTelefone, A47ClienteEmail, A11PaisClienteId, n48CartaoPontosClienteId, A48CartaoPontosClienteId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ResetCaption0C0( ) ;
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
               Load0C11( ) ;
            }
            EndLevel0C11( ) ;
         }
         CloseExtendedTableCursors0C11( ) ;
      }

      protected void Update0C11( )
      {
         BeforeValidate0C11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000C16 */
                     pr_default.execute(12, new Object[] {A44ClienteNome, A45ClienteEndereco, A46ClienteTelefone, A47ClienteEmail, A11PaisClienteId, n48CartaoPontosClienteId, A48CartaoPontosClienteId, A43ClienteId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Cliente");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C11( ) ;
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
            EndLevel0C11( ) ;
         }
         CloseExtendedTableCursors0C11( ) ;
      }

      protected void DeferredUpdate0C11( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0C11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C11( ) ;
            AfterConfirm0C11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000C17 */
                  pr_default.execute(13, new Object[] {A43ClienteId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("Cliente");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0C11( ) ;
         Gx_mode = sMode11;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0C11( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV14Pgmname = "Cliente";
            AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
            /* Using cursor T000C18 */
            pr_default.execute(14, new Object[] {A11PaisClienteId});
            A12PaisClienteNome = T000C18_A12PaisClienteNome[0];
            AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
            A40000PaisClienteBandeira_GXI = T000C18_A40000PaisClienteBandeira_GXI[0];
            n40000PaisClienteBandeira_GXI = T000C18_n40000PaisClienteBandeira_GXI[0];
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
            A69PaisClienteBandeira = T000C18_A69PaisClienteBandeira[0];
            AssignAttri("", false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
            AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
            pr_default.close(14);
            /* Using cursor T000C19 */
            pr_default.execute(15, new Object[] {n48CartaoPontosClienteId, A48CartaoPontosClienteId});
            A49CartaoPontosClienteDescricao = T000C19_A49CartaoPontosClienteDescricao[0];
            AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000C20 */
            pr_default.execute(16, new Object[] {A43ClienteId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CarrinhoCompras"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000C21 */
            pr_default.execute(17, new Object[] {A43ClienteId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CartaoPontos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel0C11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C11( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(2);
            pr_default.close(14);
            pr_default.close(15);
            context.CommitDataStores("cliente",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0C0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(2);
            pr_default.close(14);
            pr_default.close(15);
            context.RollbackDataStores("cliente",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0C11( )
      {
         /* Scan By routine */
         /* Using cursor T000C22 */
         pr_default.execute(18);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound11 = 1;
            A43ClienteId = T000C22_A43ClienteId[0];
            AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0C11( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound11 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound11 = 1;
            A43ClienteId = T000C22_A43ClienteId[0];
            AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
         }
      }

      protected void ScanEnd0C11( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0C11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C11( )
      {
         edtClienteId_Enabled = 0;
         AssignProp("", false, edtClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteId_Enabled), 5, 0), true);
         edtClienteNome_Enabled = 0;
         AssignProp("", false, edtClienteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteNome_Enabled), 5, 0), true);
         edtClienteEndereco_Enabled = 0;
         AssignProp("", false, edtClienteEndereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEndereco_Enabled), 5, 0), true);
         edtClienteTelefone_Enabled = 0;
         AssignProp("", false, edtClienteTelefone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteTelefone_Enabled), 5, 0), true);
         edtClienteEmail_Enabled = 0;
         AssignProp("", false, edtClienteEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteEmail_Enabled), 5, 0), true);
         edtPaisClienteId_Enabled = 0;
         AssignProp("", false, edtPaisClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisClienteId_Enabled), 5, 0), true);
         edtPaisClienteNome_Enabled = 0;
         AssignProp("", false, edtPaisClienteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisClienteNome_Enabled), 5, 0), true);
         imgPaisClienteBandeira_Enabled = 0;
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPaisClienteBandeira_Enabled), 5, 0), true);
         edtCartaoPontosClienteId_Enabled = 0;
         AssignProp("", false, edtCartaoPontosClienteId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosClienteId_Enabled), 5, 0), true);
         edtCartaoPontosClienteDescricao_Enabled = 0;
         AssignProp("", false, edtCartaoPontosClienteDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosClienteDescricao_Enabled), 5, 0), true);
         chkClienteVIP.Enabled = 0;
         AssignProp("", false, chkClienteVIP_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkClienteVIP.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0C11( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0C0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cliente.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ClienteId,4,0))}, new string[] {"Gx_mode","ClienteId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Cliente");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cliente:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z43ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z43ClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z44ClienteNome", Z44ClienteNome);
         GxWebStd.gx_hidden_field( context, "Z45ClienteEndereco", Z45ClienteEndereco);
         GxWebStd.gx_hidden_field( context, "Z46ClienteTelefone", StringUtil.RTrim( Z46ClienteTelefone));
         GxWebStd.gx_hidden_field( context, "Z47ClienteEmail", Z47ClienteEmail);
         GxWebStd.gx_hidden_field( context, "Z11PaisClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z11PaisClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z48CartaoPontosClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z48CartaoPontosClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N11PaisClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11PaisClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N48CartaoPontosClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48CartaoPontosClienteId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "CARTAOPONTOSACUMULADOS", StringUtil.LTrim( StringUtil.NToC( A66CartaoPontosAcumulados, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "vCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ClienteId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_PaisClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CARTAOPONTOSCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_CartaoPontosClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARTAOPONTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CartaoPontosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PAISCLIENTEBANDEIRA_GXI", A40000PaisClienteBandeira_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GXCCtlgxBlob = "PAISCLIENTEBANDEIRA" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A69PaisClienteBandeira);
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
         return formatLink("cliente.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ClienteId,4,0))}, new string[] {"Gx_mode","ClienteId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Cliente" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente" ;
      }

      protected void InitializeNonKey0C11( )
      {
         A11PaisClienteId = 0;
         AssignAttri("", false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
         A48CartaoPontosClienteId = 0;
         n48CartaoPontosClienteId = false;
         AssignAttri("", false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
         n48CartaoPontosClienteId = ((0==A48CartaoPontosClienteId) ? true : false);
         A44ClienteNome = "";
         AssignAttri("", false, "A44ClienteNome", A44ClienteNome);
         A45ClienteEndereco = "";
         AssignAttri("", false, "A45ClienteEndereco", A45ClienteEndereco);
         A46ClienteTelefone = "";
         AssignAttri("", false, "A46ClienteTelefone", A46ClienteTelefone);
         A47ClienteEmail = "";
         AssignAttri("", false, "A47ClienteEmail", A47ClienteEmail);
         A12PaisClienteNome = "";
         AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
         A69PaisClienteBandeira = "";
         AssignAttri("", false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
         A40000PaisClienteBandeira_GXI = "";
         n40000PaisClienteBandeira_GXI = false;
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
         AssignProp("", false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
         A49CartaoPontosClienteDescricao = "";
         AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
         A67ClienteVIP = false;
         AssignAttri("", false, "A67ClienteVIP", A67ClienteVIP);
         A66CartaoPontosAcumulados = 0;
         n66CartaoPontosAcumulados = false;
         AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         Z44ClienteNome = "";
         Z45ClienteEndereco = "";
         Z46ClienteTelefone = "";
         Z47ClienteEmail = "";
         Z11PaisClienteId = 0;
         Z48CartaoPontosClienteId = 0;
      }

      protected void InitAll0C11( )
      {
         A43ClienteId = 0;
         AssignAttri("", false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
         InitializeNonKey0C11( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916514213", true, true);
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
         context.AddJavascriptSource("cliente.js", "?202582916514213", false, true);
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
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteNome_Internalname = "CLIENTENOME";
         edtClienteEndereco_Internalname = "CLIENTEENDERECO";
         edtClienteTelefone_Internalname = "CLIENTETELEFONE";
         edtClienteEmail_Internalname = "CLIENTEEMAIL";
         edtPaisClienteId_Internalname = "PAISCLIENTEID";
         edtPaisClienteNome_Internalname = "PAISCLIENTENOME";
         imgPaisClienteBandeira_Internalname = "PAISCLIENTEBANDEIRA";
         edtCartaoPontosClienteId_Internalname = "CARTAOPONTOSCLIENTEID";
         edtCartaoPontosClienteDescricao_Internalname = "CARTAOPONTOSCLIENTEDESCRICAO";
         chkClienteVIP_Internalname = "CLIENTEVIP";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_11_Internalname = "PROMPT_11";
         imgprompt_48_Internalname = "PROMPT_48";
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
         Form.Caption = "Cliente";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkClienteVIP.Enabled = 0;
         edtCartaoPontosClienteDescricao_Jsonclick = "";
         edtCartaoPontosClienteDescricao_Enabled = 0;
         imgprompt_48_Visible = 1;
         imgprompt_48_Link = "";
         edtCartaoPontosClienteId_Jsonclick = "";
         edtCartaoPontosClienteId_Enabled = 1;
         imgPaisClienteBandeira_Enabled = 0;
         edtPaisClienteNome_Jsonclick = "";
         edtPaisClienteNome_Enabled = 0;
         imgprompt_11_Visible = 1;
         imgprompt_11_Link = "";
         edtPaisClienteId_Jsonclick = "";
         edtPaisClienteId_Enabled = 1;
         edtClienteEmail_Jsonclick = "";
         edtClienteEmail_Enabled = 1;
         edtClienteTelefone_Jsonclick = "";
         edtClienteTelefone_Enabled = 1;
         edtClienteEndereco_Enabled = 1;
         edtClienteNome_Jsonclick = "";
         edtClienteNome_Enabled = 1;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 1;
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
         chkClienteVIP.Name = "CLIENTEVIP";
         chkClienteVIP.WebTags = "";
         chkClienteVIP.Caption = "";
         AssignProp("", false, chkClienteVIP_Internalname, "TitleCaption", chkClienteVIP.Caption, true);
         chkClienteVIP.CheckedValue = "false";
         A67ClienteVIP = StringUtil.StrToBool( StringUtil.BoolToStr( A67ClienteVIP));
         AssignAttri("", false, "A67ClienteVIP", A67ClienteVIP);
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

      public void Valid_Paisclienteid( )
      {
         n40000PaisClienteBandeira_GXI = false;
         /* Using cursor T000C18 */
         pr_default.execute(14, new Object[] {A11PaisClienteId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISCLIENTEID");
            AnyError = 1;
            GX_FocusControl = edtPaisClienteId_Internalname;
         }
         A12PaisClienteNome = T000C18_A12PaisClienteNome[0];
         A40000PaisClienteBandeira_GXI = T000C18_A40000PaisClienteBandeira_GXI[0];
         n40000PaisClienteBandeira_GXI = T000C18_n40000PaisClienteBandeira_GXI[0];
         A69PaisClienteBandeira = T000C18_A69PaisClienteBandeira[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A12PaisClienteNome", A12PaisClienteNome);
         AssignAttri("", false, "A69PaisClienteBandeira", context.PathToRelativeUrl( A69PaisClienteBandeira));
         GXCCtlgxBlob = "PAISCLIENTEBANDEIRA" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A69PaisClienteBandeira));
         AssignAttri("", false, "A40000PaisClienteBandeira_GXI", A40000PaisClienteBandeira_GXI);
      }

      public void Valid_Cartaopontosclienteid( )
      {
         n48CartaoPontosClienteId = false;
         /* Using cursor T000C19 */
         pr_default.execute(15, new Object[] {n48CartaoPontosClienteId, A48CartaoPontosClienteId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A48CartaoPontosClienteId) ) )
            {
               GX_msglist.addItem("No matching 'Cartão'.", "ForeignKeyNotFound", 1, "CARTAOPONTOSCLIENTEID");
               AnyError = 1;
               GX_FocusControl = edtCartaoPontosClienteId_Internalname;
            }
         }
         A49CartaoPontosClienteDescricao = T000C19_A49CartaoPontosClienteDescricao[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ClienteId',fld:'vCLIENTEID',pic:'ZZZ9',hsh:true},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ClienteId',fld:'vCLIENTEID',pic:'ZZZ9',hsh:true},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E120C2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("VALID_CLIENTENOME","{handler:'Valid_Clientenome',iparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("VALID_CLIENTENOME",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("VALID_CLIENTEENDERECO","{handler:'Valid_Clienteendereco',iparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("VALID_CLIENTEENDERECO",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("VALID_CLIENTETELEFONE","{handler:'Valid_Clientetelefone',iparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("VALID_CLIENTETELEFONE",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("VALID_CLIENTEEMAIL","{handler:'Valid_Clienteemail',iparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("VALID_CLIENTEEMAIL",",oparms:[{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("VALID_PAISCLIENTEID","{handler:'Valid_Paisclienteid',iparms:[{av:'A11PaisClienteId',fld:'PAISCLIENTEID',pic:'ZZZ9'},{av:'A12PaisClienteNome',fld:'PAISCLIENTENOME',pic:''},{av:'A69PaisClienteBandeira',fld:'PAISCLIENTEBANDEIRA',pic:''},{av:'A40000PaisClienteBandeira_GXI',fld:'PAISCLIENTEBANDEIRA_GXI',pic:''},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("VALID_PAISCLIENTEID",",oparms:[{av:'A12PaisClienteNome',fld:'PAISCLIENTENOME',pic:''},{av:'A69PaisClienteBandeira',fld:'PAISCLIENTEBANDEIRA',pic:''},{av:'A40000PaisClienteBandeira_GXI',fld:'PAISCLIENTEBANDEIRA_GXI',pic:''},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
         setEventMetadata("VALID_CARTAOPONTOSCLIENTEID","{handler:'Valid_Cartaopontosclienteid',iparms:[{av:'A48CartaoPontosClienteId',fld:'CARTAOPONTOSCLIENTEID',pic:'ZZZ9'},{av:'A49CartaoPontosClienteDescricao',fld:'CARTAOPONTOSCLIENTEDESCRICAO',pic:''},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("VALID_CARTAOPONTOSCLIENTEID",",oparms:[{av:'A49CartaoPontosClienteDescricao',fld:'CARTAOPONTOSCLIENTEDESCRICAO',pic:''},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]}");
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
         pr_default.close(14);
         pr_default.close(15);
         pr_default.close(2);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z44ClienteNome = "";
         Z45ClienteEndereco = "";
         Z46ClienteTelefone = "";
         Z47ClienteEmail = "";
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
         A44ClienteNome = "";
         A45ClienteEndereco = "";
         gxphoneLink = "";
         A46ClienteTelefone = "";
         A47ClienteEmail = "";
         imgprompt_11_gximage = "";
         sImgUrl = "";
         A12PaisClienteNome = "";
         A69PaisClienteBandeira = "";
         A40000PaisClienteBandeira_GXI = "";
         imgprompt_48_gximage = "";
         A49CartaoPontosClienteDescricao = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV14Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode11 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV13TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z12PaisClienteNome = "";
         Z69PaisClienteBandeira = "";
         Z40000PaisClienteBandeira_GXI = "";
         Z49CartaoPontosClienteDescricao = "";
         T000C8_A49CartaoPontosClienteDescricao = new string[] {""} ;
         T000C7_A12PaisClienteNome = new string[] {""} ;
         T000C7_A40000PaisClienteBandeira_GXI = new string[] {""} ;
         T000C7_n40000PaisClienteBandeira_GXI = new bool[] {false} ;
         T000C7_A69PaisClienteBandeira = new string[] {""} ;
         T000C9_A43ClienteId = new short[1] ;
         T000C9_A44ClienteNome = new string[] {""} ;
         T000C9_A45ClienteEndereco = new string[] {""} ;
         T000C9_A46ClienteTelefone = new string[] {""} ;
         T000C9_A47ClienteEmail = new string[] {""} ;
         T000C9_A12PaisClienteNome = new string[] {""} ;
         T000C9_A40000PaisClienteBandeira_GXI = new string[] {""} ;
         T000C9_n40000PaisClienteBandeira_GXI = new bool[] {false} ;
         T000C9_A49CartaoPontosClienteDescricao = new string[] {""} ;
         T000C9_A11PaisClienteId = new short[1] ;
         T000C9_A48CartaoPontosClienteId = new short[1] ;
         T000C9_n48CartaoPontosClienteId = new bool[] {false} ;
         T000C9_A69PaisClienteBandeira = new string[] {""} ;
         T000C10_A12PaisClienteNome = new string[] {""} ;
         T000C10_A40000PaisClienteBandeira_GXI = new string[] {""} ;
         T000C10_n40000PaisClienteBandeira_GXI = new bool[] {false} ;
         T000C10_A69PaisClienteBandeira = new string[] {""} ;
         T000C11_A49CartaoPontosClienteDescricao = new string[] {""} ;
         T000C12_A43ClienteId = new short[1] ;
         T000C3_A43ClienteId = new short[1] ;
         T000C3_A44ClienteNome = new string[] {""} ;
         T000C3_A45ClienteEndereco = new string[] {""} ;
         T000C3_A46ClienteTelefone = new string[] {""} ;
         T000C3_A47ClienteEmail = new string[] {""} ;
         T000C3_A11PaisClienteId = new short[1] ;
         T000C3_A48CartaoPontosClienteId = new short[1] ;
         T000C3_n48CartaoPontosClienteId = new bool[] {false} ;
         T000C13_A43ClienteId = new short[1] ;
         T000C14_A43ClienteId = new short[1] ;
         T000C2_A43ClienteId = new short[1] ;
         T000C2_A44ClienteNome = new string[] {""} ;
         T000C2_A45ClienteEndereco = new string[] {""} ;
         T000C2_A46ClienteTelefone = new string[] {""} ;
         T000C2_A47ClienteEmail = new string[] {""} ;
         T000C2_A11PaisClienteId = new short[1] ;
         T000C2_A48CartaoPontosClienteId = new short[1] ;
         T000C2_n48CartaoPontosClienteId = new bool[] {false} ;
         T000C18_A12PaisClienteNome = new string[] {""} ;
         T000C18_A40000PaisClienteBandeira_GXI = new string[] {""} ;
         T000C18_n40000PaisClienteBandeira_GXI = new bool[] {false} ;
         T000C18_A69PaisClienteBandeira = new string[] {""} ;
         T000C19_A49CartaoPontosClienteDescricao = new string[] {""} ;
         T000C20_A52CarrinhoComprasId = new short[1] ;
         T000C21_A41CartaoPontosId = new short[1] ;
         T000C22_A43ClienteId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cliente__default(),
            new Object[][] {
                new Object[] {
               T000C2_A43ClienteId, T000C2_A44ClienteNome, T000C2_A45ClienteEndereco, T000C2_A46ClienteTelefone, T000C2_A47ClienteEmail, T000C2_A11PaisClienteId, T000C2_A48CartaoPontosClienteId, T000C2_n48CartaoPontosClienteId
               }
               , new Object[] {
               T000C3_A43ClienteId, T000C3_A44ClienteNome, T000C3_A45ClienteEndereco, T000C3_A46ClienteTelefone, T000C3_A47ClienteEmail, T000C3_A11PaisClienteId, T000C3_A48CartaoPontosClienteId, T000C3_n48CartaoPontosClienteId
               }
               , new Object[] {
               T000C6_A66CartaoPontosAcumulados, T000C6_n66CartaoPontosAcumulados
               }
               , new Object[] {
               T000C7_A12PaisClienteNome, T000C7_A40000PaisClienteBandeira_GXI, T000C7_n40000PaisClienteBandeira_GXI, T000C7_A69PaisClienteBandeira
               }
               , new Object[] {
               T000C8_A49CartaoPontosClienteDescricao
               }
               , new Object[] {
               T000C9_A43ClienteId, T000C9_A44ClienteNome, T000C9_A45ClienteEndereco, T000C9_A46ClienteTelefone, T000C9_A47ClienteEmail, T000C9_A12PaisClienteNome, T000C9_A40000PaisClienteBandeira_GXI, T000C9_n40000PaisClienteBandeira_GXI, T000C9_A49CartaoPontosClienteDescricao, T000C9_A11PaisClienteId,
               T000C9_A48CartaoPontosClienteId, T000C9_n48CartaoPontosClienteId, T000C9_A69PaisClienteBandeira
               }
               , new Object[] {
               T000C10_A12PaisClienteNome, T000C10_A40000PaisClienteBandeira_GXI, T000C10_n40000PaisClienteBandeira_GXI, T000C10_A69PaisClienteBandeira
               }
               , new Object[] {
               T000C11_A49CartaoPontosClienteDescricao
               }
               , new Object[] {
               T000C12_A43ClienteId
               }
               , new Object[] {
               T000C13_A43ClienteId
               }
               , new Object[] {
               T000C14_A43ClienteId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000C18_A12PaisClienteNome, T000C18_A40000PaisClienteBandeira_GXI, T000C18_n40000PaisClienteBandeira_GXI, T000C18_A69PaisClienteBandeira
               }
               , new Object[] {
               T000C19_A49CartaoPontosClienteDescricao
               }
               , new Object[] {
               T000C20_A52CarrinhoComprasId
               }
               , new Object[] {
               T000C21_A41CartaoPontosId
               }
               , new Object[] {
               T000C22_A43ClienteId
               }
            }
         );
         AV14Pgmname = "Cliente";
      }

      private short wcpOAV7ClienteId ;
      private short Z43ClienteId ;
      private short Z11PaisClienteId ;
      private short Z48CartaoPontosClienteId ;
      private short N11PaisClienteId ;
      private short N48CartaoPontosClienteId ;
      private short GxWebError ;
      private short A11PaisClienteId ;
      private short A48CartaoPontosClienteId ;
      private short AV7ClienteId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A43ClienteId ;
      private short AV11Insert_PaisClienteId ;
      private short AV12Insert_CartaoPontosClienteId ;
      private short A41CartaoPontosId ;
      private short RcdFound11 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_11 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtClienteId_Enabled ;
      private int edtClienteNome_Enabled ;
      private int edtClienteEndereco_Enabled ;
      private int edtClienteTelefone_Enabled ;
      private int edtClienteEmail_Enabled ;
      private int edtPaisClienteId_Enabled ;
      private int imgprompt_11_Visible ;
      private int edtPaisClienteNome_Enabled ;
      private int imgPaisClienteBandeira_Enabled ;
      private int edtCartaoPontosClienteId_Enabled ;
      private int imgprompt_48_Visible ;
      private int edtCartaoPontosClienteDescricao_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV15GXV1 ;
      private int idxLst ;
      private decimal A66CartaoPontosAcumulados ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z46ClienteTelefone ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtClienteId_Internalname ;
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
      private string edtClienteId_Jsonclick ;
      private string edtClienteNome_Internalname ;
      private string edtClienteNome_Jsonclick ;
      private string edtClienteEndereco_Internalname ;
      private string edtClienteTelefone_Internalname ;
      private string gxphoneLink ;
      private string A46ClienteTelefone ;
      private string edtClienteTelefone_Jsonclick ;
      private string edtClienteEmail_Internalname ;
      private string edtClienteEmail_Jsonclick ;
      private string edtPaisClienteId_Internalname ;
      private string edtPaisClienteId_Jsonclick ;
      private string imgprompt_11_gximage ;
      private string sImgUrl ;
      private string imgprompt_11_Internalname ;
      private string imgprompt_11_Link ;
      private string edtPaisClienteNome_Internalname ;
      private string edtPaisClienteNome_Jsonclick ;
      private string imgPaisClienteBandeira_Internalname ;
      private string edtCartaoPontosClienteId_Internalname ;
      private string edtCartaoPontosClienteId_Jsonclick ;
      private string imgprompt_48_gximage ;
      private string imgprompt_48_Internalname ;
      private string imgprompt_48_Link ;
      private string edtCartaoPontosClienteDescricao_Internalname ;
      private string edtCartaoPontosClienteDescricao_Jsonclick ;
      private string chkClienteVIP_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV14Pgmname ;
      private string hsh ;
      private string sMode11 ;
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
      private bool n48CartaoPontosClienteId ;
      private bool wbErr ;
      private bool A67ClienteVIP ;
      private bool A69PaisClienteBandeira_IsBlob ;
      private bool n66CartaoPontosAcumulados ;
      private bool returnInSub ;
      private bool n40000PaisClienteBandeira_GXI ;
      private bool Gx_longc ;
      private string Z44ClienteNome ;
      private string Z45ClienteEndereco ;
      private string Z47ClienteEmail ;
      private string A44ClienteNome ;
      private string A45ClienteEndereco ;
      private string A47ClienteEmail ;
      private string A12PaisClienteNome ;
      private string A40000PaisClienteBandeira_GXI ;
      private string A49CartaoPontosClienteDescricao ;
      private string Z12PaisClienteNome ;
      private string Z40000PaisClienteBandeira_GXI ;
      private string Z49CartaoPontosClienteDescricao ;
      private string A69PaisClienteBandeira ;
      private string Z69PaisClienteBandeira ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkClienteVIP ;
      private IDataStoreProvider pr_default ;
      private string[] T000C8_A49CartaoPontosClienteDescricao ;
      private string[] T000C7_A12PaisClienteNome ;
      private string[] T000C7_A40000PaisClienteBandeira_GXI ;
      private bool[] T000C7_n40000PaisClienteBandeira_GXI ;
      private string[] T000C7_A69PaisClienteBandeira ;
      private short[] T000C9_A43ClienteId ;
      private string[] T000C9_A44ClienteNome ;
      private string[] T000C9_A45ClienteEndereco ;
      private string[] T000C9_A46ClienteTelefone ;
      private string[] T000C9_A47ClienteEmail ;
      private string[] T000C9_A12PaisClienteNome ;
      private string[] T000C9_A40000PaisClienteBandeira_GXI ;
      private bool[] T000C9_n40000PaisClienteBandeira_GXI ;
      private string[] T000C9_A49CartaoPontosClienteDescricao ;
      private short[] T000C9_A11PaisClienteId ;
      private short[] T000C9_A48CartaoPontosClienteId ;
      private bool[] T000C9_n48CartaoPontosClienteId ;
      private string[] T000C9_A69PaisClienteBandeira ;
      private string[] T000C10_A12PaisClienteNome ;
      private string[] T000C10_A40000PaisClienteBandeira_GXI ;
      private bool[] T000C10_n40000PaisClienteBandeira_GXI ;
      private string[] T000C10_A69PaisClienteBandeira ;
      private string[] T000C11_A49CartaoPontosClienteDescricao ;
      private short[] T000C12_A43ClienteId ;
      private short[] T000C3_A43ClienteId ;
      private string[] T000C3_A44ClienteNome ;
      private string[] T000C3_A45ClienteEndereco ;
      private string[] T000C3_A46ClienteTelefone ;
      private string[] T000C3_A47ClienteEmail ;
      private short[] T000C3_A11PaisClienteId ;
      private short[] T000C3_A48CartaoPontosClienteId ;
      private bool[] T000C3_n48CartaoPontosClienteId ;
      private short[] T000C13_A43ClienteId ;
      private short[] T000C14_A43ClienteId ;
      private short[] T000C2_A43ClienteId ;
      private string[] T000C2_A44ClienteNome ;
      private string[] T000C2_A45ClienteEndereco ;
      private string[] T000C2_A46ClienteTelefone ;
      private string[] T000C2_A47ClienteEmail ;
      private short[] T000C2_A11PaisClienteId ;
      private short[] T000C2_A48CartaoPontosClienteId ;
      private bool[] T000C2_n48CartaoPontosClienteId ;
      private string[] T000C18_A12PaisClienteNome ;
      private string[] T000C18_A40000PaisClienteBandeira_GXI ;
      private bool[] T000C18_n40000PaisClienteBandeira_GXI ;
      private string[] T000C18_A69PaisClienteBandeira ;
      private string[] T000C19_A49CartaoPontosClienteDescricao ;
      private short[] T000C20_A52CarrinhoComprasId ;
      private short[] T000C21_A41CartaoPontosId ;
      private short[] T000C22_A43ClienteId ;
      private decimal[] T000C6_A66CartaoPontosAcumulados ;
      private bool[] T000C6_n66CartaoPontosAcumulados ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV13TrnContextAtt ;
   }

   public class cliente__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[8])
         ,new ForEachCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000C6;
          prmT000C6 = new Object[] {
          };
          Object[] prmT000C9;
          prmT000C9 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C7;
          prmT000C7 = new Object[] {
          new ParDef("@PaisClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C8;
          prmT000C8 = new Object[] {
          new ParDef("@CartaoPontosClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000C10;
          prmT000C10 = new Object[] {
          new ParDef("@PaisClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C11;
          prmT000C11 = new Object[] {
          new ParDef("@CartaoPontosClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000C12;
          prmT000C12 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C3;
          prmT000C3 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C13;
          prmT000C13 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C14;
          prmT000C14 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C2;
          prmT000C2 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C15;
          prmT000C15 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0) ,
          new ParDef("@ClienteNome",GXType.NVarChar,40,0) ,
          new ParDef("@ClienteEndereco",GXType.NVarChar,1024,0) ,
          new ParDef("@ClienteTelefone",GXType.NChar,20,0) ,
          new ParDef("@ClienteEmail",GXType.NVarChar,100,0) ,
          new ParDef("@PaisClienteId",GXType.Int16,4,0) ,
          new ParDef("@CartaoPontosClienteId",GXType.Int16,4,0){Nullable=true}
          };
          Object[] prmT000C16;
          prmT000C16 = new Object[] {
          new ParDef("@ClienteNome",GXType.NVarChar,40,0) ,
          new ParDef("@ClienteEndereco",GXType.NVarChar,1024,0) ,
          new ParDef("@ClienteTelefone",GXType.NChar,20,0) ,
          new ParDef("@ClienteEmail",GXType.NVarChar,100,0) ,
          new ParDef("@PaisClienteId",GXType.Int16,4,0) ,
          new ParDef("@CartaoPontosClienteId",GXType.Int16,4,0){Nullable=true} ,
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C17;
          prmT000C17 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C20;
          prmT000C20 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C21;
          prmT000C21 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C22;
          prmT000C22 = new Object[] {
          };
          Object[] prmT000C18;
          prmT000C18 = new Object[] {
          new ParDef("@PaisClienteId",GXType.Int16,4,0)
          };
          Object[] prmT000C19;
          prmT000C19 = new Object[] {
          new ParDef("@CartaoPontosClienteId",GXType.Int16,4,0){Nullable=true}
          };
          def= new CursorDef[] {
              new CursorDef("T000C2", "SELECT [ClienteId], [ClienteNome], [ClienteEndereco], [ClienteTelefone], [ClienteEmail], [PaisClienteId] AS PaisClienteId, [CartaoPontosClienteId] AS CartaoPontosClienteId FROM [Cliente] WITH (UPDLOCK) WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C3", "SELECT [ClienteId], [ClienteNome], [ClienteEndereco], [ClienteTelefone], [ClienteEmail], [PaisClienteId] AS PaisClienteId, [CartaoPontosClienteId] AS CartaoPontosClienteId FROM [Cliente] WHERE [ClienteId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C6", "SELECT COALESCE( T1.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (SELECT SUM(CASE  WHEN ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T3.[CartaoPontosClienteId] AS CartaoPontosClienteId FROM (([CarrinhoCompras] T2 INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T2.[CarrinhoComprasId]) GROUP BY T3.[CartaoPontosClienteId], T3.[CartaoPontosClienteId] ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C7", "SELECT [PaisNome] AS PaisClienteNome, [PaisBandeira_GXI] AS PaisClienteBandeira_GXI, [PaisBandeira] AS PaisClienteBandeira FROM [Pais] WHERE [PaisId] = @PaisClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C8", "SELECT [CartaoPontosDescricao] AS CartaoPontosClienteDescricao FROM [CartaoPontos] WHERE [CartaoPontosId] = @CartaoPontosClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C9", "SELECT TM1.[ClienteId], TM1.[ClienteNome], TM1.[ClienteEndereco], TM1.[ClienteTelefone], TM1.[ClienteEmail], T2.[PaisNome] AS PaisClienteNome, T2.[PaisBandeira_GXI] AS PaisClienteBandeira_GXI, T3.[CartaoPontosDescricao] AS CartaoPontosClienteDescricao, TM1.[PaisClienteId] AS PaisClienteId, TM1.[CartaoPontosClienteId] AS CartaoPontosClienteId, T2.[PaisBandeira] AS PaisClienteBandeira FROM (([Cliente] TM1 INNER JOIN [Pais] T2 ON T2.[PaisId] = TM1.[PaisClienteId]) LEFT JOIN [CartaoPontos] T3 ON T3.[CartaoPontosId] = TM1.[CartaoPontosClienteId]) WHERE TM1.[ClienteId] = @ClienteId ORDER BY TM1.[ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C9,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C10", "SELECT [PaisNome] AS PaisClienteNome, [PaisBandeira_GXI] AS PaisClienteBandeira_GXI, [PaisBandeira] AS PaisClienteBandeira FROM [Pais] WHERE [PaisId] = @PaisClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C10,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C11", "SELECT [CartaoPontosDescricao] AS CartaoPontosClienteDescricao FROM [CartaoPontos] WHERE [CartaoPontosId] = @CartaoPontosClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C12", "SELECT [ClienteId] FROM [Cliente] WHERE [ClienteId] = @ClienteId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C12,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C13", "SELECT TOP 1 [ClienteId] FROM [Cliente] WHERE ( [ClienteId] > @ClienteId) ORDER BY [ClienteId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C13,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C14", "SELECT TOP 1 [ClienteId] FROM [Cliente] WHERE ( [ClienteId] < @ClienteId) ORDER BY [ClienteId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C14,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C15", "INSERT INTO [Cliente]([ClienteId], [ClienteNome], [ClienteEndereco], [ClienteTelefone], [ClienteEmail], [PaisClienteId], [CartaoPontosClienteId]) VALUES(@ClienteId, @ClienteNome, @ClienteEndereco, @ClienteTelefone, @ClienteEmail, @PaisClienteId, @CartaoPontosClienteId)", GxErrorMask.GX_NOMASK,prmT000C15)
             ,new CursorDef("T000C16", "UPDATE [Cliente] SET [ClienteNome]=@ClienteNome, [ClienteEndereco]=@ClienteEndereco, [ClienteTelefone]=@ClienteTelefone, [ClienteEmail]=@ClienteEmail, [PaisClienteId]=@PaisClienteId, [CartaoPontosClienteId]=@CartaoPontosClienteId  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000C16)
             ,new CursorDef("T000C17", "DELETE FROM [Cliente]  WHERE [ClienteId] = @ClienteId", GxErrorMask.GX_NOMASK,prmT000C17)
             ,new CursorDef("T000C18", "SELECT [PaisNome] AS PaisClienteNome, [PaisBandeira_GXI] AS PaisClienteBandeira_GXI, [PaisBandeira] AS PaisClienteBandeira FROM [Pais] WHERE [PaisId] = @PaisClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C19", "SELECT [CartaoPontosDescricao] AS CartaoPontosClienteDescricao FROM [CartaoPontos] WHERE [CartaoPontosId] = @CartaoPontosClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C19,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000C20", "SELECT TOP 1 [CarrinhoComprasId] FROM [CarrinhoCompras] WHERE [ClienteCarrinhoComprasId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C21", "SELECT TOP 1 [CartaoPontosId] FROM [CartaoPontos] WHERE [ClienteCartaoPontosId] = @ClienteId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000C21,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000C22", "SELECT [ClienteId] FROM [Cliente] ORDER BY [ClienteId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000C22,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getString(4, 20);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((short[]) buf[10])[0] = rslt.getShort(10);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(7));
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
