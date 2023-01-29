using AutoMapper;
using PersonManagement.Application.Contracts;
using PersonManagement.Application.Interfaces;
using PersonManagement.Domain.Entities;
using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Application.Services
{
    public class PersonRelationService :IPersonRelationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PersonRelationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork;
            _mapper= mapper;
        }

        public async Task Add(PersonRelationModel personRelationModel)
        {
            var personRelation = _mapper.Map<PersonRelation>(personRelationModel);

            if (!_unitOfWork.PersonRelationRepository.IsDuplicate(personRelation))
            {
                await _unitOfWork.PersonRelationRepository.AddAsync(personRelation);
                await _unitOfWork.SaveChangesAsync();
            }  
        }

        public async Task Delete(int Id)
        {
            var presonRelation = await _unitOfWork.PersonRelationRepository.GetByIdAsync(Id);
            if (presonRelation != null)
            {
                _unitOfWork.PersonRelationRepository.Delete(presonRelation);
                await _unitOfWork.SaveChangesAsync();
            }           
        }

        public async Task<IEnumerable<PersonRelationReportModel>> GetPersonRelationReport()
        {
            var personRelations = await _unitOfWork.PersonRelationRepository.GetAllAsync();

            var result = new List<PersonRelationReportModel>();

            foreach (PersonRelationType item in Enum.GetValues(typeof(PersonRelationType)))
            {               
                var dt = personRelations.Where(s => s.PersonRelationType == item)
                    .GroupBy(s => s.PersonId)
                    .Select(s => new PersonRelationReportModel()
                    {                       
                        PersonId = s.Key,
                        Relation = Enum.GetName(typeof(PersonRelationType), item),
                        RelationCount = s.Count()
                    }).ToList();

                result.AddRange(dt);
            }

            foreach (var item in result)
            {
                var person = await _unitOfWork.PersonRepository.GetByIdAsync(item.PersonId);
                item.Name = $"{person.FirstName} {person.LastName}";
            }

            return result;
        }
    }
}
