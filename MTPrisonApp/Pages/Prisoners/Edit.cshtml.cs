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

namespace MTPrisonApp.Pages.Prisoners
{
    public class EditModel : PageModel
    {
        private readonly MTPrisonApp.Data.ApplicationDbContext _context;

        public EditModel(MTPrisonApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Prisoner Prisoner { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Prisoner = await _context.Prisoner.FirstOrDefaultAsync(m => m.Id == id);

            if (Prisoner == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Prisoner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return RedirectToPage("./Index");
        }

        private bool PrisonerExists(string id)
        {
            return _context.Prisoner.Any(e => e.Id == id);
        }
    }
}
