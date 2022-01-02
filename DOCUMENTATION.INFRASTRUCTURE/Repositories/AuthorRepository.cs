using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DOCUMENTATION.INFRASTRUCTURE.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _dbContext;

        public AuthorRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Author> AddAsync(Author author)
        {
            var authorCreate = await _dbContext.Authors.AddAsync(author);

            await _dbContext.SaveChangesAsync();

            return authorCreate.Entity;
        }

        public async Task<Author> GetIdAsync(int Id)
        {
            var author = await _dbContext
                   .Authors
                   .Include(t => t.Topics)
                   .Include(a => a.Articles)
                   .FirstOrDefaultAsync(t => t.Id == Id && t.DateDeleted.HasValue == false);

            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            var authorUpdate = _dbContext.Authors.Update(author);

            await _dbContext.SaveChangesAsync();

            return authorUpdate.Entity;
        }
    }
}