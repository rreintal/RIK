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
    public class DetailsModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public DetailsModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

      public Event Event { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var e = await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
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
    }
}
