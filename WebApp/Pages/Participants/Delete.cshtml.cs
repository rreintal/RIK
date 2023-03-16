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
    public class DeleteModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;
        private IParticipantRepository ParticipantRepository { get; set; }

        public DeleteModel(DAL.ApplicationDbContext context, IParticipantRepository participantRepository)
        {
            _context = context;
            ParticipantRepository = participantRepository;
        }

        [BindProperty]
      public Participant Participant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = ParticipantRepository.GetParticipantById(id);

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

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }
            var participant = ParticipantRepository.GetParticipantById(id);

            if (participant != null)
            {
                Participant = participant;
                ParticipantRepository.DeleteParticipant(Participant);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
