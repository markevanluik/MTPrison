﻿using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MTPrison.Pages.Extensions
{
    public static class MyViewerForHtml
    {
        public static IHtmlContent MyViewerFor<TModel, TResult>(
            this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var s = htmlStrings(h, e);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e)
        {
            var l = new List<object>();
            l.Add(new HtmlString("<dl class=\"row\">"));
            l.Add(new HtmlString("<dt class=\"col-sm-2\">"));
                l.Add(h.DisplayNameFor(e));
            l.Add(new HtmlString("</dt>"));
            l.Add(new HtmlString("<dd class=\"col-sm-10\">"));
                l.Add(h.DisplayFor(e));
            l.Add(new HtmlString("</dd>"));
            l.Add(new HtmlString("</dl>"));
            return l;
        }
    }
}
