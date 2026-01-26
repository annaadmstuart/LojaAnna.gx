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
   public class clientegeneral : GXWebComponent
   {
      public clientegeneral( )
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

      public clientegeneral( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( short aP0_ClienteId )
      {
         this.A43ClienteId = aP0_ClienteId;
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
         chkClienteVIP = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( StringUtil.Len( (string)(sPrefix)) == 0 )
         {
            if ( nGotPars == 0 )
            {
               entryPointCalled = false;
               gxfirstwebparm = GetFirstPar( "ClienteId");
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
                  A43ClienteId = (short)(NumberUtil.Val( GetPar( "ClienteId"), "."));
                  AssignAttri(sPrefix, false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
                  setjustcreated();
                  componentprepare(new Object[] {(string)sCompPrefix,(string)sSFPrefix,(short)A43ClienteId});
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
                  gxfirstwebparm = GetFirstPar( "ClienteId");
               }
               else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
               {
                  if ( ! IsValidAjaxCall( true) )
                  {
                     GxWebError = 1;
                     return  ;
                  }
                  gxfirstwebparm = GetFirstPar( "ClienteId");
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
            PA0N2( ) ;
            if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
            {
               /* GeneXus formulas. */
               AV13Pgmname = "ClienteGeneral";
               context.Gx_err = 0;
               WS0N2( ) ;
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
            context.SendWebValue( "Cliente General") ;
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
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("clientegeneral.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(A43ClienteId,4,0))}, new string[] {"ClienteId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, sPrefix+"wcpOA43ClienteId", StringUtil.LTrim( StringUtil.NToC( (decimal)(wcpOA43ClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, sPrefix+"CARTAOPONTOSACUMULADOS", StringUtil.LTrim( StringUtil.NToC( A66CartaoPontosAcumulados, 10, 2, ".", "")));
      }

      protected void RenderHtmlCloseForm0N2( )
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
         return "ClienteGeneral" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente General" ;
      }

      protected void WB0N0( )
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
               GxWebStd.gx_hidden_field( context, sPrefix+"_CMPPGM", "clientegeneral.aspx");
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
            GxWebStd.gx_button_ctrl( context, bttBtnupdate_Internalname, "", "Update", bttBtnupdate_Jsonclick, 7, "Update", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e110n1_client"+"'", TempTags, "", 2, "HLP_ClienteGeneral.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'" + sPrefix + "',false,'',0)\"";
            ClassString = "Button button-tertiary";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtndelete_Internalname, "", "Delete", bttBtndelete_Jsonclick, 7, "Delete", "", StyleString, ClassString, 1, 1, "standard", "'"+sPrefix+"'"+",false,"+"'"+"e120n1_client"+"'", TempTags, "", 2, "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtClienteId_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")), StringUtil.LTrim( ((edtClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A43ClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(A43ClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteNome_Internalname, "Nome", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteNome_Internalname, A44ClienteNome, StringUtil.RTrim( context.localUtil.Format( A44ClienteNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteEndereco_Internalname, "Endereço", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Multiple line edit */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtClienteEndereco_Internalname, A45ClienteEndereco, "http://maps.google.com/maps?q="+GXUtil.UrlEncode( A45ClienteEndereco), "", 0, 1, edtClienteEndereco_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "1024", -1, 0, "_blank", "", 0, true, "GeneXus\\Address", "'"+sPrefix+"'"+",false,"+"'"+""+"'", 0, "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteTelefone_Internalname, "Telefone", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A46ClienteTelefone);
            }
            GxWebStd.gx_single_line_edit( context, edtClienteTelefone_Internalname, StringUtil.RTrim( A46ClienteTelefone), StringUtil.RTrim( context.localUtil.Format( A46ClienteTelefone, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtClienteTelefone_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteTelefone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "left", true, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtClienteEmail_Internalname, "Email", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtClienteEmail_Internalname, A47ClienteEmail, StringUtil.RTrim( context.localUtil.Format( A47ClienteEmail, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "mailto:"+A47ClienteEmail, "", "", "", edtClienteEmail_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtClienteEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "left", true, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtPaisClienteId_Internalname, "País", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A11PaisClienteId), 4, 0, ".", "")), StringUtil.LTrim( ((edtPaisClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A11PaisClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(A11PaisClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisClienteId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisClienteId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtPaisClienteNome_Internalname, "País", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtPaisClienteNome_Internalname, A12PaisClienteNome, StringUtil.RTrim( context.localUtil.Format( A12PaisClienteNome, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPaisClienteNome_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtPaisClienteNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCartaoPontosClienteId_Internalname, "Cartão", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCartaoPontosClienteId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A48CartaoPontosClienteId), 4, 0, ".", "")), StringUtil.LTrim( ((edtCartaoPontosClienteId_Enabled!=0) ? context.localUtil.Format( (decimal)(A48CartaoPontosClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(A48CartaoPontosClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+"", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosClienteId_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCartaoPontosClienteId_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, edtCartaoPontosClienteDescricao_Internalname, "Cartão", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtCartaoPontosClienteDescricao_Internalname, A49CartaoPontosClienteDescricao, StringUtil.RTrim( context.localUtil.Format( A49CartaoPontosClienteDescricao, "")), "", "'"+sPrefix+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosClienteDescricao_Jsonclick, 0, "ReadonlyAttribute", "", "", "", "", 1, edtCartaoPontosClienteDescricao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_ClienteGeneral.htm");
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
            GxWebStd.gx_label_element( context, chkClienteVIP_Internalname, "VIP", "col-sm-3 ReadonlyAttributeLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
            /* Check box */
            ClassString = "ReadonlyAttribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkClienteVIP_Internalname, StringUtil.BoolToStr( A67ClienteVIP), "", "VIP", 1, chkClienteVIP.Enabled, "true", "", StyleString, ClassString, "", "", "");
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
            GxWebStd.gx_label_element( context, "", "Bandeira", "col-sm-3 ReadonlyAttributeLabel ReadonlyResponsiveImageAttributeLabel", 0, true, "");
            /* Static Bitmap Variable */
            ClassString = "ReadonlyAttribute ReadonlyResponsiveImageAttribute";
            StyleString = "";
            A69PaisClienteBandeira_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PaisClienteBandeira_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.PathToRelativeUrl( A69PaisClienteBandeira));
            GxWebStd.gx_bitmap( context, imgPaisClienteBandeira_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 0, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, A69PaisClienteBandeira_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_ClienteGeneral.htm");
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

      protected void START0N2( )
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
               Form.Meta.addItem("description", "Cliente General", 0) ;
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
               STRUP0N0( ) ;
            }
         }
      }

      protected void WS0N2( )
      {
         START0N2( ) ;
         EVT0N2( ) ;
      }

      protected void EVT0N2( )
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
                                 STRUP0N0( ) ;
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
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E130N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
                              }
                              if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
                              {
                                 context.wbHandled = 1;
                                 if ( ! wbErr )
                                 {
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E140N2 ();
                                 }
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              if ( ( StringUtil.Len( sPrefix) != 0 ) && ( nDoneStart == 0 ) )
                              {
                                 STRUP0N0( ) ;
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
                                 STRUP0N0( ) ;
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

      protected void WE0N2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               RenderHtmlCloseForm0N2( ) ;
            }
         }
      }

      protected void PA0N2( )
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
         A67ClienteVIP = StringUtil.StrToBool( StringUtil.BoolToStr( A67ClienteVIP));
         AssignAttri(sPrefix, false, "A67ClienteVIP", A67ClienteVIP);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF0N2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV13Pgmname = "ClienteGeneral";
         context.Gx_err = 0;
      }

      protected void RF0N2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H000N2 */
            pr_default.execute(0, new Object[] {A43ClienteId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A40000PaisClienteBandeira_GXI = H000N2_A40000PaisClienteBandeira_GXI[0];
               n40000PaisClienteBandeira_GXI = H000N2_n40000PaisClienteBandeira_GXI[0];
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
               A49CartaoPontosClienteDescricao = H000N2_A49CartaoPontosClienteDescricao[0];
               AssignAttri(sPrefix, false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
               A48CartaoPontosClienteId = H000N2_A48CartaoPontosClienteId[0];
               n48CartaoPontosClienteId = H000N2_n48CartaoPontosClienteId[0];
               AssignAttri(sPrefix, false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
               A12PaisClienteNome = H000N2_A12PaisClienteNome[0];
               AssignAttri(sPrefix, false, "A12PaisClienteNome", A12PaisClienteNome);
               A11PaisClienteId = H000N2_A11PaisClienteId[0];
               AssignAttri(sPrefix, false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
               A47ClienteEmail = H000N2_A47ClienteEmail[0];
               AssignAttri(sPrefix, false, "A47ClienteEmail", A47ClienteEmail);
               A46ClienteTelefone = H000N2_A46ClienteTelefone[0];
               AssignAttri(sPrefix, false, "A46ClienteTelefone", A46ClienteTelefone);
               A45ClienteEndereco = H000N2_A45ClienteEndereco[0];
               AssignAttri(sPrefix, false, "A45ClienteEndereco", A45ClienteEndereco);
               A44ClienteNome = H000N2_A44ClienteNome[0];
               AssignAttri(sPrefix, false, "A44ClienteNome", A44ClienteNome);
               A69PaisClienteBandeira = H000N2_A69PaisClienteBandeira[0];
               AssignAttri(sPrefix, false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
               A49CartaoPontosClienteDescricao = H000N2_A49CartaoPontosClienteDescricao[0];
               AssignAttri(sPrefix, false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
               A40000PaisClienteBandeira_GXI = H000N2_A40000PaisClienteBandeira_GXI[0];
               n40000PaisClienteBandeira_GXI = H000N2_n40000PaisClienteBandeira_GXI[0];
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
               A12PaisClienteNome = H000N2_A12PaisClienteNome[0];
               AssignAttri(sPrefix, false, "A12PaisClienteNome", A12PaisClienteNome);
               A69PaisClienteBandeira = H000N2_A69PaisClienteBandeira[0];
               AssignAttri(sPrefix, false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A69PaisClienteBandeira)) ? A40000PaisClienteBandeira_GXI : context.convertURL( context.PathToRelativeUrl( A69PaisClienteBandeira))), true);
               AssignProp(sPrefix, false, imgPaisClienteBandeira_Internalname, "SrcSet", context.GetImageSrcSet( A69PaisClienteBandeira), true);
               /* Execute user event: Load */
               E140N2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB0N0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0N2( )
      {
      }

      protected void before_start_formulas( )
      {
         AV13Pgmname = "ClienteGeneral";
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0N0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E130N2 ();
         context.wbGlbDoneStart = 1;
         nDoneStart = 1;
         /* After Start, stand alone formulas. */
         sXEvt = cgiGet( "_EventName");
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            wcpOA43ClienteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA43ClienteId"), ".", ","));
            /* Read variables values. */
            A44ClienteNome = cgiGet( edtClienteNome_Internalname);
            AssignAttri(sPrefix, false, "A44ClienteNome", A44ClienteNome);
            A45ClienteEndereco = cgiGet( edtClienteEndereco_Internalname);
            AssignAttri(sPrefix, false, "A45ClienteEndereco", A45ClienteEndereco);
            A46ClienteTelefone = cgiGet( edtClienteTelefone_Internalname);
            AssignAttri(sPrefix, false, "A46ClienteTelefone", A46ClienteTelefone);
            A47ClienteEmail = cgiGet( edtClienteEmail_Internalname);
            AssignAttri(sPrefix, false, "A47ClienteEmail", A47ClienteEmail);
            A11PaisClienteId = (short)(context.localUtil.CToN( cgiGet( edtPaisClienteId_Internalname), ".", ","));
            AssignAttri(sPrefix, false, "A11PaisClienteId", StringUtil.LTrimStr( (decimal)(A11PaisClienteId), 4, 0));
            A12PaisClienteNome = cgiGet( edtPaisClienteNome_Internalname);
            AssignAttri(sPrefix, false, "A12PaisClienteNome", A12PaisClienteNome);
            A48CartaoPontosClienteId = (short)(context.localUtil.CToN( cgiGet( edtCartaoPontosClienteId_Internalname), ".", ","));
            n48CartaoPontosClienteId = false;
            AssignAttri(sPrefix, false, "A48CartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(A48CartaoPontosClienteId), 4, 0));
            A49CartaoPontosClienteDescricao = cgiGet( edtCartaoPontosClienteDescricao_Internalname);
            AssignAttri(sPrefix, false, "A49CartaoPontosClienteDescricao", A49CartaoPontosClienteDescricao);
            A67ClienteVIP = StringUtil.StrToBool( cgiGet( chkClienteVIP_Internalname));
            AssignAttri(sPrefix, false, "A67ClienteVIP", A67ClienteVIP);
            A69PaisClienteBandeira = cgiGet( imgPaisClienteBandeira_Internalname);
            AssignAttri(sPrefix, false, "A69PaisClienteBandeira", A69PaisClienteBandeira);
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
         E130N2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E130N2( )
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

      protected void E140N2( )
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
         AV7TrnContext.gxTpr_Transactionname = "Cliente";
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV8TrnContextAtt.gxTpr_Attributename = "ClienteId";
         AV8TrnContextAtt.gxTpr_Attributevalue = StringUtil.Str( (decimal)(AV6ClienteId), 4, 0);
         AV7TrnContext.gxTpr_Attributes.Add(AV8TrnContextAtt, 0);
         AV9Session.Set("TrnContext", AV7TrnContext.ToXml(false, true, "", ""));
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         A43ClienteId = Convert.ToInt16(getParm(obj,0));
         AssignAttri(sPrefix, false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
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
         PA0N2( ) ;
         WS0N2( ) ;
         WE0N2( ) ;
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
         sCtrlA43ClienteId = (string)((string)getParm(obj,0));
      }

      public override void componentrestorestate( string sPPrefix ,
                                                  string sPSFPrefix )
      {
         sPrefix = sPPrefix + sPSFPrefix;
         PA0N2( ) ;
         WCParametersGet( ) ;
      }

      public override void componentprepare( Object[] obj )
      {
         wbLoad = false;
         sCompPrefix = (string)getParm(obj,0);
         sSFPrefix = (string)getParm(obj,1);
         sPrefix = sCompPrefix + sSFPrefix;
         AddComponentObject(sPrefix, "clientegeneral", GetJustCreated( ));
         if ( ( nDoneStart == 0 ) && ( nDynComponent == 0 ) )
         {
            INITWEB( ) ;
         }
         else
         {
            init_default_properties( ) ;
            init_web_controls( ) ;
         }
         PA0N2( ) ;
         if ( ! GetJustCreated( ) && ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 ) && ( context.wbGlbDoneStart == 0 ) )
         {
            WCParametersGet( ) ;
         }
         else
         {
            A43ClienteId = Convert.ToInt16(getParm(obj,2));
            AssignAttri(sPrefix, false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
         }
         wcpOA43ClienteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"wcpOA43ClienteId"), ".", ","));
         if ( ! GetJustCreated( ) && ( ( A43ClienteId != wcpOA43ClienteId ) ) )
         {
            setjustcreated();
         }
         wcpOA43ClienteId = A43ClienteId;
      }

      protected void WCParametersGet( )
      {
         /* Read Component Parameters. */
         sCtrlA43ClienteId = cgiGet( sPrefix+"A43ClienteId_CTRL");
         if ( StringUtil.Len( sCtrlA43ClienteId) > 0 )
         {
            A43ClienteId = (short)(context.localUtil.CToN( cgiGet( sCtrlA43ClienteId), ".", ","));
            AssignAttri(sPrefix, false, "A43ClienteId", StringUtil.LTrimStr( (decimal)(A43ClienteId), 4, 0));
         }
         else
         {
            A43ClienteId = (short)(context.localUtil.CToN( cgiGet( sPrefix+"A43ClienteId_PARM"), ".", ","));
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
         PA0N2( ) ;
         sEvt = sCompEvt;
         WCParametersGet( ) ;
         WS0N2( ) ;
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
         WS0N2( ) ;
         SaveComponentMsgList(sPrefix);
         context.GX_msglist = BackMsgLst;
      }

      protected void WCParametersSet( )
      {
         GxWebStd.gx_hidden_field( context, sPrefix+"A43ClienteId_PARM", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")));
         if ( StringUtil.Len( StringUtil.RTrim( sCtrlA43ClienteId)) > 0 )
         {
            GxWebStd.gx_hidden_field( context, sPrefix+"A43ClienteId_CTRL", StringUtil.RTrim( sCtrlA43ClienteId));
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
         WE0N2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513765", true, true);
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
         context.AddJavascriptSource("clientegeneral.js", "?202582916513765", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkClienteVIP.Name = "CLIENTEVIP";
         chkClienteVIP.WebTags = "";
         chkClienteVIP.Caption = "";
         AssignProp(sPrefix, false, chkClienteVIP_Internalname, "TitleCaption", chkClienteVIP.Caption, true);
         chkClienteVIP.CheckedValue = "false";
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         bttBtnupdate_Internalname = sPrefix+"BTNUPDATE";
         bttBtndelete_Internalname = sPrefix+"BTNDELETE";
         edtClienteId_Internalname = sPrefix+"CLIENTEID";
         edtClienteNome_Internalname = sPrefix+"CLIENTENOME";
         edtClienteEndereco_Internalname = sPrefix+"CLIENTEENDERECO";
         edtClienteTelefone_Internalname = sPrefix+"CLIENTETELEFONE";
         edtClienteEmail_Internalname = sPrefix+"CLIENTEEMAIL";
         edtPaisClienteId_Internalname = sPrefix+"PAISCLIENTEID";
         edtPaisClienteNome_Internalname = sPrefix+"PAISCLIENTENOME";
         edtCartaoPontosClienteId_Internalname = sPrefix+"CARTAOPONTOSCLIENTEID";
         edtCartaoPontosClienteDescricao_Internalname = sPrefix+"CARTAOPONTOSCLIENTEDESCRICAO";
         chkClienteVIP_Internalname = sPrefix+"CLIENTEVIP";
         divAttributestable_Internalname = sPrefix+"ATTRIBUTESTABLE";
         imgPaisClienteBandeira_Internalname = sPrefix+"PAISCLIENTEBANDEIRA";
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
         chkClienteVIP.Caption = "VIP";
         chkClienteVIP.Enabled = 0;
         edtCartaoPontosClienteDescricao_Jsonclick = "";
         edtCartaoPontosClienteDescricao_Enabled = 0;
         edtCartaoPontosClienteId_Jsonclick = "";
         edtCartaoPontosClienteId_Enabled = 0;
         edtPaisClienteNome_Jsonclick = "";
         edtPaisClienteNome_Enabled = 0;
         edtPaisClienteId_Jsonclick = "";
         edtPaisClienteId_Enabled = 0;
         edtClienteEmail_Jsonclick = "";
         edtClienteEmail_Enabled = 0;
         edtClienteTelefone_Jsonclick = "";
         edtClienteTelefone_Enabled = 0;
         edtClienteEndereco_Enabled = 0;
         edtClienteNome_Jsonclick = "";
         edtClienteNome_Enabled = 0;
         edtClienteId_Jsonclick = "";
         edtClienteId_Enabled = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A43ClienteId',fld:'CLIENTEID',pic:'ZZZ9'},{av:'A67ClienteVIP',fld:'CLIENTEVIP',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOUPDATE'","{handler:'E110N1',iparms:[{av:'A43ClienteId',fld:'CLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("'DOUPDATE'",",oparms:[]}");
         setEventMetadata("'DODELETE'","{handler:'E120N1',iparms:[{av:'A43ClienteId',fld:'CLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("'DODELETE'",",oparms:[]}");
         setEventMetadata("VALID_CLIENTEID","{handler:'Valid_Clienteid',iparms:[]");
         setEventMetadata("VALID_CLIENTEID",",oparms:[]}");
         setEventMetadata("VALID_PAISCLIENTEID","{handler:'Valid_Paisclienteid',iparms:[]");
         setEventMetadata("VALID_PAISCLIENTEID",",oparms:[]}");
         setEventMetadata("VALID_CARTAOPONTOSCLIENTEID","{handler:'Valid_Cartaopontosclienteid',iparms:[]");
         setEventMetadata("VALID_CARTAOPONTOSCLIENTEID",",oparms:[]}");
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
         A44ClienteNome = "";
         A45ClienteEndereco = "";
         gxphoneLink = "";
         A46ClienteTelefone = "";
         A47ClienteEmail = "";
         A12PaisClienteNome = "";
         A49CartaoPontosClienteDescricao = "";
         A69PaisClienteBandeira = "";
         A40000PaisClienteBandeira_GXI = "";
         sImgUrl = "";
         Form = new GXWebForm();
         sXEvt = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         scmdbuf = "";
         H000N2_A43ClienteId = new short[1] ;
         H000N2_A40000PaisClienteBandeira_GXI = new string[] {""} ;
         H000N2_n40000PaisClienteBandeira_GXI = new bool[] {false} ;
         H000N2_A49CartaoPontosClienteDescricao = new string[] {""} ;
         H000N2_A48CartaoPontosClienteId = new short[1] ;
         H000N2_n48CartaoPontosClienteId = new bool[] {false} ;
         H000N2_A12PaisClienteNome = new string[] {""} ;
         H000N2_A11PaisClienteId = new short[1] ;
         H000N2_A47ClienteEmail = new string[] {""} ;
         H000N2_A46ClienteTelefone = new string[] {""} ;
         H000N2_A45ClienteEndereco = new string[] {""} ;
         H000N2_A44ClienteNome = new string[] {""} ;
         H000N2_A69PaisClienteBandeira = new string[] {""} ;
         AV7TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10HTTPRequest = new GxHttpRequest( context);
         AV8TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         AV9Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         sCtrlA43ClienteId = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.clientegeneral__default(),
            new Object[][] {
                new Object[] {
               H000N2_A43ClienteId, H000N2_A40000PaisClienteBandeira_GXI, H000N2_n40000PaisClienteBandeira_GXI, H000N2_A49CartaoPontosClienteDescricao, H000N2_A48CartaoPontosClienteId, H000N2_n48CartaoPontosClienteId, H000N2_A12PaisClienteNome, H000N2_A11PaisClienteId, H000N2_A47ClienteEmail, H000N2_A46ClienteTelefone,
               H000N2_A45ClienteEndereco, H000N2_A44ClienteNome, H000N2_A69PaisClienteBandeira
               }
            }
         );
         AV13Pgmname = "ClienteGeneral";
         /* GeneXus formulas. */
         AV13Pgmname = "ClienteGeneral";
         context.Gx_err = 0;
      }

      private short A43ClienteId ;
      private short wcpOA43ClienteId ;
      private short nGotPars ;
      private short GxWebError ;
      private short nDynComponent ;
      private short initialized ;
      private short wbEnd ;
      private short wbStart ;
      private short A11PaisClienteId ;
      private short A48CartaoPontosClienteId ;
      private short nDraw ;
      private short nDoneStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short AV6ClienteId ;
      private short nGXWrapped ;
      private int edtClienteId_Enabled ;
      private int edtClienteNome_Enabled ;
      private int edtClienteEndereco_Enabled ;
      private int edtClienteTelefone_Enabled ;
      private int edtClienteEmail_Enabled ;
      private int edtPaisClienteId_Enabled ;
      private int edtPaisClienteNome_Enabled ;
      private int edtCartaoPontosClienteId_Enabled ;
      private int edtCartaoPontosClienteDescricao_Enabled ;
      private int idxLst ;
      private decimal A66CartaoPontosAcumulados ;
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
      private string edtClienteId_Internalname ;
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
      private string edtPaisClienteNome_Internalname ;
      private string edtPaisClienteNome_Jsonclick ;
      private string edtCartaoPontosClienteId_Internalname ;
      private string edtCartaoPontosClienteId_Jsonclick ;
      private string edtCartaoPontosClienteDescricao_Internalname ;
      private string edtCartaoPontosClienteDescricao_Jsonclick ;
      private string chkClienteVIP_Internalname ;
      private string divImagestable_Internalname ;
      private string sImgUrl ;
      private string imgPaisClienteBandeira_Internalname ;
      private string sXEvt ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string scmdbuf ;
      private string sCtrlA43ClienteId ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool A67ClienteVIP ;
      private bool A69PaisClienteBandeira_IsBlob ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool n40000PaisClienteBandeira_GXI ;
      private bool n48CartaoPontosClienteId ;
      private bool returnInSub ;
      private string A44ClienteNome ;
      private string A45ClienteEndereco ;
      private string A47ClienteEmail ;
      private string A12PaisClienteNome ;
      private string A49CartaoPontosClienteDescricao ;
      private string A40000PaisClienteBandeira_GXI ;
      private string A69PaisClienteBandeira ;
      private GXWebForm Form ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkClienteVIP ;
      private IDataStoreProvider pr_default ;
      private short[] H000N2_A43ClienteId ;
      private string[] H000N2_A40000PaisClienteBandeira_GXI ;
      private bool[] H000N2_n40000PaisClienteBandeira_GXI ;
      private string[] H000N2_A49CartaoPontosClienteDescricao ;
      private short[] H000N2_A48CartaoPontosClienteId ;
      private bool[] H000N2_n48CartaoPontosClienteId ;
      private string[] H000N2_A12PaisClienteNome ;
      private short[] H000N2_A11PaisClienteId ;
      private string[] H000N2_A47ClienteEmail ;
      private string[] H000N2_A46ClienteTelefone ;
      private string[] H000N2_A45ClienteEndereco ;
      private string[] H000N2_A44ClienteNome ;
      private string[] H000N2_A69PaisClienteBandeira ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV10HTTPRequest ;
      private IGxSession AV9Session ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV7TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV8TrnContextAtt ;
   }

   public class clientegeneral__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000N2;
          prmH000N2 = new Object[] {
          new ParDef("@ClienteId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000N2", "SELECT T1.[ClienteId], T3.[PaisBandeira_GXI] AS PaisClienteBandeira_GXI, T2.[CartaoPontosDescricao] AS CartaoPontosClienteDescricao, T1.[CartaoPontosClienteId] AS CartaoPontosClienteId, T3.[PaisNome] AS PaisClienteNome, T1.[PaisClienteId] AS PaisClienteId, T1.[ClienteEmail], T1.[ClienteTelefone], T1.[ClienteEndereco], T1.[ClienteNome], T3.[PaisBandeira] AS PaisClienteBandeira FROM (([Cliente] T1 LEFT JOIN [CartaoPontos] T2 ON T2.[CartaoPontosId] = T1.[CartaoPontosClienteId]) INNER JOIN [Pais] T3 ON T3.[PaisId] = T1.[PaisClienteId]) WHERE T1.[ClienteId] = @ClienteId ORDER BY T1.[ClienteId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000N2,1, GxCacheFrequency.OFF ,true,true )
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
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                ((string[]) buf[6])[0] = rslt.getVarchar(5);
                ((short[]) buf[7])[0] = rslt.getShort(6);
                ((string[]) buf[8])[0] = rslt.getVarchar(7);
                ((string[]) buf[9])[0] = rslt.getString(8, 20);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((string[]) buf[11])[0] = rslt.getVarchar(10);
                ((string[]) buf[12])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(2));
                return;
       }
    }

 }

}
