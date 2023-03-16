using Domain;

namespace DAL;

public interface IParticipantTypeRepository
{
    public ParticipantType GetParticipantTypeByName(string name);
    
    
}