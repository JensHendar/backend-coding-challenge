using System;

namespace Repository
{
    public class RepositoryService
    {
        private IRepository _repository;

        public RepositoryService(IRepository repository)
        {
            _repository = repository;
        }
    }
}
