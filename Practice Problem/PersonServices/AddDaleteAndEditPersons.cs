using Practice_Problem.Models;
using Practice_Problem.DTO;
namespace Practice_Problem.PersonServices
{
    sealed class AddDeleteAndEditPersons
    {
        internal readonly List<Person> Persons;
        public AddDeleteAndEditPersons(List<Person> persons)
        {
            Persons = persons;
        }

        public void AddPerson(PersonData personDataForAdd)
        {
            var personForAdd = new Person(personDataForAdd);

            if(personDataForAdd is not null)
                Persons.Add(personForAdd);
        }

        public void DeletePerson(Guid personId)
        {
            var PersonForDelete = Persons.FirstOrDefault(x => x.Id.Equals(personId));

            Persons.Remove(PersonForDelete);
        }
    }
}
