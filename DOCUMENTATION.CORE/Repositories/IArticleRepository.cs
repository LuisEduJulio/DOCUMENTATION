using DOCUMENTATION.CORE.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOCUMENTATION.CORE.Repositories
{
    public interface IArticleRepository
    {
        Task<Article> AddAsync(Article archive);

        Task<List<Article>> GetIdAsync(int Id);
    }
}