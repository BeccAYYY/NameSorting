namespace NameSorter
{
    public class FullNameSorter
    {
        public static string LastName(string fullName)
        {
            return fullName.Trim().Split(' ').Last();
        }

        public static string GivenNames(string fullName)
        {
            return string.Join(' ', fullName.Trim().Split(' ').Take(0..^1)).Trim();
        }

        public static IEnumerable<string> OrderNames(string[] namesList)
        {
            return namesList.OrderBy(LastName).ThenBy(GivenNames);
        }
    }
}
