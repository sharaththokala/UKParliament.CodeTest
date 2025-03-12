using UKParliament.CodeTest.Services.Validations;
using Xunit;

namespace UKParliament.CodeTest.Tests;

public class ValidationTests
{
    [Theory]
    [InlineData(1, false)]
    [InlineData(0, true)]
    [InlineData(-1, true)]
    public void NotInFuture_Validates(int days, bool isValid)
    {
        //Arrange
        var subjectUnderTest = new NotInFutureDateAttribute();

        //Act
        var result = subjectUnderTest.IsValid(DateTime.Today.AddDays(days));

        //Assert
        Assert.Equal(isValid, result);
    }

    [Theory]
    [InlineData("test", false)]
    [InlineData("testname", false)]
    [InlineData("nameTest", false)]
    [InlineData("TEST", false)]
    [InlineData("Jon", true)]
    public void ValidName_Validates(string name, bool isValid)
    {
        //Arrange
        var subjectUnderTest = new ValidNameAttribute();

        //Act
        var result = subjectUnderTest.IsValid(name);

        //Assert
        Assert.Equal(isValid, result);
    }
}
