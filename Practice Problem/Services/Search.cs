using Practice_Problem.Models;
using Practice_Problem.Enums;
namespace Practice_Problem.Services
{
    sealed class Search
    {
        public readonly List<Person> Persons;

        public Search(List<Person> persons)
        {
            Persons = persons;
        }

        public List<Person> SearchPersons(string strRequest, string dataRequest)
        {
            if (strRequest == "First name")
                return SearchWithFirtName(dataRequest);
            else if (strRequest == "Last name")
                return SearchWithLastName(dataRequest);
            else if(strRequest == "Duty")
                return SearchWithDuty(dataRequest);
            return null;
        }

        public List<Person> SearchWithLastName(string lastNameForSearch)
        {
            return Persons.
                Where(person => person.LastName == lastNameForSearch).
                ToList();
        }
        public List<Person> SearchWithFirtName(string firstNameForSearch)
        {
            return Persons.
                Where(person => person.FirstName == firstNameForSearch).
                ToList();
        }
        public List<Person> SearchWithDuty(string dutyForSearch)
        {
            return Persons.
                Where(person => person.Duty.ToString() == dutyForSearch).
                ToList();
        }


    }
}
