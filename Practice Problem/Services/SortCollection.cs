using Practice_Problem.Enums;
using Practice_Problem.InformationResult;
using Practice_Problem.Models;
using static Practice_Problem.Services.FilterCollection;

namespace Practice_Problem.Services
{
    class SortCollection
    {
        private static List<Person> Persons;

        public SortCollection(List<Person> persons) =>
            Persons = persons;

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

        public Result<bool> Sorting(string category) =>
            category switch
            {
                "First Name" => RunSorting(sortWithFirstName, category),
                "Last Name" => RunSorting(sortWithLastName, category),
                "Age" => RunSorting(sortWithAge, category),
                "Duty" => RunSorting(sortWithDuty, category),
                "Floor" => RunSorting(sortWithFloor, category),
                _ => new Result<bool>
                {
                    IsSuccessfully = false,
                    Payload = false,
                    Error = ErrorStatus.NotFound,
                    TextError = "Category is not found"
                }
            };

        public Result<bool> RunSorting(SortPersons typeSorting, string category)
        {
            var result = new Result<bool>() { Payload = false };
            if (typeSorting is null || string.IsNullOrEmpty(category))
            {
                if (typeSorting is null)
                {
                    result.Error = ErrorStatus.ArgumentNull;
                    result.TextError = "Type sort is null";
                }
                if (string.IsNullOrEmpty(category))
                {
                    result.Error = ErrorStatus.ArgumentNull;
                    result.TextError += "Category is null";
                }
            }
            else
            {
                typeSorting();
                foreach (var ii in Persons)
                    Console.WriteLine(ii.ToString());

                result.TextError = $"Sort with {category} completed successfuly";
                result.IsSuccessfully = true;
                result.Payload = true;
            }
            return result;
        }
    }
}
