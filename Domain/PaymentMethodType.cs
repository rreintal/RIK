using Domain.Identity;

namespace Domain;

public class PaymentMethodType : DomainEntityId
{
    public string Name { get; set; } = default!;
}