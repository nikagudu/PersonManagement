using AutoMapper;
using PersonManagement.Application.Contracts;
using PersonManagement.Domain.Common;
using PersonManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Mapping
{
    public class PagedListItemsMappingProfile : Profile
    {
        public PagedListItemsMappingProfile()
        {
            CreateMap<PagedListItems<Person>, PagedListItems<PersonModel>>();
            CreateMap<PagedListItems<PersonModel>, PagedListItems<Person>>();
        }
    }
}
