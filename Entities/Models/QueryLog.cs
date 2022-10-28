using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    internal class QueryLog
    {
        public int Id { get; init; }
        public string Description { get; private set; }
        public DateTime TimeStamp { get; init; } = DateTime.Now;

        public QueryLog(string description)
        {
            Description = description;
        }
    }
}
