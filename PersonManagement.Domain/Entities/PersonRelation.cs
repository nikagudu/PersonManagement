using System;
using System.Collections.Generic;
using System.Text;
using PersonManagement.Domain.Enums;

namespace PersonManagement.Domain.Entities
{
    public class PersonRelation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int RelatedPersonId { get; set; }
        public Person RelatedPerson { get; set; }
        public PersonRelationType PersonRelationType { get; set; }
    }
}
