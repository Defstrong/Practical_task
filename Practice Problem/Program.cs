using Practice_Problem.Models;
using Practice_Problem.DTO;
using Practice_Problem.Enums;
using Practice_Problem.Services;
using Practice_Problem.PersonServices;

var _emploees = new List<Person>();
var _inputData = new PersonData();
var _addAndDeletePerson = new AddDeleteAndEditPersons(_emploees);
int _countWhile = 100;
string _inputCommand = string.Empty;
var _search = new Search(_emploees);
string _allCommand = "Add Emploee\tDelete Emploee\tEdit Emploee\tEmploees Info\tSearch Emploees\n";
var _person1 = new Person(new PersonData
{
    FirstName = "Bob",
    LastName = "Another",
    DateOfBirth = new DateTime(2004, 12, 04),
    Duty = EmploeeDuty.Accountant,
    Address = "Sino",
    City = "Dushanbe",
    Floor = PersonFloor.Male,
    AboutPerson = "Another",
    Region = "Another"
});

var _person2 = new Person(new PersonData
{
    FirstName = "Bob",
    LastName = "Another",
    DateOfBirth = new DateTime(2004, 12, 04),
    Duty = EmploeeDuty.Accountant,
    Address = "Sino",
    City = "Dushanbe",
    Floor = PersonFloor.Male,
    AboutPerson = "Another",
    Region = "Another"
});

var _person3 = new Person(new PersonData
{
    FirstName = "Bob",
    LastName = "another",
    DateOfBirth = new DateTime(2004, 12, 04),
    Duty = EmploeeDuty.Accountant,
    Address = "Sino",
    City = "Dushanbe",
    Floor = PersonFloor.Male,
    AboutPerson = "Another",
    Region = "Another"
});

_emploees.Add(_person1);
_emploees.Add(_person2);
_emploees.Add(_person3);

while(--_countWhile > 0)
{
    _allCommand.ConsoleWriteDataPerson();
    "Input command: ".ConsoleWriteDataPerson();
    ReadInputData.ReadStr(ref _inputCommand);


    if (_inputCommand == "Add Emploee")
    {
        _inputData.ReadPersonData();
        _addAndDeletePerson.AddPerson(_inputData);
    }
    if(_inputCommand == "Delete Emploee")
    {
        foreach(var ii in _emploees)
            Console.WriteLine($"First Name: {ii.FirstName}, Last Name: {ii.LastName}, Id: {ii.Id}");

        Guid idPersonForDelete = Guid.Parse(Console.ReadLine());
        _addAndDeletePerson.DeletePerson(idPersonForDelete);
    }
    if(_inputCommand == "Emploees Info")
    {
        foreach (var emploee in _emploees)
            emploee.ToString().ConsoleWriteDataPerson();
    }
    if (_inputCommand == "Search Emploees")
    {
        string inputRequestSearch = String.Empty;
        string inputRequestPropertyForSearch = String.Empty;

        $"First name \t Last name \t Duty\n".ConsoleWriteDataPerson();

        "Input type search: ".ConsoleWriteDataPerson();
        ReadInputData.ReadStr(ref inputRequestSearch);
        "Input property for search: ".ConsoleWriteDataPerson();
        ReadInputData.ReadStr(ref inputRequestPropertyForSearch);

        foreach(var ii in _search.SearchPersons(inputRequestSearch, inputRequestPropertyForSearch))
            Console.WriteLine(ii.ToString());
    }
    if(_inputCommand == "Edit emploee")
    {

    }
}
