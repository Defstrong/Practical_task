using Practice_Problem.Models;
using Practice_Problem.DTO;
using Practice_Problem.Services;
using Practice_Problem.InformationResult;
using Practice_Problem.Enums;

namespace Practice_Problem.PersonServices
{
    sealed class AddDeleteAndEditPersons
    {
        internal readonly List<Person> Persons;
        public AddDeleteAndEditPersons(List<Person> persons) =>
            Persons = persons;

        public Result<bool> AddPerson(PersonData personDataForAdd)
        {
            bool error = false;
            var result = new Result<bool>() { Payload = false } ;
            if(personDataForAdd is null)
            {
                result.TextError = "Error. Please fill in all fields";
                result.Error = ErrorStatus.ArgumentNull;
                error = true;  
            }

            string textError = string.Empty;
            error = ErrorOrNO(personDataForAdd.FirstName, ref textError, "First Name");
            error = ErrorOrNO(personDataForAdd.LastName, ref textError, "Last Name");
            error = ErrorOrNO(personDataForAdd.Address, ref textError, "Address");
            error = ErrorOrNO(personDataForAdd.Region, ref textError, "Region");
            error = ErrorOrNO(personDataForAdd.City, ref textError, "City");
            error = ErrorOrNO(personDataForAdd.AboutPerson, ref textError, "About Person");
            error = ErrorOrNO(personDataForAdd.Floor.ToString(), ref textError, "Floor");
            error = ErrorOrNO(personDataForAdd.Duty.ToString(), ref textError, "Duty");
            result.TextError = textError;

            Console.WriteLine(error);

            if(error)
            {
                result.Payload = true;
                result.TextError = "Add Person completed successfuly\n";
                result.IsSuccessfully = true;
                var personForAdd = new Person(personDataForAdd);

                if (personDataForAdd is not null)
                    Persons.Add(personForAdd);
            }
            return result;
        }

        public Result<bool> DeletePerson(Guid personId)
        {
            var result = new Result<bool>() { Payload = false };
            var PersonForDelete = Persons.FirstOrDefault(x => x.Id.Equals(personId));
            if(PersonForDelete is null)
            {
                result.TextError += "Error. Person is not found\n";
                result.Error = ErrorStatus.NotFound;

            }
            else
            {
                result.Payload = true;
                result.TextError += "Delete person completed succesfuly\n";
                Persons.Remove(PersonForDelete);
            }
            return result;
        }

        public Result<bool> EditPerson(EditPersonDto dataForEdit)
        {
            var result = new Result<bool>() { Payload = false };
            var personForEdit = Persons.FirstOrDefault(x => x.Id == dataForEdit.Id);
            if (personForEdit is null)
            {
                result.Error = ErrorStatus.NotFound;
                result.TextError += "Error. Person is not found\n";
            }
            else
            {
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

                result.TextError = "Edit person completed successful\n";
                result.IsSuccessfully = true;
                result.Payload = true;
            }
            return result;
        }


        private bool ErrorOrNO(string dataForCheck, ref string textError, string nameFiel)
        {
            if(string.IsNullOrEmpty(dataForCheck.ToString()))
            {
                textError += $"{nameFiel} is empty\n";
                return false;
            }
            return true;
        }
    }
}
