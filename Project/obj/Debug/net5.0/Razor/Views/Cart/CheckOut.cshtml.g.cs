#pragma checksum "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "430fed29c12e3354d24c57a39f78207dc6f5302f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Cart_CheckOut), @"mvc.1.0.view", @"/Views/Cart/CheckOut.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"430fed29c12e3354d24c57a39f78207dc6f5302f", @"/Views/Cart/CheckOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35dcdc92d88171b520ad36517787e1ac2353faeb", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_CheckOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Project.Models.Cart>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route", "removecart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h2>GIỎ HÀNG</h2>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
 if (Model.Count > 0)
{
    decimal total = 0;
    int stt = 1;
    decimal thanhtien = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <tr>\r\n            <th>#</th>\r\n            <th>Sản phẩm</th>\r\n            <th>Giá</th>\r\n            <th>Số lượng</th>\r\n            <th>Thành tiền</th>\r\n            <th></th>\r\n        </tr>\r\n");
#nullable restore
#line 19 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
         foreach (var cartitem in Model)
        {
            thanhtien = cartitem.Quanlity * cartitem.Product.Price;
            total += thanhtien;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 24 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                Write(stt++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 25 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
               Write(cartitem.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 26 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                Write(cartitem.Product.Price.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "430fed29c12e3354d24c57a39f78207dc6f5302f5821", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 27 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => cartitem.Quanlity);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "id", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 27 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
AddHtmlAttributeValue("", 761, $"quantity-{cartitem.Product.Id}", 761, 36, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 28 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                Write(thanhtien.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>\r\n                    <button class=\"btn btn-success updatecartitem\"\r\n                            data-productid=\"");
#nullable restore
#line 31 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                                       Write(cartitem.Product.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\">\r\n                        Cập nhật\r\n                    </button>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "430fed29c12e3354d24c57a39f78207dc6f5302f8508", async() => {
                WriteLiteral("Xóa");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Route = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-productid", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 34 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                                                       WriteLiteral(cartitem.Product.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productid"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-productid", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["productid"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 38 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td colspan=\"4\" class=\"text-right\">Tổng tiền</td>\r\n            <td>");
#nullable restore
#line 41 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
            Write(total.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n");
#nullable restore
#line 45 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"section group\">\r\n    <div class=\"col-md-6\">\r\n");
#nullable restore
#line 48 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
         using (Html.BeginForm("CheckOut", "Cart", FormMethod.Post))
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div class=""form-group"">
                <label>Người nhận hàng</label>
                <input name=""shipName"" class=""form-control"" />
            </div>
            <div class=""form-group"">
                <label>Điện thoại</label>
                <input name=""phone"" class=""form-control"" />
            </div>
            <div class=""form-group"">
                <label>Địa chỉ nhận hàng</label>
                <input name=""shipAdress"" class=""form-control"" />
            </div>
            <div class=""form-group"">
                <label>Email</label>
                <input name=""email"" class=""form-control"" />
            </div>          
            <button class=""btn btn-success"" type=""submit"" class=""btn"">Gửi đơn hàng</button>
");
#nullable restore
#line 67 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Project.Models.Cart>> Html { get; private set; }
    }
}
#pragma warning restore 1591