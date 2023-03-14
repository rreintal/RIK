using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Types
{
    public class IndexModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public IndexModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ParticipantType> ParticipantType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ParticipantTypes != null)
            {
                ParticipantType = await _context.ParticipantTypes.ToListAsync();
            }
        }
    }
}
