//string[] names = OrderNames(File.ReadAllLines(@"unsorted-names.txt"));

using StreamWriter file = new("sorted-names-list.txt");

/*foreach (string name in names)
{
    Console.WriteLine(name);
    await file.WriteLineAsync(name);
}*/
