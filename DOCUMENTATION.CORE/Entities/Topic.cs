using System;
using System.Collections.Generic;

namespace DOCUMENTATION.CORE.Entities
{
    public class Topic : BaseEntity
    {
        public Topic(string title, string description, int topicId, DateTime dateCreation)
        {
            Title = title;
            Description = description;
            TopicId = topicId;
            DateCreation = dateCreation;

            Topics = new List<Topic>();
            Archives = new List<Archive>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public List<Topic> Topics { get; set; }
        public List<Archive> Archives { get; set; }
    }
}