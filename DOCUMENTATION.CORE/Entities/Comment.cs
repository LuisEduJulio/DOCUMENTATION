using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DOCUMENTATION.CORE.Entities
{
    public class Comment : BaseEntity
    {
        public Comment(string description, int articleId, int authorId)
        {
            Description = description;
            ArticleId = articleId;
            AuthorId = authorId;
            DateCreation = DateTime.Now;

            Records = new List<Record>();
        }

        public Comment()
        { }

        public string Description { get; set; }
        public int ArticleId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Article Article { get; set; }

        public int AuthorId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }

        [NotMapped]
        public virtual List<Record> Records { get; set; }
    }
}