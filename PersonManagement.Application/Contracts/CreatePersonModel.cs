using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class CreatePersonModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityID { get; set; }
        public Gender Gender { get; set; }
        public List<PhoneModel> Phones { get; set; }
    }
}
