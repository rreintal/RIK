using Domain.Identity;

namespace Domain;

public class Event : DomainEntityId
{
    public string Name { get; set; } = default!;
    public DateTime EventStartTime { get; set; } = default!;

    public ICollection<Participant>? EventParticipants { get; set; }
    
    public string? Comment { get; set; }

}