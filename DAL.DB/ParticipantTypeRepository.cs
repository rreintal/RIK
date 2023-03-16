using Domain;

namespace DAL.DB;

public class ParticipantTypeRepository : IParticipantTypeRepository
{
    
    private readonly ApplicationDbContext _dbContext;

    public ParticipantTypeRepository(ApplicationDbContext db)
    {
        _dbContext = db;
    }
    
    public ParticipantType GetParticipantTypeByName(string name)
    {
        return _dbContext.ParticipantTypes.First(x => x.Name == name);
    }
}