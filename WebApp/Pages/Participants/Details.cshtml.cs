using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Participants
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public DetailsModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

      public Participant Participant { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = await _context.Participants.FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }
            else 
            {
                Participant = participant;
            }
            return Page();
        }
    }
}
