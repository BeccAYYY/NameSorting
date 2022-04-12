using Xunit;
using System;
using System.Linq;
using System.Collections.Generic;

namespace NameSorter.Tests;

public class FullNameSorterTests
{
    [Theory]
    [MemberData(nameof(LastNameTestData))]
    public void LastNameTest(string name, string expected)
    {
        string lastName = FullNameSorter.LastName(name);
        Assert.Equal(lastName, expected);
    }

    public static IEnumerable<object[]> LastNameTestData =>
        new List<object[]>
        {
            new string[] { "John Smith", "Smith" },
            new string[] { "John  Smith", "Smith" },
            new string[] { "Smith", "Smith" },
            new string[] { "John Smith ", "Smith" },
            new string[] { "John Michael Smith", "Smith" },
            new string[] { "John 1s Smith", "Smith" },
            new string[] { "John-Michael Smith", "Smith" },
            new string[] { "Smith Smith", "Smith" },
            new string[] { " John Smith", "Smith" },
            new string[] { "1 John Smith", "Smith" },
        };

    [Theory]
    [MemberData(nameof(OrderNamesTestData))]
    public void OrderNamesTest(string[] unorderedList, string[] expected)
    {
        IEnumerable<string> sortedList = FullNameSorter.OrderNames(unorderedList);
        Assert.Equal(sortedList, expected);
    }

    public static IEnumerable<object[]> OrderNamesTestData =>
        new List<object[]>
        {
            new object[]
            {
                new string[]
                {
                    "Janet Parsons",
                    "Vaughn Lewis",
                    "Adonis Julius Archer",
                    "Shelby Nathan Yoder",
                    "Marin Alvarez",
                    "London Lindsey",
                    "Beau Tristan Bentley",
                    "Leo Gardner",
                    "Hunter Uriah Mathew Clarke",
                    "Mikayla Lopez",
                    "Frankie Conner Ritter"
                },
                new string[]
                {
                    "Marin Alvarez",
                    "Adonis Julius Archer",
                    "Beau Tristan Bentley",
                    "Hunter Uriah Mathew Clarke",
                    "Leo Gardner",
                    "Vaughn Lewis",
                    "London Lindsey",
                    "Mikayla Lopez",
                    "Janet Parsons",
                    "Frankie Conner Ritter",
                    "Shelby Nathan Yoder"
                }
            }
        };
}
