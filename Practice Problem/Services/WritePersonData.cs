using Practice_Problem.Abstractions;
using Practice_Problem.Events;
using Practice_Problem.Models;

namespace Practice_Problem.Services
{
    class WritePersonData : IActinoWithTextDatas
    {
        public event EventHandler<EventHandlerArgs> Action;
        public void CompletingAction(string textForWrite)
        {
            Action?.Invoke(this, new EventHandlerArgs() { Text = textForWrite });
        }
        public void ConsoleWriteDataPerson(string text)
        {
            Console.Write(text);
        }
        public void FileWriteDataPerson(string text, string path)
        {
            var exportDatas = new StreamWriter(path, true, System.Text.Encoding.UTF8);

            exportDatas.WriteLine($"{text} \t");
            
            exportDatas.Close();
        }
    }
}
