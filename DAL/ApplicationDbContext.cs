using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class ApplicationDbContext : DbContext
{
    public DbSet<Event> Events { get; set; } = default!;
    public DbSet<Participant> Participants { get; set; } = default!;

    public DbSet<ParticipantType> ParticipantTypes { get; set; } = default!;

    public DbSet<PaymentMethodType> PaymentMethodTypes { get; set; } = default!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ParticipantType>().HasData(
            new ParticipantType {  Name = "Eraisik" },
            new ParticipantType {  Name = "Juriidiline isik" }
        );

        modelBuilder.Entity<PaymentMethodType>().HasData(
            new PaymentMethodType
            {
                Name = "Sularaha"
            },
            new PaymentMethodType
            {
                Name = "Ülekanne"
            });

    }
    



}