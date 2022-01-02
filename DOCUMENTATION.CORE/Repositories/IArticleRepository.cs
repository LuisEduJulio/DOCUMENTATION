using DOCUMENTATION.CORE.Entities;
using System.Threading.Tasks;

namespace DOCUMENTATION.CORE.Repositories
{
    public interface IArticleRepository
    {
        Task<Article> AddAsync(Article archive);

        Task<Article> GetIdAsync(int Id);

        Task<Article> UpdateAsync(Article archive);
    }
}