using AutoMapper;
using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Mapping
{
    public class PersonRelationMappingProfile : Profile
    {
        public PersonRelationMappingProfile()
        {
            CreateMap<PersonRelationModel, PersonRelation>();
            CreateMap<PersonRelation, PersonRelationModel>();
        }
    }
}
