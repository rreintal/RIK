using Domain;
using Xunit;

namespace Tests_xUnit;

public class TestParticipantValidation
{
    [Fact]
    public void ValidCitizienParticipant()
    {
        // Arrange
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "John",
            LastName = "Doe",
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();

        // Act
        var result = validationAttribute.IsValid(participant);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void ValidCitizenFirstNameLength()
    {
        // First name length must be 2 <= n <= 50
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "12",
            LastName = "Abc",
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.True(result);
    }
    
    [Fact]
    public void ValidCitizenLastNameLength()
    {
        // Last name length must be 2 <= n <= 50
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "12",
            LastName = "Ab",
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.True(result);
    }
    
    [Fact]
    public void CitizenFirstNameTooShort()
    {
        // First name length must be 2 <= n <= 50
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "1",
            LastName = "Ab",
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }
    
    [Fact]
    public void CitizenFirstNameTooLong()
    {
        var lastName = "";
        for (var i = 1; i <= 51; i++)
        {
            lastName += "a";
        }
        // First name length must be 2 <= n <= 50
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "1",
            LastName = lastName,
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }
    
    [Fact]
    public void CitizenLastNameTooShort()
    {
        // Last name length must be 2 <= n <= 50
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "1aaaa",
            LastName = "A",
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }
    
    [Fact]
    public void CitizenLastNameTooLong()
    {
        var lastName = "";
        for (var i = 1; i <= 51; i++)
        {
            lastName += "a";
        }
        // Last name length must be 2 <= n <= 50
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "1aaaa",
            LastName = lastName,
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }
    
    [Fact]
    public void ValidCitizenComment()
    {
        var comment = "";
        for (var i = 1; i <= 1000; i++)
        {
            comment += "a";
        }
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "1aaaa",
            LastName = "aaa",
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = comment
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.True(result);
    }
    
    [Fact]
    public void InvalidCitizenComment()
    {
        var comment = "";
        for (var i = 1; i <= 1001; i++)
        {
            comment += "a";
        }
        var participant = new Participant
        {
            IsCompany = false,
            FirstName = "1aaaa",
            LastName = "aaa",
            SocialsecurityNumber = "50110312761",
            CorporationName = null,
            CorporationCode = null,
            CorporationParcitipationsCount = null,
            Comment = comment
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }
    
    [Fact]
    public void ValidCorporationComment()
    {
        var comment = "";
        for (var i = 1; i <= 5000; i++)
        {
            comment += "a";
        }
        var participant = new Participant
        {
            IsCompany = true,
            FirstName = null,
            LastName = null,
            SocialsecurityNumber = null,
            CorporationName = "abc",
            CorporationCode = "abc",
            CorporationParcitipationsCount = 1,
            Comment = comment
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.True(result);
    }
    
    [Fact]
    public void InvalidCorporationComment()
    {
        var comment = "";
        for (var i = 1; i <= 5001; i++)
        {
            comment += "a";
        }
        var participant = new Participant
        {
            IsCompany = true,
            FirstName = null,
            LastName = null,
            SocialsecurityNumber = null,
            CorporationName = "abc",
            CorporationCode = "abc",
            CorporationParcitipationsCount = 1,
            Comment = comment
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }

    [Fact]
    public void ValidCorporationName()
    {
        var participant = new Participant
        {
            IsCompany = true,
            FirstName = null,
            LastName = null,
            SocialsecurityNumber = null,
            CorporationName = "abcde",
            CorporationCode = "abc",
            CorporationParcitipationsCount = 1,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.True(result);
    }
    
    [Fact]
    public void CorporationNameTooShort()
    {
        var name = "";
        for (int i = 1; i <= 2; i++)
        {
            name += "a";
        }
        
        var participant = new Participant
        {
            IsCompany = true,
            FirstName = null,
            LastName = null,
            SocialsecurityNumber = null,
            CorporationName = name,
            CorporationCode = "abc",
            CorporationParcitipationsCount = 1,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }
    
    [Fact]
    public void CorporationNameTooLong()
    {
        var name = "";
        for (int i = 1; i <= 101; i++)
        {
            name += "a";
        }
        var participant = new Participant
        {
            IsCompany = true,
            FirstName = null,
            LastName = null,
            SocialsecurityNumber = null,
            CorporationName = name,
            CorporationCode = "abc",
            CorporationParcitipationsCount = 1,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }
    
    [Fact]
    public void ValidCorporationParticipantsCount()
    {
        // Count must be n > 0
        var participant = new Participant
        {
            IsCompany = true,
            FirstName = null,
            LastName = null,
            SocialsecurityNumber = null,
            CorporationName = "abc",
            CorporationCode = "abc",
            CorporationParcitipationsCount = 1,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.True(result);
    }
    
    [Fact]
    public void InvalidCorporationParticipantsCount()
    {
        var participant = new Participant
        {
            IsCompany = true,
            FirstName = null,
            LastName = null,
            SocialsecurityNumber = null,
            CorporationName = "abc",
            CorporationCode = "abc",
            CorporationParcitipationsCount = -1,
            Comment = null
        };
        var validationAttribute = new ParticipantValidationAttribute();
        var result = validationAttribute.IsValid(participant);
        Assert.False(result);
    }

}