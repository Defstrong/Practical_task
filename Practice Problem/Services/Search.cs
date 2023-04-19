using Practice_Problem.Models;
using Practice_Problem.Enums;
using Practice_Problem.InformationResult;

namespace Practice_Problem.Services
{
    sealed class Search
    {
        public readonly List<Person> Persons;

        public Search(List<Person> persons) =>
            Persons = persons;

        public Result<List<Person>> SearchPersons(string strRequest, string dataRequest)
        {
            var result = new Result<List<Person>>() { Payload = null };
            if(!string.IsNullOrEmpty(strRequest) && !string.IsNullOrEmpty(dataRequest))
            {
                result.TextError = "Search persons completed successfuly";
                result.IsSuccessfully = true;
                if (strRequest == "First name")
                    result.Payload = SearchWithFirtName(dataRequest);
                else if (strRequest == "Last name")
                    result.Payload = SearchWithLastName(dataRequest);
                else if(strRequest == "Duty")
                    result.Payload = SearchWithDuty(dataRequest);
            }
            else
            {
                if(string.IsNullOrEmpty(strRequest))
                {
                    result.TextError += "Str request is empty\n";
                    result.Error = ErrorStatus.ArgumentNull;
                }

                if(string.IsNullOrEmpty(dataRequest))
                {
                    result.TextError += "Data request is empty\n";
                    result.Error = ErrorStatus.ArgumentNull;
                }
            }
            return result;
        }

        public List<Person> SearchWithLastName(string lastNameForSearch) =>
            Persons.
                Where(person => person.LastName == lastNameForSearch).
                ToList();
        public List<Person> SearchWithFirtName(string firstNameForSearch) =>
            Persons.
                Where(person => person.FirstName == firstNameForSearch).
                ToList();
        public List<Person> SearchWithDuty(string dutyForSearch) =>
            Persons.
                Where(person => person.Duty.ToString() == dutyForSearch).
                ToList();
    }
}
