using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Events;

public class AddParticipants : PageModel
{
    
    [BindProperty]
    public Event Event { get; set; } = default!;

    [BindProperty]
    public Participant Participant { get; set; } = default!;

    private readonly DAL.ApplicationDbContext _context;

    public AddParticipants(DAL.ApplicationDbContext context)
    {
        _context = context;
    }
    
    
    public async Task<IActionResult> OnGetAsync(Guid? id)
    {
        
        if (id == null || _context.Events == null)
        {
            return NotFound();
        }

        var e =  await _context.Events.FirstOrDefaultAsync(m => m.Id == id);
        
        if (e == null)
        {
            return NotFound();
        }
        Event = e;
        return Page();
    }

    public IActionResult OnPost(Participant participant)
    {
        //ebcad8df-73f7-4219-a785-2f0ce9fbfe63
        var ev = _context.Events.First(x => x.Id == Event.Id);
        var type = _context.ParticipantTypes.First(x => x.Name == "Eraisik");

        Console.WriteLine($"TYPE ID IS: {type.Id}");
        
        participant.Event = ev;
        participant.EventId = ev.Id;
        
        participant.ParticipantType = type;
        participant.ParticipantTypeId = type.Id;
        
        _context.Participants.Add(participant);
        _context.SaveChanges();

        return Redirect($"AddParticipants?id={ev.Id}");
    }

}