namespace Search_text_in_file
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string text = "hello";
            string format = "txt";
            PathAndText searchText = new PathAndText(path, format, text);
            Thread myThread = new Thread(FindTextInFiles);
            myThread.Start(searchText);
        }
        static void FindTextInFiles(object? obj)
        {
            if (obj is PathAndText pathAndText)
            {
                DirectoryInfo dir = new DirectoryInfo(pathAndText.path);
                List<string> fileList = new List<string>();
                foreach (var file in dir.GetFiles("*." + pathAndText.format, SearchOption.AllDirectories))
                {
                    fileList.Add(file.FullName);
                }
                bool result = false;
                foreach (var file in fileList)
                {
                    string tmp = File.ReadAllText(file);
                    if (tmp.IndexOf(pathAndText.searchText, StringComparison.CurrentCulture) != -1)
                    {
                        Console.WriteLine("Найдено совпаденеи в файле \"{0}\"\t", file);
                        result = true;
                    }
                }
                if (!result)
                    Console.WriteLine("Файл не найден");
            }
        }
        record class PathAndText(string path, string format, string searchText);
    }
}
