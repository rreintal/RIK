using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DAL;
using Domain;

namespace WebApp.Pages.PaymentMethodTypes
{
    public class CreateModel : PageModel
    {
        private readonly DAL.ApplicationDbContext _context;
        private IPaymentMethodTypeRepository PaymentMethodTypeRepository { get; set; }

        public CreateModel(DAL.ApplicationDbContext context, IPaymentMethodTypeRepository paymentMethodTypeRepository)
        {
            _context = context;
            PaymentMethodTypeRepository = paymentMethodTypeRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PaymentMethodType PaymentMethodType { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.PaymentMethodTypes == null || PaymentMethodType == null)
            {
                return Page();
            }
            PaymentMethodTypeRepository.AddPaymentMethodType(PaymentMethodType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
