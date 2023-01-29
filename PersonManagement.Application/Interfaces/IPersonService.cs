using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Common;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Application.Interfaces
{
    public interface IPersonService 
    {

        Task<PersonModel> GetPersonDetails(int id);
        Task Add(CreatePersonModel person);
        Task Update(UpdatePersonModel person);
        Task Delete(int id);
        Task UploadPersonImage(PersonImageModel personImageModel);
        Task<PagedListItems<PersonModel>> GetPersonFilteredList(PersonFilter personFilter);
    }
}
