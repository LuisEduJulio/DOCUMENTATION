using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOCUMENTATION.INFRASTRUCTURE.Repositories
{
    public class ArchiveRepository : IArchiveRepository
    {
        public ArchiveRepository()
        {
        }

        public Task<Archive> AddAsync(Archive archive)
        {
            throw new NotImplementedException();
        }

        public Task<List<Archive>> GetIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}