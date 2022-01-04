using DOCUMENTATION.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOCUMENTATION.CORE.Repositories
{
    public interface IRecordRepository
    {
        Task<Record> AddAsync(Record record);

        Task<List<Record>> GetAllAsync();
    }
}