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
   public class cartaopontos : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_12") == 0 )
         {
            A41CartaoPontosId = (short)(NumberUtil.Val( GetPar( "CartaoPontosId"), "."));
            AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_12( A41CartaoPontosId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_11") == 0 )
         {
            A50ClienteCartaoPontosId = (short)(NumberUtil.Val( GetPar( "ClienteCartaoPontosId"), "."));
            AssignAttri("", false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_11( A50ClienteCartaoPontosId) ;
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
               AV7CartaoPontosId = (short)(NumberUtil.Val( GetPar( "CartaoPontosId"), "."));
               AssignAttri("", false, "AV7CartaoPontosId", StringUtil.LTrimStr( (decimal)(AV7CartaoPontosId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vCARTAOPONTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CartaoPontosId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Cartão de pontos", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCartaoPontosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cartaopontos( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public cartaopontos( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_CartaoPontosId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CartaoPontosId = aP1_CartaoPontosId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Cartão de pontos", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_CartaoPontos.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CartaoPontos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_CartaoPontos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_CartaoPontos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_CartaoPontos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_CartaoPontos.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtCartaoPontosId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCartaoPontosId_Internalname, "de pontos", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCartaoPontosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A41CartaoPontosId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A41CartaoPontosId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCartaoPontosId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CartaoPontos.htm");
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
         GxWebStd.gx_label_element( context, edtCartaoPontosDescricao_Internalname, "Descrição", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCartaoPontosDescricao_Internalname, A42CartaoPontosDescricao, StringUtil.RTrim( context.localUtil.Format( A42CartaoPontosDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosDescricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCartaoPontosDescricao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_CartaoPontos.htm");
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
         GxWebStd.gx_label_element( context, edtClienteCartaoPontosId_Internalname, "Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtClienteCartaoPontosId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ClienteCartaoPontosId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A50ClienteCartaoPontosId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCartaoPontosId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCartaoPontosId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_CartaoPontos.htm");
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_50_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_50_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         GxWebStd.gx_bitmap( context, imgprompt_50_Internalname, sImgUrl, imgprompt_50_Link, "", "", context.GetTheme( ), imgprompt_50_Visible, 1, "", "", 0, 0, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_CartaoPontos.htm");
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
         GxWebStd.gx_label_element( context, edtClienteCartaoPontosNome_Internalname, "Cliente", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtClienteCartaoPontosNome_Internalname, A51ClienteCartaoPontosNome, StringUtil.RTrim( context.localUtil.Format( A51ClienteCartaoPontosNome, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtClienteCartaoPontosNome_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtClienteCartaoPontosNome_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "Nome", "left", true, "", "HLP_CartaoPontos.htm");
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
         GxWebStd.gx_label_element( context, edtCartaoPontosAcumulados_Internalname, "Pontos Acumulados", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCartaoPontosAcumulados_Internalname, StringUtil.LTrim( StringUtil.NToC( A66CartaoPontosAcumulados, 10, 2, ".", "")), StringUtil.LTrim( ((edtCartaoPontosAcumulados_Enabled!=0) ? context.localUtil.Format( A66CartaoPontosAcumulados, "ZZZZZZ9.99") : context.localUtil.Format( A66CartaoPontosAcumulados, "ZZZZZZ9.99"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCartaoPontosAcumulados_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtCartaoPontosAcumulados_Enabled, 0, "text", "", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_CartaoPontos.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_CartaoPontos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 61,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_CartaoPontos.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_CartaoPontos.htm");
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
         E110A2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z41CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( "Z41CartaoPontosId"), ".", ","));
               Z42CartaoPontosDescricao = cgiGet( "Z42CartaoPontosDescricao");
               Z50ClienteCartaoPontosId = (short)(context.localUtil.CToN( cgiGet( "Z50ClienteCartaoPontosId"), ".", ","));
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               N50ClienteCartaoPontosId = (short)(context.localUtil.CToN( cgiGet( "N50ClienteCartaoPontosId"), ".", ","));
               AV7CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( "vCARTAOPONTOSID"), ".", ","));
               AV11Insert_ClienteCartaoPontosId = (short)(context.localUtil.CToN( cgiGet( "vINSERT_CLIENTECARTAOPONTOSID"), ".", ","));
               AV13Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtCartaoPontosId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtCartaoPontosId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CARTAOPONTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtCartaoPontosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A41CartaoPontosId = 0;
                  AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
               }
               else
               {
                  A41CartaoPontosId = (short)(context.localUtil.CToN( cgiGet( edtCartaoPontosId_Internalname), ".", ","));
                  AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
               }
               A42CartaoPontosDescricao = cgiGet( edtCartaoPontosDescricao_Internalname);
               AssignAttri("", false, "A42CartaoPontosDescricao", A42CartaoPontosDescricao);
               if ( ( ( context.localUtil.CToN( cgiGet( edtClienteCartaoPontosId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtClienteCartaoPontosId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "CLIENTECARTAOPONTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtClienteCartaoPontosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A50ClienteCartaoPontosId = 0;
                  AssignAttri("", false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
               }
               else
               {
                  A50ClienteCartaoPontosId = (short)(context.localUtil.CToN( cgiGet( edtClienteCartaoPontosId_Internalname), ".", ","));
                  AssignAttri("", false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
               }
               A51ClienteCartaoPontosNome = cgiGet( edtClienteCartaoPontosNome_Internalname);
               AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
               A66CartaoPontosAcumulados = context.localUtil.CToN( cgiGet( edtCartaoPontosAcumulados_Internalname), ".", ",");
               n66CartaoPontosAcumulados = false;
               AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CartaoPontos");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A41CartaoPontosId != Z41CartaoPontosId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("cartaopontos:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A41CartaoPontosId = (short)(NumberUtil.Val( GetPar( "CartaoPontosId"), "."));
                  AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
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
                     sMode10 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode10;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound10 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0A0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CARTAOPONTOSID");
                        AnyError = 1;
                        GX_FocusControl = edtCartaoPontosId_Internalname;
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
                           E110A2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120A2 ();
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
            E120A2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A10( ) ;
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
            DisableAttributes0A10( ) ;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A10( ) ;
            }
            else
            {
               CheckExtendedTable0A10( ) ;
               CloseExtendedTableCursors0A10( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0A0( )
      {
      }

      protected void E110A2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV13Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV13Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         AV11Insert_ClienteCartaoPontosId = 0;
         AssignAttri("", false, "AV11Insert_ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteCartaoPontosId), 4, 0));
         if ( ( StringUtil.StrCmp(AV9TrnContext.gxTpr_Transactionname, AV13Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV14GXV1 = 1;
            AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
            while ( AV14GXV1 <= AV9TrnContext.gxTpr_Attributes.Count )
            {
               AV12TrnContextAtt = ((GeneXus.Programs.general.ui.SdtTransactionContext_Attribute)AV9TrnContext.gxTpr_Attributes.Item(AV14GXV1));
               if ( StringUtil.StrCmp(AV12TrnContextAtt.gxTpr_Attributename, "ClienteCartaoPontosId") == 0 )
               {
                  AV11Insert_ClienteCartaoPontosId = (short)(NumberUtil.Val( AV12TrnContextAtt.gxTpr_Attributevalue, "."));
                  AssignAttri("", false, "AV11Insert_ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(AV11Insert_ClienteCartaoPontosId), 4, 0));
               }
               AV14GXV1 = (int)(AV14GXV1+1);
               AssignAttri("", false, "AV14GXV1", StringUtil.LTrimStr( (decimal)(AV14GXV1), 8, 0));
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

      protected void E120A2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwcartaopontos.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 9 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z42CartaoPontosDescricao = T000A3_A42CartaoPontosDescricao[0];
               Z50ClienteCartaoPontosId = T000A3_A50ClienteCartaoPontosId[0];
            }
            else
            {
               Z42CartaoPontosDescricao = A42CartaoPontosDescricao;
               Z50ClienteCartaoPontosId = A50ClienteCartaoPontosId;
            }
         }
         if ( GX_JID == -9 )
         {
            Z41CartaoPontosId = A41CartaoPontosId;
            Z42CartaoPontosDescricao = A42CartaoPontosDescricao;
            Z50ClienteCartaoPontosId = A50ClienteCartaoPontosId;
            Z66CartaoPontosAcumulados = A66CartaoPontosAcumulados;
            Z51ClienteCartaoPontosNome = A51ClienteCartaoPontosNome;
         }
      }

      protected void standaloneNotModal( )
      {
         imgprompt_50_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx00b0.aspx"+"',["+"{Ctrl:gx.dom.el('"+"CLIENTECARTAOPONTOSID"+"'), id:'"+"CLIENTECARTAOPONTOSID"+"'"+",IOType:'out'}"+"],"+"null"+","+"'', false"+","+"false"+");");
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7CartaoPontosId) )
         {
            A41CartaoPontosId = AV7CartaoPontosId;
            AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
         }
         if ( ! (0==AV7CartaoPontosId) )
         {
            edtCartaoPontosId_Enabled = 0;
            AssignProp("", false, edtCartaoPontosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosId_Enabled), 5, 0), true);
         }
         else
         {
            edtCartaoPontosId_Enabled = 1;
            AssignProp("", false, edtCartaoPontosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7CartaoPontosId) )
         {
            edtCartaoPontosId_Enabled = 0;
            AssignProp("", false, edtCartaoPontosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosId_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteCartaoPontosId) )
         {
            edtClienteCartaoPontosId_Enabled = 0;
            AssignProp("", false, edtClienteCartaoPontosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCartaoPontosId_Enabled), 5, 0), true);
         }
         else
         {
            edtClienteCartaoPontosId_Enabled = 1;
            AssignProp("", false, edtClienteCartaoPontosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCartaoPontosId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV11Insert_ClienteCartaoPontosId) )
         {
            A50ClienteCartaoPontosId = AV11Insert_ClienteCartaoPontosId;
            AssignAttri("", false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
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
            /* Using cursor T000A7 */
            pr_default.execute(3, new Object[] {A41CartaoPontosId});
            if ( (pr_default.getStatus(3) != 101) )
            {
               A66CartaoPontosAcumulados = T000A7_A66CartaoPontosAcumulados[0];
               n66CartaoPontosAcumulados = T000A7_n66CartaoPontosAcumulados[0];
               AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
            }
            else
            {
               A66CartaoPontosAcumulados = 0;
               n66CartaoPontosAcumulados = false;
               AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
            }
            pr_default.close(3);
            AV13Pgmname = "CartaoPontos";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000A4 */
            pr_default.execute(2, new Object[] {A50ClienteCartaoPontosId});
            A51ClienteCartaoPontosNome = T000A4_A51ClienteCartaoPontosNome[0];
            AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
            pr_default.close(2);
         }
      }

      protected void Load0A10( )
      {
         /* Using cursor T000A10 */
         pr_default.execute(4, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound10 = 1;
            A42CartaoPontosDescricao = T000A10_A42CartaoPontosDescricao[0];
            AssignAttri("", false, "A42CartaoPontosDescricao", A42CartaoPontosDescricao);
            A51ClienteCartaoPontosNome = T000A10_A51ClienteCartaoPontosNome[0];
            AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
            A50ClienteCartaoPontosId = T000A10_A50ClienteCartaoPontosId[0];
            AssignAttri("", false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
            A66CartaoPontosAcumulados = T000A10_A66CartaoPontosAcumulados[0];
            n66CartaoPontosAcumulados = T000A10_n66CartaoPontosAcumulados[0];
            AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
            ZM0A10( -9) ;
         }
         pr_default.close(4);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
         AV13Pgmname = "CartaoPontos";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV13Pgmname = "CartaoPontos";
         AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
         /* Using cursor T000A7 */
         pr_default.execute(3, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            A66CartaoPontosAcumulados = T000A7_A66CartaoPontosAcumulados[0];
            n66CartaoPontosAcumulados = T000A7_n66CartaoPontosAcumulados[0];
            AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         }
         else
         {
            nIsDirty_10 = 1;
            A66CartaoPontosAcumulados = 0;
            n66CartaoPontosAcumulados = false;
            AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         }
         pr_default.close(3);
         /* Using cursor T000A11 */
         pr_default.execute(5, new Object[] {A50ClienteCartaoPontosId, A41CartaoPontosId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Cliente"}), 1, "CLIENTECARTAOPONTOSID");
            AnyError = 1;
            GX_FocusControl = edtClienteCartaoPontosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {A50ClienteCartaoPontosId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTECARTAOPONTOSID");
            AnyError = 1;
            GX_FocusControl = edtClienteCartaoPontosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A51ClienteCartaoPontosNome = T000A4_A51ClienteCartaoPontosNome[0];
         AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0A10( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_12( short A41CartaoPontosId )
      {
         /* Using cursor T000A14 */
         pr_default.execute(6, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            A66CartaoPontosAcumulados = T000A14_A66CartaoPontosAcumulados[0];
            n66CartaoPontosAcumulados = T000A14_n66CartaoPontosAcumulados[0];
            AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         }
         else
         {
            A66CartaoPontosAcumulados = 0;
            n66CartaoPontosAcumulados = false;
            AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A66CartaoPontosAcumulados, 10, 2, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_11( short A50ClienteCartaoPontosId )
      {
         /* Using cursor T000A15 */
         pr_default.execute(7, new Object[] {A50ClienteCartaoPontosId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTECARTAOPONTOSID");
            AnyError = 1;
            GX_FocusControl = edtClienteCartaoPontosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A51ClienteCartaoPontosNome = T000A15_A51ClienteCartaoPontosNome[0];
         AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A51ClienteCartaoPontosNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey0A10( )
      {
         /* Using cursor T000A16 */
         pr_default.execute(8, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A10( 9) ;
            RcdFound10 = 1;
            A41CartaoPontosId = T000A3_A41CartaoPontosId[0];
            AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
            A42CartaoPontosDescricao = T000A3_A42CartaoPontosDescricao[0];
            AssignAttri("", false, "A42CartaoPontosDescricao", A42CartaoPontosDescricao);
            A50ClienteCartaoPontosId = T000A3_A50ClienteCartaoPontosId[0];
            AssignAttri("", false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
            Z41CartaoPontosId = A41CartaoPontosId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound10 = 0;
         /* Using cursor T000A17 */
         pr_default.execute(9, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000A17_A41CartaoPontosId[0] < A41CartaoPontosId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000A17_A41CartaoPontosId[0] > A41CartaoPontosId ) ) )
            {
               A41CartaoPontosId = T000A17_A41CartaoPontosId[0];
               AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000A18 */
         pr_default.execute(10, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000A18_A41CartaoPontosId[0] > A41CartaoPontosId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000A18_A41CartaoPontosId[0] < A41CartaoPontosId ) ) )
            {
               A41CartaoPontosId = T000A18_A41CartaoPontosId[0];
               AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCartaoPontosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A10( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A41CartaoPontosId != Z41CartaoPontosId )
               {
                  A41CartaoPontosId = Z41CartaoPontosId;
                  AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CARTAOPONTOSID");
                  AnyError = 1;
                  GX_FocusControl = edtCartaoPontosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCartaoPontosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0A10( ) ;
                  GX_FocusControl = edtCartaoPontosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A41CartaoPontosId != Z41CartaoPontosId )
               {
                  /* Insert record */
                  GX_FocusControl = edtCartaoPontosId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A10( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CARTAOPONTOSID");
                     AnyError = 1;
                     GX_FocusControl = edtCartaoPontosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCartaoPontosId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A10( ) ;
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
         if ( A41CartaoPontosId != Z41CartaoPontosId )
         {
            A41CartaoPontosId = Z41CartaoPontosId;
            AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CARTAOPONTOSID");
            AnyError = 1;
            GX_FocusControl = edtCartaoPontosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCartaoPontosId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A41CartaoPontosId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CartaoPontos"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z42CartaoPontosDescricao, T000A2_A42CartaoPontosDescricao[0]) != 0 ) || ( Z50ClienteCartaoPontosId != T000A2_A50ClienteCartaoPontosId[0] ) )
            {
               if ( StringUtil.StrCmp(Z42CartaoPontosDescricao, T000A2_A42CartaoPontosDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("cartaopontos:[seudo value changed for attri]"+"CartaoPontosDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z42CartaoPontosDescricao);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A42CartaoPontosDescricao[0]);
               }
               if ( Z50ClienteCartaoPontosId != T000A2_A50ClienteCartaoPontosId[0] )
               {
                  GXUtil.WriteLog("cartaopontos:[seudo value changed for attri]"+"ClienteCartaoPontosId");
                  GXUtil.WriteLogRaw("Old: ",Z50ClienteCartaoPontosId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A50ClienteCartaoPontosId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"CartaoPontos"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A19 */
                     pr_default.execute(11, new Object[] {A41CartaoPontosId, A42CartaoPontosDescricao, A50ClienteCartaoPontosId});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("CartaoPontos");
                     if ( (pr_default.getStatus(11) == 1) )
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
                           ResetCaption0A0( ) ;
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
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A20 */
                     pr_default.execute(12, new Object[] {A42CartaoPontosDescricao, A50ClienteCartaoPontosId, A41CartaoPontosId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("CartaoPontos");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"CartaoPontos"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A21 */
                  pr_default.execute(13, new Object[] {A41CartaoPontosId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("CartaoPontos");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV13Pgmname = "CartaoPontos";
            AssignAttri("", false, "AV13Pgmname", AV13Pgmname);
            /* Using cursor T000A24 */
            pr_default.execute(14, new Object[] {A41CartaoPontosId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               A66CartaoPontosAcumulados = T000A24_A66CartaoPontosAcumulados[0];
               n66CartaoPontosAcumulados = T000A24_n66CartaoPontosAcumulados[0];
               AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
            }
            else
            {
               A66CartaoPontosAcumulados = 0;
               n66CartaoPontosAcumulados = false;
               AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
            }
            pr_default.close(14);
            /* Using cursor T000A25 */
            pr_default.execute(15, new Object[] {A50ClienteCartaoPontosId});
            A51ClienteCartaoPontosNome = T000A25_A51ClienteCartaoPontosNome[0];
            AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000A26 */
            pr_default.execute(16, new Object[] {A41CartaoPontosId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Cliente"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
         }
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(14);
            context.CommitDataStores("cartaopontos",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(1);
            pr_default.close(15);
            pr_default.close(14);
            context.RollbackDataStores("cartaopontos",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A10( )
      {
         /* Scan By routine */
         /* Using cursor T000A27 */
         pr_default.execute(17);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound10 = 1;
            A41CartaoPontosId = T000A27_A41CartaoPontosId[0];
            AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(17);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound10 = 1;
            A41CartaoPontosId = T000A27_A41CartaoPontosId[0];
            AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
         }
      }

      protected void ScanEnd0A10( )
      {
         pr_default.close(17);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
         edtCartaoPontosId_Enabled = 0;
         AssignProp("", false, edtCartaoPontosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosId_Enabled), 5, 0), true);
         edtCartaoPontosDescricao_Enabled = 0;
         AssignProp("", false, edtCartaoPontosDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosDescricao_Enabled), 5, 0), true);
         edtClienteCartaoPontosId_Enabled = 0;
         AssignProp("", false, edtClienteCartaoPontosId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCartaoPontosId_Enabled), 5, 0), true);
         edtClienteCartaoPontosNome_Enabled = 0;
         AssignProp("", false, edtClienteCartaoPontosNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtClienteCartaoPontosNome_Enabled), 5, 0), true);
         edtCartaoPontosAcumulados_Enabled = 0;
         AssignProp("", false, edtCartaoPontosAcumulados_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCartaoPontosAcumulados_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("cartaopontos.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CartaoPontosId,4,0))}, new string[] {"Gx_mode","CartaoPontosId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CartaoPontos");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("cartaopontos:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z41CartaoPontosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z41CartaoPontosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z42CartaoPontosDescricao", Z42CartaoPontosDescricao);
         GxWebStd.gx_hidden_field( context, "Z50ClienteCartaoPontosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z50ClienteCartaoPontosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N50ClienteCartaoPontosId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A50ClienteCartaoPontosId), 4, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vCARTAOPONTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CartaoPontosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCARTAOPONTOSID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CartaoPontosId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vINSERT_CLIENTECARTAOPONTOSID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV11Insert_ClienteCartaoPontosId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV13Pgmname));
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
         return formatLink("cartaopontos.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7CartaoPontosId,4,0))}, new string[] {"Gx_mode","CartaoPontosId"})  ;
      }

      public override string GetPgmname( )
      {
         return "CartaoPontos" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cartão de pontos" ;
      }

      protected void InitializeNonKey0A10( )
      {
         A50ClienteCartaoPontosId = 0;
         AssignAttri("", false, "A50ClienteCartaoPontosId", StringUtil.LTrimStr( (decimal)(A50ClienteCartaoPontosId), 4, 0));
         A42CartaoPontosDescricao = "";
         AssignAttri("", false, "A42CartaoPontosDescricao", A42CartaoPontosDescricao);
         A51ClienteCartaoPontosNome = "";
         AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
         A66CartaoPontosAcumulados = 0;
         n66CartaoPontosAcumulados = false;
         AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrimStr( A66CartaoPontosAcumulados, 10, 2));
         Z42CartaoPontosDescricao = "";
         Z50ClienteCartaoPontosId = 0;
      }

      protected void InitAll0A10( )
      {
         A41CartaoPontosId = 0;
         AssignAttri("", false, "A41CartaoPontosId", StringUtil.LTrimStr( (decimal)(A41CartaoPontosId), 4, 0));
         InitializeNonKey0A10( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916514125", true, true);
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
         context.AddJavascriptSource("cartaopontos.js", "?202582916514125", false, true);
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
         edtCartaoPontosId_Internalname = "CARTAOPONTOSID";
         edtCartaoPontosDescricao_Internalname = "CARTAOPONTOSDESCRICAO";
         edtClienteCartaoPontosId_Internalname = "CLIENTECARTAOPONTOSID";
         edtClienteCartaoPontosNome_Internalname = "CLIENTECARTAOPONTOSNOME";
         edtCartaoPontosAcumulados_Internalname = "CARTAOPONTOSACUMULADOS";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_50_Internalname = "PROMPT_50";
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
         Form.Caption = "Cartão de pontos";
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtCartaoPontosAcumulados_Jsonclick = "";
         edtCartaoPontosAcumulados_Enabled = 0;
         edtClienteCartaoPontosNome_Jsonclick = "";
         edtClienteCartaoPontosNome_Enabled = 0;
         imgprompt_50_Visible = 1;
         imgprompt_50_Link = "";
         edtClienteCartaoPontosId_Jsonclick = "";
         edtClienteCartaoPontosId_Enabled = 1;
         edtCartaoPontosDescricao_Jsonclick = "";
         edtCartaoPontosDescricao_Enabled = 1;
         edtCartaoPontosId_Jsonclick = "";
         edtCartaoPontosId_Enabled = 1;
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

      public void Valid_Cartaopontosid( )
      {
         n66CartaoPontosAcumulados = false;
         /* Using cursor T000A24 */
         pr_default.execute(14, new Object[] {A41CartaoPontosId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            A66CartaoPontosAcumulados = T000A24_A66CartaoPontosAcumulados[0];
            n66CartaoPontosAcumulados = T000A24_n66CartaoPontosAcumulados[0];
         }
         else
         {
            A66CartaoPontosAcumulados = 0;
            n66CartaoPontosAcumulados = false;
         }
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A66CartaoPontosAcumulados", StringUtil.LTrim( StringUtil.NToC( A66CartaoPontosAcumulados, 10, 2, ".", "")));
      }

      public void Valid_Clientecartaopontosid( )
      {
         /* Using cursor T000A25 */
         pr_default.execute(15, new Object[] {A50ClienteCartaoPontosId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GX_msglist.addItem("No matching 'Cliente'.", "ForeignKeyNotFound", 1, "CLIENTECARTAOPONTOSID");
            AnyError = 1;
            GX_FocusControl = edtClienteCartaoPontosId_Internalname;
         }
         A51ClienteCartaoPontosNome = T000A25_A51ClienteCartaoPontosNome[0];
         pr_default.close(15);
         /* Using cursor T000A28 */
         pr_default.execute(18, new Object[] {A50ClienteCartaoPontosId, A41CartaoPontosId});
         if ( (pr_default.getStatus(18) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Cliente"}), 1, "CLIENTECARTAOPONTOSID");
            AnyError = 1;
            GX_FocusControl = edtClienteCartaoPontosId_Internalname;
         }
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A51ClienteCartaoPontosNome", A51ClienteCartaoPontosNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CartaoPontosId',fld:'vCARTAOPONTOSID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CartaoPontosId',fld:'vCARTAOPONTOSID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120A2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CARTAOPONTOSID","{handler:'Valid_Cartaopontosid',iparms:[{av:'A41CartaoPontosId',fld:'CARTAOPONTOSID',pic:'ZZZ9'},{av:'A66CartaoPontosAcumulados',fld:'CARTAOPONTOSACUMULADOS',pic:'ZZZZZZ9.99'}]");
         setEventMetadata("VALID_CARTAOPONTOSID",",oparms:[{av:'A66CartaoPontosAcumulados',fld:'CARTAOPONTOSACUMULADOS',pic:'ZZZZZZ9.99'}]}");
         setEventMetadata("VALID_CLIENTECARTAOPONTOSID","{handler:'Valid_Clientecartaopontosid',iparms:[{av:'A50ClienteCartaoPontosId',fld:'CLIENTECARTAOPONTOSID',pic:'ZZZ9'},{av:'A41CartaoPontosId',fld:'CARTAOPONTOSID',pic:'ZZZ9'},{av:'A51ClienteCartaoPontosNome',fld:'CLIENTECARTAOPONTOSNOME',pic:''}]");
         setEventMetadata("VALID_CLIENTECARTAOPONTOSID",",oparms:[{av:'A51ClienteCartaoPontosNome',fld:'CLIENTECARTAOPONTOSNOME',pic:''}]}");
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
         pr_default.close(15);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z42CartaoPontosDescricao = "";
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
         A42CartaoPontosDescricao = "";
         imgprompt_50_gximage = "";
         sImgUrl = "";
         A51ClienteCartaoPontosNome = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         AV13Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode10 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         AV12TrnContextAtt = new GeneXus.Programs.general.ui.SdtTransactionContext_Attribute(context);
         Z51ClienteCartaoPontosNome = "";
         T000A7_A66CartaoPontosAcumulados = new decimal[1] ;
         T000A7_n66CartaoPontosAcumulados = new bool[] {false} ;
         T000A4_A51ClienteCartaoPontosNome = new string[] {""} ;
         T000A10_A41CartaoPontosId = new short[1] ;
         T000A10_A42CartaoPontosDescricao = new string[] {""} ;
         T000A10_A51ClienteCartaoPontosNome = new string[] {""} ;
         T000A10_A50ClienteCartaoPontosId = new short[1] ;
         T000A10_A66CartaoPontosAcumulados = new decimal[1] ;
         T000A10_n66CartaoPontosAcumulados = new bool[] {false} ;
         T000A11_A50ClienteCartaoPontosId = new short[1] ;
         T000A14_A66CartaoPontosAcumulados = new decimal[1] ;
         T000A14_n66CartaoPontosAcumulados = new bool[] {false} ;
         T000A15_A51ClienteCartaoPontosNome = new string[] {""} ;
         T000A16_A41CartaoPontosId = new short[1] ;
         T000A3_A41CartaoPontosId = new short[1] ;
         T000A3_A42CartaoPontosDescricao = new string[] {""} ;
         T000A3_A50ClienteCartaoPontosId = new short[1] ;
         T000A17_A41CartaoPontosId = new short[1] ;
         T000A18_A41CartaoPontosId = new short[1] ;
         T000A2_A41CartaoPontosId = new short[1] ;
         T000A2_A42CartaoPontosDescricao = new string[] {""} ;
         T000A2_A50ClienteCartaoPontosId = new short[1] ;
         T000A24_A66CartaoPontosAcumulados = new decimal[1] ;
         T000A24_n66CartaoPontosAcumulados = new bool[] {false} ;
         T000A25_A51ClienteCartaoPontosNome = new string[] {""} ;
         T000A26_A43ClienteId = new short[1] ;
         T000A27_A41CartaoPontosId = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         T000A28_A50ClienteCartaoPontosId = new short[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.cartaopontos__default(),
            new Object[][] {
                new Object[] {
               T000A2_A41CartaoPontosId, T000A2_A42CartaoPontosDescricao, T000A2_A50ClienteCartaoPontosId
               }
               , new Object[] {
               T000A3_A41CartaoPontosId, T000A3_A42CartaoPontosDescricao, T000A3_A50ClienteCartaoPontosId
               }
               , new Object[] {
               T000A4_A51ClienteCartaoPontosNome
               }
               , new Object[] {
               T000A7_A66CartaoPontosAcumulados, T000A7_n66CartaoPontosAcumulados
               }
               , new Object[] {
               T000A10_A41CartaoPontosId, T000A10_A42CartaoPontosDescricao, T000A10_A51ClienteCartaoPontosNome, T000A10_A50ClienteCartaoPontosId, T000A10_A66CartaoPontosAcumulados, T000A10_n66CartaoPontosAcumulados
               }
               , new Object[] {
               T000A11_A50ClienteCartaoPontosId
               }
               , new Object[] {
               T000A14_A66CartaoPontosAcumulados, T000A14_n66CartaoPontosAcumulados
               }
               , new Object[] {
               T000A15_A51ClienteCartaoPontosNome
               }
               , new Object[] {
               T000A16_A41CartaoPontosId
               }
               , new Object[] {
               T000A17_A41CartaoPontosId
               }
               , new Object[] {
               T000A18_A41CartaoPontosId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A24_A66CartaoPontosAcumulados, T000A24_n66CartaoPontosAcumulados
               }
               , new Object[] {
               T000A25_A51ClienteCartaoPontosNome
               }
               , new Object[] {
               T000A26_A43ClienteId
               }
               , new Object[] {
               T000A27_A41CartaoPontosId
               }
               , new Object[] {
               T000A28_A50ClienteCartaoPontosId
               }
            }
         );
         AV13Pgmname = "CartaoPontos";
      }

      private short wcpOAV7CartaoPontosId ;
      private short Z41CartaoPontosId ;
      private short Z50ClienteCartaoPontosId ;
      private short N50ClienteCartaoPontosId ;
      private short GxWebError ;
      private short A41CartaoPontosId ;
      private short A50ClienteCartaoPontosId ;
      private short AV7CartaoPontosId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short AV11Insert_ClienteCartaoPontosId ;
      private short RcdFound10 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_10 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtCartaoPontosId_Enabled ;
      private int edtCartaoPontosDescricao_Enabled ;
      private int edtClienteCartaoPontosId_Enabled ;
      private int imgprompt_50_Visible ;
      private int edtClienteCartaoPontosNome_Enabled ;
      private int edtCartaoPontosAcumulados_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int AV14GXV1 ;
      private int idxLst ;
      private decimal A66CartaoPontosAcumulados ;
      private decimal Z66CartaoPontosAcumulados ;
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
      private string edtCartaoPontosId_Internalname ;
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
      private string edtCartaoPontosId_Jsonclick ;
      private string edtCartaoPontosDescricao_Internalname ;
      private string edtCartaoPontosDescricao_Jsonclick ;
      private string edtClienteCartaoPontosId_Internalname ;
      private string edtClienteCartaoPontosId_Jsonclick ;
      private string imgprompt_50_gximage ;
      private string sImgUrl ;
      private string imgprompt_50_Internalname ;
      private string imgprompt_50_Link ;
      private string edtClienteCartaoPontosNome_Internalname ;
      private string edtClienteCartaoPontosNome_Jsonclick ;
      private string edtCartaoPontosAcumulados_Internalname ;
      private string edtCartaoPontosAcumulados_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string AV13Pgmname ;
      private string hsh ;
      private string sMode10 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool n66CartaoPontosAcumulados ;
      private bool returnInSub ;
      private string Z42CartaoPontosDescricao ;
      private string A42CartaoPontosDescricao ;
      private string A51ClienteCartaoPontosNome ;
      private string Z51ClienteCartaoPontosNome ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T000A7_A66CartaoPontosAcumulados ;
      private bool[] T000A7_n66CartaoPontosAcumulados ;
      private string[] T000A4_A51ClienteCartaoPontosNome ;
      private short[] T000A10_A41CartaoPontosId ;
      private string[] T000A10_A42CartaoPontosDescricao ;
      private string[] T000A10_A51ClienteCartaoPontosNome ;
      private short[] T000A10_A50ClienteCartaoPontosId ;
      private decimal[] T000A10_A66CartaoPontosAcumulados ;
      private bool[] T000A10_n66CartaoPontosAcumulados ;
      private short[] T000A11_A50ClienteCartaoPontosId ;
      private decimal[] T000A14_A66CartaoPontosAcumulados ;
      private bool[] T000A14_n66CartaoPontosAcumulados ;
      private string[] T000A15_A51ClienteCartaoPontosNome ;
      private short[] T000A16_A41CartaoPontosId ;
      private short[] T000A3_A41CartaoPontosId ;
      private string[] T000A3_A42CartaoPontosDescricao ;
      private short[] T000A3_A50ClienteCartaoPontosId ;
      private short[] T000A17_A41CartaoPontosId ;
      private short[] T000A18_A41CartaoPontosId ;
      private short[] T000A2_A41CartaoPontosId ;
      private string[] T000A2_A42CartaoPontosDescricao ;
      private short[] T000A2_A50ClienteCartaoPontosId ;
      private decimal[] T000A24_A66CartaoPontosAcumulados ;
      private bool[] T000A24_n66CartaoPontosAcumulados ;
      private string[] T000A25_A51ClienteCartaoPontosNome ;
      private short[] T000A26_A43ClienteId ;
      private short[] T000A27_A41CartaoPontosId ;
      private short[] T000A28_A50ClienteCartaoPontosId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
      private GeneXus.Programs.general.ui.SdtTransactionContext_Attribute AV12TrnContextAtt ;
   }

   public class cartaopontos__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new UpdateCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new ForEachCursor(def[17])
         ,new ForEachCursor(def[18])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT000A10;
          prmT000A10 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A7;
          prmT000A7 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A11;
          prmT000A11 = new Object[] {
          new ParDef("@ClienteCartaoPontosId",GXType.Int16,4,0) ,
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A4;
          prmT000A4 = new Object[] {
          new ParDef("@ClienteCartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A14;
          prmT000A14 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A15;
          prmT000A15 = new Object[] {
          new ParDef("@ClienteCartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A16;
          prmT000A16 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A3;
          prmT000A3 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A17;
          prmT000A17 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A18;
          prmT000A18 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A2;
          prmT000A2 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A19;
          prmT000A19 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0) ,
          new ParDef("@CartaoPontosDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@ClienteCartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A20;
          prmT000A20 = new Object[] {
          new ParDef("@CartaoPontosDescricao",GXType.NVarChar,20,0) ,
          new ParDef("@ClienteCartaoPontosId",GXType.Int16,4,0) ,
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A21;
          prmT000A21 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A26;
          prmT000A26 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A27;
          prmT000A27 = new Object[] {
          };
          Object[] prmT000A24;
          prmT000A24 = new Object[] {
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A25;
          prmT000A25 = new Object[] {
          new ParDef("@ClienteCartaoPontosId",GXType.Int16,4,0)
          };
          Object[] prmT000A28;
          prmT000A28 = new Object[] {
          new ParDef("@ClienteCartaoPontosId",GXType.Int16,4,0) ,
          new ParDef("@CartaoPontosId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T000A2", "SELECT [CartaoPontosId], [CartaoPontosDescricao], [ClienteCartaoPontosId] AS ClienteCartaoPontosId FROM [CartaoPontos] WITH (UPDLOCK) WHERE [CartaoPontosId] = @CartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A3", "SELECT [CartaoPontosId], [CartaoPontosDescricao], [ClienteCartaoPontosId] AS ClienteCartaoPontosId FROM [CartaoPontos] WHERE [CartaoPontosId] = @CartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A4", "SELECT [ClienteNome] AS ClienteCartaoPontosNome FROM [Cliente] WHERE [ClienteId] = @ClienteCartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A7", "SELECT COALESCE( T1.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (SELECT SUM(CASE  WHEN ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T3.[CartaoPontosClienteId] FROM (([CarrinhoCompras] T2 INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T2.[CarrinhoComprasId]) GROUP BY T3.[CartaoPontosClienteId] ) T1 WHERE T1.[CartaoPontosClienteId] = @CartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A10", "SELECT TM1.[CartaoPontosId], TM1.[CartaoPontosDescricao], T3.[ClienteNome] AS ClienteCartaoPontosNome, TM1.[ClienteCartaoPontosId] AS ClienteCartaoPontosId, COALESCE( T2.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (([CartaoPontos] TM1 LEFT JOIN (SELECT SUM(CASE  WHEN ( COALESCE( T6.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T6.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T5.[CartaoPontosClienteId] FROM (([CarrinhoCompras] T4 INNER JOIN [Cliente] T5 ON T5.[ClienteId] = T4.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T9.[CategoriaNome] = 'Joalheria' THEN ( T7.[CarrinhoComprasProdutosQuantid] * CAST(T8.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T9.[CategoriaNome] = 'Entreterimento' THEN ( T7.[CarrinhoComprasProdutosQuantid] * CAST(T8.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T7.[CarrinhoComprasProdutosQuantid] * CAST(T8.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T7.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T7 INNER JOIN [Produto] T8 ON T8.[ProdutoId] = T7.[ProdutoId]) INNER JOIN [Categoria] T9 ON T9.[CategoriaId] = T8.[CategoriaProdutoId]) GROUP BY T7.[CarrinhoComprasId] ) T6 ON T6.[CarrinhoComprasId] = T4.[CarrinhoComprasId]) GROUP BY T5.[CartaoPontosClienteId] ) T2 ON T2.[CartaoPontosClienteId] = TM1.[CartaoPontosId]) INNER JOIN [Cliente] T3 ON T3.[ClienteId] = TM1.[ClienteCartaoPontosId]) WHERE TM1.[CartaoPontosId] = @CartaoPontosId ORDER BY TM1.[CartaoPontosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A11", "SELECT [ClienteCartaoPontosId] AS ClienteCartaoPontosId FROM [CartaoPontos] WHERE ([ClienteCartaoPontosId] = @ClienteCartaoPontosId) AND (Not ( [CartaoPontosId] = @CartaoPontosId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A14", "SELECT COALESCE( T1.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (SELECT SUM(CASE  WHEN ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T3.[CartaoPontosClienteId] FROM (([CarrinhoCompras] T2 INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T2.[CarrinhoComprasId]) GROUP BY T3.[CartaoPontosClienteId] ) T1 WHERE T1.[CartaoPontosClienteId] = @CartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A14,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A15", "SELECT [ClienteNome] AS ClienteCartaoPontosNome FROM [Cliente] WHERE [ClienteId] = @ClienteCartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A15,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A16", "SELECT [CartaoPontosId] FROM [CartaoPontos] WHERE [CartaoPontosId] = @CartaoPontosId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A17", "SELECT TOP 1 [CartaoPontosId] FROM [CartaoPontos] WHERE ( [CartaoPontosId] > @CartaoPontosId) ORDER BY [CartaoPontosId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A18", "SELECT TOP 1 [CartaoPontosId] FROM [CartaoPontos] WHERE ( [CartaoPontosId] < @CartaoPontosId) ORDER BY [CartaoPontosId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A18,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A19", "INSERT INTO [CartaoPontos]([CartaoPontosId], [CartaoPontosDescricao], [ClienteCartaoPontosId]) VALUES(@CartaoPontosId, @CartaoPontosDescricao, @ClienteCartaoPontosId)", GxErrorMask.GX_NOMASK,prmT000A19)
             ,new CursorDef("T000A20", "UPDATE [CartaoPontos] SET [CartaoPontosDescricao]=@CartaoPontosDescricao, [ClienteCartaoPontosId]=@ClienteCartaoPontosId  WHERE [CartaoPontosId] = @CartaoPontosId", GxErrorMask.GX_NOMASK,prmT000A20)
             ,new CursorDef("T000A21", "DELETE FROM [CartaoPontos]  WHERE [CartaoPontosId] = @CartaoPontosId", GxErrorMask.GX_NOMASK,prmT000A21)
             ,new CursorDef("T000A24", "SELECT COALESCE( T1.[CartaoPontosAcumulados], 0) AS CartaoPontosAcumulados FROM (SELECT SUM(CASE  WHEN ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0)) >= 1000 THEN ( ( COALESCE( T4.[CarrinhoComprasPrecoTotal], 0))) * CAST(0.05 AS decimal( 20, 10)) END) AS CartaoPontosAcumulados, T3.[CartaoPontosClienteId] FROM (([CarrinhoCompras] T2 INNER JOIN [Cliente] T3 ON T3.[ClienteId] = T2.[ClienteCarrinhoComprasId]) LEFT JOIN (SELECT SUM(CASE  WHEN T7.[CategoriaNome] = 'Joalheria' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(1.05 AS decimal( 22, 10))) WHEN T7.[CategoriaNome] = 'Entreterimento' THEN ( T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) * CAST(0.9 AS decimal( 22, 10))) ELSE T5.[CarrinhoComprasProdutosQuantid] * CAST(T6.[ProdutoPreco] AS decimal( 20, 10)) END) AS CarrinhoComprasPrecoTotal, T5.[CarrinhoComprasId] FROM (([CarrinhoComprasProdutos] T5 INNER JOIN [Produto] T6 ON T6.[ProdutoId] = T5.[ProdutoId]) INNER JOIN [Categoria] T7 ON T7.[CategoriaId] = T6.[CategoriaProdutoId]) GROUP BY T5.[CarrinhoComprasId] ) T4 ON T4.[CarrinhoComprasId] = T2.[CarrinhoComprasId]) GROUP BY T3.[CartaoPontosClienteId] ) T1 WHERE T1.[CartaoPontosClienteId] = @CartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A24,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A25", "SELECT [ClienteNome] AS ClienteCartaoPontosNome FROM [Cliente] WHERE [ClienteId] = @ClienteCartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A25,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A26", "SELECT TOP 1 [ClienteId] FROM [Cliente] WHERE [CartaoPontosClienteId] = @CartaoPontosId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A26,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000A27", "SELECT [CartaoPontosId] FROM [CartaoPontos] ORDER BY [CartaoPontosId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000A27,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000A28", "SELECT [ClienteCartaoPontosId] AS ClienteCartaoPontosId FROM [CartaoPontos] WHERE ([ClienteCartaoPontosId] = @ClienteCartaoPontosId) AND (Not ( [CartaoPontosId] = @CartaoPontosId)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A28,1, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((decimal[]) buf[4])[0] = rslt.getDecimal(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 6 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 7 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 9 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 10 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                ((bool[]) buf[1])[0] = rslt.wasNull(1);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 17 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 18 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
       }
    }

 }

}
