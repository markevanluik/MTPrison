using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrison.Infra.Party;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.Prisoners {
    public class PrisonersPage : PageModel {
        private readonly IPrisonersRepo repo;
        [BindProperty] public PrisonerView Prisoner { get; set; }
        public IList<PrisonerView> Prisoners { get; set; }
        //[BindProperty(SupportsGet = true)] public string? SearchString { get; set; }
        //public SelectList Offenses { get; set; }
        //[BindProperty(SupportsGet = true)] public string? PrisonerOffense { get; set; }
        public PrisonersPage(ApplicationDbContext c) => repo = new PrisonersRepo(c, c.Prisoners);
        public IActionResult OnGetCreate() => Page();
        public async Task<IActionResult> OnPostCreateAsync() {
            if (!ModelState.IsValid) return Page();
            await repo.AddAsync(new PrisonerViewFactory().Create(Prisoner));
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetIndexAsync() {
            var list = await repo.GetAsync();
            Prisoners = new List<PrisonerView>();
            list.ForEach(x => Prisoners.Add(new PrisonerViewFactory().Create(x)));
            return Page();
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id) {
            Prisoner = await GetPrisoner(id);
            return Prisoner == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnGetEditAsync(string id) {
            Prisoner = await GetPrisoner(id);
            return Prisoner == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostEditAsync() {
            if (!ModelState.IsValid) return Page();
            var obj = new PrisonerViewFactory().Create(Prisoner);
            var updated = await repo.UpdateAsync(obj);
            if (!updated) return NotFound();
            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id) {
            Prisoner = await GetPrisoner(id);
            return Prisoner == null ? NotFound() : Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id) {
            if (id == null) return NotFound();
            await repo.DeleteAsync(id);
            return RedirectToPage("./Index", "Index");
        }
        private async Task<PrisonerView> GetPrisoner(string id) => new PrisonerViewFactory().Create(await repo.GetAsync(id));
    }
}
