using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
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
        private readonly IDistributedCache _distributedCache;
        private readonly string KEY_TOPIC = "TOPICS";

        public TopicRepository(AppDbContext dbContext, IConfiguration configuration, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _distributedCache = distributedCache;
        }

        public async Task<Topic> AddAsync(Topic topic)
        {
            var topicCreate = await _dbContext.Topics.AddAsync(topic);

            await _dbContext.SaveChangesAsync();

            await _distributedCache.RemoveAsync(KEY_TOPIC);

            return topicCreate.Entity;
        }

        public async Task<List<Topic>> GetAllAsync()
        {
            var topicCache = await _distributedCache.GetStringAsync(KEY_TOPIC);

            if (!string.IsNullOrWhiteSpace(topicCache))
            {
                return JsonConvert.DeserializeObject<List<Topic>>(topicCache, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else
            {
                var topics = await _dbContext
                    .Topics
                    .Where(t => t.DateDeleted.HasValue == false)
                    .ToListAsync();

                var memoryCacheEntryOptions = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                    SlidingExpiration = TimeSpan.FromSeconds(1200)
                };

                var json = JsonConvert.SerializeObject(topics, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

                await _distributedCache.SetStringAsync(KEY_TOPIC, json, memoryCacheEntryOptions);

                return topics;
            }
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

            await _distributedCache.RemoveAsync(KEY_TOPIC);

            return topicUpdate.Entity;
        }
    }
}