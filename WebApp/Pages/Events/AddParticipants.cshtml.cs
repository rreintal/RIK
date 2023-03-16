using DAL;
using DAL.DB;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
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
    
    private IParticipantRepository ParticipantRepository { get; set; }
    private IEventRepository EventRepository { get; set; }
    
    private IParticipantTypeRepository ParticipantTypeRepository { get; set; }
    
    private IPaymentMethodTypeRepository PaymentMethodTypeRepository { get; set; }


    public AddParticipants(DAL.ApplicationDbContext context, 
        IParticipantRepository participantRepository, 
        IEventRepository eventRepository, 
        IParticipantTypeRepository participantTypeRepository,
        IPaymentMethodTypeRepository paymentMethodTypeRepository)
    {
        _context = context;
        ParticipantRepository = participantRepository;
        EventRepository = eventRepository;
        ParticipantTypeRepository = participantTypeRepository;
        PaymentMethodTypeRepository = paymentMethodTypeRepository;

    }

    public async Task<IActionResult> OnGetAsync(Guid id, string? delete)
    {
        Event = EventRepository.GetEventById(id);
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
        
        if (Event == null)
        {
            return NotFound();
        }
        return Page();
        
    }

    public IActionResult OnPost(Guid? id)
    {
        
        // Set type
        if (Participant.IsCompany)
        {
            var type = ParticipantTypeRepository.GetParticipantTypeByName("Juriidiline isik");
            Participant.ParticipantType = type;
        }
        else
        {
            var type = ParticipantTypeRepository.GetParticipantTypeByName("Eraisik");
            Participant.ParticipantType = type;
        }
        
        var e = EventRepository.GetEventById(Participant.EventId);
        
        var payment = PaymentMethodTypeRepository.GetPaymentMethodTypeById(Participant.PaymentMethodTypeId);
        
        Participant.Event = e;
        Participant.PaymentMethodType = payment;


        
        if (!ModelState.IsValid)
        {
            var errorString = "";
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                string errorMessage = error.ErrorMessage;
                errorString = errorMessage;
            }

            // et õige form oleks avatud!
            if (Participant.IsCompany)
            {
                return Redirect($"./AddParticipants?id={id}&status=failed&errors={errorString}&formtype=corporation");
            }
            return Redirect($"./AddParticipants?id={id}&status=failed&errors={errorString}");
            
        }

        ParticipantRepository.AddParticipant(Participant);
        _context.SaveChanges();
        return RedirectToPage($"../Index");
    }

}