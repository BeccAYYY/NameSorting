namespace NameSorter
{
    public class NameSorter
    {
        public static string LastName(string fullName)
        {
            return fullName.Trim().Split(' ').Last();
        }

        public static IEnumerable<string> OrderNames(string[] namesList)
        {
            return namesList.OrderBy(name => LastName(name)).ThenBy(name => name);
        }
    }
}
