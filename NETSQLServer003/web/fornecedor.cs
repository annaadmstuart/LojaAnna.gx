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
   public class fornecedor : GXDataArea
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
               AV7FornecedorId = (short)(NumberUtil.Val( GetPar( "FornecedorId"), "."));
               AssignAttri("", false, "AV7FornecedorId", StringUtil.LTrimStr( (decimal)(AV7FornecedorId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vFORNECEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FornecedorId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Fornecedor", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtFornecedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public fornecedor( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public fornecedor( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_FornecedorId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7FornecedorId = aP1_FornecedorId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Fornecedor", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Fornecedor.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Fornecedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Fornecedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Fornecedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Fornecedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Fornecedor.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFornecedorId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFornecedorId_Internalname, "Fornecedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFornecedorId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A17FornecedorId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A17FornecedorId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFornecedorId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFornecedorId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Fornecedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFornecedorNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFornecedorNome_Internalname, "Nome", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFornecedorNome_Internalname, A18FornecedorNome, StringUtil.RTrim( context.localUtil.Format( A18FornecedorNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFornecedorNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFornecedorNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Fornecedor.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Fornecedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Fornecedor.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Fornecedor.htm");
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
         E11052 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z17FornecedorId = (short)(context.localUtil.CToN( cgiGet( "Z17FornecedorId"), ".", ","));
               Z18FornecedorNome = cgiGet( "Z18FornecedorNome");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               AV7FornecedorId = (short)(context.localUtil.CToN( cgiGet( "vFORNECEDORID"), ".", ","));
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtFornecedorId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFornecedorId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORNECEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtFornecedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A17FornecedorId = 0;
                  AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
               }
               else
               {
                  A17FornecedorId = (short)(context.localUtil.CToN( cgiGet( edtFornecedorId_Internalname), ".", ","));
                  AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
               }
               A18FornecedorNome = cgiGet( edtFornecedorNome_Internalname);
               AssignAttri("", false, "A18FornecedorNome", A18FornecedorNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Fornecedor");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A17FornecedorId != Z17FornecedorId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("fornecedor:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A17FornecedorId = (short)(NumberUtil.Val( GetPar( "FornecedorId"), "."));
                  AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
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
                     sMode5 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode5;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound5 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_050( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "FORNECEDORID");
                        AnyError = 1;
                        GX_FocusControl = edtFornecedorId_Internalname;
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
                           E11052 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12052 ();
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
            E12052 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll055( ) ;
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
            DisableAttributes055( ) ;
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

      protected void CONFIRM_050( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls055( ) ;
            }
            else
            {
               CheckExtendedTable055( ) ;
               CloseExtendedTableCursors055( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption050( )
      {
      }

      protected void E11052( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12052( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwfornecedor.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM055( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z18FornecedorNome = T00053_A18FornecedorNome[0];
            }
            else
            {
               Z18FornecedorNome = A18FornecedorNome;
            }
         }
         if ( GX_JID == -4 )
         {
            Z17FornecedorId = A17FornecedorId;
            Z18FornecedorNome = A18FornecedorNome;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7FornecedorId) )
         {
            A17FornecedorId = AV7FornecedorId;
            AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
         }
         if ( ! (0==AV7FornecedorId) )
         {
            edtFornecedorId_Enabled = 0;
            AssignProp("", false, edtFornecedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorId_Enabled), 5, 0), true);
         }
         else
         {
            edtFornecedorId_Enabled = 1;
            AssignProp("", false, edtFornecedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7FornecedorId) )
         {
            edtFornecedorId_Enabled = 0;
            AssignProp("", false, edtFornecedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
            AV11Pgmname = "Fornecedor";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void Load055( )
      {
         /* Using cursor T00054 */
         pr_default.execute(2, new Object[] {A17FornecedorId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound5 = 1;
            A18FornecedorNome = T00054_A18FornecedorNome[0];
            AssignAttri("", false, "A18FornecedorNome", A18FornecedorNome);
            ZM055( -4) ;
         }
         pr_default.close(2);
         OnLoadActions055( ) ;
      }

      protected void OnLoadActions055( )
      {
         AV11Pgmname = "Fornecedor";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable055( )
      {
         nIsDirty_5 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Fornecedor";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         /* Using cursor T00055 */
         pr_default.execute(3, new Object[] {A18FornecedorNome, A17FornecedorId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Nome"}), 1, "FORNECEDORNOME");
            AnyError = 1;
            GX_FocusControl = edtFornecedorNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors055( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey055( )
      {
         /* Using cursor T00056 */
         pr_default.execute(4, new Object[] {A17FornecedorId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound5 = 1;
         }
         else
         {
            RcdFound5 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00053 */
         pr_default.execute(1, new Object[] {A17FornecedorId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM055( 4) ;
            RcdFound5 = 1;
            A17FornecedorId = T00053_A17FornecedorId[0];
            AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
            A18FornecedorNome = T00053_A18FornecedorNome[0];
            AssignAttri("", false, "A18FornecedorNome", A18FornecedorNome);
            Z17FornecedorId = A17FornecedorId;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load055( ) ;
            if ( AnyError == 1 )
            {
               RcdFound5 = 0;
               InitializeNonKey055( ) ;
            }
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound5 = 0;
            InitializeNonKey055( ) ;
            sMode5 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode5;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey055( ) ;
         if ( RcdFound5 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound5 = 0;
         /* Using cursor T00057 */
         pr_default.execute(5, new Object[] {A17FornecedorId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00057_A17FornecedorId[0] < A17FornecedorId ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00057_A17FornecedorId[0] > A17FornecedorId ) ) )
            {
               A17FornecedorId = T00057_A17FornecedorId[0];
               AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound5 = 0;
         /* Using cursor T00058 */
         pr_default.execute(6, new Object[] {A17FornecedorId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00058_A17FornecedorId[0] > A17FornecedorId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00058_A17FornecedorId[0] < A17FornecedorId ) ) )
            {
               A17FornecedorId = T00058_A17FornecedorId[0];
               AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
               RcdFound5 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey055( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtFornecedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert055( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound5 == 1 )
            {
               if ( A17FornecedorId != Z17FornecedorId )
               {
                  A17FornecedorId = Z17FornecedorId;
                  AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "FORNECEDORID");
                  AnyError = 1;
                  GX_FocusControl = edtFornecedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtFornecedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update055( ) ;
                  GX_FocusControl = edtFornecedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A17FornecedorId != Z17FornecedorId )
               {
                  /* Insert record */
                  GX_FocusControl = edtFornecedorId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert055( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "FORNECEDORID");
                     AnyError = 1;
                     GX_FocusControl = edtFornecedorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtFornecedorId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert055( ) ;
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
         if ( A17FornecedorId != Z17FornecedorId )
         {
            A17FornecedorId = Z17FornecedorId;
            AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "FORNECEDORID");
            AnyError = 1;
            GX_FocusControl = edtFornecedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtFornecedorId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency055( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00052 */
            pr_default.execute(0, new Object[] {A17FornecedorId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Fornecedor"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18FornecedorNome, T00052_A18FornecedorNome[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z18FornecedorNome, T00052_A18FornecedorNome[0]) != 0 )
               {
                  GXUtil.WriteLog("fornecedor:[seudo value changed for attri]"+"FornecedorNome");
                  GXUtil.WriteLogRaw("Old: ",Z18FornecedorNome);
                  GXUtil.WriteLogRaw("Current: ",T00052_A18FornecedorNome[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Fornecedor"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM055( 0) ;
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00059 */
                     pr_default.execute(7, new Object[] {A17FornecedorId, A18FornecedorNome});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("Fornecedor");
                     if ( (pr_default.getStatus(7) == 1) )
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
                           ResetCaption050( ) ;
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
               Load055( ) ;
            }
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void Update055( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable055( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm055( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate055( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000510 */
                     pr_default.execute(8, new Object[] {A18FornecedorNome, A17FornecedorId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("Fornecedor");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Fornecedor"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate055( ) ;
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
            EndLevel055( ) ;
         }
         CloseExtendedTableCursors055( ) ;
      }

      protected void DeferredUpdate055( )
      {
      }

      protected void delete( )
      {
         BeforeValidate055( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency055( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls055( ) ;
            AfterConfirm055( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete055( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000511 */
                  pr_default.execute(9, new Object[] {A17FornecedorId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("Fornecedor");
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
         sMode5 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel055( ) ;
         Gx_mode = sMode5;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls055( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Fornecedor";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000512 */
            pr_default.execute(10, new Object[] {A17FornecedorId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Produto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel055( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete055( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            context.CommitDataStores("fornecedor",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues050( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            context.RollbackDataStores("fornecedor",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart055( )
      {
         /* Scan By routine */
         /* Using cursor T000513 */
         pr_default.execute(11);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A17FornecedorId = T000513_A17FornecedorId[0];
            AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext055( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound5 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound5 = 1;
            A17FornecedorId = T000513_A17FornecedorId[0];
            AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
         }
      }

      protected void ScanEnd055( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm055( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert055( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate055( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete055( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete055( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate055( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes055( )
      {
         edtFornecedorId_Enabled = 0;
         AssignProp("", false, edtFornecedorId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorId_Enabled), 5, 0), true);
         edtFornecedorNome_Enabled = 0;
         AssignProp("", false, edtFornecedorNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes055( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues050( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("fornecedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7FornecedorId,4,0))}, new string[] {"Gx_mode","FornecedorId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Fornecedor");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("fornecedor:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z17FornecedorId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z17FornecedorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z18FornecedorNome", Z18FornecedorNome);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
         GxWebStd.gx_hidden_field( context, "vFORNECEDORID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7FornecedorId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vFORNECEDORID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7FornecedorId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
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
         return formatLink("fornecedor.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7FornecedorId,4,0))}, new string[] {"Gx_mode","FornecedorId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Fornecedor" ;
      }

      public override string GetPgmdesc( )
      {
         return "Fornecedor" ;
      }

      protected void InitializeNonKey055( )
      {
         A18FornecedorNome = "";
         AssignAttri("", false, "A18FornecedorNome", A18FornecedorNome);
         Z18FornecedorNome = "";
      }

      protected void InitAll055( )
      {
         A17FornecedorId = 0;
         AssignAttri("", false, "A17FornecedorId", StringUtil.LTrimStr( (decimal)(A17FornecedorId), 4, 0));
         InitializeNonKey055( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513545", true, true);
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
         context.AddJavascriptSource("fornecedor.js", "?202582916513545", false, true);
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
         edtFornecedorId_Internalname = "FORNECEDORID";
         edtFornecedorNome_Internalname = "FORNECEDORNOME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
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
         Form.Caption = "Fornecedor";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtFornecedorNome_Jsonclick = "";
         edtFornecedorNome_Enabled = 1;
         edtFornecedorId_Jsonclick = "";
         edtFornecedorId_Enabled = 1;
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

      public void Valid_Fornecedornome( )
      {
         /* Using cursor T000514 */
         pr_default.execute(12, new Object[] {A18FornecedorNome, A17FornecedorId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Nome"}), 1, "FORNECEDORNOME");
            AnyError = 1;
            GX_FocusControl = edtFornecedorNome_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7FornecedorId',fld:'vFORNECEDORID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7FornecedorId',fld:'vFORNECEDORID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12052',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_FORNECEDORID","{handler:'Valid_Fornecedorid',iparms:[]");
         setEventMetadata("VALID_FORNECEDORID",",oparms:[]}");
         setEventMetadata("VALID_FORNECEDORNOME","{handler:'Valid_Fornecedornome',iparms:[{av:'A18FornecedorNome',fld:'FORNECEDORNOME',pic:''},{av:'A17FornecedorId',fld:'FORNECEDORID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_FORNECEDORNOME",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z18FornecedorNome = "";
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
         A18FornecedorNome = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode5 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         T00054_A17FornecedorId = new short[1] ;
         T00054_A18FornecedorNome = new string[] {""} ;
         T00055_A18FornecedorNome = new string[] {""} ;
         T00056_A17FornecedorId = new short[1] ;
         T00053_A17FornecedorId = new short[1] ;
         T00053_A18FornecedorNome = new string[] {""} ;
         T00057_A17FornecedorId = new short[1] ;
         T00058_A17FornecedorId = new short[1] ;
         T00052_A17FornecedorId = new short[1] ;
         T00052_A18FornecedorNome = new string[] {""} ;
         T000512_A19ProdutoId = new short[1] ;
         T000513_A17FornecedorId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000514_A18FornecedorNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.fornecedor__default(),
            new Object[][] {
                new Object[] {
               T00052_A17FornecedorId, T00052_A18FornecedorNome
               }
               , new Object[] {
               T00053_A17FornecedorId, T00053_A18FornecedorNome
               }
               , new Object[] {
               T00054_A17FornecedorId, T00054_A18FornecedorNome
               }
               , new Object[] {
               T00055_A18FornecedorNome
               }
               , new Object[] {
               T00056_A17FornecedorId
               }
               , new Object[] {
               T00057_A17FornecedorId
               }
               , new Object[] {
               T00058_A17FornecedorId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000512_A19ProdutoId
               }
               , new Object[] {
               T000513_A17FornecedorId
               }
               , new Object[] {
               T000514_A18FornecedorNome
               }
            }
         );
         AV11Pgmname = "Fornecedor";
      }

      private short wcpOAV7FornecedorId ;
      private short Z17FornecedorId ;
      private short GxWebError ;
      private short AV7FornecedorId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A17FornecedorId ;
      private short RcdFound5 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_5 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtFornecedorId_Enabled ;
      private int edtFornecedorNome_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
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
      private string edtFornecedorId_Internalname ;
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
      private string edtFornecedorId_Jsonclick ;
      private string edtFornecedorNome_Internalname ;
      private string edtFornecedorNome_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode5 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string Z18FornecedorNome ;
      private string A18FornecedorNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00054_A17FornecedorId ;
      private string[] T00054_A18FornecedorNome ;
      private string[] T00055_A18FornecedorNome ;
      private short[] T00056_A17FornecedorId ;
      private short[] T00053_A17FornecedorId ;
      private string[] T00053_A18FornecedorNome ;
      private short[] T00057_A17FornecedorId ;
      private short[] T00058_A17FornecedorId ;
      private short[] T00052_A17FornecedorId ;
      private string[] T00052_A18FornecedorNome ;
      private short[] T000512_A19ProdutoId ;
      private short[] T000513_A17FornecedorId ;
      private string[] T000514_A18FornecedorNome ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class fornecedor__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[7])
         ,new UpdateCursor(def[8])
         ,new UpdateCursor(def[9])
         ,new ForEachCursor(def[10])
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00054;
          prmT00054 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT00055;
          prmT00055 = new Object[] {
          new ParDef("@FornecedorNome",GXType.NVarChar,40,0) ,
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT00056;
          prmT00056 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT00053;
          prmT00053 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT00057;
          prmT00057 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT00058;
          prmT00058 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT00052;
          prmT00052 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT00059;
          prmT00059 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0) ,
          new ParDef("@FornecedorNome",GXType.NVarChar,40,0)
          };
          Object[] prmT000510;
          prmT000510 = new Object[] {
          new ParDef("@FornecedorNome",GXType.NVarChar,40,0) ,
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT000511;
          prmT000511 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT000512;
          prmT000512 = new Object[] {
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          Object[] prmT000513;
          prmT000513 = new Object[] {
          };
          Object[] prmT000514;
          prmT000514 = new Object[] {
          new ParDef("@FornecedorNome",GXType.NVarChar,40,0) ,
          new ParDef("@FornecedorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00052", "SELECT [FornecedorId], [FornecedorNome] FROM [Fornecedor] WITH (UPDLOCK) WHERE [FornecedorId] = @FornecedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00052,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00053", "SELECT [FornecedorId], [FornecedorNome] FROM [Fornecedor] WHERE [FornecedorId] = @FornecedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00053,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00054", "SELECT TM1.[FornecedorId], TM1.[FornecedorNome] FROM [Fornecedor] TM1 WHERE TM1.[FornecedorId] = @FornecedorId ORDER BY TM1.[FornecedorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00054,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00055", "SELECT [FornecedorNome] FROM [Fornecedor] WHERE ([FornecedorNome] = @FornecedorNome) AND (Not ( [FornecedorId] = @FornecedorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00055,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00056", "SELECT [FornecedorId] FROM [Fornecedor] WHERE [FornecedorId] = @FornecedorId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00056,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00057", "SELECT TOP 1 [FornecedorId] FROM [Fornecedor] WHERE ( [FornecedorId] > @FornecedorId) ORDER BY [FornecedorId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00057,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00058", "SELECT TOP 1 [FornecedorId] FROM [Fornecedor] WHERE ( [FornecedorId] < @FornecedorId) ORDER BY [FornecedorId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00058,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T00059", "INSERT INTO [Fornecedor]([FornecedorId], [FornecedorNome]) VALUES(@FornecedorId, @FornecedorNome)", GxErrorMask.GX_NOMASK,prmT00059)
             ,new CursorDef("T000510", "UPDATE [Fornecedor] SET [FornecedorNome]=@FornecedorNome  WHERE [FornecedorId] = @FornecedorId", GxErrorMask.GX_NOMASK,prmT000510)
             ,new CursorDef("T000511", "DELETE FROM [Fornecedor]  WHERE [FornecedorId] = @FornecedorId", GxErrorMask.GX_NOMASK,prmT000511)
             ,new CursorDef("T000512", "SELECT TOP 1 [ProdutoId] FROM [Produto] WHERE [FornecedorProdutoId] = @FornecedorId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000512,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000513", "SELECT [FornecedorId] FROM [Fornecedor] ORDER BY [FornecedorId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000513,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000514", "SELECT [FornecedorNome] FROM [Fornecedor] WHERE ([FornecedorNome] = @FornecedorNome) AND (Not ( [FornecedorId] = @FornecedorId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000514,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 11 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 12 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
