using Contracts;
using Entities.Models;
using Entities.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DataUSA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryLogController : ControllerBase
    {
        private readonly IQueryLogRepository _repo;

        public QueryLogController(IQueryLogRepository queryLogRepository)
        {
            _repo = queryLogRepository;
        }

        // GET: api/<DataController>
        [HttpGet]
        public IQueryable<QueryLogDTO> Get()
        {
            return _repo.Get();
        }

        // GET api/<DataController>/5
        [HttpGet("{id}")]
        public QueryLogDTO Get(int id)
        {
            return _repo.Get(id);
        }

        // POST api/<DataController>
        [HttpPost]
        public void Post(string description)
        {
            QueryLog queryLog = new(description); 
            _repo.Post(queryLog);
        }

        // PUT api/<DataController>/5
        [HttpPut("{id}")]
        public void Put(int id, string description)
        {
            _repo.Update(id, description);
        }

        // DELETE api/<DataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _repo.Delete(id);
        }

    }
}
