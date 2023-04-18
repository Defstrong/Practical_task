using Practice_Problem.Models;
using Practice_Problem.DTO;
using Practice_Problem.Services;

namespace Practice_Problem.PersonServices
{
    sealed class AddDeleteAndEditPersons
    {
        internal readonly List<Person> Persons;
        public AddDeleteAndEditPersons(List<Person> persons) =>
            Persons = persons;

        public void AddPerson(PersonData personDataForAdd)
        {
            var personForAdd = new Person(personDataForAdd);

            if (personDataForAdd is not null)
                Persons.Add(personForAdd);
        }

        public void DeletePerson(Guid personId)
        {
            var PersonForDelete = Persons.FirstOrDefault(x => x.Id.Equals(personId));

            Persons.Remove(PersonForDelete);
        }

        public void EditPerson(EditPersonDto dataForEdit)
        {
            var personForEdit = Persons.FirstOrDefault(x => x.Id == dataForEdit.Id);

            personForEdit.FirstName = string.
                IsNullOrEmpty(dataForEdit.FirstName) 
                ? personForEdit.FirstName : dataForEdit.FirstName;

            personForEdit.LastName = string.
                IsNullOrEmpty(dataForEdit.LastName)
                ? personForEdit.LastName : dataForEdit.LastName;

            personForEdit.Age =
                dataForEdit.DateOfBirth.ToString() == "01/01/0001 12:00:00 AM"
                ? personForEdit.Age 
                : DeterminationOfAge.AgeDetermination(dataForEdit.DateOfBirth);

            personForEdit.Address = string.
                IsNullOrEmpty(dataForEdit.Address)
                ? personForEdit.Address : dataForEdit.Address;

            personForEdit.City = string.
                IsNullOrEmpty(dataForEdit.City)
                ? personForEdit.City : dataForEdit.City;

            personForEdit.Region = string.
                IsNullOrEmpty(dataForEdit.Region)
                ? personForEdit.Region : dataForEdit.Region;

            personForEdit.AboutPerson = string.
                IsNullOrEmpty(dataForEdit.AboutPerson)
                ? personForEdit.AboutPerson : dataForEdit.AboutPerson;

            personForEdit.Floor = string.
                IsNullOrEmpty(dataForEdit.Floor.ToString())
                ? personForEdit.Floor : dataForEdit.Floor;

        }
    }
}
