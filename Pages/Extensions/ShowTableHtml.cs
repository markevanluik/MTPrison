using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrison.Facade;

namespace MTPrison.Pages.Extensions {
    public static class ShowTableHtml {
        public static IHtmlContent ShowTable<TModel, TView>(
            this IHtmlHelper<TModel> html, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : UniqueView {
            var s = htmlStrings(html, items);
            return new HtmlContentBuilder(s);
        }
        private static List<object> htmlStrings<TModel, TView>(IHtmlHelper<TModel> html, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : UniqueView {
            var m = html.ViewData.Model;
            var l = new List<object> {
                new HtmlString("<table class=\"table\">"),
                new HtmlString("<thead>"),
                new HtmlString("<tr>")};
            foreach (var name in m.IndexColumns) {
                l.Add(new HtmlString("<td>"));
                l.Add(html.MyTabHdr(m.DisplayName(name)));
                l.Add(new HtmlString("</td>"));
            }
            l.Add(new HtmlString("<th></th>"));
            l.Add(new HtmlString("</tr>"));
            l.Add(new HtmlString("</thead>"));
            l.Add(new HtmlString("<tbody>"));
            foreach (var item in items ?? new List<TView>()) {
                l.Add(new HtmlString("<tr>"));
                foreach (var name in m.IndexColumns) {
                    l.Add(new HtmlString("<td>"));
                    l.Add(html.Raw(m.GetValue(name, item)));
                    l.Add(new HtmlString("</td>"));
                }
                l.Add(new HtmlString("<td>"));
                l.Add(html.ItemButtons(item.Id));
                l.Add(new HtmlString("</td>"));
                l.Add(new HtmlString("</tr>"));
            }
            l.Add(new HtmlString("</tbody>"));
            l.Add(new HtmlString("</table>"));
            return l;
        }
    }
}
