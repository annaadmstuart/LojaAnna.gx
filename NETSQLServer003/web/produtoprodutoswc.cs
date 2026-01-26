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
   public class produtoprodutoswc : GXWebComponent
   {
      public produtoprodutoswc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            context.SetDefaultTheme("LojaAnnaLaisa");
         }
      }

      public produtoprodutoswc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ProdutoId )
      {
         this.AV6ProdutoId = aP0_ProdutoId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      public override void SetPrefix( string sPPrefix )
      {
         sPrefix = sPPrefix;
      }

      protected override void createObjects( )
      {
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ProdutoId");
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
               else if ( StringUtil.StrCmp(gxfirstwebparm, "dyncomponent") == 0 )
               {
                  setAjaxEventMode();
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  nDynComponent = 1;
                  sCompPrefix = GetPar( "sCompPrefix");
                  sSFPrefix = GetPar( "sSFPrefix");
                  AV6ProdutoId = (short)(NumberUtil.Val( GetPar( "ProdutoId"), "."));
                  AssignAttri(sPrefix, false, "AV6ProdutoId", StringUtil.LTrimStr( (decimal)(AV6ProdutoId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)AV6ProdutoId});
                  componentstart();
                  context.httpAjaxContext.ajax_rspStartCmp(sPrefix);
                  componentdraw();
                  context.httpAjaxContext.ajax_rspEndCmp();
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
                  gxfirstwebparm = GetFirstPar( "ProdutoId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ProdutoId");
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
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.IsLocalStorageSupported( ) )
            {
               context.PushCurrentUrl();
            }
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_22 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_22"), "."));
         nGXsfl_22_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_22_idx"), "."));
         sGXsfl_22_idx = GetPar( "sGXsfl_22_idx");
         sPrefix = GetPar( "sPrefix");
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
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
         AV6ProdutoId = (short)(NumberUtil.Val( GetPar( "ProdutoId"), "."));
         AV12Update = GetPar( "Update");
         AV13Delete = GetPar( "Delete");
         sPrefix = GetPar( "sPrefix");
         init_default_properties( ) ;
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV6ProdutoId, AV12Update, AV13Delete, sPrefix) ;
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
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               ValidateSpaRequest();
            }
            PA0X2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV17Pgmname = "ProdutoProdutosWC";
               context.Gx_err = 0;
               edtavUpdate_Enabled = 0;
               AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_22_Refreshing);
               edtavDelete_Enabled = 0;
               AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_22_Refreshing);
               WS0X2( ) ;
               if ( ! isAjaxCallMode( ) )
               {
                  if ( nDynComponent == 0 )
                  {
                     throw new System.Net.WebException("WebComponent is not allowed to run") ;
                  }
               }
            }
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

      protected void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      protected void RenderHtmlOpenForm( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            context.WriteHtmlText( "<title>") ;
            context.SendWebValue( "Produto Produtos WC") ;
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
         }
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("produtoprodutoswc.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV6ProdutoId,4,0))}, new string[] {"ProdutoId"}) +"\">") ;
               GxWebStd.gx_hidden_field( context, "_EventName", "");
               GxWebStd.gx_hidden_field( context, "_EventGridId", "");
               GxWebStd.gx_hidden_field( context, "_EventRowId", "");
               context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
               AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
            }
         }
         else
         {
            bool toggleHtmlOutput = isOutputEnabled( );
            if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableOutput();
               }
            }
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gxwebcomponent-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            if ( toggleHtmlOutput )
            {
               if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableOutput();
                  }
               }
            }
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
         }
         if ( StringUtil.StringSearch( sPrefix, "MP", 1) == 1 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, sPrefix+"nRC_GXsfl_22", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_22), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOAV6ProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOAV6ProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"vPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0X2( )
      {
         SendCloseFormHiddens( ) ;
         if ( ( StringUtil.Len( sPrefix) != 0 ) && ( context.isAjaxRequest( ) || context.isSpaRequest( ) ) )
         {
            componentjscripts();
         }
         GxWebStd.gx_hidden_field( context, sPrefix+"GX_FocusControl", GX_FocusControl);
         define_styles( ) ;
         SendSecurityToken(sPrefix);
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            SendAjaxEncryptionKey();
            SendComponentObjects();
            SendServerCommands();
            SendState();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            if ( nGXWrapped != 1 )
            {
               context.WriteHtmlTextNl( "</form>") ;
            }
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
            include_jscripts( ) ;
            context.WriteHtmlTextNl( "</body>") ;
            context.WriteHtmlTextNl( "</html>") ;
            if ( context.isSpaRequest( ) )
            {
               enableOutput();
            }
         }
         else
         {
            SendWebComponentState();
            context.WriteHtmlText( "</div>") ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
      }

      public override string GetPgmname( )
      {
         return "ProdutoProdutosWC" ;
      }

      public override string GetPgmdesc( )
      {
         return "Produto Produtos WC" ;
      }

      protected void WB0X0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               RenderHtmlHeaders( ) ;
            }
            RenderHtmlOpenForm( ) ;
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "produtoprodutoswc.aspx");
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "ww__view__grid-table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 ww__grid-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabletop_Internalname, 1, 0, "px", 0, "px", "Flex ww__actions-container", "left", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ww__view__grid__actions-cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 13,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(22), 2, 0)+","+"null"+");", "Insert", bttBtninsert_Jsonclick, 5, "Insert", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+sPrefix+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_ProdutoProdutosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, sPrefix, "false");
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
            StartGridControl22( ) ;
         }
         if ( wbEnd == 22 )
         {
            wbEnd = 0;
            nRC_GXsfl_22 = (int)(nGXsfl_22_idx-1);
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
               context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProdutoId_Internalname, "Produto", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtProdutoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoId_Jsonclick, 0, "Attribute", "", "", "", "", edtProdutoId_Visible, edtProdutoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ProdutoProdutosWC.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 22 )
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
                  context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid(sPrefix+"_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! isAjaxCallMode( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, sPrefix+"GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+sPrefix+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0X2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( ! context.isSpaRequest( ) )
            {
               if ( context.ExposeMetadata( ) )
               {
                  Form.Meta.addItem("generator", "GeneXus .NET 18_0_0-166471", 0) ;
               }
               Form.Meta.addItem("description", "Produto Produtos WC", 0) ;
            }
            context.wjLoc = "";
            context.nUserReturn = 0;
            context.wbHandled = 0;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               sXEvt = cgiGet( "_EventName");
               if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
               {
               }
            }
         }
         wbErr = false;
         if ( ( StringUtil.Len( sPrefix) == 0 ) || ( nDraw == 1 ) )
         {
            if ( nDoneStart == 0 )
            {
               STRUP0X0( ) ;
            }
         }
      }

      protected void WS0X2( )
      {
         START0X2( ) ;
         EVT0X2( ) ;
      }

      protected void EVT0X2( )
      {
         sXEvt = cgiGet( "_EventName");
         if ( ( ( ( StringUtil.Len( sPrefix) == 0 ) ) || ( StringUtil.StringSearch( sXEvt, sPrefix, 1) > 0 ) ) && ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               if ( context.wbHandled == 0 )
               {
                  if ( StringUtil.Len( sPrefix) == 0 )
                  {
                     sEvt = cgiGet( "_EventName");
                     EvtGridId = cgiGet( "_EventGridId");
                     EvtRowId = cgiGet( "_EventRowId");
                  }
                  if ( StringUtil.Len( sEvt) > 0 )
                  {
                     sEvtType = StringUtil.Left( sEvt, 1);
                     sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: 'DoInsert' */
                                    E110X2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              sEvt = cgiGet( sPrefix+"GRIDPAGING");
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0X0( ) ;
                              }
                              nGXsfl_22_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
                              SubsflControlProps_222( ) ;
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
                              AV12Update = cgiGet( edtavUpdate_Internalname);
                              AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV12Update);
                              AV13Delete = cgiGet( edtavDelete_Internalname);
                              AssignAttri(sPrefix, false, edtavDelete_Internalname, AV13Delete);
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          /* Execute user event: Start */
                                          E120X2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                          E130X2 ();
                                       }
                                    }
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          if ( ! wbErr )
                                          {
                                             Rfr0gs = false;
                                             if ( ! Rfr0gs )
                                             {
                                             }
                                             dynload_actions( ) ;
                                          }
                                       }
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                                    {
                                       STRUP0X0( ) ;
                                    }
                                    if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                                    {
                                       context.wbHandled = 1;
                                       if ( ! wbErr )
                                       {
                                          dynload_actions( ) ;
                                       }
                                    }
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

      protected void WE0X2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0X2( ) ;
            }
         }
      }

      protected void PA0X2( )
      {
         if ( nDonePA == 0 )
         {
            if ( StringUtil.Len( sPrefix) != 0 )
            {
               initialize_properties( ) ;
            }
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( context.isSpaRequest( ) )
               {
                  disableJsOutput();
               }
            }
            init_web_controls( ) ;
            if ( StringUtil.Len( sPrefix) == 0 )
            {
               if ( toggleJsOutput )
               {
                  if ( context.isSpaRequest( ) )
                  {
                     enableJsOutput();
                  }
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
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
         SubsflControlProps_222( ) ;
         while ( nGXsfl_22_idx <= nRC_GXsfl_22 )
         {
            sendrow_222( ) ;
            nGXsfl_22_idx = ((subGrid_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV6ProdutoId ,
                                       string AV12Update ,
                                       string AV13Delete ,
                                       string sPrefix )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0X2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CARRINHOCOMPRASID", GetSecureSignedToken( sPrefix, context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, sPrefix+"CARRINHOCOMPRASID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")));
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
         RF0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV17Pgmname = "ProdutoProdutosWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_22_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_22_Refreshing);
      }

      protected void RF0X2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 22;
         nGXsfl_22_idx = 1;
         sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
         SubsflControlProps_222( ) ;
         bGXsfl_22_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", sPrefix);
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "ViewGrid");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_222( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            /* Using cursor H000X3 */
            pr_default.execute(0, new Object[] {AV6ProdutoId, GXPagingFrom2, GXPagingTo2});
            nGXsfl_22_idx = 1;
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A19ProdutoId = H000X3_A19ProdutoId[0];
               AssignAttri(sPrefix, false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
               A58ClienteCarrinhoComprasPaisNome = H000X3_A58ClienteCarrinhoComprasPaisNome[0];
               A57ClienteCarrinhoComprasPaisId = H000X3_A57ClienteCarrinhoComprasPaisId[0];
               A56ClienteCarrinhoComprasEndereco = H000X3_A56ClienteCarrinhoComprasEndereco[0];
               A55ClienteCarrinhoComprasNome = H000X3_A55ClienteCarrinhoComprasNome[0];
               A54ClienteCarrinhoComprasId = H000X3_A54ClienteCarrinhoComprasId[0];
               A52CarrinhoComprasId = H000X3_A52CarrinhoComprasId[0];
               A53CarrinhoComprasData = H000X3_A53CarrinhoComprasData[0];
               A62CarrinhoComprasPrecoTotal = H000X3_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = H000X3_n62CarrinhoComprasPrecoTotal[0];
               A54ClienteCarrinhoComprasId = H000X3_A54ClienteCarrinhoComprasId[0];
               A53CarrinhoComprasData = H000X3_A53CarrinhoComprasData[0];
               A57ClienteCarrinhoComprasPaisId = H000X3_A57ClienteCarrinhoComprasPaisId[0];
               A56ClienteCarrinhoComprasEndereco = H000X3_A56ClienteCarrinhoComprasEndereco[0];
               A55ClienteCarrinhoComprasNome = H000X3_A55ClienteCarrinhoComprasNome[0];
               A58ClienteCarrinhoComprasPaisNome = H000X3_A58ClienteCarrinhoComprasPaisNome[0];
               A62CarrinhoComprasPrecoTotal = H000X3_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = H000X3_n62CarrinhoComprasPrecoTotal[0];
               A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
               if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
               {
                  A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
               }
               else
               {
                  A65CarrinhoComprasPontos = 0;
               }
               E130X2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 22;
            WB0X0( ) ;
         }
         bGXsfl_22_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0X2( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"gxhash_CARRINHOCOMPRASID"+"_"+sGXsfl_22_idx, GetSecureSignedToken( sPrefix+sGXsfl_22_idx, context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9"), context));
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
         /* Using cursor H000X5 */
         pr_default.execute(1, new Object[] {AV6ProdutoId});
         GRID_nRecordCount = H000X5_AGRID_nRecordCount[0];
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6ProdutoId, AV12Update, AV13Delete, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6ProdutoId, AV12Update, AV13Delete, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6ProdutoId, AV12Update, AV13Delete, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6ProdutoId, AV12Update, AV13Delete, sPrefix) ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV6ProdutoId, AV12Update, AV13Delete, sPrefix) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV17Pgmname = "ProdutoProdutosWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         AssignProp(sPrefix, false, edtavUpdate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUpdate_Enabled), 5, 0), !bGXsfl_22_Refreshing);
         edtavDelete_Enabled = 0;
         AssignProp(sPrefix, false, edtavDelete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDelete_Enabled), 5, 0), !bGXsfl_22_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0X0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E120X2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_22 = (int)(context.localUtil.CToN( cgiGet( sPrefix+"nRC_GXsfl_22"), ".", ","));
            wcpOAV6ProdutoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6ProdutoId"), ".", ","));
            GRID_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nFirstRecordOnPage"), ".", ","));
            GRID_nEOF = (short)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_nEOF"), ".", ","));
            subGrid_Rows = (int)(context.localUtil.CToN( cgiGet( sPrefix+"GRID_Rows"), ".", ","));
            GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E120X2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV17Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV17Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, sPrefix+"GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         AV12Update = "Update";
         AssignAttri(sPrefix, false, edtavUpdate_Internalname, AV12Update);
         AV13Delete = "Delete";
         AssignAttri(sPrefix, false, edtavDelete_Internalname, AV13Delete);
         edtProdutoId_Visible = 0;
         AssignProp(sPrefix, false, edtProdutoId_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtProdutoId_Visible), 5, 0), true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      private void E130X2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         edtavUpdate_Link = formatLink("carrinhocompras.aspx", new object[] {UrlEncode(StringUtil.RTrim("UPD")),UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0))}, new string[] {"Mode","CarrinhoComprasId"}) ;
         edtavDelete_Link = formatLink("carrinhocompras.aspx", new object[] {UrlEncode(StringUtil.RTrim("DLT")),UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0))}, new string[] {"Mode","CarrinhoComprasId"}) ;
         edtCarrinhoComprasData_Link = formatLink("viewcarrinhocompras.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0)),UrlEncode(StringUtil.RTrim(""))}, new string[] {"CarrinhoComprasId","TabCode"}) ;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 22;
         }
         sendrow_222( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_22_Refreshing )
         {
            DoAjaxLoad(22, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E110X2( )
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
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10TrnContext.gxTpr_Callerobject = AV17Pgmname;
         AV10TrnContext.gxTpr_Callerondelete = true;
         AV10TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV10TrnContext.gxTpr_Transactionname = "CarrinhoCompras";
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV11TrnContextAtt.gxTpr_Attributename = "ProdutoId";
         AV11TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ProdutoId), 4, 0);
         AV10TrnContext.gxTpr_Attributes.Add(AV11TrnContextAtt, 0);
         AV7Session.Set("TrnContext", AV10TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6ProdutoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "AV6ProdutoId", StringUtil.LTrimStr( (decimal)(AV6ProdutoId), 4, 0));
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
         PA0X2( ) ;
         WS0X2( ) ;
         WE0X2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      public override void componentbind( Object[] obj )
      {
         if ( IsUrlCreated( ) )
         {
            return  ;
         }
         sCtrlAV6ProdutoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0X2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "produtoprodutoswc", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0X2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            AV6ProdutoId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "AV6ProdutoId", StringUtil.LTrimStr( (decimal)(AV6ProdutoId), 4, 0));
         }
         wcpOAV6ProdutoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOAV6ProdutoId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( AV6ProdutoId != wcpOAV6ProdutoId ) ) )
         {
            setjustcreated();
         }
         wcpOAV6ProdutoId = AV6ProdutoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlAV6ProdutoId = cgiGet( sPrefix+"AV6ProdutoId_CTRL");
         if ( StringUtil.Len( sCtrlAV6ProdutoId) > 0 )
         {
            AV6ProdutoId = (short)(context.localUtil.CToN( cgiGet( sCtrlAV6ProdutoId), ".", ","));
            AssignAttri(sPrefix, false, "AV6ProdutoId", StringUtil.LTrimStr( (decimal)(AV6ProdutoId), 4, 0));
         }
         else
         {
            AV6ProdutoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"AV6ProdutoId_PARM"), ".", ","));
         }
      }

      public override void componentprocess( string sPPrefix ,
                                             string sPSFPrefix ,
                                             string sCompEvt )
      {
         sCompPrefix = sPPrefix;
         sSFPrefix = sPSFPrefix;
         sPrefix = sCompPrefix + sSFPrefix;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         INITWEB( ) ;
         nDraw = 0;
         PA0X2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0X2( ) ;
         if ( isFullAjaxMode( ) )
         {
            componentdraw();
         }
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override void componentstart( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
      }

      protected void WCStart( )
      {
         nDraw = 1;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WS0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"AV6ProdutoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6ProdutoId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlAV6ProdutoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"AV6ProdutoId_CTRL", StringUtil.RTrim( sCtrlAV6ProdutoId));
         }
      }

      public override void componentdraw( )
      {
         if ( nDoneStart == 0 )
         {
            WCStart( ) ;
         }
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         WCParametersSet( ) ;
         WE0X2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      public override string getstring( string sGXControl )
      {
         string sCtrlName;
         if ( StringUtil.StrCmp(StringUtil.Substring( sGXControl, 1, 1), "&") == 0 )
         {
            sCtrlName = StringUtil.Substring( sGXControl, 2, StringUtil.Len( sGXControl)-1);
         }
         else
         {
            sCtrlName = sGXControl;
         }
         return cgiGet( sPrefix+"v"+StringUtil.Upper( sCtrlName)) ;
      }

      public override void componentjscripts( )
      {
         include_jscripts( ) ;
      }

      public override void componentthemes( )
      {
         define_styles( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20258291651387", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         CloseStyles();
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("produtoprodutoswc.js", "?20258291651387", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_222( )
      {
         edtCarrinhoComprasId_Internalname = sPrefix+"CARRINHOCOMPRASID_"+sGXsfl_22_idx;
         edtCarrinhoComprasData_Internalname = sPrefix+"CARRINHOCOMPRASDATA_"+sGXsfl_22_idx;
         edtClienteCarrinhoComprasId_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASID_"+sGXsfl_22_idx;
         edtClienteCarrinhoComprasNome_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASNOME_"+sGXsfl_22_idx;
         edtClienteCarrinhoComprasEndereco_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASENDERECO_"+sGXsfl_22_idx;
         edtClienteCarrinhoComprasPaisId_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASPAISID_"+sGXsfl_22_idx;
         edtClienteCarrinhoComprasPaisNome_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASPAISNOME_"+sGXsfl_22_idx;
         edtCarrinhoComprasPrecoTotal_Internalname = sPrefix+"CARRINHOCOMPRASPRECOTOTAL_"+sGXsfl_22_idx;
         edtCarrinhoComprasDataEntrega_Internalname = sPrefix+"CARRINHOCOMPRASDATAENTREGA_"+sGXsfl_22_idx;
         edtCarrinhoComprasPontos_Internalname = sPrefix+"CARRINHOCOMPRASPONTOS_"+sGXsfl_22_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_22_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_22_idx;
      }

      protected void SubsflControlProps_fel_222( )
      {
         edtCarrinhoComprasId_Internalname = sPrefix+"CARRINHOCOMPRASID_"+sGXsfl_22_fel_idx;
         edtCarrinhoComprasData_Internalname = sPrefix+"CARRINHOCOMPRASDATA_"+sGXsfl_22_fel_idx;
         edtClienteCarrinhoComprasId_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASID_"+sGXsfl_22_fel_idx;
         edtClienteCarrinhoComprasNome_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASNOME_"+sGXsfl_22_fel_idx;
         edtClienteCarrinhoComprasEndereco_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASENDERECO_"+sGXsfl_22_fel_idx;
         edtClienteCarrinhoComprasPaisId_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASPAISID_"+sGXsfl_22_fel_idx;
         edtClienteCarrinhoComprasPaisNome_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASPAISNOME_"+sGXsfl_22_fel_idx;
         edtCarrinhoComprasPrecoTotal_Internalname = sPrefix+"CARRINHOCOMPRASPRECOTOTAL_"+sGXsfl_22_fel_idx;
         edtCarrinhoComprasDataEntrega_Internalname = sPrefix+"CARRINHOCOMPRASDATAENTREGA_"+sGXsfl_22_fel_idx;
         edtCarrinhoComprasPontos_Internalname = sPrefix+"CARRINHOCOMPRASPONTOS_"+sGXsfl_22_fel_idx;
         edtavUpdate_Internalname = sPrefix+"vUPDATE_"+sGXsfl_22_fel_idx;
         edtavDelete_Internalname = sPrefix+"vDELETE_"+sGXsfl_22_fel_idx;
      }

      protected void sendrow_222( )
      {
         SubsflControlProps_222( ) ;
         WB0X0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_22_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_22_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"ViewGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_22_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "attribute-description";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasData_Internalname,context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"),context.localUtil.Format( A53CarrinhoComprasData, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtCarrinhoComprasData_Link,(string)"",(string)"",(string)"",(string)edtCarrinhoComprasData_Jsonclick,(short)0,(string)"attribute-description",(string)"",(string)ROClassString,(string)"column",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A54ClienteCarrinhoComprasId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A54ClienteCarrinhoComprasId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasNome_Internalname,(string)A55ClienteCarrinhoComprasNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasEndereco_Internalname,(string)A56ClienteCarrinhoComprasEndereco,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'","http://maps.google.com/maps?q="+GXUtil.UrlEncode( A56ClienteCarrinhoComprasEndereco),(string)"_blank",(string)"",(string)"",(string)edtClienteCarrinhoComprasEndereco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)1024,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Address",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasPaisId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A57ClienteCarrinhoComprasPaisId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasPaisId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteCarrinhoComprasPaisNome_Internalname,(string)A58ClienteCarrinhoComprasPaisNome,(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteCarrinhoComprasPaisNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasPrecoTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( A62CarrinhoComprasPrecoTotal, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A62CarrinhoComprasPrecoTotal, "ZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasPrecoTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasDataEntrega_Internalname,context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"),context.localUtil.Format( A63CarrinhoComprasDataEntrega, "99/99/99"),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasDataEntrega_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCarrinhoComprasPontos_Internalname,StringUtil.LTrim( StringUtil.NToC( A65CarrinhoComprasPontos, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A65CarrinhoComprasPontos, "ZZZZZZ9.99")),(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCarrinhoComprasPontos_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"column WWOptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavUpdate_Internalname,StringUtil.RTrim( AV12Update),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavUpdate_Link,(string)"",(string)"",(string)"",(string)edtavUpdate_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavUpdate_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "TextActionAttribute TextLikeLink";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDelete_Internalname,StringUtil.RTrim( AV13Delete),(string)"",(string)"",(string)"'"+sPrefix+"'"+",false,"+"'"+""+"'",(string)edtavDelete_Link,(string)"",(string)"",(string)"",(string)edtavDelete_Jsonclick,(short)0,(string)"TextActionAttribute TextLikeLink",(string)"",(string)ROClassString,(string)"WWTextActionColumn",(string)"",(short)-1,(int)edtavDelete_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)22,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            send_integrity_lvl_hashes0X2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_22_idx = ((subGrid_Islastpage==1)&&(nGXsfl_22_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_22_idx+1);
            sGXsfl_22_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_22_idx), 4, 0), 4, "0");
            SubsflControlProps_222( ) ;
         }
         /* End function sendrow_222 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl22( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+sPrefix+"GridContainer"+"DivS\" data-gxgridid=\"22\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "ViewGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "compras") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"attribute-description"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Data") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cliente") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Endereço") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
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
            GridContainer.AddObjectProperty("Class", "ViewGrid");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", sPrefix);
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
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV12Update));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavUpdate_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtavUpdate_Link));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", StringUtil.RTrim( AV13Delete));
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
         bttBtninsert_Internalname = sPrefix+"BTNINSERT";
         divTabletop_Internalname = sPrefix+"TABLETOP";
         edtCarrinhoComprasId_Internalname = sPrefix+"CARRINHOCOMPRASID";
         edtCarrinhoComprasData_Internalname = sPrefix+"CARRINHOCOMPRASDATA";
         edtClienteCarrinhoComprasId_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASID";
         edtClienteCarrinhoComprasNome_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASNOME";
         edtClienteCarrinhoComprasEndereco_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASENDERECO";
         edtClienteCarrinhoComprasPaisId_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASPAISID";
         edtClienteCarrinhoComprasPaisNome_Internalname = sPrefix+"CLIENTECARRINHOCOMPRASPAISNOME";
         edtCarrinhoComprasPrecoTotal_Internalname = sPrefix+"CARRINHOCOMPRASPRECOTOTAL";
         edtCarrinhoComprasDataEntrega_Internalname = sPrefix+"CARRINHOCOMPRASDATAENTREGA";
         edtCarrinhoComprasPontos_Internalname = sPrefix+"CARRINHOCOMPRASPONTOS";
         edtavUpdate_Internalname = sPrefix+"vUPDATE";
         edtavDelete_Internalname = sPrefix+"vDELETE";
         divGridcontainer_Internalname = sPrefix+"GRIDCONTAINER";
         divGridtable_Internalname = sPrefix+"GRIDTABLE";
         divGridcell_Internalname = sPrefix+"GRIDCELL";
         edtProdutoId_Internalname = sPrefix+"PRODUTOID";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
         subGrid_Internalname = sPrefix+"GRID";
      }

      public override void initialize_properties( )
      {
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.SetDefaultTheme("LojaAnnaLaisa");
         }
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
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
         subGrid_Class = "ViewGrid";
         subGrid_Backcolorstyle = 0;
         edtProdutoId_Jsonclick = "";
         edtProdutoId_Enabled = 0;
         edtProdutoId_Visible = 1;
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            if ( context.isSpaRequest( ) )
            {
               enableJsOutput();
            }
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6ProdutoId',fld:'vPRODUTOID',pic:'ZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID.LOAD","{handler:'E130X2',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtavUpdate_Link',ctrl:'vUPDATE',prop:'Link'},{av:'edtavDelete_Link',ctrl:'vDELETE',prop:'Link'},{av:'edtCarrinhoComprasData_Link',ctrl:'CARRINHOCOMPRASDATA',prop:'Link'}]}");
         setEventMetadata("'DOINSERT'","{handler:'E110X2',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6ProdutoId',fld:'vPRODUTOID',pic:'ZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6ProdutoId',fld:'vPRODUTOID',pic:'ZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6ProdutoId',fld:'vPRODUTOID',pic:'ZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV6ProdutoId',fld:'vPRODUTOID',pic:'ZZZ9'},{av:'AV12Update',fld:'vUPDATE',pic:''},{av:'AV13Delete',fld:'vDELETE',pic:''},{av:'sPrefix'}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[]}");
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
         sPrefix = "";
         AV12Update = "";
         AV13Delete = "";
         AV17Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A53CarrinhoComprasData = DateTime.MinValue;
         A55ClienteCarrinhoComprasNome = "";
         A56ClienteCarrinhoComprasEndereco = "";
         A58ClienteCarrinhoComprasPaisNome = "";
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         scmdbuf = "";
         H000X3_A19ProdutoId = new short[1] ;
         H000X3_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         H000X3_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         H000X3_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         H000X3_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         H000X3_A54ClienteCarrinhoComprasId = new short[1] ;
         H000X3_A52CarrinhoComprasId = new short[1] ;
         H000X3_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         H000X3_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         H000X3_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         H000X5_AGRID_nRecordCount = new long[1] ;
         GridRow = new GXWebRow();
         AV10TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV8HTTPRequest = new GxHttpRequest( context);
         AV11TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV7Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlAV6ProdutoId = "";
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produtoprodutoswc__default(),
            new Object[][] {
                new Object[] {
               H000X3_A19ProdutoId, H000X3_A58ClienteCarrinhoComprasPaisNome, H000X3_A57ClienteCarrinhoComprasPaisId, H000X3_A56ClienteCarrinhoComprasEndereco, H000X3_A55ClienteCarrinhoComprasNome, H000X3_A54ClienteCarrinhoComprasId, H000X3_A52CarrinhoComprasId, H000X3_A53CarrinhoComprasData, H000X3_A62CarrinhoComprasPrecoTotal, H000X3_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               H000X5_AGRID_nRecordCount
               }
            }
         );
         AV17Pgmname = "ProdutoProdutosWC";
         /* GeneXus formulas. */
         AV17Pgmname = "ProdutoProdutosWC";
         context.Gx_err = 0;
         edtavUpdate_Enabled = 0;
         edtavDelete_Enabled = 0;
      }

      private short AV6ProdutoId ;
      private short wcpOAV6ProdutoId ;
      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A19ProdutoId ;
      private short nDraw ;
      private short nDoneStart ;
      private short A52CarrinhoComprasId ;
      private short A54ClienteCarrinhoComprasId ;
      private short A57ClienteCarrinhoComprasPaisId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_22 ;
      private int subGrid_Rows ;
      private int nGXsfl_22_idx=1 ;
      private int edtavUpdate_Enabled ;
      private int edtavDelete_Enabled ;
      private int edtProdutoId_Enabled ;
      private int edtProdutoId_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
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
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string sGXsfl_22_idx="0001" ;
      private string AV12Update ;
      private string AV13Delete ;
      private string AV17Pgmname ;
      private string edtavUpdate_Internalname ;
      private string edtavDelete_Internalname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string divGridcell_Internalname ;
      private string divGridtable_Internalname ;
      private string divTabletop_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string divGridcontainer_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string edtProdutoId_Internalname ;
      private string edtProdutoId_Jsonclick ;
      private string sXEvt ;
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
      private string scmdbuf ;
      private string edtavUpdate_Link ;
      private string edtavDelete_Link ;
      private string edtCarrinhoComprasData_Link ;
      private string sCtrlAV6ProdutoId ;
      private string sGXsfl_22_fel_idx="0001" ;
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
      private DateTime A53CarrinhoComprasData ;
      private DateTime A63CarrinhoComprasDataEntrega ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool bGXsfl_22_Refreshing=false ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n62CarrinhoComprasPrecoTotal ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A55ClienteCarrinhoComprasNome ;
      private string A56ClienteCarrinhoComprasEndereco ;
      private string A58ClienteCarrinhoComprasPaisNome ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000X3_A19ProdutoId ;
      private string[] H000X3_A58ClienteCarrinhoComprasPaisNome ;
      private short[] H000X3_A57ClienteCarrinhoComprasPaisId ;
      private string[] H000X3_A56ClienteCarrinhoComprasEndereco ;
      private string[] H000X3_A55ClienteCarrinhoComprasNome ;
      private short[] H000X3_A54ClienteCarrinhoComprasId ;
      private short[] H000X3_A52CarrinhoComprasId ;
      private DateTime[] H000X3_A53CarrinhoComprasData ;
      private decimal[] H000X3_A62CarrinhoComprasPrecoTotal ;
      private bool[] H000X3_n62CarrinhoComprasPrecoTotal ;
      private long[] H000X5_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private IGxSession AV7Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV10TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV11TrnContextAtt ;
   }

   public class produtoprodutoswc__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH000X3;
          prmH000X3 = new Object[] {
          new ParDef("@AV6ProdutoId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000X5;
          prmH000X5 = new Object[] {
          new ParDef("@AV6ProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000X3", "SELECT T1.[ProdutoId], T4.[PaisNome] AS ClienteCarrinhoComprasPaisNome, T3.[PaisClienteId] AS ClienteCarrinhoComprasPaisId, T3.[ClienteEndereco] AS ClienteCarrinhoComprasEndereco, T3.[ClienteNome] AS ClienteCarrinhoComprasNome, T2.[ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId, T1.[CarrinhoComprasId], T2.[CarrinhoComprasData], COALESCE( T5.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (((([CarrinhoComprasProdutos] T1 INNER JOIN [CarrinhoCompras] T2 ON T2.[CarrinhoComprasId] = T1.[CarrinhoComprasId]) INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisClienteId]) LEFT JOIN (SELECT SUM(CASE  WHEN T8.[CategoriaNome] = 'Joalheria' THEN ( T6.[CarrinhoComprasProdutosQuantid] * CAST(T7.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T8.[CategoriaNome] = 'Entreterimento' THEN ( T6.[CarrinhoComprasProdutosQuantid] * CAST(T7.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T6.[CarrinhoComprasProdutosQuantid] * CAST(T7.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T6.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T6 INNER JOIN [Produto] T7 ON T7.[ProdutoId] = T6.[ProdutoId]) INNER JOIN [Categoria] T8 ON T8.[CategoriaId] = T7.[CategoriaProdutoId]) GROUP BY T6.[CarrinhoComprasId] ) T5 ON T5.[CarrinhoComprasId] = T1.[CarrinhoComprasId]) WHERE T1.[ProdutoId] = @AV6ProdutoId ORDER BY T1.[ProdutoId]  OFFSET @GXPagingFrom2 ROWS FETCH NEXT CAST((SELECT CASE WHEN @GXPagingTo2 > 0 THEN @GXPagingTo2 ELSE 1e9 END) AS INTEGER) ROWS ONLY",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X3,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000X5", "SELECT COUNT(*) FROM (((([CarrinhoComprasProdutos] T1 INNER JOIN [CarrinhoCompras] T2 ON T2.[CarrinhoComprasId] = T1.[CarrinhoComprasId]) INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T3.[PaisClienteId]) LEFT JOIN (SELECT SUM(CASE  WHEN T8.[CategoriaNome] = 'Joalheria' THEN ( T6.[CarrinhoComprasProdutosQuantid] * CAST(T7.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T8.[CategoriaNome] = 'Entreterimento' THEN ( T6.[CarrinhoComprasProdutosQuantid] * CAST(T7.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T6.[CarrinhoComprasProdutosQuantid] * CAST(T7.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T6.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T6 INNER JOIN [Produto] T7 ON T7.[ProdutoId] = T6.[ProdutoId]) INNER JOIN [Categoria] T8 ON T8.[CategoriaId] = T7.[CategoriaProdutoId]) GROUP BY T6.[CarrinhoComprasId] ) T5 ON T5.[CarrinhoComprasId] = T1.[CarrinhoComprasId]) WHERE T1.[ProdutoId] = @AV6ProdutoId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000X5,1, GxCacheFrequency.OFF ,true,false )
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
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(8);
                ((decimal[]) buf[8])[0] = rslt.getDecimal(9);
                ((bool[]) buf[9])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
