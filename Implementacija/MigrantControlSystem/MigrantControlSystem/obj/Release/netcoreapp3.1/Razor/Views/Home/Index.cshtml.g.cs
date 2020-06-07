#pragma checksum "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "234c5976ab7759acf6374372f68e4574513a522e"
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
#line 1 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\_ViewImports.cshtml"
using MigrantControlSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\_ViewImports.cshtml"
using MigrantControlSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"234c5976ab7759acf6374372f68e4574513a522e", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"02a0aa9d2d4b8296e0fd43a018becec438dda64c", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PSViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onload", new global::Microsoft.AspNetCore.Html.HtmlString("loadMapScenario()"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
  
    ViewBag.Title = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script type='text/javascript' src='https://www.bing.com/api/maps/mapcontrol?callback=GetMap&key=ArWAROPsES9KoFwx6xcSfB4rACDXoFydfo4I4OEW5VtObukHm6Ci0mzceFpe2jNp' async defer></script>
<script type='text/javascript'>

                function loadMapScenario() {
                    var map = new Microsoft.Maps.Map(document.getElementById('myMap'), {
                        mapTypeId: Microsoft.Maps.MapTypeId.road,
                        zoom: 5
                    });
                    map.setView({
                        mapTypeId: Microsoft.Maps.MapTypeId.aerial,
                        center: new Microsoft.Maps.Location(44.006336, 17.624791),
                        zoom: 7
                    });

                    map.setOptions({
                        minZoom: 7
                    });
                    // Create the infobox for the pushpin
                    var infobox = null;

                    //declare addMarker function
                    function addMarker(lati");
            WriteLiteral(@"tude, longitude, title, description, pid, ) {
                        if (description == 'PolicijskaStanica') {
                            var marker = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(latitude, longitude), { color: 'green' });
                        } else if (description == 'OtvoreniTip') {
                            var marker = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(latitude, longitude), { color: 'red' });
                        } else {
                            var marker = new Microsoft.Maps.Pushpin(new Microsoft.Maps.Location(latitude, longitude), { color: 'blue' });
                        }

                        infobox = new Microsoft.Maps.Infobox(marker.getLocation(), {
                            visible: false
                        });

                        marker.metadata = {
                            id: pid,
                            title: title,
                            description: description
                     ");
            WriteLiteral(@"   };

                        Microsoft.Maps.Events.addHandler(marker, 'mouseout', hideInfobox);
                        Microsoft.Maps.Events.addHandler(marker, 'mouseover', showInfobox);

                        infobox.setMap(map);
                        map.entities.push(marker);
                        marker.setOptions({ enableHoverStyle: true });
                    };

                    function showInfobox(e) {
                        if (e.target.metadata) {
                            infobox.setOptions({
                                location: e.target.getLocation(),
                                title: e.target.metadata.title,
                                description: e.target.metadata.description,
                                visible: true
                            });
                        }
                    }

                    function hideInfobox(e) {
                        infobox.setOptions({ visible: false });
                    }

       ");
            WriteLiteral("     //add markers to map\r\n");
#nullable restore
#line 69 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
             if (Model.stanice != null)
            {
                foreach (var item in Model.stanice)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            WriteLiteral("addMarker(");
#nullable restore
#line 73 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                           Write(item.lokacija.x);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 73 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                             Write(item.lokacija.y);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \'");
#nullable restore
#line 73 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                                                Write(item.naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'PolicijskaStanica\', ");
#nullable restore
#line 73 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                                                                                   Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n");
#nullable restore
#line 74 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 76 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
             if (Model.otvoreni != null)
            {
                foreach (var item in Model.otvoreni)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            WriteLiteral("addMarker(");
#nullable restore
#line 81 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                           Write(item.lokacija.x);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 81 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                             Write(item.lokacija.y);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \'");
#nullable restore
#line 81 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                                                Write(item.naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'OtvoreniTip\', ");
#nullable restore
#line 81 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                                                                             Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n");
#nullable restore
#line 82 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 84 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
              if (Model.zatvoreni!= null)
            {
                foreach (var item in Model.zatvoreni)
                {


#line default
#line hidden
#nullable disable
            WriteLiteral("                    ");
            WriteLiteral("addMarker(");
#nullable restore
#line 89 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                           Write(item.lokacija.x);

#line default
#line hidden
#nullable disable
            WriteLiteral(", ");
#nullable restore
#line 89 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                             Write(item.lokacija.y);

#line default
#line hidden
#nullable disable
            WriteLiteral(", \'");
#nullable restore
#line 89 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                                                Write(item.naziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("\', \'ZatvoreniTip\', ");
#nullable restore
#line 89 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                                                                                              Write(item.id);

#line default
#line hidden
#nullable disable
            WriteLiteral(");\r\n");
#nullable restore
#line 90 "C:\Users\acer\Source\Repos\Grupa3-Briferi2\Implementacija\MigrantControlSystem\MigrantControlSystem\Views\Home\Index.cshtml"
                }
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        }\r\n</script>\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "234c5976ab7759acf6374372f68e4574513a522e12984", async() => {
                WriteLiteral("\r\n    <div id=\"myMap\" style=\"position:relative;width:600px;height:400px;\"></div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PSViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
