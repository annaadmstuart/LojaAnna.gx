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
   public class carrinhocomprasgeneral : GXWebComponent
   {
      public carrinhocomprasgeneral( )
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

      public carrinhocomprasgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CarrinhoComprasId )
      {
         this.A52CarrinhoComprasId = aP0_CarrinhoComprasId;
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
               gxfirstwebparm = GetFirstPar( "CarrinhoComprasId");
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
                  A52CarrinhoComprasId = (short)(NumberUtil.Val( GetPar( "CarrinhoComprasId"), "."));
                  AssignAttri(sPrefix, false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A52CarrinhoComprasId});
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
                  gxfirstwebparm = GetFirstPar( "CarrinhoComprasId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "CarrinhoComprasId");
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
            PA0H2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "CarrinhoComprasGeneral";
               context.Gx_err = 0;
               /* Using cursor H000H3 */
               pr_default.execute(0, new Object[] {A52CarrinhoComprasId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A62CarrinhoComprasPrecoTotal = H000H3_A62CarrinhoComprasPrecoTotal[0];
                  n62CarrinhoComprasPrecoTotal = H000H3_n62CarrinhoComprasPrecoTotal[0];
                  AssignAttri(sPrefix, false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               }
               else
               {
                  A62CarrinhoComprasPrecoTotal = 0;
                  n62CarrinhoComprasPrecoTotal = false;
                  AssignAttri(sPrefix, false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               }
               pr_default.close(0);
               if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
               {
                  A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
                  AssignAttri(sPrefix, false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
               }
               else
               {
                  A65CarrinhoComprasPontos = 0;
                  AssignAttri(sPrefix, false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
               }
               WS0H2( ) ;
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
            context.SendWebValue( "Carrinho Compras General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("carrinhocomprasgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A52CarrinhoComprasId,4,0))}, new string[] {"CarrinhoComprasId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA52CarrinhoComprasId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA52CarrinhoComprasId), 4, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm0H2( )
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
         return "CarrinhoComprasGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Carrinho Compras General" ;
      }

      protected void WB0H0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "carrinhocomprasgeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110h1_client"+"'", TempTags, "", 2, "HLP_CarrinhoComprasGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120h1_client"+"'", TempTags, "", 2, "HLP_CarrinhoComprasGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "Right", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAttributestable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCarrinhoComprasId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCarrinhoComprasId_Internalname, "compras", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCarrinhoComprasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9") : context.localUtil.Format( (decimal)(A52CarrinhoComprasId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarrinhoComprasId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCarrinhoComprasData_Internalname, "Data", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtCarrinhoComprasData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasData_Internalname, context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"), context.localUtil.Format( A53CarrinhoComprasData, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasData_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarrinhoComprasData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoComprasGeneral.htm");
            GxWebStd.gx_bitmap( context, edtCarrinhoComprasData_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarrinhoComprasData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasId_Internalname, "Cliente", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A54ClienteCarrinhoComprasId), 4, 0, ".", "")), StringUtil.LTrim( ((edtClienteCarrinhoComprasId_Enabled!=0) ? context.localUtil.Format( (decimal)(A54ClienteCarrinhoComprasId), "ZZZ9") : context.localUtil.Format( (decimal)(A54ClienteCarrinhoComprasId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteCarrinhoComprasId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasNome_Internalname, "Cliente", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasNome_Internalname, A55ClienteCarrinhoComprasNome, StringUtil.RTrim( context.localUtil.Format( A55ClienteCarrinhoComprasNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteCarrinhoComprasNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasEndereco_Internalname, "Endereço", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtClienteCarrinhoComprasEndereco_Internalname, A56ClienteCarrinhoComprasEndereco, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A56ClienteCarrinhoComprasEndereco), "", 0, 1, edtClienteCarrinhoComprasEndereco_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasPaisId_Internalname, "País", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasPaisId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0, ".", "")), StringUtil.LTrim( ((edtClienteCarrinhoComprasPaisId_Enabled!=0) ? context.localUtil.Format( (decimal)(A57ClienteCarrinhoComprasPaisId), "ZZZ9") : context.localUtil.Format( (decimal)(A57ClienteCarrinhoComprasPaisId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasPaisId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteCarrinhoComprasPaisId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteCarrinhoComprasPaisNome_Internalname, "País", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteCarrinhoComprasPaisNome_Internalname, A58ClienteCarrinhoComprasPaisNome, StringUtil.RTrim( context.localUtil.Format( A58ClienteCarrinhoComprasPaisNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCarrinhoComprasPaisNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteCarrinhoComprasPaisNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCarrinhoComprasPrecoTotal_Internalname, "total", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasPrecoTotal_Internalname, StringUtil.LTrim( StringUtil.NToC( A62CarrinhoComprasPrecoTotal, 10, 2, ".", "")), StringUtil.LTrim( ((edtCarrinhoComprasPrecoTotal_Enabled!=0) ? context.localUtil.Format( A62CarrinhoComprasPrecoTotal, "ZZZZZZ9.99") : context.localUtil.Format( A62CarrinhoComprasPrecoTotal, "ZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasPrecoTotal_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarrinhoComprasPrecoTotal_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCarrinhoComprasDataEntrega_Internalname, "de entrega", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtCarrinhoComprasDataEntrega_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasDataEntrega_Internalname, context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"), context.localUtil.Format( A63CarrinhoComprasDataEntrega, "99/99/99"), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasDataEntrega_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarrinhoComprasDataEntrega_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoComprasGeneral.htm");
            GxWebStd.gx_bitmap( context, edtCarrinhoComprasDataEntrega_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtCarrinhoComprasDataEntrega_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_CarrinhoComprasGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCarrinhoComprasPontos_Internalname, "Compras Pontos", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCarrinhoComprasPontos_Internalname, StringUtil.LTrim( StringUtil.NToC( A65CarrinhoComprasPontos, 10, 2, ".", "")), StringUtil.LTrim( ((edtCarrinhoComprasPontos_Enabled!=0) ? context.localUtil.Format( A65CarrinhoComprasPontos, "ZZZZZZ9.99") : context.localUtil.Format( A65CarrinhoComprasPontos, "ZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCarrinhoComprasPontos_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCarrinhoComprasPontos_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CarrinhoComprasGeneral.htm");
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
         wbLoad = true;
      }

      protected void START0H2( )
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
               Form.Meta.addItem("description", "Carrinho Compras General", 0) ;
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
               STRUP0H0( ) ;
            }
         }
      }

      protected void WS0H2( )
      {
         START0H2( ) ;
         EVT0H2( ) ;
      }

      protected void EVT0H2( )
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
                                 STRUP0H0( ) ;
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
                                 STRUP0H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0H0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140H2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0H0( ) ;
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
                                 STRUP0H0( ) ;
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

      protected void WE0H2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0H2( ) ;
            }
         }
      }

      protected void PA0H2( )
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
         RF0H2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "CarrinhoComprasGeneral";
         context.Gx_err = 0;
      }

      protected void RF0H2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000H5 */
            pr_default.execute(1, new Object[] {A52CarrinhoComprasId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A58ClienteCarrinhoComprasPaisNome = H000H5_A58ClienteCarrinhoComprasPaisNome[0];
               AssignAttri(sPrefix, false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
               A57ClienteCarrinhoComprasPaisId = H000H5_A57ClienteCarrinhoComprasPaisId[0];
               AssignAttri(sPrefix, false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
               A56ClienteCarrinhoComprasEndereco = H000H5_A56ClienteCarrinhoComprasEndereco[0];
               AssignAttri(sPrefix, false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
               A55ClienteCarrinhoComprasNome = H000H5_A55ClienteCarrinhoComprasNome[0];
               AssignAttri(sPrefix, false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
               A54ClienteCarrinhoComprasId = H000H5_A54ClienteCarrinhoComprasId[0];
               AssignAttri(sPrefix, false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
               A53CarrinhoComprasData = H000H5_A53CarrinhoComprasData[0];
               AssignAttri(sPrefix, false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
               A62CarrinhoComprasPrecoTotal = H000H5_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = H000H5_n62CarrinhoComprasPrecoTotal[0];
               AssignAttri(sPrefix, false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               A57ClienteCarrinhoComprasPaisId = H000H5_A57ClienteCarrinhoComprasPaisId[0];
               AssignAttri(sPrefix, false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
               A56ClienteCarrinhoComprasEndereco = H000H5_A56ClienteCarrinhoComprasEndereco[0];
               AssignAttri(sPrefix, false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
               A55ClienteCarrinhoComprasNome = H000H5_A55ClienteCarrinhoComprasNome[0];
               AssignAttri(sPrefix, false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
               A58ClienteCarrinhoComprasPaisNome = H000H5_A58ClienteCarrinhoComprasPaisNome[0];
               AssignAttri(sPrefix, false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
               A62CarrinhoComprasPrecoTotal = H000H5_A62CarrinhoComprasPrecoTotal[0];
               n62CarrinhoComprasPrecoTotal = H000H5_n62CarrinhoComprasPrecoTotal[0];
               AssignAttri(sPrefix, false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
               A63CarrinhoComprasDataEntrega = DateTimeUtil.DAdd( A53CarrinhoComprasData, (5));
               AssignAttri(sPrefix, false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
               /* Execute user event: Load */
               E140H2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB0H0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0H2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "CarrinhoComprasGeneral";
         context.Gx_err = 0;
         /* Using cursor H000H7 */
         pr_default.execute(2, new Object[] {A52CarrinhoComprasId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A62CarrinhoComprasPrecoTotal = H000H7_A62CarrinhoComprasPrecoTotal[0];
            n62CarrinhoComprasPrecoTotal = H000H7_n62CarrinhoComprasPrecoTotal[0];
            AssignAttri(sPrefix, false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         else
         {
            A62CarrinhoComprasPrecoTotal = 0;
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri(sPrefix, false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
         }
         pr_default.close(2);
         if ( ( A62CarrinhoComprasPrecoTotal >= Convert.ToDecimal( 1000 )) )
         {
            A65CarrinhoComprasPontos = (decimal)(A62CarrinhoComprasPrecoTotal*0.05m);
            AssignAttri(sPrefix, false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         else
         {
            A65CarrinhoComprasPontos = 0;
            AssignAttri(sPrefix, false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
         }
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0H0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130H2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA52CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA52CarrinhoComprasId"), ".", ","));
            /* Read variables values. */
            A53CarrinhoComprasData = context.localUtil.CToD( cgiGet( edtCarrinhoComprasData_Internalname), 1);
            AssignAttri(sPrefix, false, "A53CarrinhoComprasData", context.localUtil.Format(A53CarrinhoComprasData, "99/99/99"));
            A54ClienteCarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A54ClienteCarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A54ClienteCarrinhoComprasId), 4, 0));
            A55ClienteCarrinhoComprasNome = cgiGet( edtClienteCarrinhoComprasNome_Internalname);
            AssignAttri(sPrefix, false, "A55ClienteCarrinhoComprasNome", A55ClienteCarrinhoComprasNome);
            A56ClienteCarrinhoComprasEndereco = cgiGet( edtClienteCarrinhoComprasEndereco_Internalname);
            AssignAttri(sPrefix, false, "A56ClienteCarrinhoComprasEndereco", A56ClienteCarrinhoComprasEndereco);
            A57ClienteCarrinhoComprasPaisId = (short)(context.localUtil.CToN( cgiGet( edtClienteCarrinhoComprasPaisId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A57ClienteCarrinhoComprasPaisId", StringUtil.LTrimStr( (decimal)(A57ClienteCarrinhoComprasPaisId), 4, 0));
            A58ClienteCarrinhoComprasPaisNome = cgiGet( edtClienteCarrinhoComprasPaisNome_Internalname);
            AssignAttri(sPrefix, false, "A58ClienteCarrinhoComprasPaisNome", A58ClienteCarrinhoComprasPaisNome);
            A62CarrinhoComprasPrecoTotal = context.localUtil.CToN( cgiGet( edtCarrinhoComprasPrecoTotal_Internalname), ".", ",");
            n62CarrinhoComprasPrecoTotal = false;
            AssignAttri(sPrefix, false, "A62CarrinhoComprasPrecoTotal", StringUtil.LTrimStr( A62CarrinhoComprasPrecoTotal, 10, 2));
            A63CarrinhoComprasDataEntrega = context.localUtil.CToD( cgiGet( edtCarrinhoComprasDataEntrega_Internalname), 1);
            AssignAttri(sPrefix, false, "A63CarrinhoComprasDataEntrega", context.localUtil.Format(A63CarrinhoComprasDataEntrega, "99/99/99"));
            A65CarrinhoComprasPontos = context.localUtil.CToN( cgiGet( edtCarrinhoComprasPontos_Internalname), ".", ",");
            AssignAttri(sPrefix, false, "A65CarrinhoComprasPontos", StringUtil.LTrimStr( A65CarrinhoComprasPontos, 10, 2));
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
         E130H2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130H2( )
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

      protected void E140H2( )
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
         AV7TrnContext.gxTpr_Transactionname = "CarrinhoCompras";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "CarrinhoComprasId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6CarrinhoComprasId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A52CarrinhoComprasId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
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
         PA0H2( ) ;
         WS0H2( ) ;
         WE0H2( ) ;
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
         sCtrlA52CarrinhoComprasId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0H2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "carrinhocomprasgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0H2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A52CarrinhoComprasId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
         }
         wcpOA52CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA52CarrinhoComprasId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A52CarrinhoComprasId != wcpOA52CarrinhoComprasId ) ) )
         {
            setjustcreated();
         }
         wcpOA52CarrinhoComprasId = A52CarrinhoComprasId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA52CarrinhoComprasId = cgiGet( sPrefix+"A52CarrinhoComprasId_CTRL");
         if ( StringUtil.Len( sCtrlA52CarrinhoComprasId) > 0 )
         {
            A52CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( sCtrlA52CarrinhoComprasId), ".", ","));
            AssignAttri(sPrefix, false, "A52CarrinhoComprasId", StringUtil.LTrimStr( (decimal)(A52CarrinhoComprasId), 4, 0));
         }
         else
         {
            A52CarrinhoComprasId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A52CarrinhoComprasId_PARM"), ".", ","));
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
         PA0H2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0H2( ) ;
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
         WS0H2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A52CarrinhoComprasId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A52CarrinhoComprasId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA52CarrinhoComprasId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A52CarrinhoComprasId_CTRL", StringUtil.RTrim( sCtrlA52CarrinhoComprasId));
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
         WE0H2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513798", true, true);
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
         context.AddJavascriptSource("carrinhocomprasgeneral.js", "?202582916513798", false, true);
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
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
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
         edtClienteCarrinhoComprasId_Jsonclick = "";
         edtClienteCarrinhoComprasId_Enabled = 0;
         edtCarrinhoComprasData_Jsonclick = "";
         edtCarrinhoComprasData_Enabled = 0;
         edtCarrinhoComprasId_Jsonclick = "";
         edtCarrinhoComprasId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110H1',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120H1',iparms:[{av:'A52CarrinhoComprasId',fld:'CARRINHOCOMPRASID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
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
         scmdbuf = "";
         H000H3_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         H000H3_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
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
         A53CarrinhoComprasData = DateTime.MinValue;
         A55ClienteCarrinhoComprasNome = "";
         A56ClienteCarrinhoComprasEndereco = "";
         A58ClienteCarrinhoComprasPaisNome = "";
         A63CarrinhoComprasDataEntrega = DateTime.MinValue;
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H000H5_A52CarrinhoComprasId = new short[1] ;
         H000H5_A58ClienteCarrinhoComprasPaisNome = new string[] {""} ;
         H000H5_A57ClienteCarrinhoComprasPaisId = new short[1] ;
         H000H5_A56ClienteCarrinhoComprasEndereco = new string[] {""} ;
         H000H5_A55ClienteCarrinhoComprasNome = new string[] {""} ;
         H000H5_A54ClienteCarrinhoComprasId = new short[1] ;
         H000H5_A53CarrinhoComprasData = new DateTime[] {DateTime.MinValue} ;
         H000H5_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         H000H5_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         H000H7_A62CarrinhoComprasPrecoTotal = new decimal[1] ;
         H000H7_n62CarrinhoComprasPrecoTotal = new bool[] {false} ;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA52CarrinhoComprasId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.carrinhocomprasgeneral__default(),
            new Object[][] {
                new Object[] {
               H000H3_A62CarrinhoComprasPrecoTotal, H000H3_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               H000H5_A52CarrinhoComprasId, H000H5_A58ClienteCarrinhoComprasPaisNome, H000H5_A57ClienteCarrinhoComprasPaisId, H000H5_A56ClienteCarrinhoComprasEndereco, H000H5_A55ClienteCarrinhoComprasNome, H000H5_A54ClienteCarrinhoComprasId, H000H5_A53CarrinhoComprasData, H000H5_A62CarrinhoComprasPrecoTotal, H000H5_n62CarrinhoComprasPrecoTotal
               }
               , new Object[] {
               H000H7_A62CarrinhoComprasPrecoTotal, H000H7_n62CarrinhoComprasPrecoTotal
               }
            }
         );
         AV13Pgmname = "CarrinhoComprasGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "CarrinhoComprasGeneral";
         context.Gx_err = 0;
      }

      private short A52CarrinhoComprasId ;
      private short wcpOA52CarrinhoComprasId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A54ClienteCarrinhoComprasId ;
      private short A57ClienteCarrinhoComprasPaisId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6CarrinhoComprasId ;
      private short nGXWrapped ;
      private int edtCarrinhoComprasId_Enabled ;
      private int edtCarrinhoComprasData_Enabled ;
      private int edtClienteCarrinhoComprasId_Enabled ;
      private int edtClienteCarrinhoComprasNome_Enabled ;
      private int edtClienteCarrinhoComprasEndereco_Enabled ;
      private int edtClienteCarrinhoComprasPaisId_Enabled ;
      private int edtClienteCarrinhoComprasPaisNome_Enabled ;
      private int edtCarrinhoComprasPrecoTotal_Enabled ;
      private int edtCarrinhoComprasDataEntrega_Enabled ;
      private int edtCarrinhoComprasPontos_Enabled ;
      private int idxLst ;
      private decimal A62CarrinhoComprasPrecoTotal ;
      private decimal A65CarrinhoComprasPontos ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sPrefix ;
      private string sCompPrefix ;
      private string sSFPrefix ;
      private string AV13Pgmname ;
      private string scmdbuf ;
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
      private string edtCarrinhoComprasId_Internalname ;
      private string edtCarrinhoComprasId_Jsonclick ;
      private string edtCarrinhoComprasData_Internalname ;
      private string edtCarrinhoComprasData_Jsonclick ;
      private string edtClienteCarrinhoComprasId_Internalname ;
      private string edtClienteCarrinhoComprasId_Jsonclick ;
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
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA52CarrinhoComprasId ;
      private DateTime A53CarrinhoComprasData ;
      private DateTime A63CarrinhoComprasDataEntrega ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n62CarrinhoComprasPrecoTotal ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A55ClienteCarrinhoComprasNome ;
      private string A56ClienteCarrinhoComprasEndereco ;
      private string A58ClienteCarrinhoComprasPaisNome ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H000H3_A62CarrinhoComprasPrecoTotal ;
      private bool[] H000H3_n62CarrinhoComprasPrecoTotal ;
      private short[] H000H5_A52CarrinhoComprasId ;
      private string[] H000H5_A58ClienteCarrinhoComprasPaisNome ;
      private short[] H000H5_A57ClienteCarrinhoComprasPaisId ;
      private string[] H000H5_A56ClienteCarrinhoComprasEndereco ;
      private string[] H000H5_A55ClienteCarrinhoComprasNome ;
      private short[] H000H5_A54ClienteCarrinhoComprasId ;
      private DateTime[] H000H5_A53CarrinhoComprasData ;
      private decimal[] H000H5_A62CarrinhoComprasPrecoTotal ;
      private bool[] H000H5_n62CarrinhoComprasPrecoTotal ;
      private decimal[] H000H7_A62CarrinhoComprasPrecoTotal ;
      private bool[] H000H7_n62CarrinhoComprasPrecoTotal ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class carrinhocomprasgeneral__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH000H3;
          prmH000H3 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmH000H5;
          prmH000H5 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          Object[] prmH000H7;
          prmH000H7 = new Object[] {
          new ParDef("@CarrinhoComprasId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000H3", "SELECT COALESCE( T1.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (SELECT SUM(CASE  WHEN T4.[CategoriaNome] = 'Joalheria' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T4.[CategoriaNome] = 'Entreterimento' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T2.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T2 INNER JOIN [Produto] T3 ON T3.[ProdutoId] = T2.[ProdutoId]) INNER JOIN [Categoria] T4 ON T4.[CategoriaId] = T3.[CategoriaProdutoId]) GROUP BY T2.[CarrinhoComprasId] ) T1 WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H3,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000H5", "SELECT T1.[CarrinhoComprasId], T3.[PaisNome] AS ClienteCarrinhoComprasPaisNome, T2.[PaisClienteId] AS ClienteCarrinhoComprasPaisId, T2.[ClienteEndereco] AS ClienteCarrinhoComprasEndereco, T2.[ClienteNome] AS ClienteCarrinhoComprasNome, T1.[ClienteCarrinhoComprasId] AS ClienteCarrinhoComprasId, T1.[CarrinhoComprasData], COALESCE( T4.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM ((([CarrinhoCompras] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteCarrinhoComprasId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T2.[PaisClienteId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T1.[CarrinhoComprasId]) WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ORDER BY T1.[CarrinhoComprasId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H000H7", "SELECT COALESCE( T1.[CarrinhoComprasPrecoTotal], 0) AS CarrinhoComprasPrecoTotal FROM (SELECT SUM(CASE  WHEN T4.[CategoriaNome] = 'Joalheria' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T4.[CategoriaNome] = 'Entreterimento' THEN ( T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T2.[CarrinhoComprasProdutosQuantid] * CAST(T3.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T2.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T2 INNER JOIN [Produto] T3 ON T3.[ProdutoId] = T2.[ProdutoId]) INNER JOIN [Categoria] T4 ON T4.[CategoriaId] = T3.[CategoriaProdutoId]) GROUP BY T2.[CarrinhoComprasId] ) T1 WHERE T1.[CarrinhoComprasId] = @CarrinhoComprasId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000H7,1, GxCacheFrequency.OFF ,true,true )
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
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((short[]) buf[5])[0] = rslt.getShort(6);
                ((DateTime[]) buf[6])[0] = rslt.getGXDate(7);
                ((decimal[]) buf[7])[0] = rslt.getDecimal(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
