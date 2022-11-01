using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    public class ResponseDTO
    {
        public string State { get; set; }
        public int Year { get; set; }
        public int Population { get; set; }
    }
}
