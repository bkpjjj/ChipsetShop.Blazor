using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
 
namespace ChipsetShop.MVC.Helpers
{
    public static class EndingsHelper
    {
        public static HtmlString MakeRuEndings(this IHtmlHelper html,int number, string nominativ, string genetiv, string plural) 
        {
            var titles = new[] {nominativ, genetiv, plural};
            var cases = new[] {2, 0, 1, 1, 1, 2};
            
            return new HtmlString(titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]]);
        }
    }
}