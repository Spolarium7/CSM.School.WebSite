#pragma checksum "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "175527a7aff9b8f935740f45d18f9e1a92a1c0a2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Manage_Views_Groups_Index), @"mvc.1.0.view", @"/Areas/Manage/Views/Groups/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Areas/Manage/Views/Groups/Index.cshtml", typeof(AspNetCore.Areas_Manage_Views_Groups_Index))]
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
#line 1 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
using CSM.Bataan.School.WebSite.Infrastructure.Data.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"175527a7aff9b8f935740f45d18f9e1a92a1c0a2", @"/Areas/Manage/Views/Groups/Index.cshtml")]
    public class Areas_Manage_Views_Groups_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Groups.IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/manage/groups/create"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-lg btn-info btn-block"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Update Group"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Group Members"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("page-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(142, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
  
    Layout = "~/Areas/Manage/Views/Shared/_managelayout.cshtml";

#line default
#line hidden
            BeginContext(217, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("tableHead", async() => {
                BeginContext(240, 262, true);
                WriteLiteral(@"
    <div class=""row"">
        <div class=""col-lg-9"">
            <div class=""input-group mb-3"">
                <input type=""text"" id=""searchKeyword"" placeholder=""search groups"" class=""form-control"" aria-label=""search groups"" aria-describedby=""basic-addon2""");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 502, "\"", 531, 1);
#line 13 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
WriteAttributeValue("", 510, Model.Groups.Keyword, 510, 21, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(532, 406, true);
                WriteLiteral(@">
                <div class=""input-group-append"">
                    <span class=""input-group-text"" id=""basic-addon2""><a href=""#"" onclick=""searchTrigger()""><i class=""fa fa-search fa-lg fa-fw"" aria-hidden=""true""></i></a></span>
                </div>
            </div>
        </div>
        <div class=""col-lg-3"">
            <div class=""table-responsive table--no-card m-b-30"">
                ");
                EndContext();
                BeginContext(938, 194, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f99f9f65e9e748e2931750104afc88f9", async() => {
                    BeginContext(1009, 119, true);
                    WriteLiteral("\r\n                    <i class=\"fa fa-plus\"></i>&nbsp;\r\n                    <span>Create Group</span>\r\n                ");
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
                BeginContext(1132, 50, true);
                WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(1185, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 30 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
 if (Model.Groups.Items.Count > 0)
{

#line default
#line hidden
            BeginContext(1226, 187, true);
            WriteLiteral("<table class=\"table table-borderless table-striped table-earning\">\r\n    <thead>\r\n        <tr>\r\n            <th>Name</th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 40 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
          
            foreach (Group group in Model.Groups.Items)
            {

#line default
#line hidden
            BeginContext(1497, 38, true);
            WriteLiteral("            <tr>\r\n                <td>");
            EndContext();
            BeginContext(1536, 10, false);
#line 44 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
               Write(group.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1546, 49, true);
            WriteLiteral("</td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1595, 144, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "60fec6c2820046cab3e4894b4f681816", async() => {
                BeginContext(1659, 76, true);
                WriteLiteral("<button type=\"button\" class=\"btn\"><i class=\"fas fa-pen-square\"></i></button>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1604, "~/manage/groups/update/", 1604, 23, true);
#line 46 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 1627, group.Id, 1627, 9, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1739, 22, true);
            WriteLiteral("\r\n                    ");
            EndContext();
            BeginContext(1761, 138, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "965228a96f8b46b8a493d163404c545f", async() => {
                BeginContext(1824, 71, true);
                WriteLiteral("<button type=\"button\" class=\"btn\"><i class=\"fas fa-users\"></i></button>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1770, "~/manage/group-users/", 1770, 21, true);
#line 47 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 1791, group.Id, 1791, 9, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1899, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 50 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
            }
        

#line default
#line hidden
            BeginContext(1969, 361, true);
            WriteLiteral(@"    </tbody>
    <tfoot>
        <tr>
            <td colspan=""4"">
                <nav aria-label=""Page navigation example"">
                    <ul class=""pagination"">
                        <li class=""page-item""><span class=""form-control-plaintext"">Page&nbsp;&nbsp;&nbsp;</span></li>
                        <li class=""page-item""><input type=""number""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 2330, "\"", 2361, 1);
#line 59 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
WriteAttributeValue("", 2338, Model.Groups.PageIndex, 2338, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2362, 41, true);
            WriteLiteral(" class=\"form-control\" style=\"width:50px;\"");
            EndContext();
            BeginWriteAttribute("onKeydown", " onKeydown=\"", 2403, "\"", 2642, 16);
            WriteAttributeValue("", 2415, "javascript:", 2415, 11, true);
            WriteAttributeValue(" ", 2426, "if(event.keyCode", 2427, 17, true);
            WriteAttributeValue(" ", 2443, "==", 2444, 3, true);
            WriteAttributeValue(" ", 2446, "13", 2447, 3, true);
            WriteAttributeValue(" ", 2449, "&&", 2450, 3, true);
            WriteAttributeValue(" ", 2452, "isNaN(parseInt($(this).val()))==false)", 2453, 39, true);
            WriteAttributeValue(" ", 2491, "window.location=\'/manage/groups/index?pageIndex=\'", 2492, 50, true);
            WriteAttributeValue(" ", 2541, "+", 2542, 2, true);
            WriteAttributeValue(" ", 2543, "(isNaN(parseInt($(this).val()))", 2544, 32, true);
            WriteAttributeValue(" ", 2575, "?", 2576, 2, true);
            WriteAttributeValue(" ", 2577, "1", 2578, 2, true);
            WriteAttributeValue(" ", 2579, ":", 2580, 2, true);
            WriteAttributeValue(" ", 2581, "parseInt($(this).val()))", 2582, 25, true);
            WriteAttributeValue(" ", 2606, "+", 2607, 2, true);
            WriteAttributeValue(" ", 2608, "\'&keyword=", 2609, 11, true);
#line 59 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
WriteAttributeValue("", 2619, Model.Groups.Keyword, 2619, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2643, 114, true);
            WriteLiteral(" /></li>\r\n                        <li class=\"page-item\"><span class=\"form-control-plaintext\">&nbsp;&nbsp;&nbsp;of ");
            EndContext();
            BeginContext(2758, 22, false);
#line 60 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
                                                                                                   Write(Model.Groups.PageCount);

#line default
#line hidden
            EndContext();
            BeginContext(2780, 32, true);
            WriteLiteral("&nbsp;&nbsp;&nbsp;</span></li>\r\n");
            EndContext();
#line 61 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
                          
                            var prev = Model.Groups.PageIndex - 1;
                            if (prev > 0)
                            {

#line default
#line hidden
            BeginContext(2982, 54, true);
            WriteLiteral("                                <li class=\"page-item\">");
            EndContext();
            BeginContext(3036, 165, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4647b36d48974fd8be8432b3838d4e03", async() => {
                BeginContext(3158, 39, true);
                WriteLiteral("<span aria-hidden=\"true\">&laquo;</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 6, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3063, "~/manage/groups?keyword=", 3063, 24, true);
#line 65 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 3087, Model.Groups.Keyword, 3087, 21, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 3108, "&pageSize=", 3108, 10, true);
#line 65 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 3118, Model.Groups.PageSize, 3118, 22, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 3140, "&pageIndex=", 3140, 11, true);
#line 65 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 3151, prev, 3151, 5, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3201, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 66 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(3266, 76, true);
            WriteLiteral("                        <li class=\"page-item\"><a class=\"page-link\" href=\"#\">");
            EndContext();
            BeginContext(3344, 22, false);
#line 68 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
                                                                        Write(Model.Groups.PageIndex);

#line default
#line hidden
            EndContext();
            BeginContext(3367, 11, true);
            WriteLiteral("</a></li>\r\n");
            EndContext();
#line 69 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
                          
                            var next = Model.Groups.PageIndex + 1;
                            if (next <= Model.Groups.PageCount)
                            {

#line default
#line hidden
            BeginContext(3570, 54, true);
            WriteLiteral("                                <li class=\"page-item\">");
            EndContext();
            BeginContext(3624, 165, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0dc5a1d57a1045d1a71497faac37e151", async() => {
                BeginContext(3746, 39, true);
                WriteLiteral("<span aria-hidden=\"true\">&raquo;</span>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 6, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3651, "~/manage/groups?keyword=", 3651, 24, true);
#line 73 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 3675, Model.Groups.Keyword, 3675, 21, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 3696, "&pageSize=", 3696, 10, true);
#line 73 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 3706, Model.Groups.PageSize, 3706, 22, false);

#line default
#line hidden
            AddHtmlAttributeValue("", 3728, "&pageIndex=", 3728, 11, true);
#line 73 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
AddHtmlAttributeValue("", 3739, next, 3739, 5, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3789, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 74 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
                            }
                        

#line default
#line hidden
            BeginContext(3854, 109, true);
            WriteLiteral("                    </ul>\r\n                </nav>\r\n            </td>\r\n        </tr>\r\n    </tfoot>\r\n</table>\r\n");
            EndContext();
#line 82 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
}
else {

#line default
#line hidden
            BeginContext(3974, 26, true);
            WriteLiteral("<p>0 search results.</p>\r\n");
            EndContext();
#line 85 "C:\Users\Shayne Maravillo\Desktop\Github\CSM.School.WebSite\CSM.Bataan.School.WebSite\CSM.Bataan.School.WebSite\Areas\Manage\Views\Groups\Index.cshtml"
}

#line default
#line hidden
            BeginContext(4003, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("extras", async() => {
                BeginContext(4021, 1030, true);
                WriteLiteral(@"
    <div class=""modal"" tabindex=""-1"" role=""dialog"" id=""modal-delete-group"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Delete Group</h5>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <p>Are you sure you want to delete <span id=""modal-delete-group-groupname""></span>?</p>
                </div>
                <div class=""modal-footer"">
                    <a href=""#"" id=""modal-delete-group-confirm""><button type=""button"" class=""btn btn-primary"">Delete Group</button></a>
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                </div>
            </div>
        </div>
    </");
                WriteLiteral("div>\r\n");
                EndContext();
            }
            );
            BeginContext(5054, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("pageScripts", async() => {
                BeginContext(5077, 644, true);
                WriteLiteral(@"
    <script type=""text/javascript"">
        function confirmDeleteGroup(groupId, groupName) {
            $(""#modal-delete-group-groupname"").html(groupName);
            $(""#modal-delete-group-confirm"").attr(""href"", ""/manage/groups/delete/"" + groupId);
            $(""#modal-delete-group"").modal(""show"");
        }

        $(""#searchKeyword"").keyup(function (event) {
            if (event.keyCode === 13) {
                searchTrigger();
            }
        });

        function searchTrigger() {
            window.location = ""/manage/groups?pageIndex=1&keyword="" + $(""#searchKeyword"").val();
        }
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CSM.Bataan.School.WebSite.Areas.Manage.ViewModels.Groups.IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
