using Practice_Problem.Abstractions;
using Practice_Problem.DTO;
using Practice_Problem.Enums;
using Practice_Problem.Events;

namespace Practice_Problem.Services
{
    class ReadInputData
    {
        IActinoWithTextDatas writeData = new WritePersonData();
        public Func<string> ReadStr;
        public void ReadPersonData(PersonData personInputData)
        {
            var ReadLine = ReadLineStr;
            writeData.Action += ConsoleWrite;
            writeData.CompletingAction("First Name : ");
            personInputData.FirstName = ReadLine();

            writeData.CompletingAction("Last Name : ");
            personInputData.LastName = ReadLine();

            writeData.CompletingAction("Date of birth : ");
            string dateOfBirthStr = ReadLine();
            personInputData.DateOfBirth = string.
                IsNullOrEmpty(dateOfBirthStr)
                ? default : DateTime.Parse(dateOfBirthStr);

            writeData.CompletingAction("Address : ");
            personInputData.Address = ReadLine();

            writeData.CompletingAction("AboutPerson : ");
            personInputData.AboutPerson = ReadLine();

            writeData.CompletingAction("City : ");
            personInputData.City = ReadLine();

            writeData.CompletingAction("Region : ");
            personInputData.Region = ReadLine();

            writeData.CompletingAction("Floor : ");
            string FloorPerson = ReadStr(); ;
            personInputData.Floor = string.
                IsNullOrEmpty(FloorPerson)
                ? null : (FloorPerson == "Male"
                ? PersonFloor.Male : PersonFloor.Female);
        }
        private void ConsoleWrite(object? sender, EventHandlerArgs e)
        {
            Console.Write(e.Text);
        }
        private string ReadLineStr()
        {
            return Console.ReadLine();
        }
    }
}
