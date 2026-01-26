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
   public class produto : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A24VendedorProdutoId = (short)(NumberUtil.Val( GetPar( "VendedorProdutoId"), "."));
            AssignAttri("", false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A24VendedorProdutoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_23") == 0 )
         {
            A26PaisProdutoId = (short)(NumberUtil.Val( GetPar( "PaisProdutoId"), "."));
            AssignAttri("", false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_23( A26PaisProdutoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_24") == 0 )
         {
            A28FornecedorProdutoId = (short)(NumberUtil.Val( GetPar( "FornecedorProdutoId"), "."));
            AssignAttri("", false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_24( A28FornecedorProdutoId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A30CategoriaProdutoId = (short)(NumberUtil.Val( GetPar( "CategoriaProdutoId"), "."));
            AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A30CategoriaProdutoId) ;
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
               AV7ProdutoId = (short)(NumberUtil.Val( GetPar( "ProdutoId"), "."));
               AssignAttri("", false, "AV7ProdutoId", StringUtil.LTrimStr( (decimal)(AV7ProdutoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPRODUTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProdutoId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Produto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public produto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public produto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_ProdutoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ProdutoId = aP1_ProdutoId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Produto", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Produto.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Produto.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdutoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdutoId_Internalname, "Produto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdutoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdutoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdutoNome_Internalname, "Produto", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdutoNome_Internalname, A20ProdutoNome, StringUtil.RTrim( context.localUtil.Format( A20ProdutoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdutoDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdutoDescricao_Internalname, "Descrição", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdutoDescricao_Internalname, A21ProdutoDescricao, StringUtil.RTrim( context.localUtil.Format( A21ProdutoDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoDescricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdutoDescricao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdutoPreco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtProdutoPreco_Internalname, "Preço", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtProdutoPreco_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")), StringUtil.LTrim( ((edtProdutoPreco_Enabled!=0) ? context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99") : context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoPreco_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtProdutoPreco_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgProdutoImagem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagem", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A23ProdutoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdutoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.PathToRelativeUrl( A23ProdutoImagem));
         GxWebStd.gx_bitmap( context, imgProdutoImagem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgProdutoImagem_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", "", "", 0, A23ProdutoImagem_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Produto.htm");
         AssignProp("", false, imgProdutoImagem_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.PathToRelativeUrl( A23ProdutoImagem)), true);
         AssignProp("", false, imgProdutoImagem_Internalname, "IsBlob", StringUtil.BoolToStr( A23ProdutoImagem_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVendedorProdutoId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVendedorProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24VendedorProdutoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A24VendedorProdutoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorProdutoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorProdutoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Produto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_24_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_24_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_24_Internalname, sImgUrl, imgprompt_24_Link, "", "", context.GetTheme( ), imgprompt_24_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtVendedorProdutoNome_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtVendedorProdutoNome_Internalname, A25VendedorProdutoNome, StringUtil.RTrim( context.localUtil.Format( A25VendedorProdutoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorProdutoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtVendedorProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgVendedorProdutoImagem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagem", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A68VendedorProdutoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001VendedorProdutoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.PathToRelativeUrl( A68VendedorProdutoImagem));
         GxWebStd.gx_bitmap( context, imgVendedorProdutoImagem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgVendedorProdutoImagem_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 0, A68VendedorProdutoImagem_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Produto.htm");
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.PathToRelativeUrl( A68VendedorProdutoImagem)), true);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "IsBlob", StringUtil.BoolToStr( A68VendedorProdutoImagem_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisProdutoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisProdutoId_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPaisProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26PaisProdutoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A26PaisProdutoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisProdutoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisProdutoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Produto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_26_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_26_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_26_Internalname, sImgUrl, imgprompt_26_Link, "", "", context.GetTheme( ), imgprompt_26_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPaisProdutoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPaisProdutoNome_Internalname, "País", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPaisProdutoNome_Internalname, A27PaisProdutoNome, StringUtil.RTrim( context.localUtil.Format( A27PaisProdutoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisProdutoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPaisProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFornecedorProdutoId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtFornecedorProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FornecedorProdutoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A28FornecedorProdutoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFornecedorProdutoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFornecedorProdutoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Produto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_28_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_28_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_28_Internalname, sImgUrl, imgprompt_28_Link, "", "", context.GetTheme( ), imgprompt_28_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtFornecedorProdutoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtFornecedorProdutoNome_Internalname, "Fornecedor", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtFornecedorProdutoNome_Internalname, A29FornecedorProdutoNome, StringUtil.RTrim( context.localUtil.Format( A29FornecedorProdutoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFornecedorProdutoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtFornecedorProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoriaProdutoId_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCategoriaProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A30CategoriaProdutoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaProdutoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaProdutoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Produto.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_30_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_30_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_30_Internalname, sImgUrl, imgprompt_30_Link, "", "", context.GetTheme( ), imgprompt_30_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCategoriaProdutoNome_Internalname+"\"", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCategoriaProdutoNome_Internalname, A31CategoriaProdutoNome, StringUtil.RTrim( context.localUtil.Format( A31CategoriaProdutoNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaProdutoNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCategoriaProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_Produto.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produto.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Produto.htm");
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
         E11062 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z19ProdutoId = (short)(context.localUtil.CToN( cgiGet( "Z19ProdutoId"), ".", ","));
               Z20ProdutoNome = cgiGet( "Z20ProdutoNome");
               Z21ProdutoDescricao = cgiGet( "Z21ProdutoDescricao");
               Z22ProdutoPreco = context.localUtil.CToN( cgiGet( "Z22ProdutoPreco"), ".", ",");
               Z24VendedorProdutoId = (short)(context.localUtil.CToN( cgiGet( "Z24VendedorProdutoId"), ".", ","));
               Z26PaisProdutoId = (short)(context.localUtil.CToN( cgiGet( "Z26PaisProdutoId"), ".", ","));
               Z28FornecedorProdutoId = (short)(context.localUtil.CToN( cgiGet( "Z28FornecedorProdutoId"), ".", ","));
               Z30CategoriaProdutoId = (short)(context.localUtil.CToN( cgiGet( "Z30CategoriaProdutoId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N24VendedorProdutoId = (short)(context.localUtil.CToN( cgiGet( "N24VendedorProdutoId"), ".", ","));
               N26PaisProdutoId = (short)(context.localUtil.CToN( cgiGet( "N26PaisProdutoId"), ".", ","));
               N28FornecedorProdutoId = (short)(context.localUtil.CToN( cgiGet( "N28FornecedorProdutoId"), ".", ","));
               N30CategoriaProdutoId = (short)(context.localUtil.CToN( cgiGet( "N30CategoriaProdutoId"), ".", ","));
               AV7ProdutoId = (short)(context.localUtil.CToN( cgiGet( "vPRODUTOID"), ".", ","));
               AV11Insert_VendedorProdutoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_VENDEDORPRODUTOID"), ".", ","));
               AV12Insert_PaisProdutoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_PAISPRODUTOID"), ".", ","));
               AV13Insert_FornecedorProdutoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_FORNECEDORPRODUTOID"), ".", ","));
               AV14Insert_CategoriaProdutoId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CATEGORIAPRODUTOID"), ".", ","));
               A40000ProdutoImagem_GXI = cgiGet( "PRODUTOIMAGEM_GXI");
               A40001VendedorProdutoImagem_GXI = cgiGet( "VENDEDORPRODUTOIMAGEM_GXI");
               AV16Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUTOID");
                  AnyError = 1;
                  GX_FocusControl = edtProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A19ProdutoId = 0;
                  AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
               }
               else
               {
                  A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ","));
                  AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
               }
               A20ProdutoNome = cgiGet( edtProdutoNome_Internalname);
               AssignAttri("", false, "A20ProdutoNome", A20ProdutoNome);
               A21ProdutoDescricao = cgiGet( edtProdutoDescricao_Internalname);
               AssignAttri("", false, "A21ProdutoDescricao", A21ProdutoDescricao);
               if ( ( ( context.localUtil.CToN( cgiGet( edtProdutoPreco_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdutoPreco_Internalname), ".", ",") > 9999999.99m ) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRODUTOPRECO");
                  AnyError = 1;
                  GX_FocusControl = edtProdutoPreco_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A22ProdutoPreco = 0;
                  AssignAttri("", false, "A22ProdutoPreco", StringUtil.LTrimStr( A22ProdutoPreco, 10, 2));
               }
               else
               {
                  A22ProdutoPreco = context.localUtil.CToN( cgiGet( edtProdutoPreco_Internalname), ".", ",");
                  AssignAttri("", false, "A22ProdutoPreco", StringUtil.LTrimStr( A22ProdutoPreco, 10, 2));
               }
               A23ProdutoImagem = cgiGet( imgProdutoImagem_Internalname);
               AssignAttri("", false, "A23ProdutoImagem", A23ProdutoImagem);
               if ( ( ( context.localUtil.CToN( cgiGet( edtVendedorProdutoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtVendedorProdutoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "VENDEDORPRODUTOID");
                  AnyError = 1;
                  GX_FocusControl = edtVendedorProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A24VendedorProdutoId = 0;
                  AssignAttri("", false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
               }
               else
               {
                  A24VendedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtVendedorProdutoId_Internalname), ".", ","));
                  AssignAttri("", false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
               }
               A25VendedorProdutoNome = cgiGet( edtVendedorProdutoNome_Internalname);
               AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
               A68VendedorProdutoImagem = cgiGet( imgVendedorProdutoImagem_Internalname);
               AssignAttri("", false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPaisProdutoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPaisProdutoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PAISPRODUTOID");
                  AnyError = 1;
                  GX_FocusControl = edtPaisProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A26PaisProdutoId = 0;
                  AssignAttri("", false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
               }
               else
               {
                  A26PaisProdutoId = (short)(context.localUtil.CToN( cgiGet( edtPaisProdutoId_Internalname), ".", ","));
                  AssignAttri("", false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
               }
               A27PaisProdutoNome = cgiGet( edtPaisProdutoNome_Internalname);
               AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtFornecedorProdutoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtFornecedorProdutoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "FORNECEDORPRODUTOID");
                  AnyError = 1;
                  GX_FocusControl = edtFornecedorProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A28FornecedorProdutoId = 0;
                  AssignAttri("", false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
               }
               else
               {
                  A28FornecedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtFornecedorProdutoId_Internalname), ".", ","));
                  AssignAttri("", false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
               }
               A29FornecedorProdutoNome = cgiGet( edtFornecedorProdutoNome_Internalname);
               AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtCategoriaProdutoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCategoriaProdutoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CATEGORIAPRODUTOID");
                  AnyError = 1;
                  GX_FocusControl = edtCategoriaProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A30CategoriaProdutoId = 0;
                  AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
               }
               else
               {
                  A30CategoriaProdutoId = (short)(context.localUtil.CToN( cgiGet( edtCategoriaProdutoId_Internalname), ".", ","));
                  AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
               }
               A31CategoriaProdutoNome = cgiGet( edtCategoriaProdutoNome_Internalname);
               AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgProdutoImagem_Internalname, ref  A23ProdutoImagem, ref  A40000ProdutoImagem_GXI);
               getMultimediaValue(imgVendedorProdutoImagem_Internalname, ref  A68VendedorProdutoImagem, ref  A40001VendedorProdutoImagem_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Produto");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A19ProdutoId != Z19ProdutoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("produto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A19ProdutoId = (short)(NumberUtil.Val( GetPar( "ProdutoId"), "."));
                  AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
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
                     sMode6 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode6;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound6 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_060( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRODUTOID");
                        AnyError = 1;
                        GX_FocusControl = edtProdutoId_Internalname;
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
                           E11062 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12062 ();
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
            E12062 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll066( ) ;
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
            DisableAttributes066( ) ;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption060( )
      {
      }

      protected void E11062( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV16Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV16Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_VendedorProdutoId = 0;
         AssignAttri("", false, "AV11Insert_VendedorProdutoId", StringUtil.LTrimStr( (decimal)(AV11Insert_VendedorProdutoId), 4, 0));
         AV12Insert_PaisProdutoId = 0;
         AssignAttri("", false, "AV12Insert_PaisProdutoId", StringUtil.LTrimStr( (decimal)(AV12Insert_PaisProdutoId), 4, 0));
         AV13Insert_FornecedorProdutoId = 0;
         AssignAttri("", false, "AV13Insert_FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(AV13Insert_FornecedorProdutoId), 4, 0));
         AV14Insert_CategoriaProdutoId = 0;
         AssignAttri("", false, "AV14Insert_CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(AV14Insert_CategoriaProdutoId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV16Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV17GXV1 = 1;
            AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
            while ( AV17GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV17GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "VendedorProdutoId") == 0 )
               {
                  AV11Insert_VendedorProdutoId = (short)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_VendedorProdutoId", StringUtil.LTrimStr( (decimal)(AV11Insert_VendedorProdutoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "PaisProdutoId") == 0 )
               {
                  AV12Insert_PaisProdutoId = (short)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV12Insert_PaisProdutoId", StringUtil.LTrimStr( (decimal)(AV12Insert_PaisProdutoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "FornecedorProdutoId") == 0 )
               {
                  AV13Insert_FornecedorProdutoId = (short)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV13Insert_FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(AV13Insert_FornecedorProdutoId), 4, 0));
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "CategoriaProdutoId") == 0 )
               {
                  AV14Insert_CategoriaProdutoId = (short)(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV14Insert_CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(AV14Insert_CategoriaProdutoId), 4, 0));
               }
               AV17GXV1 = (int)(AV17GXV1+1);
               AssignAttri("", false, "AV17GXV1", StringUtil.LTrimStr( (decimal)(AV17GXV1), 8, 0));
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

      protected void E12062( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwproduto.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z20ProdutoNome = T00063_A20ProdutoNome[0];
               Z21ProdutoDescricao = T00063_A21ProdutoDescricao[0];
               Z22ProdutoPreco = T00063_A22ProdutoPreco[0];
               Z24VendedorProdutoId = T00063_A24VendedorProdutoId[0];
               Z26PaisProdutoId = T00063_A26PaisProdutoId[0];
               Z28FornecedorProdutoId = T00063_A28FornecedorProdutoId[0];
               Z30CategoriaProdutoId = T00063_A30CategoriaProdutoId[0];
            }
            else
            {
               Z20ProdutoNome = A20ProdutoNome;
               Z21ProdutoDescricao = A21ProdutoDescricao;
               Z22ProdutoPreco = A22ProdutoPreco;
               Z24VendedorProdutoId = A24VendedorProdutoId;
               Z26PaisProdutoId = A26PaisProdutoId;
               Z28FornecedorProdutoId = A28FornecedorProdutoId;
               Z30CategoriaProdutoId = A30CategoriaProdutoId;
            }
         }
         if ( GX_JID == -20 )
         {
            Z19ProdutoId = A19ProdutoId;
            Z20ProdutoNome = A20ProdutoNome;
            Z21ProdutoDescricao = A21ProdutoDescricao;
            Z22ProdutoPreco = A22ProdutoPreco;
            Z23ProdutoImagem = A23ProdutoImagem;
            Z40000ProdutoImagem_GXI = A40000ProdutoImagem_GXI;
            Z24VendedorProdutoId = A24VendedorProdutoId;
            Z26PaisProdutoId = A26PaisProdutoId;
            Z28FornecedorProdutoId = A28FornecedorProdutoId;
            Z30CategoriaProdutoId = A30CategoriaProdutoId;
            Z25VendedorProdutoNome = A25VendedorProdutoNome;
            Z68VendedorProdutoImagem = A68VendedorProdutoImagem;
            Z40001VendedorProdutoImagem_GXI = A40001VendedorProdutoImagem_GXI;
            Z27PaisProdutoNome = A27PaisProdutoNome;
            Z29FornecedorProdutoNome = A29FornecedorProdutoNome;
            Z31CategoriaProdutoNome = A31CategoriaProdutoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_24_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0030.aspx"+"',["+"{Ctrl:gx.dom.el('"+"VENDEDORPRODUTOID"+"'), id:'"+"VENDEDORPRODUTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_26_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0010.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PAISPRODUTOID"+"'), id:'"+"PAISPRODUTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_28_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0050.aspx"+"',["+"{Ctrl:gx.dom.el('"+"FORNECEDORPRODUTOID"+"'), id:'"+"FORNECEDORPRODUTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         imgprompt_30_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0020.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CATEGORIAPRODUTOID"+"'), id:'"+"CATEGORIAPRODUTOID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7ProdutoId) )
         {
            A19ProdutoId = AV7ProdutoId;
            AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
         }
         if ( ! (0==AV7ProdutoId) )
         {
            edtProdutoId_Enabled = 0;
            AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), true);
         }
         else
         {
            edtProdutoId_Enabled = 1;
            AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7ProdutoId) )
         {
            edtProdutoId_Enabled = 0;
            AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_VendedorProdutoId) )
         {
            edtVendedorProdutoId_Enabled = 0;
            AssignProp("", false, edtVendedorProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorProdutoId_Enabled), 5, 0), true);
         }
         else
         {
            edtVendedorProdutoId_Enabled = 1;
            AssignProp("", false, edtVendedorProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorProdutoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_PaisProdutoId) )
         {
            edtPaisProdutoId_Enabled = 0;
            AssignProp("", false, edtPaisProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisProdutoId_Enabled), 5, 0), true);
         }
         else
         {
            edtPaisProdutoId_Enabled = 1;
            AssignProp("", false, edtPaisProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisProdutoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_FornecedorProdutoId) )
         {
            edtFornecedorProdutoId_Enabled = 0;
            AssignProp("", false, edtFornecedorProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorProdutoId_Enabled), 5, 0), true);
         }
         else
         {
            edtFornecedorProdutoId_Enabled = 1;
            AssignProp("", false, edtFornecedorProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorProdutoId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_CategoriaProdutoId) )
         {
            edtCategoriaProdutoId_Enabled = 0;
            AssignProp("", false, edtCategoriaProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaProdutoId_Enabled), 5, 0), true);
         }
         else
         {
            edtCategoriaProdutoId_Enabled = 1;
            AssignProp("", false, edtCategoriaProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaProdutoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_CategoriaProdutoId) )
         {
            A30CategoriaProdutoId = AV14Insert_CategoriaProdutoId;
            AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_FornecedorProdutoId) )
         {
            A28FornecedorProdutoId = AV13Insert_FornecedorProdutoId;
            AssignAttri("", false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV12Insert_PaisProdutoId) )
         {
            A26PaisProdutoId = AV12Insert_PaisProdutoId;
            AssignAttri("", false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_VendedorProdutoId) )
         {
            A24VendedorProdutoId = AV11Insert_VendedorProdutoId;
            AssignAttri("", false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
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
            AV16Pgmname = "Produto";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T00067 */
            pr_default.execute(5, new Object[] {A30CategoriaProdutoId});
            A31CategoriaProdutoNome = T00067_A31CategoriaProdutoNome[0];
            AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
            pr_default.close(5);
            /* Using cursor T00066 */
            pr_default.execute(4, new Object[] {A28FornecedorProdutoId});
            A29FornecedorProdutoNome = T00066_A29FornecedorProdutoNome[0];
            AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
            pr_default.close(4);
            /* Using cursor T00065 */
            pr_default.execute(3, new Object[] {A26PaisProdutoId});
            A27PaisProdutoNome = T00065_A27PaisProdutoNome[0];
            AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
            pr_default.close(3);
            /* Using cursor T00064 */
            pr_default.execute(2, new Object[] {A24VendedorProdutoId});
            A25VendedorProdutoNome = T00064_A25VendedorProdutoNome[0];
            AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
            A40001VendedorProdutoImagem_GXI = T00064_A40001VendedorProdutoImagem_GXI[0];
            n40001VendedorProdutoImagem_GXI = T00064_n40001VendedorProdutoImagem_GXI[0];
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
            A68VendedorProdutoImagem = T00064_A68VendedorProdutoImagem[0];
            AssignAttri("", false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
            pr_default.close(2);
         }
      }

      protected void Load066( )
      {
         /* Using cursor T00068 */
         pr_default.execute(6, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound6 = 1;
            A20ProdutoNome = T00068_A20ProdutoNome[0];
            AssignAttri("", false, "A20ProdutoNome", A20ProdutoNome);
            A21ProdutoDescricao = T00068_A21ProdutoDescricao[0];
            AssignAttri("", false, "A21ProdutoDescricao", A21ProdutoDescricao);
            A22ProdutoPreco = T00068_A22ProdutoPreco[0];
            AssignAttri("", false, "A22ProdutoPreco", StringUtil.LTrimStr( A22ProdutoPreco, 10, 2));
            A40000ProdutoImagem_GXI = T00068_A40000ProdutoImagem_GXI[0];
            AssignProp("", false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
            AssignProp("", false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            A25VendedorProdutoNome = T00068_A25VendedorProdutoNome[0];
            AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
            A40001VendedorProdutoImagem_GXI = T00068_A40001VendedorProdutoImagem_GXI[0];
            n40001VendedorProdutoImagem_GXI = T00068_n40001VendedorProdutoImagem_GXI[0];
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
            A27PaisProdutoNome = T00068_A27PaisProdutoNome[0];
            AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
            A29FornecedorProdutoNome = T00068_A29FornecedorProdutoNome[0];
            AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
            A31CategoriaProdutoNome = T00068_A31CategoriaProdutoNome[0];
            AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
            A24VendedorProdutoId = T00068_A24VendedorProdutoId[0];
            AssignAttri("", false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
            A26PaisProdutoId = T00068_A26PaisProdutoId[0];
            AssignAttri("", false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
            A28FornecedorProdutoId = T00068_A28FornecedorProdutoId[0];
            AssignAttri("", false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
            A30CategoriaProdutoId = T00068_A30CategoriaProdutoId[0];
            AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
            A23ProdutoImagem = T00068_A23ProdutoImagem[0];
            AssignAttri("", false, "A23ProdutoImagem", A23ProdutoImagem);
            AssignProp("", false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
            AssignProp("", false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            A68VendedorProdutoImagem = T00068_A68VendedorProdutoImagem[0];
            AssignAttri("", false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
            ZM066( -20) ;
         }
         pr_default.close(6);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
         AV16Pgmname = "Produto";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV16Pgmname = "Produto";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         /* Using cursor T00069 */
         pr_default.execute(7, new Object[] {A20ProdutoNome, A19ProdutoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Produto"}), 1, "PRODUTONOME");
            AnyError = 1;
            GX_FocusControl = edtProdutoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(7);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A20ProdutoNome)) )
         {
            GX_msglist.addItem("O nome do produto deve ser preenchido.", 1, "PRODUTONOME");
            AnyError = 1;
            GX_FocusControl = edtProdutoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A22ProdutoPreco) )
         {
            GX_msglist.addItem("O preço deve ser preenchido.", 1, "PRODUTOPRECO");
            AnyError = 1;
            GX_FocusControl = edtProdutoPreco_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {A24VendedorProdutoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Vendedor Produto'.", "ForeignKeyNotFound", 1, "VENDEDORPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtVendedorProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25VendedorProdutoNome = T00064_A25VendedorProdutoNome[0];
         AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
         A40001VendedorProdutoImagem_GXI = T00064_A40001VendedorProdutoImagem_GXI[0];
         n40001VendedorProdutoImagem_GXI = T00064_n40001VendedorProdutoImagem_GXI[0];
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
         A68VendedorProdutoImagem = T00064_A68VendedorProdutoImagem[0];
         AssignAttri("", false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
         pr_default.close(2);
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {A26PaisProdutoId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtPaisProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A27PaisProdutoNome = T00065_A27PaisProdutoNome[0];
         AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
         pr_default.close(3);
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {A28FornecedorProdutoId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("No matching 'Fornecedor'.", "ForeignKeyNotFound", 1, "FORNECEDORPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtFornecedorProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29FornecedorProdutoNome = T00066_A29FornecedorProdutoNome[0];
         AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
         pr_default.close(4);
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A31CategoriaProdutoNome = T00067_A31CategoriaProdutoNome[0];
         AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors066( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
         pr_default.close(5);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_22( short A24VendedorProdutoId )
      {
         /* Using cursor T000610 */
         pr_default.execute(8, new Object[] {A24VendedorProdutoId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("No matching 'Vendedor Produto'.", "ForeignKeyNotFound", 1, "VENDEDORPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtVendedorProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A25VendedorProdutoNome = T000610_A25VendedorProdutoNome[0];
         AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
         A40001VendedorProdutoImagem_GXI = T000610_A40001VendedorProdutoImagem_GXI[0];
         n40001VendedorProdutoImagem_GXI = T000610_n40001VendedorProdutoImagem_GXI[0];
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
         A68VendedorProdutoImagem = T000610_A68VendedorProdutoImagem[0];
         AssignAttri("", false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A25VendedorProdutoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( A68VendedorProdutoImagem)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40001VendedorProdutoImagem_GXI)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void gxLoad_23( short A26PaisProdutoId )
      {
         /* Using cursor T000611 */
         pr_default.execute(9, new Object[] {A26PaisProdutoId});
         if ( (pr_default.getStatus(9) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtPaisProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A27PaisProdutoNome = T000611_A27PaisProdutoNome[0];
         AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A27PaisProdutoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(9) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(9);
      }

      protected void gxLoad_24( short A28FornecedorProdutoId )
      {
         /* Using cursor T000612 */
         pr_default.execute(10, new Object[] {A28FornecedorProdutoId});
         if ( (pr_default.getStatus(10) == 101) )
         {
            GX_msglist.addItem("No matching 'Fornecedor'.", "ForeignKeyNotFound", 1, "FORNECEDORPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtFornecedorProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A29FornecedorProdutoNome = T000612_A29FornecedorProdutoNome[0];
         AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A29FornecedorProdutoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(10) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(10);
      }

      protected void gxLoad_25( short A30CategoriaProdutoId )
      {
         /* Using cursor T000613 */
         pr_default.execute(11, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(11) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A31CategoriaProdutoNome = T000613_A31CategoriaProdutoNome[0];
         AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A31CategoriaProdutoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(11) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(11);
      }

      protected void GetKey066( )
      {
         /* Using cursor T000614 */
         pr_default.execute(12, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(12);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 20) ;
            RcdFound6 = 1;
            A19ProdutoId = T00063_A19ProdutoId[0];
            AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
            A20ProdutoNome = T00063_A20ProdutoNome[0];
            AssignAttri("", false, "A20ProdutoNome", A20ProdutoNome);
            A21ProdutoDescricao = T00063_A21ProdutoDescricao[0];
            AssignAttri("", false, "A21ProdutoDescricao", A21ProdutoDescricao);
            A22ProdutoPreco = T00063_A22ProdutoPreco[0];
            AssignAttri("", false, "A22ProdutoPreco", StringUtil.LTrimStr( A22ProdutoPreco, 10, 2));
            A40000ProdutoImagem_GXI = T00063_A40000ProdutoImagem_GXI[0];
            AssignProp("", false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
            AssignProp("", false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            A24VendedorProdutoId = T00063_A24VendedorProdutoId[0];
            AssignAttri("", false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
            A26PaisProdutoId = T00063_A26PaisProdutoId[0];
            AssignAttri("", false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
            A28FornecedorProdutoId = T00063_A28FornecedorProdutoId[0];
            AssignAttri("", false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
            A30CategoriaProdutoId = T00063_A30CategoriaProdutoId[0];
            AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
            A23ProdutoImagem = T00063_A23ProdutoImagem[0];
            AssignAttri("", false, "A23ProdutoImagem", A23ProdutoImagem);
            AssignProp("", false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
            AssignProp("", false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
            Z19ProdutoId = A19ProdutoId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound6 = 0;
         /* Using cursor T000615 */
         pr_default.execute(13, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(13) != 101) )
         {
            while ( (pr_default.getStatus(13) != 101) && ( ( T000615_A19ProdutoId[0] < A19ProdutoId ) ) )
            {
               pr_default.readNext(13);
            }
            if ( (pr_default.getStatus(13) != 101) && ( ( T000615_A19ProdutoId[0] > A19ProdutoId ) ) )
            {
               A19ProdutoId = T000615_A19ProdutoId[0];
               AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(13);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T000616 */
         pr_default.execute(14, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            while ( (pr_default.getStatus(14) != 101) && ( ( T000616_A19ProdutoId[0] > A19ProdutoId ) ) )
            {
               pr_default.readNext(14);
            }
            if ( (pr_default.getStatus(14) != 101) && ( ( T000616_A19ProdutoId[0] < A19ProdutoId ) ) )
            {
               A19ProdutoId = T000616_A19ProdutoId[0];
               AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
               RcdFound6 = 1;
            }
         }
         pr_default.close(14);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( A19ProdutoId != Z19ProdutoId )
               {
                  A19ProdutoId = Z19ProdutoId;
                  AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRODUTOID");
                  AnyError = 1;
                  GX_FocusControl = edtProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update066( ) ;
                  GX_FocusControl = edtProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A19ProdutoId != Z19ProdutoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRODUTOID");
                     AnyError = 1;
                     GX_FocusControl = edtProdutoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtProdutoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
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
         if ( A19ProdutoId != Z19ProdutoId )
         {
            A19ProdutoId = Z19ProdutoId;
            AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {A19ProdutoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Produto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z20ProdutoNome, T00062_A20ProdutoNome[0]) != 0 ) || ( StringUtil.StrCmp(Z21ProdutoDescricao, T00062_A21ProdutoDescricao[0]) != 0 ) || ( Z22ProdutoPreco != T00062_A22ProdutoPreco[0] ) || ( Z24VendedorProdutoId != T00062_A24VendedorProdutoId[0] ) || ( Z26PaisProdutoId != T00062_A26PaisProdutoId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z28FornecedorProdutoId != T00062_A28FornecedorProdutoId[0] ) || ( Z30CategoriaProdutoId != T00062_A30CategoriaProdutoId[0] ) )
            {
               if ( StringUtil.StrCmp(Z20ProdutoNome, T00062_A20ProdutoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("produto:[seudo value changed for attri]"+"ProdutoNome");
                  GXUtil.WriteLogRaw("Old: ",Z20ProdutoNome);
                  GXUtil.WriteLogRaw("Current: ",T00062_A20ProdutoNome[0]);
               }
               if ( StringUtil.StrCmp(Z21ProdutoDescricao, T00062_A21ProdutoDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("produto:[seudo value changed for attri]"+"ProdutoDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z21ProdutoDescricao);
                  GXUtil.WriteLogRaw("Current: ",T00062_A21ProdutoDescricao[0]);
               }
               if ( Z22ProdutoPreco != T00062_A22ProdutoPreco[0] )
               {
                  GXUtil.WriteLog("produto:[seudo value changed for attri]"+"ProdutoPreco");
                  GXUtil.WriteLogRaw("Old: ",Z22ProdutoPreco);
                  GXUtil.WriteLogRaw("Current: ",T00062_A22ProdutoPreco[0]);
               }
               if ( Z24VendedorProdutoId != T00062_A24VendedorProdutoId[0] )
               {
                  GXUtil.WriteLog("produto:[seudo value changed for attri]"+"VendedorProdutoId");
                  GXUtil.WriteLogRaw("Old: ",Z24VendedorProdutoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A24VendedorProdutoId[0]);
               }
               if ( Z26PaisProdutoId != T00062_A26PaisProdutoId[0] )
               {
                  GXUtil.WriteLog("produto:[seudo value changed for attri]"+"PaisProdutoId");
                  GXUtil.WriteLogRaw("Old: ",Z26PaisProdutoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A26PaisProdutoId[0]);
               }
               if ( Z28FornecedorProdutoId != T00062_A28FornecedorProdutoId[0] )
               {
                  GXUtil.WriteLog("produto:[seudo value changed for attri]"+"FornecedorProdutoId");
                  GXUtil.WriteLogRaw("Old: ",Z28FornecedorProdutoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A28FornecedorProdutoId[0]);
               }
               if ( Z30CategoriaProdutoId != T00062_A30CategoriaProdutoId[0] )
               {
                  GXUtil.WriteLog("produto:[seudo value changed for attri]"+"CategoriaProdutoId");
                  GXUtil.WriteLogRaw("Old: ",Z30CategoriaProdutoId);
                  GXUtil.WriteLogRaw("Current: ",T00062_A30CategoriaProdutoId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Produto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000617 */
                     pr_default.execute(15, new Object[] {A19ProdutoId, A20ProdutoNome, A21ProdutoDescricao, A22ProdutoPreco, A23ProdutoImagem, A40000ProdutoImagem_GXI, A24VendedorProdutoId, A26PaisProdutoId, A28FornecedorProdutoId, A30CategoriaProdutoId});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("Produto");
                     if ( (pr_default.getStatus(15) == 1) )
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
                           ResetCaption060( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000618 */
                     pr_default.execute(16, new Object[] {A20ProdutoNome, A21ProdutoDescricao, A22ProdutoPreco, A24VendedorProdutoId, A26PaisProdutoId, A28FornecedorProdutoId, A30CategoriaProdutoId, A19ProdutoId});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("Produto");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Produto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000619 */
            pr_default.execute(17, new Object[] {A23ProdutoImagem, A40000ProdutoImagem_GXI, A19ProdutoId});
            pr_default.close(17);
            pr_default.SmartCacheProvider.SetUpdated("Produto");
         }
      }

      protected void delete( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000620 */
                  pr_default.execute(18, new Object[] {A19ProdutoId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("Produto");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV16Pgmname = "Produto";
            AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
            /* Using cursor T000621 */
            pr_default.execute(19, new Object[] {A24VendedorProdutoId});
            A25VendedorProdutoNome = T000621_A25VendedorProdutoNome[0];
            AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
            A40001VendedorProdutoImagem_GXI = T000621_A40001VendedorProdutoImagem_GXI[0];
            n40001VendedorProdutoImagem_GXI = T000621_n40001VendedorProdutoImagem_GXI[0];
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
            A68VendedorProdutoImagem = T000621_A68VendedorProdutoImagem[0];
            AssignAttri("", false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
            AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
            pr_default.close(19);
            /* Using cursor T000622 */
            pr_default.execute(20, new Object[] {A26PaisProdutoId});
            A27PaisProdutoNome = T000622_A27PaisProdutoNome[0];
            AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
            pr_default.close(20);
            /* Using cursor T000623 */
            pr_default.execute(21, new Object[] {A28FornecedorProdutoId});
            A29FornecedorProdutoNome = T000623_A29FornecedorProdutoNome[0];
            AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
            pr_default.close(21);
            /* Using cursor T000624 */
            pr_default.execute(22, new Object[] {A30CategoriaProdutoId});
            A31CategoriaProdutoNome = T000624_A31CategoriaProdutoNome[0];
            AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
            pr_default.close(22);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000625 */
            pr_default.execute(23, new Object[] {A19ProdutoId});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"CarrinhoComprasProdutos"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
            /* Using cursor T000626 */
            pr_default.execute(24, new Object[] {A19ProdutoId});
            if ( (pr_default.getStatus(24) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Produto"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(24);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            context.CommitDataStores("produto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(19);
            pr_default.close(20);
            pr_default.close(21);
            pr_default.close(22);
            context.RollbackDataStores("produto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Scan By routine */
         /* Using cursor T000627 */
         pr_default.execute(25);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound6 = 1;
            A19ProdutoId = T000627_A19ProdutoId[0];
            AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(25);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(25) != 101) )
         {
            RcdFound6 = 1;
            A19ProdutoId = T000627_A19ProdutoId[0];
            AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(25);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtProdutoId_Enabled = 0;
         AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), true);
         edtProdutoNome_Enabled = 0;
         AssignProp("", false, edtProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoNome_Enabled), 5, 0), true);
         edtProdutoDescricao_Enabled = 0;
         AssignProp("", false, edtProdutoDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoDescricao_Enabled), 5, 0), true);
         edtProdutoPreco_Enabled = 0;
         AssignProp("", false, edtProdutoPreco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoPreco_Enabled), 5, 0), true);
         imgProdutoImagem_Enabled = 0;
         AssignProp("", false, imgProdutoImagem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgProdutoImagem_Enabled), 5, 0), true);
         edtVendedorProdutoId_Enabled = 0;
         AssignProp("", false, edtVendedorProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorProdutoId_Enabled), 5, 0), true);
         edtVendedorProdutoNome_Enabled = 0;
         AssignProp("", false, edtVendedorProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVendedorProdutoNome_Enabled), 5, 0), true);
         imgVendedorProdutoImagem_Enabled = 0;
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgVendedorProdutoImagem_Enabled), 5, 0), true);
         edtPaisProdutoId_Enabled = 0;
         AssignProp("", false, edtPaisProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisProdutoId_Enabled), 5, 0), true);
         edtPaisProdutoNome_Enabled = 0;
         AssignProp("", false, edtPaisProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPaisProdutoNome_Enabled), 5, 0), true);
         edtFornecedorProdutoId_Enabled = 0;
         AssignProp("", false, edtFornecedorProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorProdutoId_Enabled), 5, 0), true);
         edtFornecedorProdutoNome_Enabled = 0;
         AssignProp("", false, edtFornecedorProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtFornecedorProdutoNome_Enabled), 5, 0), true);
         edtCategoriaProdutoId_Enabled = 0;
         AssignProp("", false, edtCategoriaProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaProdutoId_Enabled), 5, 0), true);
         edtCategoriaProdutoNome_Enabled = 0;
         AssignProp("", false, edtCategoriaProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCategoriaProdutoNome_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("produto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProdutoId,4,0))}, new string[] {"Gx_mode","ProdutoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Produto");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("produto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z19ProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z20ProdutoNome", Z20ProdutoNome);
         GxWebStd.gx_hidden_field( context, "Z21ProdutoDescricao", Z21ProdutoDescricao);
         GxWebStd.gx_hidden_field( context, "Z22ProdutoPreco", StringUtil.LTrim( StringUtil.NToC( Z22ProdutoPreco, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z24VendedorProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z24VendedorProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z26PaisProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z26PaisProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z28FornecedorProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z28FornecedorProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z30CategoriaProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z30CategoriaProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N24VendedorProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24VendedorProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N26PaisProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26PaisProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N28FornecedorProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FornecedorProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "N30CategoriaProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7ProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRODUTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7ProdutoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_VENDEDORPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_VendedorProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PAISPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12Insert_PaisProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_FORNECEDORPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_FornecedorProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_CATEGORIAPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_CategoriaProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTOIMAGEM_GXI", A40000ProdutoImagem_GXI);
         GxWebStd.gx_hidden_field( context, "VENDEDORPRODUTOIMAGEM_GXI", A40001VendedorProdutoImagem_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
         GXCCtlgxBlob = "PRODUTOIMAGEM" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A23ProdutoImagem);
         GXCCtlgxBlob = "VENDEDORPRODUTOIMAGEM" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A68VendedorProdutoImagem);
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
         return formatLink("produto.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7ProdutoId,4,0))}, new string[] {"Gx_mode","ProdutoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Produto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Produto" ;
      }

      protected void InitializeNonKey066( )
      {
         A24VendedorProdutoId = 0;
         AssignAttri("", false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
         A26PaisProdutoId = 0;
         AssignAttri("", false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
         A28FornecedorProdutoId = 0;
         AssignAttri("", false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
         A30CategoriaProdutoId = 0;
         AssignAttri("", false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
         A20ProdutoNome = "";
         AssignAttri("", false, "A20ProdutoNome", A20ProdutoNome);
         A21ProdutoDescricao = "";
         AssignAttri("", false, "A21ProdutoDescricao", A21ProdutoDescricao);
         A22ProdutoPreco = 0;
         AssignAttri("", false, "A22ProdutoPreco", StringUtil.LTrimStr( A22ProdutoPreco, 10, 2));
         A23ProdutoImagem = "";
         AssignAttri("", false, "A23ProdutoImagem", A23ProdutoImagem);
         AssignProp("", false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
         AssignProp("", false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         A40000ProdutoImagem_GXI = "";
         AssignProp("", false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
         AssignProp("", false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
         A25VendedorProdutoNome = "";
         AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
         A68VendedorProdutoImagem = "";
         AssignAttri("", false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
         A40001VendedorProdutoImagem_GXI = "";
         n40001VendedorProdutoImagem_GXI = false;
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
         AssignProp("", false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
         A27PaisProdutoNome = "";
         AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
         A29FornecedorProdutoNome = "";
         AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
         A31CategoriaProdutoNome = "";
         AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
         Z20ProdutoNome = "";
         Z21ProdutoDescricao = "";
         Z22ProdutoPreco = 0;
         Z24VendedorProdutoId = 0;
         Z26PaisProdutoId = 0;
         Z28FornecedorProdutoId = 0;
         Z30CategoriaProdutoId = 0;
      }

      protected void InitAll066( )
      {
         A19ProdutoId = 0;
         AssignAttri("", false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
         InitializeNonKey066( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916514259", true, true);
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
         context.AddJavascriptSource("produto.js", "?202582916514259", false, true);
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
         edtProdutoId_Internalname = "PRODUTOID";
         edtProdutoNome_Internalname = "PRODUTONOME";
         edtProdutoDescricao_Internalname = "PRODUTODESCRICAO";
         edtProdutoPreco_Internalname = "PRODUTOPRECO";
         imgProdutoImagem_Internalname = "PRODUTOIMAGEM";
         edtVendedorProdutoId_Internalname = "VENDEDORPRODUTOID";
         edtVendedorProdutoNome_Internalname = "VENDEDORPRODUTONOME";
         imgVendedorProdutoImagem_Internalname = "VENDEDORPRODUTOIMAGEM";
         edtPaisProdutoId_Internalname = "PAISPRODUTOID";
         edtPaisProdutoNome_Internalname = "PAISPRODUTONOME";
         edtFornecedorProdutoId_Internalname = "FORNECEDORPRODUTOID";
         edtFornecedorProdutoNome_Internalname = "FORNECEDORPRODUTONOME";
         edtCategoriaProdutoId_Internalname = "CATEGORIAPRODUTOID";
         edtCategoriaProdutoNome_Internalname = "CATEGORIAPRODUTONOME";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_24_Internalname = "PROMPT_24";
         imgprompt_26_Internalname = "PROMPT_26";
         imgprompt_28_Internalname = "PROMPT_28";
         imgprompt_30_Internalname = "PROMPT_30";
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
         Form.Caption = "Produto";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCategoriaProdutoNome_Jsonclick = "";
         edtCategoriaProdutoNome_Enabled = 0;
         imgprompt_30_Visible = 1;
         imgprompt_30_Link = "";
         edtCategoriaProdutoId_Jsonclick = "";
         edtCategoriaProdutoId_Enabled = 1;
         edtFornecedorProdutoNome_Jsonclick = "";
         edtFornecedorProdutoNome_Enabled = 0;
         imgprompt_28_Visible = 1;
         imgprompt_28_Link = "";
         edtFornecedorProdutoId_Jsonclick = "";
         edtFornecedorProdutoId_Enabled = 1;
         edtPaisProdutoNome_Jsonclick = "";
         edtPaisProdutoNome_Enabled = 0;
         imgprompt_26_Visible = 1;
         imgprompt_26_Link = "";
         edtPaisProdutoId_Jsonclick = "";
         edtPaisProdutoId_Enabled = 1;
         imgVendedorProdutoImagem_Enabled = 0;
         edtVendedorProdutoNome_Jsonclick = "";
         edtVendedorProdutoNome_Enabled = 0;
         imgprompt_24_Visible = 1;
         imgprompt_24_Link = "";
         edtVendedorProdutoId_Jsonclick = "";
         edtVendedorProdutoId_Enabled = 1;
         imgProdutoImagem_Enabled = 1;
         edtProdutoPreco_Jsonclick = "";
         edtProdutoPreco_Enabled = 1;
         edtProdutoDescricao_Jsonclick = "";
         edtProdutoDescricao_Enabled = 1;
         edtProdutoNome_Jsonclick = "";
         edtProdutoNome_Enabled = 1;
         edtProdutoId_Jsonclick = "";
         edtProdutoId_Enabled = 1;
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

      public void Valid_Produtonome( )
      {
         /* Using cursor T000628 */
         pr_default.execute(26, new Object[] {A20ProdutoNome, A19ProdutoId});
         if ( (pr_default.getStatus(26) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Produto"}), 1, "PRODUTONOME");
            AnyError = 1;
            GX_FocusControl = edtProdutoNome_Internalname;
         }
         pr_default.close(26);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A20ProdutoNome)) )
         {
            GX_msglist.addItem("O nome do produto deve ser preenchido.", 1, "PRODUTONOME");
            AnyError = 1;
            GX_FocusControl = edtProdutoNome_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Vendedorprodutoid( )
      {
         n40001VendedorProdutoImagem_GXI = false;
         /* Using cursor T000621 */
         pr_default.execute(19, new Object[] {A24VendedorProdutoId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Vendedor Produto'.", "ForeignKeyNotFound", 1, "VENDEDORPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtVendedorProdutoId_Internalname;
         }
         A25VendedorProdutoNome = T000621_A25VendedorProdutoNome[0];
         A40001VendedorProdutoImagem_GXI = T000621_A40001VendedorProdutoImagem_GXI[0];
         n40001VendedorProdutoImagem_GXI = T000621_n40001VendedorProdutoImagem_GXI[0];
         A68VendedorProdutoImagem = T000621_A68VendedorProdutoImagem[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
         AssignAttri("", false, "A68VendedorProdutoImagem", context.PathToRelativeUrl( A68VendedorProdutoImagem));
         GXCCtlgxBlob = "VENDEDORPRODUTOIMAGEM" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A68VendedorProdutoImagem));
         AssignAttri("", false, "A40001VendedorProdutoImagem_GXI", A40001VendedorProdutoImagem_GXI);
      }

      public void Valid_Paisprodutoid( )
      {
         /* Using cursor T000622 */
         pr_default.execute(20, new Object[] {A26PaisProdutoId});
         if ( (pr_default.getStatus(20) == 101) )
         {
            GX_msglist.addItem("No matching 'País'.", "ForeignKeyNotFound", 1, "PAISPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtPaisProdutoId_Internalname;
         }
         A27PaisProdutoNome = T000622_A27PaisProdutoNome[0];
         pr_default.close(20);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A27PaisProdutoNome", A27PaisProdutoNome);
      }

      public void Valid_Fornecedorprodutoid( )
      {
         /* Using cursor T000623 */
         pr_default.execute(21, new Object[] {A28FornecedorProdutoId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            GX_msglist.addItem("No matching 'Fornecedor'.", "ForeignKeyNotFound", 1, "FORNECEDORPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtFornecedorProdutoId_Internalname;
         }
         A29FornecedorProdutoNome = T000623_A29FornecedorProdutoNome[0];
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
      }

      public void Valid_Categoriaprodutoid( )
      {
         /* Using cursor T000624 */
         pr_default.execute(22, new Object[] {A30CategoriaProdutoId});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("No matching 'Categoria '.", "ForeignKeyNotFound", 1, "CATEGORIAPRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtCategoriaProdutoId_Internalname;
         }
         A31CategoriaProdutoNome = T000624_A31CategoriaProdutoNome[0];
         pr_default.close(22);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ProdutoId',fld:'vPRODUTOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ProdutoId',fld:'vPRODUTOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12062',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PRODUTOID","{handler:'Valid_Produtoid',iparms:[]");
         setEventMetadata("VALID_PRODUTOID",",oparms:[]}");
         setEventMetadata("VALID_PRODUTONOME","{handler:'Valid_Produtonome',iparms:[{av:'A20ProdutoNome',fld:'PRODUTONOME',pic:''},{av:'A19ProdutoId',fld:'PRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("VALID_PRODUTONOME",",oparms:[]}");
         setEventMetadata("VALID_PRODUTOPRECO","{handler:'Valid_Produtopreco',iparms:[]");
         setEventMetadata("VALID_PRODUTOPRECO",",oparms:[]}");
         setEventMetadata("VALID_VENDEDORPRODUTOID","{handler:'Valid_Vendedorprodutoid',iparms:[{av:'A24VendedorProdutoId',fld:'VENDEDORPRODUTOID',pic:'ZZZ9'},{av:'A25VendedorProdutoNome',fld:'VENDEDORPRODUTONOME',pic:''},{av:'A68VendedorProdutoImagem',fld:'VENDEDORPRODUTOIMAGEM',pic:''},{av:'A40001VendedorProdutoImagem_GXI',fld:'VENDEDORPRODUTOIMAGEM_GXI',pic:''}]");
         setEventMetadata("VALID_VENDEDORPRODUTOID",",oparms:[{av:'A25VendedorProdutoNome',fld:'VENDEDORPRODUTONOME',pic:''},{av:'A68VendedorProdutoImagem',fld:'VENDEDORPRODUTOIMAGEM',pic:''},{av:'A40001VendedorProdutoImagem_GXI',fld:'VENDEDORPRODUTOIMAGEM_GXI',pic:''}]}");
         setEventMetadata("VALID_PAISPRODUTOID","{handler:'Valid_Paisprodutoid',iparms:[{av:'A26PaisProdutoId',fld:'PAISPRODUTOID',pic:'ZZZ9'},{av:'A27PaisProdutoNome',fld:'PAISPRODUTONOME',pic:''}]");
         setEventMetadata("VALID_PAISPRODUTOID",",oparms:[{av:'A27PaisProdutoNome',fld:'PAISPRODUTONOME',pic:''}]}");
         setEventMetadata("VALID_FORNECEDORPRODUTOID","{handler:'Valid_Fornecedorprodutoid',iparms:[{av:'A28FornecedorProdutoId',fld:'FORNECEDORPRODUTOID',pic:'ZZZ9'},{av:'A29FornecedorProdutoNome',fld:'FORNECEDORPRODUTONOME',pic:''}]");
         setEventMetadata("VALID_FORNECEDORPRODUTOID",",oparms:[{av:'A29FornecedorProdutoNome',fld:'FORNECEDORPRODUTONOME',pic:''}]}");
         setEventMetadata("VALID_CATEGORIAPRODUTOID","{handler:'Valid_Categoriaprodutoid',iparms:[{av:'A30CategoriaProdutoId',fld:'CATEGORIAPRODUTOID',pic:'ZZZ9'},{av:'A31CategoriaProdutoNome',fld:'CATEGORIAPRODUTONOME',pic:''}]");
         setEventMetadata("VALID_CATEGORIAPRODUTOID",",oparms:[{av:'A31CategoriaProdutoNome',fld:'CATEGORIAPRODUTONOME',pic:''}]}");
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
         pr_default.close(19);
         pr_default.close(20);
         pr_default.close(21);
         pr_default.close(22);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z20ProdutoNome = "";
         Z21ProdutoDescricao = "";
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
         A20ProdutoNome = "";
         A21ProdutoDescricao = "";
         A23ProdutoImagem = "";
         A40000ProdutoImagem_GXI = "";
         sImgUrl = "";
         imgprompt_24_gximage = "";
         A25VendedorProdutoNome = "";
         A68VendedorProdutoImagem = "";
         A40001VendedorProdutoImagem_GXI = "";
         imgprompt_26_gximage = "";
         A27PaisProdutoNome = "";
         imgprompt_28_gximage = "";
         A29FornecedorProdutoNome = "";
         imgprompt_30_gximage = "";
         A31CategoriaProdutoNome = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV16Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode6 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z23ProdutoImagem = "";
         Z40000ProdutoImagem_GXI = "";
         Z25VendedorProdutoNome = "";
         Z68VendedorProdutoImagem = "";
         Z40001VendedorProdutoImagem_GXI = "";
         Z27PaisProdutoNome = "";
         Z29FornecedorProdutoNome = "";
         Z31CategoriaProdutoNome = "";
         T00067_A31CategoriaProdutoNome = new string[] {""} ;
         T00066_A29FornecedorProdutoNome = new string[] {""} ;
         T00065_A27PaisProdutoNome = new string[] {""} ;
         T00064_A25VendedorProdutoNome = new string[] {""} ;
         T00064_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         T00064_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         T00064_A68VendedorProdutoImagem = new string[] {""} ;
         T00068_A19ProdutoId = new short[1] ;
         T00068_A20ProdutoNome = new string[] {""} ;
         T00068_A21ProdutoDescricao = new string[] {""} ;
         T00068_A22ProdutoPreco = new decimal[1] ;
         T00068_A40000ProdutoImagem_GXI = new string[] {""} ;
         T00068_A25VendedorProdutoNome = new string[] {""} ;
         T00068_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         T00068_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         T00068_A27PaisProdutoNome = new string[] {""} ;
         T00068_A29FornecedorProdutoNome = new string[] {""} ;
         T00068_A31CategoriaProdutoNome = new string[] {""} ;
         T00068_A24VendedorProdutoId = new short[1] ;
         T00068_A26PaisProdutoId = new short[1] ;
         T00068_A28FornecedorProdutoId = new short[1] ;
         T00068_A30CategoriaProdutoId = new short[1] ;
         T00068_A23ProdutoImagem = new string[] {""} ;
         T00068_A68VendedorProdutoImagem = new string[] {""} ;
         T00069_A20ProdutoNome = new string[] {""} ;
         T000610_A25VendedorProdutoNome = new string[] {""} ;
         T000610_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         T000610_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         T000610_A68VendedorProdutoImagem = new string[] {""} ;
         T000611_A27PaisProdutoNome = new string[] {""} ;
         T000612_A29FornecedorProdutoNome = new string[] {""} ;
         T000613_A31CategoriaProdutoNome = new string[] {""} ;
         T000614_A19ProdutoId = new short[1] ;
         T00063_A19ProdutoId = new short[1] ;
         T00063_A20ProdutoNome = new string[] {""} ;
         T00063_A21ProdutoDescricao = new string[] {""} ;
         T00063_A22ProdutoPreco = new decimal[1] ;
         T00063_A40000ProdutoImagem_GXI = new string[] {""} ;
         T00063_A24VendedorProdutoId = new short[1] ;
         T00063_A26PaisProdutoId = new short[1] ;
         T00063_A28FornecedorProdutoId = new short[1] ;
         T00063_A30CategoriaProdutoId = new short[1] ;
         T00063_A23ProdutoImagem = new string[] {""} ;
         T000615_A19ProdutoId = new short[1] ;
         T000616_A19ProdutoId = new short[1] ;
         T00062_A19ProdutoId = new short[1] ;
         T00062_A20ProdutoNome = new string[] {""} ;
         T00062_A21ProdutoDescricao = new string[] {""} ;
         T00062_A22ProdutoPreco = new decimal[1] ;
         T00062_A40000ProdutoImagem_GXI = new string[] {""} ;
         T00062_A24VendedorProdutoId = new short[1] ;
         T00062_A26PaisProdutoId = new short[1] ;
         T00062_A28FornecedorProdutoId = new short[1] ;
         T00062_A30CategoriaProdutoId = new short[1] ;
         T00062_A23ProdutoImagem = new string[] {""} ;
         T000621_A25VendedorProdutoNome = new string[] {""} ;
         T000621_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         T000621_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         T000621_A68VendedorProdutoImagem = new string[] {""} ;
         T000622_A27PaisProdutoNome = new string[] {""} ;
         T000623_A29FornecedorProdutoNome = new string[] {""} ;
         T000624_A31CategoriaProdutoNome = new string[] {""} ;
         T000625_A52CarrinhoComprasId = new short[1] ;
         T000625_A19ProdutoId = new short[1] ;
         T000626_A32PromocaoId = new short[1] ;
         T000626_A19ProdutoId = new short[1] ;
         T000627_A19ProdutoId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         T000628_A20ProdutoNome = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produto__default(),
            new Object[][] {
                new Object[] {
               T00062_A19ProdutoId, T00062_A20ProdutoNome, T00062_A21ProdutoDescricao, T00062_A22ProdutoPreco, T00062_A40000ProdutoImagem_GXI, T00062_A24VendedorProdutoId, T00062_A26PaisProdutoId, T00062_A28FornecedorProdutoId, T00062_A30CategoriaProdutoId, T00062_A23ProdutoImagem
               }
               , new Object[] {
               T00063_A19ProdutoId, T00063_A20ProdutoNome, T00063_A21ProdutoDescricao, T00063_A22ProdutoPreco, T00063_A40000ProdutoImagem_GXI, T00063_A24VendedorProdutoId, T00063_A26PaisProdutoId, T00063_A28FornecedorProdutoId, T00063_A30CategoriaProdutoId, T00063_A23ProdutoImagem
               }
               , new Object[] {
               T00064_A25VendedorProdutoNome, T00064_A40001VendedorProdutoImagem_GXI, T00064_n40001VendedorProdutoImagem_GXI, T00064_A68VendedorProdutoImagem
               }
               , new Object[] {
               T00065_A27PaisProdutoNome
               }
               , new Object[] {
               T00066_A29FornecedorProdutoNome
               }
               , new Object[] {
               T00067_A31CategoriaProdutoNome
               }
               , new Object[] {
               T00068_A19ProdutoId, T00068_A20ProdutoNome, T00068_A21ProdutoDescricao, T00068_A22ProdutoPreco, T00068_A40000ProdutoImagem_GXI, T00068_A25VendedorProdutoNome, T00068_A40001VendedorProdutoImagem_GXI, T00068_n40001VendedorProdutoImagem_GXI, T00068_A27PaisProdutoNome, T00068_A29FornecedorProdutoNome,
               T00068_A31CategoriaProdutoNome, T00068_A24VendedorProdutoId, T00068_A26PaisProdutoId, T00068_A28FornecedorProdutoId, T00068_A30CategoriaProdutoId, T00068_A23ProdutoImagem, T00068_A68VendedorProdutoImagem
               }
               , new Object[] {
               T00069_A20ProdutoNome
               }
               , new Object[] {
               T000610_A25VendedorProdutoNome, T000610_A40001VendedorProdutoImagem_GXI, T000610_n40001VendedorProdutoImagem_GXI, T000610_A68VendedorProdutoImagem
               }
               , new Object[] {
               T000611_A27PaisProdutoNome
               }
               , new Object[] {
               T000612_A29FornecedorProdutoNome
               }
               , new Object[] {
               T000613_A31CategoriaProdutoNome
               }
               , new Object[] {
               T000614_A19ProdutoId
               }
               , new Object[] {
               T000615_A19ProdutoId
               }
               , new Object[] {
               T000616_A19ProdutoId
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
               T000621_A25VendedorProdutoNome, T000621_A40001VendedorProdutoImagem_GXI, T000621_n40001VendedorProdutoImagem_GXI, T000621_A68VendedorProdutoImagem
               }
               , new Object[] {
               T000622_A27PaisProdutoNome
               }
               , new Object[] {
               T000623_A29FornecedorProdutoNome
               }
               , new Object[] {
               T000624_A31CategoriaProdutoNome
               }
               , new Object[] {
               T000625_A52CarrinhoComprasId, T000625_A19ProdutoId
               }
               , new Object[] {
               T000626_A32PromocaoId, T000626_A19ProdutoId
               }
               , new Object[] {
               T000627_A19ProdutoId
               }
               , new Object[] {
               T000628_A20ProdutoNome
               }
            }
         );
         AV16Pgmname = "Produto";
      }

      private short wcpOAV7ProdutoId ;
      private short Z19ProdutoId ;
      private short Z24VendedorProdutoId ;
      private short Z26PaisProdutoId ;
      private short Z28FornecedorProdutoId ;
      private short Z30CategoriaProdutoId ;
      private short N24VendedorProdutoId ;
      private short N26PaisProdutoId ;
      private short N28FornecedorProdutoId ;
      private short N30CategoriaProdutoId ;
      private short GxWebError ;
      private short A24VendedorProdutoId ;
      private short A26PaisProdutoId ;
      private short A28FornecedorProdutoId ;
      private short A30CategoriaProdutoId ;
      private short AV7ProdutoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A19ProdutoId ;
      private short AV11Insert_VendedorProdutoId ;
      private short AV12Insert_PaisProdutoId ;
      private short AV13Insert_FornecedorProdutoId ;
      private short AV14Insert_CategoriaProdutoId ;
      private short RcdFound6 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_6 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtProdutoId_Enabled ;
      private int edtProdutoNome_Enabled ;
      private int edtProdutoDescricao_Enabled ;
      private int edtProdutoPreco_Enabled ;
      private int imgProdutoImagem_Enabled ;
      private int edtVendedorProdutoId_Enabled ;
      private int imgprompt_24_Visible ;
      private int edtVendedorProdutoNome_Enabled ;
      private int imgVendedorProdutoImagem_Enabled ;
      private int edtPaisProdutoId_Enabled ;
      private int imgprompt_26_Visible ;
      private int edtPaisProdutoNome_Enabled ;
      private int edtFornecedorProdutoId_Enabled ;
      private int imgprompt_28_Visible ;
      private int edtFornecedorProdutoNome_Enabled ;
      private int edtCategoriaProdutoId_Enabled ;
      private int imgprompt_30_Visible ;
      private int edtCategoriaProdutoNome_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV17GXV1 ;
      private int idxLst ;
      private decimal Z22ProdutoPreco ;
      private decimal A22ProdutoPreco ;
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
      private string edtProdutoId_Internalname ;
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
      private string edtProdutoId_Jsonclick ;
      private string edtProdutoNome_Internalname ;
      private string edtProdutoNome_Jsonclick ;
      private string edtProdutoDescricao_Internalname ;
      private string edtProdutoDescricao_Jsonclick ;
      private string edtProdutoPreco_Internalname ;
      private string edtProdutoPreco_Jsonclick ;
      private string imgProdutoImagem_Internalname ;
      private string sImgUrl ;
      private string edtVendedorProdutoId_Internalname ;
      private string edtVendedorProdutoId_Jsonclick ;
      private string imgprompt_24_gximage ;
      private string imgprompt_24_Internalname ;
      private string imgprompt_24_Link ;
      private string edtVendedorProdutoNome_Internalname ;
      private string edtVendedorProdutoNome_Jsonclick ;
      private string imgVendedorProdutoImagem_Internalname ;
      private string edtPaisProdutoId_Internalname ;
      private string edtPaisProdutoId_Jsonclick ;
      private string imgprompt_26_gximage ;
      private string imgprompt_26_Internalname ;
      private string imgprompt_26_Link ;
      private string edtPaisProdutoNome_Internalname ;
      private string edtPaisProdutoNome_Jsonclick ;
      private string edtFornecedorProdutoId_Internalname ;
      private string edtFornecedorProdutoId_Jsonclick ;
      private string imgprompt_28_gximage ;
      private string imgprompt_28_Internalname ;
      private string imgprompt_28_Link ;
      private string edtFornecedorProdutoNome_Internalname ;
      private string edtFornecedorProdutoNome_Jsonclick ;
      private string edtCategoriaProdutoId_Internalname ;
      private string edtCategoriaProdutoId_Jsonclick ;
      private string imgprompt_30_gximage ;
      private string imgprompt_30_Internalname ;
      private string imgprompt_30_Link ;
      private string edtCategoriaProdutoNome_Internalname ;
      private string edtCategoriaProdutoNome_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV16Pgmname ;
      private string hsh ;
      private string sMode6 ;
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
      private bool A23ProdutoImagem_IsBlob ;
      private bool A68VendedorProdutoImagem_IsBlob ;
      private bool returnInSub ;
      private bool n40001VendedorProdutoImagem_GXI ;
      private bool Gx_longc ;
      private string Z20ProdutoNome ;
      private string Z21ProdutoDescricao ;
      private string A20ProdutoNome ;
      private string A21ProdutoDescricao ;
      private string A40000ProdutoImagem_GXI ;
      private string A25VendedorProdutoNome ;
      private string A40001VendedorProdutoImagem_GXI ;
      private string A27PaisProdutoNome ;
      private string A29FornecedorProdutoNome ;
      private string A31CategoriaProdutoNome ;
      private string Z40000ProdutoImagem_GXI ;
      private string Z25VendedorProdutoNome ;
      private string Z40001VendedorProdutoImagem_GXI ;
      private string Z27PaisProdutoNome ;
      private string Z29FornecedorProdutoNome ;
      private string Z31CategoriaProdutoNome ;
      private string A23ProdutoImagem ;
      private string A68VendedorProdutoImagem ;
      private string Z23ProdutoImagem ;
      private string Z68VendedorProdutoImagem ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T00067_A31CategoriaProdutoNome ;
      private string[] T00066_A29FornecedorProdutoNome ;
      private string[] T00065_A27PaisProdutoNome ;
      private string[] T00064_A25VendedorProdutoNome ;
      private string[] T00064_A40001VendedorProdutoImagem_GXI ;
      private bool[] T00064_n40001VendedorProdutoImagem_GXI ;
      private string[] T00064_A68VendedorProdutoImagem ;
      private short[] T00068_A19ProdutoId ;
      private string[] T00068_A20ProdutoNome ;
      private string[] T00068_A21ProdutoDescricao ;
      private decimal[] T00068_A22ProdutoPreco ;
      private string[] T00068_A40000ProdutoImagem_GXI ;
      private string[] T00068_A25VendedorProdutoNome ;
      private string[] T00068_A40001VendedorProdutoImagem_GXI ;
      private bool[] T00068_n40001VendedorProdutoImagem_GXI ;
      private string[] T00068_A27PaisProdutoNome ;
      private string[] T00068_A29FornecedorProdutoNome ;
      private string[] T00068_A31CategoriaProdutoNome ;
      private short[] T00068_A24VendedorProdutoId ;
      private short[] T00068_A26PaisProdutoId ;
      private short[] T00068_A28FornecedorProdutoId ;
      private short[] T00068_A30CategoriaProdutoId ;
      private string[] T00068_A23ProdutoImagem ;
      private string[] T00068_A68VendedorProdutoImagem ;
      private string[] T00069_A20ProdutoNome ;
      private string[] T000610_A25VendedorProdutoNome ;
      private string[] T000610_A40001VendedorProdutoImagem_GXI ;
      private bool[] T000610_n40001VendedorProdutoImagem_GXI ;
      private string[] T000610_A68VendedorProdutoImagem ;
      private string[] T000611_A27PaisProdutoNome ;
      private string[] T000612_A29FornecedorProdutoNome ;
      private string[] T000613_A31CategoriaProdutoNome ;
      private short[] T000614_A19ProdutoId ;
      private short[] T00063_A19ProdutoId ;
      private string[] T00063_A20ProdutoNome ;
      private string[] T00063_A21ProdutoDescricao ;
      private decimal[] T00063_A22ProdutoPreco ;
      private string[] T00063_A40000ProdutoImagem_GXI ;
      private short[] T00063_A24VendedorProdutoId ;
      private short[] T00063_A26PaisProdutoId ;
      private short[] T00063_A28FornecedorProdutoId ;
      private short[] T00063_A30CategoriaProdutoId ;
      private string[] T00063_A23ProdutoImagem ;
      private short[] T000615_A19ProdutoId ;
      private short[] T000616_A19ProdutoId ;
      private short[] T00062_A19ProdutoId ;
      private string[] T00062_A20ProdutoNome ;
      private string[] T00062_A21ProdutoDescricao ;
      private decimal[] T00062_A22ProdutoPreco ;
      private string[] T00062_A40000ProdutoImagem_GXI ;
      private short[] T00062_A24VendedorProdutoId ;
      private short[] T00062_A26PaisProdutoId ;
      private short[] T00062_A28FornecedorProdutoId ;
      private short[] T00062_A30CategoriaProdutoId ;
      private string[] T00062_A23ProdutoImagem ;
      private string[] T000621_A25VendedorProdutoNome ;
      private string[] T000621_A40001VendedorProdutoImagem_GXI ;
      private bool[] T000621_n40001VendedorProdutoImagem_GXI ;
      private string[] T000621_A68VendedorProdutoImagem ;
      private string[] T000622_A27PaisProdutoNome ;
      private string[] T000623_A29FornecedorProdutoNome ;
      private string[] T000624_A31CategoriaProdutoNome ;
      private short[] T000625_A52CarrinhoComprasId ;
      private short[] T000625_A19ProdutoId ;
      private short[] T000626_A32PromocaoId ;
      private short[] T000626_A19ProdutoId ;
      private short[] T000627_A19ProdutoId ;
      private string[] T000628_A20ProdutoNome ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV15TrnContextAtt ;
   }

   public class produto__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[15])
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
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00068;
          prmT00068 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00069;
          prmT00069 = new Object[] {
          new ParDef("@ProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00064;
          prmT00064 = new Object[] {
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00065;
          prmT00065 = new Object[] {
          new ParDef("@PaisProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00066;
          prmT00066 = new Object[] {
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00067;
          prmT00067 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000610;
          prmT000610 = new Object[] {
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000611;
          prmT000611 = new Object[] {
          new ParDef("@PaisProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000612;
          prmT000612 = new Object[] {
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000613;
          prmT000613 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000614;
          prmT000614 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00063;
          prmT00063 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000615;
          prmT000615 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000616;
          prmT000616 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00062;
          prmT00062 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000617;
          prmT000617 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@ProdutoDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@ProdutoPreco",GXType.Decimal,10,2) ,
          new ParDef("@ProdutoImagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProdutoImagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=4, Tbl="Produto", Fld="ProdutoImagem"} ,
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@PaisProdutoId",GXType.Int16,4,0) ,
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000618;
          prmT000618 = new Object[] {
          new ParDef("@ProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@ProdutoDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@ProdutoPreco",GXType.Decimal,10,2) ,
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@PaisProdutoId",GXType.Int16,4,0) ,
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000619;
          prmT000619 = new Object[] {
          new ParDef("@ProdutoImagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@ProdutoImagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Produto", Fld="ProdutoImagem"} ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000620;
          prmT000620 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000625;
          prmT000625 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000626;
          prmT000626 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000627;
          prmT000627 = new Object[] {
          };
          Object[] prmT000628;
          prmT000628 = new Object[] {
          new ParDef("@ProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000621;
          prmT000621 = new Object[] {
          new ParDef("@VendedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000622;
          prmT000622 = new Object[] {
          new ParDef("@PaisProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000623;
          prmT000623 = new Object[] {
          new ParDef("@FornecedorProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000624;
          prmT000624 = new Object[] {
          new ParDef("@CategoriaProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00062", "SELECT [ProdutoId], [ProdutoNome], [ProdutoDescricao], [ProdutoPreco], [ProdutoImagem_GXI], [VendedorProdutoId] AS VendedorProdutoId, [PaisProdutoId] AS PaisProdutoId, [FornecedorProdutoId] AS FornecedorProdutoId, [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoImagem] FROM [Produto] WITH (UPDLOCK) WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00063", "SELECT [ProdutoId], [ProdutoNome], [ProdutoDescricao], [ProdutoPreco], [ProdutoImagem_GXI], [VendedorProdutoId] AS VendedorProdutoId, [PaisProdutoId] AS PaisProdutoId, [FornecedorProdutoId] AS FornecedorProdutoId, [CategoriaProdutoId] AS CategoriaProdutoId, [ProdutoImagem] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00064", "SELECT [VendedorNome] AS VendedorProdutoNome, [VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, [VendedorFoto] AS VendedorProdutoImagem FROM [Vendedor] WHERE [VendedorId] = @VendedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00065", "SELECT [PaisNome] AS PaisProdutoNome FROM [Pais] WHERE [PaisId] = @PaisProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00066", "SELECT [FornecedorNome] AS FornecedorProdutoNome FROM [Fornecedor] WHERE [FornecedorId] = @FornecedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00067", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00068", "SELECT TM1.[ProdutoId], TM1.[ProdutoNome], TM1.[ProdutoDescricao], TM1.[ProdutoPreco], TM1.[ProdutoImagem_GXI], T2.[VendedorNome] AS VendedorProdutoNome, T2.[VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, T3.[PaisNome] AS PaisProdutoNome, T4.[FornecedorNome] AS FornecedorProdutoNome, T5.[CategoriaNome] AS CategoriaProdutoNome, TM1.[VendedorProdutoId] AS VendedorProdutoId, TM1.[PaisProdutoId] AS PaisProdutoId, TM1.[FornecedorProdutoId] AS FornecedorProdutoId, TM1.[CategoriaProdutoId] AS CategoriaProdutoId, TM1.[ProdutoImagem], T2.[VendedorFoto] AS VendedorProdutoImagem FROM (((([Produto] TM1 INNER JOIN [Vendedor] T2 ON T2.[VendedorId] = TM1.[VendedorProdutoId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = TM1.[PaisProdutoId]) INNER JOIN [Fornecedor] T4 ON T4.[FornecedorId] = TM1.[FornecedorProdutoId]) INNER JOIN [Categoria] T5 ON T5.[CategoriaId] = TM1.[CategoriaProdutoId]) WHERE TM1.[ProdutoId] = @ProdutoId ORDER BY TM1.[ProdutoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00068,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00069", "SELECT [ProdutoNome] FROM [Produto] WHERE ([ProdutoNome] = @ProdutoNome) AND (Not ( [ProdutoId] = @ProdutoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00069,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000610", "SELECT [VendedorNome] AS VendedorProdutoNome, [VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, [VendedorFoto] AS VendedorProdutoImagem FROM [Vendedor] WHERE [VendedorId] = @VendedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000610,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000611", "SELECT [PaisNome] AS PaisProdutoNome FROM [Pais] WHERE [PaisId] = @PaisProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000611,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000612", "SELECT [FornecedorNome] AS FornecedorProdutoNome FROM [Fornecedor] WHERE [FornecedorId] = @FornecedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000613", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000614", "SELECT [ProdutoId] FROM [Produto] WHERE [ProdutoId] = @ProdutoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000615", "SELECT TOP 1 [ProdutoId] FROM [Produto] WHERE ( [ProdutoId] > @ProdutoId) ORDER BY [ProdutoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000616", "SELECT TOP 1 [ProdutoId] FROM [Produto] WHERE ( [ProdutoId] < @ProdutoId) ORDER BY [ProdutoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000617", "INSERT INTO [Produto]([ProdutoId], [ProdutoNome], [ProdutoDescricao], [ProdutoPreco], [ProdutoImagem], [ProdutoImagem_GXI], [VendedorProdutoId], [PaisProdutoId], [FornecedorProdutoId], [CategoriaProdutoId]) VALUES(@ProdutoId, @ProdutoNome, @ProdutoDescricao, @ProdutoPreco, @ProdutoImagem, @ProdutoImagem_GXI, @VendedorProdutoId, @PaisProdutoId, @FornecedorProdutoId, @CategoriaProdutoId)", GxErrorMask.GX_NOMASK,prmT000617)
             ,new CursorDef("T000618", "UPDATE [Produto] SET [ProdutoNome]=@ProdutoNome, [ProdutoDescricao]=@ProdutoDescricao, [ProdutoPreco]=@ProdutoPreco, [VendedorProdutoId]=@VendedorProdutoId, [PaisProdutoId]=@PaisProdutoId, [FornecedorProdutoId]=@FornecedorProdutoId, [CategoriaProdutoId]=@CategoriaProdutoId  WHERE [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmT000618)
             ,new CursorDef("T000619", "UPDATE [Produto] SET [ProdutoImagem]=@ProdutoImagem, [ProdutoImagem_GXI]=@ProdutoImagem_GXI  WHERE [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmT000619)
             ,new CursorDef("T000620", "DELETE FROM [Produto]  WHERE [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmT000620)
             ,new CursorDef("T000621", "SELECT [VendedorNome] AS VendedorProdutoNome, [VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, [VendedorFoto] AS VendedorProdutoImagem FROM [Vendedor] WHERE [VendedorId] = @VendedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000621,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000622", "SELECT [PaisNome] AS PaisProdutoNome FROM [Pais] WHERE [PaisId] = @PaisProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000622,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000623", "SELECT [FornecedorNome] AS FornecedorProdutoNome FROM [Fornecedor] WHERE [FornecedorId] = @FornecedorProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000623,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000624", "SELECT [CategoriaNome] AS CategoriaProdutoNome FROM [Categoria] WHERE [CategoriaId] = @CategoriaProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000624,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000625", "SELECT TOP 1 [CarrinhoComprasId], [ProdutoId] FROM [CarrinhoComprasProdutos] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000625,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000626", "SELECT TOP 1 [PromocaoId], [ProdutoId] FROM [PromocaoProduto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000626,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000627", "SELECT [ProdutoId] FROM [Produto] ORDER BY [ProdutoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000627,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000628", "SELECT [ProdutoNome] FROM [Produto] WHERE ([ProdutoNome] = @ProdutoNome) AND (Not ( [ProdutoId] = @ProdutoId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000628,1, GxCacheFrequency.OFF ,true,false )
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
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((short[]) buf[7])[0] = rslt.getShort(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 3 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 4 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 5 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((decimal[]) buf[3])[0] = rslt.getDecimal(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getMultimediaUri(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((short[]) buf[12])[0] = rslt.getShort(12);
                ((short[]) buf[13])[0] = rslt.getShort(13);
                ((short[]) buf[14])[0] = rslt.getShort(14);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(5));
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(7));
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 9 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 10 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 11 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 12 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(2));
                return;
             case 20 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 21 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 22 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 23 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 24 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 25 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 26 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
       }
    }

 }

}
