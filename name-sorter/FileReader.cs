namespace NameSorter
{
    public class FileReader
    {
        //Take a file path and return an array of it's lines.
        public string[] UnorderedNames;

        public FileReader(string path)
        {
            UnorderedNames = File.ReadAllLines(path);
        }
    }
}
