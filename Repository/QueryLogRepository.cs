using Contracts;
using Entities;
using Entities.Models;
using Entities.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Repository
{
    public class QueryLogRepository : IQueryLogRepository
    {
        private readonly DatabaseContext _databaseContext;

        public QueryLogRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<QueryLogDTO> Get()
        {
            var dtos = from q in _databaseContext.QueryLogs select new QueryLogDTO() 
            { 
                Id = q.Id, 
                Description = q.Description, 
                TimeStamp = q.TimeStamp 
            };

            return dtos;
        }

        public QueryLogDTO Get(int id)
        {
            if (!QueryLogExists(id)) { return null; }

            var query = _databaseContext.QueryLogs.SingleOrDefaultAsync(q => q.Id == id).Result;
            
            QueryLogDTO dto = new() { 
                Id = query.Id, 
                Description = query.Description, 
                TimeStamp = query.TimeStamp 
            };

            return dto;
        }

        public async void Update(int id, string description)
        {
            if (!QueryLogExists(id))
            {
                throw new NotImplementedException();
            }

            QueryLog querylog = await _databaseContext.QueryLogs.SingleOrDefaultAsync(x => x.Id == id);

            querylog.Description = description;

            _databaseContext.Entry(querylog).Property(q => q.Description).IsModified = true;
            // _databaseContext.Entry(queryLog).State = EntityState.Modified;

            try
            {
                await _databaseContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async void Post(QueryLog queryLog)
        {
            if (queryLog == null)
            {
                throw new ArgumentNullException(nameof(queryLog));
            }

            try
            {
                await _databaseContext.QueryLogs.AddAsync(queryLog);
                await _databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        public async void Delete(int id)
        {
            QueryLog queryLog = await _databaseContext.QueryLogs.SingleOrDefaultAsync(x => x.Id == id);

            if(queryLog == null)
            {
                throw new NotImplementedException();
            }

            if (!QueryLogExists(id))
            {
                throw new NotImplementedException();
            }

            try
            {
                _databaseContext.Remove(queryLog);
                await _databaseContext.SaveChangesAsync();
            }
            catch
            {
                throw new DbUpdateException();
            }
        }

        private bool QueryLogExists(int id)
        {
            return _databaseContext.QueryLogs.Any(q => q.Id == id);
        }
    }
}
