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
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class wwcarrinhocompras : GXDataArea
   {
      public wwcarrinhocompras( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public wwcarrinhocompras( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
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

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
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
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
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
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_29 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_29"), "."));
         nGXsfl_29_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_29_idx"), "."));
         sGXsfl_29_idx = GetPar( "sGXsfl_29_idx");
         AV13Update = GetPar( "Update");
         AV15Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(NumberUtil.Val( GetPar( "subGrid_Rows"), "."));
         AV11CarrinhoComprasData = context.localUtil.ParseDateParm( GetPar( "CarrinhoComprasData"));
         AV12CarrinhoComprasDataEntrega = context.localUtil.ParseDateParm( GetPar( "CarrinhoComprasDataEntrega"));
         AV14ADVANCED_LABEL_TEMPLATE = GetPar( "ADVANCED_LABEL_TEMPLATE");
         AV13Update = GetPar( "Update");
         AV15Delete = GetPar( "Delete");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega, AV14ADVANCED_LABEL_TEMPLATE, AV13Update, AV15Delete) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA0F2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0F2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwcarrinhocompras.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCARRINHOCOMPRASDATA", context.localUtil.Format(AV11CarrinhoComprasData, "99/99/99"));
         GxWebStd.gx_hidden_field( context, "GXH_vCARRINHOCOMPRASDATAENTREGA", context.localUtil.Format(AV12CarrinhoComprasDataEntrega, "99/99/99"));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_29", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_29), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "FILTERSCONTAINER_Class", StringUtil.RTrim( divFilterscontainer_Class));
         GxWebStd.gx_hidden_field( context, "CARRINHOCOMPRASDATAENTREGAFILTERCONTAINER_Class", StringUtil.RTrim( divCarrinhocomprasdataentregafiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE0F2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0F2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("wwcarrinhocompras.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWCarrinhoCompras" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carrinho de compras" ;
      }

      protected void WB0F0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "body-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", divGridcell_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "container-fluid container-advanced", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__title-cell", "left", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTitletext_Internalname, "Carrinho de compras", "", "", lblTitletext_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWCarrinhoCompras.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__actions-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 15,'',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWCarrinhoCompras.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__filter-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarrinhocomprasdata_Internalname, "Carrinho Compras Data", "gx-form-item attribute-searchLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 18,'',false,'" + sGXsfl_29_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCarrinhocomprasdata_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCarrinhocomprasdata_Internalname, context.localUtil.Format(AV11CarrinhoComprasData, "99/99/99"), context.localUtil.Format( AV11CarrinhoComprasData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,18);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarrinhocomprasdata_Jsonclick, 0, "attribute-search", "", "", "", "", 1, edtavCarrinhocomprasdata_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWCarrinhoCompras.htm");
            GxWebStd.gx_bitmap( context, edtavCarrinhocomprasdata_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtavCarrinhocomprasdata_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWCarrinhoCompras.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__toggle-cell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 20,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", bttBtntoggle_Caption, bttBtntoggle_Jsonclick, 7, bttBtntoggle_Tooltiptext, "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110f1_client"+"'", TempTags, "", 2, "HLP_WWCarrinhoCompras.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcontainer_Internalname, 1, 0, "px", 0, "px", "ww__grid-container", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl29( ) ;
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            nRC_GXsfl_29 = (int)(nGXsfl_29_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 col-md-2 ww__filters-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divFilterscontainer_Internalname, 1, 0, "px", 0, "px", divFilterscontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Right", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            ClassString = "filters-container__close";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggleontable_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(29), 2, 0)+","+"null"+");", "Hide Filters", bttBtntoggleontable_Jsonclick, 7, "Hide Filters", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e110f1_client"+"'", TempTags, "", 2, "HLP_WWCarrinhoCompras.htm");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCarrinhocomprasdataentregafiltercontainer_Internalname, 1, 0, "px", 0, "px", divCarrinhocomprasdataentregafiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcarrinhocomprasdataentregafilter_Internalname, lblLblcarrinhocomprasdataentregafilter_Caption, "", "", lblLblcarrinhocomprasdataentregafilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120f1_client"+"'", "", "filter-item__label", 7, "", 1, 1, 0, 1, "HLP_WWCarrinhoCompras.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 filter-item__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCarrinhocomprasdataentrega_Internalname, "Carrinho Compras Data Entrega", "col-sm-3 attribute-comboLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_29_idx + "',0)\"";
            context.WriteHtmlText( "<div id=\""+edtavCarrinhocomprasdataentrega_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtavCarrinhocomprasdataentrega_Internalname, context.localUtil.Format(AV12CarrinhoComprasDataEntrega, "99/99/99"), context.localUtil.Format( AV12CarrinhoComprasDataEntrega, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCarrinhocomprasdataentrega_Jsonclick, 0, "attribute-combo", "", "", "", "", 1, edtavCarrinhocomprasdataentrega_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_WWCarrinhoCompras.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 29 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0F2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
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
         wbErr = false;
         STRUP0F0( ) ;
      }

      protected void WS0F2( )
      {
         START0F2( ) ;
         EVT0F2( ) ;
      }

      protected void EVT0F2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E130F2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_29_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
                              SubsflControlProps_292( ) ;
                              A52CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( edtCarrinhoComprasId_Internalname), ".", ","));
                              A53CarrinhoComprasData = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCarrinhoComprasData_Internalname), 0));
                              A54ClienteCarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasId_Internalname), ".", ","));
                              A55ClienteCarrinhoComprasNome = cgiGet( edtClienteCarrinhoComprasNome_Internalname);
                              A56ClienteCarrinhoComprasEndereco = cgiGet( edtClienteCarrinhoComprasEndereco_Internalname);
                              A57ClienteCarrinhoComprasPaisId = (short)(context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasPaisId_Internalname), ".", ","));
                              A58ClienteCarrinhoComprasPaisNome = cgiGet( edtClienteCarrinhoComprasPaisNome_Internalname);
                              A62CarrinhoComprasPrecoTotal = context.localUtil.CToN( cgiGet( edtCarrinhoComprasPrecoTotal_Internalname), ".", ",");
                              n62CarrinhoComprasPrecoTotal = false;
                              A63CarrinhoComprasDataEntrega = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCarrinhoComprasDataEntrega_Internalname), 0));
                              A65CarrinhoComprasPontos = context.localUtil.CToN( cgiGet( edtCarrinhoComprasPontos_Internalname), ".", ",");
                              AV13Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri("", false, edtavUpdate_Internalname, AV13Update);
                              AV15Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri("", false, edtavDelete_Internalname, AV15Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E140F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E150F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E160F2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Carrinhocomprasdata Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCARRINHOCOMPRASDATA"), 0) != AV11CarrinhoComprasData )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Carrinhocomprasdataentrega Changed */
                                       if ( context.localUtil.CToT( cgiGet( "GXH_vCARRINHOCOMPRASDATAENTREGA"), 0) != AV12CarrinhoComprasDataEntrega )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0F2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA0F2( )
      {
         if ( nDonePA == 0 )
         {
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavCarrinhocomprasdata_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_292( ) ;
         while ( nGXsfl_29_idx <= nRC_GXsfl_29 )
         {
            sendrow_292( ) ;
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       DateTime AV11CarrinhoComprasData ,
                                       DateTime AV12CarrinhoComprasDataEntrega ,
                                       string AV14ADVANCED_LABEL_TEMPLATE ,
                                       string AV13Update ,
                                       string AV15Delete )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0F2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CARRINHOCOMPRASID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CARRINHOCOMPRASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0F2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV18Pgmname = "WWCarrinhoCompras";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_29_Refreshing);
      }

      protected void RF0F2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 29;
         /* Execute user event: Refresh */
         E150F2 ();
         nGXsfl_29_idx = 1;
         sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
         SubsflControlProps_292( ) ;
         bGXsfl_29_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ww__grid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_292( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV11CarrinhoComprasData ,
                                                 AV12CarrinhoComprasDataEntrega ,
                                                 A53CarrinhoComprasData } ,
                                                 new int[]{
                                                 TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                                 }
            });
            /* Using cursor H000F3 */
            pr_default.execute(0, new Object[] {AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_29_idx = 1;
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A58ClienteCarrinhoComprasPaisNome = H000F3_A58ClienteCarrinhoComprasPaisNome[0];
               A57ClienteCarrinhoComprasPaisId = H000F3_A57ClienteCarrinhoComprasPaisId[0];
               A56ClienteCarrinhoComprasEndereco = H000F3_A56ClienteCarrinhoComprasEndereco[0];
               A55ClienteCarrinhoComprasNome = H000F3_A55ClienteCarrinhoComprasNome[0];
               A54ClienteCarrinhoComprasId = H000F3_A54ClienteCarrinhoComprasId[0];
               A52CarrinhoComprasId = H000F3_A52CarrinhoComprasId[0];
               A53CarrinhoComprasData = H000F3_A53CarrinhoComprasData[0];
               A62CarrinhoComprasPrecoTotal = H000F3_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = H000F3_n62CarrinhoComprasPrecoTotal[0];
               A57ClienteCarrinhoComprasPaisId = H000F3_A57ClienteCarrinhoComprasPaisId[0];
               A56ClienteCarrinhoComprasEndereco = H000F3_A56ClienteCarrinhoComprasEndereco[0];
               A55ClienteCarrinhoComprasNome = H000F3_A55ClienteCarrinhoComprasNome[0];
               A58ClienteCarrinhoComprasPaisNome = H000F3_A58ClienteCarrinhoComprasPaisNome[0];
               A62CarrinhoComprasPrecoTotal = H000F3_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = H000F3_n62CarrinhoComprasPrecoTotal[0];
               A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
               if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
               {
                  A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
               }
               else
               {
                  A65CarrinhoComprasPontos = 0;
               }
               E160F2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 29;
            WB0F0( ) ;
         }
         bGXsfl_29_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0F2( )
      {
         GxWebStd.gx_hidden_field( context, "vADVANCED_LABEL_TEMPLATE", StringUtil.RTrim( AV14ADVANCED_LABEL_TEMPLATE));
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_CARRINHOCOMPRASID"+"_"+sGXsfl_29_idx, GetSecureSignedToken( sGXsfl_29_idx, context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9"), context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV11CarrinhoComprasData ,
                                              AV12CarrinhoComprasDataEntrega ,
                                              A53CarrinhoComprasData } ,
                                              new int[]{
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE
                                              }
         });
         /* Using cursor H000F5 */
         pr_default.execute(1, new Object[] {AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega});
         GRID_nRecordCount = H000F5_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega, AV14ADVANCED_LABEL_TEMPLATE, AV13Update, AV15Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega, AV14ADVANCED_LABEL_TEMPLATE, AV13Update, AV15Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega, AV14ADVANCED_LABEL_TEMPLATE, AV13Update, AV15Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega, AV14ADVANCED_LABEL_TEMPLATE, AV13Update, AV15Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV11CarrinhoComprasData, AV12CarrinhoComprasDataEntrega, AV14ADVANCED_LABEL_TEMPLATE, AV13Update, AV15Delete) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void subgrid_varsfromstate( )
      {
         if ( GridState.FilterCount >= 1 )
         {
            AV11CarrinhoComprasData = context.localUtil.CToD( GridState.FilterValues("Carrinhocomprasdata"), 1);
            AssignAttri("", false, "AV11CarrinhoComprasData", context.localUtil.Format(AV11CarrinhoComprasData, "99/99/99"));
            AV12CarrinhoComprasDataEntrega = context.localUtil.CToD( GridState.FilterValues("Carrinhocomprasdataentrega"), 1);
            AssignAttri("", false, "AV12CarrinhoComprasDataEntrega", context.localUtil.Format(AV12CarrinhoComprasDataEntrega, "99/99/99"));
         }
         if ( GridState.CurrentPage > 0 )
         {
            GridPageCount = subGrid_fnc_Pagecount( );
            if ( ( GridPageCount > 0 ) && ( GridPageCount < GridState.CurrentPage ) )
            {
               subgrid_gotopage( GridPageCount) ;
            }
            else
            {
               subgrid_gotopage( ((GridPageCount<0) ? 0 : GridState.CurrentPage)) ;
            }
         }
      }

      protected void subgrid_varstostate( )
      {
         GridState.CurrentPage = subGrid_fnc_Currentpage( );
         GridState.ClearFilterValues();
         GridState.AddFilterValue("CarrinhoComprasData", context.localUtil.Format(AV11CarrinhoComprasData, "99/99/99"));
         GridState.AddFilterValue("CarrinhoComprasDataEntrega", context.localUtil.Format(AV12CarrinhoComprasDataEntrega, "99/99/99"));
      }

      protected void before_start_formulas( )
      {
         AV18Pgmname = "WWCarrinhoCompras";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp("", false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp("", false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_29_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0F0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E140F2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_29 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_29"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( "GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            if ( context.localUtil.VCDate( cgiGet( edtavCarrinhocomprasdata_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Carrinho Compras Data"}), 1, "vCARRINHOCOMPRASDATA");
               GX_FocusControl = edtavCarrinhocomprasdata_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11CarrinhoComprasData = DateTime.MinValue;
               AssignAttri("", false, "AV11CarrinhoComprasData", context.localUtil.Format(AV11CarrinhoComprasData, "99/99/99"));
            }
            else
            {
               AV11CarrinhoComprasData = context.localUtil.CToD( cgiGet( edtavCarrinhocomprasdata_Internalname), 1);
               AssignAttri("", false, "AV11CarrinhoComprasData", context.localUtil.Format(AV11CarrinhoComprasData, "99/99/99"));
            }
            if ( context.localUtil.VCDate( cgiGet( edtavCarrinhocomprasdataentrega_Internalname), 1) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Carrinho Compras Data Entrega"}), 1, "vCARRINHOCOMPRASDATAENTREGA");
               GX_FocusControl = edtavCarrinhocomprasdataentrega_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12CarrinhoComprasDataEntrega = DateTime.MinValue;
               AssignAttri("", false, "AV12CarrinhoComprasDataEntrega", context.localUtil.Format(AV12CarrinhoComprasDataEntrega, "99/99/99"));
            }
            else
            {
               AV12CarrinhoComprasDataEntrega = context.localUtil.CToD( cgiGet( edtavCarrinhocomprasdataentrega_Internalname), 1);
               AssignAttri("", false, "AV12CarrinhoComprasDataEntrega", context.localUtil.Format(AV12CarrinhoComprasDataEntrega, "99/99/99"));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCARRINHOCOMPRASDATA"), 1) ) != DateTimeUtil.ResetTime ( AV11CarrinhoComprasData ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( DateTimeUtil.ResetTime ( context.localUtil.CToD( cgiGet( "GXH_vCARRINHOCOMPRASDATAENTREGA"), 1) ) != DateTimeUtil.ResetTime ( AV12CarrinhoComprasDataEntrega ) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E140F2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E140F2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV18Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV18Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV13Update = "Update";
         AssignAttri("", false, edtavUpdate_Internalname, AV13Update);
         AV15Delete = "Delete";
         AssignAttri("", false, edtavDelete_Internalname, AV15Delete);
         Form.Caption = "Carrinho de compras";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
         AssignAttri("", false, "AV14ADVANCED_LABEL_TEMPLATE", AV14ADVANCED_LABEL_TEMPLATE);
         GxWebStd.gx_hidden_field( context, "gxhash_vADVANCED_LABEL_TEMPLATE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "")), context));
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         GridState.LoadGridState();
      }

      protected void E150F2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         GridState.SaveGridState();
         if ( (DateTime.MinValue==AV12CarrinhoComprasDataEntrega) )
         {
            lblLblcarrinhocomprasdataentregafilter_Caption = "";
            AssignProp("", false, lblLblcarrinhocomprasdataentregafilter_Internalname, "Caption", lblLblcarrinhocomprasdataentregafilter_Caption, true);
         }
         else
         {
            lblLblcarrinhocomprasdataentregafilter_Caption = StringUtil.Format( AV14ADVANCED_LABEL_TEMPLATE, "", context.localUtil.DToC( AV12CarrinhoComprasDataEntrega, 0, "-"), "", "", "", "", "", "", "");
            AssignProp("", false, lblLblcarrinhocomprasdataentregafilter_Internalname, "Caption", lblLblcarrinhocomprasdataentregafilter_Caption, true);
         }
         /*  Sending Event outputs  */
      }

      private void E160F2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("carrinhocompras.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0))}, new string[] {"Mode","CarrinhoComprasId"}) ;
         edtavDelete_Link = formatLink("carrinhocompras.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0))}, new string[] {"Mode","CarrinhoComprasId"}) ;
         edtCarrinhoComprasData_Link = formatLink("viewcarrinhocompras.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CarrinhoComprasId","TabCode"}) ;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 29;
         }
         sendrow_292( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_29_Refreshing )
         {
            DoAjaxLoad(29, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E130F2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         CallWebObject(formatLink("carrinhocompras.aspx", new object[] {UrlEncode(StringUtil.RTrim("INS")),UrlEncode(StringUtil.LTrimStr(0,1,0))}, new string[] {"Mode","CarrinhoComprasId"}) );
         context.wjLocDisableFrm = 1;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV18Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV7HTTPRequest.ScriptName+"?"+AV7HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "CarrinhoCompras";
         AV6Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA0F2( ) ;
         WS0F2( ) ;
         WE0F2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513876", true, true);
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
         context.AddJavascriptSource("wwcarrinhocompras.js", "?202582916513876", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_292( )
      {
         edtCarrinhoComprasId_Internalname = "CARRINHOCOMPRASID_"+sGXsfl_29_idx;
         edtCarrinhoComprasData_Internalname = "CARRINHOCOMPRASDATA_"+sGXsfl_29_idx;
         edtClienteCarrinhoComprasId_Internalname = "CLIENTECARRINHOCOMPRASID_"+sGXsfl_29_idx;
         edtClienteCarrinhoComprasNome_Internalname = "CLIENTECARRINHOCOMPRASNOME_"+sGXsfl_29_idx;
         edtClienteCarrinhoComprasEndereco_Internalname = "CLIENTECARRINHOCOMPRASENDERECO_"+sGXsfl_29_idx;
         edtClienteCarrinhoComprasPaisId_Internalname = "CLIENTECARRINHOCOMPRASPAISID_"+sGXsfl_29_idx;
         edtClienteCarrinhoComprasPaisNome_Internalname = "CLIENTECARRINHOCOMPRASPAISNOME_"+sGXsfl_29_idx;
         edtCarrinhoComprasPrecoTotal_Internalname = "CARRINHOCOMPRASPRECOTOTAL_"+sGXsfl_29_idx;
         edtCarrinhoComprasDataEntrega_Internalname = "CARRINHOCOMPRASDATAENTREGA_"+sGXsfl_29_idx;
         edtCarrinhoComprasPontos_Internalname = "CARRINHOCOMPRASPONTOS_"+sGXsfl_29_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_29_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_29_idx;
      }

      protected void SubsflControlProps_fel_292( )
      {
         edtCarrinhoComprasId_Internalname = "CARRINHOCOMPRASID_"+sGXsfl_29_fel_idx;
         edtCarrinhoComprasData_Internalname = "CARRINHOCOMPRASDATA_"+sGXsfl_29_fel_idx;
         edtClienteCarrinhoComprasId_Internalname = "CLIENTECARRINHOCOMPRASID_"+sGXsfl_29_fel_idx;
         edtClienteCarrinhoComprasNome_Internalname = "CLIENTECARRINHOCOMPRASNOME_"+sGXsfl_29_fel_idx;
         edtClienteCarrinhoComprasEndereco_Internalname = "CLIENTECARRINHOCOMPRASENDERECO_"+sGXsfl_29_fel_idx;
         edtClienteCarrinhoComprasPaisId_Internalname = "CLIENTECARRINHOCOMPRASPAISID_"+sGXsfl_29_fel_idx;
         edtClienteCarrinhoComprasPaisNome_Internalname = "CLIENTECARRINHOCOMPRASPAISNOME_"+sGXsfl_29_fel_idx;
         edtCarrinhoComprasPrecoTotal_Internalname = "CARRINHOCOMPRASPRECOTOTAL_"+sGXsfl_29_fel_idx;
         edtCarrinhoComprasDataEntrega_Internalname = "CARRINHOCOMPRASDATAENTREGA_"+sGXsfl_29_fel_idx;
         edtCarrinhoComprasPontos_Internalname = "CARRINHOCOMPRASPONTOS_"+sGXsfl_29_fel_idx;
         edtavUpdate_Internalname = "vUPDATE_"+sGXsfl_29_fel_idx;
         edtavDelete_Internalname = "vDELETE_"+sGXsfl_29_fel_idx;
      }

      protected void sendrow_292( )
      {
         SubsflControlProps_292( ) ;
         WB0F0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_29_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_29_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"ww__grid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_29_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasData_Internalname,context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"),context.localUtil.Format( A53CarrinhoComprasData, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCarrinhoComprasData_Link,(string)"",(string)"",(string)"",(string)edtCarrinhoComprasData_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A54ClienteCarrinhoComprasId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A54ClienteCarrinhoComprasId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasNome_Internalname,(string)A55ClienteCarrinhoComprasNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasEndereco_Internalname,(string)A56ClienteCarrinhoComprasEndereco,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A56ClienteCarrinhoComprasEndereco),(string)"_blank",(string)"",(string)"",(string)edtClienteCarrinhoComprasEndereco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasPaisId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A57ClienteCarrinhoComprasPaisId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasPaisId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasPaisNome_Internalname,(string)A58ClienteCarrinhoComprasPaisNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasPaisNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasPrecoTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A62CarrinhoComprasPrecoTotal, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A62CarrinhoComprasPrecoTotal, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasPrecoTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasDataEntrega_Internalname,context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"),context.localUtil.Format( A63CarrinhoComprasDataEntrega, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasDataEntrega_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasPontos_Internalname,StringUtil.LTrim( StringUtil.NToC( A65CarrinhoComprasPontos, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A65CarrinhoComprasPontos, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasPontos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV13Update),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV15Delete),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)29,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0F2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_29_idx = ((subGrid_Islastpage==1)&&(nGXsfl_29_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_29_idx+1);
            sGXsfl_29_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_29_idx), 4, 0), 4, "0");
            SubsflControlProps_292( ) ;
         }
         /* End function sendrow_292 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl29( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"29\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ww__grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "compras") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Endereço") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "País") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "País") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "total") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "de entrega") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Compras Pontos") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"TextActionAttribute TextLikeLink"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "ww__grid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCarrinhoComprasData_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A54ClienteCarrinhoComprasId), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A55ClienteCarrinhoComprasNome);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A56ClienteCarrinhoComprasEndereco);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", A58ClienteCarrinhoComprasPaisNome);
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A62CarrinhoComprasPrecoTotal, 10, 2, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A65CarrinhoComprasPontos, 10, 2, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV13Update));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV15Delete));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDelete_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavDelete_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTitletext_Internalname = "TITLETEXT";
         bttBtninsert_Internalname = "BTNINSERT";
         edtavCarrinhocomprasdata_Internalname = "vCARRINHOCOMPRASDATA";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         divTabletop_Internalname = "TABLETOP";
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
         edtavUpdate_Internalname = "vUPDATE";
         edtavDelete_Internalname = "vDELETE";
         divGridcontainer_Internalname = "GRIDCONTAINER";
         divGridtable_Internalname = "GRIDTABLE";
         divGridcell_Internalname = "GRIDCELL";
         bttBtntoggleontable_Internalname = "BTNTOGGLEONTABLE";
         lblLblcarrinhocomprasdataentregafilter_Internalname = "LBLCARRINHOCOMPRASDATAENTREGAFILTER";
         edtavCarrinhocomprasdataentrega_Internalname = "vCARRINHOCOMPRASDATAENTREGA";
         divCarrinhocomprasdataentregafiltercontainer_Internalname = "CARRINHOCOMPRASDATAENTREGAFILTERCONTAINER";
         divFilterscontainer_Internalname = "FILTERSCONTAINER";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtavDelete_Jsonclick = "";
         edtavDelete_Link = "";
         edtavDelete_Enabled = 0;
         edtavUpdate_Jsonclick = "";
         edtavUpdate_Link = "";
         edtavUpdate_Enabled = 0;
         edtCarrinhoComprasPontos_Jsonclick = "";
         edtCarrinhoComprasDataEntrega_Jsonclick = "";
         edtCarrinhoComprasPrecoTotal_Jsonclick = "";
         edtClienteCarrinhoComprasPaisNome_Jsonclick = "";
         edtClienteCarrinhoComprasPaisId_Jsonclick = "";
         edtClienteCarrinhoComprasEndereco_Jsonclick = "";
         edtClienteCarrinhoComprasNome_Jsonclick = "";
         edtClienteCarrinhoComprasId_Jsonclick = "";
         edtCarrinhoComprasData_Jsonclick = "";
         edtCarrinhoComprasData_Link = "";
         edtCarrinhoComprasId_Jsonclick = "";
         subGrid_Class = "ww__grid";
         subGrid_Backcolorstyle = 0;
         edtavCarrinhocomprasdataentrega_Jsonclick = "";
         edtavCarrinhocomprasdataentrega_Enabled = 1;
         lblLblcarrinhocomprasdataentregafilter_Caption = "";
         bttBtntoggle_Class = "ww__button-filters--hide";
         bttBtntoggle_Tooltiptext = "Show Filters";
         bttBtntoggle_Caption = "Show Filters";
         edtavCarrinhocomprasdata_Jsonclick = "";
         edtavCarrinhocomprasdata_Enabled = 1;
         divGridcell_Class = "col-xs-12 col-sm-9 col-md-10 ww__grid-cell--expanded";
         divCarrinhocomprasdataentregafiltercontainer_Class = "filters-container__item";
         divFilterscontainer_Class = "filters-container";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Carrinho de compras";
         subGrid_Rows = 10;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11CarrinhoComprasData',fld:'vCARRINHOCOMPRASDATA',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV15Delete',fld:'vDELETE',pic:''},{av:'AV12CarrinhoComprasDataEntrega',fld:'vCARRINHOCOMPRASDATAENTREGA',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'lblLblcarrinhocomprasdataentregafilter_Caption',ctrl:'LBLCARRINHOCOMPRASDATAENTREGAFILTER',prop:'Caption'}]}");
         setEventMetadata("'TOGGLE'","{handler:'E110F1',iparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divFilterscontainer_Class',ctrl:'FILTERSCONTAINER',prop:'Class'},{av:'divGridcell_Class',ctrl:'GRIDCELL',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Caption'},{ctrl:'BTNTOGGLE',prop:'Tooltiptext'}]}");
         setEventMetadata("LBLCARRINHOCOMPRASDATAENTREGAFILTER.CLICK","{handler:'E120F1',iparms:[{av:'divCarrinhocomprasdataentregafiltercontainer_Class',ctrl:'CARRINHOCOMPRASDATAENTREGAFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCARRINHOCOMPRASDATAENTREGAFILTER.CLICK",",oparms:[{av:'divCarrinhocomprasdataentregafiltercontainer_Class',ctrl:'CARRINHOCOMPRASDATAENTREGAFILTERCONTAINER',prop:'Class'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E160F2',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtCarrinhoComprasData_Link',ctrl:'CARRINHOCOMPRASDATA',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E130F2',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11CarrinhoComprasData',fld:'vCARRINHOCOMPRASDATA',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV15Delete',fld:'vDELETE',pic:''},{av:'AV12CarrinhoComprasDataEntrega',fld:'vCARRINHOCOMPRASDATAENTREGA',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{av:'lblLblcarrinhocomprasdataentregafilter_Caption',ctrl:'LBLCARRINHOCOMPRASDATAENTREGAFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11CarrinhoComprasData',fld:'vCARRINHOCOMPRASDATA',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV15Delete',fld:'vDELETE',pic:''},{av:'AV12CarrinhoComprasDataEntrega',fld:'vCARRINHOCOMPRASDATAENTREGA',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{av:'lblLblcarrinhocomprasdataentregafilter_Caption',ctrl:'LBLCARRINHOCOMPRASDATAENTREGAFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11CarrinhoComprasData',fld:'vCARRINHOCOMPRASDATA',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV15Delete',fld:'vDELETE',pic:''},{av:'AV12CarrinhoComprasDataEntrega',fld:'vCARRINHOCOMPRASDATAENTREGA',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{av:'lblLblcarrinhocomprasdataentregafilter_Caption',ctrl:'LBLCARRINHOCOMPRASDATAENTREGAFILTER',prop:'Caption'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV11CarrinhoComprasData',fld:'vCARRINHOCOMPRASDATA',pic:''},{av:'AV13Update',fld:'vUPDATE',pic:''},{av:'AV15Delete',fld:'vDELETE',pic:''},{av:'AV12CarrinhoComprasDataEntrega',fld:'vCARRINHOCOMPRASDATAENTREGA',pic:''},{av:'AV14ADVANCED_LABEL_TEMPLATE',fld:'vADVANCED_LABEL_TEMPLATE',pic:'',hsh:true}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{av:'lblLblcarrinhocomprasdataentregafilter_Caption',ctrl:'LBLCARRINHOCOMPRASDATAENTREGAFILTER',prop:'Caption'}]}");
         setEventMetadata("VALIDV_CARRINHOCOMPRASDATA","{handler:'Validv_Carrinhocomprasdata',iparms:[]");
         setEventMetadata("VALIDV_CARRINHOCOMPRASDATA",",oparms:[]}");
         setEventMetadata("VALIDV_CARRINHOCOMPRASDATAENTREGA","{handler:'Validv_Carrinhocomprasdataentrega',iparms:[]");
         setEventMetadata("VALIDV_CARRINHOCOMPRASDATAENTREGA",",oparms:[]}");
         setEventMetadata("VALID_CARRINHOCOMPRASID","{handler:'Valid_Carrinhocomprasid',iparms:[]");
         setEventMetadata("VALID_CARRINHOCOMPRASID",",oparms:[]}");
         setEventMetadata("VALID_CARRINHOCOMPRASDATA","{handler:'Valid_Carrinhocomprasdata',iparms:[]");
         setEventMetadata("VALID_CARRINHOCOMPRASDATA",",oparms:[]}");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASID","{handler:'Valid_Clientecarrinhocomprasid',iparms:[]");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASID",",oparms:[]}");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASPAISID","{handler:'Valid_Clientecarrinhocompraspaisid',iparms:[]");
         setEventMetadata("VALID_CLIENTECARRINHOCOMPRASPAISID",",oparms:[]}");
         setEventMetadata("VALID_CARRINHOCOMPRASPRECOTOTAL","{handler:'Valid_Carrinhocomprasprecototal',iparms:[]");
         setEventMetadata("VALID_CARRINHOCOMPRASPRECOTOTAL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Delete',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV13Update = "";
         AV15Delete = "";
         AV11CarrinhoComprasData = DateTime.MinValue;
         AV12CarrinhoComprasDataEntrega = DateTime.MinValue;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTitletext_Jsonclick = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtntoggle_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         bttBtntoggleontable_Jsonclick = "";
         lblLblcarrinhocomprasdataentregafilter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A53CarrinhoComprasData = DateTime.MinValue;
         A55ClienteCarrinhoComprasNome = "";
         A56ClienteCarrinhoComprasEndereco = "";
         A58ClienteCarrinhoComprasPaisNome = "";
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         AV18Pgmname = "";
         GridState = new GXGridStateHandler(context,"Grid",GetPgmname(),subgrid_varsfromstate,subgrid_varstostate);
         scmdbuf = "";
         H000F3_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         H000F3_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         H000F3_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         H000F3_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         H000F3_A54ClienteCarrinhoComprasId = new short[1] ;
         H000F3_A52CarrinhoComprasId = new short[1] ;
         H000F3_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         H000F3_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         H000F3_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         H000F5_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7HTTPRequest = new GxHttpRequest( context);
         AV6Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwcarrinhocompras__default(),
            new Object[][] {
                new Object[] {
               H000F3_A58ClienteCarrinhoComprasPaisNome, H000F3_A57ClienteCarrinhoComprasPaisId, H000F3_A56ClienteCarrinhoComprasEndereco, H000F3_A55ClienteCarrinhoComprasNome, H000F3_A54ClienteCarrinhoComprasId, H000F3_A52CarrinhoComprasId, H000F3_A53CarrinhoComprasData, H000F3_A62CarrinhoComprasPrecoTotal, H000F3_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               H000F5_AGRID_nRecordCount
               }
            }
         );
         AV18Pgmname = "WWCarrinhoCompras";
         /* GeneXus formulas. */
         AV18Pgmname = "WWCarrinhoCompras";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A52CarrinhoComprasId ;
      private short A54ClienteCarrinhoComprasId ;
      private short A57ClienteCarrinhoComprasPaisId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_29 ;
      private int subGrid_Rows ;
      private int nGXsfl_29_idx=1 ;
      private int edtavCarrinhocomprasdata_Enabled ;
      private int edtavCarrinhocomprasdataentrega_Enabled ;
      private int subGrid_Islastpage ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int GridPageCount ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private decimal A62CarrinhoComprasPrecoTotal ;
      private decimal A65CarrinhoComprasPontos ;
      private string divFilterscontainer_Class ;
      private string divCarrinhocomprasdataentregafiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_29_idx="0001" ;
      private string AV13Update ;
      private string AV15Delete ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridcell_Class ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string lblTitletext_Internalname ;
      private string lblTitletext_Jsonclick ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string edtavCarrinhocomprasdata_Internalname ;
      private string edtavCarrinhocomprasdata_Jsonclick ;
      private string bttBtntoggle_Class ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Caption ;
      private string bttBtntoggle_Jsonclick ;
      private string bttBtntoggle_Tooltiptext ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string divFilterscontainer_Internalname ;
      private string bttBtntoggleontable_Internalname ;
      private string bttBtntoggleontable_Jsonclick ;
      private string divCarrinhocomprasdataentregafiltercontainer_Internalname ;
      private string lblLblcarrinhocomprasdataentregafilter_Internalname ;
      private string lblLblcarrinhocomprasdataentregafilter_Caption ;
      private string lblLblcarrinhocomprasdataentregafilter_Jsonclick ;
      private string edtavCarrinhocomprasdataentrega_Internalname ;
      private string edtavCarrinhocomprasdataentrega_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtCarrinhoComprasId_Internalname ;
      private string edtCarrinhoComprasData_Internalname ;
      private string edtClienteCarrinhoComprasId_Internalname ;
      private string edtClienteCarrinhoComprasNome_Internalname ;
      private string edtClienteCarrinhoComprasEndereco_Internalname ;
      private string edtClienteCarrinhoComprasPaisId_Internalname ;
      private string edtClienteCarrinhoComprasPaisNome_Internalname ;
      private string edtCarrinhoComprasPrecoTotal_Internalname ;
      private string edtCarrinhoComprasDataEntrega_Internalname ;
      private string edtCarrinhoComprasPontos_Internalname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string AV18Pgmname ;
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtCarrinhoComprasData_Link ;
      private string sGXsfl_29_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtCarrinhoComprasId_Jsonclick ;
      private string edtCarrinhoComprasData_Jsonclick ;
      private string edtClienteCarrinhoComprasId_Jsonclick ;
      private string edtClienteCarrinhoComprasNome_Jsonclick ;
      private string edtClienteCarrinhoComprasEndereco_Jsonclick ;
      private string edtClienteCarrinhoComprasPaisId_Jsonclick ;
      private string edtClienteCarrinhoComprasPaisNome_Jsonclick ;
      private string edtCarrinhoComprasPrecoTotal_Jsonclick ;
      private string edtCarrinhoComprasDataEntrega_Jsonclick ;
      private string edtCarrinhoComprasPontos_Jsonclick ;
      private string edtavUpdate_Jsonclick ;
      private string edtavDelete_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV11CarrinhoComprasData ;
      private DateTime AV12CarrinhoComprasDataEntrega ;
      private DateTime A53CarrinhoComprasData ;
      private DateTime A63CarrinhoComprasDataEntrega ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n62CarrinhoComprasPrecoTotal ;
      private bool bGXsfl_29_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private string A55ClienteCarrinhoComprasNome ;
      private string A56ClienteCarrinhoComprasEndereco ;
      private string A58ClienteCarrinhoComprasPaisNome ;
      private GXWebGrid GridContainer ;
      private GXGridStateHandler GridState ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000F3_A58ClienteCarrinhoComprasPaisNome ;
      private short[] H000F3_A57ClienteCarrinhoComprasPaisId ;
      private string[] H000F3_A56ClienteCarrinhoComprasEndereco ;
      private string[] H000F3_A55ClienteCarrinhoComprasNome ;
      private short[] H000F3_A54ClienteCarrinhoComprasId ;
      private short[] H000F3_A52CarrinhoComprasId ;
      private DateTime[] H000F3_A53CarrinhoComprasData ;
      private decimal[] H000F3_A62CarrinhoComprasPrecoTotal ;
      private bool[] H000F3_n62CarrinhoComprasPrecoTotal ;
      private long[] H000F5_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV7HTTPRequest ;
      private IGxSession AV6Session ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class wwcarrinhocompras__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000F3( IGxContext context ,
                                             DateTime AV11CarrinhoComprasData ,
                                             DateTime AV12CarrinhoComprasDataEntrega ,
                                             DateTime A53CarrinhoComprasData )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[5];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T3.[PaisNome] AS ClienteCarrinhoComprasPaisNome, T2.[PaisClienteId] AS ClienteCarrinhoComprasPaisId, T2.[ClienteEndereco] AS ClienteCarrinhoComprasEndereco, T2.[ClienteNome] AS ClienteCarrinhoComprasNome, T1.[ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId, T1.[CarrinhoComprasId], T1.[CarrinhoComprasData], COALESCE( T4.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal";
         sFromString = " FROM ((([CarrinhoCompras] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisClienteId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T1.[CarrinhoComprasId])";
         sOrderString = "";
         if ( ! (DateTime.MinValue==AV11CarrinhoComprasData) )
         {
            AddWhere(sWhereString, "(T1.[CarrinhoComprasData] >= @AV11CarrinhoComprasData)");
         }
         else
         {
            GXv_int1[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV12CarrinhoComprasDataEntrega) )
         {
            AddWhere(sWhereString, "(DATEADD( dd,( 5), T1.[CarrinhoComprasData]) >= @AV12CarrinhoComprasDataEntrega)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         sOrderString += " ORDER BY T1.[CarrinhoComprasData]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000F5( IGxContext context ,
                                             DateTime AV11CarrinhoComprasData ,
                                             DateTime AV12CarrinhoComprasDataEntrega ,
                                             DateTime A53CarrinhoComprasData )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[2];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM ((([CarrinhoCompras] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisClienteId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T1.[CarrinhoComprasId])";
         if ( ! (DateTime.MinValue==AV11CarrinhoComprasData) )
         {
            AddWhere(sWhereString, "(T1.[CarrinhoComprasData] >= @AV11CarrinhoComprasData)");
         }
         else
         {
            GXv_int3[0] = 1;
         }
         if ( ! (DateTime.MinValue==AV12CarrinhoComprasDataEntrega) )
         {
            AddWhere(sWhereString, "(DATEADD( dd,( 5), T1.[CarrinhoComprasData]) >= @AV12CarrinhoComprasDataEntrega)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         scmdbuf += sWhereString;
         GXv_Object4[0] = scmdbuf;
         GXv_Object4[1] = GXv_int3;
         return GXv_Object4 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H000F3(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] );
               case 1 :
                     return conditional_H000F5(context, (DateTime)dynConstraints[0] , (DateTime)dynConstraints[1] , (DateTime)dynConstraints[2] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000F3;
          prmH000F3 = new Object[] {
          new ParDef("@AV11CarrinhoComprasData",GXType.Date,8,0) ,
          new ParDef("@AV12CarrinhoComprasDataEntrega",GXType.Date,8,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000F5;
          prmH000F5 = new Object[] {
          new ParDef("@AV11CarrinhoComprasData",GXType.Date,8,0) ,
          new ParDef("@AV12CarrinhoComprasDataEntrega",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000F3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000F5", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000F5,1, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((short[]) buf[4])[0] = rslt.getShort(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
