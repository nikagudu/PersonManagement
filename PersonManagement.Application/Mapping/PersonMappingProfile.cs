using AutoMapper;
using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Mapping
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile() 
        {
            CreateMap<PersonModel, Person>();
            CreateMap<Person, PersonModel>();
        }
    }
}
