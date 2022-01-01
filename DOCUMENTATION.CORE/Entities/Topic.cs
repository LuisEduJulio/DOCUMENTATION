using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOCUMENTATION.CORE.Entities
{
    public class Topic : BaseEntity
    {
        public Topic(string title, string description, int authorId, int? topicId)
        {
            Title = title;
            Description = description;
            TopicId = topicId;
            DateCreation = DateTime.Now;
            AuthorId = authorId;

            Topics = new List<Topic>();
            Articles = new List<Article>();
        }

        public Topic()
        {            
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int? TopicId { get; set; }
        [NotMapped]
        public virtual List<Topic> Topics { get; set; }
        [NotMapped]
        public virtual List<Article> Articles { get; set; }
        public int AuthorId { get; set; }
        [NotMapped]
        public virtual Author Author { get; set; }
        [NotMapped]
        public virtual List<Record> Records { get; set; }
    }
}