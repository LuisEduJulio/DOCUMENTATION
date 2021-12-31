using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOCUMENTATION.CORE.Entities
{
    public class Record : BaseEntity
    {
        public Record(string description, int topicId , int articleId, int commentId, int authorId)
        {
            Description = description;
            ArticleId = articleId;
            TopicId = topicId;
            CommentId = commentId;
            AuthorId = authorId;
            DateCreation = DateTime.Now;
        }

        public string Description { get; set; }
        public int TopicId { get; set; }
        [NotMapped]
        public virtual Topic Topic { get; set; }
        
        public int ArticleId { get; set; }
        [NotMapped]
        public virtual Article Article { get; set; }
       
        public int CommentId { get; set; }
        [NotMapped]
        public virtual Comment Comment { get; set; }
       
        public int AuthorId { get; set; }
        [NotMapped]
        public virtual Author Author { get; set; }
       
    }
}
