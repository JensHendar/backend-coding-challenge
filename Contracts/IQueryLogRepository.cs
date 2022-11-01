using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Entities.Models.DTO;

namespace Contracts
{
    public interface IQueryLogRepository
    {
        IQueryable<QueryLogDTO> Get();

        QueryLogDTO Get(int id);

        void Post(QueryLog queryLog);

        void Update(int id, string description);

        void Delete(int id);
    }
}
