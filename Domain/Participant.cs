using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Identity;

namespace Domain;

public class Participant : DomainEntityId
{
    [Required]
    public bool IsCompany { get; set; } = default!;
    
    
    [DisplayName("Makseviis:")]
    public Guid PaymentMethodTypeId { get; set; }
    public PaymentMethodType? PaymentMethodType { get; set; } = default!;
    
    [ForeignKey("ParticipantTypeId")]
    public Guid ParticipantTypeId { get; set; }
    
    public ParticipantType? ParticipantType { get; set; } = default!;
    
    public Guid EventId { get; set; }
    public Event? Event { get; set; } = default!;
    
    // Citizen
    [MinLength(2)]
    [MaxLength(50)]
    [DisplayName("Eesnimi:")]
    [ParticipantValidation]
    public string? FirstName { get; set; }
    
    [MinLength(2)]
    [MaxLength(50)]
    [DisplayName("Perekonnanimi:")]
    [ParticipantValidation]
    public string? LastName { get; set; }
    
    [MinLength(11)]
    [MaxLength(11)]
    [DisplayName("Isikukood:")]
    [ParticipantValidation]
    public string? SocialsecurityNumber { get; set; }
    
    // Corporation
    [MinLength(3)]
    [MaxLength(100)]
    [DisplayName("Ettevõtte nimi:")]
    [ParticipantValidation]
    public string? CorporationName { get; set; }
    
    [ParticipantValidation]
    [DisplayName("Registrikood:")]
    public string? CorporationCode { get; set; }
    
    [DisplayName("Osavõtjate arv:")]
    [Range(1, int.MaxValue)]
    [ParticipantValidation]
    public int? CorporationParcitipationsCount { get; set; }


    [DisplayName("Lisainfo:")]
    public string? Comment { get; set; }
    
}

public class ParticipantValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        var participant = value as Participant;

        if (participant == null)
        {
            return true;
        }

        if (participant.IsCompany)
        {
            if (string.IsNullOrEmpty(participant.CorporationName))
            {
                ErrorMessage = "Ettevõtte nimi on kohustuslik.";
                return false;
            }

            if (string.IsNullOrEmpty(participant.CorporationCode))
            {
                ErrorMessage = "Registrikood on kohustuslik.";
                return false;
            }

            if (participant.CorporationParcitipationsCount == null || participant.CorporationParcitipationsCount < 1)
            {
                ErrorMessage = "Osavõtjate arv peab olema vähemalt 1.";
                return false;
            }

            if (participant.Comment != null)
            {
                if (participant.Comment.Length > 5000)
                {
                    ErrorMessage = "Kommentaari maksimum pikkus on 5000 tähemärki";
                    return false;
                }
            }
        }
        else
        {
            // If IsCompany is false, validate the Citizen properties.
            if (string.IsNullOrEmpty(participant.FirstName))
            {
                ErrorMessage = "Eesnimi on kohustuslik.";
                return false;
            }

            if (string.IsNullOrEmpty(participant.LastName))
            {
                ErrorMessage = "Perekonnanimi on kohustuslik.";
                return false;
            }

            if (string.IsNullOrEmpty(participant.SocialsecurityNumber))
            {
                ErrorMessage = "Isikukood on kohustuslik.";
                return false;
            }
            if (participant.Comment != null)
            {
                if (participant.Comment.Length > 1000)
                {
                    ErrorMessage = "Kommentaari maksimum pikkus on 1000 tähemärki";
                    return false;
                }
            }
        }

        return true;
    }
}
