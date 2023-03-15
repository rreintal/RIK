using Domain;

namespace DAL.DB;

public class ParticipantRepository : IParticipantRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ParticipantRepository(ApplicationDbContext db)
    {
        _dbContext = db;
    }
    
    public Participant GetParticipantById(Guid id)
    {
        throw new NotImplementedException();
    }

    public List<Participant> GetParticipantsByEvent(Event e)
    {
        // ERROR HANDLING
        var id = e.Id;
        var result = _dbContext.Participants.Where(i => i.EventId == e.Id).ToList();
        return result;
    }

    public void RemoveParticipantById(Guid id)
    {
        throw new NotImplementedException();
    }

    public void AddParticipant(Participant participant)
    {
        throw new NotImplementedException();
    }
}