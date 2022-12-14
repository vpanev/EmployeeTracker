#pragma checksum "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24fea64b33e2264da6612eebe1a09a18fc33594b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\_ViewImports.cshtml"
using EmployeeTrackerApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\_ViewImports.cshtml"
using EmployeeTrackerApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"24fea64b33e2264da6612eebe1a09a18fc33594b", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"539b0d17ab72e953c0ce175b3eedab6f31623ecc", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<X.PagedList.IPagedList<Exam.Models.Employee>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    string todayDate = DateTime.Now.ToString("yyyy-MM-dd");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div style=\"margin-bottom:20px\">\r\n");
#nullable restore
#line 11 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
     using (Html.BeginForm("Subscribe", "Home"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <input id=\"datepicker\" name=\"date\" type=\"date\"");
            BeginWriteAttribute("value", " value=\"", 368, "\"", 386, 1);
#nullable restore
#line 13 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
WriteAttributeValue("", 376, todayDate, 376, 10, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" />\r\n        <input type=\"submit\" value=\"Subscribe\" class=\"btn btn-primary\" />\r\n");
#nullable restore
#line 15 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<div class=\"search-filter\">\r\n");
#nullable restore
#line 19 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
     using (Html.BeginForm("Index", "Home"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>\r\n            Find by ID: ");
#nullable restore
#line 22 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
                   Write(Html.TextBox("SearchString", ViewData["CurrentFilter"] as string));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <input type=\"submit\" value=\"Search\"/>\r\n        </p>\r\n");
#nullable restore
#line 25 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<table class=\"table table-hover table-bordered\">\r\n    <tr>\r\n        <th>\r\n            ");
#nullable restore
#line 31 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
       Write(Html.ActionLink(
            "Employee Id",
            "Index",
            new
            {
            sortOrder = ViewData["NameSortParam"],
            currentFilter = ViewData["CurrentFilter"]
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 41 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
       Write(Html.ActionLink(
            "Arrival",
            "Index",
            new
            {
            sortOrder = ViewData["DateSortParam"],
            currentFilter = ViewData["CurrentFilter"]
            }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n");
#nullable restore
#line 51 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
     foreach (var e in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 54 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
           Write(e.EmployeeId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 55 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
           Write(e.When.ToString("dd-MM-yyyy HH:mm"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 57 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<div class=\"pagination\">\r\n    Page ");
#nullable restore
#line 61 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
     Write(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" of ");
#nullable restore
#line 61 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
                                                                    Write(Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    ");
#nullable restore
#line 63 "D:\IT WORK\Projects\EmployeeTrackerApp\Views\Home\Index.cshtml"
Write(Html.PagedListPager(
        Model,
        page => Url.Action(
            "Index",
            new
            {
                page,
                sortOrder = ViewData["CurrentSort"],
                currentFilter = ViewData["CurrentFilter"]
            }),
        new PagedListRenderOptions()
        {
            LiElementClasses = new string[] { "page-item" },
            PageClasses = new string[] { "page-link" },
            Display = PagedListDisplayMode.IfNeeded
        }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<X.PagedList.IPagedList<Exam.Models.Employee>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
