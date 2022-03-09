using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Infra.Party;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.Cells {
    public class CellsPage : PageModel {
        private readonly ICellsRepo repo;
        [BindProperty] public CellView Item { get; set; }
        public IList<CellView> Items { get; set; }
        public string ItemId => Item?.Id ?? string.Empty;
        //public SelectList Sections { get; set; }
        //[BindProperty(SupportsGet = true)] public string? CellSection { get; set; }
        //public SelectList Types { get; set; }
        //[BindProperty(SupportsGet = true)] public string? CellType { get; set; }
        public CellsPage(ApplicationDbContext c) => repo = new CellsRepo(c, c.Cells);
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new CellViewFactory().Create(Item));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync() {
            var list = await repo.GetAsync();
            Items = new List<CellView>();
            list.ForEach(x => Items.Add(new CellViewFactory().Create(x)));
            return Page();
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id) {
            Item = await GetCell(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetEditAsync(string id) {
            Item = await GetCell(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync() {
            if (!ModelState.IsValid) return Page();
            var obj = new CellViewFactory().Create(Item);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id) {
            Item = await GetCell(id);
            return Item == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        private async Task<CellView> GetCell(string id) => new CellViewFactory().Create(await repo.GetAsync(id));
    }
}
