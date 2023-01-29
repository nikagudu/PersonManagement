using AutoMapper;
using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Mapping
{
    public class CreatePersonMappingProfile : Profile
    {
        public CreatePersonMappingProfile()
        {
            CreateMap<CreatePersonModel, Person>();
            CreateMap<Person, CreatePersonModel>();
        }
    }
}
