#pragma checksum "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\Section\DetailsOfSection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "945f5036a1358901dc5eccd46c1575c6630427b0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Section_DetailsOfSection), @"mvc.1.0.view", @"/Views/Section/DetailsOfSection.cshtml")]
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
#line 1 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\_ViewImports.cshtml"
using BcuV0._3;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\_ViewImports.cshtml"
using BcuV0._3.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"945f5036a1358901dc5eccd46c1575c6630427b0", @"/Views/Section/DetailsOfSection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f64e77787b177d873c355debfa454f04043c9cf3", @"/Views/_ViewImports.cshtml")]
    public class Views_Section_DetailsOfSection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BcuV0._3.ViewModels.SectionWithPosts>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<div class=\"container justify-content-center\">\r\n    <div class=\"text-capitalize text-center\">\r\n        ");
#nullable restore
#line 5 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\Section\DetailsOfSection.cshtml"
   Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"card container\">\r\n        <div class=\"container d-flex flex-column\">\r\n");
#nullable restore
#line 9 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\Section\DetailsOfSection.cshtml"
             foreach(var post in Model.Posts)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"card\">\r\n                    <h3>\r\n                        ");
#nullable restore
#line 13 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\Section\DetailsOfSection.cshtml"
                   Write(post.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(" -- ");
#nullable restore
#line 13 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\Section\DetailsOfSection.cshtml"
                                  Write(post.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h3>\r\n                    <h2>\r\n                        ");
#nullable restore
#line 16 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\Section\DetailsOfSection.cshtml"
                   Write(post.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h2>\r\n                </div>\r\n");
#nullable restore
#line 19 "D:\miscVisStudProjects\BcuV0.3\BcuV0.3\Views\Section\DetailsOfSection.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BcuV0._3.ViewModels.SectionWithPosts> Html { get; private set; }
    }
}
#pragma warning restore 1591
