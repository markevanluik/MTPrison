using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.PrisonCells
{
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
    public class PrisonCellsPage : PageModel
    {
        private readonly ApplicationDbContext context;
        [BindProperty] public PrisonCellView PrisonCell { get; set; }
        public IList<PrisonCellView> PrisonCells { get; set; }
        public SelectList Sections { get; set; }
        [BindProperty(SupportsGet = true)] public string? PrisonCellSection { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)] public string? PrisonCellType { get; set; }
        public PrisonCellsPage(ApplicationDbContext c) => context = c;
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
            var d = new PrisonCellViewFactory().Create(PrisonCell).Data;
            context.PrisonCells.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            PrisonCell = await GetPrisonCell(id);
            return Page();
        }
        private async Task<PrisonCellView> GetPrisonCell(string id)
        {
            if (id == null) return null;
            var d = await context.PrisonCells.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new PrisonCellViewFactory().Create(new PrisonCell(d));
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            PrisonCell = await GetPrisonCell(id);
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.PrisonCells.FindAsync(id);

            if (d != null)
            {
                context.PrisonCells.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            PrisonCell = await GetPrisonCell(id);
            return Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(new PrisonCellViewFactory().Create(PrisonCell).Data).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrisonCellExists(PrisonCell.Id))
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
        private bool PrisonCellExists(string id) 
            => context.PrisonCells.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            IQueryable<string> sectionQuery = from m in context.PrisonCells
                                              orderby m.Section
                                              select m.Section;
            IQueryable<string> typeQuery = from m in context.PrisonCells
                                           orderby m.Type
                                           select m.Type;
            var prisonCells = from m in context.PrisonCells
                              select m;
            if (!string.IsNullOrEmpty(PrisonCellSection))
            {
                prisonCells = prisonCells.Where(x => x.Section == PrisonCellSection);
            }
            if (!string.IsNullOrEmpty(PrisonCellType))
            {
                prisonCells = prisonCells.Where(x => x.Type == PrisonCellType);
            }
            Sections = new SelectList(await sectionQuery.Distinct().ToListAsync());
            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            List<PrisonCellData> prisonCellDatas = await prisonCells.ToListAsync();
            PrisonCellViewFactory prisonCellViewFactory = new PrisonCellViewFactory();
            PrisonCells = prisonCellDatas.Select(x => prisonCellViewFactory.Create(new PrisonCell(x))).ToList();
        }
    }
}
