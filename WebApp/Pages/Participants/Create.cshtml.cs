using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages.Participants
{
    public class CreateModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;
        private IParticipantRepository ParticipantRepository { get; set; }

        public CreateModel(DAL.ApplicationDbContext context, IParticipantRepository participantRepository)
        {
            _context = context;
            ParticipantRepository = participantRepository;
        }

        public IActionResult OnGet()
        {
        ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
        ViewData["ParticipantTypeId"] = new SelectList(_context.ParticipantTypes, "Id", "Name");
        ViewData["PaymentMethodTypeId"] = new SelectList(_context.PaymentMethodTypes, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Participant Participant { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Participants == null || Participant == null)
            {
                return Page();
            }

            ParticipantRepository.AddParticipant(Participant);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
