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
   public class carrinhocompras : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_20") == 0 )
         {
            A52CarrinhoComprasId = (short)(NumberUtil.Val( GetPar( "CarrinhoComprasId"), "."));
            AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_20( A52CarrinhoComprasId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A54ClienteCarrinhoComprasId = (short)(NumberUtil.Val( GetPar( "ClienteCarrinhoComprasId"), "."));
            AssignAttri("", false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A54ClienteCarrinhoComprasId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_19") == 0 )
         {
            A57ClienteCarrinhoComprasPaisId = (short)(NumberUtil.Val( GetPar( "ClienteCarrinhoComprasPaisId"), "."));
            AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_19( A57ClienteCarrinhoComprasPaisId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A19ProdutoId = (short)(NumberUtil.Val( GetPar( "ProdutoId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A19ProdutoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A30CategoriaProdutoId = (short)(NumberUtil.Val( GetPar( "CategoriaProdutoId"), "."));
            AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A30CategoriaProdutoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridcarrinhocompras_produtos") == 0 )
         {
            gxnrGridcarrinhocompras_produtos_newrow_invoke( ) ;
            return  ;
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
               AV7CarrinhoComprasId = (short)(NumberUtil.Val( GetPar( "CarrinhoComprasId"), "."));
               AssignAttri("", false, "AV7CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(AV7CarrinhoComprasId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCARRINHOCOMPRASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CarrinhoComprasId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Carrinho de compras", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCarrinhoComprasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridcarrinhocompras_produtos_newrow_invoke( )
      {
         nRC_GXsfl_88 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_88"), "."));
         nGXsfl_88_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_88_idx"), "."));
         sGXsfl_88_idx = GetPar( "sGXsfl_88_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridcarrinhocompras_produtos_newrow( ) ;
         /* End function gxnrGridcarrinhocompras_produtos_newrow_invoke */
      }

      public carrinhocompras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public carrinhocompras( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_CarrinhoComprasId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CarrinhoComprasId = aP1_CarrinhoComprasId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Carrinho de compras", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_CarrinhoCompras.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CarrinhoCompras.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCarrinhoComprasId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarrinhoComprasId_Internalname, "compras", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarrinhoComprasId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCarrinhoComprasData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarrinhoComprasData_Internalname, "Data", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCarrinhoComprasData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasData_Internalname, context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"), context.localUtil.Format( A53CarrinhoComprasData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasData_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarrinhoComprasData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_bitmap( context, edtCarrinhoComprasData_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarrinhoComprasData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarrinhoCompras.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteCarrinhoComprasId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasId_Internalname, "Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A54ClienteCarrinhoComprasId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A54ClienteCarrinhoComprasId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCarrinhoComprasId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CarrinhoCompras.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_54_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_54_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_54_Internalname, sImgUrl, imgprompt_54_Link, "", "", context.GetTheme( ), imgprompt_54_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteCarrinhoComprasNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasNome_Internalname, "Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasNome_Internalname, A55ClienteCarrinhoComprasNome, StringUtil.RTrim( context.localUtil.Format( A55ClienteCarrinhoComprasNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCarrinhoComprasNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteCarrinhoComprasEndereco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasEndereco_Internalname, "Endereço", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtClienteCarrinhoComprasEndereco_Internalname, A56ClienteCarrinhoComprasEndereco, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A56ClienteCarrinhoComprasEndereco), "", 0, 1, edtClienteCarrinhoComprasEndereco_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+""+"'"+",false,"+"'"+""+"'", 0, "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteCarrinhoComprasPaisId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasPaisId_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0, ".", "")), StringUtil.LTrim( ((edtClienteCarrinhoComprasPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A57ClienteCarrinhoComprasPaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A57ClienteCarrinhoComprasPaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasPaisId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCarrinhoComprasPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteCarrinhoComprasPaisNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasPaisNome_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasPaisNome_Internalname, A58ClienteCarrinhoComprasPaisNome, StringUtil.RTrim( context.localUtil.Format( A58ClienteCarrinhoComprasPaisNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasPaisNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCarrinhoComprasPaisNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCarrinhoComprasPrecoTotal_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarrinhoComprasPrecoTotal_Internalname, "total", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasPrecoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A62CarrinhoComprasPrecoTotal, 10, 2, ".", "")), StringUtil.LTrim( ((edtCarrinhoComprasPrecoTotal_Enabled!=0) ? context.localUtil.Format( A62CarrinhoComprasPrecoTotal, "ZZZZZZ9.99") : context.localUtil.Format( A62CarrinhoComprasPrecoTotal, "ZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasPrecoTotal_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarrinhoComprasPrecoTotal_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCarrinhoComprasDataEntrega_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarrinhoComprasDataEntrega_Internalname, "de entrega", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtCarrinhoComprasDataEntrega_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasDataEntrega_Internalname, context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"), context.localUtil.Format( A63CarrinhoComprasDataEntrega, "99/99/99"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasDataEntrega_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarrinhoComprasDataEntrega_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_bitmap( context, edtCarrinhoComprasDataEntrega_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarrinhoComprasDataEntrega_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarrinhoCompras.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCarrinhoComprasPontos_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCarrinhoComprasPontos_Internalname, "Compras Pontos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasPontos_Internalname, StringUtil.LTrim( StringUtil.NToC( A65CarrinhoComprasPontos, 10, 2, ".", "")), StringUtil.LTrim( ((edtCarrinhoComprasPontos_Enabled!=0) ? context.localUtil.Format( A65CarrinhoComprasPontos, "ZZZZZZ9.99") : context.localUtil.Format( A65CarrinhoComprasPontos, "ZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasPontos_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCarrinhoComprasPontos_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProdutostable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleprodutos_Internalname, "Produtos", "", "", lblTitleprodutos_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridcarrinhocompras_produtos( ) ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CarrinhoCompras.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridcarrinhocompras_produtos( )
      {
         /*  Grid Control  */
         StartGridControl88( ) ;
         nGXsfl_88_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount13 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_13 = 1;
               ScanStart0D13( ) ;
               while ( RcdFound13 != 0 )
               {
                  init_level_properties13( ) ;
                  getByPrimaryKey0D13( ) ;
                  AddRow0D13( ) ;
                  ScanNext0D13( ) ;
               }
               ScanEnd0D13( ) ;
               nBlankRcdCount13 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            standaloneNotModal0D13( ) ;
            standaloneModal0D13( ) ;
            sMode13 = Gx_mode;
            while ( nGXsfl_88_idx < nRC_GXsfl_88 )
            {
               bGXsfl_88_Refreshing = true;
               ReadRow0D13( ) ;
               edtProdutoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOID_"+sGXsfl_88_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProdutoNome_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTONOME_"+sGXsfl_88_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoNome_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProdutoPreco_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOPRECO_"+sGXsfl_88_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdutoPreco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoPreco_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProdutoImagem_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOIMAGEM_"+sGXsfl_88_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdutoImagem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoImagem_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtCarrinhoComprasProdutosQuantid_Enabled = (int)(context.localUtil.CToN( cgiGet( "CARRINHOCOMPRASPRODUTOSQUANTID_"+sGXsfl_88_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtCarrinhoComprasProdutosQuantid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasProdutosQuantid_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               edtProdutosPrecoTotal_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOSPRECOTOTAL_"+sGXsfl_88_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdutosPrecoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutosPrecoTotal_Enabled), 5, 0), !bGXsfl_88_Refreshing);
               imgprompt_54_Link = cgiGet( "PROMPT_19_"+sGXsfl_88_idx+"Link");
               if ( ( nRcdExists_13 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0D13( ) ;
               }
               SendRow0D13( ) ;
               bGXsfl_88_Refreshing = false;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A62CarrinhoComprasPrecoTotal = B62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount13 = 5;
            nRcdExists_13 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0D13( ) ;
               while ( RcdFound13 != 0 )
               {
                  sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_8813( ) ;
                  init_level_properties13( ) ;
                  standaloneNotModal0D13( ) ;
                  getByPrimaryKey0D13( ) ;
                  standaloneModal0D13( ) ;
                  AddRow0D13( ) ;
                  ScanNext0D13( ) ;
               }
               ScanEnd0D13( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode13 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx+1), 4, 0), 4, "0");
            SubsflControlProps_8813( ) ;
            InitAll0D13( ) ;
            init_level_properties13( ) ;
            B62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            nRcdExists_13 = 0;
            nIsMod_13 = 0;
            nRcdDeleted_13 = 0;
            nBlankRcdCount13 = (short)(nBlankRcdUsr13+nBlankRcdCount13);
            fRowAdded = 0;
            while ( nBlankRcdCount13 > 0 )
            {
               standaloneNotModal0D13( ) ;
               standaloneModal0D13( ) ;
               AddRow0D13( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount13 = (short)(nBlankRcdCount13-1);
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A62CarrinhoComprasPrecoTotal = B62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridcarrinhocompras_produtosContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridcarrinhocompras_produtos", Gridcarrinhocompras_produtosContainer, subGridcarrinhocompras_produtos_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcarrinhocompras_produtosContainerData", Gridcarrinhocompras_produtosContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridcarrinhocompras_produtosContainerData"+"V", Gridcarrinhocompras_produtosContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridcarrinhocompras_produtosContainerData"+"V"+"\" value='"+Gridcarrinhocompras_produtosContainer.GridValuesHidden()+"'/>") ;
         }
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
         E110D2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z52CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( "Z52CarrinhoComprasId"), ".", ","));
               Z53CarrinhoComprasData = context.localUtil.CToD( cgiGet( "Z53CarrinhoComprasData"), 0);
               Z54ClienteCarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( "Z54ClienteCarrinhoComprasId"), ".", ","));
               O62CarrinhoComprasPrecoTotal = context.localUtil.CToN( cgiGet( "O62CarrinhoComprasPrecoTotal"), ".", ",");
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_88 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_88"), ".", ","));
               N54ClienteCarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( "N54ClienteCarrinhoComprasId"), ".", ","));
               AV7CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( "vCARRINHOCOMPRASID"), ".", ","));
               AV11Insert_ClienteCarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTECARRINHOCOMPRASID"), ".", ","));
               Gx_date = context.localUtil.CToD( cgiGet( "vTODAY"), 0);
               Gx_BScreen = (short)(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ".", ","));
               AV15Pgmname = cgiGet( "vPGMNAME");
               A31CategoriaProdutoNome = cgiGet( "CATEGORIAPRODUTONOME");
               A30CategoriaProdutoId = (short)(context.localUtil.CToN( cgiGet( "CATEGORIAPRODUTOID"), ".", ","));
               A40000ProdutoImagem_GXI = cgiGet( "PRODUTOIMAGEM_GXI");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtCarrinhoComprasId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCarrinhoComprasId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CARRINHOCOMPRASID");
                  AnyError = 1;
                  GX_FocusControl = edtCarrinhoComprasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A52CarrinhoComprasId = 0;
                  AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
               }
               else
               {
                  A52CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( edtCarrinhoComprasId_Internalname), ".", ","));
                  AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
               }
               if ( context.localUtil.VCDate( cgiGet( edtCarrinhoComprasData_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data"}), 1, "CARRINHOCOMPRASDATA");
                  AnyError = 1;
                  GX_FocusControl = edtCarrinhoComprasData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A53CarrinhoComprasData = DateTime.MinValue;
                  AssignAttri("", false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
               }
               else
               {
                  A53CarrinhoComprasData = context.localUtil.CToD( cgiGet( edtCarrinhoComprasData_Internalname), 1);
                  AssignAttri("", false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTECARRINHOCOMPRASID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteCarrinhoComprasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A54ClienteCarrinhoComprasId = 0;
                  AssignAttri("", false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
               }
               else
               {
                  A54ClienteCarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasId_Internalname), ".", ","));
                  AssignAttri("", false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
               }
               A55ClienteCarrinhoComprasNome = cgiGet( edtClienteCarrinhoComprasNome_Internalname);
               AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
               A56ClienteCarrinhoComprasEndereco = cgiGet( edtClienteCarrinhoComprasEndereco_Internalname);
               AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
               A57ClienteCarrinhoComprasPaisId = (short)(context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasPaisId_Internalname), ".", ","));
               AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
               A58ClienteCarrinhoComprasPaisNome = cgiGet( edtClienteCarrinhoComprasPaisNome_Internalname);
               AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
               A62CarrinhoComprasPrecoTotal = context.localUtil.CToN( cgiGet( edtCarrinhoComprasPrecoTotal_Internalname), ".", ",");
               n62CarrinhoComprasPrecoTotal = false;
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               A63CarrinhoComprasDataEntrega = context.localUtil.CToD( cgiGet( edtCarrinhoComprasDataEntrega_Internalname), 1);
               AssignAttri("", false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
               A65CarrinhoComprasPontos = context.localUtil.CToN( cgiGet( edtCarrinhoComprasPontos_Internalname), ".", ",");
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CarrinhoCompras");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A52CarrinhoComprasId != Z52CarrinhoComprasId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("carrinhocompras:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A52CarrinhoComprasId = (short)(NumberUtil.Val( GetPar( "CarrinhoComprasId"), "."));
                  AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
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
                     sMode12 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode12;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound12 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0D0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CARRINHOCOMPRASID");
                        AnyError = 1;
                        GX_FocusControl = edtCarrinhoComprasId_Internalname;
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
                           E110D2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120D2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E120D2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0D12( ) ;
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
            DisableAttributes0D12( ) ;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D12( ) ;
            }
            else
            {
               CheckExtendedTable0D12( ) ;
               CloseExtendedTableCursors0D12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode12 = Gx_mode;
            CONFIRM_0D13( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode12;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0D13( )
      {
         s62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         s65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
         AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0D13( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               GetKey0D13( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  if ( RcdFound13 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0D13( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0D13( ) ;
                        CloseExtendedTableCursors0D13( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                        O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                        n62CarrinhoComprasPrecoTotal = false;
                        AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                        O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                        AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUTOID_" + sGXsfl_88_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProdutoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( nRcdDeleted_13 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0D13( ) ;
                        Load0D13( ) ;
                        BeforeValidate0D13( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0D13( ) ;
                           O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                           n62CarrinhoComprasPrecoTotal = false;
                           AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                           O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                           AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                        }
                     }
                     else
                     {
                        if ( nIsMod_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0D13( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0D13( ) ;
                              CloseExtendedTableCursors0D13( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                              O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                              n62CarrinhoComprasPrecoTotal = false;
                              AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                              O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                              AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "PRODUTOID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdutoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdutoNome_Internalname, A20ProdutoNome) ;
            ChangePostValue( edtProdutoPreco_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", ""))) ;
            ChangePostValue( edtProdutoImagem_Internalname, A23ProdutoImagem) ;
            ChangePostValue( edtCarrinhoComprasProdutosQuantid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A60CarrinhoComprasProdutosQuantid), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdutosPrecoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A64ProdutosPrecoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z19ProdutoId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z60CarrinhoComprasProdutosQuantid_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60CarrinhoComprasProdutosQuantid), 4, 0, ".", ""))) ;
            ChangePostValue( "T64ProdutosPrecoTotal_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( O64ProdutosPrecoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "PRODUTOID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTONOME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTOPRECO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoPreco_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTOIMAGEM_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoImagem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CARRINHOCOMPRASPRODUTOSQUANTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarrinhoComprasProdutosQuantid_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTOSPRECOTOTAL_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutosPrecoTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         O62CarrinhoComprasPrecoTotal = s62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         O65CarrinhoComprasPontos = s65CarrinhoComprasPontos;
         AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0D0( )
      {
      }

      protected void E110D2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV15Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV15Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_ClienteCarrinhoComprasId = 0;
         AssignAttri("", false, "AV11Insert_ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteCarrinhoComprasId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV15Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV16GXV1 = 1;
            AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
            while ( AV16GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV16GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteCarrinhoComprasId") == 0 )
               {
                  AV11Insert_ClienteCarrinhoComprasId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteCarrinhoComprasId), 4, 0));
               }
               AV16GXV1 = (int)(AV16GXV1+1);
               AssignAttri("", false, "AV16GXV1", StringUtil.LTrimStr( (decimal)(AV16GXV1), 8, 0));
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

      protected void E120D2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         context.PopUp(formatLink("anotafiscalcarrinho.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0))}, new string[] {"CarrinhoComprasId"}) , new Object[] {"A52CarrinhoComprasId"});
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwcarrinhocompras.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0D12( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z53CarrinhoComprasData = T000D7_A53CarrinhoComprasData[0];
               Z54ClienteCarrinhoComprasId = T000D7_A54ClienteCarrinhoComprasId[0];
            }
            else
            {
               Z53CarrinhoComprasData = A53CarrinhoComprasData;
               Z54ClienteCarrinhoComprasId = A54ClienteCarrinhoComprasId;
            }
         }
         if ( GX_JID == -17 )
         {
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            Z53CarrinhoComprasData = A53CarrinhoComprasData;
            Z54ClienteCarrinhoComprasId = A54ClienteCarrinhoComprasId;
            Z62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            Z55ClienteCarrinhoComprasNome = A55ClienteCarrinhoComprasNome;
            Z56ClienteCarrinhoComprasEndereco = A56ClienteCarrinhoComprasEndereco;
            Z57ClienteCarrinhoComprasPaisId = A57ClienteCarrinhoComprasPaisId;
            Z58ClienteCarrinhoComprasPaisNome = A58ClienteCarrinhoComprasPaisNome;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         Gx_date = DateTimeUtil.Today( context);
         AssignAttri("", false, "Gx_date", context.localUtil.Format(Gx_date, "99/99/99"));
         imgprompt_54_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00b0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTECARRINHOCOMPRASID"+"'), id:'"+"CLIENTECARRINHOCOMPRASID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CarrinhoComprasId) )
         {
            A52CarrinhoComprasId = AV7CarrinhoComprasId;
            AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
         }
         if ( ! (0==AV7CarrinhoComprasId) )
         {
            edtCarrinhoComprasId_Enabled = 0;
            AssignProp("", false, edtCarrinhoComprasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasId_Enabled), 5, 0), true);
         }
         else
         {
            edtCarrinhoComprasId_Enabled = 1;
            AssignProp("", false, edtCarrinhoComprasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CarrinhoComprasId) )
         {
            edtCarrinhoComprasId_Enabled = 0;
            AssignProp("", false, edtCarrinhoComprasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteCarrinhoComprasId) )
         {
            edtClienteCarrinhoComprasId_Enabled = 0;
            AssignProp("", false, edtClienteCarrinhoComprasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCarrinhoComprasId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteCarrinhoComprasId_Enabled = 1;
            AssignProp("", false, edtClienteCarrinhoComprasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCarrinhoComprasId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteCarrinhoComprasId) )
         {
            A54ClienteCarrinhoComprasId = AV11Insert_ClienteCarrinhoComprasId;
            AssignAttri("", false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
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
         if ( IsIns( )  && (DateTime.MinValue==A53CarrinhoComprasData) && ( Gx_BScreen == 0 ) )
         {
            A53CarrinhoComprasData = Gx_date;
            AssignAttri("", false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000D11 */
            pr_default.execute(8, new Object[] {A52CarrinhoComprasId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               A62CarrinhoComprasPrecoTotal = T000D11_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = T000D11_n62CarrinhoComprasPrecoTotal[0];
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            }
            else
            {
               A62CarrinhoComprasPrecoTotal = 0;
               n62CarrinhoComprasPrecoTotal = false;
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            }
            O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            pr_default.close(8);
            if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
            {
               A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            }
            else
            {
               A65CarrinhoComprasPontos = 0;
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            }
            AV15Pgmname = "CarrinhoCompras";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000D8 */
            pr_default.execute(6, new Object[] {A54ClienteCarrinhoComprasId});
            A55ClienteCarrinhoComprasNome = T000D8_A55ClienteCarrinhoComprasNome[0];
            AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
            A56ClienteCarrinhoComprasEndereco = T000D8_A56ClienteCarrinhoComprasEndereco[0];
            AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
            A57ClienteCarrinhoComprasPaisId = T000D8_A57ClienteCarrinhoComprasPaisId[0];
            AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
            pr_default.close(6);
            /* Using cursor T000D9 */
            pr_default.execute(7, new Object[] {A57ClienteCarrinhoComprasPaisId});
            A58ClienteCarrinhoComprasPaisNome = T000D9_A58ClienteCarrinhoComprasPaisNome[0];
            AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
            pr_default.close(7);
            A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
            AssignAttri("", false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
         }
      }

      protected void Load0D12( )
      {
         /* Using cursor T000D13 */
         pr_default.execute(9, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound12 = 1;
            A53CarrinhoComprasData = T000D13_A53CarrinhoComprasData[0];
            AssignAttri("", false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
            A55ClienteCarrinhoComprasNome = T000D13_A55ClienteCarrinhoComprasNome[0];
            AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
            A56ClienteCarrinhoComprasEndereco = T000D13_A56ClienteCarrinhoComprasEndereco[0];
            AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
            A58ClienteCarrinhoComprasPaisNome = T000D13_A58ClienteCarrinhoComprasPaisNome[0];
            AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
            A54ClienteCarrinhoComprasId = T000D13_A54ClienteCarrinhoComprasId[0];
            AssignAttri("", false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
            A57ClienteCarrinhoComprasPaisId = T000D13_A57ClienteCarrinhoComprasPaisId[0];
            AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
            A62CarrinhoComprasPrecoTotal = T000D13_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = T000D13_n62CarrinhoComprasPrecoTotal[0];
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            ZM0D12( -17) ;
         }
         pr_default.close(9);
         OnLoadActions0D12( ) ;
      }

      protected void OnLoadActions0D12( )
      {
         O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         AV15Pgmname = "CarrinhoCompras";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         else
         {
            A65CarrinhoComprasPontos = 0;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
         AssignAttri("", false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
      }

      protected void CheckExtendedTable0D12( )
      {
         nIsDirty_12 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         AV15Pgmname = "CarrinhoCompras";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         /* Using cursor T000D11 */
         pr_default.execute(8, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            A62CarrinhoComprasPrecoTotal = T000D11_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = T000D11_n62CarrinhoComprasPrecoTotal[0];
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         else
         {
            nIsDirty_12 = 1;
            A62CarrinhoComprasPrecoTotal = 0;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         pr_default.close(8);
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            nIsDirty_12 = 1;
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         else
         {
            nIsDirty_12 = 1;
            A65CarrinhoComprasPontos = 0;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         if ( ! ( (DateTime.MinValue==A53CarrinhoComprasData) || ( DateTimeUtil.ResetTime ( A53CarrinhoComprasData ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Data is out of range", "OutOfRange", 1, "CARRINHOCOMPRASDATA");
            AnyError = 1;
            GX_FocusControl = edtCarrinhoComprasData_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         nIsDirty_12 = 1;
         A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
         AssignAttri("", false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
         /* Using cursor T000D8 */
         pr_default.execute(6, new Object[] {A54ClienteCarrinhoComprasId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASID");
            AnyError = 1;
            GX_FocusControl = edtClienteCarrinhoComprasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ClienteCarrinhoComprasNome = T000D8_A55ClienteCarrinhoComprasNome[0];
         AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
         A56ClienteCarrinhoComprasEndereco = T000D8_A56ClienteCarrinhoComprasEndereco[0];
         AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
         A57ClienteCarrinhoComprasPaisId = T000D8_A57ClienteCarrinhoComprasPaisId[0];
         AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
         pr_default.close(6);
         /* Using cursor T000D9 */
         pr_default.execute(7, new Object[] {A57ClienteCarrinhoComprasPaisId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASPAISID");
            AnyError = 1;
         }
         A58ClienteCarrinhoComprasPaisNome = T000D9_A58ClienteCarrinhoComprasPaisNome[0];
         AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
         pr_default.close(7);
      }

      protected void CloseExtendedTableCursors0D12( )
      {
         pr_default.close(8);
         pr_default.close(6);
         pr_default.close(7);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_20( short A52CarrinhoComprasId )
      {
         /* Using cursor T000D15 */
         pr_default.execute(10, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            A62CarrinhoComprasPrecoTotal = T000D15_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = T000D15_n62CarrinhoComprasPrecoTotal[0];
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         else
         {
            A62CarrinhoComprasPrecoTotal = 0;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A62CarrinhoComprasPrecoTotal, 10, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_18( short A54ClienteCarrinhoComprasId )
      {
         /* Using cursor T000D16 */
         pr_default.execute(11, new Object[] {A54ClienteCarrinhoComprasId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASID");
            AnyError = 1;
            GX_FocusControl = edtClienteCarrinhoComprasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A55ClienteCarrinhoComprasNome = T000D16_A55ClienteCarrinhoComprasNome[0];
         AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
         A56ClienteCarrinhoComprasEndereco = T000D16_A56ClienteCarrinhoComprasEndereco[0];
         AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
         A57ClienteCarrinhoComprasPaisId = T000D16_A57ClienteCarrinhoComprasPaisId[0];
         AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A55ClienteCarrinhoComprasNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A56ClienteCarrinhoComprasEndereco)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void gxLoad_19( short A57ClienteCarrinhoComprasPaisId )
      {
         /* Using cursor T000D17 */
         pr_default.execute(12, new Object[] {A57ClienteCarrinhoComprasPaisId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASPAISID");
            AnyError = 1;
         }
         A58ClienteCarrinhoComprasPaisNome = T000D17_A58ClienteCarrinhoComprasPaisNome[0];
         AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A58ClienteCarrinhoComprasPaisNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(12) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(12);
      }

      protected void GetKey0D12( )
      {
         /* Using cursor T000D18 */
         pr_default.execute(13, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(13);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            ZM0D12( 17) ;
            RcdFound12 = 1;
            A52CarrinhoComprasId = T000D7_A52CarrinhoComprasId[0];
            AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
            A53CarrinhoComprasData = T000D7_A53CarrinhoComprasData[0];
            AssignAttri("", false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
            A54ClienteCarrinhoComprasId = T000D7_A54ClienteCarrinhoComprasId[0];
            AssignAttri("", false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0D12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0D12( ) ;
            }
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0D12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode12;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(5);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D12( ) ;
         if ( RcdFound12 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound12 = 0;
         /* Using cursor T000D19 */
         pr_default.execute(14, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000D19_A52CarrinhoComprasId[0] < A52CarrinhoComprasId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000D19_A52CarrinhoComprasId[0] > A52CarrinhoComprasId ) ) )
            {
               A52CarrinhoComprasId = T000D19_A52CarrinhoComprasId[0];
               AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void move_previous( )
      {
         RcdFound12 = 0;
         /* Using cursor T000D20 */
         pr_default.execute(15, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(15) != 101) )
         {
            while ( (pr_default.getStatus(15) != 101) && ( ( T000D20_A52CarrinhoComprasId[0] > A52CarrinhoComprasId ) ) )
            {
               pr_default.readNext(15);
            }
            if ( (pr_default.getStatus(15) != 101) && ( ( T000D20_A52CarrinhoComprasId[0] < A52CarrinhoComprasId ) ) )
            {
               A52CarrinhoComprasId = T000D20_A52CarrinhoComprasId[0];
               AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
               RcdFound12 = 1;
            }
         }
         pr_default.close(15);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            GX_FocusControl = edtCarrinhoComprasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0D12( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A52CarrinhoComprasId != Z52CarrinhoComprasId )
               {
                  A52CarrinhoComprasId = Z52CarrinhoComprasId;
                  AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CARRINHOCOMPRASID");
                  AnyError = 1;
                  GX_FocusControl = edtCarrinhoComprasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                  A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                  AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCarrinhoComprasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                  A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                  AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                  Update0D12( ) ;
                  GX_FocusControl = edtCarrinhoComprasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A52CarrinhoComprasId != Z52CarrinhoComprasId )
               {
                  /* Insert record */
                  A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                  A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                  AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                  GX_FocusControl = edtCarrinhoComprasId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0D12( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CARRINHOCOMPRASID");
                     AnyError = 1;
                     GX_FocusControl = edtCarrinhoComprasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                     n62CarrinhoComprasPrecoTotal = false;
                     AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                     A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                     AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                     GX_FocusControl = edtCarrinhoComprasId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0D12( ) ;
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
         if ( A52CarrinhoComprasId != Z52CarrinhoComprasId )
         {
            A52CarrinhoComprasId = Z52CarrinhoComprasId;
            AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CARRINHOCOMPRASID");
            AnyError = 1;
            GX_FocusControl = edtCarrinhoComprasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCarrinhoComprasId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0D12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D6 */
            pr_default.execute(4, new Object[] {A52CarrinhoComprasId});
            if ( (pr_default.getStatus(4) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoCompras"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(4) == 101) || ( DateTimeUtil.ResetTime ( Z53CarrinhoComprasData ) != DateTimeUtil.ResetTime ( T000D6_A53CarrinhoComprasData[0] ) ) || ( Z54ClienteCarrinhoComprasId != T000D6_A54ClienteCarrinhoComprasId[0] ) )
            {
               if ( DateTimeUtil.ResetTime ( Z53CarrinhoComprasData ) != DateTimeUtil.ResetTime ( T000D6_A53CarrinhoComprasData[0] ) )
               {
                  GXUtil.WriteLog("carrinhocompras:[seudo value changed for attri]"+"CarrinhoComprasData");
                  GXUtil.WriteLogRaw("Old: ",Z53CarrinhoComprasData);
                  GXUtil.WriteLogRaw("Current: ",T000D6_A53CarrinhoComprasData[0]);
               }
               if ( Z54ClienteCarrinhoComprasId != T000D6_A54ClienteCarrinhoComprasId[0] )
               {
                  GXUtil.WriteLog("carrinhocompras:[seudo value changed for attri]"+"ClienteCarrinhoComprasId");
                  GXUtil.WriteLogRaw("Old: ",Z54ClienteCarrinhoComprasId);
                  GXUtil.WriteLogRaw("Current: ",T000D6_A54ClienteCarrinhoComprasId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CarrinhoCompras"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D12( )
      {
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D12( 0) ;
            CheckOptimisticConcurrency0D12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D21 */
                     pr_default.execute(16, new Object[] {A52CarrinhoComprasId, A53CarrinhoComprasData, A54ClienteCarrinhoComprasId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoCompras");
                     if ( (pr_default.getStatus(16) == 1) )
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
                           ProcessLevel0D12( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0D0( ) ;
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
            else
            {
               Load0D12( ) ;
            }
            EndLevel0D12( ) ;
         }
         CloseExtendedTableCursors0D12( ) ;
      }

      protected void Update0D12( )
      {
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D22 */
                     pr_default.execute(17, new Object[] {A53CarrinhoComprasData, A54ClienteCarrinhoComprasId, A52CarrinhoComprasId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoCompras");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoCompras"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D12( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0D12( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0D12( ) ;
         }
         CloseExtendedTableCursors0D12( ) ;
      }

      protected void DeferredUpdate0D12( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0D12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D12( ) ;
            AfterConfirm0D12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D12( ) ;
               if ( AnyError == 0 )
               {
                  A62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                  A65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
                  AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                  ScanStart0D13( ) ;
                  while ( RcdFound13 != 0 )
                  {
                     getByPrimaryKey0D13( ) ;
                     Delete0D13( ) ;
                     ScanNext0D13( ) ;
                     O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
                     n62CarrinhoComprasPrecoTotal = false;
                     AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                     O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
                     AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
                  }
                  ScanEnd0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D23 */
                     pr_default.execute(18, new Object[] {A52CarrinhoComprasId});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoCompras");
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
         }
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D12( ) ;
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV15Pgmname = "CarrinhoCompras";
            AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
            /* Using cursor T000D25 */
            pr_default.execute(19, new Object[] {A52CarrinhoComprasId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               A62CarrinhoComprasPrecoTotal = T000D25_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = T000D25_n62CarrinhoComprasPrecoTotal[0];
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            }
            else
            {
               A62CarrinhoComprasPrecoTotal = 0;
               n62CarrinhoComprasPrecoTotal = false;
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            }
            pr_default.close(19);
            if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
            {
               A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            }
            else
            {
               A65CarrinhoComprasPontos = 0;
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            }
            A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
            AssignAttri("", false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
            /* Using cursor T000D26 */
            pr_default.execute(20, new Object[] {A54ClienteCarrinhoComprasId});
            A55ClienteCarrinhoComprasNome = T000D26_A55ClienteCarrinhoComprasNome[0];
            AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
            A56ClienteCarrinhoComprasEndereco = T000D26_A56ClienteCarrinhoComprasEndereco[0];
            AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
            A57ClienteCarrinhoComprasPaisId = T000D26_A57ClienteCarrinhoComprasPaisId[0];
            AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
            pr_default.close(20);
            /* Using cursor T000D27 */
            pr_default.execute(21, new Object[] {A57ClienteCarrinhoComprasPaisId});
            A58ClienteCarrinhoComprasPaisNome = T000D27_A58ClienteCarrinhoComprasPaisNome[0];
            AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
            pr_default.close(21);
            if ( ( DateTimeUtil.ResetTime ( A53CarrinhoComprasData ) == DateTimeUtil.ResetTime ( Gx_date ) ) && IsDlt( )  )
            {
               GX_msglist.addItem("Não é permitido excluir registros do carrinho de hoje", 1, "CARRINHOCOMPRASDATA");
               AnyError = 1;
               GX_FocusControl = edtCarrinhoComprasData_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
      }

      protected void ProcessNestedLevel0D13( )
      {
         s62CarrinhoComprasPrecoTotal = O62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         s65CarrinhoComprasPontos = O65CarrinhoComprasPontos;
         AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         nGXsfl_88_idx = 0;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            ReadRow0D13( ) ;
            if ( ( nRcdExists_13 != 0 ) || ( nIsMod_13 != 0 ) )
            {
               standaloneNotModal0D13( ) ;
               GetKey0D13( ) ;
               if ( ( nRcdExists_13 == 0 ) && ( nRcdDeleted_13 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0D13( ) ;
               }
               else
               {
                  if ( RcdFound13 != 0 )
                  {
                     if ( ( nRcdDeleted_13 != 0 ) && ( nRcdExists_13 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0D13( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_13 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0D13( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_13 == 0 )
                     {
                        GXCCtl = "PRODUTOID_" + sGXsfl_88_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdutoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
               O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
               n62CarrinhoComprasPrecoTotal = false;
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               O65CarrinhoComprasPontos = A65CarrinhoComprasPontos;
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            }
            ChangePostValue( edtProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdutoNome_Internalname, A20ProdutoNome) ;
            ChangePostValue( edtProdutoPreco_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", ""))) ;
            ChangePostValue( edtProdutoImagem_Internalname, A23ProdutoImagem) ;
            ChangePostValue( edtCarrinhoComprasProdutosQuantid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A60CarrinhoComprasProdutosQuantid), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdutosPrecoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A64ProdutosPrecoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z19ProdutoId_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( "ZT_"+"Z60CarrinhoComprasProdutosQuantid_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60CarrinhoComprasProdutosQuantid), 4, 0, ".", ""))) ;
            ChangePostValue( "T64ProdutosPrecoTotal_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( O64ProdutosPrecoTotal, 10, 2, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_13_"+sGXsfl_88_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", ""))) ;
            if ( nIsMod_13 != 0 )
            {
               ChangePostValue( "PRODUTOID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTONOME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTOPRECO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoPreco_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTOIMAGEM_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoImagem_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "CARRINHOCOMPRASPRODUTOSQUANTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarrinhoComprasProdutosQuantid_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTOSPRECOTOTAL_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutosPrecoTotal_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0D13( ) ;
         if ( AnyError != 0 )
         {
            O62CarrinhoComprasPrecoTotal = s62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            O65CarrinhoComprasPontos = s65CarrinhoComprasPontos;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         nRcdExists_13 = 0;
         nIsMod_13 = 0;
         nRcdDeleted_13 = 0;
      }

      protected void ProcessLevel0D12( )
      {
         /* Save parent mode. */
         sMode12 = Gx_mode;
         ProcessNestedLevel0D13( ) ;
         if ( AnyError != 0 )
         {
            O62CarrinhoComprasPrecoTotal = s62CarrinhoComprasPrecoTotal;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            O65CarrinhoComprasPontos = s65CarrinhoComprasPontos;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         /* Restore parent mode. */
         Gx_mode = sMode12;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0D12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(4);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D12( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.CommitDataStores("carrinhocompras",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(5);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(19);
            pr_default.close(2);
            pr_default.close(3);
            context.RollbackDataStores("carrinhocompras",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D12( )
      {
         /* Scan By routine */
         /* Using cursor T000D28 */
         pr_default.execute(22);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound12 = 1;
            A52CarrinhoComprasId = T000D28_A52CarrinhoComprasId[0];
            AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D12( )
      {
         /* Scan next routine */
         pr_default.readNext(22);
         RcdFound12 = 0;
         if ( (pr_default.getStatus(22) != 101) )
         {
            RcdFound12 = 1;
            A52CarrinhoComprasId = T000D28_A52CarrinhoComprasId[0];
            AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
         }
      }

      protected void ScanEnd0D12( )
      {
         pr_default.close(22);
      }

      protected void AfterConfirm0D12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D12( )
      {
         edtCarrinhoComprasId_Enabled = 0;
         AssignProp("", false, edtCarrinhoComprasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasId_Enabled), 5, 0), true);
         edtCarrinhoComprasData_Enabled = 0;
         AssignProp("", false, edtCarrinhoComprasData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasData_Enabled), 5, 0), true);
         edtClienteCarrinhoComprasId_Enabled = 0;
         AssignProp("", false, edtClienteCarrinhoComprasId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCarrinhoComprasId_Enabled), 5, 0), true);
         edtClienteCarrinhoComprasNome_Enabled = 0;
         AssignProp("", false, edtClienteCarrinhoComprasNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCarrinhoComprasNome_Enabled), 5, 0), true);
         edtClienteCarrinhoComprasEndereco_Enabled = 0;
         AssignProp("", false, edtClienteCarrinhoComprasEndereco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCarrinhoComprasEndereco_Enabled), 5, 0), true);
         edtClienteCarrinhoComprasPaisId_Enabled = 0;
         AssignProp("", false, edtClienteCarrinhoComprasPaisId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCarrinhoComprasPaisId_Enabled), 5, 0), true);
         edtClienteCarrinhoComprasPaisNome_Enabled = 0;
         AssignProp("", false, edtClienteCarrinhoComprasPaisNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCarrinhoComprasPaisNome_Enabled), 5, 0), true);
         edtCarrinhoComprasPrecoTotal_Enabled = 0;
         AssignProp("", false, edtCarrinhoComprasPrecoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasPrecoTotal_Enabled), 5, 0), true);
         edtCarrinhoComprasDataEntrega_Enabled = 0;
         AssignProp("", false, edtCarrinhoComprasDataEntrega_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasDataEntrega_Enabled), 5, 0), true);
         edtCarrinhoComprasPontos_Enabled = 0;
         AssignProp("", false, edtCarrinhoComprasPontos_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasPontos_Enabled), 5, 0), true);
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 21 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z60CarrinhoComprasProdutosQuantid = T000D3_A60CarrinhoComprasProdutosQuantid[0];
            }
            else
            {
               Z60CarrinhoComprasProdutosQuantid = A60CarrinhoComprasProdutosQuantid;
            }
         }
         if ( GX_JID == -21 )
         {
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            Z60CarrinhoComprasProdutosQuantid = A60CarrinhoComprasProdutosQuantid;
            Z19ProdutoId = A19ProdutoId;
            Z30CategoriaProdutoId = A30CategoriaProdutoId;
            Z20ProdutoNome = A20ProdutoNome;
            Z22ProdutoPreco = A22ProdutoPreco;
            Z23ProdutoImagem = A23ProdutoImagem;
            Z40000ProdutoImagem_GXI = A40000ProdutoImagem_GXI;
            Z31CategoriaProdutoNome = A31CategoriaProdutoNome;
         }
      }

      protected void standaloneNotModal0D13( )
      {
      }

      protected void standaloneModal0D13( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProdutoId_Enabled = 0;
            AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
         else
         {
            edtProdutoId_Enabled = 1;
            AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         }
      }

      protected void Load0D13( )
      {
         /* Using cursor T000D29 */
         pr_default.execute(23, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound13 = 1;
            A30CategoriaProdutoId = T000D29_A30CategoriaProdutoId[0];
            A20ProdutoNome = T000D29_A20ProdutoNome[0];
            A22ProdutoPreco = T000D29_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = T000D29_A40000ProdutoImagem_GXI[0];
            AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
            AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            A60CarrinhoComprasProdutosQuantid = T000D29_A60CarrinhoComprasProdutosQuantid[0];
            A31CategoriaProdutoNome = T000D29_A31CategoriaProdutoNome[0];
            A23ProdutoImagem = T000D29_A23ProdutoImagem[0];
            AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
            AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            ZM0D13( -21) ;
         }
         pr_default.close(23);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
         if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Joalheria") == 0 )
         {
            A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*1.05m));
         }
         else
         {
            if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Entreterimento") == 0 )
            {
               A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*0.9m));
            }
            else
            {
               A64ProdutosPrecoTotal = (decimal)(A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco);
            }
         }
         O64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
         if ( IsIns( )  )
         {
            A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal);
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal-O64ProdutosPrecoTotal);
               n62CarrinhoComprasPrecoTotal = false;
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal-O64ProdutosPrecoTotal);
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               }
            }
         }
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         else
         {
            A65CarrinhoComprasPontos = 0;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
      }

      protected void CheckExtendedTable0D13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0D13( ) ;
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUTOID_" + sGXsfl_88_idx;
            GX_msglist.addItem("No matching 'Produto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30CategoriaProdutoId = T000D4_A30CategoriaProdutoId[0];
         A20ProdutoNome = T000D4_A20ProdutoNome[0];
         A22ProdutoPreco = T000D4_A22ProdutoPreco[0];
         A40000ProdutoImagem_GXI = T000D4_A40000ProdutoImagem_GXI[0];
         AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         A23ProdutoImagem = T000D4_A23ProdutoImagem[0];
         AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         pr_default.close(2);
         /* Using cursor T000D5 */
         pr_default.execute(3, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
         }
         A31CategoriaProdutoNome = T000D5_A31CategoriaProdutoNome[0];
         pr_default.close(3);
         if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Joalheria") == 0 )
         {
            nIsDirty_13 = 1;
            A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*1.05m));
         }
         else
         {
            if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Entreterimento") == 0 )
            {
               nIsDirty_13 = 1;
               A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*0.9m));
            }
            else
            {
               nIsDirty_13 = 1;
               A64ProdutosPrecoTotal = (decimal)(A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco);
            }
         }
         if ( IsIns( )  )
         {
            nIsDirty_13 = 1;
            A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal);
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         else
         {
            if ( IsUpd( )  )
            {
               nIsDirty_13 = 1;
               A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal-O64ProdutosPrecoTotal);
               n62CarrinhoComprasPrecoTotal = false;
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            }
            else
            {
               if ( IsDlt( )  )
               {
                  nIsDirty_13 = 1;
                  A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal-O64ProdutosPrecoTotal);
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               }
            }
         }
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            nIsDirty_13 = 1;
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         else
         {
            nIsDirty_13 = 1;
            A65CarrinhoComprasPontos = 0;
            AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
      }

      protected void CloseExtendedTableCursors0D13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable0D13( )
      {
      }

      protected void gxLoad_22( short A19ProdutoId )
      {
         /* Using cursor T000D30 */
         pr_default.execute(24, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(24) == 101) )
         {
            GXCCtl = "PRODUTOID_" + sGXsfl_88_idx;
            GX_msglist.addItem("No matching 'Produto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A30CategoriaProdutoId = T000D30_A30CategoriaProdutoId[0];
         A20ProdutoNome = T000D30_A20ProdutoNome[0];
         A22ProdutoPreco = T000D30_A22ProdutoPreco[0];
         A40000ProdutoImagem_GXI = T000D30_A40000ProdutoImagem_GXI[0];
         AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         A23ProdutoImagem = T000D30_A23ProdutoImagem[0];
         AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A20ProdutoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A23ProdutoImagem)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000ProdutoImagem_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(24) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(24);
      }

      protected void gxLoad_23( short A30CategoriaProdutoId )
      {
         /* Using cursor T000D31 */
         pr_default.execute(25, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(25) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
         }
         A31CategoriaProdutoNome = T000D31_A31CategoriaProdutoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A31CategoriaProdutoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(25) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(25);
      }

      protected void GetKey0D13( )
      {
         /* Using cursor T000D32 */
         pr_default.execute(26, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(26);
      }

      protected void getByPrimaryKey0D13( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 21) ;
            RcdFound13 = 1;
            InitializeNonKey0D13( ) ;
            A60CarrinhoComprasProdutosQuantid = T000D3_A60CarrinhoComprasProdutosQuantid[0];
            A19ProdutoId = T000D3_A19ProdutoId[0];
            Z52CarrinhoComprasId = A52CarrinhoComprasId;
            Z19ProdutoId = A19ProdutoId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0D13( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0D13( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0D13( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoComprasProdutos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z60CarrinhoComprasProdutosQuantid != T000D2_A60CarrinhoComprasProdutosQuantid[0] ) )
            {
               if ( Z60CarrinhoComprasProdutosQuantid != T000D2_A60CarrinhoComprasProdutosQuantid[0] )
               {
                  GXUtil.WriteLog("carrinhocompras:[seudo value changed for attri]"+"CarrinhoComprasProdutosQuantid");
                  GXUtil.WriteLogRaw("Old: ",Z60CarrinhoComprasProdutosQuantid);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A60CarrinhoComprasProdutosQuantid[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CarrinhoComprasProdutos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D33 */
                     pr_default.execute(27, new Object[] {A52CarrinhoComprasId, A60CarrinhoComprasProdutosQuantid, A19ProdutoId});
                     pr_default.close(27);
                     pr_default.SmartCacheProvider.SetUpdated("CarrinhoComprasProdutos");
                     if ( (pr_default.getStatus(27) == 1) )
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( ( nIsMod_13 != 0 ) || ( nIsDirty_13 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0D13( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0D13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000D34 */
                        pr_default.execute(28, new Object[] {A60CarrinhoComprasProdutosQuantid, A52CarrinhoComprasId, A19ProdutoId});
                        pr_default.close(28);
                        pr_default.SmartCacheProvider.SetUpdated("CarrinhoComprasProdutos");
                        if ( (pr_default.getStatus(28) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CarrinhoComprasProdutos"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0D13( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0D13( ) ;
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
               EndLevel0D13( ) ;
            }
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void Delete0D13( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D35 */
                  pr_default.execute(29, new Object[] {A52CarrinhoComprasId, A19ProdutoId});
                  pr_default.close(29);
                  pr_default.SmartCacheProvider.SetUpdated("CarrinhoComprasProdutos");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal0D13( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D36 */
            pr_default.execute(30, new Object[] {A19ProdutoId});
            A30CategoriaProdutoId = T000D36_A30CategoriaProdutoId[0];
            A20ProdutoNome = T000D36_A20ProdutoNome[0];
            A22ProdutoPreco = T000D36_A22ProdutoPreco[0];
            A40000ProdutoImagem_GXI = T000D36_A40000ProdutoImagem_GXI[0];
            AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
            AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            A23ProdutoImagem = T000D36_A23ProdutoImagem[0];
            AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
            AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            pr_default.close(30);
            /* Using cursor T000D37 */
            pr_default.execute(31, new Object[] {A30CategoriaProdutoId});
            A31CategoriaProdutoNome = T000D37_A31CategoriaProdutoNome[0];
            pr_default.close(31);
            if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Joalheria") == 0 )
            {
               A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*1.05m));
            }
            else
            {
               if ( StringUtil.StrCmp(A31CategoriaProdutoNome, "Entreterimento") == 0 )
               {
                  A64ProdutosPrecoTotal = (decimal)((A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco*0.9m));
               }
               else
               {
                  A64ProdutosPrecoTotal = (decimal)(A60CarrinhoComprasProdutosQuantid*A22ProdutoPreco);
               }
            }
            if ( IsIns( )  )
            {
               A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal);
               n62CarrinhoComprasPrecoTotal = false;
               AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            }
            else
            {
               if ( IsUpd( )  )
               {
                  A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal+A64ProdutosPrecoTotal-O64ProdutosPrecoTotal);
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               }
               else
               {
                  if ( IsDlt( )  )
                  {
                     A62CarrinhoComprasPrecoTotal = (decimal)(O62CarrinhoComprasPrecoTotal-O64ProdutosPrecoTotal);
                     n62CarrinhoComprasPrecoTotal = false;
                     AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
                  }
               }
            }
            if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
            {
               A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            }
            else
            {
               A65CarrinhoComprasPontos = 0;
               AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
            }
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D13( )
      {
         /* Scan By routine */
         /* Using cursor T000D38 */
         pr_default.execute(32, new Object[] {A52CarrinhoComprasId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound13 = 1;
            A19ProdutoId = T000D38_A19ProdutoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(32);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(32) != 101) )
         {
            RcdFound13 = 1;
            A19ProdutoId = T000D38_A19ProdutoId[0];
         }
      }

      protected void ScanEnd0D13( )
      {
         pr_default.close(32);
      }

      protected void AfterConfirm0D13( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
         edtProdutoId_Enabled = 0;
         AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProdutoNome_Enabled = 0;
         AssignProp("", false, edtProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoNome_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProdutoPreco_Enabled = 0;
         AssignProp("", false, edtProdutoPreco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoPreco_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProdutoImagem_Enabled = 0;
         AssignProp("", false, edtProdutoImagem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoImagem_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtCarrinhoComprasProdutosQuantid_Enabled = 0;
         AssignProp("", false, edtCarrinhoComprasProdutosQuantid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCarrinhoComprasProdutosQuantid_Enabled), 5, 0), !bGXsfl_88_Refreshing);
         edtProdutosPrecoTotal_Enabled = 0;
         AssignProp("", false, edtProdutosPrecoTotal_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutosPrecoTotal_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void send_integrity_lvl_hashes0D12( )
      {
      }

      protected void SubsflControlProps_8813( )
      {
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_88_idx;
         imgprompt_19_Internalname = "PROMPT_19_"+sGXsfl_88_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_88_idx;
         edtProdutoPreco_Internalname = "PRODUTOPRECO_"+sGXsfl_88_idx;
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM_"+sGXsfl_88_idx;
         edtCarrinhoComprasProdutosQuantid_Internalname = "CARRINHOCOMPRASPRODUTOSQUANTID_"+sGXsfl_88_idx;
         edtProdutosPrecoTotal_Internalname = "PRODUTOSPRECOTOTAL_"+sGXsfl_88_idx;
      }

      protected void SubsflControlProps_fel_8813( )
      {
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_88_fel_idx;
         imgprompt_19_Internalname = "PROMPT_19_"+sGXsfl_88_fel_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_88_fel_idx;
         edtProdutoPreco_Internalname = "PRODUTOPRECO_"+sGXsfl_88_fel_idx;
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM_"+sGXsfl_88_fel_idx;
         edtCarrinhoComprasProdutosQuantid_Internalname = "CARRINHOCOMPRASPRODUTOSQUANTID_"+sGXsfl_88_fel_idx;
         edtProdutosPrecoTotal_Internalname = "PRODUTOSPRECOTOTAL_"+sGXsfl_88_fel_idx;
      }

      protected void AddRow0D13( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8813( ) ;
         SendRow0D13( ) ;
      }

      protected void SendRow0D13( )
      {
         Gridcarrinhocompras_produtosRow = GXWebRow.GetNew(context);
         if ( subGridcarrinhocompras_produtos_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridcarrinhocompras_produtos_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridcarrinhocompras_produtos_Class, "") != 0 )
            {
               subGridcarrinhocompras_produtos_Linesclass = subGridcarrinhocompras_produtos_Class+"Odd";
            }
         }
         else if ( subGridcarrinhocompras_produtos_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridcarrinhocompras_produtos_Backstyle = 0;
            subGridcarrinhocompras_produtos_Backcolor = subGridcarrinhocompras_produtos_Allbackcolor;
            if ( StringUtil.StrCmp(subGridcarrinhocompras_produtos_Class, "") != 0 )
            {
               subGridcarrinhocompras_produtos_Linesclass = subGridcarrinhocompras_produtos_Class+"Uniform";
            }
         }
         else if ( subGridcarrinhocompras_produtos_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridcarrinhocompras_produtos_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridcarrinhocompras_produtos_Class, "") != 0 )
            {
               subGridcarrinhocompras_produtos_Linesclass = subGridcarrinhocompras_produtos_Class+"Odd";
            }
            subGridcarrinhocompras_produtos_Backcolor = (int)(0x0);
         }
         else if ( subGridcarrinhocompras_produtos_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridcarrinhocompras_produtos_Backstyle = 1;
            if ( ((int)((nGXsfl_88_idx) % (2))) == 0 )
            {
               subGridcarrinhocompras_produtos_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcarrinhocompras_produtos_Class, "") != 0 )
               {
                  subGridcarrinhocompras_produtos_Linesclass = subGridcarrinhocompras_produtos_Class+"Even";
               }
            }
            else
            {
               subGridcarrinhocompras_produtos_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridcarrinhocompras_produtos_Class, "") != 0 )
               {
                  subGridcarrinhocompras_produtos_Linesclass = subGridcarrinhocompras_produtos_Class+"Odd";
               }
            }
         }
         imgprompt_19_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUTOID_"+sGXsfl_88_idx+"'), id:'"+"PRODUTOID_"+sGXsfl_88_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_13_"+sGXsfl_88_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 89,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridcarrinhocompras_produtosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,89);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdutoId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_19_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_19_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridcarrinhocompras_produtosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_19_Internalname,(string)sImgUrl,(string)imgprompt_19_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_19_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcarrinhocompras_produtosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoNome_Internalname,(string)A20ProdutoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdutoNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcarrinhocompras_produtosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoPreco_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")),StringUtil.LTrim( ((edtProdutoPreco_Enabled!=0) ? context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99") : context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoPreco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdutoPreco_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A23ProdutoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdutoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.PathToRelativeUrl( A23ProdutoImagem));
         Gridcarrinhocompras_produtosRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoImagem_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(int)edtProdutoImagem_Enabled,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)0,(bool)A23ProdutoImagem_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         AssignProp("", false, edtProdutoImagem_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.PathToRelativeUrl( A23ProdutoImagem)), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtProdutoImagem_Internalname, "IsBlob", StringUtil.BoolToStr( A23ProdutoImagem_IsBlob), !bGXsfl_88_Refreshing);
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_13_" + sGXsfl_88_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_88_idx + "',88)\"";
         ROClassString = "Attribute";
         Gridcarrinhocompras_produtosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasProdutosQuantid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A60CarrinhoComprasProdutosQuantid), 4, 0, ".", "")),StringUtil.LTrim( ((edtCarrinhoComprasProdutosQuantid_Enabled!=0) ? context.localUtil.Format( (decimal)(A60CarrinhoComprasProdutosQuantid), "ZZZ9") : context.localUtil.Format( (decimal)(A60CarrinhoComprasProdutosQuantid), "ZZZ9")))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,93);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasProdutosQuantid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtCarrinhoComprasProdutosQuantid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridcarrinhocompras_produtosRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutosPrecoTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A64ProdutosPrecoTotal, 10, 2, ".", "")),StringUtil.LTrim( ((edtProdutosPrecoTotal_Enabled!=0) ? context.localUtil.Format( A64ProdutosPrecoTotal, "ZZZZZZ9.99") : context.localUtil.Format( A64ProdutosPrecoTotal, "ZZZZZZ9.99"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutosPrecoTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdutosPrecoTotal_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)88,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         ajax_sending_grid_row(Gridcarrinhocompras_produtosRow);
         send_integrity_lvl_hashes0D13( ) ;
         GXCCtl = "Z19ProdutoId_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProdutoId), 4, 0, ".", "")));
         GXCCtl = "Z60CarrinhoComprasProdutosQuantid_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z60CarrinhoComprasProdutosQuantid), 4, 0, ".", "")));
         GXCCtl = "O64ProdutosPrecoTotal_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( O64ProdutosPrecoTotal, 10, 2, ".", "")));
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_13), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_13_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_13), 4, 0, ".", "")));
         GXCCtl = "nIsMod_13_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_13), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_88_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vCARRINHOCOMPRASID_" + sGXsfl_88_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CarrinhoComprasId), 4, 0, ".", "")));
         GXCCtl = "PRODUTOIMAGEM_" + sGXsfl_88_idx;
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A23ProdutoImagem);
         GxWebStd.gx_hidden_field( context, "PRODUTOID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTONOME_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTOPRECO_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoPreco_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTOIMAGEM_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoImagem_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "CARRINHOCOMPRASPRODUTOSQUANTID_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarrinhoComprasProdutosQuantid_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTOSPRECOTOTAL_"+sGXsfl_88_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutosPrecoTotal_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_19_"+sGXsfl_88_idx+"Link", StringUtil.RTrim( imgprompt_19_Link));
         ajax_sending_grid_row(null);
         Gridcarrinhocompras_produtosContainer.AddRow(Gridcarrinhocompras_produtosRow);
      }

      protected void ReadRow0D13( )
      {
         nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8813( ) ;
         edtProdutoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOID_"+sGXsfl_88_idx+"Enabled"), ".", ","));
         edtProdutoNome_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTONOME_"+sGXsfl_88_idx+"Enabled"), ".", ","));
         edtProdutoPreco_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOPRECO_"+sGXsfl_88_idx+"Enabled"), ".", ","));
         edtProdutoImagem_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOIMAGEM_"+sGXsfl_88_idx+"Enabled"), ".", ","));
         edtCarrinhoComprasProdutosQuantid_Enabled = (int)(context.localUtil.CToN( cgiGet( "CARRINHOCOMPRASPRODUTOSQUANTID_"+sGXsfl_88_idx+"Enabled"), ".", ","));
         edtProdutosPrecoTotal_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOSPRECOTOTAL_"+sGXsfl_88_idx+"Enabled"), ".", ","));
         imgprompt_54_Link = cgiGet( "PROMPT_19_"+sGXsfl_88_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUTOID_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
            wbErr = true;
            A19ProdutoId = 0;
         }
         else
         {
            A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ","));
         }
         A20ProdutoNome = cgiGet( edtProdutoNome_Internalname);
         A22ProdutoPreco = context.localUtil.CToN( cgiGet( edtProdutoPreco_Internalname), ".", ",");
         A23ProdutoImagem = cgiGet( edtProdutoImagem_Internalname);
         if ( ( ( context.localUtil.CToN( cgiGet( edtCarrinhoComprasProdutosQuantid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCarrinhoComprasProdutosQuantid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "CARRINHOCOMPRASPRODUTOSQUANTID_" + sGXsfl_88_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtCarrinhoComprasProdutosQuantid_Internalname;
            wbErr = true;
            A60CarrinhoComprasProdutosQuantid = 0;
         }
         else
         {
            A60CarrinhoComprasProdutosQuantid = (short)(context.localUtil.CToN( cgiGet( edtCarrinhoComprasProdutosQuantid_Internalname), ".", ","));
         }
         A64ProdutosPrecoTotal = context.localUtil.CToN( cgiGet( edtProdutosPrecoTotal_Internalname), ".", ",");
         GXCCtl = "Z19ProdutoId_" + sGXsfl_88_idx;
         Z19ProdutoId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "Z60CarrinhoComprasProdutosQuantid_" + sGXsfl_88_idx;
         Z60CarrinhoComprasProdutosQuantid = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "O64ProdutosPrecoTotal_" + sGXsfl_88_idx;
         O64ProdutosPrecoTotal = context.localUtil.CToN( cgiGet( GXCCtl), ".", ",");
         GXCCtl = "nRcdDeleted_13_" + sGXsfl_88_idx;
         nRcdDeleted_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_13_" + sGXsfl_88_idx;
         nRcdExists_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_13_" + sGXsfl_88_idx;
         nIsMod_13 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         getMultimediaValue(edtProdutoImagem_Internalname, ref  A23ProdutoImagem, ref  A40000ProdutoImagem_GXI);
      }

      protected void assign_properties_default( )
      {
         defedtProdutoId_Enabled = edtProdutoId_Enabled;
      }

      protected void ConfirmValues0D0( )
      {
         nGXsfl_88_idx = 0;
         sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
         SubsflControlProps_8813( ) ;
         while ( nGXsfl_88_idx < nRC_GXsfl_88 )
         {
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8813( ) ;
            ChangePostValue( "Z19ProdutoId_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z19ProdutoId_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z19ProdutoId_"+sGXsfl_88_idx) ;
            ChangePostValue( "Z60CarrinhoComprasProdutosQuantid_"+sGXsfl_88_idx, cgiGet( "ZT_"+"Z60CarrinhoComprasProdutosQuantid_"+sGXsfl_88_idx)) ;
            DeletePostValue( "ZT_"+"Z60CarrinhoComprasProdutosQuantid_"+sGXsfl_88_idx) ;
         }
         ChangePostValue( "O64ProdutosPrecoTotal", cgiGet( "T64ProdutosPrecoTotal")) ;
         DeletePostValue( "T64ProdutosPrecoTotal") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 849480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 849480), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 849480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("carrinhocompras.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CarrinhoComprasId,4,0))}, new string[] {"Gx_mode","CarrinhoComprasId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CarrinhoCompras");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("carrinhocompras:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z52CarrinhoComprasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z52CarrinhoComprasId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z53CarrinhoComprasData", context.localUtil.DToC( Z53CarrinhoComprasData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z54ClienteCarrinhoComprasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z54ClienteCarrinhoComprasId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "O62CarrinhoComprasPrecoTotal", StringUtil.LTrim( StringUtil.NToC( O62CarrinhoComprasPrecoTotal, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_88", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_88_idx), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N54ClienteCarrinhoComprasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54ClienteCarrinhoComprasId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vCARRINHOCOMPRASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CarrinhoComprasId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARRINHOCOMPRASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CarrinhoComprasId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTECARRINHOCOMPRASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteCarrinhoComprasId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vTODAY", context.localUtil.DToC( Gx_date, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
         GxWebStd.gx_hidden_field( context, "CATEGORIAPRODUTONOME", A31CategoriaProdutoNome);
         GxWebStd.gx_hidden_field( context, "CATEGORIAPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTOIMAGEM_GXI", A40000ProdutoImagem_GXI);
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
         return formatLink("carrinhocompras.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CarrinhoComprasId,4,0))}, new string[] {"Gx_mode","CarrinhoComprasId"})  ;
      }

      public override string GetPgmname( )
      {
         return "CarrinhoCompras" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carrinho de compras" ;
      }

      protected void InitializeNonKey0D12( )
      {
         A54ClienteCarrinhoComprasId = 0;
         AssignAttri("", false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
         A65CarrinhoComprasPontos = 0;
         AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         AssignAttri("", false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
         A55ClienteCarrinhoComprasNome = "";
         AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
         A56ClienteCarrinhoComprasEndereco = "";
         AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
         A57ClienteCarrinhoComprasPaisId = 0;
         AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
         A58ClienteCarrinhoComprasPaisNome = "";
         AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
         A62CarrinhoComprasPrecoTotal = 0;
         n62CarrinhoComprasPrecoTotal = false;
         AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         A53CarrinhoComprasData = Gx_date;
         AssignAttri("", false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
         O62CarrinhoComprasPrecoTotal = A62CarrinhoComprasPrecoTotal;
         n62CarrinhoComprasPrecoTotal = false;
         AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         Z53CarrinhoComprasData = DateTime.MinValue;
         Z54ClienteCarrinhoComprasId = 0;
      }

      protected void InitAll0D12( )
      {
         A52CarrinhoComprasId = 0;
         AssignAttri("", false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
         InitializeNonKey0D12( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A53CarrinhoComprasData = i53CarrinhoComprasData;
         AssignAttri("", false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
      }

      protected void InitializeNonKey0D13( )
      {
         A30CategoriaProdutoId = 0;
         AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
         A64ProdutosPrecoTotal = 0;
         A20ProdutoNome = "";
         A22ProdutoPreco = 0;
         A23ProdutoImagem = "";
         AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         A40000ProdutoImagem_GXI = "";
         AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_88_Refreshing);
         AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         A60CarrinhoComprasProdutosQuantid = 0;
         A31CategoriaProdutoNome = "";
         AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
         O64ProdutosPrecoTotal = A64ProdutosPrecoTotal;
         Z60CarrinhoComprasProdutosQuantid = 0;
      }

      protected void InitAll0D13( )
      {
         A19ProdutoId = 0;
         InitializeNonKey0D13( ) ;
      }

      protected void StandaloneModalInsert0D13( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20258291651424", true, true);
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
         context.AddJavascriptSource("carrinhocompras.js", "?20258291651425", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties13( )
      {
         edtProdutoId_Enabled = defedtProdutoId_Enabled;
         AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_88_Refreshing);
      }

      protected void StartGridControl88( )
      {
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("GridName", "Gridcarrinhocompras_produtos");
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Header", subGridcarrinhocompras_produtos_Header);
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Class", "Grid");
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Backcolorstyle), 1, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("CmpContext", "");
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("InMasterPage", "false");
         Gridcarrinhocompras_produtosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddColumnProperties(Gridcarrinhocompras_produtosColumn);
         Gridcarrinhocompras_produtosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrinhocompras_produtosContainer.AddColumnProperties(Gridcarrinhocompras_produtosColumn);
         Gridcarrinhocompras_produtosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Value", A20ProdutoNome);
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddColumnProperties(Gridcarrinhocompras_produtosColumn);
         Gridcarrinhocompras_produtosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoPreco_Enabled), 5, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddColumnProperties(Gridcarrinhocompras_produtosColumn);
         Gridcarrinhocompras_produtosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Value", context.convertURL( A23ProdutoImagem));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoImagem_Enabled), 5, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddColumnProperties(Gridcarrinhocompras_produtosColumn);
         Gridcarrinhocompras_produtosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A60CarrinhoComprasProdutosQuantid), 4, 0, ".", "")));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCarrinhoComprasProdutosQuantid_Enabled), 5, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddColumnProperties(Gridcarrinhocompras_produtosColumn);
         Gridcarrinhocompras_produtosColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A64ProdutosPrecoTotal, 10, 2, ".", "")));
         Gridcarrinhocompras_produtosColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutosPrecoTotal_Enabled), 5, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddColumnProperties(Gridcarrinhocompras_produtosColumn);
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Selectedindex), 4, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Allowselection), 1, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Selectioncolor), 9, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Allowhovering), 1, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Hoveringcolor), 9, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Allowcollapsing), 1, 0, ".", "")));
         Gridcarrinhocompras_produtosContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridcarrinhocompras_produtos_Collapsed), 1, 0, ".", "")));
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
         edtCarrinhoComprasId_Internalname = "CARRINHOCOMPRASID";
         edtCarrinhoComprasData_Internalname = "CARRINHOCOMPRASDATA";
         edtClienteCarrinhoComprasId_Internalname = "CLIENTECARRINHOCOMPRASID";
         edtClienteCarrinhoComprasNome_Internalname = "CLIENTECARRINHOCOMPRASNOME";
         edtClienteCarrinhoComprasEndereco_Internalname = "CLIENTECARRINHOCOMPRASENDERECO";
         edtClienteCarrinhoComprasPaisId_Internalname = "CLIENTECARRINHOCOMPRASPAISID";
         edtClienteCarrinhoComprasPaisNome_Internalname = "CLIENTECARRINHOCOMPRASPAISNOME";
         edtCarrinhoComprasPrecoTotal_Internalname = "CARRINHOCOMPRASPRECOTOTAL";
         edtCarrinhoComprasDataEntrega_Internalname = "CARRINHOCOMPRASDATAENTREGA";
         edtCarrinhoComprasPontos_Internalname = "CARRINHOCOMPRASPONTOS";
         lblTitleprodutos_Internalname = "TITLEPRODUTOS";
         edtProdutoId_Internalname = "PRODUTOID";
         edtProdutoNome_Internalname = "PRODUTONOME";
         edtProdutoPreco_Internalname = "PRODUTOPRECO";
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM";
         edtCarrinhoComprasProdutosQuantid_Internalname = "CARRINHOCOMPRASPRODUTOSQUANTID";
         edtProdutosPrecoTotal_Internalname = "PRODUTOSPRECOTOTAL";
         divProdutostable_Internalname = "PRODUTOSTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_54_Internalname = "PROMPT_54";
         imgprompt_19_Internalname = "PROMPT_19";
         subGridcarrinhocompras_produtos_Internalname = "GRIDCARRINHOCOMPRAS_PRODUTOS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridcarrinhocompras_produtos_Allowcollapsing = 0;
         subGridcarrinhocompras_produtos_Allowselection = 0;
         subGridcarrinhocompras_produtos_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Carrinho de compras";
         edtProdutosPrecoTotal_Jsonclick = "";
         edtCarrinhoComprasProdutosQuantid_Jsonclick = "";
         edtProdutoPreco_Jsonclick = "";
         edtProdutoNome_Jsonclick = "";
         imgprompt_19_Visible = 1;
         imgprompt_19_Link = "";
         imgprompt_54_Visible = 1;
         edtProdutoId_Jsonclick = "";
         subGridcarrinhocompras_produtos_Class = "Grid";
         subGridcarrinhocompras_produtos_Backcolorstyle = 0;
         edtProdutosPrecoTotal_Enabled = 0;
         edtCarrinhoComprasProdutosQuantid_Enabled = 1;
         edtProdutoImagem_Enabled = 0;
         edtProdutoPreco_Enabled = 0;
         edtProdutoNome_Enabled = 0;
         edtProdutoId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCarrinhoComprasPontos_Jsonclick = "";
         edtCarrinhoComprasPontos_Enabled = 0;
         edtCarrinhoComprasDataEntrega_Jsonclick = "";
         edtCarrinhoComprasDataEntrega_Enabled = 0;
         edtCarrinhoComprasPrecoTotal_Jsonclick = "";
         edtCarrinhoComprasPrecoTotal_Enabled = 0;
         edtClienteCarrinhoComprasPaisNome_Jsonclick = "";
         edtClienteCarrinhoComprasPaisNome_Enabled = 0;
         edtClienteCarrinhoComprasPaisId_Jsonclick = "";
         edtClienteCarrinhoComprasPaisId_Enabled = 0;
         edtClienteCarrinhoComprasEndereco_Enabled = 0;
         edtClienteCarrinhoComprasNome_Jsonclick = "";
         edtClienteCarrinhoComprasNome_Enabled = 0;
         imgprompt_54_Visible = 1;
         imgprompt_54_Link = "";
         edtClienteCarrinhoComprasId_Jsonclick = "";
         edtClienteCarrinhoComprasId_Enabled = 1;
         edtCarrinhoComprasData_Jsonclick = "";
         edtCarrinhoComprasData_Enabled = 1;
         edtCarrinhoComprasId_Jsonclick = "";
         edtCarrinhoComprasId_Enabled = 1;
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

      protected void gxnrGridcarrinhocompras_produtos_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_8813( ) ;
         while ( nGXsfl_88_idx <= nRC_GXsfl_88 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0D13( ) ;
            standaloneModal0D13( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0D13( ) ;
            nGXsfl_88_idx = (int)(nGXsfl_88_idx+1);
            sGXsfl_88_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_88_idx), 4, 0), 4, "0");
            SubsflControlProps_8813( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridcarrinhocompras_produtosContainer)) ;
         /* End function gxnrGridcarrinhocompras_produtos_newrow */
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

      public void Valid_Carrinhocomprasid( )
      {
         n62CarrinhoComprasPrecoTotal = false;
         /* Using cursor T000D25 */
         pr_default.execute(19, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(19) != 101) )
         {
            A62CarrinhoComprasPrecoTotal = T000D25_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = T000D25_n62CarrinhoComprasPrecoTotal[0];
         }
         else
         {
            A62CarrinhoComprasPrecoTotal = 0;
            n62CarrinhoComprasPrecoTotal = false;
         }
         pr_default.close(19);
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
         }
         else
         {
            A65CarrinhoComprasPontos = 0;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrim( StringUtil.NToC( A62CarrinhoComprasPrecoTotal, 10, 2, ".", "")));
         AssignAttri("", false, "A65CarrinhoComprasPontos", StringUtil.LTrim( StringUtil.NToC( A65CarrinhoComprasPontos, 10, 2, ".", "")));
      }

      public void Valid_Clientecarrinhocomprasid( )
      {
         /* Using cursor T000D26 */
         pr_default.execute(20, new Object[] {A54ClienteCarrinhoComprasId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASID");
            AnyError = 1;
            GX_FocusControl = edtClienteCarrinhoComprasId_Internalname;
         }
         A55ClienteCarrinhoComprasNome = T000D26_A55ClienteCarrinhoComprasNome[0];
         A56ClienteCarrinhoComprasEndereco = T000D26_A56ClienteCarrinhoComprasEndereco[0];
         A57ClienteCarrinhoComprasPaisId = T000D26_A57ClienteCarrinhoComprasPaisId[0];
         pr_default.close(20);
         /* Using cursor T000D27 */
         pr_default.execute(21, new Object[] {A57ClienteCarrinhoComprasPaisId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "CLIENTECARRINHOCOMPRASPAISID");
            AnyError = 1;
         }
         A58ClienteCarrinhoComprasPaisNome = T000D27_A58ClienteCarrinhoComprasPaisNome[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
         AssignAttri("", false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
         AssignAttri("", false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0, ".", "")));
         AssignAttri("", false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
      }

      public void Valid_Produtoid( )
      {
         /* Using cursor T000D36 */
         pr_default.execute(30, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(30) == 101) )
         {
            GX_msglist.addItem("No matching 'Produto'.", "ForeignKeyNotFound", 1, "PRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
         }
         A30CategoriaProdutoId = T000D36_A30CategoriaProdutoId[0];
         A20ProdutoNome = T000D36_A20ProdutoNome[0];
         A22ProdutoPreco = T000D36_A22ProdutoPreco[0];
         A40000ProdutoImagem_GXI = T000D36_A40000ProdutoImagem_GXI[0];
         A23ProdutoImagem = T000D36_A23ProdutoImagem[0];
         pr_default.close(30);
         /* Using cursor T000D37 */
         pr_default.execute(31, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(31) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
         }
         A31CategoriaProdutoNome = T000D37_A31CategoriaProdutoNome[0];
         pr_default.close(31);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")));
         AssignAttri("", false, "A20ProdutoNome", A20ProdutoNome);
         AssignAttri("", false, "A22ProdutoPreco", StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")));
         AssignAttri("", false, "A23ProdutoImagem", context.PathToRelativeUrl( A23ProdutoImagem));
         GXCCtl = "PRODUTOIMAGEM_" + sGXsfl_88_idx;
         AssignAttri("", false, "GXCCtl", GXCCtl);
         GXCCtlgxBlob = GXCCtl + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A23ProdutoImagem));
         AssignAttri("", false, "A40000ProdutoImagem_GXI", A40000ProdutoImagem_GXI);
         AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CarrinhoComprasId',fld:'vCARRINHOCOMPRASID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CarrinhoComprasId',fld:'vCARRINHOCOMPRASID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120D2',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_CARRINHOCOMPRASID","{handler:'Valid_Carrinhocomprasid',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9'},{av:'A62CarrinhoComprasPrecoTotal',fld:'CARRINHOCOMPRASPRECOTOTAL',pic:'ZZZZZZ9.99'},{av:'A65CarrinhoComprasPontos',fld:'CARRINHOCOMPRASPONTOS',pic:'ZZZZZZ9.99'}]");
         setEventMetadata("VALID_CARRINHOCOMPRASID",",oparms:[{av:'A62CarrinhoComprasPrecoTotal',fld:'CARRINHOCOMPRASPRECOTOTAL',pic:'ZZZZZZ9.99'},{av:'A65CarrinhoComprasPontos',fld:'CARRINHOCOMPRASPONTOS',pic:'ZZZZZZ9.99'}]}");
         setEventMetadata("VALID_CARRINHOCOMPRASDATA","{handler:'Valid_Carrinhocomprasdata',iparms:[]");
         setEventMetadata("VALID_CARRINHOCOMPRASDATA",",oparms:[]}");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASID","{handler:'Valid_Clientecarrinhocomprasid',iparms:[{av:'A54ClienteCarrinhoComprasId',fld:'CLIENTECARRINHOCOMPRASID',pic:'ZZZ9'},{av:'A57ClienteCarrinhoComprasPaisId',fld:'CLIENTECARRINHOCOMPRASPAISID',pic:'ZZZ9'},{av:'A55ClienteCarrinhoComprasNome',fld:'CLIENTECARRINHOCOMPRASNOME',pic:''},{av:'A56ClienteCarrinhoComprasEndereco',fld:'CLIENTECARRINHOCOMPRASENDERECO',pic:''},{av:'A58ClienteCarrinhoComprasPaisNome',fld:'CLIENTECARRINHOCOMPRASPAISNOME',pic:''}]");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASID",",oparms:[{av:'A55ClienteCarrinhoComprasNome',fld:'CLIENTECARRINHOCOMPRASNOME',pic:''},{av:'A56ClienteCarrinhoComprasEndereco',fld:'CLIENTECARRINHOCOMPRASENDERECO',pic:''},{av:'A57ClienteCarrinhoComprasPaisId',fld:'CLIENTECARRINHOCOMPRASPAISID',pic:'ZZZ9'},{av:'A58ClienteCarrinhoComprasPaisNome',fld:'CLIENTECARRINHOCOMPRASPAISNOME',pic:''}]}");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASPAISID","{handler:'Valid_Clientecarrinhocompraspaisid',iparms:[]");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASPAISID",",oparms:[]}");
         setEventMetadata("VALID_CARRINHOCOMPRASPRECOTOTAL","{handler:'Valid_Carrinhocomprasprecototal',iparms:[]");
         setEventMetadata("VALID_CARRINHOCOMPRASPRECOTOTAL",",oparms:[]}");
         setEventMetadata("VALID_PRODUTOID","{handler:'Valid_Produtoid',iparms:[{av:'A19ProdutoId',fld:'PRODUTOID',pic:'ZZZ9'},{av:'A30CategoriaProdutoId',fld:'CATEGORIAPRODUTOID',pic:'ZZZ9'},{av:'A20ProdutoNome',fld:'PRODUTONOME',pic:''},{av:'A22ProdutoPreco',fld:'PRODUTOPRECO',pic:'ZZZZZZ9.99'},{av:'A23ProdutoImagem',fld:'PRODUTOIMAGEM',pic:''},{av:'A40000ProdutoImagem_GXI',fld:'PRODUTOIMAGEM_GXI',pic:''},{av:'A31CategoriaProdutoNome',fld:'CATEGORIAPRODUTONOME',pic:''}]");
         setEventMetadata("VALID_PRODUTOID",",oparms:[{av:'A30CategoriaProdutoId',fld:'CATEGORIAPRODUTOID',pic:'ZZZ9'},{av:'A20ProdutoNome',fld:'PRODUTONOME',pic:''},{av:'A22ProdutoPreco',fld:'PRODUTOPRECO',pic:'ZZZZZZ9.99'},{av:'A23ProdutoImagem',fld:'PRODUTOIMAGEM',pic:''},{av:'A40000ProdutoImagem_GXI',fld:'PRODUTOIMAGEM_GXI',pic:''},{av:'A31CategoriaProdutoNome',fld:'CATEGORIAPRODUTONOME',pic:''}]}");
         setEventMetadata("VALID_PRODUTOPRECO","{handler:'Valid_Produtopreco',iparms:[]");
         setEventMetadata("VALID_PRODUTOPRECO",",oparms:[]}");
         setEventMetadata("VALID_CARRINHOCOMPRASPRODUTOSQUANTID","{handler:'Valid_Carrinhocomprasprodutosquantid',iparms:[]");
         setEventMetadata("VALID_CARRINHOCOMPRASPRODUTOSQUANTID",",oparms:[]}");
         setEventMetadata("VALID_PRODUTOSPRECOTOTAL","{handler:'Valid_Produtosprecototal',iparms:[]");
         setEventMetadata("VALID_PRODUTOSPRECOTOTAL",",oparms:[]}");
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
         pr_default.close(30);
         pr_default.close(31);
         pr_default.close(5);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(19);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z53CarrinhoComprasData = DateTime.MinValue;
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
         A53CarrinhoComprasData = DateTime.MinValue;
         imgprompt_54_gximage = "";
         sImgUrl = "";
         A55ClienteCarrinhoComprasNome = "";
         A56ClienteCarrinhoComprasEndereco = "";
         A58ClienteCarrinhoComprasPaisNome = "";
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         lblTitleprodutos_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridcarrinhocompras_produtosContainer = new GXWebGrid( context);
         sMode13 = "";
         sStyleString = "";
         Gx_date = DateTime.MinValue;
         AV15Pgmname = "";
         A31CategoriaProdutoNome = "";
         A40000ProdutoImagem_GXI = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode12 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A20ProdutoNome = "";
         A23ProdutoImagem = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z55ClienteCarrinhoComprasNome = "";
         Z56ClienteCarrinhoComprasEndereco = "";
         Z58ClienteCarrinhoComprasPaisNome = "";
         T000D11_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         T000D11_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         T000D8_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         T000D8_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         T000D8_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         T000D9_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         T000D13_A52CarrinhoComprasId = new short[1] ;
         T000D13_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         T000D13_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         T000D13_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         T000D13_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         T000D13_A54ClienteCarrinhoComprasId = new short[1] ;
         T000D13_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         T000D13_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         T000D13_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         T000D15_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         T000D15_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         T000D16_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         T000D16_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         T000D16_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         T000D17_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         T000D18_A52CarrinhoComprasId = new short[1] ;
         T000D7_A52CarrinhoComprasId = new short[1] ;
         T000D7_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         T000D7_A54ClienteCarrinhoComprasId = new short[1] ;
         T000D19_A52CarrinhoComprasId = new short[1] ;
         T000D20_A52CarrinhoComprasId = new short[1] ;
         T000D6_A52CarrinhoComprasId = new short[1] ;
         T000D6_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         T000D6_A54ClienteCarrinhoComprasId = new short[1] ;
         T000D25_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         T000D25_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         T000D26_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         T000D26_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         T000D26_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         T000D27_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         T000D28_A52CarrinhoComprasId = new short[1] ;
         Z20ProdutoNome = "";
         Z23ProdutoImagem = "";
         Z40000ProdutoImagem_GXI = "";
         Z31CategoriaProdutoNome = "";
         T000D29_A30CategoriaProdutoId = new short[1] ;
         T000D29_A52CarrinhoComprasId = new short[1] ;
         T000D29_A20ProdutoNome = new string[] {""} ;
         T000D29_A22ProdutoPreco = new decimal[1] ;
         T000D29_A40000ProdutoImagem_GXI = new string[] {""} ;
         T000D29_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         T000D29_A31CategoriaProdutoNome = new string[] {""} ;
         T000D29_A19ProdutoId = new short[1] ;
         T000D29_A23ProdutoImagem = new string[] {""} ;
         T000D4_A30CategoriaProdutoId = new short[1] ;
         T000D4_A20ProdutoNome = new string[] {""} ;
         T000D4_A22ProdutoPreco = new decimal[1] ;
         T000D4_A40000ProdutoImagem_GXI = new string[] {""} ;
         T000D4_A23ProdutoImagem = new string[] {""} ;
         T000D5_A31CategoriaProdutoNome = new string[] {""} ;
         T000D30_A30CategoriaProdutoId = new short[1] ;
         T000D30_A20ProdutoNome = new string[] {""} ;
         T000D30_A22ProdutoPreco = new decimal[1] ;
         T000D30_A40000ProdutoImagem_GXI = new string[] {""} ;
         T000D30_A23ProdutoImagem = new string[] {""} ;
         T000D31_A31CategoriaProdutoNome = new string[] {""} ;
         T000D32_A52CarrinhoComprasId = new short[1] ;
         T000D32_A19ProdutoId = new short[1] ;
         T000D3_A52CarrinhoComprasId = new short[1] ;
         T000D3_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         T000D3_A19ProdutoId = new short[1] ;
         T000D2_A52CarrinhoComprasId = new short[1] ;
         T000D2_A60CarrinhoComprasProdutosQuantid = new short[1] ;
         T000D2_A19ProdutoId = new short[1] ;
         T000D36_A30CategoriaProdutoId = new short[1] ;
         T000D36_A20ProdutoNome = new string[] {""} ;
         T000D36_A22ProdutoPreco = new decimal[1] ;
         T000D36_A40000ProdutoImagem_GXI = new string[] {""} ;
         T000D36_A23ProdutoImagem = new string[] {""} ;
         T000D37_A31CategoriaProdutoNome = new string[] {""} ;
         T000D38_A52CarrinhoComprasId = new short[1] ;
         T000D38_A19ProdutoId = new short[1] ;
         Gridcarrinhocompras_produtosRow = new GXWebRow();
         subGridcarrinhocompras_produtos_Linesclass = "";
         ROClassString = "";
         imgprompt_19_gximage = "";
         GXCCtlgxBlob = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i53CarrinhoComprasData = DateTime.MinValue;
         Gridcarrinhocompras_produtosColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carrinhocompras__default(),
            new Object[][] {
                new Object[] {
               T000D2_A52CarrinhoComprasId, T000D2_A60CarrinhoComprasProdutosQuantid, T000D2_A19ProdutoId
               }
               , new Object[] {
               T000D3_A52CarrinhoComprasId, T000D3_A60CarrinhoComprasProdutosQuantid, T000D3_A19ProdutoId
               }
               , new Object[] {
               T000D4_A30CategoriaProdutoId, T000D4_A20ProdutoNome, T000D4_A22ProdutoPreco, T000D4_A40000ProdutoImagem_GXI, T000D4_A23ProdutoImagem
               }
               , new Object[] {
               T000D5_A31CategoriaProdutoNome
               }
               , new Object[] {
               T000D6_A52CarrinhoComprasId, T000D6_A53CarrinhoComprasData, T000D6_A54ClienteCarrinhoComprasId
               }
               , new Object[] {
               T000D7_A52CarrinhoComprasId, T000D7_A53CarrinhoComprasData, T000D7_A54ClienteCarrinhoComprasId
               }
               , new Object[] {
               T000D8_A55ClienteCarrinhoComprasNome, T000D8_A56ClienteCarrinhoComprasEndereco, T000D8_A57ClienteCarrinhoComprasPaisId
               }
               , new Object[] {
               T000D9_A58ClienteCarrinhoComprasPaisNome
               }
               , new Object[] {
               T000D11_A62CarrinhoComprasPrecoTotal, T000D11_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               T000D13_A52CarrinhoComprasId, T000D13_A53CarrinhoComprasData, T000D13_A55ClienteCarrinhoComprasNome, T000D13_A56ClienteCarrinhoComprasEndereco, T000D13_A58ClienteCarrinhoComprasPaisNome, T000D13_A54ClienteCarrinhoComprasId, T000D13_A57ClienteCarrinhoComprasPaisId, T000D13_A62CarrinhoComprasPrecoTotal, T000D13_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               T000D15_A62CarrinhoComprasPrecoTotal, T000D15_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               T000D16_A55ClienteCarrinhoComprasNome, T000D16_A56ClienteCarrinhoComprasEndereco, T000D16_A57ClienteCarrinhoComprasPaisId
               }
               , new Object[] {
               T000D17_A58ClienteCarrinhoComprasPaisNome
               }
               , new Object[] {
               T000D18_A52CarrinhoComprasId
               }
               , new Object[] {
               T000D19_A52CarrinhoComprasId
               }
               , new Object[] {
               T000D20_A52CarrinhoComprasId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D25_A62CarrinhoComprasPrecoTotal, T000D25_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               T000D26_A55ClienteCarrinhoComprasNome, T000D26_A56ClienteCarrinhoComprasEndereco, T000D26_A57ClienteCarrinhoComprasPaisId
               }
               , new Object[] {
               T000D27_A58ClienteCarrinhoComprasPaisNome
               }
               , new Object[] {
               T000D28_A52CarrinhoComprasId
               }
               , new Object[] {
               T000D29_A30CategoriaProdutoId, T000D29_A52CarrinhoComprasId, T000D29_A20ProdutoNome, T000D29_A22ProdutoPreco, T000D29_A40000ProdutoImagem_GXI, T000D29_A60CarrinhoComprasProdutosQuantid, T000D29_A31CategoriaProdutoNome, T000D29_A19ProdutoId, T000D29_A23ProdutoImagem
               }
               , new Object[] {
               T000D30_A30CategoriaProdutoId, T000D30_A20ProdutoNome, T000D30_A22ProdutoPreco, T000D30_A40000ProdutoImagem_GXI, T000D30_A23ProdutoImagem
               }
               , new Object[] {
               T000D31_A31CategoriaProdutoNome
               }
               , new Object[] {
               T000D32_A52CarrinhoComprasId, T000D32_A19ProdutoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D36_A30CategoriaProdutoId, T000D36_A20ProdutoNome, T000D36_A22ProdutoPreco, T000D36_A40000ProdutoImagem_GXI, T000D36_A23ProdutoImagem
               }
               , new Object[] {
               T000D37_A31CategoriaProdutoNome
               }
               , new Object[] {
               T000D38_A52CarrinhoComprasId, T000D38_A19ProdutoId
               }
            }
         );
         AV15Pgmname = "CarrinhoCompras";
         Z53CarrinhoComprasData = DateTime.MinValue;
         A53CarrinhoComprasData = DateTime.MinValue;
         i53CarrinhoComprasData = DateTime.MinValue;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short nIsMod_13 ;
      private short wcpOAV7CarrinhoComprasId ;
      private short Z52CarrinhoComprasId ;
      private short Z54ClienteCarrinhoComprasId ;
      private short N54ClienteCarrinhoComprasId ;
      private short Z19ProdutoId ;
      private short Z60CarrinhoComprasProdutosQuantid ;
      private short nRcdDeleted_13 ;
      private short nRcdExists_13 ;
      private short GxWebError ;
      private short A52CarrinhoComprasId ;
      private short A54ClienteCarrinhoComprasId ;
      private short A57ClienteCarrinhoComprasPaisId ;
      private short A19ProdutoId ;
      private short A30CategoriaProdutoId ;
      private short AV7CarrinhoComprasId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount13 ;
      private short RcdFound13 ;
      private short nBlankRcdUsr13 ;
      private short AV11Insert_ClienteCarrinhoComprasId ;
      private short Gx_BScreen ;
      private short RcdFound12 ;
      private short A60CarrinhoComprasProdutosQuantid ;
      private short GX_JID ;
      private short Z57ClienteCarrinhoComprasPaisId ;
      private short nIsDirty_12 ;
      private short Z30CategoriaProdutoId ;
      private short nIsDirty_13 ;
      private short subGridcarrinhocompras_produtos_Backcolorstyle ;
      private short subGridcarrinhocompras_produtos_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridcarrinhocompras_produtos_Allowselection ;
      private short subGridcarrinhocompras_produtos_Allowhovering ;
      private short subGridcarrinhocompras_produtos_Allowcollapsing ;
      private short subGridcarrinhocompras_produtos_Collapsed ;
      private int nRC_GXsfl_88 ;
      private int nGXsfl_88_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCarrinhoComprasId_Enabled ;
      private int edtCarrinhoComprasData_Enabled ;
      private int edtClienteCarrinhoComprasId_Enabled ;
      private int imgprompt_54_Visible ;
      private int edtClienteCarrinhoComprasNome_Enabled ;
      private int edtClienteCarrinhoComprasEndereco_Enabled ;
      private int edtClienteCarrinhoComprasPaisId_Enabled ;
      private int edtClienteCarrinhoComprasPaisNome_Enabled ;
      private int edtCarrinhoComprasPrecoTotal_Enabled ;
      private int edtCarrinhoComprasDataEntrega_Enabled ;
      private int edtCarrinhoComprasPontos_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProdutoId_Enabled ;
      private int edtProdutoNome_Enabled ;
      private int edtProdutoPreco_Enabled ;
      private int edtProdutoImagem_Enabled ;
      private int edtCarrinhoComprasProdutosQuantid_Enabled ;
      private int edtProdutosPrecoTotal_Enabled ;
      private int fRowAdded ;
      private int AV16GXV1 ;
      private int subGridcarrinhocompras_produtos_Backcolor ;
      private int subGridcarrinhocompras_produtos_Allbackcolor ;
      private int imgprompt_19_Visible ;
      private int defedtProdutoId_Enabled ;
      private int idxLst ;
      private int subGridcarrinhocompras_produtos_Selectedindex ;
      private int subGridcarrinhocompras_produtos_Selectioncolor ;
      private int subGridcarrinhocompras_produtos_Hoveringcolor ;
      private long GRIDCARRINHOCOMPRAS_PRODUTOS_nFirstRecordOnPage ;
      private decimal O62CarrinhoComprasPrecoTotal ;
      private decimal O64ProdutosPrecoTotal ;
      private decimal A62CarrinhoComprasPrecoTotal ;
      private decimal A65CarrinhoComprasPontos ;
      private decimal B62CarrinhoComprasPrecoTotal ;
      private decimal s62CarrinhoComprasPrecoTotal ;
      private decimal s65CarrinhoComprasPontos ;
      private decimal O65CarrinhoComprasPontos ;
      private decimal A22ProdutoPreco ;
      private decimal A64ProdutosPrecoTotal ;
      private decimal T64ProdutosPrecoTotal ;
      private decimal Z62CarrinhoComprasPrecoTotal ;
      private decimal Z22ProdutoPreco ;
      private decimal Z65CarrinhoComprasPontos ;
      private string sPrefix ;
      private string sGXsfl_88_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCarrinhoComprasId_Internalname ;
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
      private string edtCarrinhoComprasId_Jsonclick ;
      private string edtCarrinhoComprasData_Internalname ;
      private string edtCarrinhoComprasData_Jsonclick ;
      private string edtClienteCarrinhoComprasId_Internalname ;
      private string edtClienteCarrinhoComprasId_Jsonclick ;
      private string imgprompt_54_gximage ;
      private string sImgUrl ;
      private string imgprompt_54_Internalname ;
      private string imgprompt_54_Link ;
      private string edtClienteCarrinhoComprasNome_Internalname ;
      private string edtClienteCarrinhoComprasNome_Jsonclick ;
      private string edtClienteCarrinhoComprasEndereco_Internalname ;
      private string edtClienteCarrinhoComprasPaisId_Internalname ;
      private string edtClienteCarrinhoComprasPaisId_Jsonclick ;
      private string edtClienteCarrinhoComprasPaisNome_Internalname ;
      private string edtClienteCarrinhoComprasPaisNome_Jsonclick ;
      private string edtCarrinhoComprasPrecoTotal_Internalname ;
      private string edtCarrinhoComprasPrecoTotal_Jsonclick ;
      private string edtCarrinhoComprasDataEntrega_Internalname ;
      private string edtCarrinhoComprasDataEntrega_Jsonclick ;
      private string edtCarrinhoComprasPontos_Internalname ;
      private string edtCarrinhoComprasPontos_Jsonclick ;
      private string divProdutostable_Internalname ;
      private string lblTitleprodutos_Internalname ;
      private string lblTitleprodutos_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode13 ;
      private string edtProdutoId_Internalname ;
      private string edtProdutoNome_Internalname ;
      private string edtProdutoPreco_Internalname ;
      private string edtProdutoImagem_Internalname ;
      private string edtCarrinhoComprasProdutosQuantid_Internalname ;
      private string edtProdutosPrecoTotal_Internalname ;
      private string sStyleString ;
      private string subGridcarrinhocompras_produtos_Internalname ;
      private string AV15Pgmname ;
      private string hsh ;
      private string sMode12 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_19_Internalname ;
      private string sGXsfl_88_fel_idx="0001" ;
      private string subGridcarrinhocompras_produtos_Class ;
      private string subGridcarrinhocompras_produtos_Linesclass ;
      private string imgprompt_19_Link ;
      private string ROClassString ;
      private string edtProdutoId_Jsonclick ;
      private string imgprompt_19_gximage ;
      private string edtProdutoNome_Jsonclick ;
      private string edtProdutoPreco_Jsonclick ;
      private string edtCarrinhoComprasProdutosQuantid_Jsonclick ;
      private string edtProdutosPrecoTotal_Jsonclick ;
      private string GXCCtlgxBlob ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridcarrinhocompras_produtos_Header ;
      private DateTime Z53CarrinhoComprasData ;
      private DateTime A53CarrinhoComprasData ;
      private DateTime A63CarrinhoComprasDataEntrega ;
      private DateTime Gx_date ;
      private DateTime i53CarrinhoComprasData ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n62CarrinhoComprasPrecoTotal ;
      private bool bGXsfl_88_Refreshing=false ;
      private bool returnInSub ;
      private bool A23ProdutoImagem_IsBlob ;
      private string A55ClienteCarrinhoComprasNome ;
      private string A56ClienteCarrinhoComprasEndereco ;
      private string A58ClienteCarrinhoComprasPaisNome ;
      private string A31CategoriaProdutoNome ;
      private string A40000ProdutoImagem_GXI ;
      private string A20ProdutoNome ;
      private string Z55ClienteCarrinhoComprasNome ;
      private string Z56ClienteCarrinhoComprasEndereco ;
      private string Z58ClienteCarrinhoComprasPaisNome ;
      private string Z20ProdutoNome ;
      private string Z40000ProdutoImagem_GXI ;
      private string Z31CategoriaProdutoNome ;
      private string A23ProdutoImagem ;
      private string Z23ProdutoImagem ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridcarrinhocompras_produtosContainer ;
      private GXWebRow Gridcarrinhocompras_produtosRow ;
      private GXWebColumn Gridcarrinhocompras_produtosColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000D11_A62CarrinhoComprasPrecoTotal ;
      private bool[] T000D11_n62CarrinhoComprasPrecoTotal ;
      private string[] T000D8_A55ClienteCarrinhoComprasNome ;
      private string[] T000D8_A56ClienteCarrinhoComprasEndereco ;
      private short[] T000D8_A57ClienteCarrinhoComprasPaisId ;
      private string[] T000D9_A58ClienteCarrinhoComprasPaisNome ;
      private short[] T000D13_A52CarrinhoComprasId ;
      private DateTime[] T000D13_A53CarrinhoComprasData ;
      private string[] T000D13_A55ClienteCarrinhoComprasNome ;
      private string[] T000D13_A56ClienteCarrinhoComprasEndereco ;
      private string[] T000D13_A58ClienteCarrinhoComprasPaisNome ;
      private short[] T000D13_A54ClienteCarrinhoComprasId ;
      private short[] T000D13_A57ClienteCarrinhoComprasPaisId ;
      private decimal[] T000D13_A62CarrinhoComprasPrecoTotal ;
      private bool[] T000D13_n62CarrinhoComprasPrecoTotal ;
      private decimal[] T000D15_A62CarrinhoComprasPrecoTotal ;
      private bool[] T000D15_n62CarrinhoComprasPrecoTotal ;
      private string[] T000D16_A55ClienteCarrinhoComprasNome ;
      private string[] T000D16_A56ClienteCarrinhoComprasEndereco ;
      private short[] T000D16_A57ClienteCarrinhoComprasPaisId ;
      private string[] T000D17_A58ClienteCarrinhoComprasPaisNome ;
      private short[] T000D18_A52CarrinhoComprasId ;
      private short[] T000D7_A52CarrinhoComprasId ;
      private DateTime[] T000D7_A53CarrinhoComprasData ;
      private short[] T000D7_A54ClienteCarrinhoComprasId ;
      private short[] T000D19_A52CarrinhoComprasId ;
      private short[] T000D20_A52CarrinhoComprasId ;
      private short[] T000D6_A52CarrinhoComprasId ;
      private DateTime[] T000D6_A53CarrinhoComprasData ;
      private short[] T000D6_A54ClienteCarrinhoComprasId ;
      private decimal[] T000D25_A62CarrinhoComprasPrecoTotal ;
      private bool[] T000D25_n62CarrinhoComprasPrecoTotal ;
      private string[] T000D26_A55ClienteCarrinhoComprasNome ;
      private string[] T000D26_A56ClienteCarrinhoComprasEndereco ;
      private short[] T000D26_A57ClienteCarrinhoComprasPaisId ;
      private string[] T000D27_A58ClienteCarrinhoComprasPaisNome ;
      private short[] T000D28_A52CarrinhoComprasId ;
      private short[] T000D29_A30CategoriaProdutoId ;
      private short[] T000D29_A52CarrinhoComprasId ;
      private string[] T000D29_A20ProdutoNome ;
      private decimal[] T000D29_A22ProdutoPreco ;
      private string[] T000D29_A40000ProdutoImagem_GXI ;
      private short[] T000D29_A60CarrinhoComprasProdutosQuantid ;
      private string[] T000D29_A31CategoriaProdutoNome ;
      private short[] T000D29_A19ProdutoId ;
      private string[] T000D29_A23ProdutoImagem ;
      private short[] T000D4_A30CategoriaProdutoId ;
      private string[] T000D4_A20ProdutoNome ;
      private decimal[] T000D4_A22ProdutoPreco ;
      private string[] T000D4_A40000ProdutoImagem_GXI ;
      private string[] T000D4_A23ProdutoImagem ;
      private string[] T000D5_A31CategoriaProdutoNome ;
      private short[] T000D30_A30CategoriaProdutoId ;
      private string[] T000D30_A20ProdutoNome ;
      private decimal[] T000D30_A22ProdutoPreco ;
      private string[] T000D30_A40000ProdutoImagem_GXI ;
      private string[] T000D30_A23ProdutoImagem ;
      private string[] T000D31_A31CategoriaProdutoNome ;
      private short[] T000D32_A52CarrinhoComprasId ;
      private short[] T000D32_A19ProdutoId ;
      private short[] T000D3_A52CarrinhoComprasId ;
      private short[] T000D3_A60CarrinhoComprasProdutosQuantid ;
      private short[] T000D3_A19ProdutoId ;
      private short[] T000D2_A52CarrinhoComprasId ;
      private short[] T000D2_A60CarrinhoComprasProdutosQuantid ;
      private short[] T000D2_A19ProdutoId ;
      private short[] T000D36_A30CategoriaProdutoId ;
      private string[] T000D36_A20ProdutoNome ;
      private decimal[] T000D36_A22ProdutoPreco ;
      private string[] T000D36_A40000ProdutoImagem_GXI ;
      private string[] T000D36_A23ProdutoImagem ;
      private string[] T000D37_A31CategoriaProdutoNome ;
      private short[] T000D38_A52CarrinhoComprasId ;
      private short[] T000D38_A19ProdutoId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class carrinhocompras__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new ForEachCursor(def[11])
         ,new ForEachCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new UpdateCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
         ,new ForEachCursor(def[21])
         ,new ForEachCursor(def[22])
         ,new ForEachCursor(def[23])
         ,new ForEachCursor(def[24])
         ,new ForEachCursor(def[25])
         ,new ForEachCursor(def[26])
         ,new UpdateCursor(def[27])
         ,new UpdateCursor(def[28])
         ,new UpdateCursor(def[29])
         ,new ForEachCursor(def[30])
         ,new ForEachCursor(def[31])
         ,new ForEachCursor(def[32])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000D13;
          prmT000D13 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D11;
          prmT000D11 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D8;
          prmT000D8 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D9;
          prmT000D9 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasPaisId",GXType.Int16,4,0)
          };
          Object[] prmT000D15;
          prmT000D15 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D16;
          prmT000D16 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D17;
          prmT000D17 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasPaisId",GXType.Int16,4,0)
          };
          Object[] prmT000D18;
          prmT000D18 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D7;
          prmT000D7 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D19;
          prmT000D19 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D20;
          prmT000D20 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D6;
          prmT000D6 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D21;
          prmT000D21 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasData",GXType.Date,8,0) ,
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D22;
          prmT000D22 = new Object[] {
          new ParDef("@CarrinhoComprasData",GXType.Date,8,0) ,
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D23;
          prmT000D23 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D28;
          prmT000D28 = new Object[] {
          };
          Object[] prmT000D29;
          prmT000D29 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D4;
          prmT000D4 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D5;
          prmT000D5 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D30;
          prmT000D30 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D31;
          prmT000D31 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D32;
          prmT000D32 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D3;
          prmT000D3 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D2;
          prmT000D2 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D33;
          prmT000D33 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasProdutosQuantid",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D34;
          prmT000D34 = new Object[] {
          new ParDef("@CarrinhoComprasProdutosQuantid",GXType.Int16,4,0) ,
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D35;
          prmT000D35 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D38;
          prmT000D38 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D25;
          prmT000D25 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D26;
          prmT000D26 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmT000D27;
          prmT000D27 = new Object[] {
          new ParDef("@ClienteCarrinhoComprasPaisId",GXType.Int16,4,0)
          };
          Object[] prmT000D36;
          prmT000D36 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000D37;
          prmT000D37 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000D2", "SELECT [CarrinhoComprasId], [CarrinhoComprasProdutosQuantid], [ProdutoId] FROM [CarrinhoComprasProdutos] WITH (UPDLOCK) WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D3", "SELECT [CarrinhoComprasId], [CarrinhoComprasProdutosQuantid], [ProdutoId] FROM [CarrinhoComprasProdutos] WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D4", "SELECT [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoNome], [ProdutoPreco], [ProdutoImagem_GXI], [ProdutoImagem] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D5", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D6", "SELECT [CarrinhoComprasId], [CarrinhoComprasData], [ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId FROM [CarrinhoCompras] WITH (UPDLOCK) WHERE [CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D7", "SELECT [CarrinhoComprasId], [CarrinhoComprasData], [ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId FROM [CarrinhoCompras] WHERE [CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D8", "SELECT [ClienteNome] AS ClienteCarrinhoComprasNome, [ClienteEndereco] AS ClienteCarrinhoComprasEndereco, [PaisClienteId] AS ClienteCarrinhoComprasPaisId FROM [Cliente] WHERE [ClienteId] = @ClienteCarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D9", "SELECT [PaisNome] AS ClienteCarrinhoComprasPaisNome FROM [Pais] WHERE [PaisId] = @ClienteCarrinhoComprasPaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D9,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D11", "SELECT COALESCE( T1.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (SELECT SUM(CASE  WHEN T4.[CategoriaNome] = 'Joalheria' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T4.[CategoriaNome] = 'Entreterimento' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T2.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T2 WITH (UPDLOCK) INNER JOIN [Produto] T3 ON T3.[ProdutoId] = T2.[ProdutoId]) INNER JOIN [Categoria] T4 ON T4.[CategoriaId] = T3.[CategoriaProdutoId]) GROUP BY T2.[CarrinhoComprasId] ) T1 WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D13", "SELECT TM1.[CarrinhoComprasId], TM1.[CarrinhoComprasData], T3.[ClienteNome] AS ClienteCarrinhoComprasNome, T3.[ClienteEndereco] AS ClienteCarrinhoComprasEndereco, T4.[PaisNome] AS ClienteCarrinhoComprasPaisNome, TM1.[ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId, T3.[PaisClienteId] AS ClienteCarrinhoComprasPaisId, COALESCE( T2.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM ((([CarrinhoCompras] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T2 ON T2.[CarrinhoComprasId] = TM1.[CarrinhoComprasId]) INNER JOIN [Cliente] T3 ON T3.[ClienteId] = TM1.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisClienteId]) WHERE TM1.[CarrinhoComprasId] = @CarrinhoComprasId ORDER BY TM1.[CarrinhoComprasId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D13,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D15", "SELECT COALESCE( T1.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (SELECT SUM(CASE  WHEN T4.[CategoriaNome] = 'Joalheria' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T4.[CategoriaNome] = 'Entreterimento' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T2.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T2 WITH (UPDLOCK) INNER JOIN [Produto] T3 ON T3.[ProdutoId] = T2.[ProdutoId]) INNER JOIN [Categoria] T4 ON T4.[CategoriaId] = T3.[CategoriaProdutoId]) GROUP BY T2.[CarrinhoComprasId] ) T1 WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D16", "SELECT [ClienteNome] AS ClienteCarrinhoComprasNome, [ClienteEndereco] AS ClienteCarrinhoComprasEndereco, [PaisClienteId] AS ClienteCarrinhoComprasPaisId FROM [Cliente] WHERE [ClienteId] = @ClienteCarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D17", "SELECT [PaisNome] AS ClienteCarrinhoComprasPaisNome FROM [Pais] WHERE [PaisId] = @ClienteCarrinhoComprasPaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D17,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D18", "SELECT [CarrinhoComprasId] FROM [CarrinhoCompras] WHERE [CarrinhoComprasId] = @CarrinhoComprasId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D18,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D19", "SELECT TOP 1 [CarrinhoComprasId] FROM [CarrinhoCompras] WHERE ( [CarrinhoComprasId] > @CarrinhoComprasId) ORDER BY [CarrinhoComprasId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D19,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000D20", "SELECT TOP 1 [CarrinhoComprasId] FROM [CarrinhoCompras] WHERE ( [CarrinhoComprasId] < @CarrinhoComprasId) ORDER BY [CarrinhoComprasId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D20,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000D21", "INSERT INTO [CarrinhoCompras]([CarrinhoComprasId], [CarrinhoComprasData], [ClienteCarrinhoComprasId]) VALUES(@CarrinhoComprasId, @CarrinhoComprasData, @ClienteCarrinhoComprasId)", GxErrorMask.GX_NOMASK,prmT000D21)
             ,new CursorDef("T000D22", "UPDATE [CarrinhoCompras] SET [CarrinhoComprasData]=@CarrinhoComprasData, [ClienteCarrinhoComprasId]=@ClienteCarrinhoComprasId  WHERE [CarrinhoComprasId] = @CarrinhoComprasId", GxErrorMask.GX_NOMASK,prmT000D22)
             ,new CursorDef("T000D23", "DELETE FROM [CarrinhoCompras]  WHERE [CarrinhoComprasId] = @CarrinhoComprasId", GxErrorMask.GX_NOMASK,prmT000D23)
             ,new CursorDef("T000D25", "SELECT COALESCE( T1.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (SELECT SUM(CASE  WHEN T4.[CategoriaNome] = 'Joalheria' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T4.[CategoriaNome] = 'Entreterimento' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T2.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T2 WITH (UPDLOCK) INNER JOIN [Produto] T3 ON T3.[ProdutoId] = T2.[ProdutoId]) INNER JOIN [Categoria] T4 ON T4.[CategoriaId] = T3.[CategoriaProdutoId]) GROUP BY T2.[CarrinhoComprasId] ) T1 WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D26", "SELECT [ClienteNome] AS ClienteCarrinhoComprasNome, [ClienteEndereco] AS ClienteCarrinhoComprasEndereco, [PaisClienteId] AS ClienteCarrinhoComprasPaisId FROM [Cliente] WHERE [ClienteId] = @ClienteCarrinhoComprasId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D26,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D27", "SELECT [PaisNome] AS ClienteCarrinhoComprasPaisNome FROM [Pais] WHERE [PaisId] = @ClienteCarrinhoComprasPaisId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D27,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D28", "SELECT [CarrinhoComprasId] FROM [CarrinhoCompras] ORDER BY [CarrinhoComprasId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000D28,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D29", "SELECT T2.[CategoriaProdutoId] AS CategoriaProdutoId, T1.[CarrinhoComprasId], T2.[ProdutoNome], T2.[ProdutoPreco], T2.[ProdutoImagem_GXI], T1.[CarrinhoComprasProdutosQuantid], T3.[CategoriaNome] AS CategoriaProdutoNome, T1.[ProdutoId], T2.[ProdutoImagem] FROM (([CarrinhoComprasProdutos] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[ProdutoId]) INNER JOIN [Categoria] T3 ON T3.[CategoriaId] = T2.[CategoriaProdutoId]) WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId and T1.[ProdutoId] = @ProdutoId ORDER BY T1.[CarrinhoComprasId], T1.[ProdutoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D29,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D30", "SELECT [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoNome], [ProdutoPreco], [ProdutoImagem_GXI], [ProdutoImagem] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D30,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D31", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D31,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D32", "SELECT [CarrinhoComprasId], [ProdutoId] FROM [CarrinhoComprasProdutos] WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D32,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D33", "INSERT INTO [CarrinhoComprasProdutos]([CarrinhoComprasId], [CarrinhoComprasProdutosQuantid], [ProdutoId]) VALUES(@CarrinhoComprasId, @CarrinhoComprasProdutosQuantid, @ProdutoId)", GxErrorMask.GX_NOMASK,prmT000D33)
             ,new CursorDef("T000D34", "UPDATE [CarrinhoComprasProdutos] SET [CarrinhoComprasProdutosQuantid]=@CarrinhoComprasProdutosQuantid  WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmT000D34)
             ,new CursorDef("T000D35", "DELETE FROM [CarrinhoComprasProdutos]  WHERE [CarrinhoComprasId] = @CarrinhoComprasId AND [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmT000D35)
             ,new CursorDef("T000D36", "SELECT [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoNome], [ProdutoPreco], [ProdutoImagem_GXI], [ProdutoImagem] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D36,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D37", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D37,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000D38", "SELECT [CarrinhoComprasId], [ProdutoId] FROM [CarrinhoComprasProdutos] WHERE [CarrinhoComprasId] = @CarrinhoComprasId ORDER BY [CarrinhoComprasId], [ProdutoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D38,11, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 6 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 10 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
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
             case 15 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((string[]) buf[8])[0] = rslt.getMultimediaFile(9, rslt.getVarchar(5));
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                return;
             case 25 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 26 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
       getresults30( cursor, rslt, buf) ;
    }

    public void getresults30( int cursor ,
                              IFieldGetter rslt ,
                              Object[] buf )
    {
       switch ( cursor )
       {
             case 30 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaFile(5, rslt.getVarchar(4));
                return;
             case 31 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 32 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
