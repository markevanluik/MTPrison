using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MTPrison.Pages.Extensions {
    public static class MyTabHdrHtml {
        public static IHtmlContent MyTabHdr<TModel>(
            this IHtmlHelper<TModel> html, string name) {
            var s = htmlStrings(name, html.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings(string name, IPageModel? m) {
            name ??= "Unspeficided";
            var l = new List<object> {
                new HtmlString($"<a style=\"text-decoration:none;\""),
                new HtmlString($"href=\"/{pageName(m)}?"),
                new HtmlString($"handler=Index&amp;"),
                new HtmlString($"order={m?.SortOrder(name)}&amp;"),
                new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"),
                new HtmlString($"filter={m?.CurrentFilter}\""),
                new HtmlString($">{name}</a>")};
            return l;
        }
        private static string? pageName(IPageModel? m) => m?.GetType()?.Name?.Replace("Page", "");
    }
}
