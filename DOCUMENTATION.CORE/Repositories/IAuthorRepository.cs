using DOCUMENTATION.CORE.Entities;
using System.Threading.Tasks;

namespace DOCUMENTATION.CORE.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> AddAsync(Author author);

        Task<Author> UpdateAsync(Author author);

        Task<Author> GetIdAsync(int Id);
    }
}