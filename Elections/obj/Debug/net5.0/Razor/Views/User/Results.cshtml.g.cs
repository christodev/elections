#pragma checksum "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "51a00deebda003d015915c1f31417d38e099ad85"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_User_Results), @"mvc.1.0.view", @"/Views/User/Results.cshtml")]
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
#line 1 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\_ViewImports.cshtml"
using Elections;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\_ViewImports.cshtml"
using Elections.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"51a00deebda003d015915c1f31417d38e099ad85", @"/Views/User/Results.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6d6f3308f489fde6930c2762691a5e74bfda7861", @"/Views/_ViewImports.cshtml")]
    public class Views_User_Results : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<ElectoralList>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("card-img h-100"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral(@"
<style>

    .sub-container {
        /*border: 4px solid black;*/
    }

    .cards-container {
        /*border: 2px solid red;*/
        row-gap: 1rem;
        height: 30%;
    }

    .card {
        /*border: 2px solid green;*/
        /*height: 100%;
        width: 100%;*/
    }

    .card-image-container {
       /* border: 2px solid blue;*/
        height: auto;
        width: 40%;
    }

    .card-img { /*OK LAL IMAGE*/ 
/*        height: 100%;
        width: 100%;*/
    }

    .card-title {
        font-weight: bold;
    }

    img {
        height: 50%;
        width: 50%;
    }
</style>

");
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"d-flex flex-column sub-container\"> ");
            WriteLiteral("\r\n");
#nullable restore
#line 48 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
         foreach(var list in Model) 
        { 
            

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"d-flex\">\r\n                <h4 class=\"flex-shrink-1\" style=\"margin-left:10px;\">");
#nullable restore
#line 52 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                                                               Write(list.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"cards-container\"> ");
            WriteLiteral("\r\n");
#nullable restore
#line 55 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                         foreach (var cand in list.Candidates)
                        {
                            //Here starts the card (We have to divide it into 2 parts)

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <div class=\"card flex-row\"> ");
            WriteLiteral("\r\n                                <div class=\"card-header card-image-container w-20\"> ");
            WriteLiteral("\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "51a00deebda003d015915c1f31417d38e099ad855772", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1571, "~/images/", 1571, 9, true);
#nullable restore
#line 60 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
AddHtmlAttributeValue("", 1580, cand.ImageURL, 1580, 14, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n\r\n");
            WriteLiteral("                            <div class=\"card-body w-40\">\r\n");
#nullable restore
#line 65 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                                 if (cand.Status == Status.Winner)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <h5 class=\"card-title\">");
#nullable restore
#line 67 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                                                      Write(cand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" (Winner)</h5>\r\n");
#nullable restore
#line 68 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                                }
                                else
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <h5 class=\"card-title\">");
#nullable restore
#line 71 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                                                      Write(cand.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n");
#nullable restore
#line 72 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                <p class=""card-text"">Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate Short description of the candidate</p>
                            </div>

");
            WriteLiteral("                                <div class=\"card-footer d-flex align-self-end  bg-white border-left\">\r\n                                    <b>Votes:</b> ");
#nullable restore
#line 79 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                                             Write(cand.NbOfVotes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 82 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n");
#nullable restore
#line 84 "C:\Users\toshiba\Desktop\Uni\OnlineCourses\DesignPatterns\Elections\Elections\Views\User\Results.cshtml"
                      
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<ElectoralList>> Html { get; private set; }
    }
}
#pragma warning restore 1591
