using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Interfaces
{
    public interface IPersonRelationRepository : IRepository<PersonRelation>
    {
        bool IsDuplicate(PersonRelation personRelation);
    }
}
