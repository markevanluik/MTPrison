#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MTPrisonApp.Data;

namespace MTPrisonApp.Pages.Prisoners
{
    public class DetailsModel : PageModel
    {
        private readonly MTPrisonApp.Data.ApplicationDbContext _context;

        public DetailsModel(MTPrisonApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
