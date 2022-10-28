using Newtonsoft.Json;
using System;

namespace Entities.Models
{
    public class Response
    {
        public Data[] data { get; set; }
        public class Data
        {
            [JsonProperty("ID State")]
            public string IDState { get; set; }
            public string State { get; set; }
            [JsonProperty("ID Year")]
            public int IDYear { get; set; }
            public string Year { get; set; }
            public int Population { get; set; }
            [JsonProperty("Slug State")]
            public string SlugState { get; set; }
        }
    }
}
