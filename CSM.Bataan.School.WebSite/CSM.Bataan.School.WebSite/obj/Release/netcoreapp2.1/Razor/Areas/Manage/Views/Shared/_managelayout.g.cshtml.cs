#pragma checksum "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef0f99186d4ee10b2c308d8d1b43b3324fadf629"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Shared__managelayout), @"mvc.1.0.view", @"/Areas/Manage/Views/Shared/_managelayout.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Manage/Views/Shared/_managelayout.cshtml", typeof(AspNetCore.Areas_Manage_Views_Shared__managelayout))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef0f99186d4ee10b2c308d8d1b43b3324fadf629", @"/Areas/Manage/Views/Shared/_managelayout.cshtml")]
    public class Areas_Manage_Views_Shared__managelayout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/selectize/dist/css/selectize.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/vendor/selectize/dist/js/standalone/selectize.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 1 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml"
  
    Layout = "~/views/shared/_layout.cshtml";

#line default
#line hidden
            BeginContext(54, 66, true);
            WriteLiteral("\r\n<div class=\"divider\">\r\n</div>\r\n\r\n\r\n<div class=\"container\">\r\n    ");
            EndContext();
            BeginContext(121, 33, false);
#line 10 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml"
Write(RenderSection("tableHead", false));

#line default
#line hidden
            EndContext();
            BeginContext(154, 8, true);
            WriteLiteral("\r\n\r\n    ");
            EndContext();
            BeginContext(163, 12, false);
#line 12 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml"
Write(RenderBody());

#line default
#line hidden
            EndContext();
            BeginContext(175, 8, true);
            WriteLiteral("\r\n\r\n    ");
            EndContext();
            BeginContext(184, 30, false);
#line 14 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml"
Write(RenderSection("extras", false));

#line default
#line hidden
            EndContext();
            BeginContext(214, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("pageScriptsTop", async() => {
                BeginContext(250, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(257, 38, false);
#line 18 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml"
Write(RenderSection("pageScriptsTop", false));

#line default
#line hidden
                EndContext();
                BeginContext(295, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(300, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("pageStyles", async() => {
                BeginContext(322, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(328, 90, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "02ca17de7d8c49d38e3497be8c5f6d02", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(418, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(425, 34, false);
#line 23 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml"
Write(RenderSection("pageStyles", false));

#line default
#line hidden
                EndContext();
                BeginContext(459, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(464, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("pageScripts", async() => {
                BeginContext(487, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(493, 78, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9b0c8a41bec04558a10f70e37c600914", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(571, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(578, 35, false);
#line 28 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Shared\_managelayout.cshtml"
Write(RenderSection("pageScripts", false));

#line default
#line hidden
                EndContext();
                BeginContext(613, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
