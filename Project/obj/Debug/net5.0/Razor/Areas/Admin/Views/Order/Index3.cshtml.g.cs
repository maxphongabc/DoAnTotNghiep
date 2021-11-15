#pragma checksum "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "be627e7342881cd30375aa86ab0cd8edbb9909ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Order_Index3), @"mvc.1.0.view", @"/Areas/Admin/Views/Order/Index3.cshtml")]
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
#line 1 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"be627e7342881cd30375aa86ab0cd8edbb9909ca", @"/Areas/Admin/Views/Order/Index3.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"767cfb4f5c2a7481e8aa3be540d3fcfefe74cb13", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Order_Index3 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<Common.ViewModel.OrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Admin/img/list.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
  
    ViewData["Title"] = "Đơn hàng";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Danh sách đơn hàng thành công</h1>


<table class=""table table-bordered"" width=""100%"">
    <thead>
        <tr>
            <th>
                Người nhận hàng
            </th>
            <th>
                Tổng tiền
            </th>
            <th>
                Hình thức nhận hàng
            </th>
            <th>
                SĐT
            </th>
            <th>
                Email
            </th>
            <th>
                Địa chỉ
            </th>
            <th>
                Ngày tạo
            </th>
            <th>
                Trạng thái
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 42 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 46 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
               Write(item.UserName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
               Write(item.Total.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
               Write(item.ShipName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
               Write(item.ShipPhone);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
               Write(item.ShipEmail);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
               Write(item.ShipAdress);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 65 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
               Write(item.CreatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>          \r\n                    <br />\r\n                    <a style=\"cursor:pointer\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1616, "\"", 1720, 3);
            WriteAttributeValue("", 1626, "showModallarge(\'", 1626, 16, true);
#nullable restore
#line 70 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
WriteAttributeValue("", 1642, Url.Action("Details","Order",new { id=item.OrderId},Context.Request.Scheme), 1642, 76, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1718, "\')", 1718, 2, true);
            EndWriteAttribute();
            WriteLiteral(">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "be627e7342881cd30375aa86ab0cd8edbb9909ca8029", async() => {
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
            WriteLiteral("</a>\r\n                    <br />\r\n                </td>\r\n                <td>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 76 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<div class=\"d-flex w-100 justify-content-center\">\r\n    ");
#nullable restore
#line 80 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
Write(Html.PagedListPager((IPagedList)Model, page => Url.Action("Index", "Order", new { page, size = ViewBag.currentSize, Search = ViewBag.searchValue })));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 83 "C:\Users\DELL\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Order\Index3.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<Common.ViewModel.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
