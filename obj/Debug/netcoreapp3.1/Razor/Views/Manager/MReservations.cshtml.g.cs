#pragma checksum "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2a3776fb2023205e60f5f3f5cf5e1cb680d4c149"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Manager_MReservations), @"mvc.1.0.view", @"/Views/Manager/MReservations.cshtml")]
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
#line 1 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\_ViewImports.cshtml"
using BeanSceneDipAssT2;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\_ViewImports.cshtml"
using BeanSceneDipAssT2.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2a3776fb2023205e60f5f3f5cf5e1cb680d4c149", @"/Views/Manager/MReservations.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"495de94f15db57faec0d7d4a99a3e2b3068c270f", @"/Views/_ViewImports.cshtml")]
    public class Views_Manager_MReservations : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<BeanSceneDipAssT2.Models.BookingDetailModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Manager", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-d"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteReservation", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Detail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Booking", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
  
    ViewData["Title"] = "Manage List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<div class=\"TopRight\">\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a3776fb2023205e60f5f3f5cf5e1cb680d4c1496173", async() => {
                WriteLiteral("Go back");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</div>
<h1 style=""margin-top:40px;"">Reservation List</h1>

<div class=""ReservationTable"">
    <table class=""table col-"">
        <thead style=""border: 1px black solid; margin:2px; border-radius:15px; padding:5px; background-color: #961614; color:#fff"">
            <tr>
                <th>
                    ");
#nullable restore
#line 18 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
               Write(Html.DisplayNameFor(model => model.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    Customer\r\n                </th>\r\n                <th>\r\n                    Sitting\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 27 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
               Write(Html.DisplayNameFor(model => model.Date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 30 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
               Write(Html.DisplayNameFor(model => model.StartTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 33 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
               Write(Html.DisplayNameFor(model => model.EndTime));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 36 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
               Write(Html.DisplayNameFor(model => model.Area));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    No of Tables\r\n                </th>\r\n                <th>\r\n                    No of Guests\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 45 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
               Write(Html.DisplayNameFor(model => model.AdditionalRequirements));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 52 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr style=\"border: 1px black solid; margin:2px; border-radius:15px; padding:5px; background-color: #fff;\">\r\n                    <td>\r\n                        ");
#nullable restore
#line 56 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <div class=\"ditsName\">\r\n                            ");
#nullable restore
#line 60 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 64 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(Html.DisplayFor(modelItem => item.SittingName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 67 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(item.Date.ToString("dd-MM-yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 70 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(item.StartTime.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 73 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(item.EndTime.ToString("hh:mm tt"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 76 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Area));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 79 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumberOfTables));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 82 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumberOfGuests));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <div class=\"dits\">\r\n                            ");
#nullable restore
#line 86 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                       Write(Html.DisplayFor(modelItem => item.AdditionalRequirements));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </div>\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a3776fb2023205e60f5f3f5cf5e1cb680d4c14915658", async() => {
                WriteLiteral("DELETE");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 90 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                                                                                                       WriteLiteral(item.ReservationID);

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
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2a3776fb2023205e60f5f3f5cf5e1cb680d4c14918312", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 93 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
                                                                                      WriteLiteral(item.ReservationID);

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
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 96 "C:\Users\erick\Programming\My Projects\Reservation\Shared_C#Project\BeanSceneDipAssT2\BeanSceneDipAssT2\Views\Manager\MReservations.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<BeanSceneDipAssT2.Models.BookingDetailModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591