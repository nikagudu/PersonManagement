using Microsoft.EntityFrameworkCore;
using PersonManagement.Application.Interfaces;
using PersonManagement.Infrastructure.DataBaseContext;
using PersonManagement.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PersonsDbContext _context;       
        public IPersonRepository PersonRepository { get ; set ; }
        public IPersonRelationRepository PersonRelationRepository { get ; set ; }

        public UnitOfWork(PersonsDbContext context, IPersonRepository personRepository, IPersonRelationRepository personRelationRepository)
        {
            _context = context;
            PersonRepository = personRepository;
            PersonRelationRepository = personRelationRepository;
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }      
    }
}
