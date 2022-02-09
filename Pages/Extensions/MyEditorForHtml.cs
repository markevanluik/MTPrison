using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Pages.Extensions
{
    public static class MyEditorForHtml
    {
        public static IHtmlContent MyEditorFor<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = htmlStrings(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object>();
            l.Add(new HtmlString("<div class=\"row\">"));
                l.Add(new HtmlString("<dd class=\"col-sm-2\">"));
                    l.Add(h.LabelFor(e, null, new { @class = "control-label" }));
                l.Add(new HtmlString("</dd>"));
                l.Add(new HtmlString("<dd class=\"col-sm-10\">"));
                    l.Add(h.EditorFor(e, new { htmlAttributes = new { @class = "form-control" } }));
                    l.Add(h.ValidationMessageFor(e, null, new { @class = "text-danger"}));
                l.Add(new HtmlString("</dd>"));
            l.Add(new HtmlString("</div>"));
            return l;
        }
    }
}
