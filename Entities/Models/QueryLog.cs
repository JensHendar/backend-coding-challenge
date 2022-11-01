using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class QueryLog
    {
        [Key]
        public int Id { get; init; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; init; } = DateTime.Now;

        public QueryLog(string description)
        {
            Description = description;
        }
    }
}
