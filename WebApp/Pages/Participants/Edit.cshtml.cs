using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Participants
{
    public class EditModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;
        private IParticipantRepository ParticipantRepository { get; set; }

        public EditModel(DAL.ApplicationDbContext context, IParticipantRepository participantRepository)
        {
            _context = context;
            ParticipantRepository = participantRepository;
        }

        [BindProperty]
        public Participant Participant { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Participants == null)
            {
                return NotFound();
            }

            var participant = ParticipantRepository.GetParticipantById(id.Value);
            if (participant == null)
            {
                return NotFound();
            }
            Participant = participant;
           ViewData["EventId"] = new SelectList(_context.Events, "Id", "Name");
           ViewData["ParticipantTypeId"] = new SelectList(_context.ParticipantTypes, "Id", "Name");
           ViewData["PaymentMethodTypeId"] = new SelectList(_context.PaymentMethodTypes, "Id", "Name");
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

            _context.Attach(Participant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParticipantExists(Participant.Id))
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

        private bool ParticipantExists(Guid id)
        {
          return (_context.Participants?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
