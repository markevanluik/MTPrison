using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTPrison.Data.Party;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.Cells
{
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public class CellsPage : PageModel
    {
        private readonly ApplicationDbContext context;
        [BindProperty] public CellView Cell { get; set; }
        public IList<CellView> Cells { get; set; }
        public SelectList Sections { get; set; }
        [BindProperty(SupportsGet = true)] public string? CellSection { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)] public string? CellType { get; set; }
        public CellsPage(ApplicationDbContext c) => context = c;
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
            var d = new CellViewFactory().Create(Cell).Data;
            context.Cells.Add(d);
            await context.SaveChangesAsync();

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetDetailsAsync(string id)
        {
            Cell = await GetCell(id);
            return Page();
        }
        private async Task<CellView> GetCell(string id)
        {
            if (id == null) return null;
            var d = await context.Cells.FirstOrDefaultAsync(m => m.Id == id);
            if (d == null) return null;
            return new CellViewFactory().Create(new Cell(d));
        }
        public async Task<IActionResult> OnGetDeleteAsync(string id)
        {
            Cell = await GetCell(id);
            return Page();
        }
        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await context.Cells.FindAsync(id);

            if (d != null)
            {
                context.Cells.Remove(d);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", "Index");
        }
        public async Task<IActionResult> OnGetEditAsync(string id)
        {
            Cell = await GetCell(id);
            return Page();
        }
        public async Task<IActionResult> OnPostEditAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            context.Attach(new CellViewFactory().Create(Cell).Data).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CellExists(Cell.Id))
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
        private bool CellExists(string id)
            => context.Cells.Any(e => e.Id == id);
        public async Task OnGetIndexAsync()
        {
            IQueryable<string> sectionQuery = from m in context.Cells
                                              orderby m.Section
                                              select m.Section;
            IQueryable<string> typeQuery = from m in context.Cells
                                           orderby m.Type
                                           select m.Type;
            var prisonCells = from m in context.Cells
                              select m;
            if (!string.IsNullOrEmpty(CellSection))
            {
                prisonCells = prisonCells.Where(x => x.Section == CellSection);
            }
            if (!string.IsNullOrEmpty(CellType))
            {
                prisonCells = prisonCells.Where(x => x.Type == CellType);
            }
            Sections = new SelectList(await sectionQuery.Distinct().ToListAsync());
            Types = new SelectList(await typeQuery.Distinct().ToListAsync());
            List<CellData> prisonCellDatas = await prisonCells.ToListAsync();
            CellViewFactory prisonCellViewFactory = new CellViewFactory();
            Cells = prisonCellDatas.Select(x => prisonCellViewFactory.Create(new Cell(x))).ToList();
        }
    }
}
