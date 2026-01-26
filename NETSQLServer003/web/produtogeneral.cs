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
   public class produtogeneral : GXWebComponent
   {
      public produtogeneral( )
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

      public produtogeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ProdutoId )
      {
         this.A19ProdutoId = aP0_ProdutoId;
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
                  A19ProdutoId = (short)(NumberUtil.Val( GetPar( "ProdutoId"), "."));
                  AssignAttri(sPrefix, false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A19ProdutoId});
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
            PA0V2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ProdutoGeneral";
               context.Gx_err = 0;
               WS0V2( ) ;
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
            context.SendWebValue( "Produto General") ;
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
         if ( StringUtil.Len( sPrefix) == 0 )
         {
            context.CloseHtmlHeader();
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
            FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
            context.WriteHtmlText( "<body ") ;
            bodyStyle = "";
            if ( nGXWrapped == 0 )
            {
               bodyStyle += "-moz-opacity:0;opacity:0;";
            }
            context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
            context.WriteHtmlText( FormProcess+">") ;
            context.skipLines(1);
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("produtogeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A19ProdutoId,4,0))}, new string[] {"ProdutoId"}) +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp(sPrefix, false, "FORM", "Class", "form-horizontal Form", true);
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA19ProdutoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA19ProdutoId), 4, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0V2( )
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
            context.WriteHtmlTextNl( "</form>") ;
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
         return "ProdutoGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Produto General" ;
      }

      protected void WB0V0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "produtogeneral.aspx");
            }
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", sPrefix, "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 ww__view__actions-cell", "Right", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ww__view__actions", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 8,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-primary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110v1_client"+"'", TempTags, "", 2, "HLP_ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120v1_client"+"'", TempTags, "", 2, "HLP_ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtProdutoId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtProdutoId_Internalname, "Produto", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtProdutoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProdutoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProdutoNome_Internalname, "Produto", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProdutoNome_Internalname, A20ProdutoNome, StringUtil.RTrim( context.localUtil.Format( A20ProdutoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProdutoDescricao_Internalname, "Descrição", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProdutoDescricao_Internalname, A21ProdutoDescricao, StringUtil.RTrim( context.localUtil.Format( A21ProdutoDescricao, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoDescricao_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProdutoDescricao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtProdutoPreco_Internalname, "Preço", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtProdutoPreco_Internalname, StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")), StringUtil.LTrim( ((edtProdutoPreco_Enabled!=0) ? context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99") : context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtProdutoPreco_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtProdutoPreco_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtVendedorProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A24VendedorProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtVendedorProdutoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A24VendedorProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(A24VendedorProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorProdutoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVendedorProdutoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtVendedorProdutoNome_Internalname, A25VendedorProdutoNome, StringUtil.RTrim( context.localUtil.Format( A25VendedorProdutoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVendedorProdutoNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtVendedorProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtPaisProdutoId_Internalname, "País", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A26PaisProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtPaisProdutoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A26PaisProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(A26PaisProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisProdutoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisProdutoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtPaisProdutoNome_Internalname, "País", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisProdutoNome_Internalname, A27PaisProdutoNome, StringUtil.RTrim( context.localUtil.Format( A27PaisProdutoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisProdutoNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtFornecedorProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FornecedorProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtFornecedorProdutoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A28FornecedorProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(A28FornecedorProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFornecedorProdutoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFornecedorProdutoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtFornecedorProdutoNome_Internalname, "Fornecedor", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtFornecedorProdutoNome_Internalname, A29FornecedorProdutoNome, StringUtil.RTrim( context.localUtil.Format( A29FornecedorProdutoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtFornecedorProdutoNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtFornecedorProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtCategoriaProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCategoriaProdutoId_Enabled!=0) ? context.localUtil.Format( (decimal)(A30CategoriaProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(A30CategoriaProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaProdutoId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCategoriaProdutoId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ProdutoGeneral.htm");
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
            GxWebStd.gx_single_line_edit( context, edtCategoriaProdutoNome_Internalname, A31CategoriaProdutoNome, StringUtil.RTrim( context.localUtil.Format( A31CategoriaProdutoNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCategoriaProdutoNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCategoriaProdutoNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divImagestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Imagem", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A23ProdutoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdutoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.PathToRelativeUrl( A23ProdutoImagem));
            GxWebStd.gx_bitmap( context, imgProdutoImagem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A23ProdutoImagem_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, "", "Imagem", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A68VendedorProdutoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40001VendedorProdutoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.PathToRelativeUrl( A68VendedorProdutoImagem));
            GxWebStd.gx_bitmap( context, imgVendedorProdutoImagem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A68VendedorProdutoImagem_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ProdutoGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         wbLoad = true;
      }

      protected void START0V2( )
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
               Form.Meta.addItem("description", "Produto General", 0) ;
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
               STRUP0V0( ) ;
            }
         }
      }

      protected void WS0V2( )
      {
         START0V2( ) ;
         EVT0V2( ) ;
      }

      protected void EVT0V2( )
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
                                 STRUP0V0( ) ;
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140V2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0V0( ) ;
                              }
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
                                 STRUP0V0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                 }
                              }
                              dynload_actions( ) ;
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
      }

      protected void WE0V2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0V2( ) ;
            }
         }
      }

      protected void PA0V2( )
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

      protected void send_integrity_hashes( )
      {
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
         RF0V2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ProdutoGeneral";
         context.Gx_err = 0;
      }

      protected void RF0V2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000V2 */
            pr_default.execute(0, new Object[] {A19ProdutoId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40001VendedorProdutoImagem_GXI = H000V2_A40001VendedorProdutoImagem_GXI[0];
               n40001VendedorProdutoImagem_GXI = H000V2_n40001VendedorProdutoImagem_GXI[0];
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
               A40000ProdutoImagem_GXI = H000V2_A40000ProdutoImagem_GXI[0];
               AssignProp(sPrefix, false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
               AssignProp(sPrefix, false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
               A31CategoriaProdutoNome = H000V2_A31CategoriaProdutoNome[0];
               AssignAttri(sPrefix, false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
               A30CategoriaProdutoId = H000V2_A30CategoriaProdutoId[0];
               AssignAttri(sPrefix, false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
               A29FornecedorProdutoNome = H000V2_A29FornecedorProdutoNome[0];
               AssignAttri(sPrefix, false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
               A28FornecedorProdutoId = H000V2_A28FornecedorProdutoId[0];
               AssignAttri(sPrefix, false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
               A27PaisProdutoNome = H000V2_A27PaisProdutoNome[0];
               AssignAttri(sPrefix, false, "A27PaisProdutoNome", A27PaisProdutoNome);
               A26PaisProdutoId = H000V2_A26PaisProdutoId[0];
               AssignAttri(sPrefix, false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
               A25VendedorProdutoNome = H000V2_A25VendedorProdutoNome[0];
               AssignAttri(sPrefix, false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
               A24VendedorProdutoId = H000V2_A24VendedorProdutoId[0];
               AssignAttri(sPrefix, false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
               A22ProdutoPreco = H000V2_A22ProdutoPreco[0];
               AssignAttri(sPrefix, false, "A22ProdutoPreco", StringUtil.LTrimStr( A22ProdutoPreco, 10, 2));
               A21ProdutoDescricao = H000V2_A21ProdutoDescricao[0];
               AssignAttri(sPrefix, false, "A21ProdutoDescricao", A21ProdutoDescricao);
               A20ProdutoNome = H000V2_A20ProdutoNome[0];
               AssignAttri(sPrefix, false, "A20ProdutoNome", A20ProdutoNome);
               A68VendedorProdutoImagem = H000V2_A68VendedorProdutoImagem[0];
               AssignAttri(sPrefix, false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
               A23ProdutoImagem = H000V2_A23ProdutoImagem[0];
               AssignAttri(sPrefix, false, "A23ProdutoImagem", A23ProdutoImagem);
               AssignProp(sPrefix, false, imgProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), true);
               AssignProp(sPrefix, false, imgProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
               A31CategoriaProdutoNome = H000V2_A31CategoriaProdutoNome[0];
               AssignAttri(sPrefix, false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
               A29FornecedorProdutoNome = H000V2_A29FornecedorProdutoNome[0];
               AssignAttri(sPrefix, false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
               A27PaisProdutoNome = H000V2_A27PaisProdutoNome[0];
               AssignAttri(sPrefix, false, "A27PaisProdutoNome", A27PaisProdutoNome);
               A40001VendedorProdutoImagem_GXI = H000V2_A40001VendedorProdutoImagem_GXI[0];
               n40001VendedorProdutoImagem_GXI = H000V2_n40001VendedorProdutoImagem_GXI[0];
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
               A25VendedorProdutoNome = H000V2_A25VendedorProdutoNome[0];
               AssignAttri(sPrefix, false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
               A68VendedorProdutoImagem = H000V2_A68VendedorProdutoImagem[0];
               AssignAttri(sPrefix, false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A68VendedorProdutoImagem)) ? A40001VendedorProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A68VendedorProdutoImagem))), true);
               AssignProp(sPrefix, false, imgVendedorProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A68VendedorProdutoImagem), true);
               /* Execute user event: Load */
               E140V2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0V0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0V2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ProdutoGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0V0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130V2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA19ProdutoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA19ProdutoId"), ".", ","));
            /* Read variables values. */
            A20ProdutoNome = cgiGet( edtProdutoNome_Internalname);
            AssignAttri(sPrefix, false, "A20ProdutoNome", A20ProdutoNome);
            A21ProdutoDescricao = cgiGet( edtProdutoDescricao_Internalname);
            AssignAttri(sPrefix, false, "A21ProdutoDescricao", A21ProdutoDescricao);
            A22ProdutoPreco = context.localUtil.CToN( cgiGet( edtProdutoPreco_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A22ProdutoPreco", StringUtil.LTrimStr( A22ProdutoPreco, 10, 2));
            A24VendedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtVendedorProdutoId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A24VendedorProdutoId", StringUtil.LTrimStr( (decimal)(A24VendedorProdutoId), 4, 0));
            A25VendedorProdutoNome = cgiGet( edtVendedorProdutoNome_Internalname);
            AssignAttri(sPrefix, false, "A25VendedorProdutoNome", A25VendedorProdutoNome);
            A26PaisProdutoId = (short)(context.localUtil.CToN( cgiGet( edtPaisProdutoId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A26PaisProdutoId", StringUtil.LTrimStr( (decimal)(A26PaisProdutoId), 4, 0));
            A27PaisProdutoNome = cgiGet( edtPaisProdutoNome_Internalname);
            AssignAttri(sPrefix, false, "A27PaisProdutoNome", A27PaisProdutoNome);
            A28FornecedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtFornecedorProdutoId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A28FornecedorProdutoId", StringUtil.LTrimStr( (decimal)(A28FornecedorProdutoId), 4, 0));
            A29FornecedorProdutoNome = cgiGet( edtFornecedorProdutoNome_Internalname);
            AssignAttri(sPrefix, false, "A29FornecedorProdutoNome", A29FornecedorProdutoNome);
            A30CategoriaProdutoId = (short)(context.localUtil.CToN( cgiGet( edtCategoriaProdutoId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A30CategoriaProdutoId", StringUtil.LTrimStr( (decimal)(A30CategoriaProdutoId), 4, 0));
            A31CategoriaProdutoNome = cgiGet( edtCategoriaProdutoNome_Internalname);
            AssignAttri(sPrefix, false, "A31CategoriaProdutoNome", A31CategoriaProdutoNome);
            A23ProdutoImagem = cgiGet( imgProdutoImagem_Internalname);
            AssignAttri(sPrefix, false, "A23ProdutoImagem", A23ProdutoImagem);
            A68VendedorProdutoImagem = cgiGet( imgVendedorProdutoImagem_Internalname);
            AssignAttri(sPrefix, false, "A68VendedorProdutoImagem", A68VendedorProdutoImagem);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E130V2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130V2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140V2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV7TrnContext.gxTpr_Callerobject = AV13Pgmname;
         AV7TrnContext.gxTpr_Callerondelete = false;
         AV7TrnContext.gxTpr_Callerurl = AV10HTTPRequest.ScriptName+"?"+AV10HTTPRequest.QueryString;
         AV7TrnContext.gxTpr_Transactionname = "Produto";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ProdutoId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ProdutoId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A19ProdutoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
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
         PA0V2( ) ;
         WS0V2( ) ;
         WE0V2( ) ;
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
         sCtrlA19ProdutoId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0V2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "produtogeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0V2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A19ProdutoId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
         }
         wcpOA19ProdutoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA19ProdutoId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A19ProdutoId != wcpOA19ProdutoId ) ) )
         {
            setjustcreated();
         }
         wcpOA19ProdutoId = A19ProdutoId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA19ProdutoId = cgiGet( sPrefix+"A19ProdutoId_CTRL");
         if ( StringUtil.Len( sCtrlA19ProdutoId) > 0 )
         {
            A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( sCtrlA19ProdutoId), ".", ","));
            AssignAttri(sPrefix, false, "A19ProdutoId", StringUtil.LTrimStr( (decimal)(A19ProdutoId), 4, 0));
         }
         else
         {
            A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A19ProdutoId_PARM"), ".", ","));
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
         PA0V2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0V2( ) ;
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
         WS0V2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A19ProdutoId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA19ProdutoId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A19ProdutoId_CTRL", StringUtil.RTrim( sCtrlA19ProdutoId));
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
         WE0V2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513688", true, true);
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
         context.AddJavascriptSource("produtogeneral.js", "?202582916513688", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtProdutoId_Internalname = sPrefix+"PRODUTOID";
         edtProdutoNome_Internalname = sPrefix+"PRODUTONOME";
         edtProdutoDescricao_Internalname = sPrefix+"PRODUTODESCRICAO";
         edtProdutoPreco_Internalname = sPrefix+"PRODUTOPRECO";
         edtVendedorProdutoId_Internalname = sPrefix+"VENDEDORPRODUTOID";
         edtVendedorProdutoNome_Internalname = sPrefix+"VENDEDORPRODUTONOME";
         edtPaisProdutoId_Internalname = sPrefix+"PAISPRODUTOID";
         edtPaisProdutoNome_Internalname = sPrefix+"PAISPRODUTONOME";
         edtFornecedorProdutoId_Internalname = sPrefix+"FORNECEDORPRODUTOID";
         edtFornecedorProdutoNome_Internalname = sPrefix+"FORNECEDORPRODUTONOME";
         edtCategoriaProdutoId_Internalname = sPrefix+"CATEGORIAPRODUTOID";
         edtCategoriaProdutoNome_Internalname = sPrefix+"CATEGORIAPRODUTONOME";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgProdutoImagem_Internalname = sPrefix+"PRODUTOIMAGEM";
         imgVendedorProdutoImagem_Internalname = sPrefix+"VENDEDORPRODUTOIMAGEM";
         divImagestable_Internalname = sPrefix+"IMAGESTABLE";
         divMaintable_Internalname = sPrefix+"MAINTABLE";
         Form.Internalname = sPrefix+"FORM";
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
         edtCategoriaProdutoNome_Jsonclick = "";
         edtCategoriaProdutoNome_Enabled = 0;
         edtCategoriaProdutoId_Jsonclick = "";
         edtCategoriaProdutoId_Enabled = 0;
         edtFornecedorProdutoNome_Jsonclick = "";
         edtFornecedorProdutoNome_Enabled = 0;
         edtFornecedorProdutoId_Jsonclick = "";
         edtFornecedorProdutoId_Enabled = 0;
         edtPaisProdutoNome_Jsonclick = "";
         edtPaisProdutoNome_Enabled = 0;
         edtPaisProdutoId_Jsonclick = "";
         edtPaisProdutoId_Enabled = 0;
         edtVendedorProdutoNome_Jsonclick = "";
         edtVendedorProdutoNome_Enabled = 0;
         edtVendedorProdutoId_Jsonclick = "";
         edtVendedorProdutoId_Enabled = 0;
         edtProdutoPreco_Jsonclick = "";
         edtProdutoPreco_Enabled = 0;
         edtProdutoDescricao_Jsonclick = "";
         edtProdutoDescricao_Enabled = 0;
         edtProdutoNome_Jsonclick = "";
         edtProdutoNome_Enabled = 0;
         edtProdutoId_Jsonclick = "";
         edtProdutoId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A19ProdutoId',fld:'PRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110V1',iparms:[{av:'A19ProdutoId',fld:'PRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120V1',iparms:[{av:'A19ProdutoId',fld:'PRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_PRODUTOID","{handler:'Valid_Produtoid',iparms:[]");
         setEventMetadata("VALID_PRODUTOID",",oparms:[]}");
         setEventMetadata("VALID_VENDEDORPRODUTOID","{handler:'Valid_Vendedorprodutoid',iparms:[]");
         setEventMetadata("VALID_VENDEDORPRODUTOID",",oparms:[]}");
         setEventMetadata("VALID_PAISPRODUTOID","{handler:'Valid_Paisprodutoid',iparms:[]");
         setEventMetadata("VALID_PAISPRODUTOID",",oparms:[]}");
         setEventMetadata("VALID_FORNECEDORPRODUTOID","{handler:'Valid_Fornecedorprodutoid',iparms:[]");
         setEventMetadata("VALID_FORNECEDORPRODUTOID",",oparms:[]}");
         setEventMetadata("VALID_CATEGORIAPRODUTOID","{handler:'Valid_Categoriaprodutoid',iparms:[]");
         setEventMetadata("VALID_CATEGORIAPRODUTOID",",oparms:[]}");
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
         AV13Pgmname = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnupdate_Jsonclick = "";
         bttBtndelete_Jsonclick = "";
         A20ProdutoNome = "";
         A21ProdutoDescricao = "";
         A25VendedorProdutoNome = "";
         A27PaisProdutoNome = "";
         A29FornecedorProdutoNome = "";
         A31CategoriaProdutoNome = "";
         A23ProdutoImagem = "";
         A40000ProdutoImagem_GXI = "";
         sImgUrl = "";
         A68VendedorProdutoImagem = "";
         A40001VendedorProdutoImagem_GXI = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000V2_A19ProdutoId = new short[1] ;
         H000V2_A40001VendedorProdutoImagem_GXI = new string[] {""} ;
         H000V2_n40001VendedorProdutoImagem_GXI = new bool[] {false} ;
         H000V2_A40000ProdutoImagem_GXI = new string[] {""} ;
         H000V2_A31CategoriaProdutoNome = new string[] {""} ;
         H000V2_A30CategoriaProdutoId = new short[1] ;
         H000V2_A29FornecedorProdutoNome = new string[] {""} ;
         H000V2_A28FornecedorProdutoId = new short[1] ;
         H000V2_A27PaisProdutoNome = new string[] {""} ;
         H000V2_A26PaisProdutoId = new short[1] ;
         H000V2_A25VendedorProdutoNome = new string[] {""} ;
         H000V2_A24VendedorProdutoId = new short[1] ;
         H000V2_A22ProdutoPreco = new decimal[1] ;
         H000V2_A21ProdutoDescricao = new string[] {""} ;
         H000V2_A20ProdutoNome = new string[] {""} ;
         H000V2_A68VendedorProdutoImagem = new string[] {""} ;
         H000V2_A23ProdutoImagem = new string[] {""} ;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA19ProdutoId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.produtogeneral__default(),
            new Object[][] {
                new Object[] {
               H000V2_A19ProdutoId, H000V2_A40001VendedorProdutoImagem_GXI, H000V2_n40001VendedorProdutoImagem_GXI, H000V2_A40000ProdutoImagem_GXI, H000V2_A31CategoriaProdutoNome, H000V2_A30CategoriaProdutoId, H000V2_A29FornecedorProdutoNome, H000V2_A28FornecedorProdutoId, H000V2_A27PaisProdutoNome, H000V2_A26PaisProdutoId,
               H000V2_A25VendedorProdutoNome, H000V2_A24VendedorProdutoId, H000V2_A22ProdutoPreco, H000V2_A21ProdutoDescricao, H000V2_A20ProdutoNome, H000V2_A68VendedorProdutoImagem, H000V2_A23ProdutoImagem
               }
            }
         );
         AV13Pgmname = "ProdutoGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ProdutoGeneral";
         context.Gx_err = 0;
      }

      private short A19ProdutoId ;
      private short wcpOA19ProdutoId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A24VendedorProdutoId ;
      private short A26PaisProdutoId ;
      private short A28FornecedorProdutoId ;
      private short A30CategoriaProdutoId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6ProdutoId ;
      private short nGXWrapped ;
      private int edtProdutoId_Enabled ;
      private int edtProdutoNome_Enabled ;
      private int edtProdutoDescricao_Enabled ;
      private int edtProdutoPreco_Enabled ;
      private int edtVendedorProdutoId_Enabled ;
      private int edtVendedorProdutoNome_Enabled ;
      private int edtPaisProdutoId_Enabled ;
      private int edtPaisProdutoNome_Enabled ;
      private int edtFornecedorProdutoId_Enabled ;
      private int edtFornecedorProdutoNome_Enabled ;
      private int edtCategoriaProdutoId_Enabled ;
      private int edtCategoriaProdutoNome_Enabled ;
      private int idxLst ;
      private decimal A22ProdutoPreco ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string divMaintable_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnupdate_Internalname ;
      private string bttBtnupdate_Jsonclick ;
      private string bttBtndelete_Internalname ;
      private string bttBtndelete_Jsonclick ;
      private string divAttributestable_Internalname ;
      private string edtProdutoId_Internalname ;
      private string edtProdutoId_Jsonclick ;
      private string edtProdutoNome_Internalname ;
      private string edtProdutoNome_Jsonclick ;
      private string edtProdutoDescricao_Internalname ;
      private string edtProdutoDescricao_Jsonclick ;
      private string edtProdutoPreco_Internalname ;
      private string edtProdutoPreco_Jsonclick ;
      private string edtVendedorProdutoId_Internalname ;
      private string edtVendedorProdutoId_Jsonclick ;
      private string edtVendedorProdutoNome_Internalname ;
      private string edtVendedorProdutoNome_Jsonclick ;
      private string edtPaisProdutoId_Internalname ;
      private string edtPaisProdutoId_Jsonclick ;
      private string edtPaisProdutoNome_Internalname ;
      private string edtPaisProdutoNome_Jsonclick ;
      private string edtFornecedorProdutoId_Internalname ;
      private string edtFornecedorProdutoId_Jsonclick ;
      private string edtFornecedorProdutoNome_Internalname ;
      private string edtFornecedorProdutoNome_Jsonclick ;
      private string edtCategoriaProdutoId_Internalname ;
      private string edtCategoriaProdutoId_Jsonclick ;
      private string edtCategoriaProdutoNome_Internalname ;
      private string edtCategoriaProdutoNome_Jsonclick ;
      private string divImagestable_Internalname ;
      private string sImgUrl ;
      private string imgProdutoImagem_Internalname ;
      private string imgVendedorProdutoImagem_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string sCtrlA19ProdutoId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A23ProdutoImagem_IsBlob ;
      private bool A68VendedorProdutoImagem_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40001VendedorProdutoImagem_GXI ;
      private bool returnInSub ;
      private string A20ProdutoNome ;
      private string A21ProdutoDescricao ;
      private string A25VendedorProdutoNome ;
      private string A27PaisProdutoNome ;
      private string A29FornecedorProdutoNome ;
      private string A31CategoriaProdutoNome ;
      private string A40000ProdutoImagem_GXI ;
      private string A40001VendedorProdutoImagem_GXI ;
      private string A23ProdutoImagem ;
      private string A68VendedorProdutoImagem ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000V2_A19ProdutoId ;
      private string[] H000V2_A40001VendedorProdutoImagem_GXI ;
      private bool[] H000V2_n40001VendedorProdutoImagem_GXI ;
      private string[] H000V2_A40000ProdutoImagem_GXI ;
      private string[] H000V2_A31CategoriaProdutoNome ;
      private short[] H000V2_A30CategoriaProdutoId ;
      private string[] H000V2_A29FornecedorProdutoNome ;
      private short[] H000V2_A28FornecedorProdutoId ;
      private string[] H000V2_A27PaisProdutoNome ;
      private short[] H000V2_A26PaisProdutoId ;
      private string[] H000V2_A25VendedorProdutoNome ;
      private short[] H000V2_A24VendedorProdutoId ;
      private decimal[] H000V2_A22ProdutoPreco ;
      private string[] H000V2_A21ProdutoDescricao ;
      private string[] H000V2_A20ProdutoNome ;
      private string[] H000V2_A68VendedorProdutoImagem ;
      private string[] H000V2_A23ProdutoImagem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class produtogeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000V2;
          prmH000V2 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000V2", "SELECT T1.[ProdutoId], T5.[VendedorFoto_GXI] AS VendedorProdutoImagem_GXI, T1.[ProdutoImagem_GXI], T2.[CategoriaNome] AS CategoriaProdutoNome, T1.[CategoriaProdutoId] AS CategoriaProdutoId, T3.[FornecedorNome] AS FornecedorProdutoNome, T1.[FornecedorProdutoId] AS FornecedorProdutoId, T4.[PaisNome] AS PaisProdutoNome, T1.[PaisProdutoId] AS PaisProdutoId, T5.[VendedorNome] AS VendedorProdutoNome, T1.[VendedorProdutoId] AS VendedorProdutoId, T1.[ProdutoPreco], T1.[ProdutoDescricao], T1.[ProdutoNome], T5.[VendedorFoto] AS VendedorProdutoImagem, T1.[ProdutoImagem] FROM (((([Produto] T1 INNER JOIN [Categoria] T2 ON T2.[CategoriaId] = T1.[CategoriaProdutoId]) INNER JOIN [Fornecedor] T3 ON T3.[FornecedorId] = T1.[FornecedorProdutoId]) INNER JOIN [Pais] T4 ON T4.[PaisId] = T1.[PaisProdutoId]) INNER JOIN [Vendedor] T5 ON T5.[VendedorId] = T1.[VendedorProdutoId]) WHERE T1.[ProdutoId] = @ProdutoId ORDER BY T1.[ProdutoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000V2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((short[]) buf[5])[0] = rslt.getShort(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((short[]) buf[9])[0] = rslt.getShort(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((short[]) buf[11])[0] = rslt.getShort(11);
                ((decimal[]) buf[12])[0] = rslt.getDecimal(12);
                ((string[]) buf[13])[0] = rslt.getVarchar(13);
                ((string[]) buf[14])[0] = rslt.getVarchar(14);
                ((string[]) buf[15])[0] = rslt.getMultimediaFile(15, rslt.getVarchar(2));
                ((string[]) buf[16])[0] = rslt.getMultimediaFile(16, rslt.getVarchar(3));
                return;
       }
    }

 }

}
