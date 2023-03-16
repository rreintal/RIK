using Domain;

namespace DAL;

public interface IPaymentMethodTypeRepository
{
    public PaymentMethodType GetPaymentMethodTypeById(Guid id);

    public void AddPaymentMethodType(PaymentMethodType p);
    
    public void DeletePaymentMethodType(PaymentMethodType p);
}