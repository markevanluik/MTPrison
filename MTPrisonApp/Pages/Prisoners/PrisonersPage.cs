using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.Prisoners
{
    // TODO
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public class PrisonersPage : PageModel
    {
        private readonly ApplicationDbContext context;
        [BindProperty] public PrisonerView Prisoner { get; set; }
        public IList<PrisonerView> Prisoners { get; set; }
        [BindProperty(SupportsGet = true)] public string? SearchString { get; set; }
        public SelectList Offenses { get; set; }
        [BindProperty(SupportsGet = true)] public string? PrisonerOffense { get; set; }
        public PrisonersPage(ApplicationDbContext c) => context = c;
        public IActionResult OnGetCreate()
        {
            return Page();
        }
        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var d = new PrisonerViewFactory().Create(Prisoner).Data;
            context.Prisoners.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Prisoner = await GetPrisoner(id);
            return Prisoner == null ? NotFound() : Page();
        }
        private async Task<PrisonerView> GetPrisoner(string id)
        {
            if (id == null) return null;
            var d = await context.Prisoners.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new PrisonerViewFactory().Create(new Prisoner(d));
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Prisoner = await GetPrisoner(id);
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Prisoners.FindAsync(id);

            if (d != null)
            {
                context.Prisoners.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Prisoner = await GetPrisoner(id);
            return Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(new PrisonerViewFactory().Create(Prisoner).Data).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrisonerExists(Prisoner.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", "Index");
        }
        private bool PrisonerExists(string id) 
            => context.Prisoners.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            IQueryable<string> offenseQuery = from m in context.Prisoners
                                              orderby m.Offense
                                              select m.Offense;
            var prisoners = from m in context.Prisoners
                            select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                prisoners = prisoners.Where(s => s.FirstName.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(PrisonerOffense))
            {
                prisoners = prisoners.Where(x => x.Offense == PrisonerOffense);
            }
            Offenses = new SelectList(await offenseQuery.Distinct().ToListAsync());
            List<PrisonerData> prisonerDatas = await prisoners.ToListAsync();
            PrisonerViewFactory prisonerViewFactory = new PrisonerViewFactory();
            Prisoners = prisonerDatas.Select(x => prisonerViewFactory.Create(new Prisoner(x))).ToList();
        }
    }
}
