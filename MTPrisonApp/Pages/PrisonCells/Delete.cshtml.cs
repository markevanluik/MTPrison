#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.PrisonCells
{
    public class DeleteModel : PageModel
    {
        private readonly MTPrisonApp.Data.ApplicationDbContext _context;

        public DeleteModel(MTPrisonApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PrisonCell PrisonCell { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PrisonCell = await _context.PrisonCell.FirstOrDefaultAsync(m => m.Id == id);

            if (PrisonCell == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PrisonCell = await _context.PrisonCell.FindAsync(id);

            if (PrisonCell != null)
            {
                _context.PrisonCell.Remove(PrisonCell);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
