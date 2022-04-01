using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTPrison.Domain;
using MTPrison.Facade;

namespace MTPrison.Pages {
    public abstract class BasePage<TView, TEntity, TRepo> : PageModel
        where TView : UniqueView
        where TEntity : UniqueEntity
        where TRepo : IBaseRepo<TEntity> {
        [BindProperty] public TView? Item { get; set; }

        protected readonly TRepo repo;

        public BasePage(TRepo r) => repo = r;

        public string ItemId => Item?.Id ?? string.Empty;

        public IList<TView>? Items { get; set; }

        protected abstract TView toView(TEntity? entity);
        protected abstract TEntity toObject(TView? item);


        public virtual IActionResult OnGetCreate(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) => Page();

        public virtual async Task<IActionResult> OnPostCreateAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            if (!ModelState.IsValid) return Page();
            var updated = await repo.AddAsync(toObject(Item));
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index", new {
                pageIndex,
                currentFilter,
                sortOrder
            });
        }
        public virtual async Task<IActionResult> OnGetEditAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public virtual async Task<IActionResult> OnPostEditAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            if (!ModelState.IsValid) return Page();
            var obj = toObject(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index", new {
                pageIndex,
                currentFilter,
                sortOrder
            });
        }
        public virtual async Task<IActionResult> OnGetDetailsAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public virtual async Task<IActionResult> OnGetDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
        }
        public virtual async Task<IActionResult> OnPostDeleteAsync(string id, int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index", new {
                pageIndex,
                currentFilter,
                sortOrder
            });
        }
        public virtual async Task<IActionResult> OnGetIndexAsync(int pageIndex = 0, string? currentFilter = null, string? sortOrder = null) {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            list.ForEach(obj => Items.Add(toView(obj)));
            return Page();
        }
        private async Task<TView> getItem(string id) => toView(await repo.GetAsync(id));
    }
}
