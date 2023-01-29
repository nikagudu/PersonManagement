using AutoMapper;
using PersonManagement.Application.Contracts;
using PersonManagement.Application.Interfaces;
using PersonManagement.Domain.Common;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonManagement.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PersonService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PersonModel> GetPersonDetails(int id)
        {
            var personDetails = await _unitOfWork.PersonRepository.GetDetailsById(id);

            var result = _mapper.Map<PersonModel>(personDetails);

            if (!string.IsNullOrEmpty(result.ImagePath) && Directory.Exists(result.ImagePath))
            {
                using (var stream = new FileStream(result.ImagePath, FileMode.Open, FileAccess.Read))
                {
                    using (var binReader = new BinaryReader(stream))
                    {
                        result.ImageData = binReader.ReadBytes((int)stream.Length);
                    }
                }
            }
            return result;
        }

        public async Task Add(CreatePersonModel createPersonModel) 
        {
            var person = _mapper.Map<Person>(createPersonModel);

            await _unitOfWork.PersonRepository.AddAsync(person);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(UpdatePersonModel updatePersonModel)
        {
            var person = _mapper.Map<Person>(updatePersonModel);
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {     
            
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(id);
            if (person != null) 
            {
                var relations = await _unitOfWork.PersonRelationRepository.FindAsync(s => s.RelatedPersonId == id);
                foreach (var item in relations)
                {
                    _unitOfWork.PersonRelationRepository.Delete(item);
                }
                _unitOfWork.PersonRepository.Delete(person);
                await _unitOfWork.SaveChangesAsync();
            }          
        }

        public async Task UploadPersonImage(PersonImageModel personImageModel) 
        {
            var person = await _unitOfWork.PersonRepository.GetByIdAsync(personImageModel.PersonId);
            if (System.IO.File.Exists(person.ImagePath))
            {
                System.IO.File.Delete(person.ImagePath);
            }

            var fileName = $"{person.FirstName}{person.LastName}image.jpg";
            var path = Path.Combine("C:/Users/Gamers.Ge/source/repos/PersonManagement/PersonManagement/PersonImages/", fileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await stream.WriteAsync(personImageModel.ImageData, 0, personImageModel.ImageData.Length);
            }

            person.ImagePath = path;
            _unitOfWork.PersonRepository.Update(person);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedListItems<PersonModel>> GetPersonFilteredList(PersonFilter personFilter)
        {
            var pagedList = await _unitOfWork.PersonRepository.GetAllByFilter(personFilter);
            var result =  _mapper.Map<PagedListItems<PersonModel>>(pagedList);

            return result;
        }

       
    }
}
