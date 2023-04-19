using Practice_Problem.Abstractions;
using Practice_Problem.DTO;
using Practice_Problem.Enums;
using Practice_Problem.Events;
using Practice_Problem.InformationResult;

namespace Practice_Problem.Services
{
    class ReadInputData
    {
        IActinoWithTextDatas writeData = new WritePersonData();
        public Func<string> ReadStr;
        public Result<bool> ReadPersonData(PersonData personInputData)
        {
            var result = new Result<bool>() { Payload = false };
            bool error = false;
            ReadStr = ReadLineStr;
            writeData.ActionWithText += ConsoleWrite;
            writeData.CompletingAction("First Name : ");
            personInputData.FirstName = ReadStr();

            writeData.CompletingAction("Last Name : ");
            personInputData.LastName = ReadStr();

            writeData.CompletingAction("Date of birth : ");
            string dateOfBirthStr = ReadStr();

            try
            {
                personInputData.DateOfBirth = string.
                    IsNullOrEmpty(dateOfBirthStr)
                    ? default : DateTime.Parse(dateOfBirthStr);
            }
            catch
            {
                error = true;
                result.Error = ErrorStatus.WrongSintacsis;
                result.TextError += "Date of birth have a wrong sintacsis";
            }

            writeData.CompletingAction("Address : ");
            personInputData.Address = ReadStr();

            writeData.CompletingAction("AboutPerson : ");
            personInputData.AboutPerson = ReadStr();

            writeData.CompletingAction("City : ");
            personInputData.City = ReadStr();

            writeData.CompletingAction("Region : ");
            personInputData.Region = ReadStr();

            writeData.CompletingAction("Floor : ");
            string FloorPerson = ReadStr();
            try
            {
                personInputData.Floor = string.
                    IsNullOrEmpty(FloorPerson)
                    ? null : (FloorPerson == "Male"
                    ? PersonFloor.Male : PersonFloor.Female);
            }
            catch
            {
                error = true;
                result.Error = ErrorStatus.WrongSintacsis;
                result.TextError += "Floor person have a wrong sintacsis";
            }

            if (error)
                personInputData = null;
            else
            {
                result.IsSuccessfully = true;
                result.TextError = "Input person data completed successfuly";
                result.Payload = true;
            }
            writeData.ActionWithText -= ConsoleWrite;
            return result;
        }
        private void ConsoleWrite(object? sender, EventHandlerArgs e) =>
            Console.Write(e.Text);
        private string ReadLineStr() =>
            Console.ReadLine();
    }
}
