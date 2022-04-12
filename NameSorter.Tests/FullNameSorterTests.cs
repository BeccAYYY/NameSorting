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
            new string[] { "John Carter-Smith", "Carter-Smith" },
            new string[] { "", "" },
            new string[] { " ", "" },
        };

    [Theory]
    [MemberData(nameof(GivenNamesTestData))]
    public void GivenNamesTest(string name, string expected)
    {
        string givenNames = FullNameSorter.GivenNames(name);
        Assert.Equal(givenNames, expected);
    }

    public static IEnumerable<object[]> GivenNamesTestData =>
        new List<object[]>
        {
            new string[] { "John Smith", "John" },
            new string[] { "John  Smith", "John" },
            new string[] { "Smith", "" },
            new string[] { "John Smith ", "John" },
            new string[] { "John Michael Smith", "John Michael" },
            new string[] { "John 1s Smith", "John 1s" },
            new string[] { "John-Michael Smith", "John-Michael" },
            new string[] { "Smith Smith", "Smith" },
            new string[] { " John Smith", "John" },
            new string[] { "1 John Smith", "1 John" },
            new string[] { "", "" },
            new string[] { " ", "" },
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
            ProvidedData,
            SameLastName,
            SameLastAndFirstName,
            DuplicateName,
            SameMiddleAndLastName,
            SpacesInNames,
            HyphenatedLastName,
        };

    private readonly static object[] ProvidedData = new object[]
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
    };

    private readonly static object[] SameLastName = new object[]
    {
        new string[]
        {
            "Janet Parsons",
            "Vaughn Parsons",
            "Adonis Julius Parsons",
            "Shelby Nathan Parsons",
        },
        new string[]
        {
            "Adonis Julius Parsons",
            "Janet Parsons",
            "Shelby Nathan Parsons",
            "Vaughn Parsons",
        }
    };

    private readonly static object[] SameLastAndFirstName = new object[]
    {
        new string[]
        {
            "Janet Parsons",
            "Janet Anthony Parsons",
            "Janet Julius Parsons",
            "Shelby Nathan Parsons",
        },
        new string[]
        {
            "Janet Parsons",
            "Janet Anthony Parsons",
            "Janet Julius Parsons",
            "Shelby Nathan Parsons",
        }
    };

    private readonly static object[] DuplicateName = new object[]
    {
        new string[]
        {
            "Beau Tristan Bentley",
            "Marin Alvarez",
            "Marin Alvarez",
            "Hunter Uriah Mathew Clarke",
            "Adonis Julius Archer",
        },
        new string[]
        {
            "Marin Alvarez",
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Beau Tristan Bentley",
            "Hunter Uriah Mathew Clarke",
        }
    };

    private readonly static object[] SameMiddleAndLastName = new object[]
    {
        new string[]
        {
            "Beau Tristan Bentley",
            "Marin Alvarez",
            "Joe Uriah Mathew Clarke",
            "Adonis Julius Archer",
            "Hunter Uriah Mathew Clarke",
        },
        new string[]
        {
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Beau Tristan Bentley",
            "Hunter Uriah Mathew Clarke",
            "Joe Uriah Mathew Clarke",
        }
    };

    private readonly static object[] SpacesInNames = new object[]
    {
        new string[]
        {
            " Beau Tristan Bentley",
            "Marin Alvarez",
            "Adonis Julius  Archer",
            "Hunter Uriah Mathew Clarke",
        },
        new string[]
        {
            "Marin Alvarez",
            "Adonis Julius  Archer",
            " Beau Tristan Bentley",
            "Hunter Uriah Mathew Clarke",
        }
    };

    private readonly static object[] HyphenatedLastName = new object[]
    {
        new string[]
        {
            "Beau Tristan Clarkey",
            "Marin Alvarez",
            "Joe Uriah Mathew Clarke",
            "Adonis Julius Archer",
            "Vaughn Lewis",
            "Hunter Uriah Mathew Clarke-Adams",
        },
        new string[]
        {
            "Marin Alvarez",
            "Adonis Julius Archer",
            "Joe Uriah Mathew Clarke",
            "Hunter Uriah Mathew Clarke-Adams",
            "Beau Tristan Clarkey",
            "Vaughn Lewis",
        }
    };
}
