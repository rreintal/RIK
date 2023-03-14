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
    public class DeleteModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public DeleteModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public ParticipantType ParticipantType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.ParticipantTypes == null)
            {
                return NotFound();
            }

            var participanttype = await _context.ParticipantTypes.FirstOrDefaultAsync(m => m.Id == id);

            if (participanttype == null)
            {
                return NotFound();
            }
            else 
            {
                ParticipantType = participanttype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null || _context.ParticipantTypes == null)
            {
                return NotFound();
            }
            var participanttype = await _context.ParticipantTypes.FindAsync(id);

            if (participanttype != null)
            {
                ParticipantType = participanttype;
                _context.ParticipantTypes.Remove(ParticipantType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
