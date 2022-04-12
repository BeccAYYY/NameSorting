namespace NameSorter
{
    public class FullNameSorter
    {
        //Takes a string and returns the last section that doesn't have a space.
        public static string LastName(string fullName)
        {
            return fullName.Trim().Split(' ').Last();
        }

        //Takes a string and all characters before the last space,
        //or nothing if no spaces exist.
        public static string GivenNames(string fullName)
        {
            return string.Join(' ', fullName.Trim().Split(' ').Take(0..^1)).Trim();
        }

        //Takes an array of strings and orders them by last then first name.
        public static IEnumerable<string> OrderNames(string[] namesList)
        {
            return namesList.OrderBy(LastName).ThenBy(GivenNames);
        }
    }
}
