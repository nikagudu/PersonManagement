using AutoMapper;
using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Mapping
{
    public class PhoneMappingProfile : Profile
    {
        public PhoneMappingProfile() 
        {
            CreateMap<PhoneModel, Phone>();
            CreateMap<Phone, PhoneModel>();
        }
    }
}
