using System;
using System.Collections.Generic;
using System.Text;
using PersonManagement.Domain.Enums;

namespace PersonManagement.Domain.Entities
{
    public class Person
    {
        public Person()
        {
            this.Phones = new HashSet<Phone>();
            this.RelatedPersons = new HashSet<PersonRelation>();
            this.PersonRelations= new HashSet<PersonRelation>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? CityID { get; set; }
        public string? ImagePath { get; set; }     
        public Gender Gender { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<PersonRelation> RelatedPersons { get; set; }
        public virtual ICollection<PersonRelation> PersonRelations { get; set; }
    }
}
