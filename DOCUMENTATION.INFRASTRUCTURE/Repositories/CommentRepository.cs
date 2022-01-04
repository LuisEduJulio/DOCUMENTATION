using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DOCUMENTATION.INFRASTRUCTURE.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Comment> AddAsync(Comment comment)
        {
            var commentCreate = await _dbContext.Comments.AddAsync(comment);

            await _dbContext.SaveChangesAsync();

            return commentCreate.Entity;
        }

        public async Task<Comment> GetIdAsync(int Id)
        {
            var comment = await _dbContext
                   .Comments
                   .Include(a => a.Author)
                   .FirstOrDefaultAsync(t => t.Id == Id && t.DateDeleted.HasValue == false);

            return comment;
        }

        public async Task<Comment> UpdateAsync(Comment comment)
        {
            var commentUpdate = _dbContext.Comments.Update(comment);

            await _dbContext.SaveChangesAsync();

            return commentUpdate.Entity;
        }
    }
}
