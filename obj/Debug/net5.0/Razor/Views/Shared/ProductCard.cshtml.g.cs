#pragma checksum "D:\repos\diplom\ChipsetShop.MVC\Views\Shared\ProductCard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a934ce0969eff57e83eee1879c97315d84dbab6b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_ProductCard), @"mvc.1.0.view", @"/Views/Shared/ProductCard.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a934ce0969eff57e83eee1879c97315d84dbab6b", @"/Views/Shared/ProductCard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5d5b890ec39ff07fc8681ce23e843f3a70cab94", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_ProductCard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<string>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!-- product -->\r\n<div class=\"col py-3\"");
            BeginWriteAttribute("v-for", " v-for=\"", 56, "\"", 81, 3);
            WriteAttributeValue("", 64, "product", 64, 7, true);
            WriteAttributeValue(" ", 71, "in", 72, 3, true);
#nullable restore
#line 4 "D:\repos\diplom\ChipsetShop.MVC\Views\Shared\ProductCard.cshtml"
WriteAttributeValue(" ", 74, Model, 75, 6, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n    <div class=\"product d-flex flex-column h-100\">\r\n        <div class=\"product-img d-flex h-100\" style=\"min-height: 220px;\">\r\n            <img class=\"m-auto\" v-bind:src=\"product.icon\"");
            BeginWriteAttribute("alt", " alt=\"", 269, "\"", 275, 0);
            EndWriteAttribute();
            WriteLiteral(@">
            <div class=""product-label"">
                <span v-if=""product.discount""><span
                        class=""sale product-span"">-{{product.discount.amount}}%</span></span>
                <span v-if=""product.isNew""><span class=""new product-span"">Новинка</span></span>
            </div>
        </div>
        <div class=""product-body d-flex flex-column justify-content-between h-75"">
            <p class=""product-category"">{{ product.category }}</p>
            <h3 class=""product-name""><a href=""#"" v-bind:href=""product.url"">{{ product.name }}</a></h3>
            <h4 class=""product-price"">{{ getPrise(product) }}</h4>
            <span v-if=""product.discount && product.inStock""><del class=""product-old-price"">{{ product.prise }} руб.</del></span>
            <div class=""product-rating"">
                <i v-for=""index in [1,2,3,4,5]""
                    v-bind:class=""{ 'fa-star-o': index > Math.round(product.avgRate), 'fa-star': index <= Math.round(product.avgRate)  }""
              ");
            WriteLiteral(@"      class=""fa""></i>
            </div>
            <div class=""product-btns"">
                <button v-bind:style=""{ color : wishlist.includes(product.key) ? 'red' : '' }""
                    v-on:click=""addToWishlist(product.key)"" class=""add-to-wishlist""><i class=""fa fa-heart-o""></i><span
                        class=""tooltipp"">add to
                        wishlist</span></button>
            </div>
        </div>
        <div class=""add-to-cart"" v-if=""product.inStock"">
            <button v-on:click=""addToCart(product.key)"" class=""add-to-cart-btn""><i class=""fa fa-shopping-cart""></i> add to cart</button>
        </div>
    </div>
</div>
<!-- /product -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<string> Html { get; private set; }
    }
}
#pragma warning restore 1591
