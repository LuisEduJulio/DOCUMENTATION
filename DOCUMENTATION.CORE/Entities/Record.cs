using DOCUMENTATION.CORE.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DOCUMENTATION.CORE.Entities
{
    public class Record : BaseEntity
    {
        public string Description { get; set; }
        public int? TopicId { get; set; }
        public EStatusRecord EStatusRecord { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Topic Topic { get; set; }

        public int? ArticleId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Article Article { get; set; }

        public int? CommentId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Comment Comment { get; set; }

        public int AuthorId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Author Author { get; set; }
    }
}