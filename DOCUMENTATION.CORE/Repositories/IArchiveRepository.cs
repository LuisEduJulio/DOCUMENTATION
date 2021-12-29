using DOCUMENTATION.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOCUMENTATION.CORE.Repositories
{
    public interface IArchiveRepository
    {
        Task<Archive> AddAsync(Archive archive);

        Task<List<Archive>> GetIdAsync(int Id);
    }
}