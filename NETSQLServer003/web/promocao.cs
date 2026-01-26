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
   public class promocao : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_9") == 0 )
         {
            A19ProdutoId = (short)(NumberUtil.Val( GetPar( "ProdutoId"), "."));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_9( A19ProdutoId) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridpromocao_produto") == 0 )
         {
            gxnrGridpromocao_produto_newrow_invoke( ) ;
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
            Gx_mode = gxfirstwebparm;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
            {
               AV7PromocaoId = (short)(NumberUtil.Val( GetPar( "PromocaoId"), "."));
               AssignAttri("", false, "AV7PromocaoId", StringUtil.LTrimStr( (decimal)(AV7PromocaoId), 4, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromocaoId), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Promoção", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPromocaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridpromocao_produto_newrow_invoke( )
      {
         nRC_GXsfl_63 = (int)(NumberUtil.Val( GetPar( "nRC_GXsfl_63"), "."));
         nGXsfl_63_idx = (int)(NumberUtil.Val( GetPar( "nGXsfl_63_idx"), "."));
         sGXsfl_63_idx = GetPar( "sGXsfl_63_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridpromocao_produto_newrow( ) ;
         /* End function gxnrGridpromocao_produto_newrow_invoke */
      }

      public promocao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("LojaAnnaLaisa");
      }

      public promocao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           short aP1_PromocaoId )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PromocaoId = aP1_PromocaoId;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Promoção", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_Promocao.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Select", bttBtn_select_Jsonclick, 5, "Select", "", StyleString, ClassString, bttBtn_select_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_Promocao.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromocaoId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocaoId_Internalname, "Promoção", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocaoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A32PromocaoId), 4, 0, ".", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A32PromocaoId), "ZZZ9")), " inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocaoId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocaoId_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "Id", "right", false, "", "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromocaoDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocaoDescricao_Internalname, "Descrição", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPromocaoDescricao_Internalname, A33PromocaoDescricao, StringUtil.RTrim( context.localUtil.Format( A33PromocaoDescricao, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocaoDescricao_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocaoDescricao_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "left", true, "", "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+imgPromocaoImagem_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Imagem", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A34PromocaoImagem_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000PromocaoImagem_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.PathToRelativeUrl( A34PromocaoImagem));
         GxWebStd.gx_bitmap( context, imgPromocaoImagem_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgPromocaoImagem_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "", "", "", 0, A34PromocaoImagem_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_Promocao.htm");
         AssignProp("", false, imgPromocaoImagem_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.PathToRelativeUrl( A34PromocaoImagem)), true);
         AssignProp("", false, imgPromocaoImagem_Internalname, "IsBlob", StringUtil.BoolToStr( A34PromocaoImagem_IsBlob), true);
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromocaoDataInicio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocaoDataInicio_Internalname, "de início", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromocaoDataInicio_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromocaoDataInicio_Internalname, context.localUtil.Format(A35PromocaoDataInicio, "99/99/99"), context.localUtil.Format( A35PromocaoDataInicio, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocaoDataInicio_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocaoDataInicio_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Promocao.htm");
         GxWebStd.gx_bitmap( context, edtPromocaoDataInicio_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromocaoDataInicio_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promocao.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "left", "top", ""+" data-gx-for=\""+edtPromocaoDataTermino_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPromocaoDataTermino_Internalname, "de término", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "left", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPromocaoDataTermino_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPromocaoDataTermino_Internalname, context.localUtil.Format(A36PromocaoDataTermino, "99/99/99"), context.localUtil.Format( A36PromocaoDataTermino, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'MDY',0,12,'eng',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPromocaoDataTermino_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtPromocaoDataTermino_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "right", false, "", "HLP_Promocao.htm");
         GxWebStd.gx_bitmap( context, edtPromocaoDataTermino_Internalname+"_dp_trigger", context.GetImagePath( "", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtPromocaoDataTermino_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_Promocao.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divProdutotable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "left", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleproduto_Internalname, "Produto", "", "", lblTitleproduto_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "left", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "left", "top", "", "", "div");
         gxdraw_Gridpromocao_produto( ) ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "Right", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "left", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", bttBtn_enter_Caption, bttBtn_enter_Jsonclick, 5, bttBtn_enter_Tooltiptext, "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 72,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Cancel", bttBtn_cancel_Jsonclick, 1, "Cancel", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "left", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Delete", bttBtn_delete_Jsonclick, 5, "Delete", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_Promocao.htm");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "Right", "Middle", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
         GxWebStd.gx_div_end( context, "left", "top", "div");
      }

      protected void gxdraw_Gridpromocao_produto( )
      {
         /*  Grid Control  */
         StartGridControl63( ) ;
         nGXsfl_63_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount8 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_8 = 1;
               ScanStart078( ) ;
               while ( RcdFound8 != 0 )
               {
                  init_level_properties8( ) ;
                  getByPrimaryKey078( ) ;
                  AddRow078( ) ;
                  ScanNext078( ) ;
               }
               ScanEnd078( ) ;
               nBlankRcdCount8 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal078( ) ;
            standaloneModal078( ) ;
            sMode8 = Gx_mode;
            while ( nGXsfl_63_idx < nRC_GXsfl_63 )
            {
               bGXsfl_63_Refreshing = true;
               ReadRow078( ) ;
               edtProdutoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOID_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               edtProdutoNome_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTONOME_"+sGXsfl_63_idx+"Enabled"), ".", ","));
               AssignProp("", false, edtProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoNome_Enabled), 5, 0), !bGXsfl_63_Refreshing);
               imgprompt_19_Link = cgiGet( "PROMPT_19_"+sGXsfl_63_idx+"Link");
               if ( ( nRcdExists_8 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal078( ) ;
               }
               SendRow078( ) ;
               bGXsfl_63_Refreshing = false;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount8 = 5;
            nRcdExists_8 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart078( ) ;
               while ( RcdFound8 != 0 )
               {
                  sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_638( ) ;
                  init_level_properties8( ) ;
                  standaloneNotModal078( ) ;
                  getByPrimaryKey078( ) ;
                  standaloneModal078( ) ;
                  AddRow078( ) ;
                  ScanNext078( ) ;
               }
               ScanEnd078( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode8 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx+1), 4, 0), 4, "0");
            SubsflControlProps_638( ) ;
            InitAll078( ) ;
            init_level_properties8( ) ;
            nRcdExists_8 = 0;
            nIsMod_8 = 0;
            nRcdDeleted_8 = 0;
            nBlankRcdCount8 = (short)(nBlankRcdUsr8+nBlankRcdCount8);
            fRowAdded = 0;
            while ( nBlankRcdCount8 > 0 )
            {
               standaloneNotModal078( ) ;
               standaloneModal078( ) ;
               AddRow078( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtProdutoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount8 = (short)(nBlankRcdCount8-1);
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridpromocao_produtoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridpromocao_produto", Gridpromocao_produtoContainer, subGridpromocao_produto_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromocao_produtoContainerData", Gridpromocao_produtoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridpromocao_produtoContainerData"+"V", Gridpromocao_produtoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridpromocao_produtoContainerData"+"V"+"\" value='"+Gridpromocao_produtoContainer.GridValuesHidden()+"'/>") ;
         }
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
         E11072 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z32PromocaoId = (short)(context.localUtil.CToN( cgiGet( "Z32PromocaoId"), ".", ","));
               Z33PromocaoDescricao = cgiGet( "Z33PromocaoDescricao");
               Z35PromocaoDataInicio = context.localUtil.CToD( cgiGet( "Z35PromocaoDataInicio"), 0);
               Z36PromocaoDataTermino = context.localUtil.CToD( cgiGet( "Z36PromocaoDataTermino"), 0);
               IsConfirmed = (short)(context.localUtil.CToN( cgiGet( "IsConfirmed"), ".", ","));
               IsModified = (short)(context.localUtil.CToN( cgiGet( "IsModified"), ".", ","));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_63 = (int)(context.localUtil.CToN( cgiGet( "nRC_GXsfl_63"), ".", ","));
               AV7PromocaoId = (short)(context.localUtil.CToN( cgiGet( "vPROMOCAOID"), ".", ","));
               A40000PromocaoImagem_GXI = cgiGet( "PROMOCAOIMAGEM_GXI");
               AV11Pgmname = cgiGet( "vPGMNAME");
               /* Read variables values. */
               if ( ( ( context.localUtil.CToN( cgiGet( edtPromocaoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPromocaoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PROMOCAOID");
                  AnyError = 1;
                  GX_FocusControl = edtPromocaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A32PromocaoId = 0;
                  AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
               }
               else
               {
                  A32PromocaoId = (short)(context.localUtil.CToN( cgiGet( edtPromocaoId_Internalname), ".", ","));
                  AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
               }
               A33PromocaoDescricao = cgiGet( edtPromocaoDescricao_Internalname);
               AssignAttri("", false, "A33PromocaoDescricao", A33PromocaoDescricao);
               A34PromocaoImagem = cgiGet( imgPromocaoImagem_Internalname);
               AssignAttri("", false, "A34PromocaoImagem", A34PromocaoImagem);
               if ( context.localUtil.VCDate( cgiGet( edtPromocaoDataInicio_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data de início"}), 1, "PROMOCAODATAINICIO");
                  AnyError = 1;
                  GX_FocusControl = edtPromocaoDataInicio_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A35PromocaoDataInicio = DateTime.MinValue;
                  AssignAttri("", false, "A35PromocaoDataInicio", context.localUtil.Format(A35PromocaoDataInicio, "99/99/99"));
               }
               else
               {
                  A35PromocaoDataInicio = context.localUtil.CToD( cgiGet( edtPromocaoDataInicio_Internalname), 1);
                  AssignAttri("", false, "A35PromocaoDataInicio", context.localUtil.Format(A35PromocaoDataInicio, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPromocaoDataTermino_Internalname), 1) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data de término"}), 1, "PROMOCAODATATERMINO");
                  AnyError = 1;
                  GX_FocusControl = edtPromocaoDataTermino_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A36PromocaoDataTermino = DateTime.MinValue;
                  AssignAttri("", false, "A36PromocaoDataTermino", context.localUtil.Format(A36PromocaoDataTermino, "99/99/99"));
               }
               else
               {
                  A36PromocaoDataTermino = context.localUtil.CToD( cgiGet( edtPromocaoDataTermino_Internalname), 1);
                  AssignAttri("", false, "A36PromocaoDataTermino", context.localUtil.Format(A36PromocaoDataTermino, "99/99/99"));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               getMultimediaValue(imgPromocaoImagem_Internalname, ref  A34PromocaoImagem, ref  A40000PromocaoImagem_GXI);
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Promocao");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A32PromocaoId != Z32PromocaoId ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("promocao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A32PromocaoId = (short)(NumberUtil.Val( GetPar( "PromocaoId"), "."));
                  AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
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
                     sMode7 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode7;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound7 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_070( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PROMOCAOID");
                        AnyError = 1;
                        GX_FocusControl = edtPromocaoId_Internalname;
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
                           E11072 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12072 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E12072 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll077( ) ;
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
            DisableAttributes077( ) ;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode7 = Gx_mode;
            CONFIRM_078( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode7;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_078( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow078( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               GetKey078( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  if ( RcdFound8 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate078( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable078( ) ;
                        CloseExtendedTableCursors078( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRODUTOID_" + sGXsfl_63_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtProdutoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( nRcdDeleted_8 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey078( ) ;
                        Load078( ) ;
                        BeforeValidate078( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls078( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate078( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable078( ) ;
                              CloseExtendedTableCursors078( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "PRODUTOID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdutoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdutoNome_Internalname, A20ProdutoNome) ;
            ChangePostValue( "ZT_"+"Z19ProdutoId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ".", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( "PRODUTOID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTONOME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption070( )
      {
      }

      protected void E11072( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.general.security.isauthorized(context).executeUdp(  AV11Pgmname) )
         {
            CallWebObject(formatLink("general.security.notauthorized.aspx", new object[] {UrlEncode(StringUtil.RTrim(AV11Pgmname))}, new string[] {"GxObject"}) );
            context.wjLocDisableFrm = 1;
         }
         AV9TrnContext.FromXml(AV10WebSession.Get("TrnContext"), null, "", "");
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            bttBtn_enter_Caption = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Caption", bttBtn_enter_Caption, true);
            bttBtn_enter_Tooltiptext = "Delete";
            AssignProp("", false, bttBtn_enter_Internalname, "Tooltiptext", bttBtn_enter_Tooltiptext, true);
         }
      }

      protected void E12072( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV9TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("wwpromocao.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z33PromocaoDescricao = T00076_A33PromocaoDescricao[0];
               Z35PromocaoDataInicio = T00076_A35PromocaoDataInicio[0];
               Z36PromocaoDataTermino = T00076_A36PromocaoDataTermino[0];
            }
            else
            {
               Z33PromocaoDescricao = A33PromocaoDescricao;
               Z35PromocaoDataInicio = A35PromocaoDataInicio;
               Z36PromocaoDataTermino = A36PromocaoDataTermino;
            }
         }
         if ( GX_JID == -7 )
         {
            Z32PromocaoId = A32PromocaoId;
            Z33PromocaoDescricao = A33PromocaoDescricao;
            Z34PromocaoImagem = A34PromocaoImagem;
            Z40000PromocaoImagem_GXI = A40000PromocaoImagem_GXI;
            Z35PromocaoDataInicio = A35PromocaoDataInicio;
            Z36PromocaoDataTermino = A36PromocaoDataTermino;
         }
      }

      protected void standaloneNotModal( )
      {
         bttBtn_delete_Enabled = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         if ( ! (0==AV7PromocaoId) )
         {
            A32PromocaoId = AV7PromocaoId;
            AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
         }
         if ( ! (0==AV7PromocaoId) )
         {
            edtPromocaoId_Enabled = 0;
            AssignProp("", false, edtPromocaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocaoId_Enabled), 5, 0), true);
         }
         else
         {
            edtPromocaoId_Enabled = 1;
            AssignProp("", false, edtPromocaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocaoId_Enabled), 5, 0), true);
         }
         if ( ! (0==AV7PromocaoId) )
         {
            edtPromocaoId_Enabled = 0;
            AssignProp("", false, edtPromocaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocaoId_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
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
            AV11Pgmname = "Promocao";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void Load077( )
      {
         /* Using cursor T00077 */
         pr_default.execute(5, new Object[] {A32PromocaoId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound7 = 1;
            A33PromocaoDescricao = T00077_A33PromocaoDescricao[0];
            AssignAttri("", false, "A33PromocaoDescricao", A33PromocaoDescricao);
            A40000PromocaoImagem_GXI = T00077_A40000PromocaoImagem_GXI[0];
            AssignProp("", false, imgPromocaoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A34PromocaoImagem))), true);
            AssignProp("", false, imgPromocaoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A34PromocaoImagem), true);
            A35PromocaoDataInicio = T00077_A35PromocaoDataInicio[0];
            AssignAttri("", false, "A35PromocaoDataInicio", context.localUtil.Format(A35PromocaoDataInicio, "99/99/99"));
            A36PromocaoDataTermino = T00077_A36PromocaoDataTermino[0];
            AssignAttri("", false, "A36PromocaoDataTermino", context.localUtil.Format(A36PromocaoDataTermino, "99/99/99"));
            A34PromocaoImagem = T00077_A34PromocaoImagem[0];
            AssignAttri("", false, "A34PromocaoImagem", A34PromocaoImagem);
            AssignProp("", false, imgPromocaoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A34PromocaoImagem))), true);
            AssignProp("", false, imgPromocaoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A34PromocaoImagem), true);
            ZM077( -7) ;
         }
         pr_default.close(5);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
         AV11Pgmname = "Promocao";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         AV11Pgmname = "Promocao";
         AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         if ( ! ( (DateTime.MinValue==A35PromocaoDataInicio) || ( DateTimeUtil.ResetTime ( A35PromocaoDataInicio ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Data de início is out of range", "OutOfRange", 1, "PROMOCAODATAINICIO");
            AnyError = 1;
            GX_FocusControl = edtPromocaoDataInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( DateTimeUtil.ResetTime ( A35PromocaoDataInicio ) > DateTimeUtil.ResetTime ( A36PromocaoDataTermino ) )
         {
            GX_msglist.addItem("A data de início não pode ser maior que data de término", 1, "PROMOCAODATAINICIO");
            AnyError = 1;
            GX_FocusControl = edtPromocaoDataInicio_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( ! ( (DateTime.MinValue==A36PromocaoDataTermino) || ( DateTimeUtil.ResetTime ( A36PromocaoDataTermino ) >= DateTimeUtil.ResetTime ( context.localUtil.YMDToD( 1753, 1, 1) ) ) ) )
         {
            GX_msglist.addItem("Field Data de término is out of range", "OutOfRange", 1, "PROMOCAODATATERMINO");
            AnyError = 1;
            GX_FocusControl = edtPromocaoDataTermino_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors077( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor T00078 */
         pr_default.execute(6, new Object[] {A32PromocaoId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00076 */
         pr_default.execute(4, new Object[] {A32PromocaoId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM077( 7) ;
            RcdFound7 = 1;
            A32PromocaoId = T00076_A32PromocaoId[0];
            AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
            A33PromocaoDescricao = T00076_A33PromocaoDescricao[0];
            AssignAttri("", false, "A33PromocaoDescricao", A33PromocaoDescricao);
            A40000PromocaoImagem_GXI = T00076_A40000PromocaoImagem_GXI[0];
            AssignProp("", false, imgPromocaoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A34PromocaoImagem))), true);
            AssignProp("", false, imgPromocaoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A34PromocaoImagem), true);
            A35PromocaoDataInicio = T00076_A35PromocaoDataInicio[0];
            AssignAttri("", false, "A35PromocaoDataInicio", context.localUtil.Format(A35PromocaoDataInicio, "99/99/99"));
            A36PromocaoDataTermino = T00076_A36PromocaoDataTermino[0];
            AssignAttri("", false, "A36PromocaoDataTermino", context.localUtil.Format(A36PromocaoDataTermino, "99/99/99"));
            A34PromocaoImagem = T00076_A34PromocaoImagem[0];
            AssignAttri("", false, "A34PromocaoImagem", A34PromocaoImagem);
            AssignProp("", false, imgPromocaoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A34PromocaoImagem))), true);
            AssignProp("", false, imgPromocaoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A34PromocaoImagem), true);
            Z32PromocaoId = A32PromocaoId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode7;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound7 = 0;
         /* Using cursor T00079 */
         pr_default.execute(7, new Object[] {A32PromocaoId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00079_A32PromocaoId[0] < A32PromocaoId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00079_A32PromocaoId[0] > A32PromocaoId ) ) )
            {
               A32PromocaoId = T00079_A32PromocaoId[0];
               AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound7 = 0;
         /* Using cursor T000710 */
         pr_default.execute(8, new Object[] {A32PromocaoId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000710_A32PromocaoId[0] > A32PromocaoId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000710_A32PromocaoId[0] < A32PromocaoId ) ) )
            {
               A32PromocaoId = T000710_A32PromocaoId[0];
               AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
               RcdFound7 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPromocaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert077( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A32PromocaoId != Z32PromocaoId )
               {
                  A32PromocaoId = Z32PromocaoId;
                  AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PROMOCAOID");
                  AnyError = 1;
                  GX_FocusControl = edtPromocaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPromocaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update077( ) ;
                  GX_FocusControl = edtPromocaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A32PromocaoId != Z32PromocaoId )
               {
                  /* Insert record */
                  GX_FocusControl = edtPromocaoId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert077( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PROMOCAOID");
                     AnyError = 1;
                     GX_FocusControl = edtPromocaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPromocaoId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert077( ) ;
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
         if ( A32PromocaoId != Z32PromocaoId )
         {
            A32PromocaoId = Z32PromocaoId;
            AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PROMOCAOID");
            AnyError = 1;
            GX_FocusControl = edtPromocaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPromocaoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00075 */
            pr_default.execute(3, new Object[] {A32PromocaoId});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promocao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(3) == 101) || ( StringUtil.StrCmp(Z33PromocaoDescricao, T00075_A33PromocaoDescricao[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z35PromocaoDataInicio ) != DateTimeUtil.ResetTime ( T00075_A35PromocaoDataInicio[0] ) ) || ( DateTimeUtil.ResetTime ( Z36PromocaoDataTermino ) != DateTimeUtil.ResetTime ( T00075_A36PromocaoDataTermino[0] ) ) )
            {
               if ( StringUtil.StrCmp(Z33PromocaoDescricao, T00075_A33PromocaoDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("promocao:[seudo value changed for attri]"+"PromocaoDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z33PromocaoDescricao);
                  GXUtil.WriteLogRaw("Current: ",T00075_A33PromocaoDescricao[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z35PromocaoDataInicio ) != DateTimeUtil.ResetTime ( T00075_A35PromocaoDataInicio[0] ) )
               {
                  GXUtil.WriteLog("promocao:[seudo value changed for attri]"+"PromocaoDataInicio");
                  GXUtil.WriteLogRaw("Old: ",Z35PromocaoDataInicio);
                  GXUtil.WriteLogRaw("Current: ",T00075_A35PromocaoDataInicio[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z36PromocaoDataTermino ) != DateTimeUtil.ResetTime ( T00075_A36PromocaoDataTermino[0] ) )
               {
                  GXUtil.WriteLog("promocao:[seudo value changed for attri]"+"PromocaoDataTermino");
                  GXUtil.WriteLogRaw("Old: ",Z36PromocaoDataTermino);
                  GXUtil.WriteLogRaw("Current: ",T00075_A36PromocaoDataTermino[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"Promocao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000711 */
                     pr_default.execute(9, new Object[] {A32PromocaoId, A33PromocaoDescricao, A34PromocaoImagem, A40000PromocaoImagem_GXI, A35PromocaoDataInicio, A36PromocaoDataTermino});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("Promocao");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel077( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption070( ) ;
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
            else
            {
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000712 */
                     pr_default.execute(10, new Object[] {A33PromocaoDescricao, A35PromocaoDataInicio, A36PromocaoDataTermino, A32PromocaoId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("Promocao");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"Promocao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel077( ) ;
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
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000713 */
            pr_default.execute(11, new Object[] {A34PromocaoImagem, A40000PromocaoImagem_GXI, A32PromocaoId});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("Promocao");
         }
      }

      protected void delete( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart078( ) ;
                  while ( RcdFound8 != 0 )
                  {
                     getByPrimaryKey078( ) ;
                     Delete078( ) ;
                     ScanNext078( ) ;
                  }
                  ScanEnd078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000714 */
                     pr_default.execute(12, new Object[] {A32PromocaoId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("Promocao");
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
         }
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel077( ) ;
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            AV11Pgmname = "Promocao";
            AssignAttri("", false, "AV11Pgmname", AV11Pgmname);
         }
      }

      protected void ProcessNestedLevel078( )
      {
         nGXsfl_63_idx = 0;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            ReadRow078( ) ;
            if ( ( nRcdExists_8 != 0 ) || ( nIsMod_8 != 0 ) )
            {
               standaloneNotModal078( ) ;
               GetKey078( ) ;
               if ( ( nRcdExists_8 == 0 ) && ( nRcdDeleted_8 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert078( ) ;
               }
               else
               {
                  if ( RcdFound8 != 0 )
                  {
                     if ( ( nRcdDeleted_8 != 0 ) && ( nRcdExists_8 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete078( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_8 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update078( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_8 == 0 )
                     {
                        GXCCtl = "PRODUTOID_" + sGXsfl_63_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtProdutoId_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtProdutoId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( edtProdutoNome_Internalname, A20ProdutoNome) ;
            ChangePostValue( "ZT_"+"Z19ProdutoId_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProdutoId), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdDeleted_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nRcdExists_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ".", ""))) ;
            ChangePostValue( "nIsMod_8_"+sGXsfl_63_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ".", ""))) ;
            if ( nIsMod_8 != 0 )
            {
               ChangePostValue( "PRODUTOID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRODUTONOME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll078( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_8 = 0;
         nIsMod_8 = 0;
         nRcdDeleted_8 = 0;
      }

      protected void ProcessLevel077( )
      {
         /* Save parent mode. */
         sMode7 = Gx_mode;
         ProcessNestedLevel078( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode7;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
         }
         if ( AnyError == 0 )
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.CommitDataStores("promocao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues070( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            pr_default.close(4);
            pr_default.close(1);
            pr_default.close(0);
            pr_default.close(2);
            context.RollbackDataStores("promocao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart077( )
      {
         /* Scan By routine */
         /* Using cursor T000715 */
         pr_default.execute(13);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
            A32PromocaoId = T000715_A32PromocaoId[0];
            AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound7 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound7 = 1;
            A32PromocaoId = T000715_A32PromocaoId[0];
            AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
         }
      }

      protected void ScanEnd077( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
         edtPromocaoId_Enabled = 0;
         AssignProp("", false, edtPromocaoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocaoId_Enabled), 5, 0), true);
         edtPromocaoDescricao_Enabled = 0;
         AssignProp("", false, edtPromocaoDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocaoDescricao_Enabled), 5, 0), true);
         imgPromocaoImagem_Enabled = 0;
         AssignProp("", false, imgPromocaoImagem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgPromocaoImagem_Enabled), 5, 0), true);
         edtPromocaoDataInicio_Enabled = 0;
         AssignProp("", false, edtPromocaoDataInicio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocaoDataInicio_Enabled), 5, 0), true);
         edtPromocaoDataTermino_Enabled = 0;
         AssignProp("", false, edtPromocaoDataTermino_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPromocaoDataTermino_Enabled), 5, 0), true);
      }

      protected void ZM078( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -8 )
         {
            Z32PromocaoId = A32PromocaoId;
            Z19ProdutoId = A19ProdutoId;
            Z20ProdutoNome = A20ProdutoNome;
         }
      }

      protected void standaloneNotModal078( )
      {
      }

      protected void standaloneModal078( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtProdutoId_Enabled = 0;
            AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
         else
         {
            edtProdutoId_Enabled = 1;
            AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         }
      }

      protected void Load078( )
      {
         /* Using cursor T000716 */
         pr_default.execute(14, new Object[] {A32PromocaoId, A19ProdutoId});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A20ProdutoNome = T000716_A20ProdutoNome[0];
            ZM078( -8) ;
         }
         pr_default.close(14);
         OnLoadActions078( ) ;
      }

      protected void OnLoadActions078( )
      {
      }

      protected void CheckExtendedTable078( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal078( ) ;
         /* Using cursor T00074 */
         pr_default.execute(2, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRODUTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No matching 'Produto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20ProdutoNome = T00074_A20ProdutoNome[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors078( )
      {
         pr_default.close(2);
      }

      protected void enableDisable078( )
      {
      }

      protected void gxLoad_9( short A19ProdutoId )
      {
         /* Using cursor T000717 */
         pr_default.execute(15, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            GXCCtl = "PRODUTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem("No matching 'Produto'.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A20ProdutoNome = T000717_A20ProdutoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A20ProdutoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(15) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(15);
      }

      protected void GetKey078( )
      {
         /* Using cursor T000718 */
         pr_default.execute(16, new Object[] {A32PromocaoId, A19ProdutoId});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(16);
      }

      protected void getByPrimaryKey078( )
      {
         /* Using cursor T00073 */
         pr_default.execute(1, new Object[] {A32PromocaoId, A19ProdutoId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM078( 8) ;
            RcdFound8 = 1;
            InitializeNonKey078( ) ;
            A19ProdutoId = T00073_A19ProdutoId[0];
            Z32PromocaoId = A32PromocaoId;
            Z19ProdutoId = A19ProdutoId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load078( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey078( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal078( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes078( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency078( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00072 */
            pr_default.execute(0, new Object[] {A32PromocaoId, A19ProdutoId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"PromocaoProduto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"PromocaoProduto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM078( 0) ;
            CheckOptimisticConcurrency078( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm078( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert078( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000719 */
                     pr_default.execute(17, new Object[] {A32PromocaoId, A19ProdutoId});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("PromocaoProduto");
                     if ( (pr_default.getStatus(17) == 1) )
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
               Load078( ) ;
            }
            EndLevel078( ) ;
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void Update078( )
      {
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable078( ) ;
         }
         if ( ( nIsMod_8 != 0 ) || ( nIsDirty_8 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency078( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm078( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate078( ) ;
                     if ( AnyError == 0 )
                     {
                        /* No attributes to update on table [PromocaoProduto] */
                        DeferredUpdate078( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey078( ) ;
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
               EndLevel078( ) ;
            }
         }
         CloseExtendedTableCursors078( ) ;
      }

      protected void DeferredUpdate078( )
      {
      }

      protected void Delete078( )
      {
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate078( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency078( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls078( ) ;
            AfterConfirm078( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete078( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000720 */
                  pr_default.execute(18, new Object[] {A32PromocaoId, A19ProdutoId});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("PromocaoProduto");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel078( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls078( )
      {
         standaloneModal078( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000721 */
            pr_default.execute(19, new Object[] {A19ProdutoId});
            A20ProdutoNome = T000721_A20ProdutoNome[0];
            pr_default.close(19);
         }
      }

      protected void EndLevel078( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart078( )
      {
         /* Scan By routine */
         /* Using cursor T000722 */
         pr_default.execute(20, new Object[] {A32PromocaoId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound8 = 1;
            A19ProdutoId = T000722_A19ProdutoId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext078( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound8 = 1;
            A19ProdutoId = T000722_A19ProdutoId[0];
         }
      }

      protected void ScanEnd078( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm078( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert078( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate078( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete078( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete078( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate078( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes078( )
      {
         edtProdutoId_Enabled = 0;
         AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
         edtProdutoNome_Enabled = 0;
         AssignProp("", false, edtProdutoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoNome_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void send_integrity_lvl_hashes078( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void SubsflControlProps_638( )
      {
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_63_idx;
         imgprompt_19_Internalname = "PROMPT_19_"+sGXsfl_63_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_63_idx;
      }

      protected void SubsflControlProps_fel_638( )
      {
         edtProdutoId_Internalname = "PRODUTOID_"+sGXsfl_63_fel_idx;
         imgprompt_19_Internalname = "PROMPT_19_"+sGXsfl_63_fel_idx;
         edtProdutoNome_Internalname = "PRODUTONOME_"+sGXsfl_63_fel_idx;
      }

      protected void AddRow078( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_638( ) ;
         SendRow078( ) ;
      }

      protected void SendRow078( )
      {
         Gridpromocao_produtoRow = GXWebRow.GetNew(context);
         if ( subGridpromocao_produto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridpromocao_produto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridpromocao_produto_Class, "") != 0 )
            {
               subGridpromocao_produto_Linesclass = subGridpromocao_produto_Class+"Odd";
            }
         }
         else if ( subGridpromocao_produto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridpromocao_produto_Backstyle = 0;
            subGridpromocao_produto_Backcolor = subGridpromocao_produto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridpromocao_produto_Class, "") != 0 )
            {
               subGridpromocao_produto_Linesclass = subGridpromocao_produto_Class+"Uniform";
            }
         }
         else if ( subGridpromocao_produto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridpromocao_produto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridpromocao_produto_Class, "") != 0 )
            {
               subGridpromocao_produto_Linesclass = subGridpromocao_produto_Class+"Odd";
            }
            subGridpromocao_produto_Backcolor = (int)(0x0);
         }
         else if ( subGridpromocao_produto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridpromocao_produto_Backstyle = 1;
            if ( ((int)((nGXsfl_63_idx) % (2))) == 0 )
            {
               subGridpromocao_produto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromocao_produto_Class, "") != 0 )
               {
                  subGridpromocao_produto_Linesclass = subGridpromocao_produto_Class+"Even";
               }
            }
            else
            {
               subGridpromocao_produto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridpromocao_produto_Class, "") != 0 )
               {
                  subGridpromocao_produto_Linesclass = subGridpromocao_produto_Class+"Odd";
               }
            }
         }
         imgprompt_19_Link = ((StringUtil.StrCmp(Gx_mode, "DSP")==0)||(StringUtil.StrCmp(Gx_mode, "UPD")==0) ? "" : "javascript:"+"gx.popup.openPrompt('"+"gx0060.aspx"+"',["+"{Ctrl:gx.dom.el('"+"PRODUTOID_"+sGXsfl_63_idx+"'), id:'"+"PRODUTOID_"+sGXsfl_63_idx+"'"+",IOType:'out'}"+"],"+"gx.dom.form()."+"nIsMod_8_"+sGXsfl_63_idx+","+"'', false"+","+"false"+");");
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_8_" + sGXsfl_63_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 64,'',false,'" + sGXsfl_63_idx + "',63)\"";
         ROClassString = "Attribute";
         Gridpromocao_produtoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoId_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A19ProdutoId), "ZZZ9"))," inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,',');"+";gx.evt.onblur(this,64);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdutoId_Enabled,(short)1,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)0,(bool)true,(string)"Id",(string)"right",(bool)false,(string)""});
         /* Subfile cell */
         /* Static images/pictures */
         ClassString = "gx-prompt Image" + " " + ((StringUtil.StrCmp(imgprompt_19_gximage, "")==0) ? "" : "GX_Image_"+imgprompt_19_gximage+"_Class");
         StyleString = "";
         sImgUrl = (string)(context.GetImagePath( "prompt.gif", "", context.GetTheme( )));
         Gridpromocao_produtoRow.AddColumnProperties("bitmap", 1, isAjaxCallMode( ), new Object[] {(string)imgprompt_19_Internalname,(string)sImgUrl,(string)imgprompt_19_Link,(string)"",(string)"",context.GetTheme( ),(int)imgprompt_19_Visible,(short)1,(string)"",(string)"",(short)0,(short)0,(short)0,(string)"",(short)0,(string)"",(short)0,(short)0,(short)0,(string)"",(string)"",(string)StyleString,(string)ClassString,(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(string)"",(short)1,(bool)false,(bool)false,context.GetImageSrcSet( sImgUrl)});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridpromocao_produtoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtProdutoNome_Internalname,(string)A20ProdutoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtProdutoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtProdutoNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)63,(short)0,(short)-1,(short)-1,(bool)true,(string)"Nome",(string)"left",(bool)true,(string)""});
         ajax_sending_grid_row(Gridpromocao_produtoRow);
         send_integrity_lvl_hashes078( ) ;
         GXCCtl = "Z19ProdutoId_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(Z19ProdutoId), 4, 0, ".", "")));
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_8), 4, 0, ".", "")));
         GXCCtl = "nRcdExists_8_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_8), 4, 0, ".", "")));
         GXCCtl = "nIsMod_8_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_8), 4, 0, ".", "")));
         GXCCtl = "vMODE_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_63_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV9TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV9TrnContext);
         }
         GXCCtl = "vPROMOCAOID_" + sGXsfl_63_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromocaoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTOID_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRODUTONOME_"+sGXsfl_63_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROMPT_19_"+sGXsfl_63_idx+"Link", StringUtil.RTrim( imgprompt_19_Link));
         ajax_sending_grid_row(null);
         Gridpromocao_produtoContainer.AddRow(Gridpromocao_produtoRow);
      }

      protected void ReadRow078( )
      {
         nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_638( ) ;
         edtProdutoId_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTOID_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         edtProdutoNome_Enabled = (int)(context.localUtil.CToN( cgiGet( "PRODUTONOME_"+sGXsfl_63_idx+"Enabled"), ".", ","));
         imgprompt_19_Link = cgiGet( "PROMPT_19_"+sGXsfl_63_idx+"Link");
         if ( ( ( context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ",") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ",") > Convert.ToDecimal( 9999 )) ) )
         {
            GXCCtl = "PRODUTOID_" + sGXsfl_63_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
            wbErr = true;
            A19ProdutoId = 0;
         }
         else
         {
            A19ProdutoId = (short)(context.localUtil.CToN( cgiGet( edtProdutoId_Internalname), ".", ","));
         }
         A20ProdutoNome = cgiGet( edtProdutoNome_Internalname);
         GXCCtl = "Z19ProdutoId_" + sGXsfl_63_idx;
         Z19ProdutoId = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdDeleted_8_" + sGXsfl_63_idx;
         nRcdDeleted_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nRcdExists_8_" + sGXsfl_63_idx;
         nRcdExists_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
         GXCCtl = "nIsMod_8_" + sGXsfl_63_idx;
         nIsMod_8 = (short)(context.localUtil.CToN( cgiGet( GXCCtl), ".", ","));
      }

      protected void assign_properties_default( )
      {
         defedtProdutoId_Enabled = edtProdutoId_Enabled;
      }

      protected void ConfirmValues070( )
      {
         nGXsfl_63_idx = 0;
         sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
         SubsflControlProps_638( ) ;
         while ( nGXsfl_63_idx < nRC_GXsfl_63 )
         {
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_638( ) ;
            ChangePostValue( "Z19ProdutoId_"+sGXsfl_63_idx, cgiGet( "ZT_"+"Z19ProdutoId_"+sGXsfl_63_idx)) ;
            DeletePostValue( "ZT_"+"Z19ProdutoId_"+sGXsfl_63_idx) ;
         }
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 849480), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 849480), false, true);
         context.AddJavascriptSource("calendar-en.js", "?"+context.GetBuildNumber( 849480), false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("promocao.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PromocaoId,4,0))}, new string[] {"Gx_mode","PromocaoId"}) +"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Promocao");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("promocao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z32PromocaoId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z32PromocaoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z33PromocaoDescricao", Z33PromocaoDescricao);
         GxWebStd.gx_hidden_field( context, "Z35PromocaoDataInicio", context.localUtil.DToC( Z35PromocaoDataInicio, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z36PromocaoDataTermino", context.localUtil.DToC( Z36PromocaoDataTermino, 0, "/"));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_63", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_63_idx), 8, 0, ".", "")));
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
         GxWebStd.gx_hidden_field( context, "vPROMOCAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PromocaoId), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPROMOCAOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PromocaoId), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "PROMOCAOIMAGEM_GXI", A40000PromocaoImagem_GXI);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV11Pgmname));
         GXCCtlgxBlob = "PROMOCAOIMAGEM" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A34PromocaoImagem);
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
         return formatLink("promocao.aspx", new object[] {UrlEncode(StringUtil.RTrim(Gx_mode)),UrlEncode(StringUtil.LTrimStr(AV7PromocaoId,4,0))}, new string[] {"Gx_mode","PromocaoId"})  ;
      }

      public override string GetPgmname( )
      {
         return "Promocao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Promoção" ;
      }

      protected void InitializeNonKey077( )
      {
         A33PromocaoDescricao = "";
         AssignAttri("", false, "A33PromocaoDescricao", A33PromocaoDescricao);
         A34PromocaoImagem = "";
         AssignAttri("", false, "A34PromocaoImagem", A34PromocaoImagem);
         AssignProp("", false, imgPromocaoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A34PromocaoImagem))), true);
         AssignProp("", false, imgPromocaoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A34PromocaoImagem), true);
         A40000PromocaoImagem_GXI = "";
         AssignProp("", false, imgPromocaoImagem_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A34PromocaoImagem)) ? A40000PromocaoImagem_GXI : context.convertURL( context.PathToRelativeUrl( A34PromocaoImagem))), true);
         AssignProp("", false, imgPromocaoImagem_Internalname, "SrcSet", context.GetImageSrcSet( A34PromocaoImagem), true);
         A35PromocaoDataInicio = DateTime.MinValue;
         AssignAttri("", false, "A35PromocaoDataInicio", context.localUtil.Format(A35PromocaoDataInicio, "99/99/99"));
         A36PromocaoDataTermino = DateTime.MinValue;
         AssignAttri("", false, "A36PromocaoDataTermino", context.localUtil.Format(A36PromocaoDataTermino, "99/99/99"));
         Z33PromocaoDescricao = "";
         Z35PromocaoDataInicio = DateTime.MinValue;
         Z36PromocaoDataTermino = DateTime.MinValue;
      }

      protected void InitAll077( )
      {
         A32PromocaoId = 0;
         AssignAttri("", false, "A32PromocaoId", StringUtil.LTrimStr( (decimal)(A32PromocaoId), 4, 0));
         InitializeNonKey077( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void InitializeNonKey078( )
      {
         A20ProdutoNome = "";
      }

      protected void InitAll078( )
      {
         A19ProdutoId = 0;
         InitializeNonKey078( ) ;
      }

      protected void StandaloneModalInsert078( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202582916514133", true, true);
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
         context.AddJavascriptSource("promocao.js", "?202582916514134", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties8( )
      {
         edtProdutoId_Enabled = defedtProdutoId_Enabled;
         AssignProp("", false, edtProdutoId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtProdutoId_Enabled), 5, 0), !bGXsfl_63_Refreshing);
      }

      protected void StartGridControl63( )
      {
         Gridpromocao_produtoContainer.AddObjectProperty("GridName", "Gridpromocao_produto");
         Gridpromocao_produtoContainer.AddObjectProperty("Header", subGridpromocao_produto_Header);
         Gridpromocao_produtoContainer.AddObjectProperty("Class", "Grid");
         Gridpromocao_produtoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Backcolorstyle), 1, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("CmpContext", "");
         Gridpromocao_produtoContainer.AddObjectProperty("InMasterPage", "false");
         Gridpromocao_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromocao_produtoColumn.AddObjectProperty("Value", StringUtil.LTrim( StringUtil.NToC( (decimal)(A19ProdutoId), 4, 0, ".", "")));
         Gridpromocao_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoId_Enabled), 5, 0, ".", "")));
         Gridpromocao_produtoContainer.AddColumnProperties(Gridpromocao_produtoColumn);
         Gridpromocao_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromocao_produtoContainer.AddColumnProperties(Gridpromocao_produtoColumn);
         Gridpromocao_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridpromocao_produtoColumn.AddObjectProperty("Value", A20ProdutoNome);
         Gridpromocao_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtProdutoNome_Enabled), 5, 0, ".", "")));
         Gridpromocao_produtoContainer.AddColumnProperties(Gridpromocao_produtoColumn);
         Gridpromocao_produtoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Selectedindex), 4, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Allowselection), 1, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Selectioncolor), 9, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Allowhovering), 1, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Hoveringcolor), 9, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Allowcollapsing), 1, 0, ".", "")));
         Gridpromocao_produtoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridpromocao_produto_Collapsed), 1, 0, ".", "")));
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
         edtPromocaoId_Internalname = "PROMOCAOID";
         edtPromocaoDescricao_Internalname = "PROMOCAODESCRICAO";
         imgPromocaoImagem_Internalname = "PROMOCAOIMAGEM";
         edtPromocaoDataInicio_Internalname = "PROMOCAODATAINICIO";
         edtPromocaoDataTermino_Internalname = "PROMOCAODATATERMINO";
         lblTitleproduto_Internalname = "TITLEPRODUTO";
         edtProdutoId_Internalname = "PRODUTOID";
         edtProdutoNome_Internalname = "PRODUTONOME";
         divProdutotable_Internalname = "PRODUTOTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         imgprompt_19_Internalname = "PROMPT_19";
         subGridpromocao_produto_Internalname = "GRIDPROMOCAO_PRODUTO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("LojaAnnaLaisa");
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridpromocao_produto_Allowcollapsing = 0;
         subGridpromocao_produto_Allowselection = 0;
         subGridpromocao_produto_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Promoção";
         edtProdutoNome_Jsonclick = "";
         imgprompt_19_Visible = 1;
         imgprompt_19_Link = "";
         imgprompt_19_Visible = 1;
         edtProdutoId_Jsonclick = "";
         subGridpromocao_produto_Class = "Grid";
         subGridpromocao_produto_Backcolorstyle = 0;
         edtProdutoNome_Enabled = 0;
         edtProdutoId_Enabled = 1;
         bttBtn_delete_Enabled = 0;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Tooltiptext = "Confirm";
         bttBtn_enter_Caption = "Confirm";
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtPromocaoDataTermino_Jsonclick = "";
         edtPromocaoDataTermino_Enabled = 1;
         edtPromocaoDataInicio_Jsonclick = "";
         edtPromocaoDataInicio_Enabled = 1;
         imgPromocaoImagem_Enabled = 1;
         edtPromocaoDescricao_Jsonclick = "";
         edtPromocaoDescricao_Enabled = 1;
         edtPromocaoId_Jsonclick = "";
         edtPromocaoId_Enabled = 1;
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

      protected void gxnrGridpromocao_produto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_638( ) ;
         while ( nGXsfl_63_idx <= nRC_GXsfl_63 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal078( ) ;
            standaloneModal078( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow078( ) ;
            nGXsfl_63_idx = (int)(nGXsfl_63_idx+1);
            sGXsfl_63_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_63_idx), 4, 0), 4, "0");
            SubsflControlProps_638( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridpromocao_produtoContainer)) ;
         /* End function gxnrGridpromocao_produto_newrow */
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

      public void Valid_Produtoid( )
      {
         /* Using cursor T000721 */
         pr_default.execute(19, new Object[] {A19ProdutoId});
         if ( (pr_default.getStatus(19) == 101) )
         {
            GX_msglist.addItem("No matching 'Produto'.", "ForeignKeyNotFound", 1, "PRODUTOID");
            AnyError = 1;
            GX_FocusControl = edtProdutoId_Internalname;
         }
         A20ProdutoNome = T000721_A20ProdutoNome[0];
         pr_default.close(19);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A20ProdutoNome", A20ProdutoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PromocaoId',fld:'vPROMOCAOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PromocaoId',fld:'vPROMOCAOID',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12072',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV9TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PROMOCAOID","{handler:'Valid_Promocaoid',iparms:[]");
         setEventMetadata("VALID_PROMOCAOID",",oparms:[]}");
         setEventMetadata("VALID_PROMOCAODATAINICIO","{handler:'Valid_Promocaodatainicio',iparms:[]");
         setEventMetadata("VALID_PROMOCAODATAINICIO",",oparms:[]}");
         setEventMetadata("VALID_PROMOCAODATATERMINO","{handler:'Valid_Promocaodatatermino',iparms:[]");
         setEventMetadata("VALID_PROMOCAODATATERMINO",",oparms:[]}");
         setEventMetadata("VALID_PRODUTOID","{handler:'Valid_Produtoid',iparms:[{av:'A19ProdutoId',fld:'PRODUTOID',pic:'ZZZ9'},{av:'A20ProdutoNome',fld:'PRODUTONOME',pic:''}]");
         setEventMetadata("VALID_PRODUTOID",",oparms:[{av:'A20ProdutoNome',fld:'PRODUTONOME',pic:''}]}");
         setEventMetadata("NULL","{handler:'Valid_Produtonome',iparms:[]");
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
         pr_default.close(1);
         pr_default.close(19);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         Z33PromocaoDescricao = "";
         Z35PromocaoDataInicio = DateTime.MinValue;
         Z36PromocaoDataTermino = DateTime.MinValue;
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
         A33PromocaoDescricao = "";
         A34PromocaoImagem = "";
         A40000PromocaoImagem_GXI = "";
         sImgUrl = "";
         A35PromocaoDataInicio = DateTime.MinValue;
         A36PromocaoDataTermino = DateTime.MinValue;
         lblTitleproduto_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridpromocao_produtoContainer = new GXWebGrid( context);
         sMode8 = "";
         sStyleString = "";
         AV11Pgmname = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode7 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A20ProdutoNome = "";
         AV9TrnContext = new GeneXus.Programs.general.ui.SdtTransactionContext(context);
         AV10WebSession = context.GetSession();
         Z34PromocaoImagem = "";
         Z40000PromocaoImagem_GXI = "";
         T00077_A32PromocaoId = new short[1] ;
         T00077_A33PromocaoDescricao = new string[] {""} ;
         T00077_A40000PromocaoImagem_GXI = new string[] {""} ;
         T00077_A35PromocaoDataInicio = new DateTime[] {DateTime.MinValue} ;
         T00077_A36PromocaoDataTermino = new DateTime[] {DateTime.MinValue} ;
         T00077_A34PromocaoImagem = new string[] {""} ;
         T00078_A32PromocaoId = new short[1] ;
         T00076_A32PromocaoId = new short[1] ;
         T00076_A33PromocaoDescricao = new string[] {""} ;
         T00076_A40000PromocaoImagem_GXI = new string[] {""} ;
         T00076_A35PromocaoDataInicio = new DateTime[] {DateTime.MinValue} ;
         T00076_A36PromocaoDataTermino = new DateTime[] {DateTime.MinValue} ;
         T00076_A34PromocaoImagem = new string[] {""} ;
         T00079_A32PromocaoId = new short[1] ;
         T000710_A32PromocaoId = new short[1] ;
         T00075_A32PromocaoId = new short[1] ;
         T00075_A33PromocaoDescricao = new string[] {""} ;
         T00075_A40000PromocaoImagem_GXI = new string[] {""} ;
         T00075_A35PromocaoDataInicio = new DateTime[] {DateTime.MinValue} ;
         T00075_A36PromocaoDataTermino = new DateTime[] {DateTime.MinValue} ;
         T00075_A34PromocaoImagem = new string[] {""} ;
         T000715_A32PromocaoId = new short[1] ;
         Z20ProdutoNome = "";
         T000716_A32PromocaoId = new short[1] ;
         T000716_A20ProdutoNome = new string[] {""} ;
         T000716_A19ProdutoId = new short[1] ;
         T00074_A20ProdutoNome = new string[] {""} ;
         T000717_A20ProdutoNome = new string[] {""} ;
         T000718_A32PromocaoId = new short[1] ;
         T000718_A19ProdutoId = new short[1] ;
         T00073_A32PromocaoId = new short[1] ;
         T00073_A19ProdutoId = new short[1] ;
         T00072_A32PromocaoId = new short[1] ;
         T00072_A19ProdutoId = new short[1] ;
         T000721_A20ProdutoNome = new string[] {""} ;
         T000722_A32PromocaoId = new short[1] ;
         T000722_A19ProdutoId = new short[1] ;
         Gridpromocao_produtoRow = new GXWebRow();
         subGridpromocao_produto_Linesclass = "";
         ROClassString = "";
         imgprompt_19_gximage = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         Gridpromocao_produtoColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.promocao__default(),
            new Object[][] {
                new Object[] {
               T00072_A32PromocaoId, T00072_A19ProdutoId
               }
               , new Object[] {
               T00073_A32PromocaoId, T00073_A19ProdutoId
               }
               , new Object[] {
               T00074_A20ProdutoNome
               }
               , new Object[] {
               T00075_A32PromocaoId, T00075_A33PromocaoDescricao, T00075_A40000PromocaoImagem_GXI, T00075_A35PromocaoDataInicio, T00075_A36PromocaoDataTermino, T00075_A34PromocaoImagem
               }
               , new Object[] {
               T00076_A32PromocaoId, T00076_A33PromocaoDescricao, T00076_A40000PromocaoImagem_GXI, T00076_A35PromocaoDataInicio, T00076_A36PromocaoDataTermino, T00076_A34PromocaoImagem
               }
               , new Object[] {
               T00077_A32PromocaoId, T00077_A33PromocaoDescricao, T00077_A40000PromocaoImagem_GXI, T00077_A35PromocaoDataInicio, T00077_A36PromocaoDataTermino, T00077_A34PromocaoImagem
               }
               , new Object[] {
               T00078_A32PromocaoId
               }
               , new Object[] {
               T00079_A32PromocaoId
               }
               , new Object[] {
               T000710_A32PromocaoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000715_A32PromocaoId
               }
               , new Object[] {
               T000716_A32PromocaoId, T000716_A20ProdutoNome, T000716_A19ProdutoId
               }
               , new Object[] {
               T000717_A20ProdutoNome
               }
               , new Object[] {
               T000718_A32PromocaoId, T000718_A19ProdutoId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000721_A20ProdutoNome
               }
               , new Object[] {
               T000722_A32PromocaoId, T000722_A19ProdutoId
               }
            }
         );
         AV11Pgmname = "Promocao";
      }

      private short nIsMod_8 ;
      private short wcpOAV7PromocaoId ;
      private short Z32PromocaoId ;
      private short Z19ProdutoId ;
      private short nRcdDeleted_8 ;
      private short nRcdExists_8 ;
      private short GxWebError ;
      private short A19ProdutoId ;
      private short AV7PromocaoId ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A32PromocaoId ;
      private short nBlankRcdCount8 ;
      private short RcdFound8 ;
      private short nBlankRcdUsr8 ;
      private short RcdFound7 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_7 ;
      private short nIsDirty_8 ;
      private short subGridpromocao_produto_Backcolorstyle ;
      private short subGridpromocao_produto_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridpromocao_produto_Allowselection ;
      private short subGridpromocao_produto_Allowhovering ;
      private short subGridpromocao_produto_Allowcollapsing ;
      private short subGridpromocao_produto_Collapsed ;
      private int nRC_GXsfl_63 ;
      private int nGXsfl_63_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtPromocaoId_Enabled ;
      private int edtPromocaoDescricao_Enabled ;
      private int imgPromocaoImagem_Enabled ;
      private int edtPromocaoDataInicio_Enabled ;
      private int edtPromocaoDataTermino_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtProdutoId_Enabled ;
      private int edtProdutoNome_Enabled ;
      private int fRowAdded ;
      private int subGridpromocao_produto_Backcolor ;
      private int subGridpromocao_produto_Allbackcolor ;
      private int imgprompt_19_Visible ;
      private int defedtProdutoId_Enabled ;
      private int idxLst ;
      private int subGridpromocao_produto_Selectedindex ;
      private int subGridpromocao_produto_Selectioncolor ;
      private int subGridpromocao_produto_Hoveringcolor ;
      private long GRIDPROMOCAO_PRODUTO_nFirstRecordOnPage ;
      private string sPrefix ;
      private string sGXsfl_63_idx="0001" ;
      private string wcpOGx_mode ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPromocaoId_Internalname ;
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
      private string edtPromocaoId_Jsonclick ;
      private string edtPromocaoDescricao_Internalname ;
      private string edtPromocaoDescricao_Jsonclick ;
      private string imgPromocaoImagem_Internalname ;
      private string sImgUrl ;
      private string edtPromocaoDataInicio_Internalname ;
      private string edtPromocaoDataInicio_Jsonclick ;
      private string edtPromocaoDataTermino_Internalname ;
      private string edtPromocaoDataTermino_Jsonclick ;
      private string divProdutotable_Internalname ;
      private string lblTitleproduto_Internalname ;
      private string lblTitleproduto_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Caption ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_enter_Tooltiptext ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode8 ;
      private string edtProdutoId_Internalname ;
      private string edtProdutoNome_Internalname ;
      private string imgprompt_19_Link ;
      private string sStyleString ;
      private string subGridpromocao_produto_Internalname ;
      private string AV11Pgmname ;
      private string hsh ;
      private string sMode7 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string imgprompt_19_Internalname ;
      private string sGXsfl_63_fel_idx="0001" ;
      private string subGridpromocao_produto_Class ;
      private string subGridpromocao_produto_Linesclass ;
      private string ROClassString ;
      private string edtProdutoId_Jsonclick ;
      private string imgprompt_19_gximage ;
      private string edtProdutoNome_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string subGridpromocao_produto_Header ;
      private DateTime Z35PromocaoDataInicio ;
      private DateTime Z36PromocaoDataTermino ;
      private DateTime A35PromocaoDataInicio ;
      private DateTime A36PromocaoDataTermino ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A34PromocaoImagem_IsBlob ;
      private bool bGXsfl_63_Refreshing=false ;
      private bool returnInSub ;
      private string Z33PromocaoDescricao ;
      private string A33PromocaoDescricao ;
      private string A40000PromocaoImagem_GXI ;
      private string A20ProdutoNome ;
      private string Z40000PromocaoImagem_GXI ;
      private string Z20ProdutoNome ;
      private string A34PromocaoImagem ;
      private string Z34PromocaoImagem ;
      private IGxSession AV10WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridpromocao_produtoContainer ;
      private GXWebRow Gridpromocao_produtoRow ;
      private GXWebColumn Gridpromocao_produtoColumn ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00077_A32PromocaoId ;
      private string[] T00077_A33PromocaoDescricao ;
      private string[] T00077_A40000PromocaoImagem_GXI ;
      private DateTime[] T00077_A35PromocaoDataInicio ;
      private DateTime[] T00077_A36PromocaoDataTermino ;
      private string[] T00077_A34PromocaoImagem ;
      private short[] T00078_A32PromocaoId ;
      private short[] T00076_A32PromocaoId ;
      private string[] T00076_A33PromocaoDescricao ;
      private string[] T00076_A40000PromocaoImagem_GXI ;
      private DateTime[] T00076_A35PromocaoDataInicio ;
      private DateTime[] T00076_A36PromocaoDataTermino ;
      private string[] T00076_A34PromocaoImagem ;
      private short[] T00079_A32PromocaoId ;
      private short[] T000710_A32PromocaoId ;
      private short[] T00075_A32PromocaoId ;
      private string[] T00075_A33PromocaoDescricao ;
      private string[] T00075_A40000PromocaoImagem_GXI ;
      private DateTime[] T00075_A35PromocaoDataInicio ;
      private DateTime[] T00075_A36PromocaoDataTermino ;
      private string[] T00075_A34PromocaoImagem ;
      private short[] T000715_A32PromocaoId ;
      private short[] T000716_A32PromocaoId ;
      private string[] T000716_A20ProdutoNome ;
      private short[] T000716_A19ProdutoId ;
      private string[] T00074_A20ProdutoNome ;
      private string[] T000717_A20ProdutoNome ;
      private short[] T000718_A32PromocaoId ;
      private short[] T000718_A19ProdutoId ;
      private short[] T00073_A32PromocaoId ;
      private short[] T00073_A19ProdutoId ;
      private short[] T00072_A32PromocaoId ;
      private short[] T00072_A19ProdutoId ;
      private string[] T000721_A20ProdutoNome ;
      private short[] T000722_A32PromocaoId ;
      private short[] T000722_A19ProdutoId ;
      private GXWebForm Form ;
      private GeneXus.Programs.general.ui.SdtTransactionContext AV9TrnContext ;
   }

   public class promocao__default : DataStoreHelperBase, IDataStoreHelper
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
         ,new UpdateCursor(def[9])
         ,new UpdateCursor(def[10])
         ,new UpdateCursor(def[11])
         ,new UpdateCursor(def[12])
         ,new ForEachCursor(def[13])
         ,new ForEachCursor(def[14])
         ,new ForEachCursor(def[15])
         ,new ForEachCursor(def[16])
         ,new UpdateCursor(def[17])
         ,new UpdateCursor(def[18])
         ,new ForEachCursor(def[19])
         ,new ForEachCursor(def[20])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmT00077;
          prmT00077 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT00078;
          prmT00078 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT00076;
          prmT00076 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT00079;
          prmT00079 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT000710;
          prmT000710 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT00075;
          prmT00075 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT000711;
          prmT000711 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0) ,
          new ParDef("@PromocaoDescricao",GXType.NVarChar,40,0) ,
          new ParDef("@PromocaoImagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromocaoImagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=2, Tbl="Promocao", Fld="PromocaoImagem"} ,
          new ParDef("@PromocaoDataInicio",GXType.Date,8,0) ,
          new ParDef("@PromocaoDataTermino",GXType.Date,8,0)
          };
          Object[] prmT000712;
          prmT000712 = new Object[] {
          new ParDef("@PromocaoDescricao",GXType.NVarChar,40,0) ,
          new ParDef("@PromocaoDataInicio",GXType.Date,8,0) ,
          new ParDef("@PromocaoDataTermino",GXType.Date,8,0) ,
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT000713;
          prmT000713 = new Object[] {
          new ParDef("@PromocaoImagem",GXType.Blob,1024,0){InDB=false} ,
          new ParDef("@PromocaoImagem_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="Promocao", Fld="PromocaoImagem"} ,
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT000714;
          prmT000714 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT000715;
          prmT000715 = new Object[] {
          };
          Object[] prmT000716;
          prmT000716 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00074;
          prmT00074 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000717;
          prmT000717 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000718;
          prmT000718 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00073;
          prmT00073 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT00072;
          prmT00072 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000719;
          prmT000719 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000720;
          prmT000720 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0) ,
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          Object[] prmT000722;
          prmT000722 = new Object[] {
          new ParDef("@PromocaoId",GXType.Int16,4,0)
          };
          Object[] prmT000721;
          prmT000721 = new Object[] {
          new ParDef("@ProdutoId",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("T00072", "SELECT [PromocaoId], [ProdutoId] FROM [PromocaoProduto] WITH (UPDLOCK) WHERE [PromocaoId] = @PromocaoId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00072,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00073", "SELECT [PromocaoId], [ProdutoId] FROM [PromocaoProduto] WHERE [PromocaoId] = @PromocaoId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00073,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00074", "SELECT [ProdutoNome] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00074,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00075", "SELECT [PromocaoId], [PromocaoDescricao], [PromocaoImagem_GXI], [PromocaoDataInicio], [PromocaoDataTermino], [PromocaoImagem] FROM [Promocao] WITH (UPDLOCK) WHERE [PromocaoId] = @PromocaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00075,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00076", "SELECT [PromocaoId], [PromocaoDescricao], [PromocaoImagem_GXI], [PromocaoDataInicio], [PromocaoDataTermino], [PromocaoImagem] FROM [Promocao] WHERE [PromocaoId] = @PromocaoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00076,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00077", "SELECT TM1.[PromocaoId], TM1.[PromocaoDescricao], TM1.[PromocaoImagem_GXI], TM1.[PromocaoDataInicio], TM1.[PromocaoDataTermino], TM1.[PromocaoImagem] FROM [Promocao] TM1 WHERE TM1.[PromocaoId] = @PromocaoId ORDER BY TM1.[PromocaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT00077,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00078", "SELECT [PromocaoId] FROM [Promocao] WHERE [PromocaoId] = @PromocaoId  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00078,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T00079", "SELECT TOP 1 [PromocaoId] FROM [Promocao] WHERE ( [PromocaoId] > @PromocaoId) ORDER BY [PromocaoId]  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT00079,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000710", "SELECT TOP 1 [PromocaoId] FROM [Promocao] WHERE ( [PromocaoId] < @PromocaoId) ORDER BY [PromocaoId] DESC  OPTION (FAST 1)",true, GxErrorMask.GX_NOMASK, false, this,prmT000710,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("T000711", "INSERT INTO [Promocao]([PromocaoId], [PromocaoDescricao], [PromocaoImagem], [PromocaoImagem_GXI], [PromocaoDataInicio], [PromocaoDataTermino]) VALUES(@PromocaoId, @PromocaoDescricao, @PromocaoImagem, @PromocaoImagem_GXI, @PromocaoDataInicio, @PromocaoDataTermino)", GxErrorMask.GX_NOMASK,prmT000711)
             ,new CursorDef("T000712", "UPDATE [Promocao] SET [PromocaoDescricao]=@PromocaoDescricao, [PromocaoDataInicio]=@PromocaoDataInicio, [PromocaoDataTermino]=@PromocaoDataTermino  WHERE [PromocaoId] = @PromocaoId", GxErrorMask.GX_NOMASK,prmT000712)
             ,new CursorDef("T000713", "UPDATE [Promocao] SET [PromocaoImagem]=@PromocaoImagem, [PromocaoImagem_GXI]=@PromocaoImagem_GXI  WHERE [PromocaoId] = @PromocaoId", GxErrorMask.GX_NOMASK,prmT000713)
             ,new CursorDef("T000714", "DELETE FROM [Promocao]  WHERE [PromocaoId] = @PromocaoId", GxErrorMask.GX_NOMASK,prmT000714)
             ,new CursorDef("T000715", "SELECT [PromocaoId] FROM [Promocao] ORDER BY [PromocaoId]  OPTION (FAST 100)",true, GxErrorMask.GX_NOMASK, false, this,prmT000715,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000716", "SELECT T1.[PromocaoId], T2.[ProdutoNome], T1.[ProdutoId] FROM ([PromocaoProduto] T1 INNER JOIN [Produto] T2 ON T2.[ProdutoId] = T1.[ProdutoId]) WHERE T1.[PromocaoId] = @PromocaoId and T1.[ProdutoId] = @ProdutoId ORDER BY T1.[PromocaoId], T1.[ProdutoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000716,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000717", "SELECT [ProdutoNome] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000717,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000718", "SELECT [PromocaoId], [ProdutoId] FROM [PromocaoProduto] WHERE [PromocaoId] = @PromocaoId AND [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000718,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000719", "INSERT INTO [PromocaoProduto]([PromocaoId], [ProdutoId]) VALUES(@PromocaoId, @ProdutoId)", GxErrorMask.GX_NOMASK,prmT000719)
             ,new CursorDef("T000720", "DELETE FROM [PromocaoProduto]  WHERE [PromocaoId] = @PromocaoId AND [ProdutoId] = @ProdutoId", GxErrorMask.GX_NOMASK,prmT000720)
             ,new CursorDef("T000721", "SELECT [ProdutoNome] FROM [Produto] WHERE [ProdutoId] = @ProdutoId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000721,1, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("T000722", "SELECT [PromocaoId], [ProdutoId] FROM [PromocaoProduto] WHERE [PromocaoId] = @PromocaoId ORDER BY [PromocaoId], [ProdutoId] ",true, GxErrorMask.GX_NOMASK, false, this,prmT000722,11, GxCacheFrequency.OFF ,true,false )
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
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 2 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 3 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 4 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 5 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getMultimediaUri(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
                ((string[]) buf[5])[0] = rslt.getMultimediaFile(6, rslt.getVarchar(3));
                return;
             case 6 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 7 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 8 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 13 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                return;
             case 14 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                return;
             case 15 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 16 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
             case 19 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                return;
             case 20 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                return;
       }
    }

 }

}
