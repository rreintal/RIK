using Domain.Identity;

namespace Domain;

public class Participant : DomainEntityId
{
    public PaymentMethodType PaymentMethodType { get; set; } = default!;
    public ParticipantType ParticipantType { get; set; } = default!;
    
    // Citizen
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? SocialsecurityNumber { get; set; }
    
    // Corporation
    public string? CorporationName { get; set; }
    public string? CorporationCode { get; set; }
    public int? CorporationParcitipationsCount { get; set; }


    public string? Comment { get; set; }
    
    
}