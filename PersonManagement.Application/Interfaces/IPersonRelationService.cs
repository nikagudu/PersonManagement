using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Application.Interfaces
{
    public interface IPersonRelationService
    {
        Task Add(PersonRelationModel personRelation);
        Task Delete(int Id);
        Task<IEnumerable<PersonRelationReportModel>> GetPersonRelationReport();
    }
}
