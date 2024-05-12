namespace Search_text_in_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string searchText = "hello";
            FindTextInFiles(path, "txt", searchText);
        }
        static void FindTextInFiles(string path, string format, string searchText)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            List<string> fileList = new List<string>();
            foreach (var file in dir.GetFiles("*." + format, SearchOption.AllDirectories))
            {
                fileList.Add(file.FullName);
            }
            bool result = false;
            foreach (var file in fileList)
            {
                string tmp = File.ReadAllText(file);
                if (tmp.IndexOf(searchText, StringComparison.CurrentCulture) != -1)
                {
                    Console.WriteLine("Найдено совпаденеи в файле \"{0}\"\t", file);
                    result = true;
                }
            }
            if(!result)
                Console.WriteLine("Файл не найден");
        }
    }
}
