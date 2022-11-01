using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataUSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseController : ControllerBase
    {
        readonly HttpClient client = new();

        // GET: api/<ResponseController>
        [HttpGet]
        public async Task<Response> Get(bool latest)
        {
            string url = "https://datausa.io/api/data?measure=Population&drilldowns=State";

            if (latest)
            {
                url += "&year=latest";
            }

            var res = await client.GetAsync(url);
            res.EnsureSuccessStatusCode();
            string resContent = await res.Content.ReadAsStringAsync();
            var Response = JsonConvert.DeserializeObject<Response>(resContent);

            return Response;
        }

        // GET api/<ResponseController>/2020
        [HttpGet("{year}")]
        public async Task<Response> Get(int year)
        {
            var res = await client.GetAsync($"https://datausa.io/api/data?measure=Population&drilldowns=State&year={year}");
            res.EnsureSuccessStatusCode();
            string resContent = await res.Content.ReadAsStringAsync();
            var Response = JsonConvert.DeserializeObject<Response>(resContent);

            return JsonConvert.DeserializeObject<Response>(resContent);

            // var Response = JsonConvert.DeserializeObject<Response>(await res.Content.ReadAsStringAsync());
            //return Response;
        }
    }
}
