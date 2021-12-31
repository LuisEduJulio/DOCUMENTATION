using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
        }

        public string Description { get; set; }
        [NotMapped]
        public virtual Article Article { get; set; }
        public int ArticleId { get; set; }
        [NotMapped]
        public virtual Author Author { get; set; }
        public int AuthorId { get; set; }
        [NotMapped]
        public virtual List<Record> Records { get; set; }

    }
}
