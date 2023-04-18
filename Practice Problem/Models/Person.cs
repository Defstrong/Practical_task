using Practice_Problem.Interfaces;
using Practice_Problem.DTO;
using Practice_Problem.Services;
using Practice_Problem.Enums;

namespace Practice_Problem.Models
{
    sealed class Person : IPersonData
    {
        public Guid Id { get; set; }
        public Person(PersonData personData)
        {
            FirstName = personData.FirstName;
            LastName = personData.LastName;
            Age = DeterminationOfAge.AgeDetermination(personData.DateOfBirth);
            Address = personData.Address;
            City = personData.City;
            Region = personData.Region;
            Floor = personData.Floor;
            Duty = Duty;
            Id = Guid.NewGuid();
        }
        public override string ToString() =>
            $"\nFirst Name: {FirstName} \nLast Name: {LastName} \nAge: {Age} " +
                $"\nAddress: {Address} \nCity: {City} \nRegion: " +
                $"{Region} \nFloor: {Floor}\nAbout Person: {AboutPerson}\n\n";
    }
}
