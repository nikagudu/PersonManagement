using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class PersonRelationModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public PersonRelationType? PersonRelationType { get; set; }
    }
}
