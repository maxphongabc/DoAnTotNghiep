#pragma checksum "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\User\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dce67af8c708df951b891f2646b7eb3681a9b17c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Index), @"mvc.1.0.view", @"/Views/User/Index.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dce67af8c708df951b891f2646b7eb3681a9b17c", @"/Views/User/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35dcdc92d88171b520ad36517787e1ac2353faeb", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Common.ViewModel.UserViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("register-form outer-top-xs"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\User\Index.cshtml"
   
    ViewData["Title"] = "Tài khoản của tôi";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"sign-in-page\">\r\n    <div class=\"row\">\r\n        <!-- Sign-in -->\r\n        <div class=\"col-md-6 col-sm-6 sign-in\">\r\n            <h4");
            BeginWriteAttribute("class", " class=\"", 234, "\"", 242, 0);
            EndWriteAttribute();
            WriteLiteral(">Thông tin tài khoản</h4>\r\n            <p");
            BeginWriteAttribute("class", " class=\"", 284, "\"", 292, 0);
            EndWriteAttribute();
            WriteLiteral(">Thông tin cá nhân</p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dce67af8c708df951b891f2646b7eb3681a9b17c4848", async() => {
                WriteLiteral("\r\n            <div class=\"form-group\">\r\n                <label class=\"info-title\" for=\"exampleInputEmail1\">Họ và tên <span>*</span></label>\r\n                <input type=\"text\"");
                BeginWriteAttribute("value", " value=\"", 553, "\"", 576, 1);
#nullable restore
#line 14 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\User\Index.cshtml"
WriteAttributeValue("", 561, Model.FullName, 561, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control unicase-form-control text-input"" id=""exampleInputEmail1"">
            </div>
            <div class=""form-group"">
                <label class=""info-title"" for=""exampleInputEmail1"">Email <span>*</span></label>
                <div>");
#nullable restore
#line 18 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\User\Index.cshtml"
                Write(Model.Email);

#line default
#line hidden
#nullable disable
                WriteLiteral("</div>\r\n            </div>\r\n            <div class=\"form-group\">\r\n                <label class=\"info-title\" for=\"exampleInputEmail1\">Username <span>*</span></label>\r\n                <input type=\"email\"");
                BeginWriteAttribute("value", " value=\"", 1046, "\"", 1069, 1);
#nullable restore
#line 22 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\User\Index.cshtml"
WriteAttributeValue("", 1054, Model.UserName, 1054, 15, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control unicase-form-control text-input"" id=""exampleInputEmail1"">
            </div>
            <div class=""form-group"">
                <label class=""info-title"" for=""exampleInputPassword1"">SĐT <span>*</span></label>
                <input type=""number""");
                BeginWriteAttribute("value", " value=\"", 1342, "\"", 1362, 1);
#nullable restore
#line 26 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\User\Index.cshtml"
WriteAttributeValue("", 1350, Model.Phone, 1350, 12, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""form-control unicase-form-control text-input"" id=""exampleInputPassword1"">
            </div>
            <div class=""form-group"">
                <label class=""info-title"" for=""exampleInputPassword1"">Địa chỉ <span>*</span></label>
                <div type=""number""");
                BeginWriteAttribute("value", " value=\"", 1640, "\"", 1662, 1);
#nullable restore
#line 30 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\User\Index.cshtml"
WriteAttributeValue("", 1648, Model.Address, 1648, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"form-control unicase-form-control text-input\" id=\"exampleInputPassword1\"></div>\r\n            </div>\r\n");
                WriteLiteral("        ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n    </div><!-- /.row -->\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Common.ViewModel.UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591