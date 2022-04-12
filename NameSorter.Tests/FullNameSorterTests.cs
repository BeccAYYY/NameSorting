using Xunit;

namespace NameSorter.Tests;

public class FullNameSorterTests
{
    [Theory]
    [InlineData("John Smith")]
    [InlineData("John  Smith")]
    [InlineData("John Smith ")]
    [InlineData("John Michael Smith")]
    [InlineData("John 2 Smith")]
    [InlineData("John-Michael Smith")]
    [InlineData("Smith Smith")]
    [InlineData(" John Smith")]
    [InlineData("1 John Smith")]
    public void LastNameTest(string name)
    {
        string lastName = FullNameSorter.LastName(name);
        bool result = lastName == "Smith";
        Assert.True(result);
    }
}
