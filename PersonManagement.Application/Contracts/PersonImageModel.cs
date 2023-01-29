using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class PersonImageModel
    {
        public int PersonId { get; set; }
        public byte[] ImageData { get; set; }
    }
}
