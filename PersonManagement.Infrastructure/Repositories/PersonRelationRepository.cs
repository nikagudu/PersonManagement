using Microsoft.EntityFrameworkCore;
using PersonManagement.Application.Interfaces;
using PersonManagement.Domain.Entities;
using PersonManagement.Infrastructure.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.Repositories
{
    public class PersonRelationRepository : Repository<PersonRelation>, IPersonRelationRepository
    {
        public PersonRelationRepository(PersonsDbContext context) : base(context)
        {
        }

        public bool IsDuplicate(PersonRelation personRelation)
        {

            return _context.Set<PersonRelation>().Where(s => s.PersonId == personRelation.PersonId
                                        && s.RelatedPersonId == personRelation.RelatedPersonId).ToList().Count > 0;
        }

    }
}
