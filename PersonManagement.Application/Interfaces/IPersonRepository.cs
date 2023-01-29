using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using PersonManagement.Domain.Common;

namespace PersonManagement.Application.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        Task<Person> GetDetailsById(int id);
        Task<PagedListItems<Person>> GetAllByFilter(PersonFilter personFilter);
    }
}
