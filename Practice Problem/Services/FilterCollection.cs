using Practice_Problem.InformationResult;
using Practice_Problem.Models;
using Practice_Problem.Enums;

namespace Practice_Problem.Services
{
    class FilterCollection
    {
        private static List<Person> Persons;

        public FilterCollection(List<Person> persons) =>
            Persons = persons;

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

        public Result<bool> Filtering(string category, string data) =>
            category switch
            {
                "First Name" => RunFiltering(filterWithFirstName, category, data),
                "Last Name" => RunFiltering(filterWithLastName, category, data),
                "Age" => RunFiltering(filterWithAge, category, data),
                "Duty" => RunFiltering(filterWithDuty, category, data),
                "Floor" => RunFiltering(filterWithFloor, category, data),
                _ => new Result<bool> { 
                    IsSuccessfully = false, 
                    Payload = false, 
                    Error = ErrorStatus.NotFound, 
                    TextError = "Category is not found"}
            };

        public Result<bool> RunFiltering(FilterPersons typeFilter, string category, string dataForFilter)
        {
            var result = new Result<bool>() { Payload = false };
            if(typeFilter is null || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(dataForFilter))
            {
                if(typeFilter is null)
                {
                    result.Error = ErrorStatus.ArgumentNull;
                    result.TextError = "Type filtering is null";
                }
                if(string.IsNullOrEmpty(category))
                {
                    result.Error = ErrorStatus.ArgumentNull;
                    result.TextError += "Category is null";
                }
                if(string.IsNullOrEmpty(dataForFilter))
                {
                    result.Error = ErrorStatus.ArgumentNull;
                    result.TextError += "Data for filter is null";
                }
            }
            else
            {
                typeFilter(dataForFilter);
                foreach (var ii in Persons)
                    Console.WriteLine(ii.ToString());

                result.TextError = $"Filter with {category} completed successfuly";
                result.IsSuccessfully = true ;
                result.Payload = true ;
            }
            return result;
        }
    }
}
