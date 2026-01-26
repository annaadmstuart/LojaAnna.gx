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
   public class gx0060 : GXDataArea
   {
      public gx0060( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public gx0060( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( out short aP0_pProdutoId )
      {
         this.AV13pProdutoId = 0 ;
         executePrivate();
         aP0_pProdutoId=this.AV13pProdutoId;
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
            gxfirstwebparm = GetFirstPar( "pProdutoId");
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
               gxfirstwebparm = GetFirstPar( "pProdutoId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "pProdutoId");
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
               AV13pProdutoId = (short)(NumberUtil.Val( gxfirstwebparm, "."));
               AssignAttri("", false, "AV13pProdutoId", StringUtil.LTrimStr( (decimal)(AV13pProdutoId), 4, 0));
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
         nRC_GXsfl_84 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_84"), "."));
         nGXsfl_84_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_84_idx"), "."));
         sGXsfl_84_idx = GetPar( "sGXsfl_84_idx");
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
         AV6cProdutoId = (short)(NumberUtil.Val( GetPar( "cProdutoId"), "."));
         AV7cProdutoNome = GetPar( "cProdutoNome");
         AV8cProdutoDescricao = GetPar( "cProdutoDescricao");
         AV9cProdutoPreco = NumberUtil.Val( GetPar( "cProdutoPreco"), ".");
         AV10cVendedorProdutoId = (short)(NumberUtil.Val( GetPar( "cVendedorProdutoId"), "."));
         AV11cPaisProdutoId = (short)(NumberUtil.Val( GetPar( "cPaisProdutoId"), "."));
         AV12cFornecedorProdutoId = (short)(NumberUtil.Val( GetPar( "cFornecedorProdutoId"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( subGrid1_Rows, AV6cProdutoId, AV7cProdutoNome, AV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId) ;
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
         PA072( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START072( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pProdutoId,4,0))}, new string[] {"pProdutoId"}) +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUTONOME", AV7cProdutoNome);
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUTODESCRICAO", AV8cProdutoDescricao);
         GxWebStd.gx_hidden_field( context, "GXH_vCPRODUTOPRECO", StringUtil.LTrim( StringUtil.NToC( AV9cProdutoPreco, 10, 2, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCVENDEDORPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cVendedorProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPAISPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cPaisProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCFORNECEDORPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cFornecedorProdutoId), 4, 0, ".", "")));
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_84", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_84), 8, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPPRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13pProdutoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nFirstRecordOnPage), 15, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "ADVANCEDCONTAINER_Class", StringUtil.RTrim( divAdvancedcontainer_Class));
         GxWebStd.gx_hidden_field( context, "BTNTOGGLE_Class", StringUtil.RTrim( bttBtntoggle_Class));
         GxWebStd.gx_hidden_field( context, "PRODUTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divProdutoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUTONOMEFILTERCONTAINER_Class", StringUtil.RTrim( divProdutonomefiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUTODESCRICAOFILTERCONTAINER_Class", StringUtil.RTrim( divProdutodescricaofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PRODUTOPRECOFILTERCONTAINER_Class", StringUtil.RTrim( divProdutoprecofiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "VENDEDORPRODUTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divVendedorprodutoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "PAISPRODUTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divPaisprodutoidfiltercontainer_Class));
         GxWebStd.gx_hidden_field( context, "FORNECEDORPRODUTOIDFILTERCONTAINER_Class", StringUtil.RTrim( divFornecedorprodutoidfiltercontainer_Class));
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
            WE072( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT072( ) ;
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
         return formatLink("gx0060.aspx", new object[] {UrlEncode(StringUtil.LTrimStr(AV13pProdutoId,4,0))}, new string[] {"pProdutoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Gx0060" ;
      }

      public override string GetPgmdesc( )
      {
         return "Selection List Produto" ;
      }

      protected void WB070( )
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
            GxWebStd.gx_div_start( context, divProdutoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divProdutoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprodutoidfilter_Internalname, "Produto", "", "", lblLblprodutoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e11071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprodutoid_Internalname, "Produto", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 16,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprodutoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV6cProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCprodutoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV6cProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV6cProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,16);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprodutoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprodutoid_Visible, edtavCprodutoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divProdutonomefiltercontainer_Internalname, 1, 0, "px", 0, "px", divProdutonomefiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprodutonomefilter_Internalname, "Produto", "", "", lblLblprodutonomefilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e12071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprodutonome_Internalname, "Produto", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 26,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprodutonome_Internalname, AV7cProdutoNome, StringUtil.RTrim( context.localUtil.Format( AV7cProdutoNome, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,26);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprodutonome_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprodutonome_Visible, edtavCprodutonome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divProdutodescricaofiltercontainer_Internalname, 1, 0, "px", 0, "px", divProdutodescricaofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprodutodescricaofilter_Internalname, "Descrição", "", "", lblLblprodutodescricaofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e13071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprodutodescricao_Internalname, "Descrição", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 36,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprodutodescricao_Internalname, AV8cProdutoDescricao, StringUtil.RTrim( context.localUtil.Format( AV8cProdutoDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,36);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprodutodescricao_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprodutodescricao_Visible, edtavCprodutodescricao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divProdutoprecofiltercontainer_Internalname, 1, 0, "px", 0, "px", divProdutoprecofiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblprodutoprecofilter_Internalname, "Preço", "", "", lblLblprodutoprecofilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e14071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCprodutopreco_Internalname, "Preço", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCprodutopreco_Internalname, StringUtil.LTrim( StringUtil.NToC( AV9cProdutoPreco, 10, 2, ".", "")), StringUtil.LTrim( ((edtavCprodutopreco_Enabled!=0) ? context.localUtil.Format( AV9cProdutoPreco, "ZZZZZZ9.99") : context.localUtil.Format( AV9cProdutoPreco, "ZZZZZZ9.99"))), TempTags+" onchange=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, ',','.','2');"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCprodutopreco_Jsonclick, 0, "Attribute", "", "", "", "", edtavCprodutopreco_Visible, edtavCprodutopreco_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divVendedorprodutoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divVendedorprodutoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblvendedorprodutoidfilter_Internalname, "Vendedor ", "", "", lblLblvendedorprodutoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e15071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCvendedorprodutoid_Internalname, "Vendedor ", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCvendedorprodutoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV10cVendedorProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCvendedorprodutoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV10cVendedorProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV10cVendedorProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCvendedorprodutoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCvendedorprodutoid_Visible, edtavCvendedorprodutoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divPaisprodutoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divPaisprodutoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblpaisprodutoidfilter_Internalname, "País", "", "", lblLblpaisprodutoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e16071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpaisprodutoid_Internalname, "País", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpaisprodutoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11cPaisProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCpaisprodutoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV11cPaisProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV11cPaisProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,66);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpaisprodutoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpaisprodutoid_Visible, edtavCpaisprodutoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            GxWebStd.gx_div_start( context, divFornecedorprodutoidfiltercontainer_Internalname, 1, 0, "px", 0, "px", divFornecedorprodutoidfiltercontainer_Class, "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblLblfornecedorprodutoidfilter_Internalname, "Fornecedor ", "", "", lblLblfornecedorprodutoidfilter_Jsonclick, "'"+""+"'"+",false,"+"'"+"e17071_client"+"'", "", "WWAdvancedLabel WWFilterLabel", 7, "", 1, 1, 0, 1, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 WWFiltersCell", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "left", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCfornecedorprodutoid_Internalname, "Fornecedor ", "col-sm-3 AttributeLabel", 0, true, "");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_84_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCfornecedorprodutoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12cFornecedorProdutoId), 4, 0, ".", "")), StringUtil.LTrim( ((edtavCfornecedorprodutoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV12cFornecedorProdutoId), "ZZZ9") : context.localUtil.Format( (decimal)(AV12cFornecedorProdutoId), "ZZZ9"))), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCfornecedorprodutoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCfornecedorprodutoid_Visible, edtavCfornecedorprodutoid_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Gx0060.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 81,'',false,'',0)\"";
            ClassString = bttBtntoggle_Class;
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtntoggle_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "|||", bttBtntoggle_Jsonclick, 7, "|||", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"e18071_client"+"'", TempTags, "", 2, "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl84( ) ;
         }
         if ( wbEnd == 84 )
         {
            wbEnd = 0;
            nRC_GXsfl_84 = (int)(nGXsfl_84_idx-1);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 97,'',false,'',0)\"";
            ClassString = "BtnCancel";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(84), 2, 0)+","+"null"+");", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Gx0060.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 84 )
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

      protected void START072( )
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
            Form.Meta.addItem("description", "Selection List Produto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP070( ) ;
      }

      protected void WS072( )
      {
         START072( ) ;
         EVT072( ) ;
      }

      protected void EVT072( )
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
                              nGXsfl_84_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
                              SubsflControlProps_842( ) ;
                              AV5LinkSelection = cgiGet( edtavLinkselection_Internalname);
                              AssignProp("", false, edtavLinkselection_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.convertURL( context.PathToRelativeUrl( AV5LinkSelection))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtavLinkselection_Internalname, "SrcSet", context.GetImageSrcSet( AV5LinkSelection), true);
                              A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ","));
                              A20ProdutoNome = cgiGet( edtProdutoNome_Internalname);
                              A21ProdutoDescricao = cgiGet( edtProdutoDescricao_Internalname);
                              A22ProdutoPreco = context.localUtil.CToN( cgiGet( edtProdutoPreco_Internalname), ".", ",");
                              A23ProdutoImagem = cgiGet( edtProdutoImagem_Internalname);
                              AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_84_Refreshing);
                              AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
                              A24VendedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtVendedorProdutoId_Internalname), ".", ","));
                              A26PaisProdutoId = (short)(context.localUtil.CToN( cgiGet( edtPaisProdutoId_Internalname), ".", ","));
                              A28FornecedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtFornecedorProdutoId_Internalname), ".", ","));
                              A30CategoriaProdutoId = (short)(context.localUtil.CToN( cgiGet( edtCategoriaProdutoId_Internalname), ".", ","));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E19072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Load */
                                    E20072 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Cprodutoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUTOID"), ".", ",") != Convert.ToDecimal( AV6cProdutoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprodutonome Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUTONOME"), AV7cProdutoNome) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprodutodescricao Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUTODESCRICAO"), AV8cProdutoDescricao) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cprodutopreco Changed */
                                       if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUTOPRECO"), ".", ",") != AV9cProdutoPreco )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cvendedorprodutoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENDEDORPRODUTOID"), ".", ",") != Convert.ToDecimal( AV10cVendedorProdutoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpaisprodutoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAISPRODUTOID"), ".", ",") != Convert.ToDecimal( AV11cPaisProdutoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cfornecedorprodutoid Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFORNECEDORPRODUTOID"), ".", ",") != Convert.ToDecimal( AV12cFornecedorProdutoId )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                          /* Execute user event: Enter */
                                          E21072 ();
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

      protected void WE072( )
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

      protected void PA072( )
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
         SubsflControlProps_842( ) ;
         while ( nGXsfl_84_idx <= nRC_GXsfl_84 )
         {
            sendrow_842( ) ;
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxgrGrid1_refresh( int subGrid1_Rows ,
                                        short AV6cProdutoId ,
                                        string AV7cProdutoNome ,
                                        string AV8cProdutoDescricao ,
                                        decimal AV9cProdutoPreco ,
                                        short AV10cVendedorProdutoId ,
                                        short AV11cPaisProdutoId ,
                                        short AV12cFornecedorProdutoId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF072( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUTOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PRODUTOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")));
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
         RF072( ) ;
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

      protected void RF072( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 84;
         nGXsfl_84_idx = 1;
         sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
         SubsflControlProps_842( ) ;
         bGXsfl_84_Refreshing = true;
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
            SubsflControlProps_842( ) ;
            GXPagingFrom2 = (int)(GRID1_nFirstRecordOnPage);
            GXPagingTo2 = (int)(subGrid1_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV7cProdutoNome ,
                                                 AV8cProdutoDescricao ,
                                                 AV9cProdutoPreco ,
                                                 AV10cVendedorProdutoId ,
                                                 AV11cPaisProdutoId ,
                                                 AV12cFornecedorProdutoId ,
                                                 A20ProdutoNome ,
                                                 A21ProdutoDescricao ,
                                                 A22ProdutoPreco ,
                                                 A24VendedorProdutoId ,
                                                 A26PaisProdutoId ,
                                                 A28FornecedorProdutoId ,
                                                 AV6cProdutoId } ,
                                                 new int[]{
                                                 TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                                 }
            });
            lV7cProdutoNome = StringUtil.Concat( StringUtil.RTrim( AV7cProdutoNome), "%", "");
            lV8cProdutoDescricao = StringUtil.Concat( StringUtil.RTrim( AV8cProdutoDescricao), "%", "");
            /* Using cursor H00072 */
            pr_default.execute(0, new Object[] {AV6cProdutoId, lV7cProdutoNome, lV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_84_idx = 1;
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( GRID1_nCurrentRecord < subGrid1_fnc_Recordsperpage( ) ) ) )
            {
               A30CategoriaProdutoId = H00072_A30CategoriaProdutoId[0];
               A28FornecedorProdutoId = H00072_A28FornecedorProdutoId[0];
               A26PaisProdutoId = H00072_A26PaisProdutoId[0];
               A24VendedorProdutoId = H00072_A24VendedorProdutoId[0];
               A40000ProdutoImagem_GXI = H00072_A40000ProdutoImagem_GXI[0];
               AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
               A22ProdutoPreco = H00072_A22ProdutoPreco[0];
               A21ProdutoDescricao = H00072_A21ProdutoDescricao[0];
               A20ProdutoNome = H00072_A20ProdutoNome[0];
               A19ProdutoId = H00072_A19ProdutoId[0];
               A23ProdutoImagem = H00072_A23ProdutoImagem[0];
               AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_84_Refreshing);
               AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
               /* Execute user event: Load */
               E20072 ();
               pr_default.readNext(0);
            }
            GRID1_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID1_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID1_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 84;
            WB070( ) ;
         }
         bGXsfl_84_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes072( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PRODUTOID"+"_"+sGXsfl_84_idx, GetSecureSignedToken( sGXsfl_84_idx, context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9"), context));
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
                                              AV7cProdutoNome ,
                                              AV8cProdutoDescricao ,
                                              AV9cProdutoPreco ,
                                              AV10cVendedorProdutoId ,
                                              AV11cPaisProdutoId ,
                                              AV12cFornecedorProdutoId ,
                                              A20ProdutoNome ,
                                              A21ProdutoDescricao ,
                                              A22ProdutoPreco ,
                                              A24VendedorProdutoId ,
                                              A26PaisProdutoId ,
                                              A28FornecedorProdutoId ,
                                              AV6cProdutoId } ,
                                              new int[]{
                                              TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DECIMAL, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT
                                              }
         });
         lV7cProdutoNome = StringUtil.Concat( StringUtil.RTrim( AV7cProdutoNome), "%", "");
         lV8cProdutoDescricao = StringUtil.Concat( StringUtil.RTrim( AV8cProdutoDescricao), "%", "");
         /* Using cursor H00073 */
         pr_default.execute(1, new Object[] {AV6cProdutoId, lV7cProdutoNome, lV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId});
         GRID1_nRecordCount = H00073_AGRID1_nRecordCount[0];
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProdutoId, AV7cProdutoNome, AV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProdutoId, AV7cProdutoNome, AV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProdutoId, AV7cProdutoNome, AV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProdutoId, AV7cProdutoNome, AV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId) ;
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
            gxgrGrid1_refresh( subGrid1_Rows, AV6cProdutoId, AV7cProdutoNome, AV8cProdutoDescricao, AV9cProdutoPreco, AV10cVendedorProdutoId, AV11cPaisProdutoId, AV12cFornecedorProdutoId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP070( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E19072 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_84 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_84"), ".", ","));
            GRID1_nFirstRecordOnPage = (long)(context.localUtil.CToN( cgiGet( "GRID1_nFirstRecordOnPage"), ".", ","));
            GRID1_nEOF = (short)(context.localUtil.CToN( cgiGet( "GRID1_nEOF"), ".", ","));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprodutoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprodutoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUTOID");
               GX_FocusControl = edtavCprodutoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV6cProdutoId = 0;
               AssignAttri("", false, "AV6cProdutoId", StringUtil.LTrimStr( (decimal)(AV6cProdutoId), 4, 0));
            }
            else
            {
               AV6cProdutoId = (short)(context.localUtil.CToN( cgiGet( edtavCprodutoid_Internalname), ".", ","));
               AssignAttri("", false, "AV6cProdutoId", StringUtil.LTrimStr( (decimal)(AV6cProdutoId), 4, 0));
            }
            AV7cProdutoNome = cgiGet( edtavCprodutonome_Internalname);
            AssignAttri("", false, "AV7cProdutoNome", AV7cProdutoNome);
            AV8cProdutoDescricao = cgiGet( edtavCprodutodescricao_Internalname);
            AssignAttri("", false, "AV8cProdutoDescricao", AV8cProdutoDescricao);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCprodutopreco_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCprodutopreco_Internalname), ".", ",") > 9999999.99m ) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPRODUTOPRECO");
               GX_FocusControl = edtavCprodutopreco_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV9cProdutoPreco = 0;
               AssignAttri("", false, "AV9cProdutoPreco", StringUtil.LTrimStr( AV9cProdutoPreco, 10, 2));
            }
            else
            {
               AV9cProdutoPreco = context.localUtil.CToN( cgiGet( edtavCprodutopreco_Internalname), ".", ",");
               AssignAttri("", false, "AV9cProdutoPreco", StringUtil.LTrimStr( AV9cProdutoPreco, 10, 2));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCvendedorprodutoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCvendedorprodutoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCVENDEDORPRODUTOID");
               GX_FocusControl = edtavCvendedorprodutoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV10cVendedorProdutoId = 0;
               AssignAttri("", false, "AV10cVendedorProdutoId", StringUtil.LTrimStr( (decimal)(AV10cVendedorProdutoId), 4, 0));
            }
            else
            {
               AV10cVendedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtavCvendedorprodutoid_Internalname), ".", ","));
               AssignAttri("", false, "AV10cVendedorProdutoId", StringUtil.LTrimStr( (decimal)(AV10cVendedorProdutoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCpaisprodutoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCpaisprodutoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCPAISPRODUTOID");
               GX_FocusControl = edtavCpaisprodutoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV11cPaisProdutoId = 0;
               AssignAttri("", false, "AV11cPaisProdutoId", StringUtil.LTrimStr( (decimal)(AV11cPaisProdutoId), 4, 0));
            }
            else
            {
               AV11cPaisProdutoId = (short)(context.localUtil.CToN( cgiGet( edtavCpaisprodutoid_Internalname), ".", ","));
               AssignAttri("", false, "AV11cPaisProdutoId", StringUtil.LTrimStr( (decimal)(AV11cPaisProdutoId), 4, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCfornecedorprodutoid_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCfornecedorprodutoid_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCFORNECEDORPRODUTOID");
               GX_FocusControl = edtavCfornecedorprodutoid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV12cFornecedorProdutoId = 0;
               AssignAttri("", false, "AV12cFornecedorProdutoId", StringUtil.LTrimStr( (decimal)(AV12cFornecedorProdutoId), 4, 0));
            }
            else
            {
               AV12cFornecedorProdutoId = (short)(context.localUtil.CToN( cgiGet( edtavCfornecedorprodutoid_Internalname), ".", ","));
               AssignAttri("", false, "AV12cFornecedorProdutoId", StringUtil.LTrimStr( (decimal)(AV12cFornecedorProdutoId), 4, 0));
            }
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUTOID"), ".", ",") != Convert.ToDecimal( AV6cProdutoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUTONOME"), AV7cProdutoNome) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPRODUTODESCRICAO"), AV8cProdutoDescricao) != 0 )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( context.localUtil.CToN( cgiGet( "GXH_vCPRODUTOPRECO"), ".", ",") != AV9cProdutoPreco )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCVENDEDORPRODUTOID"), ".", ",") != Convert.ToDecimal( AV10cVendedorProdutoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCPAISPRODUTOID"), ".", ",") != Convert.ToDecimal( AV11cPaisProdutoId )) )
            {
               GRID1_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vCFORNECEDORPRODUTOID"), ".", ",") != Convert.ToDecimal( AV12cFornecedorProdutoId )) )
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
         E19072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E19072( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Caption = StringUtil.Format( "Selection List %1", "Produto", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         AV14ADVANCED_LABEL_TEMPLATE = "%1 <strong>%2</strong>";
      }

      private void E20072( )
      {
         /* Load Routine */
         returnInSub = false;
         edtavLinkselection_gximage = "selectRow";
         AV5LinkSelection = context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( ));
         AssignAttri("", false, edtavLinkselection_Internalname, AV5LinkSelection);
         AV17Linkselection_GXI = GXDbFile.PathToUrl( context.GetImagePath( "3914535b-0c03-44c5-9538-906a99cdd2bc", "", context.GetTheme( )));
         sendrow_842( ) ;
         GRID1_nCurrentRecord = (long)(GRID1_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_84_Refreshing )
         {
            DoAjaxLoad(84, Grid1Row);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E21072 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E21072( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV13pProdutoId = A19ProdutoId;
         AssignAttri("", false, "AV13pProdutoId", StringUtil.LTrimStr( (decimal)(AV13pProdutoId), 4, 0));
         context.setWebReturnParms(new Object[] {(short)AV13pProdutoId});
         context.setWebReturnParmsMetadata(new Object[] {"AV13pProdutoId"});
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
         AV13pProdutoId = Convert.ToInt16(getParm(obj,0));
         AssignAttri("", false, "AV13pProdutoId", StringUtil.LTrimStr( (decimal)(AV13pProdutoId), 4, 0));
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
         PA072( ) ;
         WS072( ) ;
         WE072( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916514537", true, true);
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
         context.AddJavascriptSource("gx0060.js", "?202582916514537", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_idx;
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_84_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_84_idx;
         edtProdutoDescricao_Internalname = "PRODUTODESCRICAO_"+sGXsfl_84_idx;
         edtProdutoPreco_Internalname = "PRODUTOPRECO_"+sGXsfl_84_idx;
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM_"+sGXsfl_84_idx;
         edtVendedorProdutoId_Internalname = "VENDEDORPRODUTOID_"+sGXsfl_84_idx;
         edtPaisProdutoId_Internalname = "PAISPRODUTOID_"+sGXsfl_84_idx;
         edtFornecedorProdutoId_Internalname = "FORNECEDORPRODUTOID_"+sGXsfl_84_idx;
         edtCategoriaProdutoId_Internalname = "CATEGORIAPRODUTOID_"+sGXsfl_84_idx;
      }

      protected void SubsflControlProps_fel_842( )
      {
         edtavLinkselection_Internalname = "vLINKSELECTION_"+sGXsfl_84_fel_idx;
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_84_fel_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_84_fel_idx;
         edtProdutoDescricao_Internalname = "PRODUTODESCRICAO_"+sGXsfl_84_fel_idx;
         edtProdutoPreco_Internalname = "PRODUTOPRECO_"+sGXsfl_84_fel_idx;
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM_"+sGXsfl_84_fel_idx;
         edtVendedorProdutoId_Internalname = "VENDEDORPRODUTOID_"+sGXsfl_84_fel_idx;
         edtPaisProdutoId_Internalname = "PAISPRODUTOID_"+sGXsfl_84_fel_idx;
         edtFornecedorProdutoId_Internalname = "FORNECEDORPRODUTOID_"+sGXsfl_84_fel_idx;
         edtCategoriaProdutoId_Internalname = "CATEGORIAPRODUTOID_"+sGXsfl_84_fel_idx;
      }

      protected void sendrow_842( )
      {
         SubsflControlProps_842( ) ;
         WB070( ) ;
         if ( ( 10 * 1 == 0 ) || ( nGXsfl_84_idx <= subGrid1_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_84_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_84_idx+"\">") ;
            }
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            edtavLinkselection_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtavLinkselection_Internalname, "Link", edtavLinkselection_Link, !bGXsfl_84_Refreshing);
            ClassString = "SelectionAttribute" + " " + ((StringUtil.StrCmp(edtavLinkselection_gximage, "")==0) ? "" : "GX_Image_"+edtavLinkselection_gximage+"_Class");
            StyleString = "";
            AV5LinkSelection_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection))&&String.IsNullOrEmpty(StringUtil.RTrim( AV17Linkselection_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( AV5LinkSelection)) ? AV17Linkselection_GXI : context.PathToRelativeUrl( AV5LinkSelection));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtavLinkselection_Internalname,(string)sImgUrl,(string)edtavLinkselection_Link,(string)"",(string)"",context.GetTheme( ),(short)-1,(short)1,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWActionColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)AV5LinkSelection_IsBlob,(bool)false,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "DescriptionAttribute";
            edtProdutoNome_Link = "javascript:gx.popup.gxReturn(["+"'"+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")))+"'"+"]);";
            AssignProp("", false, edtProdutoNome_Internalname, "Link", edtProdutoNome_Link, !bGXsfl_84_Refreshing);
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoNome_Internalname,(string)A20ProdutoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtProdutoNome_Link,(string)"",(string)"",(string)"",(string)edtProdutoNome_Jsonclick,(short)0,(string)"DescriptionAttribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoDescricao_Internalname,(string)A21ProdutoDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"left",(bool)true,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoPreco_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoPreco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
            }
            /* Static Bitmap Variable */
            ClassString = "ImageAttribute";
            StyleString = "";
            A23ProdutoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000ProdutoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)));
            sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40000ProdutoImagem_GXI : context.PathToRelativeUrl( A23ProdutoImagem));
            Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoImagem_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn OptionalColumn",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A23ProdutoImagem_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVendedorProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A24VendedorProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A24VendedorProdutoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVendedorProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPaisProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A26PaisProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A26PaisProdutoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPaisProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtFornecedorProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FornecedorProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A28FornecedorProdutoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtFornecedorProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            /* Subfile cell */
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A30CategoriaProdutoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn OptionalColumn",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)84,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
            send_integrity_lvl_hashes072( ) ;
            Grid1Container.AddRow(Grid1Row);
            nGXsfl_84_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_84_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_84_idx+1);
            sGXsfl_84_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_84_idx), 4, 0), 4, "0");
            SubsflControlProps_842( ) ;
         }
         /* End function sendrow_842 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl84( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"84\">") ;
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
            context.SendWebValue( "Produto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"DescriptionAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Produto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Preço") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Imagem") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "País") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
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
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", A20ProdutoNome);
            Grid1Column.AddObjectProperty("Link", StringUtil.RTrim( edtProdutoNome_Link));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", A21ProdutoDescricao);
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A23ProdutoImagem));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A24VendedorProdutoId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A26PaisProdutoId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A28FornecedorProdutoId), 4, 0, ".", "")));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A30CategoriaProdutoId), 4, 0, ".", "")));
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
         lblLblprodutoidfilter_Internalname = "LBLPRODUTOIDFILTER";
         edtavCprodutoid_Internalname = "vCPRODUTOID";
         divProdutoidfiltercontainer_Internalname = "PRODUTOIDFILTERCONTAINER";
         lblLblprodutonomefilter_Internalname = "LBLPRODUTONOMEFILTER";
         edtavCprodutonome_Internalname = "vCPRODUTONOME";
         divProdutonomefiltercontainer_Internalname = "PRODUTONOMEFILTERCONTAINER";
         lblLblprodutodescricaofilter_Internalname = "LBLPRODUTODESCRICAOFILTER";
         edtavCprodutodescricao_Internalname = "vCPRODUTODESCRICAO";
         divProdutodescricaofiltercontainer_Internalname = "PRODUTODESCRICAOFILTERCONTAINER";
         lblLblprodutoprecofilter_Internalname = "LBLPRODUTOPRECOFILTER";
         edtavCprodutopreco_Internalname = "vCPRODUTOPRECO";
         divProdutoprecofiltercontainer_Internalname = "PRODUTOPRECOFILTERCONTAINER";
         lblLblvendedorprodutoidfilter_Internalname = "LBLVENDEDORPRODUTOIDFILTER";
         edtavCvendedorprodutoid_Internalname = "vCVENDEDORPRODUTOID";
         divVendedorprodutoidfiltercontainer_Internalname = "VENDEDORPRODUTOIDFILTERCONTAINER";
         lblLblpaisprodutoidfilter_Internalname = "LBLPAISPRODUTOIDFILTER";
         edtavCpaisprodutoid_Internalname = "vCPAISPRODUTOID";
         divPaisprodutoidfiltercontainer_Internalname = "PAISPRODUTOIDFILTERCONTAINER";
         lblLblfornecedorprodutoidfilter_Internalname = "LBLFORNECEDORPRODUTOIDFILTER";
         edtavCfornecedorprodutoid_Internalname = "vCFORNECEDORPRODUTOID";
         divFornecedorprodutoidfiltercontainer_Internalname = "FORNECEDORPRODUTOIDFILTERCONTAINER";
         divAdvancedcontainer_Internalname = "ADVANCEDCONTAINER";
         bttBtntoggle_Internalname = "BTNTOGGLE";
         edtavLinkselection_Internalname = "vLINKSELECTION";
         edtProdutoId_Internalname = "PRODUTOID";
         edtProdutoNome_Internalname = "PRODUTONOME";
         edtProdutoDescricao_Internalname = "PRODUTODESCRICAO";
         edtProdutoPreco_Internalname = "PRODUTOPRECO";
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM";
         edtVendedorProdutoId_Internalname = "VENDEDORPRODUTOID";
         edtPaisProdutoId_Internalname = "PAISPRODUTOID";
         edtFornecedorProdutoId_Internalname = "FORNECEDORPRODUTOID";
         edtCategoriaProdutoId_Internalname = "CATEGORIAPRODUTOID";
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
         edtCategoriaProdutoId_Jsonclick = "";
         edtFornecedorProdutoId_Jsonclick = "";
         edtPaisProdutoId_Jsonclick = "";
         edtVendedorProdutoId_Jsonclick = "";
         edtProdutoPreco_Jsonclick = "";
         edtProdutoDescricao_Jsonclick = "";
         edtProdutoNome_Jsonclick = "";
         edtProdutoNome_Link = "";
         edtProdutoId_Jsonclick = "";
         edtavLinkselection_gximage = "";
         edtavLinkselection_Link = "";
         subGrid1_Class = "PromptGrid";
         subGrid1_Backcolorstyle = 0;
         edtavCfornecedorprodutoid_Jsonclick = "";
         edtavCfornecedorprodutoid_Enabled = 1;
         edtavCfornecedorprodutoid_Visible = 1;
         edtavCpaisprodutoid_Jsonclick = "";
         edtavCpaisprodutoid_Enabled = 1;
         edtavCpaisprodutoid_Visible = 1;
         edtavCvendedorprodutoid_Jsonclick = "";
         edtavCvendedorprodutoid_Enabled = 1;
         edtavCvendedorprodutoid_Visible = 1;
         edtavCprodutopreco_Jsonclick = "";
         edtavCprodutopreco_Enabled = 1;
         edtavCprodutopreco_Visible = 1;
         edtavCprodutodescricao_Jsonclick = "";
         edtavCprodutodescricao_Enabled = 1;
         edtavCprodutodescricao_Visible = 1;
         edtavCprodutonome_Jsonclick = "";
         edtavCprodutonome_Enabled = 1;
         edtavCprodutonome_Visible = 1;
         edtavCprodutoid_Jsonclick = "";
         edtavCprodutoid_Enabled = 1;
         edtavCprodutoid_Visible = 1;
         divFornecedorprodutoidfiltercontainer_Class = "AdvancedContainerItem";
         divPaisprodutoidfiltercontainer_Class = "AdvancedContainerItem";
         divVendedorprodutoidfiltercontainer_Class = "AdvancedContainerItem";
         divProdutoprecofiltercontainer_Class = "AdvancedContainerItem";
         divProdutodescricaofiltercontainer_Class = "AdvancedContainerItem";
         divProdutonomefiltercontainer_Class = "AdvancedContainerItem";
         divProdutoidfiltercontainer_Class = "AdvancedContainerItem";
         bttBtntoggle_Class = "BtnToggle";
         divAdvancedcontainer_Class = "AdvancedContainerVisible";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Selection List Produto";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProdutoId',fld:'vCPRODUTOID',pic:'ZZZ9'},{av:'AV7cProdutoNome',fld:'vCPRODUTONOME',pic:''},{av:'AV8cProdutoDescricao',fld:'vCPRODUTODESCRICAO',pic:''},{av:'AV9cProdutoPreco',fld:'vCPRODUTOPRECO',pic:'ZZZZZZ9.99'},{av:'AV10cVendedorProdutoId',fld:'vCVENDEDORPRODUTOID',pic:'ZZZ9'},{av:'AV11cPaisProdutoId',fld:'vCPAISPRODUTOID',pic:'ZZZ9'},{av:'AV12cFornecedorProdutoId',fld:'vCFORNECEDORPRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'TOGGLE'","{handler:'E18071',iparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]");
         setEventMetadata("'TOGGLE'",",oparms:[{av:'divAdvancedcontainer_Class',ctrl:'ADVANCEDCONTAINER',prop:'Class'},{ctrl:'BTNTOGGLE',prop:'Class'}]}");
         setEventMetadata("LBLPRODUTOIDFILTER.CLICK","{handler:'E11071',iparms:[{av:'divProdutoidfiltercontainer_Class',ctrl:'PRODUTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUTOIDFILTER.CLICK",",oparms:[{av:'divProdutoidfiltercontainer_Class',ctrl:'PRODUTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCprodutoid_Visible',ctrl:'vCPRODUTOID',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUTONOMEFILTER.CLICK","{handler:'E12071',iparms:[{av:'divProdutonomefiltercontainer_Class',ctrl:'PRODUTONOMEFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUTONOMEFILTER.CLICK",",oparms:[{av:'divProdutonomefiltercontainer_Class',ctrl:'PRODUTONOMEFILTERCONTAINER',prop:'Class'},{av:'edtavCprodutonome_Visible',ctrl:'vCPRODUTONOME',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUTODESCRICAOFILTER.CLICK","{handler:'E13071',iparms:[{av:'divProdutodescricaofiltercontainer_Class',ctrl:'PRODUTODESCRICAOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUTODESCRICAOFILTER.CLICK",",oparms:[{av:'divProdutodescricaofiltercontainer_Class',ctrl:'PRODUTODESCRICAOFILTERCONTAINER',prop:'Class'},{av:'edtavCprodutodescricao_Visible',ctrl:'vCPRODUTODESCRICAO',prop:'Visible'}]}");
         setEventMetadata("LBLPRODUTOPRECOFILTER.CLICK","{handler:'E14071',iparms:[{av:'divProdutoprecofiltercontainer_Class',ctrl:'PRODUTOPRECOFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPRODUTOPRECOFILTER.CLICK",",oparms:[{av:'divProdutoprecofiltercontainer_Class',ctrl:'PRODUTOPRECOFILTERCONTAINER',prop:'Class'},{av:'edtavCprodutopreco_Visible',ctrl:'vCPRODUTOPRECO',prop:'Visible'}]}");
         setEventMetadata("LBLVENDEDORPRODUTOIDFILTER.CLICK","{handler:'E15071',iparms:[{av:'divVendedorprodutoidfiltercontainer_Class',ctrl:'VENDEDORPRODUTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLVENDEDORPRODUTOIDFILTER.CLICK",",oparms:[{av:'divVendedorprodutoidfiltercontainer_Class',ctrl:'VENDEDORPRODUTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCvendedorprodutoid_Visible',ctrl:'vCVENDEDORPRODUTOID',prop:'Visible'}]}");
         setEventMetadata("LBLPAISPRODUTOIDFILTER.CLICK","{handler:'E16071',iparms:[{av:'divPaisprodutoidfiltercontainer_Class',ctrl:'PAISPRODUTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLPAISPRODUTOIDFILTER.CLICK",",oparms:[{av:'divPaisprodutoidfiltercontainer_Class',ctrl:'PAISPRODUTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCpaisprodutoid_Visible',ctrl:'vCPAISPRODUTOID',prop:'Visible'}]}");
         setEventMetadata("LBLFORNECEDORPRODUTOIDFILTER.CLICK","{handler:'E17071',iparms:[{av:'divFornecedorprodutoidfiltercontainer_Class',ctrl:'FORNECEDORPRODUTOIDFILTERCONTAINER',prop:'Class'}]");
         setEventMetadata("LBLFORNECEDORPRODUTOIDFILTER.CLICK",",oparms:[{av:'divFornecedorprodutoidfiltercontainer_Class',ctrl:'FORNECEDORPRODUTOIDFILTERCONTAINER',prop:'Class'},{av:'edtavCfornecedorprodutoid_Visible',ctrl:'vCFORNECEDORPRODUTOID',prop:'Visible'}]}");
         setEventMetadata("ENTER","{handler:'E21072',iparms:[{av:'A19ProdutoId',fld:'PRODUTOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV13pProdutoId',fld:'vPPRODUTOID',pic:'ZZZ9'}]}");
         setEventMetadata("GRID1_FIRSTPAGE","{handler:'subgrid1_firstpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProdutoId',fld:'vCPRODUTOID',pic:'ZZZ9'},{av:'AV7cProdutoNome',fld:'vCPRODUTONOME',pic:''},{av:'AV8cProdutoDescricao',fld:'vCPRODUTODESCRICAO',pic:''},{av:'AV9cProdutoPreco',fld:'vCPRODUTOPRECO',pic:'ZZZZZZ9.99'},{av:'AV10cVendedorProdutoId',fld:'vCVENDEDORPRODUTOID',pic:'ZZZ9'},{av:'AV11cPaisProdutoId',fld:'vCPAISPRODUTOID',pic:'ZZZ9'},{av:'AV12cFornecedorProdutoId',fld:'vCFORNECEDORPRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_FIRSTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_PREVPAGE","{handler:'subgrid1_previouspage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProdutoId',fld:'vCPRODUTOID',pic:'ZZZ9'},{av:'AV7cProdutoNome',fld:'vCPRODUTONOME',pic:''},{av:'AV8cProdutoDescricao',fld:'vCPRODUTODESCRICAO',pic:''},{av:'AV9cProdutoPreco',fld:'vCPRODUTOPRECO',pic:'ZZZZZZ9.99'},{av:'AV10cVendedorProdutoId',fld:'vCVENDEDORPRODUTOID',pic:'ZZZ9'},{av:'AV11cPaisProdutoId',fld:'vCPAISPRODUTOID',pic:'ZZZ9'},{av:'AV12cFornecedorProdutoId',fld:'vCFORNECEDORPRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_PREVPAGE",",oparms:[]}");
         setEventMetadata("GRID1_NEXTPAGE","{handler:'subgrid1_nextpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProdutoId',fld:'vCPRODUTOID',pic:'ZZZ9'},{av:'AV7cProdutoNome',fld:'vCPRODUTONOME',pic:''},{av:'AV8cProdutoDescricao',fld:'vCPRODUTODESCRICAO',pic:''},{av:'AV9cProdutoPreco',fld:'vCPRODUTOPRECO',pic:'ZZZZZZ9.99'},{av:'AV10cVendedorProdutoId',fld:'vCVENDEDORPRODUTOID',pic:'ZZZ9'},{av:'AV11cPaisProdutoId',fld:'vCPAISPRODUTOID',pic:'ZZZ9'},{av:'AV12cFornecedorProdutoId',fld:'vCFORNECEDORPRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_NEXTPAGE",",oparms:[]}");
         setEventMetadata("GRID1_LASTPAGE","{handler:'subgrid1_lastpage',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'subGrid1_Rows',ctrl:'GRID1',prop:'Rows'},{av:'AV6cProdutoId',fld:'vCPRODUTOID',pic:'ZZZ9'},{av:'AV7cProdutoNome',fld:'vCPRODUTONOME',pic:''},{av:'AV8cProdutoDescricao',fld:'vCPRODUTODESCRICAO',pic:''},{av:'AV9cProdutoPreco',fld:'vCPRODUTOPRECO',pic:'ZZZZZZ9.99'},{av:'AV10cVendedorProdutoId',fld:'vCVENDEDORPRODUTOID',pic:'ZZZ9'},{av:'AV11cPaisProdutoId',fld:'vCPAISPRODUTOID',pic:'ZZZ9'},{av:'AV12cFornecedorProdutoId',fld:'vCFORNECEDORPRODUTOID',pic:'ZZZ9'}]");
         setEventMetadata("GRID1_LASTPAGE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Categoriaprodutoid',iparms:[]");
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
         AV7cProdutoNome = "";
         AV8cProdutoDescricao = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblLblprodutoidfilter_Jsonclick = "";
         TempTags = "";
         lblLblprodutonomefilter_Jsonclick = "";
         lblLblprodutodescricaofilter_Jsonclick = "";
         lblLblprodutoprecofilter_Jsonclick = "";
         lblLblvendedorprodutoidfilter_Jsonclick = "";
         lblLblpaisprodutoidfilter_Jsonclick = "";
         lblLblfornecedorprodutoidfilter_Jsonclick = "";
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
         AV17Linkselection_GXI = "";
         A20ProdutoNome = "";
         A21ProdutoDescricao = "";
         A23ProdutoImagem = "";
         A40000ProdutoImagem_GXI = "";
         scmdbuf = "";
         lV7cProdutoNome = "";
         lV8cProdutoDescricao = "";
         H00072_A30CategoriaProdutoId = new short[1] ;
         H00072_A28FornecedorProdutoId = new short[1] ;
         H00072_A26PaisProdutoId = new short[1] ;
         H00072_A24VendedorProdutoId = new short[1] ;
         H00072_A40000ProdutoImagem_GXI = new string[] {""} ;
         H00072_A22ProdutoPreco = new decimal[1] ;
         H00072_A21ProdutoDescricao = new string[] {""} ;
         H00072_A20ProdutoNome = new string[] {""} ;
         H00072_A19ProdutoId = new short[1] ;
         H00072_A23ProdutoImagem = new string[] {""} ;
         H00073_AGRID1_nRecordCount = new long[1] ;
         AV14ADVANCED_LABEL_TEMPLATE = "";
         Grid1Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid1_Linesclass = "";
         sImgUrl = "";
         ROClassString = "";
         Grid1Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gx0060__default(),
            new Object[][] {
                new Object[] {
               H00072_A30CategoriaProdutoId, H00072_A28FornecedorProdutoId, H00072_A26PaisProdutoId, H00072_A24VendedorProdutoId, H00072_A40000ProdutoImagem_GXI, H00072_A22ProdutoPreco, H00072_A21ProdutoDescricao, H00072_A20ProdutoNome, H00072_A19ProdutoId, H00072_A23ProdutoImagem
               }
               , new Object[] {
               H00073_AGRID1_nRecordCount
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short AV13pProdutoId ;
      private short GRID1_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV6cProdutoId ;
      private short AV10cVendedorProdutoId ;
      private short AV11cPaisProdutoId ;
      private short AV12cFornecedorProdutoId ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short A19ProdutoId ;
      private short A24VendedorProdutoId ;
      private short A26PaisProdutoId ;
      private short A28FornecedorProdutoId ;
      private short A30CategoriaProdutoId ;
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
      private int nRC_GXsfl_84 ;
      private int subGrid1_Rows ;
      private int nGXsfl_84_idx=1 ;
      private int edtavCprodutoid_Enabled ;
      private int edtavCprodutoid_Visible ;
      private int edtavCprodutonome_Visible ;
      private int edtavCprodutonome_Enabled ;
      private int edtavCprodutodescricao_Visible ;
      private int edtavCprodutodescricao_Enabled ;
      private int edtavCprodutopreco_Enabled ;
      private int edtavCprodutopreco_Visible ;
      private int edtavCvendedorprodutoid_Enabled ;
      private int edtavCvendedorprodutoid_Visible ;
      private int edtavCpaisprodutoid_Enabled ;
      private int edtavCpaisprodutoid_Visible ;
      private int edtavCfornecedorprodutoid_Enabled ;
      private int edtavCfornecedorprodutoid_Visible ;
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
      private decimal AV9cProdutoPreco ;
      private decimal A22ProdutoPreco ;
      private string divAdvancedcontainer_Class ;
      private string bttBtntoggle_Class ;
      private string divProdutoidfiltercontainer_Class ;
      private string divProdutonomefiltercontainer_Class ;
      private string divProdutodescricaofiltercontainer_Class ;
      private string divProdutoprecofiltercontainer_Class ;
      private string divVendedorprodutoidfiltercontainer_Class ;
      private string divPaisprodutoidfiltercontainer_Class ;
      private string divFornecedorprodutoidfiltercontainer_Class ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_84_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMain_Internalname ;
      private string divAdvancedcontainer_Internalname ;
      private string divProdutoidfiltercontainer_Internalname ;
      private string lblLblprodutoidfilter_Internalname ;
      private string lblLblprodutoidfilter_Jsonclick ;
      private string edtavCprodutoid_Internalname ;
      private string TempTags ;
      private string edtavCprodutoid_Jsonclick ;
      private string divProdutonomefiltercontainer_Internalname ;
      private string lblLblprodutonomefilter_Internalname ;
      private string lblLblprodutonomefilter_Jsonclick ;
      private string edtavCprodutonome_Internalname ;
      private string edtavCprodutonome_Jsonclick ;
      private string divProdutodescricaofiltercontainer_Internalname ;
      private string lblLblprodutodescricaofilter_Internalname ;
      private string lblLblprodutodescricaofilter_Jsonclick ;
      private string edtavCprodutodescricao_Internalname ;
      private string edtavCprodutodescricao_Jsonclick ;
      private string divProdutoprecofiltercontainer_Internalname ;
      private string lblLblprodutoprecofilter_Internalname ;
      private string lblLblprodutoprecofilter_Jsonclick ;
      private string edtavCprodutopreco_Internalname ;
      private string edtavCprodutopreco_Jsonclick ;
      private string divVendedorprodutoidfiltercontainer_Internalname ;
      private string lblLblvendedorprodutoidfilter_Internalname ;
      private string lblLblvendedorprodutoidfilter_Jsonclick ;
      private string edtavCvendedorprodutoid_Internalname ;
      private string edtavCvendedorprodutoid_Jsonclick ;
      private string divPaisprodutoidfiltercontainer_Internalname ;
      private string lblLblpaisprodutoidfilter_Internalname ;
      private string lblLblpaisprodutoidfilter_Jsonclick ;
      private string edtavCpaisprodutoid_Internalname ;
      private string edtavCpaisprodutoid_Jsonclick ;
      private string divFornecedorprodutoidfiltercontainer_Internalname ;
      private string lblLblfornecedorprodutoidfilter_Internalname ;
      private string lblLblfornecedorprodutoidfilter_Jsonclick ;
      private string edtavCfornecedorprodutoid_Internalname ;
      private string edtavCfornecedorprodutoid_Jsonclick ;
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
      private string edtProdutoId_Internalname ;
      private string edtProdutoNome_Internalname ;
      private string edtProdutoDescricao_Internalname ;
      private string edtProdutoPreco_Internalname ;
      private string edtProdutoImagem_Internalname ;
      private string edtVendedorProdutoId_Internalname ;
      private string edtPaisProdutoId_Internalname ;
      private string edtFornecedorProdutoId_Internalname ;
      private string edtCategoriaProdutoId_Internalname ;
      private string scmdbuf ;
      private string AV14ADVANCED_LABEL_TEMPLATE ;
      private string edtavLinkselection_gximage ;
      private string sGXsfl_84_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string edtavLinkselection_Link ;
      private string sImgUrl ;
      private string ROClassString ;
      private string edtProdutoId_Jsonclick ;
      private string edtProdutoNome_Link ;
      private string edtProdutoNome_Jsonclick ;
      private string edtProdutoDescricao_Jsonclick ;
      private string edtProdutoPreco_Jsonclick ;
      private string edtVendedorProdutoId_Jsonclick ;
      private string edtPaisProdutoId_Jsonclick ;
      private string edtFornecedorProdutoId_Jsonclick ;
      private string edtCategoriaProdutoId_Jsonclick ;
      private string subGrid1_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_84_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV5LinkSelection_IsBlob ;
      private bool A23ProdutoImagem_IsBlob ;
      private string AV7cProdutoNome ;
      private string AV8cProdutoDescricao ;
      private string AV17Linkselection_GXI ;
      private string A20ProdutoNome ;
      private string A21ProdutoDescricao ;
      private string A40000ProdutoImagem_GXI ;
      private string lV7cProdutoNome ;
      private string lV8cProdutoDescricao ;
      private string AV5LinkSelection ;
      private string A23ProdutoImagem ;
      private GXWebGrid Grid1Container ;
      private GXWebRow Grid1Row ;
      private GXWebColumn Grid1Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H00072_A30CategoriaProdutoId ;
      private short[] H00072_A28FornecedorProdutoId ;
      private short[] H00072_A26PaisProdutoId ;
      private short[] H00072_A24VendedorProdutoId ;
      private string[] H00072_A40000ProdutoImagem_GXI ;
      private decimal[] H00072_A22ProdutoPreco ;
      private string[] H00072_A21ProdutoDescricao ;
      private string[] H00072_A20ProdutoNome ;
      private short[] H00072_A19ProdutoId ;
      private string[] H00072_A23ProdutoImagem ;
      private long[] H00073_AGRID1_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private short aP0_pProdutoId ;
      private GXWebForm Form ;
   }

   public class gx0060__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H00072( IGxContext context ,
                                             string AV7cProdutoNome ,
                                             string AV8cProdutoDescricao ,
                                             decimal AV9cProdutoPreco ,
                                             short AV10cVendedorProdutoId ,
                                             short AV11cPaisProdutoId ,
                                             short AV12cFornecedorProdutoId ,
                                             string A20ProdutoNome ,
                                             string A21ProdutoDescricao ,
                                             decimal A22ProdutoPreco ,
                                             short A24VendedorProdutoId ,
                                             short A26PaisProdutoId ,
                                             short A28FornecedorProdutoId ,
                                             short AV6cProdutoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int1 = new short[10];
         Object[] GXv_Object2 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " [CategoriaProdutoId], [FornecedorProdutoId], [PaisProdutoId], [VendedorProdutoId], [ProdutoImagem_GXI], [ProdutoPreco], [ProdutoDescricao], [ProdutoNome], [ProdutoId], [ProdutoImagem]";
         sFromString = " FROM [Produto]";
         sOrderString = "";
         AddWhere(sWhereString, "([ProdutoId] >= @AV6cProdutoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProdutoNome)) )
         {
            AddWhere(sWhereString, "([ProdutoNome] like @lV7cProdutoNome)");
         }
         else
         {
            GXv_int1[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProdutoDescricao)) )
         {
            AddWhere(sWhereString, "([ProdutoDescricao] like @lV8cProdutoDescricao)");
         }
         else
         {
            GXv_int1[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cProdutoPreco) )
         {
            AddWhere(sWhereString, "([ProdutoPreco] >= @AV9cProdutoPreco)");
         }
         else
         {
            GXv_int1[3] = 1;
         }
         if ( ! (0==AV10cVendedorProdutoId) )
         {
            AddWhere(sWhereString, "([VendedorProdutoId] >= @AV10cVendedorProdutoId)");
         }
         else
         {
            GXv_int1[4] = 1;
         }
         if ( ! (0==AV11cPaisProdutoId) )
         {
            AddWhere(sWhereString, "([PaisProdutoId] >= @AV11cPaisProdutoId)");
         }
         else
         {
            GXv_int1[5] = 1;
         }
         if ( ! (0==AV12cFornecedorProdutoId) )
         {
            AddWhere(sWhereString, "([FornecedorProdutoId] >= @AV12cFornecedorProdutoId)");
         }
         else
         {
            GXv_int1[6] = 1;
         }
         sOrderString += " ORDER BY [ProdutoId]";
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + "@GXPagingFrom2" + " ROWS FETCH NEXT CAST((SELECT CASE WHEN " + "@GXPagingTo2" + " > 0 THEN " + "@GXPagingTo2" + " ELSE 1e9 END) AS INTEGER) ROWS ONLY";
         GXv_Object2[0] = scmdbuf;
         GXv_Object2[1] = GXv_int1;
         return GXv_Object2 ;
      }

      protected Object[] conditional_H00073( IGxContext context ,
                                             string AV7cProdutoNome ,
                                             string AV8cProdutoDescricao ,
                                             decimal AV9cProdutoPreco ,
                                             short AV10cVendedorProdutoId ,
                                             short AV11cPaisProdutoId ,
                                             short AV12cFornecedorProdutoId ,
                                             string A20ProdutoNome ,
                                             string A21ProdutoDescricao ,
                                             decimal A22ProdutoPreco ,
                                             short A24VendedorProdutoId ,
                                             short A26PaisProdutoId ,
                                             short A28FornecedorProdutoId ,
                                             short AV6cProdutoId )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int3 = new short[7];
         Object[] GXv_Object4 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM [Produto]";
         AddWhere(sWhereString, "([ProdutoId] >= @AV6cProdutoId)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7cProdutoNome)) )
         {
            AddWhere(sWhereString, "([ProdutoNome] like @lV7cProdutoNome)");
         }
         else
         {
            GXv_int3[1] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8cProdutoDescricao)) )
         {
            AddWhere(sWhereString, "([ProdutoDescricao] like @lV8cProdutoDescricao)");
         }
         else
         {
            GXv_int3[2] = 1;
         }
         if ( ! (Convert.ToDecimal(0)==AV9cProdutoPreco) )
         {
            AddWhere(sWhereString, "([ProdutoPreco] >= @AV9cProdutoPreco)");
         }
         else
         {
            GXv_int3[3] = 1;
         }
         if ( ! (0==AV10cVendedorProdutoId) )
         {
            AddWhere(sWhereString, "([VendedorProdutoId] >= @AV10cVendedorProdutoId)");
         }
         else
         {
            GXv_int3[4] = 1;
         }
         if ( ! (0==AV11cPaisProdutoId) )
         {
            AddWhere(sWhereString, "([PaisProdutoId] >= @AV11cPaisProdutoId)");
         }
         else
         {
            GXv_int3[5] = 1;
         }
         if ( ! (0==AV12cFornecedorProdutoId) )
         {
            AddWhere(sWhereString, "([FornecedorProdutoId] >= @AV12cFornecedorProdutoId)");
         }
         else
         {
            GXv_int3[6] = 1;
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
                     return conditional_H00072(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
               case 1 :
                     return conditional_H00073(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (decimal)dynConstraints[2] , (short)dynConstraints[3] , (short)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (decimal)dynConstraints[8] , (short)dynConstraints[9] , (short)dynConstraints[10] , (short)dynConstraints[11] , (short)dynConstraints[12] );
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
          Object[] prmH00072;
          prmH00072 = new Object[] {
          new ParDef("@AV6cProdutoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@lV8cProdutoDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@AV9cProdutoPreco",GXType.Decimal,10,2) ,
          new ParDef("@AV10cVendedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@AV11cPaisProdutoId",GXType.Int16,4,0) ,
          new ParDef("@AV12cFornecedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("@GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH00073;
          prmH00073 = new Object[] {
          new ParDef("@AV6cProdutoId",GXType.Int16,4,0) ,
          new ParDef("@lV7cProdutoNome",GXType.NVarChar,40,0) ,
          new ParDef("@lV8cProdutoDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@AV9cProdutoPreco",GXType.Decimal,10,2) ,
          new ParDef("@AV10cVendedorProdutoId",GXType.Int16,4,0) ,
          new ParDef("@AV11cPaisProdutoId",GXType.Int16,4,0) ,
          new ParDef("@AV12cFornecedorProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H00072", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00072,11, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("H00073", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH00073,1, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((decimal[]) buf[5])[0] = rslt.getDecimal(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((short[]) buf[8])[0] = rslt.getShort(9);
                ((string[]) buf[9])[0] = rslt.getMultimediaFile(10, rslt.getVarchar(5));
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
