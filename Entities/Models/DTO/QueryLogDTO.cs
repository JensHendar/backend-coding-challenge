using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class QueryLogDTO
    {
        public QueryLogDTO()
        {
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
