using Practice_Problem.Models;
using Practice_Problem.DTO;
using Practice_Problem.Enums;
using Practice_Problem.Services;
using Practice_Problem.PersonServices;
using Practice_Problem.Events;

int _countWhile = 100;
var _persons = new List<Person>();
var _inputData = new PersonData();

var _search = new Search(_persons);
string _inputCommand = string.Empty;

var _sort = new SortCollection(_persons);
var _filter = new FilterCollection(_persons);
var _addDeleteAndEditPerson = new AddDeleteAndEditPersons(_persons);

var _writeMassage = new WritePersonData();
_writeMassage.Action += CompletingAction;

var _read = new ReadInputData();
_read.ReadStr = ReadLineStr;
var ReadLine = _read.ReadStr;

string _allCommand = "Add Person\tDelete Person\tEdit Person\tPersons Info\tSearch Persons\tExport Datas";

var _person1 = new Person(new PersonData
{
    FirstName = "Bob",
    LastName = "Another",
    DateOfBirth = new DateTime(2000, 12, 04),
    Duty = PersonDuty.Accountant,
    Address = "Sino",
    City = "Dushanbe",
    Floor = PersonFloor.Male,
    AboutPerson = "Another",
    Region = "Another"
});
var _person2 = new Person(new PersonData
{
    FirstName = "Lee",
    LastName = "Another",
    DateOfBirth = new DateTime(2001, 12, 04),
    Duty = PersonDuty.Accountant,
    Address = "Sino",
    City = "Dushanbe",
    Floor = PersonFloor.Female,
    AboutPerson = "Another",
    Region = "Another"
});
var _person3 = new Person(new PersonData
{
    FirstName = "Another",
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
_persons.Add(_person2);
_persons.Add(_person3);


while(_countWhile-- > 0)
{
    _writeMassage.CompletingAction(_allCommand);

    _writeMassage.CompletingAction("\nInput command: ");
    _inputCommand = ReadLine();
    _writeMassage.CompletingAction($"{AllAction(_inputCommand)}\n");
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
        "Sort" => SortPersons(),
        "Filter" => FilterPersons(),
        _ => "Error command does not exist"
    } ;

string FilterPersons()
{
    _writeMassage.CompletingAction("Enter Category for filter: ");
    string categoryForSort = ReadLine();
    _writeMassage.CompletingAction("Enter Data for filter: ");
    string dataForFilter = ReadLine();
    return _filter.Filtering(categoryForSort, dataForFilter);
}

string SortPersons()
{
    _writeMassage.CompletingAction("Enter Category for sort: ");
    string categoryForSort = ReadLine();
    return _sort.Sorting(categoryForSort);
}


string WriteAllPersonsDatas()
{
    foreach (var person in _persons)
    {
        _writeMassage.CompletingAction(person.Id.ToString());
        _writeMassage.CompletingAction(person.ToString());
    }
    return "Write Person Data completed successfuly";
}


string AddPerson()
{
    _read.ReadPersonData(_inputData);
    _addDeleteAndEditPerson.AddPerson(_inputData);
    return "Add Person completed successfuly";
}

string DeletePerson()
{
    foreach (var ii in _persons)
        _writeMassage.CompletingAction($"First Name: {ii.FirstName}, Last Name: {ii.LastName}, Id: {ii.Id}\n");

    Guid idPersonForDelete = Guid.Parse(Console.ReadLine());
    _addDeleteAndEditPerson.DeletePerson(idPersonForDelete);
    return "Delete Person completed successfuly";
}

string WritePersonsInfo()
{
    foreach (var person in _persons)
        _writeMassage.CompletingAction(person.ToString());
    return "Write Person Info completed successfuly";
}

string SearchPerson()
{
    string inputRequestSearch = String.Empty;
    string inputRequestPropertyForSearch = String.Empty;
    _writeMassage.CompletingAction($"First name \t Last name \t Duty\n");
    _writeMassage.CompletingAction("Input type search: ");
    inputRequestSearch = ReadLine();
    _writeMassage.CompletingAction("Input property for search: ");
    inputRequestPropertyForSearch = ReadLine();
    foreach (var ii in _search.SearchPersons(inputRequestSearch, inputRequestPropertyForSearch))
        Console.WriteLine(ii.ToString());
    return "Search Person completed successfuly";
}

string EditPerson()
{
    WriteAllPersonsDatas();
    EditPersonDto dataForEdit = new EditPersonDto();
    string inputId = string.Empty;
    _writeMassage.CompletingAction("\nEnter ID Person for edit: ");
    inputId = ReadLine();
    dataForEdit.Id = Guid.Parse(inputId);
    _read.ReadPersonData(dataForEdit);
    _addDeleteAndEditPerson.EditPerson(dataForEdit);
    return "Edit Person completed successfuly";
}

string ExportDatas()
{
    _writeMassage.CompletingAction("Enter path file: ");
    string path = ReadLine();

    foreach (var ii in _persons)
        _writeMassage.CompletingAction(ii.ToString());

    return "Export Datas completed successfuly";
}

void CompletingAction(object? sender, EventHandlerArgs e)
{
    Console.Write(e.Text);
}

string ReadLineStr() => Console.ReadLine();