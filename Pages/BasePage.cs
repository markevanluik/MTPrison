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

        // uses protected repo
        protected readonly TRepo repo;

        // has constructor from IBaseRepo<TEntity>
        public BasePage(TRepo r) => repo = r;

        // get's Item.Id from Facade.UniqueView
        public string ItemId => Item?.Id ?? string.Empty;

        // has list that \Index uses
        public IList<TView>? Items { get; set; }

        // has 2 abstract methods
        protected abstract TView toView(TEntity? entity);
        protected abstract TEntity toObject(TView? item);

        // returns a given type page, create
        public IActionResult OnGetCreate() => Page();


        public async Task<IActionResult> OnPostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            var updated = await repo.AddAsync(toObject(Item));
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
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
        public async Task<IActionResult> OnGetDetailsAsync(string id) {
            Item = await getItem(id);
            return Item == null ? NotFound() : Page();
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
        public async virtual Task<IActionResult> OnGetIndexAsync(int pageIndex = 0, string currentFilter = null, string sortOrder = null) {
            var list = await repo.GetAsync();
            Items = new List<TView>();
            list.ForEach(obj => Items.Add(toView(obj)));
            return Page();
        }
        private async Task<TView> getItem(string id) => toView(await repo.GetAsync(id));
    }
}
