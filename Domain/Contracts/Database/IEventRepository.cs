using Domain;

namespace DAL;

public interface IEventRepository
{
    public Event GetEventById(Guid id);

    public List<Event> GetAllEvents();
    
    public void AddEvent(Event e);

    public void DeleteEvent(Event e);
    
    public void DeleteEventById(Guid id);

    public List<Event>? GetAllPastEvents();

    public List<Event>? GetAllUpcomingEvents();
}