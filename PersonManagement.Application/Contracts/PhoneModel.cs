using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class PhoneModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PersonId { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
