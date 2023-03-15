using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DAL;
using Domain;

namespace WebApp.Pages.PaymentMethodTypes
{
    public class DetailsModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;

        public DetailsModel(DAL.ApplicationDbContext context)
        {
            _context = context;
        }

      public PaymentMethodType PaymentMethodType { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null || _context.PaymentMethodTypes == null)
            {
                return NotFound();
            }

            var paymentmethodtype = await _context.PaymentMethodTypes.FirstOrDefaultAsync(m => m.Id == id);
            if (paymentmethodtype == null)
            {
                return NotFound();
            }
            else 
            {
                PaymentMethodType = paymentmethodtype;
            }
            return Page();
        }
    }
}
