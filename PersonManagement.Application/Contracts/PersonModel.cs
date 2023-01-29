using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class PersonModel
    {
        public PersonModel()
        {
            this.Phones = new List<PhoneModel>();
            this.PersonRelations = new List<PersonRelationModel>();
            this.RelatedPersons = new List<PersonRelationModel>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityID { get; set; }
        public string? ImagePath { get; set; }
        public Gender Gender { get; set; }
        public byte[]? ImageData { get; set; }
        public List<PhoneModel> Phones { get; set; }
        public List<PersonRelationModel> RelatedPersons { get; set; }
        public List<PersonRelationModel> PersonRelations { get; set; }
    }
}
