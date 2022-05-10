using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using MTPrison.Aids;
using MTPrison.Domain;
using MTPrison.Facade;
using System.Text.Json;

namespace MTPrison.Pages {
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>,
        IPageModel, IIndexModel<TView>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : IPagedRepo<TEntity> {
        protected PagedPage(TRepo r) : base(r) { }
        public int PageIndex {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage => repo.HasNextPage;
        public bool HasPreviousPage => repo.HasPreviousPage;
        protected override void setAttributes(int idx, string? filter, string? order) {
            PageIndex = idx;
            CurrentFilter = filter;
            CurrentOrder = order;
        }

        public virtual string[] IndexColumns => Array.Empty<string>();
        public virtual object? GetValue(string name, TView v) =>
            Safe.Run(() => {
                var pi = v?.GetType()?.GetProperty(name);
                return pi?.GetValue(v);
            }, null);
        protected override IActionResult redirectToIndex() => RedirectToPage("./Index", "Index", new {
            pageIndex = PageIndex,
            currentFilter = CurrentFilter,
            sortOrder = CurrentOrder
        });
        protected override IActionResult redirectToEdit(TView v) {
            TempData["Item"] = JsonSerializer.Serialize(v);
            return RedirectToPage("./Edit", "Edit",
                new {
                    id = v.Id,
                    pageIndex = PageIndex,
                    currentFilter = CurrentFilter,
                    sortOrder = CurrentOrder
                });
        }
        protected override IActionResult redirectToDelete(string id) {
            TempData["Error"] = "The record you attempted to delete "
                + "was modified by another user before you selected Delete. "
                + "Delete operation was canceled and the current values from database are shown. "
                + "If you still like to delete this record, click Delete button once again.";

            return RedirectToPage("./Delete", "Delete",
                new {
                    id = id,
                    pageIndex = PageIndex,
                    currentFilter = CurrentFilter,
                    sortOrder = CurrentOrder
                });
        }
        public string? DisplayName(string name) => Safe.Run(() => {
            var p = typeof(TView).GetProperty(name);
            var a = p?.CustomAttributes?.FirstOrDefault(x => x.AttributeType == typeof(DisplayNameAttribute));
            return a?.ConstructorArguments[0].Value?.ToString() ?? name;
        }, name);
    }
}
