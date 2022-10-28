using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.DTO
{
    internal class ResponseDTO
    {
        public string State { get; set; }
        public int IDYear { get; set; }
        public string Year { get; set; }
        public int Population { get; set; }
    }
}
