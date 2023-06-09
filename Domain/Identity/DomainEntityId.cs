namespace Domain.Identity;

public abstract class DomainEntityId : IDomainEntityId<Guid>
{
    public Guid Id { get; set; } = Guid.NewGuid();
}


public interface IDomainEntityId<TKey>
{
    TKey Id { get; set; }
}