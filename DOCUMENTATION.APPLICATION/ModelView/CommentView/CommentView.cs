using System;

namespace DOCUMENTATION.APPLICATION.ModelView.CommentView
{
    public class CommentView
    {
        public CommentView(string description, int authorId, int articleId, DateTime dateCreation)
        {
            Description = description;
            AuthorId = authorId;
            ArticleId = articleId;
            DateCreation = dateCreation;
        }

        public string Description { get; set; }
        public int ArticleId { get; set; }
        public int AuthorId { get; set; }
        public DateTime DateCreation { get; set; }
    }
}