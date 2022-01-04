using DOCUMENTATION.CORE.Entities;
using System.Threading.Tasks;

namespace DOCUMENTATION.CORE.Repositories
{
    public interface ICommentRepository
    {
        Task<Comment> AddAsync(Comment comment);

        Task<Comment> UpdateAsync(Comment comment);

        Task<Comment> GetIdAsync(int Id);
    }
}