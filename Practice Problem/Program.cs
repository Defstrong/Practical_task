using Practice_Problem.Models;
using Practice_Problem.DTO;
using Practice_Problem.Enums;
using Practice_Problem.Services;
using Practice_Problem.PersonServices;

var _persons = new List<Person>();
var _inputData = new PersonData();
var _addDeleteAndEditPerson = new AddDeleteAndEditPersons(_persons);
int _countWhile = 100;
string _inputCommand = string.Empty;
var _search = new Search(_persons);
string _allCommand = "Add Person\tDelete Person\tEdit Person\tPersons Info\tSearch Persons\tExport Datas";
var _person1 = new Person(new PersonData
{
    FirstName = "Bob",
    LastName = "Another",
    DateOfBirth = new DateTime(2004, 12, 04),
    Duty = PersonDuty.Accountant,
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
    DateOfBirth = new DateTime(2002, 12, 04),
    Duty = PersonDuty.Accountant,
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
    DateOfBirth = DateTime.Parse("01.12.2004"),
    Duty = PersonDuty.Accountant,
    Address = "Sino",
    City = "Dushanbe",
    Floor = PersonFloor.Male,
    AboutPerson = "Another",
    Region = "Another"
});

_persons.Add(_person1);
_persons.Add(_person2);
_persons.Add(_person3);

while(--_countWhile > 0)
{
    _allCommand.ConsoleWriteDataPerson();
    "\nInput command: ".ConsoleWriteDataPerson();
    _inputCommand = ReadInputData.ReadStr();


    if (_inputCommand == "Add Person")
    {
        _inputData.ReadPersonData();
        _addDeleteAndEditPerson.AddPerson(_inputData);
    }
    if(_inputCommand == "Delete Person")
    {
        foreach(var ii in _persons)
            Console.WriteLine($"First Name: {ii.FirstName}, Last Name: {ii.LastName}, Id: {ii.Id}");

        Guid idPersonForDelete = Guid.Parse(Console.ReadLine());
        _addDeleteAndEditPerson.DeletePerson(idPersonForDelete);
    }
    if(_inputCommand == "Persons Info")
    {
        foreach (var emploee in _persons)
            emploee.ToString().ConsoleWriteDataPerson();
    }
    if (_inputCommand == "Search Persons")
    {
        string inputRequestSearch = String.Empty;
        string inputRequestPropertyForSearch = String.Empty;
        $"First name \t Last name \t Duty\n".ConsoleWriteDataPerson();
        "Input type search: ".ConsoleWriteDataPerson();
        inputRequestSearch = ReadInputData.ReadStr();
        "Input property for search: ".ConsoleWriteDataPerson();
        inputRequestPropertyForSearch = ReadInputData.ReadStr();
        foreach(var ii in _search.SearchPersons(inputRequestSearch, inputRequestPropertyForSearch))
            Console.WriteLine(ii.ToString());
    }
    if(_inputCommand == "Edit Person")
    {
        WriteAllPersonData();
        EditPersonDto dataForEdit = new EditPersonDto();
        string inputId = string.Empty;
        "\nEnter ID Person for edit: ".ConsoleWriteDataPerson();
        inputId = ReadInputData.ReadStr();
        dataForEdit.Id = Guid.Parse(inputId);
        dataForEdit.ReadPersonData();
        _addDeleteAndEditPerson.EditPerson(dataForEdit);
    }
    if(_inputCommand == "Export Datas")
    {
        "Enter path file: ".ConsoleWriteDataPerson();
        string path = ReadInputData.ReadStr();

        var exportDatas = new StreamWriter(path, true, System.Text.Encoding.UTF8);

        foreach(var ii in _persons)
        {
            exportDatas.WriteLine($"{ii.ToString()} \t");
        }
        exportDatas.Close();
    }
}

void WriteAllPersonData()
{
    foreach (var person in _persons)
    {
        person.Id.ToString().ConsoleWriteDataPerson();
        person.ToString().ConsoleWriteDataPerson();
    }
}
