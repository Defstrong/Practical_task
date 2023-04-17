using Practice_Problem.Models;

namespace Practice_Problem.Services
{
    class FilterCollection
    {
        private static List<Person> Persons;

        public FilterCollection(List<Person> persons)
        {
            Persons = persons;
        }

        public delegate void FilterPersons(string dataForFiltering);

        public FilterPersons filterWithFirstName = (string firstNameForFiltering) 
            => Persons = Persons.Where(x => x.FirstName == firstNameForFiltering).ToList();

        public FilterPersons filterWithLastName = (string lastNameForFiltering) 
            => Persons = Persons.Where(x => x.LastName == lastNameForFiltering).ToList();

        public FilterPersons filterWithAge = (string ageForFiltering) 
            => Persons = Persons.Where(x => x.Age > int.Parse(ageForFiltering)).ToList();

        public FilterPersons filterWithDuty = (string dutyForFiltering) 
            => Persons = Persons.Where(x => x.Duty.ToString() == dutyForFiltering).ToList();

        public FilterPersons filterWithFloor = (string floorForFiltering) 
            => Persons = Persons.Where(x => x.Floor.ToString() == floorForFiltering).ToList();

        public string Filtering(string category, string data) =>
            category switch
            {
                "First Name" => RunFiltering(filterWithFirstName, category, data),
                "Last Name" => RunFiltering(filterWithLastName, category, data),
                "Age" => RunFiltering(filterWithAge, category, data),
                "Duty" => RunFiltering(filterWithDuty, category, data),
                "Floor" => RunFiltering(filterWithFloor, category, data),
                _ => "Error 404"
            };

        public string RunFiltering(FilterPersons typeFilter, string category, string dataForFilter)
        {
            typeFilter(dataForFilter);
            foreach (var ii in Persons)
                Console.WriteLine(ii.ToString());
            return $"Filter with {category} completed successfuly";
        }
    }
}
