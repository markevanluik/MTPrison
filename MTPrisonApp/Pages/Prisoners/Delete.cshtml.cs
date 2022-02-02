#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MTPrison.Domain.Party;
using MTPrison.Facade.Party;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.Prisoners
{
    public class DeleteModel : PageModel
    {
        private readonly MTPrisonApp.Data.ApplicationDbContext _context;

        public DeleteModel(MTPrisonApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PrisonerView Prisoner { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await _context.Prisoners.FirstOrDefaultAsync(m => m.Id == id);

            if (d == null)
            {
                return NotFound();
            }

            Prisoner = new PrisonerViewFactory().Create(new Prisoner(d));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var d = await _context.Prisoners.FindAsync(id);

            if (d != null)
            {
                _context.Prisoners.Remove(d);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
