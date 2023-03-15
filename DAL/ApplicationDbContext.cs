using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Event> Events { get; set; } = default!;
    public DbSet<Participant> Participants { get; set; } = default!;

    public DbSet<ParticipantType> ParticipantTypes { get; set; } = default!;

    public DbSet<PaymentMethodType> PaymentMethodTypes { get; set; } = default!;

    //public DbSet<PaymentMethodType> PaymentMethodTypes { get; set; } = default!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    


}