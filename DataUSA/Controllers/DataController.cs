using Contracts;
using Entities;
using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataUSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ResponseController responseController = new();

        private readonly IQueryLogRepository _repo;

        public DataController(IQueryLogRepository queryLogRepository)
        {
            _repo = queryLogRepository;
        }

        // GET: api/<DataController>
        [HttpGet("all")]
        public async Task<IEnumerable<ResponseDTO>> Get(bool latest = false)
        {
            string queryDesc = "Requested all data.";
            PostQueryLog(queryDesc);

            var data = await responseController.Get(latest);

            return from d in data.data
                   select new ResponseDTO()
                   {
                       State = d.State,
                       Population = d.Population,
                       Year = d.IDYear
                   };
        }

        // GET: api/<DataController>/StateComparisoon
        [HttpGet("StateComparison")]
        public async Task<IEnumerable<ResponseDTO>> Get(string state1, string state2, int year = 0, bool latest = true)
        {
            string queryLatest = $"Compared the latest available population data between {state1} and {state2}.";
            string queryYear = $"Compared population data between {state1} and {state2} for year {year}.";
            string queryDesc = year == 0 ? queryLatest : queryYear;
            PostQueryLog(queryDesc);

            string[] states = { state1.ToLower(), state2.ToLower() };
            var data = year == 0 ? await responseController.Get(latest) : await responseController.Get(year);

            return from d in data.data
                   where d.SlugState == state1.ToLower() || d.SlugState == state2.ToLower()
                   select new ResponseDTO()
                   {
                       State = d.State,
                       Population = d.Population,
                       Year = d.IDYear
                   };
        }

        // GET api/<DataController>/Texas
        [HttpGet("{state}")]
        public async Task<IEnumerable<ResponseDTO>> Get(string state, int year = 0)
        {
            string queryYear = $"Requested population data for {state} for the year {year}.";
            string queryLatest = $"Requested the latest available population data for {state}.";
            string queryDesc = year == 0 ? queryLatest : queryYear;
            PostQueryLog(queryDesc);

            var data = year == 0 ? await responseController.Get(true) : await responseController.Get(year);

            return (from d in data.data
                    where d.SlugState == state.ToLower()
                    select new ResponseDTO()
                    {
                        State = d.State,
                        Population = d.Population,
                        Year = d.IDYear
                    }).OrderBy(x => x.Year);

            //return dtos.OrderBy(x => x.Year);
        }

        // GET: api/<DataController>/Biggest
        [HttpGet("Size")]
        public async Task<ResponseDTO> Get(string type, bool latest = true, int year = 0)
        {
            try
            {
                string typeOfSearch = type.ToLower() == "biggest" ? "largest population" : "smallest population";
                string queryDesc = $"Requested population data for the state with the {typeOfSearch}";
                queryDesc += year == 0 ? " in the latest available year." : $" in year {year}.";
                PostQueryLog(queryDesc);

                Response.Data response = null;

                var data = year == 0 ? await responseController.Get(latest) : await responseController.Get(year);

                if (type.ToLower() == "biggest")
                {
                    response = data.data.OrderByDescending(x => x.Population).FirstOrDefault();
                }
                else if (type.ToLower() == "smallest")
                {
                    response = data.data.OrderBy(x => x.Population).FirstOrDefault();
                }

                return new ResponseDTO() { State = response.State, Population = response.Population, Year = response.IDYear };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: api/<DataController>/StateHistory
        [HttpGet("StateHistory")]
        public async Task<IEnumerable<ResponseDTO>> Get(string state, int startYear = 2013, int endYear = 2020)
        {
            string queryDesc = $"Requested population data for {state} betweend year {startYear} and {endYear}";
            PostQueryLog(queryDesc);

            var data = await responseController.Get(false);

            return (from d in data.data
                    where d.SlugState == state.ToLower()
                    && d.IDYear == startYear
                    && d.IDYear == endYear
                    select new ResponseDTO()
                    {
                        State = d.State,
                        Population = d.Population,
                        Year = d.IDYear
                    }).OrderBy(x => x.Year);
        }

        private void PostQueryLog(string description)
        {
            QueryLog query = new(description);
            _repo.Post(query);
        }
    }
}
