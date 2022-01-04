using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DOCUMENTATION.CORE.Entities
{
    public class Article : BaseEntity
    {
        public Article(string title, string description, int authorId, int topicId)
        {
            Title = title;
            Description = description;
            TopicId = topicId;
            AuthorId = authorId;
            DateCreation = DateTime.Now;

            Comments = new List<Comment>();
            Records = new List<Record>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Topic Topic { get; set; }

        public int AuthorId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual List<Comment> Comments { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual List<Record> Records { get; set; }
    }
}