using DOCUMENTATION.CORE.Entities;
using DOCUMENTATION.CORE.Repositories;
using DOCUMENTATION.INFRASTRUCTURE.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DOCUMENTATION.INFRASTRUCTURE.Repositories
{
    public class RecordRepository : IRecordRepository
    {
        private readonly AppDbContext _dbContext;
        private readonly IDistributedCache _distributedCache;
        private readonly string KEY = "RECORDS";

        public RecordRepository(AppDbContext dbContext, IDistributedCache distributedCache)
        {
            _dbContext = dbContext;
            _distributedCache = distributedCache;
        }

        public async Task<Record> AddAsync(Record record)
        {
            var topicCreate = await _dbContext.Records.AddAsync(record);

            await _dbContext.SaveChangesAsync();

            await _distributedCache.RemoveAsync(KEY);

            return topicCreate.Entity;
        }

        public async Task<List<Record>> GetAllAsync()
        {
            var recordCache = await _distributedCache.GetStringAsync(KEY);

            if (!string.IsNullOrWhiteSpace(recordCache))
            {
                return JsonConvert.DeserializeObject<List<Record>>(recordCache, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            else
            {
                var topics = await _dbContext
                    .Records
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

                await _distributedCache.SetStringAsync(KEY, json, memoryCacheEntryOptions);

                return topics;
            }
        }
    }
}