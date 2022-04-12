using NameSorter;

string[] unsortedNames = new FileReader(args[0]).UnorderedNames;
IEnumerable<string> sortedNames = NameSorter.NameSorter.OrderNames(unsortedNames);

using StreamWriter file = new("sorted-names-list.txt");

foreach (string name in sortedNames)
{
    Console.WriteLine(name);
    await file.WriteLineAsync(name);
}
