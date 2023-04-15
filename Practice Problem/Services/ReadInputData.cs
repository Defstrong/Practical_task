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
            string dateOfBirthStr = Console.ReadLine();
            personInputData.DateOfBirth = string.
                IsNullOrEmpty(dateOfBirthStr) 
                ? default : DateTime.Parse(dateOfBirthStr);

            "Address : ".ConsoleWriteDataPerson();
            personInputData.Address = Console.ReadLine();

            "AboutPerson : ".ConsoleWriteDataPerson();
            personInputData.AboutPerson = Console.ReadLine();

            "City : ".ConsoleWriteDataPerson();
            personInputData.City = Console.ReadLine();

            "Region : ".ConsoleWriteDataPerson();
            personInputData.Region = Console.ReadLine();

            "Floor : ".ConsoleWriteDataPerson();
            string FloorPerson = ReadStr(); ;
            personInputData.Floor = string.
                IsNullOrEmpty(FloorPerson) 
                ? null : (FloorPerson == "Male" 
                ? PersonFloor.Male : PersonFloor.Female);
        }
        public static string ReadStr()
        {
            return Console.ReadLine();

        }
    }
}
