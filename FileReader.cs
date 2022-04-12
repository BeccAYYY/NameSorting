namespace NameSorter
{
    public class FileReader
    {
        public string[] UnorderedNames;

        public FileReader(string url)
        {
            UnorderedNames = File.ReadAllLines(url);
        }
    }
}
