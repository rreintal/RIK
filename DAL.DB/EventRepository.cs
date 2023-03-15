using Domain;

namespace DAL.DB;

public class EventRepository : IEventRepository
{
    
    private readonly ApplicationDbContext _dbContext;

    public EventRepository(ApplicationDbContext db)
    {
        _dbContext = db;
    }
    
    
    public Event GetEventById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Event> GetAllEvents()
    {
        return _dbContext.Events.ToList();
    }

    public void AddEvent(Event e)
    {
        throw new NotImplementedException();
    }

    public void DeleteEventById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Event> GetAllPastEvents()
    {
        var events = _dbContext.Events.Where(x => x.EventStartTime < DateTime.Now).ToList();
        return events;
    }

    public List<Event> GetAllUpcomingEvents()
    {
        var events = _dbContext.Events.Where(x => x.EventStartTime > DateTime.Now).ToList();
        return events;
    }
}