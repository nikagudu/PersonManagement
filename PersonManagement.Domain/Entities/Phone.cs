using System;
using System.Collections.Generic;
using System.Text;
using PersonManagement.Domain.Enums;

namespace PersonManagement.Domain.Entities
{
    public class Phone
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public PhoneNumberType PhoneNumberType { get; set; }
    }
}
