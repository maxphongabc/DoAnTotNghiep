#pragma checksum "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Shared\MessagesPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "458fe4acb2f424ab89e0566261cbf3c39a2f91de"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared_MessagesPartial), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/MessagesPartial.cshtml")]
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
#line 1 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"458fe4acb2f424ab89e0566261cbf3c39a2f91de", @"/Areas/Admin/Views/Shared/MessagesPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f8717d28d88a465d7809b60e4f2e9b0df94808f9", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Shared_MessagesPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Shared\MessagesPartial.cshtml"
 if (TempData["AlertMessage"] != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"AlertBox\"");
            BeginWriteAttribute("class", " class=\"", 82, "\"", 123, 3);
            WriteAttributeValue("", 90, "alert", 90, 5, true);
#nullable restore
#line 5 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Shared\MessagesPartial.cshtml"
WriteAttributeValue(" ", 95, TempData["AlertType"], 96, 22, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 118, "hide", 119, 5, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n        ");
#nullable restore
#line 6 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Shared\MessagesPartial.cshtml"
   Write(TempData["AlertMessage"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n");
#nullable restore
#line 8 "C:\Users\Thanh Duy\source\repos\DoAnTotNghiep\Project\Areas\Admin\Views\Shared\MessagesPartial.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591