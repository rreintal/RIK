using Domain;

namespace DAL.DB;

public class PaymentMethodTypeRepository : IPaymentMethodTypeRepository
{
    private readonly ApplicationDbContext _dbContext;

    public PaymentMethodTypeRepository(ApplicationDbContext db)
    {
        _dbContext = db;
    }
    
    public PaymentMethodType GetPaymentMethodTypeById(Guid id)
    {
        return _dbContext.PaymentMethodTypes.First(x => x.Id == id);
    }

    public void AddPaymentMethodType(PaymentMethodType p)
    {
        _dbContext.PaymentMethodTypes.Add(p);
        _dbContext.SaveChanges();
    }

    public void DeletePaymentMethodType(PaymentMethodType p)
    {
        _dbContext.PaymentMethodTypes.Remove(p);
        _dbContext.SaveChanges();
    }
}