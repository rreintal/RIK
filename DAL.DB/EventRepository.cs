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
        return _dbContext.Events.First(x => x.Id == id);
    }

    public List<Event> GetAllEvents()
    {
        return _dbContext.Events.ToList();
    }

    public void AddEvent(Event e)
    {
        _dbContext.Events.Add(e);
    }

    public void DeleteEvent(Event e)
    {
        _dbContext.Remove(e);
    }

    public void DeleteEventById(Guid id)
    {
        _dbContext.Events.Remove(GetEventById(id));
        _dbContext.SaveChanges();
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