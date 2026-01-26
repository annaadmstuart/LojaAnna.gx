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
   public class cartaopontosgeneral : GXWebComponent
   {
      public cartaopontosgeneral( )
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

      public cartaopontosgeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_CartaoPontosId )
      {
         this.A41CartaoPontosId = aP0_CartaoPontosId;
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
               gxfirstwebparm = GetFirstPar( "CartaoPontosId");
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
                  A41CartaoPontosId = (short)(NumberUtil.Val( GetPar( "CartaoPontosId"), "."));
                  AssignAttri(sPrefix, false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A41CartaoPontosId});
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
                  gxfirstwebparm = GetFirstPar( "CartaoPontosId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "CartaoPontosId");
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
            PA1C2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "CartaoPontosGeneral";
               context.Gx_err = 0;
               /* Using cursor H001C4 */
               pr_default.execute(0, new Object[] {A41CartaoPontosId});
               if ( (pr_default.getStatus(0) != 101) )
               {
                  A66CartaoPontosAcumulados = H001C4_A66CartaoPontosAcumulados[0];
                  n66CartaoPontosAcumulados = H001C4_n66CartaoPontosAcumulados[0];
                  AssignAttri(sPrefix, false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
               }
               else
               {
                  A66CartaoPontosAcumulados = 0;
                  n66CartaoPontosAcumulados = false;
                  AssignAttri(sPrefix, false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
               }
               pr_default.close(0);
               WS1C2( ) ;
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
            context.SendWebValue( "Cartao Pontos General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cartaopontosgeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A41CartaoPontosId,4,0))}, new string[] {"CartaoPontosId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA41CartaoPontosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA41CartaoPontosId), 4, 0, ".", "")));
      }

      protected void RenderHtmlCloseForm1C2( )
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
         return "CartaoPontosGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cartao Pontos General" ;
      }

      protected void WB1C0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "cartaopontosgeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e111c1_client"+"'", TempTags, "", 2, "HLP_CartaoPontosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e121c1_client"+"'", TempTags, "", 2, "HLP_CartaoPontosGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCartaoPontosId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCartaoPontosId_Internalname, "de pontos", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCartaoPontosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CartaoPontosId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCartaoPontosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A41CartaoPontosId), "ZZZ9") : context.localUtil.Format( (decimal)(A41CartaoPontosId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCartaoPontosId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CartaoPontosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCartaoPontosDescricao_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCartaoPontosDescricao_Internalname, "Descrição", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCartaoPontosDescricao_Internalname, A42CartaoPontosDescricao, StringUtil.RTrim( context.localUtil.Format( A42CartaoPontosDescricao, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosDescricao_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCartaoPontosDescricao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_CartaoPontosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteCartaoPontosId_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteCartaoPontosId_Internalname, "Cliente", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteCartaoPontosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ClienteCartaoPontosId), 4, 0, ".", "")), StringUtil.LTrim( ((edtClienteCartaoPontosId_Enabled!=0) ? context.localUtil.Format( (decimal)(A50ClienteCartaoPontosId), "ZZZ9") : context.localUtil.Format( (decimal)(A50ClienteCartaoPontosId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCartaoPontosId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteCartaoPontosId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CartaoPontosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteCartaoPontosNome_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtClienteCartaoPontosNome_Internalname, "Cliente", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteCartaoPontosNome_Internalname, A51ClienteCartaoPontosNome, StringUtil.RTrim( context.localUtil.Format( A51ClienteCartaoPontosNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCartaoPontosNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteCartaoPontosNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_CartaoPontosGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCartaoPontosAcumulados_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtCartaoPontosAcumulados_Internalname, "Pontos Acumulados", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCartaoPontosAcumulados_Internalname, StringUtil.LTrim( StringUtil.NToC( A66CartaoPontosAcumulados, 10, 2, ".", "")), StringUtil.LTrim( ((edtCartaoPontosAcumulados_Enabled!=0) ? context.localUtil.Format( A66CartaoPontosAcumulados, "ZZZZZZ9.99") : context.localUtil.Format( A66CartaoPontosAcumulados, "ZZZZZZ9.99"))), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosAcumulados_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCartaoPontosAcumulados_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CartaoPontosGeneral.htm");
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

      protected void START1C2( )
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
               Form.Meta.addItem("description", "Cartao Pontos General", 0) ;
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
               STRUP1C0( ) ;
            }
         }
      }

      protected void WS1C2( )
      {
         START1C2( ) ;
         EVT1C2( ) ;
      }

      protected void EVT1C2( )
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
                                 STRUP1C0( ) ;
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
                                 STRUP1C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E131C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1C0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E141C2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP1C0( ) ;
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
                                 STRUP1C0( ) ;
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

      protected void WE1C2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm1C2( ) ;
            }
         }
      }

      protected void PA1C2( )
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
         RF1C2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "CartaoPontosGeneral";
         context.Gx_err = 0;
      }

      protected void RF1C2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H001C7 */
            pr_default.execute(1, new Object[] {A41CartaoPontosId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A51ClienteCartaoPontosNome = H001C7_A51ClienteCartaoPontosNome[0];
               AssignAttri(sPrefix, false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
               A50ClienteCartaoPontosId = H001C7_A50ClienteCartaoPontosId[0];
               AssignAttri(sPrefix, false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
               A42CartaoPontosDescricao = H001C7_A42CartaoPontosDescricao[0];
               AssignAttri(sPrefix, false, "A42CartaoPontosDescricao", A42CartaoPontosDescricao);
               A66CartaoPontosAcumulados = H001C7_A66CartaoPontosAcumulados[0];
               n66CartaoPontosAcumulados = H001C7_n66CartaoPontosAcumulados[0];
               AssignAttri(sPrefix, false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
               A51ClienteCartaoPontosNome = H001C7_A51ClienteCartaoPontosNome[0];
               AssignAttri(sPrefix, false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
               A66CartaoPontosAcumulados = H001C7_A66CartaoPontosAcumulados[0];
               n66CartaoPontosAcumulados = H001C7_n66CartaoPontosAcumulados[0];
               AssignAttri(sPrefix, false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
               /* Execute user event: Load */
               E141C2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(1);
            WB1C0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1C2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "CartaoPontosGeneral";
         context.Gx_err = 0;
         /* Using cursor H001C10 */
         pr_default.execute(2, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A66CartaoPontosAcumulados = H001C10_A66CartaoPontosAcumulados[0];
            n66CartaoPontosAcumulados = H001C10_n66CartaoPontosAcumulados[0];
            AssignAttri(sPrefix, false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         }
         else
         {
            A66CartaoPontosAcumulados = 0;
            n66CartaoPontosAcumulados = false;
            AssignAttri(sPrefix, false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         }
         pr_default.close(2);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1C0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E131C2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA41CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA41CartaoPontosId"), ".", ","));
            /* Read variables values. */
            A42CartaoPontosDescricao = cgiGet( edtCartaoPontosDescricao_Internalname);
            AssignAttri(sPrefix, false, "A42CartaoPontosDescricao", A42CartaoPontosDescricao);
            A50ClienteCartaoPontosId = (short)(context.localUtil.CToN( cgiGet( edtClienteCartaoPontosId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
            A51ClienteCartaoPontosNome = cgiGet( edtClienteCartaoPontosNome_Internalname);
            AssignAttri(sPrefix, false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
            A66CartaoPontosAcumulados = context.localUtil.CToN( cgiGet( edtCartaoPontosAcumulados_Internalname), ".", ",");
            n66CartaoPontosAcumulados = false;
            AssignAttri(sPrefix, false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
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
         E131C2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E131C2( )
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

      protected void E141C2( )
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
         AV7TrnContext.gxTpr_Transactionname = "CartaoPontos";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "CartaoPontosId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6CartaoPontosId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A41CartaoPontosId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
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
         PA1C2( ) ;
         WS1C2( ) ;
         WE1C2( ) ;
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
         sCtrlA41CartaoPontosId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA1C2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "cartaopontosgeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA1C2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A41CartaoPontosId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
         }
         wcpOA41CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA41CartaoPontosId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A41CartaoPontosId != wcpOA41CartaoPontosId ) ) )
         {
            setjustcreated();
         }
         wcpOA41CartaoPontosId = A41CartaoPontosId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA41CartaoPontosId = cgiGet( sPrefix+"A41CartaoPontosId_CTRL");
         if ( StringUtil.Len( sCtrlA41CartaoPontosId) > 0 )
         {
            A41CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( sCtrlA41CartaoPontosId), ".", ","));
            AssignAttri(sPrefix, false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
         }
         else
         {
            A41CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A41CartaoPontosId_PARM"), ".", ","));
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
         PA1C2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS1C2( ) ;
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
         WS1C2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A41CartaoPontosId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CartaoPontosId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA41CartaoPontosId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A41CartaoPontosId_CTRL", StringUtil.RTrim( sCtrlA41CartaoPontosId));
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
         WE1C2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513694", true, true);
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
         context.AddJavascriptSource("cartaopontosgeneral.js", "?202582916513694", false, true);
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
         edtCartaoPontosId_Internalname = sPrefix+"CARTAOPONTOSID";
         edtCartaoPontosDescricao_Internalname = sPrefix+"CARTAOPONTOSDESCRICAO";
         edtClienteCartaoPontosId_Internalname = sPrefix+"CLIENTECARTAOPONTOSID";
         edtClienteCartaoPontosNome_Internalname = sPrefix+"CLIENTECARTAOPONTOSNOME";
         edtCartaoPontosAcumulados_Internalname = sPrefix+"CARTAOPONTOSACUMULADOS";
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
         edtCartaoPontosAcumulados_Jsonclick = "";
         edtCartaoPontosAcumulados_Enabled = 0;
         edtClienteCartaoPontosNome_Jsonclick = "";
         edtClienteCartaoPontosNome_Enabled = 0;
         edtClienteCartaoPontosId_Jsonclick = "";
         edtClienteCartaoPontosId_Enabled = 0;
         edtCartaoPontosDescricao_Jsonclick = "";
         edtCartaoPontosDescricao_Enabled = 0;
         edtCartaoPontosId_Jsonclick = "";
         edtCartaoPontosId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A41CartaoPontosId',fld:'CARTAOPONTOSID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E111C1',iparms:[{av:'A41CartaoPontosId',fld:'CARTAOPONTOSID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E121C1',iparms:[{av:'A41CartaoPontosId',fld:'CARTAOPONTOSID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_CARTAOPONTOSID","{handler:'Valid_Cartaopontosid',iparms:[]");
         setEventMetadata("VALID_CARTAOPONTOSID",",oparms:[]}");
         setEventMetadata("VALID_CLIENTECARTAOPONTOSID","{handler:'Valid_Clientecartaopontosid',iparms:[]");
         setEventMetadata("VALID_CLIENTECARTAOPONTOSID",",oparms:[]}");
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
         H001C4_A66CartaoPontosAcumulados = new decimal[1] ;
         H001C4_n66CartaoPontosAcumulados = new bool[] {false} ;
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
         A42CartaoPontosDescricao = "";
         A51ClienteCartaoPontosNome = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         H001C7_A51ClienteCartaoPontosNome = new string[] {""} ;
         H001C7_A50ClienteCartaoPontosId = new short[1] ;
         H001C7_A42CartaoPontosDescricao = new string[] {""} ;
         H001C7_A41CartaoPontosId = new short[1] ;
         H001C7_A66CartaoPontosAcumulados = new decimal[1] ;
         H001C7_n66CartaoPontosAcumulados = new bool[] {false} ;
         H001C10_A66CartaoPontosAcumulados = new decimal[1] ;
         H001C10_n66CartaoPontosAcumulados = new bool[] {false} ;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA41CartaoPontosId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cartaopontosgeneral__default(),
            new Object[][] {
                new Object[] {
               H001C4_A66CartaoPontosAcumulados, H001C4_n66CartaoPontosAcumulados
               }
               , new Object[] {
               H001C7_A51ClienteCartaoPontosNome, H001C7_A50ClienteCartaoPontosId, H001C7_A42CartaoPontosDescricao, H001C7_A41CartaoPontosId, H001C7_A66CartaoPontosAcumulados, H001C7_n66CartaoPontosAcumulados
               }
               , new Object[] {
               H001C10_A66CartaoPontosAcumulados, H001C10_n66CartaoPontosAcumulados
               }
            }
         );
         AV13Pgmname = "CartaoPontosGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "CartaoPontosGeneral";
         context.Gx_err = 0;
      }

      private short A41CartaoPontosId ;
      private short wcpOA41CartaoPontosId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A50ClienteCartaoPontosId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6CartaoPontosId ;
      private short nGXWrapped ;
      private int edtCartaoPontosId_Enabled ;
      private int edtCartaoPontosDescricao_Enabled ;
      private int edtClienteCartaoPontosId_Enabled ;
      private int edtClienteCartaoPontosNome_Enabled ;
      private int edtCartaoPontosAcumulados_Enabled ;
      private int idxLst ;
      private decimal A66CartaoPontosAcumulados ;
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
      private string edtCartaoPontosId_Internalname ;
      private string edtCartaoPontosId_Jsonclick ;
      private string edtCartaoPontosDescricao_Internalname ;
      private string edtCartaoPontosDescricao_Jsonclick ;
      private string edtClienteCartaoPontosId_Internalname ;
      private string edtClienteCartaoPontosId_Jsonclick ;
      private string edtClienteCartaoPontosNome_Internalname ;
      private string edtClienteCartaoPontosNome_Jsonclick ;
      private string edtCartaoPontosAcumulados_Internalname ;
      private string edtCartaoPontosAcumulados_Jsonclick ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string sCtrlA41CartaoPontosId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n66CartaoPontosAcumulados ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string A42CartaoPontosDescricao ;
      private string A51ClienteCartaoPontosNome ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] H001C4_A66CartaoPontosAcumulados ;
      private bool[] H001C4_n66CartaoPontosAcumulados ;
      private string[] H001C7_A51ClienteCartaoPontosNome ;
      private short[] H001C7_A50ClienteCartaoPontosId ;
      private string[] H001C7_A42CartaoPontosDescricao ;
      private short[] H001C7_A41CartaoPontosId ;
      private decimal[] H001C7_A66CartaoPontosAcumulados ;
      private bool[] H001C7_n66CartaoPontosAcumulados ;
      private decimal[] H001C10_A66CartaoPontosAcumulados ;
      private bool[] H001C10_n66CartaoPontosAcumulados ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class cartaopontosgeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH001C4;
          prmH001C4 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmH001C7;
          prmH001C7 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmH001C10;
          prmH001C10 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H001C4", "SELECT COALESCE( T1.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (SELECT SUM(CASE  WHEN ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T3.[CartaoPontosClienteId] FROM (([CarrinhoCompras] T2 INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T2.[CarrinhoComprasId]) GROUP BY T3.[CartaoPontosClienteId] ) T1 WHERE T1.[CartaoPontosClienteId] = @CartaoPontosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001C4,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001C7", "SELECT T2.[ClienteNome] AS ClienteCartaoPontosNome, T1.[ClienteCartaoPontosId] AS ClienteCartaoPontosId, T1.[CartaoPontosDescricao], T1.[CartaoPontosId], COALESCE( T3.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (([CartaoPontos] T1 INNER JOIN [Cliente] T2 ON T2.[ClienteId] = T1.[ClienteCartaoPontosId]) LEFT JOIN (SELECT SUM(CASE  WHEN ( COALESCE( T6.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T6.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T5.[CartaoPontosClienteId] FROM (([CarrinhoCompras] T4 INNER JOIN [Cliente] T5 ON T5.[ClienteId] = T4.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T9.[CategoriaNome] = 'Joalheria' THEN ( T7.[CarrinhoComprasProdutosQuantid] * CAST(T8.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T9.[CategoriaNome] = 'Entreterimento' THEN ( T7.[CarrinhoComprasProdutosQuantid] * CAST(T8.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T7.[CarrinhoComprasProdutosQuantid] * CAST(T8.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T7.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T7 INNER JOIN [Produto] T8 ON T8.[ProdutoId] = T7.[ProdutoId]) INNER JOIN [Categoria] T9 ON T9.[CategoriaId] = T8.[CategoriaProdutoId]) GROUP BY T7.[CarrinhoComprasId] ) T6 ON T6.[CarrinhoComprasId] = T4.[CarrinhoComprasId]) GROUP BY T5.[CartaoPontosClienteId] ) T3 ON T3.[CartaoPontosClienteId] = T1.[CartaoPontosId]) WHERE T1.[CartaoPontosId] = @CartaoPontosId ORDER BY T1.[CartaoPontosId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001C7,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H001C10", "SELECT COALESCE( T1.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (SELECT SUM(CASE  WHEN ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T3.[CartaoPontosClienteId] FROM (([CarrinhoCompras] T2 INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T2.[CarrinhoComprasId]) GROUP BY T3.[CartaoPontosClienteId] ) T1 WHERE T1.[CartaoPontosClienteId] = @CartaoPontosId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH001C10,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
       }
    }

 }

}
