using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Application.Interfaces
{
    public interface IUnitOfWork 
    {
        IPersonRepository PersonRepository { get; set; }
        IPersonRelationRepository PersonRelationRepository { get; set; }
        Task SaveChangesAsync();
    }
}
