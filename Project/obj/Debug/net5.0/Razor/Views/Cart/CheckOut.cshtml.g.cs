#pragma checksum "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "833f5d2fd0707f9297d314883136a276efca08a7"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"833f5d2fd0707f9297d314883136a276efca08a7", @"/Views/Cart/CheckOut.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"35dcdc92d88171b520ad36517787e1ac2353faeb", @"/Views/_ViewImports.cshtml")]
    public class Views_Cart_CheckOut : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CartViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n<h2>GIỎ HÀNG</h2>\r\n\r\n");
#nullable restore
#line 5 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
 if (Model.CartItems.Count > 0)
{
    int stt = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"table\">\r\n        <tr>\r\n            <th>#</th>\r\n            <th>Sản phẩm</th>\r\n            <th>Giá</th>\r\n            <th>Số lượng</th>\r\n            <th>Tổng cộng</th>\r\n            <th></th>\r\n        </tr>\r\n");
#nullable restore
#line 17 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
         foreach (var cartitem in Model.CartItems)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 20 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                Write(stt++);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "833f5d2fd0707f9297d314883136a276efca08a74712", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 490, "~/img/sanpham/", 490, 14, true);
#nullable restore
#line 21 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
AddHtmlAttributeValue("", 504, cartitem.Image, 504, 15, false);

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
#line 22 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
               Write(cartitem.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 23 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                Write(cartitem.Price.ToString("n0"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td colspan=\"4\" class=\"text-right\">Tổng tiền:  ");
#nullable restore
#line 24 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                                                          Write(cartitem.Total);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 26 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td colspan=\"4\" class=\"text-right\">Tổng tiền</td>\r\n            <td colspan=\"4\" class=\"text-right\">Tổng tiền:  ");
#nullable restore
#line 29 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
                                                      Write(Model.GrandTotal.ToString("C2"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td></td>\r\n        </tr>\r\n    </table>\r\n");
#nullable restore
#line 33 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"section group\">\r\n    <div class=\"col-md-6\">\r\n");
#nullable restore
#line 36 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
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
            <button class=""btn btn-success"" type=""submit"">Gửi đơn hàng</button>
");
#nullable restore
#line 55 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Views\Cart\CheckOut.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"

    <script>
    $(function () {

        $(""a.checkout"").click(function (e) {
            e.preventDefault();

            $(""div.cartbg"").removeClass(""d-none"");

            $.get(""/cart/clear"", {}, function () {              
            });

        });

    });
    </script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CartViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
