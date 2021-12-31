using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Topic>> GetAllAsync()
        {
            return await _dbContext
                .Topics
                .Where(t => t.DateDeleted.HasValue == false)
                .ToListAsync();
        }

        public async Task<Topic> GetIdAsync(int Id)
        {
            var topic = await _dbContext
                .Topics
                .Include(s => s.Topics)
                .FirstOrDefaultAsync(t => t.Id == Id && t.DateDeleted.HasValue == false);
                          

            return topic;
        }

        public async Task<Topic> UpdateAsync(Topic topic)
        {
            var topicUpdate = _dbContext.Topics.Update(topic);

            await _dbContext.SaveChangesAsync();

            return topicUpdate.Entity;
        }
    }
}