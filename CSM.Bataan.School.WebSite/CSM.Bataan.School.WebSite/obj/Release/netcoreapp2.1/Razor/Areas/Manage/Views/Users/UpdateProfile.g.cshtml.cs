#pragma checksum "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\UpdateProfile.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eda81482e557ce52e827a85232a4009e90ffc141"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Users_UpdateProfile), @"mvc.1.0.view", @"/Areas/Manage/Views/Users/UpdateProfile.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Manage/Views/Users/UpdateProfile.cshtml", typeof(AspNetCore.Areas_Manage_Views_Users_UpdateProfile))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eda81482e557ce52e827a85232a4009e90ffc141", @"/Areas/Manage/Views/Users/UpdateProfile.cshtml")]
    public class Areas_Manage_Views_Users_UpdateProfile : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Users.UpdateProfileViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/manage/users"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/manage/users/update-profile"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\UpdateProfile.cshtml"
  
    ViewData["Title"] = "UpdateProfile";
    Layout = "~/areas/manage/views/shared/_forms.cshtml";

#line default
#line hidden
            BeginContext(195, 25, true);
            WriteLiteral("<div class=\"card-header\">");
            EndContext();
            BeginContext(220, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e8d70e0844274645ae6c4fa33e4019c0", async() => {
                BeginContext(245, 43, true);
                WriteLiteral("<span class=\"fa fa-arrow-left\"></span> back");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(292, 155, true);
            WriteLiteral("</div>\r\n<div class=\"card-body\">\r\n    <div class=\"card-title\">\r\n        <h3 class=\"text-center title-2\">Update User Profile</h3>\r\n    </div>\r\n    <hr>\r\n    ");
            EndContext();
            BeginContext(447, 1377, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02204c02605141a48b4122ba8a9e4009", async() => {
                BeginContext(506, 48, true);
                WriteLiteral("\r\n        <div class=\"form-group\">\r\n            ");
                EndContext();
                BeginContext(555, 23, false);
#line 14 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\UpdateProfile.cshtml"
       Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(578, 14, true);
                WriteLiteral("\r\n            ");
                EndContext();
                BeginContext(593, 24, false);
#line 15 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\UpdateProfile.cshtml"
       Write(Html.ValidationSummary());

#line default
#line hidden
                EndContext();
                BeginContext(617, 274, true);
                WriteLiteral(@"
        </div>
        <div class=""form-group"">
            <input type=""hidden"" asp-for=""UserId"" />
            <label for=""firstName"" class=""control-label mb-1"">First Name</label>
            <input type=""text"" class=""form-control"" id=""firstName"" asp-for=""FirstName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 891, "\"", 915, 1);
#line 20 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\UpdateProfile.cshtml"
WriteAttributeValue("", 899, Model.FirstName, 899, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(916, 293, true);
                WriteLiteral(@" aria-describedby=""firstNameHelp"" placeholder=""Enter first name"">
        </div>
        <div class=""form-group has-success"">
            <label for=""lastName"" class=""control-label mb-1"">Last Name</label>
            <input type=""text"" class=""form-control"" id=""lastName"" asp-for=""LastName""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1209, "\"", 1232, 1);
#line 24 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\UpdateProfile.cshtml"
WriteAttributeValue("", 1217, Model.LastName, 1217, 15, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1233, 288, true);
                WriteLiteral(@" aria-describedby=""lastNameHelp"" placeholder=""Enter last name"">
        </div>
        <div class=""form-group"">
            <label for=""phonenumber"" class=""control-label mb-1"">Phone Number</label>
            <input type=""text"" class=""form-control"" id=""phoneNumber"" name=""PhoneNumber""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 1521, "\"", 1547, 1);
#line 28 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\UpdateProfile.cshtml"
WriteAttributeValue("", 1529, Model.PhoneNumber, 1529, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1548, 189, true);
                WriteLiteral(" aria-describedby=\"phoneNumberHelp\" placeholder=\"Enter phone Number\">\r\n        </div>\r\n        <div>\r\n            <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n            ");
                EndContext();
                BeginContext(1737, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02e45750fb234944b406cd38c1d726a3", async() => {
                    BeginContext(1785, 6, true);
                    WriteLiteral("Cancel");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1795, 22, true);
                WriteLiteral("\r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1824, 10, true);
            WriteLiteral("\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Users.UpdateProfileViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
