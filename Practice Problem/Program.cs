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


_persons.Add(_person1);
while(--_countWhile > 0)
{
    _allCommand.ConsoleWriteDataPerson();
    "\nInput command: ".ConsoleWriteDataPerson();
    _inputCommand = ReadInputData.ReadStr();
    $"{AllAction(_inputCommand)}\n".ConsoleWriteDataPerson();
}





string AllAction(string inputCommand) =>
    inputCommand switch
    {
        "Add Person" => AddPerson(),
        "Delete Person" => DeletePerson(),
        "Edit Person" => EditPerson(),
        "Persons Info" => WritePersonsInfo(),
        "Search Persons" => SearchPerson(),
        "Export Datas" => ExportDatas(),
        _ => "Error command does not exist"
    } ;


string WriteAllPersonsDatas()
{
    foreach (var person in _persons)
    {
        person.Id.ToString().ConsoleWriteDataPerson();
        person.ToString().ConsoleWriteDataPerson();
    }
    return "Write Person Data completed successfuly";
}


string AddPerson()
{
    _inputData.ReadPersonData();
    _addDeleteAndEditPerson.AddPerson(_inputData);
    return "Add Person completed successfuly";
}

string DeletePerson()
{
    foreach (var ii in _persons)
        $"First Name: {ii.FirstName}, Last Name: {ii.LastName}, Id: {ii.Id}".ConsoleWriteDataPerson();

    Guid idPersonForDelete = Guid.Parse(Console.ReadLine());
    _addDeleteAndEditPerson.DeletePerson(idPersonForDelete);
    return "Delete Person completed successfuly";
}

string WritePersonsInfo()
{
    foreach (var person in _persons)
        person.ToString().ConsoleWriteDataPerson();
    return "Write Person Info completed successfuly";
}

string SearchPerson()
{
    string inputRequestSearch = String.Empty;
    string inputRequestPropertyForSearch = String.Empty;
    $"First name \t Last name \t Duty\n".ConsoleWriteDataPerson();
    "Input type search: ".ConsoleWriteDataPerson();
    inputRequestSearch = ReadInputData.ReadStr();
    "Input property for search: ".ConsoleWriteDataPerson();
    inputRequestPropertyForSearch = ReadInputData.ReadStr();
    foreach (var ii in _search.SearchPersons(inputRequestSearch, inputRequestPropertyForSearch))
        Console.WriteLine(ii.ToString());
    return "Search Person completed successfuly";
}

string EditPerson()
{
    WriteAllPersonsDatas();
    EditPersonDto dataForEdit = new EditPersonDto();
    string inputId = string.Empty;
    "\nEnter ID Person for edit: ".ConsoleWriteDataPerson();
    inputId = ReadInputData.ReadStr();
    dataForEdit.Id = Guid.Parse(inputId);
    dataForEdit.ReadPersonData();
    _addDeleteAndEditPerson.EditPerson(dataForEdit);
    return "Edit Person completed successfuly";
}

string ExportDatas()
{
    "Enter path file: ".ConsoleWriteDataPerson();
    string path = ReadInputData.ReadStr();

    foreach (var ii in _persons)
        ii.ToString().FileWriteDataPerson(path);

    return "Export Datas completed successfuly";
}