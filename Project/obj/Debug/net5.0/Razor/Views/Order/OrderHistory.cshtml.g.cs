#pragma checksum "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9e13bd4882ae55b7bb924d00e9e98a17c361ca2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_OrderHistory), @"mvc.1.0.view", @"/Views/Order/OrderHistory.cshtml")]
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
#line 1 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9e13bd4882ae55b7bb924d00e9e98a17c361ca2", @"/Views/Order/OrderHistory.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35dcdc92d88171b520ad36517787e1ac2353faeb", @"/Views/_ViewImports.cshtml")]
    public class Views_Order_OrderHistory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Common.ViewModel.OrderViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "orderDetailsHistory", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
   
    ViewData["Title"] = "Đơn hàng của tôi";

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
 if(Model!=null)
{ 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""track-order-page"">
    <div class=""row"">
        <div class=""shopping-cart"">
            <div class=""shopping-cart-table "">
                <div class=""table-responsive"">
                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>Mã đơn hàng</th>
                                <th>Tổng tiền</th>
                                <th>Ngày mua</th>
                                <th>Trạng thái</th>
                            </tr>
                        </thead><!-- /thead -->
                        <tbody>
");
#nullable restore
#line 22 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                             foreach (var item in Model)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d9e13bd4882ae55b7bb924d00e9e98a17c361ca25306", async() => {
#nullable restore
#line 25 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                                                                                                                       Write(item.OrderId);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                                                                                                 WriteLiteral(item.OrderId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 26 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                               Write(item.Total.ToString("N0"));

#line default
#line hidden
#nullable disable
            WriteLiteral(" VNĐ</td>\r\n                                <td>");
#nullable restore
#line 27 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                               Write(item.CreatedOn);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 28 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                                 if (item.StatusOrder == true)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>Đã duyệt</td>\r\n");
#nullable restore
#line 31 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                                 if (item.StatusOrder == false)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <td>Chưa duyệt</td>\r\n");
#nullable restore
#line 35 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tr>\r\n");
#nullable restore
#line 37 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
                            }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </tbody><!-- /tbody -->\r\n                    </table><!-- /table -->\r\n                </div>\r\n            </div><!-- /.shopping-cart-table -->\t\t\t\t\r\n        </div>\r\n    </div><!-- /.row -->\r\n</div>\r\n");
#nullable restore
#line 45 "C:\Users\DELL\Source\Repos\DoAnTotNghiep\Project\Views\Order\OrderHistory.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Common.ViewModel.OrderViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
