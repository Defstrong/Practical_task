﻿using Practice_Problem.Enums;
namespace Practice_Problem.Interfaces
{
    public abstract class IPersonData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string AboutPerson { get; set; }
        public PersonDuty? Duty { get; set; } = null;
        public PersonFloor? Floor { get; set; }
    }
}
