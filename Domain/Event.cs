using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Identity;

namespace Domain;

public class Event : DomainEntityId
{
    
    [MinLength(2)]
    [MaxLength(50)]
    [DisplayName("Ürituse nimi:")]
    public string Name { get; set; } = default!;

    [DisplayName("Koht:")]
    public string Place { get; set; } = default!;
    
    [DisplayName("Toimumisaeg:")]
    public DateTime EventStartTime { get; set; } = default!;

    public ICollection<Participant>? EventParticipants { get; set; }
    [DisplayName("Lisainfo:")]
    public string? Comment { get; set; }

}