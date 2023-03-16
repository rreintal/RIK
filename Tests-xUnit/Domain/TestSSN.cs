using Domain;
using Xunit;

namespace Tests_xUnit;

public class TestSSN
{
    [Fact]
    public void TestInvalidSocialSecurityNumberLength1()
    {
        var ssn = "501103127611";
        Assert.False(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    [Fact]
    public void TestInvalidSocialSecurityNumberLength2()
    {
        var ssn = "5011031276";
        Assert.False(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    [Fact]
    public void TestValidSocialSecurityNumber1()
    {
        var ssn = "50110312761";
        Assert.True(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    [Fact]
    public void TestValidSocialSecurityNumber2()
    {
        var ssn = "60107074222";
        Assert.True(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    [Fact]
    public void TestInvalidSocialSecurityNumber1()
    {
        var ssn = "60107074221";
        Assert.False(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    [Fact]
    public void TestInvalidSocialSecurityNumber2()
    {
        var ssn = "12245678910";
        Assert.False(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    [Fact]
    public void TestInvalidSocialSecurityNumber3()
    {
        var ssn = "493102102081";
        Assert.False(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    [Fact]
    public void TestInvalidSocialSecurityNumber4()
    {
        var ssn = "abcdefghijk";
        Assert.False(Participant.IsValidEstonianSocialSecurityNumber(ssn));
    }
    
    
    
}