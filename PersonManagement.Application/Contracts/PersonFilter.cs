using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class PersonFilter
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PersonalNumber { get; set; }
        public int? CityID { get; set; }
        public Gender? Gender { get; set; }
        public int page { get; set; } = 1;
        public int pageSize { get; set; } = 10;

    }
}
