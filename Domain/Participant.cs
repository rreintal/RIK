using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
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
    [ParticipantValidation]
    [DisplayName("Eesnimi:")]
    public string? FirstName { get; set; }
    
    [DisplayName("Perekonnanimi:")]
    [ParticipantValidation]
    public string? LastName { get; set; }
    
    [DisplayName("Isikukood:")]
    [ParticipantValidation]
    public string? SocialsecurityNumber { get; set; }
    
    // Corporation
    [DisplayName("Ettevõtte nimi:")]
    [ParticipantValidation]
    public string? CorporationName { get; set; }
    
    [ParticipantValidation]
    [DisplayName("Registrikood:")]
    public string? CorporationCode { get; set; }
    
    [DisplayName("Osavõtjate arv:")]
    [ParticipantValidation]
    public int? CorporationParcitipationsCount { get; set; }


    [DisplayName("Lisainfo:")]
    public string? Comment { get; set; }
    
    public static bool IsValidEstonianSocialSecurityNumber(string ssn)
    {
        if (!Regex.IsMatch(ssn, @"^\d{11}$"))
        {
            return false;
        }

        int[] multiplier_1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
        int[] multiplier_2 = new int[] { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };

        int total = 0;

        for (int i = 0; i < ssn.Length - 1; i++)
        {
            total += int.Parse(ssn[i].ToString()) * multiplier_1[i];
        }
        int mod = total % 11;

        total = 0;
        if (10 == mod)
        {
            for (int i = 0; i < 10; i++)
            {
                total += int.Parse(ssn[i].ToString()) * multiplier_2[i];
            }
            mod = total % 11;

            if (10 == mod)
            {
                mod = 0;
            }
        }

        return mod == (int)char.GetNumericValue(ssn[10]);
    }

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
                ErrorMessage = "Ettev6tte nimi on kohustuslik.";
                return false;
            }

            
             if (participant.CorporationName.Length < 3)
            {
                ErrorMessage = "Ettev6tte nimi peab olema v2hemalt 3 t2hem2rki.";
                return false;
            }
            
            if (participant.CorporationName.Length > 100)
            {
                ErrorMessage = "Ettev6tte nimi peab olema v2hem kui 100 t2hem2rki.";
                return false;
            }
             

            if (string.IsNullOrEmpty(participant.CorporationCode))
            {
                ErrorMessage = "Registrikood on kohustuslik.";
                return false;
            }

            if (participant.CorporationParcitipationsCount == null || participant.CorporationParcitipationsCount < 1)
            {
                ErrorMessage = "Osav6tjate arv peab olema v2hemalt 1.";
                return false;
            }

            if (participant.Comment != null)
            {
                if (participant.Comment.Length > 5000)
                {
                    ErrorMessage = "Kommentaari maksimum pikkus on 5000 t2hem2rki";
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

            if (participant.FirstName.Length < 2)
            {
                ErrorMessage = "Eesnimi peab olema v2hemalt kaks t2hem2rki.";
                return false;
            }
            if (participant.FirstName.Length > 50)
            {
                ErrorMessage = "Eesnimi v6ib olla maksimaalselt 50 t2hem2rki.";
                return false;
            }

            if (string.IsNullOrEmpty(participant.LastName))
            {
                ErrorMessage = "Perekonnanimi on kohustuslik.";
                return false;
            }
            
            if (participant.LastName.Length < 2)
            {
                ErrorMessage = "Perekonnanimi peab olema v2hemalt kaks t2hem2rki.";
                return false;
            }
            if (participant.LastName.Length > 50)
            {
                ErrorMessage = "Perekonnanimi võib olla maksimaalselt 50 t2hem2rki.";
                return false;
            }

            if (string.IsNullOrEmpty(participant.SocialsecurityNumber))
            {
                ErrorMessage = "Isikukood on kohustuslik.";
                return false;
            }

            if (!Participant.IsValidEstonianSocialSecurityNumber(participant.SocialsecurityNumber))
            {
                ErrorMessage = "Isikukood ei ole korrektne.";
                return false;
            }
            if (participant.Comment != null)
            {
                if (participant.Comment.Length > 1000)
                {
                    ErrorMessage = "Kommentaari maksimum pikkus on 1000 t2hem2rki";
                    return false;
                }
            }
        }

        return true;
    }
}
