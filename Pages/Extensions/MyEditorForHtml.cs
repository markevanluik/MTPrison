using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace MTPrison.Pages.Extensions {
    public static class MyEditorForHtml {
        public static IHtmlContent MyEditorFor<TModel, TResult>(
            this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e) {
            var s = htmlStrings(html, e);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> e) {
            var l = new List<object> {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dd class=\"col-sm-2\">"),
                html.LabelFor(e, null, new { @class = "control-label" }),
                new HtmlString("</dd>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                html.EditorFor(e, new { htmlAttributes = new { @class = "form-control" } }),
                html.ValidationMessageFor(e, null, new { @class = "text-danger" }),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")};
            return l;
        }
    }
}
