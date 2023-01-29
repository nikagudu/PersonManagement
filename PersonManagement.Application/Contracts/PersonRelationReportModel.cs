using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.Application.Contracts
{
    public class PersonRelationReportModel
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Relation { get; set; }
        public int RelationCount { get; set; }
    }
}
