namespace NameSorter
{
    public class FileReader
    {
        public string[] UnorderedNames;

        public FileReader(string path)
        {
            UnorderedNames = File.ReadAllLines(path);
        }
    }
}
