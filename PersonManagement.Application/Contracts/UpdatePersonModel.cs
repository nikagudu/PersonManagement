using PersonManagement.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class UpdatePersonModel : CreatePersonModel
    {
        public int Id { get; set; }
        public string? ImagePath { get; set; }
    }
}
