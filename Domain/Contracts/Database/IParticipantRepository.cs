using Domain;

namespace DAL;

public interface IParticipantRepository
{
    public Participant GetParticipantById(Guid id);

    public List<Participant> GetParticipantsByEvent(Event e);

    public void RemoveParticipantById(Guid id);

    public void AddParticipant(Participant participant);
}