using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using DAL.DB;
using Domain;

namespace WebApp.Pages.Events
{
    
    public class CreateModel : PageModel
    {
        
        private readonly DAL.ApplicationDbContext _context;
        private IEventRepository EventRepository;

        public CreateModel(DAL.ApplicationDbContext context, IEventRepository eventRepository)
        {
            _context = context;
            EventRepository = eventRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Events == null || Event == null)
            {
                return Page();
            }
            EventRepository.AddEvent(Event);
            await _context.SaveChangesAsync();

            return RedirectToPage("../Index");
        }
    }
}
