using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _context;
        private IQueryLogRepository _queryLogRepository;

        public IQueryLogRepository QueryLogs
        {
            get { 
                _queryLogRepository ??= new QueryLogRepository(_context);
                return _queryLogRepository; }
        }

        public RepositoryWrapper(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public async void Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
