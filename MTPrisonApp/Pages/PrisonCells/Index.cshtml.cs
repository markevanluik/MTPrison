#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.PrisonCells
{
    public class IndexModel : PageModel
    {
        private readonly MTPrisonApp.Data.ApplicationDbContext _context;

        public IndexModel(MTPrisonApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PrisonCell> PrisonCell { get;set; }

        public SelectList Sections { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PrisonCellSection { get; set; }
        public SelectList Types { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PrisonCellType { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> sectionQuery = from m in _context.PrisonCell
                                              orderby m.Section
                                              select m.Section;
            IQueryable<string> typeQuery = from m in _context.PrisonCell
                                              orderby m.Type
                                              select m.Type;
            var prisonCells = from m in _context.PrisonCell
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
            PrisonCell = await prisonCells.ToListAsync();
        }
    }
}
