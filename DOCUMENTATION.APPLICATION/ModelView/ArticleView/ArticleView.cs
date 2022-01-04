using System;

namespace DOCUMENTATION.APPLICATION.ModelView.ArticleView
{
    public class ArticleView
    {
        public ArticleView(string title, string description, int authorId, int topicId, DateTime dateCreation)
        {
            Title = title;
            Description = description;
            TopicId = topicId;
            AuthorId = authorId;
            DateCreation = dateCreation;
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int TopicId { get; set; }
        public int AuthorId { get; set; }
        public DateTime DateCreation { get; set; }
    }
}