using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Events;


public class AddParticipants : PageModel
{
    
    //[BindProperty]
    public Event Event { get; set; } = default!;

    
    [ParticipantValidation]
    [BindProperty]
    public Participant Participant { get; set; } = default!;

    [BindProperty] 
    public Guid EventId { get; set; } = default!;


    [BindProperty]
    public List<Participant> EventParticipants { get; set; } = default!;

    private readonly DAL.ApplicationDbContext _context;


    public AddParticipants(DAL.ApplicationDbContext context)
    {
        _context = context;
        
    }

    
    public IActionResult DeleteParticipant(Guid id)
    {
        var participant = _context.Participants.First(x => x.Id == id);
        _context.Participants.Remove(participant);
        _context.SaveChanges();
        return Redirect($"./AddParticipants?id={EventId}");
    }
    


    public async Task<IActionResult> OnGetAsync(Guid id, string? delete)
    {
        Event = _context.Events.First(x => x.Id == id);
        EventId = id;

        EventParticipants =  _context.Participants
            .Where(p => p.EventId == EventId)
            .Include(p => p.ParticipantType)
            .ToList();
        

            ViewData["PaymentTypes"] = new SelectList(_context.PaymentMethodTypes, "Id", "Name");
        
        if (id == null || _context.Events == null)
        {
            return NotFound();
        }

        var e = await _context.Events.FirstOrDefaultAsync(x => x.Id == id);

        if (e == null)
        {
            return NotFound();
        }
        Event = e;
        return Page();
    }

    public IActionResult OnPost(Guid? id)
    {
        
        // Set type
        if (Participant.IsCompany)
        {
            var type = _context.ParticipantTypes.First(x => x.Name == "Juriidiline isik");
            Participant.ParticipantType = type;
        }
        else
        {
            var type = _context.ParticipantTypes.First(x => x.Name == "Eraisik");
            Participant.ParticipantType = type;
        }
        
        var e = _context.Events.First(x => x.Id == Participant.EventId);
        var payment = _context.PaymentMethodTypes.First(x => x.Id == Participant.PaymentMethodTypeId);
        
        Participant.Event = e;
        Participant.PaymentMethodType = payment;


        
        if (!ModelState.IsValid)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                // Display the error message to the user
                string errorMessage = error.ErrorMessage;
                // Alternatively, you can access the formatted error message using error.Exception.Message
                Console.WriteLine(errorMessage);
            }



            return Redirect($"./AddParticipants?id={id}&status=failed");
        }

        
        _context.Participants.Add(Participant);
        _context.SaveChanges();

        return RedirectToPage("../Index");
    }

}