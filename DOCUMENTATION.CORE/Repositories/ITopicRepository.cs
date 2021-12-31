using DOCUMENTATION.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOCUMENTATION.CORE.Repositories
{
    public interface ITopicRepository
    {
        Task<Topic> AddAsync(Topic topic);

        Task<List<Topic>> GetAllAsync();

        Task<Topic> GetIdAsync(int Id);

        Task<Topic> UpdateAsync(Topic topic);
    }
}