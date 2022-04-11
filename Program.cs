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

string[] names = OrderNames(File.ReadAllLines(@"unsorted-names.txt"));

using StreamWriter file = new("sorted-names-list.txt");

foreach (string name in names)
{
    Console.WriteLine(name);
    await file.WriteLineAsync(name);
}
