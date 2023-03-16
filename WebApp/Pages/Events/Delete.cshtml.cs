using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.Events
{
    public class DeleteModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;
        
        private IEventRepository EventRepository { get; set; }

        public DeleteModel(DAL.ApplicationDbContext context, IEventRepository eventRepository)
        {
            _context = context;
            EventRepository = eventRepository;
        }

        [BindProperty]
      public Event Event { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var e = EventRepository.GetEventById(id);

            if (e == null)
            {
                return NotFound();
            }
            else 
            {
                Event = e;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }
            var e = EventRepository.GetEventById(id);

            if (e != null)
            {
                Event = e;
                EventRepository.DeleteEvent(Event);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../Index");
        }
    }
}
