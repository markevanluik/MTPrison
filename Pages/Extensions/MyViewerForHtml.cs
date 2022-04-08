using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace MTPrison.Pages.Extensions {
    public static class MyViewerForHtml {
        public static IHtmlContent MyViewerFor<TModel, TResult> (
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e) {
            var s = htmlStrings(html, e);
            return new HtmlContentBuilder(s);
        }
        public static IHtmlContent MyViewerFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e, dynamic value) {
            var s = htmlStrings(html, e, value);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e) {
            var l = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                html.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.DisplayFor(e),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")};
            return l;
        }
        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e, dynamic value) {
            var l = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                html.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.Raw(value),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")};
            return l;
        }
    }
}
