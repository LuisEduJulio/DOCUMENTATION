using DOCUMENTATION.CORE.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOCUMENTATION.CORE.Entities
{
    public class Author : BaseEntity
    {
        public Author(string name, string description, EAvatar eAvatar)
        {
            Name = name;
            Description = description;
            Admin = false;
            EAvatar = eAvatar;

            Articles = new List<Article>();
            Topics = new List<Topic>();
            Comments = new List<Comment>();
            Records = new List<Record>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Admin { get; set; }
        public EAvatar EAvatar { get; set; }
        [NotMapped]
        public virtual List<Article> Articles { get; set; }
        [NotMapped]
        public virtual List<Topic> Topics { get; set; }
        [NotMapped]
        public virtual List<Comment> Comments { get; set; }
        [NotMapped]
        public virtual List<Record> Records { get; set; }
    }
}
