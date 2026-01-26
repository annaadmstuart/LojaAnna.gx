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
   public class vendedoreseprodutos : GXDataArea
   {
      public vendedoreseprodutos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public vendedoreseprodutos( IGxContext context )
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid2") == 0 )
            {
               gxnrGrid2_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid2") == 0 )
            {
               gxgrGrid2_refresh_invoke( ) ;
               return  ;
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

      protected void gxnrGrid2_newrow_invoke( )
      {
         nRC_GXsfl_25 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_25"), "."));
         nGXsfl_25_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_25_idx"), "."));
         sGXsfl_25_idx = GetPar( "sGXsfl_25_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid2_newrow( ) ;
         /* End function gxnrGrid2_newrow_invoke */
      }

      protected void gxgrGrid2_refresh_invoke( )
      {
         A6VendedorId = (short)(NumberUtil.Val( GetPar( "VendedorId"), "."));
         AV5Total = (short)(NumberUtil.Val( GetPar( "Total"), "."));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid2_refresh( A6VendedorId, AV5Total) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid2_refresh_invoke */
      }

      protected void gxnrGrid1_newrow_invoke( )
      {
         nRC_GXsfl_9 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_9"), "."));
         nGXsfl_9_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_9_idx"), "."));
         sGXsfl_9_idx = GetPar( "sGXsfl_9_idx");
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
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid1_refresh( ) ;
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
         PA0Y2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0Y2( ) ;
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
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("vendedoreseprodutos.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<input type=\"submit\" title=\"submit\" style=\"display:block;height:0;border:0;padding:0\" disabled>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
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
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_9", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_9), 8, 0, ".", "")));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE0Y2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0Y2( ) ;
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
         return formatLink("vendedoreseprodutos.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "VendedoresEProdutos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Vendedores e Produtos" ;
      }

      protected void WB0Y0( )
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
            GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 heading-01", "left", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblTextblock1_Internalname, "Vendedores e produtos", "", "", lblTextblock1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_VendedoresEProdutos.htm");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
            /*  Grid Control  */
            Grid1Container.SetIsFreestyle(true);
            Grid1Container.SetWrapped(nGXWrapped);
            StartGridControl9( ) ;
         }
         if ( wbEnd == 9 )
         {
            wbEnd = 0;
            nRC_GXsfl_9 = (int)(nGXsfl_9_idx-1);
            if ( Grid1Container.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
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
            GxWebStd.gx_div_end( context, "left", "top", "div");
            GxWebStd.gx_div_end( context, "left", "top", "div");
         }
         if ( wbEnd == 9 )
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
         if ( wbEnd == 25 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( Grid2Container.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"Grid2Container"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid2", Grid2Container, subGrid2_Internalname);
                  if ( ! isAjaxCallMode( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData", Grid2Container.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V", Grid2Container.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V"+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START0Y2( )
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
            Form.Meta.addItem("description", "Vendedores e Produtos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0Y0( ) ;
      }

      protected void WS0Y2( )
      {
         START0Y2( ) ;
         EVT0Y2( ) ;
      }

      protected void EVT0Y2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID1.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRID2.REFRESH") == 0 ) )
                           {
                              nGXsfl_9_idx = (int)(NumberUtil.Val( sEvtType, "."));
                              sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
                              SubsflControlProps_92( ) ;
                              A8VendedorFoto = cgiGet( edtVendedorFoto_Internalname);
                              AssignProp("", false, edtVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), !bGXsfl_9_Refreshing);
                              AssignProp("", false, edtVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
                              A7VendedorNome = cgiGet( edtVendedorNome_Internalname);
                              AV5Total = (short)(context.localUtil.CToN( cgiGet( edtavTotal_Internalname), ".", ","));
                              AssignAttri("", false, edtavTotal_Internalname, StringUtil.LTrimStr( (decimal)(AV5Total), 4, 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID1.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E110Y2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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
                                 sEvtType = StringUtil.Right( sEvt, 4);
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                                 if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 10), "GRID2.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 13), "GRID2.REFRESH") == 0 ) )
                                 {
                                    nGXsfl_25_idx = (int)(NumberUtil.Val( sEvtType, "."));
                                    sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
                                    SubsflControlProps_253( ) ;
                                    A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ","));
                                    A20ProdutoNome = cgiGet( edtProdutoNome_Internalname);
                                    A23ProdutoImagem = cgiGet( edtProdutoImagem_Internalname);
                                    AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40002ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_25_Refreshing);
                                    AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
                                    A31CategoriaProdutoNome = cgiGet( edtCategoriaProdutoNome_Internalname);
                                    A22ProdutoPreco = context.localUtil.CToN( cgiGet( edtProdutoPreco_Internalname), ".", ",");
                                    sEvtType = StringUtil.Right( sEvt, 1);
                                    if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                                    {
                                       sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                       if ( StringUtil.StrCmp(sEvt, "GRID2.LOAD") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          E120Y3 ();
                                       }
                                       else if ( StringUtil.StrCmp(sEvt, "GRID2.REFRESH") == 0 )
                                       {
                                          context.wbHandled = 1;
                                          dynload_actions( ) ;
                                          E130Y2 ();
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
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE0Y2( )
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

      protected void PA0Y2( )
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
         SubsflControlProps_92( ) ;
         while ( nGXsfl_9_idx <= nRC_GXsfl_9 )
         {
            sendrow_92( ) ;
            nGXsfl_9_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
            sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
            SubsflControlProps_92( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid1Container)) ;
         /* End function gxnrGrid1_newrow */
      }

      protected void gxnrGrid2_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_253( ) ;
         while ( nGXsfl_25_idx <= nRC_GXsfl_25 )
         {
            sendrow_253( ) ;
            nGXsfl_25_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_25_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
            sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
            SubsflControlProps_253( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Grid2Container)) ;
         /* End function gxnrGrid2_newrow */
      }

      protected void gxgrGrid2_refresh( short A6VendedorId ,
                                        short AV5Total )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID2_nCurrentRecord = 0;
         RF0Y3( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid2_refresh */
      }

      protected void gxgrGrid1_refresh( )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID1_nCurrentRecord = 0;
         RF0Y2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid1_refresh */
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
         RF0Y2( ) ;
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

      protected void RF0Y2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid1Container.ClearRows();
         }
         wbStart = 9;
         nGXsfl_9_idx = 1;
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         bGXsfl_9_Refreshing = true;
         Grid1Container.AddObjectProperty("GridName", "Grid1");
         Grid1Container.AddObjectProperty("CmpContext", "");
         Grid1Container.AddObjectProperty("InMasterPage", "false");
         Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
         Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
         Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
         Grid1Container.PageSize = subGrid1_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_92( ) ;
            /* Using cursor H000Y2 */
            pr_default.execute(0);
            while ( (pr_default.getStatus(0) != 101) )
            {
               A6VendedorId = H000Y2_A6VendedorId[0];
               A7VendedorNome = H000Y2_A7VendedorNome[0];
               A40000VendedorFoto_GXI = H000Y2_A40000VendedorFoto_GXI[0];
               AssignProp("", false, edtVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), !bGXsfl_9_Refreshing);
               AssignProp("", false, edtVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
               A8VendedorFoto = H000Y2_A8VendedorFoto[0];
               AssignProp("", false, edtVendedorFoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.convertURL( context.PathToRelativeUrl( A8VendedorFoto))), !bGXsfl_9_Refreshing);
               AssignProp("", false, edtVendedorFoto_Internalname, "SrcSet", context.GetImageSrcSet( A8VendedorFoto), true);
               E110Y2 ();
               pr_default.readNext(0);
            }
            pr_default.close(0);
            wbEnd = 9;
            WB0Y0( ) ;
         }
         bGXsfl_9_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Y2( )
      {
      }

      protected void RF0Y3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            Grid2Container.ClearRows();
         }
         wbStart = 25;
         E130Y2 ();
         nGXsfl_25_idx = 1;
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
         SubsflControlProps_253( ) ;
         bGXsfl_25_Refreshing = true;
         Grid2Container.AddObjectProperty("GridName", "Grid2");
         Grid2Container.AddObjectProperty("CmpContext", "");
         Grid2Container.AddObjectProperty("InMasterPage", "false");
         Grid2Container.AddObjectProperty("Class", "Grid");
         Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
         Grid2Container.PageSize = subGrid2_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_253( ) ;
            /* Using cursor H000Y3 */
            pr_default.execute(1, new Object[] {A6VendedorId});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A30CategoriaProdutoId = H000Y3_A30CategoriaProdutoId[0];
               A24VendedorProdutoId = H000Y3_A24VendedorProdutoId[0];
               A22ProdutoPreco = H000Y3_A22ProdutoPreco[0];
               A31CategoriaProdutoNome = H000Y3_A31CategoriaProdutoNome[0];
               A40002ProdutoImagem_GXI = H000Y3_A40002ProdutoImagem_GXI[0];
               AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40002ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_25_Refreshing);
               AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
               A20ProdutoNome = H000Y3_A20ProdutoNome[0];
               A19ProdutoId = H000Y3_A19ProdutoId[0];
               A23ProdutoImagem = H000Y3_A23ProdutoImagem[0];
               AssignProp("", false, edtProdutoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40002ProdutoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A23ProdutoImagem))), !bGXsfl_25_Refreshing);
               AssignProp("", false, edtProdutoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A23ProdutoImagem), true);
               A31CategoriaProdutoNome = H000Y3_A31CategoriaProdutoNome[0];
               E120Y3 ();
               pr_default.readNext(1);
            }
            pr_default.close(1);
            wbEnd = 25;
            WB0Y0( ) ;
         }
         bGXsfl_25_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0Y3( )
      {
      }

      protected int subGrid1_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid1_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordcount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Recordsperpage( )
      {
         return (int)(-1) ;
      }

      protected int subGrid2_fnc_Currentpage( )
      {
         return (int)(-1) ;
      }

      protected void before_start_formulas( )
      {
         context.Gx_err = 0;
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0Y0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            nRC_GXsfl_9 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_9"), ".", ","));
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void E130Y2( )
      {
         /* Grid2_Refresh Routine */
         returnInSub = false;
         AV5Total = 0;
         AssignAttri("", false, edtavTotal_Internalname, StringUtil.LTrimStr( (decimal)(AV5Total), 4, 0));
         /*  Sending Event outputs  */
      }

      private void E110Y2( )
      {
         /* Grid1_Load Routine */
         returnInSub = false;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 9;
         }
         sendrow_92( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_9_Refreshing )
         {
            DoAjaxLoad(9, Grid1Row);
         }
      }

      private void E120Y3( )
      {
         /* Grid2_Load Routine */
         returnInSub = false;
         AV5Total = (short)(AV5Total+1);
         AssignAttri("", false, edtavTotal_Internalname, StringUtil.LTrimStr( (decimal)(AV5Total), 4, 0));
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 25;
         }
         sendrow_253( ) ;
         if ( isFullAjaxMode( ) && ! bGXsfl_25_Refreshing )
         {
            DoAjaxLoad(25, Grid2Row);
         }
         /*  Sending Event outputs  */
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
         PA0Y2( ) ;
         WS0Y2( ) ;
         WE0Y2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916513963", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.eng.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("vendedoreseprodutos.js", "?202582916513963", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_253( )
      {
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_25_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_25_idx;
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM_"+sGXsfl_25_idx;
         edtCategoriaProdutoNome_Internalname = "CATEGORIAPRODUTONOME_"+sGXsfl_25_idx;
         edtProdutoPreco_Internalname = "PRODUTOPRECO_"+sGXsfl_25_idx;
      }

      protected void SubsflControlProps_fel_253( )
      {
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_25_fel_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_25_fel_idx;
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM_"+sGXsfl_25_fel_idx;
         edtCategoriaProdutoNome_Internalname = "CATEGORIAPRODUTONOME_"+sGXsfl_25_fel_idx;
         edtProdutoPreco_Internalname = "PRODUTOPRECO_"+sGXsfl_25_fel_idx;
      }

      protected void sendrow_253( )
      {
         SubsflControlProps_253( ) ;
         WB0Y0( ) ;
         Grid2Row = GXWebRow.GetNew(context,Grid2Container);
         if ( subGrid2_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGrid2_Backstyle = 0;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
         }
         else if ( subGrid2_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGrid2_Backstyle = 0;
            subGrid2_Backcolor = subGrid2_Allbackcolor;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Uniform";
            }
         }
         else if ( subGrid2_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
            {
               subGrid2_Linesclass = subGrid2_Class+"Odd";
            }
            subGrid2_Backcolor = (int)(0x0);
         }
         else if ( subGrid2_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid2_Backstyle = 1;
            if ( ((int)((nGXsfl_25_idx) % (2))) == 0 )
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Even";
               }
            }
            else
            {
               subGrid2_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid2_Class, "") != 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Odd";
               }
            }
         }
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr ") ;
            context.WriteHtmlText( " class=\""+"Grid"+"\" style=\""+""+"\"") ;
            context.WriteHtmlText( " gxrow=\""+sGXsfl_25_idx+"\">") ;
         }
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+"display:none;"+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)0,(bool)false,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoNome_Internalname,(string)A20ProdutoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)false,(string)"Nome",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+""+"\">") ;
         }
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A23ProdutoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40002ProdutoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A23ProdutoImagem)) ? A40002ProdutoImagem_GXI : context.PathToRelativeUrl( A23ProdutoImagem));
         Grid2Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoImagem_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)-1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"px",(short)0,(string)"px",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A23ProdutoImagem_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"left"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCategoriaProdutoNome_Internalname,(string)A31CategoriaProdutoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCategoriaProdutoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)-1,(bool)false,(string)"Nome",(string)"left",(bool)true,(string)""});
         /* Subfile cell */
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<td valign=\"middle\" align=\""+"right"+"\""+" style=\""+""+"\">") ;
         }
         /* Single line edit */
         ROClassString = "Attribute";
         Grid2Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoPreco_Internalname,StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")),StringUtil.LTrim( context.localUtil.Format( A22ProdutoPreco, "ZZZZZZ9.99")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoPreco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)25,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"right",(bool)false,(string)""});
         send_integrity_lvl_hashes0Y3( ) ;
         Grid2Container.AddRow(Grid2Row);
         nGXsfl_25_idx = ((subGrid2_Islastpage==1)&&(nGXsfl_25_idx+1>subGrid2_fnc_Recordsperpage( )) ? 1 : nGXsfl_25_idx+1);
         sGXsfl_25_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_25_idx), 4, 0), 4, "0") + sGXsfl_9_idx;
         SubsflControlProps_253( ) ;
         /* End function sendrow_253 */
      }

      protected void SubsflControlProps_92( )
      {
         edtVendedorFoto_Internalname = "VENDEDORFOTO_"+sGXsfl_9_idx;
         edtVendedorNome_Internalname = "VENDEDORNOME_"+sGXsfl_9_idx;
         edtavTotal_Internalname = "vTOTAL_"+sGXsfl_9_idx;
         subGrid2_Internalname = "GRID2_"+sGXsfl_9_idx;
      }

      protected void SubsflControlProps_fel_92( )
      {
         edtVendedorFoto_Internalname = "VENDEDORFOTO_"+sGXsfl_9_fel_idx;
         edtVendedorNome_Internalname = "VENDEDORNOME_"+sGXsfl_9_fel_idx;
         edtavTotal_Internalname = "vTOTAL_"+sGXsfl_9_fel_idx;
         subGrid2_Internalname = "GRID2_"+sGXsfl_9_fel_idx;
      }

      protected void sendrow_92( )
      {
         SubsflControlProps_92( ) ;
         WB0Y0( ) ;
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
            subGrid1_Backcolor = (int)(0xFFFFFF);
         }
         else if ( subGrid1_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGrid1_Backstyle = 1;
            if ( ((int)((nGXsfl_9_idx) % (2))) == 0 )
            {
               subGrid1_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Even";
               }
            }
            else
            {
               subGrid1_Backcolor = (int)(0xFFFFFF);
               if ( StringUtil.StrCmp(subGrid1_Class, "") != 0 )
               {
                  subGrid1_Linesclass = subGrid1_Class+"Odd";
               }
            }
         }
         /* Start of Columns property logic. */
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<tr"+" class=\""+subGrid1_Linesclass+"\" style=\""+""+"\""+" data-gxrow=\""+sGXsfl_9_idx+"\">") ;
         }
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)divGrid1table_Internalname+"_"+sGXsfl_9_idx,(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"Table",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtVendedorFoto_Internalname+"\"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A8VendedorFoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000VendedorFoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A8VendedorFoto)) ? A40000VendedorFoto_GXI : context.PathToRelativeUrl( A8VendedorFoto));
         Grid1Row.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)edtVendedorFoto_Internalname,(string)sImgUrl,(string)"",(string)"",(string)"",context.GetTheme( ),(short)1,(short)0,(string)"",(string)"",(short)0,(short)-1,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)A8VendedorFoto_IsBlob,(bool)true,context.GetImageSrcSet( sImgUrl)});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12 col-sm-6",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtVendedorNome_Internalname+"\"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-sm-9 gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtVendedorNome_Internalname,(string)A7VendedorNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtVendedorNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"",(short)40,(string)"chr",(short)1,(string)"row",(short)40,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"row",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"col-xs-12",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Table start */
         Grid1Row.AddColumnProperties("table", -1, isAjaxCallMode( ), new Object[] {(string)tblTable1_Internalname+"_"+sGXsfl_9_idx,(short)1,(string)"Table",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(short)2,(string)"",(string)"",(string)"",(string)"px",(string)"px",(string)""});
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /*  Child Grid Control  */
         Grid1Row.AddColumnProperties("subfile", -1, isAjaxCallMode( ), new Object[] {(string)"Grid2Container"});
         if ( isAjaxCallMode( ) )
         {
            Grid2Container = new GXWebGrid( context);
         }
         else
         {
            Grid2Container.Clear();
         }
         Grid2Container.SetWrapped(nGXWrapped);
         StartGridControl25( ) ;
         RF0Y3( ) ;
         nRC_GXsfl_25 = (int)(nGXsfl_25_idx-1);
         send_integrity_footer_hashes( ) ;
         GXCCtl = "nRC_GXsfl_25_" + sGXsfl_9_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_25), 8, 0, ".", "")));
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "</table>") ;
         }
         else
         {
            if ( ! isAjaxCallMode( ) )
            {
               GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"_"+sGXsfl_9_idx, Grid2Container.ToJavascriptSource());
            }
            if ( isAjaxCallMode( ) )
            {
               Grid1Row.AddGrid("Grid2", Grid2Container);
            }
            if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
            {
               GxWebStd.gx_hidden_field( context, "Grid2ContainerData"+"V_"+sGXsfl_9_idx, Grid2Container.GridValuesHidden());
            }
            else
            {
               context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Grid2ContainerData"+"V_"+sGXsfl_9_idx+"\" value='"+Grid2Container.GridValuesHidden()+"'/>") ;
            }
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         Grid1Row.AddColumnProperties("row", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         Grid1Row.AddColumnProperties("cell", -1, isAjaxCallMode( ), new Object[] {(string)"",(string)"",(string)""});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)0,(string)"px",(short)0,(string)"px",(string)"form-group gx-form-group gx-default-form-group",(string)"left",(string)"top",(string)""+" data-gx-for=\""+edtavTotal_Internalname+"\"",(string)"",(string)"div"});
         /* Attribute/Variable Label */
         Grid1Row.AddColumnProperties("html_label", -1, isAjaxCallMode( ), new Object[] {(string)edtavTotal_Internalname,(string)"Total",(string)"gx-form-item AttributeLabel",(short)1,(bool)true,(string)"width: 25%;"});
         /* Div Control */
         Grid1Row.AddColumnProperties("div_start", -1, isAjaxCallMode( ), new Object[] {(string)"",(short)1,(short)75,(string)"%",(short)0,(string)"px",(string)"gx-form-item gx-attribute",(string)"left",(string)"top",(string)"",(string)"",(string)"div"});
         /* Single line edit */
         ROClassString = "Attribute";
         Grid1Row.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavTotal_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Total), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(AV5Total), "ZZZ9")),(string)" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavTotal_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)1,(short)0,(short)0,(string)"text",(string)"1",(short)4,(string)"chr",(short)1,(string)"row",(short)4,(short)0,(short)0,(short)9,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"right",(bool)false,(string)""});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("cell");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("row");
         }
         if ( Grid1Container.GetWrapped() == 1 )
         {
            Grid1Container.CloseTag("table");
         }
         /* End of table */
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         Grid1Row.AddColumnProperties("div_end", -1, isAjaxCallMode( ), new Object[] {(string)"left",(string)"top",(string)"div"});
         send_integrity_lvl_hashes0Y2( ) ;
         /* End of Columns property logic. */
         Grid1Container.AddRow(Grid1Row);
         nGXsfl_9_idx = ((subGrid1_Islastpage==1)&&(nGXsfl_9_idx+1>subGrid1_fnc_Recordsperpage( )) ? 1 : nGXsfl_9_idx+1);
         sGXsfl_9_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_9_idx), 4, 0), 4, "0");
         SubsflControlProps_92( ) ;
         /* End function sendrow_92 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl9( )
      {
         if ( Grid1Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid1Container"+"DivS\" data-gxgridid=\"9\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid1_Internalname, subGrid1_Internalname, "", "FreeStyleGrid", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            Grid1Container.SetIsFreestyle(true);
            Grid1Container.SetWrapped(nGXWrapped);
            Grid1Container.AddObjectProperty("GridName", "Grid1");
            Grid1Container.AddObjectProperty("Header", subGrid1_Header);
            Grid1Container.AddObjectProperty("Class", StringUtil.RTrim( "FreeStyleGrid"));
            Grid1Container.AddObjectProperty("Class", "FreeStyleGrid");
            Grid1Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid1Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid1_Backcolorstyle), 1, 0, ".", "")));
            Grid1Container.AddObjectProperty("CmpContext", "");
            Grid1Container.AddObjectProperty("InMasterPage", "false");
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", context.convertURL( A8VendedorFoto));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", A7VendedorNome);
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Container.AddColumnProperties(Grid1Column);
            Grid1Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid1Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5Total), 4, 0, ".", "")));
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

      protected void StartGridControl25( )
      {
         if ( Grid2Container.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"Grid2Container"+"DivS\" data-gxgridid=\"25\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid2_Internalname, subGrid2_Internalname, "", "Grid", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid2_Backcolorstyle == 0 )
            {
               subGrid2_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid2_Class) > 0 )
               {
                  subGrid2_Linesclass = subGrid2_Class+"Title";
               }
            }
            else
            {
               subGrid2_Titlebackstyle = 1;
               if ( subGrid2_Backcolorstyle == 1 )
               {
                  subGrid2_Titlebackcolor = subGrid2_Allbackcolor;
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid2_Class) > 0 )
                  {
                     subGrid2_Linesclass = subGrid2_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Produto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Produto") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ImageAttribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Imagem") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"left"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Categoria ") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"right"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Preço") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            Grid2Container.AddObjectProperty("GridName", "Grid2");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               Grid2Container = new GXWebGrid( context);
            }
            else
            {
               Grid2Container.Clear();
            }
            Grid2Container.SetWrapped(nGXWrapped);
            Grid2Container.AddObjectProperty("GridName", "Grid2");
            Grid2Container.AddObjectProperty("Header", subGrid2_Header);
            Grid2Container.AddObjectProperty("Class", "Grid");
            Grid2Container.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Backcolorstyle), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("CmpContext", "");
            Grid2Container.AddObjectProperty("InMasterPage", "false");
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", A20ProdutoNome);
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", context.convertURL( A23ProdutoImagem));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", A31CategoriaProdutoNome);
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Column = GXWebColumn.GetNew(isAjaxCallMode( ));
            Grid2Column.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( A22ProdutoPreco, 10, 2, ".", "")));
            Grid2Container.AddColumnProperties(Grid2Column);
            Grid2Container.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectedindex), 4, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowselection), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Selectioncolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowhovering), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Hoveringcolor), 9, 0, ".", "")));
            Grid2Container.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Allowcollapsing), 1, 0, ".", "")));
            Grid2Container.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid2_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         lblTextblock1_Internalname = "TEXTBLOCK1";
         edtVendedorFoto_Internalname = "VENDEDORFOTO";
         edtVendedorNome_Internalname = "VENDEDORNOME";
         edtProdutoId_Internalname = "PRODUTOID";
         edtProdutoNome_Internalname = "PRODUTONOME";
         edtProdutoImagem_Internalname = "PRODUTOIMAGEM";
         edtCategoriaProdutoNome_Internalname = "CATEGORIAPRODUTONOME";
         edtProdutoPreco_Internalname = "PRODUTOPRECO";
         edtavTotal_Internalname = "vTOTAL";
         tblTable1_Internalname = "TABLE1";
         divGrid1table_Internalname = "GRID1TABLE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGrid2_Internalname = "GRID2";
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
         subGrid2_Allowcollapsing = 0;
         subGrid2_Allowselection = 0;
         subGrid2_Header = "";
         subGrid1_Allowcollapsing = 0;
         edtavTotal_Jsonclick = "";
         edtVendedorNome_Jsonclick = "";
         subGrid1_Class = "FreeStyleGrid";
         edtProdutoPreco_Jsonclick = "";
         edtCategoriaProdutoNome_Jsonclick = "";
         edtProdutoNome_Jsonclick = "";
         edtProdutoId_Jsonclick = "";
         subGrid2_Class = "Grid";
         subGrid2_Backcolorstyle = 0;
         subGrid1_Backcolorstyle = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Vendedores e Produtos";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID1_nFirstRecordOnPage'},{av:'GRID1_nEOF'},{av:'GRID2_nFirstRecordOnPage'},{av:'GRID2_nEOF'},{av:'A6VendedorId',fld:'VENDEDORID',pic:'ZZZ9'},{av:'AV5Total',fld:'vTOTAL',pic:'ZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("GRID2.LOAD","{handler:'E120Y3',iparms:[{av:'AV5Total',fld:'vTOTAL',pic:'ZZZ9'}]");
         setEventMetadata("GRID2.LOAD",",oparms:[{av:'AV5Total',fld:'vTOTAL',pic:'ZZZ9'}]}");
         setEventMetadata("GRID2.REFRESH","{handler:'E130Y2',iparms:[]");
         setEventMetadata("GRID2.REFRESH",",oparms:[{av:'AV5Total',fld:'vTOTAL',pic:'ZZZ9'}]}");
         setEventMetadata("NULL","{handler:'Valid_Produtopreco',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Total',iparms:[]");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblTextblock1_Jsonclick = "";
         Grid1Container = new GXWebGrid( context);
         sStyleString = "";
         Grid2Container = new GXWebGrid( context);
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A8VendedorFoto = "";
         A40000VendedorFoto_GXI = "";
         A7VendedorNome = "";
         A20ProdutoNome = "";
         A23ProdutoImagem = "";
         A40002ProdutoImagem_GXI = "";
         A31CategoriaProdutoNome = "";
         scmdbuf = "";
         H000Y2_A6VendedorId = new short[1] ;
         H000Y2_A7VendedorNome = new string[] {""} ;
         H000Y2_A40000VendedorFoto_GXI = new string[] {""} ;
         H000Y2_A8VendedorFoto = new string[] {""} ;
         H000Y3_A30CategoriaProdutoId = new short[1] ;
         H000Y3_A24VendedorProdutoId = new short[1] ;
         H000Y3_A22ProdutoPreco = new decimal[1] ;
         H000Y3_A31CategoriaProdutoNome = new string[] {""} ;
         H000Y3_A40002ProdutoImagem_GXI = new string[] {""} ;
         H000Y3_A20ProdutoNome = new string[] {""} ;
         H000Y3_A19ProdutoId = new short[1] ;
         H000Y3_A23ProdutoImagem = new string[] {""} ;
         Grid1Row = new GXWebRow();
         Grid2Row = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid2_Linesclass = "";
         ROClassString = "";
         ClassString = "";
         StyleString = "";
         sImgUrl = "";
         subGrid1_Linesclass = "";
         GXCCtl = "";
         subGrid1_Header = "";
         Grid1Column = new GXWebColumn();
         Grid2Column = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.vendedoreseprodutos__default(),
            new Object[][] {
                new Object[] {
               H000Y2_A6VendedorId, H000Y2_A7VendedorNome, H000Y2_A40000VendedorFoto_GXI, H000Y2_A8VendedorFoto
               }
               , new Object[] {
               H000Y3_A30CategoriaProdutoId, H000Y3_A24VendedorProdutoId, H000Y3_A22ProdutoPreco, H000Y3_A31CategoriaProdutoNome, H000Y3_A40002ProdutoImagem_GXI, H000Y3_A20ProdutoNome, H000Y3_A19ProdutoId, H000Y3_A23ProdutoImagem
               }
            }
         );
         /* GeneXus formulas. */
         context.Gx_err = 0;
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short A6VendedorId ;
      private short AV5Total ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short wbEnd ;
      private short wbStart ;
      private short A19ProdutoId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid1_Backcolorstyle ;
      private short subGrid2_Backcolorstyle ;
      private short A30CategoriaProdutoId ;
      private short A24VendedorProdutoId ;
      private short subGrid2_Backstyle ;
      private short subGrid1_Backstyle ;
      private short subGrid1_Allowselection ;
      private short subGrid1_Allowhovering ;
      private short subGrid1_Allowcollapsing ;
      private short subGrid1_Collapsed ;
      private short subGrid2_Titlebackstyle ;
      private short subGrid2_Allowselection ;
      private short subGrid2_Allowhovering ;
      private short subGrid2_Allowcollapsing ;
      private short subGrid2_Collapsed ;
      private short GRID1_nEOF ;
      private short GRID2_nEOF ;
      private int nRC_GXsfl_25 ;
      private int nGXsfl_25_idx=1 ;
      private int nRC_GXsfl_9 ;
      private int nGXsfl_9_idx=1 ;
      private int subGrid1_Islastpage ;
      private int subGrid2_Islastpage ;
      private int idxLst ;
      private int subGrid2_Backcolor ;
      private int subGrid2_Allbackcolor ;
      private int subGrid1_Backcolor ;
      private int subGrid1_Allbackcolor ;
      private int subGrid1_Selectedindex ;
      private int subGrid1_Selectioncolor ;
      private int subGrid1_Hoveringcolor ;
      private int subGrid2_Titlebackcolor ;
      private int subGrid2_Selectedindex ;
      private int subGrid2_Selectioncolor ;
      private int subGrid2_Hoveringcolor ;
      private long GRID2_nCurrentRecord ;
      private long GRID1_nCurrentRecord ;
      private long GRID1_nFirstRecordOnPage ;
      private long GRID2_nFirstRecordOnPage ;
      private decimal A22ProdutoPreco ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_25_idx="0001" ;
      private string sGXsfl_9_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divMaintable_Internalname ;
      private string lblTextblock1_Internalname ;
      private string lblTextblock1_Jsonclick ;
      private string sStyleString ;
      private string subGrid1_Internalname ;
      private string subGrid2_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtVendedorFoto_Internalname ;
      private string edtVendedorNome_Internalname ;
      private string edtavTotal_Internalname ;
      private string edtProdutoId_Internalname ;
      private string edtProdutoNome_Internalname ;
      private string edtProdutoImagem_Internalname ;
      private string edtCategoriaProdutoNome_Internalname ;
      private string edtProdutoPreco_Internalname ;
      private string scmdbuf ;
      private string sGXsfl_25_fel_idx="0001" ;
      private string subGrid2_Class ;
      private string subGrid2_Linesclass ;
      private string ROClassString ;
      private string edtProdutoId_Jsonclick ;
      private string edtProdutoNome_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string sImgUrl ;
      private string edtCategoriaProdutoNome_Jsonclick ;
      private string edtProdutoPreco_Jsonclick ;
      private string sGXsfl_9_fel_idx="0001" ;
      private string subGrid1_Class ;
      private string subGrid1_Linesclass ;
      private string divGrid1table_Internalname ;
      private string edtVendedorNome_Jsonclick ;
      private string tblTable1_Internalname ;
      private string GXCCtl ;
      private string edtavTotal_Jsonclick ;
      private string subGrid1_Header ;
      private string subGrid2_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_9_Refreshing=false ;
      private bool bGXsfl_25_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool A23ProdutoImagem_IsBlob ;
      private bool A8VendedorFoto_IsBlob ;
      private string A40000VendedorFoto_GXI ;
      private string A7VendedorNome ;
      private string A20ProdutoNome ;
      private string A40002ProdutoImagem_GXI ;
      private string A31CategoriaProdutoNome ;
      private string A8VendedorFoto ;
      private string A23ProdutoImagem ;
      private GXWebGrid Grid1Container ;
      private GXWebGrid Grid2Container ;
      private GXWebRow Grid1Row ;
      private GXWebRow Grid2Row ;
      private GXWebColumn Grid1Column ;
      private GXWebColumn Grid2Column ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H000Y2_A6VendedorId ;
      private string[] H000Y2_A7VendedorNome ;
      private string[] H000Y2_A40000VendedorFoto_GXI ;
      private string[] H000Y2_A8VendedorFoto ;
      private short[] H000Y3_A30CategoriaProdutoId ;
      private short[] H000Y3_A24VendedorProdutoId ;
      private decimal[] H000Y3_A22ProdutoPreco ;
      private string[] H000Y3_A31CategoriaProdutoNome ;
      private string[] H000Y3_A40002ProdutoImagem_GXI ;
      private string[] H000Y3_A20ProdutoNome ;
      private short[] H000Y3_A19ProdutoId ;
      private string[] H000Y3_A23ProdutoImagem ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
   }

   public class vendedoreseprodutos__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH000Y2;
          prmH000Y2 = new Object[] {
          };
          Object[] prmH000Y3;
          prmH000Y3 = new Object[] {
          new ParDef("@VendedorId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H000Y2", "SELECT [VendedorId], [VendedorNome], [VendedorFoto_GXI], [VendedorFoto] FROM [Vendedor] ORDER BY [VendedorId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y2,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H000Y3", "SELECT T1.[CategoriaProdutoId] AS CategoriaProdutoId, T1.[VendedorProdutoId], T1.[ProdutoPreco], T2.[CategoriaNome] AS CategoriaProdutoNome, T1.[ProdutoImagem_GXI], T1.[ProdutoNome], T1.[ProdutoId], T1.[ProdutoImagem] FROM ([Produto] T1 INNER JOIN [Categoria] T2 ON T2.[CategoriaId] = T1.[CategoriaProdutoId]) WHERE T1.[VendedorProdutoId] = @VendedorId ORDER BY T1.[VendedorProdutoId] ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH000Y3,11, GxCacheFrequency.OFF ,false,false )
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
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((string[]) buf[3])[0] = rslt.getMultimediaFile(4, rslt.getVarchar(3));
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((decimal[]) buf[2])[0] = rslt.getDecimal(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getMultimediaUri(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((short[]) buf[6])[0] = rslt.getShort(7);
                ((string[]) buf[7])[0] = rslt.getMultimediaFile(8, rslt.getVarchar(5));
                return;
       }
    }

 }

}
