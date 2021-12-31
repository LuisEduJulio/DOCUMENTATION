using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOCUMENTATION.INFRASTRUCTURE.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        public ArticleRepository()
        {
        }

        public Task<Article> AddAsync(Article archive)
        {
            throw new NotImplementedException();
        }

        public Task<List<Article>> GetIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}