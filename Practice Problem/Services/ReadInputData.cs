using Practice_Problem.DTO;
using Practice_Problem.Enums;
namespace Practice_Problem.Services
{
    public static class ReadInputData
    {
        public static void ReadPersonData(this PersonData personInputData)
        {
            "First Name : ".ConsoleWriteDataPerson();
            personInputData.FirstName = Console.ReadLine();
            "Last Name : ".ConsoleWriteDataPerson();
            personInputData.LastName = Console.ReadLine();
            "Date of birth : ".ConsoleWriteDataPerson();
            personInputData.DateOfBirth = DateTime.Parse(Console.ReadLine());
            "Address : ".ConsoleWriteDataPerson();
            personInputData.Address = Console.ReadLine();
            "AboutPerson : ".ConsoleWriteDataPerson();
            personInputData.AboutPerson = Console.ReadLine();
            "City : ".ConsoleWriteDataPerson();
            personInputData.City = Console.ReadLine();
            "Region : ".ConsoleWriteDataPerson();
            personInputData.Region = Console.ReadLine();
            string FloorPerson = string.Empty;
            ReadStr(ref FloorPerson);
            personInputData.Floor = FloorPerson == "Male" ? PersonFloor.Male : PersonFloor.Female;
        }
        public static void ReadPersonDataForEdit(this PersonData personInputDataForEdit)
        {

        }
        public static void ReadStr(ref string str)
        {
            str = Console.ReadLine();
        }
    }
}
