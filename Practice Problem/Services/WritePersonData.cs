using Practice_Problem.Abstractions;
using Practice_Problem.Events;
using Practice_Problem.InformationResult;
using Practice_Problem.Models;
using Practice_Problem.Enums;

namespace Practice_Problem.Services
{
    class WritePersonData : IActinoWithTextDatas
    {
        public event EventHandler<EventHandlerArgs> ActionWithText;
        public void CompletingAction(string textForWrite)
        {
            ActionWithText?.Invoke(this, new EventHandlerArgs() { Text = textForWrite });
        }

        public Result<bool> ExportDatasPersons(string text, string path)
        {
            var result = new Result<bool>() { Payload = false };
            if(string.IsNullOrEmpty(text) || string.IsNullOrEmpty(path))
            {
                if(string.IsNullOrEmpty(text))
                {
                    result.TextError += "Text for write is empty\n";
                    result.Error = ErrorStatus.ArgumentNull;
                }
                if(string.IsNullOrEmpty(path))
                {
                    result.TextError += "Path for write is empty\n";
                    result.Error = ErrorStatus.ArgumentNull;
                }
            }
            else
            {
                result.TextError = "Export datas completed successfuly\n";
                result.IsSuccessfully = true; result.Payload = true;
                using (var exportDatas = new StreamWriter(path, true, System.Text.Encoding.UTF8))
                {
                    exportDatas.WriteLine($"{text} \t");
                    exportDatas.Close();
                }
            }
            return result;
        }
    }
}
