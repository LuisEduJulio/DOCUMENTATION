using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DOCUMENTATION.INFRASTRUCTURE.Repositories
{
    public class TopicRepository : ITopicRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public TopicRepository(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public async Task<Topic> AddAsync(Topic topic)
        {
            var topicCreate = await _dbContext.Topics.AddAsync(topic);

            await _dbContext.SaveChangesAsync();

            return topicCreate.Entity;
        }

        public Task<Topic> DeleteAsync(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Task<List<Topic>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Topic> GetIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Topic> UpdateAsync(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}