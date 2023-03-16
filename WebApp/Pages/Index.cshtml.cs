using DAL;
using DAL.DB;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly IEventRepository _eventRepository;
    private readonly IParticipantRepository _participantRepository;
    public List<Event> Events = default!;


    public List<Event> PastEvents = default!;
    
    public List<Event> UpcomingEvents = default!;

    public Dictionary<Event, List<Participant>> EventWithAttendants = new Dictionary<Event, List<Participant>>();



    public IndexModel(IEventRepository eventRepository, IParticipantRepository participantRepository)
    {
        _eventRepository = eventRepository;
        _participantRepository = participantRepository;
        // Events pole vaja sest past + upcoming = events
        
        PastEvents = eventRepository.GetAllPastEvents();
        Events = eventRepository.GetAllEvents();

        foreach (var e in Events)
        {
            var participants =  _participantRepository.GetParticipantsByEvent(e);
            e.EventParticipants = participants;
        }
        
        UpcomingEvents = eventRepository.GetAllUpcomingEvents();
        
    }

    public void OnGet()
    {
        
    }
}