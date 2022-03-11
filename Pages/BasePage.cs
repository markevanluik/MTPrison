﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTPrison.Domain;
using MTPrison.Facade;

namespace MTPrison.Pages {
    public abstract class BasePage<TView, TEntity, TRepo> : PageModel
    where TView : BaseView
    where TEntity : Entity
    where TRepo : IBaseRepo<TEntity> {
        private readonly TRepo repo;
        protected abstract TView toView(TEntity entity);
        protected abstract TEntity toObject(TView item);
        [BindProperty] public TView Item { get; set; }
        public IList<TView> Items { get; set; }
        public string ItemId => Item?.Id ?? string.Empty;
        public BasePage(TRepo r) => repo = r;
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            var updated = await repo.AddAsync(toObject(Item));
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            list.ForEach(x => Items.Add(toView(x)));
            return Page();
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetEditAsync(string id) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync() {
            if (!ModelState.IsValid) return Page();
            var obj = toObject(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        private async Task<TView> getItem(string id) => toView(await repo.GetAsync(id));
    }
}


