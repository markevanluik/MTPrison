using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MTPrison.Pages.Extensions {
    public static class ItemButtonsHtml {
        public static IHtmlContent ItemButtons<TModel>(
            this IHtmlHelper<TModel> html, string id) {
            var s = htmlStrings(html, id);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel>(IHtmlHelper<TModel> html, string id) {
            var l = new List<object> {
                html.MyBtn("Edit", id),
                new HtmlString("&nbsp"),
                html.MyBtn("Details", id),
                new HtmlString("&nbsp"),
                html.MyBtn("Delete", id)};
            return l;
        }
    }
}
