using DAL;
using Domain;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests_xUnit.DAL;

public class TestDAL
{
    [Fact]
    public void CanAddPaymentType()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MyDatabase")
            .Options;

        using var dbContext = new DbMock(options);

        var typeName = "NAME";
        var entity = new ParticipantType()
        {
            Name = typeName
        };

        dbContext.ParticipantTypes.Add(entity);
        dbContext.SaveChanges();

        var result = dbContext.ParticipantTypes.First(x => x.Name == typeName);
        
        Assert.Equal(typeName, result.Name);
    }


    [Fact]
    public void CanAddEvent()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MyDatabase")
            .Options;

        using var dbContext = new DbMock(options);

        var eventId = Guid.NewGuid();
        var eventName = "Vabariigi aastapäev";
        var eventPlace = "Vabaduse Väljak";
        var eventDate = DateTime.Now;
        var comment = "content";
        
        var entity = new Event
        {
            Id = eventId,
            Name = eventName,
            Place = eventPlace,
            EventStartTime = eventDate,
            Comment = comment
        };
        
        dbContext.Events.Add(entity);
        dbContext.SaveChanges();

        var result = dbContext.Events.First(x => x.Id == eventId);
        
        Assert.Equal(eventId, result.Id);
        Assert.Equal(eventName, result.Name);
        Assert.Equal(eventPlace, result.Place);
        Assert.Equal(eventDate, result.EventStartTime);
        Assert.Equal(comment, result.Comment);
    }

    [Fact]
    public void CanAddPaymentMethodType()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MyDatabase")
            .Options;

        using var dbContext = new DbMock(options);

        var typeName = "Krüptoraha";
        
        var paymentMethodType = new PaymentMethodType
        {
            Name = typeName
        };

        dbContext.PaymentMethodTypes.Add(paymentMethodType);
        dbContext.SaveChanges();

        var result = dbContext.PaymentMethodTypes.First(x => x.Name == typeName);
        
        Assert.Equal(typeName, result.Name);
    }

    [Fact]
    public void CanAddParticipantToEvent()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "MyDatabase")
            .Options;

        using var dbContext = new DbMock(options);

        var Event = new Event
        {
            Name = "Name",
            Place = "Place",
            EventStartTime = DateTime.Now,
        };

        var paymentType = new PaymentMethodType
        {
            Name = "Sularaha"
        };

        var participantType = new ParticipantType
        {
            Name = "Eraisik"
        };
        dbContext.Events.Add(Event);
        dbContext.PaymentMethodTypes.Add(paymentType);
        dbContext.ParticipantTypes.Add(participantType);
        dbContext.SaveChanges();

        var eventId = Event.Id;
        var paymentTypeId = paymentType.Id;
        var participantTypeId = participantType.Id;

        var participant = new Participant
        {
            IsCompany = false,
            PaymentMethodTypeId = paymentTypeId,
            ParticipantTypeId = participantTypeId,
            EventId = eventId,
            Event = Event,
            FirstName = "Paul",
            LastName = "Kask",
            SocialsecurityNumber = "50110312761",
        };

        dbContext.Participants.Add(participant);
        dbContext.SaveChanges();

        var eventParticipantsCount = dbContext
            .Events
            .Where(x => x.Id == eventId)
            .Include(x => x.EventParticipants)
            .First().EventParticipants!.Count;
        
        Assert.Equal(1, eventParticipantsCount);
    }
}






