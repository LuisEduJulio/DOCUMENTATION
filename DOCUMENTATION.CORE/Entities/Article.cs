using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOCUMENTATION.CORE.Entities
{
    public class Article : BaseEntity
    {
        public Article( string title, string description, int topicId)
        {
            Title = title;
            Description = description;
            TopicId = topicId;
            DateCreation = DateTime.Now;

            Comments = new List<Comment>();
        }

        public string Title { get; set; }
        public string Description { get; set; }       
        public int TopicId { get; set; }
        [NotMapped]
        public virtual Topic Topic { get; set; }
        [NotMapped]
        public virtual List<Comment> Comments { get; set; }
        public int AuthorId { get; set; }
        [NotMapped]
        public virtual Author Author { get; set; }
        [NotMapped]
        public virtual List<Record> Records { get; set; }
    }
}