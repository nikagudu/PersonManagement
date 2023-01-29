using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PersonManagement.Application.Contracts;
using PersonManagement.Application.Interfaces;
using PersonManagement.Domain.Common;
using PersonManagement.Domain.Entities;
using PersonManagement.Infrastructure.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Infrastructure.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {

        public PersonRepository(PersonsDbContext context) : base(context)
        {

        }

        public async Task<Person> GetDetailsById(int id)
        {
            var result = await _context.Set<Person>().Include(s => s.PersonRelations)
                .ThenInclude(s => s.RelatedPerson)
                  .Include(s => s.City)
                  .Include(s => s.Phones)
                .FirstOrDefaultAsync(s => s.Id == id);

            return result;
        }


        public override void Update(Person entity)
        {
            var updatingPerson = _context.Set<Person>().Include(s => s.Phones).First(s => s.Id == entity.Id);
            updatingPerson.FirstName = entity.FirstName;
            updatingPerson.LastName = entity.LastName;
            updatingPerson.PersonalNumber = entity.PersonalNumber;
            updatingPerson.Gender = entity.Gender;
            updatingPerson.CityID= entity.CityID;
            updatingPerson.DateOfBirth= entity.DateOfBirth;
            _context.Set<Phone>().RemoveRange(updatingPerson.Phones);
            updatingPerson.Phones = entity.Phones;

        }

        public async Task<PagedListItems<Person>> GetAllByFilter(PersonFilter personFilter)
        {
            var result = new PagedListItems<Person>();

            var personsQuery = _context.Set<Person>().AsQueryable();

            if (!string.IsNullOrEmpty(personFilter.FirstName))
            {
                personsQuery = personsQuery.Where(s => s.FirstName.Contains(personFilter.FirstName));
            }
            if (!string.IsNullOrEmpty(personFilter.LastName))
            {
                personsQuery = personsQuery.Where(s => s.LastName.Contains(personFilter.LastName));
            }
            if (!string.IsNullOrEmpty(personFilter.PersonalNumber))
            {
                personsQuery = personsQuery.Where(s => s.PersonalNumber.Contains(personFilter.PersonalNumber));
            }
            if (personFilter.CityID != null && personFilter.CityID > 0)
            {
                personsQuery = personsQuery.Where(s => s.CityID == personFilter.CityID);
            }
            if (personFilter.Gender != null && personFilter.Gender > 0)
            {
                personsQuery = personsQuery.Where(s => s.Gender == personFilter.Gender);
            }

            result.TotalCount = personsQuery.Count();
            result.Items = await personsQuery.Skip((personFilter.page - 1) * personFilter.pageSize)
                .Take(personFilter.pageSize).ToListAsync();

            return result;
        }
    }
}
