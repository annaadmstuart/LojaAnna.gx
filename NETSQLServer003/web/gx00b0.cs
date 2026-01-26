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
   public class gx00b0 : GXDataArea
   {
      public gx00b0( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public gx00b0( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pClienteId )
      {
         this.AV12pClienteId = 0 ;
         executePrivate();
         aP0_pClienteId=this.AV12pClienteId;
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
            gxfirstwebparm = GetFirstPar( "pClienteId");
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
               gxfirstwebparm = GetFirstPar( "pClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pClienteId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid1") == 0 )
            {
               gxnrGrid1_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid1") == 0 )
            {
               gxgrGrid1_refresh_invoke( ) ;
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
               AV12pClienteId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV12pClienteId", StringUtil.LTrimStr( (decimal)(AV12pClienteId), 4, 0));
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

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_74 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_74"), "."));
         nGXsfl_74_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_74_idx"), "."));
         sGXsfl_74_idx = GetPar( "sGXsfl_74_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid1_newrow( ) ;
         /* End function gxnrGrid1_newrow_invoke */
      }

      protected void gxgrGrid1_refresh_invoke( )
      {
         subGrid1_Rows = (int)(NumberUtil.Val( GetPar( "subGrid1_Rows"), "."));
         AV6cClienteId = (short)(NumberUtil.Val( GetPar( "cClienteId"), "."));
         AV7cClienteNome = GetPar( "cClienteNome");
         AV8cClienteTelefone = GetPar( "cClienteTelefone");
         AV9cClienteEmail = GetPar( "cClienteEmail");
         AV10cPaisClienteId = (short)(NumberUtil.Val( GetPar( "cPaisClienteId"), "."));
         AV11cCartaoPontosClienteId = (short)(NumberUtil.Val( GetPar( "cCartaoPontosClienteId"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteTelefone, AV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid1_refresh_invoke */
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("general.ui.masterprompt", "GeneXus.Programs.general.ui.masterprompt", new Object[] {new GxContext( context.handle, context.DataStores, context.HttpContext)});
            MasterPageObj.setDataArea(this,true);
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
         PA0B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0B2( ) ;
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
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx00b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pClienteId,4,0))}, new string[] {"pClienteId"}) +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTENOME", AV7cClienteNome);
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTETELEFONE", StringUtil.RTrim( AV8cClienteTelefone));
         GxWebStd.gx_hidden_field( context, "GXH_vCCLIENTEEMAIL", AV9cClienteEmail);
         GxWebStd.gx_hidden_field( context, "GXH_vCPAISCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cPaisClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCCARTAOPONTOSCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCartaoPontosClienteId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_74", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_74), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPCLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12pClienteId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTEIDFILTERCONTAINER_Class", StringUtil.RTrim( divClienteidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTENOMEFILTERCONTAINER_Class", StringUtil.RTrim( divClientenomefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTETELEFONEFILTERCONTAINER_Class", StringUtil.RTrim( divClientetelefonefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CLIENTEEMAILFILTERCONTAINER_Class", StringUtil.RTrim( divClienteemailfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAISCLIENTEIDFILTERCONTAINER_Class", StringUtil.RTrim( divPaisclienteidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "CARTAOPONTOSCLIENTEIDFILTERCONTAINER_Class", StringUtil.RTrim( divCartaopontosclienteidfiltercontainer_Class));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", "notset");
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
            WE0B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0B2( ) ;
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
         return formatLink("gx00b0.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV12pClienteId,4,0))}, new string[] {"pClienteId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx00B0" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Cliente" ;
      }

      protected void WB0B0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "left", "top", " "+"data-gx-base-lib=\"none\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divMain_Internalname, 1, 0, "px", 0, "px", "ContainerFluid PromptContainer", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 PromptAdvancedBarCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedcontainer_Internalname, 1, 0, "px", 0, "px", divAdvancedcontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divClienteidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divClienteidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclienteidfilter_Internalname, "Cliente ", "", "", lblLblclienteidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e110b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclienteid_Internalname, "Cliente ", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cClienteId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclienteid_Visible, edtavCclienteid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divClientenomefiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientenomefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientenomefilter_Internalname, "Nome", "", "", lblLblclientenomefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e120b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientenome_Internalname, "Nome", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientenome_Internalname, AV7cClienteNome, StringUtil.RTrim( context.localUtil.Format( AV7cClienteNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientenome_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientenome_Visible, edtavCclientenome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divClientetelefonefiltercontainer_Internalname, 1, 0, "px", 0, "px", divClientetelefonefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclientetelefonefilter_Internalname, "Telefone", "", "", lblLblclientetelefonefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e130b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclientetelefone_Internalname, "Telefone", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclientetelefone_Internalname, StringUtil.RTrim( AV8cClienteTelefone), StringUtil.RTrim( context.localUtil.Format( AV8cClienteTelefone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclientetelefone_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclientetelefone_Visible, edtavCclientetelefone_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "", "left", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divClienteemailfiltercontainer_Internalname, 1, 0, "px", 0, "px", divClienteemailfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblclienteemailfilter_Internalname, "Email", "", "", lblLblclienteemailfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e140b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCclienteemail_Internalname, "Email", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCclienteemail_Internalname, AV9cClienteEmail, StringUtil.RTrim( context.localUtil.Format( AV9cClienteEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCclienteemail_Jsonclick, 0, "Attribute", "", "", "", "", edtavCclienteemail_Visible, edtavCclienteemail_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "", "left", true, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divPaisclienteidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaisclienteidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaisclienteidfilter_Internalname, "País", "", "", lblLblpaisclienteidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e150b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpaisclienteid_Internalname, "País", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaisclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cPaisClienteId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCpaisclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cPaisClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cPaisClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaisclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaisclienteid_Visible, edtavCpaisclienteid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00B0.htm");
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
            GxWebStd.gx_div_start( context, divCartaopontosclienteidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divCartaopontosclienteidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblcartaopontosclienteidfilter_Internalname, "Cartão", "", "", lblLblcartaopontosclienteidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e160b1_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCcartaopontosclienteid_Internalname, "Cartão", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_74_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCcartaopontosclienteid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cCartaoPontosClienteId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCcartaopontosclienteid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cCartaoPontosClienteId), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cCartaoPontosClienteId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCcartaopontosclienteid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCcartaopontosclienteid_Visible, edtavCcartaopontosclienteid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 WWGridCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-sm hidden-md hidden-lg ToggleCell", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e170b1_client"+"'", TempTags, "", 2, "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl74( ) ;
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            nRC_GXsfl_74 = (int)(nGXsfl_74_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
               Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(74), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx00B0.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 74 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid1Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  Grid1Container.AddObjectProperty("GRID1_nEOF", GRID1_nEOF);
                  Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid1Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid1", Grid1Container, subGrid1_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData", Grid1Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid1ContainerData"+"V", Grid1Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid1ContainerData"+"V"+"\" value='"+Grid1Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0B2( )
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
            Form.Meta.addItem("description", "Selection List Cliente", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0B0( ) ;
      }

      protected void WS0B2( )
      {
         START0B2( ) ;
         EVT0B2( ) ;
      }

      protected void EVT0B2( )
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
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRID1PAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRID1PAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid1_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid1_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid1_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid1_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 4), "LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) )
                           {
                              nGXsfl_74_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
                              SubsflControlProps_742( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_74_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A43ClienteId = (short)(context.localUtil.CToN( cgiGet( edtClienteId_Internalname), ".", ","));
                              A44ClienteNome = cgiGet( edtClienteNome_Internalname);
                              A46ClienteTelefone = cgiGet( edtClienteTelefone_Internalname);
                              A11PaisClienteId = (short)(context.localUtil.CToN( cgiGet( edtPaisClienteId_Internalname), ".", ","));
                              A48CartaoPontosClienteId = (short)(context.localUtil.CToN( cgiGet( edtCartaoPontosClienteId_Internalname), ".", ","));
                              n48CartaoPontosClienteId = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E180B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E190B2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cclienteid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTEID"), ".", ",") != Convert.ToDecimal( AV6cClienteId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientenome Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTENOME"), AV7cClienteNome) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclientetelefone Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTETELEFONE"), AV8cClienteTelefone) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cclienteemail Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTEEMAIL"), AV9cClienteEmail) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaisclienteid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAISCLIENTEID"), ".", ",") != Convert.ToDecimal( AV10cPaisClienteId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Ccartaopontosclienteid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCARTAOPONTOSCLIENTEID"), ".", ",") != Convert.ToDecimal( AV11cCartaoPontosClienteId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E200B2 ();
                                       }
                                       dynload_actions( ) ;
                                    }
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

      protected void WE0B2( )
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

      protected void PA0B2( )
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
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid1_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_742( ) ;
         while ( nGXsfl_74_idx <= nRC_GXsfl_74 )
         {
            sendrow_742( ) ;
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cClienteId ,
                                        string AV7cClienteNome ,
                                        string AV8cClienteTelefone ,
                                        string AV9cClienteEmail ,
                                        short AV10cPaisClienteId ,
                                        short AV11cCartaoPontosClienteId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0B2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A43ClienteId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CLIENTEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")));
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
         RF0B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      protected void RF0B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 74;
         nGXsfl_74_idx = 1;
         sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
         SubsflControlProps_742( ) ;
         bGXsfl_74_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", "PromptGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_742( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cClienteNome ,
                                                 AV8cClienteTelefone ,
                                                 AV9cClienteEmail ,
                                                 AV10cPaisClienteId ,
                                                 AV11cCartaoPontosClienteId ,
                                                 A44ClienteNome ,
                                                 A46ClienteTelefone ,
                                                 A47ClienteEmail ,
                                                 A11PaisClienteId ,
                                                 A48CartaoPontosClienteId ,
                                                 AV6cClienteId } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                                 }
            });
            lV7cClienteNome = StringUtil.Concat( StringUtil.RTrim( AV7cClienteNome), "%", "");
            lV8cClienteTelefone = StringUtil.PadR( StringUtil.RTrim( AV8cClienteTelefone), 20, "%");
            lV9cClienteEmail = StringUtil.Concat( StringUtil.RTrim( AV9cClienteEmail), "%", "");
            /* Using cursor H000B2 */
            pr_default.execute(0, new Object[] {AV6cClienteId, lV7cClienteNome, lV8cClienteTelefone, lV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_74_idx = 1;
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A47ClienteEmail = H000B2_A47ClienteEmail[0];
               A48CartaoPontosClienteId = H000B2_A48CartaoPontosClienteId[0];
               n48CartaoPontosClienteId = H000B2_n48CartaoPontosClienteId[0];
               A11PaisClienteId = H000B2_A11PaisClienteId[0];
               A46ClienteTelefone = H000B2_A46ClienteTelefone[0];
               A44ClienteNome = H000B2_A44ClienteNome[0];
               A43ClienteId = H000B2_A43ClienteId[0];
               /* Execute user event: Load */
               E190B2 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 74;
            WB0B0( ) ;
         }
         bGXsfl_74_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0B2( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIENTEID"+"_"+sGXsfl_74_idx, GetSecureSignedToken( sGXsfl_74_idx, context.localUtil.Format( (decimal)(A43ClienteId), "ZZZ9"), context));
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))) ;
         }
         return (int)(NumberUtil.Int( (long)(GRID1_nRecordCount/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV7cClienteNome ,
                                              AV8cClienteTelefone ,
                                              AV9cClienteEmail ,
                                              AV10cPaisClienteId ,
                                              AV11cCartaoPontosClienteId ,
                                              A44ClienteNome ,
                                              A46ClienteTelefone ,
                                              A47ClienteEmail ,
                                              A11PaisClienteId ,
                                              A48CartaoPontosClienteId ,
                                              AV6cClienteId } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT
                                              }
         });
         lV7cClienteNome = StringUtil.Concat( StringUtil.RTrim( AV7cClienteNome), "%", "");
         lV8cClienteTelefone = StringUtil.PadR( StringUtil.RTrim( AV8cClienteTelefone), 20, "%");
         lV9cClienteEmail = StringUtil.Concat( StringUtil.RTrim( AV9cClienteEmail), "%", "");
         /* Using cursor H000B3 */
         pr_default.execute(1, new Object[] {AV6cClienteId, lV7cClienteNome, lV8cClienteTelefone, lV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId});
         GRID1_nRecordCount = H000B3_AGRID1_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID1_nRecordCount) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(10*1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(GRID1_nFirstRecordOnPage/ (decimal)(subGrid1_fnc_Recordsperpage( ))))+1) ;
      }

      protected short subgrid1_firstpage( )
      {
         GRID1_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteTelefone, AV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_nextpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( ( GRID1_nRecordCount >= subGrid1_fnc_Recordsperpage( ) ) && ( GRID1_nEOF == 0 ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage+subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         Grid1Container.AddObjectProperty("GRID1_nFirstRecordOnPage", GRID1_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteTelefone, AV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID1_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid1_previouspage( )
      {
         if ( GRID1_nFirstRecordOnPage >= subGrid1_fnc_Recordsperpage( ) )
         {
            GRID1_nFirstRecordOnPage = (long)(GRID1_nFirstRecordOnPage-subGrid1_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteTelefone, AV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid1_lastpage( )
      {
         GRID1_nRecordCount = subGrid1_fnc_Recordcount( );
         if ( GRID1_nRecordCount > subGrid1_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))) == 0 )
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-subGrid1_fnc_Recordsperpage( ));
            }
            else
            {
               GRID1_nFirstRecordOnPage = (long)(GRID1_nRecordCount-((int)((GRID1_nRecordCount) % (subGrid1_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteTelefone, AV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid1_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRID1_nFirstRecordOnPage = (long)(subGrid1_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID1_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid1_refresh( subGrid1_Rows, AV6cClienteId, AV7cClienteNome, AV8cClienteTelefone, AV9cClienteEmail, AV10cPaisClienteId, AV11cCartaoPontosClienteId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E180B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_74 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_74"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCLIENTEID");
               GX_FocusControl = edtavCclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cClienteId = 0;
               AssignAttri("", false, "AV6cClienteId", StringUtil.LTrimStr( (decimal)(AV6cClienteId), 4, 0));
            }
            else
            {
               AV6cClienteId = (short)(context.localUtil.CToN( cgiGet( edtavCclienteid_Internalname), ".", ","));
               AssignAttri("", false, "AV6cClienteId", StringUtil.LTrimStr( (decimal)(AV6cClienteId), 4, 0));
            }
            AV7cClienteNome = cgiGet( edtavCclientenome_Internalname);
            AssignAttri("", false, "AV7cClienteNome", AV7cClienteNome);
            AV8cClienteTelefone = cgiGet( edtavCclientetelefone_Internalname);
            AssignAttri("", false, "AV8cClienteTelefone", AV8cClienteTelefone);
            AV9cClienteEmail = cgiGet( edtavCclienteemail_Internalname);
            AssignAttri("", false, "AV9cClienteEmail", AV9cClienteEmail);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpaisclienteid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpaisclienteid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPAISCLIENTEID");
               GX_FocusControl = edtavCpaisclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cPaisClienteId = 0;
               AssignAttri("", false, "AV10cPaisClienteId", StringUtil.LTrimStr( (decimal)(AV10cPaisClienteId), 4, 0));
            }
            else
            {
               AV10cPaisClienteId = (short)(context.localUtil.CToN( cgiGet( edtavCpaisclienteid_Internalname), ".", ","));
               AssignAttri("", false, "AV10cPaisClienteId", StringUtil.LTrimStr( (decimal)(AV10cPaisClienteId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCcartaopontosclienteid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCcartaopontosclienteid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCCARTAOPONTOSCLIENTEID");
               GX_FocusControl = edtavCcartaopontosclienteid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cCartaoPontosClienteId = 0;
               AssignAttri("", false, "AV11cCartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(AV11cCartaoPontosClienteId), 4, 0));
            }
            else
            {
               AV11cCartaoPontosClienteId = (short)(context.localUtil.CToN( cgiGet( edtavCcartaopontosclienteid_Internalname), ".", ","));
               AssignAttri("", false, "AV11cCartaoPontosClienteId", StringUtil.LTrimStr( (decimal)(AV11cCartaoPontosClienteId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCLIENTEID"), ".", ",") != Convert.ToDecimal( AV6cClienteId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTENOME"), AV7cClienteNome) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTETELEFONE"), AV8cClienteTelefone) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCCLIENTEEMAIL"), AV9cClienteEmail) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAISCLIENTEID"), ".", ",") != Convert.ToDecimal( AV10cPaisClienteId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCCARTAOPONTOSCLIENTEID"), ".", ",") != Convert.ToDecimal( AV11cCartaoPontosClienteId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
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
         E180B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E180B2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Cliente", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV13ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E190B2( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV16Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_742( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_74_Refreshing )
         {
            DoAjaxLoad(74, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E200B2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E200B2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12pClienteId = A43ClienteId;
         AssignAttri("", false, "AV12pClienteId", StringUtil.LTrimStr( (decimal)(AV12pClienteId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV12pClienteId});
         context.setWebReturnParmsMetadata(new Object[] {"AV12pClienteId"});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV12pClienteId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV12pClienteId", StringUtil.LTrimStr( (decimal)(AV12pClienteId), 4, 0));
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
         PA0B2( ) ;
         WS0B2( ) ;
         WE0B2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20258291651442", true, true);
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
         context.AddJavascriptSource("gx00b0.js", "?20258291651442", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_74_idx;
         edtClienteNome_Internalname = "CLIENTENOME_"+sGXsfl_74_idx;
         edtClienteTelefone_Internalname = "CLIENTETELEFONE_"+sGXsfl_74_idx;
         edtPaisClienteId_Internalname = "PAISCLIENTEID_"+sGXsfl_74_idx;
         edtCartaoPontosClienteId_Internalname = "CARTAOPONTOSCLIENTEID_"+sGXsfl_74_idx;
      }

      protected void SubsflControlProps_fel_742( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_74_fel_idx;
         edtClienteId_Internalname = "CLIENTEID_"+sGXsfl_74_fel_idx;
         edtClienteNome_Internalname = "CLIENTENOME_"+sGXsfl_74_fel_idx;
         edtClienteTelefone_Internalname = "CLIENTETELEFONE_"+sGXsfl_74_fel_idx;
         edtPaisClienteId_Internalname = "PAISCLIENTEID_"+sGXsfl_74_fel_idx;
         edtCartaoPontosClienteId_Internalname = "CARTAOPONTOSCLIENTEID_"+sGXsfl_74_fel_idx;
      }

      protected void sendrow_742( )
      {
         SubsflControlProps_742( ) ;
         WB0B0( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_74_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
         {
            Grid1Row = GXWebRow.GetNew(context,Grid1Container);
            if ( subGrid1_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid1_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
            else if ( subGrid1_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid1_Backstyle = 0;
               subGrid1_Backcolor = subGrid1_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Uniform";
               }
            }
            else if ( subGrid1_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
               subGrid1_Backcolor = (int)(0x0);
            }
            else if ( subGrid1_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid1_Backstyle = 1;
               if ( ((int)((nGXsfl_74_idx) % (2))) == 0 )
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Even";
                  }
               }
               else
               {
                  subGrid1_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Odd";
                  }
               }
            }
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"PromptGrid"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_74_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_74_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV16Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV16Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A43ClienteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtClienteNome_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtClienteNome_Internalname, "Link", edtClienteNome_Link, !bGXsfl_74_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteNome_Internalname,(string)A44ClienteNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtClienteNome_Link,(string)"",(string)"",(string)"",(string)edtClienteNome_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A46ClienteTelefone);
            }
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtClienteTelefone_Internalname,StringUtil.RTrim( A46ClienteTelefone),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtClienteTelefone_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A11PaisClienteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A11PaisClienteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCartaoPontosClienteId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A48CartaoPontosClienteId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A48CartaoPontosClienteId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCartaoPontosClienteId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)74,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes0B2( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_74_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_74_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_74_idx+1);
            sGXsfl_74_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_74_idx), 4, 0), 4, "0");
            SubsflControlProps_742( ) ;
         }
         /* End function sendrow_742 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl74( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"74\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "PromptGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid1_Backcolorstyle == 0 )
            {
               subGrid1_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid1_Class) > 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Title";
               }
            }
            else
            {
               subGrid1_Titlebackstyle = 1;
               if ( subGrid1_Backcolorstyle == 1 )
               {
                  subGrid1_Titlebackcolor = subGrid1_Allbackcolor;
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid1_Class) > 0 )
                  {
                     subGrid1_Linesclass = subGrid1_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"SelectionAttribute"+" "+((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class")+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Telefone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "País") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Cartão") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid1Container.AddObjectProperty("GridName", "Grid1");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid1Container = new GXWebGrid( context);
            }
            else
            {
               Grid1Container.Clear();
            }
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", "PromptGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( AV5LinkSelection));
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtavLinkselection_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A43ClienteId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", A44ClienteNome);
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtClienteNome_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.RTrim( A46ClienteTelefone));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A11PaisClienteId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A48CartaoPontosClienteId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectedindex), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowselection), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Selectioncolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowhovering), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Hoveringcolor), 9, 0, ".", "")));
            Grid1Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Allowcollapsing), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblLblclienteidfilter_Internalname = "LBLCLIENTEIDFILTER";
         edtavCclienteid_Internalname = "vCCLIENTEID";
         divClienteidfiltercontainer_Internalname = "CLIENTEIDFILTERCONTAINER";
         lblLblclientenomefilter_Internalname = "LBLCLIENTENOMEFILTER";
         edtavCclientenome_Internalname = "vCCLIENTENOME";
         divClientenomefiltercontainer_Internalname = "CLIENTENOMEFILTERCONTAINER";
         lblLblclientetelefonefilter_Internalname = "LBLCLIENTETELEFONEFILTER";
         edtavCclientetelefone_Internalname = "vCCLIENTETELEFONE";
         divClientetelefonefiltercontainer_Internalname = "CLIENTETELEFONEFILTERCONTAINER";
         lblLblclienteemailfilter_Internalname = "LBLCLIENTEEMAILFILTER";
         edtavCclienteemail_Internalname = "vCCLIENTEEMAIL";
         divClienteemailfiltercontainer_Internalname = "CLIENTEEMAILFILTERCONTAINER";
         lblLblpaisclienteidfilter_Internalname = "LBLPAISCLIENTEIDFILTER";
         edtavCpaisclienteid_Internalname = "vCPAISCLIENTEID";
         divPaisclienteidfiltercontainer_Internalname = "PAISCLIENTEIDFILTERCONTAINER";
         lblLblcartaopontosclienteidfilter_Internalname = "LBLCARTAOPONTOSCLIENTEIDFILTER";
         edtavCcartaopontosclienteid_Internalname = "vCCARTAOPONTOSCLIENTEID";
         divCartaopontosclienteidfiltercontainer_Internalname = "CARTAOPONTOSCLIENTEIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtClienteId_Internalname = "CLIENTEID";
         edtClienteNome_Internalname = "CLIENTENOME";
         edtClienteTelefone_Internalname = "CLIENTETELEFONE";
         edtPaisClienteId_Internalname = "PAISCLIENTEID";
         edtCartaoPontosClienteId_Internalname = "CARTAOPONTOSCLIENTEID";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         divGridtable_Internalname = "GRIDTABLE";
         divMain_Internalname = "MAIN";
         Form.Internalname = "FORM";
         subGrid1_Internalname = "GRID1";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid1_Allowcollapsing = 0;
         subGrid1_Allowselection = 0;
         subGrid1_Header = "";
         edtCartaoPontosClienteId_Jsonclick = "";
         edtPaisClienteId_Jsonclick = "";
         edtClienteTelefone_Jsonclick = "";
         edtClienteNome_Jsonclick = "";
         edtClienteNome_Link = "";
         edtClienteId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCcartaopontosclienteid_Jsonclick = "";
         edtavCcartaopontosclienteid_Enabled = 1;
         edtavCcartaopontosclienteid_Visible = 1;
         edtavCpaisclienteid_Jsonclick = "";
         edtavCpaisclienteid_Enabled = 1;
         edtavCpaisclienteid_Visible = 1;
         edtavCclienteemail_Jsonclick = "";
         edtavCclienteemail_Enabled = 1;
         edtavCclienteemail_Visible = 1;
         edtavCclientetelefone_Jsonclick = "";
         edtavCclientetelefone_Enabled = 1;
         edtavCclientetelefone_Visible = 1;
         edtavCclientenome_Jsonclick = "";
         edtavCclientenome_Enabled = 1;
         edtavCclientenome_Visible = 1;
         edtavCclienteid_Jsonclick = "";
         edtavCclienteid_Enabled = 1;
         edtavCclienteid_Visible = 1;
         divCartaopontosclienteidfiltercontainer_Class = "AdvancedContainerItem";
         divPaisclienteidfiltercontainer_Class = "AdvancedContainerItem";
         divClienteemailfiltercontainer_Class = "AdvancedContainerItem";
         divClientetelefonefiltercontainer_Class = "AdvancedContainerItem";
         divClientenomefiltercontainer_Class = "AdvancedContainerItem";
         divClienteidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Cliente";
         subGrid1_Rows = 10;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cClienteId',fld:'vCCLIENTEID',pic:'ZZZ9'},{av:'AV7cClienteNome',fld:'vCCLIENTENOME',pic:''},{av:'AV8cClienteTelefone',fld:'vCCLIENTETELEFONE',pic:''},{av:'AV9cClienteEmail',fld:'vCCLIENTEEMAIL',pic:''},{av:'AV10cPaisClienteId',fld:'vCPAISCLIENTEID',pic:'ZZZ9'},{av:'AV11cCartaoPontosClienteId',fld:'vCCARTAOPONTOSCLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E170B1',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLCLIENTEIDFILTER.CLICK","{handler:'E110B1',iparms:[{av:'divClienteidfiltercontainer_Class',ctrl:'CLIENTEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLIENTEIDFILTER.CLICK",",oparms:[{av:'divClienteidfiltercontainer_Class',ctrl:'CLIENTEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCclienteid_Visible',ctrl:'vCCLIENTEID',prop:'Visible'}]}");
         setEventMetadata("LBLCLIENTENOMEFILTER.CLICK","{handler:'E120B1',iparms:[{av:'divClientenomefiltercontainer_Class',ctrl:'CLIENTENOMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLIENTENOMEFILTER.CLICK",",oparms:[{av:'divClientenomefiltercontainer_Class',ctrl:'CLIENTENOMEFILTERCONTAINER',prop:'Class'},{av:'edtavCclientenome_Visible',ctrl:'vCCLIENTENOME',prop:'Visible'}]}");
         setEventMetadata("LBLCLIENTETELEFONEFILTER.CLICK","{handler:'E130B1',iparms:[{av:'divClientetelefonefiltercontainer_Class',ctrl:'CLIENTETELEFONEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLIENTETELEFONEFILTER.CLICK",",oparms:[{av:'divClientetelefonefiltercontainer_Class',ctrl:'CLIENTETELEFONEFILTERCONTAINER',prop:'Class'},{av:'edtavCclientetelefone_Visible',ctrl:'vCCLIENTETELEFONE',prop:'Visible'}]}");
         setEventMetadata("LBLCLIENTEEMAILFILTER.CLICK","{handler:'E140B1',iparms:[{av:'divClienteemailfiltercontainer_Class',ctrl:'CLIENTEEMAILFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCLIENTEEMAILFILTER.CLICK",",oparms:[{av:'divClienteemailfiltercontainer_Class',ctrl:'CLIENTEEMAILFILTERCONTAINER',prop:'Class'},{av:'edtavCclienteemail_Visible',ctrl:'vCCLIENTEEMAIL',prop:'Visible'}]}");
         setEventMetadata("LBLPAISCLIENTEIDFILTER.CLICK","{handler:'E150B1',iparms:[{av:'divPaisclienteidfiltercontainer_Class',ctrl:'PAISCLIENTEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAISCLIENTEIDFILTER.CLICK",",oparms:[{av:'divPaisclienteidfiltercontainer_Class',ctrl:'PAISCLIENTEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpaisclienteid_Visible',ctrl:'vCPAISCLIENTEID',prop:'Visible'}]}");
         setEventMetadata("LBLCARTAOPONTOSCLIENTEIDFILTER.CLICK","{handler:'E160B1',iparms:[{av:'divCartaopontosclienteidfiltercontainer_Class',ctrl:'CARTAOPONTOSCLIENTEIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLCARTAOPONTOSCLIENTEIDFILTER.CLICK",",oparms:[{av:'divCartaopontosclienteidfiltercontainer_Class',ctrl:'CARTAOPONTOSCLIENTEIDFILTERCONTAINER',prop:'Class'},{av:'edtavCcartaopontosclienteid_Visible',ctrl:'vCCARTAOPONTOSCLIENTEID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E200B2',iparms:[{av:'A43ClienteId',fld:'CLIENTEID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12pClienteId',fld:'vPCLIENTEID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cClienteId',fld:'vCCLIENTEID',pic:'ZZZ9'},{av:'AV7cClienteNome',fld:'vCCLIENTENOME',pic:''},{av:'AV8cClienteTelefone',fld:'vCCLIENTETELEFONE',pic:''},{av:'AV9cClienteEmail',fld:'vCCLIENTEEMAIL',pic:''},{av:'AV10cPaisClienteId',fld:'vCPAISCLIENTEID',pic:'ZZZ9'},{av:'AV11cCartaoPontosClienteId',fld:'vCCARTAOPONTOSCLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cClienteId',fld:'vCCLIENTEID',pic:'ZZZ9'},{av:'AV7cClienteNome',fld:'vCCLIENTENOME',pic:''},{av:'AV8cClienteTelefone',fld:'vCCLIENTETELEFONE',pic:''},{av:'AV9cClienteEmail',fld:'vCCLIENTEEMAIL',pic:''},{av:'AV10cPaisClienteId',fld:'vCPAISCLIENTEID',pic:'ZZZ9'},{av:'AV11cCartaoPontosClienteId',fld:'vCCARTAOPONTOSCLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cClienteId',fld:'vCCLIENTEID',pic:'ZZZ9'},{av:'AV7cClienteNome',fld:'vCCLIENTENOME',pic:''},{av:'AV8cClienteTelefone',fld:'vCCLIENTETELEFONE',pic:''},{av:'AV9cClienteEmail',fld:'vCCLIENTEEMAIL',pic:''},{av:'AV10cPaisClienteId',fld:'vCPAISCLIENTEID',pic:'ZZZ9'},{av:'AV11cCartaoPontosClienteId',fld:'vCCARTAOPONTOSCLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cClienteId',fld:'vCCLIENTEID',pic:'ZZZ9'},{av:'AV7cClienteNome',fld:'vCCLIENTENOME',pic:''},{av:'AV8cClienteTelefone',fld:'vCCLIENTETELEFONE',pic:''},{av:'AV9cClienteEmail',fld:'vCCLIENTEEMAIL',pic:''},{av:'AV10cPaisClienteId',fld:'vCPAISCLIENTEID',pic:'ZZZ9'},{av:'AV11cCartaoPontosClienteId',fld:'vCCARTAOPONTOSCLIENTEID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("VALIDV_CCLIENTEEMAIL","{handler:'Validv_Cclienteemail',iparms:[]");
         setEventMetadata("VALIDV_CCLIENTEEMAIL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cartaopontosclienteid',iparms:[]");
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
         AV7cClienteNome = "";
         AV8cClienteTelefone = "";
         AV9cClienteEmail = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblclienteidfilter_Jsonclick = "";
         TempTags = "";
         lblLblclientenomefilter_Jsonclick = "";
         lblLblclientetelefonefilter_Jsonclick = "";
         lblLblclienteemailfilter_Jsonclick = "";
         lblLblpaisclienteidfilter_Jsonclick = "";
         lblLblcartaopontosclienteidfilter_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         bttBtntoggle_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         bttBtn_cancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV5LinkSelection = "";
         AV16Linkselection_GXI = "";
         A44ClienteNome = "";
         A46ClienteTelefone = "";
         scmdbuf = "";
         lV7cClienteNome = "";
         lV8cClienteTelefone = "";
         lV9cClienteEmail = "";
         A47ClienteEmail = "";
         H000B2_A47ClienteEmail = new string[] {""} ;
         H000B2_A48CartaoPontosClienteId = new short[1] ;
         H000B2_n48CartaoPontosClienteId = new bool[] {false} ;
         H000B2_A11PaisClienteId = new short[1] ;
         H000B2_A46ClienteTelefone = new string[] {""} ;
         H000B2_A44ClienteNome = new string[] {""} ;
         H000B2_A43ClienteId = new short[1] ;
         H000B3_AGRID1_nRecordCount = new long[1] ;
         AV13ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         gxphoneLink = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx00b0__default(),
            new Object[][] {
                new Object[] {
               H000B2_A47ClienteEmail, H000B2_A48CartaoPontosClienteId, H000B2_n48CartaoPontosClienteId, H000B2_A11PaisClienteId, H000B2_A46ClienteTelefone, H000B2_A44ClienteNome, H000B2_A43ClienteId
               }
               , new Object[] {
               H000B3_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV12pClienteId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cClienteId ;
      private short AV10cPaisClienteId ;
      private short AV11cCartaoPontosClienteId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A43ClienteId ;
      private short A11PaisClienteId ;
      private short A48CartaoPontosClienteId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short nGXWrapped ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Titlebackstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private int nRC_GXsfl_74 ;
      private int subGrid1_Rows ;
      private int nGXsfl_74_idx=1 ;
      private int edtavCclienteid_Enabled ;
      private int edtavCclienteid_Visible ;
      private int edtavCclientenome_Visible ;
      private int edtavCclientenome_Enabled ;
      private int edtavCclientetelefone_Visible ;
      private int edtavCclientetelefone_Enabled ;
      private int edtavCclienteemail_Visible ;
      private int edtavCclienteemail_Enabled ;
      private int edtavCpaisclienteid_Enabled ;
      private int edtavCpaisclienteid_Visible ;
      private int edtavCcartaopontosclienteid_Enabled ;
      private int edtavCcartaopontosclienteid_Visible ;
      private int subGrid1_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int idxLst ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Titlebackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nRecordCount ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divClienteidfiltercontainer_Class ;
      private string divClientenomefiltercontainer_Class ;
      private string divClientetelefonefiltercontainer_Class ;
      private string divClienteemailfiltercontainer_Class ;
      private string divPaisclienteidfiltercontainer_Class ;
      private string divCartaopontosclienteidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_74_idx="0001" ;
      private string AV8cClienteTelefone ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divClienteidfiltercontainer_Internalname ;
      private string lblLblclienteidfilter_Internalname ;
      private string lblLblclienteidfilter_Jsonclick ;
      private string edtavCclienteid_Internalname ;
      private string TempTags ;
      private string edtavCclienteid_Jsonclick ;
      private string divClientenomefiltercontainer_Internalname ;
      private string lblLblclientenomefilter_Internalname ;
      private string lblLblclientenomefilter_Jsonclick ;
      private string edtavCclientenome_Internalname ;
      private string edtavCclientenome_Jsonclick ;
      private string divClientetelefonefiltercontainer_Internalname ;
      private string lblLblclientetelefonefilter_Internalname ;
      private string lblLblclientetelefonefilter_Jsonclick ;
      private string edtavCclientetelefone_Internalname ;
      private string edtavCclientetelefone_Jsonclick ;
      private string divClienteemailfiltercontainer_Internalname ;
      private string lblLblclienteemailfilter_Internalname ;
      private string lblLblclienteemailfilter_Jsonclick ;
      private string edtavCclienteemail_Internalname ;
      private string edtavCclienteemail_Jsonclick ;
      private string divPaisclienteidfiltercontainer_Internalname ;
      private string lblLblpaisclienteidfilter_Internalname ;
      private string lblLblpaisclienteidfilter_Jsonclick ;
      private string edtavCpaisclienteid_Internalname ;
      private string edtavCpaisclienteid_Jsonclick ;
      private string divCartaopontosclienteidfiltercontainer_Internalname ;
      private string lblLblcartaopontosclienteidfilter_Internalname ;
      private string lblLblcartaopontosclienteidfilter_Jsonclick ;
      private string edtavCcartaopontosclienteid_Internalname ;
      private string edtavCcartaopontosclienteid_Jsonclick ;
      private string divGridtable_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtntoggle_Internalname ;
      private string bttBtntoggle_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavLinkselection_Internalname ;
      private string edtClienteId_Internalname ;
      private string edtClienteNome_Internalname ;
      private string A46ClienteTelefone ;
      private string edtClienteTelefone_Internalname ;
      private string edtPaisClienteId_Internalname ;
      private string edtCartaoPontosClienteId_Internalname ;
      private string scmdbuf ;
      private string lV8cClienteTelefone ;
      private string AV13ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_74_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtClienteId_Jsonclick ;
      private string edtClienteNome_Link ;
      private string edtClienteNome_Jsonclick ;
      private string gxphoneLink ;
      private string edtClienteTelefone_Jsonclick ;
      private string edtPaisClienteId_Jsonclick ;
      private string edtCartaoPontosClienteId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_74_Refreshing=false ;
      private bool n48CartaoPontosClienteId ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private string AV7cClienteNome ;
      private string AV9cClienteEmail ;
      private string AV16Linkselection_GXI ;
      private string A44ClienteNome ;
      private string lV7cClienteNome ;
      private string lV9cClienteEmail ;
      private string A47ClienteEmail ;
      private string AV5LinkSelection ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] H000B2_A47ClienteEmail ;
      private short[] H000B2_A48CartaoPontosClienteId ;
      private bool[] H000B2_n48CartaoPontosClienteId ;
      private short[] H000B2_A11PaisClienteId ;
      private string[] H000B2_A46ClienteTelefone ;
      private string[] H000B2_A44ClienteNome ;
      private short[] H000B2_A43ClienteId ;
      private long[] H000B3_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pClienteId ;
      private GXWebForm Form ;
   }

   public class gx00b0__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H000B2( IGxContext context ,
                                             string AV7cClienteNome ,
                                             string AV8cClienteTelefone ,
                                             string AV9cClienteEmail ,
                                             short AV10cPaisClienteId ,
                                             short AV11cCartaoPontosClienteId ,
                                             string A44ClienteNome ,
                                             string A46ClienteTelefone ,
                                             string A47ClienteEmail ,
                                             short A11PaisClienteId ,
                                             short A48CartaoPontosClienteId ,
                                             short AV6cClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[9];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [ClienteEmail], [CartaoPontosClienteId], [PaisClienteId], [ClienteTelefone], [ClienteNome], [ClienteId]";
         sFromString = " FROM [Cliente]";
         sOrderString = "";
         AddWhere(sWhereString, "([ClienteId] >= @AV6cClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cClienteNome)) )
         {
            AddWhere(sWhereString, "([ClienteNome] like @lV7cClienteNome)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cClienteTelefone)) )
         {
            AddWhere(sWhereString, "([ClienteTelefone] like @lV8cClienteTelefone)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cClienteEmail)) )
         {
            AddWhere(sWhereString, "([ClienteEmail] like @lV9cClienteEmail)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cPaisClienteId) )
         {
            AddWhere(sWhereString, "([PaisClienteId] >= @AV10cPaisClienteId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cCartaoPontosClienteId) )
         {
            AddWhere(sWhereString, "([CartaoPontosClienteId] >= @AV11cCartaoPontosClienteId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         sOrderString += " ORDER BY [ClienteId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H000B3( IGxContext context ,
                                             string AV7cClienteNome ,
                                             string AV8cClienteTelefone ,
                                             string AV9cClienteEmail ,
                                             short AV10cPaisClienteId ,
                                             short AV11cCartaoPontosClienteId ,
                                             string A44ClienteNome ,
                                             string A46ClienteTelefone ,
                                             string A47ClienteEmail ,
                                             short A11PaisClienteId ,
                                             short A48CartaoPontosClienteId ,
                                             short AV6cClienteId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[6];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Cliente]";
         AddWhere(sWhereString, "([ClienteId] >= @AV6cClienteId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cClienteNome)) )
         {
            AddWhere(sWhereString, "([ClienteNome] like @lV7cClienteNome)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cClienteTelefone)) )
         {
            AddWhere(sWhereString, "([ClienteTelefone] like @lV8cClienteTelefone)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV9cClienteEmail)) )
         {
            AddWhere(sWhereString, "([ClienteEmail] like @lV9cClienteEmail)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cPaisClienteId) )
         {
            AddWhere(sWhereString, "([PaisClienteId] >= @AV10cPaisClienteId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cCartaoPontosClienteId) )
         {
            AddWhere(sWhereString, "([CartaoPontosClienteId] >= @AV11cCartaoPontosClienteId)");
         }
         else
         {
            GXv_int3[5] = 1;
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
                     return conditional_H000B2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
               case 1 :
                     return conditional_H000B3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] );
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
          Object[] prmH000B2;
          prmH000B2 = new Object[] {
          new ParDef("@AV6cClienteId",GXType.Int16,4,0) ,
          new ParDef("@lV7cClienteNome",GXType.NVarChar,40,0) ,
          new ParDef("@lV8cClienteTelefone",GXType.NChar,20,0) ,
          new ParDef("@lV9cClienteEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV10cPaisClienteId",GXType.Int16,4,0) ,
          new ParDef("@AV11cCartaoPontosClienteId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH000B3;
          prmH000B3 = new Object[] {
          new ParDef("@AV6cClienteId",GXType.Int16,4,0) ,
          new ParDef("@lV7cClienteNome",GXType.NVarChar,40,0) ,
          new ParDef("@lV8cClienteTelefone",GXType.NChar,20,0) ,
          new ParDef("@lV9cClienteEmail",GXType.NVarChar,100,0) ,
          new ParDef("@AV10cPaisClienteId",GXType.Int16,4,0) ,
          new ParDef("@AV11cCartaoPontosClienteId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000B2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000B2,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H000B3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000B3,1, GxCacheFrequency.OFF ,false,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((short[]) buf[3])[0] = rslt.getShort(3);
                ((string[]) buf[4])[0] = rslt.getString(4, 20);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((short[]) buf[6])[0] = rslt.getShort(6);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
