#pragma checksum "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "54af542c09128bcb81f0495029d8a1619dd36b00"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Users_Invite), @"mvc.1.0.view", @"/Areas/Manage/Views/Users/Invite.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Manage/Views/Users/Invite.cshtml", typeof(AspNetCore.Areas_Manage_Views_Users_Invite))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"54af542c09128bcb81f0495029d8a1619dd36b00", @"/Areas/Manage/Views/Users/Invite.cshtml")]
    public class Areas_Manage_Views_Users_Invite : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Users.CreateViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/manage/users"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/manage/users/invite"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml"
  
    ViewData["Title"] = "Create User";
    Layout = "~/areas/manage/views/shared/_forms.cshtml";

#line default
#line hidden
            BeginContext(186, 25, true);
            WriteLiteral("<div class=\"card-header\">");
            EndContext();
            BeginContext(211, 72, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "990027a574a44db1acb0d528d6d9d76f", async() => {
                BeginContext(236, 43, true);
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
            BeginContext(283, 153, true);
            WriteLiteral("</div>\r\n<div class=\"card-body\">\r\n    <div class=\"card-title\">\r\n        <h3 class=\"text-center title-2\">Invite a new User</h3>\r\n    </div>\r\n    <hr>\r\n    ");
            EndContext();
            BeginContext(436, 2088, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2bb5ba8e4667463b808fc78ed64844e6", async() => {
                BeginContext(487, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(498, 23, false);
#line 13 "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
                EndContext();
                BeginContext(521, 10, true);
                WriteLiteral("\r\n        ");
                EndContext();
                BeginContext(532, 24, false);
#line 14 "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml"
   Write(Html.ValidationSummary());

#line default
#line hidden
                EndContext();
                BeginContext(556, 1327, true);
                WriteLiteral(@"
        <div class=""form-group"">
            <label for=""emailAddress"" class=""control-label mb-1"">Email Address</label>
            <input type=""email"" class=""form-control"" id=""emailAddress"" name=""EmailAddress"" aria-describedby=""emailAddressHelp"" placeholder=""Enter email address"">
        </div>
        <div class=""form-group"">
            <label for=""phonenumber"" class=""control-label mb-1"">Phone Number</label>
            <input type=""text"" class=""form-control"" id=""phoneNumber"" name=""PhoneNumber"" aria-describedby=""phoneNumberHelp"" placeholder=""Enter phone Number"">
        </div>
        <div class=""form-group"">
            <label for=""firstName"" class=""control-label mb-1"">First Name</label>
            <input type=""text"" class=""form-control"" id=""firstName"" name=""FirstName"" aria-describedby=""firstNameHelp"" placeholder=""Enter first name"">
        </div>
        <div class=""form-group"">
            <label for=""lastName"" class=""control-label mb-1"">Last Name</label>
            <input type=""text"" ");
                WriteLiteral(@"class=""form-control"" id=""lastName"" name=""LastName"" aria-describedby=""lastNameHelp"" placeholder=""Enter last name"">
        </div>
        <div class=""form-group"">
            <label for=""gender"" class=""control-label mb-1"">Role</label>
            <select class=""form-control"" id=""role"" name=""Role"">
");
                EndContext();
#line 34 "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml"
                  
                    var options = Enum.GetValues(typeof(CSM.Bataan.School.WebSite.Infrastructure.Data.Enums.Role)).Cast<CSM.Bataan.School.WebSite.Infrastructure.Data.Enums.Role>();

                    foreach (CSM.Bataan.School.WebSite.Infrastructure.Data.Enums.Role option in options)
                    {

#line default
#line hidden
                BeginContext(2216, 31, true);
                WriteLiteral("                        <option");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 2247, "\"", 2262, 1);
#line 39 "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml"
WriteAttributeValue("", 2255, option, 2255, 7, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(2263, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(2265, 17, false);
#line 39 "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml"
                                           Write(option.ToString());

#line default
#line hidden
                EndContext();
                BeginContext(2282, 11, true);
                WriteLiteral("</option>\r\n");
                EndContext();
#line 40 "C:\Users\goshe\Documents\Personal\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Users\Invite.cshtml"
                    }
                

#line default
#line hidden
                BeginContext(2335, 118, true);
                WriteLiteral("            </select>\r\n        </div>\r\n        <button type=\"submit\" class=\"btn btn-primary\">Submit</button>\r\n        ");
                EndContext();
                BeginContext(2453, 58, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c473826f35974b8fa60d4f79d3d92510", async() => {
                    BeginContext(2501, 6, true);
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
                BeginContext(2511, 6, true);
                WriteLiteral("\r\n    ");
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
            BeginContext(2524, 8, true);
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Users.CreateViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
