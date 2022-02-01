#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.Prisoners
{
    public class CreateModel : PageModel
    {
        private readonly MTPrisonApp.Data.ApplicationDbContext _context;

        public CreateModel(MTPrisonApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Prisoner Prisoner { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Prisoner.Add(Prisoner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
