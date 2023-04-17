using Practice_Problem.Models;

namespace Practice_Problem.Services
{
    class SortCollection
    {
        private static List<Person> Persons;

        public SortCollection(List<Person> persons)
        {
            Persons = persons;
        }

        public delegate void SortPersons();

        public SortPersons sortWithFirstName = () 
            => Persons = Persons.OrderBy(x => x.FirstName).ToList();
        public SortPersons sortWithLastName = () 
            => Persons = Persons.OrderBy(x => x.LastName).ToList();
        public SortPersons sortWithAge = () 
            => Persons = Persons.OrderBy(x => x.Age).ToList();
        public SortPersons sortWithDuty = () 
            => Persons = Persons.OrderBy(x => x.Duty).ToList();
        public SortPersons sortWithFloor = () 
            => Persons = Persons.OrderBy(x => x.Floor).ToList();


        public string Sorting(string category) =>
            category switch
            {
                "First Name" => RunSorting(sortWithFirstName, category),
                "Last Name" => RunSorting(sortWithLastName, category),
                "Age" => RunSorting(sortWithAge, category),
                "Duty" => RunSorting(sortWithDuty, category),
                "Floor" => RunSorting(sortWithFloor, category),
                _ => "Error 404"
            };

        public string RunSorting(SortPersons typeSorting, string category)
        {
            typeSorting();
            foreach (var ii in Persons)
                Console.WriteLine(ii.ToString());
            return $"Sort with {category} completed successfuly";
        }
    }
}
