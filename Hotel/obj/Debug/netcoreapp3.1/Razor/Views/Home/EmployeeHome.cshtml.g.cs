#pragma checksum "D:\c#\ASP project\Hotel\Hotel\Views\Home\EmployeeHome.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b822374da23743935cb1a86856a73d55d65e1cb0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_EmployeeHome), @"mvc.1.0.view", @"/Views/Home/EmployeeHome.cshtml")]
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
#line 1 "D:\c#\ASP project\Hotel\Hotel\Views\_ViewImports.cshtml"
using Hotel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\c#\ASP project\Hotel\Hotel\Views\_ViewImports.cshtml"
using Hotel.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b822374da23743935cb1a86856a73d55d65e1cb0", @"/Views/Home/EmployeeHome.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"00630510a69c62db4e186dce360504dace6c5285", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_EmployeeHome : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "D:\c#\ASP project\Hotel\Hotel\Views\Home\EmployeeHome.cshtml"
  
    ViewData["Title"] = "EmployeeView";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <div class=\"mt-3 mb-5\">\r\n        <div class=\"container-fluid text-center\">\r\n            <h2>You are logged in as ");
#nullable restore
#line 8 "D:\c#\ASP project\Hotel\Hotel\Views\Home\EmployeeHome.cshtml"
                                Write(this.User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h2>\r\n        </div>\r\n    </div>\r\n\r\n");
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