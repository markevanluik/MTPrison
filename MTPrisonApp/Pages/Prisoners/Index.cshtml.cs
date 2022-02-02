#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class IndexModel : PageModel
    {
        private readonly MTPrisonApp.Data.ApplicationDbContext _context;

        public IndexModel(MTPrisonApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PrisonerView> Prisoners { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Offenses { get; set; }

        [BindProperty(SupportsGet = true)]
        public string PrisonerOffense { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> offenseQuery = from m in _context.Prisoners
                                            orderby m.Offense
                                            select m.Offense;
            var prisoners = from m in _context.Prisoners
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
