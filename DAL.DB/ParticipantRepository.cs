using Domain;
using Microsoft.EntityFrameworkCore;

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
        return _dbContext.Participants
            .Where(x => x.Id == id)
            .First();
    }

    public List<Participant> GetParticipantsByEvent(Event e)
    {
        var id = e.Id;
        var result = _dbContext.Participants.Where(i => i.EventId == e.Id).ToList();
        return result;
    }

    public void RemoveParticipantById(Guid id)
    {
        _dbContext.Participants.Remove(GetParticipantById(id));
        _dbContext.SaveChanges();
    }

    public void AddParticipant(Participant participant)
    {
        _dbContext.Participants.Add(participant);
        _dbContext.SaveChanges();
    }

    public void DeleteParticipant(Participant p)
    {
        _dbContext.Participants.Remove(p);
        _dbContext.SaveChanges();
    }
}