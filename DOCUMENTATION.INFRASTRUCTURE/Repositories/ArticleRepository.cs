using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DOCUMENTATION.INFRASTRUCTURE.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbContext _dbContext;

        public ArticleRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Article> AddAsync(Article archive)
        {
            var articleCreate = await _dbContext.Articles.AddAsync(archive);

            await _dbContext.SaveChangesAsync();

            return articleCreate.Entity;
        }

        public async Task<Article> GetIdAsync(int Id)
        {
            var article = await _dbContext
                   .Articles
                   .Include(t => t.Topic)
                   .Include(a => a.Author)
                   .FirstOrDefaultAsync(t => t.Id == Id && t.DateDeleted.HasValue == false);

            return article;
        }

        public async Task<Article> UpdateAsync(Article archive)
        {
            var authorUpdate = _dbContext.Articles.Update(archive);

            await _dbContext.SaveChangesAsync();

            return authorUpdate.Entity;
        }
    }
}