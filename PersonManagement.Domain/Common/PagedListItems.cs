using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonManagement.Domain.Common
{
    public class PagedListItems<T> where T : class
    {
        public int TotalCount { get; set; }
        public IEnumerable<T> Items { get; set; }
    }
}
