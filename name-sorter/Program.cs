using NameSorter;

//Prevents incorrect amount of arguments provided.
if (args.Length == 0)
{
    Console.WriteLine("No file path included.");
    Console.WriteLine("Usage: name-sorter <file-path>");
    Console.WriteLine("<file-path>: A text file with a list on names.");
    return 1;
}
if (args.Length != 1)
{
    Console.WriteLine("Too many arguments.");
    Console.WriteLine("Usage: name-sorter <file-path>");
    Console.WriteLine("<file-path>: A text file with a list on names.");
    return 1;
}

//Initialise unsortedNames array and try to read the file provided.
string[] unsortedNames;

try
{
    string fileName = args[0];
    unsortedNames = new FileReader(fileName).UnorderedNames;
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Invalid file. ({args[0]})");
    return 2;
}

IEnumerable<string> sortedNames = NameSorter.FullNameSorter.OrderNames(unsortedNames);

using StreamWriter file = new("sorted-names-list.txt");

//Write each name to Console and the file defined above.
foreach (string name in sortedNames)
{
    Console.WriteLine(name);
    await file.WriteLineAsync(name);
}
return 0;
