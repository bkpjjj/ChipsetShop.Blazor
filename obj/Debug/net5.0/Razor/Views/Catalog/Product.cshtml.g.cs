#pragma checksum "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ba356d08871b2071bb6f3eefaa4c078d79b02d36"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Catalog_Product), @"mvc.1.0.view", @"/Views/Catalog/Product.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba356d08871b2071bb6f3eefaa4c078d79b02d36", @"/Views/Catalog/Product.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5d5b890ec39ff07fc8681ce23e843f3a70cab94", @"/Views/_ViewImports.cshtml")]
    public class Views_Catalog_Product : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProductViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Catalog", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("review-form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/api/catalog/comment"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Account", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Login", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("primary-btn"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Register", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/pagentaion.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", "~/js/product.js", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!-- SECTION -->\r\n<div class=\"section\">\r\n\t<!-- container -->\r\n\t<div class=\"container\">\r\n\t\t<!-- row -->\r\n\t\t<div class=\"row\">\r\n\t\t\t<!-- Product main img -->\r\n\t\t\t<div class=\"col-md-5\">\r\n\t\t\t\t<div id=\"product-main-img\">\r\n");
#nullable restore
#line 12 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                     foreach (var pricture in Model.Product.Pictures)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"product-preview\">\r\n\t\t\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 354, "\"", 381, 1);
#nullable restore
#line 15 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
WriteAttributeValue("", 360, pricture.ImageSource, 360, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 382, "\"", 388, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 17 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<!-- /Product main img -->\r\n\r\n\t\t\t<!-- Product thumb imgs -->\r\n\t\t\t<div class=\"col-md-2\">\r\n\t\t\t\t<div id=\"product-imgs\">\r\n");
#nullable restore
#line 25 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                     foreach (var pricture in Model.Product.Pictures)
					{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t<div class=\"product-preview\">\r\n\t\t\t\t\t\t\t<img");
            BeginWriteAttribute("src", " src=\"", 670, "\"", 697, 1);
#nullable restore
#line 28 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
WriteAttributeValue("", 676, pricture.ImageSource, 676, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 698, "\"", 704, 0);
            EndWriteAttribute();
            WriteLiteral(">\r\n\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 30 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
					}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t</div>\r\n\t\t\t</div>\r\n\t\t\t<!-- /Product thumb imgs -->\r\n\r\n\t\t\t<!-- Product details -->\r\n\t\t\t<div class=\"col-md-5\">\r\n\t\t\t\t<div class=\"product-details\">\r\n\t\t\t\t\t<h2 class=\"product-name\">");
#nullable restore
#line 38 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                        Write(Model.Product.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h2>
					<div>
						<div class=""product-rating"">
							<i v-for=""index in [1,2,3,4,5]""
								v-bind:class=""{ 'fa-star-o': index > Math.round(comments.totalRate), 'fa-star': index <= Math.round(comments.totalRate)  }""
								class=""fa""></i>
						</div>
						<a id=""reviewButton"" type=""button"" class=""review-link"">{{ comments.commentsCount }} {{
							makeRuEndings(comments.commentsCount, 'Отзыв', 'Отзыва', 'Отзывов') }} | Добавь свой</a>
					</div>
					<div>
						<h3 class=""product-price"">
");
#nullable restore
#line 50 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                             if (Model.Product.Discount > 0)
							{
								

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                            Write((Model.Product.DicountPrise).ToString("#.## руб\\."));

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t<del class=\"product-old-price\">");
#nullable restore
#line 53 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                          Write(Model.Product.Prise.ToString("#.## руб\\."));

#line default
#line hidden
#nullable disable
            WriteLiteral("</del>\r\n");
#nullable restore
#line 54 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
							}
							else
							{
								

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                           Write(Model.Product.Prise.ToString("#.## руб\\."));

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                                            
							}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t</h3>\r\n\t\t\t\t\t</div>\r\n\t\t\t\t\t<p>");
#nullable restore
#line 61 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                  Write(string.Join(" ,",Model.Product.Tags));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</p>

					<div class=""add-to-cart"">
						<div class=""qty-label"">
							Кол-во
							<div class=""input-number"">
								<input id=""cartCount"" type=""number"" value=""1"">
								<span class=""qty-up"">+</span>
								<span class=""qty-down"">-</span>
							</div>
						</div>
");
#nullable restore
#line 72 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                         if (@Model.Product.InStock)
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<button v-on:click=\"addToCart()\" class=\"add-to-cart-btn\"><i class=\"fa fa-shopping-cart\"></i>\r\n\t\t\t\t\t\t\t\tДобавь в корзину</button>\r\n");
#nullable restore
#line 76 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
						}
						else
						{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t<button class=\"add-to-cart-btn\"><i class=\"fa fa-shopping-cart\"></i>\r\n\t\t\t\t\t\t\t\tНет в наличии</button>\r\n");
#nullable restore
#line 81 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
						}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"					</div>

					<ul class=""product-btns"">
						<li><a v-bind:style=""{ color : inWishlist ? 'red' : '' }"" v-on:click=""addToWishlist""
								type=""button""><i class=""fa fa-heart-o""></i> {{ getWishlistButtonName() }}</a></li>
					</ul>

					<ul class=""product-links"">
						<li>Категория:</li>
						<li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba356d08871b2071bb6f3eefaa4c078d79b02d3613913", async() => {
#nullable restore
#line 92 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                                         Write(Model.Product.Category.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 92 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                WriteLiteral(Model.Product.Category.MetaName);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
					</ul>

				</div>
			</div>
			<!-- /Product details -->

			<!-- Product tab -->
			<div class=""col-md-12"">
				<div id=""product-tab"">
					<!-- product tab nav -->
					<ul class=""nav tab-nav justify-content-center"" id=""pTab"" role=""tablist"">
						<li role=""presentation""><a id=""pTab1"" class=""active"" role=""tab"" aria-selected=""true""
								data-bs-toggle=""tab"" href=""#tab1"">Описание</a></li>
						<li role=""presentation""><a id=""pTab2"" role=""tab"" data-bs-toggle=""tab"" href=""#tab2"">Отзывы ({{
								comments.commentsCount }})</a></li>
					</ul>
					<!-- /product tab nav -->

					<!-- product tab content -->
					<div class=""tab-content"">
						<!-- tab1  -->
						<div id=""tab1"" role=""tabpanel"" class=""tab-pane fade in active show"">
							<div class=""row"">
								<div class=""col-md-12"">
									<table class=""table table-striped"">
										<thead>
											<tr>
												<th>
													<h3>Описание</h3>
												</th>
												<th></th>
											</t");
            WriteLiteral("r>\r\n\t\t\t\t\t\t\t\t\t\t</thead>\r\n\t\t\t\t\t\t\t\t\t\t<tbody>\r\n");
#nullable restore
#line 127 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                             foreach (AttributeModel attr in Model.Product.Attributes)
											{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t<tr>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<td style=\"font-size: 10pt\" class=\"col-1\">");
#nullable restore
#line 130 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                                                         Write(attr.AttributeSceme.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t\t<td style=\"font-size: 10pt;font-weight: 500\" class=\"col-1\">\r\n");
#nullable restore
#line 132 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                         if (attr.Value == "Да.")
														{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"															<svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24""
														fill=""green"" class=""bi bi-check2"" viewBox=""0 0 16 16"">
																<path
															d=""M13.854 3.646a.5.5 0 0 1 0 .708l-7 7a.5.5 0 0 1-.708 0l-3.5-3.5a.5.5 0 1 1 .708-.708L6.5 10.293l6.646-6.647a.5.5 0 0 1 .708 0z"" />
															</svg>
");
#nullable restore
#line 139 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
														}
														else if (attr.Value == "Нет.")
														{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"															<svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24""
														fill=""gray"" class=""bi bi-x"" viewBox=""0 0 14 14"">
																<path
															d=""M4.646 4.646a.5.5 0 0 1 .708 0L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 0 1 0-.708z"" />
															</svg>
");
#nullable restore
#line 147 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
														}
														else
														{
															

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                       Write(attr.Value);

#line default
#line hidden
#nullable disable
#nullable restore
#line 150 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                                       
														}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t\t\t\t</td>\r\n\t\t\t\t\t\t\t\t\t\t\t\t</tr>\r\n");
#nullable restore
#line 154 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
											}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"										</tbody>
									</table>
								</div>
							</div>
						</div>
						<!-- /tab1  -->

						<!-- tab3  -->
						<div id=""tab2"" role=""tabpanel"" class=""tab-pane fade in"">
							<div class=""row"">
								<!-- Rating -->
								<div class=""col-md-3"">
									<div id=""rating"">
										<div class=""rating-avg"">
											<span>{{ comments.totalRate }}</span>
											<div class=""rating-stars"">
												<i v-for=""index in [1,2,3,4,5]""
													v-bind:class=""{ 'fa-star-o': index > Math.round(comments.totalRate), 'fa-star': index <= Math.round(comments.totalRate)  }""
													class=""fa""></i>
											</div>
										</div>
										<ul class=""rating"">
											<li v-for=""(detail,d_index) in comments.totalRateDetail"">
												<div class=""rating-stars"">
													<i v-for=""index in [0,1,2,3,4]""
														v-bind:class=""{ 'fa-star-o': index > 4 - d_index, 'fa-star': index <= 4 - d_index  }""
														class=""fa""></i>
												</div>
				");
            WriteLiteral(@"								<div class=""rating-progress"">
													<div v-bind:style=""{ width: detail.precentage+'%' }""></div>
												</div>
												<span class=""sum"">{{detail.userCount}}</span>
											</li>
										</ul>
									</div>
								</div>
								<!-- /Rating -->

								<!-- Reviews -->
								<div class=""col-md-6"">
									<div id=""reviews"">
										<ul class=""reviews"">
											<li v-for=""comment in comments.comments"">
												<div class=""review-heading"">
													<h5 class=""name"">{{ comment.user.login }}</h5>
													<p class=""date"">{{ comment.date }}</p>
													<div class=""review-rating"">
														<i v-for=""index in [1,2,3,4,5]"" class=""fa""
															v-bind:class=""{ 'fa-star-o empty': index > comment.rate, 'fa-star': index <= comment.rate  }""></i>
");
#nullable restore
#line 204 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                          
															/*<i class="fa fa-star-o empty"></i>*/
														

#line default
#line hidden
#nullable disable
            WriteLiteral(@"													</div>
												</div>
												<div class=""review-body"">
													<h5>{{ comment.title }}</h5>
													<p style=""overflow-wrap: break-word;"">{{comment.text}}</p>
													<p><span class=""fw-bold""
															style=""color: #5c8527	;font-size: small;"">Достоинства:
														</span>{{ comment.dignity }}</p>
													<p><span class=""fw-bold""
															style=""color: #d31c10;font-size: small;"">Недостатки:
														</span>{{ comment.limitations }}</p>
												</div>
											</li>
										</ul>
										<ul class=""reviews-pagination"" v-if=""pages.length > 1"">
											<li v-on:click=""pageClick(page.number)"" v-for=""page in pages""
												id=""pageButton"" type=""button"" v-bind:class=""{ active: page.isActive }"">
												{{ page.number }}</li>
										</ul>
									</div>
								</div>
								<!-- /Reviews -->

								<!-- Review Form -->
								<div class=""col-md-3"">
");
#nullable restore
#line 232 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                     if (User.Identity.IsAuthenticated)
									{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<div id=\"review-form\">\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba356d08871b2071bb6f3eefaa4c078d79b02d3623764", async() => {
                WriteLiteral(@"
												<input class=""input"" name=""title"" placeholder=""Заголовок"">
												<input class=""input"" name=""dignity"" placeholder=""Достоинства"">
												<input class=""input"" name=""limitations"" placeholder=""Недостатки"">
												<textarea class=""input"" name=""text"" placeholder=""Ваш отзыв""></textarea>
												<input name=""returnUrl"" type=""hidden""");
                BeginWriteAttribute("value", " value=\"", 8688, "\"", 8717, 1);
#nullable restore
#line 240 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
WriteAttributeValue("", 8696, Context.Request.Path, 8696, 21, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n\t\t\t\t\t\t\t\t\t\t\t\t<input name=\"product\" type=\"hidden\"");
                BeginWriteAttribute("value", " value=\"", 8770, "\"", 8801, 1);
#nullable restore
#line 241 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
WriteAttributeValue("", 8778, Model.Product.MetaName, 8778, 23, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" />
												<div class=""input-rating"">
													<span>Оценка: </span>
													<div class=""stars"">
														<input id=""star5"" name=""rate"" value=""5"" type=""radio""><label
														for=""star5""></label>
														<input id=""star4"" name=""rate"" value=""4"" type=""radio""><label
														for=""star4""></label>
														<input id=""star3"" name=""rate"" value=""3"" type=""radio""><label
														for=""star3""></label>
														<input id=""star2"" name=""rate"" value=""2"" type=""radio""><label
														for=""star2""></label>
														<input id=""star1"" name=""rate"" value=""1"" type=""radio""><label
														for=""star1""></label>
													</div>
												</div>
												<button class=""primary-btn"">Отправить</button>
											");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 260 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
									}
									else
									{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t\t\t\t\t\t\t\t<div class=\"d-flex flex-column align-items-center\">\r\n\t\t\t\t\t\t\t\t\t\t\t<h6>Авторизируйтесь в аккаунт</h6>\r\n\t\t\t\t\t\t\t\t\t\t\t<h6>для того что бы оставить отзыв</h6>\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba356d08871b2071bb6f3eefaa4c078d79b02d3627864", async() => {
                WriteLiteral("Войти");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 267 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                     WriteLiteral(Context.Request.Path);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t\t<h6>или</h6>\r\n\t\t\t\t\t\t\t\t\t\t\t");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba356d08871b2071bb6f3eefaa4c078d79b02d3630399", async() => {
                WriteLiteral("Зарегистрироваться");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_7.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-returnUrl", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 270 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
                                                     WriteLiteral(Context.Request.Path);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-returnUrl", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["returnUrl"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\t\t\t\t\t\t\t\t\t\t</div>\r\n");
#nullable restore
#line 273 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
									}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"								</div>
								<!-- /Review Form -->
							</div>
						</div>
						<!-- /tab3  -->
					</div>
					<!-- /product tab content  -->
				</div>
			</div>
			<!-- /product tab -->
		</div>
		<!-- /row -->
	</div>
	<!-- /container -->
</div>
<!-- /SECTION -->

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba356d08871b2071bb6f3eefaa4c078d79b02d3633483", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ba356d08871b2071bb6f3eefaa4c078d79b02d3634579", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.ScriptTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_9.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
#nullable restore
#line 294 "D:\repos\diplom\ChipsetShop.MVC\Views\Catalog\Product.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProductViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
