using Domain.Identity;

namespace Domain;

public class ParticipantType : DomainEntityId
{
    public string Name { get; set; } = default!;
}