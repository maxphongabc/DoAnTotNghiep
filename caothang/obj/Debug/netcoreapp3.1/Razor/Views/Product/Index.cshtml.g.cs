#pragma checksum "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\caothang\Views\Product\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ab5de5d80c20eb925a79b83f0599d9d09cb7e8b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Product_Index), @"mvc.1.0.view", @"/Views/Product/Index.cshtml")]
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
#line 1 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\caothang\Views\_ViewImports.cshtml"
using caothang;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\caothang\Views\_ViewImports.cshtml"
using caothang.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ab5de5d80c20eb925a79b83f0599d9d09cb7e8b", @"/Views/Product/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d8957414e84b2351450977edad7872330e34fd8b", @"/Views/_ViewImports.cshtml")]
    public class Views_Product_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Product.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ab5de5d80c20eb925a79b83f0599d9d09cb7e8b3562", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7ab5de5d80c20eb925a79b83f0599d9d09cb7e8b3824", async() => {
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
                WriteLiteral(@"

<!-- Header-->
<header class=""bg-dark py-5"">
    <div class=""container px-4 px-lg-5 my-5"">
        <div class=""text-center text-white"">
            <h1 class=""display-4 fw-bolder"">Shop in style</h1>
            <p class=""lead fw-normal text-white-50 mb-0"">With this shop hompeage template</p>
        </div>
    </div>
</header>
<!-- Section-->
<section class=""py-5"">
    <div class=""container px-4 px-lg-5 mt-5"">
        <div class=""row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center"">
            <div class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Fancy Produ");
                WriteLiteral(@"ct</h5>
                            <!-- Product price-->
                            $40.00 - $80.00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                        <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">View options</a></div>
                    </div>
                </div>
            </div>
            <div class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Sale badge-->
                    <div class=""badge bg-dark text-white position-absolute"" style=""top: 0.5rem; right: 0.5rem"">Sale</div>
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-body p-4"">
                        <div class=""text-ce");
                WriteLiteral(@"nter"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Special Item</h5>
                            <!-- Product reviews-->
                            <div class=""d-flex justify-content-center small text-warning mb-2"">
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                            </div>
                            <!-- Product price-->
                            <span class=""text-muted text-decoration-line-through"">$20.00</span>
                            $18.00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
        ");
                WriteLiteral(@"                <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">Add to cart</a></div>
                    </div>
                </div>
            </div>
            <div class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Sale badge-->
                    <div class=""badge bg-dark text-white position-absolute"" style=""top: 0.5rem; right: 0.5rem"">Sale</div>
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Sale Item</h5>
                            <!-- Product price-->
                            <span class=""text-muted text-decoration-line-through"">$50.00</span>
                            $25");
                WriteLiteral(@".00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                        <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">Add to cart</a></div>
                    </div>
                </div>
            </div>
            <div class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Popular Item</h5>
                            <!-- Product reviews-->
                            <div class=""d-flex justify-content-center small text-war");
                WriteLiteral(@"ning mb-2"">
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                            </div>
                            <!-- Product price-->
                            $40.00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                        <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">Add to cart</a></div>
                    </div>
                </div>
            </div>
            <div class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Sale badge-->
                    <div class=""badge bg-dark text-white p");
                WriteLiteral(@"osition-absolute"" style=""top: 0.5rem; right: 0.5rem"">Sale</div>
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Sale Item</h5>
                            <!-- Product price-->
                            <span class=""text-muted text-decoration-line-through"">$50.00</span>
                            $25.00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                        <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">Add to cart</a></div>
                    </div>
                </");
                WriteLiteral(@"div>
            </div>
            <div class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Fancy Product</h5>
                            <!-- Product price-->
                            $120.00 - $280.00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                        <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">View options</a></div>
                    </div>
                </div>
            </div>
            <div");
                WriteLiteral(@" class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Sale badge-->
                    <div class=""badge bg-dark text-white position-absolute"" style=""top: 0.5rem; right: 0.5rem"">Sale</div>
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-body p-4"">
                        <div class=""text-center"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Special Item</h5>
                            <!-- Product reviews-->
                            <div class=""d-flex justify-content-center small text-warning mb-2"">
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                             ");
                WriteLiteral(@"   <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                            </div>
                            <!-- Product price-->
                            <span class=""text-muted text-decoration-line-through"">$20.00</span>
                            $18.00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                        <div class=""text-center""><a class=""btn btn-outline-dark mt-auto"" href=""#"">Add to cart</a></div>
                    </div>
                </div>
            </div>
            <div class=""col mb-5"">
                <div class=""card h-100"">
                    <!-- Product image-->
                    <img class=""card-img-top"" src=""https://dummyimage.com/450x300/dee2e6/6c757d.jpg"" alt=""..."" />
                    <!-- Product details-->
                    <div class=""card-b");
                WriteLiteral(@"ody p-4"">
                        <div class=""text-center"">
                            <!-- Product name-->
                            <h5 class=""fw-bolder"">Popular Item</h5>
                            <!-- Product reviews-->
                            <div class=""d-flex justify-content-center small text-warning mb-2"">
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                                <div class=""bi-star-fill""></div>
                            </div>
                            <!-- Product price-->
                            $40.00
                        </div>
                    </div>
                    <!-- Product actions-->
                    <div class=""card-footer p-4 pt-0 border-top-0 bg-transparent"">
                        <div class=""text-center""><a");
                WriteLiteral(" class=\"btn btn-outline-dark mt-auto\" href=\"#\">Add to cart</a></div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
