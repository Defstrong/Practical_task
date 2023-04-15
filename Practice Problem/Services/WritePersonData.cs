using Practice_Problem.Models;
namespace Practice_Problem.Services
{
    public static class WritePersonData
    {
        public static void ConsoleWriteDataPerson(this string text)
        {
            Console.Write(text);
        }
        public static void FileWriteDataPerson(this string text, string path)
        {
            var exportDatas = new StreamWriter(path, true, System.Text.Encoding.UTF8);

            exportDatas.WriteLine($"{text} \t");
            
            exportDatas.Close();
        }
    }
}
