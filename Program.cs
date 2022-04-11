string LastName(string fullName)
{
    return fullName.Trim().Split(' ').Last();
}

Console.WriteLine(LastName("That Guy"));
Console.WriteLine(LastName("Guy"));
Console.WriteLine(LastName("That Guy 2"));
Console.WriteLine(LastName("That Guy   3 "));

string[] OrderNames(string[] namesList)
{
    return namesList.OrderBy(name => LastName(name)).ThenBy(name => name).ToArray();
}

string[] names = OrderNames(System.IO.File.ReadAllLines(@"unsorted-names.txt"));

foreach (string name in names)
{
    Console.WriteLine(name);
}

async Task WriteToFile(string[] orderedNames)
{
    await File.WriteAllLinesAsync("sorted-names-list.txt", orderedNames);
}

WriteToFile(names);
