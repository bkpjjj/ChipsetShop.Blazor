#pragma checksum "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "67bd98f6a6eb630cbf02ce2650eb7376ac778444"
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
#line 1 "D:\repos\diplom\ChipsetShop.MVC\Views\_ViewImports.cshtml"
using ChipsetShop.MVC;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\repos\diplom\ChipsetShop.MVC\Views\_ViewImports.cshtml"
using ChipsetShop.MVC.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\repos\diplom\ChipsetShop.MVC\Views\_ViewImports.cshtml"
using ChipsetShop.MVC.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\repos\diplom\ChipsetShop.MVC\Views\_ViewImports.cshtml"
using ChipsetShop.MVC.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"67bd98f6a6eb630cbf02ce2650eb7376ac778444", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5d5b890ec39ff07fc8681ce23e843f3a70cab94", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
  
    string GetPrise(ProductModel product)
    {
        if (!product.InStock)
            return "Нет в наличии";
        else if (product.Discount is not null)
        {
            return (product.Prise - product.Prise * ((int)product.Discount / 100m)).ToString("#.## руб\\.");

        }
        else
        {
            return product.Prise.ToString("#.## руб\\.");
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""section"">
    <!-- container -->
    <div class=""container"">
        <!-- row -->
        <div class=""row"">

            <div class=""col-md-12"">
                <div class=""section-title text-center"">
                    <h3 class=""title"">Категории</h3>
                </div>
            </div>

            <div class=""row row-cols-1 row-cols-lg-4 row-cols-md-2"">
");
#nullable restore
#line 35 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                 foreach (CategoryModel category in Model.Categories)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <!-- product -->
                    <div class=""col py-3"">
                        <div class=""product d-flex flex-column justify-content-evenly h-100"">
                            <div class=""d-flex"" style=""min-height: 220px;"">
                                <img class=""m-auto""");
            BeginWriteAttribute("src", " src=\"", 1244, "\"", 1267, 1);
#nullable restore
#line 41 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 1250, category.IconUrl, 1250, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 1268, "\"", 1274, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                            </div>\r\n                            <div class=\"product-body\">\r\n                                <h3 class=\"product-name\"><a");
            BeginWriteAttribute("href", " href=\"", 1429, "\"", 1462, 2);
            WriteAttributeValue("", 1436, "catalog/", 1436, 8, true);
#nullable restore
#line 44 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 1444, category.MetaName, 1444, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 44 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                                                         Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /product -->\r\n");
#nullable restore
#line 49 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>

        </div>
        <!-- /row -->
    </div>
    <!-- /container -->
</div>

<div class=""section"">
    <!-- container -->
    <div class=""container"">
        <!-- row -->
        <div class=""row"">

            <div class=""col-md-12"">
                <div class=""section-title text-center"">
                    <h3 class=""title"">Новые товары</h3>
                </div>
            </div>

            <div class=""row row-cols-1 row-cols-lg-4 row-cols-md-2"">
");
#nullable restore
#line 71 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                 foreach (ProductModel product in Model.NewProducts)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <!-- product -->
                    <div class=""col py-3"">
                        <div class=""product d-flex flex-column h-100"">
                            <div class=""product-img d-flex h-100"" style=""min-height: 220px;"">
                                <img class=""m-auto""");
            BeginWriteAttribute("src", " src=\"", 2534, "\"", 2564, 1);
#nullable restore
#line 77 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 2540, product.Main.IconSource, 2540, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 2565, "\"", 2571, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <div class=\"product-label\">\r\n");
#nullable restore
#line 79 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                     if (product.Discount is not null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"sale product-span\">-");
#nullable restore
#line 81 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                                    Write(product.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 82 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                    <span><span class=""new product-span"">Новинка</span></span>
                                </div>
                            </div>
                            <div class=""product-body d-flex flex-column justify-content-between h-75"">
                                <p class=""product-category"">");
#nullable restore
#line 87 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                       Write(product.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <h3 class=\"product-name\"><a");
            BeginWriteAttribute("href", "\r\n                                    href=\"", 3309, "\"", 3405, 4);
            WriteAttributeValue("", 3353, "catalog/", 3353, 8, true);
#nullable restore
#line 89 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 3361, product.Category.MetaName, 3361, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 3387, "/", 3387, 1, true);
#nullable restore
#line 89 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 3388, product.MetaName, 3388, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 89 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                                                           Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                                <h4 class=\"product-price\">");
#nullable restore
#line 90 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                     Write(GetPrise(product));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 91 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                 if (product.Discount is not null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span><del class=\"product-old-price\">");
#nullable restore
#line 93 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                                    Write(product.Prise);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            руб.</del></span>\r\n");
#nullable restore
#line 95 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n\r\n                        </div>\r\n                    </div>\r\n                    <!-- /product -->\r\n");
#nullable restore
#line 101 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>

        </div>
        <!-- /row -->
    </div>
    <!-- /container -->
</div>

<div class=""section"">
    <!-- container -->
    <div class=""container"">
        <!-- row -->
        <div class=""row"">

            <div class=""col-md-12"">
                <div class=""section-title text-center"">
                    <h3 class=""title"">Выгодная цена</h3>
                </div>
            </div>

            <div class=""row row-cols-1 row-cols-lg-4 row-cols-md-2"">
");
#nullable restore
#line 123 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                 foreach (ProductModel product in Model.SaleProducts)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <!-- product -->
                    <div class=""col py-3"">
                        <div class=""product d-flex flex-column h-100"">
                            <div class=""product-img d-flex h-100"" style=""min-height: 220px;"">
                                <img class=""m-auto""");
            BeginWriteAttribute("src", " src=\"", 4853, "\"", 4883, 1);
#nullable restore
#line 129 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 4859, product.Main.IconSource, 4859, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 4884, "\"", 4890, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n                                <div class=\"product-label\">\r\n");
#nullable restore
#line 131 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                     if (product.Discount is not null)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span class=\"sale product-span\">-");
#nullable restore
#line 133 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                                    Write(product.Discount);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</span>\r\n");
#nullable restore
#line 134 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 135 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                     if (product.IsNew)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <span><span class=\"new product-span\">Новинка</span></span>\r\n");
#nullable restore
#line 138 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </div>\r\n                            </div>\r\n                            <div class=\"product-body d-flex flex-column justify-content-between h-75\">\r\n                                <p class=\"product-category\">");
#nullable restore
#line 142 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                       Write(product.Category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                <h3 class=\"product-name\"><a");
            BeginWriteAttribute("href", "\r\n                                    href=\"", 5767, "\"", 5863, 4);
            WriteAttributeValue("", 5811, "catalog/", 5811, 8, true);
#nullable restore
#line 144 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 5819, product.Category.MetaName, 5819, 26, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5845, "/", 5845, 1, true);
#nullable restore
#line 144 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
WriteAttributeValue("", 5846, product.MetaName, 5846, 17, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 144 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                                                           Write(product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h3>\r\n                                <h4 class=\"product-price\">");
#nullable restore
#line 145 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                     Write(GetPrise(product));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n");
#nullable restore
#line 146 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                 if (product.Discount is not null)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <span><del class=\"product-old-price\">");
#nullable restore
#line 148 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                                                    Write(product.Prise);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            руб.</del></span>\r\n");
#nullable restore
#line 150 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                    <!-- /product -->\r\n");
#nullable restore
#line 155 "D:\repos\diplom\ChipsetShop.MVC\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n\r\n        </div>\r\n        <!-- /row -->\r\n    </div>\r\n    <!-- /container -->\r\n</div>");
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
