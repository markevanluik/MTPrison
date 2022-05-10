using Microsoft.AspNetCore.Mvc;
using MTPrison.Aids;
using MTPrison.Domain;
using MTPrison.Facade;
using System.Text.Json;

namespace MTPrison.Pages {
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
        where TView : UniqueView, new()
        where TEntity : UniqueEntity
        where TRepo : ICrudRepo<TEntity> {
        // constructor
        protected CrudPage(TRepo r) : base(r) { }
        // returns a given type page, create
        protected override IActionResult getCreate() => Page();
        protected virtual async Task<IActionResult> getItemPage(string id) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        protected override async Task<IActionResult> getEditAsync(string id) {
            var s = TempData["Item"] as string;
            TView? v = null;
            if (s is not null) v = JsonSerializer.Deserialize<TView>(s);
            if (v is null) return await getItemPage(id);
            return await getEditAsync(v);
        }
        protected async Task<IActionResult> getEditAsync(TView v) {
            Item = await getItem(v.Id);
            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit was modified by another user before you. "
                + "Edit operation was canceled and current values in database is shown. "
                + "If you still like to edit this record, click Save button again with new values.");
            foreach (var p in Item.GetType().GetProperties()) {
                var n = p.Name;
                var currentValue = p.GetValue(Item)?.ToString();
                var clientValue = v?.GetType()?.GetProperty(n)?.GetValue(v)?.ToString();
                if (currentValue != clientValue)
                    ModelState.AddModelError(
                        $"{nameof(Item)}.{n}",
                        $"Your value: {clientValue}");
            }
            return itemPage();
        }
        protected IActionResult itemPage() => Item == null ? NotFound() : Page();
        protected override async Task<IActionResult> getDetailsAsync(string id) => await getItemPage(id);
        protected override async Task<IActionResult> getDeleteAsync(string id) {
            ErrorMessage = TempData["Error"] as string;
            return await getItemPage(id);
        }
        protected override async Task<IActionResult> postCreateAsync() {
            if (!ModelState.IsValid) return Page();
            var updated = await repo.AddAsync(toObject(Item));
            return !updated ? NotFound() : redirectToIndex();
        }
        protected override async Task<IActionResult> postEditAsync() {
            var o = repo.Get(Item.Id);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr(Array.Empty<byte>())) {
                ModelState.AddModelError(string.Empty, "Unable to save. The item was deleted by another user");
                return Page();
            }
            var oToken = ConcurrencyToken.ToStr(o.Token);
            var itemToken = ConcurrencyToken.ToStr(Item.Token);
            if (oToken != itemToken) return redirectToEdit(Item);

            if (!ModelState.IsValid) return Page();
            var obj = toObject(Item);
            var updated = await repo.UpdateAsync(obj);
            return !updated ? NotFound() : redirectToIndex();
        }
        protected override async Task<IActionResult> postDeleteAsync(string id, string? token = null) {
            if (id == null) return NotFound();
            var o = await getItem(id);
            if (ConcurrencyToken.ToStr(o.Token) == ConcurrencyToken.ToStr()) return redirectToIndex();
            var oToken = ConcurrencyToken.ToStr(o.Token);
            if (oToken != token) return redirectToDelete(id);
            _ = await repo.DeleteAsync(id);
            return redirectToIndex();
        }
        protected override async Task<IActionResult> getIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            list.ForEach(obj => Items.Add(toView(obj)));
            return Page();
        }
        private async Task<TView> getItem(string id)
            => toView(await repo.GetAsync(id));
    }
}
